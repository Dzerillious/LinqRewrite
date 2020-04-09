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
    // [NoRewrite]
    // [Benchmark]
    // public double ArrayAverage1()
    // {
    //     return Items.Unchecked().Take(10).Aggregate(100, (x, y) => x + y);
    // }
    [Benchmark]
    public double ArrayAverageRewritten2()
    {
        var sum = 0;
        ArrayAverageRewritten2_ProceduralLinq1().ForEach(x =>
        {
            sum += (Items[x] + Items[1 + x] + Items[2 + x] + Items[3 + x] + Items[4 + x] + Items[5 + x] + Items[6 + x] + Items[7 + x] + Items[8 + x] + Items[9 + x]);
        }

        );
        return sum;
    }

    System.Collections.Generic.IEnumerable<int> ArrayAverageRewritten2_ProceduralLinq1()
    {
        if (0 > Items.Length / 10)
            throw new System.InvalidOperationException("Index out of range");
        int v1;
        v1 = (0);
        for (; v1 < (Items.Length / 10); v1++)
            yield return (v1);
        yield break;
    }
}}