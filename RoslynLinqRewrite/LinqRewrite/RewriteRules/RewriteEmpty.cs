﻿using System.Linq;
using LinqRewrite.DataStructures;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using LinqRewrite.Core;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteEmpty
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args, InvocationExpressionSyntax invocation)
        {
            p.Variables.Where(x => !x.IsGlobal).ForEach(x => x.IsUsed = false);
            if (p.RewriteChain.Count == 1) p.NotRewrite = true;

            var access = (MemberAccessExpressionSyntax) invocation.Expression;
            var name = (GenericNameSyntax) access.Name;
            var type = name.TypeArgumentList.Arguments[0];
            
            p.Iterators.Add(p.CurrentIterator = new IteratorParameters(p));
            p.ForMin = p.ForReMin = 0;
            p.ForMax = 0;
            p.ForReMax = -1;
            
            p.ResultSize = 0;
            p.SourceSize = 0;
            p.ListEnumeration = false;
            
            p.CurrentIterator.ForIndexer = p.LocalVariable(Int);
            if (p.CurrentIndexer == null)
            {
                p.CurrentIterator.CurrentIndexer = p.CurrentIterator.ForIndexer;
                p.CurrentIterator.CurrentIndexer.IsGlobal = true;
            }
            p.LastValue = new TypedValueBridge(type, Default(type));
            p.CurrentCollection = null;
        }
    }
}