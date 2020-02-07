﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using Shaman.Roslyn.LinqRewrite.Services;
using SyntaxExtensions = Shaman.Roslyn.LinqRewrite.Extensions.SyntaxExtensions;

namespace Shaman.Roslyn.LinqRewrite
{
    public class LinqRewriter : CSharpSyntaxRewriter
    {
        private readonly RewriteDataService _data;
        private readonly RewriteLinqService _linq;
        private readonly SyntaxInformationService _info;
        private readonly CodeCreationService _code;

        public LinqRewriter(SemanticModel semantic)
        {
            _data = RewriteDataService.Instance;
            _linq = RewriteLinqService.Instance;
            _info = SyntaxInformationService.Instance;
            _code = CodeCreationService.Instance;
            
            _data.Semantic = semantic;
            RewriteService.Instance.Visit = Visit;
        }

        public int RewrittenMethods { get; private set; }
        public int RewrittenLinqQueries { get; private set; }

        public override SyntaxNode VisitInvocationExpression(InvocationExpressionSyntax node)
            => TryCatchVisitInvocationExpression(node, null) ?? base.VisitInvocationExpression(node);

        private bool insideConditionalExpression;
        public override SyntaxNode VisitConditionalAccessExpression(ConditionalAccessExpressionSyntax node)
        {
            var old = insideConditionalExpression;
            insideConditionalExpression = true;
            try
            {
                return base.VisitConditionalAccessExpression(node);
            }
            finally
            {
                insideConditionalExpression = old;
            }
        }

        private ExpressionSyntax TryCatchVisitInvocationExpression(InvocationExpressionSyntax node,
            ForEachStatementSyntax containingForEach)
        {
            if (insideConditionalExpression) return null;
            var methodIdx = _data.MethodsToAddToCurrentType.Count;
            try
            {
                var expressionSyntax = TryVisitInvocationExpression(node, containingForEach);
                if (expressionSyntax != null)
                {
                    RewrittenLinqQueries++;
                    return expressionSyntax;
                }
            }
            catch (Exception ex) when (ex is InvalidCastException || ex is NotSupportedException)
            {
                _data.MethodsToAddToCurrentType.RemoveRange(methodIdx, _data.MethodsToAddToCurrentType.Count - methodIdx);
            }
            return null;
        }

        private ExpressionSyntax TryVisitInvocationExpression(InvocationExpressionSyntax node,
            ForEachStatementSyntax containingForEach)
        {
            if (!(node.Expression is MemberAccessExpressionSyntax memberAccess)) return null;

            var symbol = _data.Semantic.GetSymbolInfo(memberAccess).Symbol as IMethodSymbol;
            var owner = node.AncestorsAndSelf().FirstOrDefault(x => x is MethodDeclarationSyntax);
            if (owner == null) return null;
            _data.CurrentMethodIsStatic = _data.Semantic.GetDeclaredSymbol((MethodDeclarationSyntax) owner).IsStatic;
            _data.CurrentMethodName = ((MethodDeclarationSyntax) owner).Identifier.ValueText;
            _data.CurrentMethodTypeParameters = ((MethodDeclarationSyntax) owner).TypeParameterList;
            _data.CurrentMethodConstraintClauses = ((MethodDeclarationSyntax) owner).ConstraintClauses;

            if (!IsSupportedMethod(node)) return null;
            
            var chain = GetStepChain(node, out var lastNode);
            if (containingForEach != null) ChainInsertForEach(chain, containingForEach);

            if (!chain.Any(x => x.Arguments.Any(y => y is AnonymousFunctionExpressionSyntax))) return null;
            if (chain.Count == 1 && Constants.RootMethodsThatRequireYieldReturn.Contains(chain[0].MethodName)) return null;
            var (flowsIn, flowsOut) = GetFlows(chain);

            _data.CurrentFlow = flowsIn.Union(flowsOut)
                .Where(x => (x as IParameterSymbol)?.IsThis != true)
                .Select(x => _code.CreateVariableCapture(x, flowsOut));

            var collection = ((MemberAccessExpressionSyntax) lastNode.Expression).Expression;
            if (SyntaxExtensions.IsAnonymousType(_data.Semantic.GetTypeInfo(collection).Type)) return null;

            var semanticReturnType = _data.Semantic.GetTypeInfo(node).Type;
            if (SyntaxExtensions.IsAnonymousType(semanticReturnType) ||
                _data.CurrentFlow.Any(x => SyntaxExtensions.IsAnonymousType(_info.GetSymbolType(x.Symbol)))) return null;

            return _linq.TryRewrite(chain.First().MethodName, collection, semanticReturnType, chain, node)
                .WithLeadingTrivia(((CSharpSyntaxNode) containingForEach ?? node).GetLeadingTrivia())
                .WithTrailingTrivia(((CSharpSyntaxNode) containingForEach ?? node).GetTrailingTrivia());
        }

