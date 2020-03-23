using System;
using LinqRewrite.DataStructures;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSingleOrDefault
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            if (p.ResultSize != null && args.Length == 0) ConditionalExpression(p.CurrentCollection.Count.IsEqual(1),
                p.CurrentCollection[0],
                Default(p.ReturnType));
            
            var foundVariable = p.GlobalVariable(NullableType(p.ReturnType), null);
            if (args.Length == 0)
            {
                p.ForAdd(If(foundVariable.IsEqual(null),
                            foundVariable.Assign(p.LastValue), 
                            Return(Default(p.ReturnType))));
            }
            else
            {
                p.ForAdd(If(args[0].Inline(p, p.LastValue),
                            If(foundVariable.IsEqual(null),
                                foundVariable.Assign(p.LastValue),
                                Return(Default(p.ReturnType)))));
            }
            
            p.FinalAdd(If(foundVariable.IsEqual(null),
                            Return(Default(p.ReturnType)), 
                            Return(foundVariable.Cast(p.ReturnType))));
        }
    }
}