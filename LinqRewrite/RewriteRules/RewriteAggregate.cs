using System.Collections.Immutable;
using System.Linq;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.AssertionExtension;
using static LinqRewrite.Extensions.ExpressionSimplifier;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteAggregate
    {
        public static ExpressionSyntax SimpleRewrite(RewriteDesign design, ImmutableArray<ValueBridge> args)
        {
            if (!TryGetInt(design.ResultSize, out var intSize) || intSize > Constants.SimpleRewriteMaxMediumElements)
                return null;

            var items = Enumerable.Range(0, intSize)
                .Select(i=> new TypedValueBridge(design.LastValue.Type, Substitute(design.LastValue, design.CurrentIterator.ForIndexer, design.CurrentMin + i)));
            
            var simpleValue = args.Length == 1 
                ? items.Aggregate((x, y) => args[0].Inline(design, x, y))
                : items.Aggregate(new TypedValueBridge(args[0].GetType(design), args[0]), (x, y) => args[1].Inline(design, x, y));

            return args.Length == 3
                ? args[2].Inline(design, simpleValue)
                : simpleValue;
        }
        
        public static void Rewrite(RewriteDesign design, ImmutableArray<ValueBridge> args)
        {
            if (args.Length == 1 && !AssertResultSizeGreaterEqual(design, 1, true)) return;
            var aggregationValue = args.Length switch
            {
                1 => args[0],
                _ => args[1]
            };

            var resultValue = design.ListEnumeration 
                ? ListAggregate(design, aggregationValue, args)
                : EnumerableAggregate(design, aggregationValue, args);
            
            design.ResultAdd(Return(args.Length switch
            {
                3 => args[2].Inline(design, resultValue),
                _ => resultValue
            }));
        }

        private static TypedValueBridge ListAggregate(RewriteDesign design, ValueBridge aggregationValue, ImmutableArray<ValueBridge> args)
        {
            var resultValue = args.Length switch
            {
                1 => design.CurrentCollection[design.CurrentIterator.ForFrom],
                _ => new TypedValueBridge(design, args[0])
            };
            if (args.Length == 1) design.CurrentIterator.ForFrom += design.CurrentIterator.ForInc;
            
            var resultVariable = CreateGlobalVariable(design, design.Info.ReturnType, resultValue);
            design.ForAdd(resultVariable.Assign(aggregationValue.Inline(design, resultVariable, design.LastValue)));
            return resultVariable;
        }
        
        private static TypedValueBridge EnumerableAggregate(RewriteDesign design, ValueBridge aggregationValue, ImmutableArray<ValueBridge> args)
        {
            var resultValue = args.Length switch
            {
                1 => new TypedValueBridge(design.LastValue.Type, Default(design.LastValue.Type)),
                _ => new TypedValueBridge(design, args[0])
            };
            var resultVariable = CreateGlobalVariable(design, design.Info.ReturnType, resultValue);
            var firstVariable = CreateGlobalVariable(design, Bool, true);
            
            design.ForAdd(If(firstVariable, Block(
                    resultVariable.Assign(design.LastValue),
                                      firstVariable.Assign(false),
                                      Continue()
                                ),
                            resultVariable.Assign(aggregationValue.Inline(design, resultVariable, design.LastValue))));

            if (args.Length == 1 && !design.Unchecked) design.ResultAdd(If(firstVariable, Throw("System.InvalidOperationException", "The sequence did not contain enough elements.")));
            return resultVariable;
        }
    }
}