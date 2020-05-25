using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteUnion
    {
        public static void Rewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            var sourceSizeValue = design.SourceSize;
            var collectionValue = args[0];
            if (!AssertionExtension.AssertNotNull(design, collectionValue)) return;

            var hashsetType = ParseTypeName($"LinqRewrite.Core.SimpleSet<{design.LastValue.Type}>");
            var hashsetCreation = args.Length switch
            {
                1 => New(hashsetType),
                2 => New(hashsetType, args[1])
            };
            var hashsetVariable = VariableCreator.GlobalVariable(design, hashsetType, hashsetCreation);

            LocalVariable itemVariable;
            var lastVariable = design.TryGetVariable(design.LastValue);
            if (lastVariable != null)
                itemVariable = lastVariable;
            else
            {
                itemVariable = VariableCreator.LocalVariable(design, design.LastValue.Type);
                design.ForAdd(itemVariable.Assign(design.LastValue));
                design.LastValue = new TypedValueBridge(design.LastValue.Type, itemVariable);
            }
            itemVariable.IsGlobal = true;
            
            var collectionType = design.Data.GetTypeInfo(collectionValue).Type;
            design.AddIterator(new CollectionValueBridge(design, collectionType, collectionValue, true));
            RewriteCollectionEnumeration.RewriteOther(design, design.CurrentIterator.Collection, itemVariable, true);
            design.ForAdd(If(Not(hashsetVariable.Access("Add").Invoke(design.LastValue)),
                Continue()));

            if (sourceSizeValue != null && design.SourceSize != null) design.SourceSize += sourceSizeValue;
            else design.SourceSize = null;
            design.ListEnumeration = false;
            design.ModifiedEnumeration = true;
        }
    }
}