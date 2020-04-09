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
            if (!p.AssertResultSizeGreaterEqual(1)) return;

            var elementType = p.ReturnType.Type is NullableTypeSyntax nullable
                ? (TypeBridge)nullable.ElementType : p.ReturnType;

            var maxVariable = elementType.ToString() switch
            {
                "int" => p.GlobalVariable(Int, int.MinValue),
                "long" => p.GlobalVariable(Long, long.MinValue),
                "float" => p.GlobalVariable(Float, float.MinValue),
                "double" => p.GlobalVariable(VariableExtensions.Double, double.MinValue),
                "decimal" => p.GlobalVariable(VariableExtensions.Decimal, decimal.MinValue),
                _ => null
            };
            
            var value = args.Length switch
            {
                0 => p.LastValue.Reusable(p),
                1 => args[0].Inline(p, p.LastValue).Reusable(p)
            };
            if (p.ReturnType.Type is NullableTypeSyntax)
            {
                p.ForAdd(If(value.IsEqual(null).Or(value <= maxVariable), Continue()));
                p.ForAdd(maxVariable.Assign(value.Cast(elementType)));
            }
            else
            {
                p.ForAdd(If(value <= maxVariable, Continue()));
                p.ForAdd(maxVariable.Assign(value));
            }
            
            p.ResultAdd(Return(maxVariable));
        }
    }
}