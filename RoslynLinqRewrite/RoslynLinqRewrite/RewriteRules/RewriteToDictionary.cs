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
            var method = (LambdaExpressionSyntax)args[0];

            var dictType = (TypeBridge)ParseTypeName($"Dictionary<{p.CurrentCollection.ItemType},{method.ReturnType(p)}>");
            var dictionary = p.GlobalVariable(dictType, New(dictType));
            p.ForAdd(dictionary.ArrayAccess(method.Inline(p, p.LastValue)).Assign(p.LastValue));
            
            p.FinalAdd(Return(dictionary));

            p.HasResultMethod = true;
        }
    }
}