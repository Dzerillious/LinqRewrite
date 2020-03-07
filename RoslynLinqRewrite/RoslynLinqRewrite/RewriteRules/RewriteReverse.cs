using System;
using System.Linq;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SimpleCollections;
using static LinqRewrite.Constants;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;


namespace LinqRewrite.RewriteRules
{
    public class RewriteReverse
    {
        public static void Rewrite(RewriteParameters p, ExpressionSyntax[] args)
        {
            if (p.Iterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<ExpressionSyntax>());
            if (!p.ModifiedEnumeration)
            {
                p.IsReversed = !p.IsReversed;
                return;
            }
            else if (p.SourceSize != null) KnownSourceSize(p);
            else UnknownSourceSize(p);
            
            p.CurrentIndexer = null;
        }

        private static void KnownSourceSize(RewriteParameters p)
        {
            p.CurrentIndexer = null;
            var reverseIndexer = p.LocalVariable(Int);
                
            var logVariable = p.LocalVariable(Int,
                "SimpleCollections".Access("IntExtensions", "Log2")
                    .Invoke(p.SourceSize.Cast(SyntaxKind.UIntKeyword)) - 3);
                
            p.InitialAdd(logVariable.SubAssign(logVariable % 2));
            var currentLengthVariable = p.LocalVariable(Int, 8);

            var resultVariable = p.GlobalVariable(p.Last.Type.ArrayType(), CreateArray(p.Last.Type.ArrayType(), 8));
            p.PreForAdd(reverseIndexer.Assign(8));

            var tmpSize = p.LocalVariable(Int);
            p.ForAdd(reverseIndexer.PreDecrement());

            p.ForAdd(If(reverseIndexer < 0,
                Block(
                    tmpSize.Assign(currentLengthVariable),
                                    "SimpleCollections".Access("EnlargeExtensions", "LogEnlargeReverseArray")
                                        .Invoke(2, 
                                            p.SourceSize, 
                                            RefArg(resultVariable), 
                                            RefArg(logVariable),
                                            OutArg(currentLengthVariable)),
                    reverseIndexer.Assign(currentLengthVariable - tmpSize - 1 ))));
            
            p.CurrentIndexer = null;

            p.ForAdd(resultVariable[reverseIndexer].Assign(p.Last.Value));
            p.CurrentCollection = new CollectionValueBridge(p.Last.Type, ArrayType(p.Last.Type), currentLengthVariable - reverseIndexer, resultVariable);
            
            p.Iterator.Complete = true;
            RewriteCollectionEnumeration.Rewrite(p, Array.Empty<ExpressionSyntax>());
            
            p.ForMin = p.ForReMin = currentLengthVariable - reverseIndexer;
            p.ForMax = currentLengthVariable;
            p.ForReMax = currentLengthVariable - 1;
            p.ResultSize = p.SourceSize = currentLengthVariable - reverseIndexer;
        }

        private static void UnknownSourceSize(RewriteParameters p)
        {
            var indexer = p.Indexer;
            
            var currentLengthVariable = p.GlobalVariable(Int, 8);
            var resultType = (ArrayTypeSyntax) p.ReturnType;
            var resultVariable = p.GlobalVariable(Int, CreateArray(resultType, 8));
                
            p.ForAdd(If(p.Indexer >= currentLengthVariable,
                            "SimpleCollections".Access("EnlargeExtensions", "LogEnlargeArray")
                                    .Invoke(2, RefArg(resultVariable), RefArg(currentLengthVariable))));
                
            p.ForAdd(resultVariable[indexer].Assign(p.Last.Value));
            p.HasResultMethod = true;
        }
    }
}