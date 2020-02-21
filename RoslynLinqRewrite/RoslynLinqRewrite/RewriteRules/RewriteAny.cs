﻿using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using Shaman.Roslyn.LinqRewrite.Extensions;
using static Shaman.Roslyn.LinqRewrite.Constants;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteAny
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            
            if (p.Chain[chainIndex].Arguments.Length == 0)
                p.ForAdd(Return(true));
            
            else
            {
                var method = p.Chain[chainIndex].Arguments[0];
                p.ForAdd(If(method.InlineForLast(p),
                            Return(true)));
            }
            
            p.PostForAdd(Return(false));
        }

        public static ExpressionSyntax RewriteSimple(RewriteParameters p) 
            => p.Chain[0].Arguments.Length == 0 
                ? p.Code.CreateCollectionCount(ItemsName, p.Collection, false).LThan(0) 
                : null;
    }
}