using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSelect
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            var method = args[0];

            p.LastValue = method.OldVal is SimpleLambdaExpressionSyntax
                ? method.Inline(p, p.LastValue)
                : method.Inline(p, p.LastValue, p.Indexer);

            p.ListEnumeration = false;
        }
    }
}