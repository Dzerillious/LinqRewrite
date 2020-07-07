// Forked and modified from https://github.com/antiufo/roslyn-linq-rewrite/tree/master/RoslynLinqRewrite

using System;
using System.Collections.Generic;
using System.Linq;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using LinqRewrite.Services;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using SyntaxExtensions = LinqRewrite.Extensions.SyntaxExtensions;

namespace LinqRewrite
{
    public class LinqRewriter : CSharpSyntaxRewriter
    {
        private readonly RewriteDataService _data;
        public int RewrittenMethods { get; private set; }
        public int RewrittenLinqQueries { get; private set; }

        public LinqRewriter(SemanticModel semantic)
        {
            _data = RewriteDataService.Instance;
            RewriteService.Instance.Visit = VisitListElement;
            
            _data.Semantic = semantic;
        }
        public override SyntaxNode VisitInvocationExpression(InvocationExpressionSyntax node)
            => TryVisitInvocationExpression(node) ?? base.VisitInvocationExpression(node);

        public override SyntaxNode VisitConditionalAccessExpression(ConditionalAccessExpressionSyntax node)
        {
            var oldIsConditional = _data.CurrentMethodIsConditional;
            _data.CurrentMethodIsConditional = true;
            try
            {
                if (!(node.WhenNotNull is InvocationExpressionSyntax invocation))
                    return base.VisitConditionalAccessExpression(node);
                
                var rewritten = TryVisitInvocationExpression(invocation);
                return node.WhenNotNull.ToString() == rewritten.ToString() ? node : rewritten;
            }
            finally
            {
                _data.CurrentMethodIsConditional = oldIsConditional;
            }
        }

        public override SyntaxNode VisitStructDeclaration(StructDeclarationSyntax node)
            => VisitTypeDeclaration(node);

        public override SyntaxNode VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            var (rewrite, uncheckedLinq) = CheckAttributes(node.AttributeLists);
            var (oldRewrite, oldUnchecked) = (_data.CurrentRewrite, _data.CurrentIsUnchecked);
            
            _data.CurrentRewrite = rewrite ?? _data.CurrentRewrite;
            _data.CurrentIsUnchecked = uncheckedLinq ?? _data.CurrentIsUnchecked;
            
            int oldRewritten = RewrittenLinqQueries;
            var syntaxNode = base.VisitMethodDeclaration(node);

            (_data.CurrentIsUnchecked, _data.CurrentRewrite) = (oldUnchecked, oldRewrite);
            if (RewrittenLinqQueries != oldRewritten) RewrittenMethods++;
            return syntaxNode;
        }

        public override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
            => VisitTypeDeclaration(node);

