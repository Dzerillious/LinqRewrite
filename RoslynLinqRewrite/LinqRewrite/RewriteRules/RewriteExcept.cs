using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteExcept
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            var sourceSizeValue = p.SourceSize;
            var collectionValue = args[0];
            if (!p.AssertNotNull(collectionValue)) return;

            var oldLast = p.LastValue;
            var oldIterator = p.InsertIterator(collectionValue);
            var collectionType = p.Data.GetTypeInfo(collectionValue).Type;
            RewriteCollectionEnumeration.RewriteOther(p, new CollectionValueBridge(p, collectionType, collectionValue.Old, true));

            var hashsetType = p.WrappedType("HashSet<", p.LastValue.Type, ">");
            var hashsetCreation = args.Length switch
            {
                1 => New(hashsetType),
                2 => New(hashsetType, args[1])
            };
            var hashsetVariable = p.GlobalVariable(hashsetType, hashsetCreation);
            
            p.CurrentForAdd(hashsetVariable.Access("Add").Invoke(p.LastValue));
            p.CurrentIterator.Complete = true;
            
            p.CurrentIterator = oldIterator;
            p.LastValue = oldLast;
            
            p.LastValue = p.LastValue.Reusable(p);
            p.ForAdd(If(Not(hashsetVariable.Access("Add").Invoke(p.LastValue)),
                        Continue()));

            if (sourceSizeValue != null && p.SourceSize != null) p.SourceSize += sourceSizeValue;
            else p.SourceSize = null;
            
            p.ModifiedEnumeration = true;
        }
    }
}