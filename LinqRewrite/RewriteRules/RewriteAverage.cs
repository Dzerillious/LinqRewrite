using System.Linq;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.ExpressionSimplifier;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteAverage
    {
        public static ExpressionSyntax SimpleRewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (args.Length != 0) return null;
            if (!TryGetInt(p.ResultSize, out var intSize) || intSize > 10)
                return null;

            var items = Enumerable.Range(0, intSize).Select(x
                => new TypedValueBridge(p.LastValue.Type, SimplifySubstitute(p.LastValue, p.CurrentIterator.ForIndexer, p.CurrentMin + x)));
            return Parenthesize(items.Aggregate((x, y) => new TypedValueBridge(p.LastValue.Type, x + y))).Div(intSize);
        }
        
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            var selectionValue = args.Length switch
            {
                0 => p.LastValue,
                1 => args[0].Inline(p, p.LastValue)
            };
            
            var elementType = selectionValue.Type is NullableTypeSyntax nullable2
                ? (TypeBridge)nullable2.ElementType : p.ReturnType;;
            var sumVariable = VariableCreator.GlobalVariable(p, elementType, 0);

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
            if (!AssertionExtension.AssertResultSizeGreaterEqual(p, 1)) return;
            p.ForAdd(sumVariable.AddAssign(selectionValue));
            p.ResultAdd(Return(sumVariable / p.GetResultSize()));
        }
    }
}