using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteCount
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.Iterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            if (p.ResultSize != null && args.Length == 0) p.SimpleRewrite = p.CurrentCollection.Count;

            if (args.Length != 0)
            {
                p.ForAdd(If(!args[0].Inline(p, p.Last),
                        Continue()));
            }
            p.FinalAdd(Return(p.Indexer));
            p.HasResultMethod = true;
        }
    }
}