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

        public StatementSyntax GetStatementSyntax(RewriteParameters p)
        {
            if (IgnoreIterator) return null;
            if (ForMin == null)
            {
                return p.Rewrite.GetForEachStatement(p, EnumeratorVariable, Collection, ForBody.Concat(ForEnd).ToList());
            }
            else if (p.IsReversed)
            {
                PreFor.Add((StatementBridge)ForIndexer.Assign(ForReverseMax));
                return p.Rewrite.GetReverseForStatement(p, ForIndexer, ForReverseMin, ForBody.Concat(ForEnd).ToList());
            }
            else
            {
                PreFor.Add((StatementBridge)ForIndexer.Assign(ForMin));
                return p.Rewrite.GetForStatement(p, ForIndexer, ForMax, ForBody.Concat(ForEnd).ToList());
            }
        }
    }
}