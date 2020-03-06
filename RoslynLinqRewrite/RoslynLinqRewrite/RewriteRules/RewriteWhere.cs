using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteWhere
    {
        public static void Rewrite(RewriteParameters p, ExpressionSyntax[] args)
        {
            if (p.Body == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<ExpressionSyntax>());

            var method = args[0];

            p.Last = p.Last.Reusable(p);
            if (method is SimpleLambdaExpressionSyntax)
                p.ForAdd(If(!method.Inline(p, p.Last),
                            Continue()));
            else p.ForAdd(If(!method.Inline(p, p.Last, p.Indexer),
                            Continue()));

            p.ModifiedEnumeration = true;
        }
    }
}