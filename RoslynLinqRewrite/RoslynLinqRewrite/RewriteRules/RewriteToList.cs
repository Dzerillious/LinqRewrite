using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.RewriteRules.RewriteToArray;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteToList
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            var resultVariable = p.CreateVariable("__result");
            var collectionType = p.Semantic.GetTypeInfo(p.Node).Type;
            var itemType = SymbolExtensions.GetItemType(collectionType)
                .GetTypeSyntaxFromExpression();
            
            RewriteOther(p, chainIndex, resultVariable, itemType);
            p.PostForAdd(Return(New(p.ReturnType, resultVariable)));
           
            p.HasResultMethod = true;
        }
    }
}