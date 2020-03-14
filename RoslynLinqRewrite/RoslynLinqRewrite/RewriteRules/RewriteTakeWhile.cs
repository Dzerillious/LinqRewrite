using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteTakeWhile
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            
            p.LastValue = p.LastValue.ReusableConst(p);
            var value = args.Length switch
            {
                1 when args[0].OldVal is SimpleLambdaExpressionSyntax => args[0].Inline(p, p.LastValue),
                1 => args[0].Inline(p, p.LastValue, p.Indexer)
            };
            
            p.ForAdd(If(Not(value), Break()));
            p.ModifiedEnumeration = true;
        }
    }
}