using Microsoft.CodeAnalysis.CSharp;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using Shaman.Roslyn.LinqRewrite.Extensions;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteToArray
    {
        private const string ResultArrayName = "__result";
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            // var first = p.Chain[chainIndex];
            // if (first.MethodName != Constants.ToArrayMethod) throw new InvalidOperationException("ToArray should be last expression.");

            if (p.ArraySize != null)
            {
                p.AddToPrefix(SyntaxFactoryHelper.CreateLocalArray(ResultArrayName, SyntaxTypeExtensions.IntType, p.ArraySize));

                p.AddToBody(SyntaxFactory.ExpressionStatement(
                    BinaryExpressionExtensions.Assign(
                        SyntaxFactoryHelper.ArrayAccess(ResultArrayName, SyntaxFactory.IdentifierName("_index")),
                        p.LastIdentifier)));
            
                p.AddToPostfix(SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName(ResultArrayName)));
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