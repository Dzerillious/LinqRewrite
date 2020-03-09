using System.Linq;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using SimpleCollections;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteRange
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            p.Variables.Where(x => !x.IsGlobal).ForEach(x => x.IsUsed = false);
            var from = args[0];
            var count = args[1];
            
            var sumVariable = p.LocalVariable(Int, from.Add(count));

            p.CurrentCollection = null;
            p.Iterators.Add(p.Iterator = new IteratorParameters(p));
            p.ForMin = p.ForReMin = from;
            p.ForMax = p.ForReMax = sumVariable;
            p.ListEnumeration = false;
            
            p.Iterator.Indexer = p.LocalVariable(Int);
            if (p.CurrentIndexer == null)
            {
                p.Iterator.CurrentIndexer = p.Iterator.Indexer;
                p.Iterator.CurrentIndexer.IsGlobal = true;
            }
            p.Last = p.Indexer;
                        
            p.ResultSize = count;
            p.SourceSize = count;
        }
    }
}