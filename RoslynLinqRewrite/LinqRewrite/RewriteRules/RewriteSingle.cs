﻿using System;
using LinqRewrite.DataStructures;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSingle
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            if (p.ResultSize != null && args.Length == 0) p.SimpleRewrite = ConditionalExpression(p.CurrentCollection.Count.IsEqual(1),
                p.CurrentCollection[0],
                CreateThrowException("System.InvalidOperationException", "The sequence does not contain one element."));
            
            var foundVariable = p.GlobalVariable(NullableType(p.ReturnType), null);
            if (args.Length == 0)
            {
                p.ForAdd(If(foundVariable.IsEqual(null),
                            foundVariable.Assign(p.LastValue), 
                            CreateThrowException("System.InvalidOperationException", "The sequence contains more than single matching element.")));
            }
            else
            {
                p.ForAdd(If(args[0].Inline(p, p.LastValue),
                            If(foundVariable.IsEqual(null),
                                foundVariable.Assign(p.LastValue),
                                CreateThrowException("System.InvalidOperationException", "The sequence contains more than single matching element."))));
            }
            
            p.FinalAdd(If(foundVariable.IsEqual(null),
                            CreateThrowException("System.InvalidOperationException", "The sequence did not contain any elements."), 
                            Return(foundVariable.Cast(p.ReturnType))));
            p.HasResultMethod = true;
        }
    }
}