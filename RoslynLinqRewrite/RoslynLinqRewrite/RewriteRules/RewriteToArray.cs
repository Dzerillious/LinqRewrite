using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Shaman.Roslyn.LinqRewrite.Extensions.OperatorExpressionExtensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Shaman.Roslyn.LinqRewrite.Extensions.VariableExtensions;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteToArray
    {
        private const string ResultArrayName = "__result";
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex != 0) throw new InvalidOperationException("ToArray should be last expression.");

            if (p.ResultSize != null)
            {
                p.AddToPrefix(CreateLocalArray(ResultArrayName, (ArrayTypeSyntax)p.ReturnType, p.ResultSize));

                p.AddToBody(ExpressionStatement(
                    Assign(ArrayAccess(ResultArrayName, IdentifierName("_index")), p.LastItem)));
            
                p.AddToPostfix(ReturnStatement(IdentifierName(ResultArrayName)));
            }
        }
        
        // public static ExpressionSyntax Rewrite(RewriteParameters p)
        // {
        //     var count = p.Chain.All(x => Constants.MethodsThatPreserveCount.Contains(x.MethodName))
        //         ? p.Code.CreateCollectionCount(p.Collection, false) : null;
        //
        //     if (count != null)
        //     {
        //         var arrayIdentifier = SyntaxFactory.IdentifierName("_array");
        //         return p.Rewrite.RewriteAsLoop(
        //             p.ReturnType,
        //             new[]
        //             {
        //                 p.Code.CreateLocalVariableDeclaration("_array",
        //                     SyntaxFactory.ArrayCreationExpression(SyntaxFactory.ArrayType(((ArrayTypeSyntax) p.ReturnType).ElementType,
        //                         SyntaxFactory.List(new[]  {SyntaxFactory.ArrayRankSpecifier(p.Code.CreateSeparatedList(count))}))))
        //             },
        //             new[] {SyntaxFactory.ReturnStatement(arrayIdentifier)},
        //             p.Collection,
        //             p.Chain,
        //             (inv, arguments, param)
        //                 => p.Code.CreateStatement(SyntaxFactory.AssignmentExpression(SyntaxKind.SimpleAssignmentExpression,
        //                     SyntaxFactory.ElementAccessExpression(arrayIdentifier, SyntaxFactory.BracketedArgumentList( p.Code.CreateSeparatedList( SyntaxFactory.Argument(SyntaxFactory.IdentifierName("_index"))))),
        //                     SyntaxFactory.IdentifierName(param.Identifier.ValueText))));
        //     }
        //
        //     var listIdentifier = SyntaxFactory.IdentifierName("_list");
        //     var listType = SyntaxFactory.ParseTypeName($"System.Collections.Generic.List<{((ArrayTypeSyntax) p.ReturnType).ElementType}>");
        //     return p.Rewrite.RewriteAsLoop(
        //         p.ReturnType,
        //         new[]
        //         {
        //             p.Code.CreateLocalVariableDeclaration("_list", SyntaxFactory.ObjectCreationExpression(listType, p.Code.CreateArguments(Enumerable.Empty<ArgumentSyntax>()), null))
        //         },
        //         new[]
        //         {
        //             SyntaxFactory.ReturnStatement(SyntaxFactory.InvocationExpression(SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, listIdentifier, SyntaxFactory.IdentifierName("ToArray"))))
        //         },
        //         p.Collection,
        //         p.Chain,
        //         (inv, arguments, param)
        //             => p.Code.CreateStatement(SyntaxFactory.InvocationExpression(
        //                 SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, listIdentifier, SyntaxFactory.IdentifierName("Add")),
        //                 p.Code.CreateArguments(SyntaxFactory.IdentifierName(param.Identifier.ValueText)))));
        // }
    }
}