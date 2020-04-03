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
        int v519;
        int[] v520;
        v520 = new int[0];
        v519 = 0;
        for (; v519 < 0; v519++)
            v520[v519] = default(int);
        return v520;
    }

    System.Collections.Generic.List<int> EmptyToListRewritten_ProceduralLinq1()
    {
        int v521;
        System.Collections.Generic.List<int> v522;
        v522 = new System.Collections.Generic.List<int>();
        v521 = 0;
        for (; v521 < 0; v521++)
            v522.Add(default(int));
        return v522;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> EmptyToSimpleListRewritten_ProceduralLinq1()
    {
        int v523;
        int[] v524;
        SimpleList<int> v525;
        v524 = new int[0];
        v523 = 0;
        for (; v523 < 0; v523++)
            v524[v523] = default(int);
        v525 = new SimpleList<int>();
        v525.Items = v524;
        v525.Count = 0;
        return v525;
    }

    System.Collections.Generic.IEnumerable<int> EmptySelectRewritten_ProceduralLinq1()
    {
        int v526;
        v526 = 0;
        for (; v526 < 0; v526++)
            yield return (default(int) + 3);
    }

    System.Collections.Generic.IEnumerable<int> EmptyWhereRewritten_ProceduralLinq1()
    {
        int v527;
        v527 = 0;
        for (; v527 < 0; v527++)
        {
            if (!((default(int) > 3)))
                continue;
            yield return default(int);
        }
    }

    System.Collections.Generic.IEnumerable<int> EmptyDistinctRewritten_ProceduralLinq1()
    {
        int v528;
        HashSet<int> v529;
        v529 = new HashSet<int>();
        v528 = 0;
        for (; v528 < 0; v528++)
        {
            if (!(v529.Add(default(int))))
                continue;
            yield return default(int);
        }
    }

    bool EmptyContainsRewritten_ProceduralLinq1()
    {
        int v531;
        v531 = 0;
        for (; v531 < 0; v531++)
            if (default(int) == 23)
                return true;
        return false;
    }

    System.Collections.Generic.IEnumerable<float> EmptyCastRewritten_ProceduralLinq1()
    {
        int v532;
        v532 = 0;
        for (; v532 < 0; v532++)
            yield return (float)(object)default(int);
    }

    double EmptyAggregateDefaultRewritten_ProceduralLinq1()
    {
        int v534;
        double v535;
        bool v536;
        v535 = 1.0;
        v536 = true;
        v534 = 0;
        for (; v534 < 0; v534++)
            if (v536)
            {
                v535 = default(int);
                v536 = false;
                continue;
            }
            else
                v535 = (v535 + default(int));
        return v535;
    }

    int EmptyAggregateRewritten_ProceduralLinq1()
    {
        int v537;
        int v538;
        bool v539;
        v538 = default(int);
        v539 = true;
        v537 = 0;
        for (; v537 < 0; v537++)
            if (v539)
            {
                v538 = default(int);
                v539 = false;
                continue;
            }
            else
                v538 = (v538 + default(int));
        if (v539)
            throw new System.InvalidOperationException("The sequence did not contain valid elements.");
        return v538;
    }

    double EmptyAverageRewritten_ProceduralLinq1()
    {
        int v540;
        double v541;
        v541 = 0;
        v540 = 0;
        for (; v540 < 0; v540++)
            v541 += default(int);
        if (0 == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v541 / 0);
    }
}}