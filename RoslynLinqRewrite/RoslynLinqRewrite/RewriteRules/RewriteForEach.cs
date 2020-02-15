using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteForEach
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == p.Chain.Count - 1) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            var lambda = (SimpleLambdaExpressionSyntax)p.Chain[chainIndex].Arguments[0];
            
            p.ForAdd(p.Code.Inline(p.Semantic, lambda, p.LastItem));
        }
    }
}