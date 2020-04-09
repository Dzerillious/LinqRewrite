using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;


namespace LinqRewrite.RewriteRules
{
    public static class RewriteReverse
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (!p.ModifiedEnumeration) p.IsReversed = !p.IsReversed;
            else if (p.SourceSize != null) KnownSourceSize(p);
            else UnknownSourceSize(p);
            
            p.SimpleEnumeration = false;
            p.ListEnumeration = false;
        }

        private static void KnownSourceSize(RewriteParameters p)
        {
            p.Indexer = null;
            var reverseIndexerVariable = p.LocalVariable(Int);
                
            var logVariable = p.LocalVariable(Int,
                "LinqRewrite".Access("Core", "IntExtensions", "Log2")
                    .Invoke(p.SourceSize.Cast(SyntaxKind.UIntKeyword)) - 3);
                
            p.PreUseAdd(logVariable.SubAssign(logVariable % 2));
            var currentLengthVariable = p.LocalVariable(Int, 8);

            var resultVariable = p.GlobalVariable(p.LastValue.Type.ArrayType(), CreateArray(p.LastValue.Type.ArrayType(), 8));
            p.PreForAdd(reverseIndexerVariable.Assign(8));

            var tmpSize = p.LocalVariable(Int);
            p.ForAdd(reverseIndexerVariable.PreDecrement());

            p.ForAdd(If(reverseIndexerVariable < 0,
                Block(
                    tmpSize.Assign(currentLengthVariable),
                                    "LinqRewrite".Access("Core", "EnlargeExtensions", "LogEnlargeReverseArray")
                                        .Invoke(2, 
                                            p.SourceSize, 
                                            RefArg(resultVariable), 
                                            RefArg(logVariable),
                                            OutArg(currentLengthVariable)),
                    reverseIndexerVariable.Assign(currentLengthVariable - tmpSize - 1 ))));
            
            p.Indexer = null;

            p.ForAdd(resultVariable[reverseIndexerVariable].Assign(p.LastValue));
            p.CurrentCollection = new CollectionValueBridge(p.LastValue.Type, ArrayType(p.LastValue.Type), currentLengthVariable - reverseIndexerVariable, resultVariable);
            
            p.CurrentIterator.Complete = true;
            RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            
            p.ResultSize = p.SourceSize = currentLengthVariable - reverseIndexerVariable;
            p.ForMin = p.ForReMin = 0;
            p.ForMax = currentLengthVariable - reverseIndexerVariable;
            p.ForReMax = currentLengthVariable - reverseIndexerVariable - 1;
            p.LastValue = new TypedValueBridge(p.CurrentCollection.ItemType, p.CurrentCollection[p.Indexer + reverseIndexerVariable]);
        }

        private static void UnknownSourceSize(RewriteParameters p)
        {
            p.Indexer = null;
            var reverseIndexerVariable = p.LocalVariable(Int);
                
            var currentLengthVariable = p.LocalVariable(Int, 8);
            var resultVariable = p.GlobalVariable(p.LastValue.Type.ArrayType(), CreateArray(p.LastValue.Type.ArrayType(), 8));
            p.PreForAdd(reverseIndexerVariable.Assign(8));

            var tmpSize = p.LocalVariable(Int);
            p.ForAdd(reverseIndexerVariable.PreDecrement());

            p.ForAdd(If(reverseIndexerVariable < 0,
                        Block(
                    tmpSize.Assign(currentLengthVariable),
                                    "LinqRewrite".Access("Core", "EnlargeExtensions", "LogEnlargeReverseArray")
                                        .Invoke(2, 
                                            RefArg(resultVariable), 
                                            RefArg(currentLengthVariable)),
                                    reverseIndexerVariable.Assign(currentLengthVariable - tmpSize - 1 ))));
            
            p.Indexer = null;

            p.ForAdd(resultVariable[reverseIndexerVariable].Assign(p.LastValue));
            p.CurrentCollection = new CollectionValueBridge(p.LastValue.Type, ArrayType(p.LastValue.Type), currentLengthVariable - reverseIndexerVariable, resultVariable);
            
            p.CurrentIterator.Complete = true;
            RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());
            
            p.ResultSize = p.SourceSize = currentLengthVariable - reverseIndexerVariable;
            p.ForMin = p.ForReMin = 0;
            p.ForMax = currentLengthVariable - reverseIndexerVariable;
            p.ForReMax = currentLengthVariable - reverseIndexerVariable - 1;
            p.LastValue = new TypedValueBridge(p.CurrentCollection.ItemType, p.CurrentCollection[p.Indexer + reverseIndexerVariable]);
        }
    }
}