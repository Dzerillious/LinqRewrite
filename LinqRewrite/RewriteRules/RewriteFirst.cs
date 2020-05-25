using LinqRewrite.DataStructures;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.AssertionExtension;
using static LinqRewrite.Extensions.ExpressionSimplifier;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteFirst
    {
        public static ExpressionSyntax SimpleRewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            if (args.Length != 0) return null;
            return SimplifySubstitute(design.LastValue, design.CurrentIterator.ForIndexer, design.CurrentMin);
        }

        public static void Rewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            if (!AssertResultSizeGreaterEqual(design, 0, true)) return;
            
            if (args.Length == 0)
                design.ForAdd(Return(design.LastValue));
            else
            {
                design.ForAdd(If(args[0].Inline(design, design.LastValue),
                            Return(design.LastValue)));
            }
            
            if (!design.Unchecked) design.ResultAdd(Throw("System.InvalidOperationException", "The sequence did not contain any elements."));
        }
    }
}