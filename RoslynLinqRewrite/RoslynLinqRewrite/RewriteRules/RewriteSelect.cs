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
            if (p.Iterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            var method = args[0];

            p.Last = method.OldVal is SimpleLambdaExpressionSyntax
                ? method.Inline(p, p.Last)
                : method.Inline(p, p.Last, p.Indexer);

            p.ListEnumeration = false;
        }
    }
}