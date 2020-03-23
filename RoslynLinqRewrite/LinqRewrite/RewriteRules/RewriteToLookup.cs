using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteToLookup
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

            TypeBridge lookupType = ParseTypeName($"Lookup<{p.CurrentCollection.ItemType},{keySelector.ReturnType(p)}>");
            var lookupVariable = args.Length switch
            {
                2 when !(args[1].OldVal.IsInvokable(p)) => p.GlobalVariable(lookupType, New(lookupType, args[1])),
                3 => p.GlobalVariable(lookupType, New(lookupType, args[2])),
                _ => p.GlobalVariable(lookupType, New(lookupType))
            };
            
            p.ForAdd(lookupVariable.ArrayAccess(keySelector.Inline(p, p.LastValue)).Assign(elementSelectorValue));
            p.FinalAdd(Return(lookupVariable));
        }
    }
}