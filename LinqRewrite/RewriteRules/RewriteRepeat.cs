using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteRepeat
    {
        public static void Rewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            design.Variables.Where(x => !x.IsGlobal).ForEach(x => x.IsUsed = false);
            var itemValue = args[0];
            var countValue = args[1];
            if (!AssertionExtension.AssertGreaterEqual(design, countValue, 0)) return;
            
            design.AddIterator();
            design.CurrentIterator.ForFrom = 0;
            design.CurrentIterator.ForTo = countValue - 1;
            design.CurrentIterator.ForIndexer = VariableCreator.LocalVariable(design, Int);
            
            design.ResultSize = countValue;
            design.SourceSize = countValue;
            design.ListEnumeration = false;
            design.SimpleEnumeration = true;
            
            if (design.CurrentIndexer == null)
            {
                design.CurrentIterator.Indexer = design.CurrentIterator.ForIndexer;
                design.CurrentIterator.Indexer.IsGlobal = true;
            }
            design.LastValue = new TypedValueBridge(itemValue.GetType(design), itemValue);
            design.FirstCollection = design.CurrentCollection = null;
        }
    }
}