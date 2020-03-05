using System.Linq;

namespace ResultsTester
{
    static class Example2
    {
        static void Main()
        {
            var arr = new int[10].AsEnumerable();
            var test = Main_ProceduralLinq1(arr);
        }

        static int[] Main_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> arr)
        {
            if (arr == null)
                throw new System.InvalidOperationException("Collection was null.");
            var __indexer0 = -1;
            var __currentLength = 8;
            var __result = new int[8];
            foreach (var __item in arr)
            {
                ++__indexer0;
                if (__indexer0 >= __currentLength)
                    SimpleCollections.EnlargeExtensions.LogEnlargeArray(2, ref __result, ref __currentLength);
                __result[__indexer0] = (__item + __indexer0);
            }

            return SimpleCollections.SimpleArrayExtensions.EnsureFullArray(__result, __indexer0);
        }

    }

}