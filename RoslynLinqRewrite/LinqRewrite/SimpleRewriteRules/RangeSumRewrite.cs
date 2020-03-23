using LinqRewrite.DataStructures;

namespace LinqRewrite.SimpleRewriteRules
{
    public static class RangeSumRewrite
    {
        public static bool Rewrite(RewriteParameters p)
        {
            var rangeArgs = p.RewriteChain[0].Arguments;
            p.SimpleRewrite = (rangeArgs[0] + rangeArgs[0] + rangeArgs[1] - 1) * rangeArgs[1] / 2;
            return true;
        }
    }
}