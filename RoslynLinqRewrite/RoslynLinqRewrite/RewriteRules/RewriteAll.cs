using System;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using static Shaman.Roslyn.LinqRewrite.Extensions.OperatorExpressionExtensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteAll
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            if (chainIndex != p.Chain.Count - 1) throw new InvalidOperationException("All should be last expression.");
            
            var method = p.Chain[chainIndex].Arguments[0];
            p.ForAdd(If(Not(method.Inline(p, p.LastItem)),
                Return(false)));
            
            p.PostForAdd(Return(true));
            p.HasResultMethod = true;
        }
    }
}