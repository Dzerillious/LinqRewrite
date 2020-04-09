using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSingleOrDefault
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            if (p.CanSimpleRewrite() && p.SimpleEnumeration && p.CurrentCollection?.Count == p.ResultSize && args.Length == 0) 
                p.SimpleRewrite = ConditionalExpression(p.CurrentCollection.Count.IsEqual(1),
                    ExpressionSimplifier.SimplifySubstitute(p.LastValue, p.CurrentIterator.ForIndexer, p.CurrentMin),
                    ConditionalExpression(p.ResultSize.IsEqual(0),
                        Default(p.ReturnType),
                        ThrowExpression("System.InvalidOperationException", "The sequence contains more than one element.")));
            
            var foundVariable = p.GlobalVariable(NullableType(p.ReturnType), null);
            if (args.Length == 0)
            {
                p.ForAdd(If(foundVariable.IsEqual(null),
                    foundVariable.Assign(p.LastValue), 
                    Throw("System.InvalidOperationException", "The sequence contains more than single matching element.")));
            }
            else
            {
                p.ForAdd(If(args[0].Inline(p, p.LastValue),
                    If(foundVariable.IsEqual(null),
                        foundVariable.Assign(p.LastValue),
                        Throw("System.InvalidOperationException", "The sequence contains more than single matching element."))));
            }
            
            p.ResultAdd(If(foundVariable.IsEqual(null),
                Return(Default(p.ReturnType)), 
                Return(foundVariable.Cast(p.ReturnType))));
        }
    }
}