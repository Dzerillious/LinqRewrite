using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteFirst
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            
            if (p.CanSimpleRewrite() && p.SimpleEnumeration && p.FirstCollection != null && args.Length == 0)
                p.SimpleRewrite = ExpressionSimplifier.SimplifySubstitute(p.LastValue, p.CurrentIterator.ForIndexer, p.CurrentMin);
            
            if (!p.AssertResultSizeGreaterEqual(0, true)) return;
            
            if (args.Length == 0)
                p.ForAdd(Return(p.LastValue));
            else
            {
                p.ForAdd(If(args[0].Inline(p, p.LastValue),
                            Return(p.LastValue)));
            }
            
            if (!p.Unchecked) p.ResultAdd(Throw("System.InvalidOperationException", "The sequence did not contain any elements."));
        }
    }
}