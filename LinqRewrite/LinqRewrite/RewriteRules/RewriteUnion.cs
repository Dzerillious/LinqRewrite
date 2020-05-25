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
            if (!AssertionExtension.AssertNotNull(p, collectionValue)) return;

            var hashsetType = ParseTypeName($"LinqRewrite.Core.SimpleSet<{p.LastValue.Type}>");
            var hashsetCreation = args.Length switch
            {
                1 => New(hashsetType),
                2 => New(hashsetType, args[1])
            };
            var hashsetVariable = VariableCreator.GlobalVariable(p, hashsetType, hashsetCreation);

            LocalVariable itemVariable;
            var lastVariable = p.TryGetVariable(p.LastValue);
            if (lastVariable != null)
                itemVariable = lastVariable;
            else
            {
                itemVariable = VariableCreator.LocalVariable(p, p.LastValue.Type);
                p.ForAdd(itemVariable.Assign(p.LastValue));
                p.LastValue = new TypedValueBridge(p.LastValue.Type, itemVariable);
            }
            itemVariable.IsGlobal = true;
            
            var collectionType = p.Data.GetTypeInfo(collectionValue).Type;
            p.AddIterator(new CollectionValueBridge(p, collectionType, collectionValue, true));
            RewriteCollectionEnumeration.RewriteOther(p, p.CurrentIterator.Collection, itemVariable, true);
            p.ForAdd(If(Not(hashsetVariable.Access("Add").Invoke(p.LastValue)),
                Continue()));

            if (sourceSizeValue != null && p.SourceSize != null) p.SourceSize += sourceSizeValue;
            else p.SourceSize = null;
            p.ListEnumeration = false;
            p.ModifiedEnumeration = true;
        }
    }
}