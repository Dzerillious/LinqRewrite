using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteSequenceEqual
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());

            p.WrapWithTry = true;
            var enumeratorVariable = p.GlobalVariable(p.WrappedItemType("IEnumerator<", args[0], ">"));
            p.PreUseAdd(enumeratorVariable.Assign(args[0].Access("GetEnumerator").Invoke()));
            
            p.ForAdd(If(Not(enumeratorVariable.Access("MoveNext").Invoke()),
                        ThrowExpression("InvalidOperationException", "Invalid sizes of sources")));
            
            var equalityTestValue = args.Length switch
            {
                1 => enumeratorVariable.Access("Current", "Equals").Invoke(p.LastValue),
                2 => args[1].ReusableConst(p).Access("Equals").Invoke(p.LastValue, enumeratorVariable.Access("Current"))
            };
            p.ForAdd(If(Not(equalityTestValue), Return(false)));
            
            p.FinalAdd(If(enumeratorVariable.Access("MoveNext").Invoke(),
                ThrowExpression("InvalidOperationException", "Invalid sizes of sources")));

            p.FinalAdd(enumeratorVariable.Access("Dispose").Invoke());
            p.FinalAdd(Return(true));
        }
    }
}