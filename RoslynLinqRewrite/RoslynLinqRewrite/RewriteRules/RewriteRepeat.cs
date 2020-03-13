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
            
            p.Iterators.Add(p.CurrentIterator = new IteratorParameters(p));
            p.ForMin = p.ForReMin = 0;
            p.ForMax = count;
            p.ForReMax = count - 1;
            
            p.ResultSize = count;
            p.SourceSize = count;
            p.ListEnumeration = false;
            
            p.CurrentIterator.ForIndexer = p.LocalVariable(Int);
            if (p.CurrentIndexer == null)
            {
                p.CurrentIterator.CurrentIndexer = p.CurrentIterator.ForIndexer;
                p.CurrentIterator.CurrentIndexer.IsGlobal = true;
            }
            p.LastValue = new TypedValueBridge(p.CurrentCollection.ItemType(p), item);
            
            p.CurrentCollection = null;
        }
    }
}