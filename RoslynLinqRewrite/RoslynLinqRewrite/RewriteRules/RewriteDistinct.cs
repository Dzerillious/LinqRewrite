using System;
using System.Collections.Generic;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public class RewriteDistinct
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.Iterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());

            var hashsetType = p.WrappedType("HashSet<", p.Last.Type, ">");
            
            var hashset = args.Length == 0 
                ? p.GlobalVariable(hashsetType, New(hashsetType))
                : p.GlobalVariable(hashsetType, New(hashsetType, args[0]));

            p.ForAdd(If(Not(hashset.Access("Add").Invoke(p.Last.Value)),
                Continue()));
            
            p.ModifiedEnumeration = true;
        }
    }
}