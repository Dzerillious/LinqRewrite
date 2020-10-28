using System.Collections.Immutable;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.ExpressionSimplifier;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteLastOrDefault
    {
        public static ExpressionSyntax SimpleRewrite(RewriteDesign design, ImmutableArray<ValueBridge> args)
        {
            if (args.Length != 0) return null;
            return ConditionalExpression(design.ResultSize.IsEqual(0),
                Default(design.Info.ReturnType),
                Substitute(design.LastValue, design.CurrentIterator.ForIndexer, design.CurrentMax));
        }

        public static void Rewrite(RewriteDesign design, ImmutableArray<ValueBridge> args)
        {
            var foundVariable = CreateGlobalVariable(design, NullableType(design.Info.ReturnType), null);
            
            if (args.Length == 0)
                design.ForAdd(foundVariable.Assign(design.LastValue));
            else
            {
                design.ForAdd(If(args[0].Inline(design, design.LastValue),
                                foundVariable.Assign(design.LastValue)));
            }
            
            design.ResultAdd(If(foundVariable.IsEqual(null),
                                Return(Default(design.Info.ReturnType)), 
                                Return(foundVariable.Cast(design.Info.ReturnType))));
        }
    }
}