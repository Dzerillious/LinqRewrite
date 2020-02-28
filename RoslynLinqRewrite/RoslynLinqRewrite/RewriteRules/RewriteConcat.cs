using LinqRewrite.DataStructures;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.RewriteRules
{
    public class RewriteConcat
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            
            var collection = p.Chain[chainIndex].Arguments[0];
            p.AddFor(collection);
            
            RewriteCollectionEnumeration.RewriteOther(p, collection, Constants.GlobalIndexerVariable, 0);
        }

        public static ExpressionSyntax RewriteSimple(RewriteParameters p) 
            => p.Chain[0].Arguments.Length == 0 
                ? p.Code.CreateCollectionCount(p.Collection, false) 
                : null;
    }
}