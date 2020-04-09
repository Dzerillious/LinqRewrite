using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteCast
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args, InvocationExpressionSyntax invocation)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());

            var access = (MemberAccessExpressionSyntax) invocation.Expression;
            var name = (GenericNameSyntax) access.Name;
            var type = name.TypeArgumentList.Arguments[0];

            p.LastValue = p.Unchecked ? new TypedValueBridge(type, p.LastValue.Cast(type))
                : new TypedValueBridge(type, p.LastValue.Cast(ParseTypeName("object")).Cast(type));
            p.ListEnumeration = false;
        }
    }
}