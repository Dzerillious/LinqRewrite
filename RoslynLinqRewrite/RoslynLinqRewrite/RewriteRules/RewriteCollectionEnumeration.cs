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

            var collectionType = p.Semantic.GetTypeFromExpression(p.Collection);
            var collectionName = collectionType.ToString();
            
            if (collectionType is ArrayTypeSyntax)
                ArrayEnumeration(p, p.Collection);
            else if (collectionName.StartsWith(ListPrefix, StringComparison.OrdinalIgnoreCase))
                ListEnumeration(p, p.Collection);
            else if (collectionName.StartsWith(IEnumerablePrefix, StringComparison.OrdinalIgnoreCase))
                EnumerableEnumeration(p, p.Collection);
        }
        
        public static void RewriteOther(RewriteParameters p, ExpressionSyntax collection, int chainIndex)
        {
            if (chainIndex != 0) throw new InvalidOperationException("Collection enumeration should be first expression.");

            var collectionType = p.Semantic.GetTypeFromExpression(collection);
            var collectionName = collectionType.ToString();
            
            if (collectionType is ArrayTypeSyntax)
                ArrayEnumeration(p, collection);
            else if (collectionName.StartsWith(ListPrefix, StringComparison.OrdinalIgnoreCase))
                ListEnumeration(p, collection);
            else if (collectionName.StartsWith(IEnumerablePrefix, StringComparison.OrdinalIgnoreCase))
                EnumerableEnumeration(p, collection);
        }

        public static void ArrayEnumeration(RewriteParameters p, ExpressionSyntax collection)
        {
            var count = p.Code.CreateCollectionCount(collection, false);

            p.ForMin = p.ForReMin = 0;
            p.ForMax = p.ForReMax = count;

            p.CurrentIndexer = p.CreateLocalVariable("__i", IntType);
            p.Body.Indexer = p.Indexer;
            p.Last = (collection.ArrayAccess(p.Indexer), IntType);
            
            p.ResultSize = count;
            p.SourceSize = count;
        }

        public static void ListEnumeration(RewriteParameters p, ExpressionSyntax collection)
        {
            
            p.InitialAdd( If(collection.EqualsExpr(NullValue),
                            CreateThrowException("System.InvalidOperationException", "Collection was null.")));
                
            var sourceCount = p.CreateLocalVariable("__sourceCount", IntType, p.Code.CreateCollectionCount(collection, false));

            p.ForMin = p.ForReMin = 0;
            p.ForMax = p.ForReMax = sourceCount;
            
            p.CurrentIndexer = p.CreateLocalVariable("__i", IntType);
            p.Body.Indexer = p.Indexer;
            p.Last = (collection.ArrayAccess(p.Indexer), IntType);
            
            p.ResultSize = IdentifierName(sourceCount);
            p.SourceSize = IdentifierName(sourceCount);
        }

        public static void EnumerableEnumeration(RewriteParameters p, ExpressionSyntax collection)
        {
            p.ForMin = p.ForReMin = null;
            p.ForMax = p.ForReMax = null;

            p.IsReversed = false;
            p.ListsEnumeration = false;
            p.Body.IndexerValue = p.CreateLocalVariable("__i", collection.ItemType(p));
            p.Last = (p.Body.IndexerValue, IntType);

            p.SourceSize = null;
            p.ResultSize = null;
        }
    }
}