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
        int v171;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v172;
        int v173;
        v171 = (0);
        for (; v171 < (ArrayItems.Length); v171 += 1)
        {
            v172 = (ArrayItems[v171]);
            yield return (v172);
        }

        v173 = (0);
        for (; v173 < (ArrayItems2.Length); v173 += 1)
        {
            v172 = ArrayItems2[v173];
            yield return (v172);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v174;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v175;
        int v176;
        v176 = SimpleListItems2.Count;
        int v177;
        v174 = (0);
        for (; v174 < (ArrayItems.Length); v174 += 1)
        {
            v175 = (ArrayItems[v174]);
            yield return (v175);
        }

        v177 = (0);
        for (; v177 < (v176); v177 += 1)
        {
            v175 = SimpleListItems2[v177];
            yield return (v175);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v178;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v179;
        IEnumerator<int> v180;
        v180 = EnumerableItems2.GetEnumerator();
        v178 = (0);
        for (; v178 < (ArrayItems.Length); v178 += 1)
        {
            v179 = (ArrayItems[v178]);
            yield return (v179);
        }

        try
        {
            while (v180.MoveNext())
            {
                v179 = v180.Current;
                yield return (v179);
            }
        }
        finally
        {
            v180.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v181;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v182;
        IEnumerator<int> v183;
        v183 = MethodEnumerable2().GetEnumerator();
        v181 = (0);
        for (; v181 < (ArrayItems.Length); v181 += 1)
        {
            v182 = (ArrayItems[v181]);
            yield return (v182);
        }

        try
        {
            while (v183.MoveNext())
            {
                v182 = v183.Current;
                yield return (v182);
            }
        }
        finally
        {
            v183.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SimpleListConcatArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v184;
        v184 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v185;
        v185 = SimpleListItems;
        int v186;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v187;
        int v188;
        v186 = (0);
        for (; v186 < (v184); v186 += 1)
        {
            v187 = (v185[v186]);
            yield return (v187);
        }

        v188 = (0);
        for (; v188 < (ArrayItems2.Length); v188 += 1)
        {
            v187 = ArrayItems2[v188];
            yield return (v187);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SimpleListConcatSimpleListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v189;
        v189 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v190;
        v190 = SimpleListItems;
        int v191;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v192;
        int v193;
        v193 = SimpleListItems2.Count;
        int v194;
        v191 = (0);
        for (; v191 < (v189); v191 += 1)
        {
            v192 = (v190[v191]);
            yield return (v192);
        }

        v194 = (0);
        for (; v194 < (v193); v194 += 1)
        {
            v192 = SimpleListItems2[v194];
            yield return (v192);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SimpleListConcatEnumerableRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v195;
        v195 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v196;
        v196 = SimpleListItems;
        int v197;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v198;
        IEnumerator<int> v199;
        v199 = EnumerableItems2.GetEnumerator();
        v197 = (0);
        for (; v197 < (v195); v197 += 1)
        {
            v198 = (v196[v197]);
            yield return (v198);
        }

        try
        {
            while (v199.MoveNext())
            {
                v198 = v199.Current;
                yield return (v198);
            }
        }
        finally
        {
            v199.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SimpleListConcatMethodRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v200;
        v200 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v201;
        v201 = SimpleListItems;
        int v202;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v203;
        IEnumerator<int> v204;
        v204 = MethodEnumerable2().GetEnumerator();
        v202 = (0);
        for (; v202 < (v200); v202 += 1)
        {
            v203 = (v201[v202]);
            yield return (v203);
        }

        try
        {
            while (v204.MoveNext())
            {
                v203 = v204.Current;
                yield return (v203);
            }
        }
        finally
        {
            v204.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableConcatArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v205;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v206;
        int v207;
        v205 = EnumerableItems.GetEnumerator();
        try
        {
            while (v205.MoveNext())
            {
                v206 = (v205.Current);
                yield return (v206);
            }
        }
        finally
        {
            v205.Dispose();
        }

        v207 = (0);
        for (; v207 < (ArrayItems2.Length); v207 += 1)
        {
            v206 = ArrayItems2[v207];
            yield return (v206);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableConcatSimpleListRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v208;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v209;
        int v210;
        v210 = SimpleListItems2.Count;
        int v211;
        v208 = EnumerableItems.GetEnumerator();
        try
        {
            while (v208.MoveNext())
            {
                v209 = (v208.Current);
                yield return (v209);
            }
        }
        finally
        {
            v208.Dispose();
        }

        v211 = (0);
        for (; v211 < (v210); v211 += 1)
        {
            v209 = SimpleListItems2[v211];
            yield return (v209);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableConcatEnumerableRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v212;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v213;
        IEnumerator<int> v214;
        v212 = EnumerableItems.GetEnumerator();
        v214 = EnumerableItems2.GetEnumerator();
        try
        {
            while (v212.MoveNext())
            {
                v213 = (v212.Current);
                yield return (v213);
            }
        }
        finally
        {
            v212.Dispose();
        }

        try
        {
            while (v214.MoveNext())
            {
                v213 = v214.Current;
                yield return (v213);
            }
        }
        finally
        {
            v214.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableConcatMethodRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v215;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v216;
        IEnumerator<int> v217;
        v215 = EnumerableItems.GetEnumerator();
        v217 = MethodEnumerable2().GetEnumerator();
        try
        {
            while (v215.MoveNext())
            {
                v216 = (v215.Current);
                yield return (v216);
            }
        }
        finally
        {
            v215.Dispose();
        }

        try
        {
            while (v217.MoveNext())
            {
                v216 = v217.Current;
                yield return (v216);
            }
        }
        finally
        {
            v217.Dispose();
        }

        yield break;
    }

    int[] ArrayConcatArrayToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v218;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v219;
        int v220;
        int[] v221;
        int v222;
        v221 = new int[(ArrayItems2.Length + ArrayItems.Length)];
        v222 = 0;
        v218 = (0);
        for (; v218 < (ArrayItems.Length); v218 += 1)
        {
            v219 = (ArrayItems[v218]);
            v221[v222] = (v219);
            v222++;
        }

        v220 = (0);
        for (; v220 < (ArrayItems2.Length); v220 += 1)
        {
            v219 = ArrayItems2[v220];
            v221[v222] = (v219);
            v222++;
        }

        return v221;
    }

    int[] ArrayConcatSimpleListToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v223;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v224;
        int v225;
        v225 = SimpleListItems2.Count;
        int v226;
        int[] v227;
        int v228;
        v227 = new int[(v225 + ArrayItems.Length)];
        v228 = 0;
        v223 = (0);
        for (; v223 < (ArrayItems.Length); v223 += 1)
        {
            v224 = (ArrayItems[v223]);
            v227[v228] = (v224);
            v228++;
        }

        v226 = (0);
        for (; v226 < (v225); v226 += 1)
        {
            v224 = SimpleListItems2[v226];
            v227[v228] = (v224);
            v228++;
        }

        return v227;
    }

    int[] ArrayConcatEnumerableToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v229;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v230;
        IEnumerator<int> v231;
        int v232;
        int v233;
        int[] v234;
        v231 = EnumerableItems2.GetEnumerator();
        v232 = 0;
        v233 = 8;
        v234 = new int[8];
        v229 = (0);
        for (; v229 < (ArrayItems.Length); v229 += 1)
        {
            v230 = (ArrayItems[v229]);
            if (v232 >= v233)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v234, ref v233);
            v234[v232] = (v230);
            v232++;
        }

        try
        {
            while (v231.MoveNext())
            {
                v230 = v231.Current;
                if (v232 >= v233)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v234, ref v233);
                v234[v232] = (v230);
                v232++;
            }
        }
        finally
        {
            v231.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v234, v232);
    }

    int[] SimpleListConcatArrayToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v235;
        v235 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v236;
        v236 = SimpleListItems;
        int v237;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v238;
        int v239;
        int[] v240;
        int v241;
        v240 = new int[(ArrayItems2.Length + v235)];
        v241 = 0;
        v237 = (0);
        for (; v237 < (v235); v237 += 1)
        {
            v238 = (v236[v237]);
            v240[v241] = (v238);
            v241++;
        }

        v239 = (0);
        for (; v239 < (ArrayItems2.Length); v239 += 1)
        {
            v238 = ArrayItems2[v239];
            v240[v241] = (v238);
            v241++;
        }

        return v240;
    }

    int[] SimpleListConcatSimpleListToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v242;
        v242 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v243;
        v243 = SimpleListItems;
        int v244;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v245;
        int v246;
        v246 = SimpleListItems2.Count;
        int v247;
        int[] v248;
        int v249;
        v248 = new int[(v246 + v242)];
        v249 = 0;
        v244 = (0);
        for (; v244 < (v242); v244 += 1)
        {
            v245 = (v243[v244]);
            v248[v249] = (v245);
            v249++;
        }

        v247 = (0);
        for (; v247 < (v246); v247 += 1)
        {
            v245 = SimpleListItems2[v247];
            v248[v249] = (v245);
            v249++;
        }

        return v248;
    }

    int[] SimpleListConcatEnumerableToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v250;
        v250 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v251;
        v251 = SimpleListItems;
        int v252;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v253;
        IEnumerator<int> v254;
        int v255;
        int v256;
        int[] v257;
        v254 = EnumerableItems2.GetEnumerator();
        v255 = 0;
        v256 = 8;
        v257 = new int[8];
        v252 = (0);
        for (; v252 < (v250); v252 += 1)
        {
            v253 = (v251[v252]);
            if (v255 >= v256)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v257, ref v256);
            v257[v255] = (v253);
            v255++;
        }

        try
        {
            while (v254.MoveNext())
            {
                v253 = v254.Current;
                if (v255 >= v256)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v257, ref v256);
                v257[v255] = (v253);
                v255++;
            }
        }
        finally
        {
            v254.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v257, v255);
    }

    int[] EnumerableConcatArrayToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v258;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v259;
        int v260;
        int v261;
        int v262;
        int[] v263;
        v258 = EnumerableItems.GetEnumerator();
        v261 = 0;
        v262 = 8;
        v263 = new int[8];
        try
        {
            while (v258.MoveNext())
            {
                v259 = (v258.Current);
                if (v261 >= v262)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v263, ref v262);
                v263[v261] = (v259);
                v261++;
            }
        }
        finally
        {
            v258.Dispose();
        }

        v260 = (0);
        for (; v260 < (ArrayItems2.Length); v260 += 1)
        {
            v259 = ArrayItems2[v260];
            if (v261 >= v262)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v263, ref v262);
            v263[v261] = (v259);
            v261++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v263, v261);
    }

    int[] EnumerableConcatSimpleListToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v264;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v265;
        int v266;
        v266 = SimpleListItems2.Count;
        int v267;
        int v268;
        int v269;
        int[] v270;
        v264 = EnumerableItems.GetEnumerator();
        v268 = 0;
        v269 = 8;
        v270 = new int[8];
        try
        {
            while (v264.MoveNext())
            {
                v265 = (v264.Current);
                if (v268 >= v269)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v270, ref v269);
                v270[v268] = (v265);
                v268++;
            }
        }
        finally
        {
            v264.Dispose();
        }

        v267 = (0);
        for (; v267 < (v266); v267 += 1)
        {
            v265 = SimpleListItems2[v267];
            if (v268 >= v269)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v270, ref v269);
            v270[v268] = (v265);
            v268++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v270, v268);
    }

    int[] EnumerableConcatEnumerableToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v271;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v272;
        IEnumerator<int> v273;
        int v274;
        int v275;
        int[] v276;
        v271 = EnumerableItems.GetEnumerator();
        v273 = EnumerableItems2.GetEnumerator();
        v274 = 0;
        v275 = 8;
        v276 = new int[8];
        try
        {
            while (v271.MoveNext())
            {
                v272 = (v271.Current);
                if (v274 >= v275)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v276, ref v275);
                v276[v274] = (v272);
                v274++;
            }
        }
        finally
        {
            v271.Dispose();
        }

        try
        {
            while (v273.MoveNext())
            {
                v272 = v273.Current;
                if (v274 >= v275)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v276, ref v275);
                v276[v274] = (v272);
                v274++;
            }
        }
        finally
        {
            v273.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v276, v274);
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectConcatArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v277;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v278;
        int v279;
        v277 = (0);
        for (; v277 < (ArrayItems.Length); v277 += 1)
        {
            v278 = (50 + ArrayItems[v277]);
            yield return (v278);
        }

        v279 = (0);
        for (; v279 < (ArrayItems2.Length); v279 += 1)
        {
            v278 = ArrayItems2[v279];
            yield return (v278);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectConcatArraySelectRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v281;
        v281 = (0);
        for (; v281 < (ArrayItems2.Length); v281 += 1)
            yield return (((ArrayItems2[v281]) + 50));
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectConcatArraySelectRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v282;
        if (ArraySelectConcatArraySelectRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v283;
        IEnumerator<int> v284;
        v284 = ArraySelectConcatArraySelectRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v282 = (0);
        for (; v282 < (ArrayItems.Length); v282 += 1)
        {
            v283 = (50 + ArrayItems[v282]);
            yield return (v283);
        }

        try
        {
            while (v284.MoveNext())
            {
                v283 = v284.Current;
                yield return (v283);
            }
        }
        finally
        {
            v284.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereConcatArrayWhereRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v285;
        v285 = (0);
        for (; v285 < (ArrayItems2.Length); v285 += 1)
        {
            if (!((((ArrayItems2[v285])) > 50)))
                continue;
            yield return ((ArrayItems2[v285]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereConcatArrayWhereRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v286;
        if (ArrayWhereConcatArrayWhereRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v287;
        IEnumerator<int> v288;
        v288 = ArrayWhereConcatArrayWhereRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v286 = (0);
        for (; v286 < (ArrayItems.Length); v286 += 1)
        {
            if (!((((ArrayItems[v286])) > 50)))
                continue;
            v287 = ((ArrayItems[v286]));
            yield return (v287);
        }

        try
        {
            while (v288.MoveNext())
            {
                v287 = v288.Current;
                yield return (v287);
            }
        }
        finally
        {
            v288.Dispose();
        }

        yield break;
    }

    int ArrayConcatArrayCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v289;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v290;
        int v291;
        int v292;
        v292 = 0;
        v289 = (0);
        for (; v289 < (ArrayItems.Length); v289 += 1)
        {
            v290 = (ArrayItems[v289]);
            v292++;
        }

        v291 = (0);
        for (; v291 < (ArrayItems2.Length); v291 += 1)
        {
            v290 = ArrayItems2[v291];
            v292++;
        }

        return v292;
    }

    int ArrayConcatArrayCount2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v293;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v294;
        int v295;
        int v296;
        v296 = 0;
        v293 = (0);
        for (; v293 < (ArrayItems.Length); v293 += 1)
        {
            v294 = (ArrayItems[v293]);
            if (!(((v294) > 70)))
                continue;
            v296++;
        }

        v295 = (0);
        for (; v295 < (ArrayItems2.Length); v295 += 1)
        {
            v294 = ArrayItems2[v295];
            if (!(((v294) > 70)))
                continue;
            v296++;
        }

        return v296;
    }

    int ArrayConcatArraySumRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v297;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v298;
        int v299;
        int v300;
        v300 = 0;
        v297 = (0);
        for (; v297 < (ArrayItems.Length); v297 += 1)
        {
            v298 = (ArrayItems[v297]);
            v300 += (v298);
        }

        v299 = (0);
        for (; v299 < (ArrayItems2.Length); v299 += 1)
        {
            v298 = ArrayItems2[v299];
            v300 += (v298);
        }

        return v300;
    }

    int ArrayConcatArraySum2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v301;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v302;
        int v303;
        int v304;
        v304 = 0;
        v301 = (0);
        for (; v301 < (ArrayItems.Length); v301 += 1)
        {
            v302 = (ArrayItems[v301]);
            v304 += ((v302) + 10);
        }

        v303 = (0);
        for (; v303 < (ArrayItems2.Length); v303 += 1)
        {
            v302 = ArrayItems2[v303];
            v304 += ((v302) + 10);
        }

        return v304;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v305;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v306;
        int v307;
        HashSet<int> v308;
        v308 = new HashSet<int>();
        v305 = (0);
        for (; v305 < (ArrayItems.Length); v305 += 1)
        {
            v306 = (ArrayItems[v305]);
            if (!(v308.Add(((v306)))))
                continue;
            yield return ((v306));
        }

        v307 = (0);
        for (; v307 < (ArrayItems2.Length); v307 += 1)
        {
            v306 = ArrayItems2[v307];
            if (!(v308.Add(((v306)))))
                continue;
            yield return ((v306));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatArrayDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v309;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v310;
        int v311;
        HashSet<int> v312;
        v312 = new HashSet<int>(EqualityComparer<int>.Default);
        v309 = (0);
        for (; v309 < (ArrayItems.Length); v309 += 1)
        {
            v310 = (ArrayItems[v309]);
            if (!(v312.Add(((v310)))))
                continue;
            yield return ((v310));
        }

        v311 = (0);
        for (; v311 < (ArrayItems2.Length); v311 += 1)
        {
            v310 = ArrayItems2[v311];
            if (!(v312.Add(((v310)))))
                continue;
            yield return ((v310));
        }

        yield break;
    }

    int ArrayConcatArrayElementAtRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v313;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v314;
        int v315;
        int v316;
        v316 = 0;
        v313 = (0);
        for (; v313 < (ArrayItems.Length); v313 += 1)
        {
            v314 = (ArrayItems[v313]);
            if (v316 == 45)
                return (v314);
            v316++;
        }

        v315 = (0);
        for (; v315 < (ArrayItems2.Length); v315 += 1)
        {
            v314 = ArrayItems2[v315];
            if (v316 == 45)
                return (v314);
            v316++;
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArrayConcatArrayElementAtOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v317;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v318;
        int v319;
        int v320;
        v320 = 0;
        v317 = (0);
        for (; v317 < (ArrayItems.Length); v317 += 1)
        {
            v318 = (ArrayItems[v317]);
            if (v320 == 45)
                return (v318);
            v320++;
        }

        v319 = (0);
        for (; v319 < (ArrayItems2.Length); v319 += 1)
        {
            v318 = ArrayItems2[v319];
            if (v320 == 45)
                return (v318);
            v320++;
        }

        return default(int);
    }

    int ArrayConcatArrayFirstRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v321;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v322;
        int v323;
        v321 = (0);
        for (; v321 < (ArrayItems.Length); v321 += 1)
        {
            v322 = (ArrayItems[v321]);
            return (v322);
        }

        v323 = (0);
        for (; v323 < (ArrayItems2.Length); v323 += 1)
        {
            v322 = ArrayItems2[v323];
            return (v322);
        }

        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int ArrayConcatArrayFirstOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v324;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v325;
        int v326;
        v324 = (0);
        for (; v324 < (ArrayItems.Length); v324 += 1)
        {
            v325 = (ArrayItems[v324]);
            return (v325);
        }

        v326 = (0);
        for (; v326 < (ArrayItems2.Length); v326 += 1)
        {
            v325 = ArrayItems2[v326];
            return (v325);
        }

        return default(int);
    }

    int ArrayConcatArrayLastRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v327;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v328;
        int v329;
        int? v330;
        v330 = null;
        v327 = (0);
        for (; v327 < (ArrayItems.Length); v327 += 1)
        {
            v328 = (ArrayItems[v327]);
            v330 = (v328);
        }

        v329 = (0);
        for (; v329 < (ArrayItems2.Length); v329 += 1)
        {
            v328 = ArrayItems2[v329];
            v330 = (v328);
        }

        if (v330 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v330;
    }

    int ArrayConcatArrayLastOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v331;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v332;
        int v333;
        int? v334;
        v334 = null;
        v331 = (0);
        for (; v331 < (ArrayItems.Length); v331 += 1)
        {
            v332 = (ArrayItems[v331]);
            v334 = (v332);
        }

        v333 = (0);
        for (; v333 < (ArrayItems2.Length); v333 += 1)
        {
            v332 = ArrayItems2[v333];
            v334 = (v332);
        }

        if (v334 == null)
            return default(int);
        else
            return (int)v334;
    }

    int ArrayConcatArraySingleRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v335;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v336;
        int v337;
        int? v338;
        v338 = null;
        v335 = (0);
        for (; v335 < (ArrayItems.Length); v335 += 1)
        {
            v336 = (ArrayItems[v335]);
            if (v338 == null)
                v338 = (v336);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        v337 = (0);
        for (; v337 < (ArrayItems2.Length); v337 += 1)
        {
            v336 = ArrayItems2[v337];
            if (v338 == null)
                v338 = (v336);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v338 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v338;
    }

    int ArrayConcatArraySingle2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v339;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v340;
        int v341;
        int? v342;
        v342 = null;
        v339 = (0);
        for (; v339 < (ArrayItems.Length); v339 += 1)
        {
            v340 = (ArrayItems[v339]);
            if (((v340) == 76))
                if (v342 == null)
                    v342 = (v340);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        v341 = (0);
        for (; v341 < (ArrayItems2.Length); v341 += 1)
        {
            v340 = ArrayItems2[v341];
            if (((v340) == 76))
                if (v342 == null)
                    v342 = (v340);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v342 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v342;
    }

    int ArrayConcatArraySingleOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v343;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v344;
        int v345;
        int? v346;
        v346 = null;
        v343 = (0);
        for (; v343 < (ArrayItems.Length); v343 += 1)
        {
            v344 = (ArrayItems[v343]);
            if (v346 == null)
                v346 = (v344);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        v345 = (0);
        for (; v345 < (ArrayItems2.Length); v345 += 1)
        {
            v344 = ArrayItems2[v345];
            if (v346 == null)
                v346 = (v344);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v346 == null)
            return default(int);
        else
            return (int)v346;
    }

    int ArrayConcatArrayMinRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v347;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v348;
        int v349;
        if (1 > (ArrayItems2.Length + ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        int v350;
        v350 = 2147483647;
        v347 = (0);
        for (; v347 < (ArrayItems.Length); v347 += 1)
        {
            v348 = (ArrayItems[v347]);
            if ((v348) >= v350)
                continue;
            v350 = (v348);
        }

        v349 = (0);
        for (; v349 < (ArrayItems2.Length); v349 += 1)
        {
            v348 = ArrayItems2[v349];
            if ((v348) >= v350)
                continue;
            v350 = (v348);
        }

        return v350;
    }

    decimal ArrayConcatArrayMin2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v351;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v352;
        int v353;
        if (1 > (ArrayItems2.Length + ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        decimal v354;
        decimal v355;
        v354 = 79228162514264337593543950335M;
        v351 = (0);
        for (; v351 < (ArrayItems.Length); v351 += 1)
        {
            v352 = (ArrayItems[v351]);
            v355 = ((v352) + 2m);
            if (v355 >= v354)
                continue;
            v354 = v355;
        }

        v353 = (0);
        for (; v353 < (ArrayItems2.Length); v353 += 1)
        {
            v352 = ArrayItems2[v353];
            v355 = ((v352) + 2m);
            if (v355 >= v354)
                continue;
            v354 = v355;
        }

        return v354;
    }

    int ArrayConcatArrayMaxRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v356;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v357;
        int v358;
        if (1 > (ArrayItems2.Length + ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        int v359;
        v359 = -2147483648;
        v356 = (0);
        for (; v356 < (ArrayItems.Length); v356 += 1)
        {
            v357 = (ArrayItems[v356]);
            if ((v357) <= v359)
                continue;
            v359 = (v357);
        }

        v358 = (0);
        for (; v358 < (ArrayItems2.Length); v358 += 1)
        {
            v357 = ArrayItems2[v358];
            if ((v357) <= v359)
                continue;
            v359 = (v357);
        }

        return v359;
    }

    decimal ArrayConcatArrayMax2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v360;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v361;
        int v362;
        if (1 > (ArrayItems2.Length + ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        decimal v363;
        decimal v364;
        v363 = -79228162514264337593543950335M;
        v360 = (0);
        for (; v360 < (ArrayItems.Length); v360 += 1)
        {
            v361 = (ArrayItems[v360]);
            v364 = ((v361) + 2m);
            if (v364 <= v363)
                continue;
            v363 = v364;
        }

        v362 = (0);
        for (; v362 < (ArrayItems2.Length); v362 += 1)
        {
            v361 = ArrayItems2[v362];
            v364 = ((v361) + 2m);
            if (v364 <= v363)
                continue;
            v363 = v364;
        }

        return v363;
    }

    long ArrayConcatArrayLongCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v365;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v366;
        int v367;
        long v368;
        v368 = 0;
        v365 = (0);
        for (; v365 < (ArrayItems.Length); v365 += 1)
        {
            v366 = (ArrayItems[v365]);
            v368++;
        }

        v367 = (0);
        for (; v367 < (ArrayItems2.Length); v367 += 1)
        {
            v366 = ArrayItems2[v367];
            v368++;
        }

        return v368;
    }

    long ArrayConcatArrayLongCount2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v369;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v370;
        int v371;
        long v372;
        v372 = 0;
        v369 = (0);
        for (; v369 < (ArrayItems.Length); v369 += 1)
        {
            v370 = (ArrayItems[v369]);
            if (!(((v370) > 50)))
                continue;
            v372++;
        }

        v371 = (0);
        for (; v371 < (ArrayItems2.Length); v371 += 1)
        {
            v370 = ArrayItems2[v371];
            if (!(((v370) > 50)))
                continue;
            v372++;
        }

        return v372;
    }

    bool ArrayConcatArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v373;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v374;
        int v375;
        v373 = (0);
        for (; v373 < (ArrayItems.Length); v373 += 1)
        {
            v374 = (ArrayItems[v373]);
            if ((v374) == 56)
                return true;
        }

        v375 = (0);
        for (; v375 < (ArrayItems2.Length); v375 += 1)
        {
            v374 = ArrayItems2[v375];
            if ((v374) == 56)
                return true;
        }

        return false;
    }

    double ArrayConcatArrayAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v376;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v377;
        int v378;
        double v379;
        if (1 > (ArrayItems2.Length + ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        v379 = 0;
        v376 = (0);
        for (; v376 < (ArrayItems.Length); v376 += 1)
        {
            v377 = (ArrayItems[v376]);
            v379 += (v377);
        }

        v378 = (0);
        for (; v378 < (ArrayItems2.Length); v378 += 1)
        {
            v377 = ArrayItems2[v378];
            v379 += (v377);
        }

        return (v379 / (ArrayItems2.Length + ArrayItems.Length));
    }

    double ArrayConcatArrayAverage2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v380;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v381;
        int v382;
        double v383;
        if (1 > (ArrayItems2.Length + ArrayItems.Length))
            throw new System.InvalidOperationException("Index out of range");
        v383 = 0;
        v380 = (0);
        for (; v380 < (ArrayItems.Length); v380 += 1)
        {
            v381 = (ArrayItems[v380]);
            v383 += ((v381) + 10);
        }

        v382 = (0);
        for (; v382 < (ArrayItems2.Length); v382 += 1)
        {
            v381 = ArrayItems2[v382];
            v383 += ((v381) + 10);
        }

        return (v383 / (ArrayItems2.Length + ArrayItems.Length));
    }

    bool ArrayConcatArrayContains2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v384;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v385;
        int v386;
        System.Collections.Generic.EqualityComparer<int> v387;
        v387 = EqualityComparer<int>.Default;
        v384 = (0);
        for (; v384 < (ArrayItems.Length); v384 += 1)
        {
            v385 = (ArrayItems[v384]);
            if (v387.Equals((v385), 56))
                return true;
        }

        v386 = (0);
        for (; v386 < (ArrayItems2.Length); v386 += 1)
        {
            v385 = ArrayItems2[v386];
            if (v387.Equals((v385), 56))
                return true;
        }

        return false;
    }

    System.Collections.Generic.IEnumerable<int> SelectWhereArrayConcatSelectWhereArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v388;
        int v389;
        v388 = (0);
        for (; v388 < (ArrayItems2.Length); v388 += 1)
        {
            v389 = (((ArrayItems2[v388]) + 10));
            if (!(((v389) > 80)))
                continue;
            yield return (v389);
        }

        yield break;
    }

    bool SelectWhereArrayConcatSelectWhereArrayContainsRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v390;
        int v391;
        if (SelectWhereArrayConcatSelectWhereArrayContainsRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v392;
        v392 = SelectWhereArrayConcatSelectWhereArrayContainsRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v390 = (0);
        for (; v390 < (ArrayItems.Length); v390 += 1)
        {
            v391 = (10 + ArrayItems[v390]);
            if (!(((v391) > 80)))
                continue;
            if ((v391) == 112)
                return true;
        }

        try
        {
            while (v392.MoveNext())
            {
                v391 = v392.Current;
                if ((v391) == 112)
                    return true;
            }
        }
        finally
        {
            v392.Dispose();
        }

        return false;
    }

    System.Collections.Generic.IEnumerable<int> RangeConcatArrayRewritten_ProceduralLinq1()
    {
        int v393;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v394;
        int v395;
        v393 = (0);
        for (; v393 < (100); v393 += (1))
        {
            v394 = (20 + v393);
            yield return (v394);
        }

        v395 = (0);
        for (; v395 < (ArrayItems2.Length); v395 += 1)
        {
            v394 = ArrayItems2[v395];
            yield return (v394);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RepeatConcatArrayRewritten_ProceduralLinq1()
    {
        int v396;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v397;
        int v398;
        v396 = (0);
        for (; v396 < (100); v396 += 1)
        {
            v397 = (20);
            yield return (v397);
        }

        v398 = (0);
        for (; v398 < (ArrayItems2.Length); v398 += 1)
        {
            v397 = ArrayItems2[v398];
            yield return (v397);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EmptyConcatArrayRewritten_ProceduralLinq1()
    {
        int v399;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v400;
        int v401;
        v399 = 0;
        v401 = (0);
        for (; v401 < (ArrayItems2.Length); v401 += 1)
        {
            v400 = ArrayItems2[v401];
            yield return (v400);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeEmpty2ArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v402;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v403;
        int v404;
        v402 = (0);
        for (; v402 < (ArrayItems.Length); v402 += 1)
        {
            if (!((false)))
                continue;
            v403 = ((ArrayItems[v402]));
            yield return (v403);
        }

        v404 = (0);
        for (; v404 < (ArrayItems2.Length); v404 += 1)
        {
            v403 = ArrayItems2[v404];
            yield return (v403);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatRangeRewritten_ProceduralLinq1()
    {
        int v405;
        v405 = (0);
        for (; v405 < (260); v405 += (1))
            yield return (70 + v405);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatRangeRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v406;
        if (ArrayConcatRangeRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v407;
        IEnumerator<int> v408;
        v408 = ArrayConcatRangeRewritten_ProceduralLinq1().GetEnumerator();
        v406 = (0);
        for (; v406 < (ArrayItems.Length); v406 += 1)
        {
            v407 = (ArrayItems[v406]);
            yield return (v407);
        }

        try
        {
            while (v408.MoveNext())
            {
                v407 = v408.Current;
                yield return (v407);
            }
        }
        finally
        {
            v408.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatRepeatRewritten_ProceduralLinq1()
    {
        int v409;
        v409 = (0);
        for (; v409 < (100); v409 += 1)
            yield return (70);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatRepeatRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v410;
        if (ArrayConcatRepeatRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v411;
        IEnumerator<int> v412;
        v412 = ArrayConcatRepeatRewritten_ProceduralLinq1().GetEnumerator();
        v410 = (0);
        for (; v410 < (ArrayItems.Length); v410 += 1)
        {
            v411 = (ArrayItems[v410]);
            yield return (v411);
        }

        try
        {
            while (v412.MoveNext())
            {
                v411 = v412.Current;
                yield return (v411);
            }
        }
        finally
        {
            v412.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatEmptyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v413;
        if (Enumerable.Empty<int>() == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v414;
        IEnumerator<int> v415;
        v415 = Enumerable.Empty<int>().GetEnumerator();
        v413 = (0);
        for (; v413 < (ArrayItems.Length); v413 += 1)
        {
            v414 = (ArrayItems[v413]);
            yield return (v414);
        }

        try
        {
            while (v415.MoveNext())
            {
                v414 = v415.Current;
                yield return (v414);
            }
        }
        finally
        {
            v415.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatEmpty2Rewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v416;
        v416 = (0);
        for (; v416 < (ArrayItems2.Length); v416 += 1)
        {
            if (!((false)))
                continue;
            yield return ((ArrayItems2[v416]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatEmpty2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v417;
        if (ArrayConcatEmpty2Rewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v418;
        IEnumerator<int> v419;
        v419 = ArrayConcatEmpty2Rewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v417 = (0);
        for (; v417 < (ArrayItems.Length); v417 += 1)
        {
            v418 = (ArrayItems[v417]);
            yield return (v418);
        }

        try
        {
            while (v419.MoveNext())
            {
                v418 = v419.Current;
                yield return (v418);
            }
        }
        finally
        {
            v419.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatAllRewritten_ProceduralLinq1()
    {
        int v420;
        v420 = (0);
        for (; v420 < (1000); v420 += (1))
            yield return (v420);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatAllRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v421;
        if (ArrayConcatAllRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v422;
        IEnumerator<int> v423;
        v423 = ArrayConcatAllRewritten_ProceduralLinq1().GetEnumerator();
        v421 = (0);
        for (; v421 < (ArrayItems.Length); v421 += 1)
        {
            v422 = (ArrayItems[v421]);
            yield return (v422);
        }

        try
        {
            while (v423.MoveNext())
            {
                v422 = v423.Current;
                yield return (v422);
            }
        }
        finally
        {
            v423.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatNullRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v424;
        throw new System.InvalidOperationException("Invalid null object");
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatArrayConcatEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v425;
        if (ArrayItems == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v426;
        int v427;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v428;
        v428 = EnumerableItems2.GetEnumerator();
        v425 = (0);
        for (; v425 < (ArrayItems.Length); v425 += 1)
        {
            v426 = (ArrayItems[v425]);
            yield return (v426);
        }

        v427 = (0);
        for (; v427 < (ArrayItems.Length); v427 += 1)
        {
            v426 = ArrayItems[v427];
            yield return (v426);
        }

        try
        {
            while (v428.MoveNext())
            {
                v426 = v428.Current;
                yield return (v426);
            }
        }
        finally
        {
            v428.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatArrayConcatEnumerable2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v429;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v430;
        IEnumerator<int> v431;
        v431 = EnumerableItems2.GetEnumerator();
        v429 = (0);
        for (; v429 < (ArrayItems.Length); v429 += 1)
        {
            v430 = (ArrayItems[v429]);
            yield return (v430);
        }

        try
        {
            while (v431.MoveNext())
            {
                v430 = v431.Current;
                yield return (v430);
            }
        }
        finally
        {
            v431.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatArrayConcatEnumerable2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v432;
        if (ArrayConcatArrayConcatEnumerable2Rewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v433;
        IEnumerator<int> v434;
        v434 = ArrayConcatArrayConcatEnumerable2Rewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v432 = (0);
        for (; v432 < (ArrayItems.Length); v432 += 1)
        {
            v433 = (ArrayItems[v432]);
            yield return (v433);
        }

        try
        {
            while (v434.MoveNext())
            {
                v433 = v434.Current;
                yield return (v433);
            }
        }
        finally
        {
            v434.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctConcatArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v435;
        HashSet<int> v436;
        v436 = new HashSet<int>();
        v435 = (0);
        for (; v435 < (ArrayItems.Length); v435 += 1)
        {
            if (!(v436.Add(((ArrayItems[v435])))))
                continue;
            yield return ((ArrayItems[v435]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctConcatArrayDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v437;
        HashSet<int> v438;
        if (ArrayDistinctConcatArrayDistinctRewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v439;
        IEnumerator<int> v440;
        v440 = ArrayDistinctConcatArrayDistinctRewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v438 = new HashSet<int>();
        v437 = (0);
        for (; v437 < (ArrayItems.Length); v437 += 1)
        {
            if (!(v438.Add(((ArrayItems[v437])))))
                continue;
            v439 = ((ArrayItems[v437]));
            yield return (v439);
        }

        try
        {
            while (v440.MoveNext())
            {
                v439 = v440.Current;
                yield return (v439);
            }
        }
        finally
        {
            v440.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v441;
        HashSet<int> v442;
        v442 = new HashSet<int>();
        v441 = (0);
        for (; v441 < (ArrayItems.Length); v441 += 1)
        {
            if (!(v442.Add(((ArrayItems[v441])))))
                continue;
            yield return ((ArrayItems[v441]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v443;
        HashSet<int> v444;
        if (ArrayDistinctConcatArrayDistinctDistinctRewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v445;
        IEnumerator<int> v446;
        HashSet<int> v447;
        v446 = ArrayDistinctConcatArrayDistinctDistinctRewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v444 = new HashSet<int>();
        v447 = new HashSet<int>();
        v443 = (0);
        for (; v443 < (ArrayItems.Length); v443 += 1)
        {
            if (!(v444.Add(((ArrayItems[v443])))))
                continue;
            v445 = ((ArrayItems[v443]));
            if (!(v447.Add(((v445)))))
                continue;
            yield return ((v445));
        }

        try
        {
            while (v446.MoveNext())
            {
                v445 = v446.Current;
                if (!(v447.Add(((v445)))))
                    continue;
                yield return ((v445));
            }
        }
        finally
        {
            v446.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v448;
        HashSet<int> v449;
        v449 = new HashSet<int>(EqualityComparer<int>.Default);
        v448 = (0);
        for (; v448 < (ArrayItems.Length); v448 += 1)
        {
            if (!(v449.Add(((ArrayItems[v448])))))
                continue;
            yield return ((ArrayItems[v448]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinct2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v450;
        HashSet<int> v451;
        if (ArrayDistinctConcatArrayDistinctDistinct2Rewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v452;
        IEnumerator<int> v453;
        HashSet<int> v454;
        v453 = ArrayDistinctConcatArrayDistinctDistinct2Rewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v451 = new HashSet<int>(EqualityComparer<int>.Default);
        v454 = new HashSet<int>(EqualityComparer<int>.Default);
        v450 = (0);
        for (; v450 < (ArrayItems.Length); v450 += 1)
        {
            if (!(v451.Add(((ArrayItems[v450])))))
                continue;
            v452 = ((ArrayItems[v450]));
            if (!(v454.Add(((v452)))))
                continue;
            yield return ((v452));
        }

        try
        {
            while (v453.MoveNext())
            {
                v452 = v453.Current;
                if (!(v454.Add(((v452)))))
                    continue;
                yield return ((v452));
            }
        }
        finally
        {
            v453.Dispose();
        }

        yield break;
    }
}}