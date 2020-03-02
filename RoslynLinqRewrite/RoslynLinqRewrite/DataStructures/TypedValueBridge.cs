using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.VariableExtensions;

namespace LinqRewrite.DataStructures
{
    public class TypedValueBridge : ValueBridge
    {
        public new ValueBridge Value { get; }
        public TypeSyntax Type { get; }
        
        public TypedValueBridge(bool value) : base(value)
        {
            Type = Bool;
            Value = value;
        }

        public TypedValueBridge(int value) : base(value)
        {
            Type = Int;
            Value = value;
        }

        public TypedValueBridge(TypeSyntax type, ExpressionSyntax value) : base(value)
        {
            Type = type;
            Value = value;
        }

        public TypedValueBridge(TypeSyntax type, IdentifierNameSyntax name) : base(name)
        {
            Type = type;
            Value = name;
        }

        public TypedValueBridge(TypeSyntax type, string name) : base(name)
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

        public void Deconstruct(out TypeBridge type, out ValueBridge value)
        {
            type = Type;
            value = Value;
        }
    }
}