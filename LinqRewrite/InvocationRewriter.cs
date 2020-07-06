// Forked and modified from https://github.com/antiufo/roslyn-linq-rewrite/tree/master/RoslynLinqRewrite

using System;
using System.Collections.Generic;
using System.Linq;
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
            using var design = RewriteParametersFactory.BorrowParameters();
            design.SetData(collection, returnType, chain, node, false);
            string[] names = chain.Select(x => x.MethodName).ToArray();
            
            var (simplePreCheck, simpleResult) = TryRewriteSimple(design, names);
            if (simplePreCheck && simpleResult != null) return simpleResult;
            if (simplePreCheck) design.SetData(collection, returnType, chain, node, true);

            design.HasResultMethod = MethodsWithResult.Contains(names.Last());
            RewriteComposite(design, names);
                    
            var body = design.Error ? new []{design.InitialStatements[0]} : GetMethodBody(design);
            if (design.NotRewrite) throw new NotSupportedException("Not good for rewrite");

            if (design.Data.CurrentMethodIsConditional && design.ReturnType.Type.ToString() != "void")
                return ConditionalExpression(design.CurrentCollection.IsEqual(null),
                Default(design.ReturnType), design.Rewrite.GetMethodInvocationExpression(design, body));
            return design.Rewrite.GetMethodInvocationExpression(design, body);
        }

        public static IEnumerable<StatementSyntax> GetMethodBody(RewriteDesign design)
        {
            if (design.Iterators.Count == 0) return design.InitialStatements.Concat(design.FinalStatements).Concat(design.ResultStatements);
            var result = new List<StatementSyntax>();
            foreach (var iterator in design.ResultIterators)
            {
                StatementSyntax[] statements = iterator.GetStatementSyntax(design);
                result.AddRange(iterator.PreFor);
                if (statements.Length > 0) result.AddRange(statements);
                result.AddRange(iterator.PostFor);
            }

            if (!design.Unchecked && design.WrapWithTry)
            {
                result = design.InitialStatements.Concat(new []{TryF(Block(result), Block(design.FinalStatements))}).Concat(design.ResultStatements).ToList();
            }
            else
            {
                result.InsertRange(0, design.InitialStatements);
                result.AddRange(design.FinalStatements);
                result.AddRange(design.ResultStatements);
            }
            return result;
        }

        private static void RewriteComposite(RewriteDesign design, string[] names)
        {
            if (design.Data.CurrentMethodIsConditional && design.ReturnType.Type.ToString() == "void")
                design.InitialAdd(If(design.CurrentCollection.IsEqual(null), ReturnStatement()));
            
            if (!MethodsCreateArray.Contains(names.First())) RewriteCollectionEnumeration.Rewrite(design, Array.Empty<RewrittenValueBridge>(), true);
            for (var i = 0; i < names.Length; i++)
            {
                design.Variables.Where(x => !x.IsGlobal).ForEach(x => x.IsUsed = false);
                RewritePart(names[i], design, i);
            }

            if (design.HasResultMethod) return;
            design.ForAdd(YieldStatement(SyntaxKind.YieldReturnStatement, design.LastValue));
            design.ResultAdd(YieldStatement(SyntaxKind.YieldBreakStatement));
        }

        private static (bool preCheck, ExpressionSyntax result) TryRewriteSimple(RewriteDesign design, string[] names)
        {
            if (design.CurrentCollection?.CollectionType == CollectionType.IEnumerable) return (false, null);
            if (names.Any(x => MethodsModifyingEnumeration.Contains(x))) return (false, null);
            if (design.Data.CurrentMethodParams.Any(x => x.Modifiers.Any())) return (false, null);

            if (!MethodsCreateArray.Contains(names.First())) RewriteCollectionEnumeration.Rewrite(design, Array.Empty<RewrittenValueBridge>(), false);
            for (var i = 0; i < names.Length; i++)
            {
                ExpressionSyntax rewrittenPart = RewriteSimplePart(names[i], design, i);
                if (design.Error) return (true, null);
                if (!design.SimpleEnumeration) return (true, null);
                if (rewrittenPart != null) return (true, rewrittenPart);
            }

            if (!MethodsWithResult.Contains(names.Last()))
            {
                ExpressionSyntax rewrittenPart = RewriteToArray.SimpleRewrite(design, Array.Empty<RewrittenValueBridge>());
                if (!design.SimpleEnumeration) return (true, null);
                if (rewrittenPart != null) return (true, rewrittenPart);
            }
            
            return (true, null);
        }

        private static ExpressionSyntax RewriteSimplePart(string last, RewriteDesign design, int i)
        {
            var args = design.RewriteChain[i].Arguments;
            switch (last)
            {
                case "Aggregate": return RewriteAggregate.SimpleRewrite(design, args);
                case "All": return RewriteAll.SimpleRewrite(design, args);
                case "Any": return RewriteAny.SimpleRewrite(design, args);
                case "Average": return RewriteAverage.SimpleRewrite(design, args);
                case "Sum": return RewriteSum.SimpleRewrite(design, args);
                
                case "Count": return RewriteCount.SimpleRewrite(design, args);
                case "LongCount": return RewriteLongCount.SimpleRewrite(design, args);
                
                case "First": return RewriteFirst.SimpleRewrite(design, args);
                case "FirstOrDefault": return RewriteFirstOrDefault.SimpleRewrite(design, args);
                case "Last": return RewriteLast.SimpleRewrite(design, args);
                case "LastOrDefault": return RewriteLastOrDefault.SimpleRewrite(design, args);
                case "Single": return RewriteSingle.SimpleRewrite(design, args);
                case "SingleOrDefault": return RewriteSingleOrDefault.SimpleRewrite(design, args);
                case "ElementAt": return RewriteElementAt.SimpleRewrite(design, args);
                case "ElementAtOrDefault": return RewriteElementAtOrDefault.SimpleRewrite(design, args);
                
                case "Range": RewriteRange.Rewrite(design, args); return null;
                case "Repeat": RewriteRepeat.Rewrite(design, args); return null;
                case "Empty": RewriteEmpty.Rewrite(design, args,  design.RewriteChain[i].Invocation); return null;
                
                case "Skip": RewriteSkip.Rewrite(design, args); return null;
                case "Take": RewriteTake.Rewrite(design, args); return null;
                case "Reverse": RewriteReverse.Rewrite(design, args); return null;
                case "Select": RewriteSelect.Rewrite(design, args); return null;
                case "Cast": RewriteCast.Rewrite(design, args, design.RewriteChain[i].Invocation); return null;
                
                case "ToArray": return RewriteToArray.SimpleRewrite(design, args);
                case "ToList": return RewriteToList.SimpleRewrite(design, args);
                case "ToSimpleList": return RewriteToSimpleList.SimpleRewrite(design, args);
                
                case "Unchecked": design.Unchecked = true; return null;
                default: return null;
            }
        }

        private static void RewritePart(string last, RewriteDesign design, int i)
        {
            var args = design.RewriteChain[i].Arguments;
            switch (last)
            {
                case "All": RewriteAll.Rewrite(design, args); return;
                case "Any": RewriteAny.Rewrite(design, args); return;
                case "Contains": RewriteContains.Rewrite(design, args); return;
                case "Count": RewriteCount.Rewrite(design, args); return;
                case "LongCount": RewriteLongCount.Rewrite(design, args); return;

                case "Min": RewriteMin.Rewrite(design, args); return;
                case "Max": RewriteMax.Rewrite(design, args); return;
                case "Average": RewriteAverage.Rewrite(design, args); return;
                case "Aggregate": RewriteAggregate.Rewrite(design, args); return;
                case "Sum": RewriteSum.Rewrite(design, args); return;
                
                case "ForEach": RewriteForEach.Rewrite(design, args); return;
                
                case "First": RewriteFirst.Rewrite(design, args); return;
                case "FirstOrDefault": RewriteFirstOrDefault.Rewrite(design, args); return;
                case "Last": RewriteLast.Rewrite(design, args); return;
                case "LastOrDefault": RewriteLastOrDefault.Rewrite(design, args); return;
                case "Single": RewriteSingle.Rewrite(design, args); return;
                case "SingleOrDefault": RewriteSingleOrDefault.Rewrite(design, args); return;
                case "ElementAt": RewriteElementAt.Rewrite(design, args); return;
                case "ElementAtOrDefault": RewriteElementAtOrDefault.Rewrite(design, args); return;
                
                case "Range": RewriteRange.Rewrite(design, args); return;
                case "Repeat": RewriteRepeat.Rewrite(design, args); return;
                case "Empty": RewriteEmpty.Rewrite(design, args,  design.RewriteChain[i].Invocation); return;
                
                case "Skip": RewriteSkip.Rewrite(design, args); return;
                case "SkipWhile": RewriteSkipWhile.Rewrite(design, args); return;
                case "Take": RewriteTake.Rewrite(design, args); return;
                case "TakeWhile": RewriteTakeWhile.Rewrite(design, args); return;
                
                case "Reverse": RewriteReverse.Rewrite(design, args); return;
                case "Select": RewriteSelect.Rewrite(design, args); return;
                case "SelectMany": RewriteSelectMany.Rewrite(design, args); return;
                case "Where": RewriteWhere.Rewrite(design, args); return;
                case "Cast": RewriteCast.Rewrite(design, args, design.RewriteChain[i].Invocation); return;
                case "OfType": RewriteOfType.Rewrite(design, args, design.RewriteChain[i].Invocation); return;
                
                case "Concat": RewriteConcat.Rewrite(design, args); return;
                case "Union": RewriteUnion.Rewrite(design, args); return;
                case "Intersect": RewriteIntersect.Rewrite(design, args); return;
                case "Except": RewriteExcept.Rewrite(design, args); return;
                case "Distinct": RewriteDistinct.Rewrite(design, args); return;
                
                case "SequenceEqual": RewriteSequenceEqual.Rewrite(design, args); return;
                case "Zip": RewriteZip.Rewrite(design, args); return;
                
                case "Join": RewriteJoin.Rewrite(design, args); return;
                case "GroupBy": RewriteGroupBy.Rewrite(design, args); return;
                case "GroupJoin": RewriteGroupJoin.Rewrite(design, args); return;
                
                case "ToArray": RewriteToArray.Rewrite(design, args); return;
                case "ToList": RewriteToList.Rewrite(design, args); return;
                case "ToSimpleList": RewriteToSimpleList.Rewrite(design, args); return;
                case "ToDictionary": RewriteToDictionary.Rewrite(design, args); return;
                
                case "Unchecked": design.Unchecked = true; return;
                default: throw new NotImplementedException($"Rewrite of {last} not implemented");
            }
        }
    }
}