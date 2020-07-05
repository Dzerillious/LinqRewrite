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
        public static ExpressionSyntax SimpleRewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            if (args.Length != 0) return null;
            return ConditionalExpression(design.FirstCollection.Count.IsEqual(0),
                Default(design.ReturnType),
                Substitute(design.LastValue, design.CurrentIterator.ForIndexer, design.CurrentMin));
        }

        public static void Rewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            if (args.Length == 0)
                design.ForAdd(Return(design.LastValue));
            else
            {
                design.ForAdd(If(args[0].Inline(design, design.LastValue),
                            Return(design.LastValue)));
            }
            design.ResultAdd(Return(Default(design.ReturnType)));
        }
    }
}