﻿using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using Shaman.Roslyn.LinqRewrite.Extensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Shaman.Roslyn.LinqRewrite.Constants;
using static Shaman.Roslyn.LinqRewrite.Extensions.VariableExtensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteLastOrDefault
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            var foundVariable = p.CreateVariable("__found");
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            if (chainIndex != p.Chain.Count - 1) throw new InvalidOperationException("LastOrDefault should be last expression.");
            
            p.PreForAdd(LocalVariableCreation(foundVariable, NullableType(p.ReturnType), NullValue));

            if (p.Chain[chainIndex].Arguments.Length == 0)
            {
                p.ForAdd(foundVariable.Assign(p.LastItem));
            }
            else
            {
                var method = p.Chain[chainIndex].Arguments[0];
                p.ForAdd(If(method.Inline(p, p.LastItem),
                            foundVariable.Assign(p.LastItem)));
            }
            
            p.PostForAdd(If(foundVariable.EqualsExpr(NullValue),
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