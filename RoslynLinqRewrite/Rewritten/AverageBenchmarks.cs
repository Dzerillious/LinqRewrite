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
    public double Select1()
    {
        return Enumerable.Range(567, 675).Average();
    }

    [Benchmark]
    public double Select1Rewritten()
    {
        return Select1Rewritten_ProceduralLinq1();
    }

    [NoRewrite]
    [Benchmark]
    public double Select2()
    {
        return Items.Average();
    }

    [Benchmark]
    public double Select2Rewritten()
    {
        return Select2Rewritten_ProceduralLinq1(Items);
    }

    double Select1Rewritten_ProceduralLinq1()
    {
        int v0;
        double v1;
        v1 = 0;
        v0 = 0;
        for (; v0 < 675; v0++)
            v1 += (v0 + 567);
        return (v1 / 675);
    }

    double Select2Rewritten_ProceduralLinq1(int[] Items)
    {
        int v2;
        double v3;
        if (Items.Length < 0)
            throw new System.InvalidOperationException("Index out of range");
        v3 = 0;
        v2 = 0;
        for (; v2 < Items.Length; v2++)
            v3 += Items[v2];
        return (v3 / Items.Length);
    }
}}