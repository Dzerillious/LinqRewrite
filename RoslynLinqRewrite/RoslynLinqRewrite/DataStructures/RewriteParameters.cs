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
        public CollectionValueBridge FirstCollection { get; set; }
        public CollectionValueBridge CurrentCollection { get; set; }
        public List<LinqStep> Chain { get; set; }

        
        public TypeBridge ReturnType { get; set; }
        public ValueBridge ResultSize { get; set; }
        public ValueBridge SourceSize { get; set; }
        public TypedValueBridge Last { get; set; }


        public List<IteratorParameters> Enumerations;
        public IteratorParameters Iterator;
        private List<StatementSyntax> _final;
        public readonly List<LocalVariable> Variables = new List<LocalVariable>();

        public bool IsReversed;
        public bool HasResultMethod;
        public bool NotRewrite;

        private bool _listEnumeration;
        public bool ListEnumeration
        {
            get => _listEnumeration;
            set
            {
                _listEnumeration = value;

                if (!value) return;
                ModifiedEnumeration = false;
            }
        }

        private bool _modifiedEnumeration;
        public bool ModifiedEnumeration
        {
            get => _modifiedEnumeration;
            set
            {
                _modifiedEnumeration = value;
                
                if (!value) return;
                ListEnumeration = false;
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

                var indexerVariable = GlobalVariable(Int, -1);
                ForAdd(indexerVariable.PreIncrement());

                return CurrentIndexer = indexerVariable;
            }
        }

        public ValueBridge ForMin
        {
            get => Iterator.ForMin;
            set => Iterator.ForMin = value;
        }
        
        public ValueBridge ForMax
        {
            get => Iterator.ForMax;
            set => Iterator.ForMax = value;
        }
        
        public ValueBridge ForReMin
        {
            get => Iterator.ForReMin;
            set => Iterator.ForReMin = value;
        }
        
        public ValueBridge ForReMax
        {
            get => Iterator.ForReMax;
            set => Iterator.ForReMax = value;
        }
        
        public SemanticModel Semantic => Data.Semantic;
        
        public RewriteParameters()
        {
            Rewrite = RewriteService.Instance;
            Code = CodeCreationService.Instance;
            Data = RewriteDataService.Instance;
        }
        
        public void SetData(ValueBridge collection, TypeSyntax returnType, List<LinqStep> chain, InvocationExpressionSyntax node)
        {
            _final = new List<StatementSyntax>();
            Enumerations = new List<IteratorParameters>();
            
            FirstCollection = CurrentCollection = new CollectionValueBridge(collection.ItemType(this), collection.GetType(this), collection.Count(this), collection);
            ReturnType = returnType;
            Chain = chain;
            Node = node;

            HasResultMethod = false;
            NotRewrite = false;
            IsReversed = false;
            ListEnumeration = true;
        }

        public void InitialAdd(StatementBridge _) => Enumerations.First().Pre.Add(_);
        public void PreForAdd(StatementBridge _) => Iterator.Pre.Add(_);
        public void ForAdd(StatementBridge _)
        {
            Enumerations.Where(x => !x.Complete)
                .ForEach(x => x.Body.Add(_));
        }
        public void LastForAdd(StatementBridge _) => Iterator.BodyAdd(_);
        public void FinalAdd(StatementBridge _) => _final.Add(_);
        
        public IteratorParameters AddIterator(ExpressionSyntax collection)
        {
            var oldBody = Iterator;
            Iterator = new IteratorParameters(this, collection);
            Enumerations.Add(Iterator);
            return oldBody;
        }
        
        public IteratorParameters CopyIterator()
        {
            var oldBody = Iterator;
            Iterator = Iterator.Copy();
            Enumerations.Add(Iterator);
            return oldBody;
        }

        public IEnumerable<StatementSyntax> GetMethodBody()
        {
            if (Enumerations.Count == 0) return _final;
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
            
            result.AddRange(_final);
            return result;
        }

        private int _variableIndex;
        public LocalVariable GlobalVariable(TypeSyntax type)
        {
            var variable = "v" + _variableIndex++;
            var created = new LocalVariable(variable, type) {IsGlobal = true};
            Variables.Add(created);
            
            InitialAdd(LocalVariableCreation(variable, type));
            return created;
        }
        
        public LocalVariable GlobalVariable(TypeSyntax type, ValueBridge initial)
        {
            var variable = "v" + _variableIndex++;
            var created = new LocalVariable(variable, type) {IsGlobal = true};
            Variables.Add(created);
            
            InitialAdd(LocalVariableCreation(variable, type, initial));
            return created;
        }
        
        public LocalVariable LocalVariable(TypeBridge type, ValueBridge initial)
        {
            var variable = "v" + _variableIndex++;
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
        
        public LocalVariable LocalVariable(TypeBridge type)
        {
            var found = Variables.FirstOrDefault(x => type.ToString().Equals(x.Type.ToString()) && !x.IsGlobal && !x.IsUsed);
            if (found != null)
            {
                found.IsUsed = true;
                return found;
            }
            var variable = "v" + _variableIndex++;
            var created = new LocalVariable(variable, type);
            Variables.Add(created);

            InitialAdd(LocalVariableCreation(variable, type));
            return created;
        }

        public void Dispose() => RewriteParametersFactory.ReturnParameters(this);
    }
}