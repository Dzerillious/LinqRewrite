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
        public ValueBridge ForMin { get; set; }
        public ValueBridge ForMax { get; set; }
        public ValueBridge ForIncrement { get; set; } = 1;
        public ValueBridge ForReverseMin { get; set; }
        public ValueBridge ForReverseMax { get; set; }
        public RewrittenValueBridge Collection { get; }

        public bool IsReversed { get; set; }
        public bool Complete { get; set; }
        
        public List<StatementSyntax> PreFor { get; } = new List<StatementSyntax>();
        public List<IStatementSyntax> ForBody { get; private set; } = new List<IStatementSyntax>();
        public List<IStatementSyntax> ForEnd { get; private set; } = new List<IStatementSyntax>();
        public List<StatementSyntax> PostFor { get; } = new List<StatementSyntax>();
        
        public LocalVariable CurrentIndexer { get; set; }
        public LocalVariable ForIndexer { get; set; }
        public LocalVariable EnumeratorVariable { get; set; }
        public bool IgnoreIterator { get; set; }

        public void BodyAdd(StatementBridge _) => ForBody.Add(_);
        
        public IteratorParameters(RewriteParameters parameters)
        {
            _parameters = parameters;
        }
        
        public IteratorParameters(RewriteParameters parameters, RewrittenValueBridge collection)
        {
            _parameters = parameters;
            Collection = collection;
        }

        public IteratorParameters Copy() =>
            new IteratorParameters(_parameters, Collection)
            {
                ForMin = ForMin,
                ForMax = ForMax,
                ForReverseMin = ForReverseMin,
                ForReverseMax = ForReverseMax,
                CurrentIndexer = ForIndexer = ForIndexer,
                ForBody = new List<IStatementSyntax>(ForBody),
            };

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
            if (ForMin == null)
            {
                PreFor.Add((StatementBridge)EnumeratorVariable.Assign(Collection.Access("GetEnumerator").Invoke()));
            }
            else if (IsReversed)
            {
                PreFor.Add((StatementBridge)ForIndexer.Assign(ForReverseMax));
            }
            else
            {
                PreFor.Add((StatementBridge)ForIndexer.Assign(ForMin));
            }
        }

        public StatementSyntax GetStatementSyntax(RewriteParameters p)
        {
            if (IgnoreIterator) return null;
            CalculatePreAdd(p);
            var content = ForBody.SelectMany(x => 
                x is IteratorParameters parameters
                    ? parameters.PreFor.Select(x => (StatementBridge)x).Concat(new[] {x})
                    : new[] {x}).Concat(ForEnd).ToList();
            
            if (ForMin == null)
                return RewriteService.GetForEachStatement(p, EnumeratorVariable, content);
            if (IsReversed)
                return RewriteService.GetReverseForStatement(p, ForIndexer, ForReverseMin.ReusableForConst(_parameters, Int, this), ForIncrement, content);
            return RewriteService.GetForStatement(p, ForIndexer, ForMax.ReusableForConst(_parameters, Int, this), ForIncrement, content);
        }
    }
}