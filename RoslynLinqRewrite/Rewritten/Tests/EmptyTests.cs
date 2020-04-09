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
        int v637;
        int[] v638;
        v637 = 0;
        v638 = new int[(0)];
        return v638;
    }

    System.Collections.Generic.List<int> EmptyToListRewritten_ProceduralLinq1()
    {
        int v639;
        System.Collections.Generic.List<int> v640;
        v639 = 0;
        v640 = new System.Collections.Generic.List<int>();
        return v640;
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> EmptyToSimpleListRewritten_ProceduralLinq1()
    {
        int v641;
        int[] v642;
        SimpleList<int> v643;
        v641 = 0;
        v642 = new int[(0)];
        v643 = new SimpleList<int>();
        v643.Items = v642;
        v643.Count = (0);
        return v643;
    }

    System.Collections.Generic.IEnumerable<int> EmptySelectRewritten_ProceduralLinq1()
    {
        int v644;
        v644 = 0;
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EmptyWhereRewritten_ProceduralLinq1()
    {
        int v645;
        int v646;
        v645 = 0;
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EmptyDistinctRewritten_ProceduralLinq1()
    {
        int v647;
        HashSet<int> v648;
        int v649;
        v647 = 0;
        v648 = new HashSet<int>();
        yield break;
    }

    int EmptyCountRewritten_ProceduralLinq1()
    {
        int v650;
        v650 = 0;
        return v650;
    }

    bool EmptyContainsRewritten_ProceduralLinq1()
    {
        int v651;
        v651 = 0;
        return false;
    }

    System.Collections.Generic.IEnumerable<float> EmptyCastRewritten_ProceduralLinq1()
    {
        int v652;
        v652 = 0;
        yield break;
    }

    bool EmptyAnyRewritten_ProceduralLinq1()
    {
        int v653;
        v653 = 0;
        return false;
    }

    double EmptyAggregateDefaultRewritten_ProceduralLinq1()
    {
        int v654;
        double v655;
        bool v656;
        v654 = 0;
        v655 = 1.0;
        v656 = true;
        return v655;
    }

    int EmptyAggregateRewritten_ProceduralLinq1()
    {
        int v657;
        throw new System.InvalidOperationException("Index out of range");
        v657 = 0;
    }

    double EmptyAverageRewritten_ProceduralLinq1()
    {
        int v658;
        double v659;
        throw new System.InvalidOperationException("Index out of range");
        v658 = 0;
        v659 = 0;
    }
}}