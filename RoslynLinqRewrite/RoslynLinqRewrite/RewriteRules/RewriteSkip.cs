using System;
using LinqRewrite.DataStructures;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSkip
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            
            var skipped = args[0];
            if (!p.ModifiedEnumeration)
            {
                p.ForMin = p.ForReMin += skipped;
                p.ResultSize -= skipped;
            }
            else p.ForAdd(If(p.Indexer < skipped, Continue()));
            p.Indexer = null;
        }
    }
}