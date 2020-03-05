﻿using System;
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
            
            var foundVariable = p.GlobalVariable(NullableType(p.ReturnType), "__found", Null);

            if (p.Chain[chainIndex].Arguments.Length == 0)
            {
                p.ForAdd(If(foundVariable.IsEqual(Null),
                            foundVariable.Assign(p.Last.Value), 
                            Return(Default(p.ReturnType))));
            }
            else
            {
                var method = p.Chain[chainIndex].Arguments[0];
                p.ForAdd(If(method.Inline(p, p.Last),
                            If(foundVariable.IsEqual(Null),
                                foundVariable.Assign(p.Last.Value),
                                Return(Default(p.ReturnType)))));
            }
            
            p.FinalAdd(If(foundVariable.IsEqual(Null),
                            Return(Default(p.ReturnType)), 
                            Return(foundVariable.Cast(p.ReturnType))));
            p.HasResultMethod = true;
        }

        public static ExpressionSyntax RewriteSimple(RewriteParameters p) 
            => p.Chain[0].Arguments.Length == 0 
                ? ConditionalExpression(p.Collection.Count(p).IsEqual(1),
                    p.Collection[0],
                    Default(p.ReturnType)) 
                : null;
    }
}