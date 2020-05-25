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
        public static ExpressionSyntax SimpleRewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (args.Length != 0) return null;
            return ConditionalExpression(p.ResultSize.IsEqual(1),
                SimplifySubstitute(p.LastValue, p.CurrentIterator.ForIndexer, p.CurrentMin),
                ThrowExpression("System.InvalidOperationException", "The sequence does not contain one element."));
        }

        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            var foundVariable = VariableCreator.GlobalVariable(p, NullableType(p.ReturnType), null);
            if (args.Length == 0)
            {
                p.ForAdd(If(foundVariable.IsEqual(null),
                            foundVariable.Assign(p.LastValue), 
                            Throw("System.InvalidOperationException", "The sequence contains more than single matching element.")));
            }
            else
            {
                p.ForAdd(If(args[0].Inline(p, p.LastValue),
                            If(foundVariable.IsEqual(null),
                                foundVariable.Assign(p.LastValue),
                                Throw("System.InvalidOperationException", "The sequence contains more than single matching element."))));
            }
            p.ResultAdd(If(foundVariable.IsEqual(null),
                            Throw("System.InvalidOperationException", "The sequence did not contain any elements."), 
                            Return(foundVariable.Cast(p.ReturnType))));
        }
    }
}