        public override SyntaxNode VisitStructDeclaration(StructDeclarationSyntax node)
            => VisitTypeDeclaration(node);

        private SyntaxNode VisitTypeDeclaration(TypeDeclarationSyntax node)
        {
            if (HasNoRewriteAttribute(node.AttributeLists)) return node;

            var old = _data.CurrentType;
            _data.CurrentType = node;
            var changed = (TypeDeclarationSyntax) (node is ClassDeclarationSyntax
                ? base.VisitClassDeclaration((ClassDeclarationSyntax) node)
                : base.VisitStructDeclaration((StructDeclarationSyntax) node));
            if (_data.MethodsToAddToCurrentType.Count != 0)
            {
                var newMembers = _data.MethodsToAddToCurrentType.Where(x => x.Item1 == _data.CurrentType).Select(x => x.Item2)
                    .ToArray();
                var withMethods = changed is ClassDeclarationSyntax syntax
                    ? (TypeDeclarationSyntax) syntax.AddMembers(newMembers)
                    : ((StructDeclarationSyntax) changed).AddMembers(newMembers);
                _data.MethodsToAddToCurrentType.RemoveAll(x => x.Item1 == _data.CurrentType);
                _data.CurrentType = old;
                return withMethods.NormalizeWhitespace();
            }

            _data.CurrentType = old;
            return changed;
        }

        public override SyntaxNode VisitForEachStatement(ForEachStatementSyntax node)
            => TryVisitForEachStatement(node) ?? base.VisitForEachStatement(node);

        private SyntaxNode TryVisitForEachStatement(ForEachStatementSyntax node)
        {
            if (!(node.Expression is InvocationExpressionSyntax collection) || !IsSupportedMethod(collection))
                return base.VisitForEachStatement(node);

            var visitor = new CanReWrapForeachVisitor();
            visitor.Visit(node.Statement);
            if (visitor.Fail) return base.VisitForEachStatement(node);

            var k = TryCatchVisitInvocationExpression(collection, node);
            return k != null
                ? SyntaxFactory.ExpressionStatement(k)
                : base.VisitForEachStatement(node);
        }

        public override SyntaxNode VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            if (HasNoRewriteAttribute(node.AttributeLists)) return node;
            var old = RewrittenLinqQueries;
            var k = base.VisitMethodDeclaration(node);
            if (RewrittenLinqQueries != old) RewrittenMethods++;
            return k;
        }

        public override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
            => VisitTypeDeclaration(node);

        private List<LinqStep> GetStepChain(InvocationExpressionSyntax node, out InvocationExpressionSyntax lastNode)
        {
            var chain = new List<LinqStep>
            {
                new LinqStep(_info.GetMethodFullName(node),
                    node.ArgumentList.Arguments.Select(x => x.Expression).ToArray(), node)
            };
            lastNode = node;
            while (node.Expression is MemberAccessExpressionSyntax syntax)
            {
                node = syntax.Expression as InvocationExpressionSyntax;
                if (node != null && IsSupportedMethod(node))
                {
                    chain.Add(new LinqStep(_info.GetMethodFullName(node),
                        node.ArgumentList.Arguments.Select(x => x.Expression).ToArray(), node));
                    lastNode = node;
                }
                else break;
            }
            return chain;
        }

