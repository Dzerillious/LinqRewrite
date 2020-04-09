using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteLastOrDefault
    {
        public static ExpressionSyntax SimpleRewrite(RewriteParameters p, RewrittenValueBridge[] args)
            => ConditionalExpression(p.ResultSize.IsEqual(0),
                Default(p.ReturnType),
                ExpressionSimplifier.SimplifySubstitute(p.LastValue, p.CurrentIterator.ForIndexer, p.CurrentMax));
        
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            var foundVariable = p.GlobalVariable(NullableType(p.ReturnType), null);
            
            if (args.Length == 0)
                p.ForAdd(foundVariable.Assign(p.LastValue));
            else
            {
                p.ForAdd(If(args[0].Inline(p, p.LastValue),
                            foundVariable.Assign(p.LastValue)));
            }
            
            p.ResultAdd(If(foundVariable.IsEqual(null),
                            Return(Default(p.ReturnType)), 
                            Return(foundVariable.Cast(p.ReturnType))));
        }
    }
}