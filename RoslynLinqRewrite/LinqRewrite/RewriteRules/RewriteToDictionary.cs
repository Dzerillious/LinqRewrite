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

            var dictionaryVariable = args.Length switch
            {
                2 when !(args[1].OldVal.IsInvokable(p)) => p.GlobalVariable(p.ReturnType, New(p.ReturnType, args[1])),
                3 => p.GlobalVariable(p.ReturnType, New(p.ReturnType, args[2])),
                _ => p.GlobalVariable(p.ReturnType, New(p.ReturnType))
            };

            p.ForAdd(dictionaryVariable.Access("Add").Invoke(keyValue, elementValue));
            p.ResultAdd(Return(dictionaryVariable));
        }
    }
}