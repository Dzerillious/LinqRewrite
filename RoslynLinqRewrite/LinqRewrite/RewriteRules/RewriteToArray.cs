using System;
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
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.IncompleteIterators.Count() <= 1 && RewriteSimplified(p))
                return;
            
            if (p.CurrentIterator ==  null)
                RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            
            var resultVariable = RewriteOther(p);
            if (p.ResultSize == null) p.ResultAdd(Return("LinqRewrite".Access("Core", "SimpleArrayExtensions", "EnsureFullArray")
                .Invoke(resultVariable, p.Indexer)));
            else p.ResultAdd(Return(resultVariable));
        }
        
        public static VariableBridge RewriteOther(RewriteParameters p, TypeSyntax itemType = null)
        {
            if (p.ResultSize != null) return KnownSize(p, itemType);
            else if (p.SourceSize != null) return KnownSourceSize(p, itemType);
            else return UnknownSourceSize(p, itemType);
        }

        private static VariableBridge KnownSize(RewriteParameters p, TypeSyntax itemType = null)
        {
            var arrayType = itemType == null ? (ArrayTypeSyntax) p.ReturnType : itemType.ArrayType();
            var resultVariable = p.GlobalVariable(arrayType, CreateArray(arrayType, p.ResultSize));

            p.ForAdd(resultVariable[p.Indexer].Assign(p.LastValue));
            return resultVariable;
        }

        private static VariableBridge KnownSourceSize(RewriteParameters p, TypeSyntax itemType = null)
        {
            var indexerVariable = p.Indexer;
                
            var logVariable = p.GlobalVariable(Int, 
                "LinqRewrite".Access("Core", "IntExtensions", "Log2")
                    .Invoke(Parenthesize(p.SourceSize).Cast(SyntaxKind.UIntKeyword)) - 3);
                
            p.PreUseAdd(logVariable.SubAssign(logVariable % 2));
            var currentLengthVariable = p.GlobalVariable(Int, 8);

            var resultType = itemType == null ? (ArrayTypeSyntax) p.ReturnType : itemType.ArrayType();
            var resultVariable = p.GlobalVariable(resultType, CreateArray(resultType, 8));

            p.ForAdd(If(p.Indexer >= currentLengthVariable,
                        "LinqRewrite".Access("Core", "EnlargeExtensions", "LogEnlargeArray")
                                .Invoke(2, 
                                    p.SourceSize, 
                                    RefArg(resultVariable), 
                                    RefArg(logVariable),
                                    OutArg(currentLengthVariable))));
                
            p.ForAdd(resultVariable[indexerVariable].Assign(p.LastValue));
            return resultVariable;
        }

        private static VariableBridge UnknownSourceSize(RewriteParameters p, TypeSyntax itemType = null)
        {
            var indexerVariable = p.Indexer;
            
            var currentLengthVariable = p.GlobalVariable(Int, 8);
            var resultType = itemType == null ? (ArrayTypeSyntax) p.ReturnType : itemType.ArrayType();
            var resultVariable = p.GlobalVariable(resultType, CreateArray(resultType, 8));
                
            p.ForAdd(If(p.Indexer >= currentLengthVariable,
                            "LinqRewrite".Access("Core", "EnlargeExtensions", "LogEnlargeArray")
                                    .Invoke(2, RefArg(resultVariable), RefArg(currentLengthVariable))));
                
            p.ForAdd(resultVariable[indexerVariable].Assign(p.LastValue));
            p.HasResultMethod = true;
            return resultVariable;
        }
        
        private static bool RewriteSimplified(RewriteParameters p)
        {
            if (p.CurrentIterator != null) p.CurrentIterator.IgnoreIterator = true;
            
            var minValue = p.CurrentMin;
            if (p.SimpleEnumeration && ExpressionSimplifier.TryGetInt(p.ResultSize, out var intSize) && intSize <= 30)
                return CreateTakeArray(p, minValue, intSize);

            if (!p.ListEnumeration) return false;
            if (p.CurrentCollection.CollectionType == CollectionType.Array)
            {
                var resultVariable = p.GlobalVariable(p.ReturnType, CreateArray((ArrayTypeSyntax) p.ReturnType, p.ResultSize));
                p.ResultAdd("System".Access("Array", "Copy")
                    .Invoke(p.CurrentCollection, minValue, resultVariable, 0, p.ResultSize));
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

        private static bool CreateTakeArray(RewriteParameters p, ValueBridge minValue, int intSize)
        {
            p.SimpleRewrite = CreateArray((ArrayTypeSyntax) p.ReturnType, p.ResultSize,
                Enumerable.Range(0, intSize).Select(x 
                    => (ExpressionSyntax) ExpressionSimplifier.SimplifySubstitute(p.LastValue, p.CurrentIterator.ForIndexer, minValue + x)));
            return true;
        }
    }
}