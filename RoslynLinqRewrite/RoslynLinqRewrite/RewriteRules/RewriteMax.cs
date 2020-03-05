using System;
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
            
            if (elementType.ToString() == "int") maxVariable = p.GlobalVariable(Int, "__max", int.MinValue);
            else if (elementType.ToString() == "float") maxVariable = p.GlobalVariable(Float, "__max", float.MinValue);
            else if (elementType.ToString() == "double") maxVariable = p.GlobalVariable(VariableExtensions.Double, "__max", double.MinValue);
            else maxVariable = null;

            if (p.Chain[chainIndex].Arguments.Length == 0)
            {
                var inlined = p.Last.Reusable(p);
                p.ForAdd(If(inlined > maxVariable,
                            maxVariable.Assign(inlined)));
            }
            else if (isNullable)
            {
                var method = p.Chain[chainIndex].Arguments[0];
                var inlined = method.Inline(p, p.Last).Reusable(p);
                p.ForAdd(If(inlined.NotEqual(Null),
                            If(inlined > maxVariable,
                                maxVariable.Assign(inlined))));
            }
            else
            {
                var method = p.Chain[chainIndex].Arguments[0];
                var inlined = method.Inline(p, p.Last).Reusable(p);
                p.ForAdd(If(inlined > maxVariable,
                            maxVariable.Assign(inlined)));
            }
            
            p.FinalAdd(Return(maxVariable));
            p.HasResultMethod = true;
        }
    }
}