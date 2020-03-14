using System;
using LinqRewrite.Extensions;
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
        
        public new TypedValueBridge this[ValueBridge i] => new TypedValueBridge(ItemType, this.ArrayAccess(i));
            
        public CollectionValueBridge(TypeBridge itemType, TypeBridge type, ValueBridge count, ValueBridge name) : base(type, name)
        {
            Count = count;
            ItemType = itemType;
            
            var collectionName = type.ToString();
            if (type.Type is ArrayTypeSyntax) 
                CollectionType = CollectionType.Array;
            else if (collectionName.StartsWith(ListPrefix, StringComparison.OrdinalIgnoreCase))
                CollectionType = CollectionType.List;
            else CollectionType = CollectionType.Enumerable;
        }

        public CollectionValueBridge(TypeSyntax itemType, TypeSyntax type, ValueBridge count, IdentifierNameSyntax name)
            : this(itemType, type, count, (ValueBridge)name)
        {
        }

        public CollectionValueBridge(TypeSyntax itemType, TypeSyntax type, ValueBridge count, LocalVariable variable)
            : this(itemType, type, count, (ValueBridge)variable)
        {
        }

        public CollectionValueBridge(TypeBridge itemType, TypeBridge type, ValueBridge count, LocalVariable variable)
            : this(itemType, type, count, (ValueBridge)variable)
        {
        }

        public override string ToString() => Value.ToString();
    }
}