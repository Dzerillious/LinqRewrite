using System.Collections.Immutable;
using System.Runtime.InteropServices.ComTypes;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.DataStructures
{
    public class RewriteInfo
    {
        public SemanticModel Semantic { get; }

        public ExpressionSyntax Source { get; }
        public ITypeSymbol SourceTypeSymbol { get; }

        public InvocationExpressionSyntax LinqExpression { get; }
        public TypeSyntax ReturnType { get; }

        public ImmutableArray<LinqStep> LinqChain { get; }
        public ImmutableArray<VariableCapture> Captures { get; }

        public RewriteInfo(SemanticModel semantic, 
            ExpressionSyntax source, 
            InvocationExpressionSyntax linqExpression,
            ImmutableArray<LinqStep> linqChain,
            ImmutableArray<VariableCapture> captures)
        {
            Semantic = semantic;

            Source = source;
            SourceTypeSymbol = semantic.GetTypeInfo(source).Type;

            LinqExpression = linqExpression;
            ReturnType = semantic.GetTypeFromExpression(linqExpression);

            LinqChain = linqChain;
            Captures = captures;
        }
    }
}