﻿namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    // public static class RewriteAverage
    // {
    //     // public static ExpressionSyntax Rewrite(RewriteParameters p)
    //     // {
    //     //     var elementType = (p.ReturnType as NullableTypeSyntax)?.ElementType ?? p.ReturnType;
    //     //     var primitive = ((PredefinedTypeSyntax) elementType).Keyword.Kind();
    //     //
    //     //     ExpressionSyntax sumIdentifier = SyntaxFactory.IdentifierName("sum_");
    //     //     ExpressionSyntax countIdentifier = SyntaxFactory.IdentifierName("count_");
    //     //
    //     //     if (primitive != SyntaxKind.DecimalKeyword)
    //     //     {
    //     //         sumIdentifier = SyntaxFactory.CastExpression(SyntaxFactoryHelper.CreatePrimitiveType(SyntaxKind.DoubleKeyword), sumIdentifier);
    //     //         countIdentifier =  SyntaxFactory.CastExpression(SyntaxFactoryHelper.CreatePrimitiveType(SyntaxKind.DoubleKeyword), countIdentifier);
    //     //     }
    //     //
    //     //     ExpressionSyntax division = SyntaxFactory.BinaryExpression(SyntaxKind.DivideExpression, sumIdentifier, countIdentifier);
    //     //     if (primitive != SyntaxKind.DoubleKeyword && primitive != SyntaxKind.DecimalKeyword)
    //     //         division = SyntaxFactory.CastExpression(elementType, SyntaxFactory.ParenthesizedExpression(division));
    //     //
    //     //     return p.Rewrite.RewriteAsLoop(
    //     //         p.ReturnType,
    //     //         new[]
    //     //         {
    //     //             SyntaxFactoryHelper.LocalVariableCreation("sum_",
    //     //                 SyntaxFactory.CastExpression(
    //     //                     primitive == SyntaxKind.IntKeyword || primitive == SyntaxKind.LongKeyword
    //     //                         ? SyntaxFactoryHelper.CreatePrimitiveType(SyntaxKind.LongKeyword)
    //     //                         : primitive == SyntaxKind.DecimalKeyword
    //     //                             ? SyntaxFactoryHelper.CreatePrimitiveType(SyntaxKind.DecimalKeyword)
    //     //                             : SyntaxFactoryHelper.CreatePrimitiveType(SyntaxKind.DoubleKeyword),
    //     //                     SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(0)))),
    //     //             SyntaxFactoryHelper.LocalVariableCreation("count_", SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.ParseToken("0L")))
    //     //         },
    //     //         new[]
    //     //         {
    //     //             SyntaxFactory.Block(
    //     //                 SyntaxFactory.IfStatement(SyntaxFactory.BinaryExpression(SyntaxKind.EqualsExpression,
    //     //                         SyntaxFactory.IdentifierName("count_"), SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.ParseToken("0"))),
    //     //                     p.ReturnType == elementType
    //     //                         ? (StatementSyntax) SyntaxFactoryHelper.CreateThrowException("System.InvalidOperationException", "The sequence did not contain any elements.")
    //     //                         : SyntaxFactory.ReturnStatement(SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression))
    //     //                 ),
    //     //                 SyntaxFactory.ReturnStatement(division)
    //     //             )
    //     //         },
    //     //         p.Collection,
    //     //         p.Code.MaybeAddSelect(p.Chain, p.Node.ArgumentList.Arguments.Count != 0),
    //     //         (inv, arguments, param) =>
    //     //         {
    //     //             var currentValue = SyntaxFactory.IdentifierName(param.Identifier.ValueText);
    //     //             return SyntaxExtensions.IfNullableIsNotNull(elementType != p.ReturnType, currentValue, x =>
    //     //                 SyntaxFactory.CheckedStatement(SyntaxKind.CheckedStatement, SyntaxFactory.Block(
    //     //                     SyntaxFactory.ExpressionStatement(SyntaxFactory.PostfixUnaryExpression(SyntaxKind.PostIncrementExpression, SyntaxFactory.IdentifierName("count_"))),
    //     //                     SyntaxFactory.ExpressionStatement(SyntaxFactory.AssignmentExpression(SyntaxKind.AddAssignmentExpression, SyntaxFactory.IdentifierName("sum_"), x))
    //     //                 )));
    //     //         }
    //     //     );
    //     // }
    // }
}