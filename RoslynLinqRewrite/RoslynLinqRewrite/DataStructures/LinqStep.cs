using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.DataStructures
{
    public class LinqStep
    {
        public bool IsGlobal { get; set; }
        public Lambda Lambda { get; set; }
        public string MethodName { get; }
        public ExpressionSyntax[] Arguments { get; }
        public InvocationExpressionSyntax Invocation { get; }
        
        public LinqStep(string methodName, ExpressionSyntax[] arguments, InvocationExpressionSyntax invocation = null, bool isGlobal = true)
        {
            MethodName = methodName;
            Arguments = arguments;
            Invocation = invocation;
            IsGlobal = isGlobal;
        }
            
        public override string ToString() => MethodName;
    }
}
