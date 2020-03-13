using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteWhere
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());

            var method = args[0];

            p.LastValue = p.LastValue.Reusable(p);
            if (method.OldVal is SimpleLambdaExpressionSyntax)
            {
                p.ForAdd(If(Not(method.Inline(p, p.LastValue)),
                            Continue()));
            }
            else 
            {
                p.ForAdd(If(Not(method.Inline(p, p.LastValue, p.Indexer)),
                            Continue()));
            }

            p.ModifiedEnumeration = true;
        }
    }
}