        private ExpressionSyntax TryVisitInvocationExpression(InvocationExpressionSyntax node)
        {
            int methodIdx = _data.MethodsToAddToCurrentType.Count;
            try
            {
                var expressionSyntax = VisitInvocation(node);
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

        private ExpressionSyntax VisitInvocation(InvocationExpressionSyntax node)
        {
            if (!_data.CurrentRewrite) return node;
            if (!(node.Expression is MemberAccessExpressionSyntax) && !(node.Expression is MemberBindingExpressionSyntax)) return null;

            var ownerNode = node.AncestorsAndSelf().FirstOrDefault(x => x is MethodDeclarationSyntax);
            if (ownerNode == null) return null;
            
            _data.CurrentMethodIsStatic = _data.Semantic.GetDeclaredSymbol((MethodDeclarationSyntax) ownerNode).IsStatic;
            _data.CurrentMethodName = ((MethodDeclarationSyntax) ownerNode).Identifier.ValueText;
            _data.CurrentMethodTypeParameters = ((MethodDeclarationSyntax) ownerNode).TypeParameterList;
            _data.CurrentMethodConstraintClauses = ((MethodDeclarationSyntax) ownerNode).ConstraintClauses;

            if (!IsSupportedMethod(node)) return node;
            var chainList = GetInvocationStepChain(node, out var lastNode);
            
            var (rewrite, collection) = CheckIfRewriteInvocation(node, lastNode);
            if (!rewrite) return null;
            
            var returnType = _data.Semantic.GetTypeFromExpression(node);

            return InvocationRewriter.TryRewrite(collection, returnType, chainList, node)
                .WithLeadingTrivia(node.GetLeadingTrivia())
                .WithTrailingTrivia(node.GetTrailingTrivia());
        }

        private SyntaxNode VisitTypeDeclaration(TypeDeclarationSyntax node)
        {
            var (rewrite, uncheckedLinq) = CheckAttributes(node.AttributeLists);
            var (oldType, oldRewrite, oldUnchecked) = (_data.CurrentType, _data.CurrentRewrite, _data.CurrentIsUnchecked);
            
            _data.CurrentType = node;
            _data.CurrentRewrite = rewrite ?? _data.CurrentRewrite;
            _data.CurrentIsUnchecked = uncheckedLinq ?? _data.CurrentIsUnchecked;
            
            var changed = (TypeDeclarationSyntax) (node is ClassDeclarationSyntax declarationSyntax
                ? base.VisitClassDeclaration(declarationSyntax)
                : base.VisitStructDeclaration((StructDeclarationSyntax) node));
            
            if (_data.MethodsToAddToCurrentType.Count != 0)
            {
                var newMembers = _data.MethodsToAddToCurrentType
                    .Where(x => x.Item1 == _data.CurrentType)
                    .Select(x => x.Item2)
                    .ToArray();
                
                var withMethods = changed is ClassDeclarationSyntax syntax
                    ? (TypeDeclarationSyntax) syntax.AddMembers(newMembers)
                    : ((StructDeclarationSyntax) changed).AddMembers(newMembers);
                
                _data.MethodsToAddToCurrentType.RemoveAll(x => x.Item1 == _data.CurrentType);
                changed = withMethods.NormalizeWhitespace();
            }
            (_data.CurrentType, _data.CurrentIsUnchecked, _data.CurrentRewrite) 
                = (oldType, oldUnchecked, oldRewrite);
            return changed;
        }

        private List<LinqStep> GetInvocationStepChain(InvocationExpressionSyntax node, out ExpressionSyntax lastNode)
        {
            var chain = new List<LinqStep>();
            var invocationExpression = node;
            lastNode = node;
            while (true)
            {
                if (!IsSupportedMethod(invocationExpression)) break;
                var arguments = RewriteArguments(invocationExpression);

                if (invocationExpression.Expression is MemberAccessExpressionSyntax access)
                {
                    chain.Insert(0, new LinqStep(GetMethodName(access.Name.ToString()), arguments, invocationExpression));
                    lastNode = access.Expression;
                    if (lastNode is InvocationExpressionSyntax invocation)
                        invocationExpression = invocation;
                    else break;
                }
                else if (invocationExpression.Expression is MemberBindingExpressionSyntax binding)
                {
                    chain.Insert(0, new LinqStep(GetMethodName(binding.Name.ToString()), arguments, invocationExpression));
                    var conditional = (ConditionalAccessExpressionSyntax) node.Parent;
                    lastNode = conditional.Expression;
                    break;
                }
                else break;
            }
            return chain;
        }

        private RewrittenValueBridge[] RewriteArguments(InvocationExpressionSyntax invocationExpression)
        {
            var arguments = new List<RewrittenValueBridge>();
            foreach (var argument in invocationExpression.ArgumentList.Arguments)
            {
                var expression = argument.Expression;
                if (expression is InvocationExpressionSyntax newInvocation)
                {
                    var visitedExpression = TryVisitInvocationExpression(newInvocation);
                    arguments.Add(new RewrittenValueBridge(expression, visitedExpression));
                }
                else if (expression is SimpleLambdaExpressionSyntax simpleLambdaExpression)
                {
                    var visitedNode = VisitSimpleLambdaExpression(simpleLambdaExpression);
                    arguments.Add(new RewrittenValueBridge(expression, SyntaxFactory.ParseExpression(visitedNode.ToString())));
                }
                else if (expression is ParenthesizedLambdaExpressionSyntax parenthesizedLambdaExpression)
                {
                    var visitedNode = VisitParenthesizedLambdaExpression(parenthesizedLambdaExpression);
                    arguments.Add(new RewrittenValueBridge(expression, SyntaxFactory.ParseExpression(visitedNode.ToString())));
                }
                else arguments.Add(new RewrittenValueBridge(expression));
            }
            return arguments.ToArray();
        }

        private (bool, ExpressionSyntax) CheckIfRewriteInvocation(InvocationExpressionSyntax node, ExpressionSyntax lastNode)
        {
            if (lastNode.ToString() == "Enumerable" || lastNode.ToString() == "ExtendedLinq") lastNode = (ExpressionSyntax)lastNode.Parent.Parent;
            var flows = _data.Semantic.AnalyzeDataFlow(node);
            var flowsOut = flows.DataFlowsOut.ToArray();
            
            var flowsIn = flows.DataFlowsIn.Concat(node.DescendantNodesAndSelf()
                .Where(x => x is IdentifierNameSyntax)
                .Select(x => _data.Semantic.GetSymbolInfo(x).Symbol)
                .Where(x => x is IFieldSymbol)).ToArray();

            var changingParams = flowsOut.Concat(flows.WrittenInside).ToArray();
            var currentFlow = flowsIn.Union(flowsOut)
                .Where(x => (x as IParameterSymbol)?.IsThis != true)
                .Select(x => VariableExtensions.CreateVariableCapture(x, changingParams));
            
            _data.CurrentMethodParams = currentFlow
                .Select(x => CreateParameter(x.Name, SymbolExtensions.GetType(x.Symbol)).WithRef(x.Changes))
                .Distinct(new RewriteService.ParameterComparer()).ToList();
            _data.CurrentMethodArguments = currentFlow
                .GroupBy(x => x.Symbol, (x, y) => new VariableCapture(x, y.Any(z => z.Changes)))
                .Select(x => Argument(x.OriginalName).WithRef(x.Changes)).ToList();

            if (SyntaxExtensions.IsAnonymousType(_data.Semantic.GetTypeInfo(lastNode).Type)) return (false, null);

            var returnType = _data.Semantic.GetTypeInfo(node).Type;
            if (SyntaxExtensions.IsAnonymousType(returnType) ||
                currentFlow.Any(x => SyntaxExtensions.IsAnonymousType(SymbolExtensions.GetType(x.Symbol)))) 
                return (false, null);

            return (true, lastNode);
        }

        private static bool IsSupportedMethod(InvocationExpressionSyntax invocation) 
            => invocation.Expression switch
            {
                MemberAccessExpressionSyntax access => Constants.RewritableMethods.Contains(GetMethodName(access.Name.ToString())),
                MemberBindingExpressionSyntax binding => Constants.RewritableMethods.Contains(GetMethodName(binding.Name.ToString())),
                _ => false
            };

        private static string GetMethodName(string name)
        {
            var index = name.IndexOf('<');
            return index == -1 ? name : name.Substring(0, index);
        }

        private (bool? rewrite, bool? uncheckedLinq) CheckAttributes(SyntaxList<AttributeListSyntax> attributeLists)
        {
            bool? rewrite = null;
            bool? uncheckedLinq = null;
            foreach (var attributeListSyntax in attributeLists)
            foreach (var attribute in attributeListSyntax.Attributes)
            {
                string symbol = ((IMethodSymbol) _data.Semantic.GetSymbolInfo(attribute).Symbol).ContainingType.ToDisplayString();
                if (symbol == "LinqRewrite.Core.NoLinqRewriteAttribute")
                    return (false, null);
                
                if (symbol != "LinqRewrite.Core.LinqRewriteAttribute") continue;
                rewrite = true;
                uncheckedLinq = false;
                
                if (attribute.ArgumentList != null && attribute.ArgumentList.Arguments.Count > 0)
                    uncheckedLinq = attribute.ArgumentList.Arguments[0].ToString().Contains("RewriteOptions.Unchecked");
            }
            return (rewrite, uncheckedLinq);
        }
    }
}