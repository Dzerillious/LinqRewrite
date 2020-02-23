using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using Shaman.Roslyn.LinqRewrite.Extensions;
using static Shaman.Roslyn.LinqRewrite.Constants;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteContains
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            var element = p.Node.ArgumentList.Arguments.First().Expression;

            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            if (chainIndex != p.Chain.Count - 1) throw new InvalidOperationException("Any should be last expression.");
            
            if (p.Chain[chainIndex].Arguments.Length == 1)
                p.ForAdd(If(p.LastItem.EqualsExpr(element),
                            Return(true)));
            
            else
            {
                var comparer = p.Chain[chainIndex].Arguments[1];
                p.ForAdd(If(comparer.Access("Equals").Invoke(p.LastItem, element),
                    Return(true)));
            }
            
            p.PostForAdd(Return(false));
        }
    }
}