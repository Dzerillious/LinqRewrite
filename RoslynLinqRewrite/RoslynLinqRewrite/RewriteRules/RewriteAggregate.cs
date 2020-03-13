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
            if (p.Iterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());

            var resultVariable = args.Length == 1 
                ? p.LocalVariable(p.ReturnType,  p.CurrentCollection[0])
                : p.LocalVariable(args[0].GetType(p), args[0]);

            var method = args.Length == 1 ? args[0] : args[1];
            p.ForAdd(resultVariable.Assign(method.Inline(p, resultVariable, p.Last)));

            p.FinalAdd(args.Length == 3 
                ? Return(args[2].Inline(p, resultVariable)) 
                : Return(resultVariable));
            p.HasResultMethod = true;
        }
    }
}