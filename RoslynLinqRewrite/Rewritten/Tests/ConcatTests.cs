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
        return ArraySelectConcatArrayRewritten_ProceduralLinq1(ArrayItems, x => x + 50);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectConcatArraySelect()
    {
        return ArrayItems.Select(x => x + 50).Concat(ArrayItems2.Select(x => x + 50));
    } //EndMethod

    public IEnumerable<int> ArraySelectConcatArraySelectRewritten()
    {
        return ArraySelectConcatArraySelectRewritten_ProceduralLinq2(ArrayItems, x => x + 50);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayWhereConcatArrayWhere()
    {
        return ArrayItems.Where(x => x > 50).Concat(ArrayItems2.Where(x => x > 50));
    } //EndMethod

    public IEnumerable<int> ArrayWhereConcatArrayWhereRewritten()
    {
        return ArrayWhereConcatArrayWhereRewritten_ProceduralLinq2(ArrayItems, x => x > 50);
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
        return RangeEmpty2ArrayRewritten_ProceduralLinq1(ArrayItems, x => false);
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
        int v137;
        int v138;
        int v139;
        v137 = 0;
        for (; v137 < ArrayItems.Length; v137++)
        {
            v138 = ArrayItems[v137];
            yield return v138;
        }

        v139 = 0;
        for (; v139 < ArrayItems2.Length; v139++)
        {
            v138 = ArrayItems2[v139];
            yield return v138;
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v140;
        int v141;
        IEnumerator<int> v142;
        v142 = SimpleListItems2.GetEnumerator();
        v140 = 0;
        for (; v140 < ArrayItems.Length; v140++)
        {
            v141 = ArrayItems[v140];
            yield return v141;
        }

        try
        {
            while (v142.MoveNext())
            {
                v141 = v142.Current;
                yield return v141;
            }
        }
        finally
        {
            v142.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v143;
        int v144;
        IEnumerator<int> v145;
        v145 = EnumerableItems2.GetEnumerator();
        v143 = 0;
        for (; v143 < ArrayItems.Length; v143++)
        {
            v144 = ArrayItems[v143];
            yield return v144;
        }

        try
        {
            while (v145.MoveNext())
            {
                v144 = v145.Current;
                yield return v144;
            }
        }
        finally
        {
            v145.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v146;
        int v147;
        IEnumerator<int> v148;
        v148 = MethodEnumerable2().GetEnumerator();
        v146 = 0;
        for (; v146 < ArrayItems.Length; v146++)
        {
            v147 = ArrayItems[v146];
            yield return v147;
        }

        try
        {
            while (v148.MoveNext())
            {
                v147 = v148.Current;
                yield return v147;
            }
        }
        finally
        {
            v148.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> SimpleListConcatArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v149;
        int v150;
        int v151;
        v149 = SimpleListItems.GetEnumerator();
        try
        {
            while (v149.MoveNext())
            {
                v150 = v149.Current;
                yield return v150;
            }
        }
        finally
        {
            v149.Dispose();
        }

        v151 = 0;
        for (; v151 < ArrayItems2.Length; v151++)
        {
            v150 = ArrayItems2[v151];
            yield return v150;
        }
    }

    System.Collections.Generic.IEnumerable<int> SimpleListConcatSimpleListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v152;
        int v153;
        IEnumerator<int> v154;
        v152 = SimpleListItems.GetEnumerator();
        v154 = SimpleListItems2.GetEnumerator();
        try
        {
            while (v152.MoveNext())
            {
                v153 = v152.Current;
                yield return v153;
            }
        }
        finally
        {
            v152.Dispose();
        }

        try
        {
            while (v154.MoveNext())
            {
                v153 = v154.Current;
                yield return v153;
            }
        }
        finally
        {
            v154.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> SimpleListConcatEnumerableRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v155;
        int v156;
        IEnumerator<int> v157;
        v155 = SimpleListItems.GetEnumerator();
        v157 = EnumerableItems2.GetEnumerator();
        try
        {
            while (v155.MoveNext())
            {
                v156 = v155.Current;
                yield return v156;
            }
        }
        finally
        {
            v155.Dispose();
        }

        try
        {
            while (v157.MoveNext())
            {
                v156 = v157.Current;
                yield return v156;
            }
        }
        finally
        {
            v157.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> SimpleListConcatMethodRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v158;
        int v159;
        IEnumerator<int> v160;
        v158 = SimpleListItems.GetEnumerator();
        v160 = MethodEnumerable2().GetEnumerator();
        try
        {
            while (v158.MoveNext())
            {
                v159 = v158.Current;
                yield return v159;
            }
        }
        finally
        {
            v158.Dispose();
        }

        try
        {
            while (v160.MoveNext())
            {
                v159 = v160.Current;
                yield return v159;
            }
        }
        finally
        {
            v160.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableConcatArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v161;
        int v162;
        int v163;
        v161 = EnumerableItems.GetEnumerator();
        try
        {
            while (v161.MoveNext())
            {
                v162 = v161.Current;
                yield return v162;
            }
        }
        finally
        {
            v161.Dispose();
        }

        v163 = 0;
        for (; v163 < ArrayItems2.Length; v163++)
        {
            v162 = ArrayItems2[v163];
            yield return v162;
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableConcatSimpleListRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v164;
        int v165;
        IEnumerator<int> v166;
        v164 = EnumerableItems.GetEnumerator();
        v166 = SimpleListItems2.GetEnumerator();
        try
        {
            while (v164.MoveNext())
            {
                v165 = v164.Current;
                yield return v165;
            }
        }
        finally
        {
            v164.Dispose();
        }

        try
        {
            while (v166.MoveNext())
            {
                v165 = v166.Current;
                yield return v165;
            }
        }
        finally
        {
            v166.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableConcatEnumerableRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v167;
        int v168;
        IEnumerator<int> v169;
        v167 = EnumerableItems.GetEnumerator();
        v169 = EnumerableItems2.GetEnumerator();
        try
        {
            while (v167.MoveNext())
            {
                v168 = v167.Current;
                yield return v168;
            }
        }
        finally
        {
            v167.Dispose();
        }

        try
        {
            while (v169.MoveNext())
            {
                v168 = v169.Current;
                yield return v168;
            }
        }
        finally
        {
            v169.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableConcatMethodRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v170;
        int v171;
        IEnumerator<int> v172;
        v170 = EnumerableItems.GetEnumerator();
        v172 = MethodEnumerable2().GetEnumerator();
        try
        {
            while (v170.MoveNext())
            {
                v171 = v170.Current;
                yield return v171;
            }
        }
        finally
        {
            v170.Dispose();
        }

        try
        {
            while (v172.MoveNext())
            {
                v171 = v172.Current;
                yield return v171;
            }
        }
        finally
        {
            v172.Dispose();
        }
    }

    int[] ArrayConcatArrayToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v173;
        int v174;
        int v175;
        int[] v176;
        v176 = new int[(ArrayItems2.Length + ArrayItems.Length)];
        v173 = 0;
        for (; v173 < ArrayItems.Length; v173++)
        {
            v174 = ArrayItems[v173];
            v176[v173] = v174;
        }

        v175 = 0;
        for (; v175 < ArrayItems2.Length; v175++)
        {
            v174 = ArrayItems2[v175];
            v176[v173] = v174;
            v173++;
        }

        return v176;
    }

    int[] ArrayConcatSimpleListToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v177;
        int v178;
        IEnumerator<int> v179;
        int v180;
        int v181;
        int[] v182;
        v179 = SimpleListItems2.GetEnumerator();
        v180 = 0;
        v181 = 8;
        v182 = new int[8];
        v177 = 0;
        for (; v177 < ArrayItems.Length; v177++)
        {
            v178 = ArrayItems[v177];
            if (v180 >= v181)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v182, ref v181);
            v182[v180] = v178;
            v180++;
        }

        try
        {
            while (v179.MoveNext())
            {
                v178 = v179.Current;
                if (v180 >= v181)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v182, ref v181);
                v182[v180] = v178;
                v180++;
            }
        }
        finally
        {
            v179.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v182, v180);
    }

    int[] ArrayConcatEnumerableToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v183;
        int v184;
        IEnumerator<int> v185;
        int v186;
        int v187;
        int[] v188;
        v185 = EnumerableItems2.GetEnumerator();
        v186 = 0;
        v187 = 8;
        v188 = new int[8];
        v183 = 0;
        for (; v183 < ArrayItems.Length; v183++)
        {
            v184 = ArrayItems[v183];
            if (v186 >= v187)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v188, ref v187);
            v188[v186] = v184;
            v186++;
        }

        try
        {
            while (v185.MoveNext())
            {
                v184 = v185.Current;
                if (v186 >= v187)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v188, ref v187);
                v188[v186] = v184;
                v186++;
            }
        }
        finally
        {
            v185.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v188, v186);
    }

    int[] SimpleListConcatArrayToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v189;
        int v190;
        int v191;
        int v192;
        int v193;
        int[] v194;
        v189 = SimpleListItems.GetEnumerator();
        v192 = 0;
        v193 = 8;
        v194 = new int[8];
        try
        {
            while (v189.MoveNext())
            {
                v190 = v189.Current;
                if (v192 >= v193)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v194, ref v193);
                v194[v192] = v190;
                v192++;
            }
        }
        finally
        {
            v189.Dispose();
        }

        v191 = 0;
        for (; v191 < ArrayItems2.Length; v191++)
        {
            v190 = ArrayItems2[v191];
            if (v192 >= v193)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v194, ref v193);
            v194[v192] = v190;
            v192++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v194, v192);
    }

    int[] SimpleListConcatSimpleListToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v195;
        int v196;
        IEnumerator<int> v197;
        int v198;
        int v199;
        int[] v200;
        v195 = SimpleListItems.GetEnumerator();
        v197 = SimpleListItems2.GetEnumerator();
        v198 = 0;
        v199 = 8;
        v200 = new int[8];
        try
        {
            while (v195.MoveNext())
            {
                v196 = v195.Current;
                if (v198 >= v199)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v200, ref v199);
                v200[v198] = v196;
                v198++;
            }
        }
        finally
        {
            v195.Dispose();
        }

        try
        {
            while (v197.MoveNext())
            {
                v196 = v197.Current;
                if (v198 >= v199)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v200, ref v199);
                v200[v198] = v196;
                v198++;
            }
        }
        finally
        {
            v197.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v200, v198);
    }

    int[] SimpleListConcatEnumerableToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v201;
        int v202;
        IEnumerator<int> v203;
        int v204;
        int v205;
        int[] v206;
        v201 = SimpleListItems.GetEnumerator();
        v203 = EnumerableItems2.GetEnumerator();
        v204 = 0;
        v205 = 8;
        v206 = new int[8];
        try
        {
            while (v201.MoveNext())
            {
                v202 = v201.Current;
                if (v204 >= v205)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v206, ref v205);
                v206[v204] = v202;
                v204++;
            }
        }
        finally
        {
            v201.Dispose();
        }

        try
        {
            while (v203.MoveNext())
            {
                v202 = v203.Current;
                if (v204 >= v205)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v206, ref v205);
                v206[v204] = v202;
                v204++;
            }
        }
        finally
        {
            v203.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v206, v204);
    }

    int[] EnumerableConcatArrayToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v207;
        int v208;
        int v209;
        int v210;
        int v211;
        int[] v212;
        v207 = EnumerableItems.GetEnumerator();
        v210 = 0;
        v211 = 8;
        v212 = new int[8];
        try
        {
            while (v207.MoveNext())
            {
                v208 = v207.Current;
                if (v210 >= v211)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v212, ref v211);
                v212[v210] = v208;
                v210++;
            }
        }
        finally
        {
            v207.Dispose();
        }

        v209 = 0;
        for (; v209 < ArrayItems2.Length; v209++)
        {
            v208 = ArrayItems2[v209];
            if (v210 >= v211)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v212, ref v211);
            v212[v210] = v208;
            v210++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v212, v210);
    }

    int[] EnumerableConcatSimpleListToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v213;
        int v214;
        IEnumerator<int> v215;
        int v216;
        int v217;
        int[] v218;
        v213 = EnumerableItems.GetEnumerator();
        v215 = SimpleListItems2.GetEnumerator();
        v216 = 0;
        v217 = 8;
        v218 = new int[8];
        try
        {
            while (v213.MoveNext())
            {
                v214 = v213.Current;
                if (v216 >= v217)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v218, ref v217);
                v218[v216] = v214;
                v216++;
            }
        }
        finally
        {
            v213.Dispose();
        }

        try
        {
            while (v215.MoveNext())
            {
                v214 = v215.Current;
                if (v216 >= v217)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v218, ref v217);
                v218[v216] = v214;
                v216++;
            }
        }
        finally
        {
            v215.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v218, v216);
    }

    int[] EnumerableConcatEnumerableToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v219;
        int v220;
        IEnumerator<int> v221;
        int v222;
        int v223;
        int[] v224;
        v219 = EnumerableItems.GetEnumerator();
        v221 = EnumerableItems2.GetEnumerator();
        v222 = 0;
        v223 = 8;
        v224 = new int[8];
        try
        {
            while (v219.MoveNext())
            {
                v220 = v219.Current;
                if (v222 >= v223)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v224, ref v223);
                v224[v222] = v220;
                v222++;
            }
        }
        finally
        {
            v219.Dispose();
        }

        try
        {
            while (v221.MoveNext())
            {
                v220 = v221.Current;
                if (v222 >= v223)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v224, ref v223);
                v224[v222] = v220;
                v222++;
            }
        }
        finally
        {
            v221.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v224, v222);
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectConcatArrayRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int> v226)
    {
        int v225;
        int v227;
        int v228;
        v225 = 0;
        for (; v225 < ArrayItems.Length; v225++)
        {
            v227 = v226(ArrayItems[v225]);
            yield return v227;
        }

        v228 = 0;
        for (; v228 < ArrayItems2.Length; v228++)
        {
            v227 = ArrayItems2[v228];
            yield return v227;
        }
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectConcatArraySelectRewritten_ProceduralLinq1(int[] ArrayItems2, System.Func<int, int> v230)
    {
        int v229;
        v229 = 0;
        for (; v229 < ArrayItems2.Length; v229++)
            yield return v230(ArrayItems2[v229]);
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectConcatArraySelectRewritten_ProceduralLinq2(int[] ArrayItems, System.Func<int, int> v232)
    {
        int v231;
        int v233;
        IEnumerator<int> v234;
        v234 = ArraySelectConcatArraySelectRewritten_ProceduralLinq1(ArrayItems2, x => x + 50).GetEnumerator();
        v231 = 0;
        for (; v231 < ArrayItems.Length; v231++)
        {
            v233 = v232(ArrayItems[v231]);
            yield return v233;
        }

        try
        {
            while (v234.MoveNext())
            {
                v233 = v234.Current;
                yield return v233;
            }
        }
        finally
        {
            v234.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereConcatArrayWhereRewritten_ProceduralLinq1(int[] ArrayItems2, System.Func<int, bool> v236)
    {
        int v235;
        v235 = 0;
        for (; v235 < ArrayItems2.Length; v235++)
        {
            if (!(v236(ArrayItems2[v235])))
                continue;
            yield return ArrayItems2[v235];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereConcatArrayWhereRewritten_ProceduralLinq2(int[] ArrayItems, System.Func<int, bool> v238)
    {
        int v237;
        int v239;
        IEnumerator<int> v240;
        v240 = ArrayWhereConcatArrayWhereRewritten_ProceduralLinq1(ArrayItems2, x => x > 50).GetEnumerator();
        v237 = 0;
        for (; v237 < ArrayItems.Length; v237++)
        {
            if (!(v238(ArrayItems[v237])))
                continue;
            v239 = ArrayItems[v237];
            yield return v239;
        }

        try
        {
            while (v240.MoveNext())
            {
                v239 = v240.Current;
                yield return v239;
            }
        }
        finally
        {
            v240.Dispose();
        }
    }

    int ArrayConcatArrayCount2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v244;
        int v245;
        int v246;
        int v247;
        v247 = 0;
        v244 = 0;
        for (; v244 < ArrayItems.Length; v244++)
        {
            v245 = ArrayItems[v244];
            if (!((v245 > 70)))
                continue;
            v247++;
        }

        v246 = 0;
        for (; v246 < ArrayItems2.Length; v246++)
        {
            v245 = ArrayItems2[v246];
            if (!((v245 > 70)))
                continue;
            v247++;
        }

        return v247;
    }

    int ArrayConcatArraySumRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v248;
        int v249;
        int v250;
        int v251;
        v251 = 0;
        v248 = 0;
        for (; v248 < ArrayItems.Length; v248++)
        {
            v249 = ArrayItems[v248];
            v251 += v249;
        }

        v250 = 0;
        for (; v250 < ArrayItems2.Length; v250++)
        {
            v249 = ArrayItems2[v250];
            v251 += v249;
        }

        return v251;
    }

    int ArrayConcatArraySum2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v252;
        int v253;
        int v254;
        int v255;
        int v256;
        v255 = 0;
        v252 = 0;
        for (; v252 < ArrayItems.Length; v252++)
        {
            v253 = ArrayItems[v252];
            v256 = (v253 + 10);
            v255 += v256;
        }

        v254 = 0;
        for (; v254 < ArrayItems2.Length; v254++)
        {
            v253 = ArrayItems2[v254];
            v256 = (v253 + 10);
            v255 += v256;
        }

        return v255;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v257;
        int v258;
        int v259;
        HashSet<int> v260;
        v260 = new HashSet<int>();
        v257 = 0;
        for (; v257 < ArrayItems.Length; v257++)
        {
            v258 = ArrayItems[v257];
            if (!(v260.Add(v258)))
                continue;
            yield return v258;
        }

        v259 = 0;
        for (; v259 < ArrayItems2.Length; v259++)
        {
            v258 = ArrayItems2[v259];
            if (!(v260.Add(v258)))
                continue;
            yield return v258;
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatArrayDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v261;
        int v262;
        int v263;
        HashSet<int> v264;
        v264 = new HashSet<int>(EqualityComparer<int>.Default);
        v261 = 0;
        for (; v261 < ArrayItems.Length; v261++)
        {
            v262 = ArrayItems[v261];
            if (!(v264.Add(v262)))
                continue;
            yield return v262;
        }

        v263 = 0;
        for (; v263 < ArrayItems2.Length; v263++)
        {
            v262 = ArrayItems2[v263];
            if (!(v264.Add(v262)))
                continue;
            yield return v262;
        }
    }

    int ArrayConcatArrayElementAtRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v265;
        int v266;
        int v267;
        v265 = 0;
        for (; v265 < ArrayItems.Length; v265++)
        {
            v266 = ArrayItems[v265];
            if (v265 == 45)
                return v266;
        }

        v267 = 0;
        for (; v267 < ArrayItems2.Length; v267++)
        {
            v266 = ArrayItems2[v267];
            if (v265 == 45)
                return v266;
            v265++;
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArrayConcatArrayElementAtOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v268;
        int v269;
        int v270;
        v268 = 0;
        for (; v268 < ArrayItems.Length; v268++)
        {
            v269 = ArrayItems[v268];
            if (v268 == 45)
                return v269;
        }

        v270 = 0;
        for (; v270 < ArrayItems2.Length; v270++)
        {
            v269 = ArrayItems2[v270];
            if (v268 == 45)
                return v269;
            v268++;
        }

        return default(int);
    }

    int ArrayConcatArrayLastRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v277;
        int v278;
        int v279;
        int? v280;
        v280 = null;
        v277 = 0;
        for (; v277 < ArrayItems.Length; v277++)
        {
            v278 = ArrayItems[v277];
            v280 = v278;
        }

        v279 = 0;
        for (; v279 < ArrayItems2.Length; v279++)
        {
            v278 = ArrayItems2[v279];
            v280 = v278;
        }

        if (v280 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v280;
    }

    int ArrayConcatArrayLastOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v281;
        int v282;
        int v283;
        int? v284;
        v284 = null;
        v281 = 0;
        for (; v281 < ArrayItems.Length; v281++)
        {
            v282 = ArrayItems[v281];
            v284 = v282;
        }

        v283 = 0;
        for (; v283 < ArrayItems2.Length; v283++)
        {
            v282 = ArrayItems2[v283];
            v284 = v282;
        }

        if (v284 == null)
            return default(int);
        else
            return (int)v284;
    }

    int ArrayConcatArraySingleRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v285;
        int v286;
        int v287;
        int? v288;
        v288 = null;
        v285 = 0;
        for (; v285 < ArrayItems.Length; v285++)
        {
            v286 = ArrayItems[v285];
            if (v288 == null)
                v288 = v286;
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        v287 = 0;
        for (; v287 < ArrayItems2.Length; v287++)
        {
            v286 = ArrayItems2[v287];
            if (v288 == null)
                v288 = v286;
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v288 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v288;
    }

    int ArrayConcatArraySingle2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v289;
        int v290;
        int v291;
        int? v292;
        v292 = null;
        v289 = 0;
        for (; v289 < ArrayItems.Length; v289++)
        {
            v290 = ArrayItems[v289];
            if ((v290 == 76))
                if (v292 == null)
                    v292 = v290;
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        v291 = 0;
        for (; v291 < ArrayItems2.Length; v291++)
        {
            v290 = ArrayItems2[v291];
            if ((v290 == 76))
                if (v292 == null)
                    v292 = v290;
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v292 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v292;
    }

    int ArrayConcatArraySingleOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v293;
        int v294;
        int v295;
        int? v296;
        v296 = null;
        v293 = 0;
        for (; v293 < ArrayItems.Length; v293++)
        {
            v294 = ArrayItems[v293];
            if (v296 == null)
                v296 = v294;
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        v295 = 0;
        for (; v295 < ArrayItems2.Length; v295++)
        {
            v294 = ArrayItems2[v295];
            if (v296 == null)
                v296 = v294;
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v296 == null)
            return default(int);
        else
            return (int)v296;
    }

    int ArrayConcatArrayMinRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v297;
        int v298;
        int v299;
        int v300;
        bool v301;
        v300 = 2147483647;
        v301 = false;
        v297 = 0;
        for (; v297 < ArrayItems.Length; v297++)
        {
            v298 = ArrayItems[v297];
            if (v298 >= v300)
                continue;
            v300 = v298;
            v301 = true;
        }

        v299 = 0;
        for (; v299 < ArrayItems2.Length; v299++)
        {
            v298 = ArrayItems2[v299];
            if (v298 >= v300)
                continue;
            v300 = v298;
            v301 = true;
        }

        if (!(v301))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v300;
    }

    decimal ArrayConcatArrayMin2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v302;
        int v303;
        int v304;
        decimal v305;
        bool v306;
        decimal v307;
        v305 = 79228162514264337593543950335M;
        v306 = false;
        v302 = 0;
        for (; v302 < ArrayItems.Length; v302++)
        {
            v303 = ArrayItems[v302];
            v307 = (v303 + 2m);
            if (v307 >= v305)
                continue;
            v305 = v307;
            v306 = true;
        }

        v304 = 0;
        for (; v304 < ArrayItems2.Length; v304++)
        {
            v303 = ArrayItems2[v304];
            v307 = (v303 + 2m);
            if (v307 >= v305)
                continue;
            v305 = v307;
            v306 = true;
        }

        if (!(v306))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v305;
    }

    int ArrayConcatArrayMaxRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v308;
        int v309;
        int v310;
        int v311;
        bool v312;
        v311 = -2147483648;
        v312 = false;
        v308 = 0;
        for (; v308 < ArrayItems.Length; v308++)
        {
            v309 = ArrayItems[v308];
            if (v309 <= v311)
                continue;
            v311 = v309;
            v312 = true;
        }

        v310 = 0;
        for (; v310 < ArrayItems2.Length; v310++)
        {
            v309 = ArrayItems2[v310];
            if (v309 <= v311)
                continue;
            v311 = v309;
            v312 = true;
        }

        if (!(v312))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v311;
    }

    decimal ArrayConcatArrayMax2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v313;
        int v314;
        int v315;
        decimal v316;
        bool v317;
        decimal v318;
        v316 = -79228162514264337593543950335M;
        v317 = false;
        v313 = 0;
        for (; v313 < ArrayItems.Length; v313++)
        {
            v314 = ArrayItems[v313];
            v318 = (v314 + 2m);
            if (v318 <= v316)
                continue;
            v316 = v318;
            v317 = true;
        }

        v315 = 0;
        for (; v315 < ArrayItems2.Length; v315++)
        {
            v314 = ArrayItems2[v315];
            v318 = (v314 + 2m);
            if (v318 <= v316)
                continue;
            v316 = v318;
            v317 = true;
        }

        if (!(v317))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v316;
    }

    long ArrayConcatArrayLongCount2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v322;
        int v323;
        int v324;
        long v325;
        v325 = 0;
        v322 = 0;
        for (; v322 < ArrayItems.Length; v322++)
        {
            v323 = ArrayItems[v322];
            if (!((v323 > 50)))
                continue;
            v325++;
        }

        v324 = 0;
        for (; v324 < ArrayItems2.Length; v324++)
        {
            v323 = ArrayItems2[v324];
            if (!((v323 > 50)))
                continue;
            v325++;
        }

        return v325;
    }

    bool ArrayConcatArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v326;
        int v327;
        int v328;
        v326 = 0;
        for (; v326 < ArrayItems.Length; v326++)
        {
            v327 = ArrayItems[v326];
            if (v327 == 56)
                return true;
        }

        v328 = 0;
        for (; v328 < ArrayItems2.Length; v328++)
        {
            v327 = ArrayItems2[v328];
            if (v327 == 56)
                return true;
        }

        return false;
    }

    double ArrayConcatArrayAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v329;
        int v330;
        int v331;
        double v332;
        v332 = 0;
        v329 = 0;
        for (; v329 < ArrayItems.Length; v329++)
        {
            v330 = ArrayItems[v329];
            v332 += v330;
        }

        v331 = 0;
        for (; v331 < ArrayItems2.Length; v331++)
        {
            v330 = ArrayItems2[v331];
            v332 += v330;
        }

        if ((ArrayItems2.Length + ArrayItems.Length) == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v332 / (ArrayItems2.Length + ArrayItems.Length));
    }

    double ArrayConcatArrayAverage2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v333;
        int v334;
        int v335;
        double v336;
        v336 = 0;
        v333 = 0;
        for (; v333 < ArrayItems.Length; v333++)
        {
            v334 = ArrayItems[v333];
            v336 += (v334 + 10);
        }

        v335 = 0;
        for (; v335 < ArrayItems2.Length; v335++)
        {
            v334 = ArrayItems2[v335];
            v336 += (v334 + 10);
        }

        if ((ArrayItems2.Length + ArrayItems.Length) == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v336 / (ArrayItems2.Length + ArrayItems.Length));
    }

    bool ArrayConcatArrayContains2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v337;
        int v338;
        int v339;
        System.Collections.Generic.EqualityComparer<int> v340;
        v340 = EqualityComparer<int>.Default;
        v337 = 0;
        for (; v337 < ArrayItems.Length; v337++)
        {
            v338 = ArrayItems[v337];
            if (v340.Equals(v338, 56))
                return true;
        }

        v339 = 0;
        for (; v339 < ArrayItems2.Length; v339++)
        {
            v338 = ArrayItems2[v339];
            if (v340.Equals(v338, 56))
                return true;
        }

        return false;
    }

    System.Collections.Generic.IEnumerable<int> SelectWhereArrayConcatSelectWhereArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems2, System.Func<int, int> v342, System.Func<int, bool> v344)
    {
        int v341;
        int v343;
        v341 = 0;
        for (; v341 < ArrayItems2.Length; v341++)
        {
            v343 = v342(ArrayItems2[v341]);
            if (!(v344(v343)))
                continue;
            yield return v343;
        }
    }

    bool SelectWhereArrayConcatSelectWhereArrayContainsRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v345;
        int v346;
        IEnumerator<int> v347;
        v347 = SelectWhereArrayConcatSelectWhereArrayContainsRewritten_ProceduralLinq1(ArrayItems2, x => x + 10, x => x > 80).GetEnumerator();
        v345 = 0;
        for (; v345 < ArrayItems.Length; v345++)
        {
            v346 = (ArrayItems[v345] + 10);
            if (!((v346 > 80)))
                continue;
            if (v346 == 112)
                return true;
        }

        try
        {
            while (v347.MoveNext())
            {
                v346 = v347.Current;
                if (v346 == 112)
                    return true;
            }
        }
        finally
        {
            v347.Dispose();
        }

        return false;
    }

    System.Collections.Generic.IEnumerable<int> RangeConcatArrayRewritten_ProceduralLinq1()
    {
        int v348;
        if (100 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        int v349;
        int v350;
        v348 = 0;
        for (; v348 < 100; v348++)
        {
            v349 = (v348 + 20);
            yield return v349;
        }

        v350 = 0;
        for (; v350 < ArrayItems2.Length; v350++)
        {
            v349 = ArrayItems2[v350];
            yield return v349;
        }
    }

    System.Collections.Generic.IEnumerable<int> RepeatConcatArrayRewritten_ProceduralLinq1()
    {
        int v351;
        if (100 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        int v352;
        int v353;
        v351 = 0;
        for (; v351 < 100; v351++)
        {
            v352 = 20;
            yield return v352;
        }

        v353 = 0;
        for (; v353 < ArrayItems2.Length; v353++)
        {
            v352 = ArrayItems2[v353];
            yield return v352;
        }
    }

    System.Collections.Generic.IEnumerable<int> EmptyConcatArrayRewritten_ProceduralLinq1()
    {
        int v354;
        int v355;
        int v356;
        v354 = 0;
        for (; v354 < 0; v354++)
        {
            v355 = default(int);
            yield return v355;
        }

        v356 = 0;
        for (; v356 < ArrayItems2.Length; v356++)
        {
            v355 = ArrayItems2[v356];
            yield return v355;
        }
    }

    System.Collections.Generic.IEnumerable<int> RangeEmpty2ArrayRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, bool> v358)
    {
        int v357;
        int v359;
        v357 = 0;
        for (; v357 < ArrayItems.Length; v357++)
        {
            if (!(v358(ArrayItems[v357])))
                continue;
            v359 = ArrayItems[v357];
            yield return v359;
        }

        v357 = 0;
        for (; v357 < ArrayItems2.Length; v357++)
        {
            v359 = ArrayItems2[v357];
            yield return v359;
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatRangeRewritten_ProceduralLinq1()
    {
        int v360;
        if (260 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        v360 = 0;
        for (; v360 < 260; v360++)
            yield return (v360 + 70);
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatRangeRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v361;
        int v362;
        IEnumerator<int> v363;
        v363 = ArrayConcatRangeRewritten_ProceduralLinq1().GetEnumerator();
        v361 = 0;
        for (; v361 < ArrayItems.Length; v361++)
        {
            v362 = ArrayItems[v361];
            yield return v362;
        }

        try
        {
            while (v363.MoveNext())
            {
                v362 = v363.Current;
                yield return v362;
            }
        }
        finally
        {
            v363.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatRepeatRewritten_ProceduralLinq1()
    {
        int v364;
        if (100 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        v364 = 0;
        for (; v364 < 100; v364++)
            yield return 70;
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatRepeatRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v365;
        int v366;
        IEnumerator<int> v367;
        v367 = ArrayConcatRepeatRewritten_ProceduralLinq1().GetEnumerator();
        v365 = 0;
        for (; v365 < ArrayItems.Length; v365++)
        {
            v366 = ArrayItems[v365];
            yield return v366;
        }

        try
        {
            while (v367.MoveNext())
            {
                v366 = v367.Current;
                yield return v366;
            }
        }
        finally
        {
            v367.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatEmptyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v368;
        int v369;
        IEnumerator<int> v370;
        v370 = Enumerable.Empty<int>().GetEnumerator();
        v368 = 0;
        for (; v368 < ArrayItems.Length; v368++)
        {
            v369 = ArrayItems[v368];
            yield return v369;
        }

        try
        {
            while (v370.MoveNext())
            {
                v369 = v370.Current;
                yield return v369;
            }
        }
        finally
        {
            v370.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatEmpty2Rewritten_ProceduralLinq1(int[] ArrayItems2, System.Func<int, bool> v372)
    {
        int v371;
        v371 = 0;
        for (; v371 < ArrayItems2.Length; v371++)
        {
            if (!(v372(ArrayItems2[v371])))
                continue;
            yield return ArrayItems2[v371];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatEmpty2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v373;
        int v374;
        IEnumerator<int> v375;
        v375 = ArrayConcatEmpty2Rewritten_ProceduralLinq1(ArrayItems2, x => false).GetEnumerator();
        v373 = 0;
        for (; v373 < ArrayItems.Length; v373++)
        {
            v374 = ArrayItems[v373];
            yield return v374;
        }

        try
        {
            while (v375.MoveNext())
            {
                v374 = v375.Current;
                yield return v374;
            }
        }
        finally
        {
            v375.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatAllRewritten_ProceduralLinq1()
    {
        int v376;
        if (1000 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        v376 = 0;
        for (; v376 < 1000; v376++)
            yield return (v376 + 0);
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatAllRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v377;
        int v378;
        IEnumerator<int> v379;
        v379 = ArrayConcatAllRewritten_ProceduralLinq1().GetEnumerator();
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

    System.Collections.Generic.IEnumerable<int> ArrayConcatNullRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v380;
        throw new System.InvalidOperationException("Collection was null");
        v380 = 0;
        for (; v380 < ArrayItems.Length; v380++)
            yield return ArrayItems[v380];
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatArrayConcatEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v381;
        int v382;
        int v383;
        IEnumerator<int> v384;
        v384 = EnumerableItems2.GetEnumerator();
        v381 = 0;
        for (; v381 < ArrayItems.Length; v381++)
        {
            v382 = ArrayItems[v381];
            yield return v382;
        }

        v383 = 0;
        for (; v383 < ArrayItems.Length; v383++)
        {
            v382 = ArrayItems[v383];
            yield return v382;
        }

        try
        {
            while (v384.MoveNext())
            {
                v382 = v384.Current;
                yield return v382;
            }
        }
        finally
        {
            v384.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatArrayConcatEnumerable2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v385;
        int v386;
        IEnumerator<int> v387;
        v387 = EnumerableItems2.GetEnumerator();
        v385 = 0;
        for (; v385 < ArrayItems.Length; v385++)
        {
            v386 = ArrayItems[v385];
            yield return v386;
        }

        try
        {
            while (v387.MoveNext())
            {
                v386 = v387.Current;
                yield return v386;
            }
        }
        finally
        {
            v387.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayConcatArrayConcatEnumerable2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v388;
        int v389;
        IEnumerator<int> v390;
        v390 = ArrayConcatArrayConcatEnumerable2Rewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v388 = 0;
        for (; v388 < ArrayItems.Length; v388++)
        {
            v389 = ArrayItems[v388];
            yield return v389;
        }

        try
        {
            while (v390.MoveNext())
            {
                v389 = v390.Current;
                yield return v389;
            }
        }
        finally
        {
            v390.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctConcatArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v391;
        HashSet<int> v392;
        v392 = new HashSet<int>();
        v391 = 0;
        for (; v391 < ArrayItems.Length; v391++)
        {
            if (!(v392.Add(ArrayItems[v391])))
                continue;
            yield return ArrayItems[v391];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctConcatArrayDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v393;
        HashSet<int> v394;
        int v395;
        IEnumerator<int> v396;
        v396 = ArrayDistinctConcatArrayDistinctRewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v394 = new HashSet<int>();
        v393 = 0;
        for (; v393 < ArrayItems.Length; v393++)
        {
            if (!(v394.Add(ArrayItems[v393])))
                continue;
            v395 = ArrayItems[v393];
            yield return v395;
        }

        try
        {
            while (v396.MoveNext())
            {
                v395 = v396.Current;
                yield return v395;
            }
        }
        finally
        {
            v396.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v397;
        HashSet<int> v398;
        v398 = new HashSet<int>();
        v397 = 0;
        for (; v397 < ArrayItems.Length; v397++)
        {
            if (!(v398.Add(ArrayItems[v397])))
                continue;
            yield return ArrayItems[v397];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v399;
        HashSet<int> v400;
        int v401;
        IEnumerator<int> v402;
        HashSet<int> v403;
        v402 = ArrayDistinctConcatArrayDistinctDistinctRewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v400 = new HashSet<int>();
        v403 = new HashSet<int>();
        v399 = 0;
        for (; v399 < ArrayItems.Length; v399++)
        {
            if (!(v400.Add(ArrayItems[v399])))
                continue;
            v401 = ArrayItems[v399];
            if (!(v403.Add(v401)))
                continue;
            yield return v401;
        }

        try
        {
            while (v402.MoveNext())
            {
                v401 = v402.Current;
                if (!(v403.Add(v401)))
                    continue;
                yield return v401;
            }
        }
        finally
        {
            v402.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v404;
        HashSet<int> v405;
        v405 = new HashSet<int>(EqualityComparer<int>.Default);
        v404 = 0;
        for (; v404 < ArrayItems.Length; v404++)
        {
            if (!(v405.Add(ArrayItems[v404])))
                continue;
            yield return ArrayItems[v404];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinct2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v406;
        HashSet<int> v407;
        int v408;
        IEnumerator<int> v409;
        HashSet<int> v410;
        v409 = ArrayDistinctConcatArrayDistinctDistinct2Rewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v407 = new HashSet<int>(EqualityComparer<int>.Default);
        v410 = new HashSet<int>(EqualityComparer<int>.Default);
        v406 = 0;
        for (; v406 < ArrayItems.Length; v406++)
        {
            if (!(v407.Add(ArrayItems[v406])))
                continue;
            v408 = ArrayItems[v406];
            if (!(v410.Add(v408)))
                continue;
            yield return v408;
        }

        try
        {
            while (v409.MoveNext())
            {
                v408 = v409.Current;
                if (!(v410.Add(v408)))
                    continue;
                yield return v408;
            }
        }
        finally
        {
            v409.Dispose();
        }
    }
}}