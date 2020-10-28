using System.Collections.Immutable;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.ExpressionSimplifier;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteElementAtOrDefault
    {
        public static ExpressionSyntax SimpleRewrite(RewriteDesign design, ImmutableArray<ValueBridge> args)
            => ConditionalExpression(design.ResultSize > args[0],
                Substitute(design.LastValue, design.CurrentIterator.ForIndexer, design.CurrentMin + args[0]),
                Default(design.Info.ReturnType));
        
        public static void Rewrite(RewriteDesign design, ImmutableArray<ValueBridge> args)
        {
            var positionValue = args[0].ReusableConst(design);
            design.ForAdd(If(design.Indexer.IsEqual(positionValue),
                            Return(design.LastValue)));
            
            design.ResultAdd(Return(Default(design.Info.ReturnType)));
        }
    }
}