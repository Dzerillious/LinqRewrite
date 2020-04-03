using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;

namespace LinqRewrite.SimpleRewriteRules
{
    public static class SelectFirstRewrite
    {
        public static bool Rewrite(RewriteParameters p)
        {
            var selectArgs = p.RewriteChain[0].Arguments;
            var firstArgs = p.RewriteChain[1].Arguments;
            if (firstArgs == null || firstArgs.Length == 0)
            {
                p.SimpleRewrite = selectArgs[0].Inline(p, p.CurrentCollection[0]);
                return true;
            }
            else return false;
        }
    }
}