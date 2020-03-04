using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;

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
                p.ForAdd(If(Not(method.Inline(p, p.Last)),
                            Continue()));
            else p.ForAdd(If(Not(method.Inline(p, p.Last, new TypedValueBridge(Int, p.Indexer))),
                            Continue()));

            p.ModifiedEnumeration = true;
        }
    }
}