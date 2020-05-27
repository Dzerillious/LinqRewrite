// Forked and modified from https://github.com/antiufo/roslyn-linq-rewrite/tree/master/RoslynLinqRewrite

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
using static LinqRewrite.Extensions.SyntaxExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.Services
{
    public class CodeCreationService
    {
        private static CodeCreationService _instance;
        public static CodeCreationService Instance => _instance ??= new CodeCreationService();
        
        private readonly RewriteDataService _data;

        public CodeCreationService()
        {
            _data = RewriteDataService.Instance;
        }

        public static ValueBridge CreateCollectionCount(ValueBridge collection, CollectionType collectionType) 
            => collectionType switch
            {
                CollectionType.Array => (ValueBridge) collection.Access("Length"),
                CollectionType.List => collection.Access("Count"),
                _ => collection.Access("Count").Invoke()
            };

        public ExpressionSyntax CreateMethod(string identifier)
            => (_data.CurrentMethodTypeParameters?.Parameters.Count).GetValueOrDefault() != 0
                ? GenericName(
                    Identifier(identifier),
                    TypeArgumentList(CreateSeparatedList(_data.CurrentMethodTypeParameters.Parameters
                            .Select(x => ParseTypeName(x.Identifier.ValueText)))))
                : (NameSyntax) IdentifierName(identifier);

        public TypedValueBridge InlineLambda(RewriteDesign p, RewrittenValueBridge rewritten, TypeSyntax returnType, params TypedValueBridge[] replaceParameters)
        {
            if (rewritten.OldVal is IdentifierNameSyntax identifier)
                return new TypedValueBridge(returnType, identifier.Invoke(replaceParameters));
            
            var oldLambda = new Lambda((LambdaExpressionSyntax)rewritten.OldVal);

            var lambdaParams = replaceParameters.Select((x, i) => GetLambdaParameter(oldLambda, i)).ToArray();
            var currentFlow = _data.Semantic.AnalyzeDataFlow(oldLambda.Body);
            var changing = currentFlow.DataFlowsOut.Concat(currentFlow.WrittenInside).ToArray();
            var currentCaptures = currentFlow.DataFlowsIn
                .Where(x => lambdaParams.All(y => x.Name != y.Identifier.ValueText) && (x as IParameterSymbol)?.IsThis != true)
                .Select(x => CreateVariableCapture(x, changing))
                .ToArray();

            if (!p.HasResultMethod && p.Data.CurrentMethodParams.Any(x => x.Modifiers.Any()))
            {
                var parameterTypes = replaceParameters.Select(x => x.Type.ToString()).Concat(new[] {returnType.ToString()});
                var funcType = ParseTypeName($"System.Func<{string.Join(",", parameterTypes)}>");
                var lambdaVariable = p.AddParameter(funcType, rewritten.NewVal);
                return new TypedValueBridge(returnType, lambdaVariable.Invoke(replaceParameters));
            }
            var newLambda = new Lambda((LambdaExpressionSyntax)rewritten.NewVal);
            newLambda = RenameSymbol(newLambda, replaceParameters);
            return new TypedValueBridge(returnType, InlineOrCreateMethod(p, currentFlow, newLambda, returnType, currentCaptures, replaceParameters));
        }

        private static ExpressionSyntax GetStatementExpression(StatementSyntax statement) 
            => statement switch
            {
                ExpressionStatementSyntax expressionStatementSyntax => expressionStatementSyntax.Expression,
                LocalDeclarationStatementSyntax localDeclarationStatementSyntax => localDeclarationStatementSyntax
                    .Declaration.Variables.Last()
                    .Initializer.Value,
                ReturnStatementSyntax returnStatementSyntax => returnStatementSyntax.Expression,
                _ => null
            };
        
        public static ValueBridge GetLastLambdaExpression(LambdaExpressionSyntax lambdaExpression)
            => lambdaExpression.ExpressionBody ?? GetStatementExpression(lambdaExpression.Block.Statements.Last());

        public static TypeSyntax GetLambdaReturnType(SemanticModel semantic, LambdaExpressionSyntax lambdaExpression) 
            => semantic.GetTypeFromExpression(GetLastLambdaExpression(lambdaExpression));

        public ExpressionSyntax InlineOrCreateMethod(RewriteDesign p, DataFlowAnalysis currentFlow, Lambda lambda, TypeSyntax returnType,
            IEnumerable<VariableCapture> captures, TypedValueBridge[] replaceParameters)
        {
            var fn = GetUniqueName($"{_data.CurrentMethodName}_ProceduralLinqHelper");
            if (lambda.Body is ExpressionSyntax syntax) return ParenthesizedExpression(syntax);

            if (captures.Any(x => IsAnonymousType(x.GetSymbolType()))) 
                throw new NotSupportedException();
            if (returnType == null) throw new NotSupportedException(); // Anonymous type
            
            var replaceParams = UpdateParameters(p, currentFlow, lambda, replaceParameters);
            var method = MethodDeclaration(returnType, fn)
                .WithParameterList(ParameterList(SeparatedList(
                    replaceParams.Union(captures.Select(x => CreateParameter(x.Name, x.GetSymbolType())
                        .WithRef(x.Changes)))
                )))
                .WithBody(lambda.Body as BlockSyntax ?? (lambda.Body is StatementSyntax statementSyntax
                              ? Block(statementSyntax)
                              : Block(Return((ExpressionSyntax) lambda.Body))))
                .WithStatic(_data.CurrentMethodIsStatic)
                .WithTypeParameterList(_data.CurrentMethodTypeParameters)
                .WithConstraintClauses(_data.CurrentMethodConstraintClauses)
                .NormalizeWhitespace();

            _data.MethodsToAddToCurrentType.Add(Tuple.Create(_data.CurrentType, method));
            return ParenthesizedExpression(InvocationExpression(
                CreateMethod(fn),
                CreateArguments(replaceParams.Select(x => SyntaxFactory.Argument(IdentifierName(x.Identifier.ValueText)))
                    .Union(captures.Select(x =>  SyntaxFactory.Argument(IdentifierName(x.OriginalName)).WithRef(x.Changes))))));
        }

        private static ParameterSyntax[] UpdateParameters(RewriteDesign p, DataFlowAnalysis currentFlow, Lambda oldLambda, TypedValueBridge[] replaceParameters)
        {
            var typedParams = new List<ParameterSyntax>();
            foreach (var symbol in currentFlow.DataFlowsIn)
            {
                if (!(symbol is IParameterSymbol parameterSymbol)) continue;
                var found = oldLambda.Parameters.FirstOrDefault(y => y.Identifier.Text == parameterSymbol.Name);
                if (found == null) continue;
                typedParams.Add(found.WithType(ParseTypeName(parameterSymbol.Type.ToDisplayString())));
            }
            var resultParams = new ParameterSyntax[typedParams.Count];
            for (var i = 0; i < typedParams.Count; i++)
            {
                var value = replaceParameters[i].Value.Value;
                while (value is ParenthesizedExpressionSyntax parenthesizedExpressionSyntax)
                    value = parenthesizedExpressionSyntax.Expression;

                var identifier = value is IdentifierNameSyntax
                    ? value : replaceParameters[i].Value.Reusable(p, typedParams[i].Type).Expression;
                resultParams[i] = CreateParameter(identifier.ToString(), typedParams[i].Type);
            }
            return resultParams;
        }

        private static Lambda RenameSymbol(Lambda newLambda, ValueBridge[] replace)
        {
            var parameters = replace.Select((x, i) => GetLambdaParameter(newLambda, i)).ToArray();
            var tokensToRename = newLambda.Body.DescendantNodesAndSelf()
                .Where(x => x is IdentifierNameSyntax && 
                            parameters.Any(y => y.Identifier.ValueText == x.ToString()));
            
            var syntax = ParenthesizedLambdaExpression(
                CreateParameters(newLambda.Parameters.Select((x, i) =>  x)),
                newLambda.Body.ReplaceNodes(tokensToRename, (a, b) =>
                {
                    if (!(b is IdentifierNameSyntax ide)) throw new NotImplementedException();
                    
                    for (var i = 0; i < parameters.Length; i++)
                        if (parameters[i].ToString() == ide.ToString())
                            return (ExpressionSyntax)replace[i];
                    throw new NotImplementedException();
                }));
            return new Lambda(syntax);
        }

        public string GetUniqueName(string v) => v + "_" + Guid.NewGuid().ToString().Replace("-", "");
    }
}