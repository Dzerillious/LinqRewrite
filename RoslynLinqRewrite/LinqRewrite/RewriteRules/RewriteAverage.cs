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
            var selectionValue = args.Length switch
            {
                0 => p.LastValue,
                1 => args[0].Inline(p, p.LastValue)
            };
            
            var elementType = selectionValue.Type is NullableTypeSyntax nullable2
                ? (TypeBridge)nullable2.ElementType : p.ReturnType;;
            var sumVariable = p.GlobalVariable(elementType, 0);

            if (p.ReturnType.Type is NullableTypeSyntax) CalculateNullableAverage(p, elementType, selectionValue, sumVariable);
            else CalculateSimpleAverage(p, selectionValue, sumVariable);
            
        }

        private static void CalculateNullableAverage(RewriteParameters p, TypeBridge elementType, TypedValueBridge selectionValue, LocalVariable sumVariable)
        {
            var inlinedValue = selectionValue.Reusable(p);
            p.ForAdd(If(inlinedValue.IsEqual(null), Continue()));
            p.ForAdd(sumVariable.AddAssign(inlinedValue.Cast(elementType)));
            p.Indexer = null;

            if (p.Unchecked) p.ResultAdd(sumVariable.Cast(p.ReturnType.Type) / p.Indexer);
            else p.ResultAdd(Return(SyntaxFactory.ConditionalExpression(p.Indexer.IsEqual(0),
                Null, sumVariable.Cast(p.ReturnType.Type) / p.Indexer)));
        }

        private static void CalculateSimpleAverage(RewriteParameters p, TypedValueBridge selectionValue, LocalVariable sumVariable)
        {
            if (!p.AssertResultSizeGreaterEqual(1)) return;
            p.ForAdd(sumVariable.AddAssign(selectionValue));
            p.ResultAdd(Return(sumVariable / p.CalculatedResultsSize));
        }
    }
}