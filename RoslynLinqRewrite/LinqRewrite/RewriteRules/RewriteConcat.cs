using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteConcat
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            var sourceSizeValue = p.SourceSize;
            var resultSizeValue = p.ResultSize;
            var collectionValue = args[0];
            if (IsNull(collectionValue, p))
            {
                p.PreForAdd(Throw("System.InvalidOperationException", "Collection was null"));
                return;
            }

            LocalVariable itemVariable;
            if (p.LastValue.Value != null && p.LastValue.Value is LocalVariable lastVariable)
                itemVariable = lastVariable;
            else
            {
                itemVariable = p.GlobalVariable(p.LastValue.Type);
                p.CurrentForAdd(itemVariable.Assign(p.LastValue));
                p.LastValue = new TypedValueBridge(p.LastValue.Type, itemVariable);
            }
            itemVariable.IsGlobal = true;
            
            p.AddIterator(collectionValue);
            RewriteCollectionEnumeration.RewriteOther(p, new CollectionValueBridge(collectionValue.ItemType(p), collectionValue.GetType(p), collectionValue.Count(p), collectionValue.Old), itemVariable, true);

            if (sourceSizeValue != null && p.SourceSize != null) p.SourceSize += sourceSizeValue;
            else p.SourceSize = null;
            
            if (resultSizeValue != null && p.ResultSize != null) p.ResultSize += resultSizeValue;
            else p.ResultSize = null;
        }
    }
}