using System.Collections.Generic;
using System.Linq;
using LinqRewrite.DataStructures;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.Extensions
{
    public static class VariableExtensions
    {
        public static LiteralExpressionSyntax NullValue
            => SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression);
        
        public static TypeSyntax IntType
            => SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.IntKeyword));
        public static LiteralExpressionSyntax IntValue(int x)
            => SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(x));
        
        public static TypeSyntax BoolType
            => SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.BoolKeyword));

        public static LocalDeclarationStatementSyntax LocalVariableCreation(string name, ValueBridge value)
            =>  SyntaxFactory.LocalDeclarationStatement(VariableCreation(name, value));
        
        public static LocalDeclarationStatementSyntax LocalVariableCreation(string name, TypeBridge type, ValueBridge value)
            =>  SyntaxFactory.LocalDeclarationStatement(VariableCreation(name, type, value));

        public static VariableDeclarationSyntax VariableCreation(VariableBridge name, ValueBridge value)
            =>  SyntaxFactory.VariableDeclaration(
                SyntaxFactory.IdentifierName("var"),
                SyntaxFactory.SeparatedList(new []{SyntaxFactory.VariableDeclarator(name)
                    .WithInitializer(SyntaxFactory.EqualsValueClause(value))}));

        public static VariableDeclarationSyntax VariableCreation(string name, TypeBridge type, ValueBridge value)
            =>  SyntaxFactory.VariableDeclaration(
                type,
                SyntaxFactory.SeparatedList(new []{SyntaxFactory.VariableDeclarator(name)
                    .WithInitializer(SyntaxFactory.EqualsValueClause(value))}));
        
        public static StatementSyntax CreateLocalArray(string name, ArrayTypeSyntax arrayType, ExpressionSyntax size)
            => LocalVariableCreation(name,
                SyntaxFactory.ArrayCreationExpression(
                    arrayType.WithRankSpecifiers(SyntaxFactory.SingletonList(SyntaxFactory.ArrayRankSpecifier(
                            SyntaxFactoryHelper.CreateSeparatedList(size))))));

        public static StatementSyntax CreateLocalArray(string name, ArrayTypeSyntax arrayType, int size)
            => LocalVariableCreation(name,
                SyntaxFactory.ArrayCreationExpression(
                    arrayType.WithRankSpecifiers(SyntaxFactory.SingletonList(SyntaxFactory.ArrayRankSpecifier(
                        SyntaxFactoryHelper.CreateSeparatedList((ExpressionSyntax)IntValue(size)))))));
        public static StatementSyntax CreateLocalArray(string name, TypeSyntax itemType, ExpressionSyntax size)
            => LocalVariableCreation(name,
                SyntaxFactory.ArrayCreationExpression(
                    SyntaxFactory.ArrayType(itemType)
                        .WithRankSpecifiers(SyntaxFactory.SingletonList(SyntaxFactory.ArrayRankSpecifier(
                            SyntaxFactoryHelper.CreateSeparatedList(size))))));
        
        public static VariableCapture CreateVariableCapture(ISymbol symbol, IReadOnlyList<ISymbol> flowsOut)
        {
            var changes = flowsOut.Contains(symbol);
            if (changes) return new VariableCapture(symbol, changes);

            if (!(symbol is ILocalSymbol local)) return new VariableCapture(symbol, changes);
            var type = local.Type;

            if (!type.IsValueType) return new VariableCapture(symbol, changes);

            // Pass big structs by ref for performance.
            var size = StructureExtensions.GetStructSize(type);
            if (size > Constants.MaximumSizeForByValStruct) changes = true;
            return new VariableCapture(symbol, changes);
        }
    }
}