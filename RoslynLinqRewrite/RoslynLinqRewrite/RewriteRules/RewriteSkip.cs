using LinqRewrite.DataStructures;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSkip
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            
            var skipped = p.Chain[chainIndex].Arguments[0];
            if (p.ListsEnumeration)
            {
                p.ForMin += skipped;
                p.ForReMax -= skipped;
                p.ResultSize -= skipped;
            }
            else
            {
                p.ForAdd(If(p.Indexer < skipped, Continue()));
                p.ModifiedEnumeration = true;
            }
            p.CurrentIndexer = null;
        }
    }
}