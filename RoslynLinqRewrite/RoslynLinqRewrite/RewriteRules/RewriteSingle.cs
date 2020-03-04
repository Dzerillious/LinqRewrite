using System;
using LinqRewrite.DataStructures;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSingle
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            if (chainIndex != p.Chain.Count - 1) throw new InvalidOperationException("Single should be last expression.");
            
            var foundVariable = p.CreateGlobalVariable("__found", NullableType(p.ReturnType), NullValue);

            if (p.Chain[chainIndex].Arguments.Length == 0)
            {
                p.ForAdd(If(foundVariable.EqualsExpr(NullValue),
                            foundVariable.Assign(p.Last.Value), 
                            CreateThrowException("System.InvalidOperationException", "The sequence contains more than single matching element.")));
            }
            else
            {
                var method = p.Chain[chainIndex].Arguments[0];
                p.ForAdd(If(method.Inline(p, p.Last),
                            If(foundVariable.EqualsExpr(NullValue),
                                foundVariable.Assign(p.Last.Value),
                                CreateThrowException("System.InvalidOperationException", "The sequence contains more than single matching element."))));
            }
            
            p.FinalAdd(If(foundVariable.EqualsExpr(NullValue),
                            CreateThrowException("System.InvalidOperationException", "The sequence did not contain any elements."), 
                            Return(foundVariable.Cast(p.ReturnType))));
            p.HasResultMethod = true;
        }

        public static ExpressionSyntax RewriteSimple(RewriteParameters p) 
            => p.Chain[0].Arguments.Length == 0 
                ? ConditionalExpression(p.Code.CreateCollectionCount(p.Collection, false).EqualsExpr(1),
                    p.Collection.ArrayAccess(0),
                    CreateThrowException("System.InvalidOperationException", "The sequence does not contain one element.")) 
                : null;
    }
}