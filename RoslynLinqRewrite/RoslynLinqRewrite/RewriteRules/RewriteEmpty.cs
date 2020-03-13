using System.Linq;
using LinqRewrite.DataStructures;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SimpleCollections;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteEmpty
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args, InvocationExpressionSyntax invocation)
        {
            p.Variables.Where(x => !x.IsGlobal).ForEach(x => x.IsUsed = false);
            if (p.Chain.Count == 1) p.NotRewrite = true;

            var access = (MemberAccessExpressionSyntax) invocation.Expression;
            var name = (GenericNameSyntax) access.Name;
            var type = name.TypeArgumentList.Arguments[0];
            
            p.Iterators.Add(p.Iterator = new IteratorParameters(p));
            p.ForMin = p.ForReMin = 0;
            p.ForMax = 0;
            p.ForReMax = -1;
            
            p.ResultSize = 0;
            p.SourceSize = 0;
            p.ListEnumeration = false;
            
            p.Iterator.Indexer = p.LocalVariable(Int);
            if (p.CurrentIndexer == null)
            {
                p.Iterator.CurrentIndexer = p.Iterator.Indexer;
                p.Iterator.CurrentIndexer.IsGlobal = true;
            }
            p.Last = new TypedValueBridge(type, Default(type));
            p.CurrentCollection = null;
        }
    }
}