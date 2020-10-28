using System;
using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using LinqRewrite.Services;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite
{
    public class RewriteDesign
    {
        public RewriteService Rewrite { get; }
        public CodeCreationService Code { get; }

        public RewriteInfo Info { get; }

        public CollectionValueBridge FirstCollection { get; set; }
        public CollectionValueBridge CurrentCollection { get; set; }

        public ValueBridge GetResultSize() => ResultSize ?? Indexer;
        private ValueBridge _resultSize;
        public ValueBridge ResultSize
        {
            get => _resultSize;
            set => _resultSize = value?.Value == null ? null : value;
        }
        
        private ValueBridge _sourceSize;
        public ValueBridge SourceSize
        {
            get => _sourceSize;
            set => _sourceSize = value?.Value == null ? null : value;
        }

        private TypedValueBridge _lastValue;
        public TypedValueBridge LastValue
        {
            get => _lastValue;
            set => _lastValue = value?.Value == null ? null : new TypedValueBridge(value.Type, value);
        }

        public readonly List<StatementSyntax> InitialStatements = new List<StatementSyntax>();
        public readonly List<StatementSyntax> FinalStatements = new List<StatementSyntax>();
        public readonly List<StatementSyntax> ResultStatements = new List<StatementSyntax>();
        public readonly List<IteratorDesign> ResultIterators = new List<IteratorDesign>();
        public IteratorCollection Iterators { get; } = new IteratorCollection();
        public IEnumerable<IteratorDesign> IncompleteIterators => Iterators.Where(x => !x.Complete);
        public IteratorDesign CurrentIterator { get; set; }
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
                IncompleteIterators.ForEach(iterator => iterator.ListEnumeration = false);
            }
        }

        private bool _simpleEnumeration = true;
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
                    LocalVariable indexer = iterator.Indexer;
                    IncompleteIterators.Where(iterator => iterator.Indexer == null).ForEach(x =>
                    {
                        x.Indexer = indexer;
                        x.ForEnd.Add((StatementBridge) indexer.PostIncrement());
                    });
                    return CurrentIndexer = indexer;
                }

                var indexerVariable = CreateSuperGlobalVariable(this, Int, 0);
                indexerVariable.IsGlobal = true;
                    
                IncompleteIterators.ForEach(iterator => iterator.Indexer = indexerVariable);
                ForEndAdd(indexerVariable.PostIncrement());

                return CurrentIndexer = indexerVariable;
            }
            set
            {
                if (value != null) throw new NotImplementedException("Implemented only for setting null");
                
                CurrentIndexer = null;
                IncompleteIterators.ForEach(iterator => iterator.Indexer = null);
            }
        }

        public LocalVariable GetIndexer(TypeBridge type)
        {
            var iterator = IncompleteIterators.FirstOrDefault();
            if (CurrentIndexer != null || iterator?.Indexer != null)
            {
                LocalVariable indexer = iterator.Indexer;
                if (indexer == null) return CurrentIndexer;

                IncompleteIterators.Where(iterator => iterator.Indexer == null).ForEach(x =>
                {
                    x.Indexer = indexer;
                    x.ForEnd.Add((StatementBridge) indexer.PostIncrement());
                });
                return CurrentIndexer = indexer;
            }

            var indexerVariable = CreateGlobalVariable(this, type, 0);
            indexerVariable.IsGlobal = true;
                    
            IncompleteIterators.ForEach(iterator => iterator.Indexer = indexerVariable);
            ForEndAdd(indexerVariable.PostIncrement());

            return CurrentIndexer = indexerVariable;
        }
        
        public RewriteDesign(RewriteInfo rewriteInfo)
        {
            Rewrite = RewriteService.Instance;
            Code = CodeCreationService.Instance;
            FirstCollection = CurrentCollection = new CollectionValueBridge(this, rewriteInfo.SourceTypeSymbol, rewriteInfo.Source);
            _sourceSize = _resultSize = FirstCollection.Count;
        }

        public void InitialAdd(StatementBridge _)
        {
            InitialStatements.Add(_);
        }
        public void PreUseAdd(StatementBridge _)
        {
            if (ResultIterators.Count == 0) InitialStatements.Add(_);
            else if (ResultIterators.Any(iterrator => !iterrator.Complete)) 
                ResultIterators.First(x => !x.Complete).PreFor.Add(_);
            else InitialAdd(_);
        }
        public void PreForAdd(StatementBridge _)
        {
            if (CurrentIterator.PreFor == null)
                InitialAdd(_);
            else CurrentIterator.PreFor.Add(_);
        }
        public void PostForAdd(StatementBridge _)
        {
            IncompleteIterators.ForEach(iterator => iterator.PostFor.Add(_));
        }
        public void ForAdd(StatementBridge _)
        {
            IncompleteIterators.ForEach(iterator => iterator.ForBody.Add(_));
        }
        public void ForEndAdd(StatementBridge _)
        {
            IncompleteIterators.ForEach(iterator => iterator.ForEnd.Add(_));
        }
        public void CurrentForAdd(StatementBridge _) => CurrentIterator.BodyAdd(_);
        public void FinalAdd(StatementBridge _) => FinalStatements.Add(_);
        public void ResultAdd(StatementBridge _) => ResultStatements.Add(_);
        
        public IteratorDesign AddIterator(CollectionValueBridge collection = null)
        {
            var oldBody = CurrentIterator;
            CurrentIterator = new IteratorDesign(this, collection);
            Iterators.Add(CurrentIterator);
            ResultIterators.Add(CurrentIterator);
            return oldBody;
        }
        
        public IteratorDesign InsertIterator(CollectionValueBridge collection = null)
        {
            var oldIterator = CurrentIterator;
            CurrentIterator = new IteratorDesign(this, collection);
            Iterators.Insert(0, CurrentIterator);
            ResultIterators.Insert(0, CurrentIterator);
            return oldIterator;
        }

        public LocalVariable AddParameter(TypeBridge type, ExpressionSyntax value)
        {
            string variable = "v" + VariableIndex++ % Constants.VariablesPeek;
            var created = new LocalVariable(variable, type);
            Variables.Add(created);
            
            //Data.CurrentMethodParams.Add(CreateParameter(variable, type));
            //Data.CurrentMethodArguments.Add(Argument(value));

            return created;
        }

        public void SwitchIsReversed()
        {
            if (Iterators.Count <= 0) throw new InvalidOperationException("Reversing not existing iterator");
            var iterator = Iterators.Last(iterator => !iterator.Complete);
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