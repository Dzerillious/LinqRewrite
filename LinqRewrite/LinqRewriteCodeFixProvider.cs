using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Rename;

namespace LinqRewrite
{
	[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(LinqRewriteCodeFixProvider)), Shared]
	public class LinqRewriteCodeFixProvider : CodeFixProvider
	{
		private const string title = "Make uppercase";

		public sealed override ImmutableArray<string> FixableDiagnosticIds
		{
			get { return ImmutableArray.Create(LinqRewriteAnalyzer.DiagnosticId); }
		}

		public sealed override FixAllProvider GetFixAllProvider()
		{
			// See https://github.com/dotnet/roslyn/blob/master/docs/analyzers/FixAllProvider.md for more information on Fix All Providers
			return WellKnownFixAllProviders.BatchFixer;
		}

		public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
		{
			var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);

			// TODO: Replace the following code with your own analysis, generating a CodeAction for each fix to suggest
			var diagnostic = context.Diagnostics.First();
			var diagnosticSpan = diagnostic.Location.SourceSpan;

			// Find the type declaration identified by the diagnostic.
			var declaration = root.FindToken(diagnosticSpan.Start).Parent.AncestorsAndSelf().OfType<TypeDeclarationSyntax>().First();

			// Register a code action that will invoke the fix.
			context.RegisterCodeFix(
				CodeAction.Create(
					title: title,
					createChangedSolution: c => MakeUppercaseAsync(context.Document, declaration, c),
					equivalenceKey: title),
				diagnostic);
		}

		private async Task<Solution> MakeUppercaseAsync(Document document, TypeDeclarationSyntax typeDecl, CancellationToken cancellationToken)
		{
			// Compute new uppercase name.
			var identifierToken = typeDecl.Identifier;
			var newName = identifierToken.Text.ToUpperInvariant();

			// Get the symbol representing the type to be renamed.
			var semanticModel = await document.GetSemanticModelAsync(cancellationToken);
			var typeSymbol = semanticModel.GetDeclaredSymbol(typeDecl, cancellationToken);

			// Produce a new solution that has all references to that type renamed, including the declaration.
			var originalSolution = document.Project.Solution;
			var optionSet = originalSolution.Workspace.Options;
			var newSolution = await Renamer.RenameSymbolAsync(document.Project.Solution, typeSymbol, newName, optionSet, cancellationToken).ConfigureAwait(false);

			// Return the new solution with the now-uppercase type name.
			return newSolution;
        }

        private static List<LinqStep> GetInvocationStepChain(InvocationExpressionSyntax node, out ExpressionSyntax lastNode)
        {
            var chain = new List<LinqStep>();
            var invocationExpression = node;
            lastNode = node;
            while (true)
            {
                if (!IsSupportedMethod(invocationExpression)) break;
                var arguments = invocationExpression.ArgumentList.Arguments
                    .Select(argument => (ValueBridge)argument.Expression)
                    .ToImmutableArray();

                if (invocationExpression.Expression is MemberAccessExpressionSyntax access)
                {
                    chain.Insert(0, new LinqStep(GetMethodName(access.Name.ToString()), arguments, invocationExpression));
                    lastNode = access.Expression;
                    if (lastNode is InvocationExpressionSyntax invocation)
                        invocationExpression = invocation;
                    else break;
                }
                else if (invocationExpression.Expression is MemberBindingExpressionSyntax binding)
                {
                    chain.Insert(0, new LinqStep(GetMethodName(binding.Name.ToString()), arguments, invocationExpression));
                    var conditional = (ConditionalAccessExpressionSyntax)node.Parent;
                    lastNode = conditional.Expression;
                    break;
                }
                else break;
            }
            return chain;
        }

        private static (bool, ExpressionSyntax) CheckIfRewriteInvocation(InvocationExpressionSyntax invocation, SemanticModel semanticModel)
        {
            var typeInfo = semanticModel.GetTypeInfo(invocation);
            var flows = semanticModel.AnalyzeDataFlow(invocation);

            var flowsIn = flows.DataFlowsIn.Concat(invocation.DescendantNodesAndSelf()
                .Where(node => node is IdentifierNameSyntax)
                .Select(node => semanticModel.GetSymbolInfo(node).Symbol)
                .Where(symbol => symbol is IFieldSymbol)).ToArray();

            var changingParams = flows.DataFlowsOut
                .Concat(flows.WrittenInside)
                .ToImmutableHashSet();
            var currentFlow = flowsIn
                .Union(flows.DataFlowsOut)
                .Where(symbol =>
                {
                    if (!(symbol is IParameterSymbol parameter)) return false;
                    return !parameter.IsThis && !parameter.IsStatic;
                })
                .Select(symbol => VariableExtensions.CreateVariableCapture(symbol, changingParams))
                .ToArray();

            if (Extensions.SyntaxExtensions.IsAnonymousType(typeInfo.Type)) return (false, null);
            var returnType = typeInfo.Type;
            if (Extensions.SyntaxExtensions.IsAnonymousType(returnType) ||
                currentFlow.Any(x => Extensions.SyntaxExtensions.IsAnonymousType(SymbolExtensions.GetType(x.Symbol))))
                return (false, null);

            return (true, invocation);
        }

        private static bool IsSupportedMethod(InvocationExpressionSyntax invocation)
            => invocation.Expression switch
            {
                MemberAccessExpressionSyntax access => Constants.RewritableMethods.Contains(GetMethodName(access.Name.ToString())),
                MemberBindingExpressionSyntax binding => Constants.RewritableMethods.Contains(GetMethodName(binding.Name.ToString())),
                _ => false
            };

        private static string GetMethodName(string name)
        {
            int index = name.IndexOf('<');
            return index == -1 ? name : name.Substring(0, index);
        }
    }
}
