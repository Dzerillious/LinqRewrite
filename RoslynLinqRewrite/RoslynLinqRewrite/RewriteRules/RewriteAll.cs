using System;
using LinqRewrite.DataStructures;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteAll
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            if (chainIndex != p.Chain.Count - 1) throw new InvalidOperationException("All should be last expression.");
            
            var method = p.Chain[chainIndex].Arguments[0];
            p.ForAdd(If(!method.Inline(p, p.Last),
                        Return(false)));

            p.FinalAdd(Return(true));
            p.HasResultMethod = true;
        }
    }
}