using System;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteRepeat
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex != p.Chain.Count - 1) throw new InvalidOperationException("Enumerable.Repeat should be first expression.");

            var item = p.Chain[chainIndex].Arguments[0];
            var count = p.Chain[chainIndex].Arguments[1];
            
            p.GetFor = body => p.Rewrite.GetForStatement("__i", 
                item, count, AggregateStatementSyntax(body));
            p.GetReverseFor = p.GetFor;
            
            p.ResultSize = count;
            p.SourceSize = count;
            
            p.LastItem = IdentifierName("__i");
        }
    }
}