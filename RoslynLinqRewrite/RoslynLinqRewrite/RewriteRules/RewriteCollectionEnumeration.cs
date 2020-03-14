using System.Linq;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using SimpleCollections;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteCollectionEnumeration
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            p.AddIterator(new RewrittenValueBridge(p.CurrentCollection));
            RewriteOther(p, p.CurrentCollection);
        }
        
        public static void RewriteOther(RewriteParameters p, CollectionValueBridge collection, LocalVariable variable = null)
        {
            p.Variables.Where(x => !x.IsGlobal).ForEach(x => x.IsUsed = false);
            
            if (collection.CollectionType == CollectionType.Array) ArrayEnumeration(p, collection, variable);
            else if (collection.CollectionType == CollectionType.List) ListEnumeration(p, collection, variable);
            else if (collection.CollectionType == CollectionType.Enumerable) EnumerableEnumeration(p, collection, variable);
        }

        public static void ArrayEnumeration(RewriteParameters p, CollectionValueBridge collection, LocalVariable variable = null)
        {
            p.ForMin = p.ForReMin = 0;
            p.ForMax = collection.Count;
            p.ForReMax = collection.Count - 1;

            p.CurrentIterator.ForIndexer = p.LocalVariable(Int);
            if (p.CurrentIndexer == null)
            {
                p.CurrentIterator.CurrentIndexer = p.CurrentIterator.ForIndexer;
                p.CurrentIterator.CurrentIndexer.IsGlobal = true;
            }
            
            if (variable == null)
            {
                p.LastValue = new TypedValueBridge(collection.ItemType, collection[p.CurrentIterator.ForIndexer]);
            }
            else
            {
                p.CurrentIterator.BodyAdd(variable.Assign(collection[p.CurrentIterator.ForIndexer]));
                p.LastValue = new TypedValueBridge(collection.ItemType, variable);
            }
            
            p.ResultSize = collection.Count;
            p.SourceSize = collection.Count;
            p.ListEnumeration = true;
        }

        public static void ListEnumeration(RewriteParameters p, CollectionValueBridge collection, LocalVariable variable = null)
        {
            var sourceCount = collection.Count.ReusableConst(p, Int);

            p.ForMin = p.ForReMin = 0;
            p.ForMax = sourceCount;
            p.ForReMax = sourceCount - 1;
            
            p.CurrentIterator.ForIndexer = p.LocalVariable(Int);
            if (p.CurrentIndexer == null)
            {
                p.CurrentIterator.CurrentIndexer = p.CurrentIterator.ForIndexer;
                p.CurrentIterator.CurrentIndexer.IsGlobal = true;
            }
            
            if (variable == null)
            {
                p.LastValue = new TypedValueBridge(collection.ItemType, collection[p.CurrentIterator.ForIndexer]);
            }
            else
            {
                p.CurrentIterator.BodyAdd(variable.Assign(collection[p.CurrentIterator.ForIndexer]));
                p.LastValue = new TypedValueBridge(collection.ItemType, variable);
            }
            
            p.ResultSize = sourceCount;
            p.SourceSize = sourceCount;
            p.ListEnumeration = true;
        }

        public static void EnumerableEnumeration(RewriteParameters p, CollectionValueBridge collection, LocalVariable variable = null)
        {
            p.ForMin = p.ForReMin = null;
            p.ForMax = p.ForReMax = null;

            p.IsReversed = false;
            p.CurrentIterator.EnumeratorVariable = p.GlobalVariable(p.WrappedItemType("IEnumerator<", collection, ">"));
            if (variable != null)
            {
                p.LastForAdd(variable.Assign(p.CurrentIterator.EnumeratorVariable.Access("Current")));
                p.LastValue = new TypedValueBridge(collection.ItemType, variable);
            }
            else p.LastValue = new TypedValueBridge(collection.ItemType, p.CurrentIterator.EnumeratorVariable.Access("Current"));

            p.SourceSize = null;
            p.ModifiedEnumeration = true;
        }
    }
}