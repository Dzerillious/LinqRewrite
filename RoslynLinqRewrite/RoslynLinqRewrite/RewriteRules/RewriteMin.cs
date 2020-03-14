using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.VariableExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteMin
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());

            var elementType = p.ReturnType.Type is NullableTypeSyntax nullable
                ? (TypeBridge)nullable.ElementType : p.ReturnType;

            var minVariable = elementType.ToString() switch
            {
                "int" => p.GlobalVariable(Int, int.MaxValue),
                "float" => p.GlobalVariable(Float, float.MaxValue),
                "double" => p.GlobalVariable(VariableExtensions.Double, double.MaxValue),
                _ => null
            };
            var value = args.Length switch
            {
                0 => p.LastValue.Reusable(p),
                1 => args[0].Inline(p, p.LastValue).Reusable(p)
            };
            if (p.ReturnType.Type is NullableTypeSyntax)
            {
                p.ForAdd(If(value.NotEqual(null),
                            If(value < minVariable,
                                minVariable.Assign(value))));
            }
            else
            {
                p.ForAdd(If(value < minVariable,
                            minVariable.Assign(value)));
            }
            
            p.FinalAdd(Return(minVariable));
            p.HasResultMethod = true;
        }
    }
}