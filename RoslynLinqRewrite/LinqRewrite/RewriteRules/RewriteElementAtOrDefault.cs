using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteElementAtOrDefault
    {
        public static ExpressionSyntax SimpleRewrite(RewriteParameters p, RewrittenValueBridge[] args)
            => ConditionalExpression(p.ResultSize <= args[0],
                ExpressionSimplifier.SimplifySubstitute(p.LastValue, p.CurrentIterator.ForIndexer, p.CurrentMin + args[0]),
                Default(p.ReturnType));
        
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            var positionValue = args[0].ReusableConst(p);
            p.ForAdd(If(p.Indexer.IsEqual(positionValue),
                        Return(p.LastValue)));
            
            p.ResultAdd(Return(Default(p.ReturnType)));
        }
    }
}