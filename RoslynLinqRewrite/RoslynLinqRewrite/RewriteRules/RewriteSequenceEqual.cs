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
            var collection = args[0];

            p.WrapWithTry = true;
            var enumerator = p.GlobalVariable(p.WrappedItemType("IEnumerator<", collection, ">"));
            p.PreUseAdd(enumerator.Assign(collection.Access("GetEnumerator").Invoke()));
            
            p.ForAdd(If(Not(enumerator.Access("MoveNext").Invoke()),
                CreateThrowException("InvalidOperationException", "Invalid sizes of sources")));

            if (args.Length == 1)
            {
                p.ForAdd(If(Not(enumerator.Access("Current", "Equals").Invoke(p.LastValue)),
                          Return(false)));
            }
            else
            {
                var inlined = args[1].ReusableConst(p);
                p.ForAdd(If(inlined.Access("Equals").Invoke(p.LastValue, enumerator.Access("Current")),
                            Return(false)));
            }
            
            p.FinalAdd(If(enumerator.Access("MoveNext").Invoke(),
                CreateThrowException("InvalidOperationException", "Invalid sizes of sources")));

            p.FinalAdd(enumerator.Access("Dispose").Invoke());
            p.FinalAdd(Return(true));

            p.HasResultMethod = true;
        }
    }
}