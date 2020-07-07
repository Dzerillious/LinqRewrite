using System.Linq;
using LinqRewrite.DataStructures;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.ExpressionSimplifier;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteAll
    {
        public static ExpressionSyntax SimpleRewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            if (!TryGetInt(design.ResultSize, out var intSize) || intSize > Constants.SimpleRewriteMaxMediumElements)
                return null;

            var items = Enumerable.Range(0, intSize)
                .Select(i=> (ExpressionSyntax) Substitute(design.LastValue, design.CurrentIterator.ForIndexer, design.CurrentMin + i));
            return items.Aggregate((x, y) => x.And(y));
        }

        public static void Rewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            design.ForAdd(If(Not(args[0].Inline(design, design.LastValue)),
                        Return(false)));

            design.ResultAdd(Return(true));
        }
    }
}