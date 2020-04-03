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
        return ArrayItems.Length >= 1;
    } //EndMethod

    [NoRewrite]
    public bool ArraySelectEmptyAny()
    {
        return ArrayItems.Select(x => x - 40).Any();
    } //EndMethod

    public bool ArraySelectEmptyAnyRewritten()
    {
        return ArrayItems.Length >= 1;
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
        int v43;
        v43 = 0;
        for (; v43 < ArrayItems.Length; v43++)
            if ((ArrayItems[v43] > 50))
                return true;
        return false;
    }

    bool ArraySelectAnyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v44;
        v44 = 0;
        for (; v44 < ArrayItems.Length; v44++)
            if (((ArrayItems[v44] + 10) > 50))
                return true;
        return false;
    }

    bool ArrayWhereAnyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v45;
        v45 = 0;
        for (; v45 < ArrayItems.Length; v45++)
        {
            if (!((ArrayItems[v45] > 40)))
                continue;
            if ((ArrayItems[v45] > 50))
                return true;
        }

        return false;
    }

    bool ArrayWhereEmptyAnyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v48;
        v48 = 0;
        for (; v48 < ArrayItems.Length; v48++)
        {
            if (!((ArrayItems[v48] > 40)))
                continue;
            return true;
        }

        return false;
    }

    bool ArrayAnyFalseRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v49;
        v49 = 0;
        for (; v49 < ArrayItems.Length; v49++)
            if ((ArrayItems[v49] > 105))
                return true;
        return false;
    }

    bool ArrayAnyPredicateRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v50;
        v50 = 0;
        for (; v50 < ArrayItems.Length; v50++)
            if (Predicate(ArrayItems[v50]))
                return true;
        return false;
    }

    bool ArrayAnyParameterRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v51;
        v51 = 0;
        for (; v51 < ArrayItems.Length; v51++)
            if ((ArrayItems[v51] > a))
                return true;
        return false;
    }

    bool ArrayAnyChangingParameterRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v52;
        v52 = 0;
        for (; v52 < ArrayItems.Length; v52++)
            if ((ArrayItems[v52] > a++))
                return true;
        return false;
    }

    bool EnumerableAnyChangingParameterRewritten_ProceduralLinq1(ref int a, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v53;
        v53 = EnumerableItems.GetEnumerator();
        try
        {
            while (v53.MoveNext())
                if ((v53.Current > a++))
                    return true;
        }
        finally
        {
            v53.Dispose();
        }

        return false;
    }

    bool EnumerableAnyRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v54;
        v54 = EnumerableItems.GetEnumerator();
        try
        {
            while (v54.MoveNext())
                if ((v54.Current > 50))
                    return true;
        }
        finally
        {
            v54.Dispose();
        }

        return false;
    }

    bool RangeAnyRewritten_ProceduralLinq1()
    {
        int v55;
        v55 = 0;
        for (; v55 < 100; v55++)
            if (((v55 + 0) > 50))
                return true;
        return false;
    }

    bool RepeatAnyRewritten_ProceduralLinq1()
    {
        int v56;
        v56 = 0;
        for (; v56 < 100; v56++)
            if ((0 > 50))
                return true;
        return false;
    }

    bool RepeatAnyTrueRewritten_ProceduralLinq1()
    {
        int v57;
        v57 = 0;
        for (; v57 < 100; v57++)
            if ((0 > -1))
                return true;
        return false;
    }
}}