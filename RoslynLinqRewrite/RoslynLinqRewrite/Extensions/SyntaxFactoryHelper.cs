using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SimpleCollections.SimpleList;

namespace Shaman.Roslyn.LinqRewrite.Extensions
{
    public static class SyntaxFactoryHelper
    {
        public static SeparatedSyntaxList<ExpressionSyntax> CreateSeparatedExpressionList<T>(params T[] items) where T : SyntaxNode
            => SyntaxFactory.SeparatedList(items.Cast<ExpressionSyntax>());
        
        public static SeparatedSyntaxList<T> CreateSeparatedList<T>(params T[] items) where T : SyntaxNode
            => SyntaxFactory.SeparatedList(items);

        public static ElementAccessExpressionSyntax ArrayAccess(this ExpressionSyntax array, ExpressionSyntax index)
            => SyntaxFactory.ElementAccessExpression(
                array, SyntaxFactory.BracketedArgumentList(CreateSeparatedList(SyntaxFactory.Argument(index))));

        public static ElementAccessExpressionSyntax ArrayAccess(this ExpressionSyntax array, string identifier)
            => SyntaxFactory.ElementAccessExpression(
                array, SyntaxFactory.BracketedArgumentList(CreateSeparatedList(SyntaxFactory.Argument(SyntaxFactory.IdentifierName(identifier)))));

        public static ElementAccessExpressionSyntax ArrayAccess(this string arrayName, ExpressionSyntax index)
            => SyntaxFactory.ElementAccessExpression(
                SyntaxFactory.IdentifierName(arrayName),
                SyntaxFactory.BracketedArgumentList(CreateSeparatedList(SyntaxFactory.Argument(index))));

        public static ElementAccessExpressionSyntax ArrayAccess(this string arrayName, string identifier)
            => SyntaxFactory.ElementAccessExpression(
                SyntaxFactory.IdentifierName(arrayName),
                SyntaxFactory.BracketedArgumentList(CreateSeparatedList(SyntaxFactory.Argument(SyntaxFactory.IdentifierName(identifier)))));

        public static StatementSyntax AggregateStatementSyntax(List<StatementSyntax> syntax) 
            => syntax.Count switch
            {
                0 => SyntaxFactory.EmptyStatement(),
                1 => syntax[0],
                _ => SyntaxFactory.Block(syntax)
            };

        public static StatementSyntax CreateStatement(ExpressionSyntax expression)
            => SyntaxFactory.ExpressionStatement(expression);

        public static ThrowStatementSyntax CreateThrowException(string type, string message = null)
            => SyntaxFactory.ThrowStatement(
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

        public static ArgumentSyntax Argument(string name)
            => SyntaxFactory.Argument(SyntaxFactory.IdentifierName(name));

        public static ArgumentSyntax Argument(int value)
            => SyntaxFactory.Argument(VariableExtensions.IntValue(value));
        
        public static ArgumentSyntax RefArgument(string name)
            => SyntaxFactory.Argument(null, SyntaxFactory.Token(SyntaxKind.RefKeyword), SyntaxFactory.IdentifierName(name));

        public static ArgumentSyntax OutArgument(string name)
            => SyntaxFactory.Argument(null, SyntaxFactory.Token(SyntaxKind.OutKeyword), SyntaxFactory.IdentifierName(name));

        public static InvocationExpressionSyntax Invoke(ExpressionSyntax invoked, params ArgumentSyntax[] args)
            => SyntaxFactory.InvocationExpression(invoked, SyntaxFactory.ArgumentList(CreateSeparatedList(args)));

        public static ArgumentListSyntax CreateArguments(params ArgumentSyntax[] items)
            => SyntaxFactory.ArgumentList(CreateSeparatedList(items));
        
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

        public static PredefinedTypeSyntax CreatePrimitiveType(SyntaxKind keyword) 
            => SyntaxFactory.PredefinedType(SyntaxFactory.Token(keyword));
    }
}