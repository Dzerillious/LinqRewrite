using Shaman.Roslyn.LinqRewrite.DataStructures;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteAny
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            
            if (p.Chain[chainIndex].Arguments.Length == 0)
                p.ForAdd(Return(true));
            
            else
            {
                var method = p.Chain[chainIndex].Arguments[0];
                p.ForAdd(If(p.Code.InlineLambda(p.Semantic, method, p.LastItem),
                            Return(true)));
            }
            
            p.PostForAdd(Return(false));
        }
    }
}