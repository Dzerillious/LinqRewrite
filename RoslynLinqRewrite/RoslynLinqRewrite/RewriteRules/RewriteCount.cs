using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteCount
    {
        public static void Rewrite(RewriteParameters p, ExpressionSyntax[] args)
        {
            if (p.Body == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<ExpressionSyntax>());

            if (args.Length != 0)
            {
                p.ForAdd(If(!args[0].Inline(p, p.Last),
                        Continue()));
                
                p.ModifiedEnumeration = true;
            }
            p.ForAdd(p.Indexer);
            p.FinalAdd(Return(p.Indexer + 1));
            p.HasResultMethod = true;
        }

        public static ExpressionSyntax RewriteSimple(RewriteParameters p) 
            => p.Chain[0].Arguments.Length == 0 
                ? p.Collection.Count(p) 
                : null;
    }
}