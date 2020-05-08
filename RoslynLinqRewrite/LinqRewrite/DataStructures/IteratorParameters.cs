using System;
using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Extensions;
using LinqRewrite.Services;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.DataStructures
{
    public class IteratorParameters : IStatementSyntax
    {
        private readonly RewriteParameters _parameters;
        public ValueBridge ForFrom { get; set; }
        public ValueBridge ForTo { get; set; }
        public ValueBridge ForInc { get; set; } = 1;
        
        public CollectionValueBridge Collection { get; }
        public LocalVariable Indexer { get; set; }
        public LocalVariable ForIndexer { get; set; }
        public LocalVariable Enumerator { get; set; }

        public bool IsReversed { get; set; }
        public bool Complete { get; set; }
        public bool ListEnumeration { get; set; } = true;
        public bool IgnoreIterator { get; set; }
        
        public List<StatementSyntax> PreFor { get; } = new List<StatementSyntax>();
        public List<IStatementSyntax> ForBody { get; } = new List<IStatementSyntax>();
        public List<IStatementSyntax> ForEnd { get; } = new List<IStatementSyntax>();
        public List<StatementSyntax> PostFor { get; } = new List<StatementSyntax>();

        public void BodyAdd(StatementBridge _) => ForBody.Add(_);
        
        public IteratorParameters(RewriteParameters parameters)
        {
            _parameters = parameters;
        }
        
        public IteratorParameters(RewriteParameters parameters, CollectionValueBridge collection)
        {
            _parameters = parameters;
            Collection = collection;
        }

        private bool _preAddCalculated;
        public void CalculatePreAdd(RewriteParameters p)
        {
            if (_preAddCalculated) return;
            _preAddCalculated = true;
            
            ForBody.ForEach(x =>
            {
                if (x is IteratorParameters iteratorParameters)
                    iteratorParameters.CalculatePreAdd(p);
            });
            if (ForFrom == null) PreFor.Insert(0, (StatementBridge)Enumerator.Assign(Collection.Access("GetEnumerator").Invoke()));
            else if (IsReversed)
            {
                PreFor.Add((StatementBridge)ForIndexer.Assign(ForFrom.Simplify()));
                ForTo = ForTo.Simplify().ReusableForConst(_parameters, Int, this);
            }
            else
            {
                PreFor.Add((StatementBridge)ForIndexer.Assign(ForFrom.Simplify()));
                ForTo = (ForTo + 1).Simplify().ReusableForConst(_parameters, Int, this);
            }
        }

        public StatementSyntax[] GetStatementSyntax(RewriteParameters p)
        {
            CalculatePreAdd(p);
            if (IgnoreIterator) return Array.Empty<StatementSyntax>();
            var content = ForBody.SelectMany(x => 
                x is IteratorParameters parameters
                    ? parameters.PreFor.Select(x => (StatementBridge)x).Concat(new[] {x})
                        .Concat(parameters.PostFor.Select(x => (StatementBridge)x))
                    : new[] {x}).Concat(ForEnd).ToList();
            
            if (ForFrom == null) return RewriteService.GetForEachStatement(p, Enumerator, content);
            if (IsReversed) return new StatementSyntax[]{RewriteService.GetReverseForStatement(p, ForIndexer, ForTo, ForInc.Simplify(), content)};
            return new StatementSyntax[]{RewriteService.GetForStatement(p, ForIndexer, ForTo, ForInc.Simplify(), content)};
        }
    }
}