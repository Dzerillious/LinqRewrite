using System.Linq;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.ExpressionSimplifier;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSum
    {
        public static ExpressionSyntax SimpleRewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            if (args.Length != 0) return null;
            if (!TryGetInt(design.ResultSize, out var intSize) || intSize > Constants.SimpleRewriteMaxMediumElements)
                return null;

            var items = Enumerable.Range(0, intSize).Select(i
                => new TypedValueBridge(design.LastValue.Type, Substitute(design.LastValue, design.CurrentIterator.ForIndexer, design.CurrentMin + i)));
            return items.Aggregate((x, y) => new TypedValueBridge(design.LastValue.Type, x + y));
        }
        
        public static void Rewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            var elementType = design.ReturnType.Type is NullableTypeSyntax nullable
                ? (TypeBridge)nullable.ElementType : design.ReturnType;
            var sumVariable = CreateGlobalVariable(design, elementType, 0);
            
            var value = args.Length switch
            {
                0 => design.LastValue,
                1 => args[0].Inline(design, design.LastValue)
            };
            if (design.ReturnType.Type is NullableTypeSyntax)
            {
                value = value.Reusable(design);
                design.ForAdd(If(value.NotEqual(null),
                            sumVariable.AddAssign(value.Cast(elementType))));
            }
            else design.ForAdd(sumVariable.AddAssign(value));
            design.ResultAdd(Return(sumVariable));
        }
    }
}