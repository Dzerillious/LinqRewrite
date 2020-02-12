using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using Shaman.Roslyn.LinqRewrite.RewriteRules;

namespace Shaman.Roslyn.LinqRewrite
{
    public static class InvocationRewriter
    {
        public static ExpressionSyntax TryRewrite(RewriteParameters parameters)
        {
            var count = parameters.Chain.Count;
            RewriteRange.Rewrite(parameters, --count);
            RewriteToArray.Rewrite(parameters, --count);

            // var collectionType = parameters.Data.Semantic.GetTypeInfo(parameters.Collection).Type;
            // var collectionItemType = parameters.Info.GetItemType(collectionType);
            var body = parameters.GetMethodBody();
            return parameters.Rewrite.GetInvocationExpression(parameters, body);
            //     if (Constants.RootMethodsThatRequireYieldReturn.Contains(aggregationMethod)) return RewriteWhenNeedsYieldReturn.Rewrite(parameters);
            //     if (aggregationMethod.Contains(".Sum")) return RewriteSum.Rewrite(parameters);
            //     if (aggregationMethod.Contains(".Max")) return RewriteMinMax.Rewrite(parameters);
            //     if (aggregationMethod.Contains(".Min")) return RewriteMinMax.Rewrite(parameters);
            //     if (aggregationMethod.Contains(".Average")) return RewriteAverage.Rewrite(parameters);
            //
            //     return aggregationMethod switch
            //     {
            //         Constants.AnyMethod                          => RewriteAny.Rewrite(parameters),
            //         Constants.AnyWithConditionMethod             => RewriteAny.Rewrite(parameters),
            //         Constants.AllWithConditionMethod             => RewriteAll.Rewrite(parameters),
            //         
            //         Constants.ListForEachMethod                  => RewriteForEach.Rewrite(parameters),
            //         Constants.EnumerableForEachMethod            => RewriteForEach.Rewrite(parameters),
            //         
            //         Constants.ContainsMethod                     => RewriteContains.Rewrite(parameters),
            //         Constants.CountMethod                        => RewriteCount.Rewrite(parameters),
            //         Constants.CountWithConditionMethod           => RewriteCount.Rewrite(parameters),
            //         Constants.LongCountMethod                    => RewriteCount.Rewrite(parameters),
            //         Constants.LongCountWithConditionMethod       => RewriteCount.Rewrite(parameters),
            //         
            //         Constants.ElementAtMethod                    => RewriteElementAt.Rewrite(parameters),
            //         Constants.ElementAtOrDefaultMethod           => RewriteElementAt.Rewrite(parameters),
            //         
            //         Constants.FirstMethod                        => RewriteFirst.Rewrite(parameters),
            //         Constants.FirstWithConditionMethod           => RewriteFirst.Rewrite(parameters),
            //         Constants.FirstOrDefaultMethod               => RewriteFirstOrDefault.Rewrite(parameters),
            //         Constants.FirstOrDefaultWithConditionMethod  => RewriteFirstOrDefault.Rewrite(parameters),
            //         Constants.LastOrDefaultMethod                => RewriteLastOrDefault.Rewrite(parameters),
            //         Constants.LastOrDefaultWithConditionMethod   => RewriteLastOrDefault.Rewrite(parameters),
            //         Constants.LastMethod                         => RewriteLast.Rewrite(parameters),
            //         Constants.LastWithConditionMethod            => RewriteLast.Rewrite(parameters),
            //         Constants.SingleMethod                       => RewriteSingle.Rewrite(parameters),
            //         Constants.SingleWithConditionMethod          => RewriteSingle.Rewrite(parameters),
            //         Constants.SingleOrDefaultMethod              => RewriteSingleOrDefault.Rewrite(parameters),
            //         Constants.SingleOrDefaultWithConditionMethod => RewriteSingleOrDefault.Rewrite(parameters),
            //         
            //         Constants.RangeMethod                        => RewriteRange.Rewrite(parameters),
            //         Constants.ReverseMethod                      => RewriteToList.Rewrite(parameters),
            //         Constants.ToListMethod                       => RewriteToList.Rewrite(parameters),
            //         Constants.ToDictionaryWithKeyValueMethod     => RewriteToDict.Rewrite(parameters),
            //         Constants.ToArrayMethod                      => RewriteToArray.Rewrite(parameters),
            //         _ => null
            //     };
            // }
        }
    }
}