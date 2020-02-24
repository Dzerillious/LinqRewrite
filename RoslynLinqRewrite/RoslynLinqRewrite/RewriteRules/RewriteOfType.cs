using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using static Shaman.Roslyn.LinqRewrite.Extensions.OperatorExpressionExtensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteOfType
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);

            var access = (MemberAccessExpressionSyntax) p.Chain[chainIndex].Invocation.Expression;
            var name = (GenericNameSyntax) access.Name;
            var type = name.TypeArgumentList.Arguments[0];

            p.LastItem = p.LastItem.Reusable(p);
            p.ForAdd(If(Not(SyntaxFactory.IsPatternExpression(p.LastItem, SyntaxFactory.ConstantPattern(type))),
                Continue()));

            p.LastItem = p.LastItem.Cast(type);

            p.ResultSize = null;
            p.DifferentEnumeration = true;
        }
    }
}