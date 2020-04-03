using System;
using System.Collections.Generic;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteToDictionary
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            var keySelector = (LambdaExpressionSyntax)args[0];
            var elementSelectorValue = args.Length switch
            {
                1 => p.LastValue,
                _ when args[1].OldVal.IsInvokable(p) => args[1].Inline(p, p.LastValue),
                _ => p.LastValue
            };

            var dictionaryVariable = args.Length switch
            {
                2 when !(args[1].OldVal.IsInvokable(p)) => p.GlobalVariable(p.ReturnType, New(p.ReturnType, args[1])),
                3 => p.GlobalVariable(p.ReturnType, New(p.ReturnType, args[2])),
                _ => p.GlobalVariable(p.ReturnType, New(p.ReturnType))
            };

            p.ForAdd(dictionaryVariable.Access("Add").Invoke(keySelector.Inline(p, p.LastValue), elementSelectorValue));
            p.ResultAdd(Return(dictionaryVariable));
        }
    }
}