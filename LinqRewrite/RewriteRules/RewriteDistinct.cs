using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteDistinct
    {
        public static void Rewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            var hashsetType = ParseTypeName($"LinqRewrite.Core.SimpleSet<{design.LastValue.Type}>");
            var hashsetVariable = VariableCreator.GlobalVariable(design, hashsetType, args.Length switch
            {
                0 => New(hashsetType),
                1 => New(hashsetType, args[0])
            });

            design.LastValue = design.LastValue.Reusable(design);
            design.ForAdd(If(Not(hashsetVariable.Access("Add").Invoke(design.LastValue)),
                        Continue()));
            
            design.ListEnumeration = false;
            design.ModifiedEnumeration = true;
        }
    }
}