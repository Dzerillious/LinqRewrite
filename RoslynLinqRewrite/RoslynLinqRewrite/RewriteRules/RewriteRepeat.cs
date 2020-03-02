using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Constants;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteRepeat
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex != 0) throw new InvalidOperationException("Enumerable.Repeat should be first expression.");

            var item = p.Chain[chainIndex].Arguments[0];
            var count = p.Chain[chainIndex].Arguments[1];
            
            p.Collection = null;
            p.ForMin = p.ForReMin = 0;
            p.ForMax = p.ForReMax = count;
            
            p.ResultSize = count;
            p.SourceSize = count;
            
            p.Last = (item, VariableExtensions.IntType);
            p.CurrentIndexer = p.CreateLocalVariable("__i", IntType);
            p.Body.Indexer = p.Indexer;
        }
    }
}