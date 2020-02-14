using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Shaman.Roslyn.LinqRewrite.Extensions.OperatorExpressionExtensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Shaman.Roslyn.LinqRewrite.Extensions.VariableExtensions;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteSingle
    {
        private const string FoundVariable = "__found";
        
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == p.Chain.Count - 1) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            
            p.PreForAdd(LocalVariableCreation("__found", NullableType(p.ReturnType), NullValue));

            if (p.Chain[chainIndex].Arguments.Length == 0)
            {
                p.ForAdd(If(FoundVariable.EqualsExpr(NullValue),
                            FoundVariable.Assign(p.LastItem), 
                            Else(CreateThrowException("System.InvalidOperationException",
                                "The sequence contains more than single matching element."))));
            }
            else if (p.Chain[chainIndex].Arguments[0] is SimpleLambdaExpressionSyntax lambda)
            {
                p.ForAdd(If(p.Code.InlineLambda(p.Semantic, lambda, p.LastItem),
                            If(FoundVariable.EqualsExpr(NullValue),
                                FoundVariable.Assign(p.LastItem),
                                Else(CreateThrowException("System.InvalidOperationException",
                                    "The sequence contains more than single matching element.")))));
            }
            
            p.PostForAdd(If(FoundVariable.EqualsExpr(NullValue),
                            CreateThrowException("System.InvalidOperationException", "The sequence did not contain any elements."), 
                            Else(Return(FoundVariable.Cast(p.ReturnType)))));
        }
    }
}