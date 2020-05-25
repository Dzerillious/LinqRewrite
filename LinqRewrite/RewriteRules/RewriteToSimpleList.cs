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
        public static ExpressionSyntax SimpleRewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            if (!TryGetInt(design.ResultSize, out var intSize) || intSize > Constants.SimpleRewriteMaxSimpleElements)
                return null;
            
            return CreateArray(design.CurrentCollection.ItemType.ArrayType(), design.ResultSize,
                Enumerable.Range(0, intSize).Select(x 
                    => (ExpressionSyntax) SimplifySubstitute(design.LastValue, design.CurrentIterator.ForIndexer, design.CurrentMin + x)))
                .Cast(design.ReturnType);
        }
        
        public static void Rewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            var enlarging = args.FirstOrDefault()?.ToString() switch
            {
                "EnlargingCoefficient.By2" => 1,
                "EnlargingCoefficient.By4" => 2,
                "EnlargingCoefficient.By8" => 3,
                _ when design.SourceSize != null => 2,
                _ => 1
            };
            
            var (currentLength, currentResult) = RewriteToArray.GetResultVariable(design, design.LastValue.Type);
            VariableBridge result = RewriteToArray.RewriteOther(design, currentLength, currentResult, enlarging);
            RewriteToArray.SimplifyPart(design, result);
            
            var listResultType = ParseTypeName($"LinqRewrite.Core.SimpleList.SimpleList<{design.LastValue.Type}>");
            LocalVariable finalResult = CreateGlobalVariable(design, listResultType);
            design.ResultAdd(finalResult.Assign(New(listResultType)));
            design.ResultAdd(finalResult.Access("Items").Assign(result));
            design.ResultAdd(finalResult.Access("Count").Assign(design.ResultSize ?? design.Indexer));
            design.ResultAdd(Return(finalResult));
        }
    }
}