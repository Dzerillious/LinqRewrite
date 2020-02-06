using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Shaman.Roslyn.LinqRewrite
{
    public static class ExtensionMethods
    {
        public static MethodDeclarationSyntax WithStatic(this MethodDeclarationSyntax syntax, bool isStatic)
        {
            return isStatic 
                ? syntax.AddModifiers(SyntaxFactory.Token(SyntaxKind.StaticKeyword)) 
                : syntax.WithModifiers(SyntaxFactory.TokenList());
        }
        public static ParameterSyntax WithRef(this ParameterSyntax syntax, bool isRef)
        {
            return isRef 
                ? syntax.AddModifiers(SyntaxFactory.Token(SyntaxKind.RefKeyword)) 
                : syntax.WithModifiers(SyntaxFactory.TokenList());
        }
        public static ArgumentSyntax WithRef(this ArgumentSyntax syntax, bool isRef)
        {
            return syntax.WithRefOrOutKeyword(isRef 
                ? SyntaxFactory.Token(SyntaxKind.RefKeyword) 
                : default);
        }
    }
}
