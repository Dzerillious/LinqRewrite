using System.Collections.Immutable;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.AssertionExtension;
using static LinqRewrite.Extensions.ExpressionSimplifier;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteElementAt
    {
        public static ExpressionSyntax SimpleRewrite(RewriteDesign design, ImmutableArray<ValueBridge> args)
            => Substitute(design.LastValue, design.CurrentIterator.ForIndexer, design.CurrentMin + args[0]);
        
        public static void Rewrite(RewriteDesign design, ImmutableArray<ValueBridge> args)
        {
            if (!AssertGreaterEqual(design, args[0], 0, true, true)) return;
            if (!AssertLesser(design, args[0], design.ResultSize, true, true)) return;
            
            var positionValue = args[0].ReusableConst(design);
            design.ForAdd(If(design.Indexer.IsEqual(positionValue),
                            Return(design.LastValue)));
            
            if (!design.Unchecked) design.ResultAdd(Throw("System.InvalidOperationException", "The sequence did not contain enough elements."));
        }
    }
}