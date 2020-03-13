﻿using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteDistinct
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());

            var hashsetType = p.WrappedType("HashSet<", p.LastValue.Type, ">");
            
            var hashset = args.Length == 0 
                ? p.GlobalVariable(hashsetType, New(hashsetType))
                : p.GlobalVariable(hashsetType, New(hashsetType, args[0]));

            p.ForAdd(If(Not(hashset.Access("Add").Invoke(p.LastValue.Value)),
                        Continue()));
            
            p.ModifiedEnumeration = true;
        }
    }
}