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
            var result = RewriteToArray.RewriteOther(p, p.LastValue.Type);
            var listResultType = SyntaxFactory.ParseTypeName($"SimpleList<{p.LastValue.Type}>");

            var finalResult = p.GlobalVariable(listResultType);
            p.ResultAdd(finalResult.Assign(New(listResultType)));
            p.ResultAdd(finalResult.Access("Items").Assign(result));
            p.ResultAdd(finalResult.Access("Count").Assign(p.ResultSize ?? p.Indexer));
            p.ResultAdd(Return(finalResult));
        }
    }
}