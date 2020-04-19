using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteJoin
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            var innerValue = args[0];
            RewrittenValueBridge outerKeySelector = args[1];
            RewrittenValueBridge innerKeySelector = args[2];
            
            var resultSelectorValue = args[3];
            var comparerValue = args.Length == 5 ? args[4] : null;

            var lookupType = ParseTypeName($"LinqRewrite.Core.SimpleLookup<{innerValue.ItemType(p)},{innerKeySelector.ReturnType(p)}>");
            var lookupVariable = p.GlobalVariable(lookupType, lookupType.Access("CreateForJoin")
                .Invoke(innerValue, innerKeySelector, comparerValue));

            var itemValue = p.LastValue;
            var groupingType = ParseTypeName($"LinqRewrite.Core.SimpleLookup<{innerValue.ItemType(p)},{outerKeySelector.ReturnType(p)}>.Grouping");
            var groupingVariable = p.GlobalVariable(groupingType);
            p.ForAdd(groupingVariable.Assign(lookupVariable.Access("GetGrouping")
                .Invoke(outerKeySelector.Inline(p, itemValue), false)));
            
            p.ForAdd(If(groupingVariable.IsEqual(null), Continue()));
            var rewritten = new RewrittenValueBridge(((LambdaExpressionSyntax) innerKeySelector.Old).ExpressionBody, groupingVariable);

            var iterator = p.GlobalVariable(innerKeySelector.ReturnType(p));
            p.Iterators.Where(x => !x.Complete).ToArray().ForEach(x =>
            {
                var newIterator = new IteratorParameters(p, new CollectionValueBridge(p, groupingType, innerKeySelector.ReturnType(p), rewritten, true));
                x.ForBody.Add(newIterator);
                p.Iterators.Add(newIterator);
                p.Iterators.Remove(x);
                p.CurrentIterator = newIterator;
                RewriteCollectionEnumeration.RewriteOther(p, p.CurrentIterator.Collection, iterator);
            });

            p.CurrentIterator = p.Iterators.Last();
            p.LastValue = resultSelectorValue.Inline(p, itemValue, p.LastValue);
            p.ListEnumeration = false;
            p.ModifiedEnumeration = true;
            p.SourceSize = null;
        }
    }
}