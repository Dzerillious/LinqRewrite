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
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            if (chainIndex != p.Chain.Count - 1) throw new InvalidOperationException("Count should be last expression.");
            
            var position = p.Chain[chainIndex].Arguments[0];
            p.ForAdd(If(p.Indexer.EqualsExpr(position),
                        Return(p.Last.Value)));
            
            p.FinalAdd(Return(Default(p.ReturnType)));
            p.HasResultMethod = true;
        }

        public static ExpressionSyntax RewriteSimple(RewriteParameters p)
        {
            if (p.Chain[0].Arguments.Length == 0) return null;
            RewriteCollectionEnumeration.Rewrite(p, 0);

            if (p.SourceSize == null) return null;
            return ConditionalExpression(
                p.Code.CreateCollectionCount(p.Collection, false).LeThan(p.Chain[0].Arguments[0]),
                p.Collection.ArrayAccess(p.Chain[0].Arguments[0]),
                Default(p.ReturnType));
        }
    }
}