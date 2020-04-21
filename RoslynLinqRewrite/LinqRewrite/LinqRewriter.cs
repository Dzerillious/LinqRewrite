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
            => TryVisitInvocationExpression(node, null) ?? base.VisitInvocationExpression(node);

        public override SyntaxNode VisitConditionalAccessExpression(ConditionalAccessExpressionSyntax node)
        {
            var old = _data.CurrentMethodIsConditional;
            _data.CurrentMethodIsConditional = true;
            try
            {
                if (!(node.WhenNotNull is InvocationExpressionSyntax invocation))
                    return base.VisitConditionalAccessExpression(node);
                
                var rewritten = TryVisitInvocationExpression(invocation, null);
                return node.WhenNotNull.ToString() == rewritten.ToString() ? node : rewritten;
            }
            finally
            {
                _data.CurrentMethodIsConditional = old;
            }
        }

        public override SyntaxNode VisitStructDeclaration(StructDeclarationSyntax node)
            => VisitTypeDeclaration(node);

        public override SyntaxNode VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            if (HasNoRewriteAttribute(node.AttributeLists)) return node;
            var old = RewrittenLinqQueries;
            var syntaxNode = base.VisitMethodDeclaration(node);
            if (RewrittenLinqQueries != old) RewrittenMethods++;
            return syntaxNode;
        }

        public override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
            => VisitTypeDeclaration(node);

        private ExpressionSyntax TryVisitInvocationExpression(InvocationExpressionSyntax node, ForEachStatementSyntax containingForEach)
        {
            var methodIdx = _data.MethodsToAddToCurrentType.Count;
            try
            {
                var expressionSyntax = VisitInvocationExpression(node, containingForEach);
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

        private ExpressionSyntax VisitInvocationExpression(InvocationExpressionSyntax node,
            ForEachStatementSyntax containingForEach)
        {
            if (!(node.Expression is MemberAccessExpressionSyntax) && !(node.Expression is MemberBindingExpressionSyntax)) return null;

            var owner = node.AncestorsAndSelf().FirstOrDefault(x => x is MethodDeclarationSyntax);
            if (owner == null) return null;
            
            _data.CurrentMethodIsStatic = _data.Semantic.GetDeclaredSymbol((MethodDeclarationSyntax) owner).IsStatic;
            _data.CurrentMethodName = ((MethodDeclarationSyntax) owner).Identifier.ValueText;
            _data.CurrentMethodTypeParameters = ((MethodDeclarationSyntax) owner).TypeParameterList;
            _data.CurrentMethodConstraintClauses = ((MethodDeclarationSyntax) owner).ConstraintClauses;

            if (!IsSupportedMethod(node)) return node;
            var chain = GetInvocationStepChain(node, out var lastNode);
            
            var (rewrite, collection) = CheckIfRewriteInvocation(node, lastNode);
            if (!rewrite) return null;
            
            var returnType = _data.Semantic.GetTypeFromExpression(node);

            return InvocationRewriter.TryRewrite(collection, returnType, chain, node)
                .WithLeadingTrivia(((CSharpSyntaxNode) containingForEach ?? node).GetLeadingTrivia())
                .WithTrailingTrivia(((CSharpSyntaxNode) containingForEach ?? node).GetTrailingTrivia());
        }

        private SyntaxNode VisitTypeDeclaration(TypeDeclarationSyntax node)
        {
            if (HasNoRewriteAttribute(node.AttributeLists)) return node;

            var old = _data.CurrentType;
            _data.CurrentType = node;
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
                _data.CurrentType = old;
                return withMethods.NormalizeWhitespace();
            }
            _data.CurrentType = old;
            return changed;
        }

        private SyntaxNode TryVisitForEachStatement(ForEachStatementSyntax node)
        {
            if (!(node.Expression is InvocationExpressionSyntax collection) || !IsSupportedMethod(collection))
                return base.VisitForEachStatement(node);

            var visitor = new CanReWrapForeachVisitor();
            visitor.Visit(node.Statement);
            if (visitor.Fail) return base.VisitForEachStatement(node);

            var expressionSyntax = TryVisitInvocationExpression(collection, node);
            return expressionSyntax != null
                ? SyntaxFactory.ExpressionStatement(expressionSyntax)
                : base.VisitForEachStatement(node);
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
            foreach (var t in invocationExpression.ArgumentList.Arguments)
            {
                var expression = t.Expression;
                if (expression is InvocationExpressionSyntax newInvocation)
                {
                    var visited = TryVisitInvocationExpression(newInvocation, null);
                    arguments.Add(new RewrittenValueBridge(expression, visited));
                }
                else if (expression is SimpleLambdaExpressionSyntax simpleLambdaExpression)
                {
                    var visited = VisitSimpleLambdaExpression(simpleLambdaExpression);
                    arguments.Add(new RewrittenValueBridge(expression, SyntaxFactory.ParseExpression(visited.ToString())));
                }
                else if (expression is ParenthesizedLambdaExpressionSyntax parenthesizedLambdaExpression)
                {
                    var visited = VisitParenthesizedLambdaExpression(parenthesizedLambdaExpression);
                    arguments.Add(new RewrittenValueBridge(expression, SyntaxFactory.ParseExpression(visited.ToString())));
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

        private static string GetMethodName(string name)
        {
            var index = name.IndexOf('<');
            return index == -1 ? name : name.Substring(0, index);
        }

        private static bool IsSupportedMethod(InvocationExpressionSyntax invocation) 
            => invocation.Expression switch
            {
                MemberAccessExpressionSyntax access => Constants.RewritableMethods.Contains(GetMethodName(access.Name.ToString())),
                MemberBindingExpressionSyntax binding => Constants.RewritableMethods.Contains(GetMethodName(binding.Name.ToString())),
                _ => false
            };

        private bool HasNoRewriteAttribute(SyntaxList<AttributeListSyntax> attributeLists) =>
            attributeLists.Any(x => 
                x.Attributes.Any(y =>
            {
                var symbol = ((IMethodSymbol) _data.Semantic.GetSymbolInfo(y).Symbol).ContainingType;
                return symbol.ToDisplayString() == "LinqRewrite.Core.NoRewriteAttribute";
            }));
    }
}