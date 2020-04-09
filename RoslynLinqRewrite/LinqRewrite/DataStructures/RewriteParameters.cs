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

        private ValueBridge _resultSize;
        public ValueBridge ResultSize
        {
            get => _resultSize;
            set => _resultSize = value?.Value == null 
                ? null : ExpressionSimplifier.Simplify(value);
        }

        public ValueBridge CalculatedResultsSize => ResultSize ?? Indexer;
        
        private ValueBridge _sourceSize;
        public ValueBridge SourceSize
        {
            get => _sourceSize;
            set => _sourceSize = value?.Value == null 
                ? null : ExpressionSimplifier.Simplify(value);
        }

        private TypedValueBridge _lastValue;
        public TypedValueBridge LastValue
        {
            get => _lastValue;
            set => _lastValue = value?.Value == null 
                ? null : new TypedValueBridge(value.Type, ExpressionSimplifier.Simplify(value));
        }

        public readonly List<IteratorParameters> ResultIterators = new List<IteratorParameters>();
        private readonly List<StatementSyntax> _initialStatements = new List<StatementSyntax>();
        private readonly List<StatementSyntax> _finalStatements = new List<StatementSyntax>();
        private readonly List<StatementSyntax> _resultStatements = new List<StatementSyntax>();
        public List<IteratorParameters> Iterators { get; } = new List<IteratorParameters>();
        public IEnumerable<IteratorParameters> IncompleteIterators => Iterators.Where(x => !x.Complete);
        public IteratorParameters CurrentIterator { get; set; }
        
        public List<LocalVariable> Variables { get; } = new List<LocalVariable>();
        
        public bool WrapWithTry { get; set; }
        public bool IsReversed { get; set; }
        public bool HasResultMethod { get; set; }
        public bool NotRewrite { get; set; }
        public bool Unchecked { get; set; }

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

        private bool _simpleEnumeration;
        public bool SimpleEnumeration
        {
            get => _simpleEnumeration;
            set
            {
                _simpleEnumeration = value;
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
                SimpleEnumeration = false;
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
            set => CurrentIterator.ForMin = value?.Value == null 
                ? null : ExpressionSimplifier.Simplify(value);
        }
        
        public ValueBridge ForMax
        {
            get => CurrentIterator.ForMax;
            set => CurrentIterator.ForMax = value?.Value == null 
                ? null : ExpressionSimplifier.Simplify(value);
        }
        
        public ValueBridge ForReMin
        {
            get => CurrentIterator.ForReverseMin;
            set => CurrentIterator.ForReverseMin = value?.Value == null 
                ? null : ExpressionSimplifier.Simplify(value);
        }
        
        public ValueBridge ForReMax
        {
            get => CurrentIterator.ForReverseMax;
            set => CurrentIterator.ForReverseMax = value?.Value == null 
                ? null : ExpressionSimplifier.Simplify(value);
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
            _resultStatements.Clear();
            Iterators.Clear();
            Variables.Clear();
            ResultIterators.Clear();
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
            SimpleEnumeration = true;
            CurrentIndexer = null;
            NotRewrite = false;
            WrapWithTry = false;
            Unchecked = false;

            LastValue = null;
        }

        public void InitialAdd(StatementBridge _)
        {
            _initialStatements.Add(_);
        }

        public void PreUseAdd(StatementBridge _)
        {
            if (ResultIterators.Count == 0) _initialStatements.Add(_);
            else ResultIterators.First(x => !x.Complete).PreFor.Add(_);
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
        public void CurrentForAdd(StatementBridge _) => CurrentIterator.BodyAdd(_);
        public void FinalAdd(StatementBridge _) => _finalStatements.Add(_);
        public void ResultAdd(StatementBridge _) => _resultStatements.Add(_);
        
        public IteratorParameters AddIterator()
        {
            var oldBody = CurrentIterator;
            CurrentIterator = new IteratorParameters(this);
            Iterators.Add(CurrentIterator);
            ResultIterators.Add(CurrentIterator);
            return oldBody;
        }
        
        public IteratorParameters AddIterator(RewrittenValueBridge collection)
        {
            var oldBody = CurrentIterator;
            CurrentIterator = new IteratorParameters(this, collection);
            Iterators.Add(CurrentIterator);
            ResultIterators.Add(CurrentIterator);
            return oldBody;
        }
        
        public IteratorParameters InsertIterator()
        {
            var oldBody = CurrentIterator;
            CurrentIterator = new IteratorParameters(this);
            Iterators.Insert(0, CurrentIterator);
            ResultIterators.Insert(0, CurrentIterator);
            return oldBody;
        }
        
        public IteratorParameters InsertIterator(RewrittenValueBridge collection)
        {
            var oldBody = CurrentIterator;
            CurrentIterator = new IteratorParameters(this, collection);
            Iterators.Insert(0, CurrentIterator);
            ResultIterators.Insert(0, CurrentIterator);
            return oldBody;
        }
        
        public IteratorParameters CopyIterator()
        {
            var oldBody = CurrentIterator;
            CurrentIterator = CurrentIterator.Copy();
            Iterators.Add(CurrentIterator);
            ResultIterators.Add(CurrentIterator);
            return oldBody;
        }

        public IEnumerable<StatementSyntax> GetMethodBody()
        {
            if (Iterators.Count == 0) return _initialStatements.Concat(_finalStatements).Concat(_resultStatements);
            var result = new List<StatementSyntax>();
            if (IsReversed)
            {
                for (var i = ResultIterators.Count - 1; i >= 0; i--)
                {
                    var statement = ResultIterators[i].GetStatementSyntax(this);
                    result.AddRange(ResultIterators[i].PreFor);
                    if (statement != null) result.Add(statement);
                    result.AddRange(ResultIterators[i].PostFor);
                }
            }
            else for (var i = 0; i < ResultIterators.Count; i++)
            {
                var statement = ResultIterators[i].GetStatementSyntax(this);
                result.AddRange(ResultIterators[i].PreFor);
                if (statement != null) result.Add(statement);
                result.AddRange(ResultIterators[i].PostFor);
            }

            if (WrapWithTry)
            {
                result = _initialStatements.Concat(new []{TryF(Block(result), Block(_finalStatements))}).Concat(_resultStatements).ToList();
            }
            else
            {
                result.InsertRange(0, _initialStatements);
                result.AddRange(_finalStatements);
                result.AddRange(_resultStatements);
            }
            return result;
        }

        private int _variableIndex;
        public LocalVariable GlobalVariable(TypeSyntax type)
        {
            var variable = "v" + _variableIndex++;
            var created = new LocalVariable(variable, type) {IsGlobal = true, IsUsed = true};
            Variables.Add(created);
            
            InitialAdd(LocalVariableCreation(variable, type));
            SimpleEnumeration = false;
            return created;
        }
        
        public LocalVariable GlobalVariable(TypeSyntax type, ValueBridge initial)
        {
            var variable = "v" + _variableIndex++;
            var created = new LocalVariable(variable, type) {IsGlobal = true, IsUsed = true};
            Variables.Add(created);
            
            InitialAdd(LocalVariableCreation(variable, type));
            PreUseAdd(((ValueBridge)variable).Assign(initial));
            SimpleEnumeration = false;
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
            SimpleEnumeration = false;
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
            SimpleEnumeration = false;
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
            SimpleEnumeration = false;
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
        
        public bool AssertResultSizeGreaterEqual(ValueBridge smaller, bool preCheck = false)
            => AssertLesserEqual(smaller, CalculatedResultsSize, ResultSize != null, preCheck);
        
        public bool AssertResultSizeGreater(ValueBridge smaller, bool preCheck = false)
            => AssertLesser(smaller, CalculatedResultsSize, ResultSize != null, preCheck);
        
        public bool AssertResultSizeLesserEqual(ValueBridge bigger, bool preCheck = false)
            => AssertLesserEqual(CalculatedResultsSize, bigger, ResultSize != null, preCheck);
        
        public bool AssertResultSizeLesser(ValueBridge bigger, bool preCheck = false)
            => AssertLesser(CalculatedResultsSize, bigger, ResultSize != null, preCheck);

        public bool AssertGreaterEqual(ValueBridge bigger, ValueBridge smaller, bool initialCheck = true, bool preCheck = false)
            => AssertLesserEqual(smaller, bigger, initialCheck, preCheck);

        public bool AssertGreater(ValueBridge bigger, ValueBridge smaller, bool initialCheck = true, bool preCheck = false)
            => AssertLesser(smaller, bigger, initialCheck, preCheck);

        public bool AssertLesserEqual(ValueBridge smaller, ValueBridge bigger, bool initialCheck = true, bool preCheck = false)
        {
            if (Unchecked) return true;
            var biggerPass = ExpressionSimplifier.TryGetDouble(bigger, out var biggerD);
            var smallerPass = ExpressionSimplifier.TryGetDouble(smaller, out var smallerD);
            
            if (biggerPass && smallerPass)
            {
                if (smallerD <= biggerD) return true;
                InitialAdd(Throw("System.InvalidOperationException", "Index out of range"));
                Iterators.ForEach(x => x.IgnoreIterator = true);
                return false;
            }
            if (preCheck) return true;
            if (initialCheck) InitialAdd(If(smaller > bigger, Throw("System.InvalidOperationException", "Index out of range")));
            else FinalAdd(If(smaller > bigger, Throw("System.InvalidOperationException", "Index out of range")));
            return true;
        }

        public bool AssertLesser(ValueBridge smaller, ValueBridge bigger, bool initialCheck = true, bool preCheck = false)
        {
            if (Unchecked) return true;
            var biggerPass = ExpressionSimplifier.TryGetDouble(bigger, out var biggerD);
            var smallerPass = ExpressionSimplifier.TryGetDouble(smaller, out var smallerD);
            
            if (biggerPass && smallerPass)
            {
                if (smallerD < biggerD) return true;
                InitialAdd(Throw("System.InvalidOperationException", "Index out of range"));
                Iterators.ForEach(x => x.IgnoreIterator = true);
                return false;
            }
            if (preCheck) return true;
            if (initialCheck) InitialAdd(If(smaller >= bigger, Throw("System.InvalidOperationException", "Index out of range")));
            else FinalAdd(If(smaller >= bigger, Throw("System.InvalidOperationException", "Index out of range")));
            return true;
        }

        public bool AssertNotNull(ValueBridge notNull, bool preCheck = false)
        {
            if (Unchecked) return true;
            if (notNull.ToString() == "null")
            {
                InitialAdd(Throw("System.InvalidOperationException", "Invalid null object"));
                Iterators.ForEach(x => x.IgnoreIterator = true);
                return false;
            }
            if (preCheck) return true;
            InitialAdd(If(notNull.IsEqual(null), Throw("System.InvalidOperationException", "Invalid null object")));
            return true;
        }

        public LocalVariable TryGetVariable(TypedValueBridge value)
        {
            if (value?.Value?.Value == null) return null;
            var expression = value.Expression;
            while (expression is ParenthesizedExpressionSyntax parenthesizedExpressionSyntax)
                expression = parenthesizedExpressionSyntax.Expression;
            return Variables.FirstOrDefault(x => x.Name == expression.ToString());
        }

        public ValueBridge CurrentMin => Iterators.FirstOrDefault() == null
            ? 0 : IsReversed
                ? CurrentIterator.ForReverseMax
                : CurrentIterator.ForMin;

        public ValueBridge CurrentMax => Iterators.FirstOrDefault() == null
            ? CurrentCollection[CurrentCollection.Count - 1] : IsReversed
                ? CurrentIterator.ForReverseMin - 1
                : CurrentIterator.ForMax - 1;
    }
}