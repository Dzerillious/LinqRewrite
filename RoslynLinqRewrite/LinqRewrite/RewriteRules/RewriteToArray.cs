using System.Linq;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteToArray
    {
        public static ExpressionSyntax SimpleRewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (!ExpressionSimplifier.TryGetInt(p.ResultSize, out var intSize) || intSize > 20)
                return null;

            var items = Enumerable.Range(0, intSize).Select(x
                => (ExpressionSyntax) ExpressionSimplifier.SimplifySubstitute(p.LastValue, p.CurrentIterator.ForIndexer, p.CurrentMin + x));
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
            if (p.IncompleteIterators.Count() <= 1 && RewriteSimplified(p))
            {
                p.CurrentIterator.IgnoreIterator = true;
                return;
            }
            
            var resultVariable = RewriteOther(p, enlarging);
            if (p.ResultSize == null) p.ResultAdd(Return("LinqRewrite".Access("Core", "SimpleArrayExtensions", "EnsureFullArray")
                .Invoke(resultVariable, p.Indexer)));
            else p.ResultAdd(Return(resultVariable));
        }
        
        public static VariableBridge RewriteOther(RewriteParameters p, int enlarging, TypeSyntax itemType = null)
        {
            if (p.ResultSize != null) return KnownSize(p, itemType);
            else if (p.SourceSize != null) return KnownSourceSize(p, enlarging, itemType);
            else return UnknownSourceSize(p, enlarging, itemType);
        }

        private static VariableBridge KnownSize(RewriteParameters p, TypeSyntax itemType = null)
        {
            var arrayType = itemType == null ? (ArrayTypeSyntax) p.ReturnType : itemType.ArrayType();
            var resultVariable = p.GlobalVariable(arrayType, CreateArray(arrayType, p.ResultSize));

            p.ForAdd(resultVariable[p.Indexer].Assign(p.LastValue));
            return resultVariable;
        }

        private static VariableBridge KnownSourceSize(RewriteParameters p, int enlarging, TypeSyntax itemType = null)
        {
            var indexerVariable = p.Indexer;
                
            var logVariable = p.GlobalVariable(Int, 
                "LinqRewrite".Access("Core", "IntExtensions", "Log2")
                    .Invoke(Parenthesize(p.SourceSize).Cast(SyntaxKind.UIntKeyword)) - 3);
                
            if (enlarging != 1) p.PreUseAdd(logVariable.SubAssign(logVariable % enlarging));
            var currentLengthVariable = p.GlobalVariable(Int, 8);

            var resultType = itemType == null ? (ArrayTypeSyntax) p.ReturnType : itemType.ArrayType();
            var resultVariable = p.GlobalVariable(resultType, CreateArray(resultType, 8));

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

        private static VariableBridge UnknownSourceSize(RewriteParameters p, int enlarging, TypeSyntax itemType = null)
        {
            var indexerVariable = p.Indexer;
            
            var currentLengthVariable = p.GlobalVariable(Int, 8);
            var resultType = itemType == null ? (ArrayTypeSyntax) p.ReturnType : itemType.ArrayType();
            var resultVariable = p.GlobalVariable(resultType, CreateArray(resultType, 8));
                
            p.ForAdd(If(p.Indexer >= currentLengthVariable,
                            "LinqRewrite".Access("Core", "EnlargeExtensions", "LogEnlargeArray")
                                    .Invoke(enlarging, RefArg(resultVariable), RefArg(currentLengthVariable))));
                
            p.ForAdd(resultVariable[indexerVariable].Assign(p.LastValue));
            return resultVariable;
        }
        
        private static bool RewriteSimplified(RewriteParameters p)
        {
            var minValue = p.CurrentMin;
            if (!p.ListEnumeration || p.CurrentCollection == null) return false;
            if (p.CurrentCollection.CollectionType == CollectionType.Array)
            {
                var resultVariable = p.GlobalVariable(p.ReturnType, CreateArray((ArrayTypeSyntax) p.ReturnType, p.ResultSize));
                p.ResultAdd("System".Access("Array", "Copy")
                    .Invoke(p.CurrentCollection, minValue, resultVariable, 0, p.ResultSize));
                p.ResultAdd(Return(resultVariable));
                return true;
            }
            else if (p.CurrentCollection.CollectionType == CollectionType.SimpleList)
            {
                var resultVariable = p.GlobalVariable(p.ReturnType, CreateArray((ArrayTypeSyntax) p.ReturnType, p.ResultSize));
                p.ResultAdd("System".Access("Array", "Copy")
                    .Invoke(p.CurrentCollection.Access("Items"), minValue, resultVariable, 0, p.ResultSize));
                p.ResultAdd(Return(resultVariable));
                return true;
            }
            else if (p.CurrentCollection.CollectionType == CollectionType.List)
            {
                var resultVariable = p.GlobalVariable(p.ReturnType,
                    CreateArray((ArrayTypeSyntax) p.ReturnType, p.ResultSize));
                p.ResultAdd(p.CurrentCollection.Access("CopyTo").Invoke(resultVariable));
                p.ResultAdd(Return(resultVariable));
                return true;
            }
            p.NotRewrite = true;
            return true;
        }
    }
}