using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteDistinct
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            var hashsetType = ParseTypeName($"LinqRewrite.Core.SimpleSet<{p.LastValue.Type}>");
            var hashsetVariable = VariableCreator.GlobalVariable(p, hashsetType, args.Length switch
            {
                0 => New(hashsetType),
                1 => New(hashsetType, args[0])
            });

            p.LastValue = p.LastValue.Reusable(p);
            p.ForAdd(If(Not(hashsetVariable.Access("Add").Invoke(p.LastValue)),
                        Continue()));
            
            p.ListEnumeration = false;
            p.ModifiedEnumeration = true;
        }
    }
}