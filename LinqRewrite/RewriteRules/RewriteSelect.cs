using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSelect
    {
        public static void Rewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            design.LastValue = args.Length switch
            {
                1 when args[0].OldVal.Invokable1Param(design) => args[0].Inline(design, design.LastValue),
                1 => args[0].Inline(design, design.LastValue, design.Indexer),
                _ => design.LastValue
            };
            design.ListEnumeration = false;
        }
    }
}