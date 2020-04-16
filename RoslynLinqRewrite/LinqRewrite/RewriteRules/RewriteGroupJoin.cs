using System.Collections.Generic;
using System.Linq;
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
            RewrittenValueBridge inner = args[0];
            RewrittenValueBridge outerKeySelector = args[1];
            RewrittenValueBridge innerKeySelector = args[2];
            RewrittenValueBridge resultSelector = args[3];
            RewrittenValueBridge comparer = args.Length == 5 ? args[4] : null;

            var lookupType = ParseTypeName($"LinqRewrite.Core.SimpleLookup<{inner.Old.ItemType(p).Type},{((LambdaExpressionSyntax)innerKeySelector.Old).ReturnType(p).Type}>");
            var lookupVariable = p.GlobalVariable(lookupType, lookupType.Access("CreateForJoin")
                .Invoke(inner, innerKeySelector, comparer));

            var lookupItemType = ParseTypeName($"System.Collections.IEnumerable<{inner.Old.ItemType(p).Type}>");
            p.LastValue = resultSelector.Inline(p, p.LastValue, new TypedValueBridge(lookupItemType, lookupVariable[outerKeySelector.Inline(p, p.LastValue)]));
            
            p.ModifiedEnumeration = true;
        }
    }
}