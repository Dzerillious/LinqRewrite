using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.DataStructures
{
    public class TypedValueBridge : ValueBridge
    {
        public ExpressionSyntax Expression => Value.Value;
        public new ValueBridge Value { get; protected set; }
        public TypeSyntax Type { get; protected set; }

        public TypedValueBridge(RewriteDesign design, ValueBridge value) : base(value)
        {
            Type = value.GetType(design);
            Value = value;
        }

        public TypedValueBridge(TypeSyntax type, IdentifierNameSyntax name) : base(name)
        {
            Type = type;
            Value = name;
        }

        public TypedValueBridge(TypeBridge type, ValueBridge name) : base(name)
        {
            Type = type;
            Value = name;
        }

        public TypedValueBridge(TypeSyntax type, LocalVariable variable) : base(variable)
        {
            Type = type;
            Value = variable;
        }

        public TypedValueBridge(TypeBridge type, LocalVariable variable) : base(variable)
        {
            Type = type;
            Value = variable;
        }
        
        public static implicit operator TypedValueBridge(LocalVariable name)
            => new TypedValueBridge(name.Type, name.Value);
    }
}