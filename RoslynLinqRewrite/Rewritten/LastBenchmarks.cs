using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;

namespace BenchmarkLibrary
{
public class LastBenchmarks
{
    public static int[] StaticArraySource;
    public int[] ArraySource;
    public IEnumerable<int> EnumerableSource;
    public int Selector(int a) => a + 3;
    [GlobalSetup]
    public void GlobalSetup()
    {
        StaticArraySource = GlobalSetup_ProceduralLinq1();
        ArraySource = GlobalSetup_ProceduralLinq2();
        EnumerableSource = GlobalSetup_ProceduralLinq3();
    }

    [NoRewrite, Benchmark]
    public void ArrayLast()
    {
        var res = ArraySource.Last();
    } //EndMethod

    [Benchmark]
    public void ArrayLastRewritten()
    {
        var res = ArraySource[-1 + ArraySource.Length];
    } //EndMethod

    [NoRewrite, Benchmark]
    public void ArrayLastCondition()
    {
        var res = ArraySource.Last(x => x > 3);
    } //EndMethod

    [Benchmark]
    public void ArrayLastRewrittenCondition()
    {
        var res = ArrayLastRewrittenCondition_ProceduralLinq1(ArraySource);
    } //EndMethod

    [NoRewrite, Benchmark]
    public void ArraySelectLast()
    {
        var res = ArraySource.Select(x => x + 3).Last();
    } //EndMethod

    [Benchmark]
    public void ArraySelectLastRewritten()
    {
        var res = 3 + ArraySource[-1 + ArraySource.Length];
    } //EndMethod

    int[] GlobalSetup_ProceduralLinq1()
    {
        int v10;
        int[] v11;
        v11 = new int[(1000)];
        return v11;
    }

    int[] GlobalSetup_ProceduralLinq2()
    {
        int v12;
        int[] v13;
        v13 = new int[(1000)];
        return v13;
    }

    System.Collections.Generic.IEnumerable<int> GlobalSetup_ProceduralLinq3()
    {
        int v14;
        v14 = (0);
        for (; v14 < (1000); v14++)
            yield return (v14);
        yield break;
    }

    int ArrayLastRewrittenCondition_ProceduralLinq1(int[] ArraySource)
    {
        int v17;
        int? v18;
        v18 = null;
        v17 = (0);
        for (; v17 < (ArraySource.Length); v17++)
            if (((ArraySource[v17]) > 3))
                v18 = (ArraySource[v17]);
        if (v18 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v18;
    }
}}