using LinqRewrite.DataStructures;
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
                p.ForMax += take;
                p.ForReMin -= take;
                p.ResultSize = take;
            }
            else p.ForAdd(If(p.Indexer > take, Break()));
            p.CurrentIndexer = null;
        }
    }
}