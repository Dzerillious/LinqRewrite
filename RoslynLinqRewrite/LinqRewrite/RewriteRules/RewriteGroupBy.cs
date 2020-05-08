using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteGroupBy
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            RewrittenValueBridge keySelector = args[0];
            var elementSelectorValue = args.Length switch
            {
                1 => p.LastValue,
                _ when args[1].OldVal.Invokable1Param(p) => args[1].Inline(p, p.LastValue),
                _ => p.LastValue
            };

            var lookupType = ParseTypeName($"LinqRewrite.Core.SimpleLookup<{keySelector.ReturnType(p)},{elementSelectorValue.Type}>");
            var lookupVariable = p.GlobalVariable(lookupType, args.Length switch
            {
                2 when !args[1].OldVal.IsInvokable(p) => New(lookupType, args[1]),
                3 when !args[2].OldVal.IsInvokable(p) => New(lookupType, args[2]),
                4 when !args[3].OldVal.IsInvokable(p) => New(lookupType, args[3]),
                _ => New(lookupType, ParseTypeName($"System.Collections.Generic.EqualityComparer<{keySelector.ReturnType(p)}>").Access("Default"))
            });

            p.ForAdd(lookupVariable.Access("GetGrouping").Invoke(keySelector.Inline(p, p.LastValue), true)
                            .Access("Add").Invoke(elementSelectorValue));
            p.Iterators.All.ForEach(x => x.Complete = true);

            var iGroupingType = ParseTypeName($"System.Linq.IGrouping<{keySelector.ReturnType(p)},{elementSelectorValue.Type}>");
            p.AddIterator(new CollectionValueBridge(p, lookupType, iGroupingType, lookupVariable, true));
            RewriteCollectionEnumeration.RewriteOther(p, p.CurrentIterator.Collection);
            var elementsType = ParseTypeName($"System.Collections.IEnumerable<{elementSelectorValue.Type}>");
            
            var groupingType = ParseTypeName($"LinqRewrite.Core.SimpleLookup<{keySelector.ReturnType(p)},{elementSelectorValue.Type}>.Grouping");
            p.LastValue = new TypedValueBridge(groupingType, p.LastValue.Cast(groupingType));
            
            var key = new TypedValueBridge(keySelector.ReturnType(p), Parenthesize(p.LastValue).Access("key"));
            var elements = new TypedValueBridge(elementsType, Parenthesize(p.LastValue).Access("elements"));
            p.LastValue = args.Length switch
            {
                1 => p.LastValue,
                _ when !args[1].OldVal.Invokable1Param(p) => args[1].Inline(p, key, elements),
                2 => p.LastValue,
                _ => args[2].Inline(p, key, elements)
            };
            
            p.ListEnumeration = false;
            p.ModifiedEnumeration = true;
        }
    }
}