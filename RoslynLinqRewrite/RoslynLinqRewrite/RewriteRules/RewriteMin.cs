using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.VariableExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public class RewriteMin
    {
        public static void Rewrite(RewriteParameters p, ExpressionSyntax[] args)
        {
            if (p.Body == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<ExpressionSyntax>());

            var isNullable = p.ReturnType is NullableTypeSyntax;
            var elementType = isNullable ? ((NullableTypeSyntax)p.ReturnType).ElementType : p.ReturnType;
            
            VariableBridge minVariable;
            if (elementType.ToString() == "int") minVariable = p.GlobalVariable(Int, "__min", int.MaxValue);
            else if (elementType.ToString() == "float") minVariable = p.GlobalVariable(Float, "__min", float.MaxValue);
            else if (elementType.ToString() == "double") minVariable = p.GlobalVariable(VariableExtensions.Double, "__min", double.MaxValue);
            else minVariable = null;

            if (args.Length == 0)
            {
                var inlined = p.Last.Reusable(p);
                p.ForAdd(If(inlined < minVariable,
                            minVariable.Assign(inlined)));
            }
            else if (isNullable)
            {
                var inlined = args[0].Inline(p, p.Last).Reusable(p);
                p.ForAdd(If(inlined.NotEqual(Null),
                            If(inlined < minVariable,
                                minVariable.Assign(inlined))));
            }
            else
            {
                var inlined = args[0].Inline(p, p.Last).Reusable(p);
                p.ForAdd(If(inlined < minVariable,
                            minVariable.Assign(inlined)));
            }
            
            p.FinalAdd(Return(minVariable));
            p.HasResultMethod = true;
        }
    }
}