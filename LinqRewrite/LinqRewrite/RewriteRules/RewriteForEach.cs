using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteForEach
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            var inlined = args.Length switch
            {
                1 when args[0].OldVal.Invokable1Param(p) => args[0].Inline(p, p.LastValue),
                1 => args[0].Inline(p, p.LastValue, p.Indexer),
                _ => p.LastValue
            };
            p.ForAdd(GetExpression(inlined));
        }

        private static ExpressionSyntax GetExpression(ExpressionSyntax expression)
        {
            while (true)
            {
                if (!(expression is ParenthesizedExpressionSyntax parenthesizedExpressionSyntax)) 
                    return expression;
                expression = parenthesizedExpressionSyntax.Expression;
            }
        }
    }
}