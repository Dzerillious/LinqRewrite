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

        public ValueBridge CreateCollectionCount(ValueBridge collection, ValueBridge fromType, bool allowUnknown = false)
        {
            var collectionType = _data.Semantic.GetTypeInfo(fromType).Type;
            if (collectionType is IArrayTypeSymbol) return collection.Access("Length");
            if (collectionType.ToDisplayString().StartsWith("System.Collections.Generic.IReadOnlyCollection<") || collectionType.AllInterfaces.Any(x => x.ToDisplayString().StartsWith("System.Collections.Generic.IReadOnlyCollection<")))
                return collection.Access("Count");
                
            if (collectionType.ToDisplayString().StartsWith("System.Collections.Generic.ICollection<") || collectionType.AllInterfaces.Any(x => x.ToDisplayString().StartsWith("System.Collections.Generic.ICollection<")))
                return collection.Access("Count");
                
            if (collectionType.ToDisplayString().StartsWith("LinqRewrite.Core.SimpleList.SimpleList<int>"))
                return collection.Access("Count");

            if (!allowUnknown) return null;
            if (collectionType.IsValueType) return null;
            var itemType = GetItemType(collectionType);
            if (itemType == null) return null;
            
            return Parenthesize(
                ConditionalAccessExpression(
                    ParenthesizedExpression(
                        ((VariableBridge)collection.ToString()).As(ParseTypeName($"System.Collections.Generic.ICollection<{itemType.ToDisplayString()}>"))
                    ),
                    MemberBindingExpression(IdentifierName("Count"))
                )
            ).Access("GetValueOrDefault").Invoke();
        }

        public ExpressionSyntax CreateMethod(string identifier)
            => (_data.CurrentMethodTypeParameters?.Parameters.Count).GetValueOrDefault() != 0
                ? GenericName(
                    Identifier(identifier),
                    TypeArgumentList(CreateSeparatedList(_data.CurrentMethodTypeParameters.Parameters
                            .Select(x => ParseTypeName(x.Identifier.ValueText)))))
                : (NameSyntax) IdentifierName(identifier);

        public TypedValueBridge InlineLambda(RewriteParameters p, ExpressionSyntax expression, TypeSyntax returnType, params TypedValueBridge[] parameters)
        {
            if (expression is IdentifierNameSyntax identifier)
                return new TypedValueBridge(returnType, identifier.Invoke(parameters));
            
            var lambda = new Lambda((LambdaExpressionSyntax)expression);

            var pS = parameters.Select((x, i) => GetLambdaParameter(lambda, i)).ToArray();
            var currentFlow = _data.Semantic.AnalyzeDataFlow(lambda.Body);
            var currentCaptures = currentFlow
                .DataFlowsOut
                .Union(currentFlow.DataFlowsIn)
                .Where(x => pS.All(y => x.Name != y.Identifier.ValueText) &&(x as IParameterSymbol)?.IsThis != true)
                .Select(x => CreateVariableCapture(x, currentFlow.DataFlowsOut, currentFlow.WrittenInside))
                .ToList();

            if (!p.HasResultMethod && p.Data.CurrentMethodParams.Any(x => x.Modifiers.Any()))
            {
                var parameterTypes = parameters.Select(x => x.Type.ToString()).Concat(new[] {returnType.ToString()});
                var funcType = ParseTypeName($"System.Func<{string.Join(",", parameterTypes)}>");
                var lambdaVariable = p.AddParameter(funcType, expression);
                return new TypedValueBridge(returnType, lambdaVariable.Invoke(parameters));
            }
            lambda = RenameSymbol(lambda, parameters);
            return new TypedValueBridge(returnType, InlineOrCreateMethod(lambda.Body, returnType, currentCaptures, pS));
        }

        private ExpressionSyntax GetStatementExpression(StatementSyntax statement)
        {
            return statement switch
            {
                ExpressionStatementSyntax expressionStatementSyntax => expressionStatementSyntax.Expression,
                LocalDeclarationStatementSyntax localDeclarationStatementSyntax => localDeclarationStatementSyntax
                    .Declaration.Variables.Last()
                    .Initializer.Value,
                ReturnStatementSyntax returnStatementSyntax => returnStatementSyntax.Expression,
                _ => null
            };
        }

        public TypeSyntax GetLambdaReturnType(SemanticModel semantic, LambdaExpressionSyntax lambdaExpression) 
            => lambdaExpression.ExpressionBody == null 
                ? semantic.GetTypeFromExpression(GetStatementExpression(lambdaExpression.Block.Statements.Last()))
                : semantic.GetTypeFromExpression(lambdaExpression.ExpressionBody);

        public ExpressionSyntax InlineOrCreateMethod(CSharpSyntaxNode body, TypeSyntax returnType,
            IEnumerable<VariableCapture> captures, params ParameterSyntax[] param)
        {
            var fn = GetUniqueName($"{_data.CurrentMethodName}_ProceduralLinqHelper");
            if (body is ExpressionSyntax syntax) return ParenthesizedExpression(syntax);

            if (captures.Any(x => IsAnonymousType(((VariableCapture) x.Symbol).GetSymbolType()))) 
                throw new NotSupportedException();
            if (returnType == null) throw new NotSupportedException(); // Anonymous type
            
            var method = MethodDeclaration(returnType, fn)
                .WithParameterList(ParameterList(SeparatedList(
                    param.Union(captures.Select(x => CreateParameter(x.Name, x.GetSymbolType())
                        .WithRef(x.Changes)))
                )))
                .WithBody(body as BlockSyntax ?? (body is StatementSyntax statementSyntax
                              ? Block(statementSyntax)
                              : Block(Return((ExpressionSyntax) body))))
                .WithStatic(_data.CurrentMethodIsStatic)
                .WithTypeParameterList(_data.CurrentMethodTypeParameters)
                .WithConstraintClauses(_data.CurrentMethodConstraintClauses)
                .NormalizeWhitespace();

            _data.MethodsToAddToCurrentType.Add(Tuple.Create(_data.CurrentType, method));
            return ParenthesizedExpression(InvocationExpression(
                CreateMethod(fn),
                CreateArguments(param.Select(x => SyntaxFactory.Argument(IdentifierName(x.Identifier.ValueText)))
                    .Union(captures.Select(x =>  SyntaxFactory.Argument(IdentifierName(x.Name)).WithRef(x.Changes))))));
        }

        private Lambda RenameSymbol(Lambda container, ValueBridge[] replace)
        {
            var parameters = replace.Select((x, i) => GetLambdaParameter(container, i)).ToArray();
            var tokensToRename = container.Body.DescendantNodesAndSelf()
                .Where(x =>
            {
                var sem = _data.Semantic.GetSymbolInfo(x).Symbol;
                return sem != null && (sem is ILocalSymbol || sem is IParameterSymbol) 
                                   && parameters.Any(y => y.Identifier.ValueText == sem.Name);
            });
            var syntax = ParenthesizedLambdaExpression(
                CreateParameters(container.Parameters.Select((x, i) =>  x)),
                container.Body.ReplaceNodes(tokensToRename, (a, b) =>
                {
                    if (!(b is IdentifierNameSyntax ide)) throw new NotImplementedException();
                    
                    for (var i = 0; i < parameters.Length; i++)
                        if (parameters[i].ToString() == ide.ToString())
                            return (ExpressionSyntax)replace[i];
                    throw new NotImplementedException();
                }));
            return new Lambda(syntax);
        }

        public string GetMethodFullName(InvocationExpressionSyntax invocation)
        {
            var definition = (_data.Semantic.GetSymbolInfo(invocation.Expression).Symbol as IMethodSymbol)?.OriginalDefinition
                .ToDisplayString();
            const string iEnumerableOfTSource = "System.Collections.Generic.IEnumerable<TSource>";

            return definition?.Replace("System.Collections.Generic.List<TSource>", iEnumerableOfTSource)
                .Replace("TSource[]", iEnumerableOfTSource);
        }

        public string GetUniqueName(string v)
        {
            for (var i = 1;; i++)
            {
                var name = v + i;
                if (_data.MethodsToAddToCurrentType.Any(x => x.Item2.Identifier.ValueText == name)) 
                    continue;
                return name;
            }
        }
    }
}