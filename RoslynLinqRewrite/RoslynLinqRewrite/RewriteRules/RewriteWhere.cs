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
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);

            var method = p.Chain[chainIndex].Arguments[0];

            p.LastItem = p.LastItem.Reusable(p);
            if (method is SimpleLambdaExpressionSyntax)
                p.ForAdd(If(Not(method.Inline(p, p.LastItem)),
                    Continue()));
            else p.ForAdd(If(Not(method.Inline(p, p.LastItem, p.Indexer)),
                Continue()));

            p.ModifiedEnumeration = true;
        }
    }
}