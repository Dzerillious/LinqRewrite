using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.VariableExtensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteCollectionEnumeration
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args, bool? reuseVariables = null)
        {
            if (!p.AssertNotNull(p.CurrentCollection)) return;
            p.AddIterator(new RewrittenValueBridge(p.CurrentCollection));
            RewriteOther(p, p.CurrentCollection, null, false, reuseVariables);
        }
        
        public static void RewriteOther(RewriteParameters p, CollectionValueBridge collection, LocalVariable variable = null, bool otherIndexer = false, bool? reuseVariables = null)
        {
            if (collection.CollectionType == CollectionType.Array
                || collection.CollectionType == CollectionType.List
                || collection.CollectionType == CollectionType.SimpleList) ArrayEnumeration(p, collection.ItemType, collection.Count, collection, variable);
            else if (collection.CollectionType == CollectionType.Enumerable) EnumerableEnumeration(p, collection, variable);

            if (otherIndexer) p.CurrentIterator.CurrentIndexer = null;
        }

        public static void ArrayEnumeration(RewriteParameters p, TypeBridge itemType, ValueBridge count, ValueBridge collection, LocalVariable variable = null)
        {
            p.ForMin = p.ForReMin = 0;
            p.ForMax = count;
            p.ForReMax = count - 1;

            p.CurrentIterator.ForIndexer = p.GlobalVariable(Int);
            if (p.CurrentIndexer == null)
            {
                p.CurrentIterator.CurrentIndexer = p.CurrentIterator.ForIndexer;
                p.CurrentIterator.CurrentIndexer.IsGlobal = true;
            }
            
            if (variable == null)
            {
                p.LastValue = new TypedValueBridge(itemType, collection[p.CurrentIterator.ForIndexer]);
            }
            else
            {
                p.CurrentIterator.BodyAdd(variable.Assign(collection[p.CurrentIterator.ForIndexer]));
                p.LastValue = new TypedValueBridge(itemType, variable);
            }
            
            p.ResultSize = count;
            p.SourceSize = count;
            p.SimpleEnumeration = true;
            p.ListEnumeration = true;
        }

        public static void EnumerableEnumeration(RewriteParameters p, CollectionValueBridge collection, LocalVariable variable = null)
        {
            p.ForMin = p.ForReMin = null;
            p.ForMax = p.ForReMax = null;

            p.CurrentIterator.EnumeratorVariable = p.GlobalVariable(ParseTypeName($"System.Collections.Generic.IEnumerator<{collection.ItemType}>"));
            if (variable != null)
            {
                p.CurrentForAdd(variable.Assign(p.CurrentIterator.EnumeratorVariable.Access("Current")));
                p.LastValue = new TypedValueBridge(collection.ItemType, variable);
            }
            else p.LastValue = new TypedValueBridge(collection.ItemType, p.CurrentIterator.EnumeratorVariable.Access("Current"));

            p.SourceSize = null;
            p.ModifiedEnumeration = true;
        }
    }
}