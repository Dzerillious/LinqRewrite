﻿using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteFirstOrDefault
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.Iterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            if (p.ResultSize != null && args.Length == 0) p.SimpleRewrite = ConditionalExpression(
                p.CurrentCollection.Count.IsEqual(0),
                p.CurrentCollection[0],
                Default(p.ReturnType));
            
            if (args.Length == 0)
                p.ForAdd(Return(p.Last.Value));
            else
            {
                p.ForAdd(If(args[0].Inline(p, p.Last),
                            Return(p.Last.Value)));
            }
            
            p.FinalAdd(Return(Default(p.ReturnType)));
            p.HasResultMethod = true;
        }
    }
}