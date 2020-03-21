using System;

namespace LinqRewrite.DataStructures
{
    internal class ExitException : Exception
    {
        public int Code { get; }

        public ExitException(int v)
            => Code = v;
    }
}