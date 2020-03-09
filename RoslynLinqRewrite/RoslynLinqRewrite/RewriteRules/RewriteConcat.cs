using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public class RewriteConcat
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.Iterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            var sourceSize = p.SourceSize;
            var resultSize = p.ResultSize;
            var collection = args[0];

            LocalVariable itemVariable;
            if (p.Last.Value != null && p.Last.Value is LocalVariable lastVariable)
                itemVariable = lastVariable;
            else
            {
                itemVariable = p.LocalVariable(Int);
                p.LastForAdd(itemVariable.Assign(p.Last.Value));
                p.Last = new TypedValueBridge(Int, itemVariable);
            }
            
            p.AddIterator(collection);
            RewriteCollectionEnumeration.RewriteOther(p, new CollectionValueBridge(collection.ItemType(p), collection.GetType(p), collection.Count(p), collection.Old), itemVariable);

            if (sourceSize != null && p.SourceSize != null) p.SourceSize += sourceSize;
            else p.SourceSize = null;
            
            if (resultSize != null && p.ResultSize != null) p.ResultSize += resultSize;
            else p.ResultSize = null;
        }
    }
}