using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.Extensions;

namespace Shaman.Roslyn.LinqRewrite.DataStructures
{
    public class EnumerationParameters : IStatementSyntax
    {
        public string Indexer { get; set; }
        public ValueBridge ForMin { get; set; }
        public ValueBridge ForMax { get; set; }
        public ValueBridge ForReMin { get; set; }
        public ValueBridge ForReMax { get; set; }

        public List<IStatementSyntax> Body { get; set; }

        public void ForAdd(StatementBridge _) => Body.Add((StatementSyntaxBridge)_);
        
        public EnumerationParameters(string indexer)
        {
            Body = new List<IStatementSyntax>();
            Indexer = indexer;
        }

        public EnumerationParameters(List<IStatementSyntax> items, string indexer)
        {
            Body = items;
            Indexer = indexer;
        }

        public EnumerationParameters Copy() =>
            new EnumerationParameters(new List<IStatementSyntax>(Body), Indexer)
            {
                ForMin = ForMin,
                ForMax = ForMax,
                ForReMin = ForReMin,
                ForReMax = ForReMax,
                Indexer = Indexer
            };

        public EnumerationParameters CopyReference() =>
            new EnumerationParameters(Body, Indexer)
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
                return p.Rewrite.GetForEachStatement(Constants.GlobalItemVariable, p.Collection, GetBody(p));
            if (p.IsReversed)
                return p.Rewrite.GetReverseForStatement( Indexer, ForReMin, ForReMax, GetBody(p));
            return p.Rewrite.GetForStatement(Indexer, ForMin, ForMax, GetBody(p));
        }
    }
}