﻿using Shaman.Roslyn.LinqRewrite.DataStructures;
using static Shaman.Roslyn.LinqRewrite.Extensions.OperatorExpressionExtensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteSkipWhile
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            
            var method = p.Chain[chainIndex].Arguments[0];
            p.LastItem = p.LastItem.Reusable(p);

            var lastFor = p.CopyFor();
            lastFor.ForAdd(If(Not(method.Inline(p, p.LastItem)),
                Break()));

            p.ResultSize = null;
            p.Indexer = null;
        }
    }
}