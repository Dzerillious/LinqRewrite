using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.DataStructures
{
    public class ArgumentBridge
    {
        public new ArgumentSyntax Value { get; }

        public ArgumentBridge(bool value)
        {
            Value = SyntaxFactory.Argument(value
                ? SyntaxFactory.LiteralExpression(SyntaxKind.TrueLiteralExpression)
                : SyntaxFactory.LiteralExpression(SyntaxKind.FalseLiteralExpression));
        }

        public ArgumentBridge(int value)
            => Value = SyntaxFactory.Argument(SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(value)));

        public ArgumentBridge(double value)
            => Value = SyntaxFactory.Argument(SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(value)));

        public ArgumentBridge(float value)
            => Value = SyntaxFactory.Argument(SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(value)));

        public ArgumentBridge(ArgumentSyntax value)
            => Value = value;

        public ArgumentBridge(ExpressionSyntax value)
            => Value = SyntaxFactory.Argument(value);

        public ArgumentBridge(IdentifierNameSyntax name)
            => Value = SyntaxFactory.Argument(name);

        public ArgumentBridge(string name)
            => Value = SyntaxFactory.Argument(SyntaxFactory.IdentifierName(name));

        protected ArgumentBridge(LocalVariable variable)
            => Value = SyntaxFactory.Argument(variable);

        public static implicit operator ArgumentBridge(int value)
            => new ArgumentBridge(value);

        public static implicit operator ArgumentBridge(float value)
            => new ArgumentBridge(value);

        public static implicit operator ArgumentBridge(double value)
            => new ArgumentBridge(value);
        
        public static implicit operator ArgumentBridge(bool value)
            => new ArgumentBridge(value);
        
        public static implicit operator ArgumentBridge(string name)
            => new ArgumentBridge(name);
        
        public static implicit operator ArgumentBridge(ExpressionSyntax value)
            => new ArgumentBridge(value);
        
        public static implicit operator ArgumentBridge(LocalVariable value)
            => new ArgumentBridge(value);
        
        public static implicit operator ArgumentBridge(ValueBridge value)
            => new ArgumentBridge(value);
        
        public static implicit operator ArgumentBridge(IdentifierNameSyntax name)
            => new ArgumentBridge(name);
        
        public static implicit operator ArgumentBridge(ArgumentSyntax name)
            => new ArgumentBridge(name);
        
        public static implicit operator ArgumentSyntax(ArgumentBridge argument)
            => argument.Value;
    }
}