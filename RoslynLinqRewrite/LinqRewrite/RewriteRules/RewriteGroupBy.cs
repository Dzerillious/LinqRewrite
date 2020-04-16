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
            RewrittenValueBridge keySelector = args[0];
            TypeSyntax keySelectorReturn = ((LambdaExpressionSyntax) args[0].OldVal).ReturnType(p).Type;
            var elementSelectorValue = args.Length switch
            {
                1 => p.LastValue,
                _ when args[1].OldVal.InvokableWith1Param(p) => args[1].Inline(p, p.LastValue),
                _ => p.LastValue
            };

            var lookupType = ParseTypeName($"SimpleLookup<{keySelectorReturn},{elementSelectorValue.Type}>");
            var lookupVariable = p.GlobalVariable(lookupType, args.Length switch
            {
                2 when !(args[1].OldVal.IsInvokable(p)) => New(lookupType, args[1]),
                3 when !(args[2].OldVal.IsInvokable(p)) => New(lookupType, args[2]),
                4 when !(args[3].OldVal.IsInvokable(p)) => New(lookupType, args[3]),
                _ => New(lookupType, ParseTypeName($"EqualityComparer<{keySelectorReturn}>").Access("Default"))
            });

            p.ForAdd(lookupVariable.Access("GetGrouping").Invoke(keySelector.Inline(p, p.LastValue), true)
                            .Access("Add").Invoke(elementSelectorValue));
            
            p.Iterators.ForEach(x => x.Complete = true);

            var rewritten = new RewrittenValueBridge(((LambdaExpressionSyntax)keySelector).ExpressionBody, lookupVariable);
            p.AddIterator(rewritten);
            var iGroupingType = ParseTypeName($"IGrouping<{keySelectorReturn},{elementSelectorValue.Type}>");
            RewriteCollectionEnumeration.RewriteOther(p, new CollectionValueBridge(p, lookupType, iGroupingType, lookupVariable, true));
            var elementsType = ParseTypeName($"IEnumerable<{elementSelectorValue.Type}>");
            
            var groupingType = ParseTypeName($"SimpleLookup<{keySelectorReturn},{elementSelectorValue.Type}>.Grouping");
            p.LastValue = new TypedValueBridge(groupingType, p.LastValue.Cast(groupingType));
            
            var key = new TypedValueBridge(keySelectorReturn, p.LastValue.Access("key"));
            var elements = new TypedValueBridge(elementsType, p.LastValue.Access("elements"));
            p.LastValue = args.Length switch
            {
                1 => p.LastValue,
                _ when !(args[1].OldVal.InvokableWith1Param(p)) => args[1].Inline(p, key, elements),
                2 => p.LastValue,
                _ => args[2].Inline(p, key, elements)
            };
            
            p.ModifiedEnumeration = true;
        }
    }
}