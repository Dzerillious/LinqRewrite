using System.Linq;
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
            if (!AssertionExtension.AssertNotNull(p, collectionValue)) return;

            LocalVariable itemVariable;
            var lastVariable = p.TryGetVariable(p.LastValue);
            if (lastVariable != null)
            {
                itemVariable = lastVariable;
            }
            else
            {
                itemVariable = VariableCreator.GlobalVariable(p, p.LastValue.Type);
                p.ForAdd(itemVariable.Assign(p.LastValue));
                p.LastValue = new TypedValueBridge(p.LastValue.Type, itemVariable);
            }
            itemVariable.IsGlobal = true;
            
            var collectionType = p.Data.GetTypeInfo(collectionValue).Type;
            p.AddIterator(new CollectionValueBridge(p, collectionType, collectionValue, true));
            RewriteCollectionEnumeration.RewriteOther(p, p.CurrentIterator.Collection, itemVariable, true);
            p.ListEnumeration = p.IncompleteIterators.All(x => x.ListEnumeration);

            if (sourceSizeValue != null && p.SourceSize != null) p.SourceSize += sourceSizeValue;
            else p.SourceSize = null;

            if (resultSizeValue != null && p.ResultSize != null) p.ResultSize += resultSizeValue;
            else p.ResultSize = null;

            (p.ModifiedEnumeration, p.ResultSize) = (true, p.ResultSize);
        }
    }
}