using System;
using LinqRewrite.DataStructures;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteTakeWhile
    {
        public static void Rewrite(RewriteParameters p, ExpressionSyntax[] args)
        {
            if (p.Body == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<ExpressionSyntax>());
            
            p.Last = p.Last.Reusable(p);
            
            p.ForAdd(If(!args[0].Inline(p, p.Last),
                        Break()));

            p.ResultSize = null;
            p.CurrentIndexer = null;
        }
    }
}