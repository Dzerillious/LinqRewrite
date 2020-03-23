using LinqRewrite.DataStructures;

namespace LinqRewrite.SimpleRewriteRules
{
    public static class RangeAverageRewrite
    {
        public static bool Rewrite(RewriteParameters p)
        {
            var rangeArgs = p.RewriteChain[0].Arguments;
            p.SimpleRewrite = (rangeArgs[0] + rangeArgs[0] + rangeArgs[1] - 1) / 2;
            return true;
        }
    }
}