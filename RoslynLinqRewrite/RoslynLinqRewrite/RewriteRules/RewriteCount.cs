﻿using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using Shaman.Roslyn.LinqRewrite.Extensions;
using static Shaman.Roslyn.LinqRewrite.Constants;
using static Shaman.Roslyn.LinqRewrite.Extensions.VariableExtensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteCount
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            var countVariable = "__count" + chainIndex;
            
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            
            p.PreForAdd(LocalVariableCreation(countVariable, 0));
            if (p.Chain[chainIndex].Arguments.Length == 0)
                p.ForAdd(countVariable.PostIncrement());
            else
            {
                var method = p.Chain[chainIndex].Arguments[0];
                p.ForAdd(If(p.Code.InlineLambda(p.Semantic, method, p.LastItem),
                            countVariable.PostIncrement()));
            }
            
            p.PostForAdd(Return(countVariable));
        }

        public static ExpressionSyntax RewriteSimple(RewriteParameters p)
            => p.Code.CreateCollectionCount(ItemsName, p.Collection, false);
    }
}