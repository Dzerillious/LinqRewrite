using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;

namespace Shaman.Roslyn.LinqRewrite.Extensions
{
    public static class SyntaxFactoryHelper
    {
        public static SeparatedSyntaxList<ExpressionSyntax> CreateSeparatedExpressionList<T>(params T[] items) where T : SyntaxNode
            => SyntaxFactory.SeparatedList(items.Cast<ExpressionSyntax>());
        
        public static SeparatedSyntaxList<T> CreateSeparatedList<T>(params T[] items) where T : SyntaxNode
            => SyntaxFactory.SeparatedList(items);

        public static StatementSyntax AggregateStatementSyntax(List<StatementSyntax> syntax) 
            => syntax.Count switch
            {
                0 => SyntaxFactory.EmptyStatement(),
                1 => syntax[0],
                _ => SyntaxFactory.Block(syntax)
            };

        public static ThrowExpressionSyntax CreateThrowException(string type, string message = null)
            => SyntaxFactory.ThrowExpression(
                SyntaxFactory.ObjectCreationExpression(
                    SyntaxFactory.ParseTypeName(type),
                    CreateArguments(message != null
                        ? new ExpressionSyntax[]
                        {
                            SyntaxFactory.LiteralExpression(SyntaxKind.StringLiteralExpression,
                                SyntaxFactory.Literal(message))
                        }
                        : new ExpressionSyntax[] { }), null));

        public static SeparatedSyntaxList<T> CreateSeparatedList<T>(IEnumerable<T> items) where T : SyntaxNode
            => SyntaxFactory.SeparatedList(items);

        public static ArgumentListSyntax CreateArguments(IEnumerable<ExpressionSyntax> items)
            => CreateArguments(items.Select(SyntaxFactory.Argument));

        public static ArgumentListSyntax CreateArguments(params ExpressionSyntax[] items)
            => CreateArguments((IEnumerable<ExpressionSyntax>) items);

        public static ArgumentSyntax Argument(ValueBridge name)
            => SyntaxFactory.Argument(name);
        
        public static ArgumentSyntax RefArgument(VariableBridge name)
            => SyntaxFactory.Argument(null, SyntaxFactory.Token(SyntaxKind.RefKeyword), name);

        public static ArgumentSyntax OutArgument(VariableBridge name)
            => SyntaxFactory.Argument(null, SyntaxFactory.Token(SyntaxKind.OutKeyword), name);

        public static InvocationExpressionSyntax Invoke(this string identifier)
            => SyntaxFactory.InvocationExpression(SyntaxFactory.IdentifierName(identifier));
        public static InvocationExpressionSyntax Invoke(this ExpressionSyntax source)
            => SyntaxFactory.InvocationExpression(source);
        public static InvocationExpressionSyntax Invoke(this ExpressionSyntax invoked, params ArgumentSyntax[] args)
            => SyntaxFactory.InvocationExpression(invoked, SyntaxFactory.ArgumentList(CreateSeparatedList(args)));
        public static InvocationExpressionSyntax Invoke(this ExpressionSyntax invoked, params ValueBridge[] args)
            => SyntaxFactory.InvocationExpression(invoked, SyntaxFactory.ArgumentList(CreateSeparatedList(args.Select(Argument))));

        public static ArgumentListSyntax CreateArguments(params ArgumentSyntax[] items)
            => SyntaxFactory.ArgumentList(CreateSeparatedList(items));
        
        public static ArgumentListSyntax CreateArguments(params ValueBridge[] items)
            => SyntaxFactory.ArgumentList(CreateSeparatedList(items.Select(Argument)));
        
        public static ArgumentListSyntax CreateArguments(IEnumerable<ArgumentSyntax> items)
            => SyntaxFactory.ArgumentList(CreateSeparatedList(items));

        public static ParameterListSyntax CreateParameters(IEnumerable<ParameterSyntax> items)
            => SyntaxFactory.ParameterList(CreateSeparatedList(items));

        public static ParameterSyntax CreateParameter(SyntaxToken name, ITypeSymbol type)
            => SyntaxFactory.Parameter(name).WithType(SyntaxFactory.ParseTypeName(type.ToDisplayString()));

        public static ParameterSyntax CreateParameter(SyntaxToken name, TypeSyntax type)
            => SyntaxFactory.Parameter(name).WithType(type);

        public static ParameterSyntax CreateParameter(string name, ITypeSymbol type)
            => CreateParameter(SyntaxFactory.Identifier(name), type);

        public static ParameterSyntax CreateParameter(string name, TypeSyntax type)
            => CreateParameter(SyntaxFactory.Identifier(name), type);

