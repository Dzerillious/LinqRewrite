using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.ExpressionSimplifier;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSkip
    {
        public static void Rewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            if (design.Iterators.Count > 1) design.ListEnumeration = false;
            
            var skippedValue = args[0];
            if (!CheckBounds(design, ref skippedValue)) return;

            if (!design.ModifiedEnumeration)
            {
                design.CurrentIterator.ForFrom += skippedValue * design.CurrentIterator.ForInc;
                design.CurrentIterator.ForFrom = design.CurrentIterator.ForFrom.Simplify();
            }
            else 
            {
                design.ForAdd(If(design.Indexer < skippedValue, Block(
                        design.Indexer.PostIncrement(),
                                         Continue()
                                    )));
            }
            
            if (design.ResultSize != null) design.ResultSize -= skippedValue;
            if (TryGetInt(design.ResultSize, out var resultInt) && resultInt < 0)
                design.ResultSize = 0;
            
            design.Indexer = null;
        }

        private static bool CheckBounds(RewriteDesign design, ref RewrittenValueBridge skippedValue)
        {
            if (design.ResultSize == null) return true;
            if (TryGetInt(skippedValue, out var skippedInt))
            {
                if (skippedInt <= 0) return false;
                if (TryGetInt(design.ResultSize, out var resultSizeInt) && skippedInt > resultSizeInt)
                    skippedValue = new RewrittenValueBridge(design.ResultSize);
                else if (!design.Unchecked)
                {
                    var skippedVariable = CreateGlobalVariable(design, Int);
                    design.InitialAdd(skippedVariable.Assign(ConditionalExpression(skippedValue > design.ResultSize, design.ResultSize,
                        skippedValue)));
                    skippedValue = new RewrittenValueBridge(skippedVariable);
                }
            }
            else if (!design.Unchecked && !design.ModifiedEnumeration)
            {
                var skippedVariable = CreateGlobalVariable(design, Int);
                design.InitialAdd(If(skippedValue < 0, skippedVariable.Assign(0),
                    If (skippedValue > design.ResultSize, skippedVariable.Assign(design.ResultSize),
                        skippedVariable.Assign(skippedValue))));
                skippedValue = new RewrittenValueBridge(skippedVariable);
            }
            return true;
        }
    }
}