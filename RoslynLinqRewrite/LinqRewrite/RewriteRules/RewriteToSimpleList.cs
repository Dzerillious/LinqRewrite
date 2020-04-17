using System.Linq;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.ExpressionSimplifier;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteToSimpleList
    {
        public static ExpressionSyntax SimpleRewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (!TryGetInt(p.ResultSize, out var intSize) || intSize > 20)
                return null;
            
            return CreateArray(p.CurrentCollection.ItemType.ArrayType(), p.ResultSize,
                Enumerable.Range(0, intSize).Select(x 
                    => (ExpressionSyntax) SimplifySubstitute(p.LastValue, p.CurrentIterator.ForIndexer, p.CurrentMin + x)))
                .Cast(p.ReturnType);
        }
        
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            var enlarging = args.FirstOrDefault()?.ToString() switch
            {
                "EnlargingCoefficient.By2" => 1,
                "EnlargingCoefficient.By4" => 2,
                "EnlargingCoefficient.By8" => 3,
                _ => 2
            };
            var result = RewriteToArray.RewriteOther(p, enlarging, p.LastValue.Type);
            var listResultType = ParseTypeName($"LinqRewrite.Core.SimpleList.SimpleList<{p.LastValue.Type}>");

            var finalResult = p.GlobalVariable(listResultType);
            p.ResultAdd(finalResult.Assign(New(listResultType)));
            p.ResultAdd(finalResult.Access("Items").Assign(result));
            p.ResultAdd(finalResult.Access("Count").Assign(p.ResultSize ?? p.Indexer));
            p.ResultAdd(Return(finalResult));
        }
    }
}