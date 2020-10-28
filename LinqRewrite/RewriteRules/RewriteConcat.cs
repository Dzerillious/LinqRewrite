using System.Collections.Immutable;
using System.Linq;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.AssertionExtension;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteConcat
    {
        public static void Rewrite(RewriteDesign design, ImmutableArray<ValueBridge> args)
        {
            var sourceSizeValue = design.SourceSize;
            var resultSizeValue = design.ResultSize;
            var collectionValue = args[0];
            if (!AssertNotNull(design, collectionValue)) return;

            LocalVariable itemVariable;
            var lastVariable = TryGetVariable(design, design.LastValue);
            if (lastVariable != null)
            {
                itemVariable = lastVariable;
            }
            else
            {
                itemVariable = CreateGlobalVariable(design, design.LastValue.Type);
                design.ForAdd(itemVariable.Assign(design.LastValue));
                design.LastValue = new TypedValueBridge(design.LastValue.Type, itemVariable);
            }
            itemVariable.IsGlobal = true;
            
            var collectionType = design.Data.GetTypeInfo(collectionValue).Type;
            design.AddIterator(new CollectionValueBridge(design, collectionType, collectionValue, true));
            RewriteCollectionEnumeration.RewriteOther(design, design.CurrentIterator.Collection, itemVariable, true);
            design.ListEnumeration = design.IncompleteIterators.All(x => x.ListEnumeration);

            if (sourceSizeValue != null && design.SourceSize != null) design.SourceSize += sourceSizeValue;
            else design.SourceSize = null;

            if (resultSizeValue != null && design.ResultSize != null) design.ResultSize += resultSizeValue;
            else design.ResultSize = null;

            (design.ModifiedEnumeration, design.ResultSize) = (true, design.ResultSize);
        }
    }
}