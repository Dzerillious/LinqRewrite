using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;

namespace Shaman.Roslyn.LinqRewrite.Extensions
{
    public static class OperatorExpressionExtensions
    {
        public static ElementAccessExpressionSyntax ArrayAccess(this ExpressionSyntax array, ValueBridge index)
            => SyntaxFactory.ElementAccessExpression(
                array, SyntaxFactory.BracketedArgumentList(SyntaxFactoryHelper.CreateSeparatedList(SyntaxFactory.Argument(index))));

        public static ElementAccessExpressionSyntax ArrayAccess(this string identifier, ValueBridge index)
            => SyntaxFactory.ElementAccessExpression(
                SyntaxFactory.IdentifierName(identifier),
                SyntaxFactory.BracketedArgumentList(SyntaxFactoryHelper.CreateSeparatedList(SyntaxFactory.Argument(index))));

        
        public static PrefixUnaryExpressionSyntax Not(ValueBridge a)
            => SyntaxFactory.PrefixUnaryExpression(SyntaxKind.LogicalNotExpression, SyntaxFactory.ParenthesizedExpression(a));

        
        
        public static PostfixUnaryExpressionSyntax PostDecrement(this string identifier)
            => SyntaxFactory.PostfixUnaryExpression(SyntaxKind.PostDecrementExpression, SyntaxFactory.IdentifierName(identifier));
        public static SeparatedSyntaxList<ExpressionSyntax> SeparatedPostDecrement(this string identifier)
            => SyntaxFactoryHelper.CreateSeparatedExpressionList(
                SyntaxFactory.PostfixUnaryExpression(SyntaxKind.PostDecrementExpression, SyntaxFactory.IdentifierName(identifier)));
        
        public static PostfixUnaryExpressionSyntax PostIncrement(this string identifier)
            => SyntaxFactory.PostfixUnaryExpression(SyntaxKind.PostIncrementExpression, SyntaxFactory.IdentifierName(identifier));

        public static SeparatedSyntaxList<ExpressionSyntax> SeparatedPostIncrement(this string identifier)
            => SyntaxFactoryHelper.CreateSeparatedExpressionList(
                SyntaxFactory.PostfixUnaryExpression(SyntaxKind.PostIncrementExpression, SyntaxFactory.IdentifierName(identifier)));
        
        
        public static CastExpressionSyntax Cast(this double a, TypeBridge type)
            => Cast((ValueBridge)a, type);
        
        public static CastExpressionSyntax Cast(this float a, TypeBridge type)
            => Cast((ValueBridge)a, type);
        
        public static CastExpressionSyntax Cast(this int a, TypeBridge type)
            => Cast((ValueBridge)a, type);
        
        public static CastExpressionSyntax Cast(this string identifier, TypeBridge type)
            => SyntaxFactory.CastExpression(type, SyntaxFactory.IdentifierName(identifier));
        
