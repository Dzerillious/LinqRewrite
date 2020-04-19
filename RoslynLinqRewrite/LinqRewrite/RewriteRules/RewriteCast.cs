using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteCast
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args, InvocationExpressionSyntax invocation)
        {
            var access = (MemberAccessExpressionSyntax) invocation.Expression;
            var name = (GenericNameSyntax) access.Name;
            var type = name.TypeArgumentList.Arguments[0];
            var typeSymbol = p.Semantic.GetTypeInfo(type).Type;

            if (SymbolExtensions.IsSameType(typeSymbol, p.LastValue.Type)) ;
            else if (p.Unchecked || SymbolExtensions.HasCommonAncestor(typeSymbol, p.LastValue.Type))
            {
                p.LastValue = new TypedValueBridge(type, p.LastValue.Cast(type));
                p.ListEnumeration = false;
            }
            else
            {
                p.LastValue = new TypedValueBridge(type, p.LastValue.Cast(ParseTypeName("object")).Cast(type));
                p.ListEnumeration = false;
            }
        }
    }
}