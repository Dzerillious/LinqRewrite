using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteIntersect
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            var sourceSize = p.SourceSize;
            var collection = args[0];

            var hashsetType = p.WrappedType("HashSet<", p.LastValue.Type, ">");
            var hashset = args.Length == 1 
                ? p.GlobalVariable(hashsetType, New(hashsetType))
                : p.GlobalVariable(hashsetType, New(hashsetType, args[1]));

            p.ForAdd(hashset.Access("Add").Invoke(p.LastValue.Value));
            p.Iterators.ForEach(x => x.Complete = true);
            
            p.AddIterator(collection);
            RewriteCollectionEnumeration.RewriteOther(p, new CollectionValueBridge(collection.ItemType(p), collection.GetType(p), collection.Count(p), collection.Old));
            p.LastForAdd(If(Not(hashset.Access("Remove").Invoke(p.LastValue.Value)),
                            Continue()));

            if (sourceSize != null && p.SourceSize != null) p.SourceSize += sourceSize;
            else p.SourceSize = null;
            
            p.ModifiedEnumeration = true;
        }
    }
}