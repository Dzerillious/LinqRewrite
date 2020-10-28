using System.Collections.Immutable;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.AssertionExtension;
using static LinqRewrite.Extensions.ExpressionSimplifier;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteLast
    {
        public static ExpressionSyntax SimpleRewrite(RewriteDesign design, ImmutableArray<ValueBridge> args)
        {
            if (args.Length != 0) return null;
            return Substitute(design.LastValue, design.CurrentIterator.ForIndexer, design.CurrentMax);
        }

        public static void Rewrite(RewriteDesign design, ImmutableArray<ValueBridge> args)
        {
            if (!AssertResultSizeGreaterEqual(design, 0, true)) return;
            var foundVariable = CreateGlobalVariable(design, NullableType(design.ReturnType), null);
            
            if (args.Length == 0)
                design.ForAdd(foundVariable.Assign(design.LastValue));
            else
            {
                design.ForAdd(If(args[0].Inline(design, design.LastValue),
                                foundVariable.Assign(design.LastValue)));
            }
            
            design.ResultAdd(If(foundVariable.IsEqual(null),
                                Throw("System.InvalidOperationException", "The sequence did not contain any elements."), 
                                Return(foundVariable.Cast(design.ReturnType))));
        }
    }
}