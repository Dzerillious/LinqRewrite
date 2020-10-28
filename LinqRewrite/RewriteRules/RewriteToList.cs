using System.Collections.Immutable;
using System.Linq;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.ExpressionSimplifier;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteToList
    {
        public static ExpressionSyntax SimpleRewrite(RewriteDesign design, ImmutableArray<ValueBridge> args)
        {
            if (!TryGetInt(design.ResultSize, out var intSize) || intSize > Constants.SimpleRewriteMaxSimpleElements)
                return null;

            var items = Enumerable.Range(0, intSize).Select(i
                => (ExpressionSyntax) Substitute(design.LastValue, design.CurrentIterator.ForIndexer, design.CurrentMin + i));
            return ObjectCreationExpression(design.ReturnType, ArgumentList(CreateSeparatedList(new ArgumentSyntax[0])), 
                InitializerExpression( SyntaxKind.ArrayInitializerExpression, SeparatedList(items)));
        }
        
        public static void Rewrite(RewriteDesign design, ImmutableArray<ValueBridge> args)
        {
            var listVariable = CreateGlobalVariable(design, design.ReturnType, New(design.ReturnType));
            design.ForAdd(listVariable.Access("Add").Invoke(design.LastValue));
            design.ResultAdd(Return(listVariable));
        }
    }
}