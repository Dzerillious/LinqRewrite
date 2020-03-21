using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteElementAtOrDefault
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            if (p.ResultSize != null && args.Length == 0) ConditionalExpression(
                p.CurrentCollection.Count <= args[0],
                p.CurrentCollection[args[0]],
                Default(p.ReturnType));
            
            var positionValue = args[0].ReusableConst(p);
            p.ForAdd(If(p.Indexer.IsEqual(positionValue),
                        Return(p.LastValue)));
            
            p.FinalAdd(Return(Default(p.ReturnType)));
            p.HasResultMethod = true;
        }
    }
}