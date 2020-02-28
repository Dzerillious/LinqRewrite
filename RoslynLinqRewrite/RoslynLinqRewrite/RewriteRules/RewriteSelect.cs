﻿using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSelect
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            var method = p.Chain[chainIndex].Arguments[0];

            p.LastItem = method is SimpleLambdaExpressionSyntax 
                ? method.Inline(p, p.LastItem) 
                : method.Inline(p, p.LastItem, p.Indexer);
        }
    }
}