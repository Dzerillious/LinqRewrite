using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Shaman.Roslyn.LinqRewrite.Extensions.VariableExtensions;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteSelect
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            var itemVariable = "__item" + chainIndex;
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            var method = p.Chain[chainIndex].Arguments[0];

            var canJoin = true;
            if (p.Chain[chainIndex].Arguments[0] is SimpleLambdaExpressionSyntax lambda)
            {
                var count = Regex.Matches(lambda.ToString(), lambda.Parameter.ToString()).Count;
                canJoin = count == 2 ||
                              !(p.LastItem is BinaryExpressionSyntax)
                              && !(p.LastItem is PostfixUnaryExpressionSyntax)
                              && !(p.LastItem is PrefixUnaryExpressionSyntax)
                              && !(p.LastItem is InvocationExpressionSyntax)
                              && !(p.LastItem is ParenthesizedExpressionSyntax);
            
            }
            
            if (canJoin) p.LastItem = p.Code.InlineLambda(p.Semantic, method, p.LastItem);
            else
            {
                p.ForAdd(LocalVariableCreation(itemVariable, p.LastItem));
                p.LastItem = IdentifierName(itemVariable);
                p.LastItem = p.Code.InlineLambda(p.Semantic, method, p.LastItem);
            }
        }
    }
}