using LinqRewrite.DataStructures;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.Extensions
{
    public static class OperatorExpressionExtensions
    {
        public static ValueBridge ArrayAccess(this ValueBridge identifier, ValueBridge index)
            => ElementAccessExpression(
                identifier,
                BracketedArgumentList(SyntaxFactoryHelper.CreateSeparatedList(Argument(index))));

        
        public static BinaryExpressionSyntax Or(this ValueBridge a, ValueBridge b)
            => BinaryExpression(SyntaxKind.LogicalOrExpression, a, b);
        public static BinaryExpressionSyntax And(this ValueBridge a, ValueBridge b)
            => BinaryExpression(SyntaxKind.LogicalAndExpression, a, b);
        public static PrefixUnaryExpressionSyntax Not(ValueBridge a)
            => PrefixUnaryExpression(SyntaxKind.LogicalNotExpression, ParenthesizedExpression(a));
        public static BinaryExpressionSyntax Or(this ExpressionSyntax a, ValueBridge b)
            => BinaryExpression(SyntaxKind.LogicalOrExpression, ParenthesizedExpression(a), b);
        public static BinaryExpressionSyntax And(this ExpressionSyntax a, ValueBridge b)
            => BinaryExpression(SyntaxKind.LogicalAndExpression, ParenthesizedExpression(a), b);

        
        
        public static ValueBridge Is(this TypedValueBridge a, TypeBridge type)
            => BinaryExpression(SyntaxKind.IsExpression, a, type);

        
        public static PostfixUnaryExpressionSyntax PostDecrement(this ValueBridge identifier)
            => PostfixUnaryExpression(SyntaxKind.PostIncrementExpression, identifier);
        public static SeparatedSyntaxList<ExpressionSyntax> SeparatedPostDecrement(this ValueBridge identifier)
            => SyntaxFactoryHelper.CreateSeparatedExpressionList(
                PostfixUnaryExpression(SyntaxKind.PostDecrementExpression, identifier));
        public static PostfixUnaryExpressionSyntax PostIncrement(this ValueBridge identifier)
            => PostfixUnaryExpression(SyntaxKind.PostIncrementExpression, identifier);
        public static SeparatedSyntaxList<ExpressionSyntax> SeparatedPostIncrement(this ValueBridge identifier)
            => SyntaxFactoryHelper.CreateSeparatedExpressionList(
                PostfixUnaryExpression(SyntaxKind.PostIncrementExpression, identifier));
        public static PrefixUnaryExpressionSyntax PreIncrement(this ValueBridge identifier)
            => PrefixUnaryExpression(SyntaxKind.PreIncrementExpression, identifier);
        public static PrefixUnaryExpressionSyntax PreDecrement(this ValueBridge identifier)
            => PrefixUnaryExpression(SyntaxKind.PreDecrementExpression, identifier);

        
        public static CastExpressionSyntax Cast(this double a, TypeBridge type)
            => Cast((ValueBridge)a, type);
        public static CastExpressionSyntax Cast(this float a, TypeBridge type)
            => Cast((ValueBridge)a, type);
        public static CastExpressionSyntax Cast(this int a, TypeBridge type)
            => Cast((ValueBridge)a, type);
        public static CastExpressionSyntax Cast(this ValueBridge a, TypeBridge type)
            => CastExpression(type, a);
        public static CastExpressionSyntax Cast(this ExpressionSyntax a, TypeBridge type)
            => CastExpression(type, a);
        
        
        public static AssignmentExpressionSyntax Assign(this ExpressionSyntax a, ValueBridge b)
            => AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, a, b);
        public static AssignmentExpressionSyntax Assign(this VariableBridge a, ValueBridge b)
            => AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, a, b);
        public static AssignmentExpressionSyntax Assign(this ValueBridge a, ValueBridge b)
            => AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, a, b);
        public static AssignmentExpressionSyntax SubAssign(this VariableBridge a, ValueBridge b)
            => AssignmentExpression(SyntaxKind.SubtractAssignmentExpression, a, b);
        public static AssignmentExpressionSyntax AddAssign(this VariableBridge a, ValueBridge b)
            => AssignmentExpression(SyntaxKind.AddAssignmentExpression, a, b);
        
        
        public static BinaryExpressionSyntax Add(this ValueBridge a, ValueBridge b)
            => BinaryExpression(SyntaxKind.AddExpression, a, b);
        public static BinaryExpressionSyntax Sub(this ValueBridge a, ValueBridge b)
            => BinaryExpression(SyntaxKind.SubtractExpression, a, b);
        public static BinaryExpressionSyntax Mul(this ValueBridge a, ValueBridge b)
            => BinaryExpression(SyntaxKind.MultiplyExpression, a, b);
        public static BinaryExpressionSyntax Div(this ValueBridge a, ValueBridge b)
            => BinaryExpression(SyntaxKind.DivideExpression, a, b);
        public static BinaryExpressionSyntax Mod(this ValueBridge a, ValueBridge b)
            => BinaryExpression(SyntaxKind.ModuloExpression, a, b);
        
        
        public static BinaryExpressionSyntax IsEqual(this ValueBridge a, ValueBridge b)
            => BinaryExpression(SyntaxKind.EqualsExpression, a, b);
        
        
        public static BinaryExpressionSyntax LThan(this ValueBridge a, ValueBridge b)
            => BinaryExpression(SyntaxKind.LessThanExpression, a, b);
        public static BinaryExpressionSyntax LeThan(this ValueBridge a, ValueBridge b)
            => BinaryExpression(SyntaxKind.LessThanOrEqualExpression, a, b);
        public static BinaryExpressionSyntax GeThan(this ValueBridge a, ValueBridge b)
            => BinaryExpression(SyntaxKind.GreaterThanOrEqualExpression, a, b);
        public static BinaryExpressionSyntax GThan(this ValueBridge a, ValueBridge b)
            => BinaryExpression(SyntaxKind.GreaterThanExpression, a, b);
        public static BinaryExpressionSyntax NotEqual(this ValueBridge a, ValueBridge b)
            => BinaryExpression(SyntaxKind.NotEqualsExpression, a, b);

        public static BinaryExpressionSyntax As(this ValueBridge identifier, ValueBridge b)
            => BinaryExpression(SyntaxKind.AsExpression, identifier, b);

        public static MemberAccessExpressionSyntax Access(this string identifier, VariableBridge accessed)
            => MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, IdentifierName(identifier), accessed);
        
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

        public static MemberAccessExpressionSyntax Access(this ValueBridge identifier, VariableBridge accessed)
            => MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, identifier, accessed);
        
        public static MemberAccessExpressionSyntax Access(this ValueBridge identifier, params VariableBridge[] accessed)
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
        
        public static MemberAccessExpressionSyntax Access(this ExpressionSyntax source, params VariableBridge[] accessed)
        {
            var expression = source;
            for (var i = 0; i < accessed.Length; i++)
            {
                expression = MemberAccessExpression(
                    SyntaxKind.SimpleMemberAccessExpression,
                    expression,
                    accessed[i]);
            }
            return (MemberAccessExpressionSyntax)expression;
        }
    }
}