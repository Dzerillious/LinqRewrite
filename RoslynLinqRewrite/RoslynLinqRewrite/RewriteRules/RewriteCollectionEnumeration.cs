using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static LinqRewrite.Constants;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteCollectionEnumeration
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex != 0) throw new InvalidOperationException("Collection enumeration should be first expression.");

            var collectionType = p.Collection.GetType(p);
            var collectionName = collectionType.ToString();
            
            if (collectionType is ArrayTypeSyntax)
                ArrayEnumeration(p, p.Collection);
            else if (collectionName.StartsWith(ListPrefix, StringComparison.OrdinalIgnoreCase))
                ListEnumeration(p, p.Collection);
            else if (collectionName.StartsWith(IEnumerablePrefix, StringComparison.OrdinalIgnoreCase))
                EnumerableEnumeration(p, p.Collection);
        }
        
        public static void RewriteOther(RewriteParameters p, ValueBridge collection, int chainIndex)
        {
            if (chainIndex != 0) throw new InvalidOperationException("Collection enumeration should be first expression.");
            
            var collectionType = collection.GetType(p);
            var collectionName = collectionType.ToString();
            
            if (collectionType is ArrayTypeSyntax)
                ArrayEnumeration(p, collection);
            else if (collectionName.StartsWith(ListPrefix, StringComparison.OrdinalIgnoreCase))
                ListEnumeration(p, collection);
            else if (collectionName.StartsWith(IEnumerablePrefix, StringComparison.OrdinalIgnoreCase))
                EnumerableEnumeration(p, collection);
        }

        public static void ArrayEnumeration(RewriteParameters p, ValueBridge collection)
        {
            var count = collection.Count(p);

            p.ForMin = p.ForReMin = 0;
            p.ForMax = p.ForReMax = count;

            p.CurrentIndexer = p.LocalVariable(Int, "__i");
            p.Body.Indexer = p.Indexer;
            p.Last = new TypedValueBridge(collection.ItemType(p), collection[p.Indexer]);
            
            p.ResultSize = count;
            p.SourceSize = count;
        }

        public static void ListEnumeration(RewriteParameters p, ValueBridge collection)
        {
            p.InitialAdd( If(collection.IsEqual(Null),
                            CreateThrowException("System.InvalidOperationException", "Collection was null.")));
                
            var sourceCount = p.LocalVariable(Int, "__sourceCount", collection.Count(p));

            p.ForMin = p.ForReMin = 0;
            p.ForMax = p.ForReMax = sourceCount;
            
            p.CurrentIndexer = p.LocalVariable(Int, "__i");
            p.Body.Indexer = p.Indexer;
            p.Last = new TypedValueBridge(collection.ItemType(p), collection[p.Indexer]);
            
            p.ResultSize = IdentifierName(sourceCount);
            p.SourceSize = IdentifierName(sourceCount);
        }

        public static void EnumerableEnumeration(RewriteParameters p, ValueBridge collection)
        {
            p.ForMin = p.ForReMin = null;
            p.ForMax = p.ForReMax = null;

            p.IsReversed = false;
            p.ListsEnumeration = false;
            p.Body.IndexedItem = p.LocalVariable(collection.ItemType(p), "__i");
            p.Last = new TypedValueBridge(collection.ItemType(p), p.Body.IndexedItem);

            p.SourceSize = null;
            p.ResultSize = null;
        }
    }
}