using System.Linq;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.AssertionExtension;
using static LinqRewrite.Extensions.ExpressionSimplifier;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteAverage
    {
        public static ExpressionSyntax SimpleRewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            if (args.Length != 0) return null;
            if (!TryGetInt(design.ResultSize, out var intSize) || intSize > Constants.SimpleRewriteMaxMediumElements)
                return null;

            var items = Enumerable.Range(0, intSize)
                .Select(x => new TypedValueBridge(design.LastValue.Type, Substitute(design.LastValue, design.CurrentIterator.ForIndexer, design.CurrentMin + x)));
            return Parenthesize(items.Aggregate((x, y) => new TypedValueBridge(design.LastValue.Type, x + y))).Div(intSize);
        }
        
        public static void Rewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            var selectionValue = args.Length switch
            {
                0 => design.LastValue,
                1 => args[0].Inline(design, design.LastValue)
            };
            
            var elementType = selectionValue.Type is NullableTypeSyntax nullable2
                ? (TypeBridge)nullable2.ElementType : design.ReturnType;;
            var sumVariable = CreateGlobalVariable(design, elementType, 0);

            if (design.ReturnType.Type is NullableTypeSyntax) CalculateNullableAverage(design, elementType, selectionValue, sumVariable);
            else CalculateSimpleAverage(design, selectionValue, sumVariable);
            
        }

        private static void CalculateNullableAverage(RewriteDesign design, TypeBridge elementType, TypedValueBridge selectionValue, LocalVariable sumVariable)
        {
            var inlinedValue = selectionValue.Reusable(design);
            design.ForAdd(If(inlinedValue.IsEqual(null), Continue()));
            design.ForAdd(sumVariable.AddAssign(inlinedValue.Cast(elementType)));
            design.Indexer = null;

            if (design.Unchecked) design.ResultAdd(sumVariable.Cast(design.ReturnType.Type) / design.Indexer);
            else design.ResultAdd(Return(SyntaxFactory.ConditionalExpression(design.Indexer.IsEqual(0),
                Null, sumVariable.Cast(design.ReturnType.Type) / design.Indexer)));
        }

        private static void CalculateSimpleAverage(RewriteDesign design, TypedValueBridge selectionValue, LocalVariable sumVariable)
        {
            if (!AssertResultSizeGreaterEqual(design, 1)) return;
            design.ForAdd(sumVariable.AddAssign(selectionValue));
            design.ResultAdd(Return(sumVariable / design.GetResultSize()));
        }
    }
}