using System.Linq;
using LinqRewrite.DataStructures;

namespace ResultsTester
{
    static class Example2
    {
        public static void Main()
        {
            var arr = new[] { 1, 2, 3, 4 };
            var q = 2;

            var res = arr.GroupJoin(arr, x => x, x => x, (x, y) => x + y.Sum()).ToArray();
            var a = Method1_ProceduralLinq1(arr);
        }

        static int[] Method1_ProceduralLinq1(int[] arr)
        {
            int v0;
            InternalLookup<int, int> v1;
            int v2;
            int v3;
            int v4;
            int[] v5;
            v1 = InternalLookup<int, int>.CreateForJoin(arr, x => x, null);
            v2 = 0;
            v3 = (SimpleCollections.IntExtensions.Log2((uint)arr.Length) - 3);
            v3 -= (v3 % 2);
            v4 = 8;
            v5 = new int[8];
            v0 = 0;
            for (; v0 < arr.Length; v0++)
            {
                if (v2 >= v4)
                    SimpleCollections.EnlargeExtensions.LogEnlargeArray(2, arr.Length, ref v5, ref v3, out v4);
                v5[v2] = (arr[v0] + v1[(arr[v0])].Sum());
                v2++;
            }

            return SimpleCollections.SimpleArrayExtensions.EnsureFullArray(v5, v2);
        }


    }
}