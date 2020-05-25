using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.ExpressionSimplifier;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSingleOrDefault
    {
        public static ExpressionSyntax SimpleRewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            if (args.Length != 0) return null;
            return ConditionalExpression(design.CurrentCollection.Count.IsEqual(1),
                SimplifySubstitute(design.LastValue, design.CurrentIterator.ForIndexer, design.CurrentMin),
                ConditionalExpression(design.ResultSize.IsEqual(0),
                    Default(design.ReturnType),
                    ThrowExpression("System.InvalidOperationException", "The sequence contains more than one element.")));
        }

        public static void Rewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            var foundVariable = CreateGlobalVariable(design, NullableType(design.ReturnType), null);
            if (args.Length == 0)
            {
                design.ForAdd(If(foundVariable.IsEqual(null),
                    foundVariable.Assign(design.LastValue), 
                    Throw("System.InvalidOperationException", "The sequence contains more than single matching element.")));
            }
            else
            {
                design.ForAdd(If(args[0].Inline(design, design.LastValue),
                    If(foundVariable.IsEqual(null),
                        foundVariable.Assign(design.LastValue),
                        Throw("System.InvalidOperationException", "The sequence contains more than single matching element."))));
            }
            design.ResultAdd(If(foundVariable.IsEqual(null),
                Return(Default(design.ReturnType)), 
                Return(foundVariable.Cast(design.ReturnType))));
        }
    }
}