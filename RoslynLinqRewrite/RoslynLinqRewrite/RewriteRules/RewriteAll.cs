using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Shaman.Roslyn.LinqRewrite.Extensions.OperatorExpressionExtensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Shaman.Roslyn.LinqRewrite.Extensions.VariableExtensions;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteAll
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == p.Chain.Count - 1) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            
            if (p.Chain[chainIndex].Arguments[0] is SimpleLambdaExpressionSyntax lambda)
            {
                p.AddToBody(IfStatement(Not(
                        p.Code.InlineOrCreateMethod(new Lambda(lambda), CreatePrimitiveType(SyntaxKind.BoolKeyword), p.LastItem)),
                    ReturnStatement(FalseValue)));
            }
            
            p.AddToPostfix(ReturnStatement(TrueValue));
        }
    }
}