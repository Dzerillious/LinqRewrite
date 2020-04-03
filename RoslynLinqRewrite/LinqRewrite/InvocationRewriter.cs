using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using LinqRewrite.RewriteRules;
using LinqRewrite.SimpleRewriteRules;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite
{
    public static class InvocationRewriter
    {
        public static ExpressionSyntax TryRewrite(RewriteParameters parameters) 
        {
            var regex = new Regex("(.*\\.)?(.*?)(\\<.*\\>)?\\(.*");
            var names = parameters.RewriteChain.Select(x =>
            {
                var match = regex.Match(x.MethodName);
                return match.Groups[1].Value.EndsWith(".")
                    ? match.Groups[2].Value : match.Groups[1].Value;
            }).ToArray();
            
            parameters.HasResultMethod = GetHasResultMethod(names);
            if (!TryRewriteSimple(parameters, names)) RewriteComposite(parameters, names);
            
            if (parameters.Data.CurrentMethodIsConditional && parameters.ReturnType.Type.ToString() == "void")
                parameters.InitialAdd(If(parameters.CurrentCollection.IsEqual(null), ReturnStatement()));

            if (parameters.SimpleRewrite != null) return parameters.SimpleRewrite;
            if (!parameters.HasResultMethod) parameters.ForAdd(YieldStatement(SyntaxKind.YieldReturnStatement, parameters.LastValue));
            var body = parameters.GetMethodBody();

            if (parameters.NotRewrite) throw new NotSupportedException("Not good for rewrite");

            if (parameters.Data.CurrentMethodIsConditional && parameters.ReturnType.Type.ToString() != "void")
                return ConditionalExpression(parameters.CurrentCollection.IsEqual(null),
                Default(parameters.ReturnType), parameters.Rewrite.GetMethodInvocationExpression(parameters, body));
            else return parameters.Rewrite.GetMethodInvocationExpression(parameters, body);
        }

        private static bool GetHasResultMethod(string[] names)
            => names.Last() switch
            {
                "Aggregate" => true,
                "All" => true,
                "Any" => true,
                "Average" => true,
                "Contains" => true,
                "Count" => true,
                "ElementAt" => true,
                "ElementAtOrDefault" => true,
                "First" => true,
                "FirstOrDefault" => true,
                "ForEach" => true,
                "Last" => true,
                "LastOrDefault" => true,
                "LongCount" => true,
                "Max" => true,
                "Min" => true,
                "SequenceEqual" => true,
                "Single" => true,
                "SingleOrDefault" => true,
                "Sum" => true,
                "ToArray" => true,
                "ToDictionary" => true,
                "ToList" => true,
                "ToLookup" => true,
                "ToSimpleList" => true,
                _ => false
            };

        private static void RewriteComposite(RewriteParameters parameters, string[] names)
        {
            for (var i = 0; i < names.Length; i++)
                RewritePart(names[i], parameters, i);
        }

        private static bool TryRewriteSimple(RewriteParameters parameters, string[] names)
        {
            if (MatchNames(names, "Range", "Sum")) return RangeSumRewrite.Rewrite(parameters);
            else if (MatchNames(names, "Select", "First")) return SelectFirstRewrite.Rewrite(parameters);
            return false;
        }

        private static bool MatchNames(IEnumerable<string> names, params string[] paramNames)
            => names.SequenceEqual(paramNames);

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
                
                case "Join": RewriteJoin.Rewrite(parameters, args); return;
                case "GroupBy": RewriteGroupBy.Rewrite(parameters, args); return;
                case "GroupJoin": RewriteGroupJoin.Rewrite(parameters, args); return;
                
                case "ToArray": RewriteToArray.Rewrite(parameters, args); return;
                case "ToList": RewriteToList.Rewrite(parameters, args); return;
                case "ToSimpleList": RewriteToSimpleList.Rewrite(parameters, args); return;
                case "ToDictionary": RewriteToDictionary.Rewrite(parameters, args); return;
                case "ToLookup": RewriteToLookup.Rewrite(parameters, args); return;
                default: throw new NotImplementedException($"Rewrite of {last} not implemented");
            }
        }
    }
}