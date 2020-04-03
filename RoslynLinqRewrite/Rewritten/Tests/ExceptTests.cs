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
        int v542;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v543;
        HashSet<int> v544;
        v544 = new HashSet<int>();
        v543 = 0;
        for (; v543 < ArrayItems2.Length; v543++)
            v544.Add(ArrayItems2[v543]);
        v542 = 0;
        for (; v542 < ArrayItems.Length; v542++)
        {
            if (!(v544.Add(ArrayItems[v542])))
                continue;
            yield return ArrayItems[v542];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v545;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v546;
        HashSet<int> v547;
        v546 = SimpleListItems2.GetEnumerator();
        v547 = new HashSet<int>();
        try
        {
            while (v546.MoveNext())
                v547.Add(v546.Current);
        }
        finally
        {
            v546.Dispose();
        }

        v545 = 0;
        for (; v545 < ArrayItems.Length; v545++)
        {
            if (!(v547.Add(ArrayItems[v545])))
                continue;
            yield return ArrayItems[v545];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v548;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v549;
        HashSet<int> v550;
        v549 = EnumerableItems2.GetEnumerator();
        v550 = new HashSet<int>();
        try
        {
            while (v549.MoveNext())
                v550.Add(v549.Current);
        }
        finally
        {
            v549.Dispose();
        }

        v548 = 0;
        for (; v548 < ArrayItems.Length; v548++)
        {
            if (!(v550.Add(ArrayItems[v548])))
                continue;
            yield return ArrayItems[v548];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v551;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v552;
        HashSet<int> v553;
        v552 = MethodEnumerable2().GetEnumerator();
        v553 = new HashSet<int>();
        try
        {
            while (v552.MoveNext())
                v553.Add(v552.Current);
        }
        finally
        {
            v552.Dispose();
        }

        v551 = 0;
        for (; v551 < ArrayItems.Length; v551++)
        {
            if (!(v553.Add(ArrayItems[v551])))
                continue;
            yield return ArrayItems[v551];
        }
    }

    System.Collections.Generic.IEnumerable<int> SimpleListExceptArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v554;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v555;
        HashSet<int> v556;
        int v557;
        v554 = SimpleListItems.GetEnumerator();
        v556 = new HashSet<int>();
        v555 = 0;
        for (; v555 < ArrayItems2.Length; v555++)
            v556.Add(ArrayItems2[v555]);
        try
        {
            while (v554.MoveNext())
            {
                v557 = v554.Current;
                if (!(v556.Add(v557)))
                    continue;
                yield return v557;
            }
        }
        finally
        {
            v554.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> SimpleListExceptSimpleListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v558;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v559;
        HashSet<int> v560;
        int v561;
        v559 = SimpleListItems2.GetEnumerator();
        v558 = SimpleListItems.GetEnumerator();
        v560 = new HashSet<int>();
        try
        {
            while (v559.MoveNext())
                v560.Add(v559.Current);
        }
        finally
        {
            v559.Dispose();
        }

        try
        {
            while (v558.MoveNext())
            {
                v561 = v558.Current;
                if (!(v560.Add(v561)))
                    continue;
                yield return v561;
            }
        }
        finally
        {
            v558.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> SimpleListExceptEnumerableRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v562;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v563;
        HashSet<int> v564;
        int v565;
        v563 = EnumerableItems2.GetEnumerator();
        v562 = SimpleListItems.GetEnumerator();
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

        try
        {
            while (v562.MoveNext())
            {
                v565 = v562.Current;
                if (!(v564.Add(v565)))
                    continue;
                yield return v565;
            }
        }
        finally
        {
            v562.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> SimpleListExceptMethodRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v566;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v567;
        HashSet<int> v568;
        int v569;
        v567 = MethodEnumerable2().GetEnumerator();
        v566 = SimpleListItems.GetEnumerator();
        v568 = new HashSet<int>();
        try
        {
            while (v567.MoveNext())
                v568.Add(v567.Current);
        }
        finally
        {
            v567.Dispose();
        }

        try
        {
            while (v566.MoveNext())
            {
                v569 = v566.Current;
                if (!(v568.Add(v569)))
                    continue;
                yield return v569;
            }
        }
        finally
        {
            v566.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableExceptArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v570;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v571;
        HashSet<int> v572;
        int v573;
        v570 = EnumerableItems.GetEnumerator();
        v572 = new HashSet<int>();
        v571 = 0;
        for (; v571 < ArrayItems2.Length; v571++)
            v572.Add(ArrayItems2[v571]);
        try
        {
            while (v570.MoveNext())
            {
                v573 = v570.Current;
                if (!(v572.Add(v573)))
                    continue;
                yield return v573;
            }
        }
        finally
        {
            v570.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableExceptSimpleListRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v574;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v575;
        HashSet<int> v576;
        int v577;
        v575 = SimpleListItems2.GetEnumerator();
        v574 = EnumerableItems.GetEnumerator();
        v576 = new HashSet<int>();
        try
        {
            while (v575.MoveNext())
                v576.Add(v575.Current);
        }
        finally
        {
            v575.Dispose();
        }

        try
        {
            while (v574.MoveNext())
            {
                v577 = v574.Current;
                if (!(v576.Add(v577)))
                    continue;
                yield return v577;
            }
        }
        finally
        {
            v574.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableExceptEnumerableRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v578;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v579;
        HashSet<int> v580;
        int v581;
        v579 = EnumerableItems2.GetEnumerator();
        v578 = EnumerableItems.GetEnumerator();
        v580 = new HashSet<int>();
        try
        {
            while (v579.MoveNext())
                v580.Add(v579.Current);
        }
        finally
        {
            v579.Dispose();
        }

        try
        {
            while (v578.MoveNext())
            {
                v581 = v578.Current;
                if (!(v580.Add(v581)))
                    continue;
                yield return v581;
            }
        }
        finally
        {
            v578.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableExceptMethodRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v582;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v583;
        HashSet<int> v584;
        int v585;
        v583 = MethodEnumerable2().GetEnumerator();
        v582 = EnumerableItems.GetEnumerator();
        v584 = new HashSet<int>();
        try
        {
            while (v583.MoveNext())
                v584.Add(v583.Current);
        }
        finally
        {
            v583.Dispose();
        }

        try
        {
            while (v582.MoveNext())
            {
                v585 = v582.Current;
                if (!(v584.Add(v585)))
                    continue;
                yield return v585;
            }
        }
        finally
        {
            v582.Dispose();
        }
    }

    int[] ArrayExceptArrayToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v586;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v587;
        HashSet<int> v588;
        int v589;
        int v590;
        int v591;
        int[] v592;
        v588 = new HashSet<int>();
        v587 = 0;
        for (; v587 < ArrayItems2.Length; v587++)
            v588.Add(ArrayItems2[v587]);
        v589 = 0;
        v590 = (LinqRewrite.Core.IntExtensions.Log2((uint)(ArrayItems2.Length + ArrayItems.Length)) - 3);
        v590 -= (v590 % 2);
        v591 = 8;
        v592 = new int[8];
        v586 = 0;
        for (; v586 < ArrayItems.Length; v586++)
        {
            if (!(v588.Add(ArrayItems[v586])))
                continue;
            if (v589 >= v591)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems2.Length + ArrayItems.Length), ref v592, ref v590, out v591);
            v592[v589] = ArrayItems[v586];
            v589++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v592, v589);
    }

    int[] ArrayExceptSimpleListToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v593;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v594;
        HashSet<int> v595;
        int v596;
        int v597;
        int[] v598;
        v594 = SimpleListItems2.GetEnumerator();
        v595 = new HashSet<int>();
        try
        {
            while (v594.MoveNext())
                v595.Add(v594.Current);
        }
        finally
        {
            v594.Dispose();
        }

        v596 = 0;
        v597 = 8;
        v598 = new int[8];
        v593 = 0;
        for (; v593 < ArrayItems.Length; v593++)
        {
            if (!(v595.Add(ArrayItems[v593])))
                continue;
            if (v596 >= v597)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v598, ref v597);
            v598[v596] = ArrayItems[v593];
            v596++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v598, v596);
    }

    int[] ArrayExceptEnumerableToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v599;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v600;
        HashSet<int> v601;
        int v602;
        int v603;
        int[] v604;
        v600 = EnumerableItems2.GetEnumerator();
        v601 = new HashSet<int>();
        try
        {
            while (v600.MoveNext())
                v601.Add(v600.Current);
        }
        finally
        {
            v600.Dispose();
        }

        v602 = 0;
        v603 = 8;
        v604 = new int[8];
        v599 = 0;
        for (; v599 < ArrayItems.Length; v599++)
        {
            if (!(v601.Add(ArrayItems[v599])))
                continue;
            if (v602 >= v603)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v604, ref v603);
            v604[v602] = ArrayItems[v599];
            v602++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v604, v602);
    }

    int[] SimpleListExceptArrayToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v605;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v606;
        HashSet<int> v607;
        int v608;
        int v609;
        int v610;
        int[] v611;
        v605 = SimpleListItems.GetEnumerator();
        v607 = new HashSet<int>();
        v606 = 0;
        for (; v606 < ArrayItems2.Length; v606++)
            v607.Add(ArrayItems2[v606]);
        v609 = 0;
        v610 = 8;
        v611 = new int[8];
        try
        {
            while (v605.MoveNext())
            {
                v608 = v605.Current;
                if (!(v607.Add(v608)))
                    continue;
                if (v609 >= v610)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v611, ref v610);
                v611[v609] = v608;
                v609++;
            }
        }
        finally
        {
            v605.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v611, v609);
    }

    int[] SimpleListExceptSimpleListToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v612;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v613;
        HashSet<int> v614;
        int v615;
        int v616;
        int v617;
        int[] v618;
        v613 = SimpleListItems2.GetEnumerator();
        v612 = SimpleListItems.GetEnumerator();
        v614 = new HashSet<int>();
        try
        {
            while (v613.MoveNext())
                v614.Add(v613.Current);
        }
        finally
        {
            v613.Dispose();
        }

        v616 = 0;
        v617 = 8;
        v618 = new int[8];
        try
        {
            while (v612.MoveNext())
            {
                v615 = v612.Current;
                if (!(v614.Add(v615)))
                    continue;
                if (v616 >= v617)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v618, ref v617);
                v618[v616] = v615;
                v616++;
            }
        }
        finally
        {
            v612.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v618, v616);
    }

    int[] SimpleListExceptEnumerableToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v619;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v620;
        HashSet<int> v621;
        int v622;
        int v623;
        int v624;
        int[] v625;
        v620 = EnumerableItems2.GetEnumerator();
        v619 = SimpleListItems.GetEnumerator();
        v621 = new HashSet<int>();
        try
        {
            while (v620.MoveNext())
                v621.Add(v620.Current);
        }
        finally
        {
            v620.Dispose();
        }

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

    int[] EnumerableExceptArrayToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v626;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v627;
        HashSet<int> v628;
        int v629;
        int v630;
        int v631;
        int[] v632;
        v626 = EnumerableItems.GetEnumerator();
        v628 = new HashSet<int>();
        v627 = 0;
        for (; v627 < ArrayItems2.Length; v627++)
            v628.Add(ArrayItems2[v627]);
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

    int[] EnumerableExceptSimpleListToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v633;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v634;
        HashSet<int> v635;
        int v636;
        int v637;
        int v638;
        int[] v639;
        v634 = SimpleListItems2.GetEnumerator();
        v633 = EnumerableItems.GetEnumerator();
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

    int[] EnumerableExceptEnumerableToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v640;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v641;
        HashSet<int> v642;
        int v643;
        int v644;
        int v645;
        int[] v646;
        v641 = EnumerableItems2.GetEnumerator();
        v640 = EnumerableItems.GetEnumerator();
        v642 = new HashSet<int>();
        try
        {
            while (v641.MoveNext())
                v642.Add(v641.Current);
        }
        finally
        {
            v641.Dispose();
        }

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

    System.Collections.Generic.IEnumerable<int> ArraySelectExceptArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v647;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v648;
        HashSet<int> v649;
        int v650;
        v649 = new HashSet<int>();
        v648 = 0;
        for (; v648 < ArrayItems2.Length; v648++)
            v649.Add(ArrayItems2[v648]);
        v647 = 0;
        for (; v647 < ArrayItems.Length; v647++)
        {
            v650 = (ArrayItems[v647] + 50);
            if (!(v649.Add(v650)))
                continue;
            yield return v650;
        }
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectExceptArraySelectRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v651;
        v651 = 0;
        for (; v651 < ArrayItems2.Length; v651++)
            yield return (ArrayItems2[v651] + 50);
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectExceptArraySelectRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v652;
        if (ArraySelectExceptArraySelectRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v653;
        HashSet<int> v654;
        int v655;
        v653 = ArraySelectExceptArraySelectRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v654 = new HashSet<int>();
        try
        {
            while (v653.MoveNext())
                v654.Add(v653.Current);
        }
        finally
        {
            v653.Dispose();
        }

        v652 = 0;
        for (; v652 < ArrayItems.Length; v652++)
        {
            v655 = (ArrayItems[v652] + 50);
            if (!(v654.Add(v655)))
                continue;
            yield return v655;
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereExceptArrayWhereRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v656;
        v656 = 0;
        for (; v656 < ArrayItems2.Length; v656++)
        {
            if (!((ArrayItems2[v656] > 50)))
                continue;
            yield return ArrayItems2[v656];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereExceptArrayWhereRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v657;
        if (ArrayWhereExceptArrayWhereRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v658;
        HashSet<int> v659;
        v658 = ArrayWhereExceptArrayWhereRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v659 = new HashSet<int>();
        try
        {
            while (v658.MoveNext())
                v659.Add(v658.Current);
        }
        finally
        {
            v658.Dispose();
        }

        v657 = 0;
        for (; v657 < ArrayItems.Length; v657++)
        {
            if (!((ArrayItems[v657] > 50)))
                continue;
            if (!(v659.Add(ArrayItems[v657])))
                continue;
            yield return ArrayItems[v657];
        }
    }

    int ArrayExceptArrayCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v660;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v661;
        HashSet<int> v662;
        int v663;
        v662 = new HashSet<int>();
        v661 = 0;
        for (; v661 < ArrayItems2.Length; v661++)
            v662.Add(ArrayItems2[v661]);
        v663 = 0;
        v660 = 0;
        for (; v660 < ArrayItems.Length; v660++)
        {
            if (!(v662.Add(ArrayItems[v660])))
                continue;
            v663++;
        }

        return v663;
    }

    int ArrayExceptArrayCount2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v664;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v665;
        HashSet<int> v666;
        int v667;
        v666 = new HashSet<int>();
        v665 = 0;
        for (; v665 < ArrayItems2.Length; v665++)
            v666.Add(ArrayItems2[v665]);
        v667 = 0;
        v664 = 0;
        for (; v664 < ArrayItems.Length; v664++)
        {
            if (!(v666.Add(ArrayItems[v664])))
                continue;
            if (!((ArrayItems[v664] > 70)))
                continue;
            v667++;
        }

        return v667;
    }

    int ArrayExceptArraySumRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v668;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v669;
        HashSet<int> v670;
        int v671;
        v670 = new HashSet<int>();
        v669 = 0;
        for (; v669 < ArrayItems2.Length; v669++)
            v670.Add(ArrayItems2[v669]);
        v671 = 0;
        v668 = 0;
        for (; v668 < ArrayItems.Length; v668++)
        {
            if (!(v670.Add(ArrayItems[v668])))
                continue;
            v671 += ArrayItems[v668];
        }

        return v671;
    }

    int ArrayExceptArraySum2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v672;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v673;
        HashSet<int> v674;
        int v675;
        int v676;
        v674 = new HashSet<int>();
        v673 = 0;
        for (; v673 < ArrayItems2.Length; v673++)
            v674.Add(ArrayItems2[v673]);
        v675 = 0;
        v672 = 0;
        for (; v672 < ArrayItems.Length; v672++)
        {
            if (!(v674.Add(ArrayItems[v672])))
                continue;
            v676 = (ArrayItems[v672] + 10);
            v675 += v676;
        }

        return v675;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v677;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v678;
        HashSet<int> v679;
        HashSet<int> v680;
        v679 = new HashSet<int>();
        v678 = 0;
        for (; v678 < ArrayItems2.Length; v678++)
            v679.Add(ArrayItems2[v678]);
        v680 = new HashSet<int>();
        v677 = 0;
        for (; v677 < ArrayItems.Length; v677++)
        {
            if (!(v679.Add(ArrayItems[v677])))
                continue;
            if (!(v680.Add(ArrayItems[v677])))
                continue;
            yield return ArrayItems[v677];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptArrayDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v681;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v682;
        HashSet<int> v683;
        HashSet<int> v684;
        v683 = new HashSet<int>();
        v682 = 0;
        for (; v682 < ArrayItems2.Length; v682++)
            v683.Add(ArrayItems2[v682]);
        v684 = new HashSet<int>(EqualityComparer<int>.Default);
        v681 = 0;
        for (; v681 < ArrayItems.Length; v681++)
        {
            if (!(v683.Add(ArrayItems[v681])))
                continue;
            if (!(v684.Add(ArrayItems[v681])))
                continue;
            yield return ArrayItems[v681];
        }
    }

    int ArrayExceptArrayElementAtRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v685;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v686;
        HashSet<int> v687;
        int v688;
        v687 = new HashSet<int>();
        v686 = 0;
        for (; v686 < ArrayItems2.Length; v686++)
            v687.Add(ArrayItems2[v686]);
        v688 = 0;
        v685 = 0;
        for (; v685 < ArrayItems.Length; v685++)
        {
            if (!(v687.Add(ArrayItems[v685])))
                continue;
            if (v688 == 45)
                return ArrayItems[v685];
            v688++;
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArrayExceptArrayElementAtOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v689;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v690;
        HashSet<int> v691;
        int v692;
        v691 = new HashSet<int>();
        v690 = 0;
        for (; v690 < ArrayItems2.Length; v690++)
            v691.Add(ArrayItems2[v690]);
        v692 = 0;
        v689 = 0;
        for (; v689 < ArrayItems.Length; v689++)
        {
            if (!(v691.Add(ArrayItems[v689])))
                continue;
            if (v692 == 45)
                return ArrayItems[v689];
            v692++;
        }

        return default(int);
    }

    int ArrayExceptArrayFirstRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v693;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v694;
        HashSet<int> v695;
        v695 = new HashSet<int>();
        v694 = 0;
        for (; v694 < ArrayItems2.Length; v694++)
            v695.Add(ArrayItems2[v694]);
        v693 = 0;
        for (; v693 < ArrayItems.Length; v693++)
        {
            if (!(v695.Add(ArrayItems[v693])))
                continue;
            return ArrayItems[v693];
        }

        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int ArrayExceptArrayFirstOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v696;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v697;
        HashSet<int> v698;
        v698 = new HashSet<int>();
        v697 = 0;
        for (; v697 < ArrayItems2.Length; v697++)
            v698.Add(ArrayItems2[v697]);
        v696 = 0;
        for (; v696 < ArrayItems.Length; v696++)
        {
            if (!(v698.Add(ArrayItems[v696])))
                continue;
            return ArrayItems[v696];
        }

        return default(int);
    }

    int ArrayExceptArrayLastRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v699;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v700;
        HashSet<int> v701;
        int? v702;
        v701 = new HashSet<int>();
        v700 = 0;
        for (; v700 < ArrayItems2.Length; v700++)
            v701.Add(ArrayItems2[v700]);
        v702 = null;
        v699 = 0;
        for (; v699 < ArrayItems.Length; v699++)
        {
            if (!(v701.Add(ArrayItems[v699])))
                continue;
            v702 = ArrayItems[v699];
        }

        if (v702 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v702;
    }

    int ArrayExceptArrayLastOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v703;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v704;
        HashSet<int> v705;
        int? v706;
        v705 = new HashSet<int>();
        v704 = 0;
        for (; v704 < ArrayItems2.Length; v704++)
            v705.Add(ArrayItems2[v704]);
        v706 = null;
        v703 = 0;
        for (; v703 < ArrayItems.Length; v703++)
        {
            if (!(v705.Add(ArrayItems[v703])))
                continue;
            v706 = ArrayItems[v703];
        }

        if (v706 == null)
            return default(int);
        else
            return (int)v706;
    }

    int ArrayExceptArraySingleRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v707;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v708;
        HashSet<int> v709;
        int? v710;
        v709 = new HashSet<int>();
        v708 = 0;
        for (; v708 < ArrayItems2.Length; v708++)
            v709.Add(ArrayItems2[v708]);
        v710 = null;
        v707 = 0;
        for (; v707 < ArrayItems.Length; v707++)
        {
            if (!(v709.Add(ArrayItems[v707])))
                continue;
            if (v710 == null)
                v710 = ArrayItems[v707];
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v710 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v710;
    }

    int ArrayExceptArraySingle2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v711;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v712;
        HashSet<int> v713;
        int? v714;
        v713 = new HashSet<int>();
        v712 = 0;
        for (; v712 < ArrayItems2.Length; v712++)
            v713.Add(ArrayItems2[v712]);
        v714 = null;
        v711 = 0;
        for (; v711 < ArrayItems.Length; v711++)
        {
            if (!(v713.Add(ArrayItems[v711])))
                continue;
            if ((ArrayItems[v711] == 76))
                if (v714 == null)
                    v714 = ArrayItems[v711];
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v714 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v714;
    }

    int ArrayExceptArraySingleOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v715;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v716;
        HashSet<int> v717;
        int? v718;
        v717 = new HashSet<int>();
        v716 = 0;
        for (; v716 < ArrayItems2.Length; v716++)
            v717.Add(ArrayItems2[v716]);
        v718 = null;
        v715 = 0;
        for (; v715 < ArrayItems.Length; v715++)
        {
            if (!(v717.Add(ArrayItems[v715])))
                continue;
            if (v718 == null)
                v718 = ArrayItems[v715];
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v718 == null)
            return default(int);
        else
            return (int)v718;
    }

    int ArrayExceptArrayMinRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v719;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v720;
        HashSet<int> v721;
        int v722;
        bool v723;
        v721 = new HashSet<int>();
        v720 = 0;
        for (; v720 < ArrayItems2.Length; v720++)
            v721.Add(ArrayItems2[v720]);
        v722 = 2147483647;
        v723 = false;
        v719 = 0;
        for (; v719 < ArrayItems.Length; v719++)
        {
            if (!(v721.Add(ArrayItems[v719])))
                continue;
            if (ArrayItems[v719] >= v722)
                continue;
            v722 = ArrayItems[v719];
            v723 = true;
        }

        if (!(v723))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v722;
    }

    decimal ArrayExceptArrayMin2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v724;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v725;
        HashSet<int> v726;
        decimal v727;
        bool v728;
        decimal v729;
        v726 = new HashSet<int>();
        v725 = 0;
        for (; v725 < ArrayItems2.Length; v725++)
            v726.Add(ArrayItems2[v725]);
        v727 = 79228162514264337593543950335M;
        v728 = false;
        v724 = 0;
        for (; v724 < ArrayItems.Length; v724++)
        {
            if (!(v726.Add(ArrayItems[v724])))
                continue;
            v729 = (ArrayItems[v724] + 2m);
            if (v729 >= v727)
                continue;
            v727 = v729;
            v728 = true;
        }

        if (!(v728))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v727;
    }

    int ArrayExceptArrayMaxRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v730;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v731;
        HashSet<int> v732;
        int v733;
        bool v734;
        v732 = new HashSet<int>();
        v731 = 0;
        for (; v731 < ArrayItems2.Length; v731++)
            v732.Add(ArrayItems2[v731]);
        v733 = -2147483648;
        v734 = false;
        v730 = 0;
        for (; v730 < ArrayItems.Length; v730++)
        {
            if (!(v732.Add(ArrayItems[v730])))
                continue;
            if (ArrayItems[v730] <= v733)
                continue;
            v733 = ArrayItems[v730];
            v734 = true;
        }

        if (!(v734))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v733;
    }

    decimal ArrayExceptArrayMax2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v735;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v736;
        HashSet<int> v737;
        decimal v738;
        bool v739;
        decimal v740;
        v737 = new HashSet<int>();
        v736 = 0;
        for (; v736 < ArrayItems2.Length; v736++)
            v737.Add(ArrayItems2[v736]);
        v738 = -79228162514264337593543950335M;
        v739 = false;
        v735 = 0;
        for (; v735 < ArrayItems.Length; v735++)
        {
            if (!(v737.Add(ArrayItems[v735])))
                continue;
            v740 = (ArrayItems[v735] + 2m);
            if (v740 <= v738)
                continue;
            v738 = v740;
            v739 = true;
        }

        if (!(v739))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v738;
    }

    long ArrayExceptArrayLongCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v741;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v742;
        HashSet<int> v743;
        long v744;
        v743 = new HashSet<int>();
        v742 = 0;
        for (; v742 < ArrayItems2.Length; v742++)
            v743.Add(ArrayItems2[v742]);
        v744 = 0;
        v741 = 0;
        for (; v741 < ArrayItems.Length; v741++)
        {
            if (!(v743.Add(ArrayItems[v741])))
                continue;
            v744++;
        }

        return v744;
    }

    long ArrayExceptArrayLongCount2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v745;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v746;
        HashSet<int> v747;
        long v748;
        v747 = new HashSet<int>();
        v746 = 0;
        for (; v746 < ArrayItems2.Length; v746++)
            v747.Add(ArrayItems2[v746]);
        v748 = 0;
        v745 = 0;
        for (; v745 < ArrayItems.Length; v745++)
        {
            if (!(v747.Add(ArrayItems[v745])))
                continue;
            if (!((ArrayItems[v745] > 50)))
                continue;
            v748++;
        }

        return v748;
    }

    bool ArrayExceptArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v749;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v750;
        HashSet<int> v751;
        v751 = new HashSet<int>();
        v750 = 0;
        for (; v750 < ArrayItems2.Length; v750++)
            v751.Add(ArrayItems2[v750]);
        v749 = 0;
        for (; v749 < ArrayItems.Length; v749++)
        {
            if (!(v751.Add(ArrayItems[v749])))
                continue;
            if (ArrayItems[v749] == 56)
                return true;
        }

        return false;
    }

    double ArrayExceptArrayAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v752;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v753;
        HashSet<int> v754;
        double v755;
        int v756;
        v754 = new HashSet<int>();
        v753 = 0;
        for (; v753 < ArrayItems2.Length; v753++)
            v754.Add(ArrayItems2[v753]);
        v755 = 0;
        v756 = 0;
        v752 = 0;
        for (; v752 < ArrayItems.Length; v752++)
        {
            if (!(v754.Add(ArrayItems[v752])))
                continue;
            v755 += ArrayItems[v752];
            v756++;
        }

        if (v756 == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v755 / v756);
    }

    double ArrayExceptArrayAverage2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v757;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v758;
        HashSet<int> v759;
        double v760;
        int v761;
        v759 = new HashSet<int>();
        v758 = 0;
        for (; v758 < ArrayItems2.Length; v758++)
            v759.Add(ArrayItems2[v758]);
        v760 = 0;
        v761 = 0;
        v757 = 0;
        for (; v757 < ArrayItems.Length; v757++)
        {
            if (!(v759.Add(ArrayItems[v757])))
                continue;
            v760 += (ArrayItems[v757] + 10);
            v761++;
        }

        if (v761 == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v760 / v761);
    }

    bool ArrayExceptArrayContains2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v762;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v763;
        HashSet<int> v764;
        System.Collections.Generic.EqualityComparer<int> v765;
        v764 = new HashSet<int>();
        v763 = 0;
        for (; v763 < ArrayItems2.Length; v763++)
            v764.Add(ArrayItems2[v763]);
        v765 = EqualityComparer<int>.Default;
        v762 = 0;
        for (; v762 < ArrayItems.Length; v762++)
        {
            if (!(v764.Add(ArrayItems[v762])))
                continue;
            if (v765.Equals(ArrayItems[v762], 56))
                return true;
        }

        return false;
    }

    System.Collections.Generic.IEnumerable<int> SelectWhereArrayExceptSelectWhereArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v766;
        int v767;
        v766 = 0;
        for (; v766 < ArrayItems2.Length; v766++)
        {
            v767 = (ArrayItems2[v766] + 10);
            if (!((v767 > 80)))
                continue;
            yield return v767;
        }
    }

    bool SelectWhereArrayExceptSelectWhereArrayContainsRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v768;
        int v769;
        if (SelectWhereArrayExceptSelectWhereArrayContainsRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v770;
        HashSet<int> v771;
        v770 = SelectWhereArrayExceptSelectWhereArrayContainsRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v771 = new HashSet<int>();
        try
        {
            while (v770.MoveNext())
                v771.Add(v770.Current);
        }
        finally
        {
            v770.Dispose();
        }

        v768 = 0;
        for (; v768 < ArrayItems.Length; v768++)
        {
            v769 = (ArrayItems[v768] + 10);
            if (!((v769 > 80)))
                continue;
            if (!(v771.Add(v769)))
                continue;
            if (v769 == 112)
                return true;
        }

        return false;
    }

    System.Collections.Generic.IEnumerable<int> RangeExceptArrayRewritten_ProceduralLinq1()
    {
        int v772;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v773;
        HashSet<int> v774;
        int v775;
        v774 = new HashSet<int>();
        v773 = 0;
        for (; v773 < ArrayItems2.Length; v773++)
            v774.Add(ArrayItems2[v773]);
        v772 = 0;
        for (; v772 < 100; v772++)
        {
            v775 = (v772 + 20);
            if (!(v774.Add(v775)))
                continue;
            yield return v775;
        }
    }

    System.Collections.Generic.IEnumerable<int> RepeatExceptArrayRewritten_ProceduralLinq1()
    {
        int v776;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v777;
        HashSet<int> v778;
        v778 = new HashSet<int>();
        v777 = 0;
        for (; v777 < ArrayItems2.Length; v777++)
            v778.Add(ArrayItems2[v777]);
        v776 = 0;
        for (; v776 < 100; v776++)
        {
            if (!(v778.Add(20)))
                continue;
            yield return 20;
        }
    }

    System.Collections.Generic.IEnumerable<int> EmptyExceptArrayRewritten_ProceduralLinq1()
    {
        int v779;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v780;
        HashSet<int> v781;
        v781 = new HashSet<int>();
        v780 = 0;
        for (; v780 < ArrayItems2.Length; v780++)
            v781.Add(ArrayItems2[v780]);
        v779 = 0;
        for (; v779 < 0; v779++)
        {
            if (!(v781.Add(default(int))))
                continue;
            yield return default(int);
        }
    }

    System.Collections.Generic.IEnumerable<int> RangeEmpty2ArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v782;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v783;
        v783 = new HashSet<int>();
        v782 = 0;
        for (; v782 < ArrayItems2.Length; v782++)
            v783.Add(ArrayItems2[v782]);
        v782 = 0;
        for (; v782 < ArrayItems.Length; v782++)
        {
            if (!((false)))
                continue;
            if (!(v783.Add(ArrayItems[v782])))
                continue;
            yield return ArrayItems[v782];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptRangeRewritten_ProceduralLinq1()
    {
        int v784;
        v784 = 0;
        for (; v784 < 260; v784++)
            yield return (v784 + 70);
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptRangeRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v785;
        if (ArrayExceptRangeRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v786;
        HashSet<int> v787;
        v786 = ArrayExceptRangeRewritten_ProceduralLinq1().GetEnumerator();
        v787 = new HashSet<int>();
        try
        {
            while (v786.MoveNext())
                v787.Add(v786.Current);
        }
        finally
        {
            v786.Dispose();
        }

        v785 = 0;
        for (; v785 < ArrayItems.Length; v785++)
        {
            if (!(v787.Add(ArrayItems[v785])))
                continue;
            yield return ArrayItems[v785];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptRepeatRewritten_ProceduralLinq1()
    {
        int v788;
        v788 = 0;
        for (; v788 < 100; v788++)
            yield return 70;
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptRepeatRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v789;
        if (ArrayExceptRepeatRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v790;
        HashSet<int> v791;
        v790 = ArrayExceptRepeatRewritten_ProceduralLinq1().GetEnumerator();
        v791 = new HashSet<int>();
        try
        {
            while (v790.MoveNext())
                v791.Add(v790.Current);
        }
        finally
        {
            v790.Dispose();
        }

        v789 = 0;
        for (; v789 < ArrayItems.Length; v789++)
        {
            if (!(v791.Add(ArrayItems[v789])))
                continue;
            yield return ArrayItems[v789];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptEmptyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v792;
        if (Enumerable.Empty<int>() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v793;
        HashSet<int> v794;
        v793 = Enumerable.Empty<int>().GetEnumerator();
        v794 = new HashSet<int>();
        try
        {
            while (v793.MoveNext())
                v794.Add(v793.Current);
        }
        finally
        {
            v793.Dispose();
        }

        v792 = 0;
        for (; v792 < ArrayItems.Length; v792++)
        {
            if (!(v794.Add(ArrayItems[v792])))
                continue;
            yield return ArrayItems[v792];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptEmpty2Rewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v795;
        v795 = 0;
        for (; v795 < ArrayItems2.Length; v795++)
        {
            if (!((false)))
                continue;
            yield return ArrayItems2[v795];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptEmpty2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v796;
        if (ArrayExceptEmpty2Rewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v797;
        HashSet<int> v798;
        v797 = ArrayExceptEmpty2Rewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v798 = new HashSet<int>();
        try
        {
            while (v797.MoveNext())
                v798.Add(v797.Current);
        }
        finally
        {
            v797.Dispose();
        }

        v796 = 0;
        for (; v796 < ArrayItems.Length; v796++)
        {
            if (!(v798.Add(ArrayItems[v796])))
                continue;
            yield return ArrayItems[v796];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptAllRewritten_ProceduralLinq1()
    {
        int v799;
        v799 = 0;
        for (; v799 < 1000; v799++)
            yield return (v799 + 0);
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptAllRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v800;
        if (ArrayExceptAllRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v801;
        HashSet<int> v802;
        v801 = ArrayExceptAllRewritten_ProceduralLinq1().GetEnumerator();
        v802 = new HashSet<int>();
        try
        {
            while (v801.MoveNext())
                v802.Add(v801.Current);
        }
        finally
        {
            v801.Dispose();
        }

        v800 = 0;
        for (; v800 < ArrayItems.Length; v800++)
        {
            if (!(v802.Add(ArrayItems[v800])))
                continue;
            yield return ArrayItems[v800];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptNullRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v803;
        throw new System.InvalidOperationException("Invalid null object");
        v803 = 0;
        for (; v803 < ArrayItems.Length; v803++)
            yield return ArrayItems[v803];
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptArrayExceptEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v804;
        if (ArrayItems == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v805;
        HashSet<int> v806;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v807;
        HashSet<int> v808;
        v807 = EnumerableItems2.GetEnumerator();
        v808 = new HashSet<int>();
        try
        {
            while (v807.MoveNext())
                v808.Add(v807.Current);
        }
        finally
        {
            v807.Dispose();
        }

        v806 = new HashSet<int>();
        v805 = 0;
        for (; v805 < ArrayItems.Length; v805++)
            v806.Add(ArrayItems[v805]);
        v804 = 0;
        for (; v804 < ArrayItems.Length; v804++)
        {
            if (!(v806.Add(ArrayItems[v804])))
                continue;
            if (!(v808.Add(ArrayItems[v804])))
                continue;
            yield return ArrayItems[v804];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptArrayExceptEnumerable2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v809;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v810;
        HashSet<int> v811;
        v810 = EnumerableItems2.GetEnumerator();
        v811 = new HashSet<int>();
        try
        {
            while (v810.MoveNext())
                v811.Add(v810.Current);
        }
        finally
        {
            v810.Dispose();
        }

        v809 = 0;
        for (; v809 < ArrayItems.Length; v809++)
        {
            if (!(v811.Add(ArrayItems[v809])))
                continue;
            yield return ArrayItems[v809];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayExceptArrayExceptEnumerable2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v812;
        if (ArrayExceptArrayExceptEnumerable2Rewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v813;
        HashSet<int> v814;
        v813 = ArrayExceptArrayExceptEnumerable2Rewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v814 = new HashSet<int>();
        try
        {
            while (v813.MoveNext())
                v814.Add(v813.Current);
        }
        finally
        {
            v813.Dispose();
        }

        v812 = 0;
        for (; v812 < ArrayItems.Length; v812++)
        {
            if (!(v814.Add(ArrayItems[v812])))
                continue;
            yield return ArrayItems[v812];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctExceptArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v815;
        HashSet<int> v816;
        v816 = new HashSet<int>();
        v815 = 0;
        for (; v815 < ArrayItems.Length; v815++)
        {
            if (!(v816.Add(ArrayItems[v815])))
                continue;
            yield return ArrayItems[v815];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctExceptArrayDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v817;
        HashSet<int> v818;
        if (ArrayDistinctExceptArrayDistinctRewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v819;
        HashSet<int> v820;
        v819 = ArrayDistinctExceptArrayDistinctRewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v820 = new HashSet<int>();
        try
        {
            while (v819.MoveNext())
                v820.Add(v819.Current);
        }
        finally
        {
            v819.Dispose();
        }

        v818 = new HashSet<int>();
        v817 = 0;
        for (; v817 < ArrayItems.Length; v817++)
        {
            if (!(v818.Add(ArrayItems[v817])))
                continue;
            if (!(v820.Add(ArrayItems[v817])))
                continue;
            yield return ArrayItems[v817];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctExceptArrayDistinctDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v821;
        HashSet<int> v822;
        v822 = new HashSet<int>();
        v821 = 0;
        for (; v821 < ArrayItems.Length; v821++)
        {
            if (!(v822.Add(ArrayItems[v821])))
                continue;
            yield return ArrayItems[v821];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctExceptArrayDistinctDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v823;
        HashSet<int> v824;
        if (ArrayDistinctExceptArrayDistinctDistinctRewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v825;
        HashSet<int> v826;
        HashSet<int> v827;
        v825 = ArrayDistinctExceptArrayDistinctDistinctRewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v826 = new HashSet<int>();
        try
        {
            while (v825.MoveNext())
                v826.Add(v825.Current);
        }
        finally
        {
            v825.Dispose();
        }

        v824 = new HashSet<int>();
        v827 = new HashSet<int>();
        v823 = 0;
        for (; v823 < ArrayItems.Length; v823++)
        {
            if (!(v824.Add(ArrayItems[v823])))
                continue;
            if (!(v826.Add(ArrayItems[v823])))
                continue;
            if (!(v827.Add(ArrayItems[v823])))
                continue;
            yield return ArrayItems[v823];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctExceptArrayDistinctDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v828;
        HashSet<int> v829;
        v829 = new HashSet<int>(EqualityComparer<int>.Default);
        v828 = 0;
        for (; v828 < ArrayItems.Length; v828++)
        {
            if (!(v829.Add(ArrayItems[v828])))
                continue;
            yield return ArrayItems[v828];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctExceptArrayDistinctDistinct2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v830;
        HashSet<int> v831;
        if (ArrayDistinctExceptArrayDistinctDistinct2Rewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v832;
        HashSet<int> v833;
        HashSet<int> v834;
        v832 = ArrayDistinctExceptArrayDistinctDistinct2Rewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v833 = new HashSet<int>();
        try
        {
            while (v832.MoveNext())
                v833.Add(v832.Current);
        }
        finally
        {
            v832.Dispose();
        }

        v831 = new HashSet<int>(EqualityComparer<int>.Default);
        v834 = new HashSet<int>(EqualityComparer<int>.Default);
        v830 = 0;
        for (; v830 < ArrayItems.Length; v830++)
        {
            if (!(v831.Add(ArrayItems[v830])))
                continue;
            if (!(v833.Add(ArrayItems[v830])))
                continue;
            if (!(v834.Add(ArrayItems[v830])))
                continue;
            yield return ArrayItems[v830];
        }
    }
}}