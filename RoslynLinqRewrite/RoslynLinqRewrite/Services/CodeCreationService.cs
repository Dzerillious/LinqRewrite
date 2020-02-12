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
            if (collectionType is IArrayTypeSymbol) return SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, SyntaxFactory.IdentifierName(Constants.ItemsName), SyntaxFactory.IdentifierName("Length"));
            if (collectionType.ToDisplayString().StartsWith("System.Collections.Generic.IReadOnlyCollection<") || collectionType.AllInterfaces.Any(x => x.ToDisplayString().StartsWith("System.Collections.Generic.IReadOnlyCollection<")))
                return SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, SyntaxFactory.IdentifierName(Constants.ItemsName), SyntaxFactory.IdentifierName("Count"));
                
            if (collectionType.ToDisplayString().StartsWith("System.Collections.Generic.ICollection<") || collectionType.AllInterfaces.Any(x => x.ToDisplayString().StartsWith("System.Collections.Generic.ICollection<")))
                return SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, SyntaxFactory.IdentifierName(Constants.ItemsName), SyntaxFactory.IdentifierName("Count"));

            if (!allowUnknown) return null;
            if (collectionType.IsValueType) return null;
            var itemType = SymbolExtensions.GetItemType(collectionType);
            if (itemType == null) return null;
            
            return SyntaxFactory.InvocationExpression(
                SyntaxFactory.MemberAccessExpression(
                    SyntaxKind.SimpleMemberAccessExpression,
                    SyntaxFactory.ParenthesizedExpression(
                        SyntaxFactory.ConditionalAccessExpression(
                            SyntaxFactory.ParenthesizedExpression(
                                SyntaxFactory.BinaryExpression(
                                    SyntaxKind.AsExpression,
                                    SyntaxFactory.IdentifierName(Constants.ItemsName),
                                    SyntaxFactory.ParseTypeName($"System.Collections.Generic.ICollection<{itemType.ToDisplayString()}>")
                                )
                            ),
                            SyntaxFactory.MemberBindingExpression(SyntaxFactory.IdentifierName("Count"))
                        )
                    ),
                    SyntaxFactory.IdentifierName("GetValueOrDefault")
                )
            );
        }

        public ExpressionSyntax CreateMethodNameSyntaxWithCurrentTypeParameters(string fn)
            => (_data.CurrentMethodTypeParameters?.Parameters.Count).GetValueOrDefault() != 0
                ? SyntaxFactory.GenericName(
                    SyntaxFactory.Identifier(fn),
                    SyntaxFactory.TypeArgumentList(
                        SyntaxFactoryHelper.CreateSeparatedList(_data.CurrentMethodTypeParameters.Parameters
                            .Select(x => SyntaxFactory.ParseTypeName(x.Identifier.ValueText)))))
                : (NameSyntax) SyntaxFactory.IdentifierName(fn);

        public ExpressionSyntax InlineOrCreateMethod(Lambda lambda, TypeSyntax returnType, ParameterSyntax param)
        {
            var p = SymbolExtensions.GetLambdaParameter(lambda, 0).Identifier.ValueText;
            //var lambdaParameter = semantic.GetDeclaredSymbol(p);
            var currentFlow = _data.Semantic.AnalyzeDataFlow(lambda.Body);
            var currentCaptures = currentFlow
                .DataFlowsOut
                .Union(currentFlow.DataFlowsIn)
                .Where(x => x.Name != p && (x as IParameterSymbol)?.IsThis != true)
                .Select(x => VariableExtensions.CreateVariableCapture(x, currentFlow.DataFlowsOut))
                .ToList();

            lambda = RenameSymbol(lambda, 0, param.Identifier.ValueText);
            return InlineOrCreateMethod(lambda.Body, returnType, param, currentCaptures);
        }

        public ExpressionSyntax InlineOrCreateMethod(CSharpSyntaxNode body, TypeSyntax returnType,
            ParameterSyntax param, IEnumerable<VariableCapture> captures)
        {
            var fn = GetUniqueName($"{_data.CurrentMethodName}_ProceduralLinqHelper");
            if (body is ExpressionSyntax syntax) return syntax;

            if (captures.Any(x => SyntaxExtensions.IsAnonymousType(SymbolExtensions.GetSymbolType(x.Symbol)))) 
                throw new NotSupportedException();
            if (returnType == null) throw new NotSupportedException(); // Anonymous type
            
            var method = SyntaxFactory.MethodDeclaration(returnType, fn)
                .WithParameterList(SyntaxFactory.ParameterList(SyntaxFactory.SeparatedList(
                    new[] { param }
                        .Union(captures.Select(x => SyntaxFactoryHelper.CreateParameter(x.Name, SymbolExtensions.GetSymbolType(x))
                        .WithRef(x.Changes)))
                )))
                .WithBody(body as BlockSyntax ?? (body is StatementSyntax statementSyntax
                              ? SyntaxFactory.Block(statementSyntax)
                              : SyntaxFactory.Block(SyntaxFactory.ReturnStatement((ExpressionSyntax) body))))
                .WithStatic(_data.CurrentMethodIsStatic)
                .WithTypeParameterList(_data.CurrentMethodTypeParameters)
                .WithConstraintClauses(_data.CurrentMethodConstraintClauses)
                .NormalizeWhitespace();

            _data.MethodsToAddToCurrentType.Add(Tuple.Create(_data.CurrentType, method));
            return SyntaxFactory.InvocationExpression(
                CreateMethodNameSyntaxWithCurrentTypeParameters(fn),
                SyntaxFactoryHelper.CreateArguments(new[] { SyntaxFactory.Argument(SyntaxFactory.IdentifierName(param.Identifier.ValueText))}
                    .Union(captures.Select(x =>  SyntaxFactory.Argument(SyntaxFactory.IdentifierName(x.Name)).WithRef(x.Changes)))));
        }

        private Lambda RenameSymbol(Lambda container, int argIndex, string newname)
        {
            var oldParameter = SymbolExtensions.GetLambdaParameter(container, argIndex).Identifier.ValueText;
            //var oldsymbol = semantic.GetDeclaredSymbol(oldparameter);
            var tokensToRename = container.Body.DescendantNodesAndSelf()
                .Where(x =>
            {
                var sem = _data.Semantic.GetSymbolInfo(x).Symbol;
                return sem != null && (sem is ILocalSymbol || sem is IParameterSymbol) && sem.Name == oldParameter;
                //  if (sem.Symbol == oldsymbol) return true;
            });
            var syntax = SyntaxFactory.ParenthesizedLambdaExpression(
                SyntaxFactoryHelper.CreateParameters(container.Parameters
                    .Select((x, i) =>  i == argIndex ? SyntaxFactory.Parameter(SyntaxFactory.Identifier(newname)).WithType(x.Type) : x)),
                container.Body.ReplaceNodes(tokensToRename, (a, b) =>
                {
                    if (b is IdentifierNameSyntax ide) return ide.WithIdentifier(SyntaxFactory.Identifier(newname));
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