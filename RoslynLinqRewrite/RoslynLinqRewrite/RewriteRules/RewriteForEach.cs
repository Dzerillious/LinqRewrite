using Shaman.Roslyn.LinqRewrite.DataStructures;
using Shaman.Roslyn.LinqRewrite.Extensions;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteForEach
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            var method = p.Chain[chainIndex].Arguments[0];
            
            p.ForAdd(method.InlineForLast(p));
            p.HasResultMethod = true;
        }
    }
}