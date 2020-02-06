using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shaman.Roslyn.LinqRewrite
{
    public partial class LinqRewriter : CSharpSyntaxRewriter
    {
        private ExpressionSyntax TryRewrite(string aggregationMethod, ExpressionSyntax collection, ITypeSymbol semanticReturnType, List<LinqStep> chain, InvocationExpressionSyntax node)
        {
            var returnType = SyntaxFactory.ParseTypeName(semanticReturnType.ToDisplayString());

            if (MethodNames.RootMethodsThatRequireYieldReturn.Contains(aggregationMethod))
            {
                return RewriteAsLoop(
                    returnType,
                    Enumerable.Empty<StatementSyntax>(),
                    Enumerable.Empty<StatementSyntax>(),
                    collection,
                    chain,
                    (inv, arguments, param) 
                        => SyntaxFactory.YieldStatement(SyntaxKind.YieldReturnStatement, SyntaxFactory.IdentifierName(param.Identifier.ValueText)),
                    true
                );
            }
            if (aggregationMethod.Contains(".Sum"))
            {
                var elementType = (returnType as NullableTypeSyntax)?.ElementType ?? returnType;
                return RewriteAsLoop(
                    returnType,
                    new[] { CreateLocalVariableDeclaration("sum_", SyntaxFactory.CastExpression(elementType, SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(0)))) },
                    new[] { SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("sum_")) },
                    collection,
                    MaybeAddSelect(chain, node.ArgumentList.Arguments.Count != 0),
                    (inv, arguments, param) =>
                    {
                        var currentValue = SyntaxFactory.IdentifierName(param.Identifier.ValueText);
                        return IfNullableIsNotNull(elementType != returnType, currentValue, x 
                            => SyntaxFactory.CheckedStatement(SyntaxKind.CheckedStatement, SyntaxFactory.Block(SyntaxFactory.ExpressionStatement(SyntaxFactory.AssignmentExpression(SyntaxKind.AddAssignmentExpression, SyntaxFactory.IdentifierName("sum_"), x)))));
                    }
                );
            }
            if (aggregationMethod.Contains(".Max") || aggregationMethod.Contains(".Min"))
            {
                var minmax = aggregationMethod.Contains(".Max") ? "max_" : "min_";
                var elementType = (returnType as NullableTypeSyntax)?.ElementType ?? returnType;
                return RewriteAsLoop(
                    returnType,
                    new[] {
                        CreateLocalVariableDeclaration("found_", SyntaxFactory.LiteralExpression(SyntaxKind.FalseLiteralExpression)),
                        CreateLocalVariableDeclaration(minmax, SyntaxFactory.CastExpression(elementType, SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(0))))
                    },
                    new[] {
                        SyntaxFactory.Block(
                        SyntaxFactory.IfStatement(SyntaxFactory.PrefixUnaryExpression(SyntaxKind.LogicalNotExpression, SyntaxFactory.IdentifierName("found_")),
                            returnType == elementType ? (StatementSyntax)CreateThrowException("System.InvalidOperationException", "The sequence did not contain any elements.") :
                            SyntaxFactory.ReturnStatement(SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression))
                        ),
                         SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName(minmax))
                        )
                    },
                    collection,
                    MaybeAddSelect(chain, node.ArgumentList.Arguments.Count != 0),
                    (inv, arguments, param) =>
                    {
                        var identifierNameSyntax = SyntaxFactory.IdentifierName(param.Identifier.ValueText);
                        return IfNullableIsNotNull(elementType != returnType, identifierNameSyntax, x =>
                        {
                            var assignmentExpressionSyntax = SyntaxFactory.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, SyntaxFactory.IdentifierName(minmax), x);
                            var condition = SyntaxFactory.BinaryExpression(aggregationMethod.Contains(".Max") ? SyntaxKind.GreaterThanExpression : SyntaxKind.LessThanExpression, x, SyntaxFactory.IdentifierName(minmax));
                            var kind = ((PredefinedTypeSyntax) elementType).Keyword.Kind();
                            if (kind == SyntaxKind.DoubleKeyword || kind == SyntaxKind.FloatKeyword)
                            {
                                condition = SyntaxFactory.BinaryExpression(SyntaxKind.LogicalOrExpression, condition, SyntaxFactory.InvocationExpression(SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, elementType, SyntaxFactory.IdentifierName("IsNaN")), CreateArguments(x)));
                            }
                            return SyntaxFactory.IfStatement(SyntaxFactory.IdentifierName("found_"),
                               SyntaxFactory.Block(SyntaxFactory.IfStatement(condition, SyntaxFactory.ExpressionStatement(assignmentExpressionSyntax))),
                               SyntaxFactory.ElseClause(SyntaxFactory.Block(SyntaxFactory.ExpressionStatement(SyntaxFactory.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, SyntaxFactory.IdentifierName("found_"), SyntaxFactory.LiteralExpression(SyntaxKind.TrueLiteralExpression))), SyntaxFactory.ExpressionStatement(assignmentExpressionSyntax))));
                        });
                    });
            }
            if (aggregationMethod.Contains(".Average"))
            {
                var elementType = (returnType as NullableTypeSyntax)?.ElementType ?? returnType;
                var primitive = ((PredefinedTypeSyntax)elementType).Keyword.Kind();

                ExpressionSyntax sumIdentifier = SyntaxFactory.IdentifierName("sum_");
                ExpressionSyntax countIdentifier = SyntaxFactory.IdentifierName("count_");

                if (primitive != SyntaxKind.DecimalKeyword)
                {
                    sumIdentifier = SyntaxFactory.CastExpression(CreatePrimitiveType(SyntaxKind.DoubleKeyword), sumIdentifier);
                    countIdentifier = SyntaxFactory.CastExpression(CreatePrimitiveType(SyntaxKind.DoubleKeyword), countIdentifier);
                }
                ExpressionSyntax division = SyntaxFactory.BinaryExpression(SyntaxKind.DivideExpression, sumIdentifier, countIdentifier);
                if (primitive != SyntaxKind.DoubleKeyword && primitive != SyntaxKind.DecimalKeyword)
                    division = SyntaxFactory.CastExpression(elementType, SyntaxFactory.ParenthesizedExpression(division));

                return RewriteAsLoop(
                    returnType,
                    new[] {
                        CreateLocalVariableDeclaration("sum_", SyntaxFactory.CastExpression(primitive == SyntaxKind.IntKeyword || primitive==SyntaxKind.LongKeyword ? CreatePrimitiveType(SyntaxKind.LongKeyword) : primitive == SyntaxKind.DecimalKeyword ? CreatePrimitiveType(SyntaxKind.DecimalKeyword) : CreatePrimitiveType(SyntaxKind.DoubleKeyword), SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(0)))),
                        CreateLocalVariableDeclaration("count_", SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.ParseToken("0L")))
                    },
                    new[] {
                        SyntaxFactory.Block(
                        SyntaxFactory.IfStatement(SyntaxFactory.BinaryExpression(SyntaxKind.EqualsExpression,
                            SyntaxFactory.IdentifierName("count_"),
                            SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.ParseToken("0"))),
                            returnType == elementType ? (StatementSyntax)CreateThrowException("System.InvalidOperationException", "The sequence did not contain any elements.") :
                            SyntaxFactory.ReturnStatement(SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression))
                        ),
                         SyntaxFactory.ReturnStatement(division)
                        )
                    },
                    collection,
                    MaybeAddSelect(chain, node.ArgumentList.Arguments.Count != 0),
                    (inv, arguments, param) =>
                    {
                        var currentValue = SyntaxFactory.IdentifierName(param.Identifier.ValueText);
                        return IfNullableIsNotNull(elementType != returnType, currentValue, x => SyntaxFactory.CheckedStatement(SyntaxKind.CheckedStatement, SyntaxFactory.Block(
                            SyntaxFactory.ExpressionStatement(SyntaxFactory.PostfixUnaryExpression(SyntaxKind.PostIncrementExpression, SyntaxFactory.IdentifierName("count_"))),
                            SyntaxFactory.ExpressionStatement(SyntaxFactory.AssignmentExpression(SyntaxKind.AddAssignmentExpression, SyntaxFactory.IdentifierName("sum_"), x))
                        )));
                    }
                );
            }
            if (aggregationMethod == MethodNames.AnyMethod || aggregationMethod == MethodNames.AnyWithConditionMethod)
            {

                return RewriteAsLoop(
                    CreatePrimitiveType(SyntaxKind.BoolKeyword),
                    Enumerable.Empty<StatementSyntax>(),
                    new[] { SyntaxFactory.ReturnStatement(SyntaxFactory.LiteralExpression(SyntaxKind.FalseLiteralExpression)) },
                    collection,
                    MaybeAddFilter(chain, aggregationMethod == MethodNames.AnyWithConditionMethod),
                    (inv, arguments, param) 
                        => SyntaxFactory.ReturnStatement(SyntaxFactory.LiteralExpression(SyntaxKind.TrueLiteralExpression)));
            }
            if (aggregationMethod == MethodNames.ListForEachMethod || aggregationMethod == MethodNames.IEnumerableForEachMethod)
            {
                return RewriteAsLoop(
                    CreatePrimitiveType(SyntaxKind.VoidKeyword),
                    Enumerable.Empty<StatementSyntax>(),
                    Enumerable.Empty<StatementSyntax>(),
                    collection,
                    chain,
                    (inv, arguments, param) =>
                    {
                        var lambda = inv.Lambda ?? new Lambda((AnonymousFunctionExpressionSyntax)inv.Arguments.First());
                        return SyntaxFactory.ExpressionStatement(InlineOrCreateMethod(lambda, CreatePrimitiveType(SyntaxKind.VoidKeyword), arguments, param));
                    }
                    );
            }
            if (aggregationMethod == MethodNames.ContainsMethod)
            {
                var elementType = SyntaxFactory.ParseTypeName(_semantic.GetTypeInfo(node.ArgumentList.Arguments.First().Expression).ConvertedType.ToDisplayString());
                var comparerIdentifier = ((elementType as NullableTypeSyntax)?.ElementType ?? elementType) is PredefinedTypeSyntax ? null : SyntaxFactory.IdentifierName("comparer_");
                return RewriteAsLoop(
                    CreatePrimitiveType(SyntaxKind.BoolKeyword),
                    comparerIdentifier != null ? new StatementSyntax[] { CreateLocalVariableDeclaration("comparer_", SyntaxFactory.ParseExpression("System.Collections.Generic.EqualityComparer<" + elementType.ToString() + ">.Default")) } : Enumerable.Empty<StatementSyntax>(),
                    new[] { SyntaxFactory.ReturnStatement(SyntaxFactory.LiteralExpression(SyntaxKind.FalseLiteralExpression)) },
                    collection,
                    chain,
                    (inv, arguments, param) =>
                    {
                        var target = SyntaxFactory.IdentifierName("_target");
                        var current = SyntaxFactory.IdentifierName(param.Identifier.ValueText);
                        var condition = comparerIdentifier != null ? SyntaxFactory.InvocationExpression(SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, comparerIdentifier, SyntaxFactory.IdentifierName("Equals")), CreateArguments(current, target)) : (ExpressionSyntax)SyntaxFactory.BinaryExpression(SyntaxKind.EqualsExpression, current, target);
                        return SyntaxFactory.IfStatement(condition, SyntaxFactory.ReturnStatement(SyntaxFactory.LiteralExpression(SyntaxKind.TrueLiteralExpression)));
                    },
                    additionalParameters: new[] { Tuple.Create(CreateParameter("_target", elementType), node.ArgumentList.Arguments.First().Expression) }
                );
            }
            if (aggregationMethod == MethodNames.AllWithConditionMethod) // All alone does not exist
            {

                return RewriteAsLoop(
                    CreatePrimitiveType(SyntaxKind.BoolKeyword),
                    Enumerable.Empty<StatementSyntax>(),
                    new[] { SyntaxFactory.ReturnStatement(SyntaxFactory.LiteralExpression(SyntaxKind.TrueLiteralExpression)) },
                    collection,
                    chain,
                    (inv, arguments, param) =>
                    {
                        var lambda = (LambdaExpressionSyntax)inv.Arguments.First();
                        return SyntaxFactory.IfStatement(SyntaxFactory.PrefixUnaryExpression(SyntaxKind.LogicalNotExpression, SyntaxFactory.ParenthesizedExpression(InlineOrCreateMethod(new Lambda(lambda), CreatePrimitiveType(SyntaxKind.BoolKeyword), arguments, param))),
                         SyntaxFactory.ReturnStatement(SyntaxFactory.LiteralExpression(SyntaxKind.FalseLiteralExpression)
                         ));
                    }
                );
            }
            if (aggregationMethod == MethodNames.CountMethod || aggregationMethod == MethodNames.CountWithConditionMethod || aggregationMethod == MethodNames.LongCountMethod || aggregationMethod == MethodNames.LongCountWithConditionMethod)
            {

                return RewriteAsLoop(
                    returnType,
                    new[] { CreateLocalVariableDeclaration("_count", SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.ParseToken(aggregationMethod == MethodNames.LongCountMethod || aggregationMethod == MethodNames.LongCountWithConditionMethod ? "0L" : "0"))) },
                    new[] { SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("_count")) },
                    collection,
                    MaybeAddFilter(chain, aggregationMethod == MethodNames.CountWithConditionMethod || aggregationMethod == MethodNames.LongCountWithConditionMethod),
                    (inv, arguments, param) 
                        => SyntaxFactory.ExpressionStatement(SyntaxFactory.PostfixUnaryExpression(SyntaxKind.PostIncrementExpression, SyntaxFactory.IdentifierName("_count"))));
            }
            if (aggregationMethod == MethodNames.ElementAtMethod || aggregationMethod == MethodNames.ElementAtOrDefaultMethod)
            {

                return RewriteAsLoop(
                    returnType,
                    new[] { CreateLocalVariableDeclaration("_count", SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.ParseToken(aggregationMethod == MethodNames.LongCountMethod || aggregationMethod == MethodNames.LongCountWithConditionMethod ? "0L" : "0"))) },
                    new[] { aggregationMethod == MethodNames.ElementAtMethod ? (StatementSyntax)CreateThrowException("System.InvalidOperationException", "The specified index is not included in the sequence.") : SyntaxFactory.ReturnStatement(SyntaxFactory.DefaultExpression(returnType)) },
                    collection,
                    MaybeAddFilter(chain, aggregationMethod == MethodNames.CountWithConditionMethod || aggregationMethod == MethodNames.LongCountWithConditionMethod),
                    (inv, arguments, param) 
                        => SyntaxFactory.IfStatement(SyntaxFactory.BinaryExpression(SyntaxKind.EqualsExpression, SyntaxFactory.IdentifierName("_requestedPosition"), SyntaxFactory.PostfixUnaryExpression(SyntaxKind.PostIncrementExpression, SyntaxFactory.IdentifierName("_count"))), SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName(param.Identifier.ValueText))),
                    additionalParameters: new[] { Tuple.Create(CreateParameter("_requestedPosition", CreatePrimitiveType(SyntaxKind.IntKeyword)), node.ArgumentList.Arguments.First().Expression) }
                );
            }
            if (aggregationMethod == MethodNames.FirstMethod || aggregationMethod == MethodNames.FirstWithConditionMethod)
            {
                return RewriteAsLoop(
                    returnType,
                    Enumerable.Empty<StatementSyntax>(),
                    new[] { CreateThrowException("System.InvalidOperationException", "The sequence did not contain any elements.") },
                    collection,
                    MaybeAddFilter(chain, aggregationMethod == MethodNames.FirstWithConditionMethod),
                    (inv, arguments, param) 
                        => SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName(param.Identifier.ValueText)));
            }
            if (aggregationMethod == MethodNames.FirstOrDefaultMethod || aggregationMethod == MethodNames.FirstOrDefaultWithConditionMethod)
            {
                return RewriteAsLoop(
                    returnType,
                    Enumerable.Empty<StatementSyntax>(),
                    new[] { SyntaxFactory.ReturnStatement(SyntaxFactory.DefaultExpression(returnType)) },
                    collection,
                    MaybeAddFilter(chain, aggregationMethod == MethodNames.FirstOrDefaultWithConditionMethod),
                    (inv, arguments, param) 
                        => SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName(param.Identifier.ValueText)));
            }
            if (aggregationMethod == MethodNames.LastOrDefaultMethod || aggregationMethod == MethodNames.LastOrDefaultWithConditionMethod)
            {
                return RewriteAsLoop(
                    returnType,
                    new[] { CreateLocalVariableDeclaration("_last", SyntaxFactory.DefaultExpression(returnType)) },
                    new[] { SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("_last")) },
                    collection,
                    MaybeAddFilter(chain, aggregationMethod == MethodNames.LastOrDefaultWithConditionMethod),
                    (inv, arguments, param) 
                        => SyntaxFactory.ExpressionStatement(SyntaxFactory.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, SyntaxFactory.IdentifierName("_last"), SyntaxFactory.IdentifierName(param.Identifier.ValueText))));
            }
            if (aggregationMethod == MethodNames.LastMethod || aggregationMethod == MethodNames.LastWithConditionMethod)
            {
                return RewriteAsLoop(
                    returnType,
                    new[] { CreateLocalVariableDeclaration("_last", SyntaxFactory.DefaultExpression(returnType)), CreateLocalVariableDeclaration("_found", SyntaxFactory.LiteralExpression(SyntaxKind.FalseLiteralExpression)) },
                    new StatementSyntax[] { SyntaxFactory.IfStatement(SyntaxFactory.PrefixUnaryExpression(SyntaxKind.LogicalNotExpression, SyntaxFactory.IdentifierName("_found")), CreateThrowException("System.InvalidOperationException", "The sequence did not contain any elements.")), SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("_last")) },
                    collection,
                    MaybeAddFilter(chain, aggregationMethod == MethodNames.LastWithConditionMethod),
                    (inv, arguments, param) => SyntaxFactory.Block(
                        SyntaxFactory.ExpressionStatement(SyntaxFactory.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, SyntaxFactory.IdentifierName("_found"), SyntaxFactory.LiteralExpression(SyntaxKind.TrueLiteralExpression))),
                        SyntaxFactory.ExpressionStatement(SyntaxFactory.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, SyntaxFactory.IdentifierName("_last"), SyntaxFactory.IdentifierName(param.Identifier.ValueText)))));
            }
            if (aggregationMethod == MethodNames.SingleMethod || aggregationMethod == MethodNames.SingleWithConditionMethod)
            {
                return RewriteAsLoop(
                    returnType,
                    new[] { CreateLocalVariableDeclaration("_last", SyntaxFactory.DefaultExpression(returnType)), CreateLocalVariableDeclaration("_found", SyntaxFactory.LiteralExpression(SyntaxKind.FalseLiteralExpression)) },
                    new StatementSyntax[] { SyntaxFactory.IfStatement(SyntaxFactory.PrefixUnaryExpression(SyntaxKind.LogicalNotExpression, SyntaxFactory.IdentifierName("_found")), CreateThrowException("System.InvalidOperationException", "The sequence did not contain any elements.")), SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("_last")) },
                    collection,
                    MaybeAddFilter(chain, aggregationMethod == MethodNames.SingleWithConditionMethod),
                    (inv, arguments, param) => SyntaxFactory.Block(
                        SyntaxFactory.IfStatement(SyntaxFactory.IdentifierName("_found"), CreateThrowException("System.InvalidOperationException", "The sequence contains more than one element.")),
                        SyntaxFactory.ExpressionStatement(SyntaxFactory.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, SyntaxFactory.IdentifierName("_found"), SyntaxFactory.LiteralExpression(SyntaxKind.TrueLiteralExpression))),
                        SyntaxFactory.ExpressionStatement(SyntaxFactory.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, SyntaxFactory.IdentifierName("_last"), SyntaxFactory.IdentifierName(param.Identifier.ValueText)))));
            }
            if (aggregationMethod == MethodNames.SingleOrDefaultMethod || aggregationMethod == MethodNames.SingleOrDefaultWithConditionMethod)
            {
                return RewriteAsLoop(
                    returnType,
                    new[] { CreateLocalVariableDeclaration("_last", SyntaxFactory.DefaultExpression(returnType)), CreateLocalVariableDeclaration("_found", SyntaxFactory.LiteralExpression(SyntaxKind.FalseLiteralExpression)) },
                    new StatementSyntax[] { SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("_last")) },
                    collection,
                    MaybeAddFilter(chain, aggregationMethod == MethodNames.SingleOrDefaultWithConditionMethod),
                    (inv, arguments, param) => SyntaxFactory.Block(
                        SyntaxFactory.IfStatement(SyntaxFactory.IdentifierName("_found"), CreateThrowException("System.InvalidOperationException", "The sequence contains more than one element.")),
                        SyntaxFactory.ExpressionStatement(SyntaxFactory.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, SyntaxFactory.IdentifierName("_found"), SyntaxFactory.LiteralExpression(SyntaxKind.TrueLiteralExpression))),
                        SyntaxFactory.ExpressionStatement(SyntaxFactory.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, SyntaxFactory.IdentifierName("_last"), SyntaxFactory.IdentifierName(param.Identifier.ValueText)))));
            }
            if (aggregationMethod == MethodNames.ToListMethod || aggregationMethod == MethodNames.ReverseMethod)
            {
                var count = chain.All(x => MethodNames.MethodsThatPreserveCount.Contains(x.MethodName)) ? GetCollectionCount(collection, true) : null;

                var listIdentifier = SyntaxFactory.IdentifierName("_list");
                return RewriteAsLoop(
                    returnType,
                    new[] { CreateLocalVariableDeclaration("_list", SyntaxFactory.ObjectCreationExpression(SyntaxFactory.ParseTypeName("System.Collections.Generic.List<" + GetItemType(semanticReturnType).ToDisplayString() + ">"), CreateArguments(count != null ? new[] { count } : Enumerable.Empty<ExpressionSyntax>()), null)) },
                    aggregationMethod == MethodNames.ReverseMethod ? new StatementSyntax[] { SyntaxFactory.ExpressionStatement(SyntaxFactory.InvocationExpression(SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, SyntaxFactory.IdentifierName("_list"), SyntaxFactory.IdentifierName("Reverse")))), SyntaxFactory.ReturnStatement(listIdentifier) } : new[] { SyntaxFactory.ReturnStatement(listIdentifier) },
                    collection,
                    chain,
                    (inv, arguments, param) => CreateStatement(SyntaxFactory.InvocationExpression(SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, listIdentifier, SyntaxFactory.IdentifierName("Add")), CreateArguments(SyntaxFactory.IdentifierName(param.Identifier.ValueText)))));
            }
            if (/*aggregationMethod == ToDictionaryWithKeyMethod || */aggregationMethod == MethodNames.ToDictionaryWithKeyValueMethod)
            {
                var dictIdentifier = SyntaxFactory.IdentifierName("_dict");
                return RewriteAsLoop(
                    returnType,
                    new[] { CreateLocalVariableDeclaration("_dict", SyntaxFactory.ObjectCreationExpression(returnType, CreateArguments(Enumerable.Empty<ArgumentSyntax>()), null)) },
                    new[] { SyntaxFactory.ReturnStatement(dictIdentifier) },
                    collection,
                    chain,
                    (inv, arguments, param) =>
                    {
                        var keyLambda = (AnonymousFunctionExpressionSyntax)node.ArgumentList.Arguments.First().Expression;
                        var valueLambda = (AnonymousFunctionExpressionSyntax)node.ArgumentList.Arguments.ElementAtOrDefault(1)?.Expression;
                        return CreateStatement(SyntaxFactory.InvocationExpression(SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, dictIdentifier, SyntaxFactory.IdentifierName("Add")), CreateArguments(InlineOrCreateMethod(new Lambda(keyLambda), SyntaxFactory.ParseTypeName( GetLambdaReturnType(keyLambda).ToDisplayString()), arguments, param), aggregationMethod == MethodNames.ToDictionaryWithKeyValueMethod ?
                                InlineOrCreateMethod( new Lambda(valueLambda), SyntaxFactory.ParseTypeName( GetLambdaReturnType(valueLambda).ToDisplayString()), arguments, param):
                                SyntaxFactory.IdentifierName(param.Identifier.ValueText))));
                    }
                );
            }
            if (aggregationMethod == MethodNames.ToArrayMethod)
            {
                var count = chain.All(x => MethodNames.MethodsThatPreserveCount.Contains(x.MethodName)) ? GetCollectionCount(collection, false) : null;

                if (count != null)
                {
                    var arrayIdentifier = SyntaxFactory.IdentifierName("_array");
                    return RewriteAsLoop(
                        returnType,
                        new[] { CreateLocalVariableDeclaration("_array", SyntaxFactory.ArrayCreationExpression(SyntaxFactory.ArrayType(((ArrayTypeSyntax)returnType).ElementType, SyntaxFactory.List(new[] { SyntaxFactory.ArrayRankSpecifier(CreateSeparatedList(count)) })))) },
                        new[] { SyntaxFactory.ReturnStatement(arrayIdentifier) },
                        collection,
                        chain,
                        (inv, arguments, param) 
                            => CreateStatement(SyntaxFactory.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, SyntaxFactory.ElementAccessExpression(arrayIdentifier, SyntaxFactory.BracketedArgumentList(CreateSeparatedList(SyntaxFactory.Argument(SyntaxFactory.IdentifierName("_index"))))), SyntaxFactory.IdentifierName(param.Identifier.ValueText))));

                }
                var listIdentifier = SyntaxFactory.IdentifierName("_list");
                var listType = SyntaxFactory.ParseTypeName("System.Collections.Generic.List<" + ((ArrayTypeSyntax)returnType).ElementType + ">");
                return RewriteAsLoop(
                    returnType,
                    new[] { CreateLocalVariableDeclaration("_list", SyntaxFactory.ObjectCreationExpression(listType, CreateArguments(Enumerable.Empty<ArgumentSyntax>()), null)) },
                    new[] { SyntaxFactory.ReturnStatement(SyntaxFactory.InvocationExpression(SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, listIdentifier, SyntaxFactory.IdentifierName("ToArray")))) },
                    collection,
                    chain,
                    (inv, arguments, param) 
                        => CreateStatement(SyntaxFactory.InvocationExpression(SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, listIdentifier, SyntaxFactory.IdentifierName("Add")), CreateArguments(SyntaxFactory.IdentifierName(param.Identifier.ValueText)))));
            }

