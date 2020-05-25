using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteGroupJoin
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            RewrittenValueBridge inner = args[0];
            RewrittenValueBridge outerKeySelector = args[1];
            RewrittenValueBridge innerKeySelector = args[2];
            RewrittenValueBridge resultSelector = args[3];
            RewrittenValueBridge comparer = args.Length == 5 ? args[4] : null;

            var lookupType = ParseTypeName($"LinqRewrite.Core.SimpleLookup<{inner.ItemType(p)},{innerKeySelector.ReturnType(p)}>");
            var lookupVariable = VariableCreator.GlobalVariable(p, lookupType, lookupType.Access("CreateForJoin")
                .Invoke(inner, innerKeySelector, comparer));

            var lookupItemType = ParseTypeName($"System.Collections.IEnumerable<{inner.ItemType(p)}>");
            p.LastValue = resultSelector.Inline(p, p.LastValue, new TypedValueBridge(lookupItemType, lookupVariable[outerKeySelector.Inline(p, p.LastValue)]));
            
            p.ListEnumeration = false;
            p.ModifiedEnumeration = true;
        }
    }
}