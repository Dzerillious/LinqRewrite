using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using SyntaxExtensions = Shaman.Roslyn.LinqRewrite.Extensions.SyntaxExtensions;

namespace Shaman.Roslyn.LinqRewrite.Services
{
    public class RewriteLinqRules
    {
        private static RewriteLinqRules _instance;
        public static RewriteLinqRules Instance => _instance ??= new RewriteLinqRules();

        private readonly RewriteService _rewrite;
        private readonly CodeCreationService _code;
        private readonly RewriteDataService _data;
        private readonly SyntaxInformationService _info;
        public RewriteLinqRules()
        {
            _rewrite = RewriteService.Instance;
            _code = CodeCreationService.Instance;
            _data = RewriteDataService.Instance;
            _info = SyntaxInformationService.Instance;
        }

        public ExpressionSyntax RewriteWhenNeedsYieldReturn(TypeSyntax returnType, ExpressionSyntax collection, List<LinqStep> chain)
            => _rewrite.RewriteAsLoop(
                returnType,
                Enumerable.Empty<StatementSyntax>(),
                Enumerable.Empty<StatementSyntax>(),
                collection,
                chain,
                (inv, arguments, param)
                    => SyntaxFactory.YieldStatement(SyntaxKind.YieldReturnStatement,
                        SyntaxFactory.IdentifierName(param.Identifier.ValueText)),
                true
            );

