using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSkip
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            
            var skippedValue = args[0];
            if (ExpressionSimplifier.TryGetInt(skippedValue, out var skippedInt))
            {
                if (skippedInt < 0) return;
            }
            else if (!p.ModifiedEnumeration)
            {
                var skippedVariable = p.GlobalVariable(Int, skippedValue);
                p.InitialAdd(skippedVariable.Assign(ConditionalExpression(
                    skippedValue < 0, skippedValue, IntValue(0))));
                skippedValue = new RewrittenValueBridge(skippedVariable);
            }
                
            if (!p.ModifiedEnumeration)
                p.ForMin = p.ForReMin += skippedValue;
            else 
            {
                p.ForAdd(If(p.Indexer < skippedValue, 
                            Block(
                    p.Indexer.PostIncrement(),
                                     Continue()
                                )));
            }
            
            if (p.ResultSize != null) p.ResultSize -= skippedValue;
            p.Indexer = null;
        }
    }
}