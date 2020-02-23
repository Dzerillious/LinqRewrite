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
        public const string CurrentVariable = "__current";
        public const string LogVariable = "__log";
        public const string CurrentLengthVariable = "__currentLength";
        
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (p.Chain.Count == 1)
            {
                RewriteSimple(p);
                return;
            }
            RewriteOther(p, chainIndex);
            if (p.ResultSize == null) p.PostForAdd(Return("SimpleCollections".Access("SimpleArrayExtensions", "EnsureFullArray")
                .Invoke(GlobalResultVariable, CurrentVariable)));
        }
        
        public static void RewriteOther(RewriteParameters p, int chainIndex, TypeSyntax itemType = null)
        {
            if (chainIndex != p.Chain.Count - 1) throw new InvalidOperationException("ToArray should be last expression.");
            
            if (p.ResultSize != null) KnownSize(p, itemType);
            else if (p.SourceSize != null) KnownSourceSize(p);
            else UnknownSourceSize(p);
        }

        private static void KnownSize(RewriteParameters p, TypeSyntax itemType = null)
        {
            var arrayType = itemType == null ? (ArrayTypeSyntax) p.ReturnType : ArrayType(itemType);
            CreateLocalArray(GlobalResultVariable, arrayType, p.ResultSize);

            p.ForAdd(GlobalResultVariable.ArrayAccess(GlobalIndexerVariable).Assign(p.LastItem));
            
            p.PostForAdd(Return(GlobalResultVariable));
        }

        private static void KnownSourceSize(RewriteParameters p)
        {
            p.PreForAdd(LocalVariableCreation(CurrentVariable, 0));
                
            p.PreForAdd(LocalVariableCreation(LogVariable, 
                        "SimpleCollections".Access("IntExtensions", "Log2")
                                .Invoke(p.SourceSize.Cast(SyntaxKind.UIntKeyword))
                                    .Sub(3)));
                
            p.PreForAdd(LogVariable.SubAssign(LogVariable.Mod(2)));
            p.PreForAdd(LocalVariableCreation(CurrentLengthVariable, 8));

            var result = (ArrayTypeSyntax) p.ReturnType;
            p.PreForAdd(CreateLocalArray(GlobalResultVariable, result, 8));

            p.ForAdd(If(CurrentVariable.GeThan(CurrentLengthVariable),
                        "SimpleCollections".Access("EnlargeExtensions", "LogEnlargeArray")
                                .Invoke(Argument(2), 
                                    Argument(p.SourceSize), 
                                    RefArgument(GlobalResultVariable), 
                                    RefArgument(LogVariable),
                                    OutArgument(CurrentLengthVariable))));
                
            p.ForAdd(GlobalResultVariable.ArrayAccess(CurrentVariable).Assign(p.LastItem));
        }

        private static void UnknownSourceSize(RewriteParameters p)
        {
            p.PreForAdd(LocalVariableCreation(CurrentVariable,0));
            p.PreForAdd(LocalVariableCreation(CurrentLengthVariable, 8));
            var result = (ArrayTypeSyntax) p.ReturnType;
            p.PreForAdd(CreateLocalArray(GlobalResultVariable, result, 8));
                
            p.ForAdd(If(CurrentVariable.GeThan(CurrentLengthVariable),
                            "SimpleCollections".Access("EnlargeExtensions", "LogEnlargeArray")
                                    .Invoke(Argument(2),
                                        RefArgument(GlobalResultVariable),
                                        RefArgument(CurrentLengthVariable))));
                
            p.ForAdd(GlobalResultVariable.ArrayAccess(CurrentVariable).Assign(p.LastItem));
        }

        private static void RewriteSimple(RewriteParameters p)
        {
            var collectionType = p.Semantic.GetTypeFromExpression(p.Collection);
            var collectionName = collectionType.ToString();

            if (collectionType is ArrayTypeSyntax)
            {
                var count = p.Code.CreateCollectionCount(GlobalItemsName, p.Collection, false);
                p.PreForAdd(CreateLocalArray(GlobalResultVariable, (ArrayTypeSyntax) p.ReturnType, count));
                p.PreForAdd("Array".Access("Copy")
                    .Invoke(GlobalItemsName, 0, GlobalResultVariable, 0, count));
                p.PreForAdd(Return(GlobalResultVariable));
                
            }
        }
    }
}