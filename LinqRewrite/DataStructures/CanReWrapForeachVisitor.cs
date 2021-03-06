﻿// Forked and modified from https://github.com/antiufo/roslyn-linq-rewrite/tree/master/RoslynLinqRewrite

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.DataStructures
{
    internal class CanReWrapForeachVisitor : CSharpSyntaxWalker
    {
        internal bool Fail;
        
        public override void VisitAwaitExpression(AwaitExpressionSyntax node)
            => Fail = true;

        public override void VisitBreakStatement(BreakStatementSyntax node)
            => Fail = true;

        public override void VisitContinueStatement(ContinueStatementSyntax node)
            => Fail = true;

        public override void VisitReturnStatement(ReturnStatementSyntax node)
            => Fail = true;

        public override void VisitGotoStatement(GotoStatementSyntax node)
            => Fail = true;

        public override void VisitYieldStatement(YieldStatementSyntax node)
            => Fail = true;

        public override void VisitParenthesizedLambdaExpression(ParenthesizedLambdaExpressionSyntax node) {}

        public override void VisitSimpleLambdaExpression(SimpleLambdaExpressionSyntax node) {}

        public override void VisitAnonymousMethodExpression(AnonymousMethodExpressionSyntax node) {}
    }
}
