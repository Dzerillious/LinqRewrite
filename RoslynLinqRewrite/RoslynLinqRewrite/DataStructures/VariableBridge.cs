using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.DataStructures
{
    public class VariableBridge : ValueBridge
    {
        public string Name { get; }

        protected VariableBridge(string name) 
            : base(SyntaxFactory.IdentifierName(name))
            => Name = name;
        
        public static implicit operator VariableBridge(string name)
            => new VariableBridge(name);
        
        public static implicit operator IdentifierNameSyntax(VariableBridge name)
            => SyntaxFactory.IdentifierName(name.Name);
        
        public static implicit operator ExpressionSyntax(VariableBridge name)
            => SyntaxFactory.IdentifierName(name.Name);
        
        public static implicit operator StatementBridge(VariableBridge name)
            => SyntaxFactory.ExpressionStatement(SyntaxFactory.IdentifierName(name.Name));
        
        public static implicit operator string(VariableBridge name)
            => name.Name;
    }
}