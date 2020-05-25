using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.VariableExtensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteCollectionEnumeration
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args, bool? reuseVariables = null)
        {
            if (!AssertionExtension.AssertNotNull(p, p.CurrentCollection)) return;
            p.AddIterator(p.CurrentCollection);
            RewriteOther(p, p.CurrentCollection, null, false, reuseVariables);
        }
        
        public static void RewriteOther(RewriteParameters p, CollectionValueBridge collection, LocalVariable variable = null, bool otherIndexer = false, bool? reuseVariables = null)
        {
            if (collection.CollectionType == CollectionType.Array
                || collection.CollectionType == CollectionType.List
                || collection.CollectionType == CollectionType.IList
                || collection.CollectionType == CollectionType.SimpleList) ArrayEnumeration(p, collection.ItemType, collection.Count, collection, variable);
            else if (collection.CollectionType == CollectionType.IEnumerable) EnumerableEnumeration(p, collection, variable);

            if (otherIndexer) p.CurrentIterator.Indexer = null;
        }

        public static void ArrayEnumeration(RewriteParameters p, TypeBridge itemType, ValueBridge count, ValueBridge collection, LocalVariable variable = null)
        {
            p.CurrentIterator.ForFrom = 0;
            p.CurrentIterator.ForTo = count - 1;
            p.CurrentIterator.ForIndexer = VariableCreator.GlobalVariable(p, Int);
            
            if (p.CurrentIndexer == null)
            {
                p.CurrentIterator.Indexer = p.CurrentIterator.ForIndexer;
                p.CurrentIterator.Indexer.IsGlobal = true;
            }
            
            if (variable == null)
                p.LastValue = new TypedValueBridge(itemType, collection[p.CurrentIterator.ForIndexer]);
            else
            {
                p.CurrentIterator.BodyAdd(variable.Assign(collection[p.CurrentIterator.ForIndexer]));
                p.LastValue = new TypedValueBridge(itemType, variable);
            }
            
            p.ResultSize = count;
            p.SourceSize = count;
            p.SimpleEnumeration = true;
            p.ListEnumeration = true;
        }

        public static void EnumerableEnumeration(RewriteParameters p, CollectionValueBridge collection, LocalVariable variable = null)
        {
            p.CurrentIterator.ForFrom = null;
            p.CurrentIterator.ForTo = null;
            p.CurrentIterator.Enumerator = VariableCreator.GlobalVariable(p, ParseTypeName($"System.Collections.Generic.IEnumerator<{collection.ItemType}>"));
            p.CurrentIterator.ListEnumeration = false;

            if (variable == null)
                p.LastValue = new TypedValueBridge(collection.ItemType, p.CurrentIterator.Enumerator.Access("Current"));
            else
            {
                p.CurrentForAdd(variable.Assign(p.CurrentIterator.Enumerator.Access("Current")));
                p.LastValue = new TypedValueBridge(collection.ItemType, variable);
            }

            p.SourceSize = null;
            var listEnumerations = p.Iterators.Select(x => x.ListEnumeration).ToArray();
            p.ListEnumeration = false;
            listEnumerations.Select((x, i) => (x, i)).ForEach(x => p.Iterators[x.i].ListEnumeration = x.x);
            p.ModifiedEnumeration = true;
        }
    }
}