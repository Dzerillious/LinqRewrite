using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteElementAt
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            if (p.ResultSize != null && args.Length == 0) p.SimpleRewrite = p.CurrentCollection[args[0]];
            
            var positionValue = args[0].ReusableConst(p);
            p.ForAdd(If(p.Indexer.IsEqual(positionValue),
                        Return(p.LastValue)));
            
            p.FinalAdd(CreateThrowException("System.InvalidOperationException", "The sequence did not enough elements."));
        }
    }
}