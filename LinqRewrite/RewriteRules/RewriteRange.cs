using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteRange
    {
        public static void Rewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            design.Variables.Where(x => !x.IsGlobal).ForEach(x => x.IsUsed = false);
            var fromValue = args[0];
            var countValue = args[1];
            var increment = args.Length == 3 ? args[2].New : 1;
            if (!AssertionExtension.AssertGreaterEqual(design, countValue, 0)) return;

            design.FirstCollection = design.CurrentCollection = null;
            design.AddIterator();
            design.CurrentIterator.ForFrom = 0;
            design.CurrentIterator.ForTo = countValue * increment - increment;
            design.CurrentIterator.ForInc = increment;
            design.CurrentIterator.ForIndexer = VariableCreator.LocalVariable(design, Int);
            
            design.ListEnumeration = false;
            design.SimpleEnumeration = true;
            if (design.CurrentIndexer == null)
            {
                design.CurrentIterator.Indexer = design.CurrentIterator.ForIndexer;
                design.CurrentIterator.Indexer.IsGlobal = true;
            }
            design.LastValue = new TypedValueBridge(Int, design.Indexer + fromValue);
                        
            design.ResultSize = countValue;
            design.SourceSize = countValue;
        }
    }
}