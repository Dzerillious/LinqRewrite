using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteAll
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            p.ForAdd(If(Not(args[0].Inline(p, p.LastValue)),
                        Return(false)));

            p.ResultAdd(Return(true));
        }
    }
}