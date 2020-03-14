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

            p.LastValue = args.Length switch
            {
                1 when args[0].OldVal is SimpleLambdaExpressionSyntax => args[0].Inline(p, p.LastValue),
                1 => args[0].Inline(p, p.LastValue, p.Indexer)
            };

            p.ListEnumeration = false;
        }
    }
}