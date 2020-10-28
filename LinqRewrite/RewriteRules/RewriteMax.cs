using System.Collections.Immutable;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.AssertionExtension;
using static LinqRewrite.Extensions.VariableExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteMax
    {
        public static void Rewrite(RewriteDesign design, ImmutableArray<ValueBridge> args)
        {
            if (!AssertResultSizeGreaterEqual(design, 1)) return;
            var elementType = design.Info.ReturnType is NullableTypeSyntax nullable
                ? nullable.ElementType : design.Info.ReturnType;

            var maxVariable = elementType.ToString() switch
            {
                "int" => CreateGlobalVariable(design, Int, int.MinValue),
                "long" => CreateGlobalVariable(design, Long, long.MinValue),
                "float" => CreateGlobalVariable(design, Float, float.MinValue),
                "double" => CreateGlobalVariable(design, Double, double.MinValue),
                "decimal" => CreateGlobalVariable(design, Decimal, decimal.MinValue),
                _ => null
            };
            
            var value = args.Length switch
            {
                0 => design.LastValue.Reusable(design),
                1 => args[0].Inline(design, design.LastValue).Reusable(design)
            };
            if (design.Info.ReturnType is NullableTypeSyntax)
            {
                design.ForAdd(If(value.IsEqual(null).Or(value <= maxVariable), Continue()));
                design.ForAdd(maxVariable.Assign(value.Cast(elementType)));
            }
            else
            {
                design.ForAdd(If(value <= maxVariable, Continue()));
                design.ForAdd(maxVariable.Assign(value));
            }
            
            design.ResultAdd(Return(maxVariable));
        }
    }
}