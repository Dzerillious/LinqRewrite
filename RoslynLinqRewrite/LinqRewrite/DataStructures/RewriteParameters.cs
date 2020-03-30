using System;
using LinqRewrite.Core;
using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Extensions;
using LinqRewrite.Services;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax; 
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.DataStructures
{
    public class RewriteParameters : IDisposable
    {
        public RewriteService Rewrite { get; }
        public CodeCreationService Code { get; }
        public RewriteDataService Data { get; }


        public InvocationExpressionSyntax Node { get; private set; }
        public CollectionValueBridge FirstCollection { get; set; }
        public CollectionValueBridge CurrentCollection { get; set; }
        public List<LinqStep> RewriteChain { get; private set; }


        public TypeBridge ReturnType { get; private set; }
        public ValueBridge ResultSize { get; set; }
        public ValueBridge SourceSize { get; set; }
        public TypedValueBridge LastValue { get; set; }

        private readonly List<IteratorParameters> _resultIterators = new List<IteratorParameters>();
        private readonly List<StatementSyntax> _initialStatements = new List<StatementSyntax>();
        private readonly List<StatementSyntax> _finalStatements = new List<StatementSyntax>();
        public List<IteratorParameters> Iterators { get; } = new List<IteratorParameters>();
        public IEnumerable<IteratorParameters> IncompleteIterators => Iterators.Where(x => !x.Complete);
        public IteratorParameters CurrentIterator { get; set; }
        
        public List<LocalVariable> Variables { get; } = new List<LocalVariable>();
        
        public ExpressionSyntax SimpleRewrite { get; set; }
        public bool WrapWithTry { get; set; }
        public bool IsReversed { get; set; }
        public bool HasResultMethod { get; set; }
        public bool NotRewrite { get; set; }

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
                Indexer = null;
            }
        }

        public LocalVariable CurrentIndexer { get; private set; }
        public LocalVariable Indexer
        {
            get
            {
                var iterator = IncompleteIterators.FirstOrDefault();
                if (CurrentIndexer != null || iterator?.CurrentIndexer != null)
                {
                    var indexer = iterator.CurrentIndexer;
                    if (indexer == null) return CurrentIndexer;

                    IncompleteIterators.Where(x => x.CurrentIndexer == null).ForEach(x =>
                    {
                        x.CurrentIndexer = indexer;
                        x.ForEnd.Add((StatementBridge) indexer.PostIncrement());
                    });
                    return CurrentIndexer = indexer;
                }

                var indexerVariable = GlobalVariable(Int, 0);
                indexerVariable.IsGlobal = true;
                    
                IncompleteIterators.ForEach(x => x.CurrentIndexer = indexerVariable);
                ForEndAdd(indexerVariable.PostIncrement());

                return CurrentIndexer = indexerVariable;
            }
            set
            {
                if (value != null) throw new NotImplementedException("Implemented only for setting null");
                
                var iterator = IncompleteIterators.FirstOrDefault();
                if (iterator?.CurrentIndexer != null) iterator.CurrentIndexer.IsGlobal = false;
                CurrentIndexer = null;
                IncompleteIterators.ForEach(x => x.CurrentIndexer = null);
            }
        }

        public LocalVariable GetIndexer(TypeBridge type)
        {
            var iterator = IncompleteIterators.FirstOrDefault();
            if (CurrentIndexer != null || iterator?.CurrentIndexer != null)
            {
                var indexer = iterator.CurrentIndexer;
                if (indexer == null) return CurrentIndexer;

                IncompleteIterators.Where(x => x.CurrentIndexer == null).ForEach(x =>
                {
                    x.CurrentIndexer = indexer;
                    x.ForEnd.Add((StatementBridge) indexer.PostIncrement());
                });
                return CurrentIndexer = indexer;
            }

            var indexerVariable = GlobalVariable(type, 0);
            indexerVariable.IsGlobal = true;
                    
            IncompleteIterators.ForEach(x => x.CurrentIndexer = indexerVariable);
            ForEndAdd(indexerVariable.PostIncrement());

            return CurrentIndexer = indexerVariable;
        }

        public ValueBridge ForMin
        {
            get => CurrentIterator.ForMin;
            set => CurrentIterator.ForMin = value;
        }
        
        public ValueBridge ForMax
        {
            get => CurrentIterator.ForMax;
            set => CurrentIterator.ForMax = value;
        }
        
        public ValueBridge ForReMin
        {
            get => CurrentIterator.ForReverseMin;
            set => CurrentIterator.ForReverseMin = value;
        }
        
        public ValueBridge ForReMax
        {
            get => CurrentIterator.ForReverseMax;
            set => CurrentIterator.ForReverseMax = value;
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
            _initialStatements.Clear();
            _finalStatements.Clear();
            Iterators.Clear();
            Variables.Clear();
            _resultIterators.Clear();
            CurrentIterator = null;
            
            var collectionType = collection.GetType(this);
            FirstCollection = CurrentCollection = new CollectionValueBridge(collection.ItemType(this), collectionType, collection.Count(this), collection);
            SourceSize = ResultSize = FirstCollection.Count;

            ReturnType = returnType;
            RewriteChain = chain;
            Node = node;

            HasResultMethod = false;
            NotRewrite = false;
            IsReversed = false;
            ListEnumeration = true;
            CurrentIndexer = null;
            NotRewrite = false;
            WrapWithTry = false;

            SimpleRewrite = null;
            LastValue = null;
        }

        public void InitialAdd(StatementBridge _)
        {
            _initialStatements.Add(_);
        }

        public void PreUseAdd(StatementBridge _)
        {
            if (_resultIterators.Count == 0) _initialStatements.Add(_);
            else _resultIterators.First(x => !x.Complete).PreFor.Add(_);
        }

        public void PreForAdd(StatementBridge _) => CurrentIterator.PreFor.Add(_);
        public void ForAdd(StatementBridge _)
        {
            IncompleteIterators.ForEach(x => x.ForBody.Add(_));
        }
        public void ForEndAdd(StatementBridge _)
        {
            IncompleteIterators.ForEach(x => x.ForEnd.Add(_));
        }
        public void LastForAdd(StatementBridge _) => CurrentIterator.BodyAdd(_);
        public void FinalAdd(StatementBridge _) => _finalStatements.Add(_);
        
        public IteratorParameters AddIterator()
        {
            var oldBody = CurrentIterator;
            CurrentIterator = new IteratorParameters(this);
            Iterators.Add(CurrentIterator);
            _resultIterators.Add(CurrentIterator);
            return oldBody;
        }
        
        public IteratorParameters AddIterator(RewrittenValueBridge collection)
        {
            var oldBody = CurrentIterator;
            CurrentIterator = new IteratorParameters(this, collection);
            Iterators.Add(CurrentIterator);
            _resultIterators.Add(CurrentIterator);
            return oldBody;
        }
        
        public IteratorParameters CopyIterator()
        {
            var oldBody = CurrentIterator;
            CurrentIterator = CurrentIterator.Copy();
            Iterators.Add(CurrentIterator);
            _resultIterators.Add(CurrentIterator);
            return oldBody;
        }

        public IEnumerable<StatementSyntax> GetMethodBody()
        {
            if (Iterators.Count == 0) return _initialStatements.Concat(_finalStatements);
            var result = new List<StatementSyntax>();
            if (IsReversed)
            {
                for (var i = _resultIterators.Count - 1; i >= 0; i--)
                {
                    var statement = _resultIterators[i].GetStatementSyntax(this);
                    result.AddRange(_resultIterators[i].PreFor);
                    if (statement != null) result.Add(statement);
                }
            }
            else for (var i = 0; i < _resultIterators.Count; i++)
            {
                var statement = _resultIterators[i].GetStatementSyntax(this);
                result.AddRange(_resultIterators[i].PreFor);
                if (statement != null) result.Add(statement);
            }

            if (WrapWithTry)
            {
                result = new List<StatementSyntax>(_initialStatements) {TryF(Block(result), Block(_finalStatements))};
            }
            else
            {
                result.InsertRange(0, _initialStatements);
                result.AddRange(_finalStatements);
            }
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
            
            InitialAdd(LocalVariableCreation(variable, type));
            PreUseAdd(((ValueBridge)variable).Assign(initial));
            return created;
        }
        
        public LocalVariable LocalVariable(TypedValueBridge value)
        {
            var variable = "v" + _variableIndex++;
            var found = Variables.FirstOrDefault(x => x.Type.Equals(value.Type) && !x.IsGlobal && !x.IsUsed);
            if (found != null)
            {
                found.IsUsed = true;
                return found;
            }
            var created = new LocalVariable(variable, value.Type);
            Variables.Add(created);
            
            InitialAdd(LocalVariableCreation(variable, value.Type));
            PreUseAdd(((ValueBridge)variable).Assign(value));
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
            
            InitialAdd(LocalVariableCreation(variable, type));
            PreUseAdd(((ValueBridge)variable).Assign(initial));
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

        public LocalVariable AddParameter(TypeBridge type, ExpressionSyntax value)
        {
            var variable = "v" + _variableIndex++;
            var created = new LocalVariable(variable, type);
            Variables.Add(created);
            
            Data.CurrentMethodParams.Add(CreateParameter(variable, type));
            Data.CurrentMethodArguments.Add(Argument(value));

            return created;
        }

        public bool CanSimpleRewrite() => !ModifiedEnumeration && ResultSize != null;

        public void Dispose() => RewriteParametersFactory.ReturnParameters(this);
    }
}