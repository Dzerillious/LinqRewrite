using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteLastOrDefault
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            if (p.CanSimpleRewrite() && p.ListEnumeration && p.CurrentCollection?.Count == p.ResultSize && args.Length == 0) 
            {
                p.SimpleRewrite = ConditionalExpression(
                p.CurrentCollection.Count.IsEqual(0),
                Default(p.ReturnType),
                p.CurrentCollection[p.CurrentCollection.Count - 1]);
                return;
            }
            
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