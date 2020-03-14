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
            var elementSelector = args.Length >= 2 && args[1].OldVal is LambdaExpressionSyntax 
                ? args[1].Inline(p, p.LastValue) : p.LastValue;


            var lookupType = (TypeBridge)ParseTypeName($"Lookup<{p.CurrentCollection.ItemType},{keySelector.ReturnType(p)}>");
            var lookup = args.Length switch
            {
                2 when !(args[1].OldVal is LambdaExpressionSyntax) => p.GlobalVariable(lookupType, New(lookupType, args[1])),
                3 => p.GlobalVariable(lookupType, New(lookupType, args[2])),
                _ => p.GlobalVariable(lookupType, New(lookupType))
            };
            p.ForAdd(lookup.ArrayAccess(keySelector.Inline(p, p.LastValue)).Assign(elementSelector));
            
            p.FinalAdd(Return(lookup));

            p.HasResultMethod = true;
        }
    }
}