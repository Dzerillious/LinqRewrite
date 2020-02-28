using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using Shaman.Roslyn.LinqRewrite.Extensions;
using static Shaman.Roslyn.LinqRewrite.Constants;
using static Shaman.Roslyn.LinqRewrite.Extensions.VariableExtensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteAggregate
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            var resultVariable = "__result" + chainIndex;
            
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            if (chainIndex != p.Chain.Count - 1) throw new InvalidOperationException("Count should be last expression.");
            
            p.PreForAdd(LocalVariableCreation(resultVariable, p.Collection.ArrayAccess(0)));
            var aggregation = p.Chain[chainIndex].Arguments[0];
            p.ForAdd(resultVariable.Assign(aggregation.Inline(p, resultVariable, p.LastItem)));
            
            p.PostForAdd(Return(resultVariable));
            p.HasResultMethod = true;
        }
    }
}