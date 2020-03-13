using System.Linq;
using LinqRewrite.DataStructures;
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

            p.CurrentCollection = null;
            p.Iterators.Add(p.CurrentIterator = new IteratorParameters(p));
            p.ForMin = p.ForReMin = from;
            p.ForMax = from + count;
            p.ForReMax = from + count - 1;
            
            p.ListEnumeration = false;
            p.CurrentIterator.ForIndexer = p.LocalVariable(Int);
            if (p.CurrentIndexer == null)
            {
                p.CurrentIterator.CurrentIndexer = p.CurrentIterator.ForIndexer;
                p.CurrentIterator.CurrentIndexer.IsGlobal = true;
            }
            p.LastValue = p.Indexer;
                        
            p.ResultSize = count;
            p.SourceSize = count;
        }
    }
}