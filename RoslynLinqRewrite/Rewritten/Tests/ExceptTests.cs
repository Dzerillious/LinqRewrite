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
        return ArraySelectExceptArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectExceptArraySelect()
    {
        return ArrayItems.Select(x => x + 50).Except(ArrayItems2.Select(x => x + 50));
    } //EndMethod

    public IEnumerable<int> ArraySelectExceptArraySelectRewritten()
    {
        return ArraySelectExceptArraySelectRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayWhereExceptArrayWhere()
    {
        return ArrayItems.Where(x => x > 50).Except(ArrayItems2.Where(x => x > 50));
    } //EndMethod

    public IEnumerable<int> ArrayWhereExceptArrayWhereRewritten()
    {
        return ArrayWhereExceptArrayWhereRewritten_ProceduralLinq2(ArrayItems);
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
        return RangeEmpty2ArrayRewritten_ProceduralLinq1(ArrayItems);
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
        int v660;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v661;
        HashSet<int> v662;
        int v663;
        v662 = new HashSet<int>();
        v661 = (0);
        for (; v661 < (ArrayItems2.Length); v661++)
            v662.Add((ArrayItems2[v661]));
        v660 = (0);
        for (; v660 < (ArrayItems.Length); v660++)
        {
            v663 = (ArrayItems[v660]);
            if (!(v662.Add((v663))))
                continue;
            yield return (v663);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v664;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v665;
        int v666;
        HashSet<int> v667;
        int v668;
        v665 = SimpleListItems2.Count;
        v667 = new HashSet<int>();
        v666 = (0);
        for (; v666 < (v665); v666++)
            v667.Add((SimpleListItems2[v666]));
        v664 = (0);
        for (; v664 < (ArrayItems.Length); v664++)
        {
            v668 = (ArrayItems[v664]);
            if (!(v667.Add((v668))))
                continue;
            yield return (v668);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v669;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v670;
        HashSet<int> v671;
        int v672;
        v670 = EnumerableItems2.GetEnumerator();
        v671 = new HashSet<int>();
        try
        {
            while (v670.MoveNext())
                v671.Add((v670.Current));
        }
        finally
        {
            v670.Dispose();
        }

        v669 = (0);
        for (; v669 < (ArrayItems.Length); v669++)
        {
            v672 = (ArrayItems[v669]);
            if (!(v671.Add((v672))))
                continue;
            yield return (v672);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v673;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v674;
        HashSet<int> v675;
        int v676;
        v674 = MethodEnumerable2().GetEnumerator();
        v675 = new HashSet<int>();
        try
        {
            while (v674.MoveNext())
                v675.Add((v674.Current));
        }
        finally
        {
            v674.Dispose();
        }

        v673 = (0);
        for (; v673 < (ArrayItems.Length); v673++)
        {
            v676 = (ArrayItems[v673]);
            if (!(v675.Add((v676))))
                continue;
            yield return (v676);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SimpleListExceptArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v677;
        LinqRewrite.Core.SimpleList.SimpleList<int> v678;
        int v679;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v680;
        HashSet<int> v681;
        int v682;
        v681 = new HashSet<int>();
        v680 = (0);
        for (; v680 < (ArrayItems2.Length); v680++)
            v681.Add((ArrayItems2[v680]));
        v677 = SimpleListItems.Count;
        v678 = SimpleListItems;
        v679 = (0);
        for (; v679 < (v677); v679++)
        {
            v682 = ((v678[v679]));
            if (!(v681.Add((v682))))
                continue;
            yield return (v682);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SimpleListExceptSimpleListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v683;
        LinqRewrite.Core.SimpleList.SimpleList<int> v684;
        int v685;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v686;
        int v687;
        HashSet<int> v688;
        int v689;
        v686 = SimpleListItems2.Count;
        v688 = new HashSet<int>();
        v687 = (0);
        for (; v687 < (v686); v687++)
            v688.Add((SimpleListItems2[v687]));
        v683 = SimpleListItems.Count;
        v684 = SimpleListItems;
        v685 = (0);
        for (; v685 < (v683); v685++)
        {
            v689 = ((v684[v685]));
            if (!(v688.Add((v689))))
                continue;
            yield return (v689);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SimpleListExceptEnumerableRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v690;
        LinqRewrite.Core.SimpleList.SimpleList<int> v691;
        int v692;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v693;
        HashSet<int> v694;
        int v695;
        v693 = EnumerableItems2.GetEnumerator();
        v694 = new HashSet<int>();
        try
        {
            while (v693.MoveNext())
                v694.Add((v693.Current));
        }
        finally
        {
            v693.Dispose();
        }

        v690 = SimpleListItems.Count;
        v691 = SimpleListItems;
        v692 = (0);
        for (; v692 < (v690); v692++)
        {
            v695 = ((v691[v692]));
            if (!(v694.Add((v695))))
                continue;
            yield return (v695);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SimpleListExceptMethodRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v696;
        LinqRewrite.Core.SimpleList.SimpleList<int> v697;
        int v698;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v699;
        HashSet<int> v700;
        int v701;
        v699 = MethodEnumerable2().GetEnumerator();
        v700 = new HashSet<int>();
        try
        {
            while (v699.MoveNext())
                v700.Add((v699.Current));
        }
        finally
        {
            v699.Dispose();
        }

        v696 = SimpleListItems.Count;
        v697 = SimpleListItems;
        v698 = (0);
        for (; v698 < (v696); v698++)
        {
            v701 = ((v697[v698]));
            if (!(v700.Add((v701))))
                continue;
            yield return (v701);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableExceptArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v702;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v703;
        HashSet<int> v704;
        int v705;
        v702 = EnumerableItems.GetEnumerator();
        v704 = new HashSet<int>();
        v703 = (0);
        for (; v703 < (ArrayItems2.Length); v703++)
            v704.Add((ArrayItems2[v703]));
        try
        {
            while (v702.MoveNext())
            {
                v705 = (v702.Current);
                if (!(v704.Add((v705))))
                    continue;
                yield return (v705);
            }
        }
        finally
        {
            v702.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableExceptSimpleListRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v706;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v707;
        int v708;
        HashSet<int> v709;
        int v710;
        v706 = EnumerableItems.GetEnumerator();
        v707 = SimpleListItems2.Count;
        v709 = new HashSet<int>();
        v708 = (0);
        for (; v708 < (v707); v708++)
            v709.Add((SimpleListItems2[v708]));
        try
        {
            while (v706.MoveNext())
            {
                v710 = (v706.Current);
                if (!(v709.Add((v710))))
                    continue;
                yield return (v710);
            }
        }
        finally
        {
            v706.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableExceptEnumerableRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v711;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v712;
        HashSet<int> v713;
        int v714;
        v712 = EnumerableItems2.GetEnumerator();
        v711 = EnumerableItems.GetEnumerator();
        v713 = new HashSet<int>();
        try
        {
            while (v712.MoveNext())
                v713.Add((v712.Current));
        }
        finally
        {
            v712.Dispose();
        }

        try
        {
            while (v711.MoveNext())
            {
                v714 = (v711.Current);
                if (!(v713.Add((v714))))
                    continue;
                yield return (v714);
            }
        }
        finally
        {
            v711.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableExceptMethodRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v715;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v716;
        HashSet<int> v717;
        int v718;
        v716 = MethodEnumerable2().GetEnumerator();
        v715 = EnumerableItems.GetEnumerator();
        v717 = new HashSet<int>();
        try
        {
            while (v716.MoveNext())
                v717.Add((v716.Current));
        }
        finally
        {
            v716.Dispose();
        }

        try
        {
            while (v715.MoveNext())
            {
                v718 = (v715.Current);
                if (!(v717.Add((v718))))
                    continue;
                yield return (v718);
            }
        }
        finally
        {
            v715.Dispose();
        }

        yield break;
    }

    int[] ArrayExceptArrayToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v719;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v720;
        HashSet<int> v721;
        int v722;
        int v723;
        int v724;
        int v725;
        int[] v726;
        v721 = new HashSet<int>();
        v720 = (0);
        for (; v720 < (ArrayItems2.Length); v720++)
            v721.Add((ArrayItems2[v720]));
        v723 = 0;
        v724 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems2.Length + ArrayItems.Length))) - 3);
        v724 -= (v724 % 2);
        v725 = 8;
        v726 = new int[8];
        v719 = (0);
        for (; v719 < (ArrayItems.Length); v719++)
        {
            v722 = (ArrayItems[v719]);
            if (!(v721.Add((v722))))
                continue;
            if (v723 >= v725)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems2.Length + ArrayItems.Length), ref v726, ref v724, out v725);
            v726[v723] = (v722);
            v723++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v726, v723);
    }

    int[] ArrayExceptSimpleListToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v727;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v728;
        int v729;
        HashSet<int> v730;
        int v731;
        int v732;
        int v733;
        int v734;
        int[] v735;
        v728 = SimpleListItems2.Count;
        v730 = new HashSet<int>();
        v729 = (0);
        for (; v729 < (v728); v729++)
            v730.Add((SimpleListItems2[v729]));
        v732 = 0;
        v733 = (LinqRewrite.Core.IntExtensions.Log2((uint)((v728 + ArrayItems.Length))) - 3);
        v733 -= (v733 % 2);
        v734 = 8;
        v735 = new int[8];
        v727 = (0);
        for (; v727 < (ArrayItems.Length); v727++)
        {
            v731 = (ArrayItems[v727]);
            if (!(v730.Add((v731))))
                continue;
            if (v732 >= v734)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (v728 + ArrayItems.Length), ref v735, ref v733, out v734);
            v735[v732] = (v731);
            v732++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v735, v732);
    }

    int[] ArrayExceptEnumerableToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v736;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v737;
        HashSet<int> v738;
        int v739;
        int v740;
        int v741;
        int[] v742;
        v737 = EnumerableItems2.GetEnumerator();
        v738 = new HashSet<int>();
        try
        {
            while (v737.MoveNext())
                v738.Add((v737.Current));
        }
        finally
        {
            v737.Dispose();
        }

        v740 = 0;
        v741 = 8;
        v742 = new int[8];
        v736 = (0);
        for (; v736 < (ArrayItems.Length); v736++)
        {
            v739 = (ArrayItems[v736]);
            if (!(v738.Add((v739))))
                continue;
            if (v740 >= v741)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v742, ref v741);
            v742[v740] = (v739);
            v740++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v742, v740);
    }

    int[] SimpleListExceptArrayToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v743;
        LinqRewrite.Core.SimpleList.SimpleList<int> v744;
        int v745;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v746;
        HashSet<int> v747;
        int v748;
        int v749;
        int v750;
        int v751;
        int[] v752;
        v747 = new HashSet<int>();
        v746 = (0);
        for (; v746 < (ArrayItems2.Length); v746++)
            v747.Add((ArrayItems2[v746]));
        v743 = SimpleListItems.Count;
        v744 = SimpleListItems;
        v749 = 0;
        v750 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems2.Length + v743))) - 3);
        v750 -= (v750 % 2);
        v751 = 8;
        v752 = new int[8];
        v745 = (0);
        for (; v745 < (v743); v745++)
        {
            v748 = ((v744[v745]));
            if (!(v747.Add((v748))))
                continue;
            if (v749 >= v751)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems2.Length + v743), ref v752, ref v750, out v751);
            v752[v749] = (v748);
            v749++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v752, v749);
    }

    int[] SimpleListExceptSimpleListToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v753;
        LinqRewrite.Core.SimpleList.SimpleList<int> v754;
        int v755;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v756;
        int v757;
        HashSet<int> v758;
        int v759;
        int v760;
        int v761;
        int v762;
        int[] v763;
        v756 = SimpleListItems2.Count;
        v758 = new HashSet<int>();
        v757 = (0);
        for (; v757 < (v756); v757++)
            v758.Add((SimpleListItems2[v757]));
        v753 = SimpleListItems.Count;
        v754 = SimpleListItems;
        v760 = 0;
        v761 = (LinqRewrite.Core.IntExtensions.Log2((uint)((v756 + v753))) - 3);
        v761 -= (v761 % 2);
        v762 = 8;
        v763 = new int[8];
        v755 = (0);
        for (; v755 < (v753); v755++)
        {
            v759 = ((v754[v755]));
            if (!(v758.Add((v759))))
                continue;
            if (v760 >= v762)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (v756 + v753), ref v763, ref v761, out v762);
            v763[v760] = (v759);
            v760++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v763, v760);
    }

    int[] SimpleListExceptEnumerableToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v764;
        LinqRewrite.Core.SimpleList.SimpleList<int> v765;
        int v766;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v767;
        HashSet<int> v768;
        int v769;
        int v770;
        int v771;
        int[] v772;
        v767 = EnumerableItems2.GetEnumerator();
        v768 = new HashSet<int>();
        try
        {
            while (v767.MoveNext())
                v768.Add((v767.Current));
        }
        finally
        {
            v767.Dispose();
        }

        v764 = SimpleListItems.Count;
        v765 = SimpleListItems;
        v770 = 0;
        v771 = 8;
        v772 = new int[8];
        v766 = (0);
        for (; v766 < (v764); v766++)
        {
            v769 = ((v765[v766]));
            if (!(v768.Add((v769))))
                continue;
            if (v770 >= v771)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v772, ref v771);
            v772[v770] = (v769);
            v770++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v772, v770);
    }

    int[] EnumerableExceptArrayToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v773;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v774;
        HashSet<int> v775;
        int v776;
        int v777;
        int v778;
        int[] v779;
        v773 = EnumerableItems.GetEnumerator();
        v775 = new HashSet<int>();
        v774 = (0);
        for (; v774 < (ArrayItems2.Length); v774++)
            v775.Add((ArrayItems2[v774]));
        v777 = 0;
        v778 = 8;
        v779 = new int[8];
        try
        {
            while (v773.MoveNext())
            {
                v776 = (v773.Current);
                if (!(v775.Add((v776))))
                    continue;
                if (v777 >= v778)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v779, ref v778);
                v779[v777] = (v776);
                v777++;
            }
        }
        finally
        {
            v773.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v779, v777);
    }

    int[] EnumerableExceptSimpleListToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v780;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v781;
        int v782;
        HashSet<int> v783;
        int v784;
        int v785;
        int v786;
        int[] v787;
        v780 = EnumerableItems.GetEnumerator();
        v781 = SimpleListItems2.Count;
        v783 = new HashSet<int>();
        v782 = (0);
        for (; v782 < (v781); v782++)
            v783.Add((SimpleListItems2[v782]));
        v785 = 0;
        v786 = 8;
        v787 = new int[8];
        try
        {
            while (v780.MoveNext())
            {
                v784 = (v780.Current);
                if (!(v783.Add((v784))))
                    continue;
                if (v785 >= v786)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v787, ref v786);
                v787[v785] = (v784);
                v785++;
            }
        }
        finally
        {
            v780.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v787, v785);
    }

    int[] EnumerableExceptEnumerableToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v788;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v789;
        HashSet<int> v790;
        int v791;
        int v792;
        int v793;
        int[] v794;
        v789 = EnumerableItems2.GetEnumerator();
        v788 = EnumerableItems.GetEnumerator();
        v790 = new HashSet<int>();
        try
        {
            while (v789.MoveNext())
                v790.Add((v789.Current));
        }
        finally
        {
            v789.Dispose();
        }

        v792 = 0;
        v793 = 8;
        v794 = new int[8];
        try
        {
            while (v788.MoveNext())
            {
                v791 = (v788.Current);
                if (!(v790.Add((v791))))
                    continue;
                if (v792 >= v793)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v794, ref v793);
                v794[v792] = (v791);
                v792++;
            }
        }
        finally
        {
            v788.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v794, v792);
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectExceptArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v795;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v796;
        HashSet<int> v797;
        int v798;
        v797 = new HashSet<int>();
        v796 = (0);
        for (; v796 < (ArrayItems2.Length); v796++)
            v797.Add((ArrayItems2[v796]));
        v795 = (0);
        for (; v795 < (ArrayItems.Length); v795++)
        {
            v798 = (50 + ArrayItems[v795]);
            if (!(v797.Add((v798))))
                continue;
            yield return (v798);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectExceptArraySelectRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v800;
        v800 = (0);
        for (; v800 < (ArrayItems2.Length); v800++)
            yield return (((ArrayItems2[v800]) + 50));
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectExceptArraySelectRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v801;
        if (ArraySelectExceptArraySelectRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v802;
        HashSet<int> v803;
        int v804;
        v802 = ArraySelectExceptArraySelectRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v803 = new HashSet<int>();
        try
        {
            while (v802.MoveNext())
                v803.Add((v802.Current));
        }
        finally
        {
            v802.Dispose();
        }

        v801 = (0);
        for (; v801 < (ArrayItems.Length); v801++)
        {
            v804 = (50 + ArrayItems[v801]);
            if (!(v803.Add((v804))))
                continue;
            yield return (v804);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereExceptArrayWhereRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v805;
        int v806;
        v805 = (0);
        for (; v805 < (ArrayItems2.Length); v805++)
        {
            v806 = (ArrayItems2[v805]);
            if (!(((v806) > 50)))
                continue;
            yield return (v806);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereExceptArrayWhereRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v807;
        int v808;
        if (ArrayWhereExceptArrayWhereRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v809;
        HashSet<int> v810;
        v809 = ArrayWhereExceptArrayWhereRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v810 = new HashSet<int>();
        try
        {
            while (v809.MoveNext())
                v810.Add((v809.Current));
        }
        finally
        {
            v809.Dispose();
        }

        v807 = (0);
        for (; v807 < (ArrayItems.Length); v807++)
        {
            v808 = (ArrayItems[v807]);
            if (!(((v808) > 50)))
                continue;
            v808 = (v808);
            if (!(v810.Add((v808))))
                continue;
            yield return (v808);
        }

        yield break;
    }

    int ArrayExceptArrayCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v811;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v812;
        HashSet<int> v813;
        int v814;
        int v815;
        v813 = new HashSet<int>();
        v812 = (0);
        for (; v812 < (ArrayItems2.Length); v812++)
            v813.Add((ArrayItems2[v812]));
        v815 = 0;
        v811 = (0);
        for (; v811 < (ArrayItems.Length); v811++)
        {
            v814 = (ArrayItems[v811]);
            if (!(v813.Add((v814))))
                continue;
            v815++;
        }

        return v815;
    }

    int ArrayExceptArrayCount2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v816;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v817;
        HashSet<int> v818;
        int v819;
        int v820;
        v818 = new HashSet<int>();
        v817 = (0);
        for (; v817 < (ArrayItems2.Length); v817++)
            v818.Add((ArrayItems2[v817]));
        v820 = 0;
        v816 = (0);
        for (; v816 < (ArrayItems.Length); v816++)
        {
            v819 = (ArrayItems[v816]);
            if (!(v818.Add((v819))))
                continue;
            if (!(((v819) > 70)))
                continue;
            v820++;
        }

        return v820;
    }

    int ArrayExceptArraySumRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v821;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v822;
        HashSet<int> v823;
        int v824;
        int v825;
        v823 = new HashSet<int>();
        v822 = (0);
        for (; v822 < (ArrayItems2.Length); v822++)
            v823.Add((ArrayItems2[v822]));
        v825 = 0;
        v821 = (0);
        for (; v821 < (ArrayItems.Length); v821++)
        {
            v824 = (ArrayItems[v821]);
            if (!(v823.Add((v824))))
                continue;
            v825 += (v824);
        }

        return v825;
    }

    int ArrayExceptArraySum2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v826;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v827;
        HashSet<int> v828;
        int v829;
        int v830;
        v828 = new HashSet<int>();
        v827 = (0);
        for (; v827 < (ArrayItems2.Length); v827++)
            v828.Add((ArrayItems2[v827]));
        v830 = 0;
        v826 = (0);
        for (; v826 < (ArrayItems.Length); v826++)
        {
            v829 = (ArrayItems[v826]);
            if (!(v828.Add((v829))))
                continue;
            v829 = ((v829) + 10);
            v830 += v829;
        }

        return v830;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v831;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v832;
        HashSet<int> v833;
        int v834;
        HashSet<int> v835;
        v833 = new HashSet<int>();
        v832 = (0);
        for (; v832 < (ArrayItems2.Length); v832++)
            v833.Add((ArrayItems2[v832]));
        v835 = new HashSet<int>();
        v831 = (0);
        for (; v831 < (ArrayItems.Length); v831++)
        {
            v834 = (ArrayItems[v831]);
            if (!(v833.Add((v834))))
                continue;
            v834 = (v834);
            if (!(v835.Add((v834))))
                continue;
            yield return (v834);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptArrayDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v836;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v837;
        HashSet<int> v838;
        int v839;
        HashSet<int> v840;
        v838 = new HashSet<int>();
        v837 = (0);
        for (; v837 < (ArrayItems2.Length); v837++)
            v838.Add((ArrayItems2[v837]));
        v840 = new HashSet<int>(EqualityComparer<int>.Default);
        v836 = (0);
        for (; v836 < (ArrayItems.Length); v836++)
        {
            v839 = (ArrayItems[v836]);
            if (!(v838.Add((v839))))
                continue;
            v839 = (v839);
            if (!(v840.Add((v839))))
                continue;
            yield return (v839);
        }

        yield break;
    }

    int ArrayExceptArrayElementAtRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v841;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v842;
        HashSet<int> v843;
        int v844;
        int v845;
        v843 = new HashSet<int>();
        v842 = (0);
        for (; v842 < (ArrayItems2.Length); v842++)
            v843.Add((ArrayItems2[v842]));
        v845 = 0;
        v841 = (0);
        for (; v841 < (ArrayItems.Length); v841++)
        {
            v844 = (ArrayItems[v841]);
            if (!(v843.Add((v844))))
                continue;
            if (v845 == 45)
                return (v844);
            v845++;
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArrayExceptArrayElementAtOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v846;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v847;
        HashSet<int> v848;
        int v849;
        int v850;
        v848 = new HashSet<int>();
        v847 = (0);
        for (; v847 < (ArrayItems2.Length); v847++)
            v848.Add((ArrayItems2[v847]));
        v850 = 0;
        v846 = (0);
        for (; v846 < (ArrayItems.Length); v846++)
        {
            v849 = (ArrayItems[v846]);
            if (!(v848.Add((v849))))
                continue;
            if (v850 == 45)
                return (v849);
            v850++;
        }

        return default(int);
    }

    int ArrayExceptArrayFirstRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v851;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v852;
        HashSet<int> v853;
        int v854;
        int v855;
        v853 = new HashSet<int>();
        v852 = (0);
        for (; v852 < (ArrayItems2.Length); v852++)
            v853.Add((ArrayItems2[v852]));
        v855 = 0;
        v851 = (0);
        for (; v851 < (ArrayItems.Length); v851++)
        {
            v854 = (ArrayItems[v851]);
            if (!(v853.Add((v854))))
                continue;
            return (v854);
            v855++;
        }

        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int ArrayExceptArrayFirstOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v856;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v857;
        HashSet<int> v858;
        int v859;
        v858 = new HashSet<int>();
        v857 = (0);
        for (; v857 < (ArrayItems2.Length); v857++)
            v858.Add((ArrayItems2[v857]));
        v856 = (0);
        for (; v856 < (ArrayItems.Length); v856++)
        {
            v859 = (ArrayItems[v856]);
            if (!(v858.Add((v859))))
                continue;
            return (v859);
        }

        return default(int);
    }

    int ArrayExceptArrayLastRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v860;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v861;
        HashSet<int> v862;
        int v863;
        int v864;
        int? v865;
        v862 = new HashSet<int>();
        v861 = (0);
        for (; v861 < (ArrayItems2.Length); v861++)
            v862.Add((ArrayItems2[v861]));
        v864 = 0;
        v865 = null;
        v860 = (0);
        for (; v860 < (ArrayItems.Length); v860++)
        {
            v863 = (ArrayItems[v860]);
            if (!(v862.Add((v863))))
                continue;
            v865 = (v863);
            v864++;
        }

        if (v865 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v865;
    }

    int ArrayExceptArrayLastOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v866;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v867;
        HashSet<int> v868;
        int v869;
        int? v870;
        v868 = new HashSet<int>();
        v867 = (0);
        for (; v867 < (ArrayItems2.Length); v867++)
            v868.Add((ArrayItems2[v867]));
        v870 = null;
        v866 = (0);
        for (; v866 < (ArrayItems.Length); v866++)
        {
            v869 = (ArrayItems[v866]);
            if (!(v868.Add((v869))))
                continue;
            v870 = (v869);
        }

        if (v870 == null)
            return default(int);
        else
            return (int)v870;
    }

    int ArrayExceptArraySingleRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v871;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v872;
        HashSet<int> v873;
        int v874;
        int? v875;
        v873 = new HashSet<int>();
        v872 = (0);
        for (; v872 < (ArrayItems2.Length); v872++)
            v873.Add((ArrayItems2[v872]));
        v875 = null;
        v871 = (0);
        for (; v871 < (ArrayItems.Length); v871++)
        {
            v874 = (ArrayItems[v871]);
            if (!(v873.Add((v874))))
                continue;
            if (v875 == null)
                v875 = (v874);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v875 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v875;
    }

    int ArrayExceptArraySingle2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v876;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v877;
        HashSet<int> v878;
        int v879;
        int? v880;
        v878 = new HashSet<int>();
        v877 = (0);
        for (; v877 < (ArrayItems2.Length); v877++)
            v878.Add((ArrayItems2[v877]));
        v880 = null;
        v876 = (0);
        for (; v876 < (ArrayItems.Length); v876++)
        {
            v879 = (ArrayItems[v876]);
            if (!(v878.Add((v879))))
                continue;
            if (((v879) == 76))
                if (v880 == null)
                    v880 = (v879);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v880 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v880;
    }

    int ArrayExceptArraySingleOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v881;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v882;
        HashSet<int> v883;
        int v884;
        int? v885;
        v883 = new HashSet<int>();
        v882 = (0);
        for (; v882 < (ArrayItems2.Length); v882++)
            v883.Add((ArrayItems2[v882]));
        v885 = null;
        v881 = (0);
        for (; v881 < (ArrayItems.Length); v881++)
        {
            v884 = (ArrayItems[v881]);
            if (!(v883.Add((v884))))
                continue;
            if (v885 == null)
                v885 = (v884);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v885 == null)
            return default(int);
        else
            return (int)v885;
    }

    int ArrayExceptArrayMinRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v886;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v887;
        HashSet<int> v888;
        int v889;
        int v890;
        int v891;
        v888 = new HashSet<int>();
        v887 = (0);
        for (; v887 < (ArrayItems2.Length); v887++)
            v888.Add((ArrayItems2[v887]));
        v890 = 0;
        v891 = 2147483647;
        v886 = (0);
        for (; v886 < (ArrayItems.Length); v886++)
        {
            v889 = (ArrayItems[v886]);
            if (!(v888.Add((v889))))
                continue;
            v889 = (v889);
            if (v889 >= v891)
                continue;
            v891 = v889;
            v890++;
        }

        if (1 > v890)
            throw new System.InvalidOperationException("Index out of range");
        return v891;
    }

    decimal ArrayExceptArrayMin2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v892;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v893;
        HashSet<int> v894;
        int v895;
        int v896;
        decimal v897;
        decimal v898;
        v894 = new HashSet<int>();
        v893 = (0);
        for (; v893 < (ArrayItems2.Length); v893++)
            v894.Add((ArrayItems2[v893]));
        v896 = 0;
        v897 = 79228162514264337593543950335M;
        v892 = (0);
        for (; v892 < (ArrayItems.Length); v892++)
        {
            v895 = (ArrayItems[v892]);
            if (!(v894.Add((v895))))
                continue;
            v898 = ((v895) + 2m);
            if (v898 >= v897)
                continue;
            v897 = v898;
            v896++;
        }

        if (1 > v896)
            throw new System.InvalidOperationException("Index out of range");
        return v897;
    }

    int ArrayExceptArrayMaxRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v899;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v900;
        HashSet<int> v901;
        int v902;
        int v903;
        int v904;
        v901 = new HashSet<int>();
        v900 = (0);
        for (; v900 < (ArrayItems2.Length); v900++)
            v901.Add((ArrayItems2[v900]));
        v903 = 0;
        v904 = -2147483648;
        v899 = (0);
        for (; v899 < (ArrayItems.Length); v899++)
        {
            v902 = (ArrayItems[v899]);
            if (!(v901.Add((v902))))
                continue;
            v902 = (v902);
            if (v902 <= v904)
                continue;
            v904 = v902;
            v903++;
        }

        if (1 > v903)
            throw new System.InvalidOperationException("Index out of range");
        return v904;
    }

    decimal ArrayExceptArrayMax2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v905;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v906;
        HashSet<int> v907;
        int v908;
        int v909;
        decimal v910;
        decimal v911;
        v907 = new HashSet<int>();
        v906 = (0);
        for (; v906 < (ArrayItems2.Length); v906++)
            v907.Add((ArrayItems2[v906]));
        v909 = 0;
        v910 = -79228162514264337593543950335M;
        v905 = (0);
        for (; v905 < (ArrayItems.Length); v905++)
        {
            v908 = (ArrayItems[v905]);
            if (!(v907.Add((v908))))
                continue;
            v911 = ((v908) + 2m);
            if (v911 <= v910)
                continue;
            v910 = v911;
            v909++;
        }

        if (1 > v909)
            throw new System.InvalidOperationException("Index out of range");
        return v910;
    }

    long ArrayExceptArrayLongCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v912;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v913;
        HashSet<int> v914;
        int v915;
        long v916;
        v914 = new HashSet<int>();
        v913 = (0);
        for (; v913 < (ArrayItems2.Length); v913++)
            v914.Add((ArrayItems2[v913]));
        v916 = 0;
        v912 = (0);
        for (; v912 < (ArrayItems.Length); v912++)
        {
            v915 = (ArrayItems[v912]);
            if (!(v914.Add((v915))))
                continue;
            v916++;
        }

        return v916;
    }

    long ArrayExceptArrayLongCount2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v917;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v918;
        HashSet<int> v919;
        int v920;
        long v921;
        v919 = new HashSet<int>();
        v918 = (0);
        for (; v918 < (ArrayItems2.Length); v918++)
            v919.Add((ArrayItems2[v918]));
        v921 = 0;
        v917 = (0);
        for (; v917 < (ArrayItems.Length); v917++)
        {
            v920 = (ArrayItems[v917]);
            if (!(v919.Add((v920))))
                continue;
            if (!(((v920) > 50)))
                continue;
            v921++;
        }

        return v921;
    }

    bool ArrayExceptArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v922;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v923;
        HashSet<int> v924;
        int v925;
        v924 = new HashSet<int>();
        v923 = (0);
        for (; v923 < (ArrayItems2.Length); v923++)
            v924.Add((ArrayItems2[v923]));
        v922 = (0);
        for (; v922 < (ArrayItems.Length); v922++)
        {
            v925 = (ArrayItems[v922]);
            if (!(v924.Add((v925))))
                continue;
            if ((v925) == 56)
                return true;
        }

        return false;
    }

    double ArrayExceptArrayAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v926;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v927;
        HashSet<int> v928;
        int v929;
        double v930;
        int v931;
        v928 = new HashSet<int>();
        v927 = (0);
        for (; v927 < (ArrayItems2.Length); v927++)
            v928.Add((ArrayItems2[v927]));
        v930 = 0;
        v931 = 0;
        v926 = (0);
        for (; v926 < (ArrayItems.Length); v926++)
        {
            v929 = (ArrayItems[v926]);
            if (!(v928.Add((v929))))
                continue;
            v930 += (v929);
            v931++;
        }

        if (1 > v931)
            throw new System.InvalidOperationException("Index out of range");
        return (v930 / v931);
    }

    double ArrayExceptArrayAverage2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v932;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v933;
        HashSet<int> v934;
        int v935;
        double v936;
        int v937;
        v934 = new HashSet<int>();
        v933 = (0);
        for (; v933 < (ArrayItems2.Length); v933++)
            v934.Add((ArrayItems2[v933]));
        v936 = 0;
        v937 = 0;
        v932 = (0);
        for (; v932 < (ArrayItems.Length); v932++)
        {
            v935 = (ArrayItems[v932]);
            if (!(v934.Add((v935))))
                continue;
            v936 += ((v935) + 10);
            v937++;
        }

        if (1 > v937)
            throw new System.InvalidOperationException("Index out of range");
        return (v936 / v937);
    }

    bool ArrayExceptArrayContains2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v938;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v939;
        HashSet<int> v940;
        int v941;
        System.Collections.Generic.EqualityComparer<int> v942;
        v940 = new HashSet<int>();
        v939 = (0);
        for (; v939 < (ArrayItems2.Length); v939++)
            v940.Add((ArrayItems2[v939]));
        v942 = EqualityComparer<int>.Default;
        v938 = (0);
        for (; v938 < (ArrayItems.Length); v938++)
        {
            v941 = (ArrayItems[v938]);
            if (!(v940.Add((v941))))
                continue;
            if (v942.Equals((v941), 56))
                return true;
        }

        return false;
    }

    System.Collections.Generic.IEnumerable<int> SelectWhereArrayExceptSelectWhereArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v943;
        int v944;
        v943 = (0);
        for (; v943 < (ArrayItems2.Length); v943++)
        {
            v944 = (((ArrayItems2[v943]) + 10));
            if (!(((v944) > 80)))
                continue;
            yield return (v944);
        }

        yield break;
    }

    bool SelectWhereArrayExceptSelectWhereArrayContainsRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v945;
        int v946;
        if (SelectWhereArrayExceptSelectWhereArrayContainsRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v947;
        HashSet<int> v948;
        v947 = SelectWhereArrayExceptSelectWhereArrayContainsRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v948 = new HashSet<int>();
        try
        {
            while (v947.MoveNext())
                v948.Add((v947.Current));
        }
        finally
        {
            v947.Dispose();
        }

        v945 = (0);
        for (; v945 < (ArrayItems.Length); v945++)
        {
            v946 = (10 + ArrayItems[v945]);
            if (!(((v946) > 80)))
                continue;
            v946 = (v946);
            if (!(v948.Add((v946))))
                continue;
            if ((v946) == 112)
                return true;
        }

        return false;
    }

    System.Collections.Generic.IEnumerable<int> RangeExceptArrayRewritten_ProceduralLinq1()
    {
        int v949;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v950;
        HashSet<int> v951;
        int v952;
        v951 = new HashSet<int>();
        v950 = (0);
        for (; v950 < (ArrayItems2.Length); v950++)
            v951.Add((ArrayItems2[v950]));
        v949 = (0);
        for (; v949 < (100); v949++)
        {
            v952 = (20 + v949);
            if (!(v951.Add((v952))))
                continue;
            yield return (v952);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RepeatExceptArrayRewritten_ProceduralLinq1()
    {
        int v953;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v954;
        HashSet<int> v955;
        int v956;
        v955 = new HashSet<int>();
        v954 = (0);
        for (; v954 < (ArrayItems2.Length); v954++)
            v955.Add((ArrayItems2[v954]));
        v953 = (0);
        for (; v953 < (100); v953++)
        {
            v956 = (20);
            if (!(v955.Add((v956))))
                continue;
            yield return (v956);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EmptyExceptArrayRewritten_ProceduralLinq1()
    {
        int v957;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v958;
        HashSet<int> v959;
        int v960;
        v959 = new HashSet<int>();
        v958 = (0);
        for (; v958 < (ArrayItems2.Length); v958++)
            v959.Add((ArrayItems2[v958]));
        v957 = 0;
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeEmpty2ArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v961;
        int v962;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v963;
        HashSet<int> v964;
        v964 = new HashSet<int>();
        v963 = (0);
        for (; v963 < (ArrayItems2.Length); v963++)
            v964.Add((ArrayItems2[v963]));
        v961 = (0);
        for (; v961 < (ArrayItems.Length); v961++)
        {
            v962 = (ArrayItems[v961]);
            if (!((false)))
                continue;
            v962 = (v962);
            if (!(v964.Add((v962))))
                continue;
            yield return (v962);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptRangeRewritten_ProceduralLinq1()
    {
        int v965;
        v965 = (0);
        for (; v965 < (260); v965++)
            yield return (70 + v965);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptRangeRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v966;
        if (ArrayExceptRangeRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v967;
        HashSet<int> v968;
        int v969;
        v967 = ArrayExceptRangeRewritten_ProceduralLinq1().GetEnumerator();
        v968 = new HashSet<int>();
        try
        {
            while (v967.MoveNext())
                v968.Add((v967.Current));
        }
        finally
        {
            v967.Dispose();
        }

        v966 = (0);
        for (; v966 < (ArrayItems.Length); v966++)
        {
            v969 = (ArrayItems[v966]);
            if (!(v968.Add((v969))))
                continue;
            yield return (v969);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptRepeatRewritten_ProceduralLinq1()
    {
        int v970;
        v970 = (0);
        for (; v970 < (100); v970++)
            yield return (70);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptRepeatRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v971;
        if (ArrayExceptRepeatRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v972;
        HashSet<int> v973;
        int v974;
        v972 = ArrayExceptRepeatRewritten_ProceduralLinq1().GetEnumerator();
        v973 = new HashSet<int>();
        try
        {
            while (v972.MoveNext())
                v973.Add((v972.Current));
        }
        finally
        {
            v972.Dispose();
        }

        v971 = (0);
        for (; v971 < (ArrayItems.Length); v971++)
        {
            v974 = (ArrayItems[v971]);
            if (!(v973.Add((v974))))
                continue;
            yield return (v974);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptEmptyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v975;
        if (Enumerable.Empty<int>() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v976;
        HashSet<int> v977;
        int v978;
        v976 = Enumerable.Empty<int>().GetEnumerator();
        v977 = new HashSet<int>();
        try
        {
            while (v976.MoveNext())
                v977.Add((v976.Current));
        }
        finally
        {
            v976.Dispose();
        }

        v975 = (0);
        for (; v975 < (ArrayItems.Length); v975++)
        {
            v978 = (ArrayItems[v975]);
            if (!(v977.Add((v978))))
                continue;
            yield return (v978);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptEmpty2Rewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v979;
        int v980;
        v979 = (0);
        for (; v979 < (ArrayItems2.Length); v979++)
        {
            v980 = (ArrayItems2[v979]);
            if (!((false)))
                continue;
            yield return (v980);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptEmpty2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v981;
        if (ArrayExceptEmpty2Rewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v982;
        HashSet<int> v983;
        int v984;
        v982 = ArrayExceptEmpty2Rewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v983 = new HashSet<int>();
        try
        {
            while (v982.MoveNext())
                v983.Add((v982.Current));
        }
        finally
        {
            v982.Dispose();
        }

        v981 = (0);
        for (; v981 < (ArrayItems.Length); v981++)
        {
            v984 = (ArrayItems[v981]);
            if (!(v983.Add((v984))))
                continue;
            yield return (v984);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptAllRewritten_ProceduralLinq1()
    {
        int v985;
        v985 = (0);
        for (; v985 < (1000); v985++)
            yield return (v985);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptAllRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v986;
        if (ArrayExceptAllRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v987;
        HashSet<int> v988;
        int v989;
        v987 = ArrayExceptAllRewritten_ProceduralLinq1().GetEnumerator();
        v988 = new HashSet<int>();
        try
        {
            while (v987.MoveNext())
                v988.Add((v987.Current));
        }
        finally
        {
            v987.Dispose();
        }

        v986 = (0);
        for (; v986 < (ArrayItems.Length); v986++)
        {
            v989 = (ArrayItems[v986]);
            if (!(v988.Add((v989))))
                continue;
            yield return (v989);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptNullRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v990;
        throw new System.InvalidOperationException("Invalid null object");
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptArrayExceptEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v991;
        if (ArrayItems == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v992;
        HashSet<int> v993;
        int v994;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v995;
        HashSet<int> v996;
        v995 = EnumerableItems2.GetEnumerator();
        v996 = new HashSet<int>();
        try
        {
            while (v995.MoveNext())
                v996.Add((v995.Current));
        }
        finally
        {
            v995.Dispose();
        }

        v993 = new HashSet<int>();
        v992 = (0);
        for (; v992 < (ArrayItems.Length); v992++)
            v993.Add((ArrayItems[v992]));
        v991 = (0);
        for (; v991 < (ArrayItems.Length); v991++)
        {
            v994 = (ArrayItems[v991]);
            if (!(v993.Add((v994))))
                continue;
            v994 = (v994);
            if (!(v996.Add((v994))))
                continue;
            yield return (v994);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptArrayExceptEnumerable2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v997;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v998;
        HashSet<int> v999;
        int v1000;
        v998 = EnumerableItems2.GetEnumerator();
        v999 = new HashSet<int>();
        try
        {
            while (v998.MoveNext())
                v999.Add((v998.Current));
        }
        finally
        {
            v998.Dispose();
        }

        v997 = (0);
        for (; v997 < (ArrayItems.Length); v997++)
        {
            v1000 = (ArrayItems[v997]);
            if (!(v999.Add((v1000))))
                continue;
            yield return (v1000);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptArrayExceptEnumerable2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1001;
        if (ArrayExceptArrayExceptEnumerable2Rewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1002;
        HashSet<int> v1003;
        int v1004;
        v1002 = ArrayExceptArrayExceptEnumerable2Rewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v1003 = new HashSet<int>();
        try
        {
            while (v1002.MoveNext())
                v1003.Add((v1002.Current));
        }
        finally
        {
            v1002.Dispose();
        }

        v1001 = (0);
        for (; v1001 < (ArrayItems.Length); v1001++)
        {
            v1004 = (ArrayItems[v1001]);
            if (!(v1003.Add((v1004))))
                continue;
            yield return (v1004);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctExceptArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1005;
        HashSet<int> v1006;
        int v1007;
        v1006 = new HashSet<int>();
        v1005 = (0);
        for (; v1005 < (ArrayItems.Length); v1005++)
        {
            v1007 = (ArrayItems[v1005]);
            if (!(v1006.Add((v1007))))
                continue;
            yield return (v1007);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctExceptArrayDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1008;
        HashSet<int> v1009;
        int v1010;
        if (ArrayDistinctExceptArrayDistinctRewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1011;
        HashSet<int> v1012;
        v1011 = ArrayDistinctExceptArrayDistinctRewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v1012 = new HashSet<int>();
        try
        {
            while (v1011.MoveNext())
                v1012.Add((v1011.Current));
        }
        finally
        {
            v1011.Dispose();
        }

        v1009 = new HashSet<int>();
        v1008 = (0);
        for (; v1008 < (ArrayItems.Length); v1008++)
        {
            v1010 = (ArrayItems[v1008]);
            if (!(v1009.Add((v1010))))
                continue;
            v1010 = (v1010);
            if (!(v1012.Add((v1010))))
                continue;
            yield return (v1010);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctExceptArrayDistinctDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1013;
        HashSet<int> v1014;
        int v1015;
        v1014 = new HashSet<int>();
        v1013 = (0);
        for (; v1013 < (ArrayItems.Length); v1013++)
        {
            v1015 = (ArrayItems[v1013]);
            if (!(v1014.Add((v1015))))
                continue;
            yield return (v1015);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctExceptArrayDistinctDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1016;
        HashSet<int> v1017;
        int v1018;
        if (ArrayDistinctExceptArrayDistinctDistinctRewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1019;
        HashSet<int> v1020;
        HashSet<int> v1021;
        v1019 = ArrayDistinctExceptArrayDistinctDistinctRewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
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

        v1017 = new HashSet<int>();
        v1021 = new HashSet<int>();
        v1016 = (0);
        for (; v1016 < (ArrayItems.Length); v1016++)
        {
            v1018 = (ArrayItems[v1016]);
            if (!(v1017.Add((v1018))))
                continue;
            v1018 = (v1018);
            if (!(v1020.Add((v1018))))
                continue;
            v1018 = (v1018);
            if (!(v1021.Add((v1018))))
                continue;
            yield return (v1018);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctExceptArrayDistinctDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1022;
        HashSet<int> v1023;
        int v1024;
        v1023 = new HashSet<int>(EqualityComparer<int>.Default);
        v1022 = (0);
        for (; v1022 < (ArrayItems.Length); v1022++)
        {
            v1024 = (ArrayItems[v1022]);
            if (!(v1023.Add((v1024))))
                continue;
            yield return (v1024);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctExceptArrayDistinctDistinct2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v1025;
        HashSet<int> v1026;
        int v1027;
        if (ArrayDistinctExceptArrayDistinctDistinct2Rewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v1028;
        HashSet<int> v1029;
        HashSet<int> v1030;
        v1028 = ArrayDistinctExceptArrayDistinctDistinct2Rewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v1029 = new HashSet<int>();
        try
        {
            while (v1028.MoveNext())
                v1029.Add((v1028.Current));
        }
        finally
        {
            v1028.Dispose();
        }

        v1026 = new HashSet<int>(EqualityComparer<int>.Default);
        v1030 = new HashSet<int>(EqualityComparer<int>.Default);
        v1025 = (0);
        for (; v1025 < (ArrayItems.Length); v1025++)
        {
            v1027 = (ArrayItems[v1025]);
            if (!(v1026.Add((v1027))))
                continue;
            v1027 = (v1027);
            if (!(v1029.Add((v1027))))
                continue;
            v1027 = (v1027);
            if (!(v1030.Add((v1027))))
                continue;
            yield return (v1027);
        }

        yield break;
    }
}}