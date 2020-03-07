using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.VariableExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public class RewriteMax
    {
        public static void Rewrite(RewriteParameters p, ExpressionSyntax[] args)
        {
            if (p.Iterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<ExpressionSyntax>());

            var elementType = p.ReturnType.Type is NullableTypeSyntax nullable
                ? (TypeBridge)nullable.ElementType : p.ReturnType;
            
            VariableBridge maxVariable;
            if (elementType.ToString() == "int") maxVariable = p.GlobalVariable(Int, int.MinValue);
            else if (elementType.ToString() == "float") maxVariable = p.GlobalVariable(Float, float.MinValue);
            else if (elementType.ToString() == "double") maxVariable = p.GlobalVariable(VariableExtensions.Double, double.MinValue);
            else maxVariable = null;

            if (args.Length == 0)
            {
                var inlined = p.Last.Reusable(p);
                p.ForAdd(If(inlined > maxVariable,
                            maxVariable.Assign(inlined)));
            }
            else if (p.ReturnType.Type is NullableTypeSyntax)
            {
                var inlined = args[0].Inline(p, p.Last).Reusable(p);
                p.ForAdd(If(inlined.NotEqual(Null),
                            If(inlined > maxVariable,
                                maxVariable.Assign(inlined))));
            }
            else
            {
                var inlined = args[0].Inline(p, p.Last).Reusable(p);
                p.ForAdd(If(inlined > maxVariable,
                            maxVariable.Assign(inlined)));
            }
            
            p.FinalAdd(Return(maxVariable));
            p.HasResultMethod = true;
        }
    }
}