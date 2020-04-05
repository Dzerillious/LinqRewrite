using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteCount
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            if (p.CanSimpleRewrite() && args.Length == 0)
                p.SimpleRewrite = p.ResultSize;

            if (args.Length != 0)
            {
                p.Indexer = null;
                p.ForAdd(If(Not(args[0].Inline(p, p.LastValue)),
                        Continue()));
            }
            p.ResultAdd(Return(p.Indexer));
        }
    }
}