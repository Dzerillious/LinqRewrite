using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteRepeat
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            p.Variables.Where(x => !x.IsGlobal).ForEach(x => x.IsUsed = false);
            var itemValue = args[0];
            var countValue = args[1];
            if (!AssertionExtension.AssertGreaterEqual(p, countValue, 0)) return;
            
            p.AddIterator();
            p.CurrentIterator.ForFrom = 0;
            p.CurrentIterator.ForTo = countValue - 1;
            p.CurrentIterator.ForIndexer = VariableCreator.LocalVariable(p, Int);
            
            p.ResultSize = countValue;
            p.SourceSize = countValue;
            p.ListEnumeration = false;
            p.SimpleEnumeration = true;
            
            if (p.CurrentIndexer == null)
            {
                p.CurrentIterator.Indexer = p.CurrentIterator.ForIndexer;
                p.CurrentIterator.Indexer.IsGlobal = true;
            }
            p.LastValue = new TypedValueBridge(itemValue.GetType(p), itemValue);
            p.FirstCollection = p.CurrentCollection = null;
        }
    }
}