using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.VariableExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteMax
    {
        public static void Rewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            if (!AssertionExtension.AssertResultSizeGreaterEqual(design, 1)) return;
            var elementType = design.ReturnType.Type is NullableTypeSyntax nullable
                ? (TypeBridge)nullable.ElementType : design.ReturnType;

            var maxVariable = elementType.ToString() switch
            {
                "int" => VariableCreator.GlobalVariable(design, Int, int.MinValue),
                "long" => VariableCreator.GlobalVariable(design, Long, long.MinValue),
                "float" => VariableCreator.GlobalVariable(design, Float, float.MinValue),
                "double" => VariableCreator.GlobalVariable(design, Double, double.MinValue),
                "decimal" => VariableCreator.GlobalVariable(design, Decimal, decimal.MinValue),
                _ => null
            };
            
            var value = args.Length switch
            {
                0 => design.LastValue.Reusable(design),
                1 => args[0].Inline(design, design.LastValue).Reusable(design)
            };
            if (design.ReturnType.Type is NullableTypeSyntax)
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