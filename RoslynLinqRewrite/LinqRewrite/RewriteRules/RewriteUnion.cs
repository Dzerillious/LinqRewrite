using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteUnion
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            var sourceSizeValue = p.SourceSize;
            var collectionValue = args[0];
            if (!p.AssertNotNull(collectionValue)) return;

            var hashsetType = ParseTypeName($"System.Collections.Generic.HashSet<{p.LastValue.Type}>");
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
                p.ForAdd(itemVariable.Assign(p.LastValue));
                p.LastValue = new TypedValueBridge(p.LastValue.Type, itemVariable);
            }
            itemVariable.IsGlobal = true;
            
            p.AddIterator(collectionValue);
                
            var collectionType = p.Data.GetTypeInfo(collectionValue).Type;
            RewriteCollectionEnumeration.RewriteOther(p, new CollectionValueBridge(p, collectionType, collectionValue, true), itemVariable, true);

            p.ForAdd(If(Not(hashsetVariable.Access("Add").Invoke(p.LastValue)),
                Continue()));

            if (sourceSizeValue != null && p.SourceSize != null) p.SourceSize += sourceSizeValue;
            else p.SourceSize = null;
            
            p.ModifiedEnumeration = true;
        }
    }
}