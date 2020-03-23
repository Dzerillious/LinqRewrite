using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteForEach
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());

            p.ForAdd(args[0].Inline(p, p.LastValue));
        }
    }
}