using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Shaman.Roslyn.LinqRewrite.Extensions.OperatorExpressionExtensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Shaman.Roslyn.LinqRewrite.Extensions.VariableExtensions;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteWhere
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);

            var lambda = (SimpleLambdaExpressionSyntax)p.Chain[chainIndex].Arguments[0];
            
            var count = Regex.Matches(lambda.ToString(), lambda.Parameter.ToString()).Count;
            var canJoin = count == 2 
                          && !(p.LastItem is BinaryExpressionSyntax)
                          && !(p.LastItem is PostfixUnaryExpressionSyntax)
                          && !(p.LastItem is PrefixUnaryExpressionSyntax)
                          && !(p.LastItem is InvocationExpressionSyntax)
                          && !(p.LastItem is ParenthesizedExpressionSyntax);

            if (canJoin)
            {
                p.ForAdd(If(Not(p.Code.Inline(p.Semantic, lambda, p.LastItem)),
                    Continue()));
            }
            else
            {
                var conditionVariable = "__item" + chainIndex;
                p.ForAdd(LocalVariableCreation(conditionVariable, p.LastItem));
                p.ForAdd(If(Not(p.Code.Inline(p.Semantic, lambda, IdentifierName(conditionVariable))), Continue()));
                p.LastItem = IdentifierName(conditionVariable);
            }

            p.ResultSize = null;
            p.DifferentEnumeration = true;
        }
    }
}