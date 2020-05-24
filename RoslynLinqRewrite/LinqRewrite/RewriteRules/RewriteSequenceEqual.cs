using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSequenceEqual
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            var collectionValue = args[0];
            if (!p.AssertNotNull(collectionValue)) return;
            if (ExpressionSimplifier.TryGetInt(p.ResultSize, out var resultSizeInt))
            {
                if (resultSizeInt == 0)
                {
                    p.InitialErrorAdd(Return((collectionValue.Access("Count").Invoke()).IsEqual(0)));
                    return;
                }
            }

            p.WrapWithTry = true;
            var itemType = collectionValue.ItemType(p);
            var enumeratorVariable = p.GlobalVariable(ParseTypeName($"System.Collections.Generic.IEnumerator<{itemType}>"));
            p.InitialAdd(enumeratorVariable.Assign(Parenthesize(collectionValue.Cast(ParseTypeName($"IEnumerable<{itemType}>")))
                .Access("GetEnumerator").Invoke()));

            var equalityTestValue = args.Length switch
            {
                1 => enumeratorVariable.Access("Current", "Equals").Invoke(p.LastValue),
                2 => args[1].ReusableConst(p).Access("Equals").Invoke(p.LastValue, enumeratorVariable.Access("Current"))
            };
            p.ForAdd(If(Not(enumeratorVariable.Access("MoveNext").Invoke().And(equalityTestValue)), 
                        Return(false)));

            p.ResultAdd(If(enumeratorVariable.Access("MoveNext").Invoke(),
                                            Return(false)));

            p.FinalAdd(enumeratorVariable.Access("Dispose").Invoke());
            p.ResultAdd(Return(true));
        }
    }
}