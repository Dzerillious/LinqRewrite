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
            if (p.ResultSize != null && args.Length == 0) p.SimpleRewrite = ConditionalExpression(
                p.CurrentCollection.Count.IsEqual(0),
                p.CurrentCollection[0],
                Default(p.ReturnType));
            
            if (args.Length == 0)
                p.ForAdd(Return(p.LastValue.Value));
            else
            {
                p.ForAdd(If(args[0].Inline(p, p.LastValue),
                            Return(p.LastValue.Value)));
            }
            
            p.FinalAdd(Return(Default(p.ReturnType)));
            p.HasResultMethod = true;
        }
    }
}