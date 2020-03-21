﻿using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteAny
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            if (p.ResultSize != null && args.Length == 0) p.SimpleRewrite = p.CurrentCollection.Count >= 1;

            if (args.Length == 0)
                p.ForAdd(Return(true));
            else 
            {
                p.ForAdd(If(args[0].Inline(p, p.LastValue),
                            Return(true)));
            }
            
            p.FinalAdd(Return(false));
            p.HasResultMethod = true;
        }
    }
}