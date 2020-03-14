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
    public static class RewriteGroupBy
    {
        // IEnumerable<TSource> source,
        //     Func<TSource, TKey> keySelector,
        // Func<TSource, TElement> elementSelector,
        //     Func<TKey, IEnumerable<TElement>, TResult> resultSelector,
        // IEqualityComparer<TKey> comparer)
        
        // Lookup<TKey, TElement> lookup = new Lookup<TKey, TElement>(comparer);
        //     foreach (TSource source1 in source)
        // lookup.GetGrouping(keySelector(source1), true).Add(elementSelector(source1));
        //     return lookup;
        
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            var keySelector = (LambdaExpressionSyntax)args[0];
            var elementSelector = args.Length >= 2 && args[1].Old.Value is SimpleLambdaExpressionSyntax ? args[1].Inline(p, p.LastValue) : p.LastValue;

            var lookupType = ParseTypeName($"InternalLookup<{keySelector.ReturnType(p).Type},{elementSelector.Type}>");
            var lookupVariable = args.Length switch
            {
                2 when !(args[1].Old.Value is LambdaExpressionSyntax) => p.GlobalVariable(lookupType, New(lookupType, args[1])),
                3 when !(args[2].Old.Value is LambdaExpressionSyntax) => p.GlobalVariable(lookupType, New(lookupType, args[2])),
                4 when !(args[3].Old.Value is LambdaExpressionSyntax) => p.GlobalVariable(lookupType, New(lookupType, args[3])),
                _ => p.GlobalVariable(lookupType, New(lookupType))
            };

            p.ForAdd(lookupVariable.Access("GetGrouping").Invoke(keySelector.Inline(p, p.LastValue), true)
                            .Access("Add").Invoke(elementSelector));
            
            p.Iterators.ForEach(x => x.Complete = true);

            var rewritten = new RewrittenValueBridge(keySelector.ExpressionBody, lookupVariable);
            p.AddIterator(rewritten);
            var iGroupingType = ParseTypeName($"IGrouping<{keySelector.ReturnType(p).Type},{elementSelector.Type}>");
            RewriteCollectionEnumeration.RewriteOther(p, new CollectionValueBridge(iGroupingType, lookupType, null, lookupVariable));
            var elementsType = ParseTypeName($"IEnumerable<{elementSelector.Type}>");
            
            var groupingType = ParseTypeName($"InternalLookup<{keySelector.ReturnType(p).Type},{elementSelector.Type}>.Grouping");
            p.LastValue = new TypedValueBridge(groupingType, p.LastValue.Cast(groupingType)).Reusable(p);
            
            if (args.Length >= 2 && !(args[1].Old.Value is SimpleLambdaExpressionSyntax))
                p.LastValue = args[1].Inline(p, new TypedValueBridge(keySelector.ReturnType(p), p.LastValue.Access("key")), 
                    new TypedValueBridge(elementsType, p.LastValue.Access("elements")));
            else if (args.Length >= 3)
                p.LastValue = args[2].Inline(p, new TypedValueBridge(keySelector.ReturnType(p), p.LastValue.Access("key")), 
                    new TypedValueBridge(elementsType, p.LastValue.Access("elements")));
            
            p.ModifiedEnumeration = true;
        }
    }
}