using System;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
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

            if (p.ResultSize != null)
            {
                p.AddToPrefix(CreateLocalArray(ResultArrayName, p.ReturnType, p.ResultSize));

                p.AddToBody(ExpressionStatement(
                    Assign(ArrayAccess(ResultArrayName, IdentifierName("_index")), p.LastItem)));
            
                p.AddToPostfix(ReturnStatement(IdentifierName(ResultArrayName)));
            }
        }
        
        public static void RewriteOther(RewriteParameters p, int chainIndex, TypeSyntax itemType)
        {
            if (chainIndex != 0) throw new InvalidOperationException("ToArray should be last expression.");

            if (p.ResultSize != null)
            {
                p.AddToPrefix(CreateLocalArray(ResultArrayName, ArrayType(itemType), p.ResultSize));

                p.AddToBody(ExpressionStatement(
                    Assign(ArrayAccess(ResultArrayName, IdentifierName("_index")), p.LastItem)));
            }
        }
    }
}