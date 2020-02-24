﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
        public ITypeSymbol SemanticReturnType;
        
        public ExpressionSyntax ResultSize;
        public ExpressionSyntax SourceSize;
        public bool DifferentEnumeration;
        
        public ExpressionSyntax LastItem;
        
        private List<StatementSyntax> _preForBody = new List<StatementSyntax>();
        private List<StatementSyntax> _lastFors;
        private List<StatementSyntax> _forBody = new List<StatementSyntax>();
        private List<StatementSyntax> _postForBody = new List<StatementSyntax>();

        public bool IsReversed;
        public ValueBridge ForMin;
        public ValueBridge ForMax;
        public ValueBridge ForReMin;
        public ValueBridge ForReMax;
        public bool HasResultMethod;
        
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
            SemanticReturnType = semanticReturnType;
        }

        public void PreForAdd(StatementBridge _) => _preForBody.Add(_);
        public void ForAdd(StatementBridge _) => _forBody.Add(_);
        public void PostForAdd(StatementBridge _) => _postForBody.Add(_);
        public List<StatementSyntax> CopyFor()
        {
            if (_lastFors == null) _lastFors = new List<StatementSyntax>(_forBody);
            else _lastFors.AddRange(_forBody);
            return _lastFors;
        }

        public IEnumerable<StatementSyntax> GetMethodBody()
        {
            if (_forBody.Count == 0) return _preForBody.Concat(_postForBody);
            if (ForMin == null)
            {
                if (_lastFors != null) _preForBody.Add(Rewrite.GetForEachStatement(Constants.GlobalItemVariable, Collection,
                    SyntaxFactoryHelper.AggregateStatementSyntax(_lastFors)));
                _preForBody.Add(Rewrite.GetForEachStatement(Constants.GlobalItemVariable, Collection,
                    SyntaxFactoryHelper.AggregateStatementSyntax(_forBody)));
            }
            else if (IsReversed)
            {
                if (_lastFors != null) _preForBody.Add(Rewrite.GetReverseForStatement(
                    Constants.GlobalIndexerVariable, ForReMin, ForReMax, SyntaxFactoryHelper.AggregateStatementSyntax(_lastFors)));
                _preForBody.Add(Rewrite.GetReverseForStatement(
                    Constants.GlobalIndexerVariable, ForReMin, ForReMax, SyntaxFactoryHelper.AggregateStatementSyntax(_forBody)));
            }
            else 
            {
                if (_lastFors != null) _preForBody.Add(Rewrite.GetForStatement(
                    Constants.GlobalIndexerVariable, ForMin, ForMax, SyntaxFactoryHelper.AggregateStatementSyntax(_lastFors)));
                _preForBody.Add(Rewrite.GetForStatement(
                    Constants.GlobalIndexerVariable, ForMin, ForMax, SyntaxFactoryHelper.AggregateStatementSyntax(_forBody)));
            }
            
            _preForBody.AddRange(_postForBody);
            return _preForBody;
        }

        public void Dispose() => RewriteParametersHolder.ReturnParameters(this);
    }
}