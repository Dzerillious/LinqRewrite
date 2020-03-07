using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.DataStructures
{
    public class TypeBridge
    {
        public TypeSyntax Type { get; }

        private TypeBridge(TypeSyntax type)
            => Type = type;

        private TypeBridge(SyntaxKind type)
            => Type = SyntaxFactory.PredefinedType(SyntaxFactory.Token(type));
        
        public static implicit operator TypeBridge(SyntaxKind kind)
            => new TypeBridge(kind);
        
        public static implicit operator TypeBridge(TypeSyntax type)
            => new TypeBridge(type);
        
        public static implicit operator TypeSyntax(TypeBridge type)
            => type.Type;

        public override string ToString() => Type.ToString();
    }
}