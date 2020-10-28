using System.Collections.Immutable;
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
        public static void Rewrite(RewriteDesign design, ImmutableArray<ValueBridge> args, InvocationExpressionSyntax invocation)
        {
            var access = (MemberAccessExpressionSyntax) invocation.Expression;
            var name = (GenericNameSyntax) access.Name;
            var type = name.TypeArgumentList.Arguments[0];
            var typeSymbol = design.Info.Semantic.GetTypeInfo(type).Type;
            
            if (SymbolExtensions.IsSameType(typeSymbol, design.LastValue.Type)) {}
            else if (design.Unchecked || SymbolExtensions.IsDescendantType(typeSymbol, design.LastValue.Type))
            {
                design.LastValue = design.LastValue.Reusable(design);
                design.ForAdd(If(Not(design.LastValue.Is(type)),
                                Continue()));
                design.LastValue = new TypedValueBridge(type, design.LastValue.Cast(type));
            }
            else
            {
                design.LastValue = design.LastValue.Reusable(design);
                design.ForAdd(If(Not(design.LastValue.Is(type)),
                                Continue()));
                design.LastValue = new TypedValueBridge(type, design.LastValue.Cast(ParseTypeName("object")).Cast(type));
            }

            design.ResultSize = null;
            design.ListEnumeration = false;
            design.ModifiedEnumeration = true;
        }
    }
}