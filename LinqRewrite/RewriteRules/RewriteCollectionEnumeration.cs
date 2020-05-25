using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.AssertionExtension;
using static LinqRewrite.Extensions.VariableExtensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteCollectionEnumeration
    {
        public static void Rewrite(RewriteDesign design, RewrittenValueBridge[] args, bool? reuseVariables = null)
        {
            if (!AssertNotNull(design, design.CurrentCollection)) return;
            design.AddIterator(design.CurrentCollection);
            RewriteOther(design, design.CurrentCollection, null, false, reuseVariables);
        }
        
        public static void RewriteOther(RewriteDesign design, CollectionValueBridge collection, LocalVariable variable = null, bool otherIndexer = false, bool? reuseVariables = null)
        {
            if (collection.CollectionType == CollectionType.Array
                || collection.CollectionType == CollectionType.List
                || collection.CollectionType == CollectionType.IList
                || collection.CollectionType == CollectionType.SimpleList) ArrayEnumeration(design, collection.ItemType, collection.Count, collection, variable);
            else if (collection.CollectionType == CollectionType.IEnumerable) EnumerableEnumeration(design, collection, variable);

            if (otherIndexer) design.CurrentIterator.Indexer = null;
        }

        public static void ArrayEnumeration(RewriteDesign design, TypeBridge itemType, ValueBridge count, ValueBridge collection, LocalVariable variable = null)
        {
            design.CurrentIterator.ForFrom = 0;
            design.CurrentIterator.ForTo = count - 1;
            design.CurrentIterator.ForIndexer = CreateGlobalVariable(design, Int);
            
            if (design.CurrentIndexer == null)
            {
                design.CurrentIterator.Indexer = design.CurrentIterator.ForIndexer;
                design.CurrentIterator.Indexer.IsGlobal = true;
            }
            
            if (variable == null)
                design.LastValue = new TypedValueBridge(itemType, collection[design.CurrentIterator.ForIndexer]);
            else
            {
                design.CurrentIterator.BodyAdd(variable.Assign(collection[design.CurrentIterator.ForIndexer]));
                design.LastValue = new TypedValueBridge(itemType, variable);
            }
            
            design.ResultSize = count;
            design.SourceSize = count;
            design.SimpleEnumeration = true;
            design.ListEnumeration = true;
        }

        public static void EnumerableEnumeration(RewriteDesign design, CollectionValueBridge collection, LocalVariable variable = null)
        {
            design.CurrentIterator.ForFrom = null;
            design.CurrentIterator.ForTo = null;
            design.CurrentIterator.Enumerator = CreateGlobalVariable(design, ParseTypeName($"System.Collections.Generic.IEnumerator<{collection.ItemType}>"));
            design.CurrentIterator.ListEnumeration = false;

            if (variable == null)
                design.LastValue = new TypedValueBridge(collection.ItemType, design.CurrentIterator.Enumerator.Access("Current"));
            else
            {
                design.CurrentForAdd(variable.Assign(design.CurrentIterator.Enumerator.Access("Current")));
                design.LastValue = new TypedValueBridge(collection.ItemType, variable);
            }

            design.SourceSize = null;
            var listEnumerations = design.Iterators.Select(x => x.ListEnumeration).ToArray();
            design.ListEnumeration = false;
            listEnumerations.Select((x, i) => (x, i)).ForEach(x => design.Iterators[x.i].ListEnumeration = x.x);
            design.ModifiedEnumeration = true;
        }
    }
}