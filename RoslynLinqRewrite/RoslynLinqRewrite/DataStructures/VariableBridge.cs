using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Shaman.Roslyn.LinqRewrite.DataStructures
{
    public class VariableBridge
    {
        private readonly IdentifierNameSyntax _name;

        private VariableBridge(IdentifierNameSyntax name)
        {
            _name = name;
        }

        private VariableBridge(string name)
        {
            _name = SyntaxFactory.IdentifierName(name);
        }
        
        public static implicit operator VariableBridge(string name)
            => new VariableBridge(name);
        
        public static implicit operator VariableBridge(IdentifierNameSyntax name)
            => new VariableBridge(name);
        
        public static implicit operator IdentifierNameSyntax(VariableBridge name)
            => name._name;
        
        public static implicit operator ExpressionSyntax(VariableBridge name)
            => name._name;
    }
}