        private void ChainInsertForEach(List<LinqStep> chain, ForEachStatementSyntax forEach)
        {
            chain.Insert(0,
                new LinqStep(Constants.EnumerableForEachMethod,
                    new ExpressionSyntax[]
                    {
                        SyntaxFactory.SimpleLambdaExpression(
                            SyntaxFactory.Parameter(forEach.Identifier), forEach.Statement)
                    })
                {
                    Lambda = new Lambda(forEach.Statement,
                        new[]
                        {
                            _code.CreateParameter(forEach.Identifier,
                                _data.Semantic.GetTypeInfo(forEach.Type).ConvertedType)
                        })
                });
        }

        private (List<ISymbol>, List<ISymbol>) GetFlows(List<LinqStep> chain)
        {
            var flowsIn = new List<ISymbol>();
            var flowsOut = new List<ISymbol>();
            foreach (var item in chain)
            {
                foreach (var syntax in item.Arguments)
                {
                    if (item.Lambda != null)
                    {
                        var dataFlow = _data.Semantic.AnalyzeDataFlow(item.Lambda.Body);
                        var pName = item.Lambda.Parameters.Single().Identifier.ValueText;
                        foreach (var k in dataFlow.DataFlowsIn)
                        {
                            if (k.Name == pName) continue;
                            if (!flowsIn.Contains(k)) flowsIn.Add(k);
                        }
                        foreach (var k in dataFlow.DataFlowsOut)
                        {
                            if (k.Name == pName) continue;
                            if (!flowsOut.Contains(k)) flowsOut.Add(k);
                        }
                    }
                    else
                    {
                        var dataFlow = _data.Semantic.AnalyzeDataFlow(syntax);
                        foreach (var k in dataFlow.DataFlowsIn)
                            if (!flowsIn.Contains(k))
                                flowsIn.Add(k);

                        foreach (var k in dataFlow.DataFlowsOut)
                            if (!flowsOut.Contains(k))
                                flowsOut.Add(k);
                    }
                }
            }
            return (flowsIn, flowsOut);
        }

        private bool IsSupportedMethod(InvocationExpressionSyntax invocation)
        {
            var name = _info.GetMethodFullName(invocation);
            if (!IsSupportedMethod(name)) return false;
            if (invocation.ArgumentList.Arguments.Count == 0) return true;
            if (name == Constants.ElementAtMethod || name == Constants.ElementAtOrDefaultMethod || name == Constants.ContainsMethod) return true;

            // Passing things like .Select(Method) is not supported.
            return invocation.ArgumentList.Arguments.All(x => x.Expression is AnonymousFunctionExpressionSyntax);
        }

        private static bool IsSupportedMethod(string v)
        {
            if (v == null) return false;
            if (Constants.KnownMethods.Contains(v)) return true;
            if (!v.StartsWith("System.Collections.Generic.IEnumerable<")) return false;
            var k = v.Replace("<", "(");
            if (!k.Contains(">.Sum(") && !k.Contains(">.Average(") && !k.Contains(">.Min(") &&
                !k.Contains(">.Max(")) return false;
            if (k.Contains("TResult")) return false;
            if (v == "System.Collections.Generic.IEnumerable<TSource>.Min()") return false;
            if (v == "System.Collections.Generic.IEnumerable<TSource>.Max()") return false;
            return true;
        }

        private bool HasNoRewriteAttribute(SyntaxList<AttributeListSyntax> attributeLists)
        {
            return attributeLists.Any(x => x.Attributes.Any(y =>
            {
                var symbol = ((IMethodSymbol) _data.Semantic.GetSymbolInfo(y).Symbol).ContainingType;
                return symbol.ToDisplayString() == "Shaman.Runtime.NoLinqRewriteAttribute";
            }));
        }

        public Diagnostic CreateDiagnosticForException(Exception ex, string path)
        {
            while (ex.InnerException != null)
                ex = ex.InnerException;

            var message = "roslyn-linq-rewrite exception while processing '" + path + "', method " + _data.CurrentMethodName +
                          ": " + ex.Message + " -- " + ex.StackTrace?.Replace("\n", "");
            return Diagnostic.Create("LQRW1001", "Compiler", new LiteralString(message), DiagnosticSeverity.Error,
                DiagnosticSeverity.Error, true, 0);
        }
    }
}