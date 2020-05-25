using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.ExpressionSimplifier;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSingle
    {
        public static ExpressionSyntax SimpleRewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            if (args.Length != 0) return null;
            return ConditionalExpression(design.ResultSize.IsEqual(1),
                SimplifySubstitute(design.LastValue, design.CurrentIterator.ForIndexer, design.CurrentMin),
                ThrowExpression("System.InvalidOperationException", "The sequence does not contain one element."));
        }

        public static void Rewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            var foundVariable = VariableCreator.GlobalVariable(design, NullableType(design.ReturnType), null);
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
                            Throw("System.InvalidOperationException", "The sequence did not contain any elements."), 
                            Return(foundVariable.Cast(design.ReturnType))));
        }
    }
}