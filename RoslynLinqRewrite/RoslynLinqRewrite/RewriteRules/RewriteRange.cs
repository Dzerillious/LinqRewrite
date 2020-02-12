using System;
using Microsoft.CodeAnalysis.CSharp;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using Shaman.Roslyn.LinqRewrite.Extensions;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteRange
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            var last = p.Chain[chainIndex];
            if (last.MethodName != Constants.RangeMethod) throw new InvalidOperationException("Enumerable.Range should be first expression.");

            var from = p.Chain[1].Arguments[0];
            var count = p.Chain[1].Arguments[1];
            
            p.AddToPrefix(SyntaxFactoryHelper.LocalVariableCreation(
                "__sum", BinaryExpressionExtensions.Add(from, count)
            ));
            p.ForBounds = (p.Chain[1].Arguments[0], SyntaxFactory.IdentifierName("__sum"));
            
            p.LastIdentifier = SyntaxFactory.IdentifierName("__i");
            p.LastIdentifierType = SyntaxTypeExtensions.IntType;

            p.ArraySize = count;
        }
    }
}