using System.Linq;
using LinqRewrite.Extensions;
using LinqRewrite.Services;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.DataStructures
{
    public enum CollectionType
    {
        Array, List, IList, IEnumerable, SimpleList
    }
    
    public class CollectionValueBridge : TypedValueBridge
    {
        public CollectionType CollectionType { get; }
        public ValueBridge Count { get; }
        public TypeSyntax ItemType { get; }
        
        public new TypedValueBridge this[ValueBridge i] => new TypedValueBridge(ItemType, this.ArrayAccess(i));
            
        public CollectionValueBridge(RewriteParameters p, TypeBridge collectionType, TypeBridge itemType, ValueBridge name, bool reuse) : base(collectionType, name)
        {
            ItemType = itemType;
            if (collectionType.Type is ArrayTypeSyntax) CollectionType = CollectionType.Array;
            else
            {
                var displayString = collectionType.Type.ToString();
                if (displayString.StartsWith("LinqRewrite.Core.SimpleList.SimpleList<"))
                    CollectionType = CollectionType.SimpleList;
                else if (displayString.StartsWith("System.Collections.Generic.List<"))
                    CollectionType = CollectionType.List;
                else if (displayString.StartsWith("System.Collections.Generic.IList<"))
                    CollectionType = CollectionType.IList;
                else CollectionType = CollectionType.IEnumerable;
            }
            Count = CodeCreationService.CreateCollectionCount(Value, CollectionType);

            if (CollectionType == CollectionType.IEnumerable) return;
            if (reuse) Value = name.ReusableConst(p, Type, CollectionType == CollectionType.SimpleList ? true : (bool?)null);
            if (reuse) Count = Count.ReusableConst(p, Int);
        }
            
        public CollectionValueBridge(RewriteParameters p, ITypeSymbol type, ValueBridge name, bool reuse) : base(null as TypeSyntax, name)
        {
            ItemType = SyntaxFactory.ParseTypeName(SymbolExtensions.GetItemType(type).ToDisplayString());
            Type = SyntaxFactory.ParseTypeName(type.ToDisplayString());
            
            if (type is IArrayTypeSymbol) CollectionType = CollectionType.Array;
            else
            {
                var displayString = type.ToDisplayString();
                if (displayString.StartsWith("LinqRewrite.Core.SimpleList.SimpleList<"))
                    CollectionType = CollectionType.SimpleList;
                else if (displayString.StartsWith("System.Collections.Generic.List<"))
                    CollectionType = CollectionType.List;
                else if (displayString.StartsWith("System.Collections.Generic.IList<") || type.AllInterfaces.Any(x => x.ToDisplayString().StartsWith("System.Collections.Generic.IList<")))
                    CollectionType = CollectionType.IList;
                else CollectionType = CollectionType.IEnumerable;
            }
            Count = CodeCreationService.CreateCollectionCount(Value, CollectionType);

            if (CollectionType == CollectionType.IEnumerable) return;
            if (reuse) Value = name.ReusableConst(p, Type, CollectionType == CollectionType.SimpleList ? true : (bool?)null);
            if (reuse) Count = Count.ReusableConst(p, Int);
        }
        
        public override string ToString() => Value.ToString();
    }
}