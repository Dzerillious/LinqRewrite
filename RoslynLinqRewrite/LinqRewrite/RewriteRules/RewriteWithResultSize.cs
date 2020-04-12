using LinqRewrite.DataStructures;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteResultSize
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            p.ResultSize = args[0];
        }
    }
}