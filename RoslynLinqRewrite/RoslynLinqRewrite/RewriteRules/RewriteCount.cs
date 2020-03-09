using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteCount
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.Iterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());

            if (args.Length != 0)
            {
                p.ForAdd(If(!args[0].Inline(p, p.Last),
                        Continue()));
            }
            p.FinalAdd(Return(p.Indexer + 1));
            p.HasResultMethod = true;
        }

        public static ExpressionSyntax RewriteSimple(RewriteParameters p, RewrittenValueBridge[] args) 
            => args.Length == 0 ? p.CurrentCollection.Count : null;
    }
}