using System.Collections.Immutable;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSelectMany
    {
        public static void Rewrite(RewriteDesign design, ImmutableArray<ValueBridge> args)
        {
            // TODO: FIX
            return;
            //RewrittenValueBridge method = args[0];
            //var newExpression = (LambdaExpressionSyntax) method.NewVal;
            //if (design.CurrentIterator.IgnoreIterator) return;

            //var collectionValue = args.Length switch
            //{
            //    _ when newExpression.Invokable1Param(design)=> method.Inline(design, design.LastValue),
            //    _ => method.Inline(design, design.LastValue, design.Indexer)
            //};
            //var rewritten = new RewrittenValueBridge(newExpression.ExpressionBody, collectionValue);

            //var iteratorVariable = CreateGlobalVariable(design, method.ReturnItemType(design));
            //design.IncompleteIterators.ToArray().ForEach(iterator =>
            //{
            //    var newIterator = new IteratorDesign(design, new CollectionValueBridge(design, method.ReturnType(design), method.ReturnItemType(design), rewritten, true));
            //    iterator.ForBody.Add(newIterator);
            //    design.Iterators.Add(newIterator);
            //    design.Iterators.Remove(iterator);
            //    design.CurrentIterator = newIterator;
            //    RewriteCollectionEnumeration.RewriteOther(design, design.CurrentIterator.Collection, iteratorVariable);
            //});

            //design.CurrentIterator = design.Iterators.Last();
            //design.LastValue = args.Length switch
            //{
            //    1 => design.LastValue,
            //    2 => args[1].Inline(design, design.LastValue, design.Indexer)
            //};
            //design.ModifiedEnumeration = true;
            //design.ListEnumeration = false;
            //design.SourceSize = null;
        }
    }
}