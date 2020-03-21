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
            
            var skippedValue = args[0];
            if (!p.ModifiedEnumeration)
            {
                p.ForMin = p.ForReMin += skippedValue;
                p.ResultSize -= skippedValue;
            }
            else p.ForAdd(If(p.Indexer < skippedValue, Continue()));
            p.Indexer = null;
        }
    }
}