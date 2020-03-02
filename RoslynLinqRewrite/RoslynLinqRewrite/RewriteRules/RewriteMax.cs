﻿using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.VariableExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public class RewriteMax
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            VariableBridge maxVariable;
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            if (chainIndex != p.Chain.Count - 1) throw new InvalidOperationException("Sum should be last expression.");

            var isNullable = p.ReturnType is NullableTypeSyntax;
            var elementType = isNullable ? ((NullableTypeSyntax)p.ReturnType).ElementType : p.ReturnType;
            
            if (elementType.ToString() == "int") maxVariable = p.CreateLocalVariable("__max", IntType, int.MinValue.Cast(elementType));
            else if (elementType.ToString() == "float") maxVariable = p.CreateLocalVariable("__max", FloatType, float.MinValue.Cast(elementType));
            else if (elementType.ToString() == "double") maxVariable = p.CreateLocalVariable("__max", DoubleType, double.MinValue.Cast(elementType));
            else maxVariable = null;

            if (p.Chain[chainIndex].Arguments.Length == 0)
            {
                var reusable = p.LastItem.Reusable(p);
                p.ForAdd(If(reusable.GThan(maxVariable),
                            maxVariable.Assign(reusable)));
            }
            else if (isNullable)
            {
                var method = p.Chain[chainIndex].Arguments[0];
                var reusable = method.Inline(p, p.LastItem).Reusable(p);
                p.ForAdd(If(reusable.NotEqualsExpr(NullValue),
                            If(reusable.GThan(maxVariable),
                                maxVariable.Assign(reusable))));
            }
            else
            {
                var method = p.Chain[chainIndex].Arguments[0];
                var reusable = method.Inline(p, p.LastItem).Reusable(p);
                p.ForAdd(If(reusable.GThan(maxVariable),
                            maxVariable.Assign(reusable)));
            }
            
            p.FinalAdd(Return(maxVariable));
            p.HasResultMethod = true;
        }
    }
}