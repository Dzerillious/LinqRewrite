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

        private static int _inlineCounter;
        public static ExpressionSyntax InlinePreForLast(this ExpressionSyntax method, RewriteParameters p)
        {
            if (p.LastItem.IsExpressionSimple() && method.IsLambdaExpressionSimple())
                return method.Inline(p, p.LastItem);
            
            var inlineVariable = "__inlined" + _inlineCounter++;
            p.PreForAdd(VariableExtensions.LocalVariableCreation(inlineVariable, method.Inline(p, p.LastItem)));
            return SyntaxFactory.IdentifierName(inlineVariable);
        }
        
        public static ExpressionSyntax InlineForLast(this ExpressionSyntax method, RewriteParameters p)
        {
            if (p.LastItem.IsExpressionSimple() && method.IsLambdaExpressionSimple())
                return method.Inline(p, p.LastItem);
            
            var inlineVariable = "__inlined" + _inlineCounter++;
            p.ForAdd(VariableExtensions.LocalVariableCreation(inlineVariable, method.Inline(p, p.LastItem)));
            return SyntaxFactory.IdentifierName(inlineVariable);
        }
        
        public static ExpressionSyntax InlinePostLast(this ExpressionSyntax method, RewriteParameters p)
        {
            if (p.LastItem.IsExpressionSimple() && method.IsLambdaExpressionSimple())
                return method.Inline(p, p.LastItem);
            
            var inlineVariable = "__inlined" + _inlineCounter++;
            p.PostForAdd(VariableExtensions.LocalVariableCreation(inlineVariable, method.Inline(p, p.LastItem)));
            return SyntaxFactory.IdentifierName(inlineVariable);
        }

        public static ExpressionSyntax Inline(this ExpressionSyntax method, RewriteParameters p, ExpressionSyntax last)
            => p.Code.InlineLambda(p.Semantic, method, last);

        public static bool IsExpressionSimple(this ExpressionSyntax e)
            => !(e is BinaryExpressionSyntax)
               && !(e is PostfixUnaryExpressionSyntax)
               && !(e is PrefixUnaryExpressionSyntax)
               && !(e is InvocationExpressionSyntax)
               && !(e is ParenthesizedExpressionSyntax)
               && !(e is ConditionalExpressionSyntax);

        public static bool IsLambdaExpressionSimple(this ExpressionSyntax e)
        {
            if (!(e is SimpleLambdaExpressionSyntax l)) return false;
            
            var count = Regex.Matches(l.ToString(), l.Parameter.ToString()).Count;
            return count <= 2
                   && !(l.Body is InvocationExpressionSyntax)
                   && !(l.Body is ParenthesizedExpressionSyntax)
                   && !(l.Body is ConditionalExpressionSyntax);
        }
    }
}