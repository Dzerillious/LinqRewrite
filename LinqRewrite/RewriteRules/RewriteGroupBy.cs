using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteGroupBy
    {
        public static void Rewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            RewrittenValueBridge keySelector = args[0];
            var elementSelectorValue = args.Length switch
            {
                1 => design.LastValue,
                _ when args[1].OldVal.Invokable1Param(design) => args[1].Inline(design, design.LastValue),
                _ => design.LastValue
            };

            var lookupType = ParseTypeName($"LinqRewrite.Core.SimpleLookup<{keySelector.ReturnType(design)},{elementSelectorValue.Type}>");
            var lookupVariable = CreateGlobalVariable(design, lookupType, args.Length switch
            {
                2 when !args[1].OldVal.IsInvokable(design) => New(lookupType, args[1]),
                3 when !args[2].OldVal.IsInvokable(design) => New(lookupType, args[2]),
                4 when !args[3].OldVal.IsInvokable(design) => New(lookupType, args[3]),
                _ => New(lookupType, ParseTypeName($"System.Collections.Generic.EqualityComparer<{keySelector.ReturnType(design)}>").Access("Default"))
            });

            design.ForAdd(lookupVariable.Access("GetGrouping").Invoke(keySelector.Inline(design, design.LastValue), true)
                                .Access("Add").Invoke(elementSelectorValue));
            design.Iterators.All.ForEach(x => x.Complete = true);

            var iGroupingType = ParseTypeName($"System.Linq.IGrouping<{keySelector.ReturnType(design)},{elementSelectorValue.Type}>");
            design.AddIterator(new CollectionValueBridge(design, lookupType, iGroupingType, lookupVariable, true));
            RewriteCollectionEnumeration.RewriteOther(design, design.CurrentIterator.Collection);
            var elementsType = ParseTypeName($"System.Collections.IEnumerable<{elementSelectorValue.Type}>");
            
            var groupingType = ParseTypeName($"LinqRewrite.Core.SimpleLookup<{keySelector.ReturnType(design)},{elementSelectorValue.Type}>.Grouping");
            design.LastValue = new TypedValueBridge(groupingType, design.LastValue.Cast(groupingType));
            
            var key = new TypedValueBridge(keySelector.ReturnType(design), Parenthesize(design.LastValue).Access("key"));
            var elements = new TypedValueBridge(elementsType, Parenthesize(design.LastValue).Access("elements"));
            design.LastValue = args.Length switch
            {
                1 => design.LastValue,
                _ when !args[1].OldVal.Invokable1Param(design) => args[1].Inline(design, key, elements),
                2 => design.LastValue,
                _ => args[2].Inline(design, key, elements)
            };
            
            design.ListEnumeration = false;
            design.ModifiedEnumeration = true;
        }
    }
}