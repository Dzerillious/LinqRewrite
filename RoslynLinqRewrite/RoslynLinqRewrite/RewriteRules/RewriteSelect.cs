using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSelect
    {
        public static void Rewrite(RewriteParameters p, ExpressionSyntax[] args)
        {
            if (p.Body == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<ExpressionSyntax>());
            var method = args[0];

            p.Last = method is SimpleLambdaExpressionSyntax
                ? method.Inline(p, p.Last)
                : method.Inline(p, p.Last, p.Indexer);
        }
    }
}