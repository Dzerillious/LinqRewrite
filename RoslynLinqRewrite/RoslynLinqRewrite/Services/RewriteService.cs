using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using Shaman.Roslyn.LinqRewrite.Extensions;

namespace Shaman.Roslyn.LinqRewrite.Services
{
    public class RewriteService
    {
        private static RewriteService _instance;
        public static RewriteService Instance => _instance ??= new RewriteService();

        private readonly RewriteDataService _data;
        private readonly CodeCreationService _code;
        private readonly ProcessingStepCreationService _processingStep;
        public Func<SyntaxNode, SyntaxNode> Visit;

        public RewriteService()
        {
            _data = RewriteDataService.Instance;
            _code = CodeCreationService.Instance;
            _processingStep = ProcessingStepCreationService.Instance;
        }
        
        internal ExpressionSyntax RewriteAsLoop(TypeSyntax returnType, IEnumerable<StatementSyntax> prologue,
            IEnumerable<StatementSyntax> epilogue, ExpressionSyntax collection, List<LinqStep> chain,
            RewriteDataService.AggregationDelegate k, bool noAggregation = false,
            IEnumerable<Tuple<ParameterSyntax, ExpressionSyntax>> additionalParameters = null)
        {
            var old = _data.CurrentAggregation;
            _data.CurrentAggregation = k;

            // var collectionType = _data.Semantic.GetTypeInfo(collection).Type;
            // var collectionItemType = _info.GetItemType(collectionType);
            // if (collectionItemType == null) throw new NotSupportedException();
            // var collectionSemanticType = _data.Semantic.GetTypeInfo(collection).Type;

            var parameters = 
                _data.CurrentFlow.Select(x => SyntaxFactoryHelper.CreateParameter(x.Name, SymbolExtensions.GetSymbolType(x.Symbol)).WithRef(x.Changes));
            if (additionalParameters != null) parameters = parameters.Concat(additionalParameters.Select(x => x.Item1));

            var functionName = _code.GetUniqueName($"{_data.CurrentMethodName}_ProceduralLinq");
            var arguments = SyntaxFactoryHelper.CreateArguments(new[] {SyntaxFactory.Argument(SyntaxFactory.IdentifierName(Constants.ItemName))}.Concat(
                _data.CurrentFlow.Select(x => SyntaxFactory.Argument(SyntaxFactory.IdentifierName(x.Name)).WithRef(x.Changes))));

            // var loopContent = _processingStep.CreateProcessingStep(chain, chain.Count - 1,
            //     SyntaxFactory.ParseTypeName(collectionItemType.ToDisplayString()), Constants.ItemName, arguments, noAggregation);
            //
            // var foreachStatement = collectionType.ToDisplayString().StartsWith("System.Collections.Generic.List<") || collectionType is IArrayTypeSymbol
            //     ? GetForStatement(loopContent, _code.CreateCollectionCount(collection, false))
            //     : GetForEachStatement(loopContent);
            //
            // var coreFunction = GetCoreMethod(returnType, 
            //     functionName, parameters, prologue.Concat(CreateSourceThrow(collectionSemanticType))
            //         .Concat(new[]{foreachStatement}).Concat(epilogue).ToList());
            //
            // _data.MethodsToAddToCurrentType.Add(Tuple.Create(_data.CurrentType, coreFunction));
            // var args = new[] {SyntaxFactory.Argument((ExpressionSyntax) Visit(collection))}
            //         .Concat(arguments.Arguments.Skip(1));
            //
            // if (additionalParameters != null) args = args.Concat(additionalParameters.Select(x => SyntaxFactory.Argument(x.Item2)));
            var inv = SyntaxFactory.InvocationExpression(
                _code.CreateMethodNameSyntaxWithCurrentTypeParameters(functionName), SyntaxFactoryHelper.CreateArguments());

            _data.CurrentAggregation = old;
            return inv;
        }
        
