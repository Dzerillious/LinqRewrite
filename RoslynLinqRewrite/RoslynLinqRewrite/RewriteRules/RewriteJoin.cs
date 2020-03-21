using System;
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
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            var innerValue = args[0];
            var outerKeySelector = (LambdaExpressionSyntax)args[1];
            var innerKeySelector = (LambdaExpressionSyntax)args[2];
            var resultSelectorValue = args[3];
            var comparerValue = args.Length == 5 ? args[4] : null;

            var lookupType = ParseTypeName($"SimpleLookup<{innerValue.ItemType(p).Type},{innerKeySelector.ReturnType(p).Type}>");
            var lookupVariable = p.GlobalVariable(lookupType, lookupType.Access("CreateForJoin")
                .Invoke(innerValue, innerKeySelector, comparerValue));

            var itemValue = p.LastValue;
            var groupingType = ParseTypeName($"SimpleLookup<{innerValue.ItemType(p).Type},{outerKeySelector.ReturnType(p).Type}>.Grouping");
            var groupingVariable = p.GlobalVariable(groupingType);
            p.ForAdd(groupingVariable.Assign(lookupVariable.Access("GetGrouping")
                .Invoke(outerKeySelector.Inline(p, itemValue), false)));
            
            p.ForAdd(If(groupingVariable.IsEqual(null), Continue()));
            
            var rewritten = new RewrittenValueBridge(innerKeySelector.ExpressionBody, groupingVariable);

            var newIterator = new IteratorParameters(p, rewritten);
            p.CurrentIterator.ForBody.Add(newIterator);
            p.Iterators.Add(newIterator);
            p.Iterators.Remove(p.CurrentIterator);
            p.CurrentIterator = newIterator;
                
            GroupingEnumeration(p, new CollectionValueBridge(innerValue.ItemType(p), groupingType, groupingVariable.Access("count"), rewritten));
            
            p.LastValue = resultSelectorValue.Inline(p, itemValue, p.LastValue);
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