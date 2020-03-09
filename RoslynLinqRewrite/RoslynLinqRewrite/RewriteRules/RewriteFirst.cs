using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteFirst
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.Iterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            
            if (args.Length == 0)
                p.ForAdd(Return(p.Last.Value));
            else
            {
                p.ForAdd(If(args[0].Inline(p, p.Last),
                            Return(p.Last.Value)));
            }
            
            p.FinalAdd(CreateThrowException("System.InvalidOperationException", "The sequence did not contain any elements."));
            p.HasResultMethod = true;
        }

        public static ExpressionSyntax RewriteSimple(RewriteParameters p, RewrittenValueBridge[] args) 
            => args.Length == 0 ? p.CurrentCollection[0] : null;
    }
}