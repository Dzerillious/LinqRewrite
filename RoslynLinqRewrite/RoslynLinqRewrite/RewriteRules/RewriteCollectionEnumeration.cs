using System;
using System.Linq;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SimpleCollections;
using static LinqRewrite.Constants;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteCollectionEnumeration
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            p.Iterators.Add(p.Iterator = new IteratorParameters(p, new RewrittenValueBridge(p.CurrentCollection)));
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

            p.CurrentIndexer = p.LocalVariable(Int);
            if (variable == null)
            {
                p.Iterator.Indexer = p.Indexer;
                p.Last = new TypedValueBridge(collection.ItemType, collection[p.Indexer]);
            }
            else
            {
                p.Iterator.BodyAdd(variable.Assign(collection[p.Indexer]));
                p.Last = new TypedValueBridge(collection.ItemType, variable);
            }
            
            p.ResultSize = collection.Count;
            p.SourceSize = collection.Count;
            p.ListEnumeration = true;
        }

        public static void ListEnumeration(RewriteParameters p, CollectionValueBridge collection, LocalVariable variable = null)
        {
            p.InitialAdd( If(collection.IsEqual(Null),
                            CreateThrowException("System.InvalidOperationException", "Collection was null.")));

            var sourceCount = collection.Count.Reusable(p);

            p.ForMin = p.ForReMin = 0;
            p.ForMax = p.ForReMax = sourceCount;
            
            p.CurrentIndexer = p.LocalVariable(Int);
            if (variable == null)
            {
                p.Iterator.Indexer = p.Indexer;
                p.Last = new TypedValueBridge(collection.ItemType, collection[p.Indexer]);
            }
            else
            {
                p.Iterator.BodyAdd(variable.Assign(collection[p.Indexer]));
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
            if (variable == null) p.LocalVariable(collection.ItemType);
            p.Iterator.IndexedItem = variable;
            p.Last = new TypedValueBridge(collection.ItemType, p.Iterator.IndexedItem);

            p.SourceSize = null;
            p.ModifiedEnumeration = true;
        }
    }
}