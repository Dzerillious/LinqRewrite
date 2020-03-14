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
            var elementSelector = args.Length >= 2 && args[1].OldVal is LambdaExpressionSyntax 
                ? args[1].Inline(p, p.LastValue) : p.LastValue;

            var dictType = (TypeBridge)ParseTypeName($"Dictionary<{p.CurrentCollection.ItemType},{keySelector.ReturnType(p)}>");
            var dictionary = args.Length switch
            {
                2 when !(args[1].OldVal is LambdaExpressionSyntax) => p.GlobalVariable(dictType, New(dictType, args[1])),
                3 => p.GlobalVariable(dictType, New(dictType, args[2])),
                _ => p.GlobalVariable(dictType, New(dictType))
            };

            p.ForAdd(dictionary.ArrayAccess(keySelector.Inline(p, p.LastValue)).Assign(elementSelector));
            
            p.FinalAdd(Return(dictionary));

            p.HasResultMethod = true;
        }
    }
}