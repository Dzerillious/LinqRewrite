// Forked and modified from https://github.com/antiufo/roslyn-linq-rewrite/tree/master/RoslynLinqRewrite

using System.Linq;
using LinqRewrite.DataStructures;
using LinqRewrite.Services;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.Extensions
{
    public static class SymbolExtensions
    {
        public static ITypeSymbol GetType(this ISymbol x)
            => x switch
            {
                ILocalSymbol local => local.Type,
                IParameterSymbol param => param.Type,
                IFieldSymbol field => field.Type,
                IPropertySymbol property => property.Type,
                IEventSymbol ev => ev.Type,
                IDiscardSymbol di => di.Type,
                _ => null
            };

        public static ITypeSymbol GetSymbolType(this VariableCapture x) 
            => GetType(x.Symbol);

        public static ParameterSyntax GetLambdaParameter(Lambda lambda, int index)
            => lambda.Parameters[index];

        public static TypeBridge ItemType(this ValueBridge collection, RewriteDesign design)
        {
            var itemString = collection.GetItemTypeSymbol(design).ToDisplayString();
            return SyntaxFactory.ParseTypeName(itemString);
        }
        
        public static TypeBridge ReturnItemType(this ValueBridge rewritten, RewriteDesign design)
        {
            var old = (LambdaExpressionSyntax) rewritten.Value;
            var itemString = CodeCreationService.GetLastLambdaExpression(old).GetItemTypeSymbol(design).ToDisplayString();
            return SyntaxFactory.ParseTypeName(itemString);
        }

        public static ITypeSymbol GetItemTypeSymbol(this TypeBridge collection, RewriteDesign design)
        {
            var collectionType = ModelExtensions.GetTypeInfo(design.Semantic, collection).Type;
            return GetItemType(collectionType);
        }

        public static ITypeSymbol GetItemTypeSymbol(this ValueBridge collection, RewriteDesign design)
        {
            var collectionType = ModelExtensions.GetTypeInfo(design.Semantic, collection.Value).Type;
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

        public static bool IsSameType(ITypeSymbol symbol, TypeBridge type) 
            => symbol.ToDisplayString() == type.ToString();

        public static bool IsDescendantType(ITypeSymbol symbol, TypeBridge type)
        {
            var checkedType = type.ToString();
            if (symbol.AllInterfaces.Any(x => x.ToDisplayString() == checkedType)) return true;
            
            while (symbol.BaseType != null)
            {
                if (symbol.ToDisplayString() == checkedType) return true;
                symbol = symbol.BaseType;
            }
            return false;
        }
    }
}