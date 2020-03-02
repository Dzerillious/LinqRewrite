using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteForEach
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            var method = p.Chain[chainIndex].Arguments[0];
            
            p.ForAdd(method.Inline(p, p.Last.Value));
            p.HasResultMethod = true;
        }
    }
}