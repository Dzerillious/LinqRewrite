using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSkipWhile
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            p.LastValue = p.LastValue.Reusable(p);
            var conditionValue = args.Length switch
            {
                1 when args[0].OldVal.InvokableWith1Param(p) => args[0].Inline(p, p.LastValue),
                1 => args[0].Inline(p, p.LastValue, p.Indexer)
            };

            var skippingVariable = p.LocalVariable(Bool, true);
            p.ForAdd(If(skippingVariable.And(conditionValue), Continue()));
            p.ForAdd(skippingVariable.Assign(false));
            p.ListEnumeration = false;
            p.ModifiedEnumeration = true;
        }
    }
}