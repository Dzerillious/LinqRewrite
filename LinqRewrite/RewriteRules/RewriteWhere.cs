using LinqRewrite.DataStructures;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteWhere
    {
        public static void Rewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            design.LastValue = design.LastValue.Reusable(design);
            var conditionValue = args.Length switch
            {
                1 when args[0].OldVal.Invokable1Param(design) => args[0].Inline(design, design.LastValue),
                1 => args[0].Inline(design, design.LastValue, design.Indexer)
            };
            design.ForAdd(If(Not(conditionValue), Continue()));
            design.ListEnumeration = false;
            design.ModifiedEnumeration = true;
        }
    }
}