using System;
using LinqRewrite.DataStructures;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSkip
    {
        public static void Rewrite(RewriteParameters p, ExpressionSyntax[] args)
        {
            if (p.Body == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<ExpressionSyntax>());
            
            var skipped = args[0];
            if (p.ListsEnumeration)
            {
                p.ForMin += skipped;
                p.ForReMax -= skipped;
                p.ResultSize -= skipped;
            }
            else
            {
                p.ForAdd(If(p.Indexer < skipped, Continue()));
                p.ModifiedEnumeration = true;
            }
            p.CurrentIndexer = null;
        }
    }
}