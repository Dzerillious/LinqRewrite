using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.DataStructures
{
    public class EnumerationParameters : IStatementSyntax
    {
        private readonly RewriteParameters _parameters;
        
        public string Indexer { get; set; }
        public ValueBridge ForMin { get; set; }
        public ValueBridge ForMax { get; set; }
        public ValueBridge ForReMin { get; set; }
        public ValueBridge ForReMax { get; set; }
        public ValueBridge Collection { get; set; }
        public List<IStatementSyntax> Body { get; set; }
        public bool Complete { get; set; } = false;

        private bool _globalIndexer;
        public bool GlobalIndexer
        {
            get => _globalIndexer;
            set
            {
                _globalIndexer = value;
                if (value) _parameters.CreateGlobalIndexer(Indexer, ForReMax);
            }
        }

        public void BodyAdd(StatementBridge _) => Body.Add((StatementSyntaxBridge)_);
        
        public EnumerationParameters(RewriteParameters parameters, string indexer, ValueBridge collection)
        {
            _parameters = parameters;
            
            Body = new List<IStatementSyntax>();
            Indexer = indexer;
            Collection = collection;
        }

        public EnumerationParameters(RewriteParameters parameters, List<IStatementSyntax> items, ValueBridge collection, string indexer)
        {
            _parameters = parameters;
            
            Body = items;
            Indexer = indexer;
            Collection = collection;
        }

        public EnumerationParameters Copy() =>
            new EnumerationParameters(_parameters, new List<IStatementSyntax>(Body), Collection, Indexer)
            {
                ForMin = ForMin,
                ForMax = ForMax,
                ForReMin = ForReMin,
                ForReMax = ForReMax,
                Indexer = Indexer
            };

        public EnumerationParameters CopyReference() =>
            new EnumerationParameters(_parameters, Body, Collection, Indexer)
            {
                ForMin = ForMin,
                ForMax = ForMax,
                ForReMin = ForReMin,
                ForReMax = ForReMax,
                Indexer = Indexer
            };

        private StatementSyntax GetBody(RewriteParameters p) => SyntaxFactoryHelper.AggregateStatementSyntax(Body.Select(x => x.GetStatementSyntax(p)).ToArray());

        public StatementSyntax GetStatementSyntax(RewriteParameters p)
        {
            if (ForMin == null)
                return p.Rewrite.GetForEachStatement(Indexer, Collection, GetBody(p));
            
            else if (p.IsReversed && GlobalIndexer)
                return p.Rewrite.GetNotInitializingReverseForStatement(Indexer, ForReMin, GetBody(p));
            
            else if (p.IsReversed)
                return p.Rewrite.GetReverseForStatement(Indexer, ForReMin, ForReMax, GetBody(p));
            
            else if (GlobalIndexer)
                return p.Rewrite.GetNotInitializingForStatement(Indexer, ForMax, GetBody(p));
            
            else return p.Rewrite.GetForStatement(Indexer, ForMin, ForMax, GetBody(p));
        }
    }
}