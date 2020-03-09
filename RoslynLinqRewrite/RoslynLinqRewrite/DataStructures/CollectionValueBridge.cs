using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Constants;

namespace LinqRewrite.DataStructures
{
    public enum CollectionType
    {
        Array, List, Enumerable
    }
    
    public class CollectionValueBridge : TypedValueBridge
    {
        public CollectionType CollectionType { get; set; }
        public ValueBridge Count { get; set; }
        public TypeSyntax ItemType { get; set; }
        
        public CollectionValueBridge(TypeSyntax itemType, TypeSyntax type, ValueBridge count, IdentifierNameSyntax name) : base(type, name)
        {
            Count = count;
            ItemType = itemType;
            
            var collectionName = type.ToString();
            if (type is ArrayTypeSyntax) 
                CollectionType = CollectionType.Array;
            else if (collectionName.StartsWith(ListPrefix, StringComparison.OrdinalIgnoreCase))
                CollectionType = CollectionType.List;
            else if (collectionName.StartsWith(IEnumerablePrefix, StringComparison.OrdinalIgnoreCase))
                CollectionType = CollectionType.Enumerable;
        }

        public CollectionValueBridge(TypeBridge itemType, TypeBridge type, ValueBridge count, ValueBridge name) : base(type, name)
        {
            Count = count;
            ItemType = itemType;
            
            var collectionName = type.ToString();
            if (type.Type is ArrayTypeSyntax) 
                CollectionType = CollectionType.Array;
            else if (collectionName.StartsWith(ListPrefix, StringComparison.OrdinalIgnoreCase))
                CollectionType = CollectionType.List;
            else if (collectionName.StartsWith(IEnumerablePrefix, StringComparison.OrdinalIgnoreCase))
                CollectionType = CollectionType.Enumerable;
        }

        public CollectionValueBridge(TypeSyntax itemType, TypeSyntax type, ValueBridge count, LocalVariable variable) : base(type, variable)
        {
            Count = count;
            ItemType = itemType;
            
            var collectionName = type.ToString();
            if (type is ArrayTypeSyntax) 
                CollectionType = CollectionType.Array;
            else if (collectionName.StartsWith(ListPrefix, StringComparison.OrdinalIgnoreCase))
                CollectionType = CollectionType.List;
            else if (collectionName.StartsWith(IEnumerablePrefix, StringComparison.OrdinalIgnoreCase))
                CollectionType = CollectionType.Enumerable;
        }

        public CollectionValueBridge(TypeBridge itemType, TypeBridge type, ValueBridge count, LocalVariable variable) : base(type, variable)
        {
            Count = count;
            ItemType = itemType;
            
            var collectionName = type.ToString();
            if (type.Type is ArrayTypeSyntax) 
                CollectionType = CollectionType.Array;
            else if (collectionName.StartsWith(ListPrefix, StringComparison.OrdinalIgnoreCase))
                CollectionType = CollectionType.List;
            else if (collectionName.StartsWith(IEnumerablePrefix, StringComparison.OrdinalIgnoreCase))
                CollectionType = CollectionType.Enumerable;
        }

        public override string ToString() => Value.ToString();
    }
}