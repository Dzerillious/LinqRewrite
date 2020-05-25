using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.DataStructures
{
    public class Lambda
    {
        public CSharpSyntaxNode Body { get; }
        public IReadOnlyList<ParameterSyntax> Parameters { get; }
        public AnonymousFunctionExpressionSyntax Syntax { get; }

        public Lambda(AnonymousFunctionExpressionSyntax lambda)
        {
            Body = lambda.Body;
            Syntax = lambda;
            Parameters = lambda switch
            {
                ParenthesizedLambdaExpressionSyntax syntax => syntax.ParameterList.Parameters,
                AnonymousMethodExpressionSyntax expressionSyntax => expressionSyntax.ParameterList.Parameters,
                SimpleLambdaExpressionSyntax lambdaExpressionSyntax => new[] {lambdaExpressionSyntax.Parameter},
                _ => Parameters
            };
        }

        public Lambda(CSharpSyntaxNode statement, ParameterSyntax[] parameters)
        {
            Body = statement;
            Parameters = parameters;
        }
    }
}
