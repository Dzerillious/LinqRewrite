using System.Collections.Immutable;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.AssertionExtension;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteZip
    {
        public static void Rewrite(RewriteDesign design, ImmutableArray<ValueBridge> args)
        {
            var collectionValue = args[0];
            if (!AssertNotNull(design, collectionValue)) return;
            var methodValue = args[1];
            design.WrapWithTry = true;

            var itemType = collectionValue.ItemType(design);
            var enumeratorVariable = CreateGlobalVariable(design, ParseTypeName($"System.Collections.Generic.IEnumerator<{itemType}>"));
            design.InitialAdd(enumeratorVariable.Assign(Parenthesize(collectionValue.Cast(ParseTypeName($"IEnumerable<{itemType}>")))
                .Access("GetEnumerator").Invoke()));
            
            design.ForAdd(If(Not(enumeratorVariable.Access("MoveNext").Invoke()), Break()));
            design.LastValue = methodValue.Inline(design, design.LastValue, new TypedValueBridge(collectionValue.ItemType(design), enumeratorVariable.Access("Current")));

            design.FinalAdd(enumeratorVariable.Access("Dispose").Invoke());
            design.ListEnumeration = false;
            design.ModifiedEnumeration = true;
        }
    }
}