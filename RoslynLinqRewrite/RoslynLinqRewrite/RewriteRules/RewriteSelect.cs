using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSelect
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            var method = p.Chain[chainIndex].Arguments[0];

            p.Last = method is SimpleLambdaExpressionSyntax
                ? method.Inline(p, p.Last.Value)
                : method.Inline(p, p.Last.Value, p.Indexer);
        }
    }
}