using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarkLibrary
{
public class AverageBenchmarks
{
    private int[] Items = Enumerable.Range(0, 100).ToArray();
    //
    // [NoRewrite]
    // [Benchmark]
    // public double RangeAverage()
    // {
    //     return Enumerable.Range(567, 675).Average();
    // }
    //
    // [Benchmark]
    // public double RangeAverageToArray()
    // {
    //     return Enumerable.Range(567, 675).Average();
    // }
    //
    // [NoRewrite]
    // [Benchmark]
    // public double ArrayAverage()
    // {
    //     return Items.Unchecked().Take(10).Average();
    // }
    //
    // [Benchmark]
    // public double ArrayAverageRewritten()
    // {
    //     return Items.Unchecked().Take(10).Average();
    // }
    //
    // [NoRewrite]
    // [Benchmark]
    // public double ArrayAverage1()
    // {
    //     return Items.Unchecked().Take(10).Aggregate(100, (x, y) => x + y);
    // }
    [Benchmark]
    public double ArrayAverage2()
    {
        return ArrayAverage2_ProceduralLinq1(Items);
    }

    [Benchmark]
    public double ArrayAverageRewritten2()
    {
        var sum = ArrayAverageRewritten2_ProceduralLinq1();
        sum += ArrayAverageRewritten2_ProceduralLinq2(Items);
        return sum;
    }

    [Benchmark]
    public double ArrayAverageRewritten3()
    {
        var sum = ArrayAverageRewritten3_ProceduralLinq1();
        sum += ArrayAverageRewritten3_ProceduralLinq2(Items);
        return sum;
    }

    int ArrayAverage2_ProceduralLinq1(int[] Items)
    {
        int v1;
        int v2;
        v2 = 0;
        v1 = (0);
        for (; v1 < (Items.Length); v1 += 1)
            v2 += (Items[v1]);
        return v2;
    }

    int ArrayAverageRewritten2_ProceduralLinq1()
    {
        if (0 > Items.Length / 10)
            throw new System.InvalidOperationException("Index out of range");
        int v4;
        int v5;
        int v6;
        v6 = ((Items.Length / 10 * 10));
        v5 = 0;
        v4 = (0);
        for (; v4 < v6; v4 += (10))
            v5 += ((Items[(v4)] + Items[1 + (v4)] + Items[2 + (v4)] + Items[3 + (v4)] + Items[4 + (v4)] + Items[5 + (v4)] + Items[6 + (v4)] + Items[7 + (v4)] + Items[8 + (v4)] + Items[9 + (v4)]));
        return v5;
    }

    int ArrayAverageRewritten2_ProceduralLinq2(int[] Items)
    {
        int v8;
        int v9;
        int v10;
        v10 = (Items.Length % 10);
        v9 = 0;
        v8 = (((0) + Items.Length - Items.Length % 10));
        for (; v8 < v10; v8 += 1)
            v9 += (Items[v8]);
        return v9;
    }

    int ArrayAverageRewritten3_ProceduralLinq1()
    {
        if (0 > Items.Length / 5)
            throw new System.InvalidOperationException("Index out of range");
        int v12;
        int v13;
        int v14;
        v14 = ((Items.Length / 5 * 5));
        v13 = 0;
        v12 = (0);
        for (; v12 < v14; v12 += (5))
            v13 += ((Items[(v12)] + Items[1 + (v12)] + Items[2 + (v12)] + Items[3 + (v12)] + Items[4 + (v12)]));
        return v13;
    }

    int ArrayAverageRewritten3_ProceduralLinq2(int[] Items)
    {
        int v16;
        int v17;
        int v18;
        v18 = (Items.Length % 5);
        v17 = 0;
        v16 = (((0) + Items.Length - Items.Length % 5));
        for (; v16 < v18; v16 += 1)
            v17 += (Items[v16]);
        return v17;
    }
}}