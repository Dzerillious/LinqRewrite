using System.Collections.Immutable;
using System.Linq;
using LinqRewrite.Core;
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
        public static void Rewrite(RewriteDesign design, ImmutableArray<ValueBridge> args)
        {
            // TODO: FIX
            return;
            //var innerValue = args[0];
            //RewrittenValueBridge outerKeySelector = args[1];
            //RewrittenValueBridge innerKeySelector = args[2];
            //if (design.CurrentIterator.IgnoreIterator) return;

            //var resultSelectorValue = args[3];
            //var comparerValue = args.Length == 5 ? args[4] : null;

            //var lookupType = ParseTypeName($"LinqRewrite.Core.SimpleLookup<{innerValue.ItemType(design)},{innerKeySelector.ReturnType(design)}>");
            //var lookupVariable = CreateGlobalVariable(design, lookupType, lookupType.Access("CreateForJoin")
            //    .Invoke(innerValue, innerKeySelector, comparerValue));

            //var itemValue = design.LastValue;
            //var groupingType = ParseTypeName($"LinqRewrite.Core.SimpleLookup<{innerValue.ItemType(design)},{outerKeySelector.ReturnType(design)}>.Grouping");
            //var groupingVariable = CreateGlobalVariable(design, groupingType);
            //design.ForAdd(groupingVariable.Assign(lookupVariable.Access("GetGrouping")
            //    .Invoke(outerKeySelector.Inline(design, itemValue), false)));

            //design.ForAdd(If(groupingVariable.IsEqual(null), Continue()));
            //var rewritten = new RewrittenValueBridge(((LambdaExpressionSyntax) innerKeySelector.Old).Body, groupingVariable);

            //var iteratorVariable = CreateGlobalVariable(design, innerKeySelector.ReturnType(design));
            //design.IncompleteIterators.ToArray().ForEach(x =>
            //{
            //    var newIterator = new IteratorDesign(design, new CollectionValueBridge(design, groupingType, innerKeySelector.ReturnType(design), rewritten, true));
            //    x.ForBody.Add(newIterator);
            //    design.Iterators.Add(newIterator);
            //    design.Iterators.Remove(x);
            //    design.CurrentIterator = newIterator;
            //    RewriteCollectionEnumeration.RewriteOther(design, design.CurrentIterator.Collection, iteratorVariable);
            //});

            //design.CurrentIterator = design.Iterators.Last();
            //design.LastValue = resultSelectorValue.Inline(design, itemValue, design.LastValue);
            //design.ModifiedEnumeration = true;
            //design.ListEnumeration = false;
            //design.SourceSize = null;
        }
    }
}