using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteToLookup
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            var method = (LambdaExpressionSyntax)args[0];

            var lookupType = (TypeBridge)ParseTypeName($"Lookup<{p.CurrentCollection.ItemType},{method.ReturnType(p)}>");
            var lookup = p.GlobalVariable(lookupType, New(lookupType));
            p.ForAdd(lookup.ArrayAccess(method.Inline(p, p.LastValue)).Assign(p.LastValue));
            
            p.FinalAdd(Return(lookup));

            p.HasResultMethod = true;
        }
    }
}