﻿using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteTakeWhile
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            p.LastValue = p.LastValue.Reusable(p);
            var value = args.Length switch
            {
                1 when args[0].OldVal is SimpleLambdaExpressionSyntax => args[0].Inline(p, p.LastValue),
                1 => args[0].Inline(p, p.LastValue, p.Indexer)
            };
            if (p.Iterators.All.Count > 1)
            {
                var lastTakeWhile = VariableCreator.GlobalVariable(p, Bool, false);
                p.ForAdd(If(Not(value).Or(lastTakeWhile), Block(
                    lastTakeWhile.Assign(true),
                    Break()))
                );
            }
            else p.ForAdd(If(Not(value), Break()));
            p.ListEnumeration = false;
            p.ModifiedEnumeration = true;
        }
    }
}