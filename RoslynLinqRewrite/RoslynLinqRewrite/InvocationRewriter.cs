using System;
using System.Text.RegularExpressions;
using LinqRewrite.DataStructures;
using LinqRewrite.RewriteRules;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite
{
    public static class InvocationRewriter
    {
        public static ExpressionSyntax TryRewrite(RewriteParameters parameters) 
            => parameters.Chain.Count == 1 
                ? SimpleRewrite(parameters) ?? CompositeRewrite(parameters)
                : CompositeRewrite(parameters);

        private static ExpressionSyntax SimpleRewrite(RewriteParameters parameters)
        {
            var regex = new Regex("(.*\\.)?(.*?)(\\<.*\\>)?\\(.*");
            var step = parameters.Chain[0];
            var match = regex.Match(step.MethodName);

            var last = match.Groups[1].Value.EndsWith(".")
                ? match.Groups[2].Value : match.Groups[1].Value;
            
            var args = parameters.Chain[0].Arguments;
            switch (last)
            {
                case "Any": return RewriteAny.RewriteSimple(parameters, args);
                case "Count": return RewriteCount.RewriteSimple(parameters, args);
                case "First": return RewriteFirst.RewriteSimple(parameters, args);
                case "FirstOrDefault": return RewriteFirstOrDefault.RewriteSimple(parameters, args);
                case "Last": return RewriteLast.RewriteSimple(parameters, args);
                case "LastOrDefault": return RewriteLastOrDefault.RewriteSimple(parameters, args);
                case "Single": return RewriteSingle.RewriteSimple(parameters, args);
                case "SingleOrDefault": return RewriteSingleOrDefault.RewriteSimple(parameters, args);
                case "ElementAt": return RewriteElementAt.RewriteSimple(parameters, args);
                case "ElementAtOrDefault": return RewriteElementAtOrDefault.RewriteSimple(parameters, args);
                default: return null;
            }
        }

        private static ExpressionSyntax CompositeRewrite(RewriteParameters parameters)
        {
            var regex = new Regex("(.*\\.)?(.*?)(\\<.*\\>)?\\(.*");
            for (var i = 0; i < parameters.Chain.Count; i++)
            {
                var step = parameters.Chain[i];
                var match = regex.Match(step.MethodName);

                var last = match.Groups[1].Value.EndsWith(".")
                    ? match.Groups[2].Value : match.Groups[1].Value;
                RewritePart(last, parameters, i);
            }

            if (!parameters.HasResultMethod)
                parameters.ForAdd(SyntaxFactory.YieldStatement(SyntaxKind.YieldReturnStatement, parameters.Last.Value));
            var body = parameters.GetMethodBody();

            if (parameters.NotRewrite) throw new NotSupportedException("Not good for rewrite");
            return parameters.FirstCollection == null 
                ? parameters.Rewrite.GetInvocationExpression(parameters, body) 
                : parameters.Rewrite.GetCollectionInvocationExpression(parameters, body);
        }

        private static void RewritePart(string last, RewriteParameters parameters, int i)
        {
            var args = parameters.Chain[i].Arguments;
            switch (last)
            {
                case "All": RewriteAll.Rewrite(parameters, args); return;
                case "Any": RewriteAny.Rewrite(parameters, args); return;
                case "Contains": RewriteContains.Rewrite(parameters, args); return;
                case "Count": RewriteCount.Rewrite(parameters, args); return;

                case "Min": RewriteMin.Rewrite(parameters, args); return;
                case "Max": RewriteMax.Rewrite(parameters, args); return;
                case "Average": RewriteAverage.Rewrite(parameters, args); return;
                case "Aggregate": RewriteAggregate.Rewrite(parameters, args); return;
                case "Sum": RewriteSum.Rewrite(parameters, args); return;
                
                case "ForEach": RewriteForEach.Rewrite(parameters, args); return;
                
                case "First": RewriteFirst.Rewrite(parameters, args); return;
                case "FirstOrDefault": RewriteFirstOrDefault.Rewrite(parameters, args); return;
                case "Last": RewriteLast.Rewrite(parameters, args); return;
                case "LastOrDefault": RewriteLastOrDefault.Rewrite(parameters, args); return;
                case "Single": RewriteSingle.Rewrite(parameters, args); return;
                case "SingleOrDefault": RewriteSingleOrDefault.Rewrite(parameters, args); return;
                case "ElementAt": RewriteElementAt.Rewrite(parameters, args); return;
                case "ElementAtOrDefault": RewriteElementAtOrDefault.Rewrite(parameters, args); return;
                
                case "Range": RewriteRange.Rewrite(parameters, args); return;
                case "Repeat": RewriteRepeat.Rewrite(parameters, args); return;
                
                case "Skip": RewriteSkip.Rewrite(parameters, args); return;
                case "SkipWhile": RewriteSkipWhile.Rewrite(parameters, args); return;
                case "Take": RewriteTake.Rewrite(parameters, args); return;
                case "TakeWhile": RewriteTakeWhile.Rewrite(parameters, args); return;
                
                case "Reverse": RewriteReverse.Rewrite(parameters, args); return;
                case "Select": RewriteSelect.Rewrite(parameters, args); return;
                case "Where": RewriteWhere.Rewrite(parameters, args); return;
                case "Cast": RewriteCast.Rewrite(parameters, args, parameters.Chain[i].Invocation); return;
                case "OfType": RewriteOfType.Rewrite(parameters, args, parameters.Chain[i].Invocation); return;
                
                case "Concat": RewriteConcat.Rewrite(parameters, args); return;
                
                case "ToArray": RewriteToArray.Rewrite(parameters, args); return;
                case "ToList": RewriteToList.Rewrite(parameters, args); return;
                default: throw new NotImplementedException($"Rewrite of {last} not implemented");
            }
        }
    }
}