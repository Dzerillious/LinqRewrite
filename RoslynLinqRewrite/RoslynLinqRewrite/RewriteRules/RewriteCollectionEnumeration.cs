﻿using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using Shaman.Roslyn.LinqRewrite.Extensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Shaman.Roslyn.LinqRewrite.Constants;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Shaman.Roslyn.LinqRewrite.Extensions.VariableExtensions;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteCollectionEnumeration
    {
        private const string SourceCount = "__sourceCount";
        private const string IndexerVariable = "__i";
        private const string ItemVariable = "__item";
        
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex != p.Chain.Count - 1) throw new InvalidOperationException("Collection enumeration should be first expression.");

            var collectionType = p.Semantic.GetTypeFromExpression(p.Collection);
            var collectionName = collectionType.ToString();
            
            if (collectionType is ArrayTypeSyntax)
                ArrayEnumeration(p);
            else if (collectionName.StartsWith(ListPrefix, StringComparison.OrdinalIgnoreCase))
                ListEnumeration(p);
            else if (collectionName.StartsWith(IEnumerablePrefix, StringComparison.OrdinalIgnoreCase))
                IEnumerableEnumeration(p);
        }

        public static void ArrayEnumeration(RewriteParameters p)
        {
            var count = p.Code.CreateCollectionCount(p.Collection, false);
                
            p.GetFor = body => p.Rewrite.GetForStatement(IndexerVariable, 0, count,
                AggregateStatementSyntax(body));
            p.GetReverseFor = body => p.Rewrite.GetReverseForStatement(IndexerVariable, 0, count,
                AggregateStatementSyntax(body));
                
                
            p.LastItem = p.Collection.ArrayAccess(IndexerVariable);
            p.ResultSize = count;
            p.SourceSize = count;
        }

        public static void ListEnumeration(RewriteParameters p)
        {
            p.PreForAdd( If(p.Collection.EqualsExpr(NullValue),
                CreateThrowException("System.InvalidOperationException", "Collection was null.")));
                
            p.PreForAdd(LocalVariableCreation(SourceCount,
                p.Collection.Access("Count").Invoke()));
                
            p.GetFor = body => p.Rewrite.GetForStatement(IndexerVariable, 0, SourceCount,
                AggregateStatementSyntax(body));
                
            p.GetReverseFor = body => p.Rewrite.GetReverseForStatement(IndexerVariable, 0, SourceCount,
                AggregateStatementSyntax(body));
                
            p.LastItem = p.Collection.ArrayAccess(IndexerVariable);
            p.ResultSize = IdentifierName(SourceCount);
            p.SourceSize = IdentifierName(SourceCount);
        }

        public static void IEnumerableEnumeration(RewriteParameters p)
        {
            p.PreForAdd(If(p.Collection.EqualsExpr(NullValue),
                CreateThrowException("System.InvalidOperationException", "Collection was null.")));
                
            p.GetFor = body => p.Rewrite.GetForEachStatement(ItemVariable, p.Collection, 
                AggregateStatementSyntax(body));
            p.LastItem = IdentifierName(ItemVariable);
        }
    }
}