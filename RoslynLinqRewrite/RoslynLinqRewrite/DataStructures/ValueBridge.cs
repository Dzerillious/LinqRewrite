using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Operations;

namespace LinqRewrite.DataStructures
{
    public class  ValueBridge
    {
        public ExpressionSyntax Value { get; }
        
        public ValueBridge this[ValueBridge i] => this.ArrayAccess(i);

        public ValueBridge(bool value)
        {
            Value = value
                ? SyntaxFactory.LiteralExpression(SyntaxKind.TrueLiteralExpression)
                : SyntaxFactory.LiteralExpression(SyntaxKind.FalseLiteralExpression);
        }

        public ValueBridge(int value)
            => Value = SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(value));

        public ValueBridge(double value)
            => Value = SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(value));

        public ValueBridge(float value)
            => Value = SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(value));

        public ValueBridge(ExpressionSyntax value)
            => Value = value;

        public ValueBridge(IdentifierNameSyntax name)
            => Value = name;

        public ValueBridge(string name)
            => Value = SyntaxFactory.IdentifierName(name);

        protected ValueBridge(LocalVariable variable)
            => Value = variable;

        public static implicit operator ValueBridge(int value)
            => new ValueBridge(value);

        public static implicit operator ValueBridge(float value)
            => new ValueBridge(value);

        public static implicit operator ValueBridge(double value)
            => new ValueBridge(value);
        
        public static implicit operator ValueBridge(bool value)
            => new ValueBridge(value);
        
        public static implicit operator ValueBridge(string name)
            => new ValueBridge(name);
        
        public static implicit operator ValueBridge(ExpressionSyntax value)
            => new ValueBridge(value);
        
        public static implicit operator ValueBridge(IdentifierNameSyntax name)
            => new ValueBridge(name);
        
        public static implicit operator ExpressionSyntax(ValueBridge name)
            => name?.Value ?? VariableExtensions.Null;

        public static ValueBridge operator +(ValueBridge a, ValueBridge b)
            => SyntaxFactory.ParenthesizedExpression(a.Add(b));

        public static ValueBridge operator -(ValueBridge a, ValueBridge b)
            => SyntaxFactory.ParenthesizedExpression(a.Sub(b));

        public static ValueBridge operator *(ValueBridge a, ValueBridge b)
            => SyntaxFactory.ParenthesizedExpression(a.Mul(b));

        public static ValueBridge operator /(ValueBridge a, ValueBridge b)
            => SyntaxFactory.ParenthesizedExpression(a.Div(b));

        public static ValueBridge operator %(ValueBridge a, ValueBridge b)
            => SyntaxFactory.ParenthesizedExpression(a.Mod(b));
        
        public static BinaryExpressionSyntax operator >(ValueBridge a, ValueBridge b)
            => a.GThan(b);

        public static BinaryExpressionSyntax operator <(ValueBridge a, ValueBridge b)
            => a.LThan(b);

        public static BinaryExpressionSyntax operator >=(ValueBridge a, ValueBridge b)
            => a.GeThan(b);

        public static BinaryExpressionSyntax operator <=(ValueBridge a, ValueBridge b)
            => a.LeThan(b);

        public override string ToString() => Value.ToString();
    }
}