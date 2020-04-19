using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.ExpressionSimplifier;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteToArray
    {
        public static ExpressionSyntax SimpleRewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (!TryGetInt(p.ResultSize, out var intSize) || intSize > 20)
                return null;

            var items = Enumerable.Range(0, intSize).Select(x
                => (ExpressionSyntax) SimplifySubstitute(p.LastValue, p.CurrentIterator.ForIndexer, p.CurrentMin + x));
            return CreateArray((ArrayTypeSyntax) p.ReturnType, p.ResultSize, items);
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

            var (currentLength, currentResult) = GetResultVariable(p, p.LastValue.Type);
            SimplifyPart(p, currentResult);
            RewriteOther(p, currentLength, currentResult, enlarging);
            
            if (p.ResultSize == null) p.ResultAdd(Return("LinqRewrite".Access("Core", "SimpleArrayExtensions", "EnsureFullArray")
                .Invoke(currentResult, p.Indexer)));
            else p.ResultAdd(Return(currentResult));
        }

        public static VariableBridge RewriteOther(RewriteParameters p, ValueBridge currentLength, VariableBridge resultVariable, int enlarging)
        {
            if (p.ResultSize != null) return KnownSize(p, resultVariable);
            else if (p.SourceSize != null) return KnownSourceSize(p, currentLength, resultVariable, enlarging);
            else return UnknownSourceSize(p, currentLength, resultVariable, enlarging);
        }

        private static VariableBridge KnownSize(RewriteParameters p, VariableBridge resultVariable)
        {
            p.ForAdd(resultVariable[p.Indexer].Assign(p.LastValue));
            return resultVariable;
        }

        private static VariableBridge KnownSourceSize(RewriteParameters p, ValueBridge currentLength, VariableBridge resultVariable, int enlarging)
        {
            var indexerVariable = p.Indexer;
                
            var logVariable = p.GlobalVariable(Int, 
                "LinqRewrite".Access("Core", "IntExtensions", "Log2")
                    .Invoke(Parenthesize(p.SourceSize).Cast(SyntaxKind.UIntKeyword)) - 3);
                
            if (enlarging != 1) p.PreUseAdd(logVariable.SubAssign(logVariable % enlarging));
            var currentLengthVariable = p.GlobalVariable(Int, currentLength);

            p.ForAdd(If(p.Indexer >= currentLengthVariable,
                        "LinqRewrite".Access("Core", "EnlargeExtensions", "LogEnlargeArray")
                                .Invoke(enlarging, 
                                    p.SourceSize, 
                                    RefArg(resultVariable), 
                                    RefArg(logVariable),
                                    OutArg(currentLengthVariable))));
                
            p.ForAdd(resultVariable[indexerVariable].Assign(p.LastValue));
            return resultVariable;
        }

        private static VariableBridge UnknownSourceSize(RewriteParameters p, ValueBridge currentLength, VariableBridge resultVariable, int enlarging)
        {
            var indexerVariable = p.Indexer;
            
            var currentLengthVariable = p.GlobalVariable(Int, currentLength);
            p.ForAdd(If(p.Indexer >= currentLengthVariable,
                            "LinqRewrite".Access("Core", "EnlargeExtensions", "LogEnlargeArray")
                                    .Invoke(enlarging, RefArg(resultVariable), RefArg(currentLengthVariable))));
                
            p.ForAdd(resultVariable[indexerVariable].Assign(p.LastValue));
            return resultVariable;
        }

        public static (ValueBridge currentLength, VariableBridge result) GetResultVariable(RewriteParameters p, TypeSyntax itemType)
        {
            var arrayType = itemType == null ? (ArrayTypeSyntax) p.ReturnType : itemType.ArrayType();
            if (p.ResultSize != null)
                return (p.ResultSize, p.GlobalVariable(arrayType, CreateArray(arrayType, p.ResultSize)));
            
            var currentResult = p.IncompleteIterators.TakeWhile(x =>
            {
                if (!TryGetInt(x.ForInc, out var inc)) return false;
                return x.Collection != null && !x.IsReversed && x.ListEnumeration && x.ForFrom != null
                       && x.ForTo != null && inc == 1;
            }).Aggregate((ValueBridge)0, (x, y) 
                => x + (y.IsReversed ? (y.ForFrom - y.ForTo + 1) : (y.ForTo - y.ForFrom + 1)), 
                x => x.Simplify());
            
            if (TryGetInt(currentResult, out var currentResultInt) && currentResultInt <= 8)
                currentResult = 8;
            
            return (currentResult, p.GlobalVariable(arrayType, CreateArray(arrayType, currentResult)));
        }

        public static void SimplifyPart(RewriteParameters p, VariableBridge resultVariable)
        {
            var hadInvalid = false;
            p.IncompleteIterators.ForEach(x =>
            {
                if (!TryGetInt(x.ForInc, out var inc) || x.Collection == null || x.IsReversed
                    || !x.ListEnumeration || x.ForFrom == null || x.ForTo == null || inc != 1
                    || (p.ResultSize == null && hadInvalid))
                {
                    hadInvalid = true;
                    return;
                }
                if (x.Collection.CollectionType == CollectionType.Array)
                {
                    var count = (x.IsReversed ? (x.ForFrom - x.ForTo + 1) : (x.ForTo - x.ForFrom + 1)).Simplify();
                    x.PreFor.Add((StatementBridge)"System".Access("Array", "Copy")
                        .Invoke(x.Collection, x.ForFrom, resultVariable, p.Indexer, count));
                    x.PreFor.Add((StatementBridge)p.Indexer.AddAssign(count));
                    x.IgnoreIterator = true;
                }
                else if (x.Collection.CollectionType == CollectionType.SimpleList)
                {
                    var count = (x.IsReversed ? (x.ForFrom - x.ForTo + 1) : (x.ForTo - x.ForFrom + 1)).Simplify();
                    x.PreFor.Add((StatementBridge)"System".Access("Array", "Copy")
                        .Invoke(x.Collection.Access("Items"), x.ForFrom, resultVariable, p.Indexer, count));
                    x.PreFor.Add((StatementBridge)p.Indexer.AddAssign(count));
                    x.IgnoreIterator = true;
                }
                else if (p.CurrentCollection.CollectionType == CollectionType.List)
                {
                    var count = (x.IsReversed ? (x.ForFrom - x.ForTo + 1) : (x.ForTo - x.ForFrom + 1)).Simplify();
                    x.PreFor.Add((StatementBridge) p.CurrentCollection.Access("CopyTo")
                        .Invoke(x.ForFrom, resultVariable, p.Indexer, count));
                    x.PreFor.Add((StatementBridge)p.Indexer.AddAssign(count));
                    x.IgnoreIterator = true;
                }
            });
        }
    }
}