using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
            
            var indexer = p.CurrentIndexer;
            if (indexer != null && indexer.Name == p.Iterator.Indexer)
                indexer.IsGlobal = true;

            LocalVariable itemVariable;
            if (p.Last.Value != null && p.Last.Value is LocalVariable lastVariable)
                itemVariable = lastVariable;
            else
            {
                itemVariable = p.LocalVariable(Int);
                p.ForAdd(itemVariable.Assign(p.Last.Value));
                p.Last = new TypedValueBridge(Int, itemVariable);
            }
            
            p.AddIterator(collection);
            if (indexer != null)
            {
                p.PreForAdd(indexer.PreDecrement());
                p.LastForAdd(indexer.PreIncrement());
            }
            RewriteCollectionEnumeration.RewriteOther(p, new CollectionValueBridge(collection.ItemType(p), collection.GetType(p), collection.Count(p), collection), itemVariable);

            if (sourceSize != null && p.SourceSize != null) p.SourceSize += sourceSize;
            else p.SourceSize = null;
            
            if (resultSize != null && p.ResultSize != null) p.ResultSize += resultSize;
            else p.ResultSize = null;
        }
    }
}