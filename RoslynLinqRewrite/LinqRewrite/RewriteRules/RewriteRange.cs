using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.DataStructures;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteRange
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            p.Variables.Where(x => !x.IsGlobal).ForEach(x => x.IsUsed = false);
            var fromValue = args[0];
            var countValue = args[1];
            var increment = args.Length == 3 ? args[2].New : 1;
            if (!p.AssertGreaterEqual(countValue, 0)) return;

            p.FirstCollection = p.CurrentCollection = null;
            p.AddIterator();
            p.ForMin = p.ForReMin = 0;
            p.ForMax = countValue * increment;
            p.ForReMax = countValue * increment - 1;
            p.ForIncrement = increment;
            
            p.ListEnumeration = false;
            p.SimpleEnumeration = true;
            
            p.CurrentIterator.ForIndexer = p.LocalVariable(Int);
            if (p.CurrentIndexer == null)
            {
                p.CurrentIterator.CurrentIndexer = p.CurrentIterator.ForIndexer;
                p.CurrentIterator.CurrentIndexer.IsGlobal = true;
            }
            p.LastValue = new TypedValueBridge(Int, p.Indexer + fromValue);
                        
            p.ResultSize = countValue;
            p.SourceSize = countValue;
        }
    }
}