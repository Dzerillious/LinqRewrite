using System;
using System.Collections.Generic;
using System.Linq;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static LinqRewrite.Extensions.SymbolExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.Services
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
            var items = new[] {CreateParameter(p.Collection.ToString(), 
                    _data.Semantic.GetTypeInfo(p.Collection).Type)};
            var parameters = items.Concat(
                _data.CurrentFlow.Select(x => CreateParameter(x.Name, GetSymbolType(x.Symbol)).WithRef(x.Changes)));
           
            var functionName = _code.GetUniqueName($"{_data.CurrentMethodName}_ProceduralLinq");
            var arguments = CreateArguments(new[] {Argument(p.Collection)}
                .Concat( _data.CurrentFlow.Select(x => Argument(x.Name).WithRef(x.Changes))));

            var coreFunction = GetCoreMethod(p.ReturnType, functionName, parameters, body);

            _data.MethodsToAddToCurrentType.Add(Tuple.Create(_data.CurrentType, coreFunction));
            var args = new[] {Argument(p.Collection)}.Concat(arguments.Arguments.Skip(1));
            
            var inv = InvocationExpression(
                _code.CreateMethodNameSyntaxWithCurrentTypeParameters(functionName), CreateArguments(args));

            return inv;
        }
        
        internal ExpressionSyntax GetInvocationExpression(RewriteParameters p, IEnumerable<StatementSyntax> body)
        {
            var parameters = _data.CurrentFlow.Select(x => CreateParameter(x.Name, GetSymbolType(x.Symbol)).WithRef(x.Changes));
           
            var functionName = _code.GetUniqueName($"{_data.CurrentMethodName}_ProceduralLinq");
            var arguments = CreateArguments(
                _data.CurrentFlow.Select(x => Argument(x.Name).WithRef(x.Changes)));

            var coreFunction = GetCoreMethod(p.ReturnType, functionName, parameters, body);

            _data.MethodsToAddToCurrentType.Add(Tuple.Create(_data.CurrentType, coreFunction));
            var args = arguments.Arguments;
            
            var inv = InvocationExpression(
                _code.CreateMethodNameSyntaxWithCurrentTypeParameters(functionName), CreateArguments(args));

            return inv;
        }

        public ForStatementSyntax GetForStatement(string name, ValueBridge min, ValueBridge max, StatementSyntax loopContent)
            => ForStatement(
                VariableCreation(name, min),
                default,
                IdentifierName(name).LThan(max),
                name.SeparatedPostIncrement(),
                loopContent);

        public ForStatementSyntax GetReverseForStatement(string name, ValueBridge min, ValueBridge max, StatementSyntax loopContent)
            => ForStatement(
                VariableCreation(name, max.Sub(1)),
                default,
                IdentifierName(name).GeThan(min),
                name.SeparatedPostDecrement(),
                loopContent);
        
        public StatementSyntax GetForEachStatement(string name, ExpressionSyntax collection, StatementSyntax loopContent)
            => ForEachStatement(
                IdentifierName("var"),
                name, collection, loopContent);
        
        private IEnumerable<StatementSyntax> CreateSourceThrow(ITypeSymbol? collectionSemanticType) =>
            collectionSemanticType.IsValueType
                ? Enumerable.Empty<StatementSyntax>()
                : new[]
                {
                    If(
                        BinaryExpression(SyntaxKind.EqualsExpression,
                            // TODO: Fix collection name
                            IdentifierName(""/*Constants.GlobalItemsVariable*/),
                            LiteralExpression(SyntaxKind.NullLiteralExpression)),
                        CreateThrowException("System.ArgumentNullException"))
                };

        public MethodDeclarationSyntax GetCoreMethod(TypeSyntax returnType, 
            string functionName, 
            IEnumerable<ParameterSyntax> parameters,
            IEnumerable<StatementSyntax> body)
            => MethodDeclaration(returnType, functionName)
                .WithParameterList(CreateParameters(parameters))
                .WithBody(Block(body))
                .WithStatic(_data.CurrentMethodIsStatic)
                .WithTypeParameterList(_data.CurrentMethodTypeParameters)
                .WithConstraintClauses(_data.CurrentMethodConstraintClauses)
                .NormalizeWhitespace();
    }
}