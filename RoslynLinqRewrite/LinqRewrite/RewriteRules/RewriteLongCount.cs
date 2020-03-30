using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteLongCount
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            if (p.CanSimpleRewrite() && args.Length == 0)
            {
                p.SimpleRewrite = p.ResultSize.Cast(Long);
                return;
            }

            if (args.Length != 0)
            {
                p.ForAdd(If(Not(args[0].Inline(p, p.LastValue)),
                            Continue()));
            }
            p.FinalAdd(Return(p.GetIndexer(Long)));
        }
    }
}