using System.Linq;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using SimpleCollections;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteRepeat
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
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
            
            p.Iterator.Indexer = p.LocalVariable(Int);
            if (p.CurrentIndexer == null)
            {
                p.Iterator.CurrentIndexer = p.Iterator.Indexer;
                p.Iterator.CurrentIndexer.IsGlobal = true;
            }
            p.Last = new TypedValueBridge(p.CurrentCollection.ItemType(p), item);
            
            p.CurrentCollection = null;
        }
    }
}