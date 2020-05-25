using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteContains
    {
        public static void Rewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            var elementSyntax = design.Node.ArgumentList.Arguments.First().Expression;
            var elementEqualityValue = args.Length switch
            {
                1 => design.LastValue.IsEqual(elementSyntax),
                2 => args[1].ReusableConst(design).Access("Equals").Invoke(design.LastValue.Value, elementSyntax)
            };
            
            design.ForAdd(If(elementEqualityValue, Return(true)));
            design.ResultAdd(Return(false));
        }
    }
}