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
        public static void Rewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            RewrittenValueBridge method = args[0];
            var newExpression = (LambdaExpressionSyntax) method.NewVal;
            if (design.CurrentIterator.IgnoreIterator) return;

            var collectionValue = args.Length switch
            {
                _ when newExpression.Invokable1Param(design)=> method.Inline(design, design.LastValue),
                _ => method.Inline(design, design.LastValue, design.Indexer)
            };
            var rewritten = new RewrittenValueBridge(newExpression.ExpressionBody, collectionValue);

            var iteratorVariable = CreateGlobalVariable(design, method.ReturnItemType(design));
            design.IncompleteIterators.ToArray().ForEach(x =>
            {
                var newIterator = new IteratorDesign(design, new CollectionValueBridge(design, method.ReturnType(design), method.ReturnItemType(design), rewritten, true));
                x.ForBody.Add(newIterator);
                design.Iterators.Add(newIterator);
                design.Iterators.Remove(x);
                design.CurrentIterator = newIterator;
                RewriteCollectionEnumeration.RewriteOther(design, design.CurrentIterator.Collection, iteratorVariable);
            });
            
            design.CurrentIterator = design.Iterators.Last();
            design.LastValue = args.Length switch
            {
                1 => design.LastValue,
                2 => args[1].Inline(design, design.LastValue, design.Indexer)
            };
            design.ModifiedEnumeration = true;
            design.ListEnumeration = false;
            design.SourceSize = null;
        }
    }
}