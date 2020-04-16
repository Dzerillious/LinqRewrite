using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;


namespace LinqRewrite.RewriteRules
{
    public static class RewriteReverse
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (!p.ModifiedEnumeration)
            {
                p.SwitchIsReversed();
                p.ListEnumeration = false;
                p.Indexer = null;
            }
            else if (p.SourceSize != null)
            {
                KnownSourceSize(p);
                p.ListEnumeration = true;
            }
            else
            {
                UnknownSourceSize(p);
                p.ListEnumeration = true;
            }

            p.ModifiedEnumeration = false;
            p.SimpleEnumeration = false;
        }

        private static void KnownSourceSize(RewriteParameters p)
        {
            p.Indexer = null;
            var reverseIndexerVariable = p.LocalVariable(Int, 8);
                
            var logVariable = p.LocalVariable(Int,
                "LinqRewrite".Access("Core", "IntExtensions", "Log2")
                    .Invoke(p.SourceSize.Cast(SyntaxKind.UIntKeyword)) - 3);
                
            p.PreUseAdd(logVariable.SubAssign(logVariable % 2));
            var currentLengthVariable = p.LocalVariable(Int, 8);
            var resultVariable = p.GlobalVariable(p.LastValue.Type.ArrayType(), CreateArray(p.LastValue.Type.ArrayType(), 8));

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
            
            p.ForAdd(resultVariable[reverseIndexerVariable].Assign(p.LastValue));
            
            p.Indexer = null;
            p.Iterators.ForEach(x => x.Complete = true);
                
            p.AddIterator(new RewrittenValueBridge(p.CurrentCollection));
            p.CurrentCollection = new CollectionValueBridge(p, resultVariable.Type, p.LastValue.Type, resultVariable, true);
            RewriteCollectionEnumeration.RewriteOther(p, p.CurrentCollection);
            
            p.ResultSize = p.SourceSize = currentLengthVariable - reverseIndexerVariable;
            p.ForMin = p.ForReMin = reverseIndexerVariable;
            p.ForMax = currentLengthVariable;
            p.ForReMax = currentLengthVariable - reverseIndexerVariable - 1;
            p.Indexer = null;
        }

        private static void UnknownSourceSize(RewriteParameters p)
        {
            p.Indexer = null;
            var reverseIndexerVariable = p.LocalVariable(Int, 8);
            var currentLengthVariable = p.LocalVariable(Int, 8);
            var resultVariable = p.GlobalVariable(p.LastValue.Type.ArrayType(), CreateArray(p.LastValue.Type.ArrayType(), 8));

            var tmpSize = p.LocalVariable(Int);
            p.ForAdd(reverseIndexerVariable.PreDecrement());

            p.ForAdd(If(reverseIndexerVariable < 0,
                        Block(
                    tmpSize.Assign(currentLengthVariable),
                                    "LinqRewrite".Access("Core", "EnlargeExtensions", "LogEnlargeReverseArray")
                                        .Invoke(2, RefArg(resultVariable), RefArg(currentLengthVariable)),
                                            reverseIndexerVariable.Assign(currentLengthVariable - tmpSize - 1 ))));

            p.ForAdd(resultVariable[reverseIndexerVariable].Assign(p.LastValue));
            
            p.Indexer = null;
            p.Iterators.ForEach(x => x.Complete = true);
            
            p.AddIterator(new RewrittenValueBridge(p.CurrentCollection));
            p.CurrentCollection = new CollectionValueBridge(p, resultVariable.Type, p.LastValue.Type, resultVariable, true);
            RewriteCollectionEnumeration.RewriteOther(p, p.CurrentCollection);
            
            p.ResultSize = p.SourceSize = currentLengthVariable - reverseIndexerVariable;
            p.ForMin = p.ForReMin = reverseIndexerVariable;
            p.ForMax = currentLengthVariable;
            p.ForReMax = currentLengthVariable - reverseIndexerVariable - 1;
            p.Indexer = null;
        }
    }
}