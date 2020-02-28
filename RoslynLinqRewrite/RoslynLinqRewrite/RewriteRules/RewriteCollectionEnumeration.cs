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
                ArrayEnumeration(p, p.Collection, p.ForIndexerName);
            else if (collectionName.StartsWith(ListPrefix, StringComparison.OrdinalIgnoreCase))
                ListEnumeration(p, p.Collection, p.ForIndexerName, chainIndex);
            else if (collectionName.StartsWith(IEnumerablePrefix, StringComparison.OrdinalIgnoreCase))
                EnumerableEnumeration(p, p.Collection, p.ForIndexerName);
        }
        
        public static void RewriteOther(RewriteParameters p, ExpressionSyntax collection, ValueBridge indexer, int chainIndex)
        {
            if (chainIndex != 0) throw new InvalidOperationException("Collection enumeration should be first expression.");

            var collectionType = p.Semantic.GetTypeFromExpression(collection);
            var collectionName = collectionType.ToString();
            
            if (collectionType is ArrayTypeSyntax)
                ArrayEnumeration(p, collection, indexer);
            else if (collectionName.StartsWith(ListPrefix, StringComparison.OrdinalIgnoreCase))
                ListEnumeration(p, collection, indexer, chainIndex);
            else if (collectionName.StartsWith(IEnumerablePrefix, StringComparison.OrdinalIgnoreCase))
                EnumerableEnumeration(p, collection, indexer);
        }

        public static void ArrayEnumeration(RewriteParameters p, ExpressionSyntax collection, ValueBridge indexer)
        {
            var count = p.Code.CreateCollectionCount(collection, false);

            p.ForMin = p.ForReMin = 0;
            p.ForMax = p.ForReMax = count;

            p.LastItem = collection.ArrayAccess(indexer);
            p.Indexer = indexer;
            
            p.ResultSize = count;
            p.SourceSize = count;
        }

        public static void ListEnumeration(RewriteParameters p, ExpressionSyntax collection, ValueBridge indexer, int chainIndex)
        {
            
            p.PreForAdd( If(collection.EqualsExpr(NullValue),
                            CreateThrowException("System.InvalidOperationException", "Collection was null.")));
                
            var sourceCount = p.CreateLocalVariable("__sourceCount", p.Code.CreateCollectionCount(collection, false));

            p.ForMin = p.ForReMin = 0;
            p.ForMax = p.ForReMax = sourceCount;
            
            p.LastItem = collection.ArrayAccess(indexer);
            p.Indexer = indexer;
            
            p.ResultSize = IdentifierName(sourceCount);
            p.SourceSize = IdentifierName(sourceCount);
        }

        public static void EnumerableEnumeration(RewriteParameters p, ExpressionSyntax collection, ValueBridge itemName)
        {
            p.PreForAdd(If(collection.EqualsExpr(NullValue),
                            CreateThrowException("System.InvalidOperationException", "Collection was null.")));

            p.ForMin = p.ForReMin = null;
            p.ForMax = p.ForReMax = null;

            p.IsReversed = false;
            p.LastItem = itemName;
            p.ListsEnumeration = false;

            p.SourceSize = null;
            p.ResultSize = null;
        }
    }
}