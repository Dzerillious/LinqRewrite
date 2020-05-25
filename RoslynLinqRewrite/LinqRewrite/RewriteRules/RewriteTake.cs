﻿using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.ExpressionSimplifier;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteTake
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.Iterators.Count > 1) p.ListEnumeration = false;
            
            var takeValue = args[0];
            CheckBounds(p, ref takeValue);
            var takeIndexer = VariableCreator.GlobalVariable(p, Int, 0);

            if (!p.ModifiedEnumeration)
            {
                p.CurrentIterator.ForTo = p.CurrentIterator.ForFrom + p.CurrentIterator.ForInc * takeValue - p.CurrentIterator.ForInc;
                p.CurrentIterator.ForTo = p.CurrentIterator.ForTo.Simplify();
            }
            else p.ForAdd(If(takeIndexer.PostIncrement() >= takeValue, Break()));
            
            if (p.ResultSize != null) p.ResultSize = takeValue;
            p.Indexer = null;
        }

        private static void CheckBounds(RewriteParameters p, ref RewrittenValueBridge takeValue)
        {
            if (p.Unchecked) return;
            var takeIntPass = TryGetInt(takeValue, out var takeInt);
            var resultIntPass = TryGetInt(p.ResultSize, out var resultInt);
            
            if (takeIntPass)
            {
                if (takeInt < 0) takeValue = new RewrittenValueBridge(IntValue(0));
                if (!resultIntPass)
                {
                    if (p.ResultSize == null) return;
                    var takeVariable = VariableCreator.GlobalVariable(p, Int);
                    p.PreUseAdd(If(takeValue > p.ResultSize, 
                                     takeVariable.Assign(p.ResultSize),
                                    takeVariable.Assign(takeValue)));
                    takeValue = new RewrittenValueBridge(takeVariable);
                }
                else if (takeInt > resultInt) takeValue = new RewrittenValueBridge(p.ResultSize);
            }
            else if (p.ResultSize != null)
            {
                var takeVariable = VariableCreator.GlobalVariable(p, Int);
                p.PreUseAdd(If(takeValue < 0, takeVariable.Assign(IntValue(0)),
                                    If(takeValue > p.ResultSize, takeVariable.Assign(p.ResultSize),
                                        takeVariable.Assign(takeValue))));
                takeValue = new RewrittenValueBridge(takeVariable);
            }
            else
            {
                var takeVariable = VariableCreator.GlobalVariable(p, Int);
                p.PreUseAdd(If(takeValue < 0, takeVariable.Assign(IntValue(0)),
                                takeVariable.Assign(takeValue)));
                takeValue = new RewrittenValueBridge(takeVariable);
            }
        }
    }
}