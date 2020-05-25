using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteExcept
    {
        public static void Rewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            var sourceSizeValue = design.SourceSize;
            var collectionValue = args[0];
            if (!AssertionExtension.AssertNotNull(design, collectionValue)) return;

            var oldLast = design.LastValue;
            var collectionType = design.Data.GetTypeInfo(collectionValue).Type;
            var oldIterator = design.InsertIterator(new CollectionValueBridge(design, collectionType, collectionValue, true));
            RewriteCollectionEnumeration.RewriteOther(design, design.CurrentIterator.Collection);

            var hashsetType = SyntaxFactory.ParseTypeName($"LinqRewrite.Core.SimpleSet<{design.LastValue.Type}>");
            var hashsetCreation = args.Length switch
            {
                1 => New(hashsetType),
                2 => New(hashsetType, args[1])
            };
            var hashsetVariable = VariableCreator.GlobalVariable(design, hashsetType, hashsetCreation);
            
            design.CurrentForAdd(hashsetVariable.Access("Add").Invoke(design.LastValue));
            design.CurrentIterator.Complete = true;
            
            design.CurrentIterator = oldIterator;
            design.LastValue = oldLast;
            
            design.LastValue = design.LastValue.Reusable(design);
            design.ForAdd(If(Not(hashsetVariable.Access("Add").Invoke(design.LastValue)),
                        Continue()));

            if (sourceSizeValue != null && design.SourceSize != null) design.SourceSize += sourceSizeValue;
            else design.SourceSize = null;
            
            design.ListEnumeration = false;
            design.ModifiedEnumeration = true;
        }
    }
}