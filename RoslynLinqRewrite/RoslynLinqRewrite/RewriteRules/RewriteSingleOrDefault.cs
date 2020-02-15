﻿using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Shaman.Roslyn.LinqRewrite.Extensions.OperatorExpressionExtensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.VariableExtensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteSingleOrDefault
    {
        private const string FoundVariable = "__found";
        
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == p.Chain.Count - 1) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            
            p.PreForAdd(LocalVariableCreation(FoundVariable, NullableType(p.ReturnType), NullValue));

            if (p.Chain[chainIndex].Arguments.Length == 0)
            {
                p.ForAdd(If(FoundVariable.EqualsExpr(NullValue),
                            FoundVariable.Assign(p.LastItem), 
                            Else(Return(Default(p.ReturnType)))));
            }
            else if (p.Chain[chainIndex].Arguments[0] is SimpleLambdaExpressionSyntax lambda)
            {
                p.ForAdd(If(p.Code.Inline(p.Semantic, lambda, p.LastItem),
                            If(FoundVariable.EqualsExpr(NullValue),
                                FoundVariable.Assign(p.LastItem),
                                Else(Return(Default(p.ReturnType))))));
            }
            
            p.PostForAdd(If(FoundVariable.EqualsExpr(NullValue),
                            Return(Default(p.ReturnType)), 
                            Else(Return(FoundVariable.Cast(p.ReturnType)))));
        }
    }
}