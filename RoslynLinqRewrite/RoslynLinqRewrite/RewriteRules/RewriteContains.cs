using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteContains
    {
        public static void Rewrite(RewriteParameters p, ExpressionSyntax[] args)
        {
            if (p.Body == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<ExpressionSyntax>());
            
            var element = p.Node.ArgumentList.Arguments.First().Expression;
            if (args.Length == 1)
            {
                p.ForAdd(If(p.Last.Value.IsEqual(element),
                            Return(true)));
            }
            else
            {
                var inlined = args[1].Reusable(p);
                p.ForAdd(If(inlined.Access("Equals").Invoke(p.Last.Value, element),
                            Return(true)));
            }
            
            p.FinalAdd(Return(false));
            p.HasResultMethod = true;
        }
    }
}