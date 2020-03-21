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
            var hashsetVariable = p.GlobalVariable(hashsetType, args.Length switch
            {
                0 => New(hashsetType),
                1 => New(hashsetType, args[0])
            });
            
            p.ForAdd(If(Not(hashsetVariable.Access("Add").Invoke(p.LastValue)),
                        Continue()));
            
            p.ModifiedEnumeration = true;
        }
    }
}