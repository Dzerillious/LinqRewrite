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
        public static ExpressionSyntax SimpleRewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (args.Length == 0) return p.ResultSize > 0;
            if (!TryGetInt(p.ResultSize, out var intSize) || intSize > 10)
                return null;

            var items = Enumerable.Range(0, intSize).Select(x
                => (ExpressionSyntax) SimplifySubstitute(p.LastValue, p.CurrentIterator.ForIndexer, p.CurrentMin + x));
            return items.Aggregate((x, y) => x.Or(y));
        }
        
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (args.Length == 0)
                p.ForAdd(Return(true));
            else 
            {
                p.ForAdd(If(args[0].Inline(p, p.LastValue),
                            Return(true)));
            }
            
            p.ResultAdd(Return(false));
        }
    }
}