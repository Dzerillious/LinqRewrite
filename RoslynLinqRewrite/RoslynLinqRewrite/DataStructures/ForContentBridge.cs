using Microsoft.CodeAnalysis.CSharp;
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
        
        public static implicit operator StatementSyntaxBridge(VariableBridge value)
            => new StatementSyntaxBridge(SyntaxFactory.ExpressionStatement(value));
        
        public static implicit operator StatementSyntaxBridge(ExpressionSyntax expression)
            => new StatementSyntaxBridge(SyntaxFactory.ExpressionStatement(expression));
        
        public static implicit operator StatementSyntaxBridge(StatementBridge statement)
            => new StatementSyntaxBridge(statement);
    }
}