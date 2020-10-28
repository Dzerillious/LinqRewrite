using System;
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

namespace LinqRewrite
{
	[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(LinqRewriteCodeFixProvider)), Shared]
	public class LinqRewriteCodeFixProvider : CodeFixProvider
	{
		private const string TitlePrefix = "Make procedural";

		public sealed override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create(LinqRewriteAnalyzer.DiagnosticId);

        public sealed override FixAllProvider GetFixAllProvider() => WellKnownFixAllProviders.BatchFixer;

        public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
		{
			var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);

            foreach (var diagnostic in context.Diagnostics)
            {
                var diagnosticSpan = diagnostic.Location.SourceSpan;
                var linqInvocation = (InvocationExpressionSyntax)root.FindNode(diagnosticSpan);

                var stepChain = GetInvocationStepChain(linqInvocation, out ExpressionSyntax lastExpression);
                var title = $"{TitlePrefix} {string.Join(".", stepChain)}";

                context.RegisterCodeFix(
                    CodeAction.Create(
                        title: title,
                        createChangedSolution: cancellation => MakeProcedural(context.Document, root, linqInvocation, cancellation),
                        equivalenceKey: title),
                    diagnostic);
            }
		}

		private async Task<Solution> MakeProcedural(Document document, SyntaxNode root, InvocationExpressionSyntax linqInvocation, CancellationToken cancellationToken)
		{
            try
            {
                var methodDeclaration = linqInvocation.FirstAncestorOrSelf<MethodDeclarationSyntax>();
                //root.InsertNodesAfter(methodDeclaration, ImmutableArray.Create(
                //    ))

                return document.WithSyntaxRoot(root).Project.Solution;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static ImmutableArray<LinqStep> GetInvocationStepChain(InvocationExpressionSyntax invocation, out ExpressionSyntax lastExpression)
        {
            var invocationChain = new List<LinqStep>();
            var currentExpression = invocation;
            lastExpression = invocation;
            while (true)
            {
                if (!IsSupportedMethod(currentExpression)) break;
                var arguments = currentExpression.ArgumentList.Arguments
                    .Select(argument => (ValueBridge) argument.Expression)
                    .ToImmutableArray();

                if (currentExpression.Expression is MemberAccessExpressionSyntax access)
                {
                    invocationChain.Insert(0, new LinqStep(GetMethodName(access.Name.ToString()), arguments, currentExpression));
                    lastExpression = access.Expression;
                    if (lastExpression is InvocationExpressionSyntax invocationExpressionSyntax)
                        currentExpression = invocationExpressionSyntax;
                    else break;
                }
                else if (currentExpression.Expression is MemberBindingExpressionSyntax binding)
                {
                    invocationChain.Insert(0, new LinqStep(GetMethodName(binding.Name.ToString()), arguments, currentExpression));
                    var conditional = (ConditionalAccessExpressionSyntax) invocation.Parent;
                    lastExpression = conditional.Expression;
                    break;
                }
                else break;
            }
            return invocationChain.ToImmutableArray();
        }

        private static ImmutableArray<VariableCapture> GetCaptures(InvocationExpressionSyntax invocation, SemanticModel semanticModel)
        {
            var flows = semanticModel.AnalyzeDataFlow(invocation);

            var flowsIn = flows.DataFlowsIn.Concat(invocation.DescendantNodesAndSelf()
                .Where(node => node is IdentifierNameSyntax)
                .Select(node => semanticModel.GetSymbolInfo(node).Symbol)
                .Where(symbol => symbol is IFieldSymbol))
                .ToImmutableArray();

            var changingParams = flows.DataFlowsOut
                .Concat(flows.WrittenInside)
                .ToImmutableHashSet();
            var captures = flowsIn
                .Union(flows.DataFlowsOut)
                .Where(symbol =>
                {
                    if (!(symbol is IParameterSymbol parameter)) return false;
                    return !parameter.IsThis && !parameter.IsStatic;
                })
                .Select(symbol => VariableExtensions.CreateVariableCapture(symbol, changingParams))
                .ToImmutableArray();

            return captures;
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
