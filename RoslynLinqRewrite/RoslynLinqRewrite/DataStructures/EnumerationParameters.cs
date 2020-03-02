using System.Collections.Generic;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.DataStructures
{
    public class EnumerationParameters : IStatementSyntax
    {
        private readonly RewriteParameters _parameters;
        
        public LocalVariable Indexer { get; set; }
        public ValueBridge ForMin { get; set; }
        public ValueBridge ForMax { get; set; }
        public ValueBridge ForReMin { get; set; }
        public ValueBridge ForReMax { get; set; }
        public ValueBridge Collection { get; }
        
        public List<StatementSyntax> Pre { get; } = new List<StatementSyntax>();
        public List<IStatementSyntax> Body { get; } = new List<IStatementSyntax>();
        public bool Complete { get; set; }
        public bool GlobalIndexer { get; set; }

        public void BodyAdd(StatementBridge _) => Body.Add((StatementSyntaxBridge)_);
        
        public EnumerationParameters(RewriteParameters parameters, ValueBridge collection)
        {
            _parameters = parameters;
            Collection = collection;
        }

        public EnumerationParameters(RewriteParameters parameters, List<IStatementSyntax> items, ValueBridge collection)
        {
            _parameters = parameters;
            
            Body = items;
            Collection = collection;
        }

        public EnumerationParameters Copy() =>
            new EnumerationParameters(_parameters, new List<IStatementSyntax>(Body), Collection)
            {
                ForMin = ForMin,
                ForMax = ForMax,
                ForReMin = ForReMin,
                ForReMax = ForReMax,
                Indexer = Indexer
            };

        public EnumerationParameters CopyReference() =>
            new EnumerationParameters(_parameters, Body, Collection)
            {
                ForMin = ForMin,
                ForMax = ForMax,
                ForReMin = ForReMin,
                ForReMax = ForReMax,
                Indexer = Indexer
            };

        public StatementSyntax GetStatementSyntax(RewriteParameters p)
        {
            if (ForMin == null)
            {
                var enumeratorVariable = p.CreateGlobalVariable("enumerable", p.WrappedItemType("IEnumerator<", Collection, ">"));
                return p.Rewrite.GetForEachStatement(p, enumeratorVariable, Indexer, Collection, Body);
            }
            else if (p.IsReversed)
            {
                Pre.Add((StatementBridge)Indexer.Assign(ForReMax));
                return p.Rewrite.GetReverseForStatement(p, Indexer, ForReMin, Body);
            }
            else
            {
                Pre.Add((StatementBridge)Indexer.Assign(ForMin));
                return p.Rewrite.GetForStatement(p, Indexer, ForMax, Body);
            }
        }
    }
}