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
    public static class RewriteJoin
    {
        // private static IEnumerable<int> JoinIterator(
        //     IEnumerable<int> outer,
        //     IEnumerable<int> inner,
        //     Func<int, int> outerKeySelector,
        //     Func<int, int> innerKeySelector,
        //     Func<int, int, int> resultSelector)
        // {
        //     InternalLookup<int, int> lookup = InternalLookup<int, int>.CreateForJoin(inner, innerKeySelector, EqualityComparer<int>.Default);
        //     foreach (int outer1 in outer)
        //     {
        //         int item = outer1;
        //         InternalLookup<int, int>.Grouping g = lookup.GetGrouping(outerKeySelector(item), false);
        //         if (g == null) continue;
        //         
        //         for (int i = 0; i < g.count; ++i)
        //             yield return resultSelector(item, g.elements[i]);
        //     }
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
                .Invoke(inner, innerKeySelector,
                    args.Length == 5 ? args[4] : null));

            var itemVariable = p.LastValue;
            var groupingType = ParseTypeName($"InternalLookup<{inner.ItemType(p).Type},{outerKeySelector.ReturnType(p).Type}>.Grouping");
            var groupingVariable = p.GlobalVariable(groupingType);
            p.ForAdd(groupingVariable.Assign(lookupVariable.Access("GetGrouping")
                .Invoke(outerKeySelector.Inline(p, itemVariable), false)));
            
            p.ForAdd(If(groupingVariable.IsEqual(null), Continue()));
            
            var rewritten = new RewrittenValueBridge(innerKeySelector.ExpressionBody, groupingVariable);

            var newIterator = new IteratorParameters(p, rewritten);
            p.CurrentIterator.ForBody.Add(newIterator);
            p.Iterators.Add(newIterator);
            p.Iterators.Remove(p.CurrentIterator);
            p.CurrentIterator = newIterator;
                
            GroupingEnumeration(p, new CollectionValueBridge(inner.ItemType(p), groupingType, groupingVariable.Access("count"), rewritten));
            
            p.LastValue = resultSelector.Inline(p, itemVariable, p.LastValue);
            p.ModifiedEnumeration = true;
        }

        public static void GroupingEnumeration(RewriteParameters p, CollectionValueBridge collection)
        {
            p.ForMin = p.ForReMin = 0;
            p.ForMax = collection.Count;
            p.ForReMax = collection.Count - 1;

            p.CurrentIterator.ForIndexer = p.LocalVariable(Int);
            if (p.CurrentIndexer == null)
            {
                p.CurrentIterator.CurrentIndexer = p.CurrentIterator.ForIndexer;
                p.CurrentIterator.CurrentIndexer.IsGlobal = true;
            }
            
            p.LastValue = new TypedValueBridge(collection.ItemType, ((ValueBridge)collection.Access("elements"))[p.Indexer]);

            p.ResultSize = null;
            p.SourceSize *= collection.Count;
            p.ListEnumeration = true;
        }
    }
}