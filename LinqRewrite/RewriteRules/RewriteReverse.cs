using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;


namespace LinqRewrite.RewriteRules
{
    public static class RewriteReverse
    {
        public static void Rewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            if (!design.ModifiedEnumeration)
            {
                design.SwitchIsReversed();
                design.ListEnumeration = false;
                design.Indexer = null;
            }
            else if (design.SourceSize != null)
            {
                KnownSourceSize(design);
                design.ListEnumeration = true;
                design.ModifiedEnumeration = false;
            }
            else
            {
                UnknownSourceSize(design);
                design.ListEnumeration = true;
                design.ModifiedEnumeration = false;
            }
            design.SimpleEnumeration = false;
        }

        private static void KnownSourceSize(RewriteDesign design)
        {
            design.Indexer = null;
            var reverseIndexerVariable = VariableCreator.GlobalVariable(design, Int, 8);
            var logVariable = VariableCreator.GlobalVariable(design, Int,
                "LinqRewrite".Access("Core", "IntExtensions", "Log2")
                    .Invoke(design.SourceSize.Cast(SyntaxKind.UIntKeyword)) - 3);
                
            design.PreUseAdd(logVariable.SubAssign(logVariable % 2));
            var currentLengthVariable = VariableCreator.GlobalVariable(design, Int, 8);
            var resultVariable = VariableCreator.GlobalVariable(design, design.LastValue.ArrayType(), CreateArray(design.LastValue.ArrayType(), 8));

            var tmpSize = VariableCreator.GlobalVariable(design, Int);
            design.ForAdd(reverseIndexerVariable.PreDecrement());
            design.ForAdd(If(reverseIndexerVariable < 0,
                Block(
                    tmpSize.Assign(currentLengthVariable),
                                    "LinqRewrite".Access("Core", "EnlargeExtensions", "LogEnlargeReverseArray")
                                        .Invoke(2, 
                                            design.SourceSize, 
                                            RefArg(resultVariable), 
                                            RefArg(logVariable),
                                            OutArg(currentLengthVariable)),
                    reverseIndexerVariable.Assign(currentLengthVariable - tmpSize - 1 ))));
            
            design.ForAdd(resultVariable[reverseIndexerVariable].Assign(design.LastValue));
            
            design.Indexer = null;
            design.Iterators.All.ForEach(x => x.Complete = true);
            design.AddIterator(new CollectionValueBridge(design, resultVariable.Type, design.LastValue.Type, resultVariable, true));
            design.CurrentCollection = design.CurrentIterator.Collection;
            RewriteCollectionEnumeration.RewriteOther(design, design.CurrentCollection);
            
            design.ResultSize = design.SourceSize = currentLengthVariable - reverseIndexerVariable;
            design.CurrentIterator.ForFrom = reverseIndexerVariable;
            design.CurrentIterator.ForTo = currentLengthVariable - 1;
            design.Indexer = null;
        }

        private static void UnknownSourceSize(RewriteDesign design)
        {
            design.Indexer = null;
            var reverseIndexerVariable = VariableCreator.GlobalVariable(design, Int, 8);
            var currentLengthVariable = VariableCreator.GlobalVariable(design, Int, 8);
            var resultVariable = VariableCreator.GlobalVariable(design, design.LastValue.ArrayType(), CreateArray(design.LastValue.ArrayType(), 8));

            var tmpSize = VariableCreator.GlobalVariable(design, Int);
            design.ForAdd(reverseIndexerVariable.PreDecrement());
            design.ForAdd(If(reverseIndexerVariable < 0,
                        Block(
                    tmpSize.Assign(currentLengthVariable),
                                    "LinqRewrite".Access("Core", "EnlargeExtensions", "LogEnlargeReverseArray")
                                        .Invoke(2, RefArg(resultVariable), RefArg(currentLengthVariable)),
                                            reverseIndexerVariable.Assign(currentLengthVariable - tmpSize - 1 ))));
            design.ForAdd(resultVariable[reverseIndexerVariable].Assign(design.LastValue));
            
            design.Indexer = null;
            design.Iterators.All.ForEach(x => x.Complete = true);
            
            design.AddIterator(new CollectionValueBridge(design, resultVariable.Type, design.LastValue.Type, resultVariable, true));
            design.CurrentCollection = design.CurrentIterator.Collection;
            RewriteCollectionEnumeration.RewriteOther(design, design.CurrentCollection);
            
            design.ResultSize = design.SourceSize = currentLengthVariable - reverseIndexerVariable;
            design.CurrentIterator.ForFrom = reverseIndexerVariable;
            design.CurrentIterator.ForTo = currentLengthVariable - 1;
            design.Indexer = null;
        }
    }
}