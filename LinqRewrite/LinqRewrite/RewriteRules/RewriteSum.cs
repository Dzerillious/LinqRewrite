using System.Linq;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.ExpressionSimplifier;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSum
    {
        public static ExpressionSyntax SimpleRewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (args.Length != 0) return null;
            if (!TryGetInt(p.ResultSize, out var intSize) || intSize > 10)
                return null;

            var items = Enumerable.Range(0, intSize).Select(x
                => new TypedValueBridge(p.LastValue.Type, SimplifySubstitute(p.LastValue, p.CurrentIterator.ForIndexer, p.CurrentMin + x)));
            var simple = items.Aggregate((x, y) => new TypedValueBridge(p.LastValue.Type, x + y));  
            return simple.Simplify();
        }
        
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            var elementType = p.ReturnType.Type is NullableTypeSyntax nullable
                ? (TypeBridge)nullable.ElementType : p.ReturnType;
            var sumVariable = VariableCreator.GlobalVariable(p, elementType, 0);
            
            var value = args.Length switch
            {
                0 => p.LastValue,
                1 => args[0].Inline(p, p.LastValue)
            };
            if (p.ReturnType.Type is NullableTypeSyntax)
            {
                value = value.Reusable(p);
                p.ForAdd(If(value.NotEqual(null),
                            sumVariable.AddAssign(value.Cast(elementType))));
            }
            else p.ForAdd(sumVariable.AddAssign(value));
            p.ResultAdd(Return(sumVariable));
        }
    }
}