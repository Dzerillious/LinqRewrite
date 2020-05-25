using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
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
            if (!AssertionExtension.AssertGreaterEqual(p, countValue, 0)) return;

            p.FirstCollection = p.CurrentCollection = null;
            p.AddIterator();
            p.CurrentIterator.ForFrom = 0;
            p.CurrentIterator.ForTo = countValue * increment - increment;
            p.CurrentIterator.ForInc = increment;
            p.CurrentIterator.ForIndexer = VariableCreator.LocalVariable(p, Int);
            
            p.ListEnumeration = false;
            p.SimpleEnumeration = true;
            if (p.CurrentIndexer == null)
            {
                p.CurrentIterator.Indexer = p.CurrentIterator.ForIndexer;
                p.CurrentIterator.Indexer.IsGlobal = true;
            }
            p.LastValue = new TypedValueBridge(Int, p.Indexer + fromValue);
                        
            p.ResultSize = countValue;
            p.SourceSize = countValue;
        }
    }
}