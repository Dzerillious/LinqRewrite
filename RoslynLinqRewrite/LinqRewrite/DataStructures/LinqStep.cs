using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.DataStructures
{
    public class LinqStep
    {
        public Lambda Lambda { get; set; }
        public string MethodName { get; }
        public RewrittenValueBridge[] Arguments { get; }
        public InvocationExpressionSyntax Invocation { get; }
        
        public LinqStep(string methodName, RewrittenValueBridge[] arguments, InvocationExpressionSyntax invocation = null)
        {
            MethodName = methodName;
            Arguments = arguments;
            Invocation = invocation;
        }
            
        public override string ToString() => MethodName;
    }
}
