using LinqRewrite.DataStructures;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteOfType
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);

            var access = (MemberAccessExpressionSyntax) p.Chain[chainIndex].Invocation.Expression;
            var name = (GenericNameSyntax) access.Name;
            var type = name.TypeArgumentList.Arguments[0];

            p.Last = p.Last.Reusable(p);
            p.ForAdd(If(Not(SyntaxFactory.IsPatternExpression(p.Last.Type, SyntaxFactory.ConstantPattern(type))),
                        Continue()));

            p.Last = (p.Last.Value.Cast(type), type);

            p.ResultSize = null;
            p.ModifiedEnumeration = true;
        }
    }
}