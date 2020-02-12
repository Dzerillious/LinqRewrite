using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;

namespace Shaman.Roslyn.LinqRewrite.Extensions
{
    public static class SymbolExtensions
    {
        public static ITypeSymbol GetSymbolType(ISymbol x)
        {
            switch (x)
            {
                case ILocalSymbol local: return local.Type;
                case IParameterSymbol param: return param.Type;
                default: throw new NotImplementedException();
            }
        }
        
        public static ITypeSymbol GetSymbolType(VariableCapture x) 
            => GetSymbolType(x.Symbol);

        public static ParameterSyntax GetLambdaParameter(Lambda lambda, int index)
            => lambda.Parameters[index];

        public static ITypeSymbol GetItemType(ITypeSymbol collectionType)
            => collectionType is IArrayTypeSymbol symbol
                ? symbol.ElementType
                : collectionType.AllInterfaces
                    .Concat(new[] {collectionType})
                    .OfType<INamedTypeSymbol>()
                    .FirstOrDefault(x => x.IsGenericType && x.ConstructUnboundGenericType().ToString() == "System.Collections.Generic.IEnumerable<>")?
                    .TypeArguments.First();
    }
}