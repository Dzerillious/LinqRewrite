using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteForEach
    {
        public static void Rewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            var inlined = args.Length switch
            {
                1 when args[0].OldVal.Invokable1Param(design) => args[0].Inline(design, design.LastValue),
                1 => args[0].Inline(design, design.LastValue, design.Indexer),
                _ => design.LastValue
            };
            design.ForAdd(GetExpression(inlined));
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