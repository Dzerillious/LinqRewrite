using System;
using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Extensions;
using LinqRewrite.Services;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.DataStructures
{
    public class IteratorDesign : IStatementSyntax
    {
        private readonly RewriteDesign _design;
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
        
        public IteratorDesign(RewriteDesign design, CollectionValueBridge collection)
        {
            _design = design;
            Collection = collection;
        }

        private bool _preAddCalculated;
        public void CalculatePreAdd(RewriteDesign design)
        {
            if (_preAddCalculated) return;
            _preAddCalculated = true;
            
            ForBody.ForEach(x =>
            {
                if (x is IteratorDesign iteratorParameters)
                    iteratorParameters.CalculatePreAdd(design);
            });
            if (ForFrom == null) PreFor.Insert(0, (StatementBridge)Enumerator.Assign(Collection.Access("GetEnumerator").Invoke()));
            else if (IsReversed)
            {
                PreFor.Add((StatementBridge)ForIndexer.Assign(ForFrom));
                ForTo = ForTo.ReusableForConst(_design, Int, this);
            }
            else
            {
                PreFor.Add((StatementBridge)ForIndexer.Assign(ForFrom));
                ForTo = (ForTo + 1).ReusableForConst(_design, Int, this);
            }
        }

        public StatementSyntax[] GetStatementSyntax(RewriteDesign design)
        {
            CalculatePreAdd(design);
            if (IgnoreIterator) return Array.Empty<StatementSyntax>();
            var content = ForBody.SelectMany(x => 
                x is IteratorDesign parameters
                    ? parameters.PreFor.Select(x => (StatementBridge)x).Concat(new[] {x})
                        .Concat(parameters.PostFor.Select(x => (StatementBridge)x))
                    : new[] {x}).Concat(ForEnd).ToList();
            
            if (ForFrom == null) return RewriteService.GetForEachStatement(design, Enumerator, content);
            if (IsReversed) return new StatementSyntax[]{RewriteService.GetReverseForStatement(design, ForIndexer, ForTo, ForInc, content)};
            return new StatementSyntax[]{RewriteService.GetForStatement(design, ForIndexer, ForTo, ForInc, content)};
        }
    }
}