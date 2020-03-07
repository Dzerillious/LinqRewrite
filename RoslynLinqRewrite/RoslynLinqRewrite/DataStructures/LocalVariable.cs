using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.DataStructures
{
    public class LocalVariable : VariableBridge
    {
        public TypeSyntax Type { get; }

        public bool IsUsed { get; set; } = true;
        public bool IsGlobal { get; set; }

        public LocalVariable(string name, TypeSyntax type)
            : base(name)
        {
            Type = type;
        }
        
        public static implicit operator IdentifierNameSyntax(LocalVariable name)
            => SyntaxFactory.IdentifierName(name.Name);
        
        public static implicit operator ExpressionSyntax(LocalVariable name)
            => SyntaxFactory.IdentifierName(name.Name);
        
        public static implicit operator StatementBridge(LocalVariable name)
            => SyntaxFactory.ExpressionStatement(SyntaxFactory.IdentifierName(name.Name));
        
        public static implicit operator string(LocalVariable name)
            => name.Name;
    }
}