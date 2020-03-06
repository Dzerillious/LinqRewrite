using System;
using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Extensions;
using LinqRewrite.Services;
using Microsoft.CodeAnalysis;
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
        public ValueBridge Collection { get; set; }
        public List<LinqStep> Chain { get; set; }

        
        public TypeSyntax ReturnType { get; set; }

        
        public ValueBridge ResultSize { get; set; }
        public ValueBridge SourceSize { get; set; }

        public TypedValueBridge Last { get; set; }


        public List<IteratorParameters> Enumerations;
        private List<StatementSyntax> _initial;
        public IteratorParameters Body;
        private List<StatementSyntax> _final;

        public List<LocalVariable> Variables = new List<LocalVariable>();

        public bool IsReversed;
        public bool HasResultMethod;
        public bool NotRewrite;

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
                
                if (!value || CurrentIndexer == null) return;
                ResultSize = null;
                CurrentIndexer = null;
            }
        }

        public LocalVariable CurrentIndexer { get; set; }
        public LocalVariable Indexer
        {
            get
            {
                if (CurrentIndexer != null) return CurrentIndexer;

                var indexerVariable = GlobalVariable(Int, "__indexer", -1);
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
            _final = new List<StatementSyntax>();
            Enumerations = new List<IteratorParameters>();
            
            Collection = collection;
            ReturnType = returnType;
            Chain = chain;
            Node = node;
        }

        public void InitialAdd(StatementBridge _) => _initial.Add(_);
        public void PreForAdd(StatementBridge _) => Body.Pre.Add(_);
        public void ForAdd(StatementBridge _)
        {
            Enumerations.Where(x => !x.Complete)
                .ForEach(x => x.Body.Add(_));
        }
        public void LastForAdd(StatementBridge _) => Body.BodyAdd(_);
        public void FinalAdd(StatementBridge _) => _final.Add(_);
        
        public IteratorParameters AddIterator(ExpressionSyntax collection)
        {
            var oldBody = Body;
            Body = new IteratorParameters(this, collection);
            Enumerations.Add(Body);
            return oldBody;
        }
        
        public IteratorParameters CopyIterator()
        {
            var oldBody = Body;
            Body = Body.Copy();
            Enumerations.Add(Body);
            return oldBody;
        }
        
        public IteratorParameters CopyIteratorReference()
        {
            var oldBody = Body;
            Body = Body.CopyReference();
            Enumerations.Add(Body);
            return oldBody;
        }

        public IEnumerable<StatementSyntax> GetMethodBody()
        {
            if (Enumerations.Count == 1 && Body.Body.Count == 0) return _initial.Concat(_final);
            var result = new List<StatementSyntax>();
            if (IsReversed)
            {
                for (var i = Enumerations.Count - 1; i >= 0; i--)
                {
                    var statement = Enumerations[i].GetStatementSyntax(this);
                    result.AddRange(Enumerations[i].Pre);
                    result.Add(statement);
                }
            }
            else
            {
                for (var i = 0; i < Enumerations.Count; i++)
                {
                    var statement = Enumerations[i].GetStatementSyntax(this);
                    result.AddRange(Enumerations[i].Pre);
                    result.Add(statement);
                }
            }
            
            _initial.AddRange(result);
            _initial.AddRange(_final);
            return _initial;
        }

        private int _variableIndex;
        public string GetVariableName(string name) => name + _variableIndex++;
        
        public LocalVariable GlobalVariable(TypeSyntax type, string name)
        {
            var variable = name + _variableIndex++;
            var created = new LocalVariable(variable, type) {IsGlobal = true};
            Variables.Add(created);
            
            InitialAdd(LocalVariableCreation(variable, type));
            return created;
        }
        
        public LocalVariable GlobalVariable(TypeSyntax type, string name, ValueBridge initial)
        {
            var variable = name + _variableIndex++;
            var created = new LocalVariable(variable, type) {IsGlobal = true};
            Variables.Add(created);
            
            InitialAdd(LocalVariableCreation(variable, type, initial));
            return created;
        }
        
        public LocalVariable LocalVariable(TypeBridge type, string name, ValueBridge initial)
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
            
            InitialAdd(LocalVariableCreation(variable, type, initial));
            return created;
        }
        
        public LocalVariable LocalVariable(TypeBridge type, string name)
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