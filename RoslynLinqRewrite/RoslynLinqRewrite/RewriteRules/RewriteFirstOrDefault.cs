using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using Shaman.Roslyn.LinqRewrite.Extensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Shaman.Roslyn.LinqRewrite.Constants;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteFirstOrDefault
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            if (chainIndex != p.Chain.Count - 1) throw new InvalidOperationException("FirstOrDefault should be last expression.");
            
            if (p.Chain[chainIndex].Arguments.Length == 0)
                p.ForAdd(Return(p.LastItem));
            
            else
            {
                var method = p.Chain[chainIndex].Arguments[0];
                p.ForAdd(If(method.Inline(p, p.LastItem),
                            Return(p.LastItem)));
            }
            
            p.PostForAdd(Return(Default(p.ReturnType)));
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