using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarkLibrary
{
public class AverageBenchmarks
{
    private int[] Items = Enumerable.Range(0, 100).ToArray();
    [NoRewrite]
    [Benchmark]
    public double RangeAverage()
    {
        return Enumerable.Range(567, 675).Average();
    }

    [Benchmark]
    public double RangeAverageToArray()
    {
        return ((((567 + 567) + 675) - 1) / 2);
    }

    [NoRewrite]
    [Benchmark]
    public double ArrayAverage()
    {
        return Items.Average();
    }

    [Benchmark]
    public double ArrayAverageRewritten()
    {
        return ArrayAverageRewritten_ProceduralLinq1(Items);
    }

    double ArrayAverageRewritten_ProceduralLinq1(int[] Items)
    {
        int v0;
        double v1;
        if (1 > (Items.Length))
            throw new System.InvalidOperationException("Index out of range");
        v1 = 0;
        v0 = (0);
        for (; v0 < (Items.Length); v0++)
            v1 += (Items[v0]);
        return (v1 / (Items.Length));
    }
}}