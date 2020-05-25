using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.ExpressionSimplifier;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteTake
    {
        public static void Rewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            if (design.Iterators.Count > 1) design.ListEnumeration = false;
            
            var takeValue = args[0];
            CheckBounds(design, ref takeValue);
            var takeIndexer = VariableCreator.GlobalVariable(design, Int, 0);

            if (!design.ModifiedEnumeration)
            {
                design.CurrentIterator.ForTo = design.CurrentIterator.ForFrom + design.CurrentIterator.ForInc * takeValue - design.CurrentIterator.ForInc;
                design.CurrentIterator.ForTo = design.CurrentIterator.ForTo.Simplify();
            }
            else design.ForAdd(If(takeIndexer.PostIncrement() >= takeValue, Break()));
            
            if (design.ResultSize != null) design.ResultSize = takeValue;
            design.Indexer = null;
        }

        private static void CheckBounds(RewriteDesign design, ref RewrittenValueBridge takeValue)
        {
            if (design.Unchecked) return;
            var takeIntPass = TryGetInt(takeValue, out var takeInt);
            var resultIntPass = TryGetInt(design.ResultSize, out var resultInt);
            
            if (takeIntPass)
            {
                if (takeInt < 0) takeValue = new RewrittenValueBridge(IntValue(0));
                if (!resultIntPass)
                {
                    if (design.ResultSize == null) return;
                    var takeVariable = VariableCreator.GlobalVariable(design, Int);
                    design.PreUseAdd(If(takeValue > design.ResultSize, 
                                     takeVariable.Assign(design.ResultSize),
                                    takeVariable.Assign(takeValue)));
                    takeValue = new RewrittenValueBridge(takeVariable);
                }
                else if (takeInt > resultInt) takeValue = new RewrittenValueBridge(design.ResultSize);
            }
            else if (design.ResultSize != null)
            {
                var takeVariable = VariableCreator.GlobalVariable(design, Int);
                design.PreUseAdd(If(takeValue < 0, takeVariable.Assign(IntValue(0)),
                                    If(takeValue > design.ResultSize, takeVariable.Assign(design.ResultSize),
                                        takeVariable.Assign(takeValue))));
                takeValue = new RewrittenValueBridge(takeVariable);
            }
            else
            {
                var takeVariable = VariableCreator.GlobalVariable(design, Int);
                design.PreUseAdd(If(takeValue < 0, takeVariable.Assign(IntValue(0)),
                                takeVariable.Assign(takeValue)));
                takeValue = new RewrittenValueBridge(takeVariable);
            }
        }
    }
}