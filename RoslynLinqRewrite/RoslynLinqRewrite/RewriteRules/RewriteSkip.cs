using Shaman.Roslyn.LinqRewrite.DataStructures;
using static Shaman.Roslyn.LinqRewrite.Extensions.OperatorExpressionExtensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Shaman.Roslyn.LinqRewrite.Extensions.VariableExtensions;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteSkip
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            
            var skipped = p.Chain[chainIndex].Arguments[0];
            if (!p.ModifiedEnumeration)
            {
                p.ForMin = p.ForMin.Add(skipped);
                p.ForReMax = p.ForReMin.Sub(skipped);
            }
            else
            {
                p.ForAdd(If(p.Indexer.LThan(skipped), Continue()));
                p.ModifiedEnumeration = true;
            }
        }
    }
}