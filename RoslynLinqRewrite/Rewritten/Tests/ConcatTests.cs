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
        return (ArrayItems2.Length + ArrayItems.Length);
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
        return ArrayItems[0];
    } //EndMethod

    [NoRewrite]
    public int ArrayConcatArrayFirstOrDefault()
    {
        return ArrayItems.Concat(ArrayItems2).FirstOrDefault();
    } //EndMethod

    public int ArrayConcatArrayFirstOrDefaultRewritten()
    {
        return ArrayItems.Length == 0 ? default(int) : ArrayItems[0];
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
        return (long)(ArrayItems2.Length + ArrayItems.Length);
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
        int v135;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v136;
        int v137;
        v135 = 0;
        for (; v135 < ArrayItems.Length; v135++)
        {
            v136 = ArrayItems[v135];
            yield return v136;
        }

        v137 = 0;
        for (; v137 < ArrayItems2.Length; v137++)
        {
            v136 = ArrayItems2[v137];
            yield return v136;
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v138;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v139;
        IEnumerator<int> v140;
        v140 = SimpleListItems2.GetEnumerator();
        v138 = 0;
        for (; v138 < ArrayItems.Length; v138++)
        {
            v139 = ArrayItems[v138];
            yield return v139;
        }

        try
        {
            while (v140.MoveNext())
            {
                v139 = v140.Current;
                yield return v139;
            }
        }
        finally
        {
            v140.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v141;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v142;
        IEnumerator<int> v143;
        v143 = EnumerableItems2.GetEnumerator();
        v141 = 0;
        for (; v141 < ArrayItems.Length; v141++)
        {
            v142 = ArrayItems[v141];
            yield return v142;
        }

        try
        {
            while (v143.MoveNext())
            {
                v142 = v143.Current;
                yield return v142;
            }
        }
        finally
        {
            v143.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v144;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v145;
        IEnumerator<int> v146;
        v146 = MethodEnumerable2().GetEnumerator();
        v144 = 0;
        for (; v144 < ArrayItems.Length; v144++)
        {
            v145 = ArrayItems[v144];
            yield return v145;
        }

        try
        {
            while (v146.MoveNext())
            {
                v145 = v146.Current;
                yield return v145;
            }
        }
        finally
        {
            v146.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> SimpleListConcatArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v147;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v148;
        int v149;
        v147 = SimpleListItems.GetEnumerator();
        try
        {
            while (v147.MoveNext())
            {
                v148 = v147.Current;
                yield return v148;
            }
        }
        finally
        {
            v147.Dispose();
        }

        v149 = 0;
        for (; v149 < ArrayItems2.Length; v149++)
        {
            v148 = ArrayItems2[v149];
            yield return v148;
        }
    }

    System.Collections.Generic.IEnumerable<int> SimpleListConcatSimpleListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v150;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v151;
        IEnumerator<int> v152;
        v150 = SimpleListItems.GetEnumerator();
        v152 = SimpleListItems2.GetEnumerator();
        try
        {
            while (v150.MoveNext())
            {
                v151 = v150.Current;
                yield return v151;
            }
        }
        finally
        {
            v150.Dispose();
        }

        try
        {
            while (v152.MoveNext())
            {
                v151 = v152.Current;
                yield return v151;
            }
        }
        finally
        {
            v152.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> SimpleListConcatEnumerableRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v153;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v154;
        IEnumerator<int> v155;
        v153 = SimpleListItems.GetEnumerator();
        v155 = EnumerableItems2.GetEnumerator();
        try
        {
            while (v153.MoveNext())
            {
                v154 = v153.Current;
                yield return v154;
            }
        }
        finally
        {
            v153.Dispose();
        }

        try
        {
            while (v155.MoveNext())
            {
                v154 = v155.Current;
                yield return v154;
            }
        }
        finally
        {
            v155.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> SimpleListConcatMethodRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v156;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v157;
        IEnumerator<int> v158;
        v156 = SimpleListItems.GetEnumerator();
        v158 = MethodEnumerable2().GetEnumerator();
        try
        {
            while (v156.MoveNext())
            {
                v157 = v156.Current;
                yield return v157;
            }
        }
        finally
        {
            v156.Dispose();
        }

        try
        {
            while (v158.MoveNext())
            {
                v157 = v158.Current;
                yield return v157;
            }
        }
        finally
        {
            v158.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableConcatArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v159;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v160;
        int v161;
        v159 = EnumerableItems.GetEnumerator();
        try
        {
            while (v159.MoveNext())
            {
                v160 = v159.Current;
                yield return v160;
            }
        }
        finally
        {
            v159.Dispose();
        }

        v161 = 0;
        for (; v161 < ArrayItems2.Length; v161++)
        {
            v160 = ArrayItems2[v161];
            yield return v160;
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableConcatSimpleListRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v162;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v163;
        IEnumerator<int> v164;
        v162 = EnumerableItems.GetEnumerator();
        v164 = SimpleListItems2.GetEnumerator();
        try
        {
            while (v162.MoveNext())
            {
                v163 = v162.Current;
                yield return v163;
            }
        }
        finally
        {
            v162.Dispose();
        }

        try
        {
            while (v164.MoveNext())
            {
                v163 = v164.Current;
                yield return v163;
            }
        }
        finally
        {
            v164.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableConcatEnumerableRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v165;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v166;
        IEnumerator<int> v167;
        v165 = EnumerableItems.GetEnumerator();
        v167 = EnumerableItems2.GetEnumerator();
        try
        {
            while (v165.MoveNext())
            {
                v166 = v165.Current;
                yield return v166;
            }
        }
        finally
        {
            v165.Dispose();
        }

        try
        {
            while (v167.MoveNext())
            {
                v166 = v167.Current;
                yield return v166;
            }
        }
        finally
        {
            v167.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableConcatMethodRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v168;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v169;
        IEnumerator<int> v170;
        v168 = EnumerableItems.GetEnumerator();
        v170 = MethodEnumerable2().GetEnumerator();
        try
        {
            while (v168.MoveNext())
            {
                v169 = v168.Current;
                yield return v169;
            }
        }
        finally
        {
            v168.Dispose();
        }

        try
        {
            while (v170.MoveNext())
            {
                v169 = v170.Current;
                yield return v169;
            }
        }
        finally
        {
            v170.Dispose();
        }
    }

    int[] ArrayConcatArrayToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v171;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v172;
        int v173;
        int[] v174;
        v174 = new int[(ArrayItems2.Length + ArrayItems.Length)];
        v171 = 0;
        for (; v171 < ArrayItems.Length; v171++)
        {
            v172 = ArrayItems[v171];
            v174[v171] = v172;
        }

        v173 = 0;
        for (; v173 < ArrayItems2.Length; v173++)
        {
            v172 = ArrayItems2[v173];
            v174[v171] = v172;
            v171++;
        }

        return v174;
    }

    int[] ArrayConcatSimpleListToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v175;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v176;
        IEnumerator<int> v177;
        int v178;
        int v179;
        int[] v180;
        v177 = SimpleListItems2.GetEnumerator();
        v178 = 0;
        v179 = 8;
        v180 = new int[8];
        v175 = 0;
        for (; v175 < ArrayItems.Length; v175++)
        {
            v176 = ArrayItems[v175];
            if (v178 >= v179)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v180, ref v179);
            v180[v178] = v176;
            v178++;
        }

        try
        {
            while (v177.MoveNext())
            {
                v176 = v177.Current;
                if (v178 >= v179)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v180, ref v179);
                v180[v178] = v176;
                v178++;
            }
        }
        finally
        {
            v177.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v180, v178);
    }

    int[] ArrayConcatEnumerableToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v181;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v182;
        IEnumerator<int> v183;
        int v184;
        int v185;
        int[] v186;
        v183 = EnumerableItems2.GetEnumerator();
        v184 = 0;
        v185 = 8;
        v186 = new int[8];
        v181 = 0;
        for (; v181 < ArrayItems.Length; v181++)
        {
            v182 = ArrayItems[v181];
            if (v184 >= v185)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v186, ref v185);
            v186[v184] = v182;
            v184++;
        }

        try
        {
            while (v183.MoveNext())
            {
                v182 = v183.Current;
                if (v184 >= v185)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v186, ref v185);
                v186[v184] = v182;
                v184++;
            }
        }
        finally
        {
            v183.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v186, v184);
    }

    int[] SimpleListConcatArrayToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v187;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v188;
        int v189;
        int v190;
        int v191;
        int[] v192;
        v187 = SimpleListItems.GetEnumerator();
        v190 = 0;
        v191 = 8;
        v192 = new int[8];
        try
        {
            while (v187.MoveNext())
            {
                v188 = v187.Current;
                if (v190 >= v191)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v192, ref v191);
                v192[v190] = v188;
                v190++;
            }
        }
        finally
        {
            v187.Dispose();
        }

        v189 = 0;
        for (; v189 < ArrayItems2.Length; v189++)
        {
            v188 = ArrayItems2[v189];
            if (v190 >= v191)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v192, ref v191);
            v192[v190] = v188;
            v190++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v192, v190);
    }

    int[] SimpleListConcatSimpleListToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v193;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v194;
        IEnumerator<int> v195;
        int v196;
        int v197;
        int[] v198;
        v193 = SimpleListItems.GetEnumerator();
        v195 = SimpleListItems2.GetEnumerator();
        v196 = 0;
        v197 = 8;
        v198 = new int[8];
        try
        {
            while (v193.MoveNext())
            {
                v194 = v193.Current;
                if (v196 >= v197)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v198, ref v197);
                v198[v196] = v194;
                v196++;
            }
        }
        finally
        {
            v193.Dispose();
        }

        try
        {
            while (v195.MoveNext())
            {
                v194 = v195.Current;
                if (v196 >= v197)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v198, ref v197);
                v198[v196] = v194;
                v196++;
            }
        }
        finally
        {
            v195.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v198, v196);
    }

    int[] SimpleListConcatEnumerableToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v199;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v200;
        IEnumerator<int> v201;
        int v202;
        int v203;
        int[] v204;
        v199 = SimpleListItems.GetEnumerator();
        v201 = EnumerableItems2.GetEnumerator();
        v202 = 0;
        v203 = 8;
        v204 = new int[8];
        try
        {
            while (v199.MoveNext())
            {
                v200 = v199.Current;
                if (v202 >= v203)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v204, ref v203);
                v204[v202] = v200;
                v202++;
            }
        }
        finally
        {
            v199.Dispose();
        }

        try
        {
            while (v201.MoveNext())
            {
                v200 = v201.Current;
                if (v202 >= v203)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v204, ref v203);
                v204[v202] = v200;
                v202++;
            }
        }
        finally
        {
            v201.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v204, v202);
    }

    int[] EnumerableConcatArrayToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v205;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v206;
        int v207;
        int v208;
        int v209;
        int[] v210;
        v205 = EnumerableItems.GetEnumerator();
        v208 = 0;
        v209 = 8;
        v210 = new int[8];
        try
        {
            while (v205.MoveNext())
            {
                v206 = v205.Current;
                if (v208 >= v209)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v210, ref v209);
                v210[v208] = v206;
                v208++;
            }
        }
        finally
        {
            v205.Dispose();
        }

        v207 = 0;
        for (; v207 < ArrayItems2.Length; v207++)
        {
            v206 = ArrayItems2[v207];
            if (v208 >= v209)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v210, ref v209);
            v210[v208] = v206;
            v208++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v210, v208);
    }

    int[] EnumerableConcatSimpleListToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v211;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v212;
        IEnumerator<int> v213;
        int v214;
        int v215;
        int[] v216;
        v211 = EnumerableItems.GetEnumerator();
        v213 = SimpleListItems2.GetEnumerator();
        v214 = 0;
        v215 = 8;
        v216 = new int[8];
        try
        {
            while (v211.MoveNext())
            {
                v212 = v211.Current;
                if (v214 >= v215)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v216, ref v215);
                v216[v214] = v212;
                v214++;
            }
        }
        finally
        {
            v211.Dispose();
        }

        try
        {
            while (v213.MoveNext())
            {
                v212 = v213.Current;
                if (v214 >= v215)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v216, ref v215);
                v216[v214] = v212;
                v214++;
            }
        }
        finally
        {
            v213.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v216, v214);
    }

    int[] EnumerableConcatEnumerableToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v217;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v218;
        IEnumerator<int> v219;
        int v220;
        int v221;
        int[] v222;
        v217 = EnumerableItems.GetEnumerator();
        v219 = EnumerableItems2.GetEnumerator();
        v220 = 0;
        v221 = 8;
        v222 = new int[8];
        try
        {
            while (v217.MoveNext())
            {
                v218 = v217.Current;
                if (v220 >= v221)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v222, ref v221);
                v222[v220] = v218;
                v220++;
            }
        }
        finally
        {
            v217.Dispose();
        }

        try
        {
            while (v219.MoveNext())
            {
                v218 = v219.Current;
                if (v220 >= v221)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v222, ref v221);
                v222[v220] = v218;
                v220++;
            }
        }
        finally
        {
            v219.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v222, v220);
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectConcatArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v223;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v224;
        int v225;
        v223 = 0;
        for (; v223 < ArrayItems.Length; v223++)
        {
            v224 = (ArrayItems[v223] + 50);
            yield return v224;
        }

        v225 = 0;
        for (; v225 < ArrayItems2.Length; v225++)
        {
            v224 = ArrayItems2[v225];
            yield return v224;
        }
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectConcatArraySelectRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v226;
        v226 = 0;
        for (; v226 < ArrayItems2.Length; v226++)
            yield return (ArrayItems2[v226] + 50);
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectConcatArraySelectRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v227;
        if (ArraySelectConcatArraySelectRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v228;
        IEnumerator<int> v229;
        v229 = ArraySelectConcatArraySelectRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v227 = 0;
        for (; v227 < ArrayItems.Length; v227++)
        {
            v228 = (ArrayItems[v227] + 50);
            yield return v228;
        }

        try
        {
            while (v229.MoveNext())
            {
                v228 = v229.Current;
                yield return v228;
            }
        }
        finally
        {
            v229.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereConcatArrayWhereRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v230;
        v230 = 0;
        for (; v230 < ArrayItems2.Length; v230++)
        {
            if (!((ArrayItems2[v230] > 50)))
                continue;
            yield return ArrayItems2[v230];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereConcatArrayWhereRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v231;
        if (ArrayWhereConcatArrayWhereRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v232;
        IEnumerator<int> v233;
        v233 = ArrayWhereConcatArrayWhereRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v231 = 0;
        for (; v231 < ArrayItems.Length; v231++)
        {
            if (!((ArrayItems[v231] > 50)))
                continue;
            v232 = ArrayItems[v231];
            yield return v232;
        }

        try
        {
            while (v233.MoveNext())
            {
                v232 = v233.Current;
                yield return v232;
            }
        }
        finally
        {
            v233.Dispose();
        }
    }

    int ArrayConcatArrayCount2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v237;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v238;
        int v239;
        int v240;
        v240 = 0;
        v237 = 0;
        for (; v237 < ArrayItems.Length; v237++)
        {
            v238 = ArrayItems[v237];
            if (!((v238 > 70)))
                continue;
            v240++;
        }

        v239 = 0;
        for (; v239 < ArrayItems2.Length; v239++)
        {
            v238 = ArrayItems2[v239];
            if (!((v238 > 70)))
                continue;
            v240++;
        }

        return v240;
    }

    int ArrayConcatArraySumRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v241;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v242;
        int v243;
        int v244;
        v244 = 0;
        v241 = 0;
        for (; v241 < ArrayItems.Length; v241++)
        {
            v242 = ArrayItems[v241];
            v244 += v242;
        }

        v243 = 0;
        for (; v243 < ArrayItems2.Length; v243++)
        {
            v242 = ArrayItems2[v243];
            v244 += v242;
        }

        return v244;
    }

    int ArrayConcatArraySum2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v245;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v246;
        int v247;
        int v248;
        int v249;
        v248 = 0;
        v245 = 0;
        for (; v245 < ArrayItems.Length; v245++)
        {
            v246 = ArrayItems[v245];
            v249 = (v246 + 10);
            v248 += v249;
        }

        v247 = 0;
        for (; v247 < ArrayItems2.Length; v247++)
        {
            v246 = ArrayItems2[v247];
            v249 = (v246 + 10);
            v248 += v249;
        }

        return v248;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v250;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v251;
        int v252;
        HashSet<int> v253;
        v253 = new HashSet<int>();
        v250 = 0;
        for (; v250 < ArrayItems.Length; v250++)
        {
            v251 = ArrayItems[v250];
            if (!(v253.Add(v251)))
                continue;
            yield return v251;
        }

        v252 = 0;
        for (; v252 < ArrayItems2.Length; v252++)
        {
            v251 = ArrayItems2[v252];
            if (!(v253.Add(v251)))
                continue;
            yield return v251;
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatArrayDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v254;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v255;
        int v256;
        HashSet<int> v257;
        v257 = new HashSet<int>(EqualityComparer<int>.Default);
        v254 = 0;
        for (; v254 < ArrayItems.Length; v254++)
        {
            v255 = ArrayItems[v254];
            if (!(v257.Add(v255)))
                continue;
            yield return v255;
        }

        v256 = 0;
        for (; v256 < ArrayItems2.Length; v256++)
        {
            v255 = ArrayItems2[v256];
            if (!(v257.Add(v255)))
                continue;
            yield return v255;
        }
    }

    int ArrayConcatArrayElementAtRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v258;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v259;
        int v260;
        v258 = 0;
        for (; v258 < ArrayItems.Length; v258++)
        {
            v259 = ArrayItems[v258];
            if (v258 == 45)
                return v259;
        }

        v260 = 0;
        for (; v260 < ArrayItems2.Length; v260++)
        {
            v259 = ArrayItems2[v260];
            if (v258 == 45)
                return v259;
            v258++;
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArrayConcatArrayElementAtOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v261;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v262;
        int v263;
        v261 = 0;
        for (; v261 < ArrayItems.Length; v261++)
        {
            v262 = ArrayItems[v261];
            if (v261 == 45)
                return v262;
        }

        v263 = 0;
        for (; v263 < ArrayItems2.Length; v263++)
        {
            v262 = ArrayItems2[v263];
            if (v261 == 45)
                return v262;
            v261++;
        }

        return default(int);
    }

    int ArrayConcatArrayLastRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v270;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v271;
        int v272;
        int? v273;
        v273 = null;
        v270 = 0;
        for (; v270 < ArrayItems.Length; v270++)
        {
            v271 = ArrayItems[v270];
            v273 = v271;
        }

        v272 = 0;
        for (; v272 < ArrayItems2.Length; v272++)
        {
            v271 = ArrayItems2[v272];
            v273 = v271;
        }

        if (v273 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v273;
    }

    int ArrayConcatArrayLastOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v274;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v275;
        int v276;
        int? v277;
        v277 = null;
        v274 = 0;
        for (; v274 < ArrayItems.Length; v274++)
        {
            v275 = ArrayItems[v274];
            v277 = v275;
        }

        v276 = 0;
        for (; v276 < ArrayItems2.Length; v276++)
        {
            v275 = ArrayItems2[v276];
            v277 = v275;
        }

        if (v277 == null)
            return default(int);
        else
            return (int)v277;
    }

    int ArrayConcatArraySingleRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v278;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v279;
        int v280;
        int? v281;
        v281 = null;
        v278 = 0;
        for (; v278 < ArrayItems.Length; v278++)
        {
            v279 = ArrayItems[v278];
            if (v281 == null)
                v281 = v279;
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        v280 = 0;
        for (; v280 < ArrayItems2.Length; v280++)
        {
            v279 = ArrayItems2[v280];
            if (v281 == null)
                v281 = v279;
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v281 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v281;
    }

    int ArrayConcatArraySingle2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v282;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v283;
        int v284;
        int? v285;
        v285 = null;
        v282 = 0;
        for (; v282 < ArrayItems.Length; v282++)
        {
            v283 = ArrayItems[v282];
            if ((v283 == 76))
                if (v285 == null)
                    v285 = v283;
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        v284 = 0;
        for (; v284 < ArrayItems2.Length; v284++)
        {
            v283 = ArrayItems2[v284];
            if ((v283 == 76))
                if (v285 == null)
                    v285 = v283;
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v285 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v285;
    }

    int ArrayConcatArraySingleOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v286;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v287;
        int v288;
        int? v289;
        v289 = null;
        v286 = 0;
        for (; v286 < ArrayItems.Length; v286++)
        {
            v287 = ArrayItems[v286];
            if (v289 == null)
                v289 = v287;
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        v288 = 0;
        for (; v288 < ArrayItems2.Length; v288++)
        {
            v287 = ArrayItems2[v288];
            if (v289 == null)
                v289 = v287;
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v289 == null)
            return default(int);
        else
            return (int)v289;
    }

    int ArrayConcatArrayMinRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v290;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v291;
        int v292;
        int v293;
        bool v294;
        v293 = 2147483647;
        v294 = false;
        v290 = 0;
        for (; v290 < ArrayItems.Length; v290++)
        {
            v291 = ArrayItems[v290];
            if (v291 >= v293)
                continue;
            v293 = v291;
            v294 = true;
        }

        v292 = 0;
        for (; v292 < ArrayItems2.Length; v292++)
        {
            v291 = ArrayItems2[v292];
            if (v291 >= v293)
                continue;
            v293 = v291;
            v294 = true;
        }

        if (!(v294))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v293;
    }

    decimal ArrayConcatArrayMin2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v295;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v296;
        int v297;
        decimal v298;
        bool v299;
        decimal v300;
        v298 = 79228162514264337593543950335M;
        v299 = false;
        v295 = 0;
        for (; v295 < ArrayItems.Length; v295++)
        {
            v296 = ArrayItems[v295];
            v300 = (v296 + 2m);
            if (v300 >= v298)
                continue;
            v298 = v300;
            v299 = true;
        }

        v297 = 0;
        for (; v297 < ArrayItems2.Length; v297++)
        {
            v296 = ArrayItems2[v297];
            v300 = (v296 + 2m);
            if (v300 >= v298)
                continue;
            v298 = v300;
            v299 = true;
        }

        if (!(v299))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v298;
    }

    int ArrayConcatArrayMaxRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v301;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v302;
        int v303;
        int v304;
        bool v305;
        v304 = -2147483648;
        v305 = false;
        v301 = 0;
        for (; v301 < ArrayItems.Length; v301++)
        {
            v302 = ArrayItems[v301];
            if (v302 <= v304)
                continue;
            v304 = v302;
            v305 = true;
        }

        v303 = 0;
        for (; v303 < ArrayItems2.Length; v303++)
        {
            v302 = ArrayItems2[v303];
            if (v302 <= v304)
                continue;
            v304 = v302;
            v305 = true;
        }

        if (!(v305))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v304;
    }

    decimal ArrayConcatArrayMax2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v306;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v307;
        int v308;
        decimal v309;
        bool v310;
        decimal v311;
        v309 = -79228162514264337593543950335M;
        v310 = false;
        v306 = 0;
        for (; v306 < ArrayItems.Length; v306++)
        {
            v307 = ArrayItems[v306];
            v311 = (v307 + 2m);
            if (v311 <= v309)
                continue;
            v309 = v311;
            v310 = true;
        }

        v308 = 0;
        for (; v308 < ArrayItems2.Length; v308++)
        {
            v307 = ArrayItems2[v308];
            v311 = (v307 + 2m);
            if (v311 <= v309)
                continue;
            v309 = v311;
            v310 = true;
        }

        if (!(v310))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v309;
    }

    long ArrayConcatArrayLongCount2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v315;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v316;
        int v317;
        long v318;
        v318 = 0;
        v315 = 0;
        for (; v315 < ArrayItems.Length; v315++)
        {
            v316 = ArrayItems[v315];
            if (!((v316 > 50)))
                continue;
            v318++;
        }

        v317 = 0;
        for (; v317 < ArrayItems2.Length; v317++)
        {
            v316 = ArrayItems2[v317];
            if (!((v316 > 50)))
                continue;
            v318++;
        }

        return v318;
    }

    bool ArrayConcatArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v319;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v320;
        int v321;
        v319 = 0;
        for (; v319 < ArrayItems.Length; v319++)
        {
            v320 = ArrayItems[v319];
            if (v320 == 56)
                return true;
        }

        v321 = 0;
        for (; v321 < ArrayItems2.Length; v321++)
        {
            v320 = ArrayItems2[v321];
            if (v320 == 56)
                return true;
        }

        return false;
    }

    double ArrayConcatArrayAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v322;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v323;
        int v324;
        double v325;
        v325 = 0;
        v322 = 0;
        for (; v322 < ArrayItems.Length; v322++)
        {
            v323 = ArrayItems[v322];
            v325 += v323;
        }

        v324 = 0;
        for (; v324 < ArrayItems2.Length; v324++)
        {
            v323 = ArrayItems2[v324];
            v325 += v323;
        }

        if ((ArrayItems2.Length + ArrayItems.Length) == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v325 / (ArrayItems2.Length + ArrayItems.Length));
    }

    double ArrayConcatArrayAverage2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v326;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v327;
        int v328;
        double v329;
        v329 = 0;
        v326 = 0;
        for (; v326 < ArrayItems.Length; v326++)
        {
            v327 = ArrayItems[v326];
            v329 += (v327 + 10);
        }

        v328 = 0;
        for (; v328 < ArrayItems2.Length; v328++)
        {
            v327 = ArrayItems2[v328];
            v329 += (v327 + 10);
        }

        if ((ArrayItems2.Length + ArrayItems.Length) == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v329 / (ArrayItems2.Length + ArrayItems.Length));
    }

    bool ArrayConcatArrayContains2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v330;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v331;
        int v332;
        System.Collections.Generic.EqualityComparer<int> v333;
        v333 = EqualityComparer<int>.Default;
        v330 = 0;
        for (; v330 < ArrayItems.Length; v330++)
        {
            v331 = ArrayItems[v330];
            if (v333.Equals(v331, 56))
                return true;
        }

        v332 = 0;
        for (; v332 < ArrayItems2.Length; v332++)
        {
            v331 = ArrayItems2[v332];
            if (v333.Equals(v331, 56))
                return true;
        }

        return false;
    }

    System.Collections.Generic.IEnumerable<int> SelectWhereArrayConcatSelectWhereArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v334;
        int v335;
        v334 = 0;
        for (; v334 < ArrayItems2.Length; v334++)
        {
            v335 = (ArrayItems2[v334] + 10);
            if (!((v335 > 80)))
                continue;
            yield return v335;
        }
    }

    bool SelectWhereArrayConcatSelectWhereArrayContainsRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v336;
        int v337;
        if (SelectWhereArrayConcatSelectWhereArrayContainsRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v338;
        v338 = SelectWhereArrayConcatSelectWhereArrayContainsRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v336 = 0;
        for (; v336 < ArrayItems.Length; v336++)
        {
            v337 = (ArrayItems[v336] + 10);
            if (!((v337 > 80)))
                continue;
            if (v337 == 112)
                return true;
        }

        try
        {
            while (v338.MoveNext())
            {
                v337 = v338.Current;
                if (v337 == 112)
                    return true;
            }
        }
        finally
        {
            v338.Dispose();
        }

        return false;
    }

    System.Collections.Generic.IEnumerable<int> RangeConcatArrayRewritten_ProceduralLinq1()
    {
        int v339;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v340;
        int v341;
        v339 = 0;
        for (; v339 < 100; v339++)
        {
            v340 = (v339 + 20);
            yield return v340;
        }

        v341 = 0;
        for (; v341 < ArrayItems2.Length; v341++)
        {
            v340 = ArrayItems2[v341];
            yield return v340;
        }
    }

    System.Collections.Generic.IEnumerable<int> RepeatConcatArrayRewritten_ProceduralLinq1()
    {
        int v342;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v343;
        int v344;
        v342 = 0;
        for (; v342 < 100; v342++)
        {
            v343 = 20;
            yield return v343;
        }

        v344 = 0;
        for (; v344 < ArrayItems2.Length; v344++)
        {
            v343 = ArrayItems2[v344];
            yield return v343;
        }
    }

    System.Collections.Generic.IEnumerable<int> EmptyConcatArrayRewritten_ProceduralLinq1()
    {
        int v345;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v346;
        int v347;
        v345 = 0;
        for (; v345 < 0; v345++)
        {
            v346 = default(int);
            yield return v346;
        }

        v347 = 0;
        for (; v347 < ArrayItems2.Length; v347++)
        {
            v346 = ArrayItems2[v347];
            yield return v346;
        }
    }

    System.Collections.Generic.IEnumerable<int> RangeEmpty2ArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v348;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v349;
        v348 = 0;
        for (; v348 < ArrayItems.Length; v348++)
        {
            if (!((false)))
                continue;
            v349 = ArrayItems[v348];
            yield return v349;
        }

        v348 = 0;
        for (; v348 < ArrayItems2.Length; v348++)
        {
            v349 = ArrayItems2[v348];
            yield return v349;
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatRangeRewritten_ProceduralLinq1()
    {
        int v350;
        v350 = 0;
        for (; v350 < 260; v350++)
            yield return (v350 + 70);
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatRangeRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v351;
        if (ArrayConcatRangeRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v352;
        IEnumerator<int> v353;
        v353 = ArrayConcatRangeRewritten_ProceduralLinq1().GetEnumerator();
        v351 = 0;
        for (; v351 < ArrayItems.Length; v351++)
        {
            v352 = ArrayItems[v351];
            yield return v352;
        }

        try
        {
            while (v353.MoveNext())
            {
                v352 = v353.Current;
                yield return v352;
            }
        }
        finally
        {
            v353.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatRepeatRewritten_ProceduralLinq1()
    {
        int v354;
        v354 = 0;
        for (; v354 < 100; v354++)
            yield return 70;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatRepeatRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v355;
        if (ArrayConcatRepeatRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v356;
        IEnumerator<int> v357;
        v357 = ArrayConcatRepeatRewritten_ProceduralLinq1().GetEnumerator();
        v355 = 0;
        for (; v355 < ArrayItems.Length; v355++)
        {
            v356 = ArrayItems[v355];
            yield return v356;
        }

        try
        {
            while (v357.MoveNext())
            {
                v356 = v357.Current;
                yield return v356;
            }
        }
        finally
        {
            v357.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatEmptyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v358;
        if (Enumerable.Empty<int>() == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v359;
        IEnumerator<int> v360;
        v360 = Enumerable.Empty<int>().GetEnumerator();
        v358 = 0;
        for (; v358 < ArrayItems.Length; v358++)
        {
            v359 = ArrayItems[v358];
            yield return v359;
        }

        try
        {
            while (v360.MoveNext())
            {
                v359 = v360.Current;
                yield return v359;
            }
        }
        finally
        {
            v360.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatEmpty2Rewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v361;
        v361 = 0;
        for (; v361 < ArrayItems2.Length; v361++)
        {
            if (!((false)))
                continue;
            yield return ArrayItems2[v361];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatEmpty2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v362;
        if (ArrayConcatEmpty2Rewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v363;
        IEnumerator<int> v364;
        v364 = ArrayConcatEmpty2Rewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v362 = 0;
        for (; v362 < ArrayItems.Length; v362++)
        {
            v363 = ArrayItems[v362];
            yield return v363;
        }

        try
        {
            while (v364.MoveNext())
            {
                v363 = v364.Current;
                yield return v363;
            }
        }
        finally
        {
            v364.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatAllRewritten_ProceduralLinq1()
    {
        int v365;
        v365 = 0;
        for (; v365 < 1000; v365++)
            yield return (v365 + 0);
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatAllRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v366;
        if (ArrayConcatAllRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v367;
        IEnumerator<int> v368;
        v368 = ArrayConcatAllRewritten_ProceduralLinq1().GetEnumerator();
        v366 = 0;
        for (; v366 < ArrayItems.Length; v366++)
        {
            v367 = ArrayItems[v366];
            yield return v367;
        }

        try
        {
            while (v368.MoveNext())
            {
                v367 = v368.Current;
                yield return v367;
            }
        }
        finally
        {
            v368.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatNullRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v369;
        throw new System.InvalidOperationException("Invalid null object");
        v369 = 0;
        for (; v369 < ArrayItems.Length; v369++)
            yield return ArrayItems[v369];
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatArrayConcatEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v370;
        if (ArrayItems == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v371;
        int v372;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v373;
        v373 = EnumerableItems2.GetEnumerator();
        v370 = 0;
        for (; v370 < ArrayItems.Length; v370++)
        {
            v371 = ArrayItems[v370];
            yield return v371;
        }

        v372 = 0;
        for (; v372 < ArrayItems.Length; v372++)
        {
            v371 = ArrayItems[v372];
            yield return v371;
        }

        try
        {
            while (v373.MoveNext())
            {
                v371 = v373.Current;
                yield return v371;
            }
        }
        finally
        {
            v373.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatArrayConcatEnumerable2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v374;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v375;
        IEnumerator<int> v376;
        v376 = EnumerableItems2.GetEnumerator();
        v374 = 0;
        for (; v374 < ArrayItems.Length; v374++)
        {
            v375 = ArrayItems[v374];
            yield return v375;
        }

        try
        {
            while (v376.MoveNext())
            {
                v375 = v376.Current;
                yield return v375;
            }
        }
        finally
        {
            v376.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatArrayConcatEnumerable2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v377;
        if (ArrayConcatArrayConcatEnumerable2Rewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v378;
        IEnumerator<int> v379;
        v379 = ArrayConcatArrayConcatEnumerable2Rewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v377 = 0;
        for (; v377 < ArrayItems.Length; v377++)
        {
            v378 = ArrayItems[v377];
            yield return v378;
        }

        try
        {
            while (v379.MoveNext())
            {
                v378 = v379.Current;
                yield return v378;
            }
        }
        finally
        {
            v379.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctConcatArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v380;
        HashSet<int> v381;
        v381 = new HashSet<int>();
        v380 = 0;
        for (; v380 < ArrayItems.Length; v380++)
        {
            if (!(v381.Add(ArrayItems[v380])))
                continue;
            yield return ArrayItems[v380];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctConcatArrayDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v382;
        HashSet<int> v383;
        if (ArrayDistinctConcatArrayDistinctRewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v384;
        IEnumerator<int> v385;
        v385 = ArrayDistinctConcatArrayDistinctRewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v383 = new HashSet<int>();
        v382 = 0;
        for (; v382 < ArrayItems.Length; v382++)
        {
            if (!(v383.Add(ArrayItems[v382])))
                continue;
            v384 = ArrayItems[v382];
            yield return v384;
        }

        try
        {
            while (v385.MoveNext())
            {
                v384 = v385.Current;
                yield return v384;
            }
        }
        finally
        {
            v385.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v386;
        HashSet<int> v387;
        v387 = new HashSet<int>();
        v386 = 0;
        for (; v386 < ArrayItems.Length; v386++)
        {
            if (!(v387.Add(ArrayItems[v386])))
                continue;
            yield return ArrayItems[v386];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v388;
        HashSet<int> v389;
        if (ArrayDistinctConcatArrayDistinctDistinctRewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v390;
        IEnumerator<int> v391;
        HashSet<int> v392;
        v391 = ArrayDistinctConcatArrayDistinctDistinctRewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v389 = new HashSet<int>();
        v392 = new HashSet<int>();
        v388 = 0;
        for (; v388 < ArrayItems.Length; v388++)
        {
            if (!(v389.Add(ArrayItems[v388])))
                continue;
            v390 = ArrayItems[v388];
            if (!(v392.Add(v390)))
                continue;
            yield return v390;
        }

        try
        {
            while (v391.MoveNext())
            {
                v390 = v391.Current;
                if (!(v392.Add(v390)))
                    continue;
                yield return v390;
            }
        }
        finally
        {
            v391.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v393;
        HashSet<int> v394;
        v394 = new HashSet<int>(EqualityComparer<int>.Default);
        v393 = 0;
        for (; v393 < ArrayItems.Length; v393++)
        {
            if (!(v394.Add(ArrayItems[v393])))
                continue;
            yield return ArrayItems[v393];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinct2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v395;
        HashSet<int> v396;
        if (ArrayDistinctConcatArrayDistinctDistinct2Rewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        int v397;
        IEnumerator<int> v398;
        HashSet<int> v399;
        v398 = ArrayDistinctConcatArrayDistinctDistinct2Rewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v396 = new HashSet<int>(EqualityComparer<int>.Default);
        v399 = new HashSet<int>(EqualityComparer<int>.Default);
        v395 = 0;
        for (; v395 < ArrayItems.Length; v395++)
        {
            if (!(v396.Add(ArrayItems[v395])))
                continue;
            v397 = ArrayItems[v395];
            if (!(v399.Add(v397)))
                continue;
            yield return v397;
        }

        try
        {
            while (v398.MoveNext())
            {
                v397 = v398.Current;
                if (!(v399.Add(v397)))
                    continue;
                yield return v397;
            }
        }
        finally
        {
            v398.Dispose();
        }
    }
}}