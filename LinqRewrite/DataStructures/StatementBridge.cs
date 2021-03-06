﻿using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.DataStructures
{
    public interface IStatementSyntax
    {
        StatementSyntax[] GetStatementSyntax(RewriteDesign design);
    }
    
    public class StatementBridge : IStatementSyntax
    {
        private readonly StatementSyntax _statement;

        private StatementBridge(StatementSyntax statement)
            => _statement = statement;

        private StatementBridge(ExpressionSyntax expression)
            => _statement = SyntaxFactory.ExpressionStatement(expression);
        
        public static implicit operator StatementBridge(StatementSyntax statement)
            => new StatementBridge(statement);
        
        public static implicit operator StatementBridge(ExpressionSyntax expression)
            => new StatementBridge(expression);
        
        public static implicit operator StatementBridge(ValueBridge expression)
            => new StatementBridge(expression);
        
        public static implicit operator StatementBridge(LocalVariable name)
            => SyntaxFactory.ExpressionStatement(SyntaxFactory.IdentifierName(name.Name));
        
        public static implicit operator StatementSyntax(StatementBridge statement)
            => statement._statement;
        
        public static implicit operator StatementBridge(VariableBridge value)
            => new StatementBridge(SyntaxFactory.ExpressionStatement(value));
        
        public StatementSyntax[] GetStatementSyntax(RewriteDesign design)
            => new []{_statement};
    }
}