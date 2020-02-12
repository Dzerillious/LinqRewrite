using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;

namespace Shaman.Roslyn.LinqRewrite.Extensions
{
    public static class SyntaxFactoryHelper
    {
        public static LiteralExpressionSyntax IntExpression(int x)
            => SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(x));
        
        public static LocalDeclarationStatementSyntax LocalVariableCreation(string name, ExpressionSyntax value)
            =>  SyntaxFactory.LocalDeclarationStatement(VariableCreation(name, value));

        public static VariableDeclarationSyntax VariableCreation(string name, ExpressionSyntax value)
            =>  SyntaxFactory.VariableDeclaration(
                SyntaxFactory.IdentifierName("var"),
                SyntaxFactory.SeparatedList(new []{SyntaxFactory.VariableDeclarator(name)
                    .WithInitializer(SyntaxFactory.EqualsValueClause(value))}));

        public static SeparatedSyntaxList<ExpressionSyntax> PostIncrement(string name)
            => SyntaxFactory.SeparatedList(new ExpressionSyntax[]
            {
                SyntaxFactory.PostfixUnaryExpression(SyntaxKind.PostIncrementExpression,
                    SyntaxFactory.IdentifierName(name))
            });

        public static SeparatedSyntaxList<T> CreateSeparatedList<T>(params T[] items) where T : SyntaxNode
            => SyntaxFactory.SeparatedList(items);

        public static StatementSyntax CreateLocalArray(string name, TypeSyntax itemType, ExpressionSyntax size)
            => LocalVariableCreation(name,
                SyntaxFactory.ArrayCreationExpression(
                    SyntaxFactory.ArrayType(itemType)
                        .WithRankSpecifiers(SyntaxFactory.SingletonList(SyntaxFactory.ArrayRankSpecifier(
                            CreateSeparatedList(size))))));

        public static ElementAccessExpressionSyntax ArrayAccess(string arrayName, ExpressionSyntax index)
            => SyntaxFactory.ElementAccessExpression(
                SyntaxFactory.IdentifierName(arrayName),
                SyntaxFactory.BracketedArgumentList(
                    CreateSeparatedList(SyntaxFactory.Argument(index))));

        public static StatementSyntax AggregateStatementSyntax(List<StatementSyntax> syntax)
        {
            return syntax.Count switch
            {
                0 => SyntaxFactory.EmptyStatement(),
                1 => syntax[0],
                _ => SyntaxFactory.Block(syntax)
            };
        }
        
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
            => CreateArguments(items.Select(x => SyntaxFactory.Argument(x)));

        public static ArgumentListSyntax CreateArguments(params ExpressionSyntax[] items)
            => CreateArguments((IEnumerable<ExpressionSyntax>) items);

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