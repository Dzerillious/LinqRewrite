using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteContains
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            var element = p.Node.ArgumentList.Arguments.First().Expression;

            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            if (chainIndex != p.Chain.Count - 1) throw new InvalidOperationException("Any should be last expression.");
            
            if (p.Chain[chainIndex].Arguments.Length == 1)
                p.ForAdd(If(p.LastItem.EqualsExpr(element),
                            Return(true)));
            
            else
            {
                var comparer = p.Chain[chainIndex].Arguments[1].Reusable(p);
                p.ForAdd(If(comparer.Access("Equals").Invoke(p.LastItem, element),
                            Return(true)));
            }
            
            p.FinalAdd(Return(false));
            p.HasResultMethod = true;
        }
    }
}