using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using static Shaman.Roslyn.LinqRewrite.Extensions.OperatorExpressionExtensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteWhere
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == p.Chain.Count - 1) RewriteCollectionEnumeration.Rewrite(p, chainIndex);

            var lambda = (SimpleLambdaExpressionSyntax)p.Chain[chainIndex].Arguments[0];
            
            p.ForAdd(If(Not(p.Code.Inline(p.Semantic, lambda, p.LastItem)),
                Continue()));

            p.ResultSize = null;
        }
    }
}