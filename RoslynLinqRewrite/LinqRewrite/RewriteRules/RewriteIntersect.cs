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
            var sourceSizeValue = p.SourceSize;
            var collectionValue = args[0];
            if (!p.AssertNotNull(collectionValue)) return;

            var hashsetType = p.WrappedType("HashSet<", p.LastValue.Type, ">");
            var hashsetVariable = p.GlobalVariable(hashsetType, args.Length switch
            {
                1 => New(hashsetType),
                2 => New(hashsetType, args[1])
            });

            p.ForAdd(hashsetVariable.Access("Add").Invoke(p.LastValue));
            p.Iterators.ForEach(x => x.Complete = true);
            
            p.AddIterator(collectionValue);
            RewriteCollectionEnumeration.RewriteOther(p, new CollectionValueBridge(collectionValue.ItemType(p), collectionValue.GetType(p), collectionValue.Count(p), collectionValue.Old));

            p.LastValue = p.LastValue.Reusable(p);
            p.CurrentForAdd(If(Not(hashsetVariable.Access("Remove").Invoke(p.LastValue)),
                            Continue()));

            if (sourceSizeValue != null && p.SourceSize != null) p.SourceSize += sourceSizeValue;
            else p.SourceSize = null;
            
            p.ModifiedEnumeration = true;
        }
    }
}