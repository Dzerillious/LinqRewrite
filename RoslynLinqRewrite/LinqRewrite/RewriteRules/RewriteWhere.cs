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
            p.LastValue = p.LastValue.Reusable(p);
            var conditionValue = args.Length switch
            {
                1 when args[0].OldVal.InvokableWith1Param(p) => args[0].Inline(p, p.LastValue),
                1 => args[0].Inline(p, p.LastValue, p.Indexer)
            };
            p.ForAdd(If(Not(conditionValue), Continue()));
            p.ListEnumeration = false;
            p.ModifiedEnumeration = true;
        }
    }
}