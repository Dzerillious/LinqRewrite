using System;
using LinqRewrite.DataStructures;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.VariableExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSingleOrDefault
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            if (chainIndex != p.Chain.Count - 1) throw new InvalidOperationException("SingleOrDefault should be last expression.");
            
            var foundVariable = p.CreateLocalVariable("__found", NullableType(p.ReturnType), NullValue);

            if (p.Chain[chainIndex].Arguments.Length == 0)
            {
                p.ForAdd(If(foundVariable.EqualsExpr(NullValue),
                            foundVariable.Assign(p.LastItem), 
                            Return(Default(p.ReturnType))));
            }
            else
            {
                var method = p.Chain[chainIndex].Arguments[0];
                p.ForAdd(If(method.Inline(p, p.LastItem),
                            If(foundVariable.EqualsExpr(NullValue),
                                foundVariable.Assign(p.LastItem),
                                Return(Default(p.ReturnType)))));
            }
            
            p.PostForAdd(If(foundVariable.EqualsExpr(NullValue),
                            Return(Default(p.ReturnType)), 
                            Return(foundVariable.Cast(p.ReturnType))));
            p.HasResultMethod = true;
        }

        public static ExpressionSyntax RewriteSimple(RewriteParameters p) 
            => p.Chain[0].Arguments.Length == 0 
                ? ConditionalExpression(p.Code.CreateCollectionCount(p.Collection, false).EqualsExpr(1),
                    p.Collection.ArrayAccess(0),
                    Default(p.ReturnType)) 
                : null;
    }
}