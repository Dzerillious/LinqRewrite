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
        int v974;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v975;
        int v976;
        v975 = new HashSet<int>();
        v974 = (0);
        for (; v974 < (ArrayItems.Length); v974 += 1)
            v975.Add((ArrayItems[v974]));
        v976 = (0);
        for (; v976 < (ArrayItems2.Length); v976 += 1)
        {
            if (!(v975.Remove(((ArrayItems2[v976])))))
                continue;
            yield return ((ArrayItems2[v976]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v977;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v978;
        int v979;
        v979 = SimpleListItems2.Count;
        int v980;
        v978 = new HashSet<int>();
        v977 = (0);
        for (; v977 < (ArrayItems.Length); v977 += 1)
            v978.Add((ArrayItems[v977]));
        v980 = (0);
        for (; v980 < (v979); v980 += 1)
        {
            if (!(v978.Remove(((SimpleListItems2[v980])))))
                continue;
            yield return ((SimpleListItems2[v980]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v981;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v982;
        IEnumerator<int> v983;
        int v984;
        v983 = EnumerableItems2.GetEnumerator();
        v982 = new HashSet<int>();
        v981 = (0);
        for (; v981 < (ArrayItems.Length); v981 += 1)
            v982.Add((ArrayItems[v981]));
        try
        {
            while (v983.MoveNext())
            {
                v984 = (v983.Current);
                if (!(v982.Remove((v984))))
                    continue;
                yield return (v984);
            }
        }
        finally
        {
            v983.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v985;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v986;
        IEnumerator<int> v987;
        int v988;
        v987 = MethodEnumerable2().GetEnumerator();
        v986 = new HashSet<int>();
        v985 = (0);
        for (; v985 < (ArrayItems.Length); v985 += 1)
            v986.Add((ArrayItems[v985]));
        try
        {
            while (v987.MoveNext())
            {
                v988 = (v987.Current);
                if (!(v986.Remove((v988))))
                    continue;
                yield return (v988);
            }
        }
        finally
        {
            v987.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SimpleListIntersectArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v989;
        v989 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v990;
        v990 = SimpleListItems;
        int v991;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v992;
        int v993;
        v992 = new HashSet<int>();
        v991 = (0);
        for (; v991 < (v989); v991 += 1)
            v992.Add((v990[v991]));
        v993 = (0);
        for (; v993 < (ArrayItems2.Length); v993 += 1)
        {
            if (!(v992.Remove(((ArrayItems2[v993])))))
                continue;
            yield return ((ArrayItems2[v993]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SimpleListIntersectSimpleListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v994;
        v994 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v995;
        v995 = SimpleListItems;
        int v996;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v997;
        int v998;
        v998 = SimpleListItems2.Count;
        int v999;
        v997 = new HashSet<int>();
        v996 = (0);
        for (; v996 < (v994); v996 += 1)
            v997.Add((v995[v996]));
        v999 = (0);
        for (; v999 < (v998); v999 += 1)
        {
            if (!(v997.Remove(((SimpleListItems2[v999])))))
                continue;
            yield return ((SimpleListItems2[v999]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SimpleListIntersectEnumerableRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v1000;
        v1000 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v1001;
        v1001 = SimpleListItems;
        int v1002;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1003;
        IEnumerator<int> v1004;
        int v1005;
        v1004 = EnumerableItems2.GetEnumerator();
        v1003 = new HashSet<int>();
        v1002 = (0);
        for (; v1002 < (v1000); v1002 += 1)
            v1003.Add((v1001[v1002]));
        try
        {
            while (v1004.MoveNext())
            {
                v1005 = (v1004.Current);
                if (!(v1003.Remove((v1005))))
                    continue;
                yield return (v1005);
            }
        }
        finally
        {
            v1004.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SimpleListIntersectMethodRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v1006;
        v1006 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v1007;
        v1007 = SimpleListItems;
        int v1008;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1009;
        IEnumerator<int> v1010;
        int v1011;
        v1010 = MethodEnumerable2().GetEnumerator();
        v1009 = new HashSet<int>();
        v1008 = (0);
        for (; v1008 < (v1006); v1008 += 1)
            v1009.Add((v1007[v1008]));
        try
        {
            while (v1010.MoveNext())
            {
                v1011 = (v1010.Current);
                if (!(v1009.Remove((v1011))))
                    continue;
                yield return (v1011);
            }
        }
        finally
        {
            v1010.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableIntersectArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1012;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1013;
        int v1014;
        v1012 = EnumerableItems.GetEnumerator();
        v1013 = new HashSet<int>();
        try
        {
            while (v1012.MoveNext())
                v1013.Add((v1012.Current));
        }
        finally
        {
            v1012.Dispose();
        }

        v1014 = (0);
        for (; v1014 < (ArrayItems2.Length); v1014 += 1)
        {
            if (!(v1013.Remove(((ArrayItems2[v1014])))))
                continue;
            yield return ((ArrayItems2[v1014]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableIntersectSimpleListRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1015;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1016;
        int v1017;
        v1017 = SimpleListItems2.Count;
        int v1018;
        v1015 = EnumerableItems.GetEnumerator();
        v1016 = new HashSet<int>();
        try
        {
            while (v1015.MoveNext())
                v1016.Add((v1015.Current));
        }
        finally
        {
            v1015.Dispose();
        }

        v1018 = (0);
        for (; v1018 < (v1017); v1018 += 1)
        {
            if (!(v1016.Remove(((SimpleListItems2[v1018])))))
                continue;
            yield return ((SimpleListItems2[v1018]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableIntersectEnumerableRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1019;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1020;
        IEnumerator<int> v1021;
        int v1022;
        v1019 = EnumerableItems.GetEnumerator();
        v1021 = EnumerableItems2.GetEnumerator();
        v1020 = new HashSet<int>();
        try
        {
            while (v1019.MoveNext())
                v1020.Add((v1019.Current));
        }
        finally
        {
            v1019.Dispose();
        }

        try
        {
            while (v1021.MoveNext())
            {
                v1022 = (v1021.Current);
                if (!(v1020.Remove((v1022))))
                    continue;
                yield return (v1022);
            }
        }
        finally
        {
            v1021.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableIntersectMethodRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1023;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1024;
        IEnumerator<int> v1025;
        int v1026;
        v1023 = EnumerableItems.GetEnumerator();
        v1025 = MethodEnumerable2().GetEnumerator();
        v1024 = new HashSet<int>();
        try
        {
            while (v1023.MoveNext())
                v1024.Add((v1023.Current));
        }
        finally
        {
            v1023.Dispose();
        }

        try
        {
            while (v1025.MoveNext())
            {
                v1026 = (v1025.Current);
                if (!(v1024.Remove((v1026))))
                    continue;
                yield return (v1026);
            }
        }
        finally
        {
            v1025.Dispose();
        }

        yield break;
    }

    int[] ArrayIntersectArrayToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1027;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1028;
        int v1029;
        int v1030;
        int v1031;
        int v1032;
        int[] v1033;
        v1028 = new HashSet<int>();
        v1027 = (0);
        for (; v1027 < (ArrayItems.Length); v1027 += 1)
            v1028.Add((ArrayItems[v1027]));
        v1030 = 0;
        v1031 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems2.Length + ArrayItems.Length))) - 3);
        v1031 -= (v1031 % 2);
        v1032 = 8;
        v1033 = new int[8];
        v1029 = (0);
        for (; v1029 < (ArrayItems2.Length); v1029 += 1)
        {
            if (!(v1028.Remove(((ArrayItems2[v1029])))))
                continue;
            if (v1030 >= v1032)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems2.Length + ArrayItems.Length), ref v1033, ref v1031, out v1032);
            v1033[v1030] = ((ArrayItems2[v1029]));
            v1030++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1033, v1030);
    }

    int[] ArrayIntersectSimpleListToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1034;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1035;
        int v1036;
        v1036 = SimpleListItems2.Count;
        int v1037;
        int v1038;
        int v1039;
        int v1040;
        int[] v1041;
        v1035 = new HashSet<int>();
        v1034 = (0);
        for (; v1034 < (ArrayItems.Length); v1034 += 1)
            v1035.Add((ArrayItems[v1034]));
        v1038 = 0;
        v1039 = (LinqRewrite.Core.IntExtensions.Log2((uint)((v1036 + ArrayItems.Length))) - 3);
        v1039 -= (v1039 % 2);
        v1040 = 8;
        v1041 = new int[8];
        v1037 = (0);
        for (; v1037 < (v1036); v1037 += 1)
        {
            if (!(v1035.Remove(((SimpleListItems2[v1037])))))
                continue;
            if (v1038 >= v1040)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (v1036 + ArrayItems.Length), ref v1041, ref v1039, out v1040);
            v1041[v1038] = ((SimpleListItems2[v1037]));
            v1038++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1041, v1038);
    }

    int[] ArrayIntersectEnumerableToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1042;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1043;
        IEnumerator<int> v1044;
        int v1045;
        int v1046;
        int v1047;
        int[] v1048;
        v1044 = EnumerableItems2.GetEnumerator();
        v1043 = new HashSet<int>();
        v1042 = (0);
        for (; v1042 < (ArrayItems.Length); v1042 += 1)
            v1043.Add((ArrayItems[v1042]));
        v1046 = 0;
        v1047 = 8;
        v1048 = new int[8];
        try
        {
            while (v1044.MoveNext())
            {
                v1045 = (v1044.Current);
                if (!(v1043.Remove((v1045))))
                    continue;
                if (v1046 >= v1047)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1048, ref v1047);
                v1048[v1046] = (v1045);
                v1046++;
            }
        }
        finally
        {
            v1044.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1048, v1046);
    }

    int[] SimpleListIntersectArrayToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v1049;
        v1049 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v1050;
        v1050 = SimpleListItems;
        int v1051;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1052;
        int v1053;
        int v1054;
        int v1055;
        int v1056;
        int[] v1057;
        v1052 = new HashSet<int>();
        v1051 = (0);
        for (; v1051 < (v1049); v1051 += 1)
            v1052.Add((v1050[v1051]));
        v1054 = 0;
        v1055 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems2.Length + v1049))) - 3);
        v1055 -= (v1055 % 2);
        v1056 = 8;
        v1057 = new int[8];
        v1053 = (0);
        for (; v1053 < (ArrayItems2.Length); v1053 += 1)
        {
            if (!(v1052.Remove(((ArrayItems2[v1053])))))
                continue;
            if (v1054 >= v1056)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems2.Length + v1049), ref v1057, ref v1055, out v1056);
            v1057[v1054] = ((ArrayItems2[v1053]));
            v1054++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1057, v1054);
    }

    int[] SimpleListIntersectSimpleListToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v1058;
        v1058 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v1059;
        v1059 = SimpleListItems;
        int v1060;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1061;
        int v1062;
        v1062 = SimpleListItems2.Count;
        int v1063;
        int v1064;
        int v1065;
        int v1066;
        int[] v1067;
        v1061 = new HashSet<int>();
        v1060 = (0);
        for (; v1060 < (v1058); v1060 += 1)
            v1061.Add((v1059[v1060]));
        v1064 = 0;
        v1065 = (LinqRewrite.Core.IntExtensions.Log2((uint)((v1062 + v1058))) - 3);
        v1065 -= (v1065 % 2);
        v1066 = 8;
        v1067 = new int[8];
        v1063 = (0);
        for (; v1063 < (v1062); v1063 += 1)
        {
            if (!(v1061.Remove(((SimpleListItems2[v1063])))))
                continue;
            if (v1064 >= v1066)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (v1062 + v1058), ref v1067, ref v1065, out v1066);
            v1067[v1064] = ((SimpleListItems2[v1063]));
            v1064++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1067, v1064);
    }

    int[] SimpleListIntersectEnumerableToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v1068;
        v1068 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v1069;
        v1069 = SimpleListItems;
        int v1070;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1071;
        IEnumerator<int> v1072;
        int v1073;
        int v1074;
        int v1075;
        int[] v1076;
        v1072 = EnumerableItems2.GetEnumerator();
        v1071 = new HashSet<int>();
        v1070 = (0);
        for (; v1070 < (v1068); v1070 += 1)
            v1071.Add((v1069[v1070]));
        v1074 = 0;
        v1075 = 8;
        v1076 = new int[8];
        try
        {
            while (v1072.MoveNext())
            {
                v1073 = (v1072.Current);
                if (!(v1071.Remove((v1073))))
                    continue;
                if (v1074 >= v1075)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1076, ref v1075);
                v1076[v1074] = (v1073);
                v1074++;
            }
        }
        finally
        {
            v1072.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1076, v1074);
    }

    int[] EnumerableIntersectArrayToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1077;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1078;
        int v1079;
        int v1080;
        int v1081;
        int[] v1082;
        v1077 = EnumerableItems.GetEnumerator();
        v1078 = new HashSet<int>();
        try
        {
            while (v1077.MoveNext())
                v1078.Add((v1077.Current));
        }
        finally
        {
            v1077.Dispose();
        }

        v1080 = 0;
        v1081 = 8;
        v1082 = new int[8];
        v1079 = (0);
        for (; v1079 < (ArrayItems2.Length); v1079 += 1)
        {
            if (!(v1078.Remove(((ArrayItems2[v1079])))))
                continue;
            if (v1080 >= v1081)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1082, ref v1081);
            v1082[v1080] = ((ArrayItems2[v1079]));
            v1080++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1082, v1080);
    }

    int[] EnumerableIntersectSimpleListToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1083;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1084;
        int v1085;
        v1085 = SimpleListItems2.Count;
        int v1086;
        int v1087;
        int v1088;
        int[] v1089;
        v1083 = EnumerableItems.GetEnumerator();
        v1084 = new HashSet<int>();
        try
        {
            while (v1083.MoveNext())
                v1084.Add((v1083.Current));
        }
        finally
        {
            v1083.Dispose();
        }

        v1087 = 0;
        v1088 = 8;
        v1089 = new int[8];
        v1086 = (0);
        for (; v1086 < (v1085); v1086 += 1)
        {
            if (!(v1084.Remove(((SimpleListItems2[v1086])))))
                continue;
            if (v1087 >= v1088)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1089, ref v1088);
            v1089[v1087] = ((SimpleListItems2[v1086]));
            v1087++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1089, v1087);
    }

    int[] EnumerableIntersectEnumerableToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1090;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1091;
        IEnumerator<int> v1092;
        int v1093;
        int v1094;
        int v1095;
        int[] v1096;
        v1090 = EnumerableItems.GetEnumerator();
        v1092 = EnumerableItems2.GetEnumerator();
        v1091 = new HashSet<int>();
        try
        {
            while (v1090.MoveNext())
                v1091.Add((v1090.Current));
        }
        finally
        {
            v1090.Dispose();
        }

        v1094 = 0;
        v1095 = 8;
        v1096 = new int[8];
        try
        {
            while (v1092.MoveNext())
            {
                v1093 = (v1092.Current);
                if (!(v1091.Remove((v1093))))
                    continue;
                if (v1094 >= v1095)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1096, ref v1095);
                v1096[v1094] = (v1093);
                v1094++;
            }
        }
        finally
        {
            v1092.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1096, v1094);
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectIntersectArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1097;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1098;
        int v1099;
        v1098 = new HashSet<int>();
        v1097 = (0);
        for (; v1097 < (ArrayItems.Length); v1097 += 1)
            v1098.Add((50 + ArrayItems[v1097]));
        v1099 = (0);
        for (; v1099 < (ArrayItems2.Length); v1099 += 1)
        {
            if (!(v1098.Remove(((ArrayItems2[v1099])))))
                continue;
            yield return ((ArrayItems2[v1099]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectIntersectArraySelectRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v1101;
        v1101 = (0);
        for (; v1101 < (ArrayItems2.Length); v1101 += 1)
            yield return (((ArrayItems2[v1101]) + 50));
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectIntersectArraySelectRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1102;
        if (ArraySelectIntersectArraySelectRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1103;
        IEnumerator<int> v1104;
        int v1105;
        v1104 = ArraySelectIntersectArraySelectRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v1103 = new HashSet<int>();
        v1102 = (0);
        for (; v1102 < (ArrayItems.Length); v1102 += 1)
            v1103.Add((50 + ArrayItems[v1102]));
        try
        {
            while (v1104.MoveNext())
            {
                v1105 = (v1104.Current);
                if (!(v1103.Remove((v1105))))
                    continue;
                yield return (v1105);
            }
        }
        finally
        {
            v1104.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereIntersectArrayWhereRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v1106;
        v1106 = (0);
        for (; v1106 < (ArrayItems2.Length); v1106 += 1)
        {
            if (!((((ArrayItems2[v1106])) > 50)))
                continue;
            yield return ((ArrayItems2[v1106]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereIntersectArrayWhereRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1107;
        if (ArrayWhereIntersectArrayWhereRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1108;
        IEnumerator<int> v1109;
        int v1110;
        v1109 = ArrayWhereIntersectArrayWhereRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v1108 = new HashSet<int>();
        v1107 = (0);
        for (; v1107 < (ArrayItems.Length); v1107 += 1)
        {
            if (!((((ArrayItems[v1107])) > 50)))
                continue;
            v1108.Add(((ArrayItems[v1107])));
        }

        try
        {
            while (v1109.MoveNext())
            {
                v1110 = (v1109.Current);
                if (!(v1108.Remove((v1110))))
                    continue;
                yield return (v1110);
            }
        }
        finally
        {
            v1109.Dispose();
        }

        yield break;
    }

    int ArrayIntersectArrayCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1111;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1112;
        int v1113;
        int v1114;
        v1112 = new HashSet<int>();
        v1111 = (0);
        for (; v1111 < (ArrayItems.Length); v1111 += 1)
            v1112.Add((ArrayItems[v1111]));
        v1114 = 0;
        v1113 = (0);
        for (; v1113 < (ArrayItems2.Length); v1113 += 1)
        {
            if (!(v1112.Remove(((ArrayItems2[v1113])))))
                continue;
            v1114++;
        }

        return v1114;
    }

    int ArrayIntersectArrayCount2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1115;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1116;
        int v1117;
        int v1118;
        v1116 = new HashSet<int>();
        v1115 = (0);
        for (; v1115 < (ArrayItems.Length); v1115 += 1)
            v1116.Add((ArrayItems[v1115]));
        v1118 = 0;
        v1117 = (0);
        for (; v1117 < (ArrayItems2.Length); v1117 += 1)
        {
            if (!(v1116.Remove(((ArrayItems2[v1117])))))
                continue;
            if (!((((ArrayItems2[v1117])) > 70)))
                continue;
            v1118++;
        }

        return v1118;
    }

    int ArrayIntersectArraySumRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1119;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1120;
        int v1121;
        int v1122;
        v1120 = new HashSet<int>();
        v1119 = (0);
        for (; v1119 < (ArrayItems.Length); v1119 += 1)
            v1120.Add((ArrayItems[v1119]));
        v1122 = 0;
        v1121 = (0);
        for (; v1121 < (ArrayItems2.Length); v1121 += 1)
        {
            if (!(v1120.Remove(((ArrayItems2[v1121])))))
                continue;
            v1122 += ((ArrayItems2[v1121]));
        }

        return v1122;
    }

    int ArrayIntersectArraySum2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1123;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1124;
        int v1125;
        int v1126;
        v1124 = new HashSet<int>();
        v1123 = (0);
        for (; v1123 < (ArrayItems.Length); v1123 += 1)
            v1124.Add((ArrayItems[v1123]));
        v1126 = 0;
        v1125 = (0);
        for (; v1125 < (ArrayItems2.Length); v1125 += 1)
        {
            if (!(v1124.Remove(((ArrayItems2[v1125])))))
                continue;
            v1126 += (((ArrayItems2[v1125])) + 10);
        }

        return v1126;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1127;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1128;
        int v1129;
        HashSet<int> v1130;
        v1128 = new HashSet<int>();
        v1127 = (0);
        for (; v1127 < (ArrayItems.Length); v1127 += 1)
            v1128.Add((ArrayItems[v1127]));
        v1130 = new HashSet<int>();
        v1129 = (0);
        for (; v1129 < (ArrayItems2.Length); v1129 += 1)
        {
            if (!(v1128.Remove(((ArrayItems2[v1129])))))
                continue;
            if (!(v1130.Add((((ArrayItems2[v1129]))))))
                continue;
            yield return (((ArrayItems2[v1129])));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectArrayDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1131;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1132;
        int v1133;
        HashSet<int> v1134;
        v1132 = new HashSet<int>();
        v1131 = (0);
        for (; v1131 < (ArrayItems.Length); v1131 += 1)
            v1132.Add((ArrayItems[v1131]));
        v1134 = new HashSet<int>(EqualityComparer<int>.Default);
        v1133 = (0);
        for (; v1133 < (ArrayItems2.Length); v1133 += 1)
        {
            if (!(v1132.Remove(((ArrayItems2[v1133])))))
                continue;
            if (!(v1134.Add((((ArrayItems2[v1133]))))))
                continue;
            yield return (((ArrayItems2[v1133])));
        }

        yield break;
    }

    int ArrayIntersectArrayElementAtRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1135;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1136;
        int v1137;
        int v1138;
        v1136 = new HashSet<int>();
        v1135 = (0);
        for (; v1135 < (ArrayItems.Length); v1135 += 1)
            v1136.Add((ArrayItems[v1135]));
        v1138 = 0;
        v1137 = (0);
        for (; v1137 < (ArrayItems2.Length); v1137 += 1)
        {
            if (!(v1136.Remove(((ArrayItems2[v1137])))))
                continue;
            if (v1138 == 45)
                return ((ArrayItems2[v1137]));
            v1138++;
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArrayIntersectArrayElementAtOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1139;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1140;
        int v1141;
        int v1142;
        v1140 = new HashSet<int>();
        v1139 = (0);
        for (; v1139 < (ArrayItems.Length); v1139 += 1)
            v1140.Add((ArrayItems[v1139]));
        v1142 = 0;
        v1141 = (0);
        for (; v1141 < (ArrayItems2.Length); v1141 += 1)
        {
            if (!(v1140.Remove(((ArrayItems2[v1141])))))
                continue;
            if (v1142 == 45)
                return ((ArrayItems2[v1141]));
            v1142++;
        }

        return default(int);
    }

    int ArrayIntersectArrayFirstRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1143;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1144;
        int v1145;
        int v1146;
        v1144 = new HashSet<int>();
        v1143 = (0);
        for (; v1143 < (ArrayItems.Length); v1143 += 1)
            v1144.Add((ArrayItems[v1143]));
        v1146 = 0;
        v1145 = (0);
        for (; v1145 < (ArrayItems2.Length); v1145 += 1)
        {
            if (!(v1144.Remove(((ArrayItems2[v1145])))))
                continue;
            return ((ArrayItems2[v1145]));
            v1146++;
        }

        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int ArrayIntersectArrayFirstOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1147;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1148;
        int v1149;
        v1148 = new HashSet<int>();
        v1147 = (0);
        for (; v1147 < (ArrayItems.Length); v1147 += 1)
            v1148.Add((ArrayItems[v1147]));
        v1149 = (0);
        for (; v1149 < (ArrayItems2.Length); v1149 += 1)
        {
            if (!(v1148.Remove(((ArrayItems2[v1149])))))
                continue;
            return ((ArrayItems2[v1149]));
        }

        return default(int);
    }

    int ArrayIntersectArrayLastRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1150;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1151;
        int v1152;
        int v1153;
        int? v1154;
        v1151 = new HashSet<int>();
        v1150 = (0);
        for (; v1150 < (ArrayItems.Length); v1150 += 1)
            v1151.Add((ArrayItems[v1150]));
        v1153 = 0;
        v1154 = null;
        v1152 = (0);
        for (; v1152 < (ArrayItems2.Length); v1152 += 1)
        {
            if (!(v1151.Remove(((ArrayItems2[v1152])))))
                continue;
            v1154 = ((ArrayItems2[v1152]));
            v1153++;
        }

        if (v1154 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1154;
    }

    int ArrayIntersectArrayLastOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1155;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1156;
        int v1157;
        int? v1158;
        v1156 = new HashSet<int>();
        v1155 = (0);
        for (; v1155 < (ArrayItems.Length); v1155 += 1)
            v1156.Add((ArrayItems[v1155]));
        v1158 = null;
        v1157 = (0);
        for (; v1157 < (ArrayItems2.Length); v1157 += 1)
        {
            if (!(v1156.Remove(((ArrayItems2[v1157])))))
                continue;
            v1158 = ((ArrayItems2[v1157]));
        }

        if (v1158 == null)
            return default(int);
        else
            return (int)v1158;
    }

    int ArrayIntersectArraySingleRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1159;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1160;
        int v1161;
        int? v1162;
        v1160 = new HashSet<int>();
        v1159 = (0);
        for (; v1159 < (ArrayItems.Length); v1159 += 1)
            v1160.Add((ArrayItems[v1159]));
        v1162 = null;
        v1161 = (0);
        for (; v1161 < (ArrayItems2.Length); v1161 += 1)
        {
            if (!(v1160.Remove(((ArrayItems2[v1161])))))
                continue;
            if (v1162 == null)
                v1162 = ((ArrayItems2[v1161]));
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v1162 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1162;
    }

    int ArrayIntersectArraySingle2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1163;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1164;
        int v1165;
        int? v1166;
        v1164 = new HashSet<int>();
        v1163 = (0);
        for (; v1163 < (ArrayItems.Length); v1163 += 1)
            v1164.Add((ArrayItems[v1163]));
        v1166 = null;
        v1165 = (0);
        for (; v1165 < (ArrayItems2.Length); v1165 += 1)
        {
            if (!(v1164.Remove(((ArrayItems2[v1165])))))
                continue;
            if ((((ArrayItems2[v1165])) == 76))
                if (v1166 == null)
                    v1166 = ((ArrayItems2[v1165]));
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v1166 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1166;
    }

    int ArrayIntersectArraySingleOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1167;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1168;
        int v1169;
        int? v1170;
        v1168 = new HashSet<int>();
        v1167 = (0);
        for (; v1167 < (ArrayItems.Length); v1167 += 1)
            v1168.Add((ArrayItems[v1167]));
        v1170 = null;
        v1169 = (0);
        for (; v1169 < (ArrayItems2.Length); v1169 += 1)
        {
            if (!(v1168.Remove(((ArrayItems2[v1169])))))
                continue;
            if (v1170 == null)
                v1170 = ((ArrayItems2[v1169]));
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v1170 == null)
            return default(int);
        else
            return (int)v1170;
    }

    int ArrayIntersectArrayMinRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1171;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1172;
        int v1173;
        int v1174;
        int v1175;
        v1172 = new HashSet<int>();
        v1171 = (0);
        for (; v1171 < (ArrayItems.Length); v1171 += 1)
            v1172.Add((ArrayItems[v1171]));
        v1174 = 0;
        v1175 = 2147483647;
        v1173 = (0);
        for (; v1173 < (ArrayItems2.Length); v1173 += 1)
        {
            if (!(v1172.Remove(((ArrayItems2[v1173])))))
                continue;
            if (((ArrayItems2[v1173])) >= v1175)
                continue;
            v1175 = ((ArrayItems2[v1173]));
            v1174++;
        }

        if (1 > v1174)
            throw new System.InvalidOperationException("Index out of range");
        return v1175;
    }

    decimal ArrayIntersectArrayMin2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1176;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1177;
        int v1178;
        int v1179;
        decimal v1180;
        decimal v1181;
        v1177 = new HashSet<int>();
        v1176 = (0);
        for (; v1176 < (ArrayItems.Length); v1176 += 1)
            v1177.Add((ArrayItems[v1176]));
        v1179 = 0;
        v1180 = 79228162514264337593543950335M;
        v1178 = (0);
        for (; v1178 < (ArrayItems2.Length); v1178 += 1)
        {
            if (!(v1177.Remove(((ArrayItems2[v1178])))))
                continue;
            v1181 = (((ArrayItems2[v1178])) + 2m);
            if (v1181 >= v1180)
                continue;
            v1180 = v1181;
            v1179++;
        }

        if (1 > v1179)
            throw new System.InvalidOperationException("Index out of range");
        return v1180;
    }

    int ArrayIntersectArrayMaxRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1182;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1183;
        int v1184;
        int v1185;
        int v1186;
        v1183 = new HashSet<int>();
        v1182 = (0);
        for (; v1182 < (ArrayItems.Length); v1182 += 1)
            v1183.Add((ArrayItems[v1182]));
        v1185 = 0;
        v1186 = -2147483648;
        v1184 = (0);
        for (; v1184 < (ArrayItems2.Length); v1184 += 1)
        {
            if (!(v1183.Remove(((ArrayItems2[v1184])))))
                continue;
            if (((ArrayItems2[v1184])) <= v1186)
                continue;
            v1186 = ((ArrayItems2[v1184]));
            v1185++;
        }

        if (1 > v1185)
            throw new System.InvalidOperationException("Index out of range");
        return v1186;
    }

    decimal ArrayIntersectArrayMax2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1187;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1188;
        int v1189;
        int v1190;
        decimal v1191;
        decimal v1192;
        v1188 = new HashSet<int>();
        v1187 = (0);
        for (; v1187 < (ArrayItems.Length); v1187 += 1)
            v1188.Add((ArrayItems[v1187]));
        v1190 = 0;
        v1191 = -79228162514264337593543950335M;
        v1189 = (0);
        for (; v1189 < (ArrayItems2.Length); v1189 += 1)
        {
            if (!(v1188.Remove(((ArrayItems2[v1189])))))
                continue;
            v1192 = (((ArrayItems2[v1189])) + 2m);
            if (v1192 <= v1191)
                continue;
            v1191 = v1192;
            v1190++;
        }

        if (1 > v1190)
            throw new System.InvalidOperationException("Index out of range");
        return v1191;
    }

    long ArrayIntersectArrayLongCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1193;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1194;
        int v1195;
        long v1196;
        v1194 = new HashSet<int>();
        v1193 = (0);
        for (; v1193 < (ArrayItems.Length); v1193 += 1)
            v1194.Add((ArrayItems[v1193]));
        v1196 = 0;
        v1195 = (0);
        for (; v1195 < (ArrayItems2.Length); v1195 += 1)
        {
            if (!(v1194.Remove(((ArrayItems2[v1195])))))
                continue;
            v1196++;
        }

        return v1196;
    }

    long ArrayIntersectArrayLongCount2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1197;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1198;
        int v1199;
        long v1200;
        v1198 = new HashSet<int>();
        v1197 = (0);
        for (; v1197 < (ArrayItems.Length); v1197 += 1)
            v1198.Add((ArrayItems[v1197]));
        v1200 = 0;
        v1199 = (0);
        for (; v1199 < (ArrayItems2.Length); v1199 += 1)
        {
            if (!(v1198.Remove(((ArrayItems2[v1199])))))
                continue;
            if (!((((ArrayItems2[v1199])) > 50)))
                continue;
            v1200++;
        }

        return v1200;
    }

    bool ArrayIntersectArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1201;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1202;
        int v1203;
        v1202 = new HashSet<int>();
        v1201 = (0);
        for (; v1201 < (ArrayItems.Length); v1201 += 1)
            v1202.Add((ArrayItems[v1201]));
        v1203 = (0);
        for (; v1203 < (ArrayItems2.Length); v1203 += 1)
        {
            if (!(v1202.Remove(((ArrayItems2[v1203])))))
                continue;
            if (((ArrayItems2[v1203])) == 56)
                return true;
        }

        return false;
    }

    double ArrayIntersectArrayAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1204;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1205;
        int v1206;
        double v1207;
        int v1208;
        v1205 = new HashSet<int>();
        v1204 = (0);
        for (; v1204 < (ArrayItems.Length); v1204 += 1)
            v1205.Add((ArrayItems[v1204]));
        v1207 = 0;
        v1208 = 0;
        v1206 = (0);
        for (; v1206 < (ArrayItems2.Length); v1206 += 1)
        {
            if (!(v1205.Remove(((ArrayItems2[v1206])))))
                continue;
            v1207 += ((ArrayItems2[v1206]));
            v1208++;
        }

        if (1 > v1208)
            throw new System.InvalidOperationException("Index out of range");
        return (v1207 / v1208);
    }

    double ArrayIntersectArrayAverage2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1209;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1210;
        int v1211;
        double v1212;
        int v1213;
        v1210 = new HashSet<int>();
        v1209 = (0);
        for (; v1209 < (ArrayItems.Length); v1209 += 1)
            v1210.Add((ArrayItems[v1209]));
        v1212 = 0;
        v1213 = 0;
        v1211 = (0);
        for (; v1211 < (ArrayItems2.Length); v1211 += 1)
        {
            if (!(v1210.Remove(((ArrayItems2[v1211])))))
                continue;
            v1212 += (((ArrayItems2[v1211])) + 10);
            v1213++;
        }

        if (1 > v1213)
            throw new System.InvalidOperationException("Index out of range");
        return (v1212 / v1213);
    }

    bool ArrayIntersectArrayContains2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1214;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1215;
        int v1216;
        System.Collections.Generic.EqualityComparer<int> v1217;
        v1217 = EqualityComparer<int>.Default;
        v1215 = new HashSet<int>();
        v1214 = (0);
        for (; v1214 < (ArrayItems.Length); v1214 += 1)
            v1215.Add((ArrayItems[v1214]));
        v1216 = (0);
        for (; v1216 < (ArrayItems2.Length); v1216 += 1)
        {
            if (!(v1215.Remove(((ArrayItems2[v1216])))))
                continue;
            if (v1217.Equals(((ArrayItems2[v1216])), 56))
                return true;
        }

        return false;
    }

    System.Collections.Generic.IEnumerable<int> SelectWhereArrayIntersectSelectWhereArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v1218;
        int v1219;
        v1218 = (0);
        for (; v1218 < (ArrayItems2.Length); v1218 += 1)
        {
            v1219 = (((ArrayItems2[v1218]) + 10));
            if (!(((v1219) > 80)))
                continue;
            yield return (v1219);
        }

        yield break;
    }

    bool SelectWhereArrayIntersectSelectWhereArrayContainsRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1220;
        int v1221;
        if (SelectWhereArrayIntersectSelectWhereArrayContainsRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1222;
        IEnumerator<int> v1223;
        v1223 = SelectWhereArrayIntersectSelectWhereArrayContainsRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v1222 = new HashSet<int>();
        v1220 = (0);
        for (; v1220 < (ArrayItems.Length); v1220 += 1)
        {
            v1221 = (10 + ArrayItems[v1220]);
            if (!(((v1221) > 80)))
                continue;
            v1222.Add((v1221));
        }

        try
        {
            while (v1223.MoveNext())
            {
                v1221 = (v1223.Current);
                if (!(v1222.Remove((v1221))))
                    continue;
                if ((v1221) == 112)
                    return true;
            }
        }
        finally
        {
            v1223.Dispose();
        }

        return false;
    }

    System.Collections.Generic.IEnumerable<int> RangeIntersectArrayRewritten_ProceduralLinq1()
    {
        int v1224;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1225;
        int v1226;
        v1225 = new HashSet<int>();
        v1224 = (0);
        for (; v1224 < (100); v1224 += (1))
            v1225.Add((20 + v1224));
        v1226 = (0);
        for (; v1226 < (ArrayItems2.Length); v1226 += 1)
        {
            if (!(v1225.Remove(((ArrayItems2[v1226])))))
                continue;
            yield return ((ArrayItems2[v1226]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RepeatIntersectArrayRewritten_ProceduralLinq1()
    {
        int v1227;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1228;
        int v1229;
        v1228 = new HashSet<int>();
        v1227 = (0);
        for (; v1227 < (100); v1227 += 1)
            v1228.Add((20));
        v1229 = (0);
        for (; v1229 < (ArrayItems2.Length); v1229 += 1)
        {
            if (!(v1228.Remove(((ArrayItems2[v1229])))))
                continue;
            yield return ((ArrayItems2[v1229]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EmptyIntersectArrayRewritten_ProceduralLinq1()
    {
        int v1230;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1231;
        int v1232;
        v1230 = 0;
        v1231 = new HashSet<int>();
        v1232 = (0);
        for (; v1232 < (ArrayItems2.Length); v1232 += 1)
        {
            if (!(v1231.Remove(((ArrayItems2[v1232])))))
                continue;
            yield return ((ArrayItems2[v1232]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeEmpty2ArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1233;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1234;
        int v1235;
        v1234 = new HashSet<int>();
        v1233 = (0);
        for (; v1233 < (ArrayItems.Length); v1233 += 1)
        {
            if (!((false)))
                continue;
            v1234.Add(((ArrayItems[v1233])));
        }

        v1235 = (0);
        for (; v1235 < (ArrayItems2.Length); v1235 += 1)
        {
            if (!(v1234.Remove(((ArrayItems2[v1235])))))
                continue;
            yield return ((ArrayItems2[v1235]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectRangeRewritten_ProceduralLinq1()
    {
        int v1236;
        v1236 = (0);
        for (; v1236 < (260); v1236 += (1))
            yield return (70 + v1236);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectRangeRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1237;
        if (ArrayIntersectRangeRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1238;
        IEnumerator<int> v1239;
        int v1240;
        v1239 = ArrayIntersectRangeRewritten_ProceduralLinq1().GetEnumerator();
        v1238 = new HashSet<int>();
        v1237 = (0);
        for (; v1237 < (ArrayItems.Length); v1237 += 1)
            v1238.Add((ArrayItems[v1237]));
        try
        {
            while (v1239.MoveNext())
            {
                v1240 = (v1239.Current);
                if (!(v1238.Remove((v1240))))
                    continue;
                yield return (v1240);
            }
        }
        finally
        {
            v1239.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectRepeatRewritten_ProceduralLinq1()
    {
        int v1241;
        v1241 = (0);
        for (; v1241 < (100); v1241 += 1)
            yield return (70);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectRepeatRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1242;
        if (ArrayIntersectRepeatRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1243;
        IEnumerator<int> v1244;
        int v1245;
        v1244 = ArrayIntersectRepeatRewritten_ProceduralLinq1().GetEnumerator();
        v1243 = new HashSet<int>();
        v1242 = (0);
        for (; v1242 < (ArrayItems.Length); v1242 += 1)
            v1243.Add((ArrayItems[v1242]));
        try
        {
            while (v1244.MoveNext())
            {
                v1245 = (v1244.Current);
                if (!(v1243.Remove((v1245))))
                    continue;
                yield return (v1245);
            }
        }
        finally
        {
            v1244.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectEmptyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1246;
        if (Enumerable.Empty<int>() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1247;
        IEnumerator<int> v1248;
        int v1249;
        v1248 = Enumerable.Empty<int>().GetEnumerator();
        v1247 = new HashSet<int>();
        v1246 = (0);
        for (; v1246 < (ArrayItems.Length); v1246 += 1)
            v1247.Add((ArrayItems[v1246]));
        try
        {
            while (v1248.MoveNext())
            {
                v1249 = (v1248.Current);
                if (!(v1247.Remove((v1249))))
                    continue;
                yield return (v1249);
            }
        }
        finally
        {
            v1248.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectEmpty2Rewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v1250;
        v1250 = (0);
        for (; v1250 < (ArrayItems2.Length); v1250 += 1)
        {
            if (!((false)))
                continue;
            yield return ((ArrayItems2[v1250]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectEmpty2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1251;
        if (ArrayIntersectEmpty2Rewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1252;
        IEnumerator<int> v1253;
        int v1254;
        v1253 = ArrayIntersectEmpty2Rewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v1252 = new HashSet<int>();
        v1251 = (0);
        for (; v1251 < (ArrayItems.Length); v1251 += 1)
            v1252.Add((ArrayItems[v1251]));
        try
        {
            while (v1253.MoveNext())
            {
                v1254 = (v1253.Current);
                if (!(v1252.Remove((v1254))))
                    continue;
                yield return (v1254);
            }
        }
        finally
        {
            v1253.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectAllRewritten_ProceduralLinq1()
    {
        int v1255;
        v1255 = (0);
        for (; v1255 < (1000); v1255 += (1))
            yield return (v1255);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectAllRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1256;
        if (ArrayIntersectAllRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1257;
        IEnumerator<int> v1258;
        int v1259;
        v1258 = ArrayIntersectAllRewritten_ProceduralLinq1().GetEnumerator();
        v1257 = new HashSet<int>();
        v1256 = (0);
        for (; v1256 < (ArrayItems.Length); v1256 += 1)
            v1257.Add((ArrayItems[v1256]));
        try
        {
            while (v1258.MoveNext())
            {
                v1259 = (v1258.Current);
                if (!(v1257.Remove((v1259))))
                    continue;
                yield return (v1259);
            }
        }
        finally
        {
            v1258.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectNullRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1260;
        throw new System.InvalidOperationException("Invalid null object");
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectArrayIntersectEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1261;
        if (ArrayItems == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1262;
        int v1263;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1264;
        IEnumerator<int> v1265;
        int v1266;
        v1265 = EnumerableItems2.GetEnumerator();
        v1262 = new HashSet<int>();
        v1261 = (0);
        for (; v1261 < (ArrayItems.Length); v1261 += 1)
            v1262.Add((ArrayItems[v1261]));
        v1264 = new HashSet<int>();
        v1263 = (0);
        for (; v1263 < (ArrayItems.Length); v1263 += 1)
        {
            if (!(v1262.Remove(((ArrayItems[v1263])))))
                continue;
            v1264.Add(((ArrayItems[v1263])));
        }

        try
        {
            while (v1265.MoveNext())
            {
                v1266 = (v1265.Current);
                if (!(v1264.Remove((v1266))))
                    continue;
                yield return (v1266);
            }
        }
        finally
        {
            v1265.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectArrayIntersectEnumerable2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1267;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1268;
        IEnumerator<int> v1269;
        int v1270;
        v1269 = EnumerableItems2.GetEnumerator();
        v1268 = new HashSet<int>();
        v1267 = (0);
        for (; v1267 < (ArrayItems.Length); v1267 += 1)
            v1268.Add((ArrayItems[v1267]));
        try
        {
            while (v1269.MoveNext())
            {
                v1270 = (v1269.Current);
                if (!(v1268.Remove((v1270))))
                    continue;
                yield return (v1270);
            }
        }
        finally
        {
            v1269.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectArrayIntersectEnumerable2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1271;
        if (ArrayIntersectArrayIntersectEnumerable2Rewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1272;
        IEnumerator<int> v1273;
        int v1274;
        v1273 = ArrayIntersectArrayIntersectEnumerable2Rewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v1272 = new HashSet<int>();
        v1271 = (0);
        for (; v1271 < (ArrayItems.Length); v1271 += 1)
            v1272.Add((ArrayItems[v1271]));
        try
        {
            while (v1273.MoveNext())
            {
                v1274 = (v1273.Current);
                if (!(v1272.Remove((v1274))))
                    continue;
                yield return (v1274);
            }
        }
        finally
        {
            v1273.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctIntersectArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1275;
        HashSet<int> v1276;
        v1276 = new HashSet<int>();
        v1275 = (0);
        for (; v1275 < (ArrayItems.Length); v1275 += 1)
        {
            if (!(v1276.Add(((ArrayItems[v1275])))))
                continue;
            yield return ((ArrayItems[v1275]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctIntersectArrayDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1277;
        HashSet<int> v1278;
        if (ArrayDistinctIntersectArrayDistinctRewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1279;
        IEnumerator<int> v1280;
        int v1281;
        v1280 = ArrayDistinctIntersectArrayDistinctRewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v1278 = new HashSet<int>();
        v1279 = new HashSet<int>();
        v1277 = (0);
        for (; v1277 < (ArrayItems.Length); v1277 += 1)
        {
            if (!(v1278.Add(((ArrayItems[v1277])))))
                continue;
            v1279.Add(((ArrayItems[v1277])));
        }

        try
        {
            while (v1280.MoveNext())
            {
                v1281 = (v1280.Current);
                if (!(v1279.Remove((v1281))))
                    continue;
                yield return (v1281);
            }
        }
        finally
        {
            v1280.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctIntersectArrayDistinctDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1282;
        HashSet<int> v1283;
        v1283 = new HashSet<int>();
        v1282 = (0);
        for (; v1282 < (ArrayItems.Length); v1282 += 1)
        {
            if (!(v1283.Add(((ArrayItems[v1282])))))
                continue;
            yield return ((ArrayItems[v1282]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctIntersectArrayDistinctDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1284;
        HashSet<int> v1285;
        if (ArrayDistinctIntersectArrayDistinctDistinctRewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1286;
        IEnumerator<int> v1287;
        int v1288;
        HashSet<int> v1289;
        v1287 = ArrayDistinctIntersectArrayDistinctDistinctRewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v1285 = new HashSet<int>();
        v1286 = new HashSet<int>();
        v1284 = (0);
        for (; v1284 < (ArrayItems.Length); v1284 += 1)
        {
            if (!(v1285.Add(((ArrayItems[v1284])))))
                continue;
            v1286.Add(((ArrayItems[v1284])));
        }

        v1289 = new HashSet<int>();
        try
        {
            while (v1287.MoveNext())
            {
                v1288 = (v1287.Current);
                if (!(v1286.Remove((v1288))))
                    continue;
                if (!(v1289.Add(((v1288)))))
                    continue;
                yield return ((v1288));
            }
        }
        finally
        {
            v1287.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctIntersectArrayDistinctDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1290;
        HashSet<int> v1291;
        v1291 = new HashSet<int>(EqualityComparer<int>.Default);
        v1290 = (0);
        for (; v1290 < (ArrayItems.Length); v1290 += 1)
        {
            if (!(v1291.Add(((ArrayItems[v1290])))))
                continue;
            yield return ((ArrayItems[v1290]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctIntersectArrayDistinctDistinct2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1292;
        HashSet<int> v1293;
        if (ArrayDistinctIntersectArrayDistinctDistinct2Rewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1294;
        IEnumerator<int> v1295;
        int v1296;
        HashSet<int> v1297;
        v1295 = ArrayDistinctIntersectArrayDistinctDistinct2Rewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v1293 = new HashSet<int>(EqualityComparer<int>.Default);
        v1294 = new HashSet<int>();
        v1292 = (0);
        for (; v1292 < (ArrayItems.Length); v1292 += 1)
        {
            if (!(v1293.Add(((ArrayItems[v1292])))))
                continue;
            v1294.Add(((ArrayItems[v1292])));
        }

        v1297 = new HashSet<int>(EqualityComparer<int>.Default);
        try
        {
            while (v1295.MoveNext())
            {
                v1296 = (v1295.Current);
                if (!(v1294.Remove((v1296))))
                    continue;
                if (!(v1297.Add(((v1296)))))
                    continue;
                yield return ((v1296));
            }
        }
        finally
        {
            v1295.Dispose();
        }

        yield break;
    }
}}