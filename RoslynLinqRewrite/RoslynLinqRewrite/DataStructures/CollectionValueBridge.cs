using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.DataStructures
{
    public abstract class CollectionValueBridge : TypedValueBridge
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

    public class ArrayValueBridge : CollectionValueBridge
    {
        public ArrayValueBridge(TypeSyntax itemType, TypeSyntax type, ValueBridge count, IdentifierNameSyntax name) : base(itemType, type, count, name)
        {
        }

        public ArrayValueBridge(TypeBridge itemType, TypeBridge type, ValueBridge count, ValueBridge name) : base(itemType, type, count, name)
        {
        }

        public ArrayValueBridge(TypeSyntax itemType, TypeSyntax type, ValueBridge count, LocalVariable variable) : base(itemType, type, count, variable)
        {
        }

        public ArrayValueBridge(TypeBridge itemType, TypeBridge type, ValueBridge count, LocalVariable variable) : base(itemType, type, count, variable)
        {
        }
    }
    
    public class ListValueBridge : CollectionValueBridge
    {
        public ListValueBridge(TypeSyntax itemType, TypeSyntax type, ValueBridge count, IdentifierNameSyntax name) : base(itemType, type, count, name)
        {
        }

        public ListValueBridge(TypeBridge itemType, TypeBridge type, ValueBridge count, ValueBridge name) : base(itemType, type, count, name)
        {
        }

        public ListValueBridge(TypeSyntax itemType, TypeSyntax type, ValueBridge count, LocalVariable variable) : base(itemType, type, count, variable)
        {
        }

        public ListValueBridge(TypeBridge itemType, TypeBridge type, ValueBridge count, LocalVariable variable) : base(itemType, type, count, variable)
        {
        }
    }
    
    public class EnumerableValueBridge : CollectionValueBridge
    {
        public EnumerableValueBridge(TypeSyntax itemType, TypeSyntax type, ValueBridge count, IdentifierNameSyntax name) : base(itemType, type, count, name)
        {
        }

        public EnumerableValueBridge(TypeBridge itemType, TypeBridge type, ValueBridge count, ValueBridge name) : base(itemType, type, count, name)
        {
        }

        public EnumerableValueBridge(TypeSyntax itemType, TypeSyntax type, ValueBridge count, LocalVariable variable) : base(itemType, type, count, variable)
        {
        }

        public EnumerableValueBridge(TypeBridge itemType, TypeBridge type, ValueBridge count, LocalVariable variable) : base(itemType, type, count, variable)
        {
        }
    }
}