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
            if (p.Iterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<ExpressionSyntax>());
            
            var take = args[0];
            if (p.ModifiedEnumeration)
            {
                p.ForMax += take;
                p.ForReMin -= take;
                p.ResultSize = take;
            }
            else p.ForAdd(If(p.Indexer > take, Break()));
            p.CurrentIndexer = null;
            p.ListEnumeration = false;
        }
    }
}