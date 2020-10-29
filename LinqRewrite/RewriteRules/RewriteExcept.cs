﻿using System.Collections.Immutable;
using LinqRewrite.DataStructures;
using Microsoft.CodeAnalysis.CSharp;
using static LinqRewrite.Extensions.AssertionExtension;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteExcept
    {
        public static void Rewrite(RewriteDesign design, ImmutableArray<ValueBridge> args)
        {
            var sourceSizeValue = design.SourceSize;
            var collectionValue = args[0];
            if (!AssertNotNull(design, collectionValue)) return;

            var oldLast = design.LastValue;
            var collectionType = design.Info.Semantic.GetTypeInfo(collectionValue).Type;
            var oldIterator = design.InsertIterator(new CollectionValueBridge(design, collectionType, collectionValue));
            RewriteCollectionEnumeration.RewriteOther(design, design.CurrentIterator.Collection);

            var hashsetType = SyntaxFactory.ParseTypeName($"LinqRewrite.Core.SimpleSet<{design.LastValue.Type}>");
            var hashsetCreation = args.Length switch
            {
                1 => New(hashsetType),
                2 => New(hashsetType, args[1])
            };
            var hashsetVariable = CreateGlobalVariable(design, hashsetType, hashsetCreation);
            
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