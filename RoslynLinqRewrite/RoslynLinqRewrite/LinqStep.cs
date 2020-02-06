using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;

namespace Shaman.Roslyn.LinqRewrite
{
    class LinqStep
    {
        public Lambda Lambda { get; set; }

        public LinqStep(string methodName, IReadOnlyList<ExpressionSyntax> arguments, InvocationExpressionSyntax invocation = null)
        {
            MethodName = methodName;
            Arguments = arguments;
            Invocation = invocation;
        }
        public string MethodName { get; }
        public IReadOnlyList<ExpressionSyntax> Arguments { get; }
        public InvocationExpressionSyntax Invocation { get; }
        public override string ToString() => MethodName;
    }
}
