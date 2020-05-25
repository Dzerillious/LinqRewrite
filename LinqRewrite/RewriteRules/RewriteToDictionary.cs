using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteToDictionary
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            var elementValue = args.Length switch
            {
                1 => p.LastValue,
                _ when args[1].OldVal.IsInvokable(p) => args[1].Inline(p, p.LastValue),
                _ => p.LastValue
            };
            var keyValue = args[0].Inline(p, p.LastValue);
            var dictionaryVariable = VariableCreator.GlobalVariable(p, p.ReturnType, args.Length switch
            {
                2 when !args[1].OldVal.IsInvokable(p) => New(p.ReturnType, args[1]),
                3 => New(p.ReturnType, args[2]),
                _ => New(p.ReturnType)
            });

            p.ForAdd(dictionaryVariable.Access("Add").Invoke(keyValue, elementValue));
            p.ResultAdd(Return(dictionaryVariable));
        }
    }
}