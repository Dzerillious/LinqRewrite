using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;

namespace BenchmarkLibrary
{
public class FirstBenchmarks
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
    public void ArrayFirst()
    {
        var res = ArraySource.First();
    } //EndMethod

    [Benchmark]
    public void ArrayFirstRewritten()
    {
        var res = ArraySource[0];
    } //EndMethod

    [NoRewrite, Benchmark]
    public void ArrayFirstCondition()
    {
        var res = ArraySource.First(x => x > 3);
    } //EndMethod

    [Benchmark]
    public void ArrayFirstRewrittenCondition()
    {
        var res = ArrayFirstRewrittenCondition_ProceduralLinq1(ArraySource);
    } //EndMethod

    [NoRewrite, Benchmark]
    public void ArraySelectFirst()
    {
        var res = ArraySource.Select(x => x + 3).First();
    } //EndMethod

    [Benchmark]
    public void ArraySelectFirstRewritten()
    {
        var res = 3 + ArraySource[0];
    } //EndMethod

    int[] GlobalSetup_ProceduralLinq1()
    {
        int v2;
        int[] v3;
        v3 = new int[(1000)];
        return v3;
    }

    int[] GlobalSetup_ProceduralLinq2()
    {
        int v4;
        int[] v5;
        v5 = new int[(1000)];
        return v5;
    }

    System.Collections.Generic.IEnumerable<int> GlobalSetup_ProceduralLinq3()
    {
        int v6;
        v6 = (0);
        for (; v6 < (1000); v6++)
            yield return (v6);
        yield break;
    }

    int ArrayFirstRewrittenCondition_ProceduralLinq1(int[] ArraySource)
    {
        int v8;
        v8 = (0);
        for (; v8 < (ArraySource.Length); v8++)
            if (((ArraySource[v8]) > 3))
                return (ArraySource[v8]);
        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }
}}

