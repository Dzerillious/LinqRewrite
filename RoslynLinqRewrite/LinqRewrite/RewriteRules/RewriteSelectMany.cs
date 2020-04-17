using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSelectMany
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            var method = args[0];
            var newExpression = (LambdaExpressionSyntax) method.NewVal;

            var collectionValue = args.Length switch
            {
                _ when newExpression.InvokableWith1Param(p)=> method.Inline(p, p.LastValue),
                _ => method.Inline(p, p.LastValue, p.Indexer)
            };
            var rewritten = new RewrittenValueBridge(newExpression.ExpressionBody, collectionValue);

            var iterator = p.GlobalVariable(method.ReturnItemType(p));
            p.Iterators.Where(x => !x.Complete).ToArray().ForEach(x =>
            {
                var newIterator = new IteratorParameters(p, rewritten);
                x.ForBody.Add(newIterator);
                p.Iterators.Add(newIterator);
                p.Iterators.Remove(x);
                p.CurrentIterator = newIterator;
                RewriteCollectionEnumeration.RewriteOther(p, new CollectionValueBridge(p, method.ReturnType(p), method.ReturnItemType(p), rewritten, true), iterator);
            });
            
            p.CurrentIterator = p.Iterators.Last();
            p.LastValue = args.Length switch
            {
                1 => p.LastValue,
                2 => args[1].Inline(p, p.LastValue, p.Indexer)
            };
            p.ModifiedEnumeration = true;
        }
    }
}