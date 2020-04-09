using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteLongCount
    {
        public static ExpressionSyntax SimpleRewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (args.Length != 0) return null;
            return p.ResultSize.Cast(Long);
        }

        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (args.Length != 0)
            {
                p.Indexer = null;
                p.ForAdd(If(Not(args[0].Inline(p, p.LastValue)),
                            Continue()));
            }
            p.ResultAdd(Return(p.GetIndexer(Long)));
        }
    }
}