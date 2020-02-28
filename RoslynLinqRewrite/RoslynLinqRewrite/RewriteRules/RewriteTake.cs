using LinqRewrite.DataStructures;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteTake
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            
            var take = p.Chain[chainIndex].Arguments[0];
            if (p.ListsEnumeration)
            {
                p.ForMax = p.ForMin.Add(take);
                p.ForReMin = p.ForReMax.Sub(take);
            }
            else p.ForAdd(If(p.Indexer.GeThan(take), Break()));
            p.Indexer = null;
        }
    }
}