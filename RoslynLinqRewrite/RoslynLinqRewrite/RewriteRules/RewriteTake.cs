using Shaman.Roslyn.LinqRewrite.DataStructures;
using static Shaman.Roslyn.LinqRewrite.Extensions.OperatorExpressionExtensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Shaman.Roslyn.LinqRewrite.Extensions.VariableExtensions;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteTake
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            var countVariable = "__count" + chainIndex;
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            
            var take = p.Chain[chainIndex].Arguments[0];
            if (!p.DifferentEnumeration)
            {
                p.ForMax = p.ForMin.Add(take);
                p.ForReMin = p.ForReMax.Sub(take);
            }
            else
            {
                p.PreForAdd(LocalVariableCreation(countVariable, 0));
                
                p.ForAdd(countVariable.PostIncrement());
                p.ForAdd(If(countVariable.GeThan(take), Break()));
            }
            p.LastIndex = null;
        }
    }
}