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

            if (args.Length == 0)
            {
                var inlined = p.LastValue.Reusable(p);
                p.ForAdd(If(inlined < minVariable,
                            minVariable.Assign(inlined)));
            }
            else if (p.ReturnType.Type is NullableTypeSyntax)
            {
                var inlined = args[0].Inline(p, p.LastValue).Reusable(p);
                p.ForAdd(If(inlined.NotEqual(Null),
                            If(inlined < minVariable,
                                minVariable.Assign(inlined))));
            }
            else
            {
                var inlined = args[0].Inline(p, p.LastValue).Reusable(p);
                p.ForAdd(If(inlined < minVariable,
                            minVariable.Assign(inlined)));
            }
            
            p.FinalAdd(Return(minVariable));
            p.HasResultMethod = true;
        }
    }
}