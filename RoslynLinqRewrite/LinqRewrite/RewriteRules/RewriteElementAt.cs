using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteElementAt
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            if (p.CanSimpleRewrite() && p.FirstCollection != null && args.Length == 0)
            {
                p.SimpleRewrite = p.FirstCollection[args[0]];
                return;
            }
            
            var positionValue = args[0].ReusableConst(p);
            p.ForAdd(If(p.Indexer.IsEqual(positionValue),
                        Return(p.LastValue)));
            
            p.FinalAdd(Throw("System.InvalidOperationException", "The sequence did not contain enough elements."));
        }
    }
}