using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteGroupBy
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            var keySelector = (LambdaExpressionSyntax)args[0];
            
            var elementSelectorValue = args.Length switch
            {
                1 => p.LastValue,
                _ when args[1].OldVal is SimpleLambdaExpressionSyntax => args[1].Inline(p, p.LastValue),
                _ => p.LastValue
            };

            var lookupType = ParseTypeName($"InternalLookup<{keySelector.ReturnType(p).Type},{elementSelectorValue.Type}>");
            var lookupVariable = p.GlobalVariable(lookupType, args.Length switch
            {
                2 when !(args[1].OldVal is LambdaExpressionSyntax) => New(lookupType, args[1]),
                3 when !(args[2].OldVal is LambdaExpressionSyntax) => New(lookupType, args[2]),
                4 when !(args[3].OldVal is LambdaExpressionSyntax) => New(lookupType, args[3]),
                _ => New(lookupType)
            });

            p.ForAdd(lookupVariable.Access("GetGrouping").Invoke(keySelector.Inline(p, p.LastValue), true)
                            .Access("Add").Invoke(elementSelectorValue));
            
            p.Iterators.ForEach(x => x.Complete = true);

            var rewritten = new RewrittenValueBridge(keySelector.ExpressionBody, lookupVariable);
            p.AddIterator(rewritten);
            var iGroupingType = ParseTypeName($"IGrouping<{keySelector.ReturnType(p).Type},{elementSelectorValue.Type}>");
            RewriteCollectionEnumeration.RewriteOther(p, new CollectionValueBridge(iGroupingType, lookupType, null, lookupVariable));
            var elementsType = ParseTypeName($"IEnumerable<{elementSelectorValue.Type}>");
            
            var groupingType = ParseTypeName($"InternalLookup<{keySelector.ReturnType(p).Type},{elementSelectorValue.Type}>.Grouping");
            p.LastValue = new TypedValueBridge(groupingType, p.LastValue.Cast(groupingType)).Reusable(p);
            
            var key = new TypedValueBridge(keySelector.ReturnType(p), p.LastValue.Access("key"));
            var elements = new TypedValueBridge(elementsType, p.LastValue.Access("elements"));
            p.LastValue = p.GlobalVariable(lookupType, args.Length switch
            {
                1 => p.LastValue,
                _ when !(args[1].OldVal is SimpleLambdaExpressionSyntax) => args[1].Inline(p, key, elements),
                2 => p.LastValue,
                _ => args[1].Inline(p, key, elements)
            });
            
            p.ModifiedEnumeration = true;
        }
    }
}