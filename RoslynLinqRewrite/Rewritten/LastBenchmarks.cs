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
    public SimpleList<int> SimpleListSource;
    public int Selector(int a) => a + 3;
    [GlobalSetup]
    public void GlobalSetup()
    {
        StaticArraySource = GlobalSetup_ProceduralLinq1();
        ArraySource = GlobalSetup_ProceduralLinq2();
        EnumerableSource = GlobalSetup_ProceduralLinq3();
        SimpleListSource = GlobalSetup_ProceduralLinq4();
    }

    [Benchmark]
    public void SimpleListLast()
    {
        var res = SimpleListSource[-1 + SimpleListSource.Count];
    } //EndMethod

    [Benchmark]
    public void SimpleListLast2()
    {
        var res = SimpleListLast2_ProceduralLinq1(SimpleListSource);
    } //EndMethod

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
        int v12;
        int[] v13;
        v13 = new int[(1000)];
        v12 = (0);
        for (; v12 < (1000); v12++)
            v13[v12] = (v12);
        return v13;
    }

    int[] GlobalSetup_ProceduralLinq2()
    {
        int v14;
        int[] v15;
        v15 = new int[(1000)];
        v14 = (0);
        for (; v14 < (1000); v14++)
            v15[v14] = (v14);
        return v15;
    }

    System.Collections.Generic.IEnumerable<int> GlobalSetup_ProceduralLinq3()
    {
        int v16;
        v16 = (0);
        for (; v16 < (1000); v16++)
            yield return (v16);
        yield break;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> GlobalSetup_ProceduralLinq4()
    {
        int v17;
        int[] v18;
        SimpleList<int> v19;
        v18 = new int[(1000)];
        v17 = (0);
        for (; v17 < (1000); v17++)
            v18[v17] = (v17);
        v19 = new SimpleList<int>();
        v19.Items = v18;
        v19.Count = (1000);
        return v19;
    }

    int SimpleListLast2_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListSource)
    {
        int v21;
        LinqRewrite.Core.SimpleList.SimpleList<int> v22;
        int v23;
        int? v24;
        v21 = SimpleListSource.Count;
        v22 = SimpleListSource;
        v24 = null;
        v23 = (0);
        for (; v23 < (v21); v23++)
            if (((v22[v23]) > 5))
                v24 = (v22[v23]);
        if (v24 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v24;
    }

    int ArrayLastRewrittenCondition_ProceduralLinq1(int[] ArraySource)
    {
        int v26;
        int? v27;
        v27 = null;
        v26 = (0);
        for (; v26 < (ArraySource.Length); v26++)
            if (((ArraySource[v26]) > 3))
                v27 = (ArraySource[v26]);
        if (v27 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v27;
    }
}}