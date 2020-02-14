using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using Shaman.Roslyn.LinqRewrite.Extensions;
using SyntaxExtensions = Shaman.Roslyn.LinqRewrite.Extensions.SyntaxExtensions;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteToList
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            var collectionType = p.Semantic.GetTypeInfo(p.Node).Type;
            var itemType = SymbolExtensions.GetItemType(collectionType)
                .GetTypeSyntaxFromExpression();
            
            RewriteToArray.RewriteOther(p, chainIndex, itemType);
            p.AddToPostfix(SyntaxFactory.ReturnStatement(
                SyntaxFactory.ObjectCreationExpression(p.ReturnType, 
                    SyntaxFactoryHelper.CreateArguments(SyntaxFactory.IdentifierName(RewriteToArray.ResultArrayName)),
                    null)));
        }
    }
}