#if false
                    if (GetMethodFullName(node) == SumWithSelectorMethod)
                    {
                        string itemArg = null;
                        return RewriteAsLoop(
                           CreatePrimitiveType(SyntaxKind.IntKeyword),
                           new[] { CreateLocalVariableDeclaration("sum_", SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(0))) },
                           arguments =>
                           {
                               return SyntaxFactory.ExpressionStatement(SyntaxFactory.AssignmentExpression(SyntaxKind.AddAssignmentExpression, SyntaxFactory.IdentifierName("sum_"),
                                    InlineOrCreateMethod((CSharpSyntaxNode)Visit(lambda.Body), arguments, CreateParameter(arg.Identifier, itemType), out itemArg)));

                           },
                           new[] { SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("sum_")) },
                           () => itemArg,
                           collection
                       );
                    }

                    if (GetMethodFullName(node) == SumIntsMethod)
                    {
                        string itemArg = null;
                        return RewriteAsLoop(
                            CreatePrimitiveType(SyntaxKind.IntKeyword),
                            new[] { CreateLocalVariableDeclaration("sum_", SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(0))) },
                            arguments =>
                            {
                                return SyntaxFactory.ExpressionStatement(SyntaxFactory.AssignmentExpression(SyntaxKind.AddAssignmentExpression, SyntaxFactory.IdentifierName("sum_"),
                                     InlineOrCreateMethod(SyntaxFactory.IdentifierName(ItemName), arguments, CreateParameter(ItemName, itemType), out itemArg)));

                            },
                            new[] { SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("sum_")) },
                            () => itemArg,
                            collection
                        );
                    }
