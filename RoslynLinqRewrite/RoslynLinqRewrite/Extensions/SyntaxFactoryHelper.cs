using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Shaman.Roslyn.LinqRewrite.Extensions
{
    public static class SyntaxFactoryHelper
    {
        public static LiteralExpressionSyntax IntExpression(int x)
            => SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(x));

        public static LocalDeclarationStatementSyntax LocalVariableCreation(SyntaxKind keyword, string name, ExpressionSyntax value)
            =>  SyntaxFactory.LocalDeclarationStatement(VariableCreation(keyword, name, value));

        public static VariableDeclarationSyntax VariableCreation(SyntaxKind keyword, string name, ExpressionSyntax value)
            =>  SyntaxFactory.VariableDeclaration(
                SyntaxFactory.PredefinedType(SyntaxFactory.Token(keyword)),
                SyntaxFactory.SeparatedList(new []{SyntaxFactory.VariableDeclarator(name)
                    .WithInitializer(SyntaxFactory.EqualsValueClause(value))}));

        public static SeparatedSyntaxList<ExpressionSyntax> PostIncrement(string name)
            => SyntaxFactory.SeparatedList(new ExpressionSyntax[]
            {
                SyntaxFactory.PostfixUnaryExpression(SyntaxKind.PostIncrementExpression,
                    SyntaxFactory.IdentifierName(name))
            });
    }
}