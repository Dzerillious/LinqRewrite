using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.Extensions;

namespace Shaman.Roslyn.LinqRewrite.DataStructures
{
    public class ValueBridge
    {
        private readonly ExpressionSyntax _value;

        public ValueBridge(bool value)
        {
            _value = value
                ? SyntaxFactory.LiteralExpression(SyntaxKind.TrueLiteralExpression)
                : SyntaxFactory.LiteralExpression(SyntaxKind.FalseLiteralExpression);
        }

        public ValueBridge(int value)
        {
            _value = SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(value));
        }

        public ValueBridge(ExpressionSyntax value)
        {
            _value = value;
        }

        public ValueBridge(IdentifierNameSyntax name)
        {
            _value = name;
        }

        public ValueBridge(string name)
        {
            _value = SyntaxFactory.IdentifierName(name);
        }
        
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
            => name._value;
        
        public static implicit operator ArgumentSyntax(ValueBridge name)
            => SyntaxFactoryHelper.Argument(name._value);
    }
}