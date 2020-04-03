using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
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
            if (!p.AssertGreaterEqual(countValue, 0)) return;
            
            p.AddIterator();
            p.ForMin = p.ForReMin = 0;
            p.ForMax = countValue;
            p.ForReMax = countValue - 1;
            
            p.ResultSize = countValue;
            p.SourceSize = countValue;
            p.ListEnumeration = false;
            
            p.CurrentIterator.ForIndexer = p.LocalVariable(Int);
            if (p.CurrentIndexer == null)
            {
                p.CurrentIterator.CurrentIndexer = p.CurrentIterator.ForIndexer;
                p.CurrentIterator.CurrentIndexer.IsGlobal = true;
            }
            p.LastValue = new TypedValueBridge(itemValue.GetType(p), itemValue);
            
            p.FirstCollection = p.CurrentCollection = null;
        }
    }
}