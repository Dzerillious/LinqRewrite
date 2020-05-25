using LinqRewrite.DataStructures;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteCount
    {
        public static ExpressionSyntax SimpleRewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            if (args.Length != 0) return null;
            return design.ResultSize;
        }

        public static void Rewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            if (args.Length != 0)
            {
                design.Indexer = null;
                design.ForAdd(If(Not(args[0].Inline(design, design.LastValue)),
                                Continue()));
            }
            design.ResultAdd(Return(design.Indexer));
        }
    }
}