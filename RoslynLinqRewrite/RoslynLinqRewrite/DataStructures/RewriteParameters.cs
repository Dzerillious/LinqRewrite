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
        private EnumerationParameters _forBody;
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
                if (value && _indexer != null)
                {
                    ResultSize = null;
                    _indexer = null;
                }
            }
        }

        private ValueBridge _indexer;
        public ValueBridge Indexer
        {
            get 
            {
                if (_indexer != null) return _indexer;

                var indexerVariable = CreateLocalVariable("__indexer", -1);
                PreForAdd(VariableExtensions.LocalVariableCreation(indexerVariable, -1));
                ForAdd(indexerVariable.PreIncrement());
            
                return _indexer = indexerVariable;
            }
            set => _indexer = value;
        }

        public ValueBridge ForMin
        {
            get => _forBody.ForMin;
            set => _forBody.ForMin = value;
        }
        
        public ValueBridge ForMax
        {
            get => _forBody.ForMax;
            set => _forBody.ForMax = value;
        }
        
        public ValueBridge ForReMin
        {
            get => _forBody.ForReMin;
            set => _forBody.ForReMin = value;
        }
        
        public ValueBridge ForReMax
        {
            get => _forBody.ForReMax;
            set => _forBody.ForReMax = value;
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
            _forBody = new EnumerationParameters(Constants.GlobalIndexerVariable, collection);
            _postForBody = new List<StatementSyntax>();
            
            _enumerations = new List<EnumerationParameters>{_forBody};
            
            Collection = collection;
            ReturnType = returnType;
            Chain = chain;
            Node = node;
        }

        public void PreForAdd(StatementBridge _) => _preForBody.Add(_);
        public void ForAdd(StatementBridge _)
        {
            _enumerations.Where(x => !x.Finished)
                .ForEach(x => x.Body.Add((StatementSyntaxBridge) _));
        }
        public void PostForAdd(StatementBridge _) => _postForBody.Add(_);
        
        public EnumerationParameters AddFor(ExpressionSyntax collection)
        {
            var oldBody = _forBody;
            _forBody = new EnumerationParameters(Constants.GlobalIndexerVariable, collection);
            _enumerations.Add(_forBody);
            return oldBody;
        }
        
        public EnumerationParameters CopyFor()
        {
            var oldBody = _forBody;
            _forBody = _forBody.Copy();
            _enumerations.Add(_forBody);
            return oldBody;
        }
        
        public EnumerationParameters CopyForReference()
        {
            var oldBody = _forBody;
            _forBody = _forBody.CopyReference();
            _enumerations.Add(_forBody);
            return oldBody;
        }

        public IEnumerable<StatementSyntax> GetMethodBody()
        {
            if (_enumerations.Count == 1 && _forBody.Body.Count == 0) return _preForBody.Concat(_postForBody);
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
        public VariableBridge CreateLocalVariable(string name, ValueBridge value)
        {
            var variable = name + _variableIndex++;
            PreForAdd(VariableExtensions.LocalVariableCreation(name, value));
            return variable;
        }
        public VariableBridge CreateLocalVariable(string name, TypeBridge type, ValueBridge value)
        {
            var variable = name + _variableIndex++;
            PreForAdd(VariableExtensions.LocalVariableCreation(name, type, value));
            return variable;
        }

        public void Dispose() => RewriteParametersFactory.ReturnParameters(this);
    }
}