using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteTake
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            
            var takeValue = args[0];
            if (int.TryParse(takeValue.OldVal.ToString(), out var takeInt))
                if (takeInt < 0) takeValue = new RewrittenValueBridge(IntValue(0));
                
            if (!p.ModifiedEnumeration)
            {
                var takeVariable = p.GlobalVariable(Int);
                p.InitialAdd(If(takeValue < 0, takeVariable.Assign(IntValue(0)),
                                If(takeValue > p.ForMax, takeVariable.Assign(p.ForMax),
                                        takeVariable.Assign(takeValue))));
                
                takeValue = new RewrittenValueBridge(takeVariable);
                p.ForReMin = p.ForMax - takeValue;
                p.ForMax = takeValue;
            }
            else p.ForAdd(If(p.Indexer >= takeValue, Break()));
            
            if (p.ResultSize != null)
                p.ResultSize = takeValue;
            
            p.Indexer = null;
        }
    }
}