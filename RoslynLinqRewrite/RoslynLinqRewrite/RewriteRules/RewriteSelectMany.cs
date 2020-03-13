using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSelectMany
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            var method = args[0];

            var collection = method.OldVal is SimpleLambdaExpressionSyntax
                ? method.Inline(p, p.LastValue)
                : method.Inline(p, p.LastValue, p.Indexer);
            
            var rewritten = new RewrittenValueBridge(((LambdaExpressionSyntax)method).ExpressionBody, collection.Reusable(p));

            var newIterator = new IteratorParameters(p, rewritten);
            p.CurrentIterator.ForBody.Add(newIterator);
            p.Iterators.Add(newIterator);
            p.Iterators.Remove(p.CurrentIterator);
            p.CurrentIterator = newIterator;
                
            var itemType = ((ValueBridge)((LambdaExpressionSyntax)method).ExpressionBody).ItemType(p);
            var collectionType = ((LambdaExpressionSyntax) method).ReturnType(p);
            RewriteCollectionEnumeration.RewriteOther(p, new CollectionValueBridge(itemType, collectionType, rewritten.Count(p), rewritten));

            p.ModifiedEnumeration = true;
        }
    }
}