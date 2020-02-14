using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Shaman.Roslyn.LinqRewrite.Extensions.OperatorExpressionExtensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Shaman.Roslyn.LinqRewrite.Extensions.VariableExtensions;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteLastOrDefault
    {
        private const string FoundVariable = "__found";
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == p.Chain.Count - 1) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            
            p.PreForAdd(LocalVariableCreation(FoundVariable, NullableType(p.ReturnType), NullValue));

            if (p.Chain[chainIndex].Arguments.Length == 0)
            {
                p.ForAdd(FoundVariable.Assign(p.LastItem));
            }
            else if (p.Chain[chainIndex].Arguments[0] is SimpleLambdaExpressionSyntax lambda)
            {
                p.ForAdd(If(p.Code.InlineLambda(p.Semantic, lambda, p.LastItem),
                            FoundVariable.Assign(p.LastItem)));
            }
            
            p.PostForAdd(If(FoundVariable.EqualsExpr(NullValue),
                            Return(Default(p.ReturnType)), 
                            Else(Return(FoundVariable.Cast(p.ReturnType)))));
        }
    }
}