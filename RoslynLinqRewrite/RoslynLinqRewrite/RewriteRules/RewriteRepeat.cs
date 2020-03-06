using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteRepeat
    {
        public static void Rewrite(RewriteParameters p, ExpressionSyntax[] args)
        {
            var item = args[0];
            var count = args[1];
            
            p.Collection = null;
            p.ForMin = p.ForReMin = 0;
            p.ForMax = p.ForReMax = count;
            
            p.ResultSize = count;
            p.SourceSize = count;
            
            p.Last = new TypedValueBridge(p.Collection.ItemType(p), item);
            p.CurrentIndexer = p.LocalVariable(Int, "__i");
            p.Body.Indexer = p.Indexer;
        }
    }
}