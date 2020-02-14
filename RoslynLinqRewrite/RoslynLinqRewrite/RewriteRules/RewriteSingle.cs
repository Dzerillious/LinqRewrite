﻿using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Shaman.Roslyn.LinqRewrite.Extensions.OperatorExpressionExtensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Shaman.Roslyn.LinqRewrite.Extensions.VariableExtensions;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteSingle
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == p.Chain.Count - 1) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            
            p.PreForAdd(LocalVariableCreation("__found", NullableType(p.ReturnType), NullValue));

            if (p.Chain[chainIndex].Arguments.Length == 0)
            {
                p.ForAdd(If("__found".EqualsExpr(NullValue),
                    "__found".Assign(p.LastItem), 
                    Else(CreateThrowException("System.InvalidOperationException",
                        "The sequence contains more than single matching element."))));
            }
            else if (p.Chain[chainIndex].Arguments[0] is SimpleLambdaExpressionSyntax lambda)
            {
                p.ForAdd(IfStatement(p.Code.InlineLambda(p.Semantic, lambda, p.LastItem),
                    If("__found".EqualsExpr(NullValue),
                        "__found".Assign(p.LastItem),
                        Else(CreateThrowException("System.InvalidOperationException",
                            "The sequence contains more than single matching element.")))));
            }
            
            p.PostForAdd(If("_found".EqualsExpr(NullValue),
                CreateThrowException("System.InvalidOperationException", "The sequence did not contain any elements."), 
                Else(ReturnStatement("_found".Cast(p.ReturnType)))));
        }
    }
}