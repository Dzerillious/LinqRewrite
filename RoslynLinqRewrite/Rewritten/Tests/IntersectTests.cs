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
        return ArraySelectIntersectArrayRewritten_ProceduralLinq1(ArrayItems, x => x + 50);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectIntersectArraySelect()
    {
        return ArrayItems.Select(x => x + 50).Intersect(ArrayItems2.Select(x => x + 50));
    } //EndMethod

    public IEnumerable<int> ArraySelectIntersectArraySelectRewritten()
    {
        return ArraySelectIntersectArraySelectRewritten_ProceduralLinq2(ArrayItems, x => x + 50);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayWhereIntersectArrayWhere()
    {
        return ArrayItems.Where(x => x > 50).Intersect(ArrayItems2.Where(x => x > 50));
    } //EndMethod

    public IEnumerable<int> ArrayWhereIntersectArrayWhereRewritten()
    {
        return ArrayWhereIntersectArrayWhereRewritten_ProceduralLinq2(ArrayItems, x => x > 50);
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
        return RangeEmpty2ArrayRewritten_ProceduralLinq1(ArrayItems, x => false);
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
        int v889;
        HashSet<int> v890;
        int v891;
        v890 = new HashSet<int>();
        v889 = 0;
        for (; v889 < ArrayItems.Length; v889++)
            v890.Add(ArrayItems[v889]);
        v891 = 0;
        for (; v891 < ArrayItems2.Length; v891++)
        {
            if (!(v890.Remove(ArrayItems2[v891])))
                continue;
            yield return ArrayItems2[v891];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v892;
        HashSet<int> v893;
        IEnumerator<int> v894;
        int v895;
        v894 = SimpleListItems2.GetEnumerator();
        v893 = new HashSet<int>();
        v892 = 0;
        for (; v892 < ArrayItems.Length; v892++)
            v893.Add(ArrayItems[v892]);
        try
        {
            while (v894.MoveNext())
            {
                v895 = v894.Current;
                if (!(v893.Remove(v895)))
                    continue;
                yield return v895;
            }
        }
        finally
        {
            v894.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v896;
        HashSet<int> v897;
        IEnumerator<int> v898;
        int v899;
        v898 = EnumerableItems2.GetEnumerator();
        v897 = new HashSet<int>();
        v896 = 0;
        for (; v896 < ArrayItems.Length; v896++)
            v897.Add(ArrayItems[v896]);
        try
        {
            while (v898.MoveNext())
            {
                v899 = v898.Current;
                if (!(v897.Remove(v899)))
                    continue;
                yield return v899;
            }
        }
        finally
        {
            v898.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v900;
        HashSet<int> v901;
        IEnumerator<int> v902;
        int v903;
        v902 = MethodEnumerable2().GetEnumerator();
        v901 = new HashSet<int>();
        v900 = 0;
        for (; v900 < ArrayItems.Length; v900++)
            v901.Add(ArrayItems[v900]);
        try
        {
            while (v902.MoveNext())
            {
                v903 = v902.Current;
                if (!(v901.Remove(v903)))
                    continue;
                yield return v903;
            }
        }
        finally
        {
            v902.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> SimpleListIntersectArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v904;
        HashSet<int> v905;
        int v906;
        v904 = SimpleListItems.GetEnumerator();
        v905 = new HashSet<int>();
        try
        {
            while (v904.MoveNext())
                v905.Add(v904.Current);
        }
        finally
        {
            v904.Dispose();
        }

        v906 = 0;
        for (; v906 < ArrayItems2.Length; v906++)
        {
            if (!(v905.Remove(ArrayItems2[v906])))
                continue;
            yield return ArrayItems2[v906];
        }
    }

    System.Collections.Generic.IEnumerable<int> SimpleListIntersectSimpleListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v907;
        HashSet<int> v908;
        IEnumerator<int> v909;
        int v910;
        v907 = SimpleListItems.GetEnumerator();
        v909 = SimpleListItems2.GetEnumerator();
        v908 = new HashSet<int>();
        try
        {
            while (v907.MoveNext())
                v908.Add(v907.Current);
        }
        finally
        {
            v907.Dispose();
        }

        try
        {
            while (v909.MoveNext())
            {
                v910 = v909.Current;
                if (!(v908.Remove(v910)))
                    continue;
                yield return v910;
            }
        }
        finally
        {
            v909.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> SimpleListIntersectEnumerableRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v911;
        HashSet<int> v912;
        IEnumerator<int> v913;
        int v914;
        v911 = SimpleListItems.GetEnumerator();
        v913 = EnumerableItems2.GetEnumerator();
        v912 = new HashSet<int>();
        try
        {
            while (v911.MoveNext())
                v912.Add(v911.Current);
        }
        finally
        {
            v911.Dispose();
        }

        try
        {
            while (v913.MoveNext())
            {
                v914 = v913.Current;
                if (!(v912.Remove(v914)))
                    continue;
                yield return v914;
            }
        }
        finally
        {
            v913.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> SimpleListIntersectMethodRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v915;
        HashSet<int> v916;
        IEnumerator<int> v917;
        int v918;
        v915 = SimpleListItems.GetEnumerator();
        v917 = MethodEnumerable2().GetEnumerator();
        v916 = new HashSet<int>();
        try
        {
            while (v915.MoveNext())
                v916.Add(v915.Current);
        }
        finally
        {
            v915.Dispose();
        }

        try
        {
            while (v917.MoveNext())
            {
                v918 = v917.Current;
                if (!(v916.Remove(v918)))
                    continue;
                yield return v918;
            }
        }
        finally
        {
            v917.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableIntersectArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v919;
        HashSet<int> v920;
        int v921;
        v919 = EnumerableItems.GetEnumerator();
        v920 = new HashSet<int>();
        try
        {
            while (v919.MoveNext())
                v920.Add(v919.Current);
        }
        finally
        {
            v919.Dispose();
        }

        v921 = 0;
        for (; v921 < ArrayItems2.Length; v921++)
        {
            if (!(v920.Remove(ArrayItems2[v921])))
                continue;
            yield return ArrayItems2[v921];
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableIntersectSimpleListRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v922;
        HashSet<int> v923;
        IEnumerator<int> v924;
        int v925;
        v922 = EnumerableItems.GetEnumerator();
        v924 = SimpleListItems2.GetEnumerator();
        v923 = new HashSet<int>();
        try
        {
            while (v922.MoveNext())
                v923.Add(v922.Current);
        }
        finally
        {
            v922.Dispose();
        }

        try
        {
            while (v924.MoveNext())
            {
                v925 = v924.Current;
                if (!(v923.Remove(v925)))
                    continue;
                yield return v925;
            }
        }
        finally
        {
            v924.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableIntersectEnumerableRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v926;
        HashSet<int> v927;
        IEnumerator<int> v928;
        int v929;
        v926 = EnumerableItems.GetEnumerator();
        v928 = EnumerableItems2.GetEnumerator();
        v927 = new HashSet<int>();
        try
        {
            while (v926.MoveNext())
                v927.Add(v926.Current);
        }
        finally
        {
            v926.Dispose();
        }

        try
        {
            while (v928.MoveNext())
            {
                v929 = v928.Current;
                if (!(v927.Remove(v929)))
                    continue;
                yield return v929;
            }
        }
        finally
        {
            v928.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableIntersectMethodRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v930;
        HashSet<int> v931;
        IEnumerator<int> v932;
        int v933;
        v930 = EnumerableItems.GetEnumerator();
        v932 = MethodEnumerable2().GetEnumerator();
        v931 = new HashSet<int>();
        try
        {
            while (v930.MoveNext())
                v931.Add(v930.Current);
        }
        finally
        {
            v930.Dispose();
        }

        try
        {
            while (v932.MoveNext())
            {
                v933 = v932.Current;
                if (!(v931.Remove(v933)))
                    continue;
                yield return v933;
            }
        }
        finally
        {
            v932.Dispose();
        }
    }

    int[] ArrayIntersectArrayToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v934;
        HashSet<int> v935;
        int v936;
        int v937;
        int v938;
        int v939;
        int[] v940;
        v935 = new HashSet<int>();
        v934 = 0;
        for (; v934 < ArrayItems.Length; v934++)
            v935.Add(ArrayItems[v934]);
        v937 = 0;
        v938 = (LinqRewrite.Core.IntExtensions.Log2((uint)(ArrayItems2.Length + ArrayItems.Length)) - 3);
        v938 -= (v938 % 2);
        v939 = 8;
        v940 = new int[8];
        v936 = 0;
        for (; v936 < ArrayItems2.Length; v936++)
        {
            if (!(v935.Remove(ArrayItems2[v936])))
                continue;
            if (v937 >= v939)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems2.Length + ArrayItems.Length), ref v940, ref v938, out v939);
            v940[v937] = ArrayItems2[v936];
            v937++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v940, v937);
    }

    int[] ArrayIntersectSimpleListToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v941;
        HashSet<int> v942;
        IEnumerator<int> v943;
        int v944;
        int v945;
        int v946;
        int[] v947;
        v943 = SimpleListItems2.GetEnumerator();
        v942 = new HashSet<int>();
        v941 = 0;
        for (; v941 < ArrayItems.Length; v941++)
            v942.Add(ArrayItems[v941]);
        v945 = 0;
        v946 = 8;
        v947 = new int[8];
        try
        {
            while (v943.MoveNext())
            {
                v944 = v943.Current;
                if (!(v942.Remove(v944)))
                    continue;
                if (v945 >= v946)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v947, ref v946);
                v947[v945] = v944;
                v945++;
            }
        }
        finally
        {
            v943.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v947, v945);
    }

    int[] ArrayIntersectEnumerableToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v948;
        HashSet<int> v949;
        IEnumerator<int> v950;
        int v951;
        int v952;
        int v953;
        int[] v954;
        v950 = EnumerableItems2.GetEnumerator();
        v949 = new HashSet<int>();
        v948 = 0;
        for (; v948 < ArrayItems.Length; v948++)
            v949.Add(ArrayItems[v948]);
        v952 = 0;
        v953 = 8;
        v954 = new int[8];
        try
        {
            while (v950.MoveNext())
            {
                v951 = v950.Current;
                if (!(v949.Remove(v951)))
                    continue;
                if (v952 >= v953)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v954, ref v953);
                v954[v952] = v951;
                v952++;
            }
        }
        finally
        {
            v950.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v954, v952);
    }

    int[] SimpleListIntersectArrayToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v955;
        HashSet<int> v956;
        int v957;
        int v958;
        int v959;
        int[] v960;
        v955 = SimpleListItems.GetEnumerator();
        v956 = new HashSet<int>();
        try
        {
            while (v955.MoveNext())
                v956.Add(v955.Current);
        }
        finally
        {
            v955.Dispose();
        }

        v958 = 0;
        v959 = 8;
        v960 = new int[8];
        v957 = 0;
        for (; v957 < ArrayItems2.Length; v957++)
        {
            if (!(v956.Remove(ArrayItems2[v957])))
                continue;
            if (v958 >= v959)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v960, ref v959);
            v960[v958] = ArrayItems2[v957];
            v958++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v960, v958);
    }

    int[] SimpleListIntersectSimpleListToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v961;
        HashSet<int> v962;
        IEnumerator<int> v963;
        int v964;
        int v965;
        int v966;
        int[] v967;
        v961 = SimpleListItems.GetEnumerator();
        v963 = SimpleListItems2.GetEnumerator();
        v962 = new HashSet<int>();
        try
        {
            while (v961.MoveNext())
                v962.Add(v961.Current);
        }
        finally
        {
            v961.Dispose();
        }

        v965 = 0;
        v966 = 8;
        v967 = new int[8];
        try
        {
            while (v963.MoveNext())
            {
                v964 = v963.Current;
                if (!(v962.Remove(v964)))
                    continue;
                if (v965 >= v966)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v967, ref v966);
                v967[v965] = v964;
                v965++;
            }
        }
        finally
        {
            v963.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v967, v965);
    }

    int[] SimpleListIntersectEnumerableToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v968;
        HashSet<int> v969;
        IEnumerator<int> v970;
        int v971;
        int v972;
        int v973;
        int[] v974;
        v968 = SimpleListItems.GetEnumerator();
        v970 = EnumerableItems2.GetEnumerator();
        v969 = new HashSet<int>();
        try
        {
            while (v968.MoveNext())
                v969.Add(v968.Current);
        }
        finally
        {
            v968.Dispose();
        }

        v972 = 0;
        v973 = 8;
        v974 = new int[8];
        try
        {
            while (v970.MoveNext())
            {
                v971 = v970.Current;
                if (!(v969.Remove(v971)))
                    continue;
                if (v972 >= v973)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v974, ref v973);
                v974[v972] = v971;
                v972++;
            }
        }
        finally
        {
            v970.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v974, v972);
    }

    int[] EnumerableIntersectArrayToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v975;
        HashSet<int> v976;
        int v977;
        int v978;
        int v979;
        int[] v980;
        v975 = EnumerableItems.GetEnumerator();
        v976 = new HashSet<int>();
        try
        {
            while (v975.MoveNext())
                v976.Add(v975.Current);
        }
        finally
        {
            v975.Dispose();
        }

        v978 = 0;
        v979 = 8;
        v980 = new int[8];
        v977 = 0;
        for (; v977 < ArrayItems2.Length; v977++)
        {
            if (!(v976.Remove(ArrayItems2[v977])))
                continue;
            if (v978 >= v979)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v980, ref v979);
            v980[v978] = ArrayItems2[v977];
            v978++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v980, v978);
    }

    int[] EnumerableIntersectSimpleListToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v981;
        HashSet<int> v982;
        IEnumerator<int> v983;
        int v984;
        int v985;
        int v986;
        int[] v987;
        v981 = EnumerableItems.GetEnumerator();
        v983 = SimpleListItems2.GetEnumerator();
        v982 = new HashSet<int>();
        try
        {
            while (v981.MoveNext())
                v982.Add(v981.Current);
        }
        finally
        {
            v981.Dispose();
        }

        v985 = 0;
        v986 = 8;
        v987 = new int[8];
        try
        {
            while (v983.MoveNext())
            {
                v984 = v983.Current;
                if (!(v982.Remove(v984)))
                    continue;
                if (v985 >= v986)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v987, ref v986);
                v987[v985] = v984;
                v985++;
            }
        }
        finally
        {
            v983.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v987, v985);
    }

    int[] EnumerableIntersectEnumerableToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v988;
        HashSet<int> v989;
        IEnumerator<int> v990;
        int v991;
        int v992;
        int v993;
        int[] v994;
        v988 = EnumerableItems.GetEnumerator();
        v990 = EnumerableItems2.GetEnumerator();
        v989 = new HashSet<int>();
        try
        {
            while (v988.MoveNext())
                v989.Add(v988.Current);
        }
        finally
        {
            v988.Dispose();
        }

        v992 = 0;
        v993 = 8;
        v994 = new int[8];
        try
        {
            while (v990.MoveNext())
            {
                v991 = v990.Current;
                if (!(v989.Remove(v991)))
                    continue;
                if (v992 >= v993)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v994, ref v993);
                v994[v992] = v991;
                v992++;
            }
        }
        finally
        {
            v990.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v994, v992);
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectIntersectArrayRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int> v996)
    {
        int v995;
        HashSet<int> v997;
        int v998;
        v997 = new HashSet<int>();
        v995 = 0;
        for (; v995 < ArrayItems.Length; v995++)
            v997.Add(v996(ArrayItems[v995]));
        v998 = 0;
        for (; v998 < ArrayItems2.Length; v998++)
        {
            if (!(v997.Remove(ArrayItems2[v998])))
                continue;
            yield return ArrayItems2[v998];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectIntersectArraySelectRewritten_ProceduralLinq1(int[] ArrayItems2, System.Func<int, int> v1000)
    {
        int v999;
        v999 = 0;
        for (; v999 < ArrayItems2.Length; v999++)
            yield return v1000(ArrayItems2[v999]);
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectIntersectArraySelectRewritten_ProceduralLinq2(int[] ArrayItems, System.Func<int, int> v1002)
    {
        int v1001;
        HashSet<int> v1003;
        IEnumerator<int> v1004;
        int v1005;
        v1004 = ArraySelectIntersectArraySelectRewritten_ProceduralLinq1(ArrayItems2, x => x + 50).GetEnumerator();
        v1003 = new HashSet<int>();
        v1001 = 0;
        for (; v1001 < ArrayItems.Length; v1001++)
            v1003.Add(v1002(ArrayItems[v1001]));
        try
        {
            while (v1004.MoveNext())
            {
                v1005 = v1004.Current;
                if (!(v1003.Remove(v1005)))
                    continue;
                yield return v1005;
            }
        }
        finally
        {
            v1004.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereIntersectArrayWhereRewritten_ProceduralLinq1(int[] ArrayItems2, System.Func<int, bool> v1007)
    {
        int v1006;
        v1006 = 0;
        for (; v1006 < ArrayItems2.Length; v1006++)
        {
            if (!(v1007(ArrayItems2[v1006])))
                continue;
            yield return ArrayItems2[v1006];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereIntersectArrayWhereRewritten_ProceduralLinq2(int[] ArrayItems, System.Func<int, bool> v1009)
    {
        int v1008;
        HashSet<int> v1010;
        IEnumerator<int> v1011;
        v1011 = ArrayWhereIntersectArrayWhereRewritten_ProceduralLinq1(ArrayItems2, x => x > 50).GetEnumerator();
        v1010 = new HashSet<int>();
        v1008 = 0;
        for (; v1008 < ArrayItems.Length; v1008++)
        {
            if (!(v1009(ArrayItems[v1008])))
                continue;
            v1010.Add(ArrayItems[v1008]);
        }

        try
        {
            while (v1011.MoveNext())
            {
                v1008 = v1011.Current;
                if (!(v1010.Remove(v1008)))
                    continue;
                yield return v1008;
            }
        }
        finally
        {
            v1011.Dispose();
        }
    }

    int ArrayIntersectArrayCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1012;
        HashSet<int> v1013;
        int v1014;
        int v1015;
        v1013 = new HashSet<int>();
        v1012 = 0;
        for (; v1012 < ArrayItems.Length; v1012++)
            v1013.Add(ArrayItems[v1012]);
        v1015 = 0;
        v1014 = 0;
        for (; v1014 < ArrayItems2.Length; v1014++)
        {
            if (!(v1013.Remove(ArrayItems2[v1014])))
                continue;
            v1015++;
        }

        return v1015;
    }

    int ArrayIntersectArrayCount2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1016;
        HashSet<int> v1017;
        int v1018;
        int v1019;
        v1017 = new HashSet<int>();
        v1016 = 0;
        for (; v1016 < ArrayItems.Length; v1016++)
            v1017.Add(ArrayItems[v1016]);
        v1019 = 0;
        v1018 = 0;
        for (; v1018 < ArrayItems2.Length; v1018++)
        {
            if (!(v1017.Remove(ArrayItems2[v1018])))
                continue;
            if (!((ArrayItems2[v1018] > 70)))
                continue;
            v1019++;
        }

        return v1019;
    }

    int ArrayIntersectArraySumRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1020;
        HashSet<int> v1021;
        int v1022;
        int v1023;
        v1021 = new HashSet<int>();
        v1020 = 0;
        for (; v1020 < ArrayItems.Length; v1020++)
            v1021.Add(ArrayItems[v1020]);
        v1023 = 0;
        v1022 = 0;
        for (; v1022 < ArrayItems2.Length; v1022++)
        {
            if (!(v1021.Remove(ArrayItems2[v1022])))
                continue;
            v1023 += ArrayItems2[v1022];
        }

        return v1023;
    }

    int ArrayIntersectArraySum2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1024;
        HashSet<int> v1025;
        int v1026;
        int v1027;
        int v1028;
        v1025 = new HashSet<int>();
        v1024 = 0;
        for (; v1024 < ArrayItems.Length; v1024++)
            v1025.Add(ArrayItems[v1024]);
        v1027 = 0;
        v1026 = 0;
        for (; v1026 < ArrayItems2.Length; v1026++)
        {
            if (!(v1025.Remove(ArrayItems2[v1026])))
                continue;
            v1028 = (ArrayItems2[v1026] + 10);
            v1027 += v1028;
        }

        return v1027;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1029;
        HashSet<int> v1030;
        int v1031;
        HashSet<int> v1032;
        v1030 = new HashSet<int>();
        v1029 = 0;
        for (; v1029 < ArrayItems.Length; v1029++)
            v1030.Add(ArrayItems[v1029]);
        v1032 = new HashSet<int>();
        v1031 = 0;
        for (; v1031 < ArrayItems2.Length; v1031++)
        {
            if (!(v1030.Remove(ArrayItems2[v1031])))
                continue;
            if (!(v1032.Add(ArrayItems2[v1031])))
                continue;
            yield return ArrayItems2[v1031];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectArrayDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1033;
        HashSet<int> v1034;
        int v1035;
        HashSet<int> v1036;
        v1034 = new HashSet<int>();
        v1033 = 0;
        for (; v1033 < ArrayItems.Length; v1033++)
            v1034.Add(ArrayItems[v1033]);
        v1036 = new HashSet<int>(EqualityComparer<int>.Default);
        v1035 = 0;
        for (; v1035 < ArrayItems2.Length; v1035++)
        {
            if (!(v1034.Remove(ArrayItems2[v1035])))
                continue;
            if (!(v1036.Add(ArrayItems2[v1035])))
                continue;
            yield return ArrayItems2[v1035];
        }
    }

    int ArrayIntersectArrayElementAtRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1037;
        HashSet<int> v1038;
        int v1039;
        int v1040;
        v1038 = new HashSet<int>();
        v1037 = 0;
        for (; v1037 < ArrayItems.Length; v1037++)
            v1038.Add(ArrayItems[v1037]);
        v1040 = 0;
        v1039 = 0;
        for (; v1039 < ArrayItems2.Length; v1039++)
        {
            if (!(v1038.Remove(ArrayItems2[v1039])))
                continue;
            if (v1040 == 45)
                return ArrayItems2[v1039];
            v1040++;
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArrayIntersectArrayElementAtOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1041;
        HashSet<int> v1042;
        int v1043;
        int v1044;
        v1042 = new HashSet<int>();
        v1041 = 0;
        for (; v1041 < ArrayItems.Length; v1041++)
            v1042.Add(ArrayItems[v1041]);
        v1044 = 0;
        v1043 = 0;
        for (; v1043 < ArrayItems2.Length; v1043++)
        {
            if (!(v1042.Remove(ArrayItems2[v1043])))
                continue;
            if (v1044 == 45)
                return ArrayItems2[v1043];
            v1044++;
        }

        return default(int);
    }

    int ArrayIntersectArrayFirstRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1045;
        HashSet<int> v1046;
        int v1047;
        v1046 = new HashSet<int>();
        v1045 = 0;
        for (; v1045 < ArrayItems.Length; v1045++)
            v1046.Add(ArrayItems[v1045]);
        v1047 = 0;
        for (; v1047 < ArrayItems2.Length; v1047++)
        {
            if (!(v1046.Remove(ArrayItems2[v1047])))
                continue;
            return ArrayItems2[v1047];
        }

        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int ArrayIntersectArrayFirstOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1048;
        HashSet<int> v1049;
        int v1050;
        v1049 = new HashSet<int>();
        v1048 = 0;
        for (; v1048 < ArrayItems.Length; v1048++)
            v1049.Add(ArrayItems[v1048]);
        v1050 = 0;
        for (; v1050 < ArrayItems2.Length; v1050++)
        {
            if (!(v1049.Remove(ArrayItems2[v1050])))
                continue;
            return ArrayItems2[v1050];
        }

        return default(int);
    }

    int ArrayIntersectArrayLastRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1051;
        HashSet<int> v1052;
        int v1053;
        int? v1054;
        v1052 = new HashSet<int>();
        v1051 = 0;
        for (; v1051 < ArrayItems.Length; v1051++)
            v1052.Add(ArrayItems[v1051]);
        v1054 = null;
        v1053 = 0;
        for (; v1053 < ArrayItems2.Length; v1053++)
        {
            if (!(v1052.Remove(ArrayItems2[v1053])))
                continue;
            v1054 = ArrayItems2[v1053];
        }

        if (v1054 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1054;
    }

    int ArrayIntersectArrayLastOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1055;
        HashSet<int> v1056;
        int v1057;
        int? v1058;
        v1056 = new HashSet<int>();
        v1055 = 0;
        for (; v1055 < ArrayItems.Length; v1055++)
            v1056.Add(ArrayItems[v1055]);
        v1058 = null;
        v1057 = 0;
        for (; v1057 < ArrayItems2.Length; v1057++)
        {
            if (!(v1056.Remove(ArrayItems2[v1057])))
                continue;
            v1058 = ArrayItems2[v1057];
        }

        if (v1058 == null)
            return default(int);
        else
            return (int)v1058;
    }

    int ArrayIntersectArraySingleRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1059;
        HashSet<int> v1060;
        int v1061;
        int? v1062;
        v1060 = new HashSet<int>();
        v1059 = 0;
        for (; v1059 < ArrayItems.Length; v1059++)
            v1060.Add(ArrayItems[v1059]);
        v1062 = null;
        v1061 = 0;
        for (; v1061 < ArrayItems2.Length; v1061++)
        {
            if (!(v1060.Remove(ArrayItems2[v1061])))
                continue;
            if (v1062 == null)
                v1062 = ArrayItems2[v1061];
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v1062 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1062;
    }

    int ArrayIntersectArraySingle2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1063;
        HashSet<int> v1064;
        int v1065;
        int? v1066;
        v1064 = new HashSet<int>();
        v1063 = 0;
        for (; v1063 < ArrayItems.Length; v1063++)
            v1064.Add(ArrayItems[v1063]);
        v1066 = null;
        v1065 = 0;
        for (; v1065 < ArrayItems2.Length; v1065++)
        {
            if (!(v1064.Remove(ArrayItems2[v1065])))
                continue;
            if ((ArrayItems2[v1065] == 76))
                if (v1066 == null)
                    v1066 = ArrayItems2[v1065];
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v1066 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1066;
    }

    int ArrayIntersectArraySingleOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1067;
        HashSet<int> v1068;
        int v1069;
        int? v1070;
        v1068 = new HashSet<int>();
        v1067 = 0;
        for (; v1067 < ArrayItems.Length; v1067++)
            v1068.Add(ArrayItems[v1067]);
        v1070 = null;
        v1069 = 0;
        for (; v1069 < ArrayItems2.Length; v1069++)
        {
            if (!(v1068.Remove(ArrayItems2[v1069])))
                continue;
            if (v1070 == null)
                v1070 = ArrayItems2[v1069];
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v1070 == null)
            return default(int);
        else
            return (int)v1070;
    }

    int ArrayIntersectArrayMinRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1071;
        HashSet<int> v1072;
        int v1073;
        int v1074;
        bool v1075;
        v1072 = new HashSet<int>();
        v1071 = 0;
        for (; v1071 < ArrayItems.Length; v1071++)
            v1072.Add(ArrayItems[v1071]);
        v1074 = 2147483647;
        v1075 = false;
        v1073 = 0;
        for (; v1073 < ArrayItems2.Length; v1073++)
        {
            if (!(v1072.Remove(ArrayItems2[v1073])))
                continue;
            if (ArrayItems2[v1073] >= v1074)
                continue;
            v1074 = ArrayItems2[v1073];
            v1075 = true;
        }

        if (!(v1075))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1074;
    }

    decimal ArrayIntersectArrayMin2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1076;
        HashSet<int> v1077;
        int v1078;
        decimal v1079;
        bool v1080;
        decimal v1081;
        v1077 = new HashSet<int>();
        v1076 = 0;
        for (; v1076 < ArrayItems.Length; v1076++)
            v1077.Add(ArrayItems[v1076]);
        v1079 = 79228162514264337593543950335M;
        v1080 = false;
        v1078 = 0;
        for (; v1078 < ArrayItems2.Length; v1078++)
        {
            if (!(v1077.Remove(ArrayItems2[v1078])))
                continue;
            v1081 = (ArrayItems2[v1078] + 2m);
            if (v1081 >= v1079)
                continue;
            v1079 = v1081;
            v1080 = true;
        }

        if (!(v1080))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1079;
    }

    int ArrayIntersectArrayMaxRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1082;
        HashSet<int> v1083;
        int v1084;
        int v1085;
        bool v1086;
        v1083 = new HashSet<int>();
        v1082 = 0;
        for (; v1082 < ArrayItems.Length; v1082++)
            v1083.Add(ArrayItems[v1082]);
        v1085 = -2147483648;
        v1086 = false;
        v1084 = 0;
        for (; v1084 < ArrayItems2.Length; v1084++)
        {
            if (!(v1083.Remove(ArrayItems2[v1084])))
                continue;
            if (ArrayItems2[v1084] <= v1085)
                continue;
            v1085 = ArrayItems2[v1084];
            v1086 = true;
        }

        if (!(v1086))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1085;
    }

    decimal ArrayIntersectArrayMax2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1087;
        HashSet<int> v1088;
        int v1089;
        decimal v1090;
        bool v1091;
        decimal v1092;
        v1088 = new HashSet<int>();
        v1087 = 0;
        for (; v1087 < ArrayItems.Length; v1087++)
            v1088.Add(ArrayItems[v1087]);
        v1090 = -79228162514264337593543950335M;
        v1091 = false;
        v1089 = 0;
        for (; v1089 < ArrayItems2.Length; v1089++)
        {
            if (!(v1088.Remove(ArrayItems2[v1089])))
                continue;
            v1092 = (ArrayItems2[v1089] + 2m);
            if (v1092 <= v1090)
                continue;
            v1090 = v1092;
            v1091 = true;
        }

        if (!(v1091))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1090;
    }

    long ArrayIntersectArrayLongCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1093;
        HashSet<int> v1094;
        int v1095;
        long v1096;
        v1094 = new HashSet<int>();
        v1093 = 0;
        for (; v1093 < ArrayItems.Length; v1093++)
            v1094.Add(ArrayItems[v1093]);
        v1096 = 0;
        v1095 = 0;
        for (; v1095 < ArrayItems2.Length; v1095++)
        {
            if (!(v1094.Remove(ArrayItems2[v1095])))
                continue;
            v1096++;
        }

        return v1096;
    }

    long ArrayIntersectArrayLongCount2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1097;
        HashSet<int> v1098;
        int v1099;
        long v1100;
        v1098 = new HashSet<int>();
        v1097 = 0;
        for (; v1097 < ArrayItems.Length; v1097++)
            v1098.Add(ArrayItems[v1097]);
        v1100 = 0;
        v1099 = 0;
        for (; v1099 < ArrayItems2.Length; v1099++)
        {
            if (!(v1098.Remove(ArrayItems2[v1099])))
                continue;
            if (!((ArrayItems2[v1099] > 50)))
                continue;
            v1100++;
        }

        return v1100;
    }

    bool ArrayIntersectArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1101;
        HashSet<int> v1102;
        int v1103;
        v1102 = new HashSet<int>();
        v1101 = 0;
        for (; v1101 < ArrayItems.Length; v1101++)
            v1102.Add(ArrayItems[v1101]);
        v1103 = 0;
        for (; v1103 < ArrayItems2.Length; v1103++)
        {
            if (!(v1102.Remove(ArrayItems2[v1103])))
                continue;
            if (ArrayItems2[v1103] == 56)
                return true;
        }

        return false;
    }

    double ArrayIntersectArrayAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1104;
        HashSet<int> v1105;
        int v1106;
        double v1107;
        int v1108;
        v1105 = new HashSet<int>();
        v1104 = 0;
        for (; v1104 < ArrayItems.Length; v1104++)
            v1105.Add(ArrayItems[v1104]);
        v1107 = 0;
        v1108 = 0;
        v1106 = 0;
        for (; v1106 < ArrayItems2.Length; v1106++)
        {
            if (!(v1105.Remove(ArrayItems2[v1106])))
                continue;
            v1107 += ArrayItems2[v1106];
            v1108++;
        }

        if (v1108 == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v1107 / v1108);
    }

    double ArrayIntersectArrayAverage2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1109;
        HashSet<int> v1110;
        int v1111;
        double v1112;
        int v1113;
        v1110 = new HashSet<int>();
        v1109 = 0;
        for (; v1109 < ArrayItems.Length; v1109++)
            v1110.Add(ArrayItems[v1109]);
        v1112 = 0;
        v1113 = 0;
        v1111 = 0;
        for (; v1111 < ArrayItems2.Length; v1111++)
        {
            if (!(v1110.Remove(ArrayItems2[v1111])))
                continue;
            v1112 += (ArrayItems2[v1111] + 10);
            v1113++;
        }

        if (v1113 == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v1112 / v1113);
    }

    bool ArrayIntersectArrayContains2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1114;
        HashSet<int> v1115;
        int v1116;
        System.Collections.Generic.EqualityComparer<int> v1117;
        v1115 = new HashSet<int>();
        v1114 = 0;
        for (; v1114 < ArrayItems.Length; v1114++)
            v1115.Add(ArrayItems[v1114]);
        v1117 = EqualityComparer<int>.Default;
        v1116 = 0;
        for (; v1116 < ArrayItems2.Length; v1116++)
        {
            if (!(v1115.Remove(ArrayItems2[v1116])))
                continue;
            if (v1117.Equals(ArrayItems2[v1116], 56))
                return true;
        }

        return false;
    }

    System.Collections.Generic.IEnumerable<int> SelectWhereArrayIntersectSelectWhereArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems2, System.Func<int, int> v1119, System.Func<int, bool> v1121)
    {
        int v1118;
        int v1120;
        v1118 = 0;
        for (; v1118 < ArrayItems2.Length; v1118++)
        {
            v1120 = v1119(ArrayItems2[v1118]);
            if (!(v1121(v1120)))
                continue;
            yield return v1120;
        }
    }

    bool SelectWhereArrayIntersectSelectWhereArrayContainsRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1122;
        int v1123;
        HashSet<int> v1124;
        IEnumerator<int> v1125;
        v1125 = SelectWhereArrayIntersectSelectWhereArrayContainsRewritten_ProceduralLinq1(ArrayItems2, x => x + 10, x => x > 80).GetEnumerator();
        v1124 = new HashSet<int>();
        v1122 = 0;
        for (; v1122 < ArrayItems.Length; v1122++)
        {
            v1123 = (ArrayItems[v1122] + 10);
            if (!((v1123 > 80)))
                continue;
            v1124.Add(v1123);
        }

        try
        {
            while (v1125.MoveNext())
            {
                v1122 = v1125.Current;
                if (!(v1124.Remove(v1122)))
                    continue;
                if (v1122 == 112)
                    return true;
            }
        }
        finally
        {
            v1125.Dispose();
        }

        return false;
    }

    System.Collections.Generic.IEnumerable<int> RangeIntersectArrayRewritten_ProceduralLinq1()
    {
        int v1126;
        if (100 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        HashSet<int> v1127;
        int v1128;
        v1127 = new HashSet<int>();
        v1126 = 0;
        for (; v1126 < 100; v1126++)
            v1127.Add((v1126 + 20));
        v1128 = 0;
        for (; v1128 < ArrayItems2.Length; v1128++)
        {
            if (!(v1127.Remove(ArrayItems2[v1128])))
                continue;
            yield return ArrayItems2[v1128];
        }
    }

    System.Collections.Generic.IEnumerable<int> RepeatIntersectArrayRewritten_ProceduralLinq1()
    {
        int v1129;
        if (100 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        HashSet<int> v1130;
        int v1131;
        v1130 = new HashSet<int>();
        v1129 = 0;
        for (; v1129 < 100; v1129++)
            v1130.Add(20);
        v1131 = 0;
        for (; v1131 < ArrayItems2.Length; v1131++)
        {
            if (!(v1130.Remove(ArrayItems2[v1131])))
                continue;
            yield return ArrayItems2[v1131];
        }
    }

    System.Collections.Generic.IEnumerable<int> EmptyIntersectArrayRewritten_ProceduralLinq1()
    {
        int v1132;
        HashSet<int> v1133;
        int v1134;
        v1133 = new HashSet<int>();
        v1132 = 0;
        for (; v1132 < 0; v1132++)
            v1133.Add(default(int));
        v1134 = 0;
        for (; v1134 < ArrayItems2.Length; v1134++)
        {
            if (!(v1133.Remove(ArrayItems2[v1134])))
                continue;
            yield return ArrayItems2[v1134];
        }
    }

    System.Collections.Generic.IEnumerable<int> RangeEmpty2ArrayRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, bool> v1136)
    {
        int v1135;
        HashSet<int> v1137;
        v1137 = new HashSet<int>();
        v1135 = 0;
        for (; v1135 < ArrayItems.Length; v1135++)
        {
            if (!(v1136(ArrayItems[v1135])))
                continue;
            v1137.Add(ArrayItems[v1135]);
        }

        v1135 = 0;
        for (; v1135 < ArrayItems2.Length; v1135++)
        {
            if (!(v1137.Remove(ArrayItems2[v1135])))
                continue;
            yield return ArrayItems2[v1135];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectRangeRewritten_ProceduralLinq1()
    {
        int v1138;
        if (260 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        v1138 = 0;
        for (; v1138 < 260; v1138++)
            yield return (v1138 + 70);
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectRangeRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1139;
        HashSet<int> v1140;
        IEnumerator<int> v1141;
        int v1142;
        v1141 = ArrayIntersectRangeRewritten_ProceduralLinq1().GetEnumerator();
        v1140 = new HashSet<int>();
        v1139 = 0;
        for (; v1139 < ArrayItems.Length; v1139++)
            v1140.Add(ArrayItems[v1139]);
        try
        {
            while (v1141.MoveNext())
            {
                v1142 = v1141.Current;
                if (!(v1140.Remove(v1142)))
                    continue;
                yield return v1142;
            }
        }
        finally
        {
            v1141.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectRepeatRewritten_ProceduralLinq1()
    {
        int v1143;
        if (100 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        v1143 = 0;
        for (; v1143 < 100; v1143++)
            yield return 70;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectRepeatRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1144;
        HashSet<int> v1145;
        IEnumerator<int> v1146;
        int v1147;
        v1146 = ArrayIntersectRepeatRewritten_ProceduralLinq1().GetEnumerator();
        v1145 = new HashSet<int>();
        v1144 = 0;
        for (; v1144 < ArrayItems.Length; v1144++)
            v1145.Add(ArrayItems[v1144]);
        try
        {
            while (v1146.MoveNext())
            {
                v1147 = v1146.Current;
                if (!(v1145.Remove(v1147)))
                    continue;
                yield return v1147;
            }
        }
        finally
        {
            v1146.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectEmptyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1148;
        HashSet<int> v1149;
        IEnumerator<int> v1150;
        int v1151;
        v1150 = Enumerable.Empty<int>().GetEnumerator();
        v1149 = new HashSet<int>();
        v1148 = 0;
        for (; v1148 < ArrayItems.Length; v1148++)
            v1149.Add(ArrayItems[v1148]);
        try
        {
            while (v1150.MoveNext())
            {
                v1151 = v1150.Current;
                if (!(v1149.Remove(v1151)))
                    continue;
                yield return v1151;
            }
        }
        finally
        {
            v1150.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectEmpty2Rewritten_ProceduralLinq1(int[] ArrayItems2, System.Func<int, bool> v1153)
    {
        int v1152;
        v1152 = 0;
        for (; v1152 < ArrayItems2.Length; v1152++)
        {
            if (!(v1153(ArrayItems2[v1152])))
                continue;
            yield return ArrayItems2[v1152];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectEmpty2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1154;
        HashSet<int> v1155;
        IEnumerator<int> v1156;
        int v1157;
        v1156 = ArrayIntersectEmpty2Rewritten_ProceduralLinq1(ArrayItems2, x => false).GetEnumerator();
        v1155 = new HashSet<int>();
        v1154 = 0;
        for (; v1154 < ArrayItems.Length; v1154++)
            v1155.Add(ArrayItems[v1154]);
        try
        {
            while (v1156.MoveNext())
            {
                v1157 = v1156.Current;
                if (!(v1155.Remove(v1157)))
                    continue;
                yield return v1157;
            }
        }
        finally
        {
            v1156.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectAllRewritten_ProceduralLinq1()
    {
        int v1158;
        if (1000 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        v1158 = 0;
        for (; v1158 < 1000; v1158++)
            yield return (v1158 + 0);
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectAllRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1159;
        HashSet<int> v1160;
        IEnumerator<int> v1161;
        int v1162;
        v1161 = ArrayIntersectAllRewritten_ProceduralLinq1().GetEnumerator();
        v1160 = new HashSet<int>();
        v1159 = 0;
        for (; v1159 < ArrayItems.Length; v1159++)
            v1160.Add(ArrayItems[v1159]);
        try
        {
            while (v1161.MoveNext())
            {
                v1162 = v1161.Current;
                if (!(v1160.Remove(v1162)))
                    continue;
                yield return v1162;
            }
        }
        finally
        {
            v1161.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectNullRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1163;
        throw new System.InvalidOperationException("Collection was null");
        v1163 = 0;
        for (; v1163 < ArrayItems.Length; v1163++)
            yield return ArrayItems[v1163];
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectArrayIntersectEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1164;
        HashSet<int> v1165;
        int v1166;
        HashSet<int> v1167;
        IEnumerator<int> v1168;
        v1168 = EnumerableItems2.GetEnumerator();
        v1165 = new HashSet<int>();
        v1164 = 0;
        for (; v1164 < ArrayItems.Length; v1164++)
            v1165.Add(ArrayItems[v1164]);
        v1167 = new HashSet<int>();
        v1166 = 0;
        for (; v1166 < ArrayItems.Length; v1166++)
        {
            if (!(v1165.Remove(ArrayItems[v1166])))
                continue;
            v1167.Add(ArrayItems[v1166]);
        }

        try
        {
            while (v1168.MoveNext())
            {
                v1166 = v1168.Current;
                if (!(v1167.Remove(v1166)))
                    continue;
                yield return v1166;
            }
        }
        finally
        {
            v1168.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectArrayIntersectEnumerable2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1169;
        HashSet<int> v1170;
        IEnumerator<int> v1171;
        int v1172;
        v1171 = EnumerableItems2.GetEnumerator();
        v1170 = new HashSet<int>();
        v1169 = 0;
        for (; v1169 < ArrayItems.Length; v1169++)
            v1170.Add(ArrayItems[v1169]);
        try
        {
            while (v1171.MoveNext())
            {
                v1172 = v1171.Current;
                if (!(v1170.Remove(v1172)))
                    continue;
                yield return v1172;
            }
        }
        finally
        {
            v1171.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectArrayIntersectEnumerable2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1173;
        HashSet<int> v1174;
        IEnumerator<int> v1175;
        int v1176;
        v1175 = ArrayIntersectArrayIntersectEnumerable2Rewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v1174 = new HashSet<int>();
        v1173 = 0;
        for (; v1173 < ArrayItems.Length; v1173++)
            v1174.Add(ArrayItems[v1173]);
        try
        {
            while (v1175.MoveNext())
            {
                v1176 = v1175.Current;
                if (!(v1174.Remove(v1176)))
                    continue;
                yield return v1176;
            }
        }
        finally
        {
            v1175.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctIntersectArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1177;
        HashSet<int> v1178;
        v1178 = new HashSet<int>();
        v1177 = 0;
        for (; v1177 < ArrayItems.Length; v1177++)
        {
            if (!(v1178.Add(ArrayItems[v1177])))
                continue;
            yield return ArrayItems[v1177];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctIntersectArrayDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1179;
        HashSet<int> v1180;
        HashSet<int> v1181;
        IEnumerator<int> v1182;
        v1182 = ArrayDistinctIntersectArrayDistinctRewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v1180 = new HashSet<int>();
        v1181 = new HashSet<int>();
        v1179 = 0;
        for (; v1179 < ArrayItems.Length; v1179++)
        {
            if (!(v1180.Add(ArrayItems[v1179])))
                continue;
            v1181.Add(ArrayItems[v1179]);
        }

        try
        {
            while (v1182.MoveNext())
            {
                v1179 = v1182.Current;
                if (!(v1181.Remove(v1179)))
                    continue;
                yield return v1179;
            }
        }
        finally
        {
            v1182.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctIntersectArrayDistinctDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1183;
        HashSet<int> v1184;
        v1184 = new HashSet<int>();
        v1183 = 0;
        for (; v1183 < ArrayItems.Length; v1183++)
        {
            if (!(v1184.Add(ArrayItems[v1183])))
                continue;
            yield return ArrayItems[v1183];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctIntersectArrayDistinctDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1185;
        HashSet<int> v1186;
        HashSet<int> v1187;
        IEnumerator<int> v1188;
        HashSet<int> v1189;
        v1188 = ArrayDistinctIntersectArrayDistinctDistinctRewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v1186 = new HashSet<int>();
        v1187 = new HashSet<int>();
        v1185 = 0;
        for (; v1185 < ArrayItems.Length; v1185++)
        {
            if (!(v1186.Add(ArrayItems[v1185])))
                continue;
            v1187.Add(ArrayItems[v1185]);
        }

        v1189 = new HashSet<int>();
        try
        {
            while (v1188.MoveNext())
            {
                v1185 = v1188.Current;
                if (!(v1187.Remove(v1185)))
                    continue;
                if (!(v1189.Add(v1185)))
                    continue;
                yield return v1185;
            }
        }
        finally
        {
            v1188.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctIntersectArrayDistinctDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1190;
        HashSet<int> v1191;
        v1191 = new HashSet<int>(EqualityComparer<int>.Default);
        v1190 = 0;
        for (; v1190 < ArrayItems.Length; v1190++)
        {
            if (!(v1191.Add(ArrayItems[v1190])))
                continue;
            yield return ArrayItems[v1190];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctIntersectArrayDistinctDistinct2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1192;
        HashSet<int> v1193;
        HashSet<int> v1194;
        IEnumerator<int> v1195;
        HashSet<int> v1196;
        v1195 = ArrayDistinctIntersectArrayDistinctDistinct2Rewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v1193 = new HashSet<int>(EqualityComparer<int>.Default);
        v1194 = new HashSet<int>();
        v1192 = 0;
        for (; v1192 < ArrayItems.Length; v1192++)
        {
            if (!(v1193.Add(ArrayItems[v1192])))
                continue;
            v1194.Add(ArrayItems[v1192]);
        }

        v1196 = new HashSet<int>(EqualityComparer<int>.Default);
        try
        {
            while (v1195.MoveNext())
            {
                v1192 = v1195.Current;
                if (!(v1194.Remove(v1192)))
                    continue;
                if (!(v1196.Add(v1192)))
                    continue;
                yield return v1192;
            }
        }
        finally
        {
            v1195.Dispose();
        }
    }
}}