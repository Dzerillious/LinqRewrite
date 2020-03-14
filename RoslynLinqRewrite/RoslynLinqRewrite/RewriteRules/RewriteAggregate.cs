using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteAggregate
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            
            var aggregationValue = args.Length switch
            {
                1 => args[0],
                _ => args[1]
            };

            var resultValue = args.Length switch
            {
                1 => p.CurrentCollection[0],
                _ => new TypedValueBridge(p, args[0])
            };

            p.ForAdd(resultValue.Assign(aggregationValue.Inline(p, resultValue, p.LastValue)));
            p.FinalAdd(Return(args.Length switch
            {
                3 => args[2].Inline(p, resultValue),
                _ => resultValue
            }));
            p.HasResultMethod = true;
        }
    }
}