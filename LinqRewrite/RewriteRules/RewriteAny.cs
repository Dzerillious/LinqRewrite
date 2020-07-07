using System.Linq;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.ExpressionSimplifier;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteAny
    {
        public static ExpressionSyntax SimpleRewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            if (args.Length == 0) return design.ResultSize > 0;
            if (!TryGetInt(design.ResultSize, out var intSize) || intSize > Constants.SimpleRewriteMaxMediumElements)
                return null;

            var items = Enumerable.Range(0, intSize)
                .Select(i => (ExpressionSyntax) Substitute(design.LastValue, design.CurrentIterator.ForIndexer, design.CurrentMin + i));
            return items.Aggregate((x, y) => x.Or(y));
        }
        
        public static void Rewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            if (args.Length == 0)
                design.ForAdd(Return(true));
            else 
            {
                design.ForAdd(If(args[0].Inline(design, design.LastValue),
                            Return(true)));
            }
            
            design.ResultAdd(Return(false));
        }
    }
}