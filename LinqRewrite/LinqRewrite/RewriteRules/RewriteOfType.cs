using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteOfType
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args, InvocationExpressionSyntax invocation)
        {
            var access = (MemberAccessExpressionSyntax) invocation.Expression;
            var name = (GenericNameSyntax) access.Name;
            var type = name.TypeArgumentList.Arguments[0];
            var typeSymbol = p.Semantic.GetTypeInfo(type).Type;
            
            if (SymbolExtensions.IsSameType(typeSymbol, p.LastValue.Type)) {}
            else if (p.Unchecked || SymbolExtensions.IsDescendantType(typeSymbol, p.LastValue.Type))
            {
                p.LastValue = p.LastValue.Reusable(p);
                p.ForAdd(If(Not(p.LastValue.Is(type)),
                    Continue()));
                p.LastValue = new TypedValueBridge(type, p.LastValue.Cast(type));
            }
            else
            {
                p.LastValue = p.LastValue.Reusable(p);
                p.ForAdd(If(Not(p.LastValue.Is(type)),
                    Continue()));
                p.LastValue = new TypedValueBridge(type, p.LastValue.Cast(ParseTypeName("object")).Cast(type));
            }

            p.ResultSize = null;
            p.ListEnumeration = false;
            p.ModifiedEnumeration = true;
        }
    }
}