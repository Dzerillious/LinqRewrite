// Forked and modified from https://github.com/antiufo/roslyn-linq-rewrite/tree/master/RoslynLinqRewrite

using Microsoft.CodeAnalysis;

namespace LinqRewrite.DataStructures
{
    public class VariableCapture
    {
        public ISymbol Symbol { get; }
        public bool IsChanging { get; }
        public string Name => Symbol.Name;
        public string OriginalName => Symbol.IsStatic ? Symbol.ToString() : Symbol.Name;

        public VariableCapture(ISymbol symbol, bool isChanging)
        {
            Symbol = symbol;
            IsChanging = isChanging;
        }
    }
}