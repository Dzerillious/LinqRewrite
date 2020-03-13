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
            if (p.Iterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            var method = args[0];
            
            p.Last = p.Last.Reusable(p);

            var lastFor = p.CopyIterator();
            lastFor.BodyAdd(If(Not(method.OldVal is SimpleLambdaExpressionSyntax
                                        ? method.Inline(p, p.Last)
                                        : method.Inline(p, p.Last, p.Indexer)),
                                Break()));

            p.ModifiedEnumeration = true;
        }
    }
}