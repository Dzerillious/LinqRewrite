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
            var method = (LambdaExpressionSyntax)args[0];

            var collectionValue = args.Length switch
            {
                _ when method.InvokableWith1Param(p)=> method.Inline(p, p.LastValue),
                _ => method.Inline(p, p.LastValue, p.Indexer)
            };
            var rewritten = new RewrittenValueBridge(method.ExpressionBody, collectionValue.ReusableConst(p));

            var newIterator = new IteratorParameters(p, rewritten);
            p.CurrentIterator.ForBody.Add(newIterator);
            p.Iterators.Add(newIterator);
            p.Iterators.Remove(p.CurrentIterator);
            p.CurrentIterator = newIterator;
                
            var itemType = ((ValueBridge)method.ExpressionBody).ItemType(p);
            var collectionType = method.ReturnType(p);
            RewriteCollectionEnumeration.RewriteOther(p, new CollectionValueBridge(itemType, collectionType, rewritten.Count(p), rewritten));
            
            p.LastValue = args.Length switch
            {
                1 => p.LastValue,
                2 => args[1].Inline(p, p.LastValue, p.Indexer)
            };
            p.ModifiedEnumeration = true;
        }
    }
}