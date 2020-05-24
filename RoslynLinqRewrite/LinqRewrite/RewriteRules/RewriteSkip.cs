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
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.Iterators.Count > 1) p.ListEnumeration = false;
            
            var skippedValue = args[0];
            CheckBounds(p, ref skippedValue);

            if (!p.ModifiedEnumeration)
            {
                p.CurrentIterator.ForFrom += skippedValue * p.CurrentIterator.ForInc;
                p.CurrentIterator.ForFrom = p.CurrentIterator.ForFrom.Simplify();
            }
            else 
            {
                p.ForAdd(If(p.Indexer < skippedValue, 
                            Block(
                    p.Indexer.PostIncrement(),
                                     Continue()
                                )));
            }
            
            if (p.ResultSize != null) p.ResultSize -= skippedValue;
            if (TryGetInt(p.ResultSize, out var resultInt) && resultInt < 0)
                p.ResultSize = 0;
            
            p.Indexer = null;
        }

        private static void CheckBounds(RewriteParameters p, ref RewrittenValueBridge skippedValue)
        {
            if (TryGetInt(skippedValue, out var skippedInt))
            {
                if (skippedInt < 0) return;
                if (TryGetInt(p.ResultSize, out var resultSizeInt) && skippedInt > resultSizeInt)
                    skippedValue = new RewrittenValueBridge(p.ResultSize);
                else if (!p.Unchecked)
                {
                    var skippedVariable = p.GlobalVariable(Int);
                    skippedVariable.Assign(ConditionalExpression(skippedValue > p.ResultSize, p.ResultSize,
                        skippedValue));
                    skippedValue = new RewrittenValueBridge(skippedVariable);
                }
            }
            else if (!p.Unchecked && !p.ModifiedEnumeration)
            {
                var skippedVariable = p.GlobalVariable(Int);
                p.InitialAdd(If(skippedValue < 0, skippedVariable.Assign(0),
                    If (skippedValue > p.ResultSize, skippedVariable.Assign(p.ResultSize),
                        skippedVariable.Assign(skippedValue))));
                skippedValue = new RewrittenValueBridge(skippedVariable);
            }
        }
    }
}