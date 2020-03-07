using System.Linq;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SimpleCollections;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteRepeat
    {
        public static void Rewrite(RewriteParameters p, ExpressionSyntax[] args)
        {
            p.Variables.Where(x => !x.IsGlobal).ForEach(x => x.IsUsed = false);
            var item = args[0];
            var count = args[1];
            
            p.Iterators.Add(p.Iterator = new IteratorParameters(p));
            p.ForMin = p.ForReMin = 0;
            p.ForMax = p.ForReMax = count;
            
            p.ResultSize = count;
            p.SourceSize = count;
            p.ListEnumeration = false;
            
            p.Last = new TypedValueBridge(p.CurrentCollection.ItemType(p), item);
            p.CurrentIndexer = p.LocalVariable(Int);
            p.Iterator.Indexer = p.Indexer;
            p.CurrentCollection = null;
        }
    }
}