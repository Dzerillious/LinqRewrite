using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Shaman.Roslyn.LinqRewrite.Extensions
{
    public static class OperatorExpressionExtensions
    {
        public static ParenthesizedExpressionSyntax Not(ExpressionSyntax a)
            => SyntaxFactory.ParenthesizedExpression(SyntaxFactory.PrefixUnaryExpression(SyntaxKind.LogicalNotExpression, a));
        
        public static SeparatedSyntaxList<ExpressionSyntax> SeparatedPostIncrement(this string identifier)
            => SyntaxFactoryHelper.CreateSeparatedExpressionList(
                SyntaxFactory.PostfixUnaryExpression(SyntaxKind.PostIncrementExpression, SyntaxFactory.IdentifierName(identifier)));
        
        public static PostfixUnaryExpressionSyntax PostIncrement(this string identifier)
            => SyntaxFactory.PostfixUnaryExpression(SyntaxKind.PostIncrementExpression, SyntaxFactory.IdentifierName(identifier));
        
        public static SeparatedSyntaxList<ExpressionSyntax> SeparatedPostDecrement(this string identifier)
            => SyntaxFactoryHelper.CreateSeparatedExpressionList(
                SyntaxFactory.PostfixUnaryExpression(SyntaxKind.PostDecrementExpression, SyntaxFactory.IdentifierName(identifier)));
        
        public static PostfixUnaryExpressionSyntax PostDecrement(this string identifier)
            => SyntaxFactory.PostfixUnaryExpression(SyntaxKind.PostDecrementExpression, SyntaxFactory.IdentifierName(identifier));
        
        public static CastExpressionSyntax Cast(this string a, TypeSyntax type)
            => SyntaxFactory.CastExpression(type, SyntaxFactory.IdentifierName(a));
        
        public static CastExpressionSyntax Cast(this ExpressionSyntax a, SyntaxKind type)
            => SyntaxFactory.CastExpression(SyntaxFactoryHelper.CreatePrimitiveType(type), a);
        
        public static CastExpressionSyntax Cast(this ExpressionSyntax a, TypeSyntax type)
            => SyntaxFactory.CastExpression(type, a);
        
        public static AssignmentExpressionSyntax Assign(this string identifier, ExpressionSyntax b)
            => SyntaxFactory.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, SyntaxFactory.IdentifierName(identifier), b);
        public static AssignmentExpressionSyntax Assign(this ExpressionSyntax a, ExpressionSyntax b)
            => SyntaxFactory.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, a, b);
        public static AssignmentExpressionSyntax AssignSubtract(this string identifier, ExpressionSyntax b)
            => SyntaxFactory.AssignmentExpression(SyntaxKind.SubtractAssignmentExpression, SyntaxFactory.IdentifierName(identifier), b);
        public static AssignmentExpressionSyntax AssignSubtract(this ExpressionSyntax a, ExpressionSyntax b)
            => SyntaxFactory.AssignmentExpression(SyntaxKind.SubtractAssignmentExpression, a, b);
        
        public static BinaryExpressionSyntax Add(this ExpressionSyntax a, ExpressionSyntax b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.AddExpression, a, b);
        
        public static BinaryExpressionSyntax Add(this string identifier, ExpressionSyntax b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.AddExpression, SyntaxFactory.IdentifierName(identifier), b);
        
        public static BinaryExpressionSyntax Sub(this ExpressionSyntax a, ExpressionSyntax b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.SubtractExpression, a, b);
        
        public static BinaryExpressionSyntax Sub(this ExpressionSyntax a, int b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.SubtractExpression, a, VariableExtensions.IntValue(b));
        
        public static BinaryExpressionSyntax Mod(this ExpressionSyntax a, ExpressionSyntax b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.ModuloExpression, a, b);
        
        public static BinaryExpressionSyntax Mod(this string identifier, ExpressionSyntax b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.ModuloExpression, SyntaxFactory.IdentifierName(identifier), b);
        
        public static BinaryExpressionSyntax Mod(this string identifier, int b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.ModuloExpression, SyntaxFactory.IdentifierName(identifier), VariableExtensions.IntValue(b));
        
        public static BinaryExpressionSyntax EqualsExpr(this string identifier, ExpressionSyntax b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.EqualsExpression, SyntaxFactory.IdentifierName(identifier), b);
        
        public static BinaryExpressionSyntax EqualsExpr(this ExpressionSyntax a, ExpressionSyntax b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.EqualsExpression, a, b);
        
        public static BinaryExpressionSyntax LThan(this ExpressionSyntax a, ExpressionSyntax b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.LessThanExpression, a, b);
        
        public static BinaryExpressionSyntax GeThan(this ExpressionSyntax a, ExpressionSyntax b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.GreaterThanOrEqualExpression, a, b);
        
        public static BinaryExpressionSyntax GeThan(this string identifier, ExpressionSyntax b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.GreaterThanOrEqualExpression, SyntaxFactory.IdentifierName(identifier), b);
        
        public static BinaryExpressionSyntax GeThan(this string identifier, string b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.GreaterThanOrEqualExpression, SyntaxFactory.IdentifierName(identifier), SyntaxFactory.IdentifierName(b));
        
        public static BinaryExpressionSyntax NotEqualsExpr(this ExpressionSyntax a, ExpressionSyntax b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.NotEqualsExpression, a, b);
        
        public static MemberAccessExpressionSyntax Access(this ExpressionSyntax source, string accessed)
            => SyntaxFactory.MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                source,
                SyntaxFactory.IdentifierName(accessed));
        
        public static MemberAccessExpressionSyntax Access(this ExpressionSyntax source, params string[] accessed)
        {
            var item = source;
            for (var i = 0; i < accessed.Length; i++)
            {
                item = SyntaxFactory.MemberAccessExpression(
                    SyntaxKind.SimpleMemberAccessExpression,
                    item,
                    SyntaxFactory.IdentifierName(accessed[i]));
            }
            return (MemberAccessExpressionSyntax)item;
        }
        
        public static MemberAccessExpressionSyntax Access(this string identifier, params string[] accessed)
        {
            var item = (ExpressionSyntax)SyntaxFactory.IdentifierName(identifier);
            for (var i = 0; i < accessed.Length; i++)
            {
                item = SyntaxFactory.MemberAccessExpression(
                    SyntaxKind.SimpleMemberAccessExpression,
                    item,
                    SyntaxFactory.IdentifierName(accessed[i]));
            }
            return (MemberAccessExpressionSyntax)item;
        }

        public static InvocationExpressionSyntax InvokeMethod(this ExpressionSyntax source, string accessed)
            => SyntaxFactory.InvocationExpression(
                SyntaxFactory.MemberAccessExpression(
                    SyntaxKind.SimpleMemberAccessExpression,
                    source,
                    SyntaxFactory.IdentifierName(accessed)));

        public static IfStatementSyntax If(ExpressionSyntax @if, StatementSyntax @do)
            => SyntaxFactory.IfStatement(@if, @do);

        public static IfStatementSyntax If(ExpressionSyntax @if, ExpressionSyntax @do)
            => SyntaxFactory.IfStatement(@if, SyntaxFactory.ExpressionStatement(@do));

        public static IfStatementSyntax If(ExpressionSyntax @if, StatementSyntax @do, ElseClauseSyntax @else)
            => SyntaxFactory.IfStatement(@if, @do, @else);

        public static IfStatementSyntax If(ExpressionSyntax @if, ExpressionSyntax @do, ElseClauseSyntax @else)
            => SyntaxFactory.IfStatement(@if, SyntaxFactory.ExpressionStatement(@do), @else);

        public static ElseClauseSyntax Else(StatementSyntax @else)
            => SyntaxFactory.ElseClause(@else);

        public static ElseClauseSyntax Else(ExpressionSyntax @else)
            => SyntaxFactory.ElseClause(SyntaxFactory.ExpressionStatement(@else));

        public static ReturnStatementSyntax Return(ExpressionSyntax @returned)
            => SyntaxFactory.ReturnStatement(@returned);

        public static DefaultExpressionSyntax Default(TypeSyntax @type)
            => SyntaxFactory.DefaultExpression(@type);

        public static ReturnStatementSyntax Return(string identifier)
            => SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName(identifier));
    }
}