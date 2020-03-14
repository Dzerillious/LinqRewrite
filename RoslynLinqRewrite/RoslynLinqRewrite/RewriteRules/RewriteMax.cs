using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.VariableExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteMax
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());

            var elementType = p.ReturnType.Type is NullableTypeSyntax nullable
                ? (TypeBridge)nullable.ElementType : p.ReturnType;

            var maxVariable = elementType.ToString() switch
            {
                "int" => p.GlobalVariable(Int, int.MinValue),
                "float" => p.GlobalVariable(Float, float.MinValue),
                "double" => p.GlobalVariable(VariableExtensions.Double, double.MinValue),
                _ => null
            };

            if (args.Length == 0)
            {
                var inlined = p.LastValue.Reusable(p);
                p.ForAdd(If(inlined > maxVariable,
                            maxVariable.Assign(inlined)));
            }
            else if (p.ReturnType.Type is NullableTypeSyntax)
            {
                var inlined = args[0].Inline(p, p.LastValue).ReusableConst(p);
                p.ForAdd(If(inlined.NotEqual(null),
                            If(inlined > maxVariable,
                                maxVariable.Assign(inlined))));
            }
            else
            {
                var inlined = args[0].Inline(p, p.LastValue).ReusableConst(p);
                p.ForAdd(If(inlined > maxVariable,
                            maxVariable.Assign(inlined)));
            }
            
            p.FinalAdd(Return(maxVariable));
            p.HasResultMethod = true;
        }
    }
}