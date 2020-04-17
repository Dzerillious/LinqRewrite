using System.Linq;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.ExpressionSimplifier;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteToList
    {
        public static ExpressionSyntax SimpleRewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (!TryGetInt(p.ResultSize, out var intSize) || intSize > 20)
                return null;

            var items = Enumerable.Range(0, intSize).Select(x
                => (ExpressionSyntax) SimplifySubstitute(p.LastValue, p.CurrentIterator.ForIndexer, p.CurrentMin + x));
            return ObjectCreationExpression(p.ReturnType, ArgumentList(CreateSeparatedList(new ArgumentSyntax[0])), 
                InitializerExpression( SyntaxKind.ArrayInitializerExpression, SeparatedList(items)));
        }
        
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            var listVariable = p.GlobalVariable(p.ReturnType, New(p.ReturnType));
            p.ForAdd(listVariable.Access("Add").Invoke(p.LastValue));
            p.ResultAdd(Return(listVariable));
        }
    }
}