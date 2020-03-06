using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteAggregate
    {
        public static void Rewrite(RewriteParameters p, ExpressionSyntax[] args)
        {
            if (p.Body == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<ExpressionSyntax>());

            var resultVariable = p.LocalVariable(p.ReturnType, "__result",  p.Collection[0]);
            p.ForAdd(resultVariable.Assign(args[0].Inline(p, resultVariable, p.Last)));
            
            p.FinalAdd(Return(resultVariable));
            p.HasResultMethod = true;
        }
    }
}