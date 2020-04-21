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

        public ValueBridge GetResultSize() => ResultSize ?? Indexer;
        private ValueBridge _resultSize;
        public ValueBridge ResultSize
        {
            get => _resultSize;
            set => _resultSize = value?.Value == null ? null : value.Simplify();
        }
        
        private ValueBridge _sourceSize;
        public ValueBridge SourceSize
        {
            get => _sourceSize;
            set => _sourceSize = value?.Value == null ? null : value.Simplify();
        }

        private TypedValueBridge _lastValue;
        public TypedValueBridge LastValue
        {
            get => _lastValue;
            set => _lastValue = value?.Value == null ? null : new TypedValueBridge(value.Type, value.Simplify());
        }

        private readonly List<StatementSyntax> _initialStatements = new List<StatementSyntax>();
        private readonly List<StatementSyntax> _finalStatements = new List<StatementSyntax>();
        private readonly List<StatementSyntax> _resultStatements = new List<StatementSyntax>();
        public readonly List<IteratorParameters> ResultIterators = new List<IteratorParameters>();
        public List<IteratorParameters> Iterators { get; } = new List<IteratorParameters>();
        public IEnumerable<IteratorParameters> IncompleteIterators => Iterators.Where(x => !x.Complete);
        public IteratorParameters CurrentIterator { get; set; }
        public List<LocalVariable> Variables { get; } = new List<LocalVariable>();
        
        public bool WrapWithTry { get; set; }
        public bool HasResultMethod { get; set; }
        public bool NotRewrite { get; set; }
        public bool Unchecked { get; set; }
        public bool Error { get; set; }

        private bool _listEnumeration;
        public bool ListEnumeration
        {
            get => _listEnumeration;
            set
            {
                _listEnumeration = value;
                if (value)
                {
                    ModifiedEnumeration = false;
                    return;
                }
                IncompleteIterators.ForEach(x => x.ListEnumeration = false);
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
                if (CurrentIndexer != null || iterator?.Indexer != null)
                {
                    var indexer = iterator.Indexer;
                    IncompleteIterators.Where(x => x.Indexer == null).ForEach(x =>
                    {
                        x.Indexer = indexer;
                        x.ForEnd.Add((StatementBridge) indexer.PostIncrement());
                    });
                    return CurrentIndexer = indexer;
                }

                var indexerVariable = GlobalVariable(Int, 0);
                indexerVariable.IsGlobal = true;
                    
                IncompleteIterators.ForEach(x => x.Indexer = indexerVariable);
                ForEndAdd(indexerVariable.PostIncrement());

                return CurrentIndexer = indexerVariable;
            }
            set
            {
                if (value != null) throw new NotImplementedException("Implemented only for setting null");
                
                CurrentIndexer = null;
                IncompleteIterators.ForEach(x => x.Indexer = null);
            }
        }

        public LocalVariable GetIndexer(TypeBridge type)
        {
            var iterator = IncompleteIterators.FirstOrDefault();
            if (CurrentIndexer != null || iterator?.Indexer != null)
            {
                var indexer = iterator.Indexer;
                if (indexer == null) return CurrentIndexer;

                IncompleteIterators.Where(x => x.Indexer == null).ForEach(x =>
                {
                    x.Indexer = indexer;
                    x.ForEnd.Add((StatementBridge) indexer.PostIncrement());
                });
                return CurrentIndexer = indexer;
            }

            var indexerVariable = GlobalVariable(type, 0);
            indexerVariable.IsGlobal = true;
                    
            IncompleteIterators.ForEach(x => x.Indexer = indexerVariable);
            ForEndAdd(indexerVariable.PostIncrement());

            return CurrentIndexer = indexerVariable;
        }
        
        public SemanticModel Semantic => Data.Semantic;
        
        public RewriteParameters()
        {
            Rewrite = RewriteService.Instance;
            Code = CodeCreationService.Instance;
            Data = RewriteDataService.Instance;
        }
        
        public void SetData(ValueBridge collection, TypeSyntax returnType, List<LinqStep> chain, InvocationExpressionSyntax node, bool reuse)
        {
            _initialStatements.Clear();
            _finalStatements.Clear();
            _resultStatements.Clear();
            Iterators.Clear();
            Variables.Clear();
            ResultIterators.Clear();
            CurrentIterator = null;
            
            var collectionType = Semantic.GetTypeInfo(collection).Type;
            FirstCollection = CurrentCollection = new CollectionValueBridge(this, collectionType, collection, reuse);
            _sourceSize = _resultSize = FirstCollection.Count;

            ReturnType = returnType;
            RewriteChain = chain;
            Node = node;

            HasResultMethod = false;
            NotRewrite = false;
            SimpleEnumeration = true;
            CurrentIndexer = null;
            NotRewrite = false;
            WrapWithTry = false;
            Unchecked = false;
            Error = false;

            LastValue = null;
        }

        public void InitialAdd(StatementBridge _)
        {
            _initialStatements.Add(_);
        }

        public void PreUseAdd(StatementBridge _)
        {
            if (ResultIterators.Count == 0) _initialStatements.Add(_);
            else if (ResultIterators.Any(x => !x.Complete)) ResultIterators.First(x => !x.Complete).PreFor.Add(_);
            else InitialAdd(_);
        }

        public void PreForAdd(StatementBridge _)
        {
            if (CurrentIterator.PreFor == null)
                InitialAdd(_);
            else CurrentIterator.PreFor.Add(_);
        }

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
        
        public IteratorParameters AddIterator(CollectionValueBridge collection)
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
        
        public IteratorParameters InsertIterator(CollectionValueBridge collection)
        {
            var oldBody = CurrentIterator;
            CurrentIterator = new IteratorParameters(this, collection);
            Iterators.Insert(0, CurrentIterator);
            ResultIterators.Insert(0, CurrentIterator);
            return oldBody;
        }

        public IEnumerable<StatementSyntax> GetMethodBody()
        {
            if (Iterators.Count == 0) return _initialStatements.Concat(_finalStatements).Concat(_resultStatements);
            var result = new List<StatementSyntax>();
            foreach (var iterator in ResultIterators)
            {
                var statements = iterator.GetStatementSyntax(this);
                result.AddRange(iterator.PreFor);
                if (statements != null && statements.Length > 0) result.AddRange(statements);
                result.AddRange(iterator.PostFor);
            }

            if (!Unchecked && WrapWithTry)
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
        
        public LocalVariable SuperGlobalVariable(TypeSyntax type, ValueBridge initial)
        {
            var variable = "v" + _variableIndex++ % 1_000_000;
            var created = new LocalVariable(variable, type) {IsGlobal = true, IsUsed = true};
            Variables.Add(created);
            
            InitialAdd(LocalVariableCreation(variable, type));
            InitialAdd(((ValueBridge)variable).Assign(initial));
            SimpleEnumeration = false;
            return created;
        }
        
        public LocalVariable GlobalVariable(TypeSyntax type)
        {
            var variable = "v" + _variableIndex++ % 1_000_000;
            var created = new LocalVariable(variable, type) {IsGlobal = true, IsUsed = true};
            Variables.Add(created);
            
            InitialAdd(LocalVariableCreation(variable, type));
            SimpleEnumeration = false;
            return created;
        }
        
        public LocalVariable GlobalVariable(TypeSyntax type, ValueBridge initial, IteratorParameters iterator)
        {
            var variable = "v" + _variableIndex++ % 1_000_000;
            var created = new LocalVariable(variable, type) {IsGlobal = true, IsUsed = true};
            Variables.Add(created);
            
            InitialAdd(LocalVariableCreation(variable, type));
            iterator.PreFor.Add((StatementBridge)((ValueBridge)variable).Assign(initial));
            SimpleEnumeration = false;
            return created;
        }
        
        public LocalVariable GlobalVariable(TypeSyntax type, ValueBridge initial)
        {
            var variable = "v" + _variableIndex++ % 10_000;
            var created = new LocalVariable(variable, type) {IsGlobal = true, IsUsed = true};
            Variables.Add(created);
            
            InitialAdd(LocalVariableCreation(variable, type));
            PreUseAdd(((ValueBridge)variable).Assign(initial));
            SimpleEnumeration = false;
            return created;
        }

        public LocalVariable LocalVariable(TypedValueBridge value)
            => LocalVariable(value.Type, value);
        
        public LocalVariable LocalVariable(TypeBridge type, ValueBridge initial)
        {
            var variable = "v" + _variableIndex++ % 10_000;
            var stringType = type.ToString();
            var found = Variables.FirstOrDefault(x => stringType == x.Type.ToString() && !x.IsGlobal && !x.IsUsed);
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
            var stringType = type.ToString();
            var found = Variables.FirstOrDefault(x => stringType == x.Type.ToString() && !x.IsGlobal && !x.IsUsed);
            if (found != null)
            {
                found.IsUsed = true;
                return found;
            }
            var variable = "v" + _variableIndex++ % 10_000;
            var created = new LocalVariable(variable, type);
            Variables.Add(created);

            InitialAdd(LocalVariableCreation(variable, type));
            SimpleEnumeration = false;
            return created;
        }

        public LocalVariable AddParameter(TypeBridge type, ExpressionSyntax value)
        {
            var variable = "v" + _variableIndex++ % 10_000;
            var created = new LocalVariable(variable, type);
            Variables.Add(created);
            
            Data.CurrentMethodParams.Add(CreateParameter(variable, type));
            Data.CurrentMethodArguments.Add(Argument(value));

            return created;
        }

        public void Dispose() => RewriteParametersFactory.ReturnParameters(this);
        
        public bool AssertResultSizeGreaterEqual(ValueBridge smaller, bool preCheck = false)
            => AssertLesserEqual(smaller, GetResultSize(), ResultSize != null, preCheck);
        
        public bool AssertResultSizeGreater(ValueBridge smaller, bool preCheck = false)
            => AssertLesser(smaller, GetResultSize(), ResultSize != null, preCheck);
        
        public bool AssertResultSizeLesserEqual(ValueBridge bigger, bool preCheck = false)
            => AssertLesserEqual(GetResultSize(), bigger, ResultSize != null, preCheck);
        
        public bool AssertResultSizeLesser(ValueBridge bigger, bool preCheck = false)
            => AssertLesser(GetResultSize(), bigger, ResultSize != null, preCheck);

        public bool AssertGreaterEqual(ValueBridge bigger, ValueBridge smaller, bool initialCheck = true, bool preCheck = false)
            => AssertLesserEqual(smaller, bigger, initialCheck, preCheck);

        public bool AssertGreater(ValueBridge bigger, ValueBridge smaller, bool initialCheck = true, bool preCheck = false)
            => AssertLesser(smaller, bigger, initialCheck, preCheck);

        public void InitialError(string type, string message)
        {
            _initialStatements.Clear();
            _initialStatements.Add(Throw(type, message));
            _finalStatements.Clear();
            _resultStatements.Clear();
            ResultIterators.Clear();
            Error = true;
        }

        public bool AssertLesserEqual(ValueBridge smaller, ValueBridge bigger, bool initialCheck = true, bool preCheck = false)
        {
            if (Unchecked) return true;
            var biggerPass = ExpressionSimplifier.TryGetDouble(bigger, out var biggerD);
            var smallerPass = ExpressionSimplifier.TryGetDouble(smaller, out var smallerD);
            
            if (biggerPass && smallerPass)
            {
                if (smallerD <= biggerD) return true;
                InitialError("System.InvalidOperationException", "Index out of range");
                return false;
            }
            if (preCheck) return true;
            if (initialCheck) PreUseAdd(If(smaller > bigger, Throw("System.InvalidOperationException", "Index out of range")));
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
                InitialError("System.InvalidOperationException", "Index out of range");
                return false;
            }
            if (preCheck) return true;
            if (initialCheck) PreUseAdd(If(smaller >= bigger, Throw("System.InvalidOperationException", "Index out of range")));
            else FinalAdd(If(smaller >= bigger, Throw("System.InvalidOperationException", "Index out of range")));
            return true;
        }

        public bool AssertNotNull(ValueBridge notNull, bool preCheck = false)
        {
            if (Unchecked) return true;
            if (notNull.ToString() == "null")
            {
                InitialError("System.InvalidOperationException", "Invalid null object");
                return false;
            }
            if (preCheck) return true;
            PreUseAdd(If(notNull.IsEqual(null), Throw("System.InvalidOperationException", "Invalid null object")));
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

        public void SwitchIsReversed()
        {
            if (Iterators.Count <= 0) throw new InvalidOperationException("Reversing not existing iterator");
            var iterator = Iterators.Last(x => !x.Complete);
            ValueBridge to = iterator.ForTo;
            iterator.ForTo = iterator.ForFrom;
            iterator.ForFrom = to;
            iterator.ForInc =  0 - iterator.ForInc;
            iterator.IsReversed = !iterator.IsReversed;
        }

        public ValueBridge CurrentMin => Iterators.FirstOrDefault() == null
            ? 0 : CurrentIterator.ForFrom;

        public ValueBridge CurrentMax => Iterators.FirstOrDefault() == null
            ? CurrentCollection[CurrentCollection.Count - 1] : CurrentIterator.ForTo;
    }
}