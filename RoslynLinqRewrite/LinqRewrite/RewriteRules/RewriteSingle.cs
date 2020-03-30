using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSingle
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            if (p.CanSimpleRewrite() && p.CurrentCollection?.Count == p.ResultSize && args.Length == 0) 
            {
                p.SimpleRewrite = ConditionalExpression(p.ResultSize.IsEqual(1),
                p.CurrentCollection[0],
                ThrowExpression("System.InvalidOperationException", "The sequence does not contain one element."));
            }
            
            var foundVariable = p.GlobalVariable(NullableType(p.ReturnType), null);
            if (args.Length == 0)
            {
                p.ForAdd(If(foundVariable.IsEqual(null),
                            foundVariable.Assign(p.LastValue), 
                            Throw("System.InvalidOperationException", "The sequence contains more than single matching element.")));
            }
            else
            {
                p.ForAdd(If(args[0].Inline(p, p.LastValue),
                            If(foundVariable.IsEqual(null),
                                foundVariable.Assign(p.LastValue),
                                Throw("System.InvalidOperationException", "The sequence contains more than single matching element."))));
            }
            
            p.FinalAdd(If(foundVariable.IsEqual(null),
                            Throw("System.InvalidOperationException", "The sequence did not contain any elements."), 
                            Return(foundVariable.Cast(p.ReturnType))));
        }
    }
}