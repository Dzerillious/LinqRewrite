using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSelect
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            p.LastValue = args.Length switch
            {
                1 when args[0].OldVal.Invokable1Param(p) => args[0].Inline(p, p.LastValue),
                1 => args[0].Inline(p, p.LastValue, p.Indexer),
                _ => p.LastValue
            };
            p.ListEnumeration = false;
        }
    }
}