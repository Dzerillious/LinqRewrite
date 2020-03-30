using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class AggregateTests
{
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 1000).ToArray();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 1000);
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(AggregateSum), AggregateSum, AggregateSumRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableAggregateSum), EnumerableAggregateSum, EnumerableAggregateSumRewritten);
        TestsExtensions.TestEquals(nameof(AggregateCount), AggregateCount, AggregateCountRewritten);
        TestsExtensions.TestEquals(nameof(AggregateEma), AggregateEma, AggregateEmaRewritten);
        TestsExtensions.TestEquals(nameof(AggregateDoubleSum), AggregateDoubleSum, AggregateDoubleSumRewritten);
        TestsExtensions.TestEquals(nameof(AggregateDoubleEma), AggregateDoubleEma, AggregateDoubleEmaRewritten);
        TestsExtensions.TestEquals(nameof(AggregateDoubleFactorial), AggregateDoubleFactorial, AggregateDoubleFactorialRewritten);
        TestsExtensions.TestEquals(nameof(AggregateDoubleAverage), AggregateDoubleAverage, AggregateDoubleAverageRewritten);
        TestsExtensions.TestEquals(nameof(AggregateDoubleAverageSelected), AggregateDoubleAverageSelected, AggregateDoubleAverageSelectedRewritten);
        TestsExtensions.TestEquals(nameof(AggregateDoubleAverageWhere), AggregateDoubleAverageWhere, AggregateDoubleAverageWhereRewritten);
        TestsExtensions.TestEquals(nameof(AggregateRangeSum), AggregateRangeSum, AggregateRangeSumRewritten);
        TestsExtensions.TestEquals(nameof(AggregateRangeFactorial0), AggregateRangeFactorial0, AggregateRangeFactorial0Rewritten);
        TestsExtensions.TestEquals(nameof(AggregateRangeFactorial20), AggregateRangeFactorial20, AggregateRangeFactorial20Rewritten);
        TestsExtensions.TestEquals(nameof(AggregateRangeFactorial100), AggregateRangeFactorial100, AggregateRangeFactorial100Rewritten);
        TestsExtensions.TestEquals(nameof(AggregateEmpty), AggregateEmpty, AggregateEmptyRewritten);
        TestsExtensions.TestEquals(nameof(AggregateEmptyDefault), AggregateEmptyDefault, AggregateEmptyDefaultRewritten);
    }

    [NoRewrite]
    public int AggregateSum()
    {
        return ArrayItems.Aggregate((x, y) => x + y);
    } //EndMethod

    public int AggregateSumRewritten()
    {
        return AggregateSumRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int EnumerableAggregateSum()
    {
        return EnumerableItems.Aggregate((x, y) => x + y);
    } //EndMethod

    public int EnumerableAggregateSumRewritten()
    {
        return EnumerableAggregateSumRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public int AggregateCount()
    {
        return ArrayItems.Aggregate((x, y) => x + 1);
    } //EndMethod

    public int AggregateCountRewritten()
    {
        return AggregateCountRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int AggregateEma()
    {
        return ArrayItems.Aggregate((x, y) => (x + y) / 2);
    } //EndMethod

    public int AggregateEmaRewritten()
    {
        return AggregateEmaRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double AggregateDoubleSum()
    {
        return ArrayItems.Aggregate(0.0, (x, y) => x + y);
    } //EndMethod

    public double AggregateDoubleSumRewritten()
    {
        return AggregateDoubleSumRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double AggregateDoubleEma()
    {
        return ArrayItems.Aggregate(0.0, (x, y) => (x + y) / 2);
    } //EndMethod

    public double AggregateDoubleEmaRewritten()
    {
        return AggregateDoubleEmaRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double AggregateDoubleFactorial()
    {
        return ArrayItems.Aggregate(1.0, (x, y) => x * y);
    } //EndMethod

    public double AggregateDoubleFactorialRewritten()
    {
        return AggregateDoubleFactorialRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double AggregateDoubleAverage()
    {
        return ArrayItems.Aggregate(0.0, (x, y) => x + y, x => x / ArrayItems.Length);
    } //EndMethod

    public double AggregateDoubleAverageRewritten()
    {
        return AggregateDoubleAverageRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double AggregateDoubleAverageSelected()
    {
        return ArrayItems.Select(x => x + 5).Aggregate(0.0, (x, y) => x + y, x => x / ArrayItems.Length);
    } //EndMethod

    public double AggregateDoubleAverageSelectedRewritten()
    {
        return AggregateDoubleAverageSelectedRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double AggregateDoubleAverageWhere()
    {
        return ArrayItems.Where(x => x % 2 == 0).Aggregate(0.0, (x, y) => x + y, x => x / ArrayItems.Length);
    } //EndMethod

    public double AggregateDoubleAverageWhereRewritten()
    {
        return AggregateDoubleAverageWhereRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int AggregateRangeSum()
    {
        return Enumerable.Range(0, 100).Aggregate((x, y) => x + y);
    } //EndMethod

    public int AggregateRangeSumRewritten()
    {
        return AggregateRangeSumRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public double AggregateRangeFactorial0()
    {
        return Enumerable.Range(0, 100).Aggregate(1.0, (x, y) => x * y);
    } //EndMethod

    public double AggregateRangeFactorial0Rewritten()
    {
        return AggregateRangeFactorial0Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public double AggregateRangeFactorial20()
    {
        return Enumerable.Range(1, 20).Aggregate(1.0, (x, y) => x * y);
    } //EndMethod

    public double AggregateRangeFactorial20Rewritten()
    {
        return AggregateRangeFactorial20Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public double AggregateRangeFactorial100()
    {
        return Enumerable.Range(1, 100).Aggregate(1.0, (x, y) => x * y);
    } //EndMethod

    public double AggregateRangeFactorial100Rewritten()
    {
        return AggregateRangeFactorial100Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public double AggregateEmptyDefault()
    {
        return ArrayItems.Where(x => false).Aggregate(1.0, (x, y) => x + y);
    } //EndMethod

    public double AggregateEmptyDefaultRewritten()
    {
        return AggregateEmptyDefaultRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double AggregateEmpty()
    {
        return ArrayItems.Where(x => false).Aggregate((x, y) => x + y);
    } //EndMethod

    public double AggregateEmptyRewritten()
    {
        return AggregateEmptyRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    int AggregateSumRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v0;
        int v1;
        v1 = ArrayItems[0];
        v0 = (0 + 1);
        for (; v0 < ArrayItems.Length; v0++)
            v1 = (v1 + ArrayItems[v0]);
        return v1;
    }

    int EnumerableAggregateSumRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2;
        int v3;
        bool v4;
        v3 = default(int);
        v4 = true;
        v2 = EnumerableItems.GetEnumerator();
        try
        {
            while (v2.MoveNext())
                if (v4)
                {
                    v3 = v2.Current;
                    v4 = false;
                    continue;
                }
                else
                    v3 = (v3 + v2.Current);
        }
        finally
        {
            v2.Dispose();
        }

        if (v4)
            throw new System.InvalidOperationException("The sequence did not contain valid elements.");
        return v3;
    }

    int AggregateCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v5;
        int v6;
        v6 = ArrayItems[0];
        v5 = (0 + 1);
        for (; v5 < ArrayItems.Length; v5++)
            v6 = (v6 + 1);
        return v6;
    }

    int AggregateEmaRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v7;
        int v8;
        v8 = ArrayItems[0];
        v7 = (0 + 1);
        for (; v7 < ArrayItems.Length; v7++)
            v8 = ((v8 + ArrayItems[v7]) / 2);
        return v8;
    }

    double AggregateDoubleSumRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v9;
        double v10;
        v10 = 0.0;
        v9 = 0;
        for (; v9 < ArrayItems.Length; v9++)
            v10 = (v10 + ArrayItems[v9]);
        return v10;
    }

    double AggregateDoubleEmaRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v11;
        double v12;
        v12 = 0.0;
        v11 = 0;
        for (; v11 < ArrayItems.Length; v11++)
            v12 = ((v12 + ArrayItems[v11]) / 2);
        return v12;
    }

    double AggregateDoubleFactorialRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v13;
        double v14;
        v14 = 1.0;
        v13 = 0;
        for (; v13 < ArrayItems.Length; v13++)
            v14 = (v14 * ArrayItems[v13]);
        return v14;
    }

    double AggregateDoubleAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v15;
        double v16;
        v16 = 0.0;
        v15 = 0;
        for (; v15 < ArrayItems.Length; v15++)
            v16 = (v16 + ArrayItems[v15]);
        return (v16 / ArrayItems.Length);
    }

    double AggregateDoubleAverageSelectedRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v17;
        double v18;
        bool v19;
        v18 = 0.0;
        v19 = true;
        v17 = 0;
        for (; v17 < ArrayItems.Length; v17++)
            if (v19)
            {
                v18 = (ArrayItems[v17] + 5);
                v19 = false;
                continue;
            }
            else
                v18 = (v18 + (ArrayItems[v17] + 5));
        return (v18 / ArrayItems.Length);
    }

    double AggregateDoubleAverageWhereRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v20;
        double v21;
        bool v22;
        v21 = 0.0;
        v22 = true;
        v20 = 0;
        for (; v20 < ArrayItems.Length; v20++)
        {
            if (!(ArrayItems[v20] % 2 == 0))
                continue;
            if (v22)
            {
                v21 = ArrayItems[v20];
                v22 = false;
                continue;
            }
            else
                v21 = (v21 + ArrayItems[v20]);
        }

        return (v21 / ArrayItems.Length);
    }

    int AggregateRangeSumRewritten_ProceduralLinq1()
    {
        int v23;
        int v24;
        bool v25;
        v24 = default(int);
        v25 = true;
        v23 = 0;
        for (; v23 < 100; v23++)
            if (v25)
            {
                v24 = (v23 + 0);
                v25 = false;
                continue;
            }
            else
                v24 = (v24 + (v23 + 0));
        if (v25)
            throw new System.InvalidOperationException("The sequence did not contain valid elements.");
        return v24;
    }

    double AggregateRangeFactorial0Rewritten_ProceduralLinq1()
    {
        int v26;
        double v27;
        bool v28;
        v27 = 1.0;
        v28 = true;
        v26 = 0;
        for (; v26 < 100; v26++)
            if (v28)
            {
                v27 = (v26 + 0);
                v28 = false;
                continue;
            }
            else
                v27 = (v27 * (v26 + 0));
        return v27;
    }

    double AggregateRangeFactorial20Rewritten_ProceduralLinq1()
    {
        int v29;
        double v30;
        bool v31;
        v30 = 1.0;
        v31 = true;
        v29 = 0;
        for (; v29 < 20; v29++)
            if (v31)
            {
                v30 = (v29 + 1);
                v31 = false;
                continue;
            }
            else
                v30 = (v30 * (v29 + 1));
        return v30;
    }

    double AggregateRangeFactorial100Rewritten_ProceduralLinq1()
    {
        int v32;
        double v33;
        bool v34;
        v33 = 1.0;
        v34 = true;
        v32 = 0;
        for (; v32 < 100; v32++)
            if (v34)
            {
                v33 = (v32 + 1);
                v34 = false;
                continue;
            }
            else
                v33 = (v33 * (v32 + 1));
        return v33;
    }

    double AggregateEmptyDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v35;
        double v36;
        bool v37;
        v36 = 1.0;
        v37 = true;
        v35 = 0;
        for (; v35 < ArrayItems.Length; v35++)
        {
            if (!(false))
                continue;
            if (v37)
            {
                v36 = ArrayItems[v35];
                v37 = false;
                continue;
            }
            else
                v36 = (v36 + ArrayItems[v35]);
        }

        return v36;
    }

    int AggregateEmptyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v38;
        int v39;
        bool v40;
        v39 = default(int);
        v40 = true;
        v38 = 0;
        for (; v38 < ArrayItems.Length; v38++)
        {
            if (!(false))
                continue;
            if (v40)
            {
                v39 = ArrayItems[v38];
                v40 = false;
                continue;
            }
            else
                v39 = (v39 + ArrayItems[v38]);
        }

        if (v40)
            throw new System.InvalidOperationException("The sequence did not contain valid elements.");
        return v39;
    }
}}