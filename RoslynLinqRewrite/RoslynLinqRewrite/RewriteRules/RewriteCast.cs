using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteCast
    {
        public static void Rewrite(RewriteParameters p, ExpressionSyntax[] args, InvocationExpressionSyntax invocation)
        {
            if (p.Iterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<ExpressionSyntax>());

            var access = (MemberAccessExpressionSyntax) invocation.Expression;
            var name = (GenericNameSyntax) access.Name;
            var type = name.TypeArgumentList.Arguments[0];

            p.Last = new TypedValueBridge(type, p.Last.Cast(type));
            p.ListEnumeration = false;
        }
    }
}