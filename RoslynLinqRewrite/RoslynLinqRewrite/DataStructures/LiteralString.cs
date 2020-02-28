using System;
using Microsoft.CodeAnalysis;

namespace LinqRewrite.DataStructures
{
    public class LiteralString : LocalizableString
    {
        private readonly string _str;
        public LiteralString(string str)
            => _str = str;
        
        protected override bool AreEqual(object other)
            => other is LiteralString o && o._str == _str;

        protected override int GetHash() => _str.GetHashCode();
        protected override string GetText(IFormatProvider formatProvider) => _str;
    }
}