        internal ExpressionSyntax RewriteEnumerableLoop(TypeSyntax returnType, IEnumerable<StatementSyntax> prologue,
            IEnumerable<StatementSyntax> epilogue, ExpressionSyntax collection, List<LinqStep> chain,
            RewriteDataService.AggregationDelegate k, bool noAggregation = false,
            IEnumerable<Tuple<ParameterSyntax, ExpressionSyntax>> additionalParameters = null)
        {
            var old = _data.CurrentAggregation;
            _data.CurrentAggregation = k;

            var parameters = _data.CurrentFlow.Select(x => SyntaxFactoryHelper.CreateParameter(x.Name, SymbolExtensions.GetSymbolType(x.Symbol)).WithRef(x.Changes));
            if (additionalParameters != null) parameters = parameters.Concat(additionalParameters.Select(x => x.Item1));

            var functionName = _code.GetUniqueName($"{_data.CurrentMethodName}_ProceduralLinq");
            var arguments = SyntaxFactoryHelper.CreateArguments(_data.CurrentFlow.Select(x => SyntaxFactory.Argument(SyntaxFactory.IdentifierName(x.Name)).WithRef(x.Changes)));

            var loopContent = _processingStep.CreateProcessingStep(chain, chain.Count - 1,
                SyntaxFactory.ParseTypeName("tmp"), Constants.ItemName, arguments, noAggregation);

            var foreachStatement = GetForStatement("__i", SyntaxFactoryHelper.IntExpression(0), SyntaxFactoryHelper.IntExpression(100), loopContent);

            var coreFunction = GetCoreMethod(returnType, functionName, parameters,
                prologue.Concat(new []{foreachStatement}).Concat(epilogue).ToList());

            _data.MethodsToAddToCurrentType.Add(Tuple.Create(_data.CurrentType, coreFunction));
            var args = new[] {SyntaxFactory.Argument((ExpressionSyntax) Visit(collection))}
                    .Concat(arguments.Arguments.Skip(1));
            
            if (additionalParameters != null) args = args.Concat(additionalParameters.Select(x => SyntaxFactory.Argument(x.Item2)));
            var inv = SyntaxFactory.InvocationExpression(
                _code.CreateMethodNameSyntaxWithCurrentTypeParameters(functionName), SyntaxFactoryHelper.CreateArguments(args));

            _data.CurrentAggregation = old;
            return inv;
        }
        
        internal ExpressionSyntax GetInvocationExpression(RewriteParameters p, IEnumerable<StatementSyntax> body)
        {
            var parameters = _data.CurrentFlow.Select(x => SyntaxFactoryHelper.CreateParameter(x.Name, SymbolExtensions.GetSymbolType(x.Symbol)).WithRef(x.Changes));
            //if (additionalParameters != null) parameters = parameters.Concat(additionalParameters.Select(x => x.Item1));

            var functionName = _code.GetUniqueName($"{_data.CurrentMethodName}_ProceduralLinq");
            var arguments = SyntaxFactoryHelper.CreateArguments(_data.CurrentFlow.Select(x => SyntaxFactory.Argument(SyntaxFactory.IdentifierName(x.Name)).WithRef(x.Changes)));

            var coreFunction = GetCoreMethod(p.ReturnType, functionName, parameters, body);

            _data.MethodsToAddToCurrentType.Add(Tuple.Create(_data.CurrentType, coreFunction));
            var args = arguments.Arguments;
            
            // if (additionalParameters != null) args = args.Concat(additionalParameters.Select(x => SyntaxFactory.Argument(x.Item2)));
            var inv = SyntaxFactory.InvocationExpression(
                _code.CreateMethodNameSyntaxWithCurrentTypeParameters(functionName), SyntaxFactoryHelper.CreateArguments(args));

            // _data.CurrentAggregation = old;
            return inv;
        }

        public ForStatementSyntax GetForStatement(string name, ExpressionSyntax min, ExpressionSyntax max, StatementSyntax loopContent)
            => SyntaxFactory.ForStatement(
                SyntaxFactoryHelper.VariableCreation(name, min),
                default,
                SyntaxFactory.BinaryExpression(SyntaxKind.LessThanExpression,
                    SyntaxFactory.IdentifierName(name),
                    max),
                SyntaxFactoryHelper.PostIncrement(name),
                loopContent);
        
        private StatementSyntax GetForEachStatement(StatementSyntax loopContent)
            => SyntaxFactory.ForEachStatement(
                SyntaxFactory.IdentifierName("var"),
                Constants.ItemName,
                SyntaxFactory.IdentifierName(Constants.ItemsName),
                loopContent is BlockSyntax ? loopContent : SyntaxFactory.Block(loopContent));
        
        private IEnumerable<StatementSyntax> CreateSourceThrow(ITypeSymbol? collectionSemanticType) =>
            collectionSemanticType.IsValueType
                ? Enumerable.Empty<StatementSyntax>()
                : new[]
                {
                    SyntaxFactory.IfStatement(
                        SyntaxFactory.BinaryExpression(SyntaxKind.EqualsExpression,
                            SyntaxFactory.IdentifierName(Constants.ItemsName),
                            SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression)),
                        SyntaxFactoryHelper.CreateThrowException("System.ArgumentNullException"))
                };

        public MethodDeclarationSyntax GetCoreMethod(TypeSyntax returnType, 
            string functionName, 
            IEnumerable<ParameterSyntax> parameters,
            IEnumerable<StatementSyntax> body)
            => SyntaxFactory.MethodDeclaration(returnType, functionName)
                .WithParameterList(SyntaxFactoryHelper.CreateParameters(parameters))
                .WithBody(SyntaxFactory.Block(body))
                .WithStatic(_data.CurrentMethodIsStatic)
                .WithTypeParameterList(_data.CurrentMethodTypeParameters)
                .WithConstraintClauses(_data.CurrentMethodConstraintClauses)
                .NormalizeWhitespace();
    }
}