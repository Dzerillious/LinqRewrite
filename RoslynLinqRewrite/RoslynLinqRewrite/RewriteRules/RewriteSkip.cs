using Shaman.Roslyn.LinqRewrite.DataStructures;
using static Shaman.Roslyn.LinqRewrite.Extensions.OperatorExpressionExtensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Shaman.Roslyn.LinqRewrite.Extensions.VariableExtensions;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteSkip
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            var countVariable = "__count" + chainIndex;
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            
            var skipped = p.Chain[chainIndex].Arguments[0];
            if (!p.DifferentEnumeration)
            {
                p.ForMin = p.ForMin.Add(skipped);
                p.ForReMax = p.ForReMin.Sub(skipped);
            }
            else
            {
                p.PreForAdd(LocalVariableCreation(countVariable, 0));
                
                p.ForAdd(If(countVariable.LThan(skipped), Continue()));
                p.ForAdd(countVariable.PostIncrement());
            }
            p.LastIndex = null;
        }
    }
}