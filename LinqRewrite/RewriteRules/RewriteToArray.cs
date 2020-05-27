using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.AssertionExtension;
using static LinqRewrite.Extensions.ExpressionSimplifier;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteToArray
    {
        public static ExpressionSyntax SimpleRewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            if (!TryGetInt(design.ResultSize, out var intSize) || intSize > Constants.SimpleRewriteMaxSimpleElements)
                return null;

            var items = Enumerable.Range(0, intSize).Select(x
                => (ExpressionSyntax) SimplifySubstitute(design.LastValue, design.CurrentIterator.ForIndexer, design.CurrentMin + x));
            return CreateArray((ArrayTypeSyntax) design.ReturnType, design.ResultSize, items);
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

            var (currentLength, currentResult) = GetResultVariable(design, design.LastValue.Type);
            SimplifyPart(design, currentResult);
            RewriteOther(design, currentLength, currentResult, enlarging);
            
            if (design.ResultSize == null) design.ResultAdd(Return("LinqRewrite".Access("Core", "SimpleArrayExtensions", "EnsureFullArray")
                .Invoke(currentResult, design.Indexer)));
            else design.ResultAdd(Return(currentResult));
        }

        public static VariableBridge RewriteOther(RewriteDesign design, ValueBridge currentLength, VariableBridge resultVariable, int enlarging)
        {
            if (design.ResultSize != null) return KnownSize(design, resultVariable);
            if (design.SourceSize != null) return KnownSourceSize(design, currentLength, resultVariable, enlarging);
            return UnknownSourceSize(design, currentLength, resultVariable, enlarging);
        }

        private static VariableBridge KnownSize(RewriteDesign design, VariableBridge resultVariable)
        {
            if (TryGetInt(design.ResultSize, out var resultInt) && resultInt < 0)
                InitialErrorAdd(design, Return("System".Access("Array", $"Empty<{design.LastValue.Type}>").Invoke()));
            design.ForAdd(resultVariable[design.Indexer].Assign(design.LastValue));
            return resultVariable;
        }

        private static VariableBridge KnownSourceSize(RewriteDesign design, ValueBridge currentLength, VariableBridge resultVariable, int enlarging)
        {
            var logVariable = CreateGlobalVariable(design, Int, 
                "LinqRewrite".Access("Core", "IntExtensions", "Log2")
                    .Invoke(Parenthesize(design.SourceSize).Cast(SyntaxKind.UIntKeyword)) - Constants.MinArraySizeLog);
                
            if (enlarging != 1) design.PreUseAdd(logVariable.Assign(
                SyntaxFactory.ConditionalExpression(logVariable.GThan(enlarging), 
                    logVariable - logVariable % enlarging,
                    IntValue(enlarging))));
            else design.PreUseAdd(logVariable.Assign(
                SyntaxFactory.ConditionalExpression(logVariable.GThan(1), 
                    logVariable,
                    IntValue(1))));
            
            var currentLengthVariable = CreateGlobalVariable(design, Int, currentLength);

            design.ForAdd(If(design.Indexer >= currentLengthVariable,
                        "LinqRewrite".Access("Core", "EnlargeExtensions", "LogEnlargeArray")
                                .Invoke(enlarging, 
                                    design.SourceSize, 
                                    RefArg(resultVariable), 
                                    RefArg(logVariable),
                                    OutArg(currentLengthVariable))));
                
            design.ForAdd(resultVariable[design.Indexer].Assign(design.LastValue));
            return resultVariable;
        }

        private static VariableBridge UnknownSourceSize(RewriteDesign design, ValueBridge currentLength, VariableBridge resultVariable, int enlarging)
        {
            var currentLengthVariable = CreateGlobalVariable(design, Int, currentLength);
            design.ForAdd(If(design.Indexer >= currentLengthVariable,
                            "LinqRewrite".Access("Core", "EnlargeExtensions", "LogEnlargeArray")
                                    .Invoke(enlarging, RefArg(resultVariable), RefArg(currentLengthVariable))));
                
            design.ForAdd(resultVariable[design.Indexer].Assign(design.LastValue));
            return resultVariable;
        }

        public static (ValueBridge currentLength, VariableBridge result) GetResultVariable(RewriteDesign design, TypeSyntax itemType)
        {
            var arrayType = itemType.ArrayType();
            if (design.ResultSize != null) return (design.ResultSize, CreateGlobalVariable(design, arrayType, CreateArray(arrayType, design.ResultSize)));
            
            var currentResult = design.IncompleteIterators.TakeWhile(x =>
            {
                if (!TryGetInt(x.ForInc, out var inc)) return false;
                return x.Collection != null 
                       && !x.IsReversed && x.ListEnumeration 
                       && x.ForFrom != null && x.ForTo != null && inc == 1;
            }).Aggregate((ValueBridge)0, (x, y) => x + (y.IsReversed ? y.ForFrom - y.ForTo + 1 : y.ForTo - y.ForFrom + 1));
            
            currentResult = currentResult.Simplify();
            if (TryGetInt(currentResult, out var currentResultInt) && currentResultInt <= Constants.MinArraySize)
                currentResult = Constants.MinArraySize;
            
            return (currentResult, CreateGlobalVariable(design, arrayType, CreateArray(arrayType, currentResult)));
        }

        public static void SimplifyPart(RewriteDesign design, VariableBridge resultVariable)
        {
            var hadInvalid = false;
            design.IncompleteIterators.ForEach(x =>
            {
                if (!TryGetInt(x.ForInc, out var inc) || x.Collection == null || x.IsReversed
                    || !x.ListEnumeration || x.ForFrom == null || x.ForTo == null || inc != 1
                    || (design.ResultSize == null && hadInvalid))
                {
                    hadInvalid = true;
                    return;
                }
                if (x.Collection.CollectionType == CollectionType.Array)
                {
                    var count = (x.IsReversed ? x.ForFrom - x.ForTo + 1 : x.ForTo - x.ForFrom + 1).Simplify();
                    x.PostFor.Add((StatementBridge)"LinqRewrite".Access("Core", "EnlargeExtensions", "ArrayCopy")
                        .Invoke(x.Collection, x.ForFrom, resultVariable, design.Indexer, count));
                    x.PostFor.Add((StatementBridge)design.Indexer.AddAssign(count));
                    x.IgnoreIterator = true;
                }
                else if (x.Collection.CollectionType == CollectionType.SimpleList)
                {
                    var count = (x.IsReversed ? x.ForFrom - x.ForTo + 1 : x.ForTo - x.ForFrom + 1).Simplify();
                    x.PostFor.Add((StatementBridge)"LinqRewrite".Access("Core", "EnlargeExtensions", "ArrayCopy")
                        .Invoke(x.Collection.Access("Items"), x.ForFrom, resultVariable, design.Indexer, count));
                    x.PostFor.Add((StatementBridge)design.Indexer.AddAssign(count));
                    x.IgnoreIterator = true;
                }
                else if (design.CurrentCollection.CollectionType == CollectionType.List)
                {
                    var count = (x.IsReversed ? x.ForFrom - x.ForTo + 1 : x.ForTo - x.ForFrom + 1).Simplify();
                    x.PostFor.Add((StatementBridge) design.CurrentCollection.Access("CopyTo")
                        .Invoke(x.ForFrom, resultVariable, design.Indexer, count));
                    x.PostFor.Add((StatementBridge)design.Indexer.AddAssign(count));
                    x.IgnoreIterator = true;
                }
            });
        }
    }
}