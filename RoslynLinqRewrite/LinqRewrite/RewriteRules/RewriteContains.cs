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
            
            var elementSyntax = p.Node.ArgumentList.Arguments.First().Expression;
            
            var elementEqualityValue = args.Length switch
            {
                0 => p.LastValue.IsEqual(elementSyntax),
                1 => args[1].ReusableConst(p).Access("Equals").Invoke(p.LastValue.Value, elementSyntax),
            };
            
            p.ForAdd(If(elementEqualityValue, Return(true)));
            p.FinalAdd(Return(false));
            p.HasResultMethod = true;
        }
    }
}