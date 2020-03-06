using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
            if (p.Body == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<ExpressionSyntax>());
            if (!p.ModifiedEnumeration)
            {
                p.IsReversed = !p.IsReversed;
                return;
            }
            else if (p.ResultSize != null) KnownSize(p, "__reversed", p.Collection.ItemType(p));
            else if (p.SourceSize != null) KnownSourceSize(p, "__reversed");
            else UnknownSourceSize(p, "__reversed");
            
            p.CurrentIndexer = null;
        }

        private static void KnownSize(RewriteParameters p, string resultName, TypeSyntax itemType = null)
        {
            var arrayType = itemType == null ? (ArrayTypeSyntax) p.ReturnType : ArrayType(itemType);
            var resultVariable = p.GlobalVariable(arrayType, resultName, CreateArray(arrayType, p.ResultSize));

            p.ForAdd(resultVariable[p.Indexer].Assign(p.Last.Value));
            
            p.FinalAdd(Return(resultVariable));
            p.AddIterator(resultVariable);
        }

        private static VariableBridge KnownSourceSize(RewriteParameters p, string resultName)
        {
            var indexer = p.Indexer;
                
            var logVariable = p.GlobalVariable(Int, "__log", 
                "SimpleCollections".Access("IntExtensions", "Log2")
                    .Invoke(p.SourceSize.Cast(SyntaxKind.UIntKeyword)) - 3);
                
            p.InitialAdd(logVariable.Assign(logVariable - logVariable % 2));
            var currentLengthVariable = p.GlobalVariable(Int, "__currentLength", 8);

            var resultType = (ArrayTypeSyntax) p.ReturnType;
            var resultVariable = p.GlobalVariable(resultType, resultName, CreateArray(resultType, p.ResultSize));

            p.ForAdd(If(p.Indexer >= currentLengthVariable,
                        "SimpleCollections".Access("EnlargeExtensions", "LogEnlargeArray")
                                .Invoke(2, 
                                    p.SourceSize, 
                                    RefArg(resultVariable), 
                                    RefArg(logVariable),
                                    OutArg(currentLengthVariable))));
                
            p.ForAdd(resultVariable[indexer].Assign(p.Last.Value));
            return resultVariable;
        }

        private static VariableBridge UnknownSourceSize(RewriteParameters p, string resultName)
        {
            var indexer = p.Indexer;
            
            var currentLengthVariable = p.GlobalVariable(Int, "__currentLength", 8);
            var resultType = (ArrayTypeSyntax) p.ReturnType;
            var resultVariable = p.GlobalVariable(Int, resultName, CreateArray(resultType, 8));
                
            p.ForAdd(If(p.Indexer >= currentLengthVariable,
                            "SimpleCollections".Access("EnlargeExtensions", "LogEnlargeArray")
                                    .Invoke(2, RefArg(resultVariable), RefArg(currentLengthVariable))));
                
            p.ForAdd(resultVariable[indexer].Assign(p.Last.Value));
            p.HasResultMethod = true;
            return resultVariable;
        }
    }
}