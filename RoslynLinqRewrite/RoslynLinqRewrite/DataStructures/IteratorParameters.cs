using System.Collections.Generic;
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
        
        public List<StatementSyntax> Pre { get; } = new List<StatementSyntax>();
        public List<IStatementSyntax> Body { get; private set; } = new List<IStatementSyntax>();
        public List<StatementSyntax> Post { get; private set; } = new List<StatementSyntax>();
        public bool Complete { get; set; }
        
        public LocalVariable Indexer { get; set; }
        public LocalVariable IndexedItem { get; set; }

        public void BodyAdd(StatementBridge _) => Body.Add(_);
        
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
                Indexer = Indexer,
                IndexedItem = IndexedItem,
                Body = new List<IStatementSyntax>(Body),
            };

        public StatementSyntax GetStatementSyntax(RewriteParameters p)
        {
            if (ForMin == null)
            {
                var enumeratorVariable = p.GlobalVariable(p.WrappedItemType("IEnumerator<", Collection.Old, ">"));
                return p.Rewrite.GetForEachStatement(p, enumeratorVariable, IndexedItem, Collection, Body);
            }
            else if (p.IsReversed)
            {
                Pre.Add((StatementBridge)Indexer.Assign(ForReverseMax));
                return p.Rewrite.GetReverseForStatement(p, Indexer, ForReverseMin, Body);
            }
            else
            {
                Pre.Add((StatementBridge)Indexer.Assign(ForMin));
                return p.Rewrite.GetForStatement(p, Indexer, ForMax, Body);
            }
        }
    }
}