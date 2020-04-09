using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteAny
    {
        public static ExpressionSyntax SimpleRewrite(RewriteParameters p, RewrittenValueBridge[] args)
            => p.ResultSize > 0;
        
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (args.Length == 0)
                p.ForAdd(Return(true));
            else 
            {
                p.ForAdd(If(args[0].Inline(p, p.LastValue),
                            Return(true)));
            }
            
            p.ResultAdd(Return(false));
        }
    }
}