using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteElementAtOrDefault
    {
        public static void Rewrite(RewriteParameters p, ExpressionSyntax[] args)
        {
            if (p.Body == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<ExpressionSyntax>());
            
            var position = args[0].Reusable(p);
            p.ForAdd(If(p.Indexer.IsEqual(position),
                        Return(p.Last.Value)));
            
            p.FinalAdd(Return(Default(p.ReturnType)));
            p.HasResultMethod = true;
        }

        public static ExpressionSyntax RewriteSimple(RewriteParameters p)
        {
            if (p.Chain[0].Arguments.Length == 0) return null;
            RewriteCollectionEnumeration.Rewrite(p, Array.Empty<ExpressionSyntax>());

            if (p.SourceSize == null) return null;
            return ConditionalExpression(
                p.Collection.Count(p) <= p.Chain[0].Arguments[0],
                p.Collection[p.Chain[0].Arguments[0]],
                Default(p.ReturnType));
        }
    }
}