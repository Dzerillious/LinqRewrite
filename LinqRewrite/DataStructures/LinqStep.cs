// Forked and modified from https://github.com/antiufo/roslyn-linq-rewrite/tree/master/RoslynLinqRewrite

using System.Collections.Immutable;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.DataStructures
{
    public class LinqStep
    {
        public string MethodName { get; }
        public ImmutableArray<ValueBridge> Arguments { get; }
        public InvocationExpressionSyntax Invocation { get; }
        
        public LinqStep(string methodName, ImmutableArray<ValueBridge> arguments, InvocationExpressionSyntax invocation = null)
        {
            MethodName = methodName;
            Arguments = arguments;
            Invocation = invocation;
        }
            
        public override string ToString() => MethodName;
    }
}
