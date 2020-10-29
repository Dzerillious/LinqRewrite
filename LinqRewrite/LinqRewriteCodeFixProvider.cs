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
                var invocation = (InvocationExpressionSyntax)root.FindNode(diagnosticSpan);

Minor                var stepChain = GetInvocationStepChain(invocation);
                var title = $"{TitlePrefix} {string.Join(".", stepChain)}";

                context.RegisterCodeFix(
                    CodeAction.Create(
                        title: title,
                        createChangedSolution: cancellation => MakeProcedural(context.Document, root, null, invocation, stepChain, cancellation),
                        equivalenceKey: title),
                    diagnostic);
            }
		}

		private async Task<Solution> MakeProcedural(Document document, SyntaxNode root, ExpressionSyntax sourceCollection, 
            InvocationExpressionSyntax linqExpression, ImmutableArray<LinqStep> linqChain, CancellationToken cancellationToken)
		{
            try
            {
                var semanticModel = await document.GetSemanticModelAsync(cancellationToken);
                var methodDeclaration = linqExpression.FirstAncestorOrSelf<MethodDeclarationSyntax>();

                var rewriteInfo = new RewriteInfo(
                    semantic: semanticModel,
                    source: sourceCollection,
                    linqExpression: linqExpression,
                    linqChain: linqChain,
                    captures: GetCaptures(linqExpression, semanticModel));

                InvocationRewriter.TryRewrite(rewriteInfo);

                return document.WithSyntaxRoot(root).Project.Solution;
            }
            catch (Exception e)
            {
                return document.Project.Solution;
            }
        }

        private static ImmutableArray<LinqStep> GetInvocationStepChain(InvocationExpressionSyntax invocationExpression)
        {
            var invocationChain = new List<LinqStep>();
            ExpressionSyntax lastExpression = invocationExpression.Expression;
            InvocationExpressionSyntax lastInvocation = invocationExpression;
            ImmutableArray<ValueBridge> lastArguments = invocationExpression.ArgumentList.Arguments
                .Select(argument => (ValueBridge)argument.Expression)
                .ToImmutableArray();

            while (true)
            {
                if (lastExpression is InvocationExpressionSyntax invocation)
                {
                    if (!IsSupportedMethod(invocation)) break;
                    lastArguments = invocation.ArgumentList.Arguments
                        .Select(argument => (ValueBridge)argument.Expression)
                        .ToImmutableArray();

                    lastInvocation = invocation;
                }
                else if (lastExpression is MemberAccessExpressionSyntax access)
                {
                    invocationChain.Add(new LinqStep(GetMethodName(access.Name.ToString()), lastArguments, lastInvocation));
                }
                else if (lastExpression is MemberBindingExpressionSyntax binding)
                {
                    invocationChain.Add(new LinqStep(GetMethodName(binding.Name.ToString()), lastArguments, lastInvocation));
                }
                else break;

                if (lastExpression.Parent is ExpressionSyntax bindingExpression)
                    lastExpression = bindingExpression;
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
