using System;
using LinqRewrite.DataStructures;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSingle
    {
        public static void Rewrite(RewriteParameters p, ExpressionSyntax[] args)
        {
            if (p.Body == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<ExpressionSyntax>());
            
            var foundVariable = p.GlobalVariable(NullableType(p.ReturnType), "__found", Null);

            if (args.Length == 0)
            {
                p.ForAdd(If(foundVariable.IsEqual(Null),
                            foundVariable.Assign(p.Last.Value), 
                            CreateThrowException("System.InvalidOperationException", "The sequence contains more than single matching element.")));
            }
            else
            {
                p.ForAdd(If(args[0].Inline(p, p.Last),
                            If(foundVariable.IsEqual(Null),
                                foundVariable.Assign(p.Last.Value),
                                CreateThrowException("System.InvalidOperationException", "The sequence contains more than single matching element."))));
            }
            
            p.FinalAdd(If(foundVariable.IsEqual(Null),
                            CreateThrowException("System.InvalidOperationException", "The sequence did not contain any elements."), 
                            Return(foundVariable.Cast(p.ReturnType))));
            p.HasResultMethod = true;
        }

        public static ExpressionSyntax RewriteSimple(RewriteParameters p) 
            => p.Chain[0].Arguments.Length == 0 
                ? ConditionalExpression(p.Collection.Count(p).IsEqual(1),
                    p.Collection[0],
                    CreateThrowException("System.InvalidOperationException", "The sequence does not contain one element.")) 
                : null;
    }
}