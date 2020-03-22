using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteToSimpleList
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());

            var result = RewriteToArray.RewriteOther(p, p.LastValue.Type);
            var listResultType = SyntaxFactory.ParseTypeName($"SimpleList<{p.LastValue.Type}>");

            var finalResult = p.GlobalVariable(listResultType);
            p.FinalAdd(finalResult.Assign(New(listResultType)));
            p.FinalAdd(finalResult.Access("Items").Assign(result));
            p.FinalAdd(finalResult.Access("Count").Assign(p.ResultSize ?? p.Indexer));
            p.FinalAdd(Return(finalResult));
            p.HasResultMethod = true;
        }
    }
}