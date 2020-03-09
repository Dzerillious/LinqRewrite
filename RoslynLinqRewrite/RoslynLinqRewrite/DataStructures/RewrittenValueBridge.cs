using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.DataStructures
{
    public class RewrittenValueBridge : ValueBridge
    {
        public ValueBridge Old { get; }
        public ExpressionSyntax OldVal => Old.Value;
        public ValueBridge New { get; }
        public ExpressionSyntax NewVal => New.Value;

        public RewrittenValueBridge(ExpressionSyntax old, ExpressionSyntax @new) : base(@new)
        {
            Old = old;
            New = @new;
        }

        public RewrittenValueBridge(ExpressionSyntax old) : base(old)
        {
            New = Old = old;
        }
    }
}