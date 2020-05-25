using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.DataStructures
{
    public class RewrittenValueBridge : ValueBridge
    {
        public ValueBridge Old { get; }
        public ExpressionSyntax OldVal => Old.Value;
        public ValueBridge New { get; }
        public ExpressionSyntax NewVal => New.Value;

        public RewrittenValueBridge(ValueBridge old, ValueBridge @new) : base(@new?.Value == null ? old : @new)
        {
            Old = old;
            New = Value;
        }

        public RewrittenValueBridge(ExpressionSyntax old, ExpressionSyntax @new) : base(@new ?? old)
        {
            Old = old;
            New = Value;
        }

        public RewrittenValueBridge(ExpressionSyntax old) : base(old)
        {
            New = Old = old;
        }
    }
}