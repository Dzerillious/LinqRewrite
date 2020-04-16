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
            TypeSyntax outerReturnType = ((LambdaExpressionSyntax) outerKeySelector.Old).ReturnType(p).Type;
            
            RewrittenValueBridge innerKeySelector = args[2];
            TypeSyntax innerReturnType = ((LambdaExpressionSyntax) innerKeySelector.Old).ReturnType(p).Type;
            
            var resultSelectorValue = args[3];
            var comparerValue = args.Length == 5 ? args[4] : null;

            var lookupType = ParseTypeName($"LinqRewrite.Core.SimpleLookup<{innerValue.ItemType(p).Type},{innerReturnType}>");
            var lookupVariable = p.GlobalVariable(lookupType, lookupType.Access("CreateForJoin")
                .Invoke(innerValue, innerKeySelector, comparerValue));

            var itemValue = p.LastValue;
            var groupingType = ParseTypeName($"LinqRewrite.Core.SimpleLookup<{innerValue.ItemType(p).Type},{outerReturnType}>.Grouping");
            var groupingVariable = p.GlobalVariable(groupingType);
            p.ForAdd(groupingVariable.Assign(lookupVariable.Access("GetGrouping")
                .Invoke(outerKeySelector.Inline(p, itemValue), false)));
            
            p.ForAdd(If(groupingVariable.IsEqual(null), Continue()));
            var rewritten = new RewrittenValueBridge(((LambdaExpressionSyntax) innerKeySelector.Old).ExpressionBody, groupingVariable);

            var iterator = p.GlobalVariable(innerReturnType);
            p.Iterators.Where(x => !x.Complete).ToArray().ForEach(x =>
            {
                var newIterator = new IteratorParameters(p, rewritten);
                x.ForBody.Add(newIterator);
                p.Iterators.Add(newIterator);
                p.Iterators.Remove(x);
                p.CurrentIterator = newIterator;
                RewriteCollectionEnumeration.RewriteOther(p, new CollectionValueBridge(p, groupingType, innerReturnType, rewritten, true), iterator);
            });

            p.CurrentIterator = p.Iterators.Last();
            p.LastValue = resultSelectorValue.Inline(p, itemValue, p.LastValue);
            p.ModifiedEnumeration = true;
        }
    }
}