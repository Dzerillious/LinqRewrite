using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;

namespace Shaman.Roslyn.LinqRewrite.Extensions
{
    public static class SyntaxTypeExtensions
    {
        public static TypeSyntax IntType
            => SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.IntKeyword));

        public static VariableCapture CreateVariableCapture(ISymbol symbol, IReadOnlyList<ISymbol> flowsOut)
        {
            var changes = flowsOut.Contains(symbol);
            if (changes) return new VariableCapture(symbol, changes);

            if (!(symbol is ILocalSymbol local)) return new VariableCapture(symbol, changes);
            var type = local.Type;

            if (!type.IsValueType) return new VariableCapture(symbol, changes);

            // Pass big structs by ref for performance.
            var size = StructureExtensions.GetStructSize(type);
            if (size > Constants.MaximumSizeForByValStruct) changes = true;
            return new VariableCapture(symbol, changes);
        }
    }
}