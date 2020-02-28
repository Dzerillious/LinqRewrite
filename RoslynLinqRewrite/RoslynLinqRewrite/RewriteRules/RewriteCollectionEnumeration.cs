using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using Shaman.Roslyn.LinqRewrite.Extensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Shaman.Roslyn.LinqRewrite.Constants;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Shaman.Roslyn.LinqRewrite.Extensions.VariableExtensions;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteCollectionEnumeration
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex != 0) throw new InvalidOperationException("Collection enumeration should be first expression.");

            var collectionType = p.Semantic.GetTypeFromExpression(p.Collection);
            var collectionName = collectionType.ToString();
            
            if (collectionType is ArrayTypeSyntax)
                ArrayEnumeration(p);
            else if (collectionName.StartsWith(ListPrefix, StringComparison.OrdinalIgnoreCase))
                ListEnumeration(p, chainIndex);
            else if (collectionName.StartsWith(IEnumerablePrefix, StringComparison.OrdinalIgnoreCase))
                IEnumerableEnumeration(p);
        }

        public static void ArrayEnumeration(RewriteParameters p)
        {
            var count = p.Code.CreateCollectionCount(GlobalItemsVariable, p.Collection, false);

            p.ForMin = p.ForReMin = 0;
            p.ForMax = p.ForReMax = count;

            p.LastItem = GlobalItemsVariable.ArrayAccess(GlobalIndexerVariable);
            p.Indexer = GlobalIndexerVariable;
            p.ResultSize = count;
            p.SourceSize = count;
        }

        public static void ListEnumeration(RewriteParameters p, int chainIndex)
        {
            var sourceCount = "__sourceCount" + chainIndex;
            
            p.PreForAdd( If(GlobalItemsVariable.EqualsExpr(NullValue),
                CreateThrowException("System.InvalidOperationException", "Collection was null.")));
                
            p.PreForAdd(LocalVariableCreation(sourceCount,
                GlobalItemsVariable.Access("Count").Invoke()));

            p.ForMin = p.ForReMin = 0;
            p.ForMax = p.ForReMax = sourceCount;
            
            p.LastItem = GlobalItemsVariable.ArrayAccess(GlobalIndexerVariable);
            p.Indexer = GlobalIndexerVariable;
            
            p.ResultSize = IdentifierName(sourceCount);
            p.SourceSize = IdentifierName(sourceCount);
        }

        public static void IEnumerableEnumeration(RewriteParameters p)
        {
            p.PreForAdd(If(GlobalItemsVariable.EqualsExpr(NullValue),
                CreateThrowException("System.InvalidOperationException", "Collection was null.")));

            p.IsReversed = false;
            p.LastItem = IdentifierName(GlobalItemVariable);
        }
    }
}