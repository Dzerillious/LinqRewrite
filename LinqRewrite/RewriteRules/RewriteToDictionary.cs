using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteToDictionary
    {
        public static void Rewrite(RewriteDesign design, RewrittenValueBridge[] args)
        {
            var elementValue = args.Length switch
            {
                1 => design.LastValue,
                _ when args[1].OldVal.IsInvokable(design) => args[1].Inline(design, design.LastValue),
                _ => design.LastValue
            };
            var keyValue = args[0].Inline(design, design.LastValue);
            var dictionaryVariable = VariableCreator.GlobalVariable(design, design.ReturnType, args.Length switch
            {
                2 when !args[1].OldVal.IsInvokable(design) => New(design.ReturnType, args[1]),
                3 => New(design.ReturnType, args[2]),
                _ => New(design.ReturnType)
            });

            design.ForAdd(dictionaryVariable.Access("Add").Invoke(keyValue, elementValue));
            design.ResultAdd(Return(dictionaryVariable));
        }
    }
}