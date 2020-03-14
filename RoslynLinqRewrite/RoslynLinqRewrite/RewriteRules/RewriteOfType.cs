using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteOfType
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args, InvocationExpressionSyntax invocation)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());

            var access = (MemberAccessExpressionSyntax) invocation.Expression;
            var name = (GenericNameSyntax) access.Name;
            var type = name.TypeArgumentList.Arguments[0];

            p.LastValue = p.LastValue.ReusableConst(p);
            p.ForAdd(If(Not(p.LastValue.Is(type)),
                        Continue()));

            p.LastValue = new TypedValueBridge(type, p.LastValue.Value.Cast(type));

            p.ResultSize = null;
            p.ModifiedEnumeration = true;
        }
    }
}