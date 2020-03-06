using System;
using LinqRewrite.DataStructures;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteTake
    {
        public static void Rewrite(RewriteParameters p, ExpressionSyntax[] args)
        {
            if (p.Body == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<ExpressionSyntax>());
            
            var take = args[0];
            if (p.ListsEnumeration)
            {
                p.ForMax += take;
                p.ForReMin -= take;
                p.ResultSize = take;
            }
            else p.ForAdd(If(p.Indexer > take, Break()));
            p.CurrentIndexer = null;
        }
    }
}