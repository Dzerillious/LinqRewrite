using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using Shaman.Roslyn.LinqRewrite.Extensions;
using Shaman.Roslyn.LinqRewrite.Services;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteContains
    {
        public static ExpressionSyntax Rewrite(RewriteParameters p)
        {
            var elementType = SyntaxFactory.ParseTypeName(ModelExtensions
                .GetTypeInfo(p.Data.Semantic, p.Node.ArgumentList.Arguments.First().Expression).ConvertedType
                .ToDisplayString());
            
            var comparerIdentifier = ((elementType as NullableTypeSyntax)?.ElementType ?? elementType) is PredefinedTypeSyntax
                    ? null : SyntaxFactory.IdentifierName("comparer_");
            
            return p.Rewrite.RewriteAsLoop(
                SyntaxFactoryHelper.CreatePrimitiveType(SyntaxKind.BoolKeyword),
                comparerIdentifier != null
                    ? new StatementSyntax[]
                    {
                        SyntaxFactoryHelper.LocalVariableCreation("comparer_",
                            SyntaxFactory.ParseExpression(
                                $"System.Collections.Generic.EqualityComparer<{elementType}>.Default"))
                    }
                    : Enumerable.Empty<StatementSyntax>(),
                new[]
                {
                    SyntaxFactory.ReturnStatement(SyntaxFactory.LiteralExpression(SyntaxKind.FalseLiteralExpression))
                },
                p.Collection,
                p.Chain,
                (inv, arguments, param) =>
                {
                    var target = SyntaxFactory.IdentifierName("_target");
                    var current = SyntaxFactory.IdentifierName(param.Identifier.ValueText);
                    var condition = comparerIdentifier != null
                        ? SyntaxFactory.InvocationExpression(
                            SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, comparerIdentifier, SyntaxFactory.IdentifierName("Equals")), SyntaxFactoryHelper.CreateArguments(current, target))
                        : (ExpressionSyntax) SyntaxFactory.BinaryExpression(SyntaxKind.EqualsExpression, current, target);
                    
                    return SyntaxFactory.IfStatement(condition,
                        SyntaxFactory.ReturnStatement(SyntaxFactory.LiteralExpression(SyntaxKind.TrueLiteralExpression)));
                },
                additionalParameters: new[]
                {
                    Tuple.Create(SyntaxFactoryHelper.CreateParameter("_target", elementType), p.Node.ArgumentList.Arguments.First().Expression)
                }
            );
        }
    }
}