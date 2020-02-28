using LinqRewrite.DataStructures;

namespace LinqRewrite.RewriteRules
{
    public class RewriteReverse
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (!p.ModifiedEnumeration)
            {
                p.IsReversed = !p.IsReversed;
                return;
            }
            else
            {
            }
            p.Indexer = null;
        }
    }
}