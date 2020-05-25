using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using LinqRewrite.DataStructures;
using LinqRewrite.Services;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.Extensions
{
    public static class SyntaxFactoryHelper
    {
        public static SeparatedSyntaxList<ExpressionSyntax> CreateSeparatedExpressionList<T>(params T[] items)
            where T : SyntaxNode
            => SeparatedList(items.Cast<ExpressionSyntax>());

        public static SeparatedSyntaxList<T> CreateSeparatedList<T>(params T[] items) where T : SyntaxNode
            => SeparatedList(items);

        public static StatementSyntax AggregateStatementSyntax(IList<StatementSyntax> syntax)
            => syntax.Count switch
            {
                0 => EmptyStatement(),
                1 => syntax[0],
                _ => Block(syntax)
            };

        public static ThrowStatementSyntax Throw(string type, string message = null) 
            => ThrowStatement(
                ObjectCreationExpression(
                    ParseTypeName(type),
                    CreateArguments(message != null
                        ? new ValueBridge[]
                        {
                            LiteralExpression(SyntaxKind.StringLiteralExpression,
                                Literal(message))
                        }
                        : new ValueBridge[] { }), null));

        public static ThrowExpressionSyntax ThrowExpression(string type, string message = null)
            => SyntaxFactory.ThrowExpression(
                ObjectCreationExpression(
                    ParseTypeName(type),
                    CreateArguments(message != null
                        ? new ValueBridge[]
                        {
                            LiteralExpression(SyntaxKind.StringLiteralExpression,
                                Literal(message))
                        }
                        : new ValueBridge[] { }), null));

        public static SeparatedSyntaxList<T> CreateSeparatedList<T>(IEnumerable<T> items) where T : SyntaxNode
            => SeparatedList(items);

        public static ArgumentSyntax Argument(ValueBridge value)
            => SyntaxFactory.Argument(value);

        public static ArgumentSyntax Argument(TypedValueBridge value)
            => SyntaxFactory.Argument(value);

        public static ArgumentSyntax RefArg(VariableBridge name)
            => SyntaxFactory.Argument(null, Token(SyntaxKind.RefKeyword), name);

        public static ArgumentSyntax OutArg(VariableBridge name)
            => SyntaxFactory.Argument(null, Token(SyntaxKind.OutKeyword), name);

        public static ValueBridge Invoke(this string identifier)
            => InvocationExpression(IdentifierName(identifier));
        public static ValueBridge Invoke(this VariableBridge source)
            => InvocationExpression(source);
        public static ValueBridge Invoke(this ExpressionSyntax source)
            => InvocationExpression(source);

        public static ValueBridge Invoke(this ExpressionSyntax invoked, params ArgumentBridge[] args)
            => InvocationExpression(invoked, ArgumentList(CreateSeparatedList(args.Select(x => (ArgumentSyntax) x))));

        public static InvocationExpressionSyntax Invoke(this ExpressionSyntax invoked, ValueBridge[] args)
            => InvocationExpression(invoked, ArgumentList(CreateSeparatedList(args.Select(Argument))));
        public static InvocationExpressionSyntax Invoke(this VariableBridge source, ValueBridge[] args)
            => InvocationExpression(source, ArgumentList(CreateSeparatedList(args.Select(Argument))));

        public static ArgumentListSyntax CreateArguments(params ArgumentSyntax[] items)
            => ArgumentList(CreateSeparatedList(items));

        public static ArgumentListSyntax CreateArguments(IEnumerable<ValueBridge> items)
            => ArgumentList(CreateSeparatedList(items.Select(Argument)));

        public static ArgumentListSyntax CreateArguments(params ValueBridge[] items)
            => ArgumentList(CreateSeparatedList(items.Select(Argument)));

        public static ArgumentListSyntax CreateArguments(IEnumerable<ArgumentSyntax> items)
            => ArgumentList(CreateSeparatedList(items));

        public static ParameterListSyntax CreateParameters(IEnumerable<ParameterSyntax> items)
            => ParameterList(CreateSeparatedList(items));

        public static ParameterSyntax CreateParameter(SyntaxToken name, ITypeSymbol type)
            => Parameter(name).WithType(ParseTypeName(type.ToDisplayString()));

        public static ParameterSyntax CreateParameter(SyntaxToken name, TypeSyntax type)
            => Parameter(name).WithType(type);

        public static ParameterSyntax CreateParameter(string name, ITypeSymbol type)
            => CreateParameter(Identifier(name), type);

        public static ParameterSyntax CreateParameter(string name, TypeSyntax type)
            => CreateParameter(Identifier(name), type);

        public static ContinueStatementSyntax Continue()
            => ContinueStatement();

        public static BreakStatementSyntax Break()
            => BreakStatement();

        public static ObjectCreationExpressionSyntax New(TypeBridge type, params ValueBridge[] args)
            => ObjectCreationExpression(type, CreateArguments(args.Select(Argument)), null);

        public static WhileStatementSyntax While(ValueBridge @while, StatementBridge @do)
            => WhileStatement(@while, @do);

        public static IfStatementSyntax If(ValueBridge @if, StatementBridge @do)
            => IfStatement(@if, @do);

        public static IfStatementSyntax If(ValueBridge @if, StatementBridge @do, StatementBridge @else)
            => IfStatement(@if, @do, ElseClause(@else));

        public static TryStatementSyntax TryF(BlockSyntax @try, BlockSyntax @finally)
            => TryStatement(@try, new SyntaxList<CatchClauseSyntax>(), FinallyClause(@finally));

        public static StatementBridge Return(ValueBridge _)
            => ReturnStatement(_);

        public static DefaultExpressionSyntax Default(TypeBridge @type)
            => DefaultExpression(@type);

        public static TypedValueBridge ReusableConst(this RewrittenValueBridge e, RewriteParameters p, bool? reuse = null)
            => ReusableConst(e.New, p, e.Old.GetType(p), reuse);

        public static TypedValueBridge ReusableConst(this TypedValueBridge e, RewriteParameters p, bool? reuse = null)
            => ReusableConst(e.Value, p, e.Type, reuse);

        public static TypedValueBridge ReusableConst(this ValueBridge e, RewriteParameters p, TypeBridge type, bool? reuse = null)
        {
            if (reuse == false) return new TypedValueBridge(type, e);
            if (reuse == null && IsReusable(e))
            {
                if (e is LocalVariable localVariable)
                    localVariable.IsGlobal = true;
                return new TypedValueBridge(type, e);
            }

            var tmpVariable = VariableCreator.SuperGlobalVariable(p, type, e);
            return new TypedValueBridge(type.Type, IdentifierName(tmpVariable));
        }

        public static TypedValueBridge ReusableForConst(this ValueBridge e, RewriteParameters p, TypeBridge type, IteratorParameters iterator, bool? reuse = null)
        {
            if (reuse == false) return new TypedValueBridge(type, e);
            if (reuse == null && IsReusable(e))
            {
                if (e is LocalVariable localVariable)
                    localVariable.IsGlobal = true;
                return new TypedValueBridge(type, e);
            }

            var tmpVariable = VariableCreator.GlobalVariable(p, type, e, iterator);
            return new TypedValueBridge(type.Type, IdentifierName(tmpVariable));
        }

        public static TypedValueBridge Reusable(this ValueBridge e, RewriteParameters p, TypeBridge type, bool? reuse = null)
        {
            if (reuse == false) return new TypedValueBridge(type, e);
            if (reuse == null && IsReusable(e))
            {
                if (e is LocalVariable localVariable)
                    localVariable.IsUsed = true;
                return new TypedValueBridge(type, e);
            }

            var tmpVariable = VariableCreator.LocalVariable(p, type);
            p.ForAdd(tmpVariable.Assign(e));
            tmpVariable.IsUsed = true;
            return new TypedValueBridge(type.Type, IdentifierName(tmpVariable));
        }

        public static TypedValueBridge Reusable(this TypedValueBridge e, RewriteParameters p, bool? reuse = null)
            => Reusable(e.Value, p, e.Type, reuse);

        public static TypedValueBridge Inline(this ExpressionSyntax e, RewriteParameters p,
            params TypedValueBridge[] values)
            => Inline(new RewrittenValueBridge(e), p, values);

        public static TypedValueBridge Inline(this RewrittenValueBridge e, RewriteParameters p,
            params TypedValueBridge[] values)
        {
            TypeBridge returnType;
            if (e.OldVal is LambdaExpressionSyntax lambda)
                returnType = lambda.ReturnType(p);
            else returnType = ParseTypeName(((INamedTypeSymbol)p.Semantic.GetTypeInfo(e.OldVal).ConvertedType).DelegateInvokeMethod.ReturnType.ToDisplayString());
            
            if (IsLambdaSimple(e.OldVal))
                return p.Code.InlineLambda(p, e, returnType, values);

            var val = values.Select(x =>
            {
                if (IsReusable(x)) return x;
                var inlineVariable = VariableCreator.LocalVariable(p, x.Type);
                p.ForAdd(inlineVariable.Assign(x));
                return new TypedValueBridge(x.Type, inlineVariable);
            }).ToArray();
            return p.Code.InlineLambda(p, e, returnType, val);
        }

        public static bool IsLambdaSimple(ExpressionSyntax e)
        {
            int maxParams;
            if (e is SimpleLambdaExpressionSyntax l)
                maxParams = Regex.Matches(ExpressionSimplifier.Simplify(l.ExpressionBody).ToString(), l.Parameter.ToString()).Count;
            else if (e is ParenthesizedLambdaExpressionSyntax p)
                maxParams = p.ParameterList.Parameters.Max(x => Regex.Matches(
                    ExpressionSimplifier.Simplify(p.ExpressionBody).ToString(), x.ToString()).Count);
            else return true;

            return maxParams <= 1;
        }

        public static bool IsReusable(ExpressionSyntax e)
        {
            while (e is ParenthesizedExpressionSyntax par)
                e = par.Expression;
            if (e is MemberAccessExpressionSyntax memberAccess && memberAccess.Name.ToString() == "Length")
                return true;
            return e is BaseExpressionSyntax
                   || e is ThisExpressionSyntax
                   || e is IdentifierNameSyntax
                   || e is LiteralExpressionSyntax
                   || e is DefaultExpressionSyntax
                   || e is RefExpressionSyntax
                   || e is SizeOfExpressionSyntax
                   || e is TypeOfExpressionSyntax
                   || e is ElementAccessExpressionSyntax
                   || e is PostfixUnaryExpressionSyntax
                   || e is PrefixUnaryExpressionSyntax;
        }

        public static TypeBridge GetType(this RewrittenValueBridge expression, RewriteParameters p)
            => p.Semantic.GetTypeFromExpression(expression.Old);

        public static TypeBridge GetType(this ValueBridge expression, RewriteParameters p)
            => p.Semantic.GetTypeFromExpression(expression);

        public static BlockSyntax Block(params StatementBridge[] statements)
            => SyntaxFactory.Block(statements.Select(x => (StatementSyntax) x));

        public static BlockSyntax Block(IList<StatementSyntax> statements)
            => SyntaxFactory.Block(statements);

        public static ArrayTypeSyntax ArrayType(this TypedValueBridge value)
            => ArrayType(value.Type);

        public static ArrayTypeSyntax ArrayType(this TypeBridge type)
            => ArrayType(type.Type);

        public static ArrayTypeSyntax ArrayType(this TypeSyntax type)
        {
            if (type is ArrayTypeSyntax arrayType)
            {
                return arrayType.WithRankSpecifiers(new SyntaxList<ArrayRankSpecifierSyntax>(arrayType.RankSpecifiers.Concat(new []
                {
                    ArrayRankSpecifier(
                        CreateSeparatedExpressionList(
                            OmittedArraySizeExpression(Token(SyntaxKind.OmittedArraySizeExpressionToken))))
                })));
            }
            return SyntaxFactory.ArrayType(type,
                new SyntaxList<ArrayRankSpecifierSyntax>(ArrayRankSpecifier(
                    CreateSeparatedExpressionList(
                        OmittedArraySizeExpression(Token(SyntaxKind.OmittedArraySizeExpressionToken))))));
        }

        public static TypeBridge ReturnType(this LambdaExpressionSyntax lambda, RewriteParameters p)
            => CodeCreationService.GetLambdaReturnType(p.Semantic, lambda);
        
        public static TypeBridge ReturnType(this RewrittenValueBridge rewritten, RewriteParameters p)
        {
            var old = (LambdaExpressionSyntax) rewritten.OldVal;
            return CodeCreationService.GetLambdaReturnType(p.Semantic, old);
        }

        public static ValueBridge Parenthesize(ExpressionSyntax expression)
            => ParenthesizedExpression(expression);

        public static bool Invokable1Param(this ExpressionSyntax e, RewriteParameters p)
        {
            switch (e)
            {
                case SimpleLambdaExpressionSyntax _:
                    return true;
                case LambdaExpressionSyntax _:
                    return false;
                default:
                    try
                    {
                        return ((INamedTypeSymbol) p.Semantic.GetTypeInfo(e).ConvertedType).DelegateInvokeMethod.Parameters.Length < 2;
                    }
                    catch (Exception)
                    {
                        return false;
                    };
            }
        }

        public static bool IsInvokable(this ExpressionSyntax e, RewriteParameters p)
        {
            switch (e)
            {
                case SimpleLambdaExpressionSyntax _:
                case LambdaExpressionSyntax _:
                    return true;
                default:
                    try
                    {
                        var _ = ((INamedTypeSymbol) p.Semantic.GetTypeInfo(e).ConvertedType).DelegateInvokeMethod.Parameters;
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    };
            }
        }
    };
}