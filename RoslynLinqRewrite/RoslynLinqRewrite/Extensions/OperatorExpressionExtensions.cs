using LinqRewrite.DataStructures;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.Extensions
{
    public static class OperatorExpressionExtensions
    {
        public static ElementAccessExpressionSyntax ArrayAccess(this ExpressionSyntax array, ValueBridge index)
            => ElementAccessExpression(
                array, BracketedArgumentList(SyntaxFactoryHelper.CreateSeparatedList(Argument(index))));

        public static ElementAccessExpressionSyntax ArrayAccess(this VariableBridge identifier, ValueBridge index)
            => ElementAccessExpression(
                identifier,
                BracketedArgumentList(SyntaxFactoryHelper.CreateSeparatedList(Argument(index))));

        
        public static PrefixUnaryExpressionSyntax Not(ValueBridge a)
            => PrefixUnaryExpression(SyntaxKind.LogicalNotExpression, ParenthesizedExpression(a));


        public static PostfixUnaryExpressionSyntax PostDecrement(this string identifier)
            => PostfixUnaryExpression(SyntaxKind.PostDecrementExpression, IdentifierName(identifier));
        public static SeparatedSyntaxList<ExpressionSyntax> SeparatedPostDecrement(this string identifier)
            => SyntaxFactoryHelper.CreateSeparatedExpressionList(
                PostfixUnaryExpression(SyntaxKind.PostDecrementExpression, IdentifierName(identifier)));
        
        public static PostfixUnaryExpressionSyntax PostIncrement(this ValueBridge identifier)
            => PostfixUnaryExpression(SyntaxKind.PostIncrementExpression, identifier);
        
        public static PostfixUnaryExpressionSyntax PostIncrement(this string identifier)
            => PostfixUnaryExpression(SyntaxKind.PostIncrementExpression, IdentifierName(identifier));
        public static SeparatedSyntaxList<ExpressionSyntax> SeparatedPostIncrement(this string identifier)
            => SyntaxFactoryHelper.CreateSeparatedExpressionList(
                PostfixUnaryExpression(SyntaxKind.PostIncrementExpression, IdentifierName(identifier)));
        
        public static PrefixUnaryExpressionSyntax PreIncrement(this VariableBridge identifier)
            => PrefixUnaryExpression(SyntaxKind.PreIncrementExpression, identifier);
        
        public static PrefixUnaryExpressionSyntax PreIncrement(this ValueBridge identifier)
            => PrefixUnaryExpression(SyntaxKind.PreIncrementExpression, identifier);
        
        public static PrefixUnaryExpressionSyntax PreIncrement(this string identifier)
            => PrefixUnaryExpression(SyntaxKind.PreIncrementExpression, IdentifierName(identifier));

        public static CastExpressionSyntax Cast(this double a, TypeBridge type)
            => Cast((ValueBridge)a, type);
        
        public static CastExpressionSyntax Cast(this float a, TypeBridge type)
            => Cast((ValueBridge)a, type);
        
        public static CastExpressionSyntax Cast(this int a, TypeBridge type)
            => Cast((ValueBridge)a, type);
        
        public static CastExpressionSyntax Cast(this VariableBridge identifier, TypeBridge type)
            => CastExpression(type, identifier);
        
        public static CastExpressionSyntax Cast(this ExpressionSyntax a, TypeBridge type)
            => CastExpression(type, a);
        
        public static CastExpressionSyntax Cast(this ValueBridge a, TypeBridge type)
            => CastExpression(type, a);
        
        
        public static AssignmentExpressionSyntax Assign(this VariableBridge a, ValueBridge b)
            => AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, a, b);
        public static AssignmentExpressionSyntax Assign(this ExpressionSyntax a, ValueBridge b)
            => AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, a, b);
        
        
        public static AssignmentExpressionSyntax SubAssign(this VariableBridge a, ValueBridge b)
            => AssignmentExpression(SyntaxKind.SubtractAssignmentExpression, a, b);
        public static AssignmentExpressionSyntax SubAssign(this ExpressionSyntax a, ValueBridge b)
            => AssignmentExpression(SyntaxKind.SubtractAssignmentExpression, a, b);
        
        public static AssignmentExpressionSyntax AddAssign(this VariableBridge a, ValueBridge b)
            => AssignmentExpression(SyntaxKind.AddAssignmentExpression, a, b);
        public static AssignmentExpressionSyntax AddAssign(this ExpressionSyntax a, ValueBridge b)
            => AssignmentExpression(SyntaxKind.AddAssignmentExpression, a, b);
        
        
        public static BinaryExpressionSyntax Add(this ValueBridge a, ValueBridge b)
            => BinaryExpression(SyntaxKind.AddExpression, a, b);
        public static BinaryExpressionSyntax Add(this ExpressionSyntax a, ValueBridge b)
            => BinaryExpression(SyntaxKind.AddExpression, a, b);
        public static BinaryExpressionSyntax Add(this VariableBridge a, ValueBridge b)
            => BinaryExpression(SyntaxKind.AddExpression, a, b);
        
        
        public static BinaryExpressionSyntax Sub(this VariableBridge a, ValueBridge b)
            => BinaryExpression(SyntaxKind.SubtractExpression, a, b);
        public static BinaryExpressionSyntax Sub(this ExpressionSyntax a, ValueBridge b)
            => BinaryExpression(SyntaxKind.SubtractExpression, a, b);
        public static BinaryExpressionSyntax Sub(this ValueBridge a, ValueBridge b)
            => BinaryExpression(SyntaxKind.SubtractExpression, a, b);
        
        
        public static BinaryExpressionSyntax Div(this ValueBridge a, ValueBridge b)
            => BinaryExpression(SyntaxKind.DivideExpression, a, b);
        public static BinaryExpressionSyntax Div(this ExpressionSyntax a, ValueBridge b)
            => BinaryExpression(SyntaxKind.DivideExpression, a, b);
        public static BinaryExpressionSyntax Div(this VariableBridge a, ValueBridge b)
            => BinaryExpression(SyntaxKind.DivideExpression, a, b);
        
        
        public static BinaryExpressionSyntax Mod(this ExpressionSyntax a, ValueBridge b)
            => BinaryExpression(SyntaxKind.ModuloExpression, a, b);
        public static BinaryExpressionSyntax Mod(this VariableBridge a, ValueBridge b)
            => BinaryExpression(SyntaxKind.ModuloExpression, a, b);
        
        
        public static BinaryExpressionSyntax EqualsExpr(this ExpressionSyntax a, ValueBridge b)
            => BinaryExpression(SyntaxKind.EqualsExpression, a, b);
        public static BinaryExpressionSyntax EqualsExpr(this ValueBridge a, ValueBridge b)
            => BinaryExpression(SyntaxKind.EqualsExpression, a, b);
        public static BinaryExpressionSyntax EqualsExpr(this VariableBridge a, ValueBridge b)
            => BinaryExpression(SyntaxKind.EqualsExpression, a, b);
        
        
        public static BinaryExpressionSyntax LThan(this ExpressionSyntax a, ValueBridge b)
            => BinaryExpression(SyntaxKind.LessThanExpression, a, b);
        public static BinaryExpressionSyntax LThan(this VariableBridge a, ValueBridge b)
            => BinaryExpression(SyntaxKind.LessThanExpression, a, b);
        public static BinaryExpressionSyntax LThan(this ValueBridge a, ValueBridge b)
            => BinaryExpression(SyntaxKind.LessThanExpression, a, b);
        
        
        public static BinaryExpressionSyntax LeThan(this ExpressionSyntax a, ValueBridge b)
            => BinaryExpression(SyntaxKind.LessThanOrEqualExpression, a, b);
        public static BinaryExpressionSyntax LeThan(this VariableBridge a, ValueBridge b)
            => BinaryExpression(SyntaxKind.LessThanOrEqualExpression, a, b);
        
        
        public static BinaryExpressionSyntax GeThan(this VariableBridge a, ValueBridge b)
            => BinaryExpression(SyntaxKind.GreaterThanOrEqualExpression, a, b);
        public static BinaryExpressionSyntax GeThan(this ExpressionSyntax a, ValueBridge b)
            => BinaryExpression(SyntaxKind.GreaterThanOrEqualExpression, a, b);
        public static BinaryExpressionSyntax GeThan(this ValueBridge a, ValueBridge b)
            => BinaryExpression(SyntaxKind.GreaterThanOrEqualExpression, a, b);
        
        
        public static BinaryExpressionSyntax GThan(this ExpressionSyntax a, ValueBridge b)
            => BinaryExpression(SyntaxKind.GreaterThanExpression, a, b);
        public static BinaryExpressionSyntax GThan(this VariableBridge a, ValueBridge b)
            => BinaryExpression(SyntaxKind.GreaterThanExpression, a, b);
        
        
        public static BinaryExpressionSyntax NotEqualsExpr(this ExpressionSyntax a, ExpressionSyntax b)
            => BinaryExpression(SyntaxKind.NotEqualsExpression, a, b);
        public static BinaryExpressionSyntax NotEqualsExpr(this VariableBridge a, ExpressionSyntax b)
            => BinaryExpression(SyntaxKind.NotEqualsExpression, a, b);

        public static BinaryExpressionSyntax As(this VariableBridge identifier, ValueBridge b)
            => BinaryExpression(SyntaxKind.AsExpression, IdentifierName(identifier), b);

        public static MemberAccessExpressionSyntax Access(this string identifier, VariableBridge accessed)
            => MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                IdentifierName(identifier),
                accessed);
        
        public static MemberAccessExpressionSyntax Access(this string identifier, params VariableBridge[] accessed)
        {
            var item = (ExpressionSyntax)IdentifierName(identifier);
            for (var i = 0; i < accessed.Length; i++)
            {
                item = MemberAccessExpression(
                    SyntaxKind.SimpleMemberAccessExpression,
                    item,
                    accessed[i]);
            }
            return (MemberAccessExpressionSyntax)item;
        }

        public static MemberAccessExpressionSyntax Access(this VariableBridge identifier, VariableBridge accessed)
            => MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                identifier,
                accessed);
        
        public static MemberAccessExpressionSyntax Access(this VariableBridge identifier, params VariableBridge[] accessed)
        {
            var item = (ExpressionSyntax)identifier;
            for (var i = 0; i < accessed.Length; i++)
            {
                item = MemberAccessExpression(
                    SyntaxKind.SimpleMemberAccessExpression,
                    item,
                    accessed[i]);
            }
            return (MemberAccessExpressionSyntax)item;
        }
        
        public static MemberAccessExpressionSyntax Access(this ExpressionSyntax source, VariableBridge accessed)
            => MemberAccessExpression(
                SyntaxKind.SimpleMemberAccessExpression,
                source,
                accessed);
        
        public static MemberAccessExpressionSyntax Access(this ExpressionSyntax source, params VariableBridge[] accessed)
        {
            var item = source;
            for (var i = 0; i < accessed.Length; i++)
            {
                item = MemberAccessExpression(
                    SyntaxKind.SimpleMemberAccessExpression,
                    item,
                    accessed[i]);
            }
            return (MemberAccessExpressionSyntax)item;
        }
    }
}