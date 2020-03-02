﻿using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.DataStructures
{
    public class TypeBridge
    {
        private readonly TypeSyntax _type;

        private TypeBridge(TypeSyntax type)
            => _type = type;

        private TypeBridge(SyntaxKind type)
            => _type = SyntaxFactory.PredefinedType(SyntaxFactory.Token(type));
        
        public static implicit operator TypeBridge(SyntaxKind kind)
            => new TypeBridge(kind);
        
        public static implicit operator TypeBridge(TypeSyntax type)
            => new TypeBridge(type);
        
        public static implicit operator TypeSyntax(TypeBridge type)
            => type._type;

        public override string ToString() => _type.ToString();
    }
}