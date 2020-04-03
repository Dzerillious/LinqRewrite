using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class ExceptTests
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
        TestsExtensions.TestEquals(nameof(ArrayExceptArray), ArrayExceptArray, ArrayExceptArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptSimpleList), ArrayExceptSimpleList, ArrayExceptSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptEnumerable), ArrayExceptEnumerable, ArrayExceptEnumerableRewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptMethod), ArrayExceptMethod, ArrayExceptMethodRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListExceptArray), SimpleListExceptArray, SimpleListExceptArrayRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListExceptSimpleList), SimpleListExceptSimpleList, SimpleListExceptSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListExceptEnumerable), SimpleListExceptEnumerable, SimpleListExceptEnumerableRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListExceptMethod), SimpleListExceptMethod, SimpleListExceptMethodRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableExceptArray), EnumerableExceptArray, EnumerableExceptArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableExceptSimpleList), EnumerableExceptSimpleList, EnumerableExceptSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableExceptEnumerable), EnumerableExceptEnumerable, EnumerableExceptEnumerableRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableExceptMethod), EnumerableExceptMethod, EnumerableExceptMethodRewritten);
        TestsExtensions.TestEquals(nameof(MethodExceptArray), MethodExceptArray, MethodExceptArrayRewritten);
        TestsExtensions.TestEquals(nameof(MethodExceptSimpleList), MethodExceptSimpleList, MethodExceptSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(MethodExceptEnumerable), MethodExceptEnumerable, MethodExceptEnumerableRewritten);
        TestsExtensions.TestEquals(nameof(MethodExceptMethod), MethodExceptMethod, MethodExceptMethodRewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptArrayToArray), ArrayExceptArrayToArray, ArrayExceptArrayToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptSimpleListToArray), ArrayExceptSimpleListToArray, ArrayExceptSimpleListToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptEnumerableToArray), ArrayExceptEnumerableToArray, ArrayExceptEnumerableToArrayRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListExceptArrayToArray), SimpleListExceptArrayToArray, SimpleListExceptArrayToArrayRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListExceptSimpleListToArray), SimpleListExceptSimpleListToArray, SimpleListExceptSimpleListToArrayRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListExceptEnumerableToArray), SimpleListExceptEnumerableToArray, SimpleListExceptEnumerableToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableExceptArrayToArray), EnumerableExceptArrayToArray, EnumerableExceptArrayToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableExceptSimpleListToArray), EnumerableExceptSimpleListToArray, EnumerableExceptSimpleListToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableExceptEnumerableToArray), EnumerableExceptEnumerableToArray, EnumerableExceptEnumerableToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectExceptArray), ArraySelectExceptArray, ArraySelectExceptArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectExceptArraySelect), ArraySelectExceptArraySelect, ArraySelectExceptArraySelectRewritten);
        TestsExtensions.TestEquals(nameof(ArrayWhereExceptArrayWhere), ArrayWhereExceptArrayWhere, ArrayWhereExceptArrayWhereRewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptArrayCount), ArrayExceptArrayCount, ArrayExceptArrayCountRewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptArrayCount2), ArrayExceptArrayCount2, ArrayExceptArrayCount2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptArraySum), ArrayExceptArraySum, ArrayExceptArraySumRewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptArraySum2), ArrayExceptArraySum2, ArrayExceptArraySum2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptArrayDistinct), ArrayExceptArrayDistinct, ArrayExceptArrayDistinctRewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptArrayDistinct2), ArrayExceptArrayDistinct2, ArrayExceptArrayDistinct2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptArrayElementAt), ArrayExceptArrayElementAt, ArrayExceptArrayElementAtRewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptArrayElementAtOrDefault), ArrayExceptArrayElementAtOrDefault, ArrayExceptArrayElementAtOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptArrayFirst), ArrayExceptArrayFirst, ArrayExceptArrayFirstRewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptArrayFirstOrDefault), ArrayExceptArrayFirstOrDefault, ArrayExceptArrayFirstOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptArrayLast), ArrayExceptArrayLast, ArrayExceptArrayLastRewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptArrayLastOrDefault), ArrayExceptArrayLastOrDefault, ArrayExceptArrayLastOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptArraySingle), ArrayExceptArraySingle, ArrayExceptArraySingleRewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptArraySingle2), ArrayExceptArraySingle2, ArrayExceptArraySingle2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptArraySingleOrDefault), ArrayExceptArraySingleOrDefault, ArrayExceptArraySingleOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptArrayMin), ArrayExceptArrayMin, ArrayExceptArrayMinRewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptArrayMin2), ArrayExceptArrayMin2, ArrayExceptArrayMin2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptArrayMax), ArrayExceptArrayMax, ArrayExceptArrayMaxRewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptArrayMax2), ArrayExceptArrayMax2, ArrayExceptArrayMax2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptArrayLongCount), ArrayExceptArrayLongCount, ArrayExceptArrayLongCountRewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptArrayLongCount2), ArrayExceptArrayLongCount2, ArrayExceptArrayLongCount2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptArrayContains), ArrayExceptArrayContains, ArrayExceptArrayContainsRewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptArrayAverage), ArrayExceptArrayAverage, ArrayExceptArrayAverageRewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptArrayAverage2), ArrayExceptArrayAverage2, ArrayExceptArrayAverage2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptArrayContains2), ArrayExceptArrayContains2, ArrayExceptArrayContains2Rewritten);
        TestsExtensions.TestEquals(nameof(SelectWhereArrayExceptSelectWhereArrayContains), SelectWhereArrayExceptSelectWhereArrayContains, SelectWhereArrayExceptSelectWhereArrayContainsRewritten);
        TestsExtensions.TestEquals(nameof(RangeExceptArray), RangeExceptArray, RangeExceptArrayRewritten);
        TestsExtensions.TestEquals(nameof(RepeatExceptArray), RepeatExceptArray, RepeatExceptArrayRewritten);
        TestsExtensions.TestEquals(nameof(EmptyExceptArray), EmptyExceptArray, EmptyExceptArrayRewritten);
        TestsExtensions.TestEquals(nameof(RangeEmpty2Array), RangeEmpty2Array, RangeEmpty2ArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptRange), ArrayExceptRange, ArrayExceptRangeRewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptRepeat), ArrayExceptRepeat, ArrayExceptRepeatRewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptEmpty), ArrayExceptEmpty, ArrayExceptEmptyRewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptEmpty2), ArrayExceptEmpty2, ArrayExceptEmpty2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptAll), ArrayExceptAll, ArrayExceptAllRewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptNull), ArrayExceptNull, ArrayExceptNullRewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptArrayExceptEnumerable), ArrayExceptArrayExceptEnumerable, ArrayExceptArrayExceptEnumerableRewritten);
        TestsExtensions.TestEquals(nameof(ArrayExceptArrayExceptEnumerable2), ArrayExceptArrayExceptEnumerable2, ArrayExceptArrayExceptEnumerable2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayDistinctExceptArrayDistinct), ArrayDistinctExceptArrayDistinct, ArrayDistinctExceptArrayDistinctRewritten);
        TestsExtensions.TestEquals(nameof(ArrayDistinctExceptArrayDistinctDistinct), ArrayDistinctExceptArrayDistinctDistinct, ArrayDistinctExceptArrayDistinctDistinctRewritten);
        TestsExtensions.TestEquals(nameof(ArrayDistinctExceptArrayDistinctDistinct2), ArrayDistinctExceptArrayDistinctDistinct2, ArrayDistinctExceptArrayDistinctDistinct2Rewritten);
    }

    [NoRewrite]
    public IEnumerable<int> ArrayExceptArray()
    {
        return ArrayItems.Except(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> ArrayExceptArrayRewritten()
    {
        return ArrayExceptArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayExceptSimpleList()
    {
        return ArrayItems.Except(SimpleListItems2);
    } //EndMethod

    public IEnumerable<int> ArrayExceptSimpleListRewritten()
    {
        return ArrayExceptSimpleListRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayExceptEnumerable()
    {
        return ArrayItems.Except(EnumerableItems2);
    } //EndMethod

    public IEnumerable<int> ArrayExceptEnumerableRewritten()
    {
        return ArrayExceptEnumerableRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayExceptMethod()
    {
        return ArrayItems.Except(MethodEnumerable2());
    } //EndMethod

    public IEnumerable<int> ArrayExceptMethodRewritten()
    {
        return ArrayExceptMethodRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListExceptArray()
    {
        return SimpleListItems.Except(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> SimpleListExceptArrayRewritten()
    {
        return SimpleListExceptArrayRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListExceptSimpleList()
    {
        return SimpleListItems.Except(SimpleListItems2);
    } //EndMethod

    public IEnumerable<int> SimpleListExceptSimpleListRewritten()
    {
        return SimpleListExceptSimpleListRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListExceptEnumerable()
    {
        return SimpleListItems.Except(EnumerableItems2);
    } //EndMethod

    public IEnumerable<int> SimpleListExceptEnumerableRewritten()
    {
        return SimpleListExceptEnumerableRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListExceptMethod()
    {
        return SimpleListItems.Except(MethodEnumerable2());
    } //EndMethod

    public IEnumerable<int> SimpleListExceptMethodRewritten()
    {
        return SimpleListExceptMethodRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableExceptArray()
    {
        return EnumerableItems.Except(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> EnumerableExceptArrayRewritten()
    {
        return EnumerableExceptArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableExceptSimpleList()
    {
        return EnumerableItems.Except(SimpleListItems2);
    } //EndMethod

    public IEnumerable<int> EnumerableExceptSimpleListRewritten()
    {
        return EnumerableExceptSimpleListRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableExceptEnumerable()
    {
        return EnumerableItems.Except(EnumerableItems2);
    } //EndMethod

    public IEnumerable<int> EnumerableExceptEnumerableRewritten()
    {
        return EnumerableExceptEnumerableRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableExceptMethod()
    {
        return EnumerableItems.Except(MethodEnumerable2());
    } //EndMethod

    public IEnumerable<int> EnumerableExceptMethodRewritten()
    {
        return EnumerableExceptMethodRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> MethodExceptArray()
    {
        return MethodEnumerable().Except(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> MethodExceptArrayRewritten()
    {
        return MethodEnumerable().Except(ArrayItems2);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> MethodExceptSimpleList()
    {
        return MethodEnumerable().Except(SimpleListItems2);
    } //EndMethod

    public IEnumerable<int> MethodExceptSimpleListRewritten()
    {
        return MethodEnumerable().Except(SimpleListItems2);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> MethodExceptEnumerable()
    {
        return MethodEnumerable().Except(EnumerableItems2);
    } //EndMethod

    public IEnumerable<int> MethodExceptEnumerableRewritten()
    {
        return MethodEnumerable().Except(EnumerableItems2);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> MethodExceptMethod()
    {
        return MethodEnumerable().Except(MethodEnumerable2());
    } //EndMethod

    public IEnumerable<int> MethodExceptMethodRewritten()
    {
        return MethodEnumerable().Except(MethodEnumerable2());
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayExceptArrayToArray()
    {
        return ArrayItems.Except(ArrayItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayExceptArrayToArrayRewritten()
    {
        return ArrayExceptArrayToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayExceptSimpleListToArray()
    {
        return ArrayItems.Except(SimpleListItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayExceptSimpleListToArrayRewritten()
    {
        return ArrayExceptSimpleListToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayExceptEnumerableToArray()
    {
        return ArrayItems.Except(EnumerableItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayExceptEnumerableToArrayRewritten()
    {
        return ArrayExceptEnumerableToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListExceptArrayToArray()
    {
        return SimpleListItems.Except(ArrayItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> SimpleListExceptArrayToArrayRewritten()
    {
        return SimpleListExceptArrayToArrayRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListExceptSimpleListToArray()
    {
        return SimpleListItems.Except(SimpleListItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> SimpleListExceptSimpleListToArrayRewritten()
    {
        return SimpleListExceptSimpleListToArrayRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListExceptEnumerableToArray()
    {
        return SimpleListItems.Except(EnumerableItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> SimpleListExceptEnumerableToArrayRewritten()
    {
        return SimpleListExceptEnumerableToArrayRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableExceptArrayToArray()
    {
        return EnumerableItems.Except(ArrayItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableExceptArrayToArrayRewritten()
    {
        return EnumerableExceptArrayToArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableExceptSimpleListToArray()
    {
        return EnumerableItems.Except(SimpleListItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableExceptSimpleListToArrayRewritten()
    {
        return EnumerableExceptSimpleListToArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableExceptEnumerableToArray()
    {
        return EnumerableItems.Except(EnumerableItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableExceptEnumerableToArrayRewritten()
    {
        return EnumerableExceptEnumerableToArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectExceptArray()
    {
        return ArrayItems.Select(x => x + 50).Except(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> ArraySelectExceptArrayRewritten()
    {
        return ArraySelectExceptArrayRewritten_ProceduralLinq1(ArrayItems, x => x + 50);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectExceptArraySelect()
    {
        return ArrayItems.Select(x => x + 50).Except(ArrayItems2.Select(x => x + 50));
    } //EndMethod

    public IEnumerable<int> ArraySelectExceptArraySelectRewritten()
    {
        return ArraySelectExceptArraySelectRewritten_ProceduralLinq2(ArrayItems, x => x + 50);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayWhereExceptArrayWhere()
    {
        return ArrayItems.Where(x => x > 50).Except(ArrayItems2.Where(x => x > 50));
    } //EndMethod

    public IEnumerable<int> ArrayWhereExceptArrayWhereRewritten()
    {
        return ArrayWhereExceptArrayWhereRewritten_ProceduralLinq2(ArrayItems, x => x > 50);
    } //EndMethod

    [NoRewrite]
    public int ArrayExceptArrayCount()
    {
        return ArrayItems.Except(ArrayItems2).Count();
    } //EndMethod

    public int ArrayExceptArrayCountRewritten()
    {
        return ArrayExceptArrayCountRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayExceptArrayCount2()
    {
        return ArrayItems.Except(ArrayItems2).Count(x => x > 70);
    } //EndMethod

    public int ArrayExceptArrayCount2Rewritten()
    {
        return ArrayExceptArrayCount2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayExceptArraySum()
    {
        return ArrayItems.Except(ArrayItems2).Sum();
    } //EndMethod

    public int ArrayExceptArraySumRewritten()
    {
        return ArrayExceptArraySumRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayExceptArraySum2()
    {
        return ArrayItems.Except(ArrayItems2).Sum(x => x + 10);
    } //EndMethod

    public int ArrayExceptArraySum2Rewritten()
    {
        return ArrayExceptArraySum2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayExceptArrayDistinct()
    {
        return ArrayItems.Except(ArrayItems2).Distinct();
    } //EndMethod

    public IEnumerable<int> ArrayExceptArrayDistinctRewritten()
    {
        return ArrayExceptArrayDistinctRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayExceptArrayDistinct2()
    {
        return ArrayItems.Except(ArrayItems2).Distinct(EqualityComparer<int>.Default);
    } //EndMethod

    public IEnumerable<int> ArrayExceptArrayDistinct2Rewritten()
    {
        return ArrayExceptArrayDistinct2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayExceptArrayElementAt()
    {
        return ArrayItems.Except(ArrayItems2).ElementAt(45);
    } //EndMethod

    public int ArrayExceptArrayElementAtRewritten()
    {
        return ArrayExceptArrayElementAtRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayExceptArrayElementAtOrDefault()
    {
        return ArrayItems.Except(ArrayItems2).ElementAtOrDefault(45);
    } //EndMethod

    public int ArrayExceptArrayElementAtOrDefaultRewritten()
    {
        return ArrayExceptArrayElementAtOrDefaultRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayExceptArrayFirst()
    {
        return ArrayItems.Except(ArrayItems2).First();
    } //EndMethod

    public int ArrayExceptArrayFirstRewritten()
    {
        return ArrayExceptArrayFirstRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayExceptArrayFirstOrDefault()
    {
        return ArrayItems.Except(ArrayItems2).FirstOrDefault();
    } //EndMethod

    public int ArrayExceptArrayFirstOrDefaultRewritten()
    {
        return ArrayExceptArrayFirstOrDefaultRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayExceptArrayLast()
    {
        return ArrayItems.Except(ArrayItems2).Last();
    } //EndMethod

    public int ArrayExceptArrayLastRewritten()
    {
        return ArrayExceptArrayLastRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayExceptArrayLastOrDefault()
    {
        return ArrayItems.Except(ArrayItems2).LastOrDefault();
    } //EndMethod

    public int ArrayExceptArrayLastOrDefaultRewritten()
    {
        return ArrayExceptArrayLastOrDefaultRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayExceptArraySingle()
    {
        return ArrayItems.Except(ArrayItems2).Single();
    } //EndMethod

    public int ArrayExceptArraySingleRewritten()
    {
        return ArrayExceptArraySingleRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayExceptArraySingle2()
    {
        return ArrayItems.Except(ArrayItems2).Single(x => x == 76);
    } //EndMethod

    public int ArrayExceptArraySingle2Rewritten()
    {
        return ArrayExceptArraySingle2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayExceptArraySingleOrDefault()
    {
        return ArrayItems.Except(ArrayItems2).SingleOrDefault();
    } //EndMethod

    public int ArrayExceptArraySingleOrDefaultRewritten()
    {
        return ArrayExceptArraySingleOrDefaultRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayExceptArrayMin()
    {
        return ArrayItems.Except(ArrayItems2).Min();
    } //EndMethod

    public int ArrayExceptArrayMinRewritten()
    {
        return ArrayExceptArrayMinRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public decimal ArrayExceptArrayMin2()
    {
        return ArrayItems.Except(ArrayItems2).Min(x => x + 2m);
    } //EndMethod

    public decimal ArrayExceptArrayMin2Rewritten()
    {
        return ArrayExceptArrayMin2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayExceptArrayMax()
    {
        return ArrayItems.Except(ArrayItems2).Max();
    } //EndMethod

    public int ArrayExceptArrayMaxRewritten()
    {
        return ArrayExceptArrayMaxRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public decimal ArrayExceptArrayMax2()
    {
        return ArrayItems.Except(ArrayItems2).Max(x => x + 2m);
    } //EndMethod

    public decimal ArrayExceptArrayMax2Rewritten()
    {
        return ArrayExceptArrayMax2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public long ArrayExceptArrayLongCount()
    {
        return ArrayItems.Except(ArrayItems2).LongCount();
    } //EndMethod

    public long ArrayExceptArrayLongCountRewritten()
    {
        return ArrayExceptArrayLongCountRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public long ArrayExceptArrayLongCount2()
    {
        return ArrayItems.Except(ArrayItems2).LongCount(x => x > 50);
    } //EndMethod

    public long ArrayExceptArrayLongCount2Rewritten()
    {
        return ArrayExceptArrayLongCount2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArrayExceptArrayContains()
    {
        return ArrayItems.Except(ArrayItems2).Contains(56);
    } //EndMethod

    public bool ArrayExceptArrayContainsRewritten()
    {
        return ArrayExceptArrayContainsRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double ArrayExceptArrayAverage()
    {
        return ArrayItems.Except(ArrayItems2).Average();
    } //EndMethod

    public double ArrayExceptArrayAverageRewritten()
    {
        return ArrayExceptArrayAverageRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double ArrayExceptArrayAverage2()
    {
        return ArrayItems.Except(ArrayItems2).Average(x => x + 10);
    } //EndMethod

    public double ArrayExceptArrayAverage2Rewritten()
    {
        return ArrayExceptArrayAverage2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArrayExceptArrayContains2()
    {
        return ArrayItems.Except(ArrayItems2).Contains(56, EqualityComparer<int>.Default);
    } //EndMethod

    public bool ArrayExceptArrayContains2Rewritten()
    {
        return ArrayExceptArrayContains2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool SelectWhereArrayExceptSelectWhereArrayContains()
    {
        return ArrayItems.Select(x => x + 10).Where(x => x > 80).Except(ArrayItems2.Select(x => x + 10).Where(x => x > 80)).Contains(112);
    } //EndMethod

    public bool SelectWhereArrayExceptSelectWhereArrayContainsRewritten()
    {
        return SelectWhereArrayExceptSelectWhereArrayContainsRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeExceptArray()
    {
        return Enumerable.Range(20, 100).Except(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> RangeExceptArrayRewritten()
    {
        return RangeExceptArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatExceptArray()
    {
        return Enumerable.Repeat(20, 100).Except(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> RepeatExceptArrayRewritten()
    {
        return RepeatExceptArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EmptyExceptArray()
    {
        return Enumerable.Empty<int>().Except(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> EmptyExceptArrayRewritten()
    {
        return EmptyExceptArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeEmpty2Array()
    {
        return ArrayItems.Where(x => false).Except(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> RangeEmpty2ArrayRewritten()
    {
        return RangeEmpty2ArrayRewritten_ProceduralLinq1(ArrayItems, x => false);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayExceptRange()
    {
        return ArrayItems.Except(Enumerable.Range(70, 260));
    } //EndMethod

    public IEnumerable<int> ArrayExceptRangeRewritten()
    {
        return ArrayExceptRangeRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayExceptRepeat()
    {
        return ArrayItems.Except(Enumerable.Repeat(70, 100));
    } //EndMethod

    public IEnumerable<int> ArrayExceptRepeatRewritten()
    {
        return ArrayExceptRepeatRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayExceptEmpty()
    {
        return ArrayItems.Except(Enumerable.Empty<int>());
    } //EndMethod

    public IEnumerable<int> ArrayExceptEmptyRewritten()
    {
        return ArrayExceptEmptyRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayExceptEmpty2()
    {
        return ArrayItems.Except(ArrayItems2.Where(x => false));
    } //EndMethod

    public IEnumerable<int> ArrayExceptEmpty2Rewritten()
    {
        return ArrayExceptEmpty2Rewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayExceptAll()
    {
        return ArrayItems.Except(Enumerable.Range(0, 1000));
    } //EndMethod

    public IEnumerable<int> ArrayExceptAllRewritten()
    {
        return ArrayExceptAllRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayExceptNull()
    {
        return ArrayItems.Except(null);
    } //EndMethod

    public IEnumerable<int> ArrayExceptNullRewritten()
    {
        return ArrayExceptNullRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayExceptArrayExceptEnumerable()
    {
        return ArrayItems.Except(ArrayItems).Except(EnumerableItems2);
    } //EndMethod

    public IEnumerable<int> ArrayExceptArrayExceptEnumerableRewritten()
    {
        return ArrayExceptArrayExceptEnumerableRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayExceptArrayExceptEnumerable2()
    {
        return ArrayItems.Except(ArrayItems.Except(EnumerableItems2));
    } //EndMethod

    public IEnumerable<int> ArrayExceptArrayExceptEnumerable2Rewritten()
    {
        return ArrayExceptArrayExceptEnumerable2Rewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayDistinctExceptArrayDistinct()
    {
        return ArrayItems.Distinct().Except(ArrayItems.Distinct());
    } //EndMethod

    public IEnumerable<int> ArrayDistinctExceptArrayDistinctRewritten()
    {
        return ArrayDistinctExceptArrayDistinctRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayDistinctExceptArrayDistinctDistinct()
    {
        return ArrayItems.Distinct().Except(ArrayItems.Distinct()).Distinct();
    } //EndMethod

    public IEnumerable<int> ArrayDistinctExceptArrayDistinctDistinctRewritten()
    {
        return ArrayDistinctExceptArrayDistinctDistinctRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayDistinctExceptArrayDistinctDistinct2()
    {
        return ArrayItems.Distinct(EqualityComparer<int>.Default).Except(ArrayItems.Distinct(EqualityComparer<int>.Default)).Distinct(EqualityComparer<int>.Default);
    } //EndMethod

    public IEnumerable<int> ArrayDistinctExceptArrayDistinctDistinct2Rewritten()
    {
        return ArrayDistinctExceptArrayDistinctDistinct2Rewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    System.Collections.Generic.IEnumerable<int> ArrayExceptArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v556;
        int v557;
        HashSet<int> v558;
        v558 = new HashSet<int>();
        v557 = 0;
        for (; v557 < ArrayItems2.Length; v557++)
            v558.Add(ArrayItems2[v557]);
        v556 = 0;
        for (; v556 < ArrayItems.Length; v556++)
        {
            if (!(v558.Add(ArrayItems[v556])))
                continue;
            yield return ArrayItems[v556];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v559;
        IEnumerator<int> v560;
        HashSet<int> v561;
        v560 = SimpleListItems2.GetEnumerator();
        v561 = new HashSet<int>();
        try
        {
            while (v560.MoveNext())
                v561.Add(v560.Current);
        }
        finally
        {
            v560.Dispose();
        }

        v559 = 0;
        for (; v559 < ArrayItems.Length; v559++)
        {
            if (!(v561.Add(ArrayItems[v559])))
                continue;
            yield return ArrayItems[v559];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v562;
        IEnumerator<int> v563;
        HashSet<int> v564;
        v563 = EnumerableItems2.GetEnumerator();
        v564 = new HashSet<int>();
        try
        {
            while (v563.MoveNext())
                v564.Add(v563.Current);
        }
        finally
        {
            v563.Dispose();
        }

        v562 = 0;
        for (; v562 < ArrayItems.Length; v562++)
        {
            if (!(v564.Add(ArrayItems[v562])))
                continue;
            yield return ArrayItems[v562];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v565;
        IEnumerator<int> v566;
        HashSet<int> v567;
        v566 = MethodEnumerable2().GetEnumerator();
        v567 = new HashSet<int>();
        try
        {
            while (v566.MoveNext())
                v567.Add(v566.Current);
        }
        finally
        {
            v566.Dispose();
        }

        v565 = 0;
        for (; v565 < ArrayItems.Length; v565++)
        {
            if (!(v567.Add(ArrayItems[v565])))
                continue;
            yield return ArrayItems[v565];
        }
    }

    System.Collections.Generic.IEnumerable<int> SimpleListExceptArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v568;
        int v569;
        HashSet<int> v570;
        int v571;
        v568 = SimpleListItems.GetEnumerator();
        v570 = new HashSet<int>();
        v569 = 0;
        for (; v569 < ArrayItems2.Length; v569++)
            v570.Add(ArrayItems2[v569]);
        try
        {
            while (v568.MoveNext())
            {
                v571 = v568.Current;
                if (!(v570.Add(v571)))
                    continue;
                yield return v571;
            }
        }
        finally
        {
            v568.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> SimpleListExceptSimpleListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v572;
        IEnumerator<int> v573;
        HashSet<int> v574;
        int v575;
        v573 = SimpleListItems2.GetEnumerator();
        v572 = SimpleListItems.GetEnumerator();
        v574 = new HashSet<int>();
        try
        {
            while (v573.MoveNext())
                v574.Add(v573.Current);
        }
        finally
        {
            v573.Dispose();
        }

        try
        {
            while (v572.MoveNext())
            {
                v575 = v572.Current;
                if (!(v574.Add(v575)))
                    continue;
                yield return v575;
            }
        }
        finally
        {
            v572.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> SimpleListExceptEnumerableRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v576;
        IEnumerator<int> v577;
        HashSet<int> v578;
        int v579;
        v577 = EnumerableItems2.GetEnumerator();
        v576 = SimpleListItems.GetEnumerator();
        v578 = new HashSet<int>();
        try
        {
            while (v577.MoveNext())
                v578.Add(v577.Current);
        }
        finally
        {
            v577.Dispose();
        }

        try
        {
            while (v576.MoveNext())
            {
                v579 = v576.Current;
                if (!(v578.Add(v579)))
                    continue;
                yield return v579;
            }
        }
        finally
        {
            v576.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> SimpleListExceptMethodRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v580;
        IEnumerator<int> v581;
        HashSet<int> v582;
        int v583;
        v581 = MethodEnumerable2().GetEnumerator();
        v580 = SimpleListItems.GetEnumerator();
        v582 = new HashSet<int>();
        try
        {
            while (v581.MoveNext())
                v582.Add(v581.Current);
        }
        finally
        {
            v581.Dispose();
        }

        try
        {
            while (v580.MoveNext())
            {
                v583 = v580.Current;
                if (!(v582.Add(v583)))
                    continue;
                yield return v583;
            }
        }
        finally
        {
            v580.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableExceptArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v584;
        int v585;
        HashSet<int> v586;
        int v587;
        v584 = EnumerableItems.GetEnumerator();
        v586 = new HashSet<int>();
        v585 = 0;
        for (; v585 < ArrayItems2.Length; v585++)
            v586.Add(ArrayItems2[v585]);
        try
        {
            while (v584.MoveNext())
            {
                v587 = v584.Current;
                if (!(v586.Add(v587)))
                    continue;
                yield return v587;
            }
        }
        finally
        {
            v584.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableExceptSimpleListRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v588;
        IEnumerator<int> v589;
        HashSet<int> v590;
        int v591;
        v589 = SimpleListItems2.GetEnumerator();
        v588 = EnumerableItems.GetEnumerator();
        v590 = new HashSet<int>();
        try
        {
            while (v589.MoveNext())
                v590.Add(v589.Current);
        }
        finally
        {
            v589.Dispose();
        }

        try
        {
            while (v588.MoveNext())
            {
                v591 = v588.Current;
                if (!(v590.Add(v591)))
                    continue;
                yield return v591;
            }
        }
        finally
        {
            v588.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableExceptEnumerableRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v592;
        IEnumerator<int> v593;
        HashSet<int> v594;
        int v595;
        v593 = EnumerableItems2.GetEnumerator();
        v592 = EnumerableItems.GetEnumerator();
        v594 = new HashSet<int>();
        try
        {
            while (v593.MoveNext())
                v594.Add(v593.Current);
        }
        finally
        {
            v593.Dispose();
        }

        try
        {
            while (v592.MoveNext())
            {
                v595 = v592.Current;
                if (!(v594.Add(v595)))
                    continue;
                yield return v595;
            }
        }
        finally
        {
            v592.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableExceptMethodRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v596;
        IEnumerator<int> v597;
        HashSet<int> v598;
        int v599;
        v597 = MethodEnumerable2().GetEnumerator();
        v596 = EnumerableItems.GetEnumerator();
        v598 = new HashSet<int>();
        try
        {
            while (v597.MoveNext())
                v598.Add(v597.Current);
        }
        finally
        {
            v597.Dispose();
        }

        try
        {
            while (v596.MoveNext())
            {
                v599 = v596.Current;
                if (!(v598.Add(v599)))
                    continue;
                yield return v599;
            }
        }
        finally
        {
            v596.Dispose();
        }
    }

    int[] ArrayExceptArrayToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v600;
        int v601;
        HashSet<int> v602;
        int v603;
        int v604;
        int v605;
        int[] v606;
        v602 = new HashSet<int>();
        v601 = 0;
        for (; v601 < ArrayItems2.Length; v601++)
            v602.Add(ArrayItems2[v601]);
        v603 = 0;
        v604 = (LinqRewrite.Core.IntExtensions.Log2((uint)(ArrayItems2.Length + ArrayItems.Length)) - 3);
        v604 -= (v604 % 2);
        v605 = 8;
        v606 = new int[8];
        v600 = 0;
        for (; v600 < ArrayItems.Length; v600++)
        {
            if (!(v602.Add(ArrayItems[v600])))
                continue;
            if (v603 >= v605)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems2.Length + ArrayItems.Length), ref v606, ref v604, out v605);
            v606[v603] = ArrayItems[v600];
            v603++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v606, v603);
    }

    int[] ArrayExceptSimpleListToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v607;
        IEnumerator<int> v608;
        HashSet<int> v609;
        int v610;
        int v611;
        int[] v612;
        v608 = SimpleListItems2.GetEnumerator();
        v609 = new HashSet<int>();
        try
        {
            while (v608.MoveNext())
                v609.Add(v608.Current);
        }
        finally
        {
            v608.Dispose();
        }

        v610 = 0;
        v611 = 8;
        v612 = new int[8];
        v607 = 0;
        for (; v607 < ArrayItems.Length; v607++)
        {
            if (!(v609.Add(ArrayItems[v607])))
                continue;
            if (v610 >= v611)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v612, ref v611);
            v612[v610] = ArrayItems[v607];
            v610++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v612, v610);
    }

    int[] ArrayExceptEnumerableToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v613;
        IEnumerator<int> v614;
        HashSet<int> v615;
        int v616;
        int v617;
        int[] v618;
        v614 = EnumerableItems2.GetEnumerator();
        v615 = new HashSet<int>();
        try
        {
            while (v614.MoveNext())
                v615.Add(v614.Current);
        }
        finally
        {
            v614.Dispose();
        }

        v616 = 0;
        v617 = 8;
        v618 = new int[8];
        v613 = 0;
        for (; v613 < ArrayItems.Length; v613++)
        {
            if (!(v615.Add(ArrayItems[v613])))
                continue;
            if (v616 >= v617)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v618, ref v617);
            v618[v616] = ArrayItems[v613];
            v616++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v618, v616);
    }

    int[] SimpleListExceptArrayToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v619;
        int v620;
        HashSet<int> v621;
        int v622;
        int v623;
        int v624;
        int[] v625;
        v619 = SimpleListItems.GetEnumerator();
        v621 = new HashSet<int>();
        v620 = 0;
        for (; v620 < ArrayItems2.Length; v620++)
            v621.Add(ArrayItems2[v620]);
        v623 = 0;
        v624 = 8;
        v625 = new int[8];
        try
        {
            while (v619.MoveNext())
            {
                v622 = v619.Current;
                if (!(v621.Add(v622)))
                    continue;
                if (v623 >= v624)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v625, ref v624);
                v625[v623] = v622;
                v623++;
            }
        }
        finally
        {
            v619.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v625, v623);
    }

    int[] SimpleListExceptSimpleListToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v626;
        IEnumerator<int> v627;
        HashSet<int> v628;
        int v629;
        int v630;
        int v631;
        int[] v632;
        v627 = SimpleListItems2.GetEnumerator();
        v626 = SimpleListItems.GetEnumerator();
        v628 = new HashSet<int>();
        try
        {
            while (v627.MoveNext())
                v628.Add(v627.Current);
        }
        finally
        {
            v627.Dispose();
        }

        v630 = 0;
        v631 = 8;
        v632 = new int[8];
        try
        {
            while (v626.MoveNext())
            {
                v629 = v626.Current;
                if (!(v628.Add(v629)))
                    continue;
                if (v630 >= v631)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v632, ref v631);
                v632[v630] = v629;
                v630++;
            }
        }
        finally
        {
            v626.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v632, v630);
    }

    int[] SimpleListExceptEnumerableToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v633;
        IEnumerator<int> v634;
        HashSet<int> v635;
        int v636;
        int v637;
        int v638;
        int[] v639;
        v634 = EnumerableItems2.GetEnumerator();
        v633 = SimpleListItems.GetEnumerator();
        v635 = new HashSet<int>();
        try
        {
            while (v634.MoveNext())
                v635.Add(v634.Current);
        }
        finally
        {
            v634.Dispose();
        }

        v637 = 0;
        v638 = 8;
        v639 = new int[8];
        try
        {
            while (v633.MoveNext())
            {
                v636 = v633.Current;
                if (!(v635.Add(v636)))
                    continue;
                if (v637 >= v638)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v639, ref v638);
                v639[v637] = v636;
                v637++;
            }
        }
        finally
        {
            v633.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v639, v637);
    }

    int[] EnumerableExceptArrayToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v640;
        int v641;
        HashSet<int> v642;
        int v643;
        int v644;
        int v645;
        int[] v646;
        v640 = EnumerableItems.GetEnumerator();
        v642 = new HashSet<int>();
        v641 = 0;
        for (; v641 < ArrayItems2.Length; v641++)
            v642.Add(ArrayItems2[v641]);
        v644 = 0;
        v645 = 8;
        v646 = new int[8];
        try
        {
            while (v640.MoveNext())
            {
                v643 = v640.Current;
                if (!(v642.Add(v643)))
                    continue;
                if (v644 >= v645)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v646, ref v645);
                v646[v644] = v643;
                v644++;
            }
        }
        finally
        {
            v640.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v646, v644);
    }

    int[] EnumerableExceptSimpleListToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v647;
        IEnumerator<int> v648;
        HashSet<int> v649;
        int v650;
        int v651;
        int v652;
        int[] v653;
        v648 = SimpleListItems2.GetEnumerator();
        v647 = EnumerableItems.GetEnumerator();
        v649 = new HashSet<int>();
        try
        {
            while (v648.MoveNext())
                v649.Add(v648.Current);
        }
        finally
        {
            v648.Dispose();
        }

        v651 = 0;
        v652 = 8;
        v653 = new int[8];
        try
        {
            while (v647.MoveNext())
            {
                v650 = v647.Current;
                if (!(v649.Add(v650)))
                    continue;
                if (v651 >= v652)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v653, ref v652);
                v653[v651] = v650;
                v651++;
            }
        }
        finally
        {
            v647.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v653, v651);
    }

    int[] EnumerableExceptEnumerableToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v654;
        IEnumerator<int> v655;
        HashSet<int> v656;
        int v657;
        int v658;
        int v659;
        int[] v660;
        v655 = EnumerableItems2.GetEnumerator();
        v654 = EnumerableItems.GetEnumerator();
        v656 = new HashSet<int>();
        try
        {
            while (v655.MoveNext())
                v656.Add(v655.Current);
        }
        finally
        {
            v655.Dispose();
        }

        v658 = 0;
        v659 = 8;
        v660 = new int[8];
        try
        {
            while (v654.MoveNext())
            {
                v657 = v654.Current;
                if (!(v656.Add(v657)))
                    continue;
                if (v658 >= v659)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v660, ref v659);
                v660[v658] = v657;
                v658++;
            }
        }
        finally
        {
            v654.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v660, v658);
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectExceptArrayRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int> v662)
    {
        int v661;
        int v663;
        HashSet<int> v664;
        int v665;
        v664 = new HashSet<int>();
        v663 = 0;
        for (; v663 < ArrayItems2.Length; v663++)
            v664.Add(ArrayItems2[v663]);
        v661 = 0;
        for (; v661 < ArrayItems.Length; v661++)
        {
            v665 = v662(ArrayItems[v661]);
            if (!(v664.Add(v665)))
                continue;
            yield return v665;
        }
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectExceptArraySelectRewritten_ProceduralLinq1(int[] ArrayItems2, System.Func<int, int> v667)
    {
        int v666;
        v666 = 0;
        for (; v666 < ArrayItems2.Length; v666++)
            yield return v667(ArrayItems2[v666]);
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectExceptArraySelectRewritten_ProceduralLinq2(int[] ArrayItems, System.Func<int, int> v669)
    {
        int v668;
        IEnumerator<int> v670;
        HashSet<int> v671;
        int v672;
        v670 = ArraySelectExceptArraySelectRewritten_ProceduralLinq1(ArrayItems2, x => x + 50).GetEnumerator();
        v671 = new HashSet<int>();
        try
        {
            while (v670.MoveNext())
                v671.Add(v670.Current);
        }
        finally
        {
            v670.Dispose();
        }

        v668 = 0;
        for (; v668 < ArrayItems.Length; v668++)
        {
            v672 = v669(ArrayItems[v668]);
            if (!(v671.Add(v672)))
                continue;
            yield return v672;
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereExceptArrayWhereRewritten_ProceduralLinq1(int[] ArrayItems2, System.Func<int, bool> v674)
    {
        int v673;
        v673 = 0;
        for (; v673 < ArrayItems2.Length; v673++)
        {
            if (!(v674(ArrayItems2[v673])))
                continue;
            yield return ArrayItems2[v673];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereExceptArrayWhereRewritten_ProceduralLinq2(int[] ArrayItems, System.Func<int, bool> v676)
    {
        int v675;
        IEnumerator<int> v677;
        HashSet<int> v678;
        v677 = ArrayWhereExceptArrayWhereRewritten_ProceduralLinq1(ArrayItems2, x => x > 50).GetEnumerator();
        v678 = new HashSet<int>();
        try
        {
            while (v677.MoveNext())
                v678.Add(v677.Current);
        }
        finally
        {
            v677.Dispose();
        }

        v675 = 0;
        for (; v675 < ArrayItems.Length; v675++)
        {
            if (!(v676(ArrayItems[v675])))
                continue;
            if (!(v678.Add(ArrayItems[v675])))
                continue;
            yield return ArrayItems[v675];
        }
    }

    int ArrayExceptArrayCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v679;
        int v680;
        HashSet<int> v681;
        int v682;
        v681 = new HashSet<int>();
        v680 = 0;
        for (; v680 < ArrayItems2.Length; v680++)
            v681.Add(ArrayItems2[v680]);
        v682 = 0;
        v679 = 0;
        for (; v679 < ArrayItems.Length; v679++)
        {
            if (!(v681.Add(ArrayItems[v679])))
                continue;
            v682++;
        }

        return v682;
    }

    int ArrayExceptArrayCount2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v683;
        int v684;
        HashSet<int> v685;
        int v686;
        v685 = new HashSet<int>();
        v684 = 0;
        for (; v684 < ArrayItems2.Length; v684++)
            v685.Add(ArrayItems2[v684]);
        v686 = 0;
        v683 = 0;
        for (; v683 < ArrayItems.Length; v683++)
        {
            if (!(v685.Add(ArrayItems[v683])))
                continue;
            if (!((ArrayItems[v683] > 70)))
                continue;
            v686++;
        }

        return v686;
    }

    int ArrayExceptArraySumRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v687;
        int v688;
        HashSet<int> v689;
        int v690;
        v689 = new HashSet<int>();
        v688 = 0;
        for (; v688 < ArrayItems2.Length; v688++)
            v689.Add(ArrayItems2[v688]);
        v690 = 0;
        v687 = 0;
        for (; v687 < ArrayItems.Length; v687++)
        {
            if (!(v689.Add(ArrayItems[v687])))
                continue;
            v690 += ArrayItems[v687];
        }

        return v690;
    }

    int ArrayExceptArraySum2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v691;
        int v692;
        HashSet<int> v693;
        int v694;
        int v695;
        v693 = new HashSet<int>();
        v692 = 0;
        for (; v692 < ArrayItems2.Length; v692++)
            v693.Add(ArrayItems2[v692]);
        v694 = 0;
        v691 = 0;
        for (; v691 < ArrayItems.Length; v691++)
        {
            if (!(v693.Add(ArrayItems[v691])))
                continue;
            v695 = (ArrayItems[v691] + 10);
            v694 += v695;
        }

        return v694;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v696;
        int v697;
        HashSet<int> v698;
        HashSet<int> v699;
        v698 = new HashSet<int>();
        v697 = 0;
        for (; v697 < ArrayItems2.Length; v697++)
            v698.Add(ArrayItems2[v697]);
        v699 = new HashSet<int>();
        v696 = 0;
        for (; v696 < ArrayItems.Length; v696++)
        {
            if (!(v698.Add(ArrayItems[v696])))
                continue;
            if (!(v699.Add(ArrayItems[v696])))
                continue;
            yield return ArrayItems[v696];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptArrayDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v700;
        int v701;
        HashSet<int> v702;
        HashSet<int> v703;
        v702 = new HashSet<int>();
        v701 = 0;
        for (; v701 < ArrayItems2.Length; v701++)
            v702.Add(ArrayItems2[v701]);
        v703 = new HashSet<int>(EqualityComparer<int>.Default);
        v700 = 0;
        for (; v700 < ArrayItems.Length; v700++)
        {
            if (!(v702.Add(ArrayItems[v700])))
                continue;
            if (!(v703.Add(ArrayItems[v700])))
                continue;
            yield return ArrayItems[v700];
        }
    }

    int ArrayExceptArrayElementAtRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v704;
        int v705;
        HashSet<int> v706;
        int v707;
        v706 = new HashSet<int>();
        v705 = 0;
        for (; v705 < ArrayItems2.Length; v705++)
            v706.Add(ArrayItems2[v705]);
        v707 = 0;
        v704 = 0;
        for (; v704 < ArrayItems.Length; v704++)
        {
            if (!(v706.Add(ArrayItems[v704])))
                continue;
            if (v707 == 45)
                return ArrayItems[v704];
            v707++;
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArrayExceptArrayElementAtOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v708;
        int v709;
        HashSet<int> v710;
        int v711;
        v710 = new HashSet<int>();
        v709 = 0;
        for (; v709 < ArrayItems2.Length; v709++)
            v710.Add(ArrayItems2[v709]);
        v711 = 0;
        v708 = 0;
        for (; v708 < ArrayItems.Length; v708++)
        {
            if (!(v710.Add(ArrayItems[v708])))
                continue;
            if (v711 == 45)
                return ArrayItems[v708];
            v711++;
        }

        return default(int);
    }

    int ArrayExceptArrayFirstRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v712;
        int v713;
        HashSet<int> v714;
        v714 = new HashSet<int>();
        v713 = 0;
        for (; v713 < ArrayItems2.Length; v713++)
            v714.Add(ArrayItems2[v713]);
        v712 = 0;
        for (; v712 < ArrayItems.Length; v712++)
        {
            if (!(v714.Add(ArrayItems[v712])))
                continue;
            return ArrayItems[v712];
        }

        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int ArrayExceptArrayFirstOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v715;
        int v716;
        HashSet<int> v717;
        v717 = new HashSet<int>();
        v716 = 0;
        for (; v716 < ArrayItems2.Length; v716++)
            v717.Add(ArrayItems2[v716]);
        v715 = 0;
        for (; v715 < ArrayItems.Length; v715++)
        {
            if (!(v717.Add(ArrayItems[v715])))
                continue;
            return ArrayItems[v715];
        }

        return default(int);
    }

    int ArrayExceptArrayLastRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v718;
        int v719;
        HashSet<int> v720;
        int? v721;
        v720 = new HashSet<int>();
        v719 = 0;
        for (; v719 < ArrayItems2.Length; v719++)
            v720.Add(ArrayItems2[v719]);
        v721 = null;
        v718 = 0;
        for (; v718 < ArrayItems.Length; v718++)
        {
            if (!(v720.Add(ArrayItems[v718])))
                continue;
            v721 = ArrayItems[v718];
        }

        if (v721 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v721;
    }

    int ArrayExceptArrayLastOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v722;
        int v723;
        HashSet<int> v724;
        int? v725;
        v724 = new HashSet<int>();
        v723 = 0;
        for (; v723 < ArrayItems2.Length; v723++)
            v724.Add(ArrayItems2[v723]);
        v725 = null;
        v722 = 0;
        for (; v722 < ArrayItems.Length; v722++)
        {
            if (!(v724.Add(ArrayItems[v722])))
                continue;
            v725 = ArrayItems[v722];
        }

        if (v725 == null)
            return default(int);
        else
            return (int)v725;
    }

    int ArrayExceptArraySingleRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v726;
        int v727;
        HashSet<int> v728;
        int? v729;
        v728 = new HashSet<int>();
        v727 = 0;
        for (; v727 < ArrayItems2.Length; v727++)
            v728.Add(ArrayItems2[v727]);
        v729 = null;
        v726 = 0;
        for (; v726 < ArrayItems.Length; v726++)
        {
            if (!(v728.Add(ArrayItems[v726])))
                continue;
            if (v729 == null)
                v729 = ArrayItems[v726];
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v729 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v729;
    }

    int ArrayExceptArraySingle2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v730;
        int v731;
        HashSet<int> v732;
        int? v733;
        v732 = new HashSet<int>();
        v731 = 0;
        for (; v731 < ArrayItems2.Length; v731++)
            v732.Add(ArrayItems2[v731]);
        v733 = null;
        v730 = 0;
        for (; v730 < ArrayItems.Length; v730++)
        {
            if (!(v732.Add(ArrayItems[v730])))
                continue;
            if ((ArrayItems[v730] == 76))
                if (v733 == null)
                    v733 = ArrayItems[v730];
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v733 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v733;
    }

    int ArrayExceptArraySingleOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v734;
        int v735;
        HashSet<int> v736;
        int? v737;
        v736 = new HashSet<int>();
        v735 = 0;
        for (; v735 < ArrayItems2.Length; v735++)
            v736.Add(ArrayItems2[v735]);
        v737 = null;
        v734 = 0;
        for (; v734 < ArrayItems.Length; v734++)
        {
            if (!(v736.Add(ArrayItems[v734])))
                continue;
            if (v737 == null)
                v737 = ArrayItems[v734];
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v737 == null)
            return default(int);
        else
            return (int)v737;
    }

    int ArrayExceptArrayMinRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v738;
        int v739;
        HashSet<int> v740;
        int v741;
        bool v742;
        v740 = new HashSet<int>();
        v739 = 0;
        for (; v739 < ArrayItems2.Length; v739++)
            v740.Add(ArrayItems2[v739]);
        v741 = 2147483647;
        v742 = false;
        v738 = 0;
        for (; v738 < ArrayItems.Length; v738++)
        {
            if (!(v740.Add(ArrayItems[v738])))
                continue;
            if (ArrayItems[v738] >= v741)
                continue;
            v741 = ArrayItems[v738];
            v742 = true;
        }

        if (!(v742))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v741;
    }

    decimal ArrayExceptArrayMin2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v743;
        int v744;
        HashSet<int> v745;
        decimal v746;
        bool v747;
        decimal v748;
        v745 = new HashSet<int>();
        v744 = 0;
        for (; v744 < ArrayItems2.Length; v744++)
            v745.Add(ArrayItems2[v744]);
        v746 = 79228162514264337593543950335M;
        v747 = false;
        v743 = 0;
        for (; v743 < ArrayItems.Length; v743++)
        {
            if (!(v745.Add(ArrayItems[v743])))
                continue;
            v748 = (ArrayItems[v743] + 2m);
            if (v748 >= v746)
                continue;
            v746 = v748;
            v747 = true;
        }

        if (!(v747))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v746;
    }

    int ArrayExceptArrayMaxRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v749;
        int v750;
        HashSet<int> v751;
        int v752;
        bool v753;
        v751 = new HashSet<int>();
        v750 = 0;
        for (; v750 < ArrayItems2.Length; v750++)
            v751.Add(ArrayItems2[v750]);
        v752 = -2147483648;
        v753 = false;
        v749 = 0;
        for (; v749 < ArrayItems.Length; v749++)
        {
            if (!(v751.Add(ArrayItems[v749])))
                continue;
            if (ArrayItems[v749] <= v752)
                continue;
            v752 = ArrayItems[v749];
            v753 = true;
        }

        if (!(v753))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v752;
    }

    decimal ArrayExceptArrayMax2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v754;
        int v755;
        HashSet<int> v756;
        decimal v757;
        bool v758;
        decimal v759;
        v756 = new HashSet<int>();
        v755 = 0;
        for (; v755 < ArrayItems2.Length; v755++)
            v756.Add(ArrayItems2[v755]);
        v757 = -79228162514264337593543950335M;
        v758 = false;
        v754 = 0;
        for (; v754 < ArrayItems.Length; v754++)
        {
            if (!(v756.Add(ArrayItems[v754])))
                continue;
            v759 = (ArrayItems[v754] + 2m);
            if (v759 <= v757)
                continue;
            v757 = v759;
            v758 = true;
        }

        if (!(v758))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v757;
    }

    long ArrayExceptArrayLongCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v760;
        int v761;
        HashSet<int> v762;
        long v763;
        v762 = new HashSet<int>();
        v761 = 0;
        for (; v761 < ArrayItems2.Length; v761++)
            v762.Add(ArrayItems2[v761]);
        v763 = 0;
        v760 = 0;
        for (; v760 < ArrayItems.Length; v760++)
        {
            if (!(v762.Add(ArrayItems[v760])))
                continue;
            v763++;
        }

        return v763;
    }

    long ArrayExceptArrayLongCount2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v764;
        int v765;
        HashSet<int> v766;
        long v767;
        v766 = new HashSet<int>();
        v765 = 0;
        for (; v765 < ArrayItems2.Length; v765++)
            v766.Add(ArrayItems2[v765]);
        v767 = 0;
        v764 = 0;
        for (; v764 < ArrayItems.Length; v764++)
        {
            if (!(v766.Add(ArrayItems[v764])))
                continue;
            if (!((ArrayItems[v764] > 50)))
                continue;
            v767++;
        }

        return v767;
    }

    bool ArrayExceptArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v768;
        int v769;
        HashSet<int> v770;
        v770 = new HashSet<int>();
        v769 = 0;
        for (; v769 < ArrayItems2.Length; v769++)
            v770.Add(ArrayItems2[v769]);
        v768 = 0;
        for (; v768 < ArrayItems.Length; v768++)
        {
            if (!(v770.Add(ArrayItems[v768])))
                continue;
            if (ArrayItems[v768] == 56)
                return true;
        }

        return false;
    }

    double ArrayExceptArrayAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v771;
        int v772;
        HashSet<int> v773;
        double v774;
        int v775;
        v773 = new HashSet<int>();
        v772 = 0;
        for (; v772 < ArrayItems2.Length; v772++)
            v773.Add(ArrayItems2[v772]);
        v774 = 0;
        v775 = 0;
        v771 = 0;
        for (; v771 < ArrayItems.Length; v771++)
        {
            if (!(v773.Add(ArrayItems[v771])))
                continue;
            v774 += ArrayItems[v771];
            v775++;
        }

        if (v775 == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v774 / v775);
    }

    double ArrayExceptArrayAverage2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v776;
        int v777;
        HashSet<int> v778;
        double v779;
        int v780;
        v778 = new HashSet<int>();
        v777 = 0;
        for (; v777 < ArrayItems2.Length; v777++)
            v778.Add(ArrayItems2[v777]);
        v779 = 0;
        v780 = 0;
        v776 = 0;
        for (; v776 < ArrayItems.Length; v776++)
        {
            if (!(v778.Add(ArrayItems[v776])))
                continue;
            v779 += (ArrayItems[v776] + 10);
            v780++;
        }

        if (v780 == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v779 / v780);
    }

    bool ArrayExceptArrayContains2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v781;
        int v782;
        HashSet<int> v783;
        System.Collections.Generic.EqualityComparer<int> v784;
        v783 = new HashSet<int>();
        v782 = 0;
        for (; v782 < ArrayItems2.Length; v782++)
            v783.Add(ArrayItems2[v782]);
        v784 = EqualityComparer<int>.Default;
        v781 = 0;
        for (; v781 < ArrayItems.Length; v781++)
        {
            if (!(v783.Add(ArrayItems[v781])))
                continue;
            if (v784.Equals(ArrayItems[v781], 56))
                return true;
        }

        return false;
    }

    System.Collections.Generic.IEnumerable<int> SelectWhereArrayExceptSelectWhereArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems2, System.Func<int, int> v786, System.Func<int, bool> v788)
    {
        int v785;
        int v787;
        v785 = 0;
        for (; v785 < ArrayItems2.Length; v785++)
        {
            v787 = v786(ArrayItems2[v785]);
            if (!(v788(v787)))
                continue;
            yield return v787;
        }
    }

    bool SelectWhereArrayExceptSelectWhereArrayContainsRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v789;
        int v790;
        IEnumerator<int> v791;
        HashSet<int> v792;
        v791 = SelectWhereArrayExceptSelectWhereArrayContainsRewritten_ProceduralLinq1(ArrayItems2, x => x + 10, x => x > 80).GetEnumerator();
        v792 = new HashSet<int>();
        try
        {
            while (v791.MoveNext())
                v792.Add(v791.Current);
        }
        finally
        {
            v791.Dispose();
        }

        v789 = 0;
        for (; v789 < ArrayItems.Length; v789++)
        {
            v790 = (ArrayItems[v789] + 10);
            if (!((v790 > 80)))
                continue;
            if (!(v792.Add(v790)))
                continue;
            if (v790 == 112)
                return true;
        }

        return false;
    }

    System.Collections.Generic.IEnumerable<int> RangeExceptArrayRewritten_ProceduralLinq1()
    {
        int v793;
        if (100 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        int v794;
        HashSet<int> v795;
        int v796;
        v795 = new HashSet<int>();
        v794 = 0;
        for (; v794 < ArrayItems2.Length; v794++)
            v795.Add(ArrayItems2[v794]);
        v793 = 0;
        for (; v793 < 100; v793++)
        {
            v796 = (v793 + 20);
            if (!(v795.Add(v796)))
                continue;
            yield return v796;
        }
    }

    System.Collections.Generic.IEnumerable<int> RepeatExceptArrayRewritten_ProceduralLinq1()
    {
        int v797;
        if (100 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        int v798;
        HashSet<int> v799;
        v799 = new HashSet<int>();
        v798 = 0;
        for (; v798 < ArrayItems2.Length; v798++)
            v799.Add(ArrayItems2[v798]);
        v797 = 0;
        for (; v797 < 100; v797++)
        {
            if (!(v799.Add(20)))
                continue;
            yield return 20;
        }
    }

    System.Collections.Generic.IEnumerable<int> EmptyExceptArrayRewritten_ProceduralLinq1()
    {
        int v800;
        int v801;
        HashSet<int> v802;
        v802 = new HashSet<int>();
        v801 = 0;
        for (; v801 < ArrayItems2.Length; v801++)
            v802.Add(ArrayItems2[v801]);
        v800 = 0;
        for (; v800 < 0; v800++)
        {
            if (!(v802.Add(default(int))))
                continue;
            yield return default(int);
        }
    }

    System.Collections.Generic.IEnumerable<int> RangeEmpty2ArrayRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, bool> v804)
    {
        int v803;
        HashSet<int> v805;
        v805 = new HashSet<int>();
        v803 = 0;
        for (; v803 < ArrayItems2.Length; v803++)
            v805.Add(ArrayItems2[v803]);
        v803 = 0;
        for (; v803 < ArrayItems.Length; v803++)
        {
            if (!(v804(ArrayItems[v803])))
                continue;
            if (!(v805.Add(ArrayItems[v803])))
                continue;
            yield return ArrayItems[v803];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptRangeRewritten_ProceduralLinq1()
    {
        int v806;
        if (260 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        v806 = 0;
        for (; v806 < 260; v806++)
            yield return (v806 + 70);
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptRangeRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v807;
        IEnumerator<int> v808;
        HashSet<int> v809;
        v808 = ArrayExceptRangeRewritten_ProceduralLinq1().GetEnumerator();
        v809 = new HashSet<int>();
        try
        {
            while (v808.MoveNext())
                v809.Add(v808.Current);
        }
        finally
        {
            v808.Dispose();
        }

        v807 = 0;
        for (; v807 < ArrayItems.Length; v807++)
        {
            if (!(v809.Add(ArrayItems[v807])))
                continue;
            yield return ArrayItems[v807];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptRepeatRewritten_ProceduralLinq1()
    {
        int v810;
        if (100 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        v810 = 0;
        for (; v810 < 100; v810++)
            yield return 70;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptRepeatRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v811;
        IEnumerator<int> v812;
        HashSet<int> v813;
        v812 = ArrayExceptRepeatRewritten_ProceduralLinq1().GetEnumerator();
        v813 = new HashSet<int>();
        try
        {
            while (v812.MoveNext())
                v813.Add(v812.Current);
        }
        finally
        {
            v812.Dispose();
        }

        v811 = 0;
        for (; v811 < ArrayItems.Length; v811++)
        {
            if (!(v813.Add(ArrayItems[v811])))
                continue;
            yield return ArrayItems[v811];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptEmptyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v814;
        IEnumerator<int> v815;
        HashSet<int> v816;
        v815 = Enumerable.Empty<int>().GetEnumerator();
        v816 = new HashSet<int>();
        try
        {
            while (v815.MoveNext())
                v816.Add(v815.Current);
        }
        finally
        {
            v815.Dispose();
        }

        v814 = 0;
        for (; v814 < ArrayItems.Length; v814++)
        {
            if (!(v816.Add(ArrayItems[v814])))
                continue;
            yield return ArrayItems[v814];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptEmpty2Rewritten_ProceduralLinq1(int[] ArrayItems2, System.Func<int, bool> v818)
    {
        int v817;
        v817 = 0;
        for (; v817 < ArrayItems2.Length; v817++)
        {
            if (!(v818(ArrayItems2[v817])))
                continue;
            yield return ArrayItems2[v817];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptEmpty2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v819;
        IEnumerator<int> v820;
        HashSet<int> v821;
        v820 = ArrayExceptEmpty2Rewritten_ProceduralLinq1(ArrayItems2, x => false).GetEnumerator();
        v821 = new HashSet<int>();
        try
        {
            while (v820.MoveNext())
                v821.Add(v820.Current);
        }
        finally
        {
            v820.Dispose();
        }

        v819 = 0;
        for (; v819 < ArrayItems.Length; v819++)
        {
            if (!(v821.Add(ArrayItems[v819])))
                continue;
            yield return ArrayItems[v819];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptAllRewritten_ProceduralLinq1()
    {
        int v822;
        if (1000 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        v822 = 0;
        for (; v822 < 1000; v822++)
            yield return (v822 + 0);
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptAllRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v823;
        IEnumerator<int> v824;
        HashSet<int> v825;
        v824 = ArrayExceptAllRewritten_ProceduralLinq1().GetEnumerator();
        v825 = new HashSet<int>();
        try
        {
            while (v824.MoveNext())
                v825.Add(v824.Current);
        }
        finally
        {
            v824.Dispose();
        }

        v823 = 0;
        for (; v823 < ArrayItems.Length; v823++)
        {
            if (!(v825.Add(ArrayItems[v823])))
                continue;
            yield return ArrayItems[v823];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptNullRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v826;
        throw new System.InvalidOperationException("Collection was null");
        v826 = 0;
        for (; v826 < ArrayItems.Length; v826++)
            yield return ArrayItems[v826];
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptArrayExceptEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v827;
        int v828;
        HashSet<int> v829;
        IEnumerator<int> v830;
        HashSet<int> v831;
        v830 = EnumerableItems2.GetEnumerator();
        v831 = new HashSet<int>();
        try
        {
            while (v830.MoveNext())
                v831.Add(v830.Current);
        }
        finally
        {
            v830.Dispose();
        }

        v829 = new HashSet<int>();
        v828 = 0;
        for (; v828 < ArrayItems.Length; v828++)
            v829.Add(ArrayItems[v828]);
        v827 = 0;
        for (; v827 < ArrayItems.Length; v827++)
        {
            if (!(v829.Add(ArrayItems[v827])))
                continue;
            if (!(v831.Add(ArrayItems[v827])))
                continue;
            yield return ArrayItems[v827];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptArrayExceptEnumerable2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v832;
        IEnumerator<int> v833;
        HashSet<int> v834;
        v833 = EnumerableItems2.GetEnumerator();
        v834 = new HashSet<int>();
        try
        {
            while (v833.MoveNext())
                v834.Add(v833.Current);
        }
        finally
        {
            v833.Dispose();
        }

        v832 = 0;
        for (; v832 < ArrayItems.Length; v832++)
        {
            if (!(v834.Add(ArrayItems[v832])))
                continue;
            yield return ArrayItems[v832];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptArrayExceptEnumerable2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v835;
        IEnumerator<int> v836;
        HashSet<int> v837;
        v836 = ArrayExceptArrayExceptEnumerable2Rewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v837 = new HashSet<int>();
        try
        {
            while (v836.MoveNext())
                v837.Add(v836.Current);
        }
        finally
        {
            v836.Dispose();
        }

        v835 = 0;
        for (; v835 < ArrayItems.Length; v835++)
        {
            if (!(v837.Add(ArrayItems[v835])))
                continue;
            yield return ArrayItems[v835];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctExceptArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v838;
        HashSet<int> v839;
        v839 = new HashSet<int>();
        v838 = 0;
        for (; v838 < ArrayItems.Length; v838++)
        {
            if (!(v839.Add(ArrayItems[v838])))
                continue;
            yield return ArrayItems[v838];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctExceptArrayDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v840;
        HashSet<int> v841;
        IEnumerator<int> v842;
        HashSet<int> v843;
        v842 = ArrayDistinctExceptArrayDistinctRewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v843 = new HashSet<int>();
        try
        {
            while (v842.MoveNext())
                v843.Add(v842.Current);
        }
        finally
        {
            v842.Dispose();
        }

        v841 = new HashSet<int>();
        v840 = 0;
        for (; v840 < ArrayItems.Length; v840++)
        {
            if (!(v841.Add(ArrayItems[v840])))
                continue;
            if (!(v843.Add(ArrayItems[v840])))
                continue;
            yield return ArrayItems[v840];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctExceptArrayDistinctDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v844;
        HashSet<int> v845;
        v845 = new HashSet<int>();
        v844 = 0;
        for (; v844 < ArrayItems.Length; v844++)
        {
            if (!(v845.Add(ArrayItems[v844])))
                continue;
            yield return ArrayItems[v844];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctExceptArrayDistinctDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v846;
        HashSet<int> v847;
        IEnumerator<int> v848;
        HashSet<int> v849;
        HashSet<int> v850;
        v848 = ArrayDistinctExceptArrayDistinctDistinctRewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v849 = new HashSet<int>();
        try
        {
            while (v848.MoveNext())
                v849.Add(v848.Current);
        }
        finally
        {
            v848.Dispose();
        }

        v847 = new HashSet<int>();
        v850 = new HashSet<int>();
        v846 = 0;
        for (; v846 < ArrayItems.Length; v846++)
        {
            if (!(v847.Add(ArrayItems[v846])))
                continue;
            if (!(v849.Add(ArrayItems[v846])))
                continue;
            if (!(v850.Add(ArrayItems[v846])))
                continue;
            yield return ArrayItems[v846];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctExceptArrayDistinctDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v851;
        HashSet<int> v852;
        v852 = new HashSet<int>(EqualityComparer<int>.Default);
        v851 = 0;
        for (; v851 < ArrayItems.Length; v851++)
        {
            if (!(v852.Add(ArrayItems[v851])))
                continue;
            yield return ArrayItems[v851];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctExceptArrayDistinctDistinct2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v853;
        HashSet<int> v854;
        IEnumerator<int> v855;
        HashSet<int> v856;
        HashSet<int> v857;
        v855 = ArrayDistinctExceptArrayDistinctDistinct2Rewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v856 = new HashSet<int>();
        try
        {
            while (v855.MoveNext())
                v856.Add(v855.Current);
        }
        finally
        {
            v855.Dispose();
        }

        v854 = new HashSet<int>(EqualityComparer<int>.Default);
        v857 = new HashSet<int>(EqualityComparer<int>.Default);
        v853 = 0;
        for (; v853 < ArrayItems.Length; v853++)
        {
            if (!(v854.Add(ArrayItems[v853])))
                continue;
            if (!(v856.Add(ArrayItems[v853])))
                continue;
            if (!(v857.Add(ArrayItems[v853])))
                continue;
            yield return ArrayItems[v853];
        }
    }
}}