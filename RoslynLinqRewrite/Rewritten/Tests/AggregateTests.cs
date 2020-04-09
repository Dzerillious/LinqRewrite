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
        for (; v1 < (ArrayItems.Length); v1++)
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
        for (; v8 < (ArrayItems.Length); v8++)
            v9 = (v9 + 1);
        return v9;
    }

    int AggregateEmaRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v11;
        int v12;
        v12 = ArrayItems[0];
        v11 = (1);
        for (; v11 < (ArrayItems.Length); v11++)
            v12 = ((v12 + (ArrayItems[v11])) / 2);
        return v12;
    }

    double AggregateDoubleSumRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v14;
        double v15;
        v15 = 0.0;
        v14 = (0);
        for (; v14 < (ArrayItems.Length); v14++)
            v15 = (v15 + (ArrayItems[v14]));
        return v15;
    }

    double AggregateDoubleEmaRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v17;
        double v18;
        v18 = 0.0;
        v17 = (0);
        for (; v17 < (ArrayItems.Length); v17++)
            v18 = ((v18 + (ArrayItems[v17])) / 2);
        return v18;
    }

    double AggregateDoubleFactorialRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v20;
        double v21;
        v21 = 1.0;
        v20 = (0);
        for (; v20 < (ArrayItems.Length); v20++)
            v21 = (v21 * (ArrayItems[v20]));
        return v21;
    }

    double AggregateDoubleAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v23;
        double v24;
        v24 = 0.0;
        v23 = (0);
        for (; v23 < (ArrayItems.Length); v23++)
            v24 = (v24 + (ArrayItems[v23]));
        return (v24 / ArrayItems.Length);
    }

    double AggregateDoubleAverageSelectedRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v26;
        double v27;
        v27 = 0.0;
        v26 = (0);
        for (; v26 < (ArrayItems.Length); v26++)
            v27 = (v27 + (5 + ArrayItems[v26]));
        return (v27 / ArrayItems.Length);
    }

    double AggregateDoubleAverageWhereRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v28;
        int v29;
        double v30;
        bool v31;
        v30 = 0.0;
        v31 = true;
        v28 = (0);
        for (; v28 < (ArrayItems.Length); v28++)
        {
            v29 = (ArrayItems[v28]);
            if (!(((v29) % 2 == 0)))
                continue;
            if (v31)
            {
                v30 = (v29);
                v31 = false;
                continue;
            }
            else
                v30 = (v30 + (v29));
        }

        return (v30 / ArrayItems.Length);
    }

    int AggregateRangeSumRewritten_ProceduralLinq1()
    {
        int v32;
        int v33;
        bool v34;
        v33 = default(int);
        v34 = true;
        v32 = (0);
        for (; v32 < (100); v32++)
            if (v34)
            {
                v33 = (v32);
                v34 = false;
                continue;
            }
            else
                v33 = (v33 + (v32));
        if (v34)
            throw new System.InvalidOperationException("The sequence did not contain enough elements.");
        return v33;
    }

    double AggregateRangeFactorial0Rewritten_ProceduralLinq1()
    {
        int v35;
        double v36;
        bool v37;
        v36 = 1.0;
        v37 = true;
        v35 = (0);
        for (; v35 < (100); v35++)
            if (v37)
            {
                v36 = (v35);
                v37 = false;
                continue;
            }
            else
                v36 = (v36 * (v35));
        return v36;
    }

    double AggregateRangeFactorial20Rewritten_ProceduralLinq1()
    {
        int v38;
        double v39;
        bool v40;
        v39 = 1.0;
        v40 = true;
        v38 = (0);
        for (; v38 < (20); v38++)
            if (v40)
            {
                v39 = (1 + v38);
                v40 = false;
                continue;
            }
            else
                v39 = (v39 * (1 + v38));
        return v39;
    }

    double AggregateRangeFactorial100Rewritten_ProceduralLinq1()
    {
        int v41;
        double v42;
        bool v43;
        v42 = 1.0;
        v43 = true;
        v41 = (0);
        for (; v41 < (100); v41++)
            if (v43)
            {
                v42 = (1 + v41);
                v43 = false;
                continue;
            }
            else
                v42 = (v42 * (1 + v41));
        return v42;
    }

    double AggregateEmptyDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v44;
        int v45;
        double v46;
        bool v47;
        v46 = 1.0;
        v47 = true;
        v44 = (0);
        for (; v44 < (ArrayItems.Length); v44++)
        {
            v45 = (ArrayItems[v44]);
            if (!((false)))
                continue;
            if (v47)
            {
                v46 = (v45);
                v47 = false;
                continue;
            }
            else
                v46 = (v46 + (v45));
        }

        return v46;
    }

    int AggregateEmptyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v48;
        int v49;
        int v50;
        int v51;
        bool v52;
        v50 = 0;
        v51 = default(int);
        v52 = true;
        v48 = (0);
        for (; v48 < (ArrayItems.Length); v48++)
        {
            v49 = (ArrayItems[v48]);
            if (!((false)))
                continue;
            if (v52)
            {
                v51 = (v49);
                v52 = false;
                continue;
            }
            else
                v51 = (v51 + (v49));
            v50++;
        }

        if (v52)
            throw new System.InvalidOperationException("The sequence did not contain enough elements.");
        return v51;
    }
}}