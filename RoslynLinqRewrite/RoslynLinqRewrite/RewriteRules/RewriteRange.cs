using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static LinqRewrite.Constants;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteRange
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex != 0) throw new InvalidOperationException("Enumerable.Range should be first expression.");

            var from = p.Chain[chainIndex].Arguments[0];
            var count = p.Chain[chainIndex].Arguments[1];
            
            var sumVariable = p.CreateLocalVariable("__sum", IntType, from.Add(count));

            p.Collection = null;
            p.ForMin = p.ForReMin = p.Chain[chainIndex].Arguments[0];
            p.ForMax = p.ForReMax = sumVariable;
            
            p.CurrentIndexer = p.CreateLocalVariable("__i", IntType);
            p.Body.Indexer = p.Indexer;
            p.Last = (p.Indexer, IntType);
            
            p.ResultSize = count;
            p.SourceSize = count;
        }
    }
}