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
        public static LiteralExpressionSyntax Null
            => SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression);
        
        public static TypeSyntax Int
            => SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.IntKeyword));
        public static LiteralExpressionSyntax IntValue(int x)
            => SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(x));
        
        public static TypeSyntax Long
            => SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.LongKeyword));
        public static TypeSyntax Float
            => SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.FloatKeyword));
        public static TypeSyntax Double
            => SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.DoubleKeyword));
        public static TypeSyntax Bool
            => SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.BoolKeyword));

        public static LocalDeclarationStatementSyntax LocalVariableCreation(string name, TypeSyntax type)
            =>  SyntaxFactory.LocalDeclarationStatement(VariableCreation(name, type));
        
        public static LocalDeclarationStatementSyntax LocalVariableCreation(string name, TypeBridge type)
            =>  SyntaxFactory.LocalDeclarationStatement(VariableCreation(name, type));

        public static VariableDeclarationSyntax VariableCreation(VariableBridge name, TypeSyntax type)
            =>  SyntaxFactory.VariableDeclaration(type,
                SyntaxFactory.SeparatedList(new []{SyntaxFactory.VariableDeclarator(name)}));
        
        public static ArrayCreationExpressionSyntax CreateArray(ArrayTypeSyntax arrayType, ValueBridge size)
        {
            var rankSpecifiers = arrayType.RankSpecifiers;
            var newRankSpecifiers = rankSpecifiers.Select((x, i) 
                => i == 0
                    ? SyntaxFactory.ArrayRankSpecifier(SyntaxFactoryHelper.CreateSeparatedList((ExpressionSyntax) size))
                    : x);
            return SyntaxFactory.ArrayCreationExpression(
                arrayType.WithRankSpecifiers(new SyntaxList<ArrayRankSpecifierSyntax>(newRankSpecifiers)));
        }
        
        public static ArrayCreationExpressionSyntax CreateArray2(ArrayTypeSyntax arrayType, ValueBridge size)
        {
            var rankSpecifiers = arrayType.RankSpecifiers;
            var newRankSpecifiers = rankSpecifiers.Select((x, i) 
                => i == 0
                    ? SyntaxFactory.ArrayRankSpecifier(SyntaxFactoryHelper.CreateSeparatedList((ExpressionSyntax) size))
                    : x);
            return SyntaxFactory.ArrayCreationExpression(
                arrayType.WithRankSpecifiers(new SyntaxList<ArrayRankSpecifierSyntax>(newRankSpecifiers)));
        }

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

        public static ValueBridge Count(this RewrittenValueBridge value, RewriteParameters p)
            => p.Code.CreateCollectionCount(value.New, value.Old);

        public static ValueBridge Count(this ValueBridge value, RewriteParameters p)
            => p.Code.CreateCollectionCount(value, value);
    }
}