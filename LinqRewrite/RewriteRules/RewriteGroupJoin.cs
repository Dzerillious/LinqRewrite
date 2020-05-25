using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.VariableExtensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteGroupJoin
    {
        public static void Rewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            RewrittenValueBridge inner = args[0];
            RewrittenValueBridge outerKeySelector = args[1];
            RewrittenValueBridge innerKeySelector = args[2];
            RewrittenValueBridge resultSelector = args[3];
            RewrittenValueBridge comparer = args.Length == 5 ? args[4] : null;

            var lookupType = ParseTypeName($"LinqRewrite.Core.SimpleLookup<{inner.ItemType(design)},{innerKeySelector.ReturnType(design)}>");
            var lookupVariable = CreateGlobalVariable(design, lookupType, lookupType.Access("CreateForJoin")
                .Invoke(inner, innerKeySelector, comparer));

            var lookupItemType = ParseTypeName($"System.Collections.IEnumerable<{inner.ItemType(design)}>");
            design.LastValue = resultSelector.Inline(design, design.LastValue, new TypedValueBridge(lookupItemType, lookupVariable[outerKeySelector.Inline(design, design.LastValue)]));
            
            design.ListEnumeration = false;
            design.ModifiedEnumeration = true;
        }
    }
}