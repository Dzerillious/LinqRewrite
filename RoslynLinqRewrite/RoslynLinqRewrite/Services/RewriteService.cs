using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using Shaman.Roslyn.LinqRewrite.Extensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.VariableExtensions;

namespace Shaman.Roslyn.LinqRewrite.Services
{
    public class RewriteService
    {
        private static RewriteService _instance;
        public static RewriteService Instance => _instance ??= new RewriteService();
        public Func<ExpressionSyntax, ExpressionSyntax> Visit { get; set; }

        private readonly RewriteDataService _data;
        private readonly CodeCreationService _code;

        public RewriteService()
        {
            _data = RewriteDataService.Instance;
            _code = CodeCreationService.Instance;
        }
        
        internal ExpressionSyntax GetCollectionInvocationExpression(RewriteParameters p, IEnumerable<StatementSyntax> body)
        {
            var items = new[] {SyntaxFactoryHelper.CreateParameter(Constants.ItemsName, 
                    _data.Semantic.GetTypeInfo(p.Collection).Type)};
            var parameters = items.Concat(_data.CurrentFlow.Select(x => SyntaxFactoryHelper.CreateParameter(x.Name, SymbolExtensions.GetSymbolType(x.Symbol)).WithRef(x.Changes)));
           
            var functionName = _code.GetUniqueName($"{_data.CurrentMethodName}_ProceduralLinq");
            var arguments = SyntaxFactoryHelper.CreateArguments(new[] {SyntaxFactory.Argument(p.Collection)}.Concat(
                _data.CurrentFlow.Select(x => SyntaxFactory.Argument(SyntaxFactory.IdentifierName(x.Name)).WithRef(x.Changes))));

            var coreFunction = GetCoreMethod(p.ReturnType, functionName, parameters, body);

            _data.MethodsToAddToCurrentType.Add(Tuple.Create(_data.CurrentType, coreFunction));
            var args = new[] {SyntaxFactory.Argument(p.Collection)}.Concat(arguments.Arguments.Skip(1));
            
            var inv = SyntaxFactory.InvocationExpression(
                _code.CreateMethodNameSyntaxWithCurrentTypeParameters(functionName), SyntaxFactoryHelper.CreateArguments(args));

            return inv;
        }
        
        internal ExpressionSyntax GetInvocationExpression(RewriteParameters p, IEnumerable<StatementSyntax> body)
        {
            var parameters = _data.CurrentFlow.Select(x => SyntaxFactoryHelper.CreateParameter(x.Name, SymbolExtensions.GetSymbolType(x.Symbol)).WithRef(x.Changes));
           
            var functionName = _code.GetUniqueName($"{_data.CurrentMethodName}_ProceduralLinq");
            var arguments = SyntaxFactoryHelper.CreateArguments(
                _data.CurrentFlow.Select(x => SyntaxFactory.Argument(SyntaxFactory.IdentifierName(x.Name)).WithRef(x.Changes)));

            var coreFunction = GetCoreMethod(p.ReturnType, functionName, parameters, body);

            _data.MethodsToAddToCurrentType.Add(Tuple.Create(_data.CurrentType, coreFunction));
            var args = arguments.Arguments;
            
            var inv = SyntaxFactory.InvocationExpression(
                _code.CreateMethodNameSyntaxWithCurrentTypeParameters(functionName), SyntaxFactoryHelper.CreateArguments(args));

            return inv;
        }

        public ForStatementSyntax GetForStatement(string name, ValueBridge min, ValueBridge max, StatementSyntax loopContent)
            => SyntaxFactory.ForStatement(
                VariableCreation(name, min),
                default,
                SyntaxFactory.IdentifierName(name).LThan(max),
                name.SeparatedPostIncrement(),
                loopContent);

        public ForStatementSyntax GetReverseForStatement(string name, ValueBridge min, ValueBridge max, StatementSyntax loopContent)
            => SyntaxFactory.ForStatement(
                VariableCreation(name, max.Sub(IntValue(1))),
                default,
                SyntaxFactory.IdentifierName(name).GeThan(min),
                name.SeparatedPostDecrement(),
                loopContent);
        
        public StatementSyntax GetForEachStatement(string name, ExpressionSyntax collection, StatementSyntax loopContent)
            => SyntaxFactory.ForEachStatement(
                SyntaxFactory.IdentifierName("var"),
                name, collection, loopContent);
        
        private IEnumerable<StatementSyntax> CreateSourceThrow(ITypeSymbol? collectionSemanticType) =>
            collectionSemanticType.IsValueType
                ? Enumerable.Empty<StatementSyntax>()
                : new[]
                {
                    SyntaxFactoryHelper.If(
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