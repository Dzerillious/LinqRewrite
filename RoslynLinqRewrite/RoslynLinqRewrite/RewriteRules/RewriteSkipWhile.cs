using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSkipWhile
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            var method = args[0];
            
            p.LastValue = p.LastValue.Reusable(p);

            var lastFor = p.CopyIterator();
            lastFor.BodyAdd(If(Not(method.OldVal is SimpleLambdaExpressionSyntax
                                        ? method.Inline(p, p.LastValue)
                                        : method.Inline(p, p.LastValue, p.Indexer)),
                                Break()));

            p.ModifiedEnumeration = true;
        }
    }
}