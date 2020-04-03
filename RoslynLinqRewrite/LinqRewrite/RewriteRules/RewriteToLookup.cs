using LinqRewrite.DataStructures;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteToLookup
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            p.NotRewrite = true;
        }
    }
}