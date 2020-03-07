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
        public static void Rewrite(RewriteParameters p, ExpressionSyntax[] args)
        {
            p.Iterators.Add(p.Iterator = new IteratorParameters(p, p.CurrentCollection));
            RewriteOther(p, p.CurrentCollection);
        }
        
        public static void RewriteOther(RewriteParameters p, CollectionValueBridge collection)
        {
            p.Variables.Where(x => !x.IsGlobal).ForEach(x => x.IsUsed = false);
            
            if (p.CurrentCollection is ArrayValueBridge) ArrayEnumeration(p, collection);
            else if (p.CurrentCollection is ListValueBridge) ListEnumeration(p, collection);
            else if (p.CurrentCollection is EnumerableValueBridge) EnumerableEnumeration(p, collection);
        }

        public static void ArrayEnumeration(RewriteParameters p, CollectionValueBridge collection)
        {
            p.ForMin = p.ForReMin = 0;
            p.ForMax = collection.Count;
            p.ForReMax = collection.Count - 1;

            p.CurrentIndexer = p.LocalVariable(Int);
            p.Iterator.Indexer = p.Indexer;
            p.Last = new TypedValueBridge(collection.ItemType, collection[p.Indexer]);
            
            p.ResultSize = collection.Count;
            p.SourceSize = collection.Count;
            p.ListEnumeration = true;
        }

        public static void ListEnumeration(RewriteParameters p, CollectionValueBridge collection)
        {
            p.InitialAdd( If(collection.IsEqual(Null),
                            CreateThrowException("System.InvalidOperationException", "Collection was null.")));

            var sourceCount = collection.Count.Reusable(p);

            p.ForMin = p.ForReMin = 0;
            p.ForMax = p.ForReMax = sourceCount;
            
            p.CurrentIndexer = p.LocalVariable(Int);
            p.Iterator.Indexer = p.Indexer;
            p.Last = new TypedValueBridge(collection.ItemType, collection[p.Indexer]);
            
            p.ResultSize = sourceCount;
            p.SourceSize = sourceCount;
            p.ListEnumeration = true;
        }

        public static void EnumerableEnumeration(RewriteParameters p, CollectionValueBridge collection)
        {
            p.ForMin = p.ForReMin = null;
            p.ForMax = p.ForReMax = null;

            p.IsReversed = false;
            p.Iterator.IndexedItem = p.LocalVariable(collection.ItemType);
            p.Last = new TypedValueBridge(collection.ItemType, p.Iterator.IndexedItem);

            p.SourceSize = null;
            p.ModifiedEnumeration = true;
        }
    }
}