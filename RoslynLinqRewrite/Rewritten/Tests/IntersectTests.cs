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
        int v871;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v872;
        int v873;
        v872 = new HashSet<int>();
        v871 = 0;
        for (; v871 < ArrayItems.Length; v871++)
            v872.Add(ArrayItems[v871]);
        v873 = 0;
        for (; v873 < ArrayItems2.Length; v873++)
        {
            if (!(v872.Remove(ArrayItems2[v873])))
                continue;
            yield return ArrayItems2[v873];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v874;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v875;
        IEnumerator<int> v876;
        int v877;
        v876 = SimpleListItems2.GetEnumerator();
        v875 = new HashSet<int>();
        v874 = 0;
        for (; v874 < ArrayItems.Length; v874++)
            v875.Add(ArrayItems[v874]);
        try
        {
            while (v876.MoveNext())
            {
                v877 = v876.Current;
                if (!(v875.Remove(v877)))
                    continue;
                yield return v877;
            }
        }
        finally
        {
            v876.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v878;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v879;
        IEnumerator<int> v880;
        int v881;
        v880 = EnumerableItems2.GetEnumerator();
        v879 = new HashSet<int>();
        v878 = 0;
        for (; v878 < ArrayItems.Length; v878++)
            v879.Add(ArrayItems[v878]);
        try
        {
            while (v880.MoveNext())
            {
                v881 = v880.Current;
                if (!(v879.Remove(v881)))
                    continue;
                yield return v881;
            }
        }
        finally
        {
            v880.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v882;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v883;
        IEnumerator<int> v884;
        int v885;
        v884 = MethodEnumerable2().GetEnumerator();
        v883 = new HashSet<int>();
        v882 = 0;
        for (; v882 < ArrayItems.Length; v882++)
            v883.Add(ArrayItems[v882]);
        try
        {
            while (v884.MoveNext())
            {
                v885 = v884.Current;
                if (!(v883.Remove(v885)))
                    continue;
                yield return v885;
            }
        }
        finally
        {
            v884.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> SimpleListIntersectArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v886;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v887;
        int v888;
        v886 = SimpleListItems.GetEnumerator();
        v887 = new HashSet<int>();
        try
        {
            while (v886.MoveNext())
                v887.Add(v886.Current);
        }
        finally
        {
            v886.Dispose();
        }

        v888 = 0;
        for (; v888 < ArrayItems2.Length; v888++)
        {
            if (!(v887.Remove(ArrayItems2[v888])))
                continue;
            yield return ArrayItems2[v888];
        }
    }

    System.Collections.Generic.IEnumerable<int> SimpleListIntersectSimpleListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v889;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v890;
        IEnumerator<int> v891;
        int v892;
        v889 = SimpleListItems.GetEnumerator();
        v891 = SimpleListItems2.GetEnumerator();
        v890 = new HashSet<int>();
        try
        {
            while (v889.MoveNext())
                v890.Add(v889.Current);
        }
        finally
        {
            v889.Dispose();
        }

        try
        {
            while (v891.MoveNext())
            {
                v892 = v891.Current;
                if (!(v890.Remove(v892)))
                    continue;
                yield return v892;
            }
        }
        finally
        {
            v891.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> SimpleListIntersectEnumerableRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v893;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v894;
        IEnumerator<int> v895;
        int v896;
        v893 = SimpleListItems.GetEnumerator();
        v895 = EnumerableItems2.GetEnumerator();
        v894 = new HashSet<int>();
        try
        {
            while (v893.MoveNext())
                v894.Add(v893.Current);
        }
        finally
        {
            v893.Dispose();
        }

        try
        {
            while (v895.MoveNext())
            {
                v896 = v895.Current;
                if (!(v894.Remove(v896)))
                    continue;
                yield return v896;
            }
        }
        finally
        {
            v895.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> SimpleListIntersectMethodRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v897;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v898;
        IEnumerator<int> v899;
        int v900;
        v897 = SimpleListItems.GetEnumerator();
        v899 = MethodEnumerable2().GetEnumerator();
        v898 = new HashSet<int>();
        try
        {
            while (v897.MoveNext())
                v898.Add(v897.Current);
        }
        finally
        {
            v897.Dispose();
        }

        try
        {
            while (v899.MoveNext())
            {
                v900 = v899.Current;
                if (!(v898.Remove(v900)))
                    continue;
                yield return v900;
            }
        }
        finally
        {
            v899.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableIntersectArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v901;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v902;
        int v903;
        v901 = EnumerableItems.GetEnumerator();
        v902 = new HashSet<int>();
        try
        {
            while (v901.MoveNext())
                v902.Add(v901.Current);
        }
        finally
        {
            v901.Dispose();
        }

        v903 = 0;
        for (; v903 < ArrayItems2.Length; v903++)
        {
            if (!(v902.Remove(ArrayItems2[v903])))
                continue;
            yield return ArrayItems2[v903];
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableIntersectSimpleListRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v904;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v905;
        IEnumerator<int> v906;
        int v907;
        v904 = EnumerableItems.GetEnumerator();
        v906 = SimpleListItems2.GetEnumerator();
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

        try
        {
            while (v906.MoveNext())
            {
                v907 = v906.Current;
                if (!(v905.Remove(v907)))
                    continue;
                yield return v907;
            }
        }
        finally
        {
            v906.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableIntersectEnumerableRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v908;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v909;
        IEnumerator<int> v910;
        int v911;
        v908 = EnumerableItems.GetEnumerator();
        v910 = EnumerableItems2.GetEnumerator();
        v909 = new HashSet<int>();
        try
        {
            while (v908.MoveNext())
                v909.Add(v908.Current);
        }
        finally
        {
            v908.Dispose();
        }

        try
        {
            while (v910.MoveNext())
            {
                v911 = v910.Current;
                if (!(v909.Remove(v911)))
                    continue;
                yield return v911;
            }
        }
        finally
        {
            v910.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableIntersectMethodRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v912;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v913;
        IEnumerator<int> v914;
        int v915;
        v912 = EnumerableItems.GetEnumerator();
        v914 = MethodEnumerable2().GetEnumerator();
        v913 = new HashSet<int>();
        try
        {
            while (v912.MoveNext())
                v913.Add(v912.Current);
        }
        finally
        {
            v912.Dispose();
        }

        try
        {
            while (v914.MoveNext())
            {
                v915 = v914.Current;
                if (!(v913.Remove(v915)))
                    continue;
                yield return v915;
            }
        }
        finally
        {
            v914.Dispose();
        }
    }

    int[] ArrayIntersectArrayToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v916;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v917;
        int v918;
        int v919;
        int v920;
        int v921;
        int[] v922;
        v917 = new HashSet<int>();
        v916 = 0;
        for (; v916 < ArrayItems.Length; v916++)
            v917.Add(ArrayItems[v916]);
        v919 = 0;
        v920 = (LinqRewrite.Core.IntExtensions.Log2((uint)(ArrayItems2.Length + ArrayItems.Length)) - 3);
        v920 -= (v920 % 2);
        v921 = 8;
        v922 = new int[8];
        v918 = 0;
        for (; v918 < ArrayItems2.Length; v918++)
        {
            if (!(v917.Remove(ArrayItems2[v918])))
                continue;
            if (v919 >= v921)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems2.Length + ArrayItems.Length), ref v922, ref v920, out v921);
            v922[v919] = ArrayItems2[v918];
            v919++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v922, v919);
    }

    int[] ArrayIntersectSimpleListToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v923;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v924;
        IEnumerator<int> v925;
        int v926;
        int v927;
        int v928;
        int[] v929;
        v925 = SimpleListItems2.GetEnumerator();
        v924 = new HashSet<int>();
        v923 = 0;
        for (; v923 < ArrayItems.Length; v923++)
            v924.Add(ArrayItems[v923]);
        v927 = 0;
        v928 = 8;
        v929 = new int[8];
        try
        {
            while (v925.MoveNext())
            {
                v926 = v925.Current;
                if (!(v924.Remove(v926)))
                    continue;
                if (v927 >= v928)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v929, ref v928);
                v929[v927] = v926;
                v927++;
            }
        }
        finally
        {
            v925.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v929, v927);
    }

    int[] ArrayIntersectEnumerableToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v930;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v931;
        IEnumerator<int> v932;
        int v933;
        int v934;
        int v935;
        int[] v936;
        v932 = EnumerableItems2.GetEnumerator();
        v931 = new HashSet<int>();
        v930 = 0;
        for (; v930 < ArrayItems.Length; v930++)
            v931.Add(ArrayItems[v930]);
        v934 = 0;
        v935 = 8;
        v936 = new int[8];
        try
        {
            while (v932.MoveNext())
            {
                v933 = v932.Current;
                if (!(v931.Remove(v933)))
                    continue;
                if (v934 >= v935)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v936, ref v935);
                v936[v934] = v933;
                v934++;
            }
        }
        finally
        {
            v932.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v936, v934);
    }

    int[] SimpleListIntersectArrayToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v937;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v938;
        int v939;
        int v940;
        int v941;
        int[] v942;
        v937 = SimpleListItems.GetEnumerator();
        v938 = new HashSet<int>();
        try
        {
            while (v937.MoveNext())
                v938.Add(v937.Current);
        }
        finally
        {
            v937.Dispose();
        }

        v940 = 0;
        v941 = 8;
        v942 = new int[8];
        v939 = 0;
        for (; v939 < ArrayItems2.Length; v939++)
        {
            if (!(v938.Remove(ArrayItems2[v939])))
                continue;
            if (v940 >= v941)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v942, ref v941);
            v942[v940] = ArrayItems2[v939];
            v940++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v942, v940);
    }

    int[] SimpleListIntersectSimpleListToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v943;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v944;
        IEnumerator<int> v945;
        int v946;
        int v947;
        int v948;
        int[] v949;
        v943 = SimpleListItems.GetEnumerator();
        v945 = SimpleListItems2.GetEnumerator();
        v944 = new HashSet<int>();
        try
        {
            while (v943.MoveNext())
                v944.Add(v943.Current);
        }
        finally
        {
            v943.Dispose();
        }

        v947 = 0;
        v948 = 8;
        v949 = new int[8];
        try
        {
            while (v945.MoveNext())
            {
                v946 = v945.Current;
                if (!(v944.Remove(v946)))
                    continue;
                if (v947 >= v948)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v949, ref v948);
                v949[v947] = v946;
                v947++;
            }
        }
        finally
        {
            v945.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v949, v947);
    }

    int[] SimpleListIntersectEnumerableToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v950;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v951;
        IEnumerator<int> v952;
        int v953;
        int v954;
        int v955;
        int[] v956;
        v950 = SimpleListItems.GetEnumerator();
        v952 = EnumerableItems2.GetEnumerator();
        v951 = new HashSet<int>();
        try
        {
            while (v950.MoveNext())
                v951.Add(v950.Current);
        }
        finally
        {
            v950.Dispose();
        }

        v954 = 0;
        v955 = 8;
        v956 = new int[8];
        try
        {
            while (v952.MoveNext())
            {
                v953 = v952.Current;
                if (!(v951.Remove(v953)))
                    continue;
                if (v954 >= v955)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v956, ref v955);
                v956[v954] = v953;
                v954++;
            }
        }
        finally
        {
            v952.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v956, v954);
    }

    int[] EnumerableIntersectArrayToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v957;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v958;
        int v959;
        int v960;
        int v961;
        int[] v962;
        v957 = EnumerableItems.GetEnumerator();
        v958 = new HashSet<int>();
        try
        {
            while (v957.MoveNext())
                v958.Add(v957.Current);
        }
        finally
        {
            v957.Dispose();
        }

        v960 = 0;
        v961 = 8;
        v962 = new int[8];
        v959 = 0;
        for (; v959 < ArrayItems2.Length; v959++)
        {
            if (!(v958.Remove(ArrayItems2[v959])))
                continue;
            if (v960 >= v961)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v962, ref v961);
            v962[v960] = ArrayItems2[v959];
            v960++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v962, v960);
    }

    int[] EnumerableIntersectSimpleListToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v963;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v964;
        IEnumerator<int> v965;
        int v966;
        int v967;
        int v968;
        int[] v969;
        v963 = EnumerableItems.GetEnumerator();
        v965 = SimpleListItems2.GetEnumerator();
        v964 = new HashSet<int>();
        try
        {
            while (v963.MoveNext())
                v964.Add(v963.Current);
        }
        finally
        {
            v963.Dispose();
        }

        v967 = 0;
        v968 = 8;
        v969 = new int[8];
        try
        {
            while (v965.MoveNext())
            {
                v966 = v965.Current;
                if (!(v964.Remove(v966)))
                    continue;
                if (v967 >= v968)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v969, ref v968);
                v969[v967] = v966;
                v967++;
            }
        }
        finally
        {
            v965.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v969, v967);
    }

    int[] EnumerableIntersectEnumerableToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v970;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v971;
        IEnumerator<int> v972;
        int v973;
        int v974;
        int v975;
        int[] v976;
        v970 = EnumerableItems.GetEnumerator();
        v972 = EnumerableItems2.GetEnumerator();
        v971 = new HashSet<int>();
        try
        {
            while (v970.MoveNext())
                v971.Add(v970.Current);
        }
        finally
        {
            v970.Dispose();
        }

        v974 = 0;
        v975 = 8;
        v976 = new int[8];
        try
        {
            while (v972.MoveNext())
            {
                v973 = v972.Current;
                if (!(v971.Remove(v973)))
                    continue;
                if (v974 >= v975)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v976, ref v975);
                v976[v974] = v973;
                v974++;
            }
        }
        finally
        {
            v972.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v976, v974);
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectIntersectArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v977;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v978;
        int v979;
        v978 = new HashSet<int>();
        v977 = 0;
        for (; v977 < ArrayItems.Length; v977++)
            v978.Add((ArrayItems[v977] + 50));
        v979 = 0;
        for (; v979 < ArrayItems2.Length; v979++)
        {
            if (!(v978.Remove(ArrayItems2[v979])))
                continue;
            yield return ArrayItems2[v979];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectIntersectArraySelectRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v980;
        v980 = 0;
        for (; v980 < ArrayItems2.Length; v980++)
            yield return (ArrayItems2[v980] + 50);
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectIntersectArraySelectRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v981;
        if (ArraySelectIntersectArraySelectRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v982;
        IEnumerator<int> v983;
        int v984;
        v983 = ArraySelectIntersectArraySelectRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v982 = new HashSet<int>();
        v981 = 0;
        for (; v981 < ArrayItems.Length; v981++)
            v982.Add((ArrayItems[v981] + 50));
        try
        {
            while (v983.MoveNext())
            {
                v984 = v983.Current;
                if (!(v982.Remove(v984)))
                    continue;
                yield return v984;
            }
        }
        finally
        {
            v983.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereIntersectArrayWhereRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v985;
        v985 = 0;
        for (; v985 < ArrayItems2.Length; v985++)
        {
            if (!((ArrayItems2[v985] > 50)))
                continue;
            yield return ArrayItems2[v985];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereIntersectArrayWhereRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v986;
        if (ArrayWhereIntersectArrayWhereRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v987;
        IEnumerator<int> v988;
        v988 = ArrayWhereIntersectArrayWhereRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v987 = new HashSet<int>();
        v986 = 0;
        for (; v986 < ArrayItems.Length; v986++)
        {
            if (!((ArrayItems[v986] > 50)))
                continue;
            v987.Add(ArrayItems[v986]);
        }

        try
        {
            while (v988.MoveNext())
            {
                v986 = v988.Current;
                if (!(v987.Remove(v986)))
                    continue;
                yield return v986;
            }
        }
        finally
        {
            v988.Dispose();
        }
    }

    int ArrayIntersectArrayCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v989;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v990;
        int v991;
        int v992;
        v990 = new HashSet<int>();
        v989 = 0;
        for (; v989 < ArrayItems.Length; v989++)
            v990.Add(ArrayItems[v989]);
        v992 = 0;
        v991 = 0;
        for (; v991 < ArrayItems2.Length; v991++)
        {
            if (!(v990.Remove(ArrayItems2[v991])))
                continue;
            v992++;
        }

        return v992;
    }

    int ArrayIntersectArrayCount2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v993;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v994;
        int v995;
        int v996;
        v994 = new HashSet<int>();
        v993 = 0;
        for (; v993 < ArrayItems.Length; v993++)
            v994.Add(ArrayItems[v993]);
        v996 = 0;
        v995 = 0;
        for (; v995 < ArrayItems2.Length; v995++)
        {
            if (!(v994.Remove(ArrayItems2[v995])))
                continue;
            if (!((ArrayItems2[v995] > 70)))
                continue;
            v996++;
        }

        return v996;
    }

    int ArrayIntersectArraySumRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v997;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v998;
        int v999;
        int v1000;
        v998 = new HashSet<int>();
        v997 = 0;
        for (; v997 < ArrayItems.Length; v997++)
            v998.Add(ArrayItems[v997]);
        v1000 = 0;
        v999 = 0;
        for (; v999 < ArrayItems2.Length; v999++)
        {
            if (!(v998.Remove(ArrayItems2[v999])))
                continue;
            v1000 += ArrayItems2[v999];
        }

        return v1000;
    }

    int ArrayIntersectArraySum2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1001;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1002;
        int v1003;
        int v1004;
        int v1005;
        v1002 = new HashSet<int>();
        v1001 = 0;
        for (; v1001 < ArrayItems.Length; v1001++)
            v1002.Add(ArrayItems[v1001]);
        v1004 = 0;
        v1003 = 0;
        for (; v1003 < ArrayItems2.Length; v1003++)
        {
            if (!(v1002.Remove(ArrayItems2[v1003])))
                continue;
            v1005 = (ArrayItems2[v1003] + 10);
            v1004 += v1005;
        }

        return v1004;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1006;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1007;
        int v1008;
        HashSet<int> v1009;
        v1007 = new HashSet<int>();
        v1006 = 0;
        for (; v1006 < ArrayItems.Length; v1006++)
            v1007.Add(ArrayItems[v1006]);
        v1009 = new HashSet<int>();
        v1008 = 0;
        for (; v1008 < ArrayItems2.Length; v1008++)
        {
            if (!(v1007.Remove(ArrayItems2[v1008])))
                continue;
            if (!(v1009.Add(ArrayItems2[v1008])))
                continue;
            yield return ArrayItems2[v1008];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectArrayDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1010;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1011;
        int v1012;
        HashSet<int> v1013;
        v1011 = new HashSet<int>();
        v1010 = 0;
        for (; v1010 < ArrayItems.Length; v1010++)
            v1011.Add(ArrayItems[v1010]);
        v1013 = new HashSet<int>(EqualityComparer<int>.Default);
        v1012 = 0;
        for (; v1012 < ArrayItems2.Length; v1012++)
        {
            if (!(v1011.Remove(ArrayItems2[v1012])))
                continue;
            if (!(v1013.Add(ArrayItems2[v1012])))
                continue;
            yield return ArrayItems2[v1012];
        }
    }

    int ArrayIntersectArrayElementAtRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1014;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1015;
        int v1016;
        int v1017;
        v1015 = new HashSet<int>();
        v1014 = 0;
        for (; v1014 < ArrayItems.Length; v1014++)
            v1015.Add(ArrayItems[v1014]);
        v1017 = 0;
        v1016 = 0;
        for (; v1016 < ArrayItems2.Length; v1016++)
        {
            if (!(v1015.Remove(ArrayItems2[v1016])))
                continue;
            if (v1017 == 45)
                return ArrayItems2[v1016];
            v1017++;
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArrayIntersectArrayElementAtOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1018;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1019;
        int v1020;
        int v1021;
        v1019 = new HashSet<int>();
        v1018 = 0;
        for (; v1018 < ArrayItems.Length; v1018++)
            v1019.Add(ArrayItems[v1018]);
        v1021 = 0;
        v1020 = 0;
        for (; v1020 < ArrayItems2.Length; v1020++)
        {
            if (!(v1019.Remove(ArrayItems2[v1020])))
                continue;
            if (v1021 == 45)
                return ArrayItems2[v1020];
            v1021++;
        }

        return default(int);
    }

    int ArrayIntersectArrayFirstRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1022;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1023;
        int v1024;
        v1023 = new HashSet<int>();
        v1022 = 0;
        for (; v1022 < ArrayItems.Length; v1022++)
            v1023.Add(ArrayItems[v1022]);
        v1024 = 0;
        for (; v1024 < ArrayItems2.Length; v1024++)
        {
            if (!(v1023.Remove(ArrayItems2[v1024])))
                continue;
            return ArrayItems2[v1024];
        }

        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int ArrayIntersectArrayFirstOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1025;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1026;
        int v1027;
        v1026 = new HashSet<int>();
        v1025 = 0;
        for (; v1025 < ArrayItems.Length; v1025++)
            v1026.Add(ArrayItems[v1025]);
        v1027 = 0;
        for (; v1027 < ArrayItems2.Length; v1027++)
        {
            if (!(v1026.Remove(ArrayItems2[v1027])))
                continue;
            return ArrayItems2[v1027];
        }

        return default(int);
    }

    int ArrayIntersectArrayLastRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1028;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1029;
        int v1030;
        int? v1031;
        v1029 = new HashSet<int>();
        v1028 = 0;
        for (; v1028 < ArrayItems.Length; v1028++)
            v1029.Add(ArrayItems[v1028]);
        v1031 = null;
        v1030 = 0;
        for (; v1030 < ArrayItems2.Length; v1030++)
        {
            if (!(v1029.Remove(ArrayItems2[v1030])))
                continue;
            v1031 = ArrayItems2[v1030];
        }

        if (v1031 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1031;
    }

    int ArrayIntersectArrayLastOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1032;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1033;
        int v1034;
        int? v1035;
        v1033 = new HashSet<int>();
        v1032 = 0;
        for (; v1032 < ArrayItems.Length; v1032++)
            v1033.Add(ArrayItems[v1032]);
        v1035 = null;
        v1034 = 0;
        for (; v1034 < ArrayItems2.Length; v1034++)
        {
            if (!(v1033.Remove(ArrayItems2[v1034])))
                continue;
            v1035 = ArrayItems2[v1034];
        }

        if (v1035 == null)
            return default(int);
        else
            return (int)v1035;
    }

    int ArrayIntersectArraySingleRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1036;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1037;
        int v1038;
        int? v1039;
        v1037 = new HashSet<int>();
        v1036 = 0;
        for (; v1036 < ArrayItems.Length; v1036++)
            v1037.Add(ArrayItems[v1036]);
        v1039 = null;
        v1038 = 0;
        for (; v1038 < ArrayItems2.Length; v1038++)
        {
            if (!(v1037.Remove(ArrayItems2[v1038])))
                continue;
            if (v1039 == null)
                v1039 = ArrayItems2[v1038];
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v1039 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1039;
    }

    int ArrayIntersectArraySingle2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1040;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1041;
        int v1042;
        int? v1043;
        v1041 = new HashSet<int>();
        v1040 = 0;
        for (; v1040 < ArrayItems.Length; v1040++)
            v1041.Add(ArrayItems[v1040]);
        v1043 = null;
        v1042 = 0;
        for (; v1042 < ArrayItems2.Length; v1042++)
        {
            if (!(v1041.Remove(ArrayItems2[v1042])))
                continue;
            if ((ArrayItems2[v1042] == 76))
                if (v1043 == null)
                    v1043 = ArrayItems2[v1042];
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v1043 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1043;
    }

    int ArrayIntersectArraySingleOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1044;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1045;
        int v1046;
        int? v1047;
        v1045 = new HashSet<int>();
        v1044 = 0;
        for (; v1044 < ArrayItems.Length; v1044++)
            v1045.Add(ArrayItems[v1044]);
        v1047 = null;
        v1046 = 0;
        for (; v1046 < ArrayItems2.Length; v1046++)
        {
            if (!(v1045.Remove(ArrayItems2[v1046])))
                continue;
            if (v1047 == null)
                v1047 = ArrayItems2[v1046];
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v1047 == null)
            return default(int);
        else
            return (int)v1047;
    }

    int ArrayIntersectArrayMinRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1048;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1049;
        int v1050;
        int v1051;
        bool v1052;
        v1049 = new HashSet<int>();
        v1048 = 0;
        for (; v1048 < ArrayItems.Length; v1048++)
            v1049.Add(ArrayItems[v1048]);
        v1051 = 2147483647;
        v1052 = false;
        v1050 = 0;
        for (; v1050 < ArrayItems2.Length; v1050++)
        {
            if (!(v1049.Remove(ArrayItems2[v1050])))
                continue;
            if (ArrayItems2[v1050] >= v1051)
                continue;
            v1051 = ArrayItems2[v1050];
            v1052 = true;
        }

        if (!(v1052))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1051;
    }

    decimal ArrayIntersectArrayMin2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1053;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1054;
        int v1055;
        decimal v1056;
        bool v1057;
        decimal v1058;
        v1054 = new HashSet<int>();
        v1053 = 0;
        for (; v1053 < ArrayItems.Length; v1053++)
            v1054.Add(ArrayItems[v1053]);
        v1056 = 79228162514264337593543950335M;
        v1057 = false;
        v1055 = 0;
        for (; v1055 < ArrayItems2.Length; v1055++)
        {
            if (!(v1054.Remove(ArrayItems2[v1055])))
                continue;
            v1058 = (ArrayItems2[v1055] + 2m);
            if (v1058 >= v1056)
                continue;
            v1056 = v1058;
            v1057 = true;
        }

        if (!(v1057))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1056;
    }

    int ArrayIntersectArrayMaxRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1059;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1060;
        int v1061;
        int v1062;
        bool v1063;
        v1060 = new HashSet<int>();
        v1059 = 0;
        for (; v1059 < ArrayItems.Length; v1059++)
            v1060.Add(ArrayItems[v1059]);
        v1062 = -2147483648;
        v1063 = false;
        v1061 = 0;
        for (; v1061 < ArrayItems2.Length; v1061++)
        {
            if (!(v1060.Remove(ArrayItems2[v1061])))
                continue;
            if (ArrayItems2[v1061] <= v1062)
                continue;
            v1062 = ArrayItems2[v1061];
            v1063 = true;
        }

        if (!(v1063))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1062;
    }

    decimal ArrayIntersectArrayMax2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1064;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1065;
        int v1066;
        decimal v1067;
        bool v1068;
        decimal v1069;
        v1065 = new HashSet<int>();
        v1064 = 0;
        for (; v1064 < ArrayItems.Length; v1064++)
            v1065.Add(ArrayItems[v1064]);
        v1067 = -79228162514264337593543950335M;
        v1068 = false;
        v1066 = 0;
        for (; v1066 < ArrayItems2.Length; v1066++)
        {
            if (!(v1065.Remove(ArrayItems2[v1066])))
                continue;
            v1069 = (ArrayItems2[v1066] + 2m);
            if (v1069 <= v1067)
                continue;
            v1067 = v1069;
            v1068 = true;
        }

        if (!(v1068))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1067;
    }

    long ArrayIntersectArrayLongCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1070;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1071;
        int v1072;
        long v1073;
        v1071 = new HashSet<int>();
        v1070 = 0;
        for (; v1070 < ArrayItems.Length; v1070++)
            v1071.Add(ArrayItems[v1070]);
        v1073 = 0;
        v1072 = 0;
        for (; v1072 < ArrayItems2.Length; v1072++)
        {
            if (!(v1071.Remove(ArrayItems2[v1072])))
                continue;
            v1073++;
        }

        return v1073;
    }

    long ArrayIntersectArrayLongCount2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1074;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1075;
        int v1076;
        long v1077;
        v1075 = new HashSet<int>();
        v1074 = 0;
        for (; v1074 < ArrayItems.Length; v1074++)
            v1075.Add(ArrayItems[v1074]);
        v1077 = 0;
        v1076 = 0;
        for (; v1076 < ArrayItems2.Length; v1076++)
        {
            if (!(v1075.Remove(ArrayItems2[v1076])))
                continue;
            if (!((ArrayItems2[v1076] > 50)))
                continue;
            v1077++;
        }

        return v1077;
    }

    bool ArrayIntersectArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1078;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1079;
        int v1080;
        v1079 = new HashSet<int>();
        v1078 = 0;
        for (; v1078 < ArrayItems.Length; v1078++)
            v1079.Add(ArrayItems[v1078]);
        v1080 = 0;
        for (; v1080 < ArrayItems2.Length; v1080++)
        {
            if (!(v1079.Remove(ArrayItems2[v1080])))
                continue;
            if (ArrayItems2[v1080] == 56)
                return true;
        }

        return false;
    }

    double ArrayIntersectArrayAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1081;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1082;
        int v1083;
        double v1084;
        int v1085;
        v1082 = new HashSet<int>();
        v1081 = 0;
        for (; v1081 < ArrayItems.Length; v1081++)
            v1082.Add(ArrayItems[v1081]);
        v1084 = 0;
        v1085 = 0;
        v1083 = 0;
        for (; v1083 < ArrayItems2.Length; v1083++)
        {
            if (!(v1082.Remove(ArrayItems2[v1083])))
                continue;
            v1084 += ArrayItems2[v1083];
            v1085++;
        }

        if (v1085 == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v1084 / v1085);
    }

    double ArrayIntersectArrayAverage2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1086;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1087;
        int v1088;
        double v1089;
        int v1090;
        v1087 = new HashSet<int>();
        v1086 = 0;
        for (; v1086 < ArrayItems.Length; v1086++)
            v1087.Add(ArrayItems[v1086]);
        v1089 = 0;
        v1090 = 0;
        v1088 = 0;
        for (; v1088 < ArrayItems2.Length; v1088++)
        {
            if (!(v1087.Remove(ArrayItems2[v1088])))
                continue;
            v1089 += (ArrayItems2[v1088] + 10);
            v1090++;
        }

        if (v1090 == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v1089 / v1090);
    }

    bool ArrayIntersectArrayContains2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1091;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1092;
        int v1093;
        System.Collections.Generic.EqualityComparer<int> v1094;
        v1092 = new HashSet<int>();
        v1091 = 0;
        for (; v1091 < ArrayItems.Length; v1091++)
            v1092.Add(ArrayItems[v1091]);
        v1094 = EqualityComparer<int>.Default;
        v1093 = 0;
        for (; v1093 < ArrayItems2.Length; v1093++)
        {
            if (!(v1092.Remove(ArrayItems2[v1093])))
                continue;
            if (v1094.Equals(ArrayItems2[v1093], 56))
                return true;
        }

        return false;
    }

    System.Collections.Generic.IEnumerable<int> SelectWhereArrayIntersectSelectWhereArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v1095;
        int v1096;
        v1095 = 0;
        for (; v1095 < ArrayItems2.Length; v1095++)
        {
            v1096 = (ArrayItems2[v1095] + 10);
            if (!((v1096 > 80)))
                continue;
            yield return v1096;
        }
    }

    bool SelectWhereArrayIntersectSelectWhereArrayContainsRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1097;
        int v1098;
        if (SelectWhereArrayIntersectSelectWhereArrayContainsRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1099;
        IEnumerator<int> v1100;
        v1100 = SelectWhereArrayIntersectSelectWhereArrayContainsRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v1099 = new HashSet<int>();
        v1097 = 0;
        for (; v1097 < ArrayItems.Length; v1097++)
        {
            v1098 = (ArrayItems[v1097] + 10);
            if (!((v1098 > 80)))
                continue;
            v1099.Add(v1098);
        }

        try
        {
            while (v1100.MoveNext())
            {
                v1097 = v1100.Current;
                if (!(v1099.Remove(v1097)))
                    continue;
                if (v1097 == 112)
                    return true;
            }
        }
        finally
        {
            v1100.Dispose();
        }

        return false;
    }

    System.Collections.Generic.IEnumerable<int> RangeIntersectArrayRewritten_ProceduralLinq1()
    {
        int v1101;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1102;
        int v1103;
        v1102 = new HashSet<int>();
        v1101 = 0;
        for (; v1101 < 100; v1101++)
            v1102.Add((v1101 + 20));
        v1103 = 0;
        for (; v1103 < ArrayItems2.Length; v1103++)
        {
            if (!(v1102.Remove(ArrayItems2[v1103])))
                continue;
            yield return ArrayItems2[v1103];
        }
    }

    System.Collections.Generic.IEnumerable<int> RepeatIntersectArrayRewritten_ProceduralLinq1()
    {
        int v1104;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1105;
        int v1106;
        v1105 = new HashSet<int>();
        v1104 = 0;
        for (; v1104 < 100; v1104++)
            v1105.Add(20);
        v1106 = 0;
        for (; v1106 < ArrayItems2.Length; v1106++)
        {
            if (!(v1105.Remove(ArrayItems2[v1106])))
                continue;
            yield return ArrayItems2[v1106];
        }
    }

    System.Collections.Generic.IEnumerable<int> EmptyIntersectArrayRewritten_ProceduralLinq1()
    {
        int v1107;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1108;
        int v1109;
        v1108 = new HashSet<int>();
        v1107 = 0;
        for (; v1107 < 0; v1107++)
            v1108.Add(default(int));
        v1109 = 0;
        for (; v1109 < ArrayItems2.Length; v1109++)
        {
            if (!(v1108.Remove(ArrayItems2[v1109])))
                continue;
            yield return ArrayItems2[v1109];
        }
    }

    System.Collections.Generic.IEnumerable<int> RangeEmpty2ArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1110;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1111;
        v1111 = new HashSet<int>();
        v1110 = 0;
        for (; v1110 < ArrayItems.Length; v1110++)
        {
            if (!((false)))
                continue;
            v1111.Add(ArrayItems[v1110]);
        }

        v1110 = 0;
        for (; v1110 < ArrayItems2.Length; v1110++)
        {
            if (!(v1111.Remove(ArrayItems2[v1110])))
                continue;
            yield return ArrayItems2[v1110];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectRangeRewritten_ProceduralLinq1()
    {
        int v1112;
        v1112 = 0;
        for (; v1112 < 260; v1112++)
            yield return (v1112 + 70);
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectRangeRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1113;
        if (ArrayIntersectRangeRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1114;
        IEnumerator<int> v1115;
        int v1116;
        v1115 = ArrayIntersectRangeRewritten_ProceduralLinq1().GetEnumerator();
        v1114 = new HashSet<int>();
        v1113 = 0;
        for (; v1113 < ArrayItems.Length; v1113++)
            v1114.Add(ArrayItems[v1113]);
        try
        {
            while (v1115.MoveNext())
            {
                v1116 = v1115.Current;
                if (!(v1114.Remove(v1116)))
                    continue;
                yield return v1116;
            }
        }
        finally
        {
            v1115.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectRepeatRewritten_ProceduralLinq1()
    {
        int v1117;
        v1117 = 0;
        for (; v1117 < 100; v1117++)
            yield return 70;
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectRepeatRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1118;
        if (ArrayIntersectRepeatRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1119;
        IEnumerator<int> v1120;
        int v1121;
        v1120 = ArrayIntersectRepeatRewritten_ProceduralLinq1().GetEnumerator();
        v1119 = new HashSet<int>();
        v1118 = 0;
        for (; v1118 < ArrayItems.Length; v1118++)
            v1119.Add(ArrayItems[v1118]);
        try
        {
            while (v1120.MoveNext())
            {
                v1121 = v1120.Current;
                if (!(v1119.Remove(v1121)))
                    continue;
                yield return v1121;
            }
        }
        finally
        {
            v1120.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectEmptyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1122;
        if (Enumerable.Empty<int>() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1123;
        IEnumerator<int> v1124;
        int v1125;
        v1124 = Enumerable.Empty<int>().GetEnumerator();
        v1123 = new HashSet<int>();
        v1122 = 0;
        for (; v1122 < ArrayItems.Length; v1122++)
            v1123.Add(ArrayItems[v1122]);
        try
        {
            while (v1124.MoveNext())
            {
                v1125 = v1124.Current;
                if (!(v1123.Remove(v1125)))
                    continue;
                yield return v1125;
            }
        }
        finally
        {
            v1124.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectEmpty2Rewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v1126;
        v1126 = 0;
        for (; v1126 < ArrayItems2.Length; v1126++)
        {
            if (!((false)))
                continue;
            yield return ArrayItems2[v1126];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectEmpty2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1127;
        if (ArrayIntersectEmpty2Rewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1128;
        IEnumerator<int> v1129;
        int v1130;
        v1129 = ArrayIntersectEmpty2Rewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v1128 = new HashSet<int>();
        v1127 = 0;
        for (; v1127 < ArrayItems.Length; v1127++)
            v1128.Add(ArrayItems[v1127]);
        try
        {
            while (v1129.MoveNext())
            {
                v1130 = v1129.Current;
                if (!(v1128.Remove(v1130)))
                    continue;
                yield return v1130;
            }
        }
        finally
        {
            v1129.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectAllRewritten_ProceduralLinq1()
    {
        int v1131;
        v1131 = 0;
        for (; v1131 < 1000; v1131++)
            yield return (v1131 + 0);
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectAllRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1132;
        if (ArrayIntersectAllRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1133;
        IEnumerator<int> v1134;
        int v1135;
        v1134 = ArrayIntersectAllRewritten_ProceduralLinq1().GetEnumerator();
        v1133 = new HashSet<int>();
        v1132 = 0;
        for (; v1132 < ArrayItems.Length; v1132++)
            v1133.Add(ArrayItems[v1132]);
        try
        {
            while (v1134.MoveNext())
            {
                v1135 = v1134.Current;
                if (!(v1133.Remove(v1135)))
                    continue;
                yield return v1135;
            }
        }
        finally
        {
            v1134.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectNullRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1136;
        throw new System.InvalidOperationException("Invalid null object");
        v1136 = 0;
        for (; v1136 < ArrayItems.Length; v1136++)
            yield return ArrayItems[v1136];
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectArrayIntersectEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1137;
        if (ArrayItems == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1138;
        int v1139;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1140;
        IEnumerator<int> v1141;
        v1141 = EnumerableItems2.GetEnumerator();
        v1138 = new HashSet<int>();
        v1137 = 0;
        for (; v1137 < ArrayItems.Length; v1137++)
            v1138.Add(ArrayItems[v1137]);
        v1140 = new HashSet<int>();
        v1139 = 0;
        for (; v1139 < ArrayItems.Length; v1139++)
        {
            if (!(v1138.Remove(ArrayItems[v1139])))
                continue;
            v1140.Add(ArrayItems[v1139]);
        }

        try
        {
            while (v1141.MoveNext())
            {
                v1139 = v1141.Current;
                if (!(v1140.Remove(v1139)))
                    continue;
                yield return v1139;
            }
        }
        finally
        {
            v1141.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectArrayIntersectEnumerable2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1142;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1143;
        IEnumerator<int> v1144;
        int v1145;
        v1144 = EnumerableItems2.GetEnumerator();
        v1143 = new HashSet<int>();
        v1142 = 0;
        for (; v1142 < ArrayItems.Length; v1142++)
            v1143.Add(ArrayItems[v1142]);
        try
        {
            while (v1144.MoveNext())
            {
                v1145 = v1144.Current;
                if (!(v1143.Remove(v1145)))
                    continue;
                yield return v1145;
            }
        }
        finally
        {
            v1144.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayIntersectArrayIntersectEnumerable2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1146;
        if (ArrayIntersectArrayIntersectEnumerable2Rewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1147;
        IEnumerator<int> v1148;
        int v1149;
        v1148 = ArrayIntersectArrayIntersectEnumerable2Rewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v1147 = new HashSet<int>();
        v1146 = 0;
        for (; v1146 < ArrayItems.Length; v1146++)
            v1147.Add(ArrayItems[v1146]);
        try
        {
            while (v1148.MoveNext())
            {
                v1149 = v1148.Current;
                if (!(v1147.Remove(v1149)))
                    continue;
                yield return v1149;
            }
        }
        finally
        {
            v1148.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctIntersectArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1150;
        HashSet<int> v1151;
        v1151 = new HashSet<int>();
        v1150 = 0;
        for (; v1150 < ArrayItems.Length; v1150++)
        {
            if (!(v1151.Add(ArrayItems[v1150])))
                continue;
            yield return ArrayItems[v1150];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctIntersectArrayDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1152;
        HashSet<int> v1153;
        if (ArrayDistinctIntersectArrayDistinctRewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1154;
        IEnumerator<int> v1155;
        v1155 = ArrayDistinctIntersectArrayDistinctRewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v1153 = new HashSet<int>();
        v1154 = new HashSet<int>();
        v1152 = 0;
        for (; v1152 < ArrayItems.Length; v1152++)
        {
            if (!(v1153.Add(ArrayItems[v1152])))
                continue;
            v1154.Add(ArrayItems[v1152]);
        }

        try
        {
            while (v1155.MoveNext())
            {
                v1152 = v1155.Current;
                if (!(v1154.Remove(v1152)))
                    continue;
                yield return v1152;
            }
        }
        finally
        {
            v1155.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctIntersectArrayDistinctDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1156;
        HashSet<int> v1157;
        v1157 = new HashSet<int>();
        v1156 = 0;
        for (; v1156 < ArrayItems.Length; v1156++)
        {
            if (!(v1157.Add(ArrayItems[v1156])))
                continue;
            yield return ArrayItems[v1156];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctIntersectArrayDistinctDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1158;
        HashSet<int> v1159;
        if (ArrayDistinctIntersectArrayDistinctDistinctRewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1160;
        IEnumerator<int> v1161;
        HashSet<int> v1162;
        v1161 = ArrayDistinctIntersectArrayDistinctDistinctRewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v1159 = new HashSet<int>();
        v1160 = new HashSet<int>();
        v1158 = 0;
        for (; v1158 < ArrayItems.Length; v1158++)
        {
            if (!(v1159.Add(ArrayItems[v1158])))
                continue;
            v1160.Add(ArrayItems[v1158]);
        }

        v1162 = new HashSet<int>();
        try
        {
            while (v1161.MoveNext())
            {
                v1158 = v1161.Current;
                if (!(v1160.Remove(v1158)))
                    continue;
                if (!(v1162.Add(v1158)))
                    continue;
                yield return v1158;
            }
        }
        finally
        {
            v1161.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctIntersectArrayDistinctDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1163;
        HashSet<int> v1164;
        v1164 = new HashSet<int>(EqualityComparer<int>.Default);
        v1163 = 0;
        for (; v1163 < ArrayItems.Length; v1163++)
        {
            if (!(v1164.Add(ArrayItems[v1163])))
                continue;
            yield return ArrayItems[v1163];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctIntersectArrayDistinctDistinct2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1165;
        HashSet<int> v1166;
        if (ArrayDistinctIntersectArrayDistinctDistinct2Rewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v1167;
        IEnumerator<int> v1168;
        HashSet<int> v1169;
        v1168 = ArrayDistinctIntersectArrayDistinctDistinct2Rewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v1166 = new HashSet<int>(EqualityComparer<int>.Default);
        v1167 = new HashSet<int>();
        v1165 = 0;
        for (; v1165 < ArrayItems.Length; v1165++)
        {
            if (!(v1166.Add(ArrayItems[v1165])))
                continue;
            v1167.Add(ArrayItems[v1165]);
        }

        v1169 = new HashSet<int>(EqualityComparer<int>.Default);
        try
        {
            while (v1168.MoveNext())
            {
                v1165 = v1168.Current;
                if (!(v1167.Remove(v1165)))
                    continue;
                if (!(v1169.Add(v1165)))
                    continue;
                yield return v1165;
            }
        }
        finally
        {
            v1168.Dispose();
        }
    }
}}