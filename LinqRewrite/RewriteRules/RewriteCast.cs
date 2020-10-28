using System.Collections.Immutable;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteCast
    {
        public static void Rewrite(RewriteDesign design, ImmutableArray<ValueBridge> args, InvocationExpressionSyntax invocation)
        {
            var access = (MemberAccessExpressionSyntax) invocation.Expression;
            var name = (GenericNameSyntax) access.Name;
            var type = name.TypeArgumentList.Arguments[0];
            var typeSymbol = design.Info.Semantic.GetTypeInfo(type).Type;

            if (SymbolExtensions.IsSameType(typeSymbol, design.LastValue.Type)) ;
            else if (design.Unchecked || SymbolExtensions.IsDescendantType(typeSymbol, design.LastValue.Type))
            {
                design.LastValue = new TypedValueBridge(type, design.LastValue.Cast(type));
                if (!design.Unchecked) design.ListEnumeration = false;
            }
            else
            {
                design.LastValue = new TypedValueBridge(type, design.LastValue.Cast(ParseTypeName("object")).Cast(type));
                design.ListEnumeration = false;
            }
        }
    }
}