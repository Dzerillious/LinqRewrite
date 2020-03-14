using System;
using LinqRewrite.DataStructures;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteTake
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            
            var takeValue = args[0];
            if (!p.ModifiedEnumeration)
            {
                p.ForMax += takeValue;
                p.ForReMin -= takeValue;
                p.ResultSize = takeValue;
            }
            else p.ForAdd(If(p.Indexer > takeValue, Break()));
            p.Indexer = null;
        }
    }
}