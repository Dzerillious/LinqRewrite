using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.ExpressionSimplifier;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteFirstOrDefault
    {
        public static ExpressionSyntax SimpleRewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (args.Length != 0) return null;
            return ConditionalExpression(p.FirstCollection.Count.IsEqual(0),
                Default(p.ReturnType),
                SimplifySubstitute(p.LastValue, p.CurrentIterator.ForIndexer, p.CurrentMin));
        }

        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (args.Length == 0)
                p.ForAdd(Return(p.LastValue));
            else
            {
                p.ForAdd(If(args[0].Inline(p, p.LastValue),
                            Return(p.LastValue)));
            }
            p.ResultAdd(Return(Default(p.ReturnType)));
        }
    }
}