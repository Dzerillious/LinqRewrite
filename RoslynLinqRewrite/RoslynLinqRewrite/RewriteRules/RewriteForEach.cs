using Shaman.Roslyn.LinqRewrite.DataStructures;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteForEach
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            var method = p.Chain[chainIndex].Arguments[0];
            
            p.ForAdd(p.Code.InlineLambda(p.Semantic, method, p.LastItem));
        }
    }
}