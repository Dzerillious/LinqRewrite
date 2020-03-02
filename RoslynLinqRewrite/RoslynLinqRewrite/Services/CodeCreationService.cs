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

        public ExpressionSyntax CreateCollectionCount(ExpressionSyntax collection, bool allowUnknown)
        {
            var collectionType = _data.Semantic.GetTypeInfo(collection).Type;
            if (collectionType is IArrayTypeSymbol) return MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, collection, IdentifierName("Length"));
            if (collectionType.ToDisplayString().StartsWith("System.Collections.Generic.IReadOnlyCollection<") || collectionType.AllInterfaces.Any(x => x.ToDisplayString().StartsWith("System.Collections.Generic.IReadOnlyCollection<")))
                return MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, collection, IdentifierName("Count"));
                
            if (collectionType.ToDisplayString().StartsWith("System.Collections.Generic.ICollection<") || collectionType.AllInterfaces.Any(x => x.ToDisplayString().StartsWith("System.Collections.Generic.ICollection<")))
                return MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, collection, IdentifierName("Count"));

            if (!allowUnknown) return null;
            if (collectionType.IsValueType) return null;
            var itemType = GetItemType(collectionType);
            if (itemType == null) return null;
            
            return ParenthesizedExpression(
                ConditionalAccessExpression(
                    ParenthesizedExpression(
                        ((VariableBridge)collection.ToString()).As(ParseTypeName($"System.Collections.Generic.ICollection<{itemType.ToDisplayString()}>"))
                    ),
                    MemberBindingExpression(IdentifierName("Count"))
                )
            ).Access("GetValueOrDefault").Invoke();
        }

        public ExpressionSyntax CreateMethodNameSyntaxWithCurrentTypeParameters(string identifier)
            => (_data.CurrentMethodTypeParameters?.Parameters.Count).GetValueOrDefault() != 0
                ? GenericName(
                    Identifier(identifier),
                    TypeArgumentList(
                        CreateSeparatedList(_data.CurrentMethodTypeParameters.Parameters
                            .Select(x => ParseTypeName(x.Identifier.ValueText)))))
                : (NameSyntax) IdentifierName(identifier);

        public TypedValueBridge InlineLambda(SemanticModel semantic, ExpressionSyntax expression, params ValueBridge[] p)
        {
            if (expression is IdentifierNameSyntax identifier)
                return new TypedValueBridge(Int, identifier.Invoke(p));
            
            var simpleLambda = (LambdaExpressionSyntax) expression;
            var lambda = new Lambda(simpleLambda);
            
            var returnType = simpleLambda.ExpressionBody == null 
                ? semantic.GetTypeFromExpression(((ReturnStatementSyntax) simpleLambda.Block.Statements.Last()).Expression)
                : semantic.GetTypeFromExpression(simpleLambda.ExpressionBody);

            var pS = p.Select((x, i) => GetLambdaParameter(lambda, i)).ToArray();
            var currentFlow = _data.Semantic.AnalyzeDataFlow(lambda.Body);
            var currentCaptures = currentFlow
                .DataFlowsOut
                .Union(currentFlow.DataFlowsIn)
                .Where(x => pS.All(y => x.Name != y.Identifier.ValueText) &&(x as IParameterSymbol)?.IsThis != true)
                .Select(x => CreateVariableCapture(x, currentFlow.DataFlowsOut))
                .ToList();

            lambda = RenameSymbol(lambda, p);
            return new TypedValueBridge(returnType, InlineOrCreateMethod(lambda.Body, returnType, currentCaptures, pS));
        }

        public ExpressionSyntax InlineOrCreateMethod(CSharpSyntaxNode body, TypeSyntax returnType,
            IEnumerable<VariableCapture> captures, params ParameterSyntax[] param)
        {
            var fn = GetUniqueName($"{_data.CurrentMethodName}_ProceduralLinqHelper");
            if (body is ExpressionSyntax syntax) return ParenthesizedExpression(syntax);

            if (captures.Any(x => IsAnonymousType(GetSymbolType(x.Symbol)))) 
                throw new NotSupportedException();
            if (returnType == null) throw new NotSupportedException(); // Anonymous type
            
            var method = MethodDeclaration(returnType, fn)
                .WithParameterList(ParameterList(SeparatedList(
                    param.Union(captures.Select(x => CreateParameter(x.Name, GetSymbolType(x))
                        .WithRef(x.Changes)))
                )))
                .WithBody(body as BlockSyntax ?? (body is StatementSyntax statementSyntax
                              ? Block(statementSyntax)
                              : Block(ReturnStatement((ExpressionSyntax) body))))
                .WithStatic(_data.CurrentMethodIsStatic)
                .WithTypeParameterList(_data.CurrentMethodTypeParameters)
                .WithConstraintClauses(_data.CurrentMethodConstraintClauses)
                .NormalizeWhitespace();

            _data.MethodsToAddToCurrentType.Add(Tuple.Create(_data.CurrentType, method));
            return ParenthesizedExpression(InvocationExpression(
                CreateMethodNameSyntaxWithCurrentTypeParameters(fn),
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
            //var doc = project.GetDocument(docid);

            //var annot = new SyntaxAnnotation("RenamedLambda");
            //var annotated = container.WithAdditionalAnnotations(annot);
            //var root = project.GetDocument(docid).GetSyntaxRootAsync().Result.ReplaceNode(container, annotated).SyntaxTree;
            //var proj = project.GetDocument(docid).WithSyntaxRoot(root.GetRoot()).Project;
            //doc = proj.GetDocument(docid);
            //var syntaxTree = doc.GetSyntaxTreeAsync().Result;
            //var modifiedSemantic = proj.GetCompilationAsync().Result.GetSemanticModel(syntaxTree);
            //annotated = (AnonymousFunctionExpressionSyntax)doc.GetSyntaxRootAsync().Result.GetAnnotatedNodes(annot).First();
            //var parameter = GetLambdaParameter(annotated, 0);
            //var renamed = Renamer.RenameSymbolAsync(proj.Solution, modifiedSemantic.GetDeclaredSymbol(parameter), newname, null).Result;
            //annotated = (AnonymousFunctionExpressionSyntax)renamed.GetDocument(doc.Id).GetSyntaxRootAsync().Result.GetAnnotatedNodes(annot).First();
            //return annotated.WithoutAnnotations();
        }

        public string GetMethodFullName(InvocationExpressionSyntax invocation)
        {
            var n = (_data.Semantic.GetSymbolInfo(invocation.Expression).Symbol as IMethodSymbol)?.OriginalDefinition
                .ToDisplayString();
            const string iEnumerableOfTSource = "System.Collections.Generic.IEnumerable<TSource>";

            return n?.Replace("System.Collections.Generic.List<TSource>", iEnumerableOfTSource)
                .Replace("TSource[]", iEnumerableOfTSource);
        }
        
        public TypeSyntax GetLambdaType(SimpleLambdaExpressionSyntax lambda)
            => _data.Semantic.GetTypeFromExpression(lambda.ExpressionBody);

        public ITypeSymbol GetLambdaReturnType(AnonymousFunctionExpressionSyntax lambda)
            => ((INamedTypeSymbol) _data.Semantic.GetTypeInfo(lambda).ConvertedType).TypeArguments.Last();

        public string GetUniqueName(string v)
        {
            for (var i = 1;; i++)
            {
                var name = v + i;
                if (_data.MethodsToAddToCurrentType.Any(x => x.Item2.Identifier.ValueText == name)) continue;
                return name;
            }
        }
    }
}