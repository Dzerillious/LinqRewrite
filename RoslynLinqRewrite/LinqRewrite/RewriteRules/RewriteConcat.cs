using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteConcat
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            var sourceSizeValue = p.SourceSize;
            var resultSizeValue = p.ResultSize;
            var collectionValue = args[0];
            if (!p.AssertNotNull(collectionValue)) return;

            LocalVariable itemVariable;
            var lastVariable = p.TryGetVariable(p.LastValue);
            if (lastVariable != null)
            {
                itemVariable = lastVariable;
            }
            else
            {
                itemVariable = p.GlobalVariable(p.LastValue.Type);
                p.ForAdd(itemVariable.Assign(p.LastValue));
                p.LastValue = new TypedValueBridge(p.LastValue.Type, itemVariable);
            }
            itemVariable.IsGlobal = true;
            
            p.AddIterator(collectionValue);
            var collectionType = p.Data.GetTypeInfo(collectionValue).Type;
            RewriteCollectionEnumeration.RewriteOther(p, new CollectionValueBridge(p, collectionType, collectionValue, true), itemVariable, true);

            if (sourceSizeValue != null && p.SourceSize != null) p.SourceSize += sourceSizeValue;
            else p.SourceSize = null;
            
            if (resultSizeValue != null && p.ResultSize != null) p.ResultSize += resultSizeValue;
            else p.ResultSize = null;

            var resSize = p.ResultSize;
            p.ModifiedEnumeration = true;
            p.ResultSize = resSize;
        }
    }
}