using Shaman.Roslyn.LinqRewrite.DataStructures;
using static Shaman.Roslyn.LinqRewrite.Extensions.OperatorExpressionExtensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteWhere
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);

            var lambda = p.Chain[chainIndex].Arguments[0];

            p.LastItem = p.LastItem.Reusable(p);
            p.ForAdd(If(Not(lambda.InlineForLast(p)),
                Continue()));

            p.ResultSize = null;
            p.DifferentEnumeration = true;
        }
    }
}