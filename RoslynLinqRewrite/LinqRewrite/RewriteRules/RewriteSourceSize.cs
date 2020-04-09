using LinqRewrite.DataStructures;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSourceSize
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            p.SourceSize = args[0];
        }
    }
}