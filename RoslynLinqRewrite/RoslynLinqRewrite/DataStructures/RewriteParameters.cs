﻿using System;
using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Extensions;
using LinqRewrite.Services;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SimpleCollections;
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
        public CollectionValueBridge FirstCollection { get; private set; }
        public CollectionValueBridge CurrentCollection { get; set; }
        public List<LinqStep> Chain { get; private set; }


        public TypeBridge ReturnType { get; private set; }
        public ValueBridge ResultSize { get; set; }
        public ValueBridge SourceSize { get; set; }
        public TypedValueBridge Last { get; set; }

        public List<StatementSyntax> Initial { get; } = new List<StatementSyntax>();
        public List<IteratorParameters> FinalIterators { get; } = new List<IteratorParameters>();
        public List<IteratorParameters> Iterators { get; } = new List<IteratorParameters>();
        public IEnumerable<IteratorParameters> IncompleteIterators => Iterators.Where(x => !x.Complete);
        public IteratorParameters Iterator { get; set; }
        public List<StatementSyntax> Final { get; } = new List<StatementSyntax>();
        public List<LocalVariable> Variables { get; } = new List<LocalVariable>();
        
        public bool WrapWithTry { get; set; }

        public ExpressionSyntax SimpleRewrite { get; set; }
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
                        x.EndFor.Add((StatementBridge) indexer.PostIncrement());
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
                    x.EndFor.Add((StatementBridge) indexer.PostIncrement());
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
            get => Iterator.ForReverseMin;
            set => Iterator.ForReverseMin = value;
        }
        
        public ValueBridge ForReMax
        {
            get => Iterator.ForReverseMax;
            set => Iterator.ForReverseMax = value;
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
            Initial.Clear();
            Final.Clear();
            Iterators.Clear();
            Variables.Clear();
            FinalIterators.Clear();
            Iterator = null;
            
            var collectionType = collection.GetType(this);
            FirstCollection = CurrentCollection = new CollectionValueBridge(collection.ItemType(this), collectionType, collection.Count(this), collection);
            SourceSize = ResultSize = FirstCollection.Count;

            ReturnType = returnType;
            Chain = chain;
            Node = node;

            HasResultMethod = false;
            NotRewrite = false;
            IsReversed = false;
            ListEnumeration = true;
            CurrentIndexer = null;
            NotRewrite = false;

            SimpleRewrite = null;
            Last = null;
        }

        public void InitialAdd(StatementBridge _)
        {
            Initial.Add(_);
        }

        public void PreUseAdd(StatementBridge _)
        {
            if (Iterators.Count == 0) Initial.Add(_);
            else IncompleteIterators.First().Pre.Add(_);
        }

        public void PreForAdd(StatementBridge _) => Iterator.Pre.Add(_);
        public void ForAdd(StatementBridge _)
        {
            IncompleteIterators.ForEach(x => x.Body.Add(_));
        }
        public void ForEndAdd(StatementBridge _)
        {
            IncompleteIterators.ForEach(x => x.EndFor.Add(_));
        }
        public void LastForAdd(StatementBridge _) => Iterator.BodyAdd(_);
        public void FinalAdd(StatementBridge _) => Final.Add(_);
        
        public IteratorParameters AddIterator(RewrittenValueBridge collection)
        {
            var oldBody = Iterator;
            Iterator = new IteratorParameters(this, collection);
            Iterators.Add(Iterator);
            FinalIterators.Add(Iterator);
            return oldBody;
        }
        
        public IteratorParameters CopyIterator()
        {
            var oldBody = Iterator;
            Iterator = Iterator.Copy();
            Iterators.Add(Iterator);
            FinalIterators.Add(Iterator);
            return oldBody;
        }

        public IEnumerable<StatementSyntax> GetMethodBody()
        {
            if (Iterators.Count == 0) return Initial.Concat(Final);
            var result = new List<StatementSyntax>();
            if (IsReversed)
            {
                for (var i = FinalIterators.Count - 1; i >= 0; i--)
                {
                    var statement = FinalIterators[i].GetStatementSyntax(this);
                    result.AddRange(FinalIterators[i].Pre);
                    if (statement != null) result.Add(statement);
                }
            }
            else for (var i = 0; i < FinalIterators.Count; i++)
            {
                var statement = FinalIterators[i].GetStatementSyntax(this);
                result.AddRange(FinalIterators[i].Pre);
                if (statement != null) result.Add(statement);
            }

            if (WrapWithTry)
            {
                result = new List<StatementSyntax>(Initial) {TryF(Block(result), Block(Final))};
            }
            else
            {
                result.InsertRange(0, Initial);
                result.AddRange(Final);
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

        public void Dispose() => RewriteParametersFactory.ReturnParameters(this);
    }
}