        public static ContinueStatementSyntax Continue()
            => SyntaxFactory.ContinueStatement();

        public static BreakStatementSyntax Break()
            => SyntaxFactory.BreakStatement();

        public static ObjectCreationExpressionSyntax New(TypeBridge type, params ValueBridge[] args)
            => SyntaxFactory.ObjectCreationExpression(type, CreateArguments(args.Select(Argument)), null);

        public static IfStatementSyntax If(ValueBridge @if, StatementBridge @do)
            => SyntaxFactory.IfStatement(@if, @do);

        public static IfStatementSyntax If(ValueBridge @if, StatementBridge @do, StatementBridge @else)
            => SyntaxFactory.IfStatement(@if, @do, SyntaxFactory.ElseClause(@else));

        
        public static ReturnStatementSyntax Return(ValueBridge @returned)
            => SyntaxFactory.ReturnStatement(@returned);

        public static DefaultExpressionSyntax Default(TypeBridge @type)
            => SyntaxFactory.DefaultExpression(@type);

        private static int _tmpCounter;
        
        public static ExpressionSyntax Reusable(this ExpressionSyntax e, RewriteParameters p)
        {
            if (e.IsExpressionReusable()) return e;
            
            var tmpVariable = "__tmp" + _tmpCounter++;
            p.ForAdd(VariableExtensions.LocalVariableCreation(tmpVariable, e));
            return SyntaxFactory.IdentifierName(tmpVariable);
        }

        public static ExpressionSyntax Inline(this ExpressionSyntax method, RewriteParameters p, ExpressionSyntax last)
            => p.Code.InlineLambda(p.Semantic, method, last);
        
        public static ExpressionSyntax InlineForLast(this ExpressionSyntax e, RewriteParameters p)
        {
            if (e.IsLambdaExpressionSimple(p.LastItem))
                return e.Inline(p, p.LastItem);
            
            var inlineVariable = "__tmp" + _tmpCounter++;
            p.ForAdd(VariableExtensions.LocalVariableCreation(inlineVariable, p.LastItem));
            return e.Inline(p, SyntaxFactory.IdentifierName(inlineVariable));
        }

        public static bool IsLambdaExpressionSimple(this ExpressionSyntax e, ExpressionSyntax body)
        {
            if (!(e is SimpleLambdaExpressionSyntax l)) return true;
            
            var count = Regex.Matches(l.ToString(), l.Parameter.ToString()).Count;
            return count switch
            {
                1 => true,
                2 => true, // Counts left side of lambda too
                // 3 => NotVeryCostly(body),
                // 4 => (NotVeryCostly(body) && !(body is BinaryExpressionSyntax)),
                //
                // 5 => (NotVeryCostly(body) && !(body is BinaryExpressionSyntax) &&
                //       !(body is PostfixUnaryExpressionSyntax) && !(body is PrefixUnaryExpressionSyntax) &&
                //       !(body is SizeOfExpressionSyntax) && !(body is TypeOfExpressionSyntax)),
                //
                // _ => body.IsExpressionReusable()
                _ => IsExpressionReusable(body)
            };
        }

        public static bool NotVeryCostly(this ExpressionSyntax e)
            => !(e is InvocationExpressionSyntax)
               && !(e is ParenthesizedExpressionSyntax)
               && !(e is ConditionalExpressionSyntax)
               && !(e is AwaitExpressionSyntax)
               && !(e is SimpleLambdaExpressionSyntax)
               && !(e is ParenthesizedLambdaExpressionSyntax)
               && !(e is ObjectCreationExpressionSyntax)
               && !(e is IsPatternExpressionSyntax)
               && !(e is InterpolatedStringExpressionSyntax)
               && !(e is ArrayCreationExpressionSyntax)
               && !(e is TupleExpressionSyntax)
               && !(e is SwitchExpressionSyntax)
               && !(e is RangeExpressionSyntax)
               && !(e is QueryExpressionSyntax)
               && !(e is LambdaExpressionSyntax)
               && !(e is InitializerExpressionSyntax);

        public static bool IsExpressionReusable(this ExpressionSyntax e) =>
            e is BaseExpressionSyntax
            || e is ThisExpressionSyntax
            || e is IdentifierNameSyntax
            || e is LiteralExpressionSyntax
            || e is DefaultExpressionSyntax
            || e is RefExpressionSyntax
            || e is SizeOfExpressionSyntax
            || e is TypeOfExpressionSyntax
            || e is ElementAccessExpressionSyntax
            || e is MemberAccessExpressionSyntax
            || e is PostfixUnaryExpressionSyntax
            || e is PrefixUnaryExpressionSyntax;
    }
}