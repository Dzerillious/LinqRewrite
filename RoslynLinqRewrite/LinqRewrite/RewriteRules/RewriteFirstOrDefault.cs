using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteFirstOrDefault
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            if (p.CanSimpleRewrite() && p.SimpleEnumeration && p.FirstCollection != null && args.Length == 0) 
                p.SimpleRewrite = ConditionalExpression(p.FirstCollection.Count.IsEqual(0),
                    Default(p.ReturnType),
                    ExpressionSimplifier.SimplifySubstitute(p.LastValue, p.CurrentIterator.ForIndexer, p.CurrentMin));
            
            if (args.Length == 0)
                p.ForAdd(Return(p.LastValue));
            else
            {
                p.ForAdd(If(args[0].Inline(p, p.LastValue),
                            Return(p.LastValue)));
            }
            
            p.ResultAdd(Return(Default(p.ReturnType)));
        }
    }
}