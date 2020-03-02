using LinqRewrite.DataStructures;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteWhere
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);

            var method = p.Chain[chainIndex].Arguments[0];

            p.Last = p.Last.Reusable(p);
            if (method is SimpleLambdaExpressionSyntax)
                p.ForAdd(If(Not(method.Inline(p, p.Last.Value)),
                            Continue()));
            else p.ForAdd(If(Not(method.Inline(p, p.Last.Value, p.Indexer)),
                            Continue()));

            p.ModifiedEnumeration = true;
        }
    }
}