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
        return EmptyCountRewritten_ProceduralLinq1();
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
        return EmptyAnyRewritten_ProceduralLinq1();
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
        int v582;
        int[] v583;
        v582 = 0;
        v583 = new int[(0)];
        return v583;
    }

    System.Collections.Generic.List<int> EmptyToListRewritten_ProceduralLinq1()
    {
        int v584;
        System.Collections.Generic.List<int> v585;
        v584 = 0;
        v585 = new System.Collections.Generic.List<int>();
        return v585;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> EmptyToSimpleListRewritten_ProceduralLinq1()
    {
        int v586;
        int[] v587;
        SimpleList<int> v588;
        v586 = 0;
        v587 = new int[(0)];
        v588 = new SimpleList<int>();
        v588.Items = v587;
        v588.Count = (0);
        return v588;
    }

    System.Collections.Generic.IEnumerable<int> EmptySelectRewritten_ProceduralLinq1()
    {
        int v589;
        v589 = 0;
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EmptyWhereRewritten_ProceduralLinq1()
    {
        int v590;
        v590 = 0;
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EmptyDistinctRewritten_ProceduralLinq1()
    {
        int v591;
        HashSet<int> v592;
        v591 = 0;
        v592 = new HashSet<int>();
        yield break;
    }

    int EmptyCountRewritten_ProceduralLinq1()
    {
        int v593;
        v593 = 0;
        return v593;
    }

    bool EmptyContainsRewritten_ProceduralLinq1()
    {
        int v594;
        v594 = 0;
        return false;
    }

    System.Collections.Generic.IEnumerable<float> EmptyCastRewritten_ProceduralLinq1()
    {
        int v595;
        v595 = 0;
        yield break;
    }

    bool EmptyAnyRewritten_ProceduralLinq1()
    {
        int v596;
        v596 = 0;
        return false;
    }

    double EmptyAggregateDefaultRewritten_ProceduralLinq1()
    {
        int v597;
        double v598;
        bool v599;
        v597 = 0;
        v598 = 1.0;
        v599 = true;
        return v598;
    }

    int EmptyAggregateRewritten_ProceduralLinq1()
    {
        int v600;
        int v601;
        bool v602;
        v600 = 0;
        v601 = default(int);
        v602 = true;
        if (v602)
            throw new System.InvalidOperationException("The sequence did not contain enough elements.");
        return v601;
    }

    double EmptyAverageRewritten_ProceduralLinq1()
    {
        int v603;
        double v604;
        if (1 > (0))
            throw new System.InvalidOperationException("Index out of range");
        v603 = 0;
        v604 = 0;
        return (v604 / (0));
    }
}}