using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.DataStructures
{
    public class CollectionValueBridge : TypedValueBridge
    {
        public ValueBridge Count { get; set; }
        public TypeSyntax ItemType { get; set; }
        
        public CollectionValueBridge(TypeSyntax itemType, TypeSyntax type, ValueBridge count, IdentifierNameSyntax name) : base(type, name)
        {
            Count = count;
            ItemType = itemType;
        }

        public CollectionValueBridge(TypeBridge itemType, TypeBridge type, ValueBridge count, ValueBridge name) : base(type, name)
        {
            Count = count;
            ItemType = itemType;
        }

        public CollectionValueBridge(TypeSyntax itemType, TypeSyntax type, ValueBridge count, LocalVariable variable) : base(type, variable)
        {
            Count = count;
            ItemType = itemType;
        }

        public CollectionValueBridge(TypeBridge itemType, TypeBridge type, ValueBridge count, LocalVariable variable) : base(type, variable)
        {
            Count = count;
            ItemType = itemType;
        }

        public override string ToString() => Value.ToString();
    }
}