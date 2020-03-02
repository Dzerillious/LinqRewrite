using System.Linq;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SimpleCollections;

namespace LinqRewrite.RewriteRules
{
    public class RewriteConcat
    {
        public static void Rewrite(RewriteParameters p, int chainIndex)
        {
            if (chainIndex == 0) RewriteCollectionEnumeration.Rewrite(p, chainIndex);
            var sourceSize = p.SourceSize;
            var resultSize = p.ResultSize;
            
            var collection = p.Chain[chainIndex].Arguments[0];
            var indexer = p.CurrentIndexer;
            if (indexer != null && indexer.Name == p.Body.Indexer)
                indexer.IsGlobal = true;

            LocalVariable itemVariable;
            if (p.Last.Value != null && p.Last.Value is LocalVariable lastVariable)
            {
                itemVariable = lastVariable;
            }
            else
            {
                itemVariable = p.CreateLocalVariable("__i", VariableExtensions.IntType);
                p.ForAdd(itemVariable.Assign(p.Last.Value));
                p.Last = (itemVariable, VariableExtensions.IntType);
            }
            
            p.AddIterator(collection);
            if (indexer != null)
            {
                p.PreForAdd(indexer.PreDecrement());
                p.LastForAdd(indexer.PreIncrement());
            }
            p.Variables.Where(x => !x.IsGlobal).ForEach(x => x.IsUsed = false);
            RewriteCollectionEnumeration.RewriteOther(p, collection, 0);
            p.CurrentIndexer = indexer;
            
            p.LastForAdd(itemVariable.Assign(p.Last.Value));
            p.Last = (itemVariable, itemVariable.Type);

            if (sourceSize != null && p.SourceSize != null) p.SourceSize = p.SourceSize.Add(sourceSize);
            else p.SourceSize = null;
            
            if (resultSize != null && p.ResultSize != null) p.ResultSize = p.ResultSize.Add(resultSize);
            else p.ResultSize = null;
        }
    }
}