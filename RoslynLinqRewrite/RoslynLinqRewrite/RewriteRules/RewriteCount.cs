using System;
using LinqRewrite.DataStructures;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteCount
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            if (chainIndex != p.Chain.Count - 1) throw new InvalidOperationException("Count should be last expression.");

            if (p.Chain[chainIndex].Arguments.Length != 0)
            {
                var method = p.Chain[chainIndex].Arguments[0];
                p.ForAdd(If(Not(method.Inline(p, p.LastItem)),
                    Continue()));
                
                p.ModifiedEnumeration = true;
            }
            p.ForAdd(p.Indexer);
            p.PostForAdd(Return(p.Indexer.Add(1)));
            p.HasResultMethod = true;
        }

        public static ExpressionSyntax RewriteSimple(RewriteParameters p) 
            => p.Chain[0].Arguments.Length == 0 
                ? p.Code.CreateCollectionCount(p.Collection, false) 
                : null;
    }
}