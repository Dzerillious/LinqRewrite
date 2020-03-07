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
            if (p.Iterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<ExpressionSyntax>());
            
            var position = args[0].Reusable(p);
            p.ForAdd(If(p.Indexer.IsEqual(position),
                        Return(p.Last.Value)));
            
            p.FinalAdd(Return(Default(p.ReturnType)));
            p.HasResultMethod = true;
        }

        public static ExpressionSyntax RewriteSimple(RewriteParameters p, ExpressionSyntax[] args)
        {
            if (args.Length == 0) return null;
            RewriteCollectionEnumeration.Rewrite(p, Array.Empty<ExpressionSyntax>());

            if (p.SourceSize == null) return null;
            return ConditionalExpression(
                p.CurrentCollection.Count <= args[0],
                p.CurrentCollection[args[0]],
                Default(p.ReturnType));
        }
    }
}