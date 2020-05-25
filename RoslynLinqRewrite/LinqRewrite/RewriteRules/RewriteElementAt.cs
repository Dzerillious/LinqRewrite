using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.ExpressionSimplifier;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteElementAt
    {
        public static ExpressionSyntax SimpleRewrite(RewriteParameters p, RewrittenValueBridge[] args)
            => SimplifySubstitute(p.LastValue, p.CurrentIterator.ForIndexer, p.CurrentMin + args[0]);
        
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (!AssertionExtension.AssertGreaterEqual(p, args[0], 0, true, true)) return;
            if (!AssertionExtension.AssertLesser(p, args[0], p.ResultSize, true, true)) return;
            
            var positionValue = args[0].ReusableConst(p);
            p.ForAdd(If(p.Indexer.IsEqual(positionValue),
                        Return(p.LastValue)));
            
            if (!p.Unchecked) p.ResultAdd(Throw("System.InvalidOperationException", "The sequence did not contain enough elements."));
        }
    }
}