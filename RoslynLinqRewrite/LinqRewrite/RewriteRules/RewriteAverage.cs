using System;
using System.Linq.Expressions;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteAverage
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            
            var selectionValue = args.Length switch
            {
                0 => p.LastValue,
                1 => args[0].Inline(p, p.LastValue)
            };
            
            var elementType = selectionValue.Type is NullableTypeSyntax nullable2
                ? (TypeBridge)nullable2.ElementType : p.ReturnType;;
            var sumVariable = p.GlobalVariable(elementType, 0);
            
            if (p.ReturnType.Type is NullableTypeSyntax)
            {
                var inlinedValue = selectionValue.ReusableConst(p);
                p.ForAdd(If(inlinedValue.IsEqual(null), Continue()));
                p.ForAdd(sumVariable.AddAssign(inlinedValue.Cast(elementType)));
                p.Indexer = null;
                
                p.FinalAdd(Return(SyntaxFactory.ConditionalExpression(p.Indexer.IsEqual(0),
                    Null, sumVariable.Cast(p.ReturnType.Type) / p.Indexer)));
            }
            else
            {
                p.ForAdd(sumVariable.AddAssign(selectionValue));
                
                p.FinalAdd(Return(p.ResultSize == null
                    ? sumVariable / p.Indexer
                    : sumVariable / p.ResultSize));
            }
        }
    }
}