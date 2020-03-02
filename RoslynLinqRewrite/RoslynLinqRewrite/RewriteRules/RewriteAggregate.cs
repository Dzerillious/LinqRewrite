using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.VariableExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteAggregate
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex != p.Chain.Count - 1) throw new InvalidOperationException("Count should be last expression.");

            var resultVariable = p.CreateLocalVariable("__result",  p.ReturnType, p.Collection.ArrayAccess(0));
            var aggregation = p.Chain[chainIndex].Arguments[0];
            p.ForAdd(resultVariable.Assign(aggregation.Inline(p, resultVariable, p.LastItem)));
            
            p.FinalAdd(Return(resultVariable));
            p.HasResultMethod = true;
        }
    }
}