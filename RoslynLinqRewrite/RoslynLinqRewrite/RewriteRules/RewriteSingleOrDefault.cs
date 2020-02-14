using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Shaman.Roslyn.LinqRewrite.Extensions.OperatorExpressionExtensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Shaman.Roslyn.LinqRewrite.Extensions.VariableExtensions;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteSingleOrDefault
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == p.Chain.Count - 1) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            
            p.AddToPrefix(LocalVariableCreation("_found", NullableType(p.ReturnType), NullValue));

            if (p.Chain[chainIndex].Arguments.Length == 0)
            {
                p.AddToBody(IfStatement(EqualsExpr(IdentifierName("_found"), NullValue),
                    ExpressionStatement(Assign("_found", p.LastItem)), 
                    ElseClause(ReturnStatement(DefaultExpression(p.ReturnType)))));
            }
            else if (p.Chain[chainIndex].Arguments[0] is SimpleLambdaExpressionSyntax lambda)
            {
                p.AddToBody(IfStatement(p.Code.InlineOrCreateMethod(new Lambda(lambda),
                        CreatePrimitiveType(SyntaxKind.BoolKeyword), p.LastItem),
                    IfStatement(EqualsExpr(IdentifierName("_found"), NullValue),
                        ExpressionStatement(Assign("_found", p.LastItem)),
                        ElseClause((ReturnStatement(DefaultExpression(p.ReturnType)))))));
            }
            
            p.AddToPostfix(IfStatement(EqualsExpr(IdentifierName("_found"), NullValue),
                ReturnStatement(DefaultExpression(p.ReturnType)), 
                ElseClause(ReturnStatement(CastExpression(p.ReturnType, IdentifierName("_found"))))));
        }
    }
}