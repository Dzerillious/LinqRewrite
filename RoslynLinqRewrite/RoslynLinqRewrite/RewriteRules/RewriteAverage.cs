using System;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using Shaman.Roslyn.LinqRewrite.Extensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.VariableExtensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteAverage
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            var sumVariable = "__sum" + chainIndex;
            var countVariable = "__count" + chainIndex;
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            if (chainIndex != p.Chain.Count - 1) throw new InvalidOperationException("Sum should be last expression.");

            var isNullable = p.ReturnType is NullableTypeSyntax;
            var elementType = isNullable ? ((NullableTypeSyntax)p.ReturnType).ElementType : p.ReturnType;
            p.PreForAdd(LocalVariableCreation(sumVariable, 0.Cast(elementType)));

            if (p.Chain[chainIndex].Arguments.Length == 0)
                p.ForAdd(sumVariable.AddAssign(p.LastItem));
            else if (isNullable)
            {
                var method = p.Chain[chainIndex].Arguments[0];
                var inlined = method.Inline(p, p.LastItem).Reusable(p);
                p.ForAdd(If(inlined.NotEqualsExpr(NullValue),
                    sumVariable.AddAssign(inlined)));
            }
            else
            {
                var method = p.Chain[chainIndex].Arguments[0];
                p.ForAdd(sumVariable.AddAssign(method.Inline(p, p.LastItem)));
            }

            if (p.ResultSize == null)
            {
                p.PreForAdd(LocalVariableCreation(countVariable, 0));
                p.ForAdd(countVariable.PostIncrement());
                p.PostForAdd(Return(sumVariable.Div(countVariable)));
            }
            else p.PostForAdd(Return(sumVariable.Div(p.ResultSize)));
            
            p.HasResultMethod = true;
        }
    }
}