using System;
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

            TypeBridge dictType = ParseTypeName($"Dictionary<{p.CurrentCollection.ItemType},{keySelector.ReturnType(p)}>");
            var dictionaryVariable = args.Length switch
            {
                2 when !(args[1].OldVal.IsInvokable(p)) => p.GlobalVariable(dictType, New(dictType, args[1])),
                3 => p.GlobalVariable(dictType, New(dictType, args[2])),
                _ => p.GlobalVariable(dictType, New(dictType))
            };

            p.ForAdd(dictionaryVariable.ArrayAccess(keySelector.Inline(p, p.LastValue)).Assign(elementSelectorValue));
            p.FinalAdd(Return(dictionaryVariable));
            p.HasResultMethod = true;
        }
    }
}