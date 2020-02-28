using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using Shaman.Roslyn.LinqRewrite.Extensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Shaman.Roslyn.LinqRewrite.Constants;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Shaman.Roslyn.LinqRewrite.Extensions.VariableExtensions;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteToArray
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            var resultVariable = p.CreateVariable("__result");
            if (p.Chain.Count == 1)
            {
                RewriteSimple(p, resultVariable);
                return;
            }
            RewriteOther(p, chainIndex, resultVariable);
            if (p.ResultSize == null) p.PostForAdd(Return("SimpleCollections".Access("SimpleArrayExtensions", "EnsureFullArray")
                .Invoke(resultVariable, p.Indexer)));

            p.HasResultMethod = true;
        }
        
        public static void RewriteOther(RewriteParameters p, int chainIndex, VariableBridge resultVariable, TypeSyntax itemType = null)
        {
            if (chainIndex != p.Chain.Count - 1) throw new InvalidOperationException("ToArray should be last expression.");
            
            if (p.ResultSize != null) KnownSize(p, resultVariable, itemType);
            else if (p.SourceSize != null) KnownSourceSize(p, resultVariable);
            else UnknownSourceSize(p, resultVariable);
        }

        private static void KnownSize(RewriteParameters p, VariableBridge resultVariable, TypeSyntax itemType = null)
        {
            var arrayType = itemType == null ? (ArrayTypeSyntax) p.ReturnType : ArrayType(itemType);
            p.PreForAdd(CreateLocalArray(resultVariable, arrayType, p.ResultSize));

            p.ForAdd(resultVariable.ArrayAccess(p.Indexer).Assign(p.LastItem));
            
            p.PostForAdd(Return(resultVariable));
        }

        private static void KnownSourceSize(RewriteParameters p, VariableBridge resultVariable)
        {
            var logVariable = p.CreateVariable("__log");
            var currentLengthVariable = p.CreateVariable("__currentLength");
            var indexer = p.Indexer;
                
            p.PreForAdd(LocalVariableCreation(logVariable, 
                        "SimpleCollections".Access("IntExtensions", "Log2")
                                .Invoke(p.SourceSize.Cast(SyntaxKind.UIntKeyword))
                                    .Sub(3)));
                
            p.PreForAdd(logVariable.SubAssign(logVariable.Mod(2)));
            p.PreForAdd(LocalVariableCreation(currentLengthVariable, 8));

            var result = (ArrayTypeSyntax) p.ReturnType;
            p.PreForAdd(CreateLocalArray(resultVariable, result, 8));

            p.ForAdd(If(p.Indexer.GeThan(currentLengthVariable),
                        "SimpleCollections".Access("EnlargeExtensions", "LogEnlargeArray")
                                .Invoke(Argument(2), 
                                    Argument(p.SourceSize), 
                                    RefArg(resultVariable), 
                                    RefArg(logVariable),
                                    OutArg(currentLengthVariable))));
                
            p.ForAdd(resultVariable.ArrayAccess(indexer).Assign(p.LastItem));
        }

        private static void UnknownSourceSize(RewriteParameters p, VariableBridge resultVariable)
        {
            var currentLengthVariable = p.CreateVariable("__currentLength");
            var indexer = p.Indexer;
            
            p.PreForAdd(LocalVariableCreation(currentLengthVariable, 8));
            var result = (ArrayTypeSyntax) p.ReturnType;
            p.PreForAdd(CreateLocalArray(resultVariable, result, 8));
                
            p.ForAdd(If(p.Indexer.GeThan(currentLengthVariable),
                            "SimpleCollections".Access("EnlargeExtensions", "LogEnlargeArray")
                                    .Invoke(Argument(2), RefArg(resultVariable), RefArg(currentLengthVariable))));
                
            p.ForAdd(resultVariable.ArrayAccess(indexer).Assign(p.LastItem));
            p.HasResultMethod = true;
        }

        private static void RewriteSimple(RewriteParameters p, VariableBridge resultVariable)
        {
            var collectionType = p.Semantic.GetTypeFromExpression(p.Collection);
            var collectionName = collectionType.ToString();

            if (collectionType is ArrayTypeSyntax)
            {
                var count = p.Code.CreateCollectionCount(p.Collection, false);
                p.PreForAdd(CreateLocalArray(resultVariable, (ArrayTypeSyntax) p.ReturnType, count));
                p.PreForAdd("Array".Access("Copy")
                    .Invoke(p.Collection, 0, resultVariable, 0, count));
                p.PreForAdd(Return(resultVariable));
            }
        }
    }
}