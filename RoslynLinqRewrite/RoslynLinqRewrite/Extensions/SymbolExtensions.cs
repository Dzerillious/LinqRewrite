using System;
using System.Linq;
using LinqRewrite.DataStructures;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.Extensions
{
    public static class SymbolExtensions
    {
        public static ITypeSymbol GetSymbolType(ISymbol x)
            => x switch
            {
                ILocalSymbol local => local.Type,
                IParameterSymbol param => param.Type,
                _ => throw new NotImplementedException()
            };

        public static ITypeSymbol GetSymbolType(VariableCapture x) 
            => GetSymbolType(x.Symbol);

        public static ParameterSyntax GetLambdaParameter(Lambda lambda, int index)
            => lambda.Parameters[index];

        public static TypeSyntax WrappedItemType(this RewriteParameters p, string pre, ExpressionSyntax collection,
            string post)
        {
            var itemString = pre + p.GetItemType(collection).ToDisplayString() + post;
            return SyntaxFactory.ParseTypeName(itemString);
        }

        public static TypeSyntax ItemType(this ExpressionSyntax collection, RewriteParameters p)
        {
            var itemString = p.GetItemType(collection).ToDisplayString();
            return SyntaxFactory.ParseTypeName(itemString);
        }

        public static ITypeSymbol GetItemType(this RewriteParameters p, ExpressionSyntax collection)
        {
            var collectionType = ModelExtensions.GetTypeInfo(p.Semantic, collection).Type;
            return GetItemType(collectionType);
        }

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