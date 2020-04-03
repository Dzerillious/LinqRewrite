using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;

namespace TestsLibrary.Tests
{
public class EmptyTests
{
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(Empty), Empty, EmptyRewritten);
        TestsExtensions.TestEquals(nameof(EmptyToArray), EmptyToArray, EmptyToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EmptyToList), EmptyToList, EmptyToListRewritten);
        TestsExtensions.TestEquals(nameof(EmptyToSimpleList), EmptyToSimpleList, EmptyToSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(EmptySelect), EmptySelect, EmptySelectRewritten);
        TestsExtensions.TestEquals(nameof(EmptyWhere), EmptyWhere, EmptyWhereRewritten);
        TestsExtensions.TestEquals(nameof(EmptyDistinct), EmptyDistinct, EmptyDistinctRewritten);
        TestsExtensions.TestEquals(nameof(EmptyCount), EmptyCount, EmptyCountRewritten);
        TestsExtensions.TestEquals(nameof(EmptyContains), EmptyContains, EmptyContainsRewritten);
        TestsExtensions.TestEquals(nameof(EmptyCast), EmptyCast, EmptyCastRewritten);
        TestsExtensions.TestEquals(nameof(EmptyAny), EmptyAny, EmptyAnyRewritten);
        TestsExtensions.TestEquals(nameof(EmptyAggregateDefault), EmptyAggregateDefault, EmptyAggregateDefaultRewritten);
        TestsExtensions.TestEquals(nameof(EmptyAggregate), EmptyAggregate, EmptyAggregateRewritten);
        TestsExtensions.TestEquals(nameof(EmptyAverage), EmptyAverage, EmptyAverageRewritten);
    }

    [NoRewrite]
    public IEnumerable<int> Empty()
    {
        return Enumerable.Empty<int>();
    } //EndMethod

    public IEnumerable<int> EmptyRewritten()
    {
        return Enumerable.Empty<int>();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EmptyToArray()
    {
        return Enumerable.Empty<int>().ToArray();
    } //EndMethod

    public IEnumerable<int> EmptyToArrayRewritten()
    {
        return EmptyToArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EmptyToList()
    {
        return Enumerable.Empty<int>().ToList();
    } //EndMethod

    public IEnumerable<int> EmptyToListRewritten()
    {
        return EmptyToListRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EmptyToSimpleList()
    {
        return Enumerable.Empty<int>().ToSimpleList();
    } //EndMethod

    public IEnumerable<int> EmptyToSimpleListRewritten()
    {
        return EmptyToSimpleListRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EmptySelect()
    {
        return Enumerable.Empty<int>().Select(x => x + 3);
    } //EndMethod

    public IEnumerable<int> EmptySelectRewritten()
    {
        return EmptySelectRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EmptyWhere()
    {
        return Enumerable.Empty<int>().Where(x => x > 3);
    } //EndMethod

    public IEnumerable<int> EmptyWhereRewritten()
    {
        return EmptyWhereRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EmptyDistinct()
    {
        return Enumerable.Empty<int>().Distinct();
    } //EndMethod

    public IEnumerable<int> EmptyDistinctRewritten()
    {
        return EmptyDistinctRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public int EmptyCount()
    {
        return Enumerable.Empty<int>().Count();
    } //EndMethod

    public int EmptyCountRewritten()
    {
        return 0;
    } //EndMethod

    [NoRewrite]
    public bool EmptyContains()
    {
        return Enumerable.Empty<int>().Contains(23);
    } //EndMethod

    public bool EmptyContainsRewritten()
    {
        return EmptyContainsRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<float> EmptyCast()
    {
        return Enumerable.Empty<int>().Cast<float>();
    } //EndMethod

    public IEnumerable<float> EmptyCastRewritten()
    {
        return EmptyCastRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public bool EmptyAny()
    {
        return Enumerable.Empty<int>().Any();
    } //EndMethod

    public bool EmptyAnyRewritten()
    {
        return 0 >= 1;
    } //EndMethod

    [NoRewrite]
    public double EmptyAggregateDefault()
    {
        return Enumerable.Empty<int>().Aggregate(1.0, (x, y) => x + y);
    } //EndMethod

    public double EmptyAggregateDefaultRewritten()
    {
        return EmptyAggregateDefaultRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public double EmptyAggregate()
    {
        return Enumerable.Empty<int>().Aggregate((x, y) => x + y);
    } //EndMethod

    public double EmptyAggregateRewritten()
    {
        return EmptyAggregateRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public double EmptyAverage()
    {
        return Enumerable.Empty<int>().Average();
    } //EndMethod

    public double EmptyAverageRewritten()
    {
        return EmptyAverageRewritten_ProceduralLinq1();
    } //EndMethod

    int[] EmptyToArrayRewritten_ProceduralLinq1()
    {
        int v533;
        int[] v534;
        v534 = new int[0];
        v533 = 0;
        for (; v533 < 0; v533++)
            v534[v533] = default(int);
        return v534;
    }

    System.Collections.Generic.List<int> EmptyToListRewritten_ProceduralLinq1()
    {
        int v535;
        System.Collections.Generic.List<int> v536;
        v536 = new System.Collections.Generic.List<int>();
        v535 = 0;
        for (; v535 < 0; v535++)
            v536.Add(default(int));
        return v536;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> EmptyToSimpleListRewritten_ProceduralLinq1()
    {
        int v537;
        int[] v538;
        SimpleList<int> v539;
        v538 = new int[0];
        v537 = 0;
        for (; v537 < 0; v537++)
            v538[v537] = default(int);
        v539 = new SimpleList<int>();
        v539.Items = v538;
        v539.Count = 0;
        return v539;
    }

    System.Collections.Generic.IEnumerable<int> EmptySelectRewritten_ProceduralLinq1()
    {
        int v540;
        v540 = 0;
        for (; v540 < 0; v540++)
            yield return (default(int) + 3);
    }

    System.Collections.Generic.IEnumerable<int> EmptyWhereRewritten_ProceduralLinq1()
    {
        int v541;
        v541 = 0;
        for (; v541 < 0; v541++)
        {
            if (!((default(int) > 3)))
                continue;
            yield return default(int);
        }
    }

    System.Collections.Generic.IEnumerable<int> EmptyDistinctRewritten_ProceduralLinq1()
    {
        int v542;
        HashSet<int> v543;
        v543 = new HashSet<int>();
        v542 = 0;
        for (; v542 < 0; v542++)
        {
            if (!(v543.Add(default(int))))
                continue;
            yield return default(int);
        }
    }

    bool EmptyContainsRewritten_ProceduralLinq1()
    {
        int v545;
        v545 = 0;
        for (; v545 < 0; v545++)
            if (default(int) == 23)
                return true;
        return false;
    }

    System.Collections.Generic.IEnumerable<float> EmptyCastRewritten_ProceduralLinq1()
    {
        int v546;
        v546 = 0;
        for (; v546 < 0; v546++)
            yield return (float)(object)default(int);
    }

    double EmptyAggregateDefaultRewritten_ProceduralLinq1()
    {
        int v548;
        double v549;
        bool v550;
        v549 = 1.0;
        v550 = true;
        v548 = 0;
        for (; v548 < 0; v548++)
            if (v550)
            {
                v549 = default(int);
                v550 = false;
                continue;
            }
            else
                v549 = (v549 + default(int));
        return v549;
    }

    int EmptyAggregateRewritten_ProceduralLinq1()
    {
        int v551;
        int v552;
        bool v553;
        v552 = default(int);
        v553 = true;
        v551 = 0;
        for (; v551 < 0; v551++)
            if (v553)
            {
                v552 = default(int);
                v553 = false;
                continue;
            }
            else
                v552 = (v552 + default(int));
        if (v553)
            throw new System.InvalidOperationException("The sequence did not contain valid elements.");
        return v552;
    }

    double EmptyAverageRewritten_ProceduralLinq1()
    {
        int v554;
        double v555;
        v555 = 0;
        v554 = 0;
        for (; v554 < 0; v554++)
            v555 += default(int);
        if (0 == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v555 / 0);
    }
}}