﻿using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using Shaman.Roslyn.LinqRewrite.Extensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Shaman.Roslyn.LinqRewrite.Constants;
using static Shaman.Roslyn.LinqRewrite.Extensions.VariableExtensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteLast
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            var foundVariable = "__found" + chainIndex;
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            
            p.PreForAdd(LocalVariableCreation(foundVariable, NullableType(p.ReturnType), NullValue));

            if (p.Chain[chainIndex].Arguments.Length == 0)
            {
                p.ForAdd(foundVariable.Assign(p.LastItem));
            }
            else
            {
                var method = p.Chain[chainIndex].Arguments[0];
                p.ForAdd(If(method.InlineForLast(p),
                            foundVariable.Assign(p.LastItem)));
            }
            
            p.PostForAdd(If(foundVariable.EqualsExpr(NullValue),
                            CreateThrowException("System.InvalidOperationException", "The sequence did not contain any elements."), 
                            Return(foundVariable.Cast(p.ReturnType))));
        }

        public static ExpressionSyntax RewriteSimple(RewriteParameters p)
        {
            if (p.Chain[0].Arguments.Length == 0) return null;
            RewriteCollectionEnumeration.Rewrite(p, 0);
            
            return p.SourceSize == null 
                ? null 
                : ItemsName.ArrayAccess(p.Code.CreateCollectionCount(ItemsName, p.Collection, false).Sub(1));
        }
    }
}