using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Shaman.Roslyn.LinqRewrite.Extensions
{
    public static class OperatorExpressionExtensions
    {
        public static PrefixUnaryExpressionSyntax Not(ExpressionSyntax a)
            => SyntaxFactory.PrefixUnaryExpression(SyntaxKind.LogicalNotExpression, a);
        
        public static SeparatedSyntaxList<ExpressionSyntax> PostIncrement(string name)
            => SyntaxFactoryHelper.CreateSeparatedExpressionList(
                SyntaxFactory.PostfixUnaryExpression(SyntaxKind.PostIncrementExpression, SyntaxFactory.IdentifierName(name)));
        
        public static SeparatedSyntaxList<ExpressionSyntax> PostDecrement(string name)
            => SyntaxFactoryHelper.CreateSeparatedExpressionList(
                SyntaxFactory.PostfixUnaryExpression(SyntaxKind.PostDecrementExpression, SyntaxFactory.IdentifierName(name)));
        
        public static AssignmentExpressionSyntax Assign(string a, ExpressionSyntax b)
            => SyntaxFactory.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, SyntaxFactory.IdentifierName(a), b);
        public static AssignmentExpressionSyntax Assign(ExpressionSyntax a, ExpressionSyntax b)
            => SyntaxFactory.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, a, b);
        
        public static BinaryExpressionSyntax Add(ExpressionSyntax a, ExpressionSyntax b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.AddExpression, a, b);
        
        public static BinaryExpressionSyntax Sub(ExpressionSyntax a, ExpressionSyntax b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.SubtractExpression, a, b);
        
        public static BinaryExpressionSyntax EqualsExpr(ExpressionSyntax a, ExpressionSyntax b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.EqualsExpression, a, b);
        
        public static BinaryExpressionSyntax LThan(ExpressionSyntax a, ExpressionSyntax b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.LessThanExpression, a, b);
        
        public static BinaryExpressionSyntax GeThan(ExpressionSyntax a, ExpressionSyntax b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.GreaterThanOrEqualExpression, a, b);
        
        public static BinaryExpressionSyntax NotEqualsExpr(ExpressionSyntax a, ExpressionSyntax b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.NotEqualsExpression, a, b);
        
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