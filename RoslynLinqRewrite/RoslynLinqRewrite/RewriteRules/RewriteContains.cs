using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteContains
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            
            var element = p.Node.ArgumentList.Arguments.First().Expression;
            if (args.Length == 1)
            {
                p.ForAdd(If(p.LastValue.Value.IsEqual(element),
                            Return(true)));
            }
            else
            {
                var inlined = args[1].Reusable(p);
                p.ForAdd(If(inlined.Access("Equals").Invoke(p.LastValue.Value, element),
                            Return(true)));
            }
            
            p.FinalAdd(Return(false));
            p.HasResultMethod = true;
        }
    }
}