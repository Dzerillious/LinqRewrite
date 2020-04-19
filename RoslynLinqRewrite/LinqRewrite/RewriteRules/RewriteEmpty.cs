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
            var access = (MemberAccessExpressionSyntax) invocation.Expression;
            var name = (GenericNameSyntax) access.Name;
            var type = name.TypeArgumentList.Arguments[0];
            
            if (p.RewriteChain.Count == 1)
            {
                p.NotRewrite = true;
                return;
            }

            p.FirstCollection = p.CurrentCollection = null;
            p.AddIterator();
            
            p.CurrentIterator.IgnoreIterator = true;
            p.CurrentIterator.ForFrom = 0;
            p.CurrentIterator.ForTo = 0;
            p.CurrentIterator.ForIndexer = p.LocalVariable(Int, 0);
            
            p.ResultSize = 0;
            p.SourceSize = 0;
            p.ListEnumeration = true;
            p.SimpleEnumeration = true;
            
            if (p.CurrentIndexer == null)
            {
                p.CurrentIterator.Indexer = p.CurrentIterator.ForIndexer;
                p.CurrentIterator.Indexer.IsGlobal = true;
            }
            p.LastValue = new TypedValueBridge(type, Default(type));
            p.CurrentCollection = null;
        }
    }
}