using System;
using LinqRewrite.DataStructures;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.VariableExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSingleOrDefault
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.Iterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            if (p.ResultSize != null && args.Length == 0) ConditionalExpression(p.CurrentCollection.Count.IsEqual(1),
                p.CurrentCollection[0],
                Default(p.ReturnType));
            
            var foundVariable = p.GlobalVariable(NullableType(p.ReturnType), Null);

            if (args.Length == 0)
            {
                p.ForAdd(If(foundVariable.IsEqual(Null),
                            foundVariable.Assign(p.Last.Value), 
                            Return(Default(p.ReturnType))));
            }
            else
            {
                p.ForAdd(If(args[0].Inline(p, p.Last),
                            If(foundVariable.IsEqual(Null),
                                foundVariable.Assign(p.Last.Value),
                                Return(Default(p.ReturnType)))));
            }
            
            p.FinalAdd(If(foundVariable.IsEqual(Null),
                            Return(Default(p.ReturnType)), 
                            Return(foundVariable.Cast(p.ReturnType))));
            p.HasResultMethod = true;
        }
    }
}