using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static LinqRewrite.Extensions.VariableExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteLast
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.Iterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            
            var foundVariable = p.GlobalVariable(NullableType(p.ReturnType), Null);
            
            if (args.Length == 0)
                p.ForAdd(foundVariable.Assign(p.Last.Value));
            else
            {
                p.ForAdd(If(args[0].Inline(p, p.Last),
                            foundVariable.Assign(p.Last.Value)));
            }
            
            p.FinalAdd(If(foundVariable.IsEqual(Null),
                            CreateThrowException("System.InvalidOperationException", "The sequence did not contain any elements."), 
                            Return(foundVariable.Cast(p.ReturnType))));
            p.HasResultMethod = true;
        }

        public static ExpressionSyntax RewriteSimple(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (args.Length == 0) return null;
            RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            
            return p.SourceSize == null 
                ? null : p.CurrentCollection[p.CurrentCollection.Count - 1];
        }
    }
}