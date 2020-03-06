﻿using System;
using LinqRewrite.DataStructures;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteOfType
    {
        public static void Rewrite(RewriteParameters p, ExpressionSyntax[] args, InvocationExpressionSyntax invocation)
        {
            if (p.Body == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<ExpressionSyntax>());

            var access = (MemberAccessExpressionSyntax) invocation.Expression;
            var name = (GenericNameSyntax) access.Name;
            var type = name.TypeArgumentList.Arguments[0];

            p.Last = p.Last.Reusable(p);
            p.ForAdd(If(!p.Last.Is(type),
                        Continue()));

            p.Last = new TypedValueBridge(type, p.Last.Value.Cast(type));

            p.ResultSize = null;
            p.ModifiedEnumeration = true;
        }
    }
}