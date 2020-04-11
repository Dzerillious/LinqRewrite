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
        int v605;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v606;
        HashSet<int> v607;
        v607 = new HashSet<int>();
        v606 = (0);
        for (; v606 < (ArrayItems2.Length); v606 += 1)
            v607.Add((ArrayItems2[v606]));
        v605 = (0);
        for (; v605 < (ArrayItems.Length); v605 += 1)
        {
            if (!(v607.Add((((ArrayItems[v605]))))))
                continue;
            yield return (((ArrayItems[v605])));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v608;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v609;
        v609 = SimpleListItems2.Count;
        int v610;
        HashSet<int> v611;
        v611 = new HashSet<int>();
        v610 = (0);
        for (; v610 < (v609); v610 += 1)
            v611.Add((SimpleListItems2[v610]));
        v608 = (0);
        for (; v608 < (ArrayItems.Length); v608 += 1)
        {
            if (!(v611.Add((((ArrayItems[v608]))))))
                continue;
            yield return (((ArrayItems[v608])));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v612;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v613;
        HashSet<int> v614;
        v613 = EnumerableItems2.GetEnumerator();
        v614 = new HashSet<int>();
        try
        {
            while (v613.MoveNext())
                v614.Add((v613.Current));
        }
        finally
        {
            v613.Dispose();
        }

        v612 = (0);
        for (; v612 < (ArrayItems.Length); v612 += 1)
        {
            if (!(v614.Add((((ArrayItems[v612]))))))
                continue;
            yield return (((ArrayItems[v612])));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v615;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v616;
        HashSet<int> v617;
        v616 = MethodEnumerable2().GetEnumerator();
        v617 = new HashSet<int>();
        try
        {
            while (v616.MoveNext())
                v617.Add((v616.Current));
        }
        finally
        {
            v616.Dispose();
        }

        v615 = (0);
        for (; v615 < (ArrayItems.Length); v615 += 1)
        {
            if (!(v617.Add((((ArrayItems[v615]))))))
                continue;
            yield return (((ArrayItems[v615])));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SimpleListExceptArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v618;
        v618 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v619;
        v619 = SimpleListItems;
        int v620;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v621;
        HashSet<int> v622;
        v622 = new HashSet<int>();
        v621 = (0);
        for (; v621 < (ArrayItems2.Length); v621 += 1)
            v622.Add((ArrayItems2[v621]));
        v620 = (0);
        for (; v620 < (v618); v620 += 1)
        {
            if (!(v622.Add((((v619[v620]))))))
                continue;
            yield return (((v619[v620])));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SimpleListExceptSimpleListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v623;
        v623 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v624;
        v624 = SimpleListItems;
        int v625;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v626;
        v626 = SimpleListItems2.Count;
        int v627;
        HashSet<int> v628;
        v628 = new HashSet<int>();
        v627 = (0);
        for (; v627 < (v626); v627 += 1)
            v628.Add((SimpleListItems2[v627]));
        v625 = (0);
        for (; v625 < (v623); v625 += 1)
        {
            if (!(v628.Add((((v624[v625]))))))
                continue;
            yield return (((v624[v625])));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SimpleListExceptEnumerableRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v629;
        v629 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v630;
        v630 = SimpleListItems;
        int v631;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v632;
        HashSet<int> v633;
        v632 = EnumerableItems2.GetEnumerator();
        v633 = new HashSet<int>();
        try
        {
            while (v632.MoveNext())
                v633.Add((v632.Current));
        }
        finally
        {
            v632.Dispose();
        }

        v631 = (0);
        for (; v631 < (v629); v631 += 1)
        {
            if (!(v633.Add((((v630[v631]))))))
                continue;
            yield return (((v630[v631])));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SimpleListExceptMethodRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v634;
        v634 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v635;
        v635 = SimpleListItems;
        int v636;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v637;
        HashSet<int> v638;
        v637 = MethodEnumerable2().GetEnumerator();
        v638 = new HashSet<int>();
        try
        {
            while (v637.MoveNext())
                v638.Add((v637.Current));
        }
        finally
        {
            v637.Dispose();
        }

        v636 = (0);
        for (; v636 < (v634); v636 += 1)
        {
            if (!(v638.Add((((v635[v636]))))))
                continue;
            yield return (((v635[v636])));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableExceptArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v639;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v640;
        HashSet<int> v641;
        int v642;
        v639 = EnumerableItems.GetEnumerator();
        v641 = new HashSet<int>();
        v640 = (0);
        for (; v640 < (ArrayItems2.Length); v640 += 1)
            v641.Add((ArrayItems2[v640]));
        try
        {
            while (v639.MoveNext())
            {
                v642 = ((v639.Current));
                if (!(v641.Add((v642))))
                    continue;
                yield return (v642);
            }
        }
        finally
        {
            v639.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableExceptSimpleListRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v643;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v644;
        v644 = SimpleListItems2.Count;
        int v645;
        HashSet<int> v646;
        int v647;
        v643 = EnumerableItems.GetEnumerator();
        v646 = new HashSet<int>();
        v645 = (0);
        for (; v645 < (v644); v645 += 1)
            v646.Add((SimpleListItems2[v645]));
        try
        {
            while (v643.MoveNext())
            {
                v647 = ((v643.Current));
                if (!(v646.Add((v647))))
                    continue;
                yield return (v647);
            }
        }
        finally
        {
            v643.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableExceptEnumerableRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v648;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v649;
        HashSet<int> v650;
        int v651;
        v649 = EnumerableItems2.GetEnumerator();
        v648 = EnumerableItems.GetEnumerator();
        v650 = new HashSet<int>();
        try
        {
            while (v649.MoveNext())
                v650.Add((v649.Current));
        }
        finally
        {
            v649.Dispose();
        }

        try
        {
            while (v648.MoveNext())
            {
                v651 = ((v648.Current));
                if (!(v650.Add((v651))))
                    continue;
                yield return (v651);
            }
        }
        finally
        {
            v648.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableExceptMethodRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v652;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v653;
        HashSet<int> v654;
        int v655;
        v653 = MethodEnumerable2().GetEnumerator();
        v652 = EnumerableItems.GetEnumerator();
        v654 = new HashSet<int>();
        try
        {
            while (v653.MoveNext())
                v654.Add((v653.Current));
        }
        finally
        {
            v653.Dispose();
        }

        try
        {
            while (v652.MoveNext())
            {
                v655 = ((v652.Current));
                if (!(v654.Add((v655))))
                    continue;
                yield return (v655);
            }
        }
        finally
        {
            v652.Dispose();
        }

        yield break;
    }

    int[] ArrayExceptArrayToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v656;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v657;
        HashSet<int> v658;
        int v659;
        int v660;
        int v661;
        int[] v662;
        v658 = new HashSet<int>();
        v657 = (0);
        for (; v657 < (ArrayItems2.Length); v657 += 1)
            v658.Add((ArrayItems2[v657]));
        v659 = 0;
        v660 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems2.Length + ArrayItems.Length))) - 3);
        v660 -= (v660 % 2);
        v661 = 8;
        v662 = new int[8];
        v656 = (0);
        for (; v656 < (ArrayItems.Length); v656 += 1)
        {
            if (!(v658.Add((((ArrayItems[v656]))))))
                continue;
            if (v659 >= v661)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems2.Length + ArrayItems.Length), ref v662, ref v660, out v661);
            v662[v659] = (((ArrayItems[v656])));
            v659++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v662, v659);
    }

    int[] ArrayExceptSimpleListToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v663;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v664;
        v664 = SimpleListItems2.Count;
        int v665;
        HashSet<int> v666;
        int v667;
        int v668;
        int v669;
        int[] v670;
        v666 = new HashSet<int>();
        v665 = (0);
        for (; v665 < (v664); v665 += 1)
            v666.Add((SimpleListItems2[v665]));
        v667 = 0;
        v668 = (LinqRewrite.Core.IntExtensions.Log2((uint)((v664 + ArrayItems.Length))) - 3);
        v668 -= (v668 % 2);
        v669 = 8;
        v670 = new int[8];
        v663 = (0);
        for (; v663 < (ArrayItems.Length); v663 += 1)
        {
            if (!(v666.Add((((ArrayItems[v663]))))))
                continue;
            if (v667 >= v669)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (v664 + ArrayItems.Length), ref v670, ref v668, out v669);
            v670[v667] = (((ArrayItems[v663])));
            v667++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v670, v667);
    }

    int[] ArrayExceptEnumerableToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v671;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v672;
        HashSet<int> v673;
        int v674;
        int v675;
        int[] v676;
        v672 = EnumerableItems2.GetEnumerator();
        v673 = new HashSet<int>();
        try
        {
            while (v672.MoveNext())
                v673.Add((v672.Current));
        }
        finally
        {
            v672.Dispose();
        }

        v674 = 0;
        v675 = 8;
        v676 = new int[8];
        v671 = (0);
        for (; v671 < (ArrayItems.Length); v671 += 1)
        {
            if (!(v673.Add((((ArrayItems[v671]))))))
                continue;
            if (v674 >= v675)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v676, ref v675);
            v676[v674] = (((ArrayItems[v671])));
            v674++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v676, v674);
    }

    int[] SimpleListExceptArrayToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v677;
        v677 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v678;
        v678 = SimpleListItems;
        int v679;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v680;
        HashSet<int> v681;
        int v682;
        int v683;
        int v684;
        int[] v685;
        v681 = new HashSet<int>();
        v680 = (0);
        for (; v680 < (ArrayItems2.Length); v680 += 1)
            v681.Add((ArrayItems2[v680]));
        v682 = 0;
        v683 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems2.Length + v677))) - 3);
        v683 -= (v683 % 2);
        v684 = 8;
        v685 = new int[8];
        v679 = (0);
        for (; v679 < (v677); v679 += 1)
        {
            if (!(v681.Add((((v678[v679]))))))
                continue;
            if (v682 >= v684)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems2.Length + v677), ref v685, ref v683, out v684);
            v685[v682] = (((v678[v679])));
            v682++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v685, v682);
    }

    int[] SimpleListExceptSimpleListToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v686;
        v686 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v687;
        v687 = SimpleListItems;
        int v688;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v689;
        v689 = SimpleListItems2.Count;
        int v690;
        HashSet<int> v691;
        int v692;
        int v693;
        int v694;
        int[] v695;
        v691 = new HashSet<int>();
        v690 = (0);
        for (; v690 < (v689); v690 += 1)
            v691.Add((SimpleListItems2[v690]));
        v692 = 0;
        v693 = (LinqRewrite.Core.IntExtensions.Log2((uint)((v689 + v686))) - 3);
        v693 -= (v693 % 2);
        v694 = 8;
        v695 = new int[8];
        v688 = (0);
        for (; v688 < (v686); v688 += 1)
        {
            if (!(v691.Add((((v687[v688]))))))
                continue;
            if (v692 >= v694)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (v689 + v686), ref v695, ref v693, out v694);
            v695[v692] = (((v687[v688])));
            v692++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v695, v692);
    }

    int[] SimpleListExceptEnumerableToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v696;
        v696 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v697;
        v697 = SimpleListItems;
        int v698;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v699;
        HashSet<int> v700;
        int v701;
        int v702;
        int[] v703;
        v699 = EnumerableItems2.GetEnumerator();
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

        v701 = 0;
        v702 = 8;
        v703 = new int[8];
        v698 = (0);
        for (; v698 < (v696); v698 += 1)
        {
            if (!(v700.Add((((v697[v698]))))))
                continue;
            if (v701 >= v702)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v703, ref v702);
            v703[v701] = (((v697[v698])));
            v701++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v703, v701);
    }

    int[] EnumerableExceptArrayToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v704;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v705;
        HashSet<int> v706;
        int v707;
        int v708;
        int v709;
        int[] v710;
        v704 = EnumerableItems.GetEnumerator();
        v706 = new HashSet<int>();
        v705 = (0);
        for (; v705 < (ArrayItems2.Length); v705 += 1)
            v706.Add((ArrayItems2[v705]));
        v708 = 0;
        v709 = 8;
        v710 = new int[8];
        try
        {
            while (v704.MoveNext())
            {
                v707 = ((v704.Current));
                if (!(v706.Add((v707))))
                    continue;
                if (v708 >= v709)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v710, ref v709);
                v710[v708] = (v707);
                v708++;
            }
        }
        finally
        {
            v704.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v710, v708);
    }

    int[] EnumerableExceptSimpleListToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v711;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v712;
        v712 = SimpleListItems2.Count;
        int v713;
        HashSet<int> v714;
        int v715;
        int v716;
        int v717;
        int[] v718;
        v711 = EnumerableItems.GetEnumerator();
        v714 = new HashSet<int>();
        v713 = (0);
        for (; v713 < (v712); v713 += 1)
            v714.Add((SimpleListItems2[v713]));
        v716 = 0;
        v717 = 8;
        v718 = new int[8];
        try
        {
            while (v711.MoveNext())
            {
                v715 = ((v711.Current));
                if (!(v714.Add((v715))))
                    continue;
                if (v716 >= v717)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v718, ref v717);
                v718[v716] = (v715);
                v716++;
            }
        }
        finally
        {
            v711.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v718, v716);
    }

    int[] EnumerableExceptEnumerableToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v719;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v720;
        HashSet<int> v721;
        int v722;
        int v723;
        int v724;
        int[] v725;
        v720 = EnumerableItems2.GetEnumerator();
        v719 = EnumerableItems.GetEnumerator();
        v721 = new HashSet<int>();
        try
        {
            while (v720.MoveNext())
                v721.Add((v720.Current));
        }
        finally
        {
            v720.Dispose();
        }

        v723 = 0;
        v724 = 8;
        v725 = new int[8];
        try
        {
            while (v719.MoveNext())
            {
                v722 = ((v719.Current));
                if (!(v721.Add((v722))))
                    continue;
                if (v723 >= v724)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v725, ref v724);
                v725[v723] = (v722);
                v723++;
            }
        }
        finally
        {
            v719.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v725, v723);
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectExceptArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v726;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v727;
        HashSet<int> v728;
        int v729;
        v728 = new HashSet<int>();
        v727 = (0);
        for (; v727 < (ArrayItems2.Length); v727 += 1)
            v728.Add((ArrayItems2[v727]));
        v726 = (0);
        for (; v726 < (ArrayItems.Length); v726 += 1)
        {
            v729 = (50 + ArrayItems[v726]);
            if (!(v728.Add((v729))))
                continue;
            yield return (v729);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectExceptArraySelectRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v731;
        v731 = (0);
        for (; v731 < (ArrayItems2.Length); v731 += 1)
            yield return (((ArrayItems2[v731]) + 50));
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectExceptArraySelectRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v732;
        if (ArraySelectExceptArraySelectRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v733;
        HashSet<int> v734;
        int v735;
        v733 = ArraySelectExceptArraySelectRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v734 = new HashSet<int>();
        try
        {
            while (v733.MoveNext())
                v734.Add((v733.Current));
        }
        finally
        {
            v733.Dispose();
        }

        v732 = (0);
        for (; v732 < (ArrayItems.Length); v732 += 1)
        {
            v735 = (50 + ArrayItems[v732]);
            if (!(v734.Add((v735))))
                continue;
            yield return (v735);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereExceptArrayWhereRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v736;
        v736 = (0);
        for (; v736 < (ArrayItems2.Length); v736 += 1)
        {
            if (!((((ArrayItems2[v736])) > 50)))
                continue;
            yield return ((ArrayItems2[v736]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereExceptArrayWhereRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v737;
        if (ArrayWhereExceptArrayWhereRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v738;
        HashSet<int> v739;
        v738 = ArrayWhereExceptArrayWhereRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v739 = new HashSet<int>();
        try
        {
            while (v738.MoveNext())
                v739.Add((v738.Current));
        }
        finally
        {
            v738.Dispose();
        }

        v737 = (0);
        for (; v737 < (ArrayItems.Length); v737 += 1)
        {
            if (!((((ArrayItems[v737])) > 50)))
                continue;
            if (!(v739.Add(((((ArrayItems[v737])))))))
                continue;
            yield return ((((ArrayItems[v737]))));
        }

        yield break;
    }

    int ArrayExceptArrayCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v740;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v741;
        HashSet<int> v742;
        int v743;
        v742 = new HashSet<int>();
        v741 = (0);
        for (; v741 < (ArrayItems2.Length); v741 += 1)
            v742.Add((ArrayItems2[v741]));
        v743 = 0;
        v740 = (0);
        for (; v740 < (ArrayItems.Length); v740 += 1)
        {
            if (!(v742.Add((((ArrayItems[v740]))))))
                continue;
            v743++;
        }

        return v743;
    }

    int ArrayExceptArrayCount2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v744;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v745;
        HashSet<int> v746;
        int v747;
        v746 = new HashSet<int>();
        v745 = (0);
        for (; v745 < (ArrayItems2.Length); v745 += 1)
            v746.Add((ArrayItems2[v745]));
        v747 = 0;
        v744 = (0);
        for (; v744 < (ArrayItems.Length); v744 += 1)
        {
            if (!(v746.Add((((ArrayItems[v744]))))))
                continue;
            if (!(((((ArrayItems[v744]))) > 70)))
                continue;
            v747++;
        }

        return v747;
    }

    int ArrayExceptArraySumRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v748;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v749;
        HashSet<int> v750;
        int v751;
        v750 = new HashSet<int>();
        v749 = (0);
        for (; v749 < (ArrayItems2.Length); v749 += 1)
            v750.Add((ArrayItems2[v749]));
        v751 = 0;
        v748 = (0);
        for (; v748 < (ArrayItems.Length); v748 += 1)
        {
            if (!(v750.Add((((ArrayItems[v748]))))))
                continue;
            v751 += (((ArrayItems[v748])));
        }

        return v751;
    }

    int ArrayExceptArraySum2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v752;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v753;
        HashSet<int> v754;
        int v755;
        v754 = new HashSet<int>();
        v753 = (0);
        for (; v753 < (ArrayItems2.Length); v753 += 1)
            v754.Add((ArrayItems2[v753]));
        v755 = 0;
        v752 = (0);
        for (; v752 < (ArrayItems.Length); v752 += 1)
        {
            if (!(v754.Add((((ArrayItems[v752]))))))
                continue;
            v755 += ((((ArrayItems[v752]))) + 10);
        }

        return v755;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v756;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v757;
        HashSet<int> v758;
        HashSet<int> v759;
        v758 = new HashSet<int>();
        v757 = (0);
        for (; v757 < (ArrayItems2.Length); v757 += 1)
            v758.Add((ArrayItems2[v757]));
        v759 = new HashSet<int>();
        v756 = (0);
        for (; v756 < (ArrayItems.Length); v756 += 1)
        {
            if (!(v758.Add((((ArrayItems[v756]))))))
                continue;
            if (!(v759.Add(((((ArrayItems[v756])))))))
                continue;
            yield return ((((ArrayItems[v756]))));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptArrayDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v760;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v761;
        HashSet<int> v762;
        HashSet<int> v763;
        v762 = new HashSet<int>();
        v761 = (0);
        for (; v761 < (ArrayItems2.Length); v761 += 1)
            v762.Add((ArrayItems2[v761]));
        v763 = new HashSet<int>(EqualityComparer<int>.Default);
        v760 = (0);
        for (; v760 < (ArrayItems.Length); v760 += 1)
        {
            if (!(v762.Add((((ArrayItems[v760]))))))
                continue;
            if (!(v763.Add(((((ArrayItems[v760])))))))
                continue;
            yield return ((((ArrayItems[v760]))));
        }

        yield break;
    }

    int ArrayExceptArrayElementAtRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v764;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v765;
        HashSet<int> v766;
        int v767;
        v766 = new HashSet<int>();
        v765 = (0);
        for (; v765 < (ArrayItems2.Length); v765 += 1)
            v766.Add((ArrayItems2[v765]));
        v767 = 0;
        v764 = (0);
        for (; v764 < (ArrayItems.Length); v764 += 1)
        {
            if (!(v766.Add((((ArrayItems[v764]))))))
                continue;
            if (v767 == 45)
                return (((ArrayItems[v764])));
            v767++;
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArrayExceptArrayElementAtOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v768;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v769;
        HashSet<int> v770;
        int v771;
        v770 = new HashSet<int>();
        v769 = (0);
        for (; v769 < (ArrayItems2.Length); v769 += 1)
            v770.Add((ArrayItems2[v769]));
        v771 = 0;
        v768 = (0);
        for (; v768 < (ArrayItems.Length); v768 += 1)
        {
            if (!(v770.Add((((ArrayItems[v768]))))))
                continue;
            if (v771 == 45)
                return (((ArrayItems[v768])));
            v771++;
        }

        return default(int);
    }

    int ArrayExceptArrayFirstRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v772;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v773;
        HashSet<int> v774;
        int v775;
        v774 = new HashSet<int>();
        v773 = (0);
        for (; v773 < (ArrayItems2.Length); v773 += 1)
            v774.Add((ArrayItems2[v773]));
        v775 = 0;
        v772 = (0);
        for (; v772 < (ArrayItems.Length); v772 += 1)
        {
            if (!(v774.Add((((ArrayItems[v772]))))))
                continue;
            return (((ArrayItems[v772])));
            v775++;
        }

        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int ArrayExceptArrayFirstOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v776;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v777;
        HashSet<int> v778;
        v778 = new HashSet<int>();
        v777 = (0);
        for (; v777 < (ArrayItems2.Length); v777 += 1)
            v778.Add((ArrayItems2[v777]));
        v776 = (0);
        for (; v776 < (ArrayItems.Length); v776 += 1)
        {
            if (!(v778.Add((((ArrayItems[v776]))))))
                continue;
            return (((ArrayItems[v776])));
        }

        return default(int);
    }

    int ArrayExceptArrayLastRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v779;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v780;
        HashSet<int> v781;
        int v782;
        int? v783;
        v781 = new HashSet<int>();
        v780 = (0);
        for (; v780 < (ArrayItems2.Length); v780 += 1)
            v781.Add((ArrayItems2[v780]));
        v782 = 0;
        v783 = null;
        v779 = (0);
        for (; v779 < (ArrayItems.Length); v779 += 1)
        {
            if (!(v781.Add((((ArrayItems[v779]))))))
                continue;
            v783 = (((ArrayItems[v779])));
            v782++;
        }

        if (v783 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v783;
    }

    int ArrayExceptArrayLastOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v784;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v785;
        HashSet<int> v786;
        int? v787;
        v786 = new HashSet<int>();
        v785 = (0);
        for (; v785 < (ArrayItems2.Length); v785 += 1)
            v786.Add((ArrayItems2[v785]));
        v787 = null;
        v784 = (0);
        for (; v784 < (ArrayItems.Length); v784 += 1)
        {
            if (!(v786.Add((((ArrayItems[v784]))))))
                continue;
            v787 = (((ArrayItems[v784])));
        }

        if (v787 == null)
            return default(int);
        else
            return (int)v787;
    }

    int ArrayExceptArraySingleRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v788;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v789;
        HashSet<int> v790;
        int? v791;
        v790 = new HashSet<int>();
        v789 = (0);
        for (; v789 < (ArrayItems2.Length); v789 += 1)
            v790.Add((ArrayItems2[v789]));
        v791 = null;
        v788 = (0);
        for (; v788 < (ArrayItems.Length); v788 += 1)
        {
            if (!(v790.Add((((ArrayItems[v788]))))))
                continue;
            if (v791 == null)
                v791 = (((ArrayItems[v788])));
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v791 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v791;
    }

    int ArrayExceptArraySingle2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v792;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v793;
        HashSet<int> v794;
        int? v795;
        v794 = new HashSet<int>();
        v793 = (0);
        for (; v793 < (ArrayItems2.Length); v793 += 1)
            v794.Add((ArrayItems2[v793]));
        v795 = null;
        v792 = (0);
        for (; v792 < (ArrayItems.Length); v792 += 1)
        {
            if (!(v794.Add((((ArrayItems[v792]))))))
                continue;
            if (((((ArrayItems[v792]))) == 76))
                if (v795 == null)
                    v795 = (((ArrayItems[v792])));
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v795 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v795;
    }

    int ArrayExceptArraySingleOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v796;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v797;
        HashSet<int> v798;
        int? v799;
        v798 = new HashSet<int>();
        v797 = (0);
        for (; v797 < (ArrayItems2.Length); v797 += 1)
            v798.Add((ArrayItems2[v797]));
        v799 = null;
        v796 = (0);
        for (; v796 < (ArrayItems.Length); v796 += 1)
        {
            if (!(v798.Add((((ArrayItems[v796]))))))
                continue;
            if (v799 == null)
                v799 = (((ArrayItems[v796])));
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v799 == null)
            return default(int);
        else
            return (int)v799;
    }

    int ArrayExceptArrayMinRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v800;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v801;
        HashSet<int> v802;
        int v803;
        int v804;
        v802 = new HashSet<int>();
        v801 = (0);
        for (; v801 < (ArrayItems2.Length); v801 += 1)
            v802.Add((ArrayItems2[v801]));
        v803 = 0;
        v804 = 2147483647;
        v800 = (0);
        for (; v800 < (ArrayItems.Length); v800 += 1)
        {
            if (!(v802.Add((((ArrayItems[v800]))))))
                continue;
            if ((((ArrayItems[v800]))) >= v804)
                continue;
            v804 = (((ArrayItems[v800])));
            v803++;
        }

        if (1 > v803)
            throw new System.InvalidOperationException("Index out of range");
        return v804;
    }

    decimal ArrayExceptArrayMin2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v805;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v806;
        HashSet<int> v807;
        int v808;
        decimal v809;
        decimal v810;
        v807 = new HashSet<int>();
        v806 = (0);
        for (; v806 < (ArrayItems2.Length); v806 += 1)
            v807.Add((ArrayItems2[v806]));
        v808 = 0;
        v809 = 79228162514264337593543950335M;
        v805 = (0);
        for (; v805 < (ArrayItems.Length); v805 += 1)
        {
            if (!(v807.Add((((ArrayItems[v805]))))))
                continue;
            v810 = ((((ArrayItems[v805]))) + 2m);
            if (v810 >= v809)
                continue;
            v809 = v810;
            v808++;
        }

        if (1 > v808)
            throw new System.InvalidOperationException("Index out of range");
        return v809;
    }

    int ArrayExceptArrayMaxRewritten_ProceduralLinq1(int[] ArrayItems)
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
        for (; v812 < (ArrayItems2.Length); v812 += 1)
            v813.Add((ArrayItems2[v812]));
        v814 = 0;
        v815 = -2147483648;
        v811 = (0);
        for (; v811 < (ArrayItems.Length); v811 += 1)
        {
            if (!(v813.Add((((ArrayItems[v811]))))))
                continue;
            if ((((ArrayItems[v811]))) <= v815)
                continue;
            v815 = (((ArrayItems[v811])));
            v814++;
        }

        if (1 > v814)
            throw new System.InvalidOperationException("Index out of range");
        return v815;
    }

    decimal ArrayExceptArrayMax2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v816;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v817;
        HashSet<int> v818;
        int v819;
        decimal v820;
        decimal v821;
        v818 = new HashSet<int>();
        v817 = (0);
        for (; v817 < (ArrayItems2.Length); v817 += 1)
            v818.Add((ArrayItems2[v817]));
        v819 = 0;
        v820 = -79228162514264337593543950335M;
        v816 = (0);
        for (; v816 < (ArrayItems.Length); v816 += 1)
        {
            if (!(v818.Add((((ArrayItems[v816]))))))
                continue;
            v821 = ((((ArrayItems[v816]))) + 2m);
            if (v821 <= v820)
                continue;
            v820 = v821;
            v819++;
        }

        if (1 > v819)
            throw new System.InvalidOperationException("Index out of range");
        return v820;
    }

    long ArrayExceptArrayLongCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v822;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v823;
        HashSet<int> v824;
        long v825;
        v824 = new HashSet<int>();
        v823 = (0);
        for (; v823 < (ArrayItems2.Length); v823 += 1)
            v824.Add((ArrayItems2[v823]));
        v825 = 0;
        v822 = (0);
        for (; v822 < (ArrayItems.Length); v822 += 1)
        {
            if (!(v824.Add((((ArrayItems[v822]))))))
                continue;
            v825++;
        }

        return v825;
    }

    long ArrayExceptArrayLongCount2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v826;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v827;
        HashSet<int> v828;
        long v829;
        v828 = new HashSet<int>();
        v827 = (0);
        for (; v827 < (ArrayItems2.Length); v827 += 1)
            v828.Add((ArrayItems2[v827]));
        v829 = 0;
        v826 = (0);
        for (; v826 < (ArrayItems.Length); v826 += 1)
        {
            if (!(v828.Add((((ArrayItems[v826]))))))
                continue;
            if (!(((((ArrayItems[v826]))) > 50)))
                continue;
            v829++;
        }

        return v829;
    }

    bool ArrayExceptArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v830;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v831;
        HashSet<int> v832;
        v832 = new HashSet<int>();
        v831 = (0);
        for (; v831 < (ArrayItems2.Length); v831 += 1)
            v832.Add((ArrayItems2[v831]));
        v830 = (0);
        for (; v830 < (ArrayItems.Length); v830 += 1)
        {
            if (!(v832.Add((((ArrayItems[v830]))))))
                continue;
            if ((((ArrayItems[v830]))) == 56)
                return true;
        }

        return false;
    }

    double ArrayExceptArrayAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v833;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v834;
        HashSet<int> v835;
        double v836;
        int v837;
        v835 = new HashSet<int>();
        v834 = (0);
        for (; v834 < (ArrayItems2.Length); v834 += 1)
            v835.Add((ArrayItems2[v834]));
        v836 = 0;
        v837 = 0;
        v833 = (0);
        for (; v833 < (ArrayItems.Length); v833 += 1)
        {
            if (!(v835.Add((((ArrayItems[v833]))))))
                continue;
            v836 += (((ArrayItems[v833])));
            v837++;
        }

        if (1 > v837)
            throw new System.InvalidOperationException("Index out of range");
        return (v836 / v837);
    }

    double ArrayExceptArrayAverage2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v838;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v839;
        HashSet<int> v840;
        double v841;
        int v842;
        v840 = new HashSet<int>();
        v839 = (0);
        for (; v839 < (ArrayItems2.Length); v839 += 1)
            v840.Add((ArrayItems2[v839]));
        v841 = 0;
        v842 = 0;
        v838 = (0);
        for (; v838 < (ArrayItems.Length); v838 += 1)
        {
            if (!(v840.Add((((ArrayItems[v838]))))))
                continue;
            v841 += ((((ArrayItems[v838]))) + 10);
            v842++;
        }

        if (1 > v842)
            throw new System.InvalidOperationException("Index out of range");
        return (v841 / v842);
    }

    bool ArrayExceptArrayContains2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v843;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v844;
        HashSet<int> v845;
        System.Collections.Generic.EqualityComparer<int> v846;
        v846 = EqualityComparer<int>.Default;
        v845 = new HashSet<int>();
        v844 = (0);
        for (; v844 < (ArrayItems2.Length); v844 += 1)
            v845.Add((ArrayItems2[v844]));
        v843 = (0);
        for (; v843 < (ArrayItems.Length); v843 += 1)
        {
            if (!(v845.Add((((ArrayItems[v843]))))))
                continue;
            if (v846.Equals((((ArrayItems[v843]))), 56))
                return true;
        }

        return false;
    }

    System.Collections.Generic.IEnumerable<int> SelectWhereArrayExceptSelectWhereArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v847;
        int v848;
        v847 = (0);
        for (; v847 < (ArrayItems2.Length); v847 += 1)
        {
            v848 = (((ArrayItems2[v847]) + 10));
            if (!(((v848) > 80)))
                continue;
            yield return (v848);
        }

        yield break;
    }

    bool SelectWhereArrayExceptSelectWhereArrayContainsRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v849;
        int v850;
        if (SelectWhereArrayExceptSelectWhereArrayContainsRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v851;
        HashSet<int> v852;
        v851 = SelectWhereArrayExceptSelectWhereArrayContainsRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v852 = new HashSet<int>();
        try
        {
            while (v851.MoveNext())
                v852.Add((v851.Current));
        }
        finally
        {
            v851.Dispose();
        }

        v849 = (0);
        for (; v849 < (ArrayItems.Length); v849 += 1)
        {
            v850 = (10 + ArrayItems[v849]);
            if (!(((v850) > 80)))
                continue;
            if (!(v852.Add((((v850))))))
                continue;
            if ((((v850))) == 112)
                return true;
        }

        return false;
    }

    System.Collections.Generic.IEnumerable<int> RangeExceptArrayRewritten_ProceduralLinq1()
    {
        int v853;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v854;
        HashSet<int> v855;
        int v856;
        v855 = new HashSet<int>();
        v854 = (0);
        for (; v854 < (ArrayItems2.Length); v854 += 1)
            v855.Add((ArrayItems2[v854]));
        v853 = (0);
        for (; v853 < (100); v853 += (1))
        {
            v856 = (20 + v853);
            if (!(v855.Add((v856))))
                continue;
            yield return (v856);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RepeatExceptArrayRewritten_ProceduralLinq1()
    {
        int v857;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v858;
        HashSet<int> v859;
        v859 = new HashSet<int>();
        v858 = (0);
        for (; v858 < (ArrayItems2.Length); v858 += 1)
            v859.Add((ArrayItems2[v858]));
        v857 = (0);
        for (; v857 < (100); v857 += 1)
        {
            if (!(v859.Add((((20))))))
                continue;
            yield return (((20)));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EmptyExceptArrayRewritten_ProceduralLinq1()
    {
        int v860;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v861;
        HashSet<int> v862;
        v862 = new HashSet<int>();
        v861 = (0);
        for (; v861 < (ArrayItems2.Length); v861 += 1)
            v862.Add((ArrayItems2[v861]));
        v860 = 0;
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeEmpty2ArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v863;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v864;
        HashSet<int> v865;
        v865 = new HashSet<int>();
        v864 = (0);
        for (; v864 < (ArrayItems2.Length); v864 += 1)
            v865.Add((ArrayItems2[v864]));
        v863 = (0);
        for (; v863 < (ArrayItems.Length); v863 += 1)
        {
            if (!((false)))
                continue;
            if (!(v865.Add(((((ArrayItems[v863])))))))
                continue;
            yield return ((((ArrayItems[v863]))));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptRangeRewritten_ProceduralLinq1()
    {
        int v866;
        v866 = (0);
        for (; v866 < (260); v866 += (1))
            yield return (70 + v866);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptRangeRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v867;
        if (ArrayExceptRangeRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v868;
        HashSet<int> v869;
        v868 = ArrayExceptRangeRewritten_ProceduralLinq1().GetEnumerator();
        v869 = new HashSet<int>();
        try
        {
            while (v868.MoveNext())
                v869.Add((v868.Current));
        }
        finally
        {
            v868.Dispose();
        }

        v867 = (0);
        for (; v867 < (ArrayItems.Length); v867 += 1)
        {
            if (!(v869.Add((((ArrayItems[v867]))))))
                continue;
            yield return (((ArrayItems[v867])));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptRepeatRewritten_ProceduralLinq1()
    {
        int v870;
        v870 = (0);
        for (; v870 < (100); v870 += 1)
            yield return (70);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptRepeatRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v871;
        if (ArrayExceptRepeatRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v872;
        HashSet<int> v873;
        v872 = ArrayExceptRepeatRewritten_ProceduralLinq1().GetEnumerator();
        v873 = new HashSet<int>();
        try
        {
            while (v872.MoveNext())
                v873.Add((v872.Current));
        }
        finally
        {
            v872.Dispose();
        }

        v871 = (0);
        for (; v871 < (ArrayItems.Length); v871 += 1)
        {
            if (!(v873.Add((((ArrayItems[v871]))))))
                continue;
            yield return (((ArrayItems[v871])));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptEmptyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v874;
        if (Enumerable.Empty<int>() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v875;
        HashSet<int> v876;
        v875 = Enumerable.Empty<int>().GetEnumerator();
        v876 = new HashSet<int>();
        try
        {
            while (v875.MoveNext())
                v876.Add((v875.Current));
        }
        finally
        {
            v875.Dispose();
        }

        v874 = (0);
        for (; v874 < (ArrayItems.Length); v874 += 1)
        {
            if (!(v876.Add((((ArrayItems[v874]))))))
                continue;
            yield return (((ArrayItems[v874])));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptEmpty2Rewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v877;
        v877 = (0);
        for (; v877 < (ArrayItems2.Length); v877 += 1)
        {
            if (!((false)))
                continue;
            yield return ((ArrayItems2[v877]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptEmpty2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v878;
        if (ArrayExceptEmpty2Rewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v879;
        HashSet<int> v880;
        v879 = ArrayExceptEmpty2Rewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v880 = new HashSet<int>();
        try
        {
            while (v879.MoveNext())
                v880.Add((v879.Current));
        }
        finally
        {
            v879.Dispose();
        }

        v878 = (0);
        for (; v878 < (ArrayItems.Length); v878 += 1)
        {
            if (!(v880.Add((((ArrayItems[v878]))))))
                continue;
            yield return (((ArrayItems[v878])));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptAllRewritten_ProceduralLinq1()
    {
        int v881;
        v881 = (0);
        for (; v881 < (1000); v881 += (1))
            yield return (v881);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptAllRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v882;
        if (ArrayExceptAllRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v883;
        HashSet<int> v884;
        v883 = ArrayExceptAllRewritten_ProceduralLinq1().GetEnumerator();
        v884 = new HashSet<int>();
        try
        {
            while (v883.MoveNext())
                v884.Add((v883.Current));
        }
        finally
        {
            v883.Dispose();
        }

        v882 = (0);
        for (; v882 < (ArrayItems.Length); v882 += 1)
        {
            if (!(v884.Add((((ArrayItems[v882]))))))
                continue;
            yield return (((ArrayItems[v882])));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptNullRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v885;
        throw new System.InvalidOperationException("Invalid null object");
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptArrayExceptEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v886;
        if (ArrayItems == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v887;
        HashSet<int> v888;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v889;
        HashSet<int> v890;
        v889 = EnumerableItems2.GetEnumerator();
        v890 = new HashSet<int>();
        try
        {
            while (v889.MoveNext())
                v890.Add((v889.Current));
        }
        finally
        {
            v889.Dispose();
        }

        v888 = new HashSet<int>();
        v887 = (0);
        for (; v887 < (ArrayItems.Length); v887 += 1)
            v888.Add((ArrayItems[v887]));
        v886 = (0);
        for (; v886 < (ArrayItems.Length); v886 += 1)
        {
            if (!(v888.Add((((ArrayItems[v886]))))))
                continue;
            if (!(v890.Add((((((ArrayItems[v886]))))))))
                continue;
            yield return (((((ArrayItems[v886])))));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptArrayExceptEnumerable2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v891;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v892;
        HashSet<int> v893;
        v892 = EnumerableItems2.GetEnumerator();
        v893 = new HashSet<int>();
        try
        {
            while (v892.MoveNext())
                v893.Add((v892.Current));
        }
        finally
        {
            v892.Dispose();
        }

        v891 = (0);
        for (; v891 < (ArrayItems.Length); v891 += 1)
        {
            if (!(v893.Add((((ArrayItems[v891]))))))
                continue;
            yield return (((ArrayItems[v891])));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptArrayExceptEnumerable2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v894;
        if (ArrayExceptArrayExceptEnumerable2Rewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v895;
        HashSet<int> v896;
        v895 = ArrayExceptArrayExceptEnumerable2Rewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v896 = new HashSet<int>();
        try
        {
            while (v895.MoveNext())
                v896.Add((v895.Current));
        }
        finally
        {
            v895.Dispose();
        }

        v894 = (0);
        for (; v894 < (ArrayItems.Length); v894 += 1)
        {
            if (!(v896.Add((((ArrayItems[v894]))))))
                continue;
            yield return (((ArrayItems[v894])));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctExceptArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v897;
        HashSet<int> v898;
        v898 = new HashSet<int>();
        v897 = (0);
        for (; v897 < (ArrayItems.Length); v897 += 1)
        {
            if (!(v898.Add(((ArrayItems[v897])))))
                continue;
            yield return ((ArrayItems[v897]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctExceptArrayDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v899;
        HashSet<int> v900;
        if (ArrayDistinctExceptArrayDistinctRewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v901;
        HashSet<int> v902;
        v901 = ArrayDistinctExceptArrayDistinctRewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v902 = new HashSet<int>();
        try
        {
            while (v901.MoveNext())
                v902.Add((v901.Current));
        }
        finally
        {
            v901.Dispose();
        }

        v900 = new HashSet<int>();
        v899 = (0);
        for (; v899 < (ArrayItems.Length); v899 += 1)
        {
            if (!(v900.Add(((ArrayItems[v899])))))
                continue;
            if (!(v902.Add(((((ArrayItems[v899])))))))
                continue;
            yield return ((((ArrayItems[v899]))));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctExceptArrayDistinctDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v903;
        HashSet<int> v904;
        v904 = new HashSet<int>();
        v903 = (0);
        for (; v903 < (ArrayItems.Length); v903 += 1)
        {
            if (!(v904.Add(((ArrayItems[v903])))))
                continue;
            yield return ((ArrayItems[v903]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctExceptArrayDistinctDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v905;
        HashSet<int> v906;
        if (ArrayDistinctExceptArrayDistinctDistinctRewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v907;
        HashSet<int> v908;
        HashSet<int> v909;
        v907 = ArrayDistinctExceptArrayDistinctDistinctRewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v908 = new HashSet<int>();
        try
        {
            while (v907.MoveNext())
                v908.Add((v907.Current));
        }
        finally
        {
            v907.Dispose();
        }

        v906 = new HashSet<int>();
        v909 = new HashSet<int>();
        v905 = (0);
        for (; v905 < (ArrayItems.Length); v905 += 1)
        {
            if (!(v906.Add(((ArrayItems[v905])))))
                continue;
            if (!(v908.Add(((((ArrayItems[v905])))))))
                continue;
            if (!(v909.Add((((((ArrayItems[v905]))))))))
                continue;
            yield return (((((ArrayItems[v905])))));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctExceptArrayDistinctDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v910;
        HashSet<int> v911;
        v911 = new HashSet<int>(EqualityComparer<int>.Default);
        v910 = (0);
        for (; v910 < (ArrayItems.Length); v910 += 1)
        {
            if (!(v911.Add(((ArrayItems[v910])))))
                continue;
            yield return ((ArrayItems[v910]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctExceptArrayDistinctDistinct2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v912;
        HashSet<int> v913;
        if (ArrayDistinctExceptArrayDistinctDistinct2Rewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v914;
        HashSet<int> v915;
        HashSet<int> v916;
        v914 = ArrayDistinctExceptArrayDistinctDistinct2Rewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v915 = new HashSet<int>();
        try
        {
            while (v914.MoveNext())
                v915.Add((v914.Current));
        }
        finally
        {
            v914.Dispose();
        }

        v913 = new HashSet<int>(EqualityComparer<int>.Default);
        v916 = new HashSet<int>(EqualityComparer<int>.Default);
        v912 = (0);
        for (; v912 < (ArrayItems.Length); v912 += 1)
        {
            if (!(v913.Add(((ArrayItems[v912])))))
                continue;
            if (!(v915.Add(((((ArrayItems[v912])))))))
                continue;
            if (!(v916.Add((((((ArrayItems[v912]))))))))
                continue;
            yield return (((((ArrayItems[v912])))));
        }

        yield break;
    }
}}