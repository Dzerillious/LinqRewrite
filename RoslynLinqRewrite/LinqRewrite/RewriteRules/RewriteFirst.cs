using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.ExpressionSimplifier;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteFirst
    {
        public static ExpressionSyntax SimpleRewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (args.Length != 0) return null;
            return SimplifySubstitute(p.LastValue, p.CurrentIterator.ForIndexer, p.CurrentMin);
        }

        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (!p.AssertResultSizeGreaterEqual(0, true)) return;
            
            if (args.Length == 0)
                p.ForAdd(Return(p.LastValue));
            else
            {
                p.ForAdd(If(args[0].Inline(p, p.LastValue),
                            Return(p.LastValue)));
            }
            
            if (!p.Unchecked) p.ResultAdd(Throw("System.InvalidOperationException", "The sequence did not contain any elements."));
        }
    }
}