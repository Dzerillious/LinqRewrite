using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteElementAt
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.Iterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            
            var position = args[0].Reusable(p);
            p.ForAdd(If(p.Indexer.IsEqual(position),
                        Return(p.Last.Value)));
            
            p.FinalAdd(CreateThrowException("System.InvalidOperationException", "The sequence did not enough elements."));
            p.HasResultMethod = true;
        }

        public static ExpressionSyntax RewriteSimple(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.Chain[0].Arguments.Length == 0) return null;
            RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            
            return p.SourceSize == null ? null : p.CurrentCollection[args[0]];
        }
    }
}