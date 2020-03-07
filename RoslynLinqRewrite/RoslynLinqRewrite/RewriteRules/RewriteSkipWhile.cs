using System;
using LinqRewrite.DataStructures;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSkipWhile
    {
        public static void Rewrite(RewriteParameters p, ExpressionSyntax[] args)
        {
            if (p.Iterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<ExpressionSyntax>());
            
            p.Last = p.Last.Reusable(p);

            var lastFor = p.CopyIterator();
            lastFor.BodyAdd(If(!args[0].Inline(p, p.Last),
                                Break()));

            p.ModifiedEnumeration = true;
        }
    }
}