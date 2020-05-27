// Forked and modified from https://github.com/antiufo/roslyn-linq-rewrite/tree/master/RoslynLinqRewrite

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.Extensions
{
    public static class SyntaxExtensions
    {
        public static MethodDeclarationSyntax WithStatic(this MethodDeclarationSyntax syntax, bool isStatic) 
            => isStatic  ? syntax.AddModifiers(SyntaxFactory.Token(SyntaxKind.StaticKeyword)) 
                : syntax.WithModifiers(SyntaxFactory.TokenList());

        public static ParameterSyntax WithRef(this ParameterSyntax syntax, bool isRef) 
            => isRef 
                ? syntax.AddModifiers(SyntaxFactory.Token(SyntaxKind.RefKeyword)) 
                : syntax.WithModifiers(SyntaxFactory.TokenList());

        public static ArgumentSyntax WithRef(this ArgumentSyntax syntax, bool isRef) 
            => syntax.WithRefOrOutKeyword(isRef 
                ? SyntaxFactory.Token(SyntaxKind.RefKeyword) 
                : default);

        public static bool IsAnonymousType(ITypeSymbol t) 
            => t.ToDisplayString().Contains("anonymous type:");

        public static TypeSyntax GetTypeFromExpression(this SemanticModel model, ExpressionSyntax syntax)
            => SyntaxFactory.ParseTypeName(model.GetTypeInfo(syntax).Type.ToDisplayString());
    }
}
