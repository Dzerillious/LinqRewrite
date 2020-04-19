using LinqRewrite.DataStructures;
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
            var takeValue = args[0];
            CheckBounds(p, ref takeValue);

            if (!p.ModifiedEnumeration)
            {
                p.CurrentIterator.ForTo = p.CurrentIterator.ForFrom + p.CurrentIterator.ForInc * takeValue - p.CurrentIterator.ForInc;
                p.CurrentIterator.ForTo = p.CurrentIterator.ForTo.Simplify();
            }
            else p.ForAdd(If(p.Indexer >= takeValue, Break()));
            
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
                    var takeVariable = p.GlobalVariable(Int);
                    p.InitialAdd(If(takeValue > p.ResultSize, 
                                     takeVariable.Assign(p.ResultSize),
                                    takeVariable.Assign(takeValue)));
                    takeValue = new RewrittenValueBridge(takeVariable);
                }
                else if (takeInt > resultInt) takeValue = new RewrittenValueBridge(p.ResultSize);
            }
            else if (p.ResultSize != null)
            {
                var takeVariable = p.GlobalVariable(Int);
                p.InitialAdd(If(takeValue < 0, takeVariable.Assign(IntValue(0)),
                                    If(takeValue > p.ResultSize, takeVariable.Assign(p.ResultSize),
                                        takeVariable.Assign(takeValue))));
                takeValue = new RewrittenValueBridge(takeVariable);
            }
            else
            {
                var takeVariable = p.GlobalVariable(Int);
                p.InitialAdd(If(takeValue < 0, takeVariable.Assign(IntValue(0)),
                                takeVariable.Assign(takeValue)));
                takeValue = new RewrittenValueBridge(takeVariable);
            }
        }
    }
}