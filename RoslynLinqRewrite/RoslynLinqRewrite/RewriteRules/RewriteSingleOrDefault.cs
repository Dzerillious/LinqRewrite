using Shaman.Roslyn.LinqRewrite.DataStructures;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Shaman.Roslyn.LinqRewrite.Extensions.OperatorExpressionExtensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.VariableExtensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteSingleOrDefault
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            var foundVariable = "__found" + chainIndex;
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            
            p.PreForAdd(LocalVariableCreation(foundVariable, NullableType(p.ReturnType), NullValue));

            if (p.Chain[chainIndex].Arguments.Length == 0)
            {
                p.ForAdd(If(foundVariable.EqualsExpr(NullValue),
                            foundVariable.Assign(p.LastItem), 
                            Else(Return(Default(p.ReturnType)))));
            }
            else
            {
                var method = p.Chain[chainIndex].Arguments[0];
                p.ForAdd(If(p.Code.InlineLambda(p.Semantic, method, p.LastItem),
                            If(foundVariable.EqualsExpr(NullValue),
                                foundVariable.Assign(p.LastItem),
                                Else(Return(Default(p.ReturnType))))));
            }
            
            p.PostForAdd(If(foundVariable.EqualsExpr(NullValue),
                            Return(Default(p.ReturnType)), 
                            Else(Return(foundVariable.Cast(p.ReturnType)))));
        }
    }
}