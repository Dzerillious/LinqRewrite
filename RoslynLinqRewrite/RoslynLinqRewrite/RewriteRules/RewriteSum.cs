using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.VariableExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSum
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            if (chainIndex != p.Chain.Count - 1) throw new InvalidOperationException("Sum should be last expression.");

            var isNullable = p.ReturnType is NullableTypeSyntax;
            var elementType = isNullable ? ((NullableTypeSyntax)p.ReturnType).ElementType : p.ReturnType;
            var sumVariable = p.CreateLocalVariable("__sum", 0.Cast(elementType));

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
            
            p.PostForAdd(Return(sumVariable));
            p.HasResultMethod = true;
        }
    }
}