using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using Shaman.Roslyn.LinqRewrite.Extensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Shaman.Roslyn.LinqRewrite.Extensions.OperatorExpressionExtensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Shaman.Roslyn.LinqRewrite.RewriteRules.RewriteToArray;
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
            
            RewriteOther(p, chainIndex, itemType);
            p.PostForAdd(Return(
                ObjectCreationExpression(p.ReturnType, 
                    CreateArguments(Argument(ResultVariable)),
                    null)));
        }
    }
}