using LinqRewrite.DataStructures;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteTakeWhile
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            
            var method = p.Chain[chainIndex].Arguments[0];
            p.Last = p.Last.Reusable(p);
            
            p.ForAdd(If(!method.Inline(p, p.Last),
                        Break()));

            p.ResultSize = null;
            p.CurrentIndexer = null;
        }
    }
}