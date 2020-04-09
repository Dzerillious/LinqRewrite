using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.OperatorExpressionExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteOfType
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args, InvocationExpressionSyntax invocation)
        {
            var access = (MemberAccessExpressionSyntax) invocation.Expression;
            var name = (GenericNameSyntax) access.Name;
            var type = name.TypeArgumentList.Arguments[0];

            p.LastValue = p.LastValue.Reusable(p);
            p.ForAdd(If(Not(p.LastValue.Is(type)),
                        Continue()));

            p.LastValue = p.Unchecked ? new TypedValueBridge(type, p.LastValue.Cast(type)) 
                : new TypedValueBridge(type, p.LastValue.Cast(ParseTypeName("object")).Cast(type));

            p.ResultSize = null;
            p.ModifiedEnumeration = true;
        }
    }
}