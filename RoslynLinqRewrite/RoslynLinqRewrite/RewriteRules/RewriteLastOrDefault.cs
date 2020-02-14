﻿using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Shaman.Roslyn.LinqRewrite.Extensions.OperatorExpressionExtensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Shaman.Roslyn.LinqRewrite.Extensions.VariableExtensions;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteLastOrDefault
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == p.Chain.Count - 1) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            
            p.PreForAdd(LocalVariableCreation("_found", NullableType(p.ReturnType), NullValue));

            if (p.Chain[chainIndex].Arguments.Length == 0)
            {
                p.ForAdd(  "_found".Assign(p.LastItem));
            }
            else if (p.Chain[chainIndex].Arguments[0] is SimpleLambdaExpressionSyntax lambda)
            {
                p.ForAdd(If(p.Code.InlineLambda(p.Semantic, lambda, p.LastItem),
                    "_found".Assign(p.LastItem)));
            }
            
            p.PostForAdd(If("_found".EqualsExpr(NullValue),
                ReturnStatement(DefaultExpression(p.ReturnType)), 
                Else(ReturnStatement("_found".Cast(p.ReturnType)))));
        }
    }
}