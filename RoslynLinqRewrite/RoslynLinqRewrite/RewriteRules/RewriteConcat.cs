using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.RewriteRules
{
    public class RewriteConcat
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            var sourceSize = p.SourceSize;
            var resultSize = p.ResultSize;
            
            var collection = p.Chain[chainIndex].Arguments[0];
            var indexer = p.CurrentIndexer;
            if (indexer != null && (ExpressionSyntax) indexer is IdentifierNameSyntax identifier && identifier.Identifier.ToString() == p.ForBody.Indexer)
                p.ForBody.GlobalIndexer = true;
            

            string itemName;
            if (p.LastItem != null && (ExpressionSyntax) p.LastItem is IdentifierNameSyntax lastIdentifier)
            {
                itemName = lastIdentifier.Identifier.ToString();
            }
            else
            {
                itemName = p.GetVariableName("__item");
                p.ForBody.BodyAdd(VariableExtensions.LocalVariableCreation(itemName, p.LastItem));
                p.LastItem = itemName;
            }
            
            p.AddFor(collection);
            if (indexer != null) p.ForBody.BodyAdd(indexer.PreIncrement());
            RewriteCollectionEnumeration.RewriteOther(p, collection, p.ForIndexerName, 0);
            p.Indexer = itemName;
            
            p.ForBody.BodyAdd(VariableExtensions.LocalVariableCreation(itemName, p.LastItem));
            p.LastItem = itemName;

            if (sourceSize != null && p.SourceSize != null) p.SourceSize = p.SourceSize.Add(sourceSize);
            else p.SourceSize = null;
            
            if (resultSize != null && p.ResultSize != null) p.ResultSize = p.ResultSize.Add(resultSize);
            else p.ResultSize = null;
        }

        public static ExpressionSyntax RewriteSimple(RewriteParameters p) 
            => p.Chain[0].Arguments.Length == 0 
                ? p.Code.CreateCollectionCount(p.Collection, false) 
                : null;
    }
}