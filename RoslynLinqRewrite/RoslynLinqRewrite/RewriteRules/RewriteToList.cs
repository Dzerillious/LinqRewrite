using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteToList
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());

            TypeBridge listType = ParseTypeName($"List<{p.CurrentCollection.ItemType}>");
            var listVariable = p.GlobalVariable(listType, New(listType));
            p.ForAdd(listVariable.Access("Add").Invoke(p.LastValue));
            
            p.FinalAdd(Return(listVariable));
            p.HasResultMethod = true;
        }
    }
}