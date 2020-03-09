using System;
using LinqRewrite.DataStructures;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteAll
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.Iterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            
            p.ForAdd(If(!args[0].Inline(p, p.Last),
                        Return(false)));

            p.FinalAdd(Return(true));
            p.HasResultMethod = true;
        }
    }
}