using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;

namespace Shaman.Roslyn.LinqRewrite.Services
{
    public class RewriteLinqService
    {
        private static RewriteLinqService _instance;
        public static RewriteLinqService Instance => _instance ??= new RewriteLinqService();

        private readonly RewriteLinqRules _rules;
        public RewriteLinqService()
        {
            _rules = RewriteLinqRules.Instance;
        }
        
        public ExpressionSyntax TryRewrite(string aggregationMethod, ExpressionSyntax collection,
            ITypeSymbol semanticReturnType, List<LinqStep> chain, InvocationExpressionSyntax node)
        {
            var returnType = SyntaxFactory.ParseTypeName(semanticReturnType.ToDisplayString());
            if (Constants.RootMethodsThatRequireYieldReturn.Contains(aggregationMethod))
                return _rules.RewriteWhenNeedsYieldReturn(returnType, collection, chain);

            if (aggregationMethod.Contains(".Sum"))
                return _rules.RewriteSum(returnType, collection, chain, node);

            if (aggregationMethod.Contains(".Max") || aggregationMethod.Contains(".Min"))
                return _rules.RewriteMinMax(returnType, aggregationMethod, collection, chain, node);

            if (aggregationMethod.Contains(".Average"))
                return _rules.RewriteAverage(returnType, collection, chain, node);

            return aggregationMethod switch
            {
                Constants.AnyMethod => _rules.RewriteAny(aggregationMethod, collection, chain),
                Constants.AnyWithConditionMethod => _rules.RewriteAny(aggregationMethod, collection, chain),
                Constants.ListForEachMethod => _rules.RewriteForEach(collection, chain),
                Constants.EnumerableForEachMethod => _rules.RewriteForEach(collection, chain),
                Constants.ContainsMethod => _rules.RewriteContains(collection, chain, node),
                Constants.AllWithConditionMethod => _rules.RewriteAll(collection, chain), // All alone does not exist
                Constants.CountMethod => _rules.RewriteCount(returnType, aggregationMethod, collection, chain),
                Constants.CountWithConditionMethod => _rules.RewriteCount(returnType, aggregationMethod, collection, chain),
                Constants.LongCountMethod => _rules.RewriteCount(returnType, aggregationMethod, collection, chain),
                Constants.LongCountWithConditionMethod => _rules.RewriteCount(returnType, aggregationMethod, collection, chain),
                Constants.ElementAtMethod => _rules.RewriteElementAt(returnType, aggregationMethod, collection, chain, node),
                Constants.ElementAtOrDefaultMethod => _rules.RewriteElementAt(returnType, aggregationMethod, collection, chain, node),
                Constants.FirstMethod => _rules.RewriteFirst(returnType, aggregationMethod, collection, chain),
                Constants.FirstWithConditionMethod => _rules.RewriteFirst(returnType, aggregationMethod, collection, chain),
                Constants.FirstOrDefaultMethod => _rules.RewriteFirstOrDefault(returnType, aggregationMethod, collection, chain),
                Constants.FirstOrDefaultWithConditionMethod => _rules.RewriteFirstOrDefault(returnType, aggregationMethod, collection, chain),
                Constants.LastOrDefaultMethod => _rules.RewriteLastOrDefault(returnType, aggregationMethod, collection, chain),
                Constants.LastOrDefaultWithConditionMethod => _rules.RewriteLastOrDefault(returnType, aggregationMethod, collection, chain),
                Constants.LastMethod => _rules.RewriteLast(returnType, aggregationMethod, collection, chain),
                Constants.LastWithConditionMethod => _rules.RewriteLast(returnType, aggregationMethod, collection, chain),
                Constants.SingleMethod => _rules.RewriteSingle(returnType, aggregationMethod, collection, chain),
                Constants.SingleWithConditionMethod => _rules.RewriteSingle(returnType, aggregationMethod, collection, chain),
                Constants.SingleOrDefaultMethod => _rules.RewriteSingleOrDefault(returnType, aggregationMethod, collection, chain),
                Constants.SingleOrDefaultWithConditionMethod => _rules.RewriteSingleOrDefault(returnType, aggregationMethod, collection, chain),
                Constants.ToListMethod => _rules.RewriteToList(returnType, aggregationMethod, collection, semanticReturnType, chain),
                Constants.ReverseMethod => _rules.RewriteToList(returnType, aggregationMethod, collection, semanticReturnType, chain),
                Constants.ToDictionaryWithKeyValueMethod => _rules.RewriteToDict(returnType, aggregationMethod, collection, chain, node), /*aggregationMethod == ToDictionaryWithKeyMethod || */
                Constants.ToArrayMethod => _rules.RewriteToArray(returnType, collection, chain),
                _ => null
            };
        }
    }
}