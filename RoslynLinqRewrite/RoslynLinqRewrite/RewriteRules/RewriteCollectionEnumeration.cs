using System;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using Shaman.Roslyn.LinqRewrite.Extensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Shaman.Roslyn.LinqRewrite.Constants;
using static Shaman.Roslyn.LinqRewrite.Extensions.OperatorExpressionExtensions;
using static Shaman.Roslyn.LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Shaman.Roslyn.LinqRewrite.Extensions.VariableExtensions;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteCollectionEnumeration
    {
        private const string SourceCount = "__sourceCount";
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex != p.Chain.Count - 1) throw new InvalidOperationException("Collection enumeration should be first expression.");

            var collectionType = p.Semantic.GetTypeFromExpression(p.Collection);
            if (collectionType is ArrayTypeSyntax)
            {
                var count = p.Code.CreateCollectionCount(p.Collection, false);
                
                p.GetFor = body => p.Rewrite.GetForStatement("__i", IntValue(0), count,
                    AggregateStatementSyntax(body));
                p.GetReverseFor = body => p.Rewrite.GetReverseForStatement("__i", IntValue(0), count,
                    AggregateStatementSyntax(body));
                
                
                p.LastItem = p.Collection.ArrayAccess("__i");
                p.ResultSize = count;
                p.SourceSize = count;
                return;
            }

            var collectionName = collectionType.ToString();
            if (collectionName.StartsWith(ListPrefix, StringComparison.OrdinalIgnoreCase) 
                || collectionName.StartsWith(SimpleListPrefix, StringComparison.OrdinalIgnoreCase))
            {
                p.PreForAdd( IfStatement(p.Collection.EqualsExpr(NullValue),
                    CreateThrowException("System.InvalidOperationException", "Collection was null.")));
                
                p.PreForAdd(LocalVariableCreation(SourceCount,
                    p.Collection.InvokeMethod("Count")));
                
                p.GetFor = body => p.Rewrite.GetForStatement("__i", IntValue(0), IdentifierName(SourceCount),
                    AggregateStatementSyntax(body));
                
                p.GetReverseFor = body => p.Rewrite.GetReverseForStatement("__i", IntValue(0), IdentifierName(SourceCount),
                    AggregateStatementSyntax(body));
                
                p.LastItem = p.Collection.ArrayAccess("__i");
                p.ResultSize = IdentifierName(SourceCount);
                p.SourceSize = IdentifierName(SourceCount);
            }
            else if (collectionName.StartsWith(IEnumerablePrefix, StringComparison.OrdinalIgnoreCase))
            {
                p.PreForAdd( IfStatement(p.Collection.EqualsExpr(NullValue),
                        CreateThrowException("System.InvalidOperationException", "Collection was null.")));
                
                p.GetFor = body => p.Rewrite.GetForEachStatement("__item", p.Collection, 
                    AggregateStatementSyntax(body));
                p.LastItem = IdentifierName("__item");
            }
        }
    }
}