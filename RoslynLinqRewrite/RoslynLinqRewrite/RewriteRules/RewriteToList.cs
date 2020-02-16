using Microsoft.CodeAnalysis.CSharp;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using Shaman.Roslyn.LinqRewrite.Extensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Shaman.Roslyn.LinqRewrite.RewriteRules.RewriteToArray;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteToList
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            var collectionType = p.Semantic.GetTypeInfo(p.Node).Type;
            var itemType = SymbolExtensions.GetItemType(collectionType)
                .GetTypeSyntaxFromExpression();
            
            RewriteOther(p, chainIndex, itemType);
            p.PostForAdd(Return(New(p.ReturnType, Constants.GlobalResultVariable)));
        }
    }
}