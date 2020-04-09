using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteGroupJoin
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            var inner = args[0];
            var outerKeySelector = (LambdaExpressionSyntax)args[1];
            var innerKeySelector = (LambdaExpressionSyntax)args[2];
            var resultSelector = args[3];
            var comparer = args.Length == 5 ? args[4] : null;

            var lookupType = ParseTypeName($"SimpleLookup<{inner.ItemType(p).Type},{innerKeySelector.ReturnType(p).Type}>");
            var lookupVariable = p.GlobalVariable(lookupType, lookupType.Access("CreateForJoin")
                .Invoke(inner, innerKeySelector, comparer));

            var lookupItemType = ParseTypeName($"IEnumerable<{inner.ItemType(p).Type}>");
            p.LastValue = resultSelector.Inline(p, p.LastValue, new TypedValueBridge(lookupItemType, lookupVariable[outerKeySelector.Inline(p, p.LastValue)]));
            
            p.ModifiedEnumeration = true;
        }
    }
}