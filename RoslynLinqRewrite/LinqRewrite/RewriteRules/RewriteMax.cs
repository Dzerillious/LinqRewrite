using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
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
                "long" => p.GlobalVariable(Long, long.MinValue),
                "float" => p.GlobalVariable(Float, float.MinValue),
                "double" => p.GlobalVariable(VariableExtensions.Double, double.MinValue),
                "decimal" => p.GlobalVariable(VariableExtensions.Decimal, decimal.MinValue),
                _ => null
            };
            var foundVariable = p.GlobalVariable(Bool, false);
            
            var value = args.Length switch
            {
                0 => p.LastValue.Reusable(p),
                1 => args[0].Inline(p, p.LastValue).Reusable(p)
            };
            if (p.ReturnType.Type is NullableTypeSyntax)
            {
                p.ForAdd(If(value.IsEqual(null).Or(value <= maxVariable), Continue()));
                p.ForAdd(maxVariable.Assign(value.Cast(elementType)));
                p.ForAdd(foundVariable.Assign(true));
            }
            else
            {
                p.ForAdd(If(value <= maxVariable, Continue()));
                p.ForAdd(maxVariable.Assign(value));
                p.ForAdd(foundVariable.Assign(true));
            }
            
            p.ResultAdd(If(Not(foundVariable), Throw("System.InvalidOperationException", "Sequence does not contains any elements")));
            p.ResultAdd(Return(maxVariable));
        }
    }
}