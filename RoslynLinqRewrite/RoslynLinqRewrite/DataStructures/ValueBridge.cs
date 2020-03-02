using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.DataStructures
{
    public class  ValueBridge
    {
        public ExpressionSyntax Value { get; }

        public ValueBridge(bool value)
        {
            Value = value
                ? SyntaxFactory.LiteralExpression(SyntaxKind.TrueLiteralExpression)
                : SyntaxFactory.LiteralExpression(SyntaxKind.FalseLiteralExpression);
        }

        public ValueBridge(int value)
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
        
        public static implicit operator ValueBridge(bool value)
            => new ValueBridge(value);
        
        public static implicit operator ValueBridge(string name)
            => new ValueBridge(name);
        
        public static implicit operator ValueBridge(ExpressionSyntax value)
            => new ValueBridge(value);
        
        public static implicit operator ValueBridge(IdentifierNameSyntax name)
            => new ValueBridge(name);
        
        public static implicit operator ExpressionSyntax(ValueBridge name)
            => name.Value;
        
        public static implicit operator ArgumentSyntax(ValueBridge name)
            => SyntaxFactoryHelper.Argument(name.Value);
    }
}