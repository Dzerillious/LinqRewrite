﻿using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            if (chainIndex != p.Chain.Count - 1) throw new InvalidOperationException("Count should be last expression.");
            
            if (p.Chain[chainIndex].Arguments.Length == 0)
                p.ForAdd(p.Indexer);
            else
            {
                var method = p.Chain[chainIndex].Arguments[0];
                p.ForAdd(If(method.Inline(p, p.LastItem),
                            p.Indexer));
            }
            
            p.PostForAdd(Return(p.Indexer));
            p.HasResultMethod = true;
        }

        public static ExpressionSyntax RewriteSimple(RewriteParameters p) 
            => p.Chain[0].Arguments.Length == 0 
                ? p.Code.CreateCollectionCount(p.Collection, false) 
                : null;
    }
}