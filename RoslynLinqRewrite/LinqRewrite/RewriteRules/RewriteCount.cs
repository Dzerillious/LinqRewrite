using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteCount
    {
        public static ExpressionSyntax SimpleRewrite(RewriteParameters p, RewrittenValueBridge[] args)
            => p.ResultSize;
        
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (args.Length != 0)
            {
                p.Indexer = null;
                p.ForAdd(If(Not(args[0].Inline(p, p.LastValue)),
                        Continue()));
            }
            p.ResultAdd(Return(p.Indexer));
        }
    }
}