using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using Shaman.Roslyn.LinqRewrite.Extensions;
using SyntaxExtensions = Shaman.Roslyn.LinqRewrite.Extensions.SyntaxExtensions;

namespace Shaman.Roslyn.LinqRewrite.Services
{
    public class ProcessingStepCreationService
    {
        private static ProcessingStepCreationService _instance;
        public static ProcessingStepCreationService Instance => _instance ??= new ProcessingStepCreationService();

        private readonly RewriteDataService _data;
        private readonly CodeCreationService _code;

        public ProcessingStepCreationService()
        {
            _data = RewriteDataService.Instance;
            _code = CodeCreationService.Instance;
        }

        public StatementSyntax CreateProcessingStep(List<LinqStep> chain, int chainIndex, TypeSyntax itemType,
            string itemName, ArgumentListSyntax arguments, bool noAggregation)
        {
            if (chainIndex == 0 && !noAggregation || chainIndex == -1)
                return _data.CurrentAggregation(chain[0], arguments, SyntaxFactoryHelper.CreateParameter(itemName, itemType));

            var step = chain[chainIndex];
            return step.MethodName switch
            {
                Constants.WhereMethod => WhereProcessingStep(chain, chainIndex, itemType, itemName, arguments, noAggregation, step),
                Constants.CastMethod => CastProcessingStep(chain, chainIndex, itemType, itemName, arguments, noAggregation, step),
                Constants.OfTypeMethod => OfTypeProcessingStep(chain, chainIndex, itemType, itemName, arguments, noAggregation, step),
                Constants.SelectMethod => SelectProcessingStep(chain, chainIndex, itemType, itemName, arguments, noAggregation, step),
                _ => throw new NotSupportedException()
            };
        }

        private StatementSyntax WhereProcessingStep(List<LinqStep> chain, int chainIndex, TypeSyntax itemType,
            string itemName, ArgumentListSyntax arguments, bool noAggregation, LinqStep step)
        {
            var lambda = (AnonymousFunctionExpressionSyntax) step.Arguments[0];

            var check = _code.InlineOrCreateMethod(new Lambda(lambda), SyntaxFactoryHelper.CreatePrimitiveType(SyntaxKind.BoolKeyword), SyntaxFactoryHelper.CreateParameter(itemName, itemType));
            var next = CreateProcessingStep(chain, chainIndex - 1, itemType, itemName, arguments, noAggregation);
            return SyntaxFactory.IfStatement(check, next is BlockSyntax ? next : SyntaxFactory.Block(next));
        }

        private StatementSyntax CastProcessingStep(List<LinqStep> chain, int chainIndex, TypeSyntax itemType,
            string itemName, ArgumentListSyntax arguments, bool noAggregation, LinqStep step)
        {
            var newType = ((GenericNameSyntax) ((MemberAccessExpressionSyntax) step.Invocation.Expression).Name).TypeArgumentList.Arguments.First();
            var newName = $"_linqitem{++_data.LastId}";
            var next = CreateProcessingStep(chain, chainIndex - 1, newType, newName, arguments, noAggregation);
                    
            var local = SyntaxFactoryHelper.LocalVariableCreation(newName,
                SyntaxFactory.CastExpression(newType, SyntaxFactory.IdentifierName(itemName)));
            var nextStatement = next is BlockSyntax syntax
                ? syntax.Statements
                : (IEnumerable<StatementSyntax>) new[] {next};
            return SyntaxFactory.Block(new[] {local}.Concat(nextStatement));
        }

        private StatementSyntax OfTypeProcessingStep(List<LinqStep> chain, int chainIndex, TypeSyntax itemType,
            string itemName, ArgumentListSyntax arguments, bool noAggregation, LinqStep step)
        {
            var newType = ((GenericNameSyntax) ((MemberAccessExpressionSyntax) step.Invocation.Expression).Name)
                .TypeArgumentList.Arguments.First();
            var newName = $"_linqitem{++_data.LastId}";
            var next = CreateProcessingStep(chain, chainIndex - 1, newType, newName, arguments, noAggregation);
                    
            var type = _data.Semantic.GetTypeInfo(newType).Type;
            if (type.IsValueType)
            {
                return SyntaxFactory.IfStatement(
                    SyntaxFactory.BinaryExpression(SyntaxKind.IsExpression,
                        SyntaxFactory.IdentifierName(itemName), newType), SyntaxFactory.Block(
                        SyntaxFactoryHelper.LocalVariableCreation(newName,
                            SyntaxFactory.CastExpression(newType, SyntaxFactory.IdentifierName(itemName))),
                        next

                    ));
            }

            var local = SyntaxFactoryHelper.LocalVariableCreation(newName,
                SyntaxFactory.BinaryExpression(SyntaxKind.AsExpression,
                    SyntaxFactory.IdentifierName(itemName), newType));
            return SyntaxFactory.Block(local,
                SyntaxFactory.IfStatement(
                    SyntaxFactory.BinaryExpression(SyntaxKind.NotEqualsExpression,
                        SyntaxFactory.IdentifierName(newName),
                        SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression)), next));
        }

        private StatementSyntax SelectProcessingStep(List<LinqStep> chain, int chainIndex, TypeSyntax itemType,
            string itemName, ArgumentListSyntax arguments, bool noAggregation, LinqStep step)
        {
            var lambda = (AnonymousFunctionExpressionSyntax) step.Arguments[0];

            var newName = $"_linqitem{++_data.LastId}";
            var lambdaType = (INamedTypeSymbol) _data.Semantic.GetTypeInfo(lambda).ConvertedType;
            var lambdaBodyType = lambdaType.TypeArguments.Last();
            var newType = SyntaxExtensions.IsAnonymousType(lambdaBodyType)
                ? null
                : SyntaxFactory.ParseTypeName(lambdaBodyType.ToDisplayString());

            var local = SyntaxFactoryHelper.LocalVariableCreation(newName,
                _code.InlineOrCreateMethod(new Lambda(lambda), newType,
                    SyntaxFactoryHelper.CreateParameter(itemName, itemType)));

            var next = CreateProcessingStep(chain, chainIndex - 1, newType, newName, arguments, noAggregation);
            var nextStatement = next is BlockSyntax syntax
                ? syntax.Statements
                : (IEnumerable<StatementSyntax>) new[] {next};
            return SyntaxFactory.Block(new[] {local}.Concat(nextStatement));
        }
    }
}