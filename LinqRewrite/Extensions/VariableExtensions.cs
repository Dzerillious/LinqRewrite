using System.Collections.Generic;
using System.Collections.Immutable;
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
        public static TypeSyntax Decimal
            => SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.DecimalKeyword));
        public static TypeSyntax Bool
            => SyntaxFactory.PredefinedType(SyntaxFactory.Token(SyntaxKind.BoolKeyword));

        public static LocalDeclarationStatementSyntax LocalVariableCreation(string name, TypeSyntax type)
            =>  SyntaxFactory.LocalDeclarationStatement(VariableCreation(name, type));
        
        public static LocalDeclarationStatementSyntax LocalVariableCreation(string name, TypeBridge type)
            =>  SyntaxFactory.LocalDeclarationStatement(VariableCreation(name, type));

        public static VariableDeclarationSyntax VariableCreation(VariableBridge name, TypeSyntax type)
            =>  SyntaxFactory.VariableDeclaration(type,
                SyntaxFactory.SeparatedList(new []{SyntaxFactory.VariableDeclarator(name)}));
        
        public static ArrayCreationExpressionSyntax CreateArray(ArrayTypeSyntax arrayType, ValueBridge size, IEnumerable<ExpressionSyntax> items)
        {
            var rankSpecifiers = arrayType.RankSpecifiers;
            var newRankSpecifiers = rankSpecifiers.Select((x, i) 
                => i == 0 ? SyntaxFactory.ArrayRankSpecifier(SyntaxFactoryHelper.CreateSeparatedList((ExpressionSyntax) size)) : x);
            
            return SyntaxFactory.ArrayCreationExpression(
                arrayType.WithRankSpecifiers(new SyntaxList<ArrayRankSpecifierSyntax>(newRankSpecifiers)), SyntaxFactory.InitializerExpression(SyntaxKind.ArrayInitializerExpression,
                    SyntaxFactory.SeparatedList(items)));
        }
        
        public static ArrayCreationExpressionSyntax CreateArray(ArrayTypeSyntax arrayType, ValueBridge size)
        {
            var rankSpecifiers = arrayType.RankSpecifiers;
            var newRankSpecifiers = rankSpecifiers.Select((x, i) 
                => i == 0 ? SyntaxFactory.ArrayRankSpecifier(SyntaxFactoryHelper.CreateSeparatedList((ExpressionSyntax) size)) : x);
            
            return SyntaxFactory.ArrayCreationExpression(
                arrayType.WithRankSpecifiers(new SyntaxList<ArrayRankSpecifierSyntax>(newRankSpecifiers)));
        }

        public static VariableCapture CreateVariableCapture(ISymbol symbol, ImmutableHashSet<ISymbol> changing)
        {
            var isChanging = changing.Contains(symbol);
            if (isChanging) return new VariableCapture(symbol, true);

            if (!(symbol is ILocalSymbol local)) return new VariableCapture(symbol, false);
            var type = local.Type;

            if (!type.IsValueType) return new VariableCapture(symbol, false);

            // Pass big structs by ref for performance.
            int size = StructureExtensions.GetStructSize(type);
            return new VariableCapture(symbol, size > Constants.MaximumSizeForByValStruct);
        }
        
        
        public static LocalVariable TryGetVariable(RewriteDesign design, TypedValueBridge value)
        {
            if (value?.Value?.Value == null) return null;
            var expression = value.Expression;
            while (expression is ParenthesizedExpressionSyntax parenthesizedExpressionSyntax)
                expression = parenthesizedExpressionSyntax.Expression;
            return design.Variables.FirstOrDefault(x => x.Name == expression.ToString());
        }
        
        public static int VariableIndex;
        public static LocalVariable CreateSuperGlobalVariable(RewriteDesign design, TypeSyntax type, ValueBridge initial)
        {
            string variable = "v" + VariableIndex++ % Constants.VariablesPeek;
            var created = new LocalVariable(variable, type) {IsGlobal = true, IsUsed = true};
            design.Variables.Add(created);
            
            design.InitialAdd(LocalVariableCreation(variable, type));
            design.InitialAdd(((ValueBridge)variable).Assign(initial));
            design.SimpleEnumeration = false;
            return created;
        }
        
        public static LocalVariable CreateGlobalVariable(RewriteDesign design, TypeSyntax type)
        {
            string variable = "v" + VariableIndex++ % Constants.VariablesPeek;
            var created = new LocalVariable(variable, type) {IsGlobal = true, IsUsed = true};
            design.Variables.Add(created);
            
            design.InitialAdd(LocalVariableCreation(variable, type));
            design.SimpleEnumeration = false;
            return created;
        }
        
        public static LocalVariable CreateGlobalVariable(RewriteDesign design, TypeSyntax type, ValueBridge initial, IteratorDesign iterator)
        {
            string variable = "v" + VariableIndex++ % Constants.VariablesPeek;
            var created = new LocalVariable(variable, type) {IsGlobal = true, IsUsed = true};
            design.Variables.Add(created);
            
            design.InitialAdd(LocalVariableCreation(variable, type));
            iterator.PreFor.Add((StatementBridge)((ValueBridge)variable).Assign(initial));
            design.SimpleEnumeration = false;
            return created;
        }
        
        public static LocalVariable CreateGlobalVariable(RewriteDesign design, TypeSyntax type, ValueBridge initial)
        {
            string variable = "v" + VariableIndex++ % Constants.VariablesPeek;
            var created = new LocalVariable(variable, type) {IsGlobal = true, IsUsed = true};
            design.Variables.Add(created);
            
            design.InitialAdd(LocalVariableCreation(variable, type));
            design.PreUseAdd(((ValueBridge)variable).Assign(initial));
            design.SimpleEnumeration = false;
            return created;
        }

        public static LocalVariable CreateLocalVariable(RewriteDesign design, TypedValueBridge value)
            => CreateLocalVariable(design, value.Type, value);
        
        public static LocalVariable CreateLocalVariable(RewriteDesign design, TypeBridge type, ValueBridge initial)
        {
            string variable = "v" + VariableIndex++ % Constants.VariablesPeek;
            var stringType = type.ToString();
            var foundVariable = design.Variables.FirstOrDefault(x => stringType == x.Type.ToString() && !x.IsGlobal && !x.IsUsed);
            if (foundVariable != null)
            {
                foundVariable.IsUsed = true;
                return foundVariable;
            }
            var created = new LocalVariable(variable, type);
            design.Variables.Add(created);
            
            design.InitialAdd(LocalVariableCreation(variable, type));
            design.PreUseAdd(((ValueBridge)variable).Assign(initial));
            design.SimpleEnumeration = false;
            return created;
        }
        
        public static LocalVariable CreateLocalVariable(RewriteDesign design, TypeBridge type)
        {
            var stringType = type.ToString();
            var foundVariable = design.Variables.FirstOrDefault(x => stringType == x.Type.ToString() && !x.IsGlobal && !x.IsUsed);
            if (foundVariable != null)
            {
                foundVariable.IsUsed = true;
                return foundVariable;
            }
            string variable = "v" + VariableIndex++ % Constants.VariablesPeek;
            var created = new LocalVariable(variable, type);
            design.Variables.Add(created);

            design.InitialAdd(LocalVariableCreation(variable, type));
            design.SimpleEnumeration = false;
            return created;
        }
    }
}