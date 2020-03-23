using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
            
            var selectionValue = args.Length switch
            {
                0 => p.LastValue,
                1 => args[0].Inline(p, p.LastValue)
            };
            if (p.ReturnType.Type is NullableTypeSyntax)
            {
                var inlinedValue = selectionValue.ReusableConst(p);
                p.ForAdd(If(inlinedValue.NotEqual(null),
                            sumVariable.AddAssign(inlinedValue)));
            }
            else
            {
                p.ForAdd(sumVariable.AddAssign(selectionValue));
            }

            p.FinalAdd(Return(p.ResultSize == null
                ? sumVariable / p.Indexer
                : sumVariable / p.ResultSize));
        }
    }
}