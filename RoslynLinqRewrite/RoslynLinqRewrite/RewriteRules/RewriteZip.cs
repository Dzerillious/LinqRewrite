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
            var collection = args[0];
            var method = args[1];

            p.WrapWithTry = true;
            var enumerator = p.GlobalVariable(p.WrappedItemType("IEnumerator<", collection, ">"));
            p.PreUseAdd(enumerator.Assign(collection.Access("GetEnumerator").Invoke()));
            
            p.ForAdd(If(Not(enumerator.Access("MoveNext").Invoke()),
                CreateThrowException("InvalidOperationException", "Invalid sizes of sources")));

            p.LastValue = method.Inline(p, p.LastValue, new TypedValueBridge(collection.ItemType(p), enumerator.Access("Current")));
            
            p.FinalAdd(If(enumerator.Access("MoveNext").Invoke(),
                CreateThrowException("InvalidOperationException", "Invalid sizes of sources")));

            p.FinalAdd(enumerator.Access("Dispose").Invoke());
            p.ListEnumeration = false;
        }
    }
}