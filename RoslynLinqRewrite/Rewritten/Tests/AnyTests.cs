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
        ArrayAny().TestEquals(nameof(ArrayAny), ArrayAnyRewritten());
        ArraySelectAny().TestEquals(nameof(ArraySelectAny), ArraySelectAnyRewritten());
        ArrayWhereAny().TestEquals(nameof(ArrayWhereAny), ArrayWhereAnyRewritten());
        ArrayEmptyAny().TestEquals(nameof(ArrayEmptyAny), ArrayEmptyAnyRewritten());
        ArraySelectEmptyAny().TestEquals(nameof(ArraySelectEmptyAny), ArraySelectEmptyAnyRewritten());
        ArrayWhereEmptyAny().TestEquals(nameof(ArrayWhereEmptyAny), ArrayWhereEmptyAnyRewritten());
        ArrayAnyFalse().TestEquals(nameof(ArrayAnyFalse), ArrayAnyFalseRewritten());
        ArrayAnyPredicate().TestEquals(nameof(ArrayAnyPredicate), ArrayAnyPredicateRewritten());
        ArrayAnyParameter().TestEquals(nameof(ArrayAnyParameter), ArrayAnyParameterRewritten());
        ArrayAnyChangingParameter().TestEquals(nameof(ArrayAnyChangingParameter), ArrayAnyChangingParameterRewritten());
        EnumerableAnyChangingParameter().TestEquals(nameof(EnumerableAnyChangingParameter), EnumerableAnyChangingParameterRewritten());
        EnumerableAny().TestEquals(nameof(EnumerableAny), EnumerableAnyRewritten());
        RepeatAny().TestEquals(nameof(RepeatAny), RepeatAnyRewritten());
        RangeAny().TestEquals(nameof(RangeAny), RangeAnyRewritten());
        RepeatAnyTrue().TestEquals(nameof(RepeatAnyTrue), RepeatAnyTrueRewritten());
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
        int v35;
        v35 = 0;
        for (; v35 < ArrayItems.Length; v35++)
            if ((ArrayItems[v35] > 50))
                return true;
        return false;
    }

    bool ArraySelectAnyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v36;
        v36 = 0;
        for (; v36 < ArrayItems.Length; v36++)
            if (((ArrayItems[v36] + 10) > 50))
                return true;
        return false;
    }

    bool ArrayWhereAnyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v37;
        v37 = 0;
        for (; v37 < ArrayItems.Length; v37++)
        {
            if (!(ArrayItems[v37] > 40))
                continue;
            if ((ArrayItems[v37] > 50))
                return true;
        }

        return false;
    }

    bool ArrayWhereEmptyAnyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v40;
        v40 = 0;
        for (; v40 < ArrayItems.Length; v40++)
        {
            if (!(ArrayItems[v40] > 40))
                continue;
            return true;
        }

        return false;
    }

    bool ArrayAnyFalseRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v41;
        v41 = 0;
        for (; v41 < ArrayItems.Length; v41++)
            if ((ArrayItems[v41] > 105))
                return true;
        return false;
    }

    bool ArrayAnyPredicateRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v42;
        v42 = 0;
        for (; v42 < ArrayItems.Length; v42++)
            if (Predicate(ArrayItems[v42]))
                return true;
        return false;
    }

    bool ArrayAnyParameterRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v43;
        v43 = 0;
        for (; v43 < ArrayItems.Length; v43++)
            if ((ArrayItems[v43] > a))
                return true;
        return false;
    }

    bool ArrayAnyChangingParameterRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v44;
        v44 = 0;
        for (; v44 < ArrayItems.Length; v44++)
            if ((ArrayItems[v44] > a++))
                return true;
        return false;
    }

    bool EnumerableAnyChangingParameterRewritten_ProceduralLinq1(ref int a, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v45;
        v45 = EnumerableItems.GetEnumerator();
        try
        {
            while (v45.MoveNext())
                if ((v45.Current > a++))
                    return true;
        }
        finally
        {
            v45.Dispose();
        }

        return false;
    }

    bool EnumerableAnyRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v46;
        v46 = EnumerableItems.GetEnumerator();
        try
        {
            while (v46.MoveNext())
                if ((v46.Current > 50))
                    return true;
        }
        finally
        {
            v46.Dispose();
        }

        return false;
    }

    bool RangeAnyRewritten_ProceduralLinq1()
    {
        int v47;
        v47 = 0;
        for (; v47 < 100; v47++)
            if (((v47 + 0) > 50))
                return true;
        return false;
    }

    bool RepeatAnyRewritten_ProceduralLinq1()
    {
        int v48;
        v48 = 0;
        for (; v48 < 100; v48++)
            if ((0 > 50))
                return true;
        return false;
    }

    bool RepeatAnyTrueRewritten_ProceduralLinq1()
    {
        int v49;
        v49 = 0;
        for (; v49 < 100; v49++)
            if ((0 > -1))
                return true;
        return false;
    }
}}