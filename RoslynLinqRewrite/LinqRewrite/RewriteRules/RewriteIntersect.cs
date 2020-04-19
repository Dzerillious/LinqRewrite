using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteIntersect
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            var sourceSizeValue = p.SourceSize;
            var collectionValue = args[0];
            if (!p.AssertNotNull(collectionValue)) return;

            var hashsetType = ParseTypeName($"System.Collections.Generic.HashSet<{p.LastValue.Type}>");
            var hashsetVariable = p.GlobalVariable(hashsetType, args.Length switch
            {
                1 => New(hashsetType),
                2 => New(hashsetType, args[1])
            });

            p.ForAdd(hashsetVariable.Access("Add").Invoke(p.LastValue));
            p.Iterators.ForEach(x => x.Complete = true);
            
            var collectionType = p.Data.GetTypeInfo(collectionValue).Type;
            p.AddIterator(new CollectionValueBridge(p, collectionType, collectionValue, true));
            RewriteCollectionEnumeration.RewriteOther(p, p.CurrentIterator.Collection);

            p.LastValue = p.LastValue.Reusable(p);
            p.CurrentForAdd(If(Not(hashsetVariable.Access("Remove").Invoke(p.LastValue)),
                            Continue()));

            if (sourceSizeValue != null && p.SourceSize != null) p.SourceSize += sourceSizeValue;
            else p.SourceSize = null;
            
            p.ListEnumeration = false;
            p.ModifiedEnumeration = true;
        }
    }
}