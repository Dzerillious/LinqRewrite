using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.VariableExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteMin
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            if (!p.AssertResultSizeGreaterEqual(1)) return;

            var elementType = p.ReturnType.Type is NullableTypeSyntax nullable
                ? (TypeBridge)nullable.ElementType : p.ReturnType;

            var minVariable = elementType.ToString() switch
            {
                "int" => p.GlobalVariable(Int, int.MaxValue),
                "long" => p.GlobalVariable(Long, long.MaxValue),
                "float" => p.GlobalVariable(Float, float.MaxValue),
                "double" => p.GlobalVariable(VariableExtensions.Double, double.MaxValue),
                "decimal" => p.GlobalVariable(VariableExtensions.Decimal, decimal.MaxValue),
                _ => null
            };
            
            var value = args.Length switch
            {
                0 => p.LastValue.Reusable(p),
                1 => args[0].Inline(p, p.LastValue).Reusable(p)
            };
            if (p.ReturnType.Type is NullableTypeSyntax)
            {
                p.ForAdd(If(value.IsEqual(null).Or(value >= minVariable), Continue()));
                p.ForAdd(minVariable.Assign(value.Cast(elementType)));
            }
            else
            {
                p.ForAdd(If(value >= minVariable, Continue()));
                p.ForAdd(minVariable.Assign(value));
            }
            
            p.ResultAdd(Return(minVariable));
        }
    }
}