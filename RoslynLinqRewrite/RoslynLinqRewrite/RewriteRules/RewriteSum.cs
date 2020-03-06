using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.VariableExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSum
    {
        public static void Rewrite(RewriteParameters p, ExpressionSyntax[] args)
        {
            if (p.Body == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<ExpressionSyntax>());

            var isNullable = p.ReturnType is NullableTypeSyntax;
            var elementType = isNullable ? ((NullableTypeSyntax)p.ReturnType).ElementType : p.ReturnType;
            var sumVariable = p.GlobalVariable(elementType, "__sum", 0);

            if (args.Length == 0)
                p.ForAdd(sumVariable.AddAssign(p.Last.Value));
            else if (isNullable)
            {
                var inlined = args[0].Inline(p, p.Last).Reusable(p);
                p.ForAdd(If(inlined.NotEqual(Null),
                    sumVariable.AddAssign(inlined)));
            }
            else p.ForAdd(sumVariable.AddAssign(args[0].Inline(p, p.Last)));
            
            p.FinalAdd(Return(sumVariable));
            p.HasResultMethod = true;
        }
    }
}