using Microsoft.CodeAnalysis;

namespace LinqRewrite.DataStructures
{
    public class VariableCapture
    {
        public VariableCapture(ISymbol symbol, bool changes)
        {
            Symbol = symbol;
            Changes = changes;
        }

        public ISymbol Symbol { get; }
        public bool Changes { get; }
        public string Name => Symbol.Name;
        public string OriginalName => Symbol.IsStatic ? Symbol.ToString() : Symbol.Name;
    }
}