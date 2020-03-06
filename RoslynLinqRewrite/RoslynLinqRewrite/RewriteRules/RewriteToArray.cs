using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Constants;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteToArray
    {
        public static void Rewrite(RewriteParameters p, ExpressionSyntax[] args)
        {
            if (p.Body == null)
            {
                RewriteSimple(p, "__result");
                return;
            }
            var resultVariable = RewriteOther(p, "__result");
            if (p.ResultSize == null) p.FinalAdd(Return("SimpleCollections".Access("SimpleArrayExtensions", "EnsureFullArray")
                .Invoke(resultVariable, p.Indexer)));

            p.HasResultMethod = true;
        }
        
        public static VariableBridge RewriteOther(RewriteParameters p, string resultName, TypeSyntax itemType = null)
        {
            if (p.ResultSize != null) return KnownSize(p, resultName, itemType);
            else if (p.SourceSize != null) return KnownSourceSize(p, resultName);
            else return UnknownSourceSize(p, resultName);
        }

        private static VariableBridge KnownSize(RewriteParameters p, string resultName, TypeSyntax itemType = null)
        {
            var arrayType = itemType == null ? (ArrayTypeSyntax) p.ReturnType : ArrayType(itemType);
            var resultVariable = p.GlobalVariable(arrayType, resultName, CreateArray(arrayType, p.ResultSize));

            p.ForAdd(resultVariable[p.Indexer].Assign(p.Last.Value));
            
            p.FinalAdd(Return(resultVariable));
            return resultVariable;
        }

        private static VariableBridge KnownSourceSize(RewriteParameters p, string resultName)
        {
            var indexer = p.Indexer;
                
            var logVariable = p.GlobalVariable(Int, "__log", 
                "SimpleCollections".Access("IntExtensions", "Log2")
                    .Invoke(p.SourceSize.Cast(SyntaxKind.UIntKeyword)) - 3);
                
            p.InitialAdd(logVariable.Assign(logVariable - logVariable % 2));
            var currentLengthVariable = p.GlobalVariable(Int, "__currentLength", 8);

            var resultType = (ArrayTypeSyntax) p.ReturnType;
            var resultVariable = p.GlobalVariable(resultType, resultName, CreateArray(resultType, p.ResultSize));

            p.ForAdd(If(p.Indexer >= currentLengthVariable,
                        "SimpleCollections".Access("EnlargeExtensions", "LogEnlargeArray")
                                .Invoke(2, 
                                    p.SourceSize, 
                                    RefArg(resultVariable), 
                                    RefArg(logVariable),
                                    OutArg(currentLengthVariable))));
                
            p.ForAdd(resultVariable[indexer].Assign(p.Last.Value));
            return resultVariable;
        }

        private static VariableBridge UnknownSourceSize(RewriteParameters p, string resultName)
        {
            var indexer = p.Indexer;
            
            var currentLengthVariable = p.GlobalVariable(Int, "__currentLength", 8);
            var resultType = (ArrayTypeSyntax) p.ReturnType;
            var resultVariable = p.GlobalVariable(Int, resultName, CreateArray(resultType, 8));
                
            p.ForAdd(If(p.Indexer >= currentLengthVariable,
                            "SimpleCollections".Access("EnlargeExtensions", "LogEnlargeArray")
                                    .Invoke(2, RefArg(resultVariable), RefArg(currentLengthVariable))));
                
            p.ForAdd(resultVariable[indexer].Assign(p.Last.Value));
            p.HasResultMethod = true;
            return resultVariable;
        }

        private static void RewriteSimple(RewriteParameters p, string resultName)
        {
            var collectionType = p.Semantic.GetTypeFromExpression(p.Collection);
            var collectionName = collectionType.ToString();

            if (collectionType is ArrayTypeSyntax)
            {
                var count = p.Collection.Count(p);
                var resultVariable = p.GlobalVariable(p.ReturnType, resultName, CreateArray((ArrayTypeSyntax) p.ReturnType, count));
                p.InitialAdd("Array".Access("Copy")
                    .Invoke(p.Collection, 0, resultVariable, 0, count));
                p.InitialAdd(Return(resultVariable));
            }
            else if (collectionName.StartsWith(ListPrefix, StringComparison.OrdinalIgnoreCase))
            {
                var count = p.Collection.Count(p);
                var resultVariable = p.GlobalVariable(p.ReturnType, resultName,
                    CreateArray((ArrayTypeSyntax) p.ReturnType, count));
                p.InitialAdd(p.Collection.Access("CopyTo").Invoke(resultVariable));
                p.InitialAdd(Return(resultVariable));
            }
            else p.NotRewrite = true;

            p.HasResultMethod = true;
        }
    }
}