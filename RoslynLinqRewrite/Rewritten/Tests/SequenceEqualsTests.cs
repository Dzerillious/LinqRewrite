using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class SequenceEqualTests
{
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private int[] ArrayItems2 = Enumerable.Range(30, 130).ToArray();
    [Datapoints]
    private SimpleList<int> SimpleListItems = Enumerable.Range(10, 110).ToSimpleList();
    [Datapoints]
    private SimpleList<int> SimpleListItems2 = Enumerable.Range(40, 140).ToSimpleList();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(20, 120);
    [Datapoints]
    private IEnumerable<int> EnumerableItems2 = Enumerable.Range(50, 150);
    private IEnumerable<int> MethodEnumerable()
    {
        for (int i = 25; i < 125; i++)
        {
            yield return i;
        }
    }

    private IEnumerable<int> MethodEnumerable2()
    {
        for (int i = 55; i < 155; i++)
        {
            yield return i;
        }
    }

    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(ArraySequenceEqualArray), ArraySequenceEqualArray, ArraySequenceEqualArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArraySequenceEqualSimpleList), ArraySequenceEqualSimpleList, ArraySequenceEqualSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(ArraySequenceEqualEnumerable), ArraySequenceEqualEnumerable, ArraySequenceEqualEnumerableRewritten);
        TestsExtensions.TestEquals(nameof(ArraySequenceEqualMethod), ArraySequenceEqualMethod, ArraySequenceEqualMethodRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListSequenceEqualArray), SimpleListSequenceEqualArray, SimpleListSequenceEqualArrayRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListSequenceEqualSimpleList), SimpleListSequenceEqualSimpleList, SimpleListSequenceEqualSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListSequenceEqualEnumerable), SimpleListSequenceEqualEnumerable, SimpleListSequenceEqualEnumerableRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListSequenceEqualMethod), SimpleListSequenceEqualMethod, SimpleListSequenceEqualMethodRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSequenceEqualArray), EnumerableSequenceEqualArray, EnumerableSequenceEqualArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSequenceEqualSimpleList), EnumerableSequenceEqualSimpleList, EnumerableSequenceEqualSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSequenceEqualEnumerable), EnumerableSequenceEqualEnumerable, EnumerableSequenceEqualEnumerableRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSequenceEqualMethod), EnumerableSequenceEqualMethod, EnumerableSequenceEqualMethodRewritten);
        TestsExtensions.TestEquals(nameof(MethodSequenceEqualArray), MethodSequenceEqualArray, MethodSequenceEqualArrayRewritten);
        TestsExtensions.TestEquals(nameof(MethodSequenceEqualSimpleList), MethodSequenceEqualSimpleList, MethodSequenceEqualSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(MethodSequenceEqualEnumerable), MethodSequenceEqualEnumerable, MethodSequenceEqualEnumerableRewritten);
        TestsExtensions.TestEquals(nameof(MethodSequenceEqualMethod), MethodSequenceEqualMethod, MethodSequenceEqualMethodRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectSequenceEqualArray), ArraySelectSequenceEqualArray, ArraySelectSequenceEqualArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectSequenceEqualArraySelect), ArraySelectSequenceEqualArraySelect, ArraySelectSequenceEqualArraySelectRewritten);
        TestsExtensions.TestEquals(nameof(ArrayWhereSequenceEqualArrayWhere), ArrayWhereSequenceEqualArrayWhere, ArrayWhereSequenceEqualArrayWhereRewritten);
        TestsExtensions.TestEquals(nameof(SelectWhereArraySequenceEqualSelectWhereArray), SelectWhereArraySequenceEqualSelectWhereArray, SelectWhereArraySequenceEqualSelectWhereArrayRewritten);
        TestsExtensions.TestEquals(nameof(RangeSequenceEqualArray), RangeSequenceEqualArray, RangeSequenceEqualArrayRewritten);
        TestsExtensions.TestEquals(nameof(RepeatSequenceEqualArray), RepeatSequenceEqualArray, RepeatSequenceEqualArrayRewritten);
        TestsExtensions.TestEquals(nameof(EmptySequenceEqualArray), EmptySequenceEqualArray, EmptySequenceEqualArrayRewritten);
        TestsExtensions.TestEquals(nameof(RangeEmpty2Array), RangeEmpty2Array, RangeEmpty2ArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArraySequenceEqualRange), ArraySequenceEqualRange, ArraySequenceEqualRangeRewritten);
        TestsExtensions.TestEquals(nameof(ArraySequenceEqualRepeat), ArraySequenceEqualRepeat, ArraySequenceEqualRepeatRewritten);
        TestsExtensions.TestEquals(nameof(ArraySequenceEqualEmpty), ArraySequenceEqualEmpty, ArraySequenceEqualEmptyRewritten);
        TestsExtensions.TestEquals(nameof(ArraySequenceEqualEmpty2), ArraySequenceEqualEmpty2, ArraySequenceEqualEmpty2Rewritten);
        TestsExtensions.TestEquals(nameof(ArraySequenceEqualAll), ArraySequenceEqualAll, ArraySequenceEqualAllRewritten);
        TestsExtensions.TestEquals(nameof(ArraySequenceEqualNull), ArraySequenceEqualNull, ArraySequenceEqualNullRewritten);
        TestsExtensions.TestEquals(nameof(ArrayDistinctSequenceEqualArrayDistinct), ArrayDistinctSequenceEqualArrayDistinct, ArrayDistinctSequenceEqualArrayDistinctRewritten);
        TestsExtensions.TestEquals(nameof(ArrayDistinctSequenceEqualArrayDistinct2), ArrayDistinctSequenceEqualArrayDistinct, ArrayDistinctSequenceEqualArrayDistinct2Rewritten);
    }

    [NoRewrite]
    public bool ArraySequenceEqualArray()
    {
        return ArrayItems.SequenceEqual(ArrayItems2);
    } //EndMethod

    public bool ArraySequenceEqualArrayRewritten()
    {
        return ArraySequenceEqualArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArraySequenceEqualSimpleList()
    {
        return ArrayItems.SequenceEqual(SimpleListItems2);
    } //EndMethod

    public bool ArraySequenceEqualSimpleListRewritten()
    {
        return ArraySequenceEqualSimpleListRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArraySequenceEqualEnumerable()
    {
        return ArrayItems.SequenceEqual(EnumerableItems2);
    } //EndMethod

    public bool ArraySequenceEqualEnumerableRewritten()
    {
        return ArraySequenceEqualEnumerableRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArraySequenceEqualMethod()
    {
        return ArrayItems.SequenceEqual(MethodEnumerable2());
    } //EndMethod

    public bool ArraySequenceEqualMethodRewritten()
    {
        return ArraySequenceEqualMethodRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool SimpleListSequenceEqualArray()
    {
        return SimpleListItems.SequenceEqual(ArrayItems2);
    } //EndMethod

    public bool SimpleListSequenceEqualArrayRewritten()
    {
        return SimpleListSequenceEqualArrayRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public bool SimpleListSequenceEqualSimpleList()
    {
        return SimpleListItems.SequenceEqual(SimpleListItems2);
    } //EndMethod

    public bool SimpleListSequenceEqualSimpleListRewritten()
    {
        return SimpleListSequenceEqualSimpleListRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public bool SimpleListSequenceEqualEnumerable()
    {
        return SimpleListItems.SequenceEqual(EnumerableItems2);
    } //EndMethod

    public bool SimpleListSequenceEqualEnumerableRewritten()
    {
        return SimpleListSequenceEqualEnumerableRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public bool SimpleListSequenceEqualMethod()
    {
        return SimpleListItems.SequenceEqual(MethodEnumerable2());
    } //EndMethod

    public bool SimpleListSequenceEqualMethodRewritten()
    {
        return SimpleListSequenceEqualMethodRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public bool EnumerableSequenceEqualArray()
    {
        return EnumerableItems.SequenceEqual(ArrayItems2);
    } //EndMethod

    public bool EnumerableSequenceEqualArrayRewritten()
    {
        return EnumerableSequenceEqualArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public bool EnumerableSequenceEqualSimpleList()
    {
        return EnumerableItems.SequenceEqual(SimpleListItems2);
    } //EndMethod

    public bool EnumerableSequenceEqualSimpleListRewritten()
    {
        return EnumerableSequenceEqualSimpleListRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public bool EnumerableSequenceEqualEnumerable()
    {
        return EnumerableItems.SequenceEqual(EnumerableItems2);
    } //EndMethod

    public bool EnumerableSequenceEqualEnumerableRewritten()
    {
        return EnumerableSequenceEqualEnumerableRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public bool EnumerableSequenceEqualMethod()
    {
        return EnumerableItems.SequenceEqual(MethodEnumerable2());
    } //EndMethod

    public bool EnumerableSequenceEqualMethodRewritten()
    {
        return EnumerableSequenceEqualMethodRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public bool MethodSequenceEqualArray()
    {
        return MethodEnumerable().SequenceEqual(ArrayItems2);
    } //EndMethod

    public bool MethodSequenceEqualArrayRewritten()
    {
        return MethodEnumerable().SequenceEqual(ArrayItems2);
    } //EndMethod

    [NoRewrite]
    public bool MethodSequenceEqualSimpleList()
    {
        return MethodEnumerable().SequenceEqual(SimpleListItems2);
    } //EndMethod

    public bool MethodSequenceEqualSimpleListRewritten()
    {
        return MethodEnumerable().SequenceEqual(SimpleListItems2);
    } //EndMethod

    [NoRewrite]
    public bool MethodSequenceEqualEnumerable()
    {
        return MethodEnumerable().SequenceEqual(EnumerableItems2);
    } //EndMethod

    public bool MethodSequenceEqualEnumerableRewritten()
    {
        return MethodEnumerable().SequenceEqual(EnumerableItems2);
    } //EndMethod

    [NoRewrite]
    public bool MethodSequenceEqualMethod()
    {
        return MethodEnumerable().SequenceEqual(MethodEnumerable2());
    } //EndMethod

    public bool MethodSequenceEqualMethodRewritten()
    {
        return MethodEnumerable().SequenceEqual(MethodEnumerable2());
    } //EndMethod

    [NoRewrite]
    public bool ArraySelectSequenceEqualArray()
    {
        return ArrayItems.Select(x => x + 50).SequenceEqual(ArrayItems2);
    } //EndMethod

    public bool ArraySelectSequenceEqualArrayRewritten()
    {
        return ArraySelectSequenceEqualArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArraySelectSequenceEqualArraySelect()
    {
        return ArrayItems.Select(x => x + 50).SequenceEqual(ArrayItems2.Select(x => x + 50));
    } //EndMethod

    public bool ArraySelectSequenceEqualArraySelectRewritten()
    {
        return ArraySelectSequenceEqualArraySelectRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArrayWhereSequenceEqualArrayWhere()
    {
        return ArrayItems.Where(x => x > 50).SequenceEqual(ArrayItems2.Where(x => x > 50));
    } //EndMethod

    public bool ArrayWhereSequenceEqualArrayWhereRewritten()
    {
        return ArrayWhereSequenceEqualArrayWhereRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool SelectWhereArraySequenceEqualSelectWhereArray()
    {
        return ArrayItems.Select(x => x + 10).Where(x => x > 80).SequenceEqual(ArrayItems2.Select(x => x + 10).Where(x => x > 80));
    } //EndMethod

    public bool SelectWhereArraySequenceEqualSelectWhereArrayRewritten()
    {
        return SelectWhereArraySequenceEqualSelectWhereArrayRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool RangeSequenceEqualArray()
    {
        return Enumerable.Range(20, 100).SequenceEqual(ArrayItems2);
    } //EndMethod

    public bool RangeSequenceEqualArrayRewritten()
    {
        return RangeSequenceEqualArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public bool RepeatSequenceEqualArray()
    {
        return Enumerable.Repeat(20, 100).SequenceEqual(ArrayItems2);
    } //EndMethod

    public bool RepeatSequenceEqualArrayRewritten()
    {
        return RepeatSequenceEqualArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public bool EmptySequenceEqualArray()
    {
        return Enumerable.Empty<int>().SequenceEqual(ArrayItems2);
    } //EndMethod

    public bool EmptySequenceEqualArrayRewritten()
    {
        return EmptySequenceEqualArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public bool RangeEmpty2Array()
    {
        return ArrayItems.Where(x => false).SequenceEqual(ArrayItems2);
    } //EndMethod

    public bool RangeEmpty2ArrayRewritten()
    {
        return RangeEmpty2ArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArraySequenceEqualRange()
    {
        return ArrayItems.SequenceEqual(Enumerable.Range(70, 260));
    } //EndMethod

    public bool ArraySequenceEqualRangeRewritten()
    {
        return ArraySequenceEqualRangeRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArraySequenceEqualRepeat()
    {
        return ArrayItems.SequenceEqual(Enumerable.Repeat(70, 100));
    } //EndMethod

    public bool ArraySequenceEqualRepeatRewritten()
    {
        return ArraySequenceEqualRepeatRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArraySequenceEqualEmpty()
    {
        return ArrayItems.SequenceEqual(Enumerable.Empty<int>());
    } //EndMethod

    public bool ArraySequenceEqualEmptyRewritten()
    {
        return ArraySequenceEqualEmptyRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArraySequenceEqualEmpty2()
    {
        return ArrayItems.SequenceEqual(ArrayItems2.Where(x => false));
    } //EndMethod

    public bool ArraySequenceEqualEmpty2Rewritten()
    {
        return ArraySequenceEqualEmpty2Rewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArraySequenceEqualAll()
    {
        return ArrayItems.SequenceEqual(Enumerable.Range(0, 1000));
    } //EndMethod

    public bool ArraySequenceEqualAllRewritten()
    {
        return ArraySequenceEqualAllRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArraySequenceEqualNull()
    {
        return ArrayItems.SequenceEqual(null);
    } //EndMethod

    public bool ArraySequenceEqualNullRewritten()
    {
        return ArraySequenceEqualNullRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArrayDistinctSequenceEqualArrayDistinct()
    {
        return ArrayItems.Distinct().SequenceEqual(ArrayItems.Distinct());
    } //EndMethod

    public bool ArrayDistinctSequenceEqualArrayDistinctRewritten()
    {
        return ArrayDistinctSequenceEqualArrayDistinctRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArrayDistinctSequenceEqualArrayDistinct2()
    {
        return ArrayItems.Distinct(EqualityComparer<int>.Default).SequenceEqual(ArrayItems.Distinct(EqualityComparer<int>.Default));
    } //EndMethod

    public bool ArrayDistinctSequenceEqualArrayDistinct2Rewritten()
    {
        return ArrayDistinctSequenceEqualArrayDistinct2Rewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    bool ArraySequenceEqualArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1541;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1542;
        v1542 = ((IEnumerable<int>)ArrayItems2).GetEnumerator();
        try
        {
            v1541 = 0;
            for (; v1541 < ArrayItems.Length; v1541++)
                if (!((v1542.MoveNext()) && v1542.Current.Equals(ArrayItems[v1541])))
                    return false;
            if (v1542.MoveNext())
                return false;
        }
        finally
        {
            v1542.Dispose();
        }

        return true;
    }

    bool ArraySequenceEqualSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1543;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1544;
        v1544 = ((IEnumerable<int>)SimpleListItems2).GetEnumerator();
        try
        {
            v1543 = 0;
            for (; v1543 < ArrayItems.Length; v1543++)
                if (!((v1544.MoveNext()) && v1544.Current.Equals(ArrayItems[v1543])))
                    return false;
            if (v1544.MoveNext())
                return false;
        }
        finally
        {
            v1544.Dispose();
        }

        return true;
    }

    bool ArraySequenceEqualEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1545;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1546;
        v1546 = ((IEnumerable<int>)EnumerableItems2).GetEnumerator();
        try
        {
            v1545 = 0;
            for (; v1545 < ArrayItems.Length; v1545++)
                if (!((v1546.MoveNext()) && v1546.Current.Equals(ArrayItems[v1545])))
                    return false;
            if (v1546.MoveNext())
                return false;
        }
        finally
        {
            v1546.Dispose();
        }

        return true;
    }

    bool ArraySequenceEqualMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1547;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1548;
        v1548 = ((IEnumerable<int>)MethodEnumerable2()).GetEnumerator();
        try
        {
            v1547 = 0;
            for (; v1547 < ArrayItems.Length; v1547++)
                if (!((v1548.MoveNext()) && v1548.Current.Equals(ArrayItems[v1547])))
                    return false;
            if (v1548.MoveNext())
                return false;
        }
        finally
        {
            v1548.Dispose();
        }

        return true;
    }

    bool SimpleListSequenceEqualArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v1549;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1550;
        v1550 = ((IEnumerable<int>)ArrayItems2).GetEnumerator();
        v1549 = SimpleListItems.GetEnumerator();
        try
        {
            try
            {
                while (v1549.MoveNext())
                    if (!((v1550.MoveNext()) && v1550.Current.Equals(v1549.Current)))
                        return false;
            }
            finally
            {
                v1549.Dispose();
            }

            if (v1550.MoveNext())
                return false;
        }
        finally
        {
            v1550.Dispose();
        }

        return true;
    }

    bool SimpleListSequenceEqualSimpleListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v1551;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1552;
        v1552 = ((IEnumerable<int>)SimpleListItems2).GetEnumerator();
        v1551 = SimpleListItems.GetEnumerator();
        try
        {
            try
            {
                while (v1551.MoveNext())
                    if (!((v1552.MoveNext()) && v1552.Current.Equals(v1551.Current)))
                        return false;
            }
            finally
            {
                v1551.Dispose();
            }

            if (v1552.MoveNext())
                return false;
        }
        finally
        {
            v1552.Dispose();
        }

        return true;
    }

    bool SimpleListSequenceEqualEnumerableRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v1553;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1554;
        v1554 = ((IEnumerable<int>)EnumerableItems2).GetEnumerator();
        v1553 = SimpleListItems.GetEnumerator();
        try
        {
            try
            {
                while (v1553.MoveNext())
                    if (!((v1554.MoveNext()) && v1554.Current.Equals(v1553.Current)))
                        return false;
            }
            finally
            {
                v1553.Dispose();
            }

            if (v1554.MoveNext())
                return false;
        }
        finally
        {
            v1554.Dispose();
        }

        return true;
    }

    bool SimpleListSequenceEqualMethodRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v1555;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1556;
        v1556 = ((IEnumerable<int>)MethodEnumerable2()).GetEnumerator();
        v1555 = SimpleListItems.GetEnumerator();
        try
        {
            try
            {
                while (v1555.MoveNext())
                    if (!((v1556.MoveNext()) && v1556.Current.Equals(v1555.Current)))
                        return false;
            }
            finally
            {
                v1555.Dispose();
            }

            if (v1556.MoveNext())
                return false;
        }
        finally
        {
            v1556.Dispose();
        }

        return true;
    }

    bool EnumerableSequenceEqualArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1557;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1558;
        v1558 = ((IEnumerable<int>)ArrayItems2).GetEnumerator();
        v1557 = EnumerableItems.GetEnumerator();
        try
        {
            try
            {
                while (v1557.MoveNext())
                    if (!((v1558.MoveNext()) && v1558.Current.Equals(v1557.Current)))
                        return false;
            }
            finally
            {
                v1557.Dispose();
            }

            if (v1558.MoveNext())
                return false;
        }
        finally
        {
            v1558.Dispose();
        }

        return true;
    }

    bool EnumerableSequenceEqualSimpleListRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1559;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1560;
        v1560 = ((IEnumerable<int>)SimpleListItems2).GetEnumerator();
        v1559 = EnumerableItems.GetEnumerator();
        try
        {
            try
            {
                while (v1559.MoveNext())
                    if (!((v1560.MoveNext()) && v1560.Current.Equals(v1559.Current)))
                        return false;
            }
            finally
            {
                v1559.Dispose();
            }

            if (v1560.MoveNext())
                return false;
        }
        finally
        {
            v1560.Dispose();
        }

        return true;
    }

    bool EnumerableSequenceEqualEnumerableRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1561;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1562;
        v1562 = ((IEnumerable<int>)EnumerableItems2).GetEnumerator();
        v1561 = EnumerableItems.GetEnumerator();
        try
        {
            try
            {
                while (v1561.MoveNext())
                    if (!((v1562.MoveNext()) && v1562.Current.Equals(v1561.Current)))
                        return false;
            }
            finally
            {
                v1561.Dispose();
            }

            if (v1562.MoveNext())
                return false;
        }
        finally
        {
            v1562.Dispose();
        }

        return true;
    }

    bool EnumerableSequenceEqualMethodRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1563;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1564;
        v1564 = ((IEnumerable<int>)MethodEnumerable2()).GetEnumerator();
        v1563 = EnumerableItems.GetEnumerator();
        try
        {
            try
            {
                while (v1563.MoveNext())
                    if (!((v1564.MoveNext()) && v1564.Current.Equals(v1563.Current)))
                        return false;
            }
            finally
            {
                v1563.Dispose();
            }

            if (v1564.MoveNext())
                return false;
        }
        finally
        {
            v1564.Dispose();
        }

        return true;
    }

    bool ArraySelectSequenceEqualArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1565;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1566;
        v1566 = ((IEnumerable<int>)ArrayItems2).GetEnumerator();
        try
        {
            v1565 = 0;
            for (; v1565 < ArrayItems.Length; v1565++)
                if (!((v1566.MoveNext()) && v1566.Current.Equals((ArrayItems[v1565] + 50))))
                    return false;
            if (v1566.MoveNext())
                return false;
        }
        finally
        {
            v1566.Dispose();
        }

        return true;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectSequenceEqualArraySelectRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v1567;
        v1567 = 0;
        for (; v1567 < ArrayItems2.Length; v1567++)
            yield return (ArrayItems2[v1567] + 50);
    }

    bool ArraySelectSequenceEqualArraySelectRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1568;
        if (ArraySelectSequenceEqualArraySelectRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1569;
        v1569 = ((IEnumerable<int>)ArraySelectSequenceEqualArraySelectRewritten_ProceduralLinq1(ArrayItems2)).GetEnumerator();
        try
        {
            v1568 = 0;
            for (; v1568 < ArrayItems.Length; v1568++)
                if (!((v1569.MoveNext()) && v1569.Current.Equals((ArrayItems[v1568] + 50))))
                    return false;
            if (v1569.MoveNext())
                return false;
        }
        finally
        {
            v1569.Dispose();
        }

        return true;
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereSequenceEqualArrayWhereRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v1570;
        v1570 = 0;
        for (; v1570 < ArrayItems2.Length; v1570++)
        {
            if (!((ArrayItems2[v1570] > 50)))
                continue;
            yield return ArrayItems2[v1570];
        }
    }

    bool ArrayWhereSequenceEqualArrayWhereRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1571;
        if (ArrayWhereSequenceEqualArrayWhereRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1572;
        v1572 = ((IEnumerable<int>)ArrayWhereSequenceEqualArrayWhereRewritten_ProceduralLinq1(ArrayItems2)).GetEnumerator();
        try
        {
            v1571 = 0;
            for (; v1571 < ArrayItems.Length; v1571++)
            {
                if (!((ArrayItems[v1571] > 50)))
                    continue;
                if (!((v1572.MoveNext()) && v1572.Current.Equals(ArrayItems[v1571])))
                    return false;
            }

            if (v1572.MoveNext())
                return false;
        }
        finally
        {
            v1572.Dispose();
        }

        return true;
    }

    System.Collections.Generic.IEnumerable<int> SelectWhereArraySequenceEqualSelectWhereArrayRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v1573;
        int v1574;
        v1573 = 0;
        for (; v1573 < ArrayItems2.Length; v1573++)
        {
            v1574 = (ArrayItems2[v1573] + 10);
            if (!((v1574 > 80)))
                continue;
            yield return v1574;
        }
    }

    bool SelectWhereArraySequenceEqualSelectWhereArrayRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1575;
        int v1576;
        if (SelectWhereArraySequenceEqualSelectWhereArrayRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1577;
        v1577 = ((IEnumerable<int>)SelectWhereArraySequenceEqualSelectWhereArrayRewritten_ProceduralLinq1(ArrayItems2)).GetEnumerator();
        try
        {
            v1575 = 0;
            for (; v1575 < ArrayItems.Length; v1575++)
            {
                v1576 = (ArrayItems[v1575] + 10);
                if (!((v1576 > 80)))
                    continue;
                if (!((v1577.MoveNext()) && v1577.Current.Equals(v1576)))
                    return false;
            }

            if (v1577.MoveNext())
                return false;
        }
        finally
        {
            v1577.Dispose();
        }

        return true;
    }

    bool RangeSequenceEqualArrayRewritten_ProceduralLinq1()
    {
        int v1578;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1579;
        v1579 = ((IEnumerable<int>)ArrayItems2).GetEnumerator();
        try
        {
            v1578 = 0;
            for (; v1578 < 100; v1578++)
                if (!((v1579.MoveNext()) && v1579.Current.Equals((v1578 + 20))))
                    return false;
            if (v1579.MoveNext())
                return false;
        }
        finally
        {
            v1579.Dispose();
        }

        return true;
    }

    bool RepeatSequenceEqualArrayRewritten_ProceduralLinq1()
    {
        int v1580;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1581;
        v1581 = ((IEnumerable<int>)ArrayItems2).GetEnumerator();
        try
        {
            v1580 = 0;
            for (; v1580 < 100; v1580++)
                if (!((v1581.MoveNext()) && v1581.Current.Equals(20)))
                    return false;
            if (v1581.MoveNext())
                return false;
        }
        finally
        {
            v1581.Dispose();
        }

        return true;
    }

    bool EmptySequenceEqualArrayRewritten_ProceduralLinq1()
    {
        int v1582;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1583;
        v1583 = ((IEnumerable<int>)ArrayItems2).GetEnumerator();
        try
        {
            v1582 = 0;
            for (; v1582 < 0; v1582++)
                if (!((v1583.MoveNext()) && v1583.Current.Equals(default(int))))
                    return false;
            if (v1583.MoveNext())
                return false;
        }
        finally
        {
            v1583.Dispose();
        }

        return true;
    }

    bool RangeEmpty2ArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1584;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1585;
        v1585 = ((IEnumerable<int>)ArrayItems2).GetEnumerator();
        try
        {
            v1584 = 0;
            for (; v1584 < ArrayItems.Length; v1584++)
            {
                if (!((false)))
                    continue;
                if (!((v1585.MoveNext()) && v1585.Current.Equals(ArrayItems[v1584])))
                    return false;
            }

            if (v1585.MoveNext())
                return false;
        }
        finally
        {
            v1585.Dispose();
        }

        return true;
    }

    System.Collections.Generic.IEnumerable<int> ArraySequenceEqualRangeRewritten_ProceduralLinq1()
    {
        int v1586;
        v1586 = 0;
        for (; v1586 < 260; v1586++)
            yield return (v1586 + 70);
    }

    bool ArraySequenceEqualRangeRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1587;
        if (ArraySequenceEqualRangeRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1588;
        v1588 = ((IEnumerable<int>)ArraySequenceEqualRangeRewritten_ProceduralLinq1()).GetEnumerator();
        try
        {
            v1587 = 0;
            for (; v1587 < ArrayItems.Length; v1587++)
                if (!((v1588.MoveNext()) && v1588.Current.Equals(ArrayItems[v1587])))
                    return false;
            if (v1588.MoveNext())
                return false;
        }
        finally
        {
            v1588.Dispose();
        }

        return true;
    }

    System.Collections.Generic.IEnumerable<int> ArraySequenceEqualRepeatRewritten_ProceduralLinq1()
    {
        int v1589;
        v1589 = 0;
        for (; v1589 < 100; v1589++)
            yield return 70;
    }

    bool ArraySequenceEqualRepeatRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1590;
        if (ArraySequenceEqualRepeatRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1591;
        v1591 = ((IEnumerable<int>)ArraySequenceEqualRepeatRewritten_ProceduralLinq1()).GetEnumerator();
        try
        {
            v1590 = 0;
            for (; v1590 < ArrayItems.Length; v1590++)
                if (!((v1591.MoveNext()) && v1591.Current.Equals(ArrayItems[v1590])))
                    return false;
            if (v1591.MoveNext())
                return false;
        }
        finally
        {
            v1591.Dispose();
        }

        return true;
    }

    bool ArraySequenceEqualEmptyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1592;
        if (Enumerable.Empty<int>() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1593;
        v1593 = ((IEnumerable<int>)Enumerable.Empty<int>()).GetEnumerator();
        try
        {
            v1592 = 0;
            for (; v1592 < ArrayItems.Length; v1592++)
                if (!((v1593.MoveNext()) && v1593.Current.Equals(ArrayItems[v1592])))
                    return false;
            if (v1593.MoveNext())
                return false;
        }
        finally
        {
            v1593.Dispose();
        }

        return true;
    }

    System.Collections.Generic.IEnumerable<int> ArraySequenceEqualEmpty2Rewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v1594;
        v1594 = 0;
        for (; v1594 < ArrayItems2.Length; v1594++)
        {
            if (!((false)))
                continue;
            yield return ArrayItems2[v1594];
        }
    }

    bool ArraySequenceEqualEmpty2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1595;
        if (ArraySequenceEqualEmpty2Rewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1596;
        v1596 = ((IEnumerable<int>)ArraySequenceEqualEmpty2Rewritten_ProceduralLinq1(ArrayItems2)).GetEnumerator();
        try
        {
            v1595 = 0;
            for (; v1595 < ArrayItems.Length; v1595++)
                if (!((v1596.MoveNext()) && v1596.Current.Equals(ArrayItems[v1595])))
                    return false;
            if (v1596.MoveNext())
                return false;
        }
        finally
        {
            v1596.Dispose();
        }

        return true;
    }

    System.Collections.Generic.IEnumerable<int> ArraySequenceEqualAllRewritten_ProceduralLinq1()
    {
        int v1597;
        v1597 = 0;
        for (; v1597 < 1000; v1597++)
            yield return (v1597 + 0);
    }

    bool ArraySequenceEqualAllRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1598;
        if (ArraySequenceEqualAllRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1599;
        v1599 = ((IEnumerable<int>)ArraySequenceEqualAllRewritten_ProceduralLinq1()).GetEnumerator();
        try
        {
            v1598 = 0;
            for (; v1598 < ArrayItems.Length; v1598++)
                if (!((v1599.MoveNext()) && v1599.Current.Equals(ArrayItems[v1598])))
                    return false;
            if (v1599.MoveNext())
                return false;
        }
        finally
        {
            v1599.Dispose();
        }

        return true;
    }

    bool ArraySequenceEqualNullRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1600;
        throw new System.InvalidOperationException("Invalid null object");
        v1600 = 0;
        for (; v1600 < ArrayItems.Length; v1600++)
            ;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctSequenceEqualArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1601;
        HashSet<int> v1602;
        v1602 = new HashSet<int>();
        v1601 = 0;
        for (; v1601 < ArrayItems.Length; v1601++)
        {
            if (!(v1602.Add(ArrayItems[v1601])))
                continue;
            yield return ArrayItems[v1601];
        }
    }

    bool ArrayDistinctSequenceEqualArrayDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1603;
        HashSet<int> v1604;
        if (ArrayDistinctSequenceEqualArrayDistinctRewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1605;
        v1605 = ((IEnumerable<int>)ArrayDistinctSequenceEqualArrayDistinctRewritten_ProceduralLinq1(ArrayItems)).GetEnumerator();
        try
        {
            v1604 = new HashSet<int>();
            v1603 = 0;
            for (; v1603 < ArrayItems.Length; v1603++)
            {
                if (!(v1604.Add(ArrayItems[v1603])))
                    continue;
                if (!((v1605.MoveNext()) && v1605.Current.Equals(ArrayItems[v1603])))
                    return false;
            }

            if (v1605.MoveNext())
                return false;
        }
        finally
        {
            v1605.Dispose();
        }

        return true;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctSequenceEqualArrayDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1606;
        HashSet<int> v1607;
        v1607 = new HashSet<int>(EqualityComparer<int>.Default);
        v1606 = 0;
        for (; v1606 < ArrayItems.Length; v1606++)
        {
            if (!(v1607.Add(ArrayItems[v1606])))
                continue;
            yield return ArrayItems[v1606];
        }
    }

    bool ArrayDistinctSequenceEqualArrayDistinct2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1608;
        HashSet<int> v1609;
        if (ArrayDistinctSequenceEqualArrayDistinct2Rewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1610;
        v1610 = ((IEnumerable<int>)ArrayDistinctSequenceEqualArrayDistinct2Rewritten_ProceduralLinq1(ArrayItems)).GetEnumerator();
        try
        {
            v1609 = new HashSet<int>(EqualityComparer<int>.Default);
            v1608 = 0;
            for (; v1608 < ArrayItems.Length; v1608++)
            {
                if (!(v1609.Add(ArrayItems[v1608])))
                    continue;
                if (!((v1610.MoveNext()) && v1610.Current.Equals(ArrayItems[v1608])))
                    return false;
            }

            if (v1610.MoveNext())
                return false;
        }
        finally
        {
            v1610.Dispose();
        }

        return true;
    }
}}