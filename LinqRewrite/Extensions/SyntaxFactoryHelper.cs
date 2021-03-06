﻿using System;
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

        public static DefaultExpressionSyntax Default(TypeBridge type)
            => DefaultExpression(type);

        public static TypedValueBridge ReusableConst(this RewrittenValueBridge e, RewriteDesign design, bool? reuse = null)
            => ReusableConst(e.New, design, e.Old.GetType(design), reuse);

        public static TypedValueBridge ReusableConst(this TypedValueBridge e, RewriteDesign design, bool? reuse = null)
            => ReusableConst(e.Value, design, e.Type, reuse);

        public static TypedValueBridge ReusableConst(this ValueBridge e, RewriteDesign design, TypeBridge type, bool? reuse = null)
        {
            if (reuse == false) return new TypedValueBridge(type, e);
            if (reuse == null && IsReusable(e))
            {
                if (e is LocalVariable localVariable)
                    localVariable.IsGlobal = true;
                return new TypedValueBridge(type, e);
            }

            var tmpVariable = VariableExtensions.CreateSuperGlobalVariable(design, type, e);
            return new TypedValueBridge(type.Type, IdentifierName(tmpVariable));
        }

        public static TypedValueBridge ReusableForConst(this ValueBridge e, RewriteDesign design, TypeBridge type, IteratorDesign iterator, bool? reuse = null)
        {
            if (reuse == false) return new TypedValueBridge(type, e);
            if (reuse == null && IsReusable(e))
            {
                if (e is LocalVariable localVariable)
                    localVariable.IsGlobal = true;
                return new TypedValueBridge(type, e);
            }

            var tmpVariable = VariableExtensions.CreateGlobalVariable(design, type, e, iterator);
            return new TypedValueBridge(type.Type, IdentifierName(tmpVariable));
        }

        public static TypedValueBridge Reusable(this ValueBridge e, RewriteDesign design, TypeBridge type, bool? reuse = null)
        {
            if (reuse == false) return new TypedValueBridge(type, e);
            if (reuse == null && IsReusable(e))
            {
                if (e is LocalVariable localVariable)
                    localVariable.IsUsed = true;
                return new TypedValueBridge(type, e);
            }

            var tmpVariable = VariableExtensions.CreateLocalVariable(design, type);
            design.ForAdd(tmpVariable.Assign(e));
            tmpVariable.IsUsed = true;
            return new TypedValueBridge(type.Type, IdentifierName(tmpVariable));
        }

        public static TypedValueBridge Reusable(this TypedValueBridge e, RewriteDesign design, bool? reuse = null)
            => Reusable(e.Value, design, e.Type, reuse);

        public static TypedValueBridge Inline(this ExpressionSyntax e, RewriteDesign design,
            params TypedValueBridge[] values)
            => Inline(new RewrittenValueBridge(e), design, values);

        public static TypedValueBridge Inline(this RewrittenValueBridge e, RewriteDesign design,
            params TypedValueBridge[] values)
        {
            TypeBridge returnType;
            if (e.OldVal is LambdaExpressionSyntax lambda)
                returnType = lambda.ReturnType(design);
            else returnType = ParseTypeName(((INamedTypeSymbol)design.Semantic.GetTypeInfo(e.OldVal).ConvertedType).DelegateInvokeMethod.ReturnType.ToDisplayString());
            
            if (IsLambdaSimple(e.OldVal))
                return design.Code.InlineLambda(design, e, returnType, values);

            var val = values.Select(x =>
            {
                if (IsReusable(x)) return x;
                var inlineVariable = VariableExtensions.CreateLocalVariable(design, x.Type);
                design.ForAdd(inlineVariable.Assign(x));
                return new TypedValueBridge(x.Type, inlineVariable);
            }).ToArray();
            return design.Code.InlineLambda(design, e, returnType, val);
        }

        public static bool IsLambdaSimple(ExpressionSyntax e)
        {
            int maxParams;
            if (e is SimpleLambdaExpressionSyntax l)
                maxParams = Regex.Matches(l.ExpressionBody.ToString(), l.Parameter.ToString()).Count;
            else if (e is ParenthesizedLambdaExpressionSyntax p)
                maxParams = p.ParameterList.Parameters.Max(x => Regex.Matches(
                    p.ExpressionBody.ToString(), x.ToString()).Count);
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

        public static TypeBridge GetType(this RewrittenValueBridge expression, RewriteDesign design)
            => design.Semantic.GetTypeFromExpression(expression.Old);

        public static TypeBridge GetType(this ValueBridge expression, RewriteDesign design)
            => design.Semantic.GetTypeFromExpression(expression);

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

        public static TypeBridge ReturnType(this LambdaExpressionSyntax lambda, RewriteDesign design)
            => CodeCreationService.GetLambdaReturnType(design.Semantic, lambda);
        
        public static TypeBridge ReturnType(this RewrittenValueBridge rewritten, RewriteDesign design)
        {
            var old = (LambdaExpressionSyntax) rewritten.OldVal;
            return CodeCreationService.GetLambdaReturnType(design.Semantic, old);
        }

        public static ValueBridge Parenthesize(ExpressionSyntax expression)
            => ParenthesizedExpression(expression);

        public static bool Invokable1Param(this ExpressionSyntax e, RewriteDesign design)
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
                        return ((INamedTypeSymbol) design.Semantic.GetTypeInfo(e).ConvertedType).DelegateInvokeMethod.Parameters.Length < 2;
                    }
                    catch (Exception)
                    {
                        return false;
                    };
            }
        }

        public static bool IsInvokable(this ExpressionSyntax e, RewriteDesign design)
        {
            switch (e)
            {
                case SimpleLambdaExpressionSyntax _:
                case LambdaExpressionSyntax _:
                    return true;
                default:
                    try
                    {
                        var _ = ((INamedTypeSymbol) design.Semantic.GetTypeInfo(e).ConvertedType).DelegateInvokeMethod.Parameters;
                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    };
            }
        }
    }
}