using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Shaman.Roslyn.LinqRewrite.DataStructures
{
    public class StatementBridge
    {
        private readonly StatementSyntax _statement;

        private StatementBridge(StatementSyntax statement)
        {
            _statement = statement;
        }

        private StatementBridge(ExpressionSyntax expression)
        {
            _statement = SyntaxFactory.ExpressionStatement(expression);
        }
        
        public static implicit operator StatementBridge(StatementSyntax statement)
            => new StatementBridge(statement);
        
        public static implicit operator StatementBridge(ExpressionSyntax expression)
            => new StatementBridge(expression);
        
        public static implicit operator StatementBridge(ValueBridge expression)
            => new StatementBridge(expression);
        
        public static implicit operator StatementSyntax(StatementBridge statement)
            => statement._statement;
        
        public static implicit operator StatementSyntaxBridge(StatementBridge statement)
            => new StatementSyntaxBridge(statement);
    }
}