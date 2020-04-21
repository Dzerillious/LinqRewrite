using System.Linq;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.ExpressionSimplifier;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteAggregate
    {
        public static ExpressionSyntax SimpleRewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (!TryGetInt(p.ResultSize, out var intSize) || intSize > 10)
                return null;

            var items = Enumerable.Range(0, intSize).Select(x
                => new TypedValueBridge(p.LastValue.Type, SimplifySubstitute(p.LastValue, p.CurrentIterator.ForIndexer, p.CurrentMin + x)));
            
            var simple = args.Length == 1 
                ? items.Aggregate((x, y) => args[0].Inline(p, x, y))
                : items.Aggregate(new TypedValueBridge(args[0].GetType(p), args[0]), (x, y) => args[1].Inline(p, x, y));

            return args.Length == 3
                ? args[2].Inline(p, simple).Simplify()
                : simple.Simplify();
        }
        
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (args.Length == 1 && !p.AssertResultSizeGreaterEqual(1, true)) return;
            var aggregationValue = args.Length switch
            {
                1 => args[0],
                _ => args[1]
            };

            var resultValue = p.ListEnumeration
                ? ListAggregate(p, aggregationValue, args)
                : EnumerableAggregate(p, aggregationValue, args);
            
            p.ResultAdd(Return(args.Length switch
            {
                3 => args[2].Inline(p, resultValue),
                _ => resultValue
            }));
        }

        private static TypedValueBridge ListAggregate(RewriteParameters p, RewrittenValueBridge aggregationValue,  RewrittenValueBridge[] args)
        {
            var resultValue = args.Length switch
            {
                1 => p.CurrentCollection[0],
                _ => new TypedValueBridge(p, args[0])
            };
            if (args.Length == 1) p.CurrentIterator.ForFrom += p.CurrentIterator.ForInc;
            
            var resultVariable = p.GlobalVariable(p.ReturnType, resultValue);
            p.ForAdd(resultVariable.Assign(aggregationValue.Inline(p, resultVariable, p.LastValue)));
            return resultVariable;
        }
        
        private static TypedValueBridge EnumerableAggregate(RewriteParameters p, RewrittenValueBridge aggregationValue,  RewrittenValueBridge[] args)
        {
            var resultValue = args.Length switch
            {
                1 => new TypedValueBridge(p.LastValue.Type, Default(p.LastValue.Type)),
                _ => new TypedValueBridge(p, args[0])
            };
            var resultVariable = p.GlobalVariable(p.ReturnType, resultValue);
            var firstVariable = p.GlobalVariable(Bool, true);
            
            p.ForAdd(If(firstVariable,
                        Block(
                    resultVariable.Assign(p.LastValue),
                                    firstVariable.Assign(false),
                                    Continue()
                            ),
                       resultVariable.Assign(aggregationValue.Inline(p, resultVariable, p.LastValue))));

            if (args.Length == 1 && !p.Unchecked) p.ResultAdd(If(firstVariable, Throw("System.InvalidOperationException", "The sequence did not contain enough elements.")));
            return resultVariable;
        }
    }
}