﻿using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteFirst
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == p.Chain.Count - 1) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            
            if (p.Chain[chainIndex].Arguments.Length == 0)
                p.AddToBody(ReturnStatement(p.LastItem));
            else if (p.Chain[chainIndex].Arguments[0] is SimpleLambdaExpressionSyntax lambda)
            {
                p.AddToBody(IfStatement(InvocationExpression(lambda, CreateArguments(p.LastItem)), 
                    ReturnStatement(p.LastItem)));
            }
            //else p.AddToBody(),
                // CreateThrowException("System.InvalidOperationException", "Collection was null."))););
            //p.AddToBody();
            
            p.AddToPostfix(CreateThrowException("System.InvalidOperationException",
            "The sequence did not contain any elements."));
        }
    }
}