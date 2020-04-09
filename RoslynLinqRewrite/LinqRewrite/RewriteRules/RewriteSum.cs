using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSum
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            var elementType = p.ReturnType.Type is NullableTypeSyntax nullable
                ? (TypeBridge)nullable.ElementType : p.ReturnType;
            var sumVariable = p.GlobalVariable(elementType, 0);
            
            var value = args.Length switch
            {
                0 => p.LastValue,
                1 => args[0].Inline(p, p.LastValue).Reusable(p)
            };
            if (p.ReturnType.Type is NullableTypeSyntax)
            {
                p.ForAdd(If(value.NotEqual(null),
                            sumVariable.AddAssign(value)));
            }
            else p.ForAdd(sumVariable.AddAssign(value));
            
            p.ResultAdd(Return(sumVariable));
        }
    }
}