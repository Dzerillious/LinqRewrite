using System.Linq;

namespace ResultsTester
{
    static class Example2
    {
        static void Main()
        {
            var arr = Enumerable.Range(0, 50).ToArray();
            var test = Main_ProceduralLinq1();
            test = Main_ProceduralLinq2();
        }

        static int[] Main_ProceduralLinq1()
        {
            int v0;
            int v1;
            int v2 = (SimpleCollections.IntExtensions.Log2((uint)100) - 3);
            v2 -= (v2 % 2);
            int v3 = 8;
            int[] v4 = new int[8];
            v1 = 8;
            int v5;
            v0 = 5;
            for (; v0 < (5 + 100); v0++)
            {
                if (!(v0 >= 25))
                    continue;
                --v1;
                if (v1 < 0)
                {
                    v5 = v3;
                    SimpleCollections.EnlargeExtensions.LogEnlargeReverseArray(2, 100, ref v4, ref v2, out v3);
                    v1 = ((v3 - v5) - 1);
                }

                v4[v1] = v0;
            }

            int[] v6 = new int[(v3 - v1)];
            v0 = 0;
            for (; v0 < (v3 - v1); v0++)
                v6[v0] = v4[(v0 + v1)];
            return v6;
        }


        static int[] Main_ProceduralLinq2()
        {
            int v0;
            int[] v1 = new int[(100 - 20)];
            int v2 = 0;
            v0 = ((5 + 100) - 1);
            for (; v0 >= (5 + 20); v0--)
            {
                v1[v2] = v0;
                v2++;
            }

            return v1;
        }
    }
}