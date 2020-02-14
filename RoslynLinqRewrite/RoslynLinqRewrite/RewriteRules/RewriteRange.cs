using System;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Shaman.Roslyn.LinqRewrite.Extensions.OperatorExpressionExtensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Shaman.Roslyn.LinqRewrite.Extensions.VariableExtensions;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteRange
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex != p.Chain.Count - 1) throw new InvalidOperationException("Enumerable.Range should be first expression.");

            var from = p.Chain[chainIndex].Arguments[0];
            var count = p.Chain[chainIndex].Arguments[1];
            
            p.PreForAdd(LocalVariableCreation("__sum", from.Add(count)));

            p.GetFor = body => p.Rewrite.GetForStatement("__i", p.Chain[1].Arguments[0], IdentifierName("__sum"),
                AggregateStatementSyntax(body));
            p.GetReverseFor = body => p.Rewrite.GetReverseForStatement("__i", p.Chain[1].Arguments[0], IdentifierName("__sum"),
                AggregateStatementSyntax(body));
            
            p.LastItem = IdentifierName("__i");
            
            p.ResultSize = count;
            p.SourceSize = count;
        }
    }
}