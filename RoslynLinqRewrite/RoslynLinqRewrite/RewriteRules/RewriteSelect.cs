using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using Shaman.Roslyn.LinqRewrite.Extensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Shaman.Roslyn.LinqRewrite.Extensions.VariableExtensions;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteSelect
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == p.Chain.Count - 1) RewriteCollectionEnumeration.Rewrite(p, chainIndex);

            var lambda = (SimpleLambdaExpressionSyntax)p.Chain[chainIndex].Arguments[0];
            var returnType = p.Semantic.GetTypeFromExpression(lambda.ExpressionBody);
            var itemName = $"_item{chainIndex}";
            
            p.AddToBody(LocalVariableCreation(itemName, 
                p.Code.InlineOrCreateMethod(new Lambda(lambda), returnType, p.LastItem)));
            p.LastItem = IdentifierName(itemName);
            
            // p.AddToBody(LocalVariableCreation(itemName, 
            //     p.Code.InlineOrCreateMethod(new Lambda(lambda), returnType, p.LastItem)));
            
            // p.LastItem = p.Code.InlineOrCreateMethod(new Lambda(lambda), returnType, p.LastItem);
        }
    }
}