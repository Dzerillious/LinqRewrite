using System.Collections.Immutable;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.AssertionExtension;
using static LinqRewrite.Extensions.VariableExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteMin
    {
        public static void Rewrite(RewriteDesign design, ImmutableArray<ValueBridge> args)
        {
            if (!AssertResultSizeGreaterEqual(design, 1)) return;
            var elementType = design.Info.ReturnType is NullableTypeSyntax nullable
                ? nullable.ElementType : design.Info.ReturnType;

            var minVariable = elementType.ToString() switch
            {
                "int" => CreateGlobalVariable(design, Int, int.MaxValue),
                "long" => CreateGlobalVariable(design, Long, long.MaxValue),
                "float" => CreateGlobalVariable(design, Float, float.MaxValue),
                "double" => CreateGlobalVariable(design, Double, double.MaxValue),
                "decimal" => CreateGlobalVariable(design, Decimal, decimal.MaxValue),
                _ => null
            };
            
            var value = args.Length switch
            {
                0 => design.LastValue.Reusable(design),
                1 => args[0].Inline(design, design.LastValue).Reusable(design)
            };
            if (design.Info.ReturnType is NullableTypeSyntax)
            {
                design.ForAdd(If(value.IsEqual(null).Or(value >= minVariable), Continue()));
                design.ForAdd(minVariable.Assign(value.Cast(elementType)));
            }
            else
            {
                design.ForAdd(If(value >= minVariable, Continue()));
                design.ForAdd(minVariable.Assign(value));
            }
            
            design.ResultAdd(Return(minVariable));
        }
    }
}