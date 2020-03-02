using System;
using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Extensions;
using LinqRewrite.Services;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SimpleCollections;
using static LinqRewrite.Extensions.VariableExtensions;

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

        public TypedValueBridge Last { get; set; }

        
        private List<IteratorParameters> _enumerations;
        private List<StatementSyntax> _initial;
        public IteratorParameters Body;
        private List<StatementSyntax> _final;

        public List<LocalVariable> Variables = new List<LocalVariable>();

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

        public LocalVariable CurrentIndexer { get; set; }
        public LocalVariable Indexer
        {
            get
            {
                if (CurrentIndexer != null) return CurrentIndexer;

                var indexerVariable = CreateGlobalVariable("__indexer", Int, -1);
                ForAdd(indexerVariable.PreIncrement());

                return CurrentIndexer = indexerVariable;
            }
        }

        public ValueBridge ForMin
        {
            get => Body.ForMin;
            set => Body.ForMin = value;
        }
        
        public ValueBridge ForMax
        {
            get => Body.ForMax;
            set => Body.ForMax = value;
        }
        
        public ValueBridge ForReMin
        {
            get => Body.ForReMin;
            set => Body.ForReMin = value;
        }
        
        public ValueBridge ForReMax
        {
            get => Body.ForReMax;
            set => Body.ForReMax = value;
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
            _initial = new List<StatementSyntax>();
            Body = new IteratorParameters(this, collection);
            _final = new List<StatementSyntax>();
            
            _enumerations = new List<IteratorParameters>{Body};
            
            Collection = collection;
            ReturnType = returnType;
            Chain = chain;
            Node = node;
        }

        public void InitialAdd(StatementBridge _) => _initial.Add(_);
        public void PreForAdd(StatementBridge _) => Body.Pre.Add(_);
        public void ForAdd(StatementBridge _)
        {
            _enumerations.Where(x => !x.Complete)
                .ForEach(x => x.Body.Add(_));
        }
        public void LastForAdd(StatementBridge _) => Body.BodyAdd(_);
        public void FinalAdd(StatementBridge _) => _final.Add(_);
        
        public IteratorParameters AddIterator(ExpressionSyntax collection)
        {
            var oldBody = Body;
            Body = new IteratorParameters(this, collection);
            _enumerations.Add(Body);
            return oldBody;
        }
        
        public IteratorParameters CopyIterator()
        {
            var oldBody = Body;
            Body = Body.Copy();
            _enumerations.Add(Body);
            return oldBody;
        }
        
        public IteratorParameters CopyIteratorReference()
        {
            var oldBody = Body;
            Body = Body.CopyReference();
            _enumerations.Add(Body);
            return oldBody;
        }

        public IEnumerable<StatementSyntax> GetMethodBody()
        {
            if (_enumerations.Count == 1 && Body.Body.Count == 0) return _initial.Concat(_final);
            var result = new List<StatementSyntax>();
            if (IsReversed)
            {
                for (var i = _enumerations.Count - 1; i >= 0; i--)
                {
                    var statement = _enumerations[i].GetStatementSyntax(this);
                    result.AddRange(_enumerations[i].Pre);
                    result.Add(statement);
                }
            }
            else
            {
                for (var i = 0; i < _enumerations.Count; i++)
                {
                    var statement = _enumerations[i].GetStatementSyntax(this);
                    result.AddRange(_enumerations[i].Pre);
                    result.Add(statement);
                }
            }
            
            _initial.AddRange(result);
            _initial.AddRange(_final);
            return _initial;
        }

        private int _variableIndex;
        public string GetVariableName(string name) => name + _variableIndex++;
        
        public LocalVariable CreateGlobalVariable(string name, TypeSyntax type)
        {
            var variable = name + _variableIndex++;
            var created = new LocalVariable(variable, type) {IsGlobal = true};
            Variables.Add(created);
            
            InitialAdd(LocalVariableCreation(variable, type));
            return created;
        }
        
        public LocalVariable CreateGlobalVariable(string name, TypeSyntax type, ValueBridge initial)
        {
            var variable = name + _variableIndex++;
            var created = new LocalVariable(variable, type) {IsGlobal = true};
            Variables.Add(created);
            
            InitialAdd(LocalVariableCreation(variable, type, initial));
            return created;
        }
        
        public LocalVariable CreateLocalVariable(string name, TypeBridge type, ValueBridge initial)
        {
            var variable = name + _variableIndex++;
            var found = Variables.FirstOrDefault(x => x.Type.Equals(type) && !x.IsGlobal && !x.IsUsed);
            if (found != null)
            {
                found.IsUsed = true;
                return found;
            }
            var created = new LocalVariable(variable, type);
            Variables.Add(created);
            
            InitialAdd(LocalVariableCreation(variable, type));
            PreForAdd(((VariableBridge)variable).Assign(initial));
            return created;
        }
        
        public LocalVariable CreateLocalVariable(string name, TypeBridge type)
        {
            var found = Variables.FirstOrDefault(x => type.ToString().Equals(x.Type.ToString()) && !x.IsGlobal && !x.IsUsed);
            if (found != null)
            {
                found.IsUsed = true;
                return found;
            }
            var variable = name + _variableIndex++;
            var created = new LocalVariable(variable, type);
            Variables.Add(created);

            InitialAdd(LocalVariableCreation(variable, type));
            return created;
        }

        public void Dispose() => RewriteParametersFactory.ReturnParameters(this);
    }
}