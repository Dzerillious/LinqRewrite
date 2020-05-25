using LinqRewrite.DataStructures;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteTakeWhile
    {
        public static void Rewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            design.LastValue = design.LastValue.Reusable(design);
            var value = args.Length switch
            {
                1 when args[0].OldVal is SimpleLambdaExpressionSyntax => args[0].Inline(design, design.LastValue),
                1 => args[0].Inline(design, design.LastValue, design.Indexer)
            };
            if (design.Iterators.All.Count > 1)
            {
                var lastTakeWhile = CreateGlobalVariable(design, Bool, false);
                design.ForAdd(If(Not(value).Or(lastTakeWhile), Block(
                    lastTakeWhile.Assign(true),
                    Break()))
                );
            }
            else design.ForAdd(If(Not(value), Break()));
            design.ListEnumeration = false;
            design.ModifiedEnumeration = true;
        }
    }
}