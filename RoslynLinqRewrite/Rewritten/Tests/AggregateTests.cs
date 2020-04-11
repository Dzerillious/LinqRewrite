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
        TestsExtensions.TestEquals(nameof(AggregateNull), AggregateNull, AggregateNullRewritten);
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

    [NoRewrite]
    public double AggregateNull()
    {
        return ArrayItems.Aggregate(null);
    } //EndMethod

    public double AggregateNullRewritten()
    {
        return ArrayItems.Aggregate(null);
    } //EndMethod

    int AggregateSumRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1;
        int v2;
        v2 = ArrayItems[0];
        v1 = (1);
        for (; v1 < (ArrayItems.Length); v1 += 1)
            v2 = (v2 + (ArrayItems[v1]));
        return v2;
    }

    int EnumerableAggregateSumRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v3;
        int v4;
        int v5;
        bool v6;
        v3 = EnumerableItems.GetEnumerator();
        v4 = 0;
        v5 = default(int);
        v6 = true;
        try
        {
            while (v3.MoveNext())
            {
                if (v6)
                {
                    v5 = (v3.Current);
                    v6 = false;
                    continue;
                }
                else
                    v5 = (v5 + (v3.Current));
                v4++;
            }
        }
        finally
        {
            v3.Dispose();
        }

        if (v6)
            throw new System.InvalidOperationException("The sequence did not contain enough elements.");
        return v5;
    }

    int AggregateCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v8;
        int v9;
        v9 = ArrayItems[0];
        v8 = (1);
        for (; v8 < (ArrayItems.Length); v8 += 1)
            v9 = (v9 + 1);
        return v9;
    }

    int AggregateEmaRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v11;
        int v12;
        v12 = ArrayItems[0];
        v11 = (1);
        for (; v11 < (ArrayItems.Length); v11 += 1)
            v12 = ((v12 + (ArrayItems[v11])) / 2);
        return v12;
    }

    double AggregateDoubleSumRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v14;
        double v15;
        v15 = 0.0;
        v14 = (0);
        for (; v14 < (ArrayItems.Length); v14 += 1)
            v15 = (v15 + (ArrayItems[v14]));
        return v15;
    }

    double AggregateDoubleEmaRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v17;
        double v18;
        v18 = 0.0;
        v17 = (0);
        for (; v17 < (ArrayItems.Length); v17 += 1)
            v18 = ((v18 + (ArrayItems[v17])) / 2);
        return v18;
    }

    double AggregateDoubleFactorialRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v20;
        double v21;
        v21 = 1.0;
        v20 = (0);
        for (; v20 < (ArrayItems.Length); v20 += 1)
            v21 = (v21 * (ArrayItems[v20]));
        return v21;
    }

    double AggregateDoubleAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v23;
        double v24;
        v24 = 0.0;
        v23 = (0);
        for (; v23 < (ArrayItems.Length); v23 += 1)
            v24 = (v24 + (ArrayItems[v23]));
        return (v24 / ArrayItems.Length);
    }

    double AggregateDoubleAverageSelectedRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v26;
        double v27;
        v27 = 0.0;
        v26 = (0);
        for (; v26 < (ArrayItems.Length); v26 += 1)
            v27 = (v27 + (5 + ArrayItems[v26]));
        return (v27 / ArrayItems.Length);
    }

    double AggregateDoubleAverageWhereRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v28;
        double v29;
        bool v30;
        v29 = 0.0;
        v30 = true;
        v28 = (0);
        for (; v28 < (ArrayItems.Length); v28 += 1)
        {
            if (!((((ArrayItems[v28])) % 2 == 0)))
                continue;
            if (v30)
            {
                v29 = ((ArrayItems[v28]));
                v30 = false;
                continue;
            }
            else
                v29 = (v29 + ((ArrayItems[v28])));
        }

        return (v29 / ArrayItems.Length);
    }

    int AggregateRangeSumRewritten_ProceduralLinq1()
    {
        int v31;
        int v32;
        bool v33;
        v32 = default(int);
        v33 = true;
        v31 = (0);
        for (; v31 < (100); v31 += (1))
            if (v33)
            {
                v32 = (v31);
                v33 = false;
                continue;
            }
            else
                v32 = (v32 + (v31));
        if (v33)
            throw new System.InvalidOperationException("The sequence did not contain enough elements.");
        return v32;
    }

    double AggregateRangeFactorial0Rewritten_ProceduralLinq1()
    {
        int v34;
        double v35;
        bool v36;
        v35 = 1.0;
        v36 = true;
        v34 = (0);
        for (; v34 < (100); v34 += (1))
            if (v36)
            {
                v35 = (v34);
                v36 = false;
                continue;
            }
            else
                v35 = (v35 * (v34));
        return v35;
    }

    double AggregateRangeFactorial20Rewritten_ProceduralLinq1()
    {
        int v37;
        double v38;
        bool v39;
        v38 = 1.0;
        v39 = true;
        v37 = (0);
        for (; v37 < (20); v37 += (1))
            if (v39)
            {
                v38 = (1 + v37);
                v39 = false;
                continue;
            }
            else
                v38 = (v38 * (1 + v37));
        return v38;
    }

    double AggregateRangeFactorial100Rewritten_ProceduralLinq1()
    {
        int v40;
        double v41;
        bool v42;
        v41 = 1.0;
        v42 = true;
        v40 = (0);
        for (; v40 < (100); v40 += (1))
            if (v42)
            {
                v41 = (1 + v40);
                v42 = false;
                continue;
            }
            else
                v41 = (v41 * (1 + v40));
        return v41;
    }

    double AggregateEmptyDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v43;
        double v44;
        bool v45;
        v44 = 1.0;
        v45 = true;
        v43 = (0);
        for (; v43 < (ArrayItems.Length); v43 += 1)
        {
            if (!((false)))
                continue;
            if (v45)
            {
                v44 = ((ArrayItems[v43]));
                v45 = false;
                continue;
            }
            else
                v44 = (v44 + ((ArrayItems[v43])));
        }

        return v44;
    }

    int AggregateEmptyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v46;
        int v47;
        int v48;
        bool v49;
        v47 = 0;
        v48 = default(int);
        v49 = true;
        v46 = (0);
        for (; v46 < (ArrayItems.Length); v46 += 1)
        {
            if (!((false)))
                continue;
            if (v49)
            {
                v48 = ((ArrayItems[v46]));
                v49 = false;
                continue;
            }
            else
                v48 = (v48 + ((ArrayItems[v46])));
            v47++;
        }

        if (v49)
            throw new System.InvalidOperationException("The sequence did not contain enough elements.");
        return v48;
    }
}}