﻿namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteSum
    {
        // public static ExpressionSyntax Rewrite(RewriteParameters p)
        // {
        //     var elementType = (p.ReturnType as NullableTypeSyntax)?.ElementType ?? p.ReturnType;
        //     return p.Rewrite.RewriteAsLoop(
        //         p.ReturnType,
        //         new[]
        //         {
        //             SyntaxFactoryHelper.LocalVariableCreation("sum_",
        //                 SyntaxFactory.CastExpression(elementType,
        //                     SyntaxFactoryHelper.IntExpression(0)))
        //         },
        //         new[] {SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("sum_"))},
        //         p.Collection,
        //         p.Code.MaybeAddSelect(p.Chain, p.Node.ArgumentList.Arguments.Count != 0),
        //         (inv, arguments, param) =>
        //         {
        //             var currentValue = SyntaxFactory.IdentifierName(param.Identifier.ValueText);
        //             return SyntaxExtensions.IfNullableIsNotNull(elementType != p.ReturnType, currentValue, x
        //                 => SyntaxFactory.CheckedStatement(SyntaxKind.CheckedStatement,
        //                     SyntaxFactory.Block(SyntaxFactory.ExpressionStatement(
        //                         SyntaxFactory.AssignmentExpression(SyntaxKind.AddAssignmentExpression, SyntaxFactory.IdentifierName("sum_"), x)))));
        //         }
        //     );
        // }
    }
}