using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteRange
    {
        public static void Rewrite(RewriteParameters p, ExpressionSyntax[] args)
        {
            var from = args[0];
            var count = args[1];
            
            var sumVariable = p.LocalVariable(Int, "__sum", from.Add(count));

            p.Collection = null;
            p.ForMin = p.ForReMin = from;
            p.ForMax = p.ForReMax = sumVariable;
            
            p.CurrentIndexer = p.LocalVariable(Int, "__i");
            p.Body.Indexer = p.Indexer;
            p.Last = p.Indexer;
            
            p.ResultSize = count;
            p.SourceSize = count;
        }
    }
}