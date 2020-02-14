using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using Shaman.Roslyn.LinqRewrite.Extensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Shaman.Roslyn.LinqRewrite.Extensions.OperatorExpressionExtensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Shaman.Roslyn.LinqRewrite.Extensions.VariableExtensions;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteToArray
    {
        public const string ResultArrayName = "__result";
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex != 0) throw new InvalidOperationException("ToArray should be last expression.");

            if (p.ResultSize != null) KnownSize(p);
            else
            {
                if (p.SourceSize != null) KnownSourceSize(p);
                else UnknownSourceSize(p);
                
                p.PostForAdd(ReturnStatement(
                    Invoke("SimpleCollections".Access("SimpleArrayExtensions", "EnsureFullArray"), 
                            Argument("__result"), Argument("__current"))));
            }
        }
        
        public static void RewriteOther(RewriteParameters p, int chainIndex, TypeSyntax itemType)
        {
            if (chainIndex != 0) throw new InvalidOperationException("ToArray should be last expression.");

            if (p.ResultSize != null)
            {
                p.PreForAdd(CreateLocalArray(ResultArrayName, ArrayType(itemType), p.ResultSize));

                p.ForAdd(ExpressionStatement(
                    ResultArrayName.ArrayAccess("__index").Assign(p.LastItem)));
            }
        }

        private static void KnownSize(RewriteParameters p)
        {
            p.PreForAdd(CreateLocalArray(ResultArrayName, p.ReturnType, p.ResultSize));

            p.ForAdd(ExpressionStatement(
                ResultArrayName.ArrayAccess("__index").Assign(p.LastItem)));
            
            p.PostForAdd(ReturnStatement(IdentifierName(ResultArrayName)));
        }

        private static void KnownSourceSize(RewriteParameters p)
        {
            p.PreForAdd(LocalVariableCreation("__current", IntValue(0)));
                
            p.PreForAdd(LocalVariableCreation("__log", 
                Invoke("SimpleCollections".Access("IntExtensions", "Log2"),
                        Argument(CastExpression(CreatePrimitiveType(SyntaxKind.UIntKeyword), p.SourceSize)))
                    .Sub(IntValue(3))));
                
            p.PreForAdd(ExpressionStatement("__log".AssignSubtract("__log".Mod(IntValue(2)))));
            p.PreForAdd(LocalVariableCreation("__currentLength", IntValue(8)));

            var result = (ArrayTypeSyntax) p.ReturnType;
            p.PreForAdd(CreateLocalArray(ResultArrayName, result, IntValue(8)));
                
            p.ForAdd(IfStatement("__current".GeThan(IdentifierName("__currentLength")),
                ExpressionStatement(Invoke("SimpleCollections".Access("EnlargeExtensions", "LogEnlargeArray"), 
                        Argument(IntValue(2)),
                        Argument(p.SourceSize),
                        RefArgument("__result"),
                        RefArgument("__log"),
                        OutArgument("__currentLength")))));
                
            p.ForAdd(ExpressionStatement(
                ResultArrayName.ArrayAccess("__index").Assign(p.LastItem)));
        }

        private static void UnknownSourceSize(RewriteParameters p)
        {
            p.PreForAdd(LocalVariableCreation("__current", IntValue(0)));
            p.PreForAdd(LocalVariableCreation("__currentLength", IntValue(8)));
            var result = (ArrayTypeSyntax) p.ReturnType;
            p.PreForAdd(CreateLocalArray(ResultArrayName, result, IntValue(8)));
                
            p.ForAdd(IfStatement("__current".GeThan(IdentifierName("__currentLength")),
                ExpressionStatement(Invoke("SimpleCollections".Access("EnlargeExtensions", "LogEnlargeArray"), 
                        Argument(IntValue(2)),
                        RefArgument("__result"),
                        RefArgument("__currentLength")))));
                
            p.ForAdd(ExpressionStatement(
                ResultArrayName.ArrayAccess("__index").Assign(p.LastItem)));
        }
    }
}