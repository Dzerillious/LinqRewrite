﻿using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.VariableExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteAverage
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            if (chainIndex != p.Chain.Count - 1) throw new InvalidOperationException("Sum should be last expression.");

            var isNullable = p.ReturnType is NullableTypeSyntax;
            var elementType = isNullable ? ((NullableTypeSyntax)p.ReturnType).ElementType : p.ReturnType;
            var sumVariable = p.CreateGlobalVariable("__sum", elementType, 0);

            if (p.Chain[chainIndex].Arguments.Length == 0)
            {
                p.ForAdd(sumVariable.AddAssign(p.Last.Value));
            }
            else if (isNullable)
            {
                var method = p.Chain[chainIndex].Arguments[0];
                var inlined = method.Inline(p, p.Last.Value).Reusable(p);
                p.ForAdd(If(inlined.Item1.NotEqualsExpr(NullValue),
                            sumVariable.AddAssign(inlined.Item1)));
            }
            else
            {
                var method = p.Chain[chainIndex].Arguments[0];
                p.ForAdd(sumVariable.AddAssign(method.Inline(p, p.Last.Value)));
            }

            p.FinalAdd(Return(p.ResultSize == null
                ? sumVariable.Div(p.Indexer.Add(1))
                : sumVariable.Div(p.ResultSize)));

            p.HasResultMethod = true;
        }
    }
}