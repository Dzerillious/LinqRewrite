using LinqRewrite.DataStructures;

namespace LinqRewrite.SimpleRewriteRules
{
    public static class RepeatSumRewrite
    {
        public static bool Rewrite(RewriteParameters p)
        {
            var repeatArgs = p.RewriteChain[0].Arguments;
            p.SimpleRewrite = repeatArgs[0] * repeatArgs[1];
            return true;
        }
    }
}