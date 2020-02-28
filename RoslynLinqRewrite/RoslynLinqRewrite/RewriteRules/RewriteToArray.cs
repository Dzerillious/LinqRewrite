using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteToArray
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (p.Chain.Count == 1)
            {
                RewriteSimple(p, "__result");
                return;
            }
            var resultVariable = RewriteOther(p, chainIndex, "__result");
            if (p.ResultSize == null) p.PostForAdd(Return("SimpleCollections".Access("SimpleArrayExtensions", "EnsureFullArray")
                .Invoke(resultVariable, p.Indexer)));

            p.HasResultMethod = true;
        }
        
        public static VariableBridge RewriteOther(RewriteParameters p, int chainIndex, string resultName, TypeSyntax itemType = null)
        {
            if (chainIndex != p.Chain.Count - 1) throw new InvalidOperationException("ToArray should be last expression.");
            
            if (p.ResultSize != null) return KnownSize(p, resultName, itemType);
            else if (p.SourceSize != null) return KnownSourceSize(p, resultName);
            else return UnknownSourceSize(p, resultName);
        }

        private static VariableBridge KnownSize(RewriteParameters p, string resultName, TypeSyntax itemType = null)
        {
            var arrayType = itemType == null ? (ArrayTypeSyntax) p.ReturnType : ArrayType(itemType);
            var resultVariable = p.CreateLocalVariable(resultName, CreateArray(arrayType, p.ResultSize));

            p.ForAdd(resultVariable.ArrayAccess(p.Indexer).Assign(p.LastItem));
            
            p.PostForAdd(Return(resultVariable));
            return resultVariable;
        }

        private static VariableBridge KnownSourceSize(RewriteParameters p, string resultName)
        {
            var indexer = p.Indexer;
                
            var logVariable = p.CreateLocalVariable("__log",
                "SimpleCollections".Access("IntExtensions", "Log2")
                    .Invoke(p.SourceSize.Cast(SyntaxKind.UIntKeyword))
                    .Sub(3));
                
            p.PreForAdd(logVariable.SubAssign(logVariable.Mod(2)));
            var currentLengthVariable = p.CreateLocalVariable("__currentLength", 8);

            var resultType = (ArrayTypeSyntax) p.ReturnType;
            var resultVariable = p.CreateLocalVariable(resultName, CreateArray(resultType, p.ResultSize));

            p.ForAdd(If(p.Indexer.GeThan(currentLengthVariable),
                        "SimpleCollections".Access("EnlargeExtensions", "LogEnlargeArray")
                                .Invoke(Argument(2), 
                                    Argument(p.SourceSize), 
                                    RefArg(resultVariable), 
                                    RefArg(logVariable),
                                    OutArg(currentLengthVariable))));
                
            p.ForAdd(resultVariable.ArrayAccess(indexer).Assign(p.LastItem));
            return resultVariable;
        }

        private static VariableBridge UnknownSourceSize(RewriteParameters p, string resultName)
        {
            var indexer = p.Indexer;
            
            var currentLengthVariable = p.CreateLocalVariable("__currentLength", 8);
            var resultType = (ArrayTypeSyntax) p.ReturnType;
            var resultVariable = p.CreateLocalVariable(resultName, CreateArray(resultType, 8));
                
            p.ForAdd(If(p.Indexer.GeThan(currentLengthVariable),
                            "SimpleCollections".Access("EnlargeExtensions", "LogEnlargeArray")
                                    .Invoke(Argument(2), RefArg(resultVariable), RefArg(currentLengthVariable))));
                
            p.ForAdd(resultVariable.ArrayAccess(indexer).Assign(p.LastItem));
            p.HasResultMethod = true;
            return resultVariable;
        }

        private static void RewriteSimple(RewriteParameters p, string resultName)
        {
            var collectionType = p.Semantic.GetTypeFromExpression(p.Collection);
            var collectionName = collectionType.ToString();

            if (collectionType is ArrayTypeSyntax)
            {
                var count = p.Code.CreateCollectionCount(p.Collection, false);
                var resultVariable = p.CreateLocalVariable(resultName, CreateArray((ArrayTypeSyntax) p.ReturnType, count));
                p.PreForAdd("Array".Access("Copy")
                    .Invoke(p.Collection, 0, resultVariable, 0, count));
                p.PreForAdd(Return(resultVariable));
            }
        }
    }
}