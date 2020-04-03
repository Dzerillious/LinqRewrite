using System;
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
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            var collectionValue = args[0];
            if (IsNull(collectionValue, p))
            {
                p.PreForAdd(Throw("System.InvalidOperationException", "Collection was null"));
                return;
            }

            p.WrapWithTry = true;
            var itemType = collectionValue.ItemType(p);
            var enumeratorVariable = p.GlobalVariable(ParseTypeName($"IEnumerator<{itemType}>"));
            p.InitialAdd(enumeratorVariable.Assign(Parenthesize(collectionValue.Cast(ParseTypeName($"IEnumerable<{itemType}>")))
                .Access("GetEnumerator").Invoke()));

            var equalityTestValue = args.Length switch
            {
                1 => enumeratorVariable.Access("Current", "Equals").Invoke(p.LastValue),
                2 => args[1].ReusableConst(p).Access("Equals").Invoke(p.LastValue, enumeratorVariable.Access("Current"))
            };
            p.ForAdd(If(Not(enumeratorVariable.Access("MoveNext").Invoke().And(equalityTestValue)), 
                        Return(false)));
            
            p.CurrentIterator.PostFor.Add(If(enumeratorVariable.Access("MoveNext").Invoke(),
                                            Return(false)));

            p.FinalAdd(enumeratorVariable.Access("Dispose").Invoke());
            p.ResultAdd(Return(true));
        }
    }
}