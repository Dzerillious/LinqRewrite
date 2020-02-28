using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.DataStructures
{
    public interface IStatementSyntax
    {
        StatementSyntax GetStatementSyntax(RewriteParameters p);
    }
    
    public class StatementSyntaxBridge : IStatementSyntax
    {
        private readonly StatementSyntax _statementSyntax;

        public StatementSyntaxBridge(StatementSyntax statementSyntax)
            => _statementSyntax = statementSyntax;
        
        public StatementSyntax GetStatementSyntax(RewriteParameters p)
            => _statementSyntax;
    }
}