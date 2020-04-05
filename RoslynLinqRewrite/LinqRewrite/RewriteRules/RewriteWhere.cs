using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteWhere
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());

            p.LastValue = p.LastValue.Reusable(p);
            var conditionValue = args.Length switch
            {
                1 when args[0].OldVal.InvokableWith1Param(p) => args[0].Inline(p, p.LastValue),
                1 => args[0].Inline(p, p.LastValue, p.Indexer)
            };
            
            p.ForAdd(If(Not(conditionValue), Continue()));
            p.ModifiedEnumeration = true;
        }
    }
}