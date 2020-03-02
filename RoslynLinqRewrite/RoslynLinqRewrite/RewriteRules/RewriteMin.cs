﻿using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.VariableExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public class RewriteMin
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            VariableBridge minVariable;
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            if (chainIndex != p.Chain.Count - 1) throw new InvalidOperationException("Sum should be last expression.");

            var isNullable = p.ReturnType is NullableTypeSyntax;
            var elementType = isNullable ? ((NullableTypeSyntax)p.ReturnType).ElementType : p.ReturnType;
            
            if (elementType.ToString() == "int") minVariable = p.CreateLocalVariable("__min", IntType, int.MaxValue.Cast(elementType));
            else if (elementType.ToString() == "float") minVariable = p.CreateLocalVariable("__min", FloatType, float.MaxValue.Cast(elementType));
            else if (elementType.ToString() == "double") minVariable = p.CreateLocalVariable("__min", DoubleType, double.MaxValue.Cast(elementType));
            else minVariable = null;

            if (p.Chain[chainIndex].Arguments.Length == 0)
            {
                var reusable = p.LastItem.Reusable(p);
                p.ForAdd(If(reusable.LThan(minVariable),
                            minVariable.Assign(reusable)));
            }
            else if (isNullable)
            {
                var method = p.Chain[chainIndex].Arguments[0];
                var reusable = method.Inline(p, p.LastItem).Reusable(p);
                p.ForAdd(If(reusable.NotEqualsExpr(NullValue),
                            If(reusable.LThan(minVariable),
                                minVariable.Assign(reusable))));
            }
            else
            {
                var method = p.Chain[chainIndex].Arguments[0];
                var reusable = method.Inline(p, p.LastItem).Reusable(p);
                p.ForAdd(If(reusable.LThan(minVariable),
                            minVariable.Assign(reusable)));
            }
            
            p.FinalAdd(Return(minVariable));
            p.HasResultMethod = true;
        }
    }
}