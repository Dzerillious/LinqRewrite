using System.Linq;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.ExpressionSimplifier;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteAll
    {
        public static ExpressionSyntax SimpleRewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (!TryGetInt(p.ResultSize, out var intSize) || intSize > 10)
                return null;

            var items = Enumerable.Range(0, intSize).Select(x
                => (ExpressionSyntax) SimplifySubstitute(p.LastValue, p.CurrentIterator.ForIndexer, p.CurrentMin + x));
            return items.Aggregate((x, y) => x.And(y));
        }

        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            p.ForAdd(If(Not(args[0].Inline(p, p.LastValue)),
                        Return(false)));

            p.ResultAdd(Return(true));
        }
    }
}