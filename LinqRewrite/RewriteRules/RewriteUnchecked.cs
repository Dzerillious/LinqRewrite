using LinqRewrite.DataStructures;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteUnchecked
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            p.Unchecked = true;
        }
    }
}