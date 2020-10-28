using System.Collections.Immutable;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteToDictionary
    {
        public static void Rewrite(RewriteDesign design, ImmutableArray<ValueBridge> args)
        {
            var elementValue = args.Length switch
            {
                1 => design.LastValue,
                _ when args[1].Value.IsInvokable(design) => args[1].Inline(design, design.LastValue),
                _ => design.LastValue
            };
            var keyValue = args[0].Inline(design, design.LastValue);
            var dictionaryVariable = CreateGlobalVariable(design, design.Info.ReturnType, args.Length switch
            {
                2 when !args[1].Value.IsInvokable(design) => New(design.Info.ReturnType, args[1]),
                3 => New(design.Info.ReturnType, args[2]),
                _ => New(design.Info.ReturnType)
            });

            design.ForAdd(dictionaryVariable.Access("Add").Invoke(keyValue, elementValue));
            design.ResultAdd(Return(dictionaryVariable));
        }
    }
}