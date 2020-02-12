using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Shaman.Roslyn.LinqRewrite.Extensions
{
    public static class BinaryExpressionExtensions
    {
        public static AssignmentExpressionSyntax Assign(ExpressionSyntax a, ExpressionSyntax b)
            => SyntaxFactory.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, a, b);
        
        public static BinaryExpressionSyntax Add(ExpressionSyntax a, ExpressionSyntax b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.AddExpression, a, b);
    }
}