using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.VariableExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteAverage
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());

            var elementType = p.ReturnType.Type is NullableTypeSyntax nullable
                ? (TypeBridge)nullable.ElementType : p.ReturnType;
            var sumVariable = p.GlobalVariable(elementType, 0);

            if (args.Length == 0)
            {
                p.ForAdd(sumVariable.AddAssign(p.LastValue.Value));
            }
            else if (p.ReturnType.Type is NullableTypeSyntax)
            {
                var inlined = args[0].Inline(p, p.LastValue).ReusableConst(p);
                p.ForAdd(If(inlined.NotEqual(null),
                            sumVariable.AddAssign(inlined)));
            }
            else
            {
                p.ForAdd(sumVariable.AddAssign(args[0].Inline(p, p.LastValue)));
            }

            p.FinalAdd(Return(p.ResultSize == null
                ? sumVariable / p.Indexer
                : sumVariable / p.ResultSize));

            p.HasResultMethod = true;
        }
    }
}