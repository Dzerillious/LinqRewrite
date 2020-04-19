﻿using System;
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

        public static TypeBridge ItemType(this RewrittenValueBridge collection, RewriteParameters p)
        {
            var itemString = collection.Old.GetItemTypeSymbol(p).ToDisplayString();
            return SyntaxFactory.ParseTypeName(itemString);
        }
        
        public static TypeBridge ReturnItemType(this RewrittenValueBridge rewritten, RewriteParameters p)
        {
            var old = (LambdaExpressionSyntax) rewritten.OldVal;
            var itemString = CodeCreationService.GetLastLambdaExpression(old).GetItemTypeSymbol(p).ToDisplayString();
            return SyntaxFactory.ParseTypeName(itemString);
        }


        public static TypeBridge ItemType(this TypeBridge collection, RewriteParameters p)
        {
            var itemString = collection.GetItemTypeSymbol(p).ToDisplayString();
            return SyntaxFactory.ParseTypeName(itemString);
        }

        public static TypeBridge ItemType(this ValueBridge collection, RewriteParameters p)
        {
            try
            {
                var itemString = collection.GetItemTypeSymbol(p).ToDisplayString();
                return SyntaxFactory.ParseTypeName(itemString);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static ITypeSymbol GetItemTypeSymbol(this TypeBridge collection, RewriteParameters p)
        {
            var collectionType = ModelExtensions.GetTypeInfo(p.Semantic, collection).Type;
            return GetItemType(collectionType);
        }

        public static ITypeSymbol GetItemTypeSymbol(this ValueBridge collection, RewriteParameters p)
        {
            var collectionType = ModelExtensions.GetTypeInfo(p.Semantic, collection.Value).Type;
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

        public static bool HasCommonAncestor(ITypeSymbol symbol, TypeBridge type)
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