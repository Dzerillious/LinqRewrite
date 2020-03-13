using System.Linq;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using SimpleCollections;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteCollectionEnumeration
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            p.FinalIterators.Add(p.Iterator = new IteratorParameters(p, new RewrittenValueBridge(p.CurrentCollection)));
            p.Iterators.Add(p.Iterator);
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

            p.Iterator.Indexer = p.LocalVariable(Int);
            if (p.CurrentIndexer == null)
            {
                p.Iterator.CurrentIndexer = p.Iterator.Indexer;
                p.Iterator.CurrentIndexer.IsGlobal = true;
            }
            
            if (variable == null)
            {
                p.Last = new TypedValueBridge(collection.ItemType, collection[p.Iterator.Indexer]);
            }
            else
            {
                p.Iterator.BodyAdd(variable.Assign(collection[p.Iterator.Indexer]));
                p.Last = new TypedValueBridge(collection.ItemType, variable);
            }
            
            p.ResultSize = collection.Count;
            p.SourceSize = collection.Count;
            p.ListEnumeration = true;
        }

        public static void ListEnumeration(RewriteParameters p, CollectionValueBridge collection, LocalVariable variable = null)
        {
            p.PreUseAdd( If(collection.IsEqual(Null),
                            CreateThrowException("System.InvalidOperationException", "Collection was null.")));

            var sourceCount = collection.Count.Reusable(p, Int);

            p.ForMin = p.ForReMin = 0;
            p.ForMax = sourceCount;
            p.ForReMax = sourceCount - 1;
            
            p.Iterator.Indexer = p.LocalVariable(Int);
            if (p.CurrentIndexer == null)
            {
                p.Iterator.CurrentIndexer = p.Iterator.Indexer;
                p.Iterator.CurrentIndexer.IsGlobal = true;
            }
            
            if (variable == null)
            {
                p.Last = new TypedValueBridge(collection.ItemType, collection[p.Iterator.Indexer]);
            }
            else
            {
                p.Iterator.BodyAdd(variable.Assign(collection[p.Iterator.Indexer]));
                p.Last = new TypedValueBridge(collection.ItemType, variable);
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
            p.Iterator.Enumerator = p.GlobalVariable(p.WrappedItemType("IEnumerator<", collection, ">"));
            if (variable != null)
            {
                p.LastForAdd(variable.Assign(p.Iterator.Enumerator.Access("Current")));
                p.Last = new TypedValueBridge(collection.ItemType, variable);
            }
            else p.Last = new TypedValueBridge(collection.ItemType, p.Iterator.Enumerator.Access("Current"));

            p.SourceSize = null;
            p.ModifiedEnumeration = true;
        }
    }
}