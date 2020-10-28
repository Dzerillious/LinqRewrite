using System.Collections.Immutable;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSkipWhile
    {
        public static void Rewrite(RewriteDesign design, ImmutableArray<ValueBridge> args)
        {
            design.LastValue = design.LastValue.Reusable(design);
            var conditionValue = args.Length switch
            {
                1 when args[0].Value.Invokable1Param(design) => args[0].Inline(design, design.LastValue),
                1 => args[0].Inline(design, design.LastValue, design.Indexer)
            };

            var skippingVariable = CreateLocalVariable(design, Bool, true);
            design.ForAdd(If(skippingVariable.And(conditionValue), Continue()));
            design.ForAdd(skippingVariable.Assign(false));
            design.ListEnumeration = false;
            design.ModifiedEnumeration = true;
        }
    }
}