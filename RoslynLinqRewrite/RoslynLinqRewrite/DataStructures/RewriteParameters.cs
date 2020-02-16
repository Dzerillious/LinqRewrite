using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Operations;
using Shaman.Roslyn.LinqRewrite.Extensions;
using Shaman.Roslyn.LinqRewrite.Services;

namespace Shaman.Roslyn.LinqRewrite.DataStructures
{
    public class RewriteParameters : IDisposable
    {
        public readonly RewriteService Rewrite;
        public readonly CodeCreationService Code;
        public readonly RewriteDataService Data;
        
        public InvocationExpressionSyntax Node;
        public ExpressionSyntax Collection;
        public List<LinqStep> Chain;
        
        public TypeSyntax ReturnType;
        
        public ExpressionSyntax ResultSize;
        public ExpressionSyntax SourceSize;
        public bool DifferentEnumeration;
        
        public ExpressionSyntax LastItem;
        
        private List<StatementSyntax> _preForBody = new List<StatementSyntax>();
        private List<StatementSyntax> _forBody = new List<StatementSyntax>();
        private List<StatementSyntax> _postForBody = new List<StatementSyntax>();

        public bool IsReversed;
        public ValueBridge ForMin;
        public ValueBridge ForMax;
        public ValueBridge ForReMin;
        public ValueBridge ForReMax;
        
        public SemanticModel Semantic => Data.Semantic;
        
        public RewriteParameters()
        {
            Rewrite = RewriteService.Instance;
            Code = CodeCreationService.Instance;
            Data = RewriteDataService.Instance;
        }
        
        public void SetData(ExpressionSyntax collection, TypeSyntax returnType, ITypeSymbol semanticReturnType, List<LinqStep> chain, InvocationExpressionSyntax node)
        {
            _preForBody = new List<StatementSyntax>();
            _forBody = new List<StatementSyntax>();
            _postForBody = new List<StatementSyntax>();
            
            Collection = collection;
            ReturnType = returnType;
            Chain = chain;
            Node = node;
        }

        public void PreForAdd(StatementSyntax _) => _preForBody.Add(_);
        public void PreForAdd(ExpressionSyntax _) => _preForBody.Add(SyntaxFactory.ExpressionStatement(_));
        public void ForAdd(StatementSyntax _) => _forBody.Add(_);
        public void ForAdd(ExpressionSyntax _) => _forBody.Add(SyntaxFactory.ExpressionStatement(_));
        public void PostForAdd(StatementSyntax _) => _postForBody.Add(_);
        public void PostForAdd(ExpressionSyntax _) => _postForBody.Add(SyntaxFactory.ExpressionStatement(_));

        public IEnumerable<StatementSyntax> GetMethodBody()
        {
            if (ForMin == null)
            {
                _preForBody.Add(Rewrite.GetForEachStatement(Constants.GlobalItemVariable, Collection,
                    SyntaxFactoryHelper.AggregateStatementSyntax(_forBody)));
            }
            else if (IsReversed)
            {
                _preForBody.Add(Rewrite.GetForStatement(
                    Constants.GlobalIndexerVariable, ForReMin, ForReMax, SyntaxFactoryHelper.AggregateStatementSyntax(_forBody)));
            }
            else 
            {
                _preForBody.Add(Rewrite.GetReverseForStatement(
                    Constants.GlobalIndexerVariable, ForMin, ForMax, SyntaxFactoryHelper.AggregateStatementSyntax(_forBody)));
            }
            
            _preForBody.AddRange(_postForBody);
            return _preForBody;
        }

        public void Dispose() => RewriteParametersHolder.ReturnParameters(this);
    }
}