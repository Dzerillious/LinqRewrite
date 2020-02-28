using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using Shaman.Roslyn.LinqRewrite.Extensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.VariableExtensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public class RewriteMin
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            var minVariable = p.CreateVariable("__min");
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            if (chainIndex != p.Chain.Count - 1) throw new InvalidOperationException("Sum should be last expression.");

            var isNullable = p.ReturnType is NullableTypeSyntax;
            var elementType = isNullable ? ((NullableTypeSyntax)p.ReturnType).ElementType : p.ReturnType;
            
            if (elementType.ToString() == "int") p.PreForAdd(LocalVariableCreation(minVariable, int.MaxValue.Cast(elementType)));
            else if (elementType.ToString() == "float") p.PreForAdd(LocalVariableCreation(minVariable, float.MaxValue.Cast(elementType)));
            else if (elementType.ToString() == "double") p.PreForAdd(LocalVariableCreation(minVariable, double.MaxValue.Cast(elementType)));

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
            
            p.PostForAdd(Return(minVariable));
            p.HasResultMethod = true;
        }
    }
}