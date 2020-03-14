using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.DataStructures
{
    public class IteratorParameters : IStatementSyntax
    {
        private readonly RewriteParameters _parameters;
        public ValueBridge ForMin { get; set; }
        public ValueBridge ForMax { get; set; }
        public ValueBridge ForReverseMin { get; set; }
        public ValueBridge ForReverseMax { get; set; }
        public RewrittenValueBridge Collection { get; }

        public bool Complete { get; set; }
        
        public List<StatementSyntax> PreFor { get; } = new List<StatementSyntax>();
        public List<IStatementSyntax> ForBody { get; private set; } = new List<IStatementSyntax>();
        public List<IStatementSyntax> ForEnd { get; private set; } = new List<IStatementSyntax>();
        
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

        public void CalculatePreAdd(RewriteParameters p)
        {
            ForBody.ForEach(x =>
            {
                if (x is IteratorParameters iteratorParameters)
                    iteratorParameters.CalculatePreAdd(p);
            });
            if (ForMin == null)
            {
                PreFor.Add((StatementBridge)EnumeratorVariable.Assign(Collection.Access("GetEnumerator").Invoke()));
            }
            else if (p.IsReversed)
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
                return p.Rewrite.GetForEachStatement(p, EnumeratorVariable, Collection, content);
            else if (p.IsReversed)
                return p.Rewrite.GetReverseForStatement(p, ForIndexer, ForReverseMin, content);
            else return p.Rewrite.GetForStatement(p, ForIndexer, ForMax, content);
        }
    }
}