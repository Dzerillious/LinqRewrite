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
        {
            var regex = new Regex("(.*\\.)?(.*?)(\\<.*\\>)?\\(.*");
            for (var i = 0; i < parameters.RewriteChain.Count; i++)
            {
                var step = parameters.RewriteChain[i];
                var match = regex.Match(step.MethodName);

                var last = match.Groups[1].Value.EndsWith(".")
                    ? match.Groups[2].Value : match.Groups[1].Value;
                RewritePart(last, parameters, i);
            }

            if (parameters.SimpleRewrite != null) return parameters.SimpleRewrite;
            if (!parameters.HasResultMethod)
                parameters.ForAdd(SyntaxFactory.YieldStatement(SyntaxKind.YieldReturnStatement, parameters.LastValue.Value));
            var body = parameters.GetMethodBody();

            if (parameters.NotRewrite) throw new NotSupportedException("Not good for rewrite");
            return parameters.FirstCollection == null 
                ? parameters.Rewrite.GetInvocationExpression(parameters, body) 
                : parameters.Rewrite.GetCollectionInvocationExpression(parameters, body);
        }

        private static void RewritePart(string last, RewriteParameters parameters, int i)
        {
            var args = parameters.RewriteChain[i].Arguments;
            switch (last)
            {
                case "All": RewriteAll.Rewrite(parameters, args); return;
                case "Any": RewriteAny.Rewrite(parameters, args); return;
                case "Contains": RewriteContains.Rewrite(parameters, args); return;
                case "Count": RewriteCount.Rewrite(parameters, args); return;
                case "LongCount": RewriteLongCount.Rewrite(parameters, args); return;

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
                case "Empty": RewriteEmpty.Rewrite(parameters, args,  parameters.RewriteChain[i].Invocation); return;
                
                case "Skip": RewriteSkip.Rewrite(parameters, args); return;
                case "SkipWhile": RewriteSkipWhile.Rewrite(parameters, args); return;
                case "Take": RewriteTake.Rewrite(parameters, args); return;
                case "TakeWhile": RewriteTakeWhile.Rewrite(parameters, args); return;
                
                case "Reverse": RewriteReverse.Rewrite(parameters, args); return;
                case "Select": RewriteSelect.Rewrite(parameters, args); return;
                case "SelectMany": RewriteSelectMany.Rewrite(parameters, args); return;
                case "Where": RewriteWhere.Rewrite(parameters, args); return;
                case "Cast": RewriteCast.Rewrite(parameters, args, parameters.RewriteChain[i].Invocation); return;
                case "OfType": RewriteOfType.Rewrite(parameters, args, parameters.RewriteChain[i].Invocation); return;
                
                case "Concat": RewriteConcat.Rewrite(parameters, args); return;
                case "Union": RewriteUnion.Rewrite(parameters, args); return;
                case "Intersect": RewriteIntersect.Rewrite(parameters, args); return;
                case "Except": RewriteExcept.Rewrite(parameters, args); return;
                case "Distinct": RewriteDistinct.Rewrite(parameters, args); return;
                
                case "SequenceEqual": RewriteSequenceEqual.Rewrite(parameters, args); return;
                case "Zip": RewriteZip.Rewrite(parameters, args); return;
                
                case "ToArray": RewriteToArray.Rewrite(parameters, args); return;
                case "ToList": RewriteToList.Rewrite(parameters, args); return;
                case "ToDictionary": RewriteToDictionary.Rewrite(parameters, args); return;
                case "ToLookup": RewriteToLookup.Rewrite(parameters, args); return;
                default: throw new NotImplementedException($"Rewrite of {last} not implemented");
            }
        }
    }
}