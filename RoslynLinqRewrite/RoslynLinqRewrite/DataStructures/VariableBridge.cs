using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.DataStructures
{
    public class VariableBridge : ValueBridge
    {
        private readonly string _name;

        private VariableBridge(string name) 
            : base(SyntaxFactory.IdentifierName(name))
            => _name = name;
        
        public static implicit operator VariableBridge(string name)
            => new VariableBridge(name);
        
        public static implicit operator VariableBridge(LocalVariable variable)
            => new VariableBridge(variable.Name);
        
        public static implicit operator IdentifierNameSyntax(VariableBridge name)
            => SyntaxFactory.IdentifierName(name._name);
        
        public static implicit operator ExpressionSyntax(VariableBridge name)
            => SyntaxFactory.IdentifierName(name._name);
        
        public static implicit operator StatementBridge(VariableBridge name)
            => SyntaxFactory.ExpressionStatement(SyntaxFactory.IdentifierName(name._name));
        
        public static implicit operator string(VariableBridge name)
            => name._name;
    }
}