using System;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace LinqRewrite
{
	[DiagnosticAnalyzer(LanguageNames.CSharp)]
	public class LinqRewriteAnalyzer : DiagnosticAnalyzer
	{
		public const string DiagnosticId = "LinqRewrite";
        private const string Category = "Optimization";

        private static readonly LocalizableString Title = new LocalizableResourceString(nameof(Resources.AnalyzerTitle), Resources.ResourceManager, typeof(Resources));
		private static readonly LocalizableString MessageFormat = new LocalizableResourceString(nameof(Resources.AnalyzerMessageFormat), Resources.ResourceManager, typeof(Resources));
		private static readonly LocalizableString Description = new LocalizableResourceString(nameof(Resources.AnalyzerDescription), Resources.ResourceManager, typeof(Resources));
		
		private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Info, isEnabledByDefault: true, description: Description);

		public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

        public override void Initialize(AnalysisContext context)
		{
			context.RegisterSyntaxNodeAction(AnalyzeLinq, SyntaxKind.InvocationExpression);
		}

		private static void AnalyzeLinq(SyntaxNodeAnalysisContext context)
		{
			var expression = (InvocationExpressionSyntax)context.Node;
            var semanticModel = context.SemanticModel;
			var typeInfo = semanticModel.GetTypeInfo(expression);
			if (typeInfo.Type is INamedTypeSymbol type 
                && type.Name.Equals("IEnumerable", StringComparison.Ordinal))
            {
                if (!IsSupportedMethod(expression)) return;
                context.ReportDiagnostic(Diagnostic.Create(Rule, expression.GetLocation(), type.TypeArguments[0].Name));
			}
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
