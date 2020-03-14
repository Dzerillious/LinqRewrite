using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteZip
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            var collectionValue = args[0];
            var methodValue = args[1];

            p.WrapWithTry = true;
            var enumeratorVariable = p.GlobalVariable(p.WrappedItemType("IEnumerator<", collectionValue, ">"));
            p.PreUseAdd(enumeratorVariable.Assign(collectionValue.Access("GetEnumerator").Invoke()));
            
            p.ForAdd(If(Not(enumeratorVariable.Access("MoveNext").Invoke()),
                CreateThrowException("InvalidOperationException", "Invalid sizes of sources")));

            p.LastValue = methodValue.Inline(p, p.LastValue, new TypedValueBridge(collectionValue.ItemType(p), enumeratorVariable.Access("Current")));
            
            p.FinalAdd(If(enumeratorVariable.Access("MoveNext").Invoke(),
                CreateThrowException("InvalidOperationException", "Invalid sizes of sources")));

            p.FinalAdd(enumeratorVariable.Access("Dispose").Invoke());
            p.ListEnumeration = false;
        }
    }
}