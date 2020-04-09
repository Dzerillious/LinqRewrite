using System.Linq;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteToList
    {
        public static ExpressionSyntax SimpleRewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (!ExpressionSimplifier.TryGetInt(p.ResultSize, out var intSize) || intSize > 20)
                return null;

            var items = Enumerable.Range(0, intSize).Select(x
                => (ExpressionSyntax) ExpressionSimplifier.SimplifySubstitute(p.LastValue, p.CurrentIterator.ForIndexer, p.CurrentMin + x));
            return SyntaxFactory.ObjectCreationExpression(p.ReturnType, SyntaxFactory.ArgumentList(CreateSeparatedList(new ArgumentSyntax[0])), 
                SyntaxFactory.InitializerExpression( SyntaxKind.ArrayInitializerExpression, SyntaxFactory.SeparatedList(items)));
        }
        
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            var listVariable = p.GlobalVariable(p.ReturnType, New(p.ReturnType));
            p.ForAdd(listVariable.Access("Add").Invoke(p.LastValue));
            
            p.ResultAdd(Return(listVariable));
        }
    }
}