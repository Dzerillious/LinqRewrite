using System;
using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
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

        public TypedValueBridge InlineLambda(RewriteParameters p, RewrittenValueBridge rewritten, TypeSyntax returnType, params TypedValueBridge[] replaceParameters)
        {
            if (rewritten.OldVal is IdentifierNameSyntax identifier)
                return new TypedValueBridge(returnType, identifier.Invoke(replaceParameters));
            
            var oldLambda = new Lambda((LambdaExpressionSyntax)rewritten.OldVal);

            var lambdaParams = replaceParameters.Select((x, i) => GetLambdaParameter(oldLambda, i)).ToArray();
            var currentFlow = _data.Semantic.AnalyzeDataFlow(oldLambda.Body);
            var currentCaptures = currentFlow
                .DataFlowsOut
                .Union(currentFlow.DataFlowsIn)
                .Where(x => lambdaParams.All(y => x.Name != y.Identifier.ValueText) &&(x as IParameterSymbol)?.IsThis != true)
                .Select(x => CreateVariableCapture(x, currentFlow.DataFlowsOut, currentFlow.WrittenInside))
                .ToList();

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

        public ExpressionSyntax InlineOrCreateMethod(RewriteParameters p, DataFlowAnalysis currentFlow, Lambda lambda, TypeSyntax returnType,
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
                    .Union(captures.Select(x =>  SyntaxFactory.Argument(IdentifierName(x.Name)).WithRef(x.Changes))))));
        }

        private static ParameterSyntax[] UpdateParameters(RewriteParameters p, DataFlowAnalysis currentFlow, Lambda oldLambda, TypedValueBridge[] replaceParameters)
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

        private Lambda RenameSymbol(Lambda newLambda, ValueBridge[] replace)
        {
            var parameters = replace.Select((x, i) => GetLambdaParameter(newLambda, i)).ToArray();
            var tokensToRename = newLambda.Body.DescendantNodesAndSelf()
                .Where(x =>
            {
                if (x is IdentifierNameSyntax)
                    return parameters.Any(y => y.Identifier.ValueText == x.ToString());
                else return false;
            });
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