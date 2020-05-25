using System.Linq;
using LinqRewrite.DataStructures;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using LinqRewrite.Core;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteEmpty
    {
        public static void Rewrite(RewriteDesign design, RewrittenValueBridge[] args, InvocationExpressionSyntax invocation)
        {
            design.Variables.Where(x => !x.IsGlobal).ForEach(x => x.IsUsed = false);
            var access = (MemberAccessExpressionSyntax) invocation.Expression;
            var name = (GenericNameSyntax) access.Name;
            var type = name.TypeArgumentList.Arguments[0];
            
            if (design.RewriteChain.Count == 1)
            {
                design.NotRewrite = true;
                return;
            }

            design.FirstCollection = design.CurrentCollection = null;
            design.AddIterator();
            
            design.CurrentIterator.IgnoreIterator = true;
            design.CurrentIterator.ForFrom = 0;
            design.CurrentIterator.ForTo = 0;
            design.CurrentIterator.ForIndexer = VariableCreator.LocalVariable(design, Int, 0);
            
            design.ResultSize = 0;
            design.SourceSize = 0;
            design.ListEnumeration = false;
            design.SimpleEnumeration = true;
            
            if (design.CurrentIndexer == null)
            {
                design.CurrentIterator.Indexer = design.CurrentIterator.ForIndexer;
                design.CurrentIterator.Indexer.IsGlobal = true;
            }
            design.LastValue = new TypedValueBridge(type, Default(type));
            design.CurrentCollection = null;
        }
    }
}