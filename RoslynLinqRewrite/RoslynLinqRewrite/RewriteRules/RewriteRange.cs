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
            
            var sumVariable = p.LocalVariable(Int, from.Add(count));

            p.CurrentCollection = null;
            p.Enumerations.Add(p.Iterator = new IteratorParameters(p));
            p.ForMin = p.ForReMin = from;
            p.ForMax = p.ForReMax = sumVariable;
            p.ListEnumeration = false;
            
            p.CurrentIndexer = p.LocalVariable(Int);
            p.Iterator.Indexer = p.Indexer;
            p.Last = p.Indexer;
            
            p.ResultSize = count;
            p.SourceSize = count;
        }
    }
}