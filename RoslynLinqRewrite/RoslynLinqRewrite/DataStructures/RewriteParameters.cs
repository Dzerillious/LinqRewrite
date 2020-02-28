using System;
using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Extensions;
using LinqRewrite.Services;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SimpleCollections;

namespace LinqRewrite.DataStructures
{
    public class RewriteParameters : IDisposable
    {
        public RewriteService Rewrite { get; }
        public CodeCreationService Code { get; }
        public RewriteDataService Data { get; }

        public InvocationExpressionSyntax Node { get; set; }
        public ExpressionSyntax Collection { get; set; }
        public List<LinqStep> Chain { get; set; }

        public TypeSyntax ReturnType { get; set; }

        public ExpressionSyntax ResultSize { get; set; }
        public ExpressionSyntax SourceSize { get; set; }

        public ValueBridge LastItem { get; set; }

        private List<EnumerationParameters> _enumerations;

        private List<StatementSyntax> _preForBody;
        public EnumerationParameters ForBody;
        private List<StatementSyntax> _postForBody;

        public bool IsReversed;
        public bool HasResultMethod;

        private bool _listsEnumeration = true;

        public bool ListsEnumeration
        {
            get => _listsEnumeration;
            set => _listsEnumeration = value;
        }

        private bool _modifiedEnumeration;

        public bool ModifiedEnumeration
        {
            get => _modifiedEnumeration;
            set
            {
                _modifiedEnumeration = value;
                if (value && CurrentIndexer != null)
                {
                    ResultSize = null;
                    CurrentIndexer = null;
                }
            }
        }

        public ValueBridge CurrentIndexer { get; set; }

        public ValueBridge Indexer
        {
            get
            {
                if (CurrentIndexer != null) return CurrentIndexer;

                var indexerVariable = CreateLocalVariable("__indexer", -1);
                ForAdd(indexerVariable.PreIncrement());

                return CurrentIndexer = indexerVariable;
            }
            set => CurrentIndexer = value;
        }

        public ValueBridge ForMin
        {
            get => ForBody.ForMin;
            set => ForBody.ForMin = value;
        }
        
        public ValueBridge ForMax
        {
            get => ForBody.ForMax;
            set => ForBody.ForMax = value;
        }
        
        public ValueBridge ForReMin
        {
            get => ForBody.ForReMin;
            set => ForBody.ForReMin = value;
        }
        
        public ValueBridge ForReMax
        {
            get => ForBody.ForReMax;
            set => ForBody.ForReMax = value;
        }
        
        public SemanticModel Semantic => Data.Semantic;
        
        public RewriteParameters()
        {
            Rewrite = RewriteService.Instance;
            Code = CodeCreationService.Instance;
            Data = RewriteDataService.Instance;
        }
        
        public void SetData(ExpressionSyntax collection, TypeSyntax returnType, List<LinqStep> chain, InvocationExpressionSyntax node)
        {
            _preForBody = new List<StatementSyntax>();
            ForBody = new EnumerationParameters(this, ForIndexerName, collection);
            _postForBody = new List<StatementSyntax>();
            
            _enumerations = new List<EnumerationParameters>{ForBody};
            
            Collection = collection;
            ReturnType = returnType;
            Chain = chain;
            Node = node;
        }

        public void PreForAdd(StatementBridge _) => _preForBody.Add(_);
        public void ForAdd(StatementBridge _)
        {
            _enumerations.Where(x => !x.Complete)
                .ForEach(x => x.Body.Add((StatementSyntaxBridge) _));
        }
        public void PostForAdd(StatementBridge _) => _postForBody.Add(_);
        
        public EnumerationParameters AddFor(ExpressionSyntax collection)
        {
            var oldBody = ForBody;
            ForBody = new EnumerationParameters(this, ForIndexerName, collection);
            _enumerations.Add(ForBody);
            return oldBody;
        }
        
        public EnumerationParameters CopyFor()
        {
            var oldBody = ForBody;
            ForBody = ForBody.Copy();
            _enumerations.Add(ForBody);
            return oldBody;
        }
        
        public EnumerationParameters CopyForReference()
        {
            var oldBody = ForBody;
            ForBody = ForBody.CopyReference();
            _enumerations.Add(ForBody);
            return oldBody;
        }

        public IEnumerable<StatementSyntax> GetMethodBody()
        {
            if (_enumerations.Count == 1 && ForBody.Body.Count == 0) return _preForBody.Concat(_postForBody);
            if (IsReversed)
            {
                for (var i = _enumerations.Count - 1; i >= 0; i--)
                    _preForBody.Add(_enumerations[i].GetStatementSyntax(this));
            }
            else
            {
                for (var i = 0; i < _enumerations.Count; i++)
                    _preForBody.Add(_enumerations[i].GetStatementSyntax(this));
            }
            
            _preForBody.AddRange(_postForBody);
            return _preForBody;
        }

        private int _variableIndex;
        public string GetVariableName(string name) => name + _variableIndex++;
        
        public VariableBridge CreateLocalVariable(string name, ValueBridge value)
        {
            var variable = name + _variableIndex++;
            PreForAdd(VariableExtensions.LocalVariableCreation(variable, value));
            return variable;
        }
        
        public VariableBridge CreateLocalVariable(string name, TypeBridge type, ValueBridge value)
        {
            var variable = name + _variableIndex++;
            PreForAdd(VariableExtensions.LocalVariableCreation(name, type, value));
            return variable;
        }
        
        public VariableBridge CreateForVariable(string name, ValueBridge value)
        {
            var variable = name + _variableIndex++;
            ForBody.BodyAdd(VariableExtensions.LocalVariableCreation(variable, value));
            return variable;
        }
        
        private int _globalForIndexersCounter;
        public VariableBridge CreateGlobalIndexer(string name, ValueBridge value)
        {
            var variable = name + _globalForIndexersCounter++;
            PreForAdd(VariableExtensions.LocalVariableCreation(name, value));
            return variable;
        }

        public string ForIndexerName => Constants.GlobalIndexerVariable + _globalForIndexersCounter;

        public void Dispose() => RewriteParametersFactory.ReturnParameters(this);
    }
}