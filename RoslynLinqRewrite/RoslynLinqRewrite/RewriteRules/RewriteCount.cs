using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using Shaman.Roslyn.LinqRewrite.Extensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Shaman.Roslyn.LinqRewrite.Extensions.VariableExtensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.OperatorExpressionExtensions;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteCount
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == p.Chain.Count - 1) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            
            p.AddToPrefix(LocalVariableCreation("__count",  IntValue(0)));
            if (p.Chain[chainIndex].Arguments.Length == 0)
                p.AddToBody(ExpressionStatement(Add(IdentifierName("__count"), IntValue(1))));
            else if (p.Chain[chainIndex].Arguments[0] is SimpleLambdaExpressionSyntax lambda)
            {
                p.AddToBody(IfStatement(p.Code.InlineOrCreateMethod(new Lambda(lambda),
                        CreatePrimitiveType(SyntaxKind.BoolKeyword), p.LastItem),
                    ExpressionStatement(Add(IdentifierName("__count"), IntValue(1)))));
            }
            
            p.AddToPostfix(ReturnStatement(IdentifierName("__count")));
        }
    }
}