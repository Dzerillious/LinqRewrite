using System;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using Shaman.Roslyn.LinqRewrite.RewriteRules;

namespace Shaman.Roslyn.LinqRewrite
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
            switch (last)
            {
                case "Any": return RewriteAny.RewriteSimple(parameters);
                case "Count": return RewriteCount.RewriteSimple(parameters);
                case "First": return RewriteFirst.RewriteSimple(parameters);
                case "FirstOrDefault": return RewriteFirstOrDefault.RewriteSimple(parameters);
                case "Last": return RewriteLast.RewriteSimple(parameters);
                case "LastOrDefault": return RewriteLastOrDefault.RewriteSimple(parameters);
                case "Single": return RewriteSingle.RewriteSimple(parameters);
                case "SingleOrDefault": return RewriteSingleOrDefault.RewriteSimple(parameters);
                case "ElementAt": return RewriteElementAt.RewriteSimple(parameters);
                case "ElementAtOrDefault": return RewriteElementAtOrDefault.RewriteSimple(parameters);
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
            {
                parameters.ForAdd(SyntaxFactory.YieldStatement(SyntaxKind.YieldReturnStatement, parameters.LastItem));
                parameters.PostForAdd(SyntaxFactory.YieldStatement(SyntaxKind.YieldBreakStatement));
            }
            var body = parameters.GetMethodBody();

            return parameters.Collection == null 
                ? parameters.Rewrite.GetInvocationExpression(parameters, body) 
                : parameters.Rewrite.GetCollectionInvocationExpression(parameters, body);
        }

        private static void RewritePart(string last, RewriteParameters parameters, int i)
        {
            switch (last)
            {
                case "All": RewriteAll.Rewrite(parameters, i); return;
                case "Any": RewriteAny.Rewrite(parameters, i); return;
                case "Contains": RewriteContains.Rewrite(parameters, i); return;
                case "Count": RewriteCount.Rewrite(parameters, i); return;

                case "Min": RewriteMin.Rewrite(parameters, i); return;
                case "Max": RewriteMax.Rewrite(parameters, i); return;
                case "Average": RewriteAverage.Rewrite(parameters, i); return;
                case "Aggregate": RewriteAggregate.Rewrite(parameters, i); return;
                case "Sum": RewriteSum.Rewrite(parameters, i); return;
                
                case "ForEach": RewriteForEach.Rewrite(parameters, i); return;
                
                case "First": RewriteFirst.Rewrite(parameters, i); return;
                case "FirstOrDefault": RewriteFirstOrDefault.Rewrite(parameters, i); return;
                case "Last": RewriteLast.Rewrite(parameters, i); return;
                case "LastOrDefault": RewriteLastOrDefault.Rewrite(parameters, i); return;
                case "Single": RewriteSingle.Rewrite(parameters, i); return;
                case "SingleOrDefault": RewriteSingleOrDefault.Rewrite(parameters, i); return;
                case "ElementAt": RewriteElementAt.Rewrite(parameters, i); return;
                case "ElementAtOrDefault": RewriteElementAtOrDefault.Rewrite(parameters, i); return;
                
                case "Range": RewriteRange.Rewrite(parameters, i); return;
                case "Repeat": RewriteRepeat.Rewrite(parameters, i); return;
                
                case "Skip": RewriteSkip.Rewrite(parameters, i); return;
                case "SkipWhile": RewriteSkipWhile.Rewrite(parameters, i); return;
                case "Take": RewriteTake.Rewrite(parameters, i); return;
                case "TakeWhile": RewriteTakeWhile.Rewrite(parameters, i); return;
                
                case "Reverse": RewriteReverse.Rewrite(parameters, i); return;
                case "Select": RewriteSelect.Rewrite(parameters, i); return;
                case "Where": RewriteWhere.Rewrite(parameters, i); return;
                case "Cast": RewriteCast.Rewrite(parameters, i); return;
                case "OfType": RewriteOfType.Rewrite(parameters, i); return;
                
                case "ToArray": RewriteToArray.Rewrite(parameters, i); return;
                case "ToList": RewriteToList.Rewrite(parameters, i); return;
                default: throw new NotImplementedException($"Rewrite of {last} not implemented");
            }
        }
    }
}