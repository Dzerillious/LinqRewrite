using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using Shaman.Roslyn.LinqRewrite.Extensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Shaman.Roslyn.LinqRewrite.Extensions.VariableExtensions;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteToArray
    {
        public const string ResultVariable = "__result";
        public const string CurrentVariable = "__current";
        public const string IndexVariable = "__index";
        public const string LogVariable = "__log";
        public const string CurrentLengthVariable = "__currentLength";
        
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex != 0) throw new InvalidOperationException("ToArray should be last expression.");

            if (p.ResultSize != null) KnownSize(p);
            else
            {
                if (p.SourceSize != null) KnownSourceSize(p);
                else UnknownSourceSize(p);
                
                p.PostForAdd(Return("SimpleCollections".Access("SimpleArrayExtensions", "EnsureFullArray")
                        .Invoke(ResultVariable, CurrentVariable)));
            }
        }
        
        public static void RewriteOther(RewriteParameters p, int chainIndex, TypeSyntax itemType)
        {
            if (chainIndex != 0) throw new InvalidOperationException("ToArray should be last expression.");

            if (p.ResultSize != null)
            {
                p.PreForAdd(CreateLocalArray(ResultVariable, ArrayType(itemType), p.ResultSize));

                p.ForAdd(ResultVariable.ArrayAccess(IndexVariable).Assign(p.LastItem));
            }
        }

        private static void KnownSize(RewriteParameters p)
        {
            p.PreForAdd(CreateLocalArray(ResultVariable, p.ReturnType, p.ResultSize));

            p.ForAdd(ResultVariable.ArrayAccess(IndexVariable).Assign(p.LastItem));
            
            p.PostForAdd(Return(ResultVariable));
        }

        private static void KnownSourceSize(RewriteParameters p)
        {
            p.PreForAdd(LocalVariableCreation(CurrentVariable, 0));
                
            p.PreForAdd(LocalVariableCreation(LogVariable, 
                        "SimpleCollections".Access("IntExtensions", "Log2")
                                .Invoke(p.SourceSize.Cast(SyntaxKind.UIntKeyword))
                                    .Sub(3)));
                
            p.PreForAdd(LogVariable.AssignSubtract(LogVariable.Mod(2)));
            p.PreForAdd(LocalVariableCreation(CurrentLengthVariable, 8));

            var result = (ArrayTypeSyntax) p.ReturnType;
            p.PreForAdd(CreateLocalArray(ResultVariable, result, 8));

            p.ForAdd(If(CurrentVariable.GeThan(CurrentLengthVariable),
                        "SimpleCollections".Access("EnlargeExtensions", "LogEnlargeArray")
                                .Invoke(Argument(2), 
                                    Argument(p.SourceSize), 
                                    RefArgument(ResultVariable), 
                                    RefArgument(LogVariable),
                                    OutArgument(CurrentLengthVariable))));
                
            p.ForAdd(ResultVariable.ArrayAccess(IndexVariable).Assign(p.LastItem));
        }

        private static void UnknownSourceSize(RewriteParameters p)
        {
            p.PreForAdd(LocalVariableCreation(CurrentVariable,0));
            p.PreForAdd(LocalVariableCreation(CurrentLengthVariable, 8));
            var result = (ArrayTypeSyntax) p.ReturnType;
            p.PreForAdd(CreateLocalArray(ResultVariable, result, 8));
                
            p.ForAdd(If(CurrentVariable.GeThan(CurrentLengthVariable),
                            "SimpleCollections".Access("EnlargeExtensions", "LogEnlargeArray")
                                    .Invoke(Argument(2),
                                        RefArgument(ResultVariable),
                                        RefArgument(CurrentLengthVariable))));
                
            p.ForAdd(ResultVariable.ArrayAccess(IndexVariable).Assign(p.LastItem));
        }
    }
}