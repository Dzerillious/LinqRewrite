using System.Linq;
using SimpleCollections;

namespace ResultsTester
{
    static class Example2
    {
        static void Main()
        {
            var arr = Enumerable.Range(0, 50).ToArray();
            var test = Main_ProceduralLinq1(arr);
        }

        static int[] Main_ProceduralLinq1(int[] arr)
        {
            int __i0;
            int __log2 = (SimpleCollections.IntExtensions.Log2((uint)arr.Length) - 3);
            __log2 = (__log2 - (__log2 % 2));
            int __currentLength3 = 8;
            int __i1 = __currentLength3;
            int[] __reversed4 = new int[8];
            int __localSize5;
            int __i6 = -1;
            int __i7;
            __i0 = 0;
            for (; __i0 < arr.Length; __i0++)
            {
                if (!((arr[__i0] > 4)))
                    continue;
                --__i1;
                if (__i1 < 0)
                {
                    __localSize5 = __currentLength3;
                    SimpleCollections.EnlargeExtensions.LogEnlargeReverseArray(2, arr.Length, ref __reversed4, ref __log2, out __currentLength3);
                    __i1 = ((__currentLength3 - __localSize5) - 1);
                }

                __reversed4[__i1] = arr[__i0];
                ++__i6;
            }

            var result = SimpleArrayExtensions.EnsureFullReversedArray(__reversed4, __i6 + 1);
            int[] __result8 = new int[__i6];
            __i7 = 0;
            for (; __i7 < __i6; __i7++)
                __result8[__i7] = (result[__i7] + 3);
            return __result8;
        }


    }

}