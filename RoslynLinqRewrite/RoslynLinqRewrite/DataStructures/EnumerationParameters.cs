using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.DataStructures
{
    public class EnumerationParameters : IStatementSyntax
    {
        public string Indexer { get; set; }
        public ValueBridge ForMin { get; set; }
        public ValueBridge ForMax { get; set; }
        public ValueBridge ForReMin { get; set; }
        public ValueBridge ForReMax { get; set; }
        public ValueBridge Collection { get; set; }
        public List<IStatementSyntax> Body { get; set; }
        public bool Finished { get; set; } = false;

        public void ForAdd(StatementBridge _) => Body.Add((StatementSyntaxBridge)_);
        
        public EnumerationParameters(string indexer, ValueBridge collection)
        {
            Body = new List<IStatementSyntax>();
            Indexer = indexer;
            Collection = collection;
        }

        public EnumerationParameters(List<IStatementSyntax> items, ValueBridge collection, string indexer)
        {
            Body = items;
            Indexer = indexer;
            Collection = collection;
        }

        public EnumerationParameters Copy() =>
            new EnumerationParameters(new List<IStatementSyntax>(Body), Collection, Indexer)
            {
                ForMin = ForMin,
                ForMax = ForMax,
                ForReMin = ForReMin,
                ForReMax = ForReMax,
                Indexer = Indexer
            };

        public EnumerationParameters CopyReference() =>
            new EnumerationParameters(Body, Collection, Indexer)
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
            if (p.IsReversed)
                return p.Rewrite.GetReverseForStatement(Indexer, ForReMin, ForReMax, GetBody(p));
            return p.Rewrite.GetForStatement(Indexer, ForMin, ForMax, GetBody(p));
        }
    }
}