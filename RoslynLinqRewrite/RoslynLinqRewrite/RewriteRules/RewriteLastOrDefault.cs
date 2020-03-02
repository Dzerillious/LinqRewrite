using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static LinqRewrite.Extensions.VariableExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteLastOrDefault
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            if (chainIndex != p.Chain.Count - 1) throw new InvalidOperationException("LastOrDefault should be last expression.");
            
            var foundVariable = p.CreateGlobalVariable("__found", NullableType(p.ReturnType), NullValue);
            if (p.Chain[chainIndex].Arguments.Length == 0)
            {
                p.ForAdd(foundVariable.Assign(p.Last.Value));
            }
            else
            {
                var method = p.Chain[chainIndex].Arguments[0];
                p.ForAdd(If(method.Inline(p, p.Last.Value),
                            foundVariable.Assign(p.Last.Value)));
            }
            
            p.FinalAdd(If(foundVariable.EqualsExpr(NullValue),
                            Return(Default(p.ReturnType)), 
                            Return(foundVariable.Cast(p.ReturnType))));
            p.HasResultMethod = true;
        }

        public static ExpressionSyntax RewriteSimple(RewriteParameters p)
        {
            if (p.Chain[0].Arguments.Length == 0) return null;
            RewriteCollectionEnumeration.Rewrite(p, 0);
            if (p.SourceSize == null) return null;
            
            return ConditionalExpression(
                p.Code.CreateCollectionCount(p.Collection, false)
                    .EqualsExpr(0),
                p.Collection.ArrayAccess(p.Code.CreateCollectionCount(p.Collection, false).Sub(1)),
                Default(p.ReturnType));
        }
    }
}