﻿using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Shaman.Roslyn.LinqRewrite.Constants;
using static Shaman.Roslyn.LinqRewrite.Extensions.OperatorExpressionExtensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Shaman.Roslyn.LinqRewrite.Extensions.VariableExtensions;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteSingle
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            var foundVariable = "__found" + chainIndex;
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            if (chainIndex != p.Chain.Count - 1) throw new InvalidOperationException("Single should be last expression.");
            
            p.PreForAdd(LocalVariableCreation(foundVariable, NullableType(p.ReturnType), NullValue));

            if (p.Chain[chainIndex].Arguments.Length == 0)
            {
                p.ForAdd(If(foundVariable.EqualsExpr(NullValue),
                            foundVariable.Assign(p.LastItem), 
                            CreateThrowException("System.InvalidOperationException", "The sequence contains more than single matching element.")));
            }
            else
            {
                var method = p.Chain[chainIndex].Arguments[0];
                p.ForAdd(If(method.Inline(p, p.LastItem),
                            If(foundVariable.EqualsExpr(NullValue),
                                foundVariable.Assign(p.LastItem),
                                CreateThrowException("System.InvalidOperationException", "The sequence contains more than single matching element."))));
            }
            
            p.PostForAdd(If(foundVariable.EqualsExpr(NullValue),
                            CreateThrowException("System.InvalidOperationException", "The sequence did not contain any elements."), 
                            Return(foundVariable.Cast(p.ReturnType))));
            p.HasResultMethod = true;
        }

        public static ExpressionSyntax RewriteSimple(RewriteParameters p) 
            => p.Chain[0].Arguments.Length == 0 
                ? ConditionalExpression(p.Code.CreateCollectionCount(GlobalItemsVariable, p.Collection, false).EqualsExpr(1),
                    GlobalItemsVariable.ArrayAccess(0),
                    CreateThrowException("System.InvalidOperationException", "The sequence does not contain one element.")) 
                : null;
    }
}