        public ExpressionSyntax RewriteSum(TypeSyntax returnType, ExpressionSyntax collection, List<LinqStep> chain, InvocationExpressionSyntax node)
        {
            var elementType = (returnType as NullableTypeSyntax)?.ElementType ?? returnType;
            return _rewrite.RewriteAsLoop(
                returnType,
                new[]
                {
                    _code.CreateLocalVariableDeclaration("sum_",
                        SyntaxFactory.CastExpression(elementType,
                            SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression,
                                SyntaxFactory.Literal(0))))
                },
                new[] {SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("sum_"))},
                collection,
                CodeCreationService.MaybeAddSelect(chain, node.ArgumentList.Arguments.Count != 0),
                (inv, arguments, param) =>
                {
                    var currentValue = SyntaxFactory.IdentifierName(param.Identifier.ValueText);
                    return SyntaxExtensions.IfNullableIsNotNull(elementType != returnType, currentValue, x
                        => SyntaxFactory.CheckedStatement(SyntaxKind.CheckedStatement,
                            SyntaxFactory.Block(SyntaxFactory.ExpressionStatement(
                                SyntaxFactory.AssignmentExpression(SyntaxKind.AddAssignmentExpression,
                                    SyntaxFactory.IdentifierName("sum_"), x)))));
                }
            );
        }

        public ExpressionSyntax RewriteMinMax(TypeSyntax returnType, string aggregationMethod, ExpressionSyntax collection, List<LinqStep> chain, InvocationExpressionSyntax node)
        {
            var minmax = aggregationMethod.Contains(".Max") ? "max_" : "min_";
            var elementType = (returnType as NullableTypeSyntax)?.ElementType ?? returnType;
            return _rewrite.RewriteAsLoop(
                returnType,
                new[]
                {
                    _code.CreateLocalVariableDeclaration("found_",
                        SyntaxFactory.LiteralExpression(SyntaxKind.FalseLiteralExpression)),
                    _code.CreateLocalVariableDeclaration(minmax,
                        SyntaxFactory.CastExpression(elementType,
                            SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression,
                                SyntaxFactory.Literal(0))))
                },
                new[]
                {
                    SyntaxFactory.Block(
                        SyntaxFactory.IfStatement(
                            SyntaxFactory.PrefixUnaryExpression(SyntaxKind.LogicalNotExpression,
                                SyntaxFactory.IdentifierName("found_")),
                            returnType == elementType
                                ? (StatementSyntax) _code.CreateThrowException("System.InvalidOperationException",
                                    "The sequence did not contain any elements.")
                                : SyntaxFactory.ReturnStatement(
                                    SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression))
                        ),
                        SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName(minmax))
                    )
                },
                collection,
                CodeCreationService.MaybeAddSelect(chain, node.ArgumentList.Arguments.Count != 0),
                (inv, arguments, param) =>
                {
                    var identifierNameSyntax = SyntaxFactory.IdentifierName(param.Identifier.ValueText);
                    return SyntaxExtensions.IfNullableIsNotNull(elementType != returnType, identifierNameSyntax, x =>
                    {
                        var assignmentExpressionSyntax =
                            SyntaxFactory.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression,
                                SyntaxFactory.IdentifierName(minmax), x);
                        var condition = SyntaxFactory.BinaryExpression(
                            aggregationMethod.Contains(".Max")
                                ? SyntaxKind.GreaterThanExpression
                                : SyntaxKind.LessThanExpression, x, SyntaxFactory.IdentifierName(minmax));
                        var kind = ((PredefinedTypeSyntax) elementType).Keyword.Kind();
                        if (kind == SyntaxKind.DoubleKeyword || kind == SyntaxKind.FloatKeyword)
                        {
                            condition = SyntaxFactory.BinaryExpression(SyntaxKind.LogicalOrExpression, condition,
                                SyntaxFactory.InvocationExpression(
                                    SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
                                        elementType, SyntaxFactory.IdentifierName("IsNaN")), _code.CreateArguments(x)));
                        }

                        return SyntaxFactory.IfStatement(SyntaxFactory.IdentifierName("found_"),
                            SyntaxFactory.Block(SyntaxFactory.IfStatement(condition,
                                SyntaxFactory.ExpressionStatement(assignmentExpressionSyntax))),
                            SyntaxFactory.ElseClause(SyntaxFactory.Block(
                                SyntaxFactory.ExpressionStatement(SyntaxFactory.AssignmentExpression(
                                    SyntaxKind.SimpleAssignmentExpression, SyntaxFactory.IdentifierName("found_"),
                                    SyntaxFactory.LiteralExpression(SyntaxKind.TrueLiteralExpression))),
                                SyntaxFactory.ExpressionStatement(assignmentExpressionSyntax))));
                    });
                });
        }

        public ExpressionSyntax RewriteAverage(TypeSyntax returnType, ExpressionSyntax collection, List<LinqStep> chain, InvocationExpressionSyntax node)
        {
            var elementType = (returnType as NullableTypeSyntax)?.ElementType ?? returnType;
            var primitive = ((PredefinedTypeSyntax) elementType).Keyword.Kind();

            ExpressionSyntax sumIdentifier = SyntaxFactory.IdentifierName("sum_");
            ExpressionSyntax countIdentifier = SyntaxFactory.IdentifierName("count_");

            if (primitive != SyntaxKind.DecimalKeyword)
            {
                sumIdentifier =
                    SyntaxFactory.CastExpression(_code.CreatePrimitiveType(SyntaxKind.DoubleKeyword), sumIdentifier);
                countIdentifier =
                    SyntaxFactory.CastExpression(_code.CreatePrimitiveType(SyntaxKind.DoubleKeyword), countIdentifier);
            }

            ExpressionSyntax division =
                SyntaxFactory.BinaryExpression(SyntaxKind.DivideExpression, sumIdentifier, countIdentifier);
            if (primitive != SyntaxKind.DoubleKeyword && primitive != SyntaxKind.DecimalKeyword)
                division = SyntaxFactory.CastExpression(elementType, SyntaxFactory.ParenthesizedExpression(division));

            return _rewrite.RewriteAsLoop(
                returnType,
                new[]
                {
                    _code.CreateLocalVariableDeclaration("sum_",
                        SyntaxFactory.CastExpression(
                            primitive == SyntaxKind.IntKeyword || primitive == SyntaxKind.LongKeyword
                                ? _code.CreatePrimitiveType(SyntaxKind.LongKeyword)
                                : primitive == SyntaxKind.DecimalKeyword
                                    ? _code.CreatePrimitiveType(SyntaxKind.DecimalKeyword)
                                    : _code.CreatePrimitiveType(SyntaxKind.DoubleKeyword),
                            SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression,
                                SyntaxFactory.Literal(0)))),
                    _code.CreateLocalVariableDeclaration("count_",
                        SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression,
                            SyntaxFactory.ParseToken("0L")))
                },
                new[]
                {
                    SyntaxFactory.Block(
                        SyntaxFactory.IfStatement(SyntaxFactory.BinaryExpression(SyntaxKind.EqualsExpression,
                                SyntaxFactory.IdentifierName("count_"),
                                SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression,
                                    SyntaxFactory.ParseToken("0"))),
                            returnType == elementType
                                ? (StatementSyntax) _code.CreateThrowException("System.InvalidOperationException",
                                    "The sequence did not contain any elements.")
                                : SyntaxFactory.ReturnStatement(
                                    SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression))
                        ),
                        SyntaxFactory.ReturnStatement(division)
                    )
                },
                collection,
                CodeCreationService.MaybeAddSelect(chain, node.ArgumentList.Arguments.Count != 0),
                (inv, arguments, param) =>
                {
                    var currentValue = SyntaxFactory.IdentifierName(param.Identifier.ValueText);
                    return SyntaxExtensions.IfNullableIsNotNull(elementType != returnType, currentValue, x =>
                        SyntaxFactory.CheckedStatement(SyntaxKind.CheckedStatement, SyntaxFactory.Block(
                            SyntaxFactory.ExpressionStatement(SyntaxFactory.PostfixUnaryExpression(
                                SyntaxKind.PostIncrementExpression, SyntaxFactory.IdentifierName("count_"))),
                            SyntaxFactory.ExpressionStatement(SyntaxFactory.AssignmentExpression(
                                SyntaxKind.AddAssignmentExpression, SyntaxFactory.IdentifierName("sum_"), x))
                        )));
                }
            );
        }

        public ExpressionSyntax RewriteAny(string aggregationMethod, ExpressionSyntax collection, List<LinqStep> chain)
            => _rewrite.RewriteAsLoop(
                _code.CreatePrimitiveType(SyntaxKind.BoolKeyword),
                Enumerable.Empty<StatementSyntax>(),
                new[]
                {
                    SyntaxFactory.ReturnStatement(SyntaxFactory.LiteralExpression(SyntaxKind.FalseLiteralExpression))
                },
                collection,
                CodeCreationService.MaybeAddFilter(chain, aggregationMethod == Constants.AnyWithConditionMethod),
                (inv, arguments, param)
                    => SyntaxFactory.ReturnStatement(
                        SyntaxFactory.LiteralExpression(SyntaxKind.TrueLiteralExpression)));

        public ExpressionSyntax RewriteForEach(ExpressionSyntax collection, List<LinqStep> chain)
            => _rewrite.RewriteAsLoop(
                _code.CreatePrimitiveType(SyntaxKind.VoidKeyword),
                Enumerable.Empty<StatementSyntax>(),
                Enumerable.Empty<StatementSyntax>(),
                collection,
                chain,
                (inv, arguments, param) =>
                {
                    var lambda = inv.Lambda ?? new Lambda((AnonymousFunctionExpressionSyntax) inv.Arguments.First());
                    return SyntaxFactory.ExpressionStatement(_code.InlineOrCreateMethod(lambda,
                        _code.CreatePrimitiveType(SyntaxKind.VoidKeyword), param));
                }
            );

        public ExpressionSyntax RewriteContains(ExpressionSyntax collection, List<LinqStep> chain, InvocationExpressionSyntax node)
        {
            var elementType = SyntaxFactory.ParseTypeName(ModelExtensions
                .GetTypeInfo(_data.Semantic, node.ArgumentList.Arguments.First().Expression).ConvertedType
                .ToDisplayString());
            var comparerIdentifier =
                ((elementType as NullableTypeSyntax)?.ElementType ?? elementType) is PredefinedTypeSyntax
                    ? null
                    : SyntaxFactory.IdentifierName("comparer_");
            return _rewrite.RewriteAsLoop(
                _code.CreatePrimitiveType(SyntaxKind.BoolKeyword),
                comparerIdentifier != null
                    ? new StatementSyntax[]
                    {
                        _code.CreateLocalVariableDeclaration("comparer_",
                            SyntaxFactory.ParseExpression("System.Collections.Generic.EqualityComparer<" + elementType +
                                                          ">.Default"))
                    }
                    : Enumerable.Empty<StatementSyntax>(),
                new[]
                {
                    SyntaxFactory.ReturnStatement(SyntaxFactory.LiteralExpression(SyntaxKind.FalseLiteralExpression))
                },
                collection,
                chain,
                (inv, arguments, param) =>
                {
                    var target = SyntaxFactory.IdentifierName("_target");
                    var current = SyntaxFactory.IdentifierName(param.Identifier.ValueText);
                    var condition = comparerIdentifier != null
                        ? SyntaxFactory.InvocationExpression(
                            SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
                                comparerIdentifier, SyntaxFactory.IdentifierName("Equals")),
                            _code.CreateArguments(current, target))
                        : (ExpressionSyntax) SyntaxFactory.BinaryExpression(SyntaxKind.EqualsExpression, current,
                            target);
                    return SyntaxFactory.IfStatement(condition,
                        SyntaxFactory.ReturnStatement(
                            SyntaxFactory.LiteralExpression(SyntaxKind.TrueLiteralExpression)));
                },
                additionalParameters: new[]
                {
                    Tuple.Create(_code.CreateParameter("_target", elementType),
                        node.ArgumentList.Arguments.First().Expression)
                }
            );
        }

        public ExpressionSyntax RewriteAll(ExpressionSyntax collection, List<LinqStep> chain)
            => _rewrite.RewriteAsLoop(
                _code.CreatePrimitiveType(SyntaxKind.BoolKeyword),
                Enumerable.Empty<StatementSyntax>(),
                new[]
                {
                    SyntaxFactory.ReturnStatement(SyntaxFactory.LiteralExpression(SyntaxKind.TrueLiteralExpression))
                },
                collection,
                chain,
                (inv, arguments, param) =>
                {
                    var lambda = (LambdaExpressionSyntax) inv.Arguments.First();
                    return SyntaxFactory.IfStatement(
                        SyntaxFactory.PrefixUnaryExpression(SyntaxKind.LogicalNotExpression,
                            SyntaxFactory.ParenthesizedExpression(_code.InlineOrCreateMethod(new Lambda(lambda),
                                _code.CreatePrimitiveType(SyntaxKind.BoolKeyword), param))),
                        SyntaxFactory.ReturnStatement(SyntaxFactory.LiteralExpression(SyntaxKind.FalseLiteralExpression)
                        ));
                });

        public ExpressionSyntax RewriteCount(TypeSyntax returnType, string aggregationMethod,
            ExpressionSyntax collection, List<LinqStep> chain)
            => _rewrite.RewriteAsLoop(
                returnType,
                new[]
                {
                    _code.CreateLocalVariableDeclaration("_count",
                        SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression,
                            SyntaxFactory.ParseToken(aggregationMethod == Constants.LongCountMethod ||
                                                     aggregationMethod == Constants.LongCountWithConditionMethod
                                ? "0L"
                                : "0")))
                },
                new[] {SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("_count"))},
                collection,
                CodeCreationService.MaybeAddFilter(chain,
                    aggregationMethod == Constants.CountWithConditionMethod ||
                    aggregationMethod == Constants.LongCountWithConditionMethod),
                (inv, arguments, param)
                    => SyntaxFactory.ExpressionStatement(
                        SyntaxFactory.PostfixUnaryExpression(SyntaxKind.PostIncrementExpression,
                            SyntaxFactory.IdentifierName("_count"))));

        public ExpressionSyntax RewriteElementAt(TypeSyntax returnType, string aggregationMethod,
            ExpressionSyntax collection, List<LinqStep> chain, InvocationExpressionSyntax node)
            => _rewrite.RewriteAsLoop(
                returnType,
                new[]
                {
                    _code.CreateLocalVariableDeclaration("_count",
                        SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression,
                            SyntaxFactory.ParseToken(aggregationMethod == Constants.LongCountMethod ||
                                                     aggregationMethod == Constants.LongCountWithConditionMethod
                                ? "0L"
                                : "0")))
                },
                new[]
                {
                    aggregationMethod == Constants.ElementAtMethod
                        ? (StatementSyntax) _code.CreateThrowException("System.InvalidOperationException",
                            "The specified index is not included in the sequence.")
                        : SyntaxFactory.ReturnStatement(SyntaxFactory.DefaultExpression(returnType))
                },
                collection,
                CodeCreationService.MaybeAddFilter(chain,
                    aggregationMethod == Constants.CountWithConditionMethod ||
                    aggregationMethod == Constants.LongCountWithConditionMethod),
                (inv, arguments, param)
                    => SyntaxFactory.IfStatement(
                        SyntaxFactory.BinaryExpression(SyntaxKind.EqualsExpression,
                            SyntaxFactory.IdentifierName("_requestedPosition"),
                            SyntaxFactory.PostfixUnaryExpression(SyntaxKind.PostIncrementExpression,
                                SyntaxFactory.IdentifierName("_count"))),
                        SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName(param.Identifier.ValueText))),
                additionalParameters: new[]
                {
                    Tuple.Create(_code.CreateParameter("_requestedPosition", _code.CreatePrimitiveType(SyntaxKind.IntKeyword)),
                        node.ArgumentList.Arguments.First().Expression)
                }
            );

        public ExpressionSyntax RewriteFirst(TypeSyntax returnType, string aggregationMethod,
            ExpressionSyntax collection, List<LinqStep> chain)
            => _rewrite.RewriteAsLoop(
                returnType,
                Enumerable.Empty<StatementSyntax>(),
                new[]
                {
                    _code.CreateThrowException("System.InvalidOperationException",
                        "The sequence did not contain any elements.")
                },
                collection,
                CodeCreationService.MaybeAddFilter(chain, aggregationMethod == Constants.FirstWithConditionMethod),
                (inv, arguments, param)
                    => SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName(param.Identifier.ValueText)));

        public ExpressionSyntax RewriteFirstOrDefault(TypeSyntax returnType, string aggregationMethod,
            ExpressionSyntax collection, List<LinqStep> chain)
            => _rewrite.RewriteAsLoop(
                returnType,
                Enumerable.Empty<StatementSyntax>(),
                new[] {SyntaxFactory.ReturnStatement(SyntaxFactory.DefaultExpression(returnType))},
                collection,
                CodeCreationService.MaybeAddFilter(chain, aggregationMethod == Constants.FirstOrDefaultWithConditionMethod),
                (inv, arguments, param)
                    => SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName(param.Identifier.ValueText)));

        public ExpressionSyntax RewriteLast(TypeSyntax returnType, string aggregationMethod,
            ExpressionSyntax collection, List<LinqStep> chain)
            => _rewrite.RewriteAsLoop(
                returnType,
                new[]
                {
                    _code.CreateLocalVariableDeclaration("_last", SyntaxFactory.DefaultExpression(returnType)),
                    _code.CreateLocalVariableDeclaration("_found",
                        SyntaxFactory.LiteralExpression(SyntaxKind.FalseLiteralExpression))
                },
                new StatementSyntax[]
                {
                    SyntaxFactory.IfStatement(
                        SyntaxFactory.PrefixUnaryExpression(SyntaxKind.LogicalNotExpression,
                            SyntaxFactory.IdentifierName("_found")),
                        _code.CreateThrowException("System.InvalidOperationException",
                            "The sequence did not contain any elements.")),
                    SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("_last"))
                },
                collection,
                CodeCreationService.MaybeAddFilter(chain, aggregationMethod == Constants.LastWithConditionMethod),
                (inv, arguments, param) => SyntaxFactory.Block(
                    SyntaxFactory.ExpressionStatement(SyntaxFactory.AssignmentExpression(
                        SyntaxKind.SimpleAssignmentExpression, SyntaxFactory.IdentifierName("_found"),
                        SyntaxFactory.LiteralExpression(SyntaxKind.TrueLiteralExpression))),
                    SyntaxFactory.ExpressionStatement(SyntaxFactory.AssignmentExpression(
                        SyntaxKind.SimpleAssignmentExpression, SyntaxFactory.IdentifierName("_last"),
                        SyntaxFactory.IdentifierName(param.Identifier.ValueText)))));

        public ExpressionSyntax RewriteLastOrDefault(TypeSyntax returnType, string aggregationMethod,
            ExpressionSyntax collection, List<LinqStep> chain)
            => _rewrite.RewriteAsLoop(
                returnType,
                new[] {_code.CreateLocalVariableDeclaration("_last", SyntaxFactory.DefaultExpression(returnType))},
                new[] {SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("_last"))},
                collection,
                CodeCreationService.MaybeAddFilter(chain, aggregationMethod == Constants.LastOrDefaultWithConditionMethod),
                (inv, arguments, param)
                    => SyntaxFactory.ExpressionStatement(SyntaxFactory.AssignmentExpression(
                        SyntaxKind.SimpleAssignmentExpression, SyntaxFactory.IdentifierName("_last"),
                        SyntaxFactory.IdentifierName(param.Identifier.ValueText))));

        public ExpressionSyntax RewriteSingle(TypeSyntax returnType, string aggregationMethod,
            ExpressionSyntax collection, List<LinqStep> chain)
            => _rewrite.RewriteAsLoop(
                returnType,
                new[]
                {
                    _code.CreateLocalVariableDeclaration("_last", SyntaxFactory.DefaultExpression(returnType)),
                    _code.CreateLocalVariableDeclaration("_found",
                        SyntaxFactory.LiteralExpression(SyntaxKind.FalseLiteralExpression))
                },
                new StatementSyntax[]
                {
                    SyntaxFactory.IfStatement(
                        SyntaxFactory.PrefixUnaryExpression(SyntaxKind.LogicalNotExpression,
                            SyntaxFactory.IdentifierName("_found")),
                        _code.CreateThrowException("System.InvalidOperationException",
                            "The sequence did not contain any elements.")),
                    SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("_last"))
                },
                collection,
                CodeCreationService.MaybeAddFilter(chain, aggregationMethod == Constants.SingleWithConditionMethod),
                (inv, arguments, param) => SyntaxFactory.Block(
                    SyntaxFactory.IfStatement(SyntaxFactory.IdentifierName("_found"),
                        _code.CreateThrowException("System.InvalidOperationException",
                            "The sequence contains more than one element.")),
                    SyntaxFactory.ExpressionStatement(SyntaxFactory.AssignmentExpression(
                        SyntaxKind.SimpleAssignmentExpression, SyntaxFactory.IdentifierName("_found"),
                        SyntaxFactory.LiteralExpression(SyntaxKind.TrueLiteralExpression))),
                    SyntaxFactory.ExpressionStatement(SyntaxFactory.AssignmentExpression(
                        SyntaxKind.SimpleAssignmentExpression, SyntaxFactory.IdentifierName("_last"),
                        SyntaxFactory.IdentifierName(param.Identifier.ValueText)))));

        public ExpressionSyntax RewriteSingleOrDefault(TypeSyntax returnType, string aggregationMethod, ExpressionSyntax collection, List<LinqStep> chain)
            => _rewrite.RewriteAsLoop(
                returnType,
                new[]
                {
                    _code.CreateLocalVariableDeclaration("_last", SyntaxFactory.DefaultExpression(returnType)),
                    _code.CreateLocalVariableDeclaration("_found",
                        SyntaxFactory.LiteralExpression(SyntaxKind.FalseLiteralExpression))
                },
                new StatementSyntax[] {SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("_last"))},
                collection,
                CodeCreationService.MaybeAddFilter(chain, aggregationMethod == Constants.SingleOrDefaultWithConditionMethod),
                (inv, arguments, param) => SyntaxFactory.Block(
                    SyntaxFactory.IfStatement(SyntaxFactory.IdentifierName("_found"),
                        _code.CreateThrowException("System.InvalidOperationException",
                            "The sequence contains more than one element.")),
                    SyntaxFactory.ExpressionStatement(SyntaxFactory.AssignmentExpression(
                        SyntaxKind.SimpleAssignmentExpression, SyntaxFactory.IdentifierName("_found"),
                        SyntaxFactory.LiteralExpression(SyntaxKind.TrueLiteralExpression))),
                    SyntaxFactory.ExpressionStatement(SyntaxFactory.AssignmentExpression(
                        SyntaxKind.SimpleAssignmentExpression, SyntaxFactory.IdentifierName("_last"),
                        SyntaxFactory.IdentifierName(param.Identifier.ValueText)))));

        public ExpressionSyntax RewriteToList(TypeSyntax returnType, string aggregationMethod, ExpressionSyntax collection, ITypeSymbol semanticReturnType, List<LinqStep> chain)
        {
            var count = chain.All(x => Constants.MethodsThatPreserveCount.Contains(x.MethodName))
                ? _code.CreateCollectionCount(collection, true)
                : null;
            var listIdentifier = SyntaxFactory.IdentifierName("_list");
            return _rewrite.RewriteAsLoop(
                returnType,
                new[]
                {
                    _code.CreateLocalVariableDeclaration("_list",
                        SyntaxFactory.ObjectCreationExpression(
                            SyntaxFactory.ParseTypeName("System.Collections.Generic.List<" +
                                                        _info.GetItemType(semanticReturnType).ToDisplayString() + ">"),
                            _code.CreateArguments(count != null ? new[] {count} : Enumerable.Empty<ExpressionSyntax>()),
                            null))
                },
                aggregationMethod == Constants.ReverseMethod
                    ? new StatementSyntax[]
                    {
                        SyntaxFactory.ExpressionStatement(SyntaxFactory.InvocationExpression(
                            SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
                                SyntaxFactory.IdentifierName("_list"), SyntaxFactory.IdentifierName("Reverse")))),
                        SyntaxFactory.ReturnStatement(listIdentifier)
                    }
                    : new[] {SyntaxFactory.ReturnStatement(listIdentifier)},
                collection,
                chain,
                (inv, arguments, param) => _code.CreateStatement(SyntaxFactory.InvocationExpression(
                    SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, listIdentifier,
                        SyntaxFactory.IdentifierName("Add")),
                    _code.CreateArguments(SyntaxFactory.IdentifierName(param.Identifier.ValueText)))));
        }

        public ExpressionSyntax RewriteToDict(TypeSyntax returnType, string aggregationMethod, ExpressionSyntax collection, List<LinqStep> chain, InvocationExpressionSyntax node)
        {
            var dictIdentifier = SyntaxFactory.IdentifierName("_dict");
            return _rewrite.RewriteAsLoop(
                returnType,
                new[]
                {
                    _code.CreateLocalVariableDeclaration("_dict",
                        SyntaxFactory.ObjectCreationExpression(returnType,
                            _code.CreateArguments(Enumerable.Empty<ArgumentSyntax>()), null))
                },
                new[] {SyntaxFactory.ReturnStatement(dictIdentifier)},
                collection,
                chain,
                (inv, arguments, param) =>
                {
                    var keyLambda = (AnonymousFunctionExpressionSyntax) node.ArgumentList.Arguments.First().Expression;
                    var valueLambda =
                        (AnonymousFunctionExpressionSyntax) node.ArgumentList.Arguments.ElementAtOrDefault(1)
                            ?.Expression;
                    return _code.CreateStatement(SyntaxFactory.InvocationExpression(
                        SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, dictIdentifier,
                            SyntaxFactory.IdentifierName("Add")),
                        _code.CreateArguments(
                            _code.InlineOrCreateMethod(new Lambda(keyLambda),
                                SyntaxFactory.ParseTypeName(_info.GetLambdaReturnType(keyLambda).ToDisplayString()), param),
                            aggregationMethod == Constants.ToDictionaryWithKeyValueMethod
                                ? _code.InlineOrCreateMethod(new Lambda(valueLambda),
                                    SyntaxFactory.ParseTypeName(_info.GetLambdaReturnType(valueLambda).ToDisplayString()), param)
                                : SyntaxFactory.IdentifierName(param.Identifier.ValueText))));
                }
            );
        }

        public ExpressionSyntax RewriteToArray(TypeSyntax returnType, ExpressionSyntax collection, List<LinqStep> chain)
        {
            var count = chain.All(x => Constants.MethodsThatPreserveCount.Contains(x.MethodName))
                ? _code.CreateCollectionCount(collection, false)
                : null;

            if (count != null)
            {
                var arrayIdentifier = SyntaxFactory.IdentifierName("_array");
                return _rewrite.RewriteAsLoop(
                    returnType,
                    new[]
                    {
                        _code.CreateLocalVariableDeclaration("_array",
                            SyntaxFactory.ArrayCreationExpression(SyntaxFactory.ArrayType(
                                ((ArrayTypeSyntax) returnType).ElementType,
                                SyntaxFactory.List(new[]
                                    {SyntaxFactory.ArrayRankSpecifier(_code.CreateSeparatedList(count))}))))
                    },
                    new[] {SyntaxFactory.ReturnStatement(arrayIdentifier)},
                    collection,
                    chain,
                    (inv, arguments, param)
                        => _code.CreateStatement(SyntaxFactory.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression,
                            SyntaxFactory.ElementAccessExpression(arrayIdentifier,
                                SyntaxFactory.BracketedArgumentList(
                                    _code.CreateSeparatedList(
                                        SyntaxFactory.Argument(SyntaxFactory.IdentifierName("_index"))))),
                            SyntaxFactory.IdentifierName(param.Identifier.ValueText))));
            }

            var listIdentifier = SyntaxFactory.IdentifierName("_list");
            var listType =
                SyntaxFactory.ParseTypeName("System.Collections.Generic.List<" +
                                            ((ArrayTypeSyntax) returnType).ElementType + ">");
            return _rewrite.RewriteAsLoop(
                returnType,
                new[]
                {
                    _code.CreateLocalVariableDeclaration("_list",
                        SyntaxFactory.ObjectCreationExpression(listType,
                            _code.CreateArguments(Enumerable.Empty<ArgumentSyntax>()), null))
                },
                new[]
                {
                    SyntaxFactory.ReturnStatement(SyntaxFactory.InvocationExpression(
                        SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
                            listIdentifier, SyntaxFactory.IdentifierName("ToArray"))))
                },
                collection,
                chain,
                (inv, arguments, param)
                    => _code.CreateStatement(SyntaxFactory.InvocationExpression(
                        SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
                            listIdentifier, SyntaxFactory.IdentifierName("Add")),
                        _code.CreateArguments(SyntaxFactory.IdentifierName(param.Identifier.ValueText)))));
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
    }
}