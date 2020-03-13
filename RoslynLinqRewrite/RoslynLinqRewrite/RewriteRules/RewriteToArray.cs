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
            p.HasResultMethod = true;
            if (p.ListEnumeration && p.IncompleteIterators.Count() <= 1 && RewriteList(p))
                return;
            
            if (p.Iterator ==  null)
                RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            
            var resultVariable = RewriteOther(p);
            if (p.ResultSize == null) p.FinalAdd(Return("SimpleCollections".Access("SimpleArrayExtensions", "EnsureFullArray")
                .Invoke(resultVariable, p.Indexer)));
        }
        
        public static VariableBridge RewriteOther(RewriteParameters p, TypeSyntax itemType = null)
        {
            if (p.ResultSize != null) return KnownSize(p, itemType);
            else if (p.SourceSize != null) return KnownSourceSize(p);
            else return UnknownSourceSize(p);
        }

        private static VariableBridge KnownSize(RewriteParameters p, TypeSyntax itemType = null)
        {
            var arrayType = itemType == null ? (ArrayTypeSyntax) p.ReturnType : itemType.ArrayType();
            var resultVariable = p.GlobalVariable(arrayType, CreateArray(arrayType, p.ResultSize));

            p.ForAdd(resultVariable[p.Indexer].Assign(p.Last.Value));
            
            p.FinalAdd(Return(resultVariable));
            return resultVariable;
        }

        private static VariableBridge KnownSourceSize(RewriteParameters p)
        {
            var indexer = p.Indexer;
                
            var logVariable = p.GlobalVariable(Int, 
                "SimpleCollections".Access("IntExtensions", "Log2")
                    .Invoke(p.SourceSize.Cast(SyntaxKind.UIntKeyword)) - 3);
                
            p.PreUseAdd(logVariable.SubAssign(logVariable % 2));
            var currentLengthVariable = p.GlobalVariable(Int, 8);

            var resultType = (ArrayTypeSyntax) p.ReturnType;
            var resultVariable = p.GlobalVariable(resultType, CreateArray(resultType, 8));

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

        private static VariableBridge UnknownSourceSize(RewriteParameters p)
        {
            var indexer = p.Indexer;
            
            var currentLengthVariable = p.GlobalVariable(Int, 8);
            var resultType = (ArrayTypeSyntax) p.ReturnType;
            var resultVariable = p.GlobalVariable(Int, CreateArray(resultType, 8));
                
            p.ForAdd(If(p.Indexer >= currentLengthVariable,
                            "SimpleCollections".Access("EnlargeExtensions", "LogEnlargeArray")
                                    .Invoke(2, RefArg(resultVariable), RefArg(currentLengthVariable))));
                
            p.ForAdd(resultVariable[indexer].Assign(p.Last.Value));
            p.HasResultMethod = true;
            return resultVariable;
        }

        private static bool RewriteList(RewriteParameters p)
        {
            p.HasResultMethod = true;
            if (p.Iterator != null) p.Iterator.Ignore = true;
            
            if (p.CurrentCollection.CollectionType == CollectionType.Array)
            {
                var min = p.Iterator == null ? 0 : p.Iterator.ForMin;
                var size = p.Iterator == null ? p.ResultSize : p.Iterator.ForMax - p.Iterator.ForMin;
                
                var resultVariable = p.GlobalVariable(p.ReturnType, CreateArray((ArrayTypeSyntax) p.ReturnType, p.CurrentCollection.Count));
                p.FinalAdd("Array".Access("Copy")
                    .Invoke(p.CurrentCollection, min, resultVariable, 0, size));
                p.FinalAdd(Return(resultVariable));
                return true;
            }
            else if (p.CurrentCollection.CollectionType == CollectionType.List)
            {
                var resultVariable = p.GlobalVariable(p.ReturnType,
                    CreateArray((ArrayTypeSyntax) p.ReturnType, p.CurrentCollection.Count));
                p.FinalAdd(p.CurrentCollection.Access("CopyTo").Invoke(resultVariable));
                p.FinalAdd(Return(resultVariable));
                return true;
            }
            p.NotRewrite = true;
            return true;
        }
    }
}