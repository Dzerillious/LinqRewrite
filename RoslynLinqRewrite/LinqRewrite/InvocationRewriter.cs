using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using LinqRewrite.Core;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using LinqRewrite.RewriteRules;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Constants;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite
{
    public static class InvocationRewriter
    {
        public static ExpressionSyntax TryRewrite(ValueBridge collection, TypeSyntax returnType, List<LinqStep> chain, InvocationExpressionSyntax node) 
        {
            using var parameters = RewriteParametersFactory.BorrowParameters();
            parameters.SetData(collection, returnType, chain, node);
            
            var regex = new Regex("(.*\\.)?(.*?)(\\<.*\\>)?\\(.*");
            var names = chain.Select(x =>
            {
                var match = regex.Match(x.MethodName);
                return match.Groups[1].Value.EndsWith(".")
                    ? match.Groups[2].Value : match.Groups[1].Value;
            }).ToArray();
            
            var (simpleSuccess, simpleResult) = TryRewriteSimple(parameters, names);
            if (simpleSuccess && simpleResult != null) return simpleResult;
            if (simpleSuccess) parameters.SetData(collection, returnType, chain, node);

            parameters.HasResultMethod = MethodsWithResult.Contains(names.Last());
            RewriteComposite(parameters, names);
                    
            var body = parameters.GetMethodBody();
            if (parameters.NotRewrite) throw new NotSupportedException("Not good for rewrite");

            if (parameters.Data.CurrentMethodIsConditional && parameters.ReturnType.Type.ToString() != "void")
                return ConditionalExpression(parameters.CurrentCollection.IsEqual(null),
                Default(parameters.ReturnType), parameters.Rewrite.GetMethodInvocationExpression(parameters, body));
            else return parameters.Rewrite.GetMethodInvocationExpression(parameters, body);
        }

        private static void RewriteComposite(RewriteParameters parameters, string[] names)
        {
            if (!MethodsCreateArray.Contains(names.First())) RewriteCollectionEnumeration.Rewrite(parameters, Array.Empty<RewrittenValueBridge>(), true);
            for (var i = 0; i < names.Length; i++)
            {
                parameters.Variables.Where(x => !x.IsGlobal).ForEach(x => x.IsUsed = false);
                RewritePart(names[i], parameters, i);
            }
            
            if (parameters.Data.CurrentMethodIsConditional && parameters.ReturnType.Type.ToString() == "void")
                parameters.InitialAdd(If(parameters.CurrentCollection.IsEqual(null), ReturnStatement()));

            if (!parameters.HasResultMethod)
            {
                parameters.ForAdd(YieldStatement(SyntaxKind.YieldReturnStatement, parameters.LastValue));
                parameters.ResultAdd(YieldStatement(SyntaxKind.YieldBreakStatement));
            }
        }

        private static (bool success, ExpressionSyntax result) TryRewriteSimple(RewriteParameters parameters, string[] names)
        {
            if (parameters.CurrentCollection?.CollectionType == CollectionType.Enumerable) return (false, null);
            if (names.Any(x => MethodsModifyingEnumeration.Contains(x))) return (false, null);
            if (parameters.Data.CurrentMethodParams.Any(x => x.Modifiers.Any())) return (false, null);
            if (!MethodsSimplyRewritable.Contains(names.Last())) return (false, null);
            if (parameters.RewriteChain.Last().Arguments.Any()) return (false, null);

            if (!MethodsCreateArray.Contains(names.First())) RewriteCollectionEnumeration.Rewrite(parameters, Array.Empty<RewrittenValueBridge>(), false);
            for (var i = 0; i < names.Length; i++)
            {
                var res = RewriteSimplePart(names[i], parameters, i);
                if (!parameters.SimpleEnumeration) return (true, null);
                if (res != null) return (true, res);
            }
            
            return (true, null);
        }

        private static ExpressionSyntax RewriteSimplePart(string last, RewriteParameters parameters, int i)
        {
            var args = parameters.RewriteChain[i].Arguments;
            switch (last)
            {
                case "Any": return RewriteAny.SimpleRewrite(parameters, args);
                case "Count": return RewriteCount.SimpleRewrite(parameters, args);
                case "LongCount": return RewriteLongCount.SimpleRewrite(parameters, args);
                
                case "First": return RewriteFirst.SimpleRewrite(parameters, args);
                case "FirstOrDefault": return RewriteFirstOrDefault.SimpleRewrite(parameters, args);
                case "Last": return RewriteLast.SimpleRewrite(parameters, args);
                case "LastOrDefault": return RewriteLastOrDefault.SimpleRewrite(parameters, args);
                case "Single": return RewriteSingle.SimpleRewrite(parameters, args);
                case "SingleOrDefault": return RewriteSingleOrDefault.SimpleRewrite(parameters, args);
                case "ElementAt": return RewriteElementAt.SimpleRewrite(parameters, args);
                case "ElementAtOrDefault": return RewriteElementAtOrDefault.SimpleRewrite(parameters, args);
                
                case "Range": RewriteRange.Rewrite(parameters, args); return null;
                case "Repeat": RewriteRepeat.Rewrite(parameters, args); return null;
                case "Empty": RewriteEmpty.Rewrite(parameters, args,  parameters.RewriteChain[i].Invocation); return null;
                
                case "Skip": RewriteSkip.Rewrite(parameters, args); return null;
                case "Take": RewriteTake.Rewrite(parameters, args); return null;
                case "Reverse": RewriteReverse.Rewrite(parameters, args); return null;
                case "Select": RewriteSelect.Rewrite(parameters, args); return null;
                case "Cast": RewriteCast.Rewrite(parameters, args, parameters.RewriteChain[i].Invocation); return null;
                
                case "ToArray": return RewriteToArray.SimpleRewrite(parameters, args);
                
                case "Unchecked": RewriteUnchecked.Rewrite(parameters, args); return null;
                case "WithResultSize": RewriteResultSize.Rewrite(parameters, args); return null;
                case "WithMaxSize": RewriteSourceSize.Rewrite(parameters, args); return null;
                default: return null;
            }
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
                
                case "Join": RewriteJoin.Rewrite(parameters, args); return;
                case "GroupBy": RewriteGroupBy.Rewrite(parameters, args); return;
                case "GroupJoin": RewriteGroupJoin.Rewrite(parameters, args); return;
                
                case "ToArray": RewriteToArray.Rewrite(parameters, args); return;
                case "ToList": RewriteToList.Rewrite(parameters, args); return;
                case "ToSimpleList": RewriteToSimpleList.Rewrite(parameters, args); return;
                case "ToDictionary": RewriteToDictionary.Rewrite(parameters, args); return;
                case "ToLookup": RewriteToLookup.Rewrite(parameters, args); return;
                
                case "Unchecked": RewriteUnchecked.Rewrite(parameters, args); return;
                case "WithResultSize": RewriteResultSize.Rewrite(parameters, args); return;
                case "WithMaxSize": RewriteSourceSize.Rewrite(parameters, args); return;
                default: throw new NotImplementedException($"Rewrite of {last} not implemented");
            }
        }
    }
}