using System;
using System.Linq;
using System.Text.RegularExpressions;
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
                case "Count": return RewriteCount.RewriteSimple(parameters);
                case "First": return RewriteFirst.RewriteSimple(parameters);
                case "FirstOrDefault": return RewriteFirstOrDefault.RewriteSimple(parameters);
                case "Last": return RewriteLast.RewriteSimple(parameters);
                case "LastOrDefault": return RewriteLastOrDefault.RewriteSimple(parameters);
                case "Single": return RewriteSingle.RewriteSimple(parameters);
                case "SingleOrDefault": return RewriteSingleOrDefault.RewriteSimple(parameters);
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
                switch (last)
                {
                    case "All": RewriteAll.Rewrite(parameters, i); continue;
                    case "Any": RewriteAny.Rewrite(parameters, i); continue;
                    case "Count": RewriteCount.Rewrite(parameters, i); continue;
                    case "First": RewriteFirst.Rewrite(parameters, i); continue;
                    case "FirstOrDefault": RewriteFirstOrDefault.Rewrite(parameters, i); continue;
                    case "ForEach": RewriteForEach.Rewrite(parameters, i); continue;
                    case "Last": RewriteLast.Rewrite(parameters, i); continue;
                    case "LastOrDefault": RewriteLastOrDefault.Rewrite(parameters, i); continue;
                    case "Range": RewriteRange.Rewrite(parameters, i); continue;
                    case "Repeat": RewriteRepeat.Rewrite(parameters, i); continue;
                    case "Reverse": RewriteReverse.Rewrite(parameters, i); continue;
                    case "Select": RewriteSelect.Rewrite(parameters, i); continue;
                    case "Single": RewriteSingle.Rewrite(parameters, i); continue;
                    case "SingleOrDefault": RewriteSingleOrDefault.Rewrite(parameters, i); continue;
                    case "Skip": RewriteSkip.Rewrite(parameters, i); continue;
                    case "Take": RewriteTake.Rewrite(parameters, i); continue;
                    case "Sum": RewriteSum.Rewrite(parameters, i); continue;
                    case "ToArray": RewriteToArray.Rewrite(parameters, i); continue;
                    case "ToList": RewriteToList.Rewrite(parameters, i); continue;
                    case "Where": RewriteWhere.Rewrite(parameters, i); continue;
                }
            }
            var body = parameters.GetMethodBody();

            if (parameters.Collection == null) return parameters.Rewrite.GetInvocationExpression(parameters, body);
            return parameters.Rewrite.GetCollectionInvocationExpression(parameters, body);
        }
    }
}