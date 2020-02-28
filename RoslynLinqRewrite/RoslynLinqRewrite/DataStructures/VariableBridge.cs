using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Shaman.Roslyn.LinqRewrite.DataStructures
{
    public class VariableBridge
    {
        private readonly string _name;

        private VariableBridge(string name)
        {
            _name = name;
        }
        
        public static implicit operator VariableBridge(string name)
            => new VariableBridge(name);
        
        public static implicit operator IdentifierNameSyntax(VariableBridge name)
            => SyntaxFactory.IdentifierName(name._name);
        
        public static implicit operator ExpressionSyntax(VariableBridge name)
            => SyntaxFactory.IdentifierName(name._name);
        
        public static implicit operator ValueBridge(VariableBridge name)
            => SyntaxFactory.IdentifierName(name._name);
        
        public static implicit operator string(VariableBridge name)
            => name._name;
    }
}