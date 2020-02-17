using System;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Shaman.Roslyn.LinqRewrite.Constants;
using static Shaman.Roslyn.LinqRewrite.Extensions.OperatorExpressionExtensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.VariableExtensions;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteRange
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            var sumVariable = "__sum" + chainIndex;
            if (chainIndex != 0) throw new InvalidOperationException("Enumerable.Range should be first expression.");

            var from = p.Chain[chainIndex].Arguments[0];
            var count = p.Chain[chainIndex].Arguments[1];
            
            p.PreForAdd(LocalVariableCreation(sumVariable, from.Add(count)));

            p.Collection = null;
            p.ForMin = p.ForReMin = p.Chain[chainIndex].Arguments[0];
            p.ForMax = p.ForReMax = sumVariable;
            
            p.LastItem = IdentifierName(GlobalIndexerVariable);
            
            p.ResultSize = count;
            p.SourceSize = count;
        }
    }
}