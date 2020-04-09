using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class ConcatTests
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
        TestsExtensions.TestEquals(nameof(ArrayConcatArray), ArrayConcatArray, ArrayConcatArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatSimpleList), ArrayConcatSimpleList, ArrayConcatSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatEnumerable), ArrayConcatEnumerable, ArrayConcatEnumerableRewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatMethod), ArrayConcatMethod, ArrayConcatMethodRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListConcatArray), SimpleListConcatArray, SimpleListConcatArrayRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListConcatSimpleList), SimpleListConcatSimpleList, SimpleListConcatSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListConcatEnumerable), SimpleListConcatEnumerable, SimpleListConcatEnumerableRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListConcatMethod), SimpleListConcatMethod, SimpleListConcatMethodRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableConcatArray), EnumerableConcatArray, EnumerableConcatArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableConcatSimpleList), EnumerableConcatSimpleList, EnumerableConcatSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableConcatEnumerable), EnumerableConcatEnumerable, EnumerableConcatEnumerableRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableConcatMethod), EnumerableConcatMethod, EnumerableConcatMethodRewritten);
        TestsExtensions.TestEquals(nameof(MethodConcatArray), MethodConcatArray, MethodConcatArrayRewritten);
        TestsExtensions.TestEquals(nameof(MethodConcatSimpleList), MethodConcatSimpleList, MethodConcatSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(MethodConcatEnumerable), MethodConcatEnumerable, MethodConcatEnumerableRewritten);
        TestsExtensions.TestEquals(nameof(MethodConcatMethod), MethodConcatMethod, MethodConcatMethodRewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatArrayToArray), ArrayConcatArrayToArray, ArrayConcatArrayToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatSimpleListToArray), ArrayConcatSimpleListToArray, ArrayConcatSimpleListToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatEnumerableToArray), ArrayConcatEnumerableToArray, ArrayConcatEnumerableToArrayRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListConcatArrayToArray), SimpleListConcatArrayToArray, SimpleListConcatArrayToArrayRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListConcatSimpleListToArray), SimpleListConcatSimpleListToArray, SimpleListConcatSimpleListToArrayRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListConcatEnumerableToArray), SimpleListConcatEnumerableToArray, SimpleListConcatEnumerableToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableConcatArrayToArray), EnumerableConcatArrayToArray, EnumerableConcatArrayToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableConcatSimpleListToArray), EnumerableConcatSimpleListToArray, EnumerableConcatSimpleListToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableConcatEnumerableToArray), EnumerableConcatEnumerableToArray, EnumerableConcatEnumerableToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectConcatArray), ArraySelectConcatArray, ArraySelectConcatArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectConcatArraySelect), ArraySelectConcatArraySelect, ArraySelectConcatArraySelectRewritten);
        TestsExtensions.TestEquals(nameof(ArrayWhereConcatArrayWhere), ArrayWhereConcatArrayWhere, ArrayWhereConcatArrayWhereRewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatArrayCount), ArrayConcatArrayCount, ArrayConcatArrayCountRewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatArrayCount2), ArrayConcatArrayCount2, ArrayConcatArrayCount2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatArraySum), ArrayConcatArraySum, ArrayConcatArraySumRewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatArraySum2), ArrayConcatArraySum2, ArrayConcatArraySum2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatArrayDistinct), ArrayConcatArrayDistinct, ArrayConcatArrayDistinctRewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatArrayDistinct2), ArrayConcatArrayDistinct2, ArrayConcatArrayDistinct2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatArrayElementAt), ArrayConcatArrayElementAt, ArrayConcatArrayElementAtRewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatArrayElementAtOrDefault), ArrayConcatArrayElementAtOrDefault, ArrayConcatArrayElementAtOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatArrayFirst), ArrayConcatArrayFirst, ArrayConcatArrayFirstRewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatArrayFirstOrDefault), ArrayConcatArrayFirstOrDefault, ArrayConcatArrayFirstOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatArrayLast), ArrayConcatArrayLast, ArrayConcatArrayLastRewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatArrayLastOrDefault), ArrayConcatArrayLastOrDefault, ArrayConcatArrayLastOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatArraySingle), ArrayConcatArraySingle, ArrayConcatArraySingleRewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatArraySingle2), ArrayConcatArraySingle2, ArrayConcatArraySingle2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatArraySingleOrDefault), ArrayConcatArraySingleOrDefault, ArrayConcatArraySingleOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatArrayMin), ArrayConcatArrayMin, ArrayConcatArrayMinRewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatArrayMin2), ArrayConcatArrayMin2, ArrayConcatArrayMin2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatArrayMax), ArrayConcatArrayMax, ArrayConcatArrayMaxRewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatArrayMax2), ArrayConcatArrayMax2, ArrayConcatArrayMax2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatArrayLongCount), ArrayConcatArrayLongCount, ArrayConcatArrayLongCountRewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatArrayLongCount2), ArrayConcatArrayLongCount2, ArrayConcatArrayLongCount2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatArrayContains), ArrayConcatArrayContains, ArrayConcatArrayContainsRewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatArrayAverage), ArrayConcatArrayAverage, ArrayConcatArrayAverageRewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatArrayAverage2), ArrayConcatArrayAverage2, ArrayConcatArrayAverage2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatArrayContains2), ArrayConcatArrayContains2, ArrayConcatArrayContains2Rewritten);
        TestsExtensions.TestEquals(nameof(SelectWhereArrayConcatSelectWhereArrayContains), SelectWhereArrayConcatSelectWhereArrayContains, SelectWhereArrayConcatSelectWhereArrayContainsRewritten);
        TestsExtensions.TestEquals(nameof(RangeConcatArray), RangeConcatArray, RangeConcatArrayRewritten);
        TestsExtensions.TestEquals(nameof(RepeatConcatArray), RepeatConcatArray, RepeatConcatArrayRewritten);
        TestsExtensions.TestEquals(nameof(EmptyConcatArray), EmptyConcatArray, EmptyConcatArrayRewritten);
        TestsExtensions.TestEquals(nameof(RangeEmpty2Array), RangeEmpty2Array, RangeEmpty2ArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatRange), ArrayConcatRange, ArrayConcatRangeRewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatRepeat), ArrayConcatRepeat, ArrayConcatRepeatRewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatEmpty), ArrayConcatEmpty, ArrayConcatEmptyRewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatEmpty2), ArrayConcatEmpty2, ArrayConcatEmpty2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatAll), ArrayConcatAll, ArrayConcatAllRewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatNull), ArrayConcatNull, ArrayConcatNullRewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatArrayConcatEnumerable), ArrayConcatArrayConcatEnumerable, ArrayConcatArrayConcatEnumerableRewritten);
        TestsExtensions.TestEquals(nameof(ArrayConcatArrayConcatEnumerable2), ArrayConcatArrayConcatEnumerable2, ArrayConcatArrayConcatEnumerable2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayDistinctConcatArrayDistinct), ArrayDistinctConcatArrayDistinct, ArrayDistinctConcatArrayDistinctRewritten);
        TestsExtensions.TestEquals(nameof(ArrayDistinctConcatArrayDistinctDistinct), ArrayDistinctConcatArrayDistinctDistinct, ArrayDistinctConcatArrayDistinctDistinctRewritten);
        TestsExtensions.TestEquals(nameof(ArrayDistinctConcatArrayDistinctDistinct2), ArrayDistinctConcatArrayDistinctDistinct2, ArrayDistinctConcatArrayDistinctDistinct2Rewritten);
    }

    [NoRewrite]
    public IEnumerable<int> ArrayConcatArray()
    {
        return ArrayItems.Concat(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> ArrayConcatArrayRewritten()
    {
        return ArrayConcatArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayConcatSimpleList()
    {
        return ArrayItems.Concat(SimpleListItems2);
    } //EndMethod

    public IEnumerable<int> ArrayConcatSimpleListRewritten()
    {
        return ArrayConcatSimpleListRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayConcatEnumerable()
    {
        return ArrayItems.Concat(EnumerableItems2);
    } //EndMethod

    public IEnumerable<int> ArrayConcatEnumerableRewritten()
    {
        return ArrayConcatEnumerableRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayConcatMethod()
    {
        return ArrayItems.Concat(MethodEnumerable2());
    } //EndMethod

    public IEnumerable<int> ArrayConcatMethodRewritten()
    {
        return ArrayConcatMethodRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListConcatArray()
    {
        return SimpleListItems.Concat(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> SimpleListConcatArrayRewritten()
    {
        return SimpleListConcatArrayRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListConcatSimpleList()
    {
        return SimpleListItems.Concat(SimpleListItems2);
    } //EndMethod

    public IEnumerable<int> SimpleListConcatSimpleListRewritten()
    {
        return SimpleListConcatSimpleListRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListConcatEnumerable()
    {
        return SimpleListItems.Concat(EnumerableItems2);
    } //EndMethod

    public IEnumerable<int> SimpleListConcatEnumerableRewritten()
    {
        return SimpleListConcatEnumerableRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListConcatMethod()
    {
        return SimpleListItems.Concat(MethodEnumerable2());
    } //EndMethod

    public IEnumerable<int> SimpleListConcatMethodRewritten()
    {
        return SimpleListConcatMethodRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableConcatArray()
    {
        return EnumerableItems.Concat(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> EnumerableConcatArrayRewritten()
    {
        return EnumerableConcatArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableConcatSimpleList()
    {
        return EnumerableItems.Concat(SimpleListItems2);
    } //EndMethod

    public IEnumerable<int> EnumerableConcatSimpleListRewritten()
    {
        return EnumerableConcatSimpleListRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableConcatEnumerable()
    {
        return EnumerableItems.Concat(EnumerableItems2);
    } //EndMethod

    public IEnumerable<int> EnumerableConcatEnumerableRewritten()
    {
        return EnumerableConcatEnumerableRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableConcatMethod()
    {
        return EnumerableItems.Concat(MethodEnumerable2());
    } //EndMethod

    public IEnumerable<int> EnumerableConcatMethodRewritten()
    {
        return EnumerableConcatMethodRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> MethodConcatArray()
    {
        return MethodEnumerable().Concat(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> MethodConcatArrayRewritten()
    {
        return MethodEnumerable().Concat(ArrayItems2);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> MethodConcatSimpleList()
    {
        return MethodEnumerable().Concat(SimpleListItems2);
    } //EndMethod

    public IEnumerable<int> MethodConcatSimpleListRewritten()
    {
        return MethodEnumerable().Concat(SimpleListItems2);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> MethodConcatEnumerable()
    {
        return MethodEnumerable().Concat(EnumerableItems2);
    } //EndMethod

    public IEnumerable<int> MethodConcatEnumerableRewritten()
    {
        return MethodEnumerable().Concat(EnumerableItems2);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> MethodConcatMethod()
    {
        return MethodEnumerable().Concat(MethodEnumerable2());
    } //EndMethod

    public IEnumerable<int> MethodConcatMethodRewritten()
    {
        return MethodEnumerable().Concat(MethodEnumerable2());
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayConcatArrayToArray()
    {
        return ArrayItems.Concat(ArrayItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayConcatArrayToArrayRewritten()
    {
        return ArrayConcatArrayToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayConcatSimpleListToArray()
    {
        return ArrayItems.Concat(SimpleListItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayConcatSimpleListToArrayRewritten()
    {
        return ArrayConcatSimpleListToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayConcatEnumerableToArray()
    {
        return ArrayItems.Concat(EnumerableItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayConcatEnumerableToArrayRewritten()
    {
        return ArrayConcatEnumerableToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListConcatArrayToArray()
    {
        return SimpleListItems.Concat(ArrayItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> SimpleListConcatArrayToArrayRewritten()
    {
        return SimpleListConcatArrayToArrayRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListConcatSimpleListToArray()
    {
        return SimpleListItems.Concat(SimpleListItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> SimpleListConcatSimpleListToArrayRewritten()
    {
        return SimpleListConcatSimpleListToArrayRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListConcatEnumerableToArray()
    {
        return SimpleListItems.Concat(EnumerableItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> SimpleListConcatEnumerableToArrayRewritten()
    {
        return SimpleListConcatEnumerableToArrayRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableConcatArrayToArray()
    {
        return EnumerableItems.Concat(ArrayItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableConcatArrayToArrayRewritten()
    {
        return EnumerableConcatArrayToArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableConcatSimpleListToArray()
    {
        return EnumerableItems.Concat(SimpleListItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableConcatSimpleListToArrayRewritten()
    {
        return EnumerableConcatSimpleListToArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableConcatEnumerableToArray()
    {
        return EnumerableItems.Concat(EnumerableItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableConcatEnumerableToArrayRewritten()
    {
        return EnumerableConcatEnumerableToArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectConcatArray()
    {
        return ArrayItems.Select(x => x + 50).Concat(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> ArraySelectConcatArrayRewritten()
    {
        return ArraySelectConcatArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectConcatArraySelect()
    {
        return ArrayItems.Select(x => x + 50).Concat(ArrayItems2.Select(x => x + 50));
    } //EndMethod

    public IEnumerable<int> ArraySelectConcatArraySelectRewritten()
    {
        return ArraySelectConcatArraySelectRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayWhereConcatArrayWhere()
    {
        return ArrayItems.Where(x => x > 50).Concat(ArrayItems2.Where(x => x > 50));
    } //EndMethod

    public IEnumerable<int> ArrayWhereConcatArrayWhereRewritten()
    {
        return ArrayWhereConcatArrayWhereRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayConcatArrayCount()
    {
        return ArrayItems.Concat(ArrayItems2).Count();
    } //EndMethod

    public int ArrayConcatArrayCountRewritten()
    {
        return ArrayConcatArrayCountRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayConcatArrayCount2()
    {
        return ArrayItems.Concat(ArrayItems2).Count(x => x > 70);
    } //EndMethod

    public int ArrayConcatArrayCount2Rewritten()
    {
        return ArrayConcatArrayCount2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayConcatArraySum()
    {
        return ArrayItems.Concat(ArrayItems2).Sum();
    } //EndMethod

    public int ArrayConcatArraySumRewritten()
    {
        return ArrayConcatArraySumRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayConcatArraySum2()
    {
        return ArrayItems.Concat(ArrayItems2).Sum(x => x + 10);
    } //EndMethod

    public int ArrayConcatArraySum2Rewritten()
    {
        return ArrayConcatArraySum2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayConcatArrayDistinct()
    {
        return ArrayItems.Concat(ArrayItems2).Distinct();
    } //EndMethod

    public IEnumerable<int> ArrayConcatArrayDistinctRewritten()
    {
        return ArrayConcatArrayDistinctRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayConcatArrayDistinct2()
    {
        return ArrayItems.Concat(ArrayItems2).Distinct(EqualityComparer<int>.Default);
    } //EndMethod

    public IEnumerable<int> ArrayConcatArrayDistinct2Rewritten()
    {
        return ArrayConcatArrayDistinct2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayConcatArrayElementAt()
    {
        return ArrayItems.Concat(ArrayItems2).ElementAt(45);
    } //EndMethod

    public int ArrayConcatArrayElementAtRewritten()
    {
        return ArrayConcatArrayElementAtRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayConcatArrayElementAtOrDefault()
    {
        return ArrayItems.Concat(ArrayItems2).ElementAtOrDefault(45);
    } //EndMethod

    public int ArrayConcatArrayElementAtOrDefaultRewritten()
    {
        return ArrayConcatArrayElementAtOrDefaultRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayConcatArrayFirst()
    {
        return ArrayItems.Concat(ArrayItems2).First();
    } //EndMethod

    public int ArrayConcatArrayFirstRewritten()
    {
        return ArrayConcatArrayFirstRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayConcatArrayFirstOrDefault()
    {
        return ArrayItems.Concat(ArrayItems2).FirstOrDefault();
    } //EndMethod

    public int ArrayConcatArrayFirstOrDefaultRewritten()
    {
        return ArrayConcatArrayFirstOrDefaultRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayConcatArrayLast()
    {
        return ArrayItems.Concat(ArrayItems2).Last();
    } //EndMethod

    public int ArrayConcatArrayLastRewritten()
    {
        return ArrayConcatArrayLastRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayConcatArrayLastOrDefault()
    {
        return ArrayItems.Concat(ArrayItems2).LastOrDefault();
    } //EndMethod

    public int ArrayConcatArrayLastOrDefaultRewritten()
    {
        return ArrayConcatArrayLastOrDefaultRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayConcatArraySingle()
    {
        return ArrayItems.Concat(ArrayItems2).Single();
    } //EndMethod

    public int ArrayConcatArraySingleRewritten()
    {
        return ArrayConcatArraySingleRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayConcatArraySingle2()
    {
        return ArrayItems.Concat(ArrayItems2).Single(x => x == 76);
    } //EndMethod

    public int ArrayConcatArraySingle2Rewritten()
    {
        return ArrayConcatArraySingle2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayConcatArraySingleOrDefault()
    {
        return ArrayItems.Concat(ArrayItems2).SingleOrDefault();
    } //EndMethod

    public int ArrayConcatArraySingleOrDefaultRewritten()
    {
        return ArrayConcatArraySingleOrDefaultRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayConcatArrayMin()
    {
        return ArrayItems.Concat(ArrayItems2).Min();
    } //EndMethod

    public int ArrayConcatArrayMinRewritten()
    {
        return ArrayConcatArrayMinRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public decimal ArrayConcatArrayMin2()
    {
        return ArrayItems.Concat(ArrayItems2).Min(x => x + 2m);
    } //EndMethod

    public decimal ArrayConcatArrayMin2Rewritten()
    {
        return ArrayConcatArrayMin2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayConcatArrayMax()
    {
        return ArrayItems.Concat(ArrayItems2).Max();
    } //EndMethod

    public int ArrayConcatArrayMaxRewritten()
    {
        return ArrayConcatArrayMaxRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public decimal ArrayConcatArrayMax2()
    {
        return ArrayItems.Concat(ArrayItems2).Max(x => x + 2m);
    } //EndMethod

    public decimal ArrayConcatArrayMax2Rewritten()
    {
        return ArrayConcatArrayMax2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public long ArrayConcatArrayLongCount()
    {
        return ArrayItems.Concat(ArrayItems2).LongCount();
    } //EndMethod

    public long ArrayConcatArrayLongCountRewritten()
    {
        return ArrayConcatArrayLongCountRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public long ArrayConcatArrayLongCount2()
    {
        return ArrayItems.Concat(ArrayItems2).LongCount(x => x > 50);
    } //EndMethod

    public long ArrayConcatArrayLongCount2Rewritten()
    {
        return ArrayConcatArrayLongCount2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArrayConcatArrayContains()
    {
        return ArrayItems.Concat(ArrayItems2).Contains(56);
    } //EndMethod

    public bool ArrayConcatArrayContainsRewritten()
    {
        return ArrayConcatArrayContainsRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double ArrayConcatArrayAverage()
    {
        return ArrayItems.Concat(ArrayItems2).Average();
    } //EndMethod

    public double ArrayConcatArrayAverageRewritten()
    {
        return ArrayConcatArrayAverageRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double ArrayConcatArrayAverage2()
    {
        return ArrayItems.Concat(ArrayItems2).Average(x => x + 10);
    } //EndMethod

    public double ArrayConcatArrayAverage2Rewritten()
    {
        return ArrayConcatArrayAverage2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArrayConcatArrayContains2()
    {
        return ArrayItems.Concat(ArrayItems2).Contains(56, EqualityComparer<int>.Default);
    } //EndMethod

    public bool ArrayConcatArrayContains2Rewritten()
    {
        return ArrayConcatArrayContains2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool SelectWhereArrayConcatSelectWhereArrayContains()
    {
        return ArrayItems.Select(x => x + 10).Where(x => x > 80).Concat(ArrayItems2.Select(x => x + 10).Where(x => x > 80)).Contains(112);
    } //EndMethod

    public bool SelectWhereArrayConcatSelectWhereArrayContainsRewritten()
    {
        return SelectWhereArrayConcatSelectWhereArrayContainsRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeConcatArray()
    {
        return Enumerable.Range(20, 100).Concat(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> RangeConcatArrayRewritten()
    {
        return RangeConcatArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatConcatArray()
    {
        return Enumerable.Repeat(20, 100).Concat(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> RepeatConcatArrayRewritten()
    {
        return RepeatConcatArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EmptyConcatArray()
    {
        return Enumerable.Empty<int>().Concat(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> EmptyConcatArrayRewritten()
    {
        return EmptyConcatArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeEmpty2Array()
    {
        return ArrayItems.Where(x => false).Concat(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> RangeEmpty2ArrayRewritten()
    {
        return RangeEmpty2ArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayConcatRange()
    {
        return ArrayItems.Concat(Enumerable.Range(70, 260));
    } //EndMethod

    public IEnumerable<int> ArrayConcatRangeRewritten()
    {
        return ArrayConcatRangeRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayConcatRepeat()
    {
        return ArrayItems.Concat(Enumerable.Repeat(70, 100));
    } //EndMethod

    public IEnumerable<int> ArrayConcatRepeatRewritten()
    {
        return ArrayConcatRepeatRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayConcatEmpty()
    {
        return ArrayItems.Concat(Enumerable.Empty<int>());
    } //EndMethod

    public IEnumerable<int> ArrayConcatEmptyRewritten()
    {
        return ArrayConcatEmptyRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayConcatEmpty2()
    {
        return ArrayItems.Concat(ArrayItems2.Where(x => false));
    } //EndMethod

    public IEnumerable<int> ArrayConcatEmpty2Rewritten()
    {
        return ArrayConcatEmpty2Rewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayConcatAll()
    {
        return ArrayItems.Concat(Enumerable.Range(0, 1000));
    } //EndMethod

    public IEnumerable<int> ArrayConcatAllRewritten()
    {
        return ArrayConcatAllRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayConcatNull()
    {
        return ArrayItems.Concat(null);
    } //EndMethod

    public IEnumerable<int> ArrayConcatNullRewritten()
    {
        return ArrayConcatNullRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayConcatArrayConcatEnumerable()
    {
        return ArrayItems.Concat(ArrayItems).Concat(EnumerableItems2);
    } //EndMethod

    public IEnumerable<int> ArrayConcatArrayConcatEnumerableRewritten()
    {
        return ArrayConcatArrayConcatEnumerableRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayConcatArrayConcatEnumerable2()
    {
        return ArrayItems.Concat(ArrayItems.Concat(EnumerableItems2));
    } //EndMethod

    public IEnumerable<int> ArrayConcatArrayConcatEnumerable2Rewritten()
    {
        return ArrayConcatArrayConcatEnumerable2Rewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayDistinctConcatArrayDistinct()
    {
        return ArrayItems.Distinct().Concat(ArrayItems.Distinct());
    } //EndMethod

    public IEnumerable<int> ArrayDistinctConcatArrayDistinctRewritten()
    {
        return ArrayDistinctConcatArrayDistinctRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinct()
    {
        return ArrayItems.Distinct().Concat(ArrayItems.Distinct()).Distinct();
    } //EndMethod

    public IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinctRewritten()
    {
        return ArrayDistinctConcatArrayDistinctDistinctRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinct2()
    {
        return ArrayItems.Distinct(EqualityComparer<int>.Default).Concat(ArrayItems.Distinct(EqualityComparer<int>.Default)).Distinct(EqualityComparer<int>.Default);
    } //EndMethod

    public IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinct2Rewritten()
    {
        return ArrayDistinctConcatArrayDistinctDistinct2Rewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    System.Collections.Generic.IEnumerable<int> ArrayConcatArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v183;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v184;
        int v185;
        v183 = (0);
        for (; v183 < (ArrayItems.Length); v183++)
        {
            v184 = (ArrayItems[v183]);
            yield return (v184);
        }

        v185 = (0);
        for (; v185 < (ArrayItems2.Length); v185++)
        {
            v184 = ArrayItems2[v185];
            yield return (v184);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v186;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v187;
        int v188;
        int v189;
        v188 = SimpleListItems2.Count;
        v186 = (0);
        for (; v186 < (ArrayItems.Length); v186++)
        {
            v187 = (ArrayItems[v186]);
            yield return (v187);
        }

        v189 = (0);
        for (; v189 < (v188); v189++)
        {
            v187 = SimpleListItems2[v189];
            yield return (v187);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v190;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v191;
        IEnumerator<int> v192;
        v192 = EnumerableItems2.GetEnumerator();
        v190 = (0);
        for (; v190 < (ArrayItems.Length); v190++)
        {
            v191 = (ArrayItems[v190]);
            yield return (v191);
        }

        try
        {
            while (v192.MoveNext())
            {
                v191 = v192.Current;
                yield return (v191);
            }
        }
        finally
        {
            v192.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v193;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v194;
        IEnumerator<int> v195;
        v195 = MethodEnumerable2().GetEnumerator();
        v193 = (0);
        for (; v193 < (ArrayItems.Length); v193++)
        {
            v194 = (ArrayItems[v193]);
            yield return (v194);
        }

        try
        {
            while (v195.MoveNext())
            {
                v194 = v195.Current;
                yield return (v194);
            }
        }
        finally
        {
            v195.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SimpleListConcatArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v196;
        LinqRewrite.Core.SimpleList.SimpleList<int> v197;
        int v198;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v199;
        int v200;
        v196 = SimpleListItems.Count;
        v197 = SimpleListItems;
        v198 = (0);
        for (; v198 < (v196); v198++)
        {
            v199 = (v197[v198]);
            yield return (v199);
        }

        v200 = (0);
        for (; v200 < (ArrayItems2.Length); v200++)
        {
            v199 = ArrayItems2[v200];
            yield return (v199);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SimpleListConcatSimpleListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v201;
        LinqRewrite.Core.SimpleList.SimpleList<int> v202;
        int v203;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v204;
        int v205;
        int v206;
        v201 = SimpleListItems.Count;
        v202 = SimpleListItems;
        v205 = SimpleListItems2.Count;
        v203 = (0);
        for (; v203 < (v201); v203++)
        {
            v204 = (v202[v203]);
            yield return (v204);
        }

        v206 = (0);
        for (; v206 < (v205); v206++)
        {
            v204 = SimpleListItems2[v206];
            yield return (v204);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SimpleListConcatEnumerableRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v207;
        LinqRewrite.Core.SimpleList.SimpleList<int> v208;
        int v209;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v210;
        IEnumerator<int> v211;
        v211 = EnumerableItems2.GetEnumerator();
        v207 = SimpleListItems.Count;
        v208 = SimpleListItems;
        v209 = (0);
        for (; v209 < (v207); v209++)
        {
            v210 = (v208[v209]);
            yield return (v210);
        }

        try
        {
            while (v211.MoveNext())
            {
                v210 = v211.Current;
                yield return (v210);
            }
        }
        finally
        {
            v211.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SimpleListConcatMethodRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v212;
        LinqRewrite.Core.SimpleList.SimpleList<int> v213;
        int v214;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v215;
        IEnumerator<int> v216;
        v216 = MethodEnumerable2().GetEnumerator();
        v212 = SimpleListItems.Count;
        v213 = SimpleListItems;
        v214 = (0);
        for (; v214 < (v212); v214++)
        {
            v215 = (v213[v214]);
            yield return (v215);
        }

        try
        {
            while (v216.MoveNext())
            {
                v215 = v216.Current;
                yield return (v215);
            }
        }
        finally
        {
            v216.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableConcatArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v217;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v218;
        int v219;
        v217 = EnumerableItems.GetEnumerator();
        try
        {
            while (v217.MoveNext())
            {
                v218 = (v217.Current);
                yield return (v218);
            }
        }
        finally
        {
            v217.Dispose();
        }

        v219 = (0);
        for (; v219 < (ArrayItems2.Length); v219++)
        {
            v218 = ArrayItems2[v219];
            yield return (v218);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableConcatSimpleListRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v220;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v221;
        int v222;
        int v223;
        v220 = EnumerableItems.GetEnumerator();
        v222 = SimpleListItems2.Count;
        try
        {
            while (v220.MoveNext())
            {
                v221 = (v220.Current);
                yield return (v221);
            }
        }
        finally
        {
            v220.Dispose();
        }

        v223 = (0);
        for (; v223 < (v222); v223++)
        {
            v221 = SimpleListItems2[v223];
            yield return (v221);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableConcatEnumerableRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v224;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v225;
        IEnumerator<int> v226;
        v224 = EnumerableItems.GetEnumerator();
        v226 = EnumerableItems2.GetEnumerator();
        try
        {
            while (v224.MoveNext())
            {
                v225 = (v224.Current);
                yield return (v225);
            }
        }
        finally
        {
            v224.Dispose();
        }

        try
        {
            while (v226.MoveNext())
            {
                v225 = v226.Current;
                yield return (v225);
            }
        }
        finally
        {
            v226.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableConcatMethodRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v227;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v228;
        IEnumerator<int> v229;
        v227 = EnumerableItems.GetEnumerator();
        v229 = MethodEnumerable2().GetEnumerator();
        try
        {
            while (v227.MoveNext())
            {
                v228 = (v227.Current);
                yield return (v228);
            }
        }
        finally
        {
            v227.Dispose();
        }

        try
        {
            while (v229.MoveNext())
            {
                v228 = v229.Current;
                yield return (v228);
            }
        }
        finally
        {
            v229.Dispose();
        }

        yield break;
    }

    int[] ArrayConcatArrayToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v230;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v231;
        int v232;
        int v233;
        int v234;
        int v235;
        int[] v236;
        v233 = 0;
        v234 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems2.Length + ArrayItems.Length))) - 3);
        v234 -= (v234 % 2);
        v235 = 8;
        v236 = new int[8];
        v230 = (0);
        for (; v230 < (ArrayItems.Length); v230++)
        {
            v231 = (ArrayItems[v230]);
            if (v233 >= v235)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems2.Length + ArrayItems.Length), ref v236, ref v234, out v235);
            v236[v233] = (v231);
            v233++;
        }

        v232 = (0);
        for (; v232 < (ArrayItems2.Length); v232++)
        {
            v231 = ArrayItems2[v232];
            if (v233 >= v235)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems2.Length + ArrayItems.Length), ref v236, ref v234, out v235);
            v236[v233] = (v231);
            v233++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v236, v233);
    }

    int[] ArrayConcatSimpleListToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v237;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v238;
        int v239;
        int v240;
        int v241;
        int v242;
        int v243;
        int[] v244;
        v239 = SimpleListItems2.Count;
        v241 = 0;
        v242 = (LinqRewrite.Core.IntExtensions.Log2((uint)((v239 + ArrayItems.Length))) - 3);
        v242 -= (v242 % 2);
        v243 = 8;
        v244 = new int[8];
        v237 = (0);
        for (; v237 < (ArrayItems.Length); v237++)
        {
            v238 = (ArrayItems[v237]);
            if (v241 >= v243)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (v239 + ArrayItems.Length), ref v244, ref v242, out v243);
            v244[v241] = (v238);
            v241++;
        }

        v240 = (0);
        for (; v240 < (v239); v240++)
        {
            v238 = SimpleListItems2[v240];
            if (v241 >= v243)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (v239 + ArrayItems.Length), ref v244, ref v242, out v243);
            v244[v241] = (v238);
            v241++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v244, v241);
    }

    int[] ArrayConcatEnumerableToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v245;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v246;
        IEnumerator<int> v247;
        int v248;
        int v249;
        int[] v250;
        v247 = EnumerableItems2.GetEnumerator();
        v248 = 0;
        v249 = 8;
        v250 = new int[8];
        v245 = (0);
        for (; v245 < (ArrayItems.Length); v245++)
        {
            v246 = (ArrayItems[v245]);
            if (v248 >= v249)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v250, ref v249);
            v250[v248] = (v246);
            v248++;
        }

        try
        {
            while (v247.MoveNext())
            {
                v246 = v247.Current;
                if (v248 >= v249)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v250, ref v249);
                v250[v248] = (v246);
                v248++;
            }
        }
        finally
        {
            v247.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v250, v248);
    }

    int[] SimpleListConcatArrayToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v251;
        LinqRewrite.Core.SimpleList.SimpleList<int> v252;
        int v253;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v254;
        int v255;
        int v256;
        int v257;
        int v258;
        int[] v259;
        v251 = SimpleListItems.Count;
        v252 = SimpleListItems;
        v256 = 0;
        v257 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems2.Length + v251))) - 3);
        v257 -= (v257 % 2);
        v258 = 8;
        v259 = new int[8];
        v253 = (0);
        for (; v253 < (v251); v253++)
        {
            v254 = (v252[v253]);
            if (v256 >= v258)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems2.Length + v251), ref v259, ref v257, out v258);
            v259[v256] = (v254);
            v256++;
        }

        v255 = (0);
        for (; v255 < (ArrayItems2.Length); v255++)
        {
            v254 = ArrayItems2[v255];
            if (v256 >= v258)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems2.Length + v251), ref v259, ref v257, out v258);
            v259[v256] = (v254);
            v256++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v259, v256);
    }

    int[] SimpleListConcatSimpleListToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v260;
        LinqRewrite.Core.SimpleList.SimpleList<int> v261;
        int v262;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v263;
        int v264;
        int v265;
        int v266;
        int v267;
        int v268;
        int[] v269;
        v260 = SimpleListItems.Count;
        v261 = SimpleListItems;
        v264 = SimpleListItems2.Count;
        v266 = 0;
        v267 = (LinqRewrite.Core.IntExtensions.Log2((uint)((v264 + v260))) - 3);
        v267 -= (v267 % 2);
        v268 = 8;
        v269 = new int[8];
        v262 = (0);
        for (; v262 < (v260); v262++)
        {
            v263 = (v261[v262]);
            if (v266 >= v268)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (v264 + v260), ref v269, ref v267, out v268);
            v269[v266] = (v263);
            v266++;
        }

        v265 = (0);
        for (; v265 < (v264); v265++)
        {
            v263 = SimpleListItems2[v265];
            if (v266 >= v268)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (v264 + v260), ref v269, ref v267, out v268);
            v269[v266] = (v263);
            v266++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v269, v266);
    }

    int[] SimpleListConcatEnumerableToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v270;
        LinqRewrite.Core.SimpleList.SimpleList<int> v271;
        int v272;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v273;
        IEnumerator<int> v274;
        int v275;
        int v276;
        int[] v277;
        v274 = EnumerableItems2.GetEnumerator();
        v270 = SimpleListItems.Count;
        v271 = SimpleListItems;
        v275 = 0;
        v276 = 8;
        v277 = new int[8];
        v272 = (0);
        for (; v272 < (v270); v272++)
        {
            v273 = (v271[v272]);
            if (v275 >= v276)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v277, ref v276);
            v277[v275] = (v273);
            v275++;
        }

        try
        {
            while (v274.MoveNext())
            {
                v273 = v274.Current;
                if (v275 >= v276)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v277, ref v276);
                v277[v275] = (v273);
                v275++;
            }
        }
        finally
        {
            v274.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v277, v275);
    }

    int[] EnumerableConcatArrayToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v278;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v279;
        int v280;
        int v281;
        int v282;
        int[] v283;
        v278 = EnumerableItems.GetEnumerator();
        v281 = 0;
        v282 = 8;
        v283 = new int[8];
        try
        {
            while (v278.MoveNext())
            {
                v279 = (v278.Current);
                if (v281 >= v282)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v283, ref v282);
                v283[v281] = (v279);
                v281++;
            }
        }
        finally
        {
            v278.Dispose();
        }

        v280 = (0);
        for (; v280 < (ArrayItems2.Length); v280++)
        {
            v279 = ArrayItems2[v280];
            if (v281 >= v282)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v283, ref v282);
            v283[v281] = (v279);
            v281++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v283, v281);
    }

    int[] EnumerableConcatSimpleListToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v284;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v285;
        int v286;
        int v287;
        int v288;
        int v289;
        int[] v290;
        v284 = EnumerableItems.GetEnumerator();
        v286 = SimpleListItems2.Count;
        v288 = 0;
        v289 = 8;
        v290 = new int[8];
        try
        {
            while (v284.MoveNext())
            {
                v285 = (v284.Current);
                if (v288 >= v289)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v290, ref v289);
                v290[v288] = (v285);
                v288++;
            }
        }
        finally
        {
            v284.Dispose();
        }

        v287 = (0);
        for (; v287 < (v286); v287++)
        {
            v285 = SimpleListItems2[v287];
            if (v288 >= v289)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v290, ref v289);
            v290[v288] = (v285);
            v288++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v290, v288);
    }

    int[] EnumerableConcatEnumerableToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v291;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v292;
        IEnumerator<int> v293;
        int v294;
        int v295;
        int[] v296;
        v291 = EnumerableItems.GetEnumerator();
        v293 = EnumerableItems2.GetEnumerator();
        v294 = 0;
        v295 = 8;
        v296 = new int[8];
        try
        {
            while (v291.MoveNext())
            {
                v292 = (v291.Current);
                if (v294 >= v295)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v296, ref v295);
                v296[v294] = (v292);
                v294++;
            }
        }
        finally
        {
            v291.Dispose();
        }

        try
        {
            while (v293.MoveNext())
            {
                v292 = v293.Current;
                if (v294 >= v295)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v296, ref v295);
                v296[v294] = (v292);
                v294++;
            }
        }
        finally
        {
            v293.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v296, v294);
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectConcatArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v297;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v298;
        int v299;
        v297 = (0);
        for (; v297 < (ArrayItems.Length); v297++)
        {
            v298 = (50 + ArrayItems[v297]);
            yield return (v298);
        }

        v299 = (0);
        for (; v299 < (ArrayItems2.Length); v299++)
        {
            v298 = ArrayItems2[v299];
            yield return (v298);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectConcatArraySelectRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v301;
        v301 = (0);
        for (; v301 < (ArrayItems2.Length); v301++)
            yield return (((ArrayItems2[v301]) + 50));
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectConcatArraySelectRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v302;
        if (ArraySelectConcatArraySelectRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v303;
        IEnumerator<int> v304;
        v304 = ArraySelectConcatArraySelectRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v302 = (0);
        for (; v302 < (ArrayItems.Length); v302++)
        {
            v303 = (50 + ArrayItems[v302]);
            yield return (v303);
        }

        try
        {
            while (v304.MoveNext())
            {
                v303 = v304.Current;
                yield return (v303);
            }
        }
        finally
        {
            v304.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereConcatArrayWhereRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v305;
        int v306;
        v305 = (0);
        for (; v305 < (ArrayItems2.Length); v305++)
        {
            v306 = (ArrayItems2[v305]);
            if (!(((v306) > 50)))
                continue;
            yield return (v306);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereConcatArrayWhereRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v307;
        int v308;
        if (ArrayWhereConcatArrayWhereRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v309;
        v309 = ArrayWhereConcatArrayWhereRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v307 = (0);
        for (; v307 < (ArrayItems.Length); v307++)
        {
            v308 = (ArrayItems[v307]);
            if (!(((v308) > 50)))
                continue;
            yield return (v308);
        }

        try
        {
            while (v309.MoveNext())
            {
                v308 = v309.Current;
                yield return (v308);
            }
        }
        finally
        {
            v309.Dispose();
        }

        yield break;
    }

    int ArrayConcatArrayCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v310;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v311;
        int v312;
        int v313;
        v313 = 0;
        v310 = (0);
        for (; v310 < (ArrayItems.Length); v310++)
        {
            v311 = (ArrayItems[v310]);
            v313++;
        }

        v312 = (0);
        for (; v312 < (ArrayItems2.Length); v312++)
        {
            v311 = ArrayItems2[v312];
            v313++;
        }

        return v313;
    }

    int ArrayConcatArrayCount2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v314;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v315;
        int v316;
        int v317;
        v317 = 0;
        v314 = (0);
        for (; v314 < (ArrayItems.Length); v314++)
        {
            v315 = (ArrayItems[v314]);
            if (!(((v315) > 70)))
                continue;
            v317++;
        }

        v316 = (0);
        for (; v316 < (ArrayItems2.Length); v316++)
        {
            v315 = ArrayItems2[v316];
            if (!(((v315) > 70)))
                continue;
            v317++;
        }

        return v317;
    }

    int ArrayConcatArraySumRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v318;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v319;
        int v320;
        int v321;
        v321 = 0;
        v318 = (0);
        for (; v318 < (ArrayItems.Length); v318++)
        {
            v319 = (ArrayItems[v318]);
            v321 += (v319);
        }

        v320 = (0);
        for (; v320 < (ArrayItems2.Length); v320++)
        {
            v319 = ArrayItems2[v320];
            v321 += (v319);
        }

        return v321;
    }

    int ArrayConcatArraySum2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v322;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v323;
        int v324;
        int v325;
        int v326;
        v325 = 0;
        v322 = (0);
        for (; v322 < (ArrayItems.Length); v322++)
        {
            v323 = (ArrayItems[v322]);
            v326 = ((v323) + 10);
            v325 += v326;
        }

        v324 = (0);
        for (; v324 < (ArrayItems2.Length); v324++)
        {
            v323 = ArrayItems2[v324];
            v326 = ((v323) + 10);
            v325 += v326;
        }

        return v325;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v327;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v328;
        int v329;
        HashSet<int> v330;
        int v331;
        v330 = new HashSet<int>();
        v327 = (0);
        for (; v327 < (ArrayItems.Length); v327++)
        {
            v328 = (ArrayItems[v327]);
            v331 = (v328);
            if (!(v330.Add((v331))))
                continue;
            yield return (v331);
        }

        v329 = (0);
        for (; v329 < (ArrayItems2.Length); v329++)
        {
            v328 = ArrayItems2[v329];
            v331 = (v328);
            if (!(v330.Add((v331))))
                continue;
            yield return (v331);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatArrayDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v332;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v333;
        int v334;
        HashSet<int> v335;
        int v336;
        v335 = new HashSet<int>(EqualityComparer<int>.Default);
        v332 = (0);
        for (; v332 < (ArrayItems.Length); v332++)
        {
            v333 = (ArrayItems[v332]);
            v336 = (v333);
            if (!(v335.Add((v336))))
                continue;
            yield return (v336);
        }

        v334 = (0);
        for (; v334 < (ArrayItems2.Length); v334++)
        {
            v333 = ArrayItems2[v334];
            v336 = (v333);
            if (!(v335.Add((v336))))
                continue;
            yield return (v336);
        }

        yield break;
    }

    int ArrayConcatArrayElementAtRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v337;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v338;
        int v339;
        int v340;
        v340 = 0;
        v337 = (0);
        for (; v337 < (ArrayItems.Length); v337++)
        {
            v338 = (ArrayItems[v337]);
            if (v340 == 45)
                return (v338);
            v340++;
        }

        v339 = (0);
        for (; v339 < (ArrayItems2.Length); v339++)
        {
            v338 = ArrayItems2[v339];
            if (v340 == 45)
                return (v338);
            v340++;
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArrayConcatArrayElementAtOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v341;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v342;
        int v343;
        int v344;
        v344 = 0;
        v341 = (0);
        for (; v341 < (ArrayItems.Length); v341++)
        {
            v342 = (ArrayItems[v341]);
            if (v344 == 45)
                return (v342);
            v344++;
        }

        v343 = (0);
        for (; v343 < (ArrayItems2.Length); v343++)
        {
            v342 = ArrayItems2[v343];
            if (v344 == 45)
                return (v342);
            v344++;
        }

        return default(int);
    }

    int ArrayConcatArrayFirstRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v345;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v346;
        int v347;
        int v348;
        v348 = 0;
        v345 = (0);
        for (; v345 < (ArrayItems.Length); v345++)
        {
            v346 = (ArrayItems[v345]);
            return (v346);
            v348++;
        }

        v347 = (0);
        for (; v347 < (ArrayItems2.Length); v347++)
        {
            v346 = ArrayItems2[v347];
            return (v346);
            v348++;
        }

        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int ArrayConcatArrayFirstOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v349;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v350;
        int v351;
        v349 = (0);
        for (; v349 < (ArrayItems.Length); v349++)
        {
            v350 = (ArrayItems[v349]);
            return (v350);
        }

        v351 = (0);
        for (; v351 < (ArrayItems2.Length); v351++)
        {
            v350 = ArrayItems2[v351];
            return (v350);
        }

        return default(int);
    }

    int ArrayConcatArrayLastRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v352;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v353;
        int v354;
        int v355;
        int? v356;
        v355 = 0;
        v356 = null;
        v352 = (0);
        for (; v352 < (ArrayItems.Length); v352++)
        {
            v353 = (ArrayItems[v352]);
            v356 = (v353);
            v355++;
        }

        v354 = (0);
        for (; v354 < (ArrayItems2.Length); v354++)
        {
            v353 = ArrayItems2[v354];
            v356 = (v353);
            v355++;
        }

        if (v356 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v356;
    }

    int ArrayConcatArrayLastOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v357;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v358;
        int v359;
        int? v360;
        v360 = null;
        v357 = (0);
        for (; v357 < (ArrayItems.Length); v357++)
        {
            v358 = (ArrayItems[v357]);
            v360 = (v358);
        }

        v359 = (0);
        for (; v359 < (ArrayItems2.Length); v359++)
        {
            v358 = ArrayItems2[v359];
            v360 = (v358);
        }

        if (v360 == null)
            return default(int);
        else
            return (int)v360;
    }

    int ArrayConcatArraySingleRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v361;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v362;
        int v363;
        int? v364;
        v364 = null;
        v361 = (0);
        for (; v361 < (ArrayItems.Length); v361++)
        {
            v362 = (ArrayItems[v361]);
            if (v364 == null)
                v364 = (v362);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        v363 = (0);
        for (; v363 < (ArrayItems2.Length); v363++)
        {
            v362 = ArrayItems2[v363];
            if (v364 == null)
                v364 = (v362);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v364 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v364;
    }

    int ArrayConcatArraySingle2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v365;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v366;
        int v367;
        int? v368;
        v368 = null;
        v365 = (0);
        for (; v365 < (ArrayItems.Length); v365++)
        {
            v366 = (ArrayItems[v365]);
            if (((v366) == 76))
                if (v368 == null)
                    v368 = (v366);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        v367 = (0);
        for (; v367 < (ArrayItems2.Length); v367++)
        {
            v366 = ArrayItems2[v367];
            if (((v366) == 76))
                if (v368 == null)
                    v368 = (v366);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v368 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v368;
    }

    int ArrayConcatArraySingleOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v369;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v370;
        int v371;
        int? v372;
        v372 = null;
        v369 = (0);
        for (; v369 < (ArrayItems.Length); v369++)
        {
            v370 = (ArrayItems[v369]);
            if (v372 == null)
                v372 = (v370);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        v371 = (0);
        for (; v371 < (ArrayItems2.Length); v371++)
        {
            v370 = ArrayItems2[v371];
            if (v372 == null)
                v372 = (v370);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v372 == null)
            return default(int);
        else
            return (int)v372;
    }

    int ArrayConcatArrayMinRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v373;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v374;
        int v375;
        int v376;
        int v377;
        int v378;
        v376 = 0;
        v377 = 2147483647;
        v373 = (0);
        for (; v373 < (ArrayItems.Length); v373++)
        {
            v374 = (ArrayItems[v373]);
            v378 = (v374);
            if (v378 >= v377)
                continue;
            v377 = v378;
            v376++;
        }

        v375 = (0);
        for (; v375 < (ArrayItems2.Length); v375++)
        {
            v374 = ArrayItems2[v375];
            v378 = (v374);
            if (v378 >= v377)
                continue;
            v377 = v378;
            v376++;
        }

        if (1 > v376)
            throw new System.InvalidOperationException("Index out of range");
        return v377;
    }

    decimal ArrayConcatArrayMin2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v379;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v380;
        int v381;
        int v382;
        decimal v383;
        decimal v384;
        v382 = 0;
        v383 = 79228162514264337593543950335M;
        v379 = (0);
        for (; v379 < (ArrayItems.Length); v379++)
        {
            v380 = (ArrayItems[v379]);
            v384 = ((v380) + 2m);
            if (v384 >= v383)
                continue;
            v383 = v384;
            v382++;
        }

        v381 = (0);
        for (; v381 < (ArrayItems2.Length); v381++)
        {
            v380 = ArrayItems2[v381];
            v384 = ((v380) + 2m);
            if (v384 >= v383)
                continue;
            v383 = v384;
            v382++;
        }

        if (1 > v382)
            throw new System.InvalidOperationException("Index out of range");
        return v383;
    }

    int ArrayConcatArrayMaxRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v385;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v386;
        int v387;
        int v388;
        int v389;
        int v390;
        v388 = 0;
        v389 = -2147483648;
        v385 = (0);
        for (; v385 < (ArrayItems.Length); v385++)
        {
            v386 = (ArrayItems[v385]);
            v390 = (v386);
            if (v390 <= v389)
                continue;
            v389 = v390;
            v388++;
        }

        v387 = (0);
        for (; v387 < (ArrayItems2.Length); v387++)
        {
            v386 = ArrayItems2[v387];
            v390 = (v386);
            if (v390 <= v389)
                continue;
            v389 = v390;
            v388++;
        }

        if (1 > v388)
            throw new System.InvalidOperationException("Index out of range");
        return v389;
    }

    decimal ArrayConcatArrayMax2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v391;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v392;
        int v393;
        int v394;
        decimal v395;
        decimal v396;
        v394 = 0;
        v395 = -79228162514264337593543950335M;
        v391 = (0);
        for (; v391 < (ArrayItems.Length); v391++)
        {
            v392 = (ArrayItems[v391]);
            v396 = ((v392) + 2m);
            if (v396 <= v395)
                continue;
            v395 = v396;
            v394++;
        }

        v393 = (0);
        for (; v393 < (ArrayItems2.Length); v393++)
        {
            v392 = ArrayItems2[v393];
            v396 = ((v392) + 2m);
            if (v396 <= v395)
                continue;
            v395 = v396;
            v394++;
        }

        if (1 > v394)
            throw new System.InvalidOperationException("Index out of range");
        return v395;
    }

    long ArrayConcatArrayLongCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v397;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v398;
        int v399;
        long v400;
        v400 = 0;
        v397 = (0);
        for (; v397 < (ArrayItems.Length); v397++)
        {
            v398 = (ArrayItems[v397]);
            v400++;
        }

        v399 = (0);
        for (; v399 < (ArrayItems2.Length); v399++)
        {
            v398 = ArrayItems2[v399];
            v400++;
        }

        return v400;
    }

    long ArrayConcatArrayLongCount2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v401;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v402;
        int v403;
        long v404;
        v404 = 0;
        v401 = (0);
        for (; v401 < (ArrayItems.Length); v401++)
        {
            v402 = (ArrayItems[v401]);
            if (!(((v402) > 50)))
                continue;
            v404++;
        }

        v403 = (0);
        for (; v403 < (ArrayItems2.Length); v403++)
        {
            v402 = ArrayItems2[v403];
            if (!(((v402) > 50)))
                continue;
            v404++;
        }

        return v404;
    }

    bool ArrayConcatArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v405;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v406;
        int v407;
        v405 = (0);
        for (; v405 < (ArrayItems.Length); v405++)
        {
            v406 = (ArrayItems[v405]);
            if ((v406) == 56)
                return true;
        }

        v407 = (0);
        for (; v407 < (ArrayItems2.Length); v407++)
        {
            v406 = ArrayItems2[v407];
            if ((v406) == 56)
                return true;
        }

        return false;
    }

    double ArrayConcatArrayAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v408;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v409;
        int v410;
        double v411;
        int v412;
        v411 = 0;
        v412 = 0;
        v408 = (0);
        for (; v408 < (ArrayItems.Length); v408++)
        {
            v409 = (ArrayItems[v408]);
            v411 += (v409);
            v412++;
        }

        v410 = (0);
        for (; v410 < (ArrayItems2.Length); v410++)
        {
            v409 = ArrayItems2[v410];
            v411 += (v409);
            v412++;
        }

        if (1 > v412)
            throw new System.InvalidOperationException("Index out of range");
        return (v411 / v412);
    }

    double ArrayConcatArrayAverage2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v413;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v414;
        int v415;
        double v416;
        int v417;
        v416 = 0;
        v417 = 0;
        v413 = (0);
        for (; v413 < (ArrayItems.Length); v413++)
        {
            v414 = (ArrayItems[v413]);
            v416 += ((v414) + 10);
            v417++;
        }

        v415 = (0);
        for (; v415 < (ArrayItems2.Length); v415++)
        {
            v414 = ArrayItems2[v415];
            v416 += ((v414) + 10);
            v417++;
        }

        if (1 > v417)
            throw new System.InvalidOperationException("Index out of range");
        return (v416 / v417);
    }

    bool ArrayConcatArrayContains2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v418;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v419;
        int v420;
        System.Collections.Generic.EqualityComparer<int> v421;
        v421 = EqualityComparer<int>.Default;
        v418 = (0);
        for (; v418 < (ArrayItems.Length); v418++)
        {
            v419 = (ArrayItems[v418]);
            if (v421.Equals((v419), 56))
                return true;
        }

        v420 = (0);
        for (; v420 < (ArrayItems2.Length); v420++)
        {
            v419 = ArrayItems2[v420];
            if (v421.Equals((v419), 56))
                return true;
        }

        return false;
    }

    System.Collections.Generic.IEnumerable<int> SelectWhereArrayConcatSelectWhereArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v422;
        int v423;
        v422 = (0);
        for (; v422 < (ArrayItems2.Length); v422++)
        {
            v423 = (((ArrayItems2[v422]) + 10));
            if (!(((v423) > 80)))
                continue;
            yield return (v423);
        }

        yield break;
    }

    bool SelectWhereArrayConcatSelectWhereArrayContainsRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v424;
        int v425;
        if (SelectWhereArrayConcatSelectWhereArrayContainsRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v426;
        v426 = SelectWhereArrayConcatSelectWhereArrayContainsRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v424 = (0);
        for (; v424 < (ArrayItems.Length); v424++)
        {
            v425 = (10 + ArrayItems[v424]);
            if (!(((v425) > 80)))
                continue;
            if ((v425) == 112)
                return true;
        }

        try
        {
            while (v426.MoveNext())
            {
                v425 = v426.Current;
                if ((v425) == 112)
                    return true;
            }
        }
        finally
        {
            v426.Dispose();
        }

        return false;
    }

    System.Collections.Generic.IEnumerable<int> RangeConcatArrayRewritten_ProceduralLinq1()
    {
        int v427;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v428;
        int v429;
        v427 = (0);
        for (; v427 < (100); v427++)
        {
            v428 = (20 + v427);
            yield return (v428);
        }

        v429 = (0);
        for (; v429 < (ArrayItems2.Length); v429++)
        {
            v428 = ArrayItems2[v429];
            yield return (v428);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RepeatConcatArrayRewritten_ProceduralLinq1()
    {
        int v430;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v431;
        int v432;
        v430 = (0);
        for (; v430 < (100); v430++)
        {
            v431 = (20);
            yield return (v431);
        }

        v432 = (0);
        for (; v432 < (ArrayItems2.Length); v432++)
        {
            v431 = ArrayItems2[v432];
            yield return (v431);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EmptyConcatArrayRewritten_ProceduralLinq1()
    {
        int v433;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v434;
        int v435;
        v433 = 0;
        v435 = (0);
        for (; v435 < (ArrayItems2.Length); v435++)
        {
            v434 = ArrayItems2[v435];
            yield return (v434);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeEmpty2ArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v436;
        int v437;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v438;
        v436 = (0);
        for (; v436 < (ArrayItems.Length); v436++)
        {
            v437 = (ArrayItems[v436]);
            if (!((false)))
                continue;
            yield return (v437);
        }

        v438 = (0);
        for (; v438 < (ArrayItems2.Length); v438++)
        {
            v437 = ArrayItems2[v438];
            yield return (v437);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatRangeRewritten_ProceduralLinq1()
    {
        int v439;
        v439 = (0);
        for (; v439 < (260); v439++)
            yield return (70 + v439);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatRangeRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v440;
        if (ArrayConcatRangeRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v441;
        IEnumerator<int> v442;
        v442 = ArrayConcatRangeRewritten_ProceduralLinq1().GetEnumerator();
        v440 = (0);
        for (; v440 < (ArrayItems.Length); v440++)
        {
            v441 = (ArrayItems[v440]);
            yield return (v441);
        }

        try
        {
            while (v442.MoveNext())
            {
                v441 = v442.Current;
                yield return (v441);
            }
        }
        finally
        {
            v442.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatRepeatRewritten_ProceduralLinq1()
    {
        int v443;
        v443 = (0);
        for (; v443 < (100); v443++)
            yield return (70);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatRepeatRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v444;
        if (ArrayConcatRepeatRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v445;
        IEnumerator<int> v446;
        v446 = ArrayConcatRepeatRewritten_ProceduralLinq1().GetEnumerator();
        v444 = (0);
        for (; v444 < (ArrayItems.Length); v444++)
        {
            v445 = (ArrayItems[v444]);
            yield return (v445);
        }

        try
        {
            while (v446.MoveNext())
            {
                v445 = v446.Current;
                yield return (v445);
            }
        }
        finally
        {
            v446.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatEmptyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v447;
        if (Enumerable.Empty<int>() == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v448;
        IEnumerator<int> v449;
        v449 = Enumerable.Empty<int>().GetEnumerator();
        v447 = (0);
        for (; v447 < (ArrayItems.Length); v447++)
        {
            v448 = (ArrayItems[v447]);
            yield return (v448);
        }

        try
        {
            while (v449.MoveNext())
            {
                v448 = v449.Current;
                yield return (v448);
            }
        }
        finally
        {
            v449.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatEmpty2Rewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v450;
        int v451;
        v450 = (0);
        for (; v450 < (ArrayItems2.Length); v450++)
        {
            v451 = (ArrayItems2[v450]);
            if (!((false)))
                continue;
            yield return (v451);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatEmpty2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v452;
        if (ArrayConcatEmpty2Rewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v453;
        IEnumerator<int> v454;
        v454 = ArrayConcatEmpty2Rewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v452 = (0);
        for (; v452 < (ArrayItems.Length); v452++)
        {
            v453 = (ArrayItems[v452]);
            yield return (v453);
        }

        try
        {
            while (v454.MoveNext())
            {
                v453 = v454.Current;
                yield return (v453);
            }
        }
        finally
        {
            v454.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatAllRewritten_ProceduralLinq1()
    {
        int v455;
        v455 = (0);
        for (; v455 < (1000); v455++)
            yield return (v455);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatAllRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v456;
        if (ArrayConcatAllRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v457;
        IEnumerator<int> v458;
        v458 = ArrayConcatAllRewritten_ProceduralLinq1().GetEnumerator();
        v456 = (0);
        for (; v456 < (ArrayItems.Length); v456++)
        {
            v457 = (ArrayItems[v456]);
            yield return (v457);
        }

        try
        {
            while (v458.MoveNext())
            {
                v457 = v458.Current;
                yield return (v457);
            }
        }
        finally
        {
            v458.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatNullRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v459;
        throw new System.InvalidOperationException("Invalid null object");
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatArrayConcatEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v460;
        if (ArrayItems == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v461;
        int v462;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v463;
        v463 = EnumerableItems2.GetEnumerator();
        v460 = (0);
        for (; v460 < (ArrayItems.Length); v460++)
        {
            v461 = (ArrayItems[v460]);
            yield return (v461);
        }

        v462 = (0);
        for (; v462 < (ArrayItems.Length); v462++)
        {
            v461 = ArrayItems[v462];
            yield return (v461);
        }

        try
        {
            while (v463.MoveNext())
            {
                v461 = v463.Current;
                yield return (v461);
            }
        }
        finally
        {
            v463.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatArrayConcatEnumerable2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v464;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v465;
        IEnumerator<int> v466;
        v466 = EnumerableItems2.GetEnumerator();
        v464 = (0);
        for (; v464 < (ArrayItems.Length); v464++)
        {
            v465 = (ArrayItems[v464]);
            yield return (v465);
        }

        try
        {
            while (v466.MoveNext())
            {
                v465 = v466.Current;
                yield return (v465);
            }
        }
        finally
        {
            v466.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatArrayConcatEnumerable2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v467;
        if (ArrayConcatArrayConcatEnumerable2Rewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v468;
        IEnumerator<int> v469;
        v469 = ArrayConcatArrayConcatEnumerable2Rewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v467 = (0);
        for (; v467 < (ArrayItems.Length); v467++)
        {
            v468 = (ArrayItems[v467]);
            yield return (v468);
        }

        try
        {
            while (v469.MoveNext())
            {
                v468 = v469.Current;
                yield return (v468);
            }
        }
        finally
        {
            v469.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctConcatArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v470;
        HashSet<int> v471;
        int v472;
        v471 = new HashSet<int>();
        v470 = (0);
        for (; v470 < (ArrayItems.Length); v470++)
        {
            v472 = (ArrayItems[v470]);
            if (!(v471.Add((v472))))
                continue;
            yield return (v472);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctConcatArrayDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v473;
        HashSet<int> v474;
        int v475;
        if (ArrayDistinctConcatArrayDistinctRewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v476;
        v476 = ArrayDistinctConcatArrayDistinctRewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v474 = new HashSet<int>();
        v473 = (0);
        for (; v473 < (ArrayItems.Length); v473++)
        {
            v475 = (ArrayItems[v473]);
            if (!(v474.Add((v475))))
                continue;
            yield return (v475);
        }

        try
        {
            while (v476.MoveNext())
            {
                v475 = v476.Current;
                yield return (v475);
            }
        }
        finally
        {
            v476.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v477;
        HashSet<int> v478;
        int v479;
        v478 = new HashSet<int>();
        v477 = (0);
        for (; v477 < (ArrayItems.Length); v477++)
        {
            v479 = (ArrayItems[v477]);
            if (!(v478.Add((v479))))
                continue;
            yield return (v479);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v480;
        HashSet<int> v481;
        int v482;
        if (ArrayDistinctConcatArrayDistinctDistinctRewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v483;
        HashSet<int> v484;
        int v485;
        v483 = ArrayDistinctConcatArrayDistinctDistinctRewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v481 = new HashSet<int>();
        v484 = new HashSet<int>();
        v480 = (0);
        for (; v480 < (ArrayItems.Length); v480++)
        {
            v482 = (ArrayItems[v480]);
            if (!(v481.Add((v482))))
                continue;
            v485 = (v482);
            if (!(v484.Add((v485))))
                continue;
            yield return (v485);
        }

        try
        {
            while (v483.MoveNext())
            {
                v482 = v483.Current;
                v485 = (v482);
                if (!(v484.Add((v485))))
                    continue;
                yield return (v485);
            }
        }
        finally
        {
            v483.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v486;
        HashSet<int> v487;
        int v488;
        v487 = new HashSet<int>(EqualityComparer<int>.Default);
        v486 = (0);
        for (; v486 < (ArrayItems.Length); v486++)
        {
            v488 = (ArrayItems[v486]);
            if (!(v487.Add((v488))))
                continue;
            yield return (v488);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinct2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v489;
        HashSet<int> v490;
        int v491;
        if (ArrayDistinctConcatArrayDistinctDistinct2Rewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v492;
        HashSet<int> v493;
        int v494;
        v492 = ArrayDistinctConcatArrayDistinctDistinct2Rewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v490 = new HashSet<int>(EqualityComparer<int>.Default);
        v493 = new HashSet<int>(EqualityComparer<int>.Default);
        v489 = (0);
        for (; v489 < (ArrayItems.Length); v489++)
        {
            v491 = (ArrayItems[v489]);
            if (!(v490.Add((v491))))
                continue;
            v494 = (v491);
            if (!(v493.Add((v494))))
                continue;
            yield return (v494);
        }

        try
        {
            while (v492.MoveNext())
            {
                v491 = v492.Current;
                v494 = (v491);
                if (!(v493.Add((v494))))
                    continue;
                yield return (v494);
            }
        }
        finally
        {
            v492.Dispose();
        }

        yield break;
    }
}}