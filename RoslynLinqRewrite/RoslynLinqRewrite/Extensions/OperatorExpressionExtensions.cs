using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Shaman.Roslyn.LinqRewrite.Extensions
{
    public static class OperatorExpressionExtensions
    {
        public static SeparatedSyntaxList<ExpressionSyntax> PostIncrement(string name)
            => SyntaxFactoryHelper.CreateSeparatedExpressionList(
                SyntaxFactory.PostfixUnaryExpression(SyntaxKind.PostIncrementExpression, SyntaxFactory.IdentifierName(name)));
        
        public static AssignmentExpressionSyntax Assign(ExpressionSyntax a, ExpressionSyntax b)
            => SyntaxFactory.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, a, b);
        
        public static BinaryExpressionSyntax Add(ExpressionSyntax a, ExpressionSyntax b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.AddExpression, a, b);
        
        public static MemberAccessExpressionSyntax Access(ExpressionSyntax source, string accessed)
            => SyntaxFactory.MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                source,
                SyntaxFactory.IdentifierName(accessed));

        public static InvocationExpressionSyntax InvokeMethod(ExpressionSyntax source, string accessed)
            => SyntaxFactory.InvocationExpression(
                SyntaxFactory.MemberAccessExpression(
                    SyntaxKind.SimpleMemberAccessExpression,
                    source,
                    SyntaxFactory.IdentifierName(accessed)));
    }
}