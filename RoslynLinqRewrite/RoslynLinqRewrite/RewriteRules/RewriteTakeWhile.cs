using System;
using LinqRewrite.DataStructures;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteTakeWhile
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.Iterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            
            p.Last = p.Last.Reusable(p);
            
            p.ForAdd(If(!args[0].Inline(p, p.Last),
                        Break()));

            p.ModifiedEnumeration = true;
        }
    }
}