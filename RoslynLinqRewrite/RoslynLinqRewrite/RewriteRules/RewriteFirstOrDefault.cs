using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteFirstOrDefault
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            if (chainIndex != p.Chain.Count - 1) throw new InvalidOperationException("FirstOrDefault should be last expression.");
            
            if (p.Chain[chainIndex].Arguments.Length == 0)
                p.ForAdd(Return(p.Last.Value));
            
            else
            {
                var method = p.Chain[chainIndex].Arguments[0];
                p.ForAdd(If(method.Inline(p, p.Last.Value),
                            Return(p.Last.Value)));
            }
            
            p.FinalAdd(Return(Default(p.ReturnType)));
            p.HasResultMethod = true;
        }

        public static ExpressionSyntax RewriteSimple(RewriteParameters p)
        {
            if (p.Chain[0].Arguments.Length != 0) return null;
            return ConditionalExpression(
                p.Code.CreateCollectionCount(p.Collection, false).EqualsExpr(0),
                p.Collection.ArrayAccess(0),
                Default(p.ReturnType));
        }
    }
}