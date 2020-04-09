using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class IntersectTests
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
        TestsExtensions.TestEquals(nameof(ArrayIntersectArray), ArrayIntersectArray, ArrayIntersectArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectSimpleList), ArrayIntersectSimpleList, ArrayIntersectSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectEnumerable), ArrayIntersectEnumerable, ArrayIntersectEnumerableRewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectMethod), ArrayIntersectMethod, ArrayIntersectMethodRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListIntersectArray), SimpleListIntersectArray, SimpleListIntersectArrayRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListIntersectSimpleList), SimpleListIntersectSimpleList, SimpleListIntersectSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListIntersectEnumerable), SimpleListIntersectEnumerable, SimpleListIntersectEnumerableRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListIntersectMethod), SimpleListIntersectMethod, SimpleListIntersectMethodRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableIntersectArray), EnumerableIntersectArray, EnumerableIntersectArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableIntersectSimpleList), EnumerableIntersectSimpleList, EnumerableIntersectSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableIntersectEnumerable), EnumerableIntersectEnumerable, EnumerableIntersectEnumerableRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableIntersectMethod), EnumerableIntersectMethod, EnumerableIntersectMethodRewritten);
        TestsExtensions.TestEquals(nameof(MethodIntersectArray), MethodIntersectArray, MethodIntersectArrayRewritten);
        TestsExtensions.TestEquals(nameof(MethodIntersectSimpleList), MethodIntersectSimpleList, MethodIntersectSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(MethodIntersectEnumerable), MethodIntersectEnumerable, MethodIntersectEnumerableRewritten);
        TestsExtensions.TestEquals(nameof(MethodIntersectMethod), MethodIntersectMethod, MethodIntersectMethodRewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectArrayToArray), ArrayIntersectArrayToArray, ArrayIntersectArrayToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectSimpleListToArray), ArrayIntersectSimpleListToArray, ArrayIntersectSimpleListToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectEnumerableToArray), ArrayIntersectEnumerableToArray, ArrayIntersectEnumerableToArrayRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListIntersectArrayToArray), SimpleListIntersectArrayToArray, SimpleListIntersectArrayToArrayRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListIntersectSimpleListToArray), SimpleListIntersectSimpleListToArray, SimpleListIntersectSimpleListToArrayRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListIntersectEnumerableToArray), SimpleListIntersectEnumerableToArray, SimpleListIntersectEnumerableToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableIntersectArrayToArray), EnumerableIntersectArrayToArray, EnumerableIntersectArrayToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableIntersectSimpleListToArray), EnumerableIntersectSimpleListToArray, EnumerableIntersectSimpleListToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableIntersectEnumerableToArray), EnumerableIntersectEnumerableToArray, EnumerableIntersectEnumerableToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectIntersectArray), ArraySelectIntersectArray, ArraySelectIntersectArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectIntersectArraySelect), ArraySelectIntersectArraySelect, ArraySelectIntersectArraySelectRewritten);
        TestsExtensions.TestEquals(nameof(ArrayWhereIntersectArrayWhere), ArrayWhereIntersectArrayWhere, ArrayWhereIntersectArrayWhereRewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectArrayCount), ArrayIntersectArrayCount, ArrayIntersectArrayCountRewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectArrayCount2), ArrayIntersectArrayCount2, ArrayIntersectArrayCount2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectArraySum), ArrayIntersectArraySum, ArrayIntersectArraySumRewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectArraySum2), ArrayIntersectArraySum2, ArrayIntersectArraySum2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectArrayDistinct), ArrayIntersectArrayDistinct, ArrayIntersectArrayDistinctRewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectArrayDistinct2), ArrayIntersectArrayDistinct2, ArrayIntersectArrayDistinct2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectArrayElementAt), ArrayIntersectArrayElementAt, ArrayIntersectArrayElementAtRewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectArrayElementAtOrDefault), ArrayIntersectArrayElementAtOrDefault, ArrayIntersectArrayElementAtOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectArrayFirst), ArrayIntersectArrayFirst, ArrayIntersectArrayFirstRewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectArrayFirstOrDefault), ArrayIntersectArrayFirstOrDefault, ArrayIntersectArrayFirstOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectArrayLast), ArrayIntersectArrayLast, ArrayIntersectArrayLastRewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectArrayLastOrDefault), ArrayIntersectArrayLastOrDefault, ArrayIntersectArrayLastOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectArraySingle), ArrayIntersectArraySingle, ArrayIntersectArraySingleRewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectArraySingle2), ArrayIntersectArraySingle2, ArrayIntersectArraySingle2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectArraySingleOrDefault), ArrayIntersectArraySingleOrDefault, ArrayIntersectArraySingleOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectArrayMin), ArrayIntersectArrayMin, ArrayIntersectArrayMinRewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectArrayMin2), ArrayIntersectArrayMin2, ArrayIntersectArrayMin2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectArrayMax), ArrayIntersectArrayMax, ArrayIntersectArrayMaxRewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectArrayMax2), ArrayIntersectArrayMax2, ArrayIntersectArrayMax2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectArrayLongCount), ArrayIntersectArrayLongCount, ArrayIntersectArrayLongCountRewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectArrayLongCount2), ArrayIntersectArrayLongCount2, ArrayIntersectArrayLongCount2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectArrayContains), ArrayIntersectArrayContains, ArrayIntersectArrayContainsRewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectArrayAverage), ArrayIntersectArrayAverage, ArrayIntersectArrayAverageRewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectArrayAverage2), ArrayIntersectArrayAverage2, ArrayIntersectArrayAverage2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectArrayContains2), ArrayIntersectArrayContains2, ArrayIntersectArrayContains2Rewritten);
        TestsExtensions.TestEquals(nameof(SelectWhereArrayIntersectSelectWhereArrayContains), SelectWhereArrayIntersectSelectWhereArrayContains, SelectWhereArrayIntersectSelectWhereArrayContainsRewritten);
        TestsExtensions.TestEquals(nameof(RangeIntersectArray), RangeIntersectArray, RangeIntersectArrayRewritten);
        TestsExtensions.TestEquals(nameof(RepeatIntersectArray), RepeatIntersectArray, RepeatIntersectArrayRewritten);
        TestsExtensions.TestEquals(nameof(EmptyIntersectArray), EmptyIntersectArray, EmptyIntersectArrayRewritten);
        TestsExtensions.TestEquals(nameof(RangeEmpty2Array), RangeEmpty2Array, RangeEmpty2ArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectRange), ArrayIntersectRange, ArrayIntersectRangeRewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectRepeat), ArrayIntersectRepeat, ArrayIntersectRepeatRewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectEmpty), ArrayIntersectEmpty, ArrayIntersectEmptyRewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectEmpty2), ArrayIntersectEmpty2, ArrayIntersectEmpty2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectAll), ArrayIntersectAll, ArrayIntersectAllRewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectNull), ArrayIntersectNull, ArrayIntersectNullRewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectArrayIntersectEnumerable), ArrayIntersectArrayIntersectEnumerable, ArrayIntersectArrayIntersectEnumerableRewritten);
        TestsExtensions.TestEquals(nameof(ArrayIntersectArrayIntersectEnumerable2), ArrayIntersectArrayIntersectEnumerable2, ArrayIntersectArrayIntersectEnumerable2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayDistinctIntersectArrayDistinct), ArrayDistinctIntersectArrayDistinct, ArrayDistinctIntersectArrayDistinctRewritten);
        TestsExtensions.TestEquals(nameof(ArrayDistinctIntersectArrayDistinctDistinct), ArrayDistinctIntersectArrayDistinctDistinct, ArrayDistinctIntersectArrayDistinctDistinctRewritten);
        TestsExtensions.TestEquals(nameof(ArrayDistinctIntersectArrayDistinctDistinct2), ArrayDistinctIntersectArrayDistinctDistinct2, ArrayDistinctIntersectArrayDistinctDistinct2Rewritten);
    }

    [NoRewrite]
    public IEnumerable<int> ArrayIntersectArray()
    {
        return ArrayItems.Intersect(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> ArrayIntersectArrayRewritten()
    {
        return ArrayIntersectArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayIntersectSimpleList()
    {
        return ArrayItems.Intersect(SimpleListItems2);
    } //EndMethod

    public IEnumerable<int> ArrayIntersectSimpleListRewritten()
    {
        return ArrayIntersectSimpleListRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayIntersectEnumerable()
    {
        return ArrayItems.Intersect(EnumerableItems2);
    } //EndMethod

    public IEnumerable<int> ArrayIntersectEnumerableRewritten()
    {
        return ArrayIntersectEnumerableRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayIntersectMethod()
    {
        return ArrayItems.Intersect(MethodEnumerable2());
    } //EndMethod

    public IEnumerable<int> ArrayIntersectMethodRewritten()
    {
        return ArrayIntersectMethodRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListIntersectArray()
    {
        return SimpleListItems.Intersect(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> SimpleListIntersectArrayRewritten()
    {
        return SimpleListIntersectArrayRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListIntersectSimpleList()
    {
        return SimpleListItems.Intersect(SimpleListItems2);
    } //EndMethod

    public IEnumerable<int> SimpleListIntersectSimpleListRewritten()
    {
        return SimpleListIntersectSimpleListRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListIntersectEnumerable()
    {
        return SimpleListItems.Intersect(EnumerableItems2);
    } //EndMethod

    public IEnumerable<int> SimpleListIntersectEnumerableRewritten()
    {
        return SimpleListIntersectEnumerableRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListIntersectMethod()
    {
        return SimpleListItems.Intersect(MethodEnumerable2());
    } //EndMethod

    public IEnumerable<int> SimpleListIntersectMethodRewritten()
    {
        return SimpleListIntersectMethodRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableIntersectArray()
    {
        return EnumerableItems.Intersect(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> EnumerableIntersectArrayRewritten()
    {
        return EnumerableIntersectArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableIntersectSimpleList()
    {
        return EnumerableItems.Intersect(SimpleListItems2);
    } //EndMethod

    public IEnumerable<int> EnumerableIntersectSimpleListRewritten()
    {
        return EnumerableIntersectSimpleListRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableIntersectEnumerable()
    {
        return EnumerableItems.Intersect(EnumerableItems2);
    } //EndMethod

    public IEnumerable<int> EnumerableIntersectEnumerableRewritten()
    {
        return EnumerableIntersectEnumerableRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableIntersectMethod()
    {
        return EnumerableItems.Intersect(MethodEnumerable2());
    } //EndMethod

    public IEnumerable<int> EnumerableIntersectMethodRewritten()
    {
        return EnumerableIntersectMethodRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> MethodIntersectArray()
    {
        return MethodEnumerable().Intersect(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> MethodIntersectArrayRewritten()
    {
        return MethodEnumerable().Intersect(ArrayItems2);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> MethodIntersectSimpleList()
    {
        return MethodEnumerable().Intersect(SimpleListItems2);
    } //EndMethod

    public IEnumerable<int> MethodIntersectSimpleListRewritten()
    {
        return MethodEnumerable().Intersect(SimpleListItems2);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> MethodIntersectEnumerable()
    {
        return MethodEnumerable().Intersect(EnumerableItems2);
    } //EndMethod

    public IEnumerable<int> MethodIntersectEnumerableRewritten()
    {
        return MethodEnumerable().Intersect(EnumerableItems2);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> MethodIntersectMethod()
    {
        return MethodEnumerable().Intersect(MethodEnumerable2());
    } //EndMethod

    public IEnumerable<int> MethodIntersectMethodRewritten()
    {
        return MethodEnumerable().Intersect(MethodEnumerable2());
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayIntersectArrayToArray()
    {
        return ArrayItems.Intersect(ArrayItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayIntersectArrayToArrayRewritten()
    {
        return ArrayIntersectArrayToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayIntersectSimpleListToArray()
    {
        return ArrayItems.Intersect(SimpleListItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayIntersectSimpleListToArrayRewritten()
    {
        return ArrayIntersectSimpleListToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayIntersectEnumerableToArray()
    {
        return ArrayItems.Intersect(EnumerableItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayIntersectEnumerableToArrayRewritten()
    {
        return ArrayIntersectEnumerableToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListIntersectArrayToArray()
    {
        return SimpleListItems.Intersect(ArrayItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> SimpleListIntersectArrayToArrayRewritten()
    {
        return SimpleListIntersectArrayToArrayRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListIntersectSimpleListToArray()
    {
        return SimpleListItems.Intersect(SimpleListItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> SimpleListIntersectSimpleListToArrayRewritten()
    {
        return SimpleListIntersectSimpleListToArrayRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListIntersectEnumerableToArray()
    {
        return SimpleListItems.Intersect(EnumerableItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> SimpleListIntersectEnumerableToArrayRewritten()
    {
        return SimpleListIntersectEnumerableToArrayRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableIntersectArrayToArray()
    {
        return EnumerableItems.Intersect(ArrayItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableIntersectArrayToArrayRewritten()
    {
        return EnumerableIntersectArrayToArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableIntersectSimpleListToArray()
    {
        return EnumerableItems.Intersect(SimpleListItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableIntersectSimpleListToArrayRewritten()
    {
        return EnumerableIntersectSimpleListToArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableIntersectEnumerableToArray()
    {
        return EnumerableItems.Intersect(EnumerableItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableIntersectEnumerableToArrayRewritten()
    {
        return EnumerableIntersectEnumerableToArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectIntersectArray()
    {
        return ArrayItems.Select(x => x + 50).Intersect(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> ArraySelectIntersectArrayRewritten()
    {
        return ArraySelectIntersectArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectIntersectArraySelect()
    {
        return ArrayItems.Select(x => x + 50).Intersect(ArrayItems2.Select(x => x + 50));
    } //EndMethod

    public IEnumerable<int> ArraySelectIntersectArraySelectRewritten()
    {
        return ArraySelectIntersectArraySelectRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayWhereIntersectArrayWhere()
    {
        return ArrayItems.Where(x => x > 50).Intersect(ArrayItems2.Where(x => x > 50));
    } //EndMethod

    public IEnumerable<int> ArrayWhereIntersectArrayWhereRewritten()
    {
        return ArrayWhereIntersectArrayWhereRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayIntersectArrayCount()
    {
        return ArrayItems.Intersect(ArrayItems2).Count();
    } //EndMethod

    public int ArrayIntersectArrayCountRewritten()
    {
        return ArrayIntersectArrayCountRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayIntersectArrayCount2()
    {
        return ArrayItems.Intersect(ArrayItems2).Count(x => x > 70);
    } //EndMethod

    public int ArrayIntersectArrayCount2Rewritten()
    {
        return ArrayIntersectArrayCount2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayIntersectArraySum()
    {
        return ArrayItems.Intersect(ArrayItems2).Sum();
    } //EndMethod

    public int ArrayIntersectArraySumRewritten()
    {
        return ArrayIntersectArraySumRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayIntersectArraySum2()
    {
        return ArrayItems.Intersect(ArrayItems2).Sum(x => x + 10);
    } //EndMethod

    public int ArrayIntersectArraySum2Rewritten()
    {
        return ArrayIntersectArraySum2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayIntersectArrayDistinct()
    {
        return ArrayItems.Intersect(ArrayItems2).Distinct();
    } //EndMethod

    public IEnumerable<int> ArrayIntersectArrayDistinctRewritten()
    {
        return ArrayIntersectArrayDistinctRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayIntersectArrayDistinct2()
    {
        return ArrayItems.Intersect(ArrayItems2).Distinct(EqualityComparer<int>.Default);
    } //EndMethod

    public IEnumerable<int> ArrayIntersectArrayDistinct2Rewritten()
    {
        return ArrayIntersectArrayDistinct2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayIntersectArrayElementAt()
    {
        return ArrayItems.Intersect(ArrayItems2).ElementAt(45);
    } //EndMethod

    public int ArrayIntersectArrayElementAtRewritten()
    {
        return ArrayIntersectArrayElementAtRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayIntersectArrayElementAtOrDefault()
    {
        return ArrayItems.Intersect(ArrayItems2).ElementAtOrDefault(45);
    } //EndMethod

    public int ArrayIntersectArrayElementAtOrDefaultRewritten()
    {
        return ArrayIntersectArrayElementAtOrDefaultRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayIntersectArrayFirst()
    {
        return ArrayItems.Intersect(ArrayItems2).First();
    } //EndMethod

    public int ArrayIntersectArrayFirstRewritten()
    {
        return ArrayIntersectArrayFirstRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayIntersectArrayFirstOrDefault()
    {
        return ArrayItems.Intersect(ArrayItems2).FirstOrDefault();
    } //EndMethod

    public int ArrayIntersectArrayFirstOrDefaultRewritten()
    {
        return ArrayIntersectArrayFirstOrDefaultRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayIntersectArrayLast()
    {
        return ArrayItems.Intersect(ArrayItems2).Last();
    } //EndMethod

    public int ArrayIntersectArrayLastRewritten()
    {
        return ArrayIntersectArrayLastRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayIntersectArrayLastOrDefault()
    {
        return ArrayItems.Intersect(ArrayItems2).LastOrDefault();
    } //EndMethod

    public int ArrayIntersectArrayLastOrDefaultRewritten()
    {
        return ArrayIntersectArrayLastOrDefaultRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayIntersectArraySingle()
    {
        return ArrayItems.Intersect(ArrayItems2).Single();
    } //EndMethod

    public int ArrayIntersectArraySingleRewritten()
    {
        return ArrayIntersectArraySingleRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayIntersectArraySingle2()
    {
        return ArrayItems.Intersect(ArrayItems2).Single(x => x == 76);
    } //EndMethod

    public int ArrayIntersectArraySingle2Rewritten()
    {
        return ArrayIntersectArraySingle2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayIntersectArraySingleOrDefault()
    {
        return ArrayItems.Intersect(ArrayItems2).SingleOrDefault();
    } //EndMethod

    public int ArrayIntersectArraySingleOrDefaultRewritten()
    {
        return ArrayIntersectArraySingleOrDefaultRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayIntersectArrayMin()
    {
        return ArrayItems.Intersect(ArrayItems2).Min();
    } //EndMethod

    public int ArrayIntersectArrayMinRewritten()
    {
        return ArrayIntersectArrayMinRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public decimal ArrayIntersectArrayMin2()
    {
        return ArrayItems.Intersect(ArrayItems2).Min(x => x + 2m);
    } //EndMethod

    public decimal ArrayIntersectArrayMin2Rewritten()
    {
        return ArrayIntersectArrayMin2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayIntersectArrayMax()
    {
        return ArrayItems.Intersect(ArrayItems2).Max();
    } //EndMethod

    public int ArrayIntersectArrayMaxRewritten()
    {
        return ArrayIntersectArrayMaxRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public decimal ArrayIntersectArrayMax2()
    {
        return ArrayItems.Intersect(ArrayItems2).Max(x => x + 2m);
    } //EndMethod

    public decimal ArrayIntersectArrayMax2Rewritten()
    {
        return ArrayIntersectArrayMax2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public long ArrayIntersectArrayLongCount()
    {
        return ArrayItems.Intersect(ArrayItems2).LongCount();
    } //EndMethod

    public long ArrayIntersectArrayLongCountRewritten()
    {
        return ArrayIntersectArrayLongCountRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public long ArrayIntersectArrayLongCount2()
    {
        return ArrayItems.Intersect(ArrayItems2).LongCount(x => x > 50);
    } //EndMethod

    public long ArrayIntersectArrayLongCount2Rewritten()
    {
        return ArrayIntersectArrayLongCount2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArrayIntersectArrayContains()
    {
        return ArrayItems.Intersect(ArrayItems2).Contains(56);
    } //EndMethod

    public bool ArrayIntersectArrayContainsRewritten()
    {
        return ArrayIntersectArrayContainsRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double ArrayIntersectArrayAverage()
    {
        return ArrayItems.Intersect(ArrayItems2).Average();
    } //EndMethod

    public double ArrayIntersectArrayAverageRewritten()
    {
        return ArrayIntersectArrayAverageRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double ArrayIntersectArrayAverage2()
    {
        return ArrayItems.Intersect(ArrayItems2).Average(x => x + 10);
    } //EndMethod

    public double ArrayIntersectArrayAverage2Rewritten()
    {
        return ArrayIntersectArrayAverage2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArrayIntersectArrayContains2()
    {
        return ArrayItems.Intersect(ArrayItems2).Contains(56, EqualityComparer<int>.Default);
    } //EndMethod

    public bool ArrayIntersectArrayContains2Rewritten()
    {
        return ArrayIntersectArrayContains2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool SelectWhereArrayIntersectSelectWhereArrayContains()
    {
        return ArrayItems.Select(x => x + 10).Where(x => x > 80).Intersect(ArrayItems2.Select(x => x + 10).Where(x => x > 80)).Contains(112);
    } //EndMethod

    public bool SelectWhereArrayIntersectSelectWhereArrayContainsRewritten()
    {
        return SelectWhereArrayIntersectSelectWhereArrayContainsRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeIntersectArray()
    {
        return Enumerable.Range(20, 100).Intersect(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> RangeIntersectArrayRewritten()
    {
        return RangeIntersectArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatIntersectArray()
    {
        return Enumerable.Repeat(20, 100).Intersect(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> RepeatIntersectArrayRewritten()
    {
        return RepeatIntersectArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EmptyIntersectArray()
    {
        return Enumerable.Empty<int>().Intersect(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> EmptyIntersectArrayRewritten()
    {
        return EmptyIntersectArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeEmpty2Array()
    {
        return ArrayItems.Where(x => false).Intersect(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> RangeEmpty2ArrayRewritten()
    {
        return RangeEmpty2ArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayIntersectRange()
    {
        return ArrayItems.Intersect(Enumerable.Range(70, 260));
    } //EndMethod

    public IEnumerable<int> ArrayIntersectRangeRewritten()
    {
        return ArrayIntersectRangeRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayIntersectRepeat()
    {
        return ArrayItems.Intersect(Enumerable.Repeat(70, 100));
    } //EndMethod

    public IEnumerable<int> ArrayIntersectRepeatRewritten()
    {
        return ArrayIntersectRepeatRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayIntersectEmpty()
    {
        return ArrayItems.Intersect(Enumerable.Empty<int>());
    } //EndMethod

    public IEnumerable<int> ArrayIntersectEmptyRewritten()
    {
        return ArrayIntersectEmptyRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayIntersectEmpty2()
    {
        return ArrayItems.Intersect(ArrayItems2.Where(x => false));
    } //EndMethod

    public IEnumerable<int> ArrayIntersectEmpty2Rewritten()
    {
        return ArrayIntersectEmpty2Rewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayIntersectAll()
    {
        return ArrayItems.Intersect(Enumerable.Range(0, 1000));
    } //EndMethod

    public IEnumerable<int> ArrayIntersectAllRewritten()
    {
        return ArrayIntersectAllRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayIntersectNull()
    {
        return ArrayItems.Intersect(null);
    } //EndMethod

    public IEnumerable<int> ArrayIntersectNullRewritten()
    {
        return ArrayIntersectNullRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayIntersectArrayIntersectEnumerable()
    {
        return ArrayItems.Intersect(ArrayItems).Intersect(EnumerableItems2);
    } //EndMethod

    public IEnumerable<int> ArrayIntersectArrayIntersectEnumerableRewritten()
    {
        return ArrayIntersectArrayIntersectEnumerableRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayIntersectArrayIntersectEnumerable2()
    {
        return ArrayItems.Intersect(ArrayItems.Intersect(EnumerableItems2));
    } //EndMethod

    public IEnumerable<int> ArrayIntersectArrayIntersectEnumerable2Rewritten()
    {
        return ArrayIntersectArrayIntersectEnumerable2Rewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayDistinctIntersectArrayDistinct()
    {
        return ArrayItems.Distinct().Intersect(ArrayItems.Distinct());
    } //EndMethod

    public IEnumerable<int> ArrayDistinctIntersectArrayDistinctRewritten()
    {
        return ArrayDistinctIntersectArrayDistinctRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayDistinctIntersectArrayDistinctDistinct()
    {
        return ArrayItems.Distinct().Intersect(ArrayItems.Distinct()).Distinct();
    } //EndMethod

    public IEnumerable<int> ArrayDistinctIntersectArrayDistinctDistinctRewritten()
    {
        return ArrayDistinctIntersectArrayDistinctDistinctRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayDistinctIntersectArrayDistinctDistinct2()
    {
        return ArrayItems.Distinct(EqualityComparer<int>.Default).Intersect(ArrayItems.Distinct(EqualityComparer<int>.Default)).Distinct(EqualityComparer<int>.Default);
    } //EndMethod

    public IEnumerable<int> ArrayDistinctIntersectArrayDistinctDistinct2Rewritten()
    {
        return ArrayDistinctIntersectArrayDistinctDistinct2Rewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    System.Collections.Generic.IEnumerable<int> ArrayIntersectArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1090;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1091;
        int v1092;
        int v1093;
        v1091 = new HashSet<int>();
        v1090 = (0);
        for (; v1090 < (ArrayItems.Length); v1090++)
            v1091.Add((ArrayItems[v1090]));
        v1092 = (0);
        for (; v1092 < (ArrayItems2.Length); v1092++)
        {
            v1093 = (ArrayItems2[v1092]);
            if (!(v1091.Remove((v1093))))
                continue;
            yield return (v1093);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1094;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1095;
        int v1096;
        int v1097;
        int v1098;
        v1095 = new HashSet<int>();
        v1094 = (0);
        for (; v1094 < (ArrayItems.Length); v1094++)
            v1095.Add((ArrayItems[v1094]));
        v1096 = SimpleListItems2.Count;
        v1097 = (0);
        for (; v1097 < (v1096); v1097++)
        {
            v1098 = (SimpleListItems2[v1097]);
            if (!(v1095.Remove((v1098))))
                continue;
            yield return (v1098);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1099;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1100;
        IEnumerator<int> v1101;
        int v1102;
        v1101 = EnumerableItems2.GetEnumerator();
        v1100 = new HashSet<int>();
        v1099 = (0);
        for (; v1099 < (ArrayItems.Length); v1099++)
            v1100.Add((ArrayItems[v1099]));
        try
        {
            while (v1101.MoveNext())
            {
                v1102 = (v1101.Current);
                if (!(v1100.Remove((v1102))))
                    continue;
                yield return (v1102);
            }
        }
        finally
        {
            v1101.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1103;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1104;
        IEnumerator<int> v1105;
        int v1106;
        v1105 = MethodEnumerable2().GetEnumerator();
        v1104 = new HashSet<int>();
        v1103 = (0);
        for (; v1103 < (ArrayItems.Length); v1103++)
            v1104.Add((ArrayItems[v1103]));
        try
        {
            while (v1105.MoveNext())
            {
                v1106 = (v1105.Current);
                if (!(v1104.Remove((v1106))))
                    continue;
                yield return (v1106);
            }
        }
        finally
        {
            v1105.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SimpleListIntersectArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v1107;
        LinqRewrite.Core.SimpleList.SimpleList<int> v1108;
        int v1109;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1110;
        int v1111;
        int v1112;
        v1107 = SimpleListItems.Count;
        v1108 = SimpleListItems;
        v1110 = new HashSet<int>();
        v1109 = (0);
        for (; v1109 < (v1107); v1109++)
            v1110.Add((v1108[v1109]));
        v1111 = (0);
        for (; v1111 < (ArrayItems2.Length); v1111++)
        {
            v1112 = (ArrayItems2[v1111]);
            if (!(v1110.Remove((v1112))))
                continue;
            yield return (v1112);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SimpleListIntersectSimpleListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v1113;
        LinqRewrite.Core.SimpleList.SimpleList<int> v1114;
        int v1115;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1116;
        int v1117;
        int v1118;
        int v1119;
        v1113 = SimpleListItems.Count;
        v1114 = SimpleListItems;
        v1116 = new HashSet<int>();
        v1115 = (0);
        for (; v1115 < (v1113); v1115++)
            v1116.Add((v1114[v1115]));
        v1117 = SimpleListItems2.Count;
        v1118 = (0);
        for (; v1118 < (v1117); v1118++)
        {
            v1119 = (SimpleListItems2[v1118]);
            if (!(v1116.Remove((v1119))))
                continue;
            yield return (v1119);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SimpleListIntersectEnumerableRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v1120;
        LinqRewrite.Core.SimpleList.SimpleList<int> v1121;
        int v1122;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1123;
        IEnumerator<int> v1124;
        int v1125;
        v1124 = EnumerableItems2.GetEnumerator();
        v1120 = SimpleListItems.Count;
        v1121 = SimpleListItems;
        v1123 = new HashSet<int>();
        v1122 = (0);
        for (; v1122 < (v1120); v1122++)
            v1123.Add((v1121[v1122]));
        try
        {
            while (v1124.MoveNext())
            {
                v1125 = (v1124.Current);
                if (!(v1123.Remove((v1125))))
                    continue;
                yield return (v1125);
            }
        }
        finally
        {
            v1124.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SimpleListIntersectMethodRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v1126;
        LinqRewrite.Core.SimpleList.SimpleList<int> v1127;
        int v1128;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1129;
        IEnumerator<int> v1130;
        int v1131;
        v1130 = MethodEnumerable2().GetEnumerator();
        v1126 = SimpleListItems.Count;
        v1127 = SimpleListItems;
        v1129 = new HashSet<int>();
        v1128 = (0);
        for (; v1128 < (v1126); v1128++)
            v1129.Add((v1127[v1128]));
        try
        {
            while (v1130.MoveNext())
            {
                v1131 = (v1130.Current);
                if (!(v1129.Remove((v1131))))
                    continue;
                yield return (v1131);
            }
        }
        finally
        {
            v1130.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableIntersectArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1132;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1133;
        int v1134;
        int v1135;
        v1132 = EnumerableItems.GetEnumerator();
        v1133 = new HashSet<int>();
        try
        {
            while (v1132.MoveNext())
                v1133.Add((v1132.Current));
        }
        finally
        {
            v1132.Dispose();
        }

        v1134 = (0);
        for (; v1134 < (ArrayItems2.Length); v1134++)
        {
            v1135 = (ArrayItems2[v1134]);
            if (!(v1133.Remove((v1135))))
                continue;
            yield return (v1135);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableIntersectSimpleListRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1136;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1137;
        int v1138;
        int v1139;
        int v1140;
        v1136 = EnumerableItems.GetEnumerator();
        v1137 = new HashSet<int>();
        try
        {
            while (v1136.MoveNext())
                v1137.Add((v1136.Current));
        }
        finally
        {
            v1136.Dispose();
        }

        v1138 = SimpleListItems2.Count;
        v1139 = (0);
        for (; v1139 < (v1138); v1139++)
        {
            v1140 = (SimpleListItems2[v1139]);
            if (!(v1137.Remove((v1140))))
                continue;
            yield return (v1140);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableIntersectEnumerableRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1141;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1142;
        IEnumerator<int> v1143;
        int v1144;
        v1141 = EnumerableItems.GetEnumerator();
        v1143 = EnumerableItems2.GetEnumerator();
        v1142 = new HashSet<int>();
        try
        {
            while (v1141.MoveNext())
                v1142.Add((v1141.Current));
        }
        finally
        {
            v1141.Dispose();
        }

        try
        {
            while (v1143.MoveNext())
            {
                v1144 = (v1143.Current);
                if (!(v1142.Remove((v1144))))
                    continue;
                yield return (v1144);
            }
        }
        finally
        {
            v1143.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableIntersectMethodRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1145;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1146;
        IEnumerator<int> v1147;
        int v1148;
        v1145 = EnumerableItems.GetEnumerator();
        v1147 = MethodEnumerable2().GetEnumerator();
        v1146 = new HashSet<int>();
        try
        {
            while (v1145.MoveNext())
                v1146.Add((v1145.Current));
        }
        finally
        {
            v1145.Dispose();
        }

        try
        {
            while (v1147.MoveNext())
            {
                v1148 = (v1147.Current);
                if (!(v1146.Remove((v1148))))
                    continue;
                yield return (v1148);
            }
        }
        finally
        {
            v1147.Dispose();
        }

        yield break;
    }

    int[] ArrayIntersectArrayToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1149;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1150;
        int v1151;
        int v1152;
        int v1153;
        int v1154;
        int v1155;
        int[] v1156;
        v1150 = new HashSet<int>();
        v1149 = (0);
        for (; v1149 < (ArrayItems.Length); v1149++)
            v1150.Add((ArrayItems[v1149]));
        v1153 = 0;
        v1154 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems2.Length + ArrayItems.Length))) - 3);
        v1154 -= (v1154 % 2);
        v1155 = 8;
        v1156 = new int[8];
        v1151 = (0);
        for (; v1151 < (ArrayItems2.Length); v1151++)
        {
            v1152 = (ArrayItems2[v1151]);
            if (!(v1150.Remove((v1152))))
                continue;
            if (v1153 >= v1155)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems2.Length + ArrayItems.Length), ref v1156, ref v1154, out v1155);
            v1156[v1153] = (v1152);
            v1153++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1156, v1153);
    }

    int[] ArrayIntersectSimpleListToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1157;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1158;
        int v1159;
        int v1160;
        int v1161;
        int v1162;
        int v1163;
        int v1164;
        int[] v1165;
        v1158 = new HashSet<int>();
        v1157 = (0);
        for (; v1157 < (ArrayItems.Length); v1157++)
            v1158.Add((ArrayItems[v1157]));
        v1159 = SimpleListItems2.Count;
        v1162 = 0;
        v1163 = (LinqRewrite.Core.IntExtensions.Log2((uint)((v1159 + ArrayItems.Length))) - 3);
        v1163 -= (v1163 % 2);
        v1164 = 8;
        v1165 = new int[8];
        v1160 = (0);
        for (; v1160 < (v1159); v1160++)
        {
            v1161 = (SimpleListItems2[v1160]);
            if (!(v1158.Remove((v1161))))
                continue;
            if (v1162 >= v1164)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (v1159 + ArrayItems.Length), ref v1165, ref v1163, out v1164);
            v1165[v1162] = (v1161);
            v1162++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1165, v1162);
    }

    int[] ArrayIntersectEnumerableToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1166;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1167;
        IEnumerator<int> v1168;
        int v1169;
        int v1170;
        int v1171;
        int[] v1172;
        v1168 = EnumerableItems2.GetEnumerator();
        v1167 = new HashSet<int>();
        v1166 = (0);
        for (; v1166 < (ArrayItems.Length); v1166++)
            v1167.Add((ArrayItems[v1166]));
        v1170 = 0;
        v1171 = 8;
        v1172 = new int[8];
        try
        {
            while (v1168.MoveNext())
            {
                v1169 = (v1168.Current);
                if (!(v1167.Remove((v1169))))
                    continue;
                if (v1170 >= v1171)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1172, ref v1171);
                v1172[v1170] = (v1169);
                v1170++;
            }
        }
        finally
        {
            v1168.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1172, v1170);
    }

    int[] SimpleListIntersectArrayToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v1173;
        LinqRewrite.Core.SimpleList.SimpleList<int> v1174;
        int v1175;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1176;
        int v1177;
        int v1178;
        int v1179;
        int v1180;
        int v1181;
        int[] v1182;
        v1173 = SimpleListItems.Count;
        v1174 = SimpleListItems;
        v1176 = new HashSet<int>();
        v1175 = (0);
        for (; v1175 < (v1173); v1175++)
            v1176.Add((v1174[v1175]));
        v1179 = 0;
        v1180 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems2.Length + v1173))) - 3);
        v1180 -= (v1180 % 2);
        v1181 = 8;
        v1182 = new int[8];
        v1177 = (0);
        for (; v1177 < (ArrayItems2.Length); v1177++)
        {
            v1178 = (ArrayItems2[v1177]);
            if (!(v1176.Remove((v1178))))
                continue;
            if (v1179 >= v1181)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems2.Length + v1173), ref v1182, ref v1180, out v1181);
            v1182[v1179] = (v1178);
            v1179++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1182, v1179);
    }

    int[] SimpleListIntersectSimpleListToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v1183;
        LinqRewrite.Core.SimpleList.SimpleList<int> v1184;
        int v1185;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1186;
        int v1187;
        int v1188;
        int v1189;
        int v1190;
        int v1191;
        int v1192;
        int[] v1193;
        v1183 = SimpleListItems.Count;
        v1184 = SimpleListItems;
        v1186 = new HashSet<int>();
        v1185 = (0);
        for (; v1185 < (v1183); v1185++)
            v1186.Add((v1184[v1185]));
        v1187 = SimpleListItems2.Count;
        v1190 = 0;
        v1191 = (LinqRewrite.Core.IntExtensions.Log2((uint)((v1187 + v1183))) - 3);
        v1191 -= (v1191 % 2);
        v1192 = 8;
        v1193 = new int[8];
        v1188 = (0);
        for (; v1188 < (v1187); v1188++)
        {
            v1189 = (SimpleListItems2[v1188]);
            if (!(v1186.Remove((v1189))))
                continue;
            if (v1190 >= v1192)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (v1187 + v1183), ref v1193, ref v1191, out v1192);
            v1193[v1190] = (v1189);
            v1190++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1193, v1190);
    }

    int[] SimpleListIntersectEnumerableToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v1194;
        LinqRewrite.Core.SimpleList.SimpleList<int> v1195;
        int v1196;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1197;
        IEnumerator<int> v1198;
        int v1199;
        int v1200;
        int v1201;
        int[] v1202;
        v1198 = EnumerableItems2.GetEnumerator();
        v1194 = SimpleListItems.Count;
        v1195 = SimpleListItems;
        v1197 = new HashSet<int>();
        v1196 = (0);
        for (; v1196 < (v1194); v1196++)
            v1197.Add((v1195[v1196]));
        v1200 = 0;
        v1201 = 8;
        v1202 = new int[8];
        try
        {
            while (v1198.MoveNext())
            {
                v1199 = (v1198.Current);
                if (!(v1197.Remove((v1199))))
                    continue;
                if (v1200 >= v1201)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1202, ref v1201);
                v1202[v1200] = (v1199);
                v1200++;
            }
        }
        finally
        {
            v1198.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1202, v1200);
    }

    int[] EnumerableIntersectArrayToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1203;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1204;
        int v1205;
        int v1206;
        int v1207;
        int v1208;
        int[] v1209;
        v1203 = EnumerableItems.GetEnumerator();
        v1204 = new HashSet<int>();
        try
        {
            while (v1203.MoveNext())
                v1204.Add((v1203.Current));
        }
        finally
        {
            v1203.Dispose();
        }

        v1207 = 0;
        v1208 = 8;
        v1209 = new int[8];
        v1205 = (0);
        for (; v1205 < (ArrayItems2.Length); v1205++)
        {
            v1206 = (ArrayItems2[v1205]);
            if (!(v1204.Remove((v1206))))
                continue;
            if (v1207 >= v1208)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1209, ref v1208);
            v1209[v1207] = (v1206);
            v1207++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1209, v1207);
    }

    int[] EnumerableIntersectSimpleListToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1210;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1211;
        int v1212;
        int v1213;
        int v1214;
        int v1215;
        int v1216;
        int[] v1217;
        v1210 = EnumerableItems.GetEnumerator();
        v1211 = new HashSet<int>();
        try
        {
            while (v1210.MoveNext())
                v1211.Add((v1210.Current));
        }
        finally
        {
            v1210.Dispose();
        }

        v1212 = SimpleListItems2.Count;
        v1215 = 0;
        v1216 = 8;
        v1217 = new int[8];
        v1213 = (0);
        for (; v1213 < (v1212); v1213++)
        {
            v1214 = (SimpleListItems2[v1213]);
            if (!(v1211.Remove((v1214))))
                continue;
            if (v1215 >= v1216)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1217, ref v1216);
            v1217[v1215] = (v1214);
            v1215++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1217, v1215);
    }

    int[] EnumerableIntersectEnumerableToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1218;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1219;
        IEnumerator<int> v1220;
        int v1221;
        int v1222;
        int v1223;
        int[] v1224;
        v1218 = EnumerableItems.GetEnumerator();
        v1220 = EnumerableItems2.GetEnumerator();
        v1219 = new HashSet<int>();
        try
        {
            while (v1218.MoveNext())
                v1219.Add((v1218.Current));
        }
        finally
        {
            v1218.Dispose();
        }

        v1222 = 0;
        v1223 = 8;
        v1224 = new int[8];
        try
        {
            while (v1220.MoveNext())
            {
                v1221 = (v1220.Current);
                if (!(v1219.Remove((v1221))))
                    continue;
                if (v1222 >= v1223)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1224, ref v1223);
                v1224[v1222] = (v1221);
                v1222++;
            }
        }
        finally
        {
            v1220.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1224, v1222);
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectIntersectArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1225;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1226;
        int v1227;
        int v1228;
        v1226 = new HashSet<int>();
        v1225 = (0);
        for (; v1225 < (ArrayItems.Length); v1225++)
            v1226.Add((50 + ArrayItems[v1225]));
        v1227 = (0);
        for (; v1227 < (ArrayItems2.Length); v1227++)
        {
            v1228 = (ArrayItems2[v1227]);
            if (!(v1226.Remove((v1228))))
                continue;
            yield return (v1228);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectIntersectArraySelectRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v1230;
        v1230 = (0);
        for (; v1230 < (ArrayItems2.Length); v1230++)
            yield return (((ArrayItems2[v1230]) + 50));
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectIntersectArraySelectRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1231;
        if (ArraySelectIntersectArraySelectRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1232;
        IEnumerator<int> v1233;
        int v1234;
        v1233 = ArraySelectIntersectArraySelectRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v1232 = new HashSet<int>();
        v1231 = (0);
        for (; v1231 < (ArrayItems.Length); v1231++)
            v1232.Add((50 + ArrayItems[v1231]));
        try
        {
            while (v1233.MoveNext())
            {
                v1234 = (v1233.Current);
                if (!(v1232.Remove((v1234))))
                    continue;
                yield return (v1234);
            }
        }
        finally
        {
            v1233.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereIntersectArrayWhereRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v1235;
        int v1236;
        v1235 = (0);
        for (; v1235 < (ArrayItems2.Length); v1235++)
        {
            v1236 = (ArrayItems2[v1235]);
            if (!(((v1236) > 50)))
                continue;
            yield return (v1236);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereIntersectArrayWhereRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1237;
        int v1238;
        if (ArrayWhereIntersectArrayWhereRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1239;
        IEnumerator<int> v1240;
        v1240 = ArrayWhereIntersectArrayWhereRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v1239 = new HashSet<int>();
        v1237 = (0);
        for (; v1237 < (ArrayItems.Length); v1237++)
        {
            v1238 = (ArrayItems[v1237]);
            if (!(((v1238) > 50)))
                continue;
            v1239.Add((v1238));
        }

        try
        {
            while (v1240.MoveNext())
            {
                v1238 = (v1240.Current);
                if (!(v1239.Remove((v1238))))
                    continue;
                yield return (v1238);
            }
        }
        finally
        {
            v1240.Dispose();
        }

        yield break;
    }

    int ArrayIntersectArrayCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1241;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1242;
        int v1243;
        int v1244;
        int v1245;
        v1242 = new HashSet<int>();
        v1241 = (0);
        for (; v1241 < (ArrayItems.Length); v1241++)
            v1242.Add((ArrayItems[v1241]));
        v1245 = 0;
        v1243 = (0);
        for (; v1243 < (ArrayItems2.Length); v1243++)
        {
            v1244 = (ArrayItems2[v1243]);
            if (!(v1242.Remove((v1244))))
                continue;
            v1245++;
        }

        return v1245;
    }

    int ArrayIntersectArrayCount2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1246;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1247;
        int v1248;
        int v1249;
        int v1250;
        v1247 = new HashSet<int>();
        v1246 = (0);
        for (; v1246 < (ArrayItems.Length); v1246++)
            v1247.Add((ArrayItems[v1246]));
        v1250 = 0;
        v1248 = (0);
        for (; v1248 < (ArrayItems2.Length); v1248++)
        {
            v1249 = (ArrayItems2[v1248]);
            if (!(v1247.Remove((v1249))))
                continue;
            if (!(((v1249) > 70)))
                continue;
            v1250++;
        }

        return v1250;
    }

    int ArrayIntersectArraySumRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1251;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1252;
        int v1253;
        int v1254;
        int v1255;
        v1252 = new HashSet<int>();
        v1251 = (0);
        for (; v1251 < (ArrayItems.Length); v1251++)
            v1252.Add((ArrayItems[v1251]));
        v1255 = 0;
        v1253 = (0);
        for (; v1253 < (ArrayItems2.Length); v1253++)
        {
            v1254 = (ArrayItems2[v1253]);
            if (!(v1252.Remove((v1254))))
                continue;
            v1255 += (v1254);
        }

        return v1255;
    }

    int ArrayIntersectArraySum2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1256;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1257;
        int v1258;
        int v1259;
        int v1260;
        v1257 = new HashSet<int>();
        v1256 = (0);
        for (; v1256 < (ArrayItems.Length); v1256++)
            v1257.Add((ArrayItems[v1256]));
        v1260 = 0;
        v1258 = (0);
        for (; v1258 < (ArrayItems2.Length); v1258++)
        {
            v1259 = (ArrayItems2[v1258]);
            if (!(v1257.Remove((v1259))))
                continue;
            v1259 = ((v1259) + 10);
            v1260 += v1259;
        }

        return v1260;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1261;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1262;
        int v1263;
        int v1264;
        HashSet<int> v1265;
        v1262 = new HashSet<int>();
        v1261 = (0);
        for (; v1261 < (ArrayItems.Length); v1261++)
            v1262.Add((ArrayItems[v1261]));
        v1265 = new HashSet<int>();
        v1263 = (0);
        for (; v1263 < (ArrayItems2.Length); v1263++)
        {
            v1264 = (ArrayItems2[v1263]);
            if (!(v1262.Remove((v1264))))
                continue;
            v1264 = (v1264);
            if (!(v1265.Add((v1264))))
                continue;
            yield return (v1264);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectArrayDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1266;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1267;
        int v1268;
        int v1269;
        HashSet<int> v1270;
        v1267 = new HashSet<int>();
        v1266 = (0);
        for (; v1266 < (ArrayItems.Length); v1266++)
            v1267.Add((ArrayItems[v1266]));
        v1270 = new HashSet<int>(EqualityComparer<int>.Default);
        v1268 = (0);
        for (; v1268 < (ArrayItems2.Length); v1268++)
        {
            v1269 = (ArrayItems2[v1268]);
            if (!(v1267.Remove((v1269))))
                continue;
            v1269 = (v1269);
            if (!(v1270.Add((v1269))))
                continue;
            yield return (v1269);
        }

        yield break;
    }

    int ArrayIntersectArrayElementAtRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1271;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1272;
        int v1273;
        int v1274;
        int v1275;
        v1272 = new HashSet<int>();
        v1271 = (0);
        for (; v1271 < (ArrayItems.Length); v1271++)
            v1272.Add((ArrayItems[v1271]));
        v1275 = 0;
        v1273 = (0);
        for (; v1273 < (ArrayItems2.Length); v1273++)
        {
            v1274 = (ArrayItems2[v1273]);
            if (!(v1272.Remove((v1274))))
                continue;
            if (v1275 == 45)
                return (v1274);
            v1275++;
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArrayIntersectArrayElementAtOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1276;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1277;
        int v1278;
        int v1279;
        int v1280;
        v1277 = new HashSet<int>();
        v1276 = (0);
        for (; v1276 < (ArrayItems.Length); v1276++)
            v1277.Add((ArrayItems[v1276]));
        v1280 = 0;
        v1278 = (0);
        for (; v1278 < (ArrayItems2.Length); v1278++)
        {
            v1279 = (ArrayItems2[v1278]);
            if (!(v1277.Remove((v1279))))
                continue;
            if (v1280 == 45)
                return (v1279);
            v1280++;
        }

        return default(int);
    }

    int ArrayIntersectArrayFirstRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1281;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1282;
        int v1283;
        int v1284;
        int v1285;
        v1282 = new HashSet<int>();
        v1281 = (0);
        for (; v1281 < (ArrayItems.Length); v1281++)
            v1282.Add((ArrayItems[v1281]));
        v1285 = 0;
        v1283 = (0);
        for (; v1283 < (ArrayItems2.Length); v1283++)
        {
            v1284 = (ArrayItems2[v1283]);
            if (!(v1282.Remove((v1284))))
                continue;
            return (v1284);
            v1285++;
        }

        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int ArrayIntersectArrayFirstOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1286;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1287;
        int v1288;
        int v1289;
        v1287 = new HashSet<int>();
        v1286 = (0);
        for (; v1286 < (ArrayItems.Length); v1286++)
            v1287.Add((ArrayItems[v1286]));
        v1288 = (0);
        for (; v1288 < (ArrayItems2.Length); v1288++)
        {
            v1289 = (ArrayItems2[v1288]);
            if (!(v1287.Remove((v1289))))
                continue;
            return (v1289);
        }

        return default(int);
    }

    int ArrayIntersectArrayLastRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1290;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1291;
        int v1292;
        int v1293;
        int v1294;
        int? v1295;
        v1291 = new HashSet<int>();
        v1290 = (0);
        for (; v1290 < (ArrayItems.Length); v1290++)
            v1291.Add((ArrayItems[v1290]));
        v1294 = 0;
        v1295 = null;
        v1292 = (0);
        for (; v1292 < (ArrayItems2.Length); v1292++)
        {
            v1293 = (ArrayItems2[v1292]);
            if (!(v1291.Remove((v1293))))
                continue;
            v1295 = (v1293);
            v1294++;
        }

        if (v1295 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1295;
    }

    int ArrayIntersectArrayLastOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1296;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1297;
        int v1298;
        int v1299;
        int? v1300;
        v1297 = new HashSet<int>();
        v1296 = (0);
        for (; v1296 < (ArrayItems.Length); v1296++)
            v1297.Add((ArrayItems[v1296]));
        v1300 = null;
        v1298 = (0);
        for (; v1298 < (ArrayItems2.Length); v1298++)
        {
            v1299 = (ArrayItems2[v1298]);
            if (!(v1297.Remove((v1299))))
                continue;
            v1300 = (v1299);
        }

        if (v1300 == null)
            return default(int);
        else
            return (int)v1300;
    }

    int ArrayIntersectArraySingleRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1301;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1302;
        int v1303;
        int v1304;
        int? v1305;
        v1302 = new HashSet<int>();
        v1301 = (0);
        for (; v1301 < (ArrayItems.Length); v1301++)
            v1302.Add((ArrayItems[v1301]));
        v1305 = null;
        v1303 = (0);
        for (; v1303 < (ArrayItems2.Length); v1303++)
        {
            v1304 = (ArrayItems2[v1303]);
            if (!(v1302.Remove((v1304))))
                continue;
            if (v1305 == null)
                v1305 = (v1304);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v1305 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1305;
    }

    int ArrayIntersectArraySingle2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1306;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1307;
        int v1308;
        int v1309;
        int? v1310;
        v1307 = new HashSet<int>();
        v1306 = (0);
        for (; v1306 < (ArrayItems.Length); v1306++)
            v1307.Add((ArrayItems[v1306]));
        v1310 = null;
        v1308 = (0);
        for (; v1308 < (ArrayItems2.Length); v1308++)
        {
            v1309 = (ArrayItems2[v1308]);
            if (!(v1307.Remove((v1309))))
                continue;
            if (((v1309) == 76))
                if (v1310 == null)
                    v1310 = (v1309);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v1310 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1310;
    }

    int ArrayIntersectArraySingleOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1311;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1312;
        int v1313;
        int v1314;
        int? v1315;
        v1312 = new HashSet<int>();
        v1311 = (0);
        for (; v1311 < (ArrayItems.Length); v1311++)
            v1312.Add((ArrayItems[v1311]));
        v1315 = null;
        v1313 = (0);
        for (; v1313 < (ArrayItems2.Length); v1313++)
        {
            v1314 = (ArrayItems2[v1313]);
            if (!(v1312.Remove((v1314))))
                continue;
            if (v1315 == null)
                v1315 = (v1314);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v1315 == null)
            return default(int);
        else
            return (int)v1315;
    }

    int ArrayIntersectArrayMinRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1316;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1317;
        int v1318;
        int v1319;
        int v1320;
        int v1321;
        v1317 = new HashSet<int>();
        v1316 = (0);
        for (; v1316 < (ArrayItems.Length); v1316++)
            v1317.Add((ArrayItems[v1316]));
        v1320 = 0;
        v1321 = 2147483647;
        v1318 = (0);
        for (; v1318 < (ArrayItems2.Length); v1318++)
        {
            v1319 = (ArrayItems2[v1318]);
            if (!(v1317.Remove((v1319))))
                continue;
            v1319 = (v1319);
            if (v1319 >= v1321)
                continue;
            v1321 = v1319;
            v1320++;
        }

        if (1 > v1320)
            throw new System.InvalidOperationException("Index out of range");
        return v1321;
    }

    decimal ArrayIntersectArrayMin2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1322;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1323;
        int v1324;
        int v1325;
        int v1326;
        decimal v1327;
        decimal v1328;
        v1323 = new HashSet<int>();
        v1322 = (0);
        for (; v1322 < (ArrayItems.Length); v1322++)
            v1323.Add((ArrayItems[v1322]));
        v1326 = 0;
        v1327 = 79228162514264337593543950335M;
        v1324 = (0);
        for (; v1324 < (ArrayItems2.Length); v1324++)
        {
            v1325 = (ArrayItems2[v1324]);
            if (!(v1323.Remove((v1325))))
                continue;
            v1328 = ((v1325) + 2m);
            if (v1328 >= v1327)
                continue;
            v1327 = v1328;
            v1326++;
        }

        if (1 > v1326)
            throw new System.InvalidOperationException("Index out of range");
        return v1327;
    }

    int ArrayIntersectArrayMaxRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1329;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1330;
        int v1331;
        int v1332;
        int v1333;
        int v1334;
        v1330 = new HashSet<int>();
        v1329 = (0);
        for (; v1329 < (ArrayItems.Length); v1329++)
            v1330.Add((ArrayItems[v1329]));
        v1333 = 0;
        v1334 = -2147483648;
        v1331 = (0);
        for (; v1331 < (ArrayItems2.Length); v1331++)
        {
            v1332 = (ArrayItems2[v1331]);
            if (!(v1330.Remove((v1332))))
                continue;
            v1332 = (v1332);
            if (v1332 <= v1334)
                continue;
            v1334 = v1332;
            v1333++;
        }

        if (1 > v1333)
            throw new System.InvalidOperationException("Index out of range");
        return v1334;
    }

    decimal ArrayIntersectArrayMax2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1335;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1336;
        int v1337;
        int v1338;
        int v1339;
        decimal v1340;
        decimal v1341;
        v1336 = new HashSet<int>();
        v1335 = (0);
        for (; v1335 < (ArrayItems.Length); v1335++)
            v1336.Add((ArrayItems[v1335]));
        v1339 = 0;
        v1340 = -79228162514264337593543950335M;
        v1337 = (0);
        for (; v1337 < (ArrayItems2.Length); v1337++)
        {
            v1338 = (ArrayItems2[v1337]);
            if (!(v1336.Remove((v1338))))
                continue;
            v1341 = ((v1338) + 2m);
            if (v1341 <= v1340)
                continue;
            v1340 = v1341;
            v1339++;
        }

        if (1 > v1339)
            throw new System.InvalidOperationException("Index out of range");
        return v1340;
    }

    long ArrayIntersectArrayLongCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1342;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1343;
        int v1344;
        int v1345;
        long v1346;
        v1343 = new HashSet<int>();
        v1342 = (0);
        for (; v1342 < (ArrayItems.Length); v1342++)
            v1343.Add((ArrayItems[v1342]));
        v1346 = 0;
        v1344 = (0);
        for (; v1344 < (ArrayItems2.Length); v1344++)
        {
            v1345 = (ArrayItems2[v1344]);
            if (!(v1343.Remove((v1345))))
                continue;
            v1346++;
        }

        return v1346;
    }

    long ArrayIntersectArrayLongCount2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1347;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1348;
        int v1349;
        int v1350;
        long v1351;
        v1348 = new HashSet<int>();
        v1347 = (0);
        for (; v1347 < (ArrayItems.Length); v1347++)
            v1348.Add((ArrayItems[v1347]));
        v1351 = 0;
        v1349 = (0);
        for (; v1349 < (ArrayItems2.Length); v1349++)
        {
            v1350 = (ArrayItems2[v1349]);
            if (!(v1348.Remove((v1350))))
                continue;
            if (!(((v1350) > 50)))
                continue;
            v1351++;
        }

        return v1351;
    }

    bool ArrayIntersectArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1352;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1353;
        int v1354;
        int v1355;
        v1353 = new HashSet<int>();
        v1352 = (0);
        for (; v1352 < (ArrayItems.Length); v1352++)
            v1353.Add((ArrayItems[v1352]));
        v1354 = (0);
        for (; v1354 < (ArrayItems2.Length); v1354++)
        {
            v1355 = (ArrayItems2[v1354]);
            if (!(v1353.Remove((v1355))))
                continue;
            if ((v1355) == 56)
                return true;
        }

        return false;
    }

    double ArrayIntersectArrayAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1356;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1357;
        int v1358;
        int v1359;
        double v1360;
        int v1361;
        v1357 = new HashSet<int>();
        v1356 = (0);
        for (; v1356 < (ArrayItems.Length); v1356++)
            v1357.Add((ArrayItems[v1356]));
        v1360 = 0;
        v1361 = 0;
        v1358 = (0);
        for (; v1358 < (ArrayItems2.Length); v1358++)
        {
            v1359 = (ArrayItems2[v1358]);
            if (!(v1357.Remove((v1359))))
                continue;
            v1360 += (v1359);
            v1361++;
        }

        if (1 > v1361)
            throw new System.InvalidOperationException("Index out of range");
        return (v1360 / v1361);
    }

    double ArrayIntersectArrayAverage2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1362;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1363;
        int v1364;
        int v1365;
        double v1366;
        int v1367;
        v1363 = new HashSet<int>();
        v1362 = (0);
        for (; v1362 < (ArrayItems.Length); v1362++)
            v1363.Add((ArrayItems[v1362]));
        v1366 = 0;
        v1367 = 0;
        v1364 = (0);
        for (; v1364 < (ArrayItems2.Length); v1364++)
        {
            v1365 = (ArrayItems2[v1364]);
            if (!(v1363.Remove((v1365))))
                continue;
            v1366 += ((v1365) + 10);
            v1367++;
        }

        if (1 > v1367)
            throw new System.InvalidOperationException("Index out of range");
        return (v1366 / v1367);
    }

    bool ArrayIntersectArrayContains2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1368;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1369;
        int v1370;
        int v1371;
        System.Collections.Generic.EqualityComparer<int> v1372;
        v1369 = new HashSet<int>();
        v1368 = (0);
        for (; v1368 < (ArrayItems.Length); v1368++)
            v1369.Add((ArrayItems[v1368]));
        v1372 = EqualityComparer<int>.Default;
        v1370 = (0);
        for (; v1370 < (ArrayItems2.Length); v1370++)
        {
            v1371 = (ArrayItems2[v1370]);
            if (!(v1369.Remove((v1371))))
                continue;
            if (v1372.Equals((v1371), 56))
                return true;
        }

        return false;
    }

    System.Collections.Generic.IEnumerable<int> SelectWhereArrayIntersectSelectWhereArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v1373;
        int v1374;
        v1373 = (0);
        for (; v1373 < (ArrayItems2.Length); v1373++)
        {
            v1374 = (((ArrayItems2[v1373]) + 10));
            if (!(((v1374) > 80)))
                continue;
            yield return (v1374);
        }

        yield break;
    }

    bool SelectWhereArrayIntersectSelectWhereArrayContainsRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1375;
        int v1376;
        if (SelectWhereArrayIntersectSelectWhereArrayContainsRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1377;
        IEnumerator<int> v1378;
        v1378 = SelectWhereArrayIntersectSelectWhereArrayContainsRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v1377 = new HashSet<int>();
        v1375 = (0);
        for (; v1375 < (ArrayItems.Length); v1375++)
        {
            v1376 = (10 + ArrayItems[v1375]);
            if (!(((v1376) > 80)))
                continue;
            v1377.Add((v1376));
        }

        try
        {
            while (v1378.MoveNext())
            {
                v1376 = (v1378.Current);
                if (!(v1377.Remove((v1376))))
                    continue;
                if ((v1376) == 112)
                    return true;
            }
        }
        finally
        {
            v1378.Dispose();
        }

        return false;
    }

    System.Collections.Generic.IEnumerable<int> RangeIntersectArrayRewritten_ProceduralLinq1()
    {
        int v1379;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1380;
        int v1381;
        int v1382;
        v1380 = new HashSet<int>();
        v1379 = (0);
        for (; v1379 < (100); v1379++)
            v1380.Add((20 + v1379));
        v1381 = (0);
        for (; v1381 < (ArrayItems2.Length); v1381++)
        {
            v1382 = (ArrayItems2[v1381]);
            if (!(v1380.Remove((v1382))))
                continue;
            yield return (v1382);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RepeatIntersectArrayRewritten_ProceduralLinq1()
    {
        int v1383;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1384;
        int v1385;
        int v1386;
        v1384 = new HashSet<int>();
        v1383 = (0);
        for (; v1383 < (100); v1383++)
            v1384.Add((20));
        v1385 = (0);
        for (; v1385 < (ArrayItems2.Length); v1385++)
        {
            v1386 = (ArrayItems2[v1385]);
            if (!(v1384.Remove((v1386))))
                continue;
            yield return (v1386);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EmptyIntersectArrayRewritten_ProceduralLinq1()
    {
        int v1387;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1388;
        int v1389;
        int v1390;
        v1387 = 0;
        v1388 = new HashSet<int>();
        v1389 = (0);
        for (; v1389 < (ArrayItems2.Length); v1389++)
        {
            v1390 = (ArrayItems2[v1389]);
            if (!(v1388.Remove((v1390))))
                continue;
            yield return (v1390);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeEmpty2ArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1391;
        int v1392;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1393;
        int v1394;
        v1393 = new HashSet<int>();
        v1391 = (0);
        for (; v1391 < (ArrayItems.Length); v1391++)
        {
            v1392 = (ArrayItems[v1391]);
            if (!((false)))
                continue;
            v1393.Add((v1392));
        }

        v1394 = (0);
        for (; v1394 < (ArrayItems2.Length); v1394++)
        {
            v1392 = (ArrayItems2[v1394]);
            if (!(v1393.Remove((v1392))))
                continue;
            yield return (v1392);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectRangeRewritten_ProceduralLinq1()
    {
        int v1395;
        v1395 = (0);
        for (; v1395 < (260); v1395++)
            yield return (70 + v1395);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectRangeRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1396;
        if (ArrayIntersectRangeRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1397;
        IEnumerator<int> v1398;
        int v1399;
        v1398 = ArrayIntersectRangeRewritten_ProceduralLinq1().GetEnumerator();
        v1397 = new HashSet<int>();
        v1396 = (0);
        for (; v1396 < (ArrayItems.Length); v1396++)
            v1397.Add((ArrayItems[v1396]));
        try
        {
            while (v1398.MoveNext())
            {
                v1399 = (v1398.Current);
                if (!(v1397.Remove((v1399))))
                    continue;
                yield return (v1399);
            }
        }
        finally
        {
            v1398.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectRepeatRewritten_ProceduralLinq1()
    {
        int v1400;
        v1400 = (0);
        for (; v1400 < (100); v1400++)
            yield return (70);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectRepeatRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1401;
        if (ArrayIntersectRepeatRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1402;
        IEnumerator<int> v1403;
        int v1404;
        v1403 = ArrayIntersectRepeatRewritten_ProceduralLinq1().GetEnumerator();
        v1402 = new HashSet<int>();
        v1401 = (0);
        for (; v1401 < (ArrayItems.Length); v1401++)
            v1402.Add((ArrayItems[v1401]));
        try
        {
            while (v1403.MoveNext())
            {
                v1404 = (v1403.Current);
                if (!(v1402.Remove((v1404))))
                    continue;
                yield return (v1404);
            }
        }
        finally
        {
            v1403.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectEmptyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1405;
        if (Enumerable.Empty<int>() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1406;
        IEnumerator<int> v1407;
        int v1408;
        v1407 = Enumerable.Empty<int>().GetEnumerator();
        v1406 = new HashSet<int>();
        v1405 = (0);
        for (; v1405 < (ArrayItems.Length); v1405++)
            v1406.Add((ArrayItems[v1405]));
        try
        {
            while (v1407.MoveNext())
            {
                v1408 = (v1407.Current);
                if (!(v1406.Remove((v1408))))
                    continue;
                yield return (v1408);
            }
        }
        finally
        {
            v1407.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectEmpty2Rewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v1409;
        int v1410;
        v1409 = (0);
        for (; v1409 < (ArrayItems2.Length); v1409++)
        {
            v1410 = (ArrayItems2[v1409]);
            if (!((false)))
                continue;
            yield return (v1410);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectEmpty2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1411;
        if (ArrayIntersectEmpty2Rewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1412;
        IEnumerator<int> v1413;
        int v1414;
        v1413 = ArrayIntersectEmpty2Rewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v1412 = new HashSet<int>();
        v1411 = (0);
        for (; v1411 < (ArrayItems.Length); v1411++)
            v1412.Add((ArrayItems[v1411]));
        try
        {
            while (v1413.MoveNext())
            {
                v1414 = (v1413.Current);
                if (!(v1412.Remove((v1414))))
                    continue;
                yield return (v1414);
            }
        }
        finally
        {
            v1413.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectAllRewritten_ProceduralLinq1()
    {
        int v1415;
        v1415 = (0);
        for (; v1415 < (1000); v1415++)
            yield return (v1415);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectAllRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1416;
        if (ArrayIntersectAllRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1417;
        IEnumerator<int> v1418;
        int v1419;
        v1418 = ArrayIntersectAllRewritten_ProceduralLinq1().GetEnumerator();
        v1417 = new HashSet<int>();
        v1416 = (0);
        for (; v1416 < (ArrayItems.Length); v1416++)
            v1417.Add((ArrayItems[v1416]));
        try
        {
            while (v1418.MoveNext())
            {
                v1419 = (v1418.Current);
                if (!(v1417.Remove((v1419))))
                    continue;
                yield return (v1419);
            }
        }
        finally
        {
            v1418.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectNullRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1420;
        throw new System.InvalidOperationException("Invalid null object");
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectArrayIntersectEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1421;
        if (ArrayItems == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1422;
        int v1423;
        int v1424;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1425;
        IEnumerator<int> v1426;
        v1426 = EnumerableItems2.GetEnumerator();
        v1422 = new HashSet<int>();
        v1421 = (0);
        for (; v1421 < (ArrayItems.Length); v1421++)
            v1422.Add((ArrayItems[v1421]));
        v1425 = new HashSet<int>();
        v1423 = (0);
        for (; v1423 < (ArrayItems.Length); v1423++)
        {
            v1424 = (ArrayItems[v1423]);
            if (!(v1422.Remove((v1424))))
                continue;
            v1425.Add((v1424));
        }

        try
        {
            while (v1426.MoveNext())
            {
                v1424 = (v1426.Current);
                if (!(v1425.Remove((v1424))))
                    continue;
                yield return (v1424);
            }
        }
        finally
        {
            v1426.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectArrayIntersectEnumerable2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1427;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1428;
        IEnumerator<int> v1429;
        int v1430;
        v1429 = EnumerableItems2.GetEnumerator();
        v1428 = new HashSet<int>();
        v1427 = (0);
        for (; v1427 < (ArrayItems.Length); v1427++)
            v1428.Add((ArrayItems[v1427]));
        try
        {
            while (v1429.MoveNext())
            {
                v1430 = (v1429.Current);
                if (!(v1428.Remove((v1430))))
                    continue;
                yield return (v1430);
            }
        }
        finally
        {
            v1429.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectArrayIntersectEnumerable2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1431;
        if (ArrayIntersectArrayIntersectEnumerable2Rewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1432;
        IEnumerator<int> v1433;
        int v1434;
        v1433 = ArrayIntersectArrayIntersectEnumerable2Rewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v1432 = new HashSet<int>();
        v1431 = (0);
        for (; v1431 < (ArrayItems.Length); v1431++)
            v1432.Add((ArrayItems[v1431]));
        try
        {
            while (v1433.MoveNext())
            {
                v1434 = (v1433.Current);
                if (!(v1432.Remove((v1434))))
                    continue;
                yield return (v1434);
            }
        }
        finally
        {
            v1433.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctIntersectArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1435;
        HashSet<int> v1436;
        int v1437;
        v1436 = new HashSet<int>();
        v1435 = (0);
        for (; v1435 < (ArrayItems.Length); v1435++)
        {
            v1437 = (ArrayItems[v1435]);
            if (!(v1436.Add((v1437))))
                continue;
            yield return (v1437);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctIntersectArrayDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1438;
        HashSet<int> v1439;
        int v1440;
        if (ArrayDistinctIntersectArrayDistinctRewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1441;
        IEnumerator<int> v1442;
        v1442 = ArrayDistinctIntersectArrayDistinctRewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v1439 = new HashSet<int>();
        v1441 = new HashSet<int>();
        v1438 = (0);
        for (; v1438 < (ArrayItems.Length); v1438++)
        {
            v1440 = (ArrayItems[v1438]);
            if (!(v1439.Add((v1440))))
                continue;
            v1441.Add((v1440));
        }

        try
        {
            while (v1442.MoveNext())
            {
                v1440 = (v1442.Current);
                if (!(v1441.Remove((v1440))))
                    continue;
                yield return (v1440);
            }
        }
        finally
        {
            v1442.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctIntersectArrayDistinctDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1443;
        HashSet<int> v1444;
        int v1445;
        v1444 = new HashSet<int>();
        v1443 = (0);
        for (; v1443 < (ArrayItems.Length); v1443++)
        {
            v1445 = (ArrayItems[v1443]);
            if (!(v1444.Add((v1445))))
                continue;
            yield return (v1445);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctIntersectArrayDistinctDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1446;
        HashSet<int> v1447;
        int v1448;
        if (ArrayDistinctIntersectArrayDistinctDistinctRewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1449;
        IEnumerator<int> v1450;
        HashSet<int> v1451;
        v1450 = ArrayDistinctIntersectArrayDistinctDistinctRewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v1447 = new HashSet<int>();
        v1449 = new HashSet<int>();
        v1446 = (0);
        for (; v1446 < (ArrayItems.Length); v1446++)
        {
            v1448 = (ArrayItems[v1446]);
            if (!(v1447.Add((v1448))))
                continue;
            v1449.Add((v1448));
        }

        v1451 = new HashSet<int>();
        try
        {
            while (v1450.MoveNext())
            {
                v1448 = (v1450.Current);
                if (!(v1449.Remove((v1448))))
                    continue;
                v1448 = (v1448);
                if (!(v1451.Add((v1448))))
                    continue;
                yield return (v1448);
            }
        }
        finally
        {
            v1450.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctIntersectArrayDistinctDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1452;
        HashSet<int> v1453;
        int v1454;
        v1453 = new HashSet<int>(EqualityComparer<int>.Default);
        v1452 = (0);
        for (; v1452 < (ArrayItems.Length); v1452++)
        {
            v1454 = (ArrayItems[v1452]);
            if (!(v1453.Add((v1454))))
                continue;
            yield return (v1454);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctIntersectArrayDistinctDistinct2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1455;
        HashSet<int> v1456;
        int v1457;
        if (ArrayDistinctIntersectArrayDistinctDistinct2Rewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1458;
        IEnumerator<int> v1459;
        HashSet<int> v1460;
        v1459 = ArrayDistinctIntersectArrayDistinctDistinct2Rewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v1456 = new HashSet<int>(EqualityComparer<int>.Default);
        v1458 = new HashSet<int>();
        v1455 = (0);
        for (; v1455 < (ArrayItems.Length); v1455++)
        {
            v1457 = (ArrayItems[v1455]);
            if (!(v1456.Add((v1457))))
                continue;
            v1458.Add((v1457));
        }

        v1460 = new HashSet<int>(EqualityComparer<int>.Default);
        try
        {
            while (v1459.MoveNext())
            {
                v1457 = (v1459.Current);
                if (!(v1458.Remove((v1457))))
                    continue;
                v1457 = (v1457);
                if (!(v1460.Add((v1457))))
                    continue;
                yield return (v1457);
            }
        }
        finally
        {
            v1459.Dispose();
        }

        yield break;
    }
}}