        public static CastExpressionSyntax Cast(this ExpressionSyntax a, TypeBridge type)
            => SyntaxFactory.CastExpression(type, a);
        
        
        public static AssignmentExpressionSyntax Assign(this string identifier, ValueBridge b)
            => SyntaxFactory.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, SyntaxFactory.IdentifierName(identifier), b);
        public static AssignmentExpressionSyntax Assign(this ExpressionSyntax a, ValueBridge b)
            => SyntaxFactory.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, a, b);
        
        
        public static AssignmentExpressionSyntax SubAssign(this string identifier, ValueBridge b)
            => SyntaxFactory.AssignmentExpression(SyntaxKind.SubtractAssignmentExpression, SyntaxFactory.IdentifierName(identifier), b);
        public static AssignmentExpressionSyntax SubAssign(this ExpressionSyntax a, ValueBridge b)
            => SyntaxFactory.AssignmentExpression(SyntaxKind.SubtractAssignmentExpression, a, b);
        
        public static AssignmentExpressionSyntax AddAssign(this string identifier, ValueBridge b)
            => SyntaxFactory.AssignmentExpression(SyntaxKind.AddAssignmentExpression, SyntaxFactory.IdentifierName(identifier), b);
        public static AssignmentExpressionSyntax AddAssign(this ExpressionSyntax a, ValueBridge b)
            => SyntaxFactory.AssignmentExpression(SyntaxKind.AddAssignmentExpression, a, b);
        
        
        public static BinaryExpressionSyntax Add(this ValueBridge a, ValueBridge b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.AddExpression, a, b);
        public static BinaryExpressionSyntax Add(this ExpressionSyntax a, ValueBridge b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.AddExpression, a, b);
        public static BinaryExpressionSyntax Add(this string identifier, ValueBridge b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.AddExpression, SyntaxFactory.IdentifierName(identifier), b);
        
        
        public static BinaryExpressionSyntax Sub(this string identifier, ValueBridge b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.SubtractExpression, SyntaxFactory.IdentifierName(identifier), b);
        public static BinaryExpressionSyntax Sub(this ExpressionSyntax a, ValueBridge b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.SubtractExpression, a, b);
        public static BinaryExpressionSyntax Sub(this ValueBridge a, ValueBridge b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.SubtractExpression, a, b);
        
        
        public static BinaryExpressionSyntax Div(this ValueBridge a, ValueBridge b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.DivideExpression, a, b);
        public static BinaryExpressionSyntax Div(this ExpressionSyntax a, ValueBridge b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.DivideExpression, a, b);
        public static BinaryExpressionSyntax Div(this string identifier, ValueBridge b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.DivideExpression, SyntaxFactory.IdentifierName(identifier), b);
        
        
        public static BinaryExpressionSyntax Mod(this string identifier, ValueBridge b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.ModuloExpression, SyntaxFactory.IdentifierName(identifier), b);
        public static BinaryExpressionSyntax Mod(this ExpressionSyntax a, ValueBridge b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.ModuloExpression, a, b);
        
        
        public static BinaryExpressionSyntax EqualsExpr(this string identifier, ValueBridge b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.EqualsExpression, SyntaxFactory.IdentifierName(identifier), b);
        public static BinaryExpressionSyntax EqualsExpr(this ExpressionSyntax a, ValueBridge b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.EqualsExpression, a, b);
        
        
        public static BinaryExpressionSyntax LThan(this string identifier, ValueBridge b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.LessThanExpression, SyntaxFactory.IdentifierName(identifier), b);
        public static BinaryExpressionSyntax LThan(this ExpressionSyntax a, ValueBridge b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.LessThanExpression, a, b);
        
        
        public static BinaryExpressionSyntax GeThan(this string identifier, ValueBridge b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.GreaterThanOrEqualExpression, SyntaxFactory.IdentifierName(identifier), b);
        public static BinaryExpressionSyntax GeThan(this ExpressionSyntax a, ValueBridge b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.GreaterThanOrEqualExpression, a, b);
        
        
        public static BinaryExpressionSyntax GThan(this string identifier, ValueBridge b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.GreaterThanExpression, SyntaxFactory.IdentifierName(identifier), b);
        public static BinaryExpressionSyntax GThan(this ExpressionSyntax a, ValueBridge b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.GreaterThanExpression, a, b);
        
        
        public static BinaryExpressionSyntax NotEqualsExpr(this ExpressionSyntax a, ExpressionSyntax b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.NotEqualsExpression, a, b);
        public static BinaryExpressionSyntax NotEqualsExpr(this string identifier, ExpressionSyntax b)
            => SyntaxFactory.BinaryExpression(SyntaxKind.NotEqualsExpression, SyntaxFactory.IdentifierName(identifier), b);

        
        
        public static MemberAccessExpressionSyntax Access(this string identifier, VariableBridge accessed)
            => SyntaxFactory.MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                SyntaxFactory.IdentifierName(identifier),
                accessed);
        
        public static MemberAccessExpressionSyntax Access(this ExpressionSyntax source, VariableBridge accessed)
            => SyntaxFactory.MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                source,
                accessed);
        
        public static MemberAccessExpressionSyntax Access(this ExpressionSyntax source, params VariableBridge[] accessed)
        {
            var item = source;
            for (var i = 0; i < accessed.Length; i++)
            {
                item = SyntaxFactory.MemberAccessExpression(
                    SyntaxKind.SimpleMemberAccessExpression,
                    item,
                    accessed[i]);
            }
            return (MemberAccessExpressionSyntax)item;
        }
        
        public static MemberAccessExpressionSyntax Access(this string identifier, params VariableBridge[] accessed)
        {
            var item = (ExpressionSyntax)SyntaxFactory.IdentifierName(identifier);
            for (var i = 0; i < accessed.Length; i++)
            {
                item = SyntaxFactory.MemberAccessExpression(
                    SyntaxKind.SimpleMemberAccessExpression,
                    item,
                    accessed[i]);
            }
            return (MemberAccessExpressionSyntax)item;
        }
    }
}