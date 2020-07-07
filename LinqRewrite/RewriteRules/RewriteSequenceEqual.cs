using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.AssertionExtension;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSequenceEqual
    {
        public static void Rewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            var collectionValue = args[0];
            if (!AssertNotNull(design, collectionValue)) return;
            if (ExpressionSimplifier.TryGetInt(design.ResultSize, out var resultSizeInt))
            {
                if (resultSizeInt == 0)
                {
                    InitialErrorAdd(design, Return((collectionValue.Access("Count").Invoke()).IsEqual(0)));
                    return;
                }
            }

            design.WrapWithTry = true;
            var itemType = collectionValue.ItemType(design);
            var enumeratorVariable = CreateGlobalVariable(design, ParseTypeName($"System.Collections.Generic.IEnumerator<{itemType}>"));
            design.InitialAdd(enumeratorVariable.Assign(Parenthesize(collectionValue.Cast(ParseTypeName($"IEnumerable<{itemType}>")))
                .Access("GetEnumerator").Invoke()));

            var equalityTestValue = args.Length switch
            {
                1 => enumeratorVariable.Access("Current", "Equals").Invoke(design.LastValue),
                2 => args[1].ReusableConst(design).Access("Equals").Invoke(design.LastValue, enumeratorVariable.Access("Current"))
            };
            design.ForAdd(If(Not(enumeratorVariable.Access("MoveNext").Invoke().And(equalityTestValue)), 
                            Return(false)));

            design.ResultAdd(If(enumeratorVariable.Access("MoveNext").Invoke(),
                                Return(false)));

            design.FinalAdd(enumeratorVariable.Access("Dispose").Invoke());
            design.ResultAdd(Return(true));
        }
    }
}