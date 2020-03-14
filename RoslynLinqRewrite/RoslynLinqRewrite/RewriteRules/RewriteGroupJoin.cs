using System;
using System.Collections.Generic;
using System.Linq;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteGroupJoin
    {
        // private static IEnumerable<TResult> GroupJoinIterator<TOuter, TInner, TKey, TResult>(
        //     IEnumerable<TOuter> outer,
        //     IEnumerable<TInner> inner,
        //     Func<TOuter, TKey> outerKeySelector,
        //     Func<TInner, TKey> innerKeySelector,
        //     Func<TOuter, IEnumerable<TInner>, TResult> resultSelector,
        //     IEqualityComparer<TKey> comparer)
        // {
        //     Lookup<TKey, TInner> lookup = Lookup<TKey, TInner>.CreateForJoin(inner, innerKeySelector, comparer);
        //     foreach (TOuter outer1 in outer)
        //         yield return resultSelector(outer1, lookup[outerKeySelector(outer1)]);
        // }

        // private static IEnumerable<TResult> GroupJoinIterator<TOuter, TInner, TKey, TResult>(
        //     IEnumerable<TOuter> outer,
        //     IEnumerable<TInner> inner,
        //     Func<TOuter, TKey> outerKeySelector,
        //     Func<TInner, TKey> innerKeySelector,
        //     Func<TOuter, IEnumerable<TInner>, TResult> resultSelector,
        //     IEqualityComparer<TKey> comparer)
        // {
        //     Lookup<TKey, TInner> lookup = Lookup<TKey, TInner>.CreateForJoin(inner, innerKeySelector, comparer);
        //     foreach (TOuter outer1 in outer)
        //         yield return resultSelector(outer1, lookup[outerKeySelector(outer1)]);
        // }
        
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            var inner = args[0];
            var outerKeySelector = (LambdaExpressionSyntax)args[1];
            var innerKeySelector = (LambdaExpressionSyntax)args[2];
            var resultSelector = args[3];

            var lookupType = ParseTypeName($"InternalLookup<{inner.ItemType(p).Type},{innerKeySelector.ReturnType(p).Type}>");
            var lookupVariable = p.GlobalVariable(lookupType, lookupType.Access("CreateForJoin")
                .Invoke(inner, innerKeySelector, args.Length == 5 ? args[4] : null));

            var lookupItemType = ParseTypeName($"IEnumerable<{inner.ItemType(p).Type}>");
            p.LastValue = resultSelector.Inline(p, p.LastValue, new TypedValueBridge(lookupItemType, lookupVariable[outerKeySelector.Inline(p, p.LastValue)]));
            
            p.ModifiedEnumeration = true;
        }
    }
}