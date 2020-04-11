using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class AnyTests
{
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
    public bool Predicate(int x) => x > 50;
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(ArrayAny), ArrayAny, ArrayAnyRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectAny), ArraySelectAny, ArraySelectAnyRewritten);
        TestsExtensions.TestEquals(nameof(ArrayWhereAny), ArrayWhereAny, ArrayWhereAnyRewritten);
        TestsExtensions.TestEquals(nameof(ArrayEmptyAny), ArrayEmptyAny, ArrayEmptyAnyRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectEmptyAny), ArraySelectEmptyAny, ArraySelectEmptyAnyRewritten);
        TestsExtensions.TestEquals(nameof(ArrayWhereEmptyAny), ArrayWhereEmptyAny, ArrayWhereEmptyAnyRewritten);
        TestsExtensions.TestEquals(nameof(ArrayAnyFalse), ArrayAnyFalse, ArrayAnyFalseRewritten);
        TestsExtensions.TestEquals(nameof(ArrayAnyPredicate), ArrayAnyPredicate, ArrayAnyPredicateRewritten);
        TestsExtensions.TestEquals(nameof(ArrayAnyParameter), ArrayAnyParameter, ArrayAnyParameterRewritten);
        TestsExtensions.TestEquals(nameof(ArrayAnyChangingParameter), ArrayAnyChangingParameter, ArrayAnyChangingParameterRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableAnyChangingParameter), EnumerableAnyChangingParameter, EnumerableAnyChangingParameterRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableAny), EnumerableAny, EnumerableAnyRewritten);
        TestsExtensions.TestEquals(nameof(RepeatAny), RepeatAny, RepeatAnyRewritten);
        TestsExtensions.TestEquals(nameof(RangeAny), RangeAny, RangeAnyRewritten);
        TestsExtensions.TestEquals(nameof(RepeatAnyTrue), RepeatAnyTrue, RepeatAnyTrueRewritten);
    }

    [NoRewrite]
    public bool ArrayAny()
    {
        return ArrayItems.Any(x => x > 50);
    } //EndMethod

    public bool ArrayAnyRewritten()
    {
        return ArrayAnyRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArraySelectAny()
    {
        return ArrayItems.Select(x => x + 10).Any(x => x > 50);
    } //EndMethod

    public bool ArraySelectAnyRewritten()
    {
        return ArraySelectAnyRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArrayWhereAny()
    {
        return ArrayItems.Where(x => x > 40).Any(x => x > 50);
    } //EndMethod

    public bool ArrayWhereAnyRewritten()
    {
        return ArrayWhereAnyRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArrayEmptyAny()
    {
        return ArrayItems.Any();
    } //EndMethod

    public bool ArrayEmptyAnyRewritten()
    {
        return (ArrayItems.Length) > 0;
    } //EndMethod

    [NoRewrite]
    public bool ArraySelectEmptyAny()
    {
        return ArrayItems.Select(x => x - 40).Any();
    } //EndMethod

    public bool ArraySelectEmptyAnyRewritten()
    {
        return (ArrayItems.Length) > 0;
    } //EndMethod

    [NoRewrite]
    public bool ArrayWhereEmptyAny()
    {
        return ArrayItems.Where(x => x > 40).Any();
    } //EndMethod

    public bool ArrayWhereEmptyAnyRewritten()
    {
        return ArrayWhereEmptyAnyRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArrayAnyFalse()
    {
        return ArrayItems.Any(x => x > 105);
    } //EndMethod

    public bool ArrayAnyFalseRewritten()
    {
        return ArrayAnyFalseRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArrayAnyPredicate()
    {
        return ArrayItems.Any(Predicate);
    } //EndMethod

    public bool ArrayAnyPredicateRewritten()
    {
        return ArrayAnyPredicateRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArrayAnyParameter()
    {
        var a = 5;
        return ArrayItems.Any(x => x > a);
    } //EndMethod

    public bool ArrayAnyParameterRewritten()
    {
        var a = 5;
        return ArrayAnyParameterRewritten_ProceduralLinq1(a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArrayAnyChangingParameter()
    {
        var a = 5;
        return ArrayItems.Any(x => x > a++);
    } //EndMethod

    public bool ArrayAnyChangingParameterRewritten()
    {
        var a = 5;
        return ArrayAnyChangingParameterRewritten_ProceduralLinq1(ref a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool EnumerableAnyChangingParameter()
    {
        var a = 5;
        return EnumerableItems.Any(x => x > a++);
    } //EndMethod

    public bool EnumerableAnyChangingParameterRewritten()
    {
        var a = 5;
        return EnumerableAnyChangingParameterRewritten_ProceduralLinq1(ref a, EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public bool EnumerableAny()
    {
        return EnumerableItems.Any(x => x > 50);
    } //EndMethod

    public bool EnumerableAnyRewritten()
    {
        return EnumerableAnyRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public bool RangeAny()
    {
        return Enumerable.Range(0, 100).Any(x => x > 50);
    } //EndMethod

    public bool RangeAnyRewritten()
    {
        return RangeAnyRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public bool RepeatAny()
    {
        return Enumerable.Repeat(0, 100).Any(x => x > 50);
    } //EndMethod

    public bool RepeatAnyRewritten()
    {
        return RepeatAnyRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public bool RepeatAnyTrue()
    {
        return Enumerable.Repeat(0, 100).Any(x => x > -1);
    } //EndMethod

    public bool RepeatAnyTrueRewritten()
    {
        return RepeatAnyTrueRewritten_ProceduralLinq1();
    } //EndMethod

    bool ArrayAnyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v54;
        v54 = (0);
        for (; v54 < (ArrayItems.Length); v54 += 1)
            if (((ArrayItems[v54]) > 50))
                return true;
        return false;
    }

    bool ArraySelectAnyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v56;
        v56 = (0);
        for (; v56 < (ArrayItems.Length); v56 += 1)
            if (((10 + ArrayItems[v56]) > 50))
                return true;
        return false;
    }

    bool ArrayWhereAnyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v57;
        v57 = (0);
        for (; v57 < (ArrayItems.Length); v57 += 1)
        {
            if (!((((ArrayItems[v57])) > 40)))
                continue;
            if ((((ArrayItems[v57])) > 50))
                return true;
        }

        return false;
    }

    bool ArrayWhereEmptyAnyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v60;
        v60 = (0);
        for (; v60 < (ArrayItems.Length); v60 += 1)
        {
            if (!((((ArrayItems[v60])) > 40)))
                continue;
            return true;
        }

        return false;
    }

    bool ArrayAnyFalseRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v62;
        v62 = (0);
        for (; v62 < (ArrayItems.Length); v62 += 1)
            if (((ArrayItems[v62]) > 105))
                return true;
        return false;
    }

    bool ArrayAnyPredicateRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v64;
        v64 = (0);
        for (; v64 < (ArrayItems.Length); v64 += 1)
            if (Predicate((ArrayItems[v64])))
                return true;
        return false;
    }

    bool ArrayAnyParameterRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v66;
        v66 = (0);
        for (; v66 < (ArrayItems.Length); v66 += 1)
            if (((ArrayItems[v66]) > a))
                return true;
        return false;
    }

    bool ArrayAnyChangingParameterRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v67;
        v67 = (0);
        for (; v67 < (ArrayItems.Length); v67 += 1)
            if (((ArrayItems[v67]) > a++))
                return true;
        return false;
    }

    bool EnumerableAnyChangingParameterRewritten_ProceduralLinq1(ref int a, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v68;
        v68 = EnumerableItems.GetEnumerator();
        try
        {
            while (v68.MoveNext())
                if (((v68.Current) > a++))
                    return true;
        }
        finally
        {
            v68.Dispose();
        }

        return false;
    }

    bool EnumerableAnyRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v69;
        v69 = EnumerableItems.GetEnumerator();
        try
        {
            while (v69.MoveNext())
                if (((v69.Current) > 50))
                    return true;
        }
        finally
        {
            v69.Dispose();
        }

        return false;
    }

    bool RangeAnyRewritten_ProceduralLinq1()
    {
        int v70;
        v70 = (0);
        for (; v70 < (100); v70 += (1))
            if (((v70) > 50))
                return true;
        return false;
    }

    bool RepeatAnyRewritten_ProceduralLinq1()
    {
        int v71;
        v71 = (0);
        for (; v71 < (100); v71 += 1)
            if (((0) > 50))
                return true;
        return false;
    }

    bool RepeatAnyTrueRewritten_ProceduralLinq1()
    {
        int v72;
        v72 = (0);
        for (; v72 < (100); v72 += 1)
            if (((0) > -1))
                return true;
        return false;
    }
}}