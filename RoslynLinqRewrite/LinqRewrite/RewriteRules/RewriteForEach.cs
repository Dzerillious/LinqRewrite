using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteForEach
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());

            var inlined = args[0].Inline(p, p.LastValue);
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