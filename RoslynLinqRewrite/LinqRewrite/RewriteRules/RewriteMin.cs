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
            if (!AssertionExtension.AssertResultSizeGreaterEqual(p, 1)) return;
            var elementType = p.ReturnType.Type is NullableTypeSyntax nullable
                ? (TypeBridge)nullable.ElementType : p.ReturnType;

            var minVariable = elementType.ToString() switch
            {
                "int" => VariableCreator.GlobalVariable(p, Int, int.MaxValue),
                "long" => VariableCreator.GlobalVariable(p, Long, long.MaxValue),
                "float" => VariableCreator.GlobalVariable(p, Float, float.MaxValue),
                "double" => VariableCreator.GlobalVariable(p, Double, double.MaxValue),
                "decimal" => VariableCreator.GlobalVariable(p, Decimal, decimal.MaxValue),
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