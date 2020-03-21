using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace LinqRewrite.Core
{
    public static class IntExtensions
    {
        [StructLayout(LayoutKind.Explicit)]
        private ref struct ConverterStruct
        {
            [FieldOffset(0)] public int asInt;
            [FieldOffset(0)] public float asFloat;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Log2(uint val)
        {
            ConverterStruct a;  a.asInt = 0; a.asFloat = val;
            return ((a.asInt >> 23) + 1) & 0x1F;
        }
    }
}