using Shaman.Roslyn.LinqRewrite.DataStructures;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public class RewriteReverse
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            p.IsReversed = !p.IsReversed;
        }
    }
}