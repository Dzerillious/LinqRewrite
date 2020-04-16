using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteZip
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            var collectionValue = args[0];
            if (!p.AssertNotNull(collectionValue)) return;
            var methodValue = args[1];
            p.WrapWithTry = true;

            var itemType = collectionValue.ItemType(p);
            var enumeratorVariable = p.GlobalVariable(ParseTypeName($"System.Collections.Generic.IEnumerator<{itemType}>"));
            p.InitialAdd(enumeratorVariable.Assign(Parenthesize(collectionValue.Cast(ParseTypeName($"IEnumerable<{itemType}>")))
                .Access("GetEnumerator").Invoke()));
            
            p.ForAdd(If(Not(enumeratorVariable.Access("MoveNext").Invoke()),
                Throw("System.InvalidOperationException", "Invalid sizes of sources")));

            p.LastValue = methodValue.Inline(p, p.LastValue, new TypedValueBridge(collectionValue.ItemType(p), enumeratorVariable.Access("Current")));
            
            p.ResultAdd(If(enumeratorVariable.Access("MoveNext").Invoke(),
                Throw("System.InvalidOperationException", "Invalid sizes of sources")));

            p.FinalAdd(enumeratorVariable.Access("Dispose").Invoke());
            p.SimpleEnumeration = false;
            p.ListEnumeration = false;
        }
    }
}