#endif
            return null;
        }

        private StatementSyntax IfNullableIsNotNull(bool nullable, IdentifierNameSyntax currentValue, Func<ExpressionSyntax, StatementSyntax> p)
        {
            var k = nullable ? (ExpressionSyntax)SyntaxFactory.InvocationExpression(SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, currentValue, SyntaxFactory.IdentifierName("GetValueOrDefault"))) : currentValue;
            return nullable ? SyntaxFactory.IfStatement(SyntaxFactory.BinaryExpression(SyntaxKind.NotEqualsExpression, currentValue, SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression)), p(k)) : p(k);
        }

        private ExpressionSyntax GetCollectionCount(ExpressionSyntax collection, bool allowUnknown)
        {
            var collectionType = _semantic.GetTypeInfo(collection).Type;
            if (collectionType is IArrayTypeSymbol)
                return SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, SyntaxFactory.IdentifierName(ItemsName), SyntaxFactory.IdentifierName("Length"));
            
            if (collectionType.ToDisplayString().StartsWith("System.Collections.Generic.IReadOnlyCollection<") || collectionType.AllInterfaces.Any(x => x.ToDisplayString().StartsWith("System.Collections.Generic.IReadOnlyCollection<")))
                return SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, SyntaxFactory.IdentifierName(ItemsName), SyntaxFactory.IdentifierName("Count"));
                
            if (collectionType.ToDisplayString().StartsWith("System.Collections.Generic.ICollection<") || collectionType.AllInterfaces.Any(x => x.ToDisplayString().StartsWith("System.Collections.Generic.ICollection<")))
                return SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, SyntaxFactory.IdentifierName(ItemsName), SyntaxFactory.IdentifierName("Count"));

            if (!allowUnknown) return null;
            if (collectionType.IsValueType) return null;
            var itemType = GetItemType(collectionType);
            if (itemType == null) return null;
            return
                SyntaxFactory.InvocationExpression(
                    SyntaxFactory.MemberAccessExpression(
                        SyntaxKind.SimpleMemberAccessExpression,
                        SyntaxFactory.ParenthesizedExpression(
                            SyntaxFactory.ConditionalAccessExpression(
                                SyntaxFactory.ParenthesizedExpression(
                                    SyntaxFactory.BinaryExpression(
                                        SyntaxKind.AsExpression,
                                        SyntaxFactory.IdentifierName(ItemsName),
                                        SyntaxFactory.ParseTypeName("System.Collections.Generic.ICollection<" + itemType.ToDisplayString() + ">")
                                    )
                                ),
                                SyntaxFactory.MemberBindingExpression(
                                    SyntaxFactory.IdentifierName("Count")
                                )
                            )
                        ),
                        SyntaxFactory.IdentifierName("GetValueOrDefault")
                    )
                );
        }

        private List<LinqStep> MaybeAddFilter(List<LinqStep> chain, bool condition)
        {
            if (!condition) return chain;
            var lambda = (LambdaExpressionSyntax)chain.First().Arguments.FirstOrDefault();
            return InsertExpandedShortcutMethod(chain, MethodNames.WhereMethod, lambda);
        }

        private List<LinqStep> MaybeAddSelect(List<LinqStep> chain, bool condition)
        {
            if (!condition) return chain;
            var lambda = (LambdaExpressionSyntax)chain.First().Arguments.FirstOrDefault();
            return InsertExpandedShortcutMethod(chain, MethodNames.SelectMethod, lambda);
        }

        private List<LinqStep> InsertExpandedShortcutMethod(List<LinqStep> chain, string methodFullName, LambdaExpressionSyntax lambda)
        {
            var ch = chain.ToList();
            //    var baseExpression = ((MemberAccessExpressionSyntax)chain.First().Expression).Expression;
            ch.Insert(1, new LinqStep(methodFullName, new[] { lambda }));
            return ch;
        }

        private StatementSyntax CreateProcessingStep(List<LinqStep> chain, int chainIndex, TypeSyntax itemType, string itemName, ArgumentListSyntax arguments, bool noAggregation)
        {

            if (chainIndex == 0 && !noAggregation || chainIndex == -1)
                return currentAggregation(chain[0], arguments, CreateParameter(itemName, itemType));

            var step = chain[chainIndex];
            var method = step.MethodName;

            switch (method)
            {
                case MethodNames.WhereMethod:
                {
                    var lambda = (AnonymousFunctionExpressionSyntax)step.Arguments[0];

                    var check = InlineOrCreateMethod(new Lambda(lambda), CreatePrimitiveType(SyntaxKind.BoolKeyword), arguments, CreateParameter(itemName, itemType));
                    var next = CreateProcessingStep(chain, chainIndex - 1, itemType, itemName, arguments, noAggregation);
                    return SyntaxFactory.IfStatement(check, next is BlockSyntax ? next : SyntaxFactory.Block(next));
                }
                case MethodNames.OfTypeMethod:
                case MethodNames.CastMethod:
                {
                    var newType = ((GenericNameSyntax)((MemberAccessExpressionSyntax)step.Invocation.Expression).Name).TypeArgumentList.Arguments.First();
                    var newName = "_linqitem" + ++lastId;
                    var next = CreateProcessingStep(chain, chainIndex - 1, newType, newName, arguments, noAggregation);


                    if (method == MethodNames.CastMethod)
                    {
                        var local = CreateLocalVariableDeclaration(newName, SyntaxFactory.CastExpression(newType, SyntaxFactory.IdentifierName(itemName)));
                        var nextStatement = next is BlockSyntax ? ((BlockSyntax)next).Statements : (IEnumerable<StatementSyntax>)new[] { next };
                        return SyntaxFactory.Block(new[] { local }.Concat(nextStatement));
                    }
                    else
                    {
                        var type = _semantic.GetTypeInfo(newType).Type;
                        if (type.IsValueType)
                        {
                            return SyntaxFactory.IfStatement(SyntaxFactory.BinaryExpression(SyntaxKind.IsExpression, SyntaxFactory.IdentifierName(itemName), newType), SyntaxFactory.Block(
                                CreateLocalVariableDeclaration(newName, SyntaxFactory.CastExpression(newType, SyntaxFactory.IdentifierName(itemName))),
                                next

                            ));
                        }
                        var local = CreateLocalVariableDeclaration(newName, SyntaxFactory.BinaryExpression(SyntaxKind.AsExpression, SyntaxFactory.IdentifierName(itemName), newType));
                        return SyntaxFactory.Block(local, SyntaxFactory.IfStatement(SyntaxFactory.BinaryExpression(SyntaxKind.NotEqualsExpression, SyntaxFactory.IdentifierName(newName), SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression)),
                            next));
                    }
                }
                case MethodNames.SelectMethod:
                {
                    var lambda = (AnonymousFunctionExpressionSyntax)step.Arguments[0];

                    var newName = "_linqitem" + ++lastId;
                    var lambdaType = (INamedTypeSymbol)_semantic.GetTypeInfo(lambda).ConvertedType;
                    var lambdaBodyType = lambdaType.TypeArguments.Last();
                    var newType = IsAnonymousType(lambdaBodyType) ? null : SyntaxFactory.ParseTypeName(lambdaBodyType.ToDisplayString());

                    var local = CreateLocalVariableDeclaration(newName, InlineOrCreateMethod(new Lambda(lambda), newType, arguments, CreateParameter(itemName, itemType)));
                    
                    var next = CreateProcessingStep(chain, chainIndex - 1, newType, newName, arguments, noAggregation);
                    var nextStatement = next is BlockSyntax syntax ? syntax.Statements : (IEnumerable<StatementSyntax>)new[] { next };
                    return SyntaxFactory.Block(new[] { local }.Concat(nextStatement));
                }
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
