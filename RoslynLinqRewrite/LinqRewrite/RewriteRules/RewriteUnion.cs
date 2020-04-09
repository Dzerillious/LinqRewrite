using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteUnion
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            var sourceSizeValue = p.SourceSize;
            var collectionValue = args[0];
            if (!p.AssertNotNull(collectionValue)) return;

            var hashsetType = p.WrappedType("HashSet<", p.LastValue.Type, ">");
            var hashsetCreation = args.Length switch
            {
                1 => New(hashsetType),
                2 => New(hashsetType, args[1])
            };
            var hashsetVariable = p.GlobalVariable(hashsetType, hashsetCreation);

            LocalVariable itemVariable;
            var lastVariable = p.TryGetVariable(p.LastValue);
            if (lastVariable != null)
                itemVariable = lastVariable;
            else
            {
                itemVariable = p.LocalVariable(p.LastValue.Type);
                p.CurrentForAdd(itemVariable.Assign(p.LastValue));
                p.LastValue = new TypedValueBridge(p.LastValue.Type, itemVariable);
            }
            itemVariable.IsGlobal = true;
            
            p.AddIterator(collectionValue);
            RewriteCollectionEnumeration.RewriteOther(p, new CollectionValueBridge(collectionValue.ItemType(p), collectionValue.GetType(p), collectionValue.Count(p), collectionValue.Old), itemVariable, true);

            p.ForAdd(If(Not(hashsetVariable.Access("Add").Invoke(p.LastValue)),
                Continue()));

            if (sourceSizeValue != null && p.SourceSize != null) p.SourceSize += sourceSizeValue;
            else p.SourceSize = null;
            
            p.ModifiedEnumeration = true;
        }
    }
}