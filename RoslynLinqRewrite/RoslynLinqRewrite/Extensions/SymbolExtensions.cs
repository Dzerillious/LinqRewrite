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

        public static TypeSyntax WrappedItemType(this RewriteParameters p, string pre, ValueBridge collection,
            string post)
        {
            var itemString = pre + collection.GetItemTypeSymbol(p).ToDisplayString() + post;
            return SyntaxFactory.ParseTypeName(itemString);
        }

        public static TypeBridge ItemType(this RewrittenValueBridge collection, RewriteParameters p)
        {
            var itemString = collection.Old.GetItemTypeSymbol(p).ToDisplayString();
            return SyntaxFactory.ParseTypeName(itemString);
        }

        public static TypeBridge ItemType(this ValueBridge collection, RewriteParameters p)
        {
            var itemString = collection.GetItemTypeSymbol(p).ToDisplayString();
            return SyntaxFactory.ParseTypeName(itemString);
        }

        public static ITypeSymbol GetItemTypeSymbol(this ValueBridge collection, RewriteParameters p)
        {
            var collectionType = ModelExtensions.GetTypeInfo(p.Semantic, collection.Value).Type;
            return GetItemType(collectionType);
        }

        public static TypeSyntax GetType(this ExpressionSyntax item, RewriteParameters p)
        {
            var itemString = ModelExtensions.GetTypeInfo(p.Semantic, item).Type.ToDisplayString();
            return SyntaxFactory.ParseTypeName(itemString);
        }

        public static ITypeSymbol GetTypeSymbol(this RewriteParameters p, ExpressionSyntax item)
            => ModelExtensions.GetTypeInfo(p.Semantic, item).Type;

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