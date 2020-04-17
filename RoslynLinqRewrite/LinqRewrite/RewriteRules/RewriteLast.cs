using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.ExpressionSimplifier;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteLast
    {
        public static ExpressionSyntax SimpleRewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (args.Length != 0) return null;
            return SimplifySubstitute(p.LastValue, p.CurrentIterator.ForIndexer, p.CurrentMax);
        }

        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (!p.AssertResultSizeGreaterEqual(0, true)) return;
            var foundVariable = p.GlobalVariable(NullableType(p.ReturnType), null);
            
            if (args.Length == 0)
                p.ForAdd(foundVariable.Assign(p.LastValue));
            else
            {
                p.ForAdd(If(args[0].Inline(p, p.LastValue),
                            foundVariable.Assign(p.LastValue)));
            }
            
            p.ResultAdd(If(foundVariable.IsEqual(null),
                            Throw("System.InvalidOperationException", "The sequence did not contain any elements."), 
                            Return(foundVariable.Cast(p.ReturnType))));
        }
    }
}