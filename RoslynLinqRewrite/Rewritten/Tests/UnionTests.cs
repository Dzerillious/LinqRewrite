using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class UnionTests
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
        TestsExtensions.TestEquals(nameof(ArrayUnionArray), ArrayUnionArray, ArrayUnionArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionSimpleList), ArrayUnionSimpleList, ArrayUnionSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionEnumerable), ArrayUnionEnumerable, ArrayUnionEnumerableRewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionMethod), ArrayUnionMethod, ArrayUnionMethodRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListUnionArray), SimpleListUnionArray, SimpleListUnionArrayRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListUnionSimpleList), SimpleListUnionSimpleList, SimpleListUnionSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListUnionEnumerable), SimpleListUnionEnumerable, SimpleListUnionEnumerableRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListUnionMethod), SimpleListUnionMethod, SimpleListUnionMethodRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableUnionArray), EnumerableUnionArray, EnumerableUnionArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableUnionSimpleList), EnumerableUnionSimpleList, EnumerableUnionSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableUnionEnumerable), EnumerableUnionEnumerable, EnumerableUnionEnumerableRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableUnionMethod), EnumerableUnionMethod, EnumerableUnionMethodRewritten);
        TestsExtensions.TestEquals(nameof(MethodUnionArray), MethodUnionArray, MethodUnionArrayRewritten);
        TestsExtensions.TestEquals(nameof(MethodUnionSimpleList), MethodUnionSimpleList, MethodUnionSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(MethodUnionEnumerable), MethodUnionEnumerable, MethodUnionEnumerableRewritten);
        TestsExtensions.TestEquals(nameof(MethodUnionMethod), MethodUnionMethod, MethodUnionMethodRewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionArrayToArray), ArrayUnionArrayToArray, ArrayUnionArrayToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionSimpleListToArray), ArrayUnionSimpleListToArray, ArrayUnionSimpleListToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionEnumerableToArray), ArrayUnionEnumerableToArray, ArrayUnionEnumerableToArrayRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListUnionArrayToArray), SimpleListUnionArrayToArray, SimpleListUnionArrayToArrayRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListUnionSimpleListToArray), SimpleListUnionSimpleListToArray, SimpleListUnionSimpleListToArrayRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListUnionEnumerableToArray), SimpleListUnionEnumerableToArray, SimpleListUnionEnumerableToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableUnionArrayToArray), EnumerableUnionArrayToArray, EnumerableUnionArrayToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableUnionSimpleListToArray), EnumerableUnionSimpleListToArray, EnumerableUnionSimpleListToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableUnionEnumerableToArray), EnumerableUnionEnumerableToArray, EnumerableUnionEnumerableToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectUnionArray), ArraySelectUnionArray, ArraySelectUnionArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectUnionArraySelect), ArraySelectUnionArraySelect, ArraySelectUnionArraySelectRewritten);
        TestsExtensions.TestEquals(nameof(ArrayWhereUnionArrayWhere), ArrayWhereUnionArrayWhere, ArrayWhereUnionArrayWhereRewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionArrayCount), ArrayUnionArrayCount, ArrayUnionArrayCountRewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionArrayCount2), ArrayUnionArrayCount2, ArrayUnionArrayCount2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionArraySum), ArrayUnionArraySum, ArrayUnionArraySumRewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionArraySum2), ArrayUnionArraySum2, ArrayUnionArraySum2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionArrayDistinct), ArrayUnionArrayDistinct, ArrayUnionArrayDistinctRewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionArrayDistinct2), ArrayUnionArrayDistinct2, ArrayUnionArrayDistinct2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionArrayElementAt), ArrayUnionArrayElementAt, ArrayUnionArrayElementAtRewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionArrayElementAtOrDefault), ArrayUnionArrayElementAtOrDefault, ArrayUnionArrayElementAtOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionArrayFirst), ArrayUnionArrayFirst, ArrayUnionArrayFirstRewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionArrayFirstOrDefault), ArrayUnionArrayFirstOrDefault, ArrayUnionArrayFirstOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionArrayLast), ArrayUnionArrayLast, ArrayUnionArrayLastRewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionArrayLastOrDefault), ArrayUnionArrayLastOrDefault, ArrayUnionArrayLastOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionArraySingle), ArrayUnionArraySingle, ArrayUnionArraySingleRewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionArraySingle2), ArrayUnionArraySingle2, ArrayUnionArraySingle2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionArraySingleOrDefault), ArrayUnionArraySingleOrDefault, ArrayUnionArraySingleOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionArrayMin), ArrayUnionArrayMin, ArrayUnionArrayMinRewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionArrayMin2), ArrayUnionArrayMin2, ArrayUnionArrayMin2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionArrayMax), ArrayUnionArrayMax, ArrayUnionArrayMaxRewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionArrayMax2), ArrayUnionArrayMax2, ArrayUnionArrayMax2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionArrayLongCount), ArrayUnionArrayLongCount, ArrayUnionArrayLongCountRewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionArrayLongCount2), ArrayUnionArrayLongCount2, ArrayUnionArrayLongCount2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionArrayContains), ArrayUnionArrayContains, ArrayUnionArrayContainsRewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionArrayAverage), ArrayUnionArrayAverage, ArrayUnionArrayAverageRewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionArrayAverage2), ArrayUnionArrayAverage2, ArrayUnionArrayAverage2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionArrayContains2), ArrayUnionArrayContains2, ArrayUnionArrayContains2Rewritten);
        TestsExtensions.TestEquals(nameof(SelectWhereArrayUnionSelectWhereArrayContains), SelectWhereArrayUnionSelectWhereArrayContains, SelectWhereArrayUnionSelectWhereArrayContainsRewritten);
        TestsExtensions.TestEquals(nameof(RangeUnionArray), RangeUnionArray, RangeUnionArrayRewritten);
        TestsExtensions.TestEquals(nameof(RepeatUnionArray), RepeatUnionArray, RepeatUnionArrayRewritten);
        TestsExtensions.TestEquals(nameof(EmptyUnionArray), EmptyUnionArray, EmptyUnionArrayRewritten);
        TestsExtensions.TestEquals(nameof(RangeEmpty2Array), RangeEmpty2Array, RangeEmpty2ArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionRange), ArrayUnionRange, ArrayUnionRangeRewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionRepeat), ArrayUnionRepeat, ArrayUnionRepeatRewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionEmpty), ArrayUnionEmpty, ArrayUnionEmptyRewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionEmpty2), ArrayUnionEmpty2, ArrayUnionEmpty2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionAll), ArrayUnionAll, ArrayUnionAllRewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionNull), ArrayUnionNull, ArrayUnionNullRewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionArrayUnionEnumerable), ArrayUnionArrayUnionEnumerable, ArrayUnionArrayUnionEnumerableRewritten);
        TestsExtensions.TestEquals(nameof(ArrayUnionArrayUnionEnumerable2), ArrayUnionArrayUnionEnumerable2, ArrayUnionArrayUnionEnumerable2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayDistinctUnionArrayDistinct), ArrayDistinctUnionArrayDistinct, ArrayDistinctUnionArrayDistinctRewritten);
        TestsExtensions.TestEquals(nameof(ArrayDistinctUnionArrayDistinctDistinct), ArrayDistinctUnionArrayDistinctDistinct, ArrayDistinctUnionArrayDistinctDistinctRewritten);
        TestsExtensions.TestEquals(nameof(ArrayDistinctUnionArrayDistinctDistinct2), ArrayDistinctUnionArrayDistinctDistinct2, ArrayDistinctUnionArrayDistinctDistinct2Rewritten);
    }

    [NoRewrite]
    public IEnumerable<int> ArrayUnionArray()
    {
        return ArrayItems.Union(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> ArrayUnionArrayRewritten()
    {
        return ArrayUnionArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayUnionSimpleList()
    {
        return ArrayItems.Union(SimpleListItems2);
    } //EndMethod

    public IEnumerable<int> ArrayUnionSimpleListRewritten()
    {
        return ArrayUnionSimpleListRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayUnionEnumerable()
    {
        return ArrayItems.Union(EnumerableItems2);
    } //EndMethod

    public IEnumerable<int> ArrayUnionEnumerableRewritten()
    {
        return ArrayUnionEnumerableRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayUnionMethod()
    {
        return ArrayItems.Union(MethodEnumerable2());
    } //EndMethod

    public IEnumerable<int> ArrayUnionMethodRewritten()
    {
        return ArrayUnionMethodRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListUnionArray()
    {
        return SimpleListItems.Union(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> SimpleListUnionArrayRewritten()
    {
        return SimpleListUnionArrayRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListUnionSimpleList()
    {
        return SimpleListItems.Union(SimpleListItems2);
    } //EndMethod

    public IEnumerable<int> SimpleListUnionSimpleListRewritten()
    {
        return SimpleListUnionSimpleListRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListUnionEnumerable()
    {
        return SimpleListItems.Union(EnumerableItems2);
    } //EndMethod

    public IEnumerable<int> SimpleListUnionEnumerableRewritten()
    {
        return SimpleListUnionEnumerableRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListUnionMethod()
    {
        return SimpleListItems.Union(MethodEnumerable2());
    } //EndMethod

    public IEnumerable<int> SimpleListUnionMethodRewritten()
    {
        return SimpleListUnionMethodRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableUnionArray()
    {
        return EnumerableItems.Union(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> EnumerableUnionArrayRewritten()
    {
        return EnumerableUnionArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableUnionSimpleList()
    {
        return EnumerableItems.Union(SimpleListItems2);
    } //EndMethod

    public IEnumerable<int> EnumerableUnionSimpleListRewritten()
    {
        return EnumerableUnionSimpleListRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableUnionEnumerable()
    {
        return EnumerableItems.Union(EnumerableItems2);
    } //EndMethod

    public IEnumerable<int> EnumerableUnionEnumerableRewritten()
    {
        return EnumerableUnionEnumerableRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableUnionMethod()
    {
        return EnumerableItems.Union(MethodEnumerable2());
    } //EndMethod

    public IEnumerable<int> EnumerableUnionMethodRewritten()
    {
        return EnumerableUnionMethodRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> MethodUnionArray()
    {
        return MethodEnumerable().Union(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> MethodUnionArrayRewritten()
    {
        return MethodEnumerable().Union(ArrayItems2);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> MethodUnionSimpleList()
    {
        return MethodEnumerable().Union(SimpleListItems2);
    } //EndMethod

    public IEnumerable<int> MethodUnionSimpleListRewritten()
    {
        return MethodEnumerable().Union(SimpleListItems2);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> MethodUnionEnumerable()
    {
        return MethodEnumerable().Union(EnumerableItems2);
    } //EndMethod

    public IEnumerable<int> MethodUnionEnumerableRewritten()
    {
        return MethodEnumerable().Union(EnumerableItems2);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> MethodUnionMethod()
    {
        return MethodEnumerable().Union(MethodEnumerable2());
    } //EndMethod

    public IEnumerable<int> MethodUnionMethodRewritten()
    {
        return MethodEnumerable().Union(MethodEnumerable2());
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayUnionArrayToArray()
    {
        return ArrayItems.Union(ArrayItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayUnionArrayToArrayRewritten()
    {
        return ArrayUnionArrayToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayUnionSimpleListToArray()
    {
        return ArrayItems.Union(SimpleListItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayUnionSimpleListToArrayRewritten()
    {
        return ArrayUnionSimpleListToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayUnionEnumerableToArray()
    {
        return ArrayItems.Union(EnumerableItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayUnionEnumerableToArrayRewritten()
    {
        return ArrayUnionEnumerableToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListUnionArrayToArray()
    {
        return SimpleListItems.Union(ArrayItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> SimpleListUnionArrayToArrayRewritten()
    {
        return SimpleListUnionArrayToArrayRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListUnionSimpleListToArray()
    {
        return SimpleListItems.Union(SimpleListItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> SimpleListUnionSimpleListToArrayRewritten()
    {
        return SimpleListUnionSimpleListToArrayRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListUnionEnumerableToArray()
    {
        return SimpleListItems.Union(EnumerableItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> SimpleListUnionEnumerableToArrayRewritten()
    {
        return SimpleListUnionEnumerableToArrayRewritten_ProceduralLinq1(SimpleListItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableUnionArrayToArray()
    {
        return EnumerableItems.Union(ArrayItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableUnionArrayToArrayRewritten()
    {
        return EnumerableUnionArrayToArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableUnionSimpleListToArray()
    {
        return EnumerableItems.Union(SimpleListItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableUnionSimpleListToArrayRewritten()
    {
        return EnumerableUnionSimpleListToArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableUnionEnumerableToArray()
    {
        return EnumerableItems.Union(EnumerableItems2).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableUnionEnumerableToArrayRewritten()
    {
        return EnumerableUnionEnumerableToArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectUnionArray()
    {
        return ArrayItems.Select(x => x + 50).Union(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> ArraySelectUnionArrayRewritten()
    {
        return ArraySelectUnionArrayRewritten_ProceduralLinq1(ArrayItems, x => x + 50);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectUnionArraySelect()
    {
        return ArrayItems.Select(x => x + 50).Union(ArrayItems2.Select(x => x + 50));
    } //EndMethod

    public IEnumerable<int> ArraySelectUnionArraySelectRewritten()
    {
        return ArraySelectUnionArraySelectRewritten_ProceduralLinq2(ArrayItems, x => x + 50);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayWhereUnionArrayWhere()
    {
        return ArrayItems.Where(x => x > 50).Union(ArrayItems2.Where(x => x > 50));
    } //EndMethod

    public IEnumerable<int> ArrayWhereUnionArrayWhereRewritten()
    {
        return ArrayWhereUnionArrayWhereRewritten_ProceduralLinq2(ArrayItems, x => x > 50);
    } //EndMethod

    [NoRewrite]
    public int ArrayUnionArrayCount()
    {
        return ArrayItems.Union(ArrayItems2).Count();
    } //EndMethod

    public int ArrayUnionArrayCountRewritten()
    {
        return ArrayUnionArrayCountRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayUnionArrayCount2()
    {
        return ArrayItems.Union(ArrayItems2).Count(x => x > 70);
    } //EndMethod

    public int ArrayUnionArrayCount2Rewritten()
    {
        return ArrayUnionArrayCount2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayUnionArraySum()
    {
        return ArrayItems.Union(ArrayItems2).Sum();
    } //EndMethod

    public int ArrayUnionArraySumRewritten()
    {
        return ArrayUnionArraySumRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayUnionArraySum2()
    {
        return ArrayItems.Union(ArrayItems2).Sum(x => x + 10);
    } //EndMethod

    public int ArrayUnionArraySum2Rewritten()
    {
        return ArrayUnionArraySum2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayUnionArrayDistinct()
    {
        return ArrayItems.Union(ArrayItems2).Distinct();
    } //EndMethod

    public IEnumerable<int> ArrayUnionArrayDistinctRewritten()
    {
        return ArrayUnionArrayDistinctRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayUnionArrayDistinct2()
    {
        return ArrayItems.Union(ArrayItems2).Distinct(EqualityComparer<int>.Default);
    } //EndMethod

    public IEnumerable<int> ArrayUnionArrayDistinct2Rewritten()
    {
        return ArrayUnionArrayDistinct2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayUnionArrayElementAt()
    {
        return ArrayItems.Union(ArrayItems2).ElementAt(45);
    } //EndMethod

    public int ArrayUnionArrayElementAtRewritten()
    {
        return ArrayUnionArrayElementAtRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayUnionArrayElementAtOrDefault()
    {
        return ArrayItems.Union(ArrayItems2).ElementAtOrDefault(45);
    } //EndMethod

    public int ArrayUnionArrayElementAtOrDefaultRewritten()
    {
        return ArrayUnionArrayElementAtOrDefaultRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayUnionArrayFirst()
    {
        return ArrayItems.Union(ArrayItems2).First();
    } //EndMethod

    public int ArrayUnionArrayFirstRewritten()
    {
        return ArrayUnionArrayFirstRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayUnionArrayFirstOrDefault()
    {
        return ArrayItems.Union(ArrayItems2).FirstOrDefault();
    } //EndMethod

    public int ArrayUnionArrayFirstOrDefaultRewritten()
    {
        return ArrayUnionArrayFirstOrDefaultRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayUnionArrayLast()
    {
        return ArrayItems.Union(ArrayItems2).Last();
    } //EndMethod

    public int ArrayUnionArrayLastRewritten()
    {
        return ArrayUnionArrayLastRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayUnionArrayLastOrDefault()
    {
        return ArrayItems.Union(ArrayItems2).LastOrDefault();
    } //EndMethod

    public int ArrayUnionArrayLastOrDefaultRewritten()
    {
        return ArrayUnionArrayLastOrDefaultRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayUnionArraySingle()
    {
        return ArrayItems.Union(ArrayItems2).Single();
    } //EndMethod

    public int ArrayUnionArraySingleRewritten()
    {
        return ArrayUnionArraySingleRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayUnionArraySingle2()
    {
        return ArrayItems.Union(ArrayItems2).Single(x => x == 76);
    } //EndMethod

    public int ArrayUnionArraySingle2Rewritten()
    {
        return ArrayUnionArraySingle2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayUnionArraySingleOrDefault()
    {
        return ArrayItems.Union(ArrayItems2).SingleOrDefault();
    } //EndMethod

    public int ArrayUnionArraySingleOrDefaultRewritten()
    {
        return ArrayUnionArraySingleOrDefaultRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayUnionArrayMin()
    {
        return ArrayItems.Union(ArrayItems2).Min();
    } //EndMethod

    public int ArrayUnionArrayMinRewritten()
    {
        return ArrayUnionArrayMinRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public decimal ArrayUnionArrayMin2()
    {
        return ArrayItems.Union(ArrayItems2).Min(x => x + 2m);
    } //EndMethod

    public decimal ArrayUnionArrayMin2Rewritten()
    {
        return ArrayUnionArrayMin2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public int ArrayUnionArrayMax()
    {
        return ArrayItems.Union(ArrayItems2).Max();
    } //EndMethod

    public int ArrayUnionArrayMaxRewritten()
    {
        return ArrayUnionArrayMaxRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public decimal ArrayUnionArrayMax2()
    {
        return ArrayItems.Union(ArrayItems2).Max(x => x + 2m);
    } //EndMethod

    public decimal ArrayUnionArrayMax2Rewritten()
    {
        return ArrayUnionArrayMax2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public long ArrayUnionArrayLongCount()
    {
        return ArrayItems.Union(ArrayItems2).LongCount();
    } //EndMethod

    public long ArrayUnionArrayLongCountRewritten()
    {
        return ArrayUnionArrayLongCountRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public long ArrayUnionArrayLongCount2()
    {
        return ArrayItems.Union(ArrayItems2).LongCount(x => x > 50);
    } //EndMethod

    public long ArrayUnionArrayLongCount2Rewritten()
    {
        return ArrayUnionArrayLongCount2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArrayUnionArrayContains()
    {
        return ArrayItems.Union(ArrayItems2).Contains(56);
    } //EndMethod

    public bool ArrayUnionArrayContainsRewritten()
    {
        return ArrayUnionArrayContainsRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double ArrayUnionArrayAverage()
    {
        return ArrayItems.Union(ArrayItems2).Average();
    } //EndMethod

    public double ArrayUnionArrayAverageRewritten()
    {
        return ArrayUnionArrayAverageRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public double ArrayUnionArrayAverage2()
    {
        return ArrayItems.Union(ArrayItems2).Average(x => x + 10);
    } //EndMethod

    public double ArrayUnionArrayAverage2Rewritten()
    {
        return ArrayUnionArrayAverage2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool ArrayUnionArrayContains2()
    {
        return ArrayItems.Union(ArrayItems2).Contains(56, EqualityComparer<int>.Default);
    } //EndMethod

    public bool ArrayUnionArrayContains2Rewritten()
    {
        return ArrayUnionArrayContains2Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public bool SelectWhereArrayUnionSelectWhereArrayContains()
    {
        return ArrayItems.Select(x => x + 10).Where(x => x > 80).Union(ArrayItems2.Select(x => x + 10).Where(x => x > 80)).Contains(112);
    } //EndMethod

    public bool SelectWhereArrayUnionSelectWhereArrayContainsRewritten()
    {
        return SelectWhereArrayUnionSelectWhereArrayContainsRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeUnionArray()
    {
        return Enumerable.Range(20, 100).Union(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> RangeUnionArrayRewritten()
    {
        return RangeUnionArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatUnionArray()
    {
        return Enumerable.Repeat(20, 100).Union(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> RepeatUnionArrayRewritten()
    {
        return RepeatUnionArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EmptyUnionArray()
    {
        return Enumerable.Empty<int>().Union(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> EmptyUnionArrayRewritten()
    {
        return EmptyUnionArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeEmpty2Array()
    {
        return ArrayItems.Where(x => false).Union(ArrayItems2);
    } //EndMethod

    public IEnumerable<int> RangeEmpty2ArrayRewritten()
    {
        return RangeEmpty2ArrayRewritten_ProceduralLinq1(ArrayItems, x => false);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayUnionRange()
    {
        return ArrayItems.Union(Enumerable.Range(70, 260));
    } //EndMethod

    public IEnumerable<int> ArrayUnionRangeRewritten()
    {
        return ArrayUnionRangeRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayUnionRepeat()
    {
        return ArrayItems.Union(Enumerable.Repeat(70, 100));
    } //EndMethod

    public IEnumerable<int> ArrayUnionRepeatRewritten()
    {
        return ArrayUnionRepeatRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayUnionEmpty()
    {
        return ArrayItems.Union(Enumerable.Empty<int>());
    } //EndMethod

    public IEnumerable<int> ArrayUnionEmptyRewritten()
    {
        return ArrayUnionEmptyRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayUnionEmpty2()
    {
        return ArrayItems.Union(ArrayItems2.Where(x => false));
    } //EndMethod

    public IEnumerable<int> ArrayUnionEmpty2Rewritten()
    {
        return ArrayUnionEmpty2Rewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayUnionAll()
    {
        return ArrayItems.Union(Enumerable.Range(0, 1000));
    } //EndMethod

    public IEnumerable<int> ArrayUnionAllRewritten()
    {
        return ArrayUnionAllRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayUnionNull()
    {
        return ArrayItems.Union(null);
    } //EndMethod

    public IEnumerable<int> ArrayUnionNullRewritten()
    {
        return ArrayUnionNullRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayUnionArrayUnionEnumerable()
    {
        return ArrayItems.Union(ArrayItems).Union(EnumerableItems2);
    } //EndMethod

    public IEnumerable<int> ArrayUnionArrayUnionEnumerableRewritten()
    {
        return ArrayUnionArrayUnionEnumerableRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayUnionArrayUnionEnumerable2()
    {
        return ArrayItems.Union(ArrayItems.Union(EnumerableItems2));
    } //EndMethod

    public IEnumerable<int> ArrayUnionArrayUnionEnumerable2Rewritten()
    {
        return ArrayUnionArrayUnionEnumerable2Rewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayDistinctUnionArrayDistinct()
    {
        return ArrayItems.Distinct().Union(ArrayItems.Distinct());
    } //EndMethod

    public IEnumerable<int> ArrayDistinctUnionArrayDistinctRewritten()
    {
        return ArrayDistinctUnionArrayDistinctRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayDistinctUnionArrayDistinctDistinct()
    {
        return ArrayItems.Distinct().Union(ArrayItems.Distinct()).Distinct();
    } //EndMethod

    public IEnumerable<int> ArrayDistinctUnionArrayDistinctDistinctRewritten()
    {
        return ArrayDistinctUnionArrayDistinctDistinctRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayDistinctUnionArrayDistinctDistinct2()
    {
        return ArrayItems.Distinct(EqualityComparer<int>.Default).Union(ArrayItems.Distinct(EqualityComparer<int>.Default)).Distinct(EqualityComparer<int>.Default);
    } //EndMethod

    public IEnumerable<int> ArrayDistinctUnionArrayDistinctDistinct2Rewritten()
    {
        return ArrayDistinctUnionArrayDistinctDistinct2Rewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    System.Collections.Generic.IEnumerable<int> ArrayUnionArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1737;
        HashSet<int> v1738;
        int v1739;
        int v1740;
        v1738 = new HashSet<int>();
        v1737 = 0;
        for (; v1737 < ArrayItems.Length; v1737++)
        {
            v1739 = ArrayItems[v1737];
            if (!(v1738.Add(v1739)))
                continue;
            yield return v1739;
        }

        v1740 = 0;
        for (; v1740 < ArrayItems2.Length; v1740++)
        {
            v1739 = ArrayItems2[v1740];
            if (!(v1738.Add(v1739)))
                continue;
            yield return v1739;
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1741;
        HashSet<int> v1742;
        int v1743;
        IEnumerator<int> v1744;
        v1744 = SimpleListItems2.GetEnumerator();
        v1742 = new HashSet<int>();
        v1741 = 0;
        for (; v1741 < ArrayItems.Length; v1741++)
        {
            v1743 = ArrayItems[v1741];
            if (!(v1742.Add(v1743)))
                continue;
            yield return v1743;
        }

        try
        {
            while (v1744.MoveNext())
            {
                v1743 = v1744.Current;
                if (!(v1742.Add(v1743)))
                    continue;
                yield return v1743;
            }
        }
        finally
        {
            v1744.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1745;
        HashSet<int> v1746;
        int v1747;
        IEnumerator<int> v1748;
        v1748 = EnumerableItems2.GetEnumerator();
        v1746 = new HashSet<int>();
        v1745 = 0;
        for (; v1745 < ArrayItems.Length; v1745++)
        {
            v1747 = ArrayItems[v1745];
            if (!(v1746.Add(v1747)))
                continue;
            yield return v1747;
        }

        try
        {
            while (v1748.MoveNext())
            {
                v1747 = v1748.Current;
                if (!(v1746.Add(v1747)))
                    continue;
                yield return v1747;
            }
        }
        finally
        {
            v1748.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1749;
        HashSet<int> v1750;
        int v1751;
        IEnumerator<int> v1752;
        v1752 = MethodEnumerable2().GetEnumerator();
        v1750 = new HashSet<int>();
        v1749 = 0;
        for (; v1749 < ArrayItems.Length; v1749++)
        {
            v1751 = ArrayItems[v1749];
            if (!(v1750.Add(v1751)))
                continue;
            yield return v1751;
        }

        try
        {
            while (v1752.MoveNext())
            {
                v1751 = v1752.Current;
                if (!(v1750.Add(v1751)))
                    continue;
                yield return v1751;
            }
        }
        finally
        {
            v1752.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> SimpleListUnionArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v1753;
        HashSet<int> v1754;
        int v1755;
        int v1756;
        v1753 = SimpleListItems.GetEnumerator();
        v1754 = new HashSet<int>();
        try
        {
            while (v1753.MoveNext())
            {
                v1755 = v1753.Current;
                if (!(v1754.Add(v1755)))
                    continue;
                yield return v1755;
            }
        }
        finally
        {
            v1753.Dispose();
        }

        v1756 = 0;
        for (; v1756 < ArrayItems2.Length; v1756++)
        {
            v1755 = ArrayItems2[v1756];
            if (!(v1754.Add(v1755)))
                continue;
            yield return v1755;
        }
    }

    System.Collections.Generic.IEnumerable<int> SimpleListUnionSimpleListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v1757;
        HashSet<int> v1758;
        int v1759;
        IEnumerator<int> v1760;
        v1757 = SimpleListItems.GetEnumerator();
        v1760 = SimpleListItems2.GetEnumerator();
        v1758 = new HashSet<int>();
        try
        {
            while (v1757.MoveNext())
            {
                v1759 = v1757.Current;
                if (!(v1758.Add(v1759)))
                    continue;
                yield return v1759;
            }
        }
        finally
        {
            v1757.Dispose();
        }

        try
        {
            while (v1760.MoveNext())
            {
                v1759 = v1760.Current;
                if (!(v1758.Add(v1759)))
                    continue;
                yield return v1759;
            }
        }
        finally
        {
            v1760.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> SimpleListUnionEnumerableRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v1761;
        HashSet<int> v1762;
        int v1763;
        IEnumerator<int> v1764;
        v1761 = SimpleListItems.GetEnumerator();
        v1764 = EnumerableItems2.GetEnumerator();
        v1762 = new HashSet<int>();
        try
        {
            while (v1761.MoveNext())
            {
                v1763 = v1761.Current;
                if (!(v1762.Add(v1763)))
                    continue;
                yield return v1763;
            }
        }
        finally
        {
            v1761.Dispose();
        }

        try
        {
            while (v1764.MoveNext())
            {
                v1763 = v1764.Current;
                if (!(v1762.Add(v1763)))
                    continue;
                yield return v1763;
            }
        }
        finally
        {
            v1764.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> SimpleListUnionMethodRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v1765;
        HashSet<int> v1766;
        int v1767;
        IEnumerator<int> v1768;
        v1765 = SimpleListItems.GetEnumerator();
        v1768 = MethodEnumerable2().GetEnumerator();
        v1766 = new HashSet<int>();
        try
        {
            while (v1765.MoveNext())
            {
                v1767 = v1765.Current;
                if (!(v1766.Add(v1767)))
                    continue;
                yield return v1767;
            }
        }
        finally
        {
            v1765.Dispose();
        }

        try
        {
            while (v1768.MoveNext())
            {
                v1767 = v1768.Current;
                if (!(v1766.Add(v1767)))
                    continue;
                yield return v1767;
            }
        }
        finally
        {
            v1768.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableUnionArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1769;
        HashSet<int> v1770;
        int v1771;
        int v1772;
        v1769 = EnumerableItems.GetEnumerator();
        v1770 = new HashSet<int>();
        try
        {
            while (v1769.MoveNext())
            {
                v1771 = v1769.Current;
                if (!(v1770.Add(v1771)))
                    continue;
                yield return v1771;
            }
        }
        finally
        {
            v1769.Dispose();
        }

        v1772 = 0;
        for (; v1772 < ArrayItems2.Length; v1772++)
        {
            v1771 = ArrayItems2[v1772];
            if (!(v1770.Add(v1771)))
                continue;
            yield return v1771;
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableUnionSimpleListRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1773;
        HashSet<int> v1774;
        int v1775;
        IEnumerator<int> v1776;
        v1773 = EnumerableItems.GetEnumerator();
        v1776 = SimpleListItems2.GetEnumerator();
        v1774 = new HashSet<int>();
        try
        {
            while (v1773.MoveNext())
            {
                v1775 = v1773.Current;
                if (!(v1774.Add(v1775)))
                    continue;
                yield return v1775;
            }
        }
        finally
        {
            v1773.Dispose();
        }

        try
        {
            while (v1776.MoveNext())
            {
                v1775 = v1776.Current;
                if (!(v1774.Add(v1775)))
                    continue;
                yield return v1775;
            }
        }
        finally
        {
            v1776.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableUnionEnumerableRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1777;
        HashSet<int> v1778;
        int v1779;
        IEnumerator<int> v1780;
        v1777 = EnumerableItems.GetEnumerator();
        v1780 = EnumerableItems2.GetEnumerator();
        v1778 = new HashSet<int>();
        try
        {
            while (v1777.MoveNext())
            {
                v1779 = v1777.Current;
                if (!(v1778.Add(v1779)))
                    continue;
                yield return v1779;
            }
        }
        finally
        {
            v1777.Dispose();
        }

        try
        {
            while (v1780.MoveNext())
            {
                v1779 = v1780.Current;
                if (!(v1778.Add(v1779)))
                    continue;
                yield return v1779;
            }
        }
        finally
        {
            v1780.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableUnionMethodRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1781;
        HashSet<int> v1782;
        int v1783;
        IEnumerator<int> v1784;
        v1781 = EnumerableItems.GetEnumerator();
        v1784 = MethodEnumerable2().GetEnumerator();
        v1782 = new HashSet<int>();
        try
        {
            while (v1781.MoveNext())
            {
                v1783 = v1781.Current;
                if (!(v1782.Add(v1783)))
                    continue;
                yield return v1783;
            }
        }
        finally
        {
            v1781.Dispose();
        }

        try
        {
            while (v1784.MoveNext())
            {
                v1783 = v1784.Current;
                if (!(v1782.Add(v1783)))
                    continue;
                yield return v1783;
            }
        }
        finally
        {
            v1784.Dispose();
        }
    }

    int[] ArrayUnionArrayToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1785;
        HashSet<int> v1786;
        int v1787;
        int v1788;
        int v1789;
        int v1790;
        int v1791;
        int[] v1792;
        v1786 = new HashSet<int>();
        v1789 = 0;
        v1790 = (LinqRewrite.Core.IntExtensions.Log2((uint)(ArrayItems2.Length + ArrayItems.Length)) - 3);
        v1790 -= (v1790 % 2);
        v1791 = 8;
        v1792 = new int[8];
        v1785 = 0;
        for (; v1785 < ArrayItems.Length; v1785++)
        {
            v1787 = ArrayItems[v1785];
            if (!(v1786.Add(v1787)))
                continue;
            if (v1789 >= v1791)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems2.Length + ArrayItems.Length), ref v1792, ref v1790, out v1791);
            v1792[v1789] = v1787;
            v1789++;
        }

        v1788 = 0;
        for (; v1788 < ArrayItems2.Length; v1788++)
        {
            v1787 = ArrayItems2[v1788];
            if (!(v1786.Add(v1787)))
                continue;
            if (v1789 >= v1791)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems2.Length + ArrayItems.Length), ref v1792, ref v1790, out v1791);
            v1792[v1789] = v1787;
            v1789++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1792, v1789);
    }

    int[] ArrayUnionSimpleListToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1793;
        HashSet<int> v1794;
        int v1795;
        IEnumerator<int> v1796;
        int v1797;
        int v1798;
        int[] v1799;
        v1796 = SimpleListItems2.GetEnumerator();
        v1794 = new HashSet<int>();
        v1797 = 0;
        v1798 = 8;
        v1799 = new int[8];
        v1793 = 0;
        for (; v1793 < ArrayItems.Length; v1793++)
        {
            v1795 = ArrayItems[v1793];
            if (!(v1794.Add(v1795)))
                continue;
            if (v1797 >= v1798)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1799, ref v1798);
            v1799[v1797] = v1795;
            v1797++;
        }

        try
        {
            while (v1796.MoveNext())
            {
                v1795 = v1796.Current;
                if (!(v1794.Add(v1795)))
                    continue;
                if (v1797 >= v1798)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1799, ref v1798);
                v1799[v1797] = v1795;
                v1797++;
            }
        }
        finally
        {
            v1796.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1799, v1797);
    }

    int[] ArrayUnionEnumerableToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1800;
        HashSet<int> v1801;
        int v1802;
        IEnumerator<int> v1803;
        int v1804;
        int v1805;
        int[] v1806;
        v1803 = EnumerableItems2.GetEnumerator();
        v1801 = new HashSet<int>();
        v1804 = 0;
        v1805 = 8;
        v1806 = new int[8];
        v1800 = 0;
        for (; v1800 < ArrayItems.Length; v1800++)
        {
            v1802 = ArrayItems[v1800];
            if (!(v1801.Add(v1802)))
                continue;
            if (v1804 >= v1805)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1806, ref v1805);
            v1806[v1804] = v1802;
            v1804++;
        }

        try
        {
            while (v1803.MoveNext())
            {
                v1802 = v1803.Current;
                if (!(v1801.Add(v1802)))
                    continue;
                if (v1804 >= v1805)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1806, ref v1805);
                v1806[v1804] = v1802;
                v1804++;
            }
        }
        finally
        {
            v1803.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1806, v1804);
    }

    int[] SimpleListUnionArrayToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v1807;
        HashSet<int> v1808;
        int v1809;
        int v1810;
        int v1811;
        int v1812;
        int[] v1813;
        v1807 = SimpleListItems.GetEnumerator();
        v1808 = new HashSet<int>();
        v1811 = 0;
        v1812 = 8;
        v1813 = new int[8];
        try
        {
            while (v1807.MoveNext())
            {
                v1809 = v1807.Current;
                if (!(v1808.Add(v1809)))
                    continue;
                if (v1811 >= v1812)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1813, ref v1812);
                v1813[v1811] = v1809;
                v1811++;
            }
        }
        finally
        {
            v1807.Dispose();
        }

        v1810 = 0;
        for (; v1810 < ArrayItems2.Length; v1810++)
        {
            v1809 = ArrayItems2[v1810];
            if (!(v1808.Add(v1809)))
                continue;
            if (v1811 >= v1812)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1813, ref v1812);
            v1813[v1811] = v1809;
            v1811++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1813, v1811);
    }

    int[] SimpleListUnionSimpleListToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v1814;
        HashSet<int> v1815;
        int v1816;
        IEnumerator<int> v1817;
        int v1818;
        int v1819;
        int[] v1820;
        v1814 = SimpleListItems.GetEnumerator();
        v1817 = SimpleListItems2.GetEnumerator();
        v1815 = new HashSet<int>();
        v1818 = 0;
        v1819 = 8;
        v1820 = new int[8];
        try
        {
            while (v1814.MoveNext())
            {
                v1816 = v1814.Current;
                if (!(v1815.Add(v1816)))
                    continue;
                if (v1818 >= v1819)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1820, ref v1819);
                v1820[v1818] = v1816;
                v1818++;
            }
        }
        finally
        {
            v1814.Dispose();
        }

        try
        {
            while (v1817.MoveNext())
            {
                v1816 = v1817.Current;
                if (!(v1815.Add(v1816)))
                    continue;
                if (v1818 >= v1819)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1820, ref v1819);
                v1820[v1818] = v1816;
                v1818++;
            }
        }
        finally
        {
            v1817.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1820, v1818);
    }

    int[] SimpleListUnionEnumerableToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v1821;
        HashSet<int> v1822;
        int v1823;
        IEnumerator<int> v1824;
        int v1825;
        int v1826;
        int[] v1827;
        v1821 = SimpleListItems.GetEnumerator();
        v1824 = EnumerableItems2.GetEnumerator();
        v1822 = new HashSet<int>();
        v1825 = 0;
        v1826 = 8;
        v1827 = new int[8];
        try
        {
            while (v1821.MoveNext())
            {
                v1823 = v1821.Current;
                if (!(v1822.Add(v1823)))
                    continue;
                if (v1825 >= v1826)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1827, ref v1826);
                v1827[v1825] = v1823;
                v1825++;
            }
        }
        finally
        {
            v1821.Dispose();
        }

        try
        {
            while (v1824.MoveNext())
            {
                v1823 = v1824.Current;
                if (!(v1822.Add(v1823)))
                    continue;
                if (v1825 >= v1826)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1827, ref v1826);
                v1827[v1825] = v1823;
                v1825++;
            }
        }
        finally
        {
            v1824.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1827, v1825);
    }

    int[] EnumerableUnionArrayToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1828;
        HashSet<int> v1829;
        int v1830;
        int v1831;
        int v1832;
        int v1833;
        int[] v1834;
        v1828 = EnumerableItems.GetEnumerator();
        v1829 = new HashSet<int>();
        v1832 = 0;
        v1833 = 8;
        v1834 = new int[8];
        try
        {
            while (v1828.MoveNext())
            {
                v1830 = v1828.Current;
                if (!(v1829.Add(v1830)))
                    continue;
                if (v1832 >= v1833)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1834, ref v1833);
                v1834[v1832] = v1830;
                v1832++;
            }
        }
        finally
        {
            v1828.Dispose();
        }

        v1831 = 0;
        for (; v1831 < ArrayItems2.Length; v1831++)
        {
            v1830 = ArrayItems2[v1831];
            if (!(v1829.Add(v1830)))
                continue;
            if (v1832 >= v1833)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1834, ref v1833);
            v1834[v1832] = v1830;
            v1832++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1834, v1832);
    }

    int[] EnumerableUnionSimpleListToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1835;
        HashSet<int> v1836;
        int v1837;
        IEnumerator<int> v1838;
        int v1839;
        int v1840;
        int[] v1841;
        v1835 = EnumerableItems.GetEnumerator();
        v1838 = SimpleListItems2.GetEnumerator();
        v1836 = new HashSet<int>();
        v1839 = 0;
        v1840 = 8;
        v1841 = new int[8];
        try
        {
            while (v1835.MoveNext())
            {
                v1837 = v1835.Current;
                if (!(v1836.Add(v1837)))
                    continue;
                if (v1839 >= v1840)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1841, ref v1840);
                v1841[v1839] = v1837;
                v1839++;
            }
        }
        finally
        {
            v1835.Dispose();
        }

        try
        {
            while (v1838.MoveNext())
            {
                v1837 = v1838.Current;
                if (!(v1836.Add(v1837)))
                    continue;
                if (v1839 >= v1840)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1841, ref v1840);
                v1841[v1839] = v1837;
                v1839++;
            }
        }
        finally
        {
            v1838.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1841, v1839);
    }

    int[] EnumerableUnionEnumerableToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1842;
        HashSet<int> v1843;
        int v1844;
        IEnumerator<int> v1845;
        int v1846;
        int v1847;
        int[] v1848;
        v1842 = EnumerableItems.GetEnumerator();
        v1845 = EnumerableItems2.GetEnumerator();
        v1843 = new HashSet<int>();
        v1846 = 0;
        v1847 = 8;
        v1848 = new int[8];
        try
        {
            while (v1842.MoveNext())
            {
                v1844 = v1842.Current;
                if (!(v1843.Add(v1844)))
                    continue;
                if (v1846 >= v1847)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1848, ref v1847);
                v1848[v1846] = v1844;
                v1846++;
            }
        }
        finally
        {
            v1842.Dispose();
        }

        try
        {
            while (v1845.MoveNext())
            {
                v1844 = v1845.Current;
                if (!(v1843.Add(v1844)))
                    continue;
                if (v1846 >= v1847)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1848, ref v1847);
                v1848[v1846] = v1844;
                v1846++;
            }
        }
        finally
        {
            v1845.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1848, v1846);
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectUnionArrayRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int> v1850)
    {
        int v1849;
        HashSet<int> v1851;
        int v1852;
        int v1853;
        v1851 = new HashSet<int>();
        v1849 = 0;
        for (; v1849 < ArrayItems.Length; v1849++)
        {
            v1852 = v1850(ArrayItems[v1849]);
            if (!(v1851.Add(v1852)))
                continue;
            yield return v1852;
        }

        v1853 = 0;
        for (; v1853 < ArrayItems2.Length; v1853++)
        {
            v1852 = ArrayItems2[v1853];
            if (!(v1851.Add(v1852)))
                continue;
            yield return v1852;
        }
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectUnionArraySelectRewritten_ProceduralLinq1(int[] ArrayItems2, System.Func<int, int> v1855)
    {
        int v1854;
        v1854 = 0;
        for (; v1854 < ArrayItems2.Length; v1854++)
            yield return v1855(ArrayItems2[v1854]);
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectUnionArraySelectRewritten_ProceduralLinq2(int[] ArrayItems, System.Func<int, int> v1857)
    {
        int v1856;
        HashSet<int> v1858;
        int v1859;
        IEnumerator<int> v1860;
        v1860 = ArraySelectUnionArraySelectRewritten_ProceduralLinq1(ArrayItems2, x => x + 50).GetEnumerator();
        v1858 = new HashSet<int>();
        v1856 = 0;
        for (; v1856 < ArrayItems.Length; v1856++)
        {
            v1859 = v1857(ArrayItems[v1856]);
            if (!(v1858.Add(v1859)))
                continue;
            yield return v1859;
        }

        try
        {
            while (v1860.MoveNext())
            {
                v1859 = v1860.Current;
                if (!(v1858.Add(v1859)))
                    continue;
                yield return v1859;
            }
        }
        finally
        {
            v1860.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereUnionArrayWhereRewritten_ProceduralLinq1(int[] ArrayItems2, System.Func<int, bool> v1862)
    {
        int v1861;
        v1861 = 0;
        for (; v1861 < ArrayItems2.Length; v1861++)
        {
            if (!(v1862(ArrayItems2[v1861])))
                continue;
            yield return ArrayItems2[v1861];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereUnionArrayWhereRewritten_ProceduralLinq2(int[] ArrayItems, System.Func<int, bool> v1864)
    {
        int v1863;
        HashSet<int> v1865;
        int v1866;
        IEnumerator<int> v1867;
        v1867 = ArrayWhereUnionArrayWhereRewritten_ProceduralLinq1(ArrayItems2, x => x > 50).GetEnumerator();
        v1865 = new HashSet<int>();
        v1863 = 0;
        for (; v1863 < ArrayItems.Length; v1863++)
        {
            if (!(v1864(ArrayItems[v1863])))
                continue;
            v1866 = ArrayItems[v1863];
            if (!(v1865.Add(v1866)))
                continue;
            yield return v1866;
        }

        try
        {
            while (v1867.MoveNext())
            {
                v1866 = v1867.Current;
                if (!(v1865.Add(v1866)))
                    continue;
                yield return v1866;
            }
        }
        finally
        {
            v1867.Dispose();
        }
    }

    int ArrayUnionArrayCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1868;
        HashSet<int> v1869;
        int v1870;
        int v1871;
        int v1872;
        v1869 = new HashSet<int>();
        v1872 = 0;
        v1868 = 0;
        for (; v1868 < ArrayItems.Length; v1868++)
        {
            v1870 = ArrayItems[v1868];
            if (!(v1869.Add(v1870)))
                continue;
            v1872++;
        }

        v1871 = 0;
        for (; v1871 < ArrayItems2.Length; v1871++)
        {
            v1870 = ArrayItems2[v1871];
            if (!(v1869.Add(v1870)))
                continue;
            v1872++;
        }

        return v1872;
    }

    int ArrayUnionArrayCount2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1873;
        HashSet<int> v1874;
        int v1875;
        int v1876;
        int v1877;
        v1874 = new HashSet<int>();
        v1877 = 0;
        v1873 = 0;
        for (; v1873 < ArrayItems.Length; v1873++)
        {
            v1875 = ArrayItems[v1873];
            if (!(v1874.Add(v1875)))
                continue;
            if (!((v1875 > 70)))
                continue;
            v1877++;
        }

        v1876 = 0;
        for (; v1876 < ArrayItems2.Length; v1876++)
        {
            v1875 = ArrayItems2[v1876];
            if (!(v1874.Add(v1875)))
                continue;
            if (!((v1875 > 70)))
                continue;
            v1877++;
        }

        return v1877;
    }

    int ArrayUnionArraySumRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1878;
        HashSet<int> v1879;
        int v1880;
        int v1881;
        int v1882;
        v1879 = new HashSet<int>();
        v1882 = 0;
        v1878 = 0;
        for (; v1878 < ArrayItems.Length; v1878++)
        {
            v1880 = ArrayItems[v1878];
            if (!(v1879.Add(v1880)))
                continue;
            v1882 += v1880;
        }

        v1881 = 0;
        for (; v1881 < ArrayItems2.Length; v1881++)
        {
            v1880 = ArrayItems2[v1881];
            if (!(v1879.Add(v1880)))
                continue;
            v1882 += v1880;
        }

        return v1882;
    }

    int ArrayUnionArraySum2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1883;
        HashSet<int> v1884;
        int v1885;
        int v1886;
        int v1887;
        int v1888;
        v1884 = new HashSet<int>();
        v1887 = 0;
        v1883 = 0;
        for (; v1883 < ArrayItems.Length; v1883++)
        {
            v1885 = ArrayItems[v1883];
            if (!(v1884.Add(v1885)))
                continue;
            v1888 = (v1885 + 10);
            v1887 += v1888;
        }

        v1886 = 0;
        for (; v1886 < ArrayItems2.Length; v1886++)
        {
            v1885 = ArrayItems2[v1886];
            if (!(v1884.Add(v1885)))
                continue;
            v1888 = (v1885 + 10);
            v1887 += v1888;
        }

        return v1887;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1889;
        HashSet<int> v1890;
        int v1891;
        int v1892;
        HashSet<int> v1893;
        v1890 = new HashSet<int>();
        v1893 = new HashSet<int>();
        v1889 = 0;
        for (; v1889 < ArrayItems.Length; v1889++)
        {
            v1891 = ArrayItems[v1889];
            if (!(v1890.Add(v1891)))
                continue;
            if (!(v1893.Add(v1891)))
                continue;
            yield return v1891;
        }

        v1892 = 0;
        for (; v1892 < ArrayItems2.Length; v1892++)
        {
            v1891 = ArrayItems2[v1892];
            if (!(v1890.Add(v1891)))
                continue;
            if (!(v1893.Add(v1891)))
                continue;
            yield return v1891;
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionArrayDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1894;
        HashSet<int> v1895;
        int v1896;
        int v1897;
        HashSet<int> v1898;
        v1895 = new HashSet<int>();
        v1898 = new HashSet<int>(EqualityComparer<int>.Default);
        v1894 = 0;
        for (; v1894 < ArrayItems.Length; v1894++)
        {
            v1896 = ArrayItems[v1894];
            if (!(v1895.Add(v1896)))
                continue;
            if (!(v1898.Add(v1896)))
                continue;
            yield return v1896;
        }

        v1897 = 0;
        for (; v1897 < ArrayItems2.Length; v1897++)
        {
            v1896 = ArrayItems2[v1897];
            if (!(v1895.Add(v1896)))
                continue;
            if (!(v1898.Add(v1896)))
                continue;
            yield return v1896;
        }
    }

    int ArrayUnionArrayElementAtRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1899;
        HashSet<int> v1900;
        int v1901;
        int v1902;
        int v1903;
        v1900 = new HashSet<int>();
        v1903 = 0;
        v1899 = 0;
        for (; v1899 < ArrayItems.Length; v1899++)
        {
            v1901 = ArrayItems[v1899];
            if (!(v1900.Add(v1901)))
                continue;
            if (v1903 == 45)
                return v1901;
            v1903++;
        }

        v1902 = 0;
        for (; v1902 < ArrayItems2.Length; v1902++)
        {
            v1901 = ArrayItems2[v1902];
            if (!(v1900.Add(v1901)))
                continue;
            if (v1903 == 45)
                return v1901;
            v1903++;
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArrayUnionArrayElementAtOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1904;
        HashSet<int> v1905;
        int v1906;
        int v1907;
        int v1908;
        v1905 = new HashSet<int>();
        v1908 = 0;
        v1904 = 0;
        for (; v1904 < ArrayItems.Length; v1904++)
        {
            v1906 = ArrayItems[v1904];
            if (!(v1905.Add(v1906)))
                continue;
            if (v1908 == 45)
                return v1906;
            v1908++;
        }

        v1907 = 0;
        for (; v1907 < ArrayItems2.Length; v1907++)
        {
            v1906 = ArrayItems2[v1907];
            if (!(v1905.Add(v1906)))
                continue;
            if (v1908 == 45)
                return v1906;
            v1908++;
        }

        return default(int);
    }

    int ArrayUnionArrayFirstRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1909;
        HashSet<int> v1910;
        int v1911;
        int v1912;
        v1910 = new HashSet<int>();
        v1909 = 0;
        for (; v1909 < ArrayItems.Length; v1909++)
        {
            v1911 = ArrayItems[v1909];
            if (!(v1910.Add(v1911)))
                continue;
            return v1911;
        }

        v1912 = 0;
        for (; v1912 < ArrayItems2.Length; v1912++)
        {
            v1911 = ArrayItems2[v1912];
            if (!(v1910.Add(v1911)))
                continue;
            return v1911;
        }

        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int ArrayUnionArrayFirstOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1913;
        HashSet<int> v1914;
        int v1915;
        int v1916;
        v1914 = new HashSet<int>();
        v1913 = 0;
        for (; v1913 < ArrayItems.Length; v1913++)
        {
            v1915 = ArrayItems[v1913];
            if (!(v1914.Add(v1915)))
                continue;
            return v1915;
        }

        v1916 = 0;
        for (; v1916 < ArrayItems2.Length; v1916++)
        {
            v1915 = ArrayItems2[v1916];
            if (!(v1914.Add(v1915)))
                continue;
            return v1915;
        }

        return default(int);
    }

    int ArrayUnionArrayLastRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1917;
        HashSet<int> v1918;
        int v1919;
        int v1920;
        int? v1921;
        v1918 = new HashSet<int>();
        v1921 = null;
        v1917 = 0;
        for (; v1917 < ArrayItems.Length; v1917++)
        {
            v1919 = ArrayItems[v1917];
            if (!(v1918.Add(v1919)))
                continue;
            v1921 = v1919;
        }

        v1920 = 0;
        for (; v1920 < ArrayItems2.Length; v1920++)
        {
            v1919 = ArrayItems2[v1920];
            if (!(v1918.Add(v1919)))
                continue;
            v1921 = v1919;
        }

        if (v1921 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1921;
    }

    int ArrayUnionArrayLastOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1922;
        HashSet<int> v1923;
        int v1924;
        int v1925;
        int? v1926;
        v1923 = new HashSet<int>();
        v1926 = null;
        v1922 = 0;
        for (; v1922 < ArrayItems.Length; v1922++)
        {
            v1924 = ArrayItems[v1922];
            if (!(v1923.Add(v1924)))
                continue;
            v1926 = v1924;
        }

        v1925 = 0;
        for (; v1925 < ArrayItems2.Length; v1925++)
        {
            v1924 = ArrayItems2[v1925];
            if (!(v1923.Add(v1924)))
                continue;
            v1926 = v1924;
        }

        if (v1926 == null)
            return default(int);
        else
            return (int)v1926;
    }

    int ArrayUnionArraySingleRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1927;
        HashSet<int> v1928;
        int v1929;
        int v1930;
        int? v1931;
        v1928 = new HashSet<int>();
        v1931 = null;
        v1927 = 0;
        for (; v1927 < ArrayItems.Length; v1927++)
        {
            v1929 = ArrayItems[v1927];
            if (!(v1928.Add(v1929)))
                continue;
            if (v1931 == null)
                v1931 = v1929;
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        v1930 = 0;
        for (; v1930 < ArrayItems2.Length; v1930++)
        {
            v1929 = ArrayItems2[v1930];
            if (!(v1928.Add(v1929)))
                continue;
            if (v1931 == null)
                v1931 = v1929;
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v1931 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1931;
    }

    int ArrayUnionArraySingle2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1932;
        HashSet<int> v1933;
        int v1934;
        int v1935;
        int? v1936;
        v1933 = new HashSet<int>();
        v1936 = null;
        v1932 = 0;
        for (; v1932 < ArrayItems.Length; v1932++)
        {
            v1934 = ArrayItems[v1932];
            if (!(v1933.Add(v1934)))
                continue;
            if ((v1934 == 76))
                if (v1936 == null)
                    v1936 = v1934;
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        v1935 = 0;
        for (; v1935 < ArrayItems2.Length; v1935++)
        {
            v1934 = ArrayItems2[v1935];
            if (!(v1933.Add(v1934)))
                continue;
            if ((v1934 == 76))
                if (v1936 == null)
                    v1936 = v1934;
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v1936 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v1936;
    }

    int ArrayUnionArraySingleOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1937;
        HashSet<int> v1938;
        int v1939;
        int v1940;
        int? v1941;
        v1938 = new HashSet<int>();
        v1941 = null;
        v1937 = 0;
        for (; v1937 < ArrayItems.Length; v1937++)
        {
            v1939 = ArrayItems[v1937];
            if (!(v1938.Add(v1939)))
                continue;
            if (v1941 == null)
                v1941 = v1939;
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        v1940 = 0;
        for (; v1940 < ArrayItems2.Length; v1940++)
        {
            v1939 = ArrayItems2[v1940];
            if (!(v1938.Add(v1939)))
                continue;
            if (v1941 == null)
                v1941 = v1939;
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v1941 == null)
            return default(int);
        else
            return (int)v1941;
    }

    int ArrayUnionArrayMinRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1942;
        HashSet<int> v1943;
        int v1944;
        int v1945;
        int v1946;
        bool v1947;
        v1943 = new HashSet<int>();
        v1946 = 2147483647;
        v1947 = false;
        v1942 = 0;
        for (; v1942 < ArrayItems.Length; v1942++)
        {
            v1944 = ArrayItems[v1942];
            if (!(v1943.Add(v1944)))
                continue;
            if (v1944 >= v1946)
                continue;
            v1946 = v1944;
            v1947 = true;
        }

        v1945 = 0;
        for (; v1945 < ArrayItems2.Length; v1945++)
        {
            v1944 = ArrayItems2[v1945];
            if (!(v1943.Add(v1944)))
                continue;
            if (v1944 >= v1946)
                continue;
            v1946 = v1944;
            v1947 = true;
        }

        if (!(v1947))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1946;
    }

    decimal ArrayUnionArrayMin2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1948;
        HashSet<int> v1949;
        int v1950;
        int v1951;
        decimal v1952;
        bool v1953;
        decimal v1954;
        v1949 = new HashSet<int>();
        v1952 = 79228162514264337593543950335M;
        v1953 = false;
        v1948 = 0;
        for (; v1948 < ArrayItems.Length; v1948++)
        {
            v1950 = ArrayItems[v1948];
            if (!(v1949.Add(v1950)))
                continue;
            v1954 = (v1950 + 2m);
            if (v1954 >= v1952)
                continue;
            v1952 = v1954;
            v1953 = true;
        }

        v1951 = 0;
        for (; v1951 < ArrayItems2.Length; v1951++)
        {
            v1950 = ArrayItems2[v1951];
            if (!(v1949.Add(v1950)))
                continue;
            v1954 = (v1950 + 2m);
            if (v1954 >= v1952)
                continue;
            v1952 = v1954;
            v1953 = true;
        }

        if (!(v1953))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1952;
    }

    int ArrayUnionArrayMaxRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1955;
        HashSet<int> v1956;
        int v1957;
        int v1958;
        int v1959;
        bool v1960;
        v1956 = new HashSet<int>();
        v1959 = -2147483648;
        v1960 = false;
        v1955 = 0;
        for (; v1955 < ArrayItems.Length; v1955++)
        {
            v1957 = ArrayItems[v1955];
            if (!(v1956.Add(v1957)))
                continue;
            if (v1957 <= v1959)
                continue;
            v1959 = v1957;
            v1960 = true;
        }

        v1958 = 0;
        for (; v1958 < ArrayItems2.Length; v1958++)
        {
            v1957 = ArrayItems2[v1958];
            if (!(v1956.Add(v1957)))
                continue;
            if (v1957 <= v1959)
                continue;
            v1959 = v1957;
            v1960 = true;
        }

        if (!(v1960))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1959;
    }

    decimal ArrayUnionArrayMax2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1961;
        HashSet<int> v1962;
        int v1963;
        int v1964;
        decimal v1965;
        bool v1966;
        decimal v1967;
        v1962 = new HashSet<int>();
        v1965 = -79228162514264337593543950335M;
        v1966 = false;
        v1961 = 0;
        for (; v1961 < ArrayItems.Length; v1961++)
        {
            v1963 = ArrayItems[v1961];
            if (!(v1962.Add(v1963)))
                continue;
            v1967 = (v1963 + 2m);
            if (v1967 <= v1965)
                continue;
            v1965 = v1967;
            v1966 = true;
        }

        v1964 = 0;
        for (; v1964 < ArrayItems2.Length; v1964++)
        {
            v1963 = ArrayItems2[v1964];
            if (!(v1962.Add(v1963)))
                continue;
            v1967 = (v1963 + 2m);
            if (v1967 <= v1965)
                continue;
            v1965 = v1967;
            v1966 = true;
        }

        if (!(v1966))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v1965;
    }

    long ArrayUnionArrayLongCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1968;
        HashSet<int> v1969;
        int v1970;
        int v1971;
        long v1972;
        v1969 = new HashSet<int>();
        v1972 = 0;
        v1968 = 0;
        for (; v1968 < ArrayItems.Length; v1968++)
        {
            v1970 = ArrayItems[v1968];
            if (!(v1969.Add(v1970)))
                continue;
            v1972++;
        }

        v1971 = 0;
        for (; v1971 < ArrayItems2.Length; v1971++)
        {
            v1970 = ArrayItems2[v1971];
            if (!(v1969.Add(v1970)))
                continue;
            v1972++;
        }

        return v1972;
    }

    long ArrayUnionArrayLongCount2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1973;
        HashSet<int> v1974;
        int v1975;
        int v1976;
        long v1977;
        v1974 = new HashSet<int>();
        v1977 = 0;
        v1973 = 0;
        for (; v1973 < ArrayItems.Length; v1973++)
        {
            v1975 = ArrayItems[v1973];
            if (!(v1974.Add(v1975)))
                continue;
            if (!((v1975 > 50)))
                continue;
            v1977++;
        }

        v1976 = 0;
        for (; v1976 < ArrayItems2.Length; v1976++)
        {
            v1975 = ArrayItems2[v1976];
            if (!(v1974.Add(v1975)))
                continue;
            if (!((v1975 > 50)))
                continue;
            v1977++;
        }

        return v1977;
    }

    bool ArrayUnionArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1978;
        HashSet<int> v1979;
        int v1980;
        int v1981;
        v1979 = new HashSet<int>();
        v1978 = 0;
        for (; v1978 < ArrayItems.Length; v1978++)
        {
            v1980 = ArrayItems[v1978];
            if (!(v1979.Add(v1980)))
                continue;
            if (v1980 == 56)
                return true;
        }

        v1981 = 0;
        for (; v1981 < ArrayItems2.Length; v1981++)
        {
            v1980 = ArrayItems2[v1981];
            if (!(v1979.Add(v1980)))
                continue;
            if (v1980 == 56)
                return true;
        }

        return false;
    }

    double ArrayUnionArrayAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1982;
        HashSet<int> v1983;
        int v1984;
        int v1985;
        double v1986;
        int v1987;
        v1983 = new HashSet<int>();
        v1986 = 0;
        v1987 = 0;
        v1982 = 0;
        for (; v1982 < ArrayItems.Length; v1982++)
        {
            v1984 = ArrayItems[v1982];
            if (!(v1983.Add(v1984)))
                continue;
            v1986 += v1984;
            v1987++;
        }

        v1985 = 0;
        for (; v1985 < ArrayItems2.Length; v1985++)
        {
            v1984 = ArrayItems2[v1985];
            if (!(v1983.Add(v1984)))
                continue;
            v1986 += v1984;
            v1987++;
        }

        if (v1987 == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v1986 / v1987);
    }

    double ArrayUnionArrayAverage2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1988;
        HashSet<int> v1989;
        int v1990;
        int v1991;
        double v1992;
        int v1993;
        v1989 = new HashSet<int>();
        v1992 = 0;
        v1993 = 0;
        v1988 = 0;
        for (; v1988 < ArrayItems.Length; v1988++)
        {
            v1990 = ArrayItems[v1988];
            if (!(v1989.Add(v1990)))
                continue;
            v1992 += (v1990 + 10);
            v1993++;
        }

        v1991 = 0;
        for (; v1991 < ArrayItems2.Length; v1991++)
        {
            v1990 = ArrayItems2[v1991];
            if (!(v1989.Add(v1990)))
                continue;
            v1992 += (v1990 + 10);
            v1993++;
        }

        if (v1993 == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v1992 / v1993);
    }

    bool ArrayUnionArrayContains2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1994;
        HashSet<int> v1995;
        int v1996;
        int v1997;
        System.Collections.Generic.EqualityComparer<int> v1998;
        v1995 = new HashSet<int>();
        v1998 = EqualityComparer<int>.Default;
        v1994 = 0;
        for (; v1994 < ArrayItems.Length; v1994++)
        {
            v1996 = ArrayItems[v1994];
            if (!(v1995.Add(v1996)))
                continue;
            if (v1998.Equals(v1996, 56))
                return true;
        }

        v1997 = 0;
        for (; v1997 < ArrayItems2.Length; v1997++)
        {
            v1996 = ArrayItems2[v1997];
            if (!(v1995.Add(v1996)))
                continue;
            if (v1998.Equals(v1996, 56))
                return true;
        }

        return false;
    }

    System.Collections.Generic.IEnumerable<int> SelectWhereArrayUnionSelectWhereArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems2, System.Func<int, int> v2000, System.Func<int, bool> v2002)
    {
        int v1999;
        int v2001;
        v1999 = 0;
        for (; v1999 < ArrayItems2.Length; v1999++)
        {
            v2001 = v2000(ArrayItems2[v1999]);
            if (!(v2002(v2001)))
                continue;
            yield return v2001;
        }
    }

    bool SelectWhereArrayUnionSelectWhereArrayContainsRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v2003;
        int v2004;
        HashSet<int> v2005;
        IEnumerator<int> v2006;
        v2006 = SelectWhereArrayUnionSelectWhereArrayContainsRewritten_ProceduralLinq1(ArrayItems2, x => x + 10, x => x > 80).GetEnumerator();
        v2005 = new HashSet<int>();
        v2003 = 0;
        for (; v2003 < ArrayItems.Length; v2003++)
        {
            v2004 = (ArrayItems[v2003] + 10);
            if (!((v2004 > 80)))
                continue;
            if (!(v2005.Add(v2004)))
                continue;
            if (v2004 == 112)
                return true;
        }

        try
        {
            while (v2006.MoveNext())
            {
                v2004 = v2006.Current;
                if (!(v2005.Add(v2004)))
                    continue;
                if (v2004 == 112)
                    return true;
            }
        }
        finally
        {
            v2006.Dispose();
        }

        return false;
    }

    System.Collections.Generic.IEnumerable<int> RangeUnionArrayRewritten_ProceduralLinq1()
    {
        int v2007;
        if (100 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        HashSet<int> v2008;
        int v2009;
        int v2010;
        v2008 = new HashSet<int>();
        v2007 = 0;
        for (; v2007 < 100; v2007++)
        {
            v2009 = (v2007 + 20);
            if (!(v2008.Add(v2009)))
                continue;
            yield return v2009;
        }

        v2010 = 0;
        for (; v2010 < ArrayItems2.Length; v2010++)
        {
            v2009 = ArrayItems2[v2010];
            if (!(v2008.Add(v2009)))
                continue;
            yield return v2009;
        }
    }

    System.Collections.Generic.IEnumerable<int> RepeatUnionArrayRewritten_ProceduralLinq1()
    {
        int v2011;
        if (100 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        HashSet<int> v2012;
        int v2013;
        int v2014;
        v2012 = new HashSet<int>();
        v2011 = 0;
        for (; v2011 < 100; v2011++)
        {
            v2013 = 20;
            if (!(v2012.Add(v2013)))
                continue;
            yield return v2013;
        }

        v2014 = 0;
        for (; v2014 < ArrayItems2.Length; v2014++)
        {
            v2013 = ArrayItems2[v2014];
            if (!(v2012.Add(v2013)))
                continue;
            yield return v2013;
        }
    }

    System.Collections.Generic.IEnumerable<int> EmptyUnionArrayRewritten_ProceduralLinq1()
    {
        int v2015;
        HashSet<int> v2016;
        int v2017;
        int v2018;
        v2016 = new HashSet<int>();
        v2015 = 0;
        for (; v2015 < 0; v2015++)
        {
            v2017 = default(int);
            if (!(v2016.Add(v2017)))
                continue;
            yield return v2017;
        }

        v2018 = 0;
        for (; v2018 < ArrayItems2.Length; v2018++)
        {
            v2017 = ArrayItems2[v2018];
            if (!(v2016.Add(v2017)))
                continue;
            yield return v2017;
        }
    }

    System.Collections.Generic.IEnumerable<int> RangeEmpty2ArrayRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, bool> v2020)
    {
        int v2019;
        HashSet<int> v2021;
        int v2022;
        v2021 = new HashSet<int>();
        v2019 = 0;
        for (; v2019 < ArrayItems.Length; v2019++)
        {
            if (!(v2020(ArrayItems[v2019])))
                continue;
            v2022 = ArrayItems[v2019];
            if (!(v2021.Add(v2022)))
                continue;
            yield return v2022;
        }

        v2019 = 0;
        for (; v2019 < ArrayItems2.Length; v2019++)
        {
            v2022 = ArrayItems2[v2019];
            if (!(v2021.Add(v2022)))
                continue;
            yield return v2022;
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionRangeRewritten_ProceduralLinq1()
    {
        int v2023;
        if (260 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        v2023 = 0;
        for (; v2023 < 260; v2023++)
            yield return (v2023 + 70);
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionRangeRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v2024;
        HashSet<int> v2025;
        int v2026;
        IEnumerator<int> v2027;
        v2027 = ArrayUnionRangeRewritten_ProceduralLinq1().GetEnumerator();
        v2025 = new HashSet<int>();
        v2024 = 0;
        for (; v2024 < ArrayItems.Length; v2024++)
        {
            v2026 = ArrayItems[v2024];
            if (!(v2025.Add(v2026)))
                continue;
            yield return v2026;
        }

        try
        {
            while (v2027.MoveNext())
            {
                v2026 = v2027.Current;
                if (!(v2025.Add(v2026)))
                    continue;
                yield return v2026;
            }
        }
        finally
        {
            v2027.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionRepeatRewritten_ProceduralLinq1()
    {
        int v2028;
        if (100 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        v2028 = 0;
        for (; v2028 < 100; v2028++)
            yield return 70;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionRepeatRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v2029;
        HashSet<int> v2030;
        int v2031;
        IEnumerator<int> v2032;
        v2032 = ArrayUnionRepeatRewritten_ProceduralLinq1().GetEnumerator();
        v2030 = new HashSet<int>();
        v2029 = 0;
        for (; v2029 < ArrayItems.Length; v2029++)
        {
            v2031 = ArrayItems[v2029];
            if (!(v2030.Add(v2031)))
                continue;
            yield return v2031;
        }

        try
        {
            while (v2032.MoveNext())
            {
                v2031 = v2032.Current;
                if (!(v2030.Add(v2031)))
                    continue;
                yield return v2031;
            }
        }
        finally
        {
            v2032.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionEmptyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2033;
        HashSet<int> v2034;
        int v2035;
        IEnumerator<int> v2036;
        v2036 = Enumerable.Empty<int>().GetEnumerator();
        v2034 = new HashSet<int>();
        v2033 = 0;
        for (; v2033 < ArrayItems.Length; v2033++)
        {
            v2035 = ArrayItems[v2033];
            if (!(v2034.Add(v2035)))
                continue;
            yield return v2035;
        }

        try
        {
            while (v2036.MoveNext())
            {
                v2035 = v2036.Current;
                if (!(v2034.Add(v2035)))
                    continue;
                yield return v2035;
            }
        }
        finally
        {
            v2036.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionEmpty2Rewritten_ProceduralLinq1(int[] ArrayItems2, System.Func<int, bool> v2038)
    {
        int v2037;
        v2037 = 0;
        for (; v2037 < ArrayItems2.Length; v2037++)
        {
            if (!(v2038(ArrayItems2[v2037])))
                continue;
            yield return ArrayItems2[v2037];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionEmpty2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v2039;
        HashSet<int> v2040;
        int v2041;
        IEnumerator<int> v2042;
        v2042 = ArrayUnionEmpty2Rewritten_ProceduralLinq1(ArrayItems2, x => false).GetEnumerator();
        v2040 = new HashSet<int>();
        v2039 = 0;
        for (; v2039 < ArrayItems.Length; v2039++)
        {
            v2041 = ArrayItems[v2039];
            if (!(v2040.Add(v2041)))
                continue;
            yield return v2041;
        }

        try
        {
            while (v2042.MoveNext())
            {
                v2041 = v2042.Current;
                if (!(v2040.Add(v2041)))
                    continue;
                yield return v2041;
            }
        }
        finally
        {
            v2042.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionAllRewritten_ProceduralLinq1()
    {
        int v2043;
        if (1000 < 0)
            throw new System.InvalidOperationException("Negative number of elements");
        v2043 = 0;
        for (; v2043 < 1000; v2043++)
            yield return (v2043 + 0);
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionAllRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v2044;
        HashSet<int> v2045;
        int v2046;
        IEnumerator<int> v2047;
        v2047 = ArrayUnionAllRewritten_ProceduralLinq1().GetEnumerator();
        v2045 = new HashSet<int>();
        v2044 = 0;
        for (; v2044 < ArrayItems.Length; v2044++)
        {
            v2046 = ArrayItems[v2044];
            if (!(v2045.Add(v2046)))
                continue;
            yield return v2046;
        }

        try
        {
            while (v2047.MoveNext())
            {
                v2046 = v2047.Current;
                if (!(v2045.Add(v2046)))
                    continue;
                yield return v2046;
            }
        }
        finally
        {
            v2047.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionNullRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2048;
        throw new System.InvalidOperationException("Collection was null");
        v2048 = 0;
        for (; v2048 < ArrayItems.Length; v2048++)
            yield return ArrayItems[v2048];
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionArrayUnionEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2049;
        HashSet<int> v2050;
        int v2051;
        int v2052;
        HashSet<int> v2053;
        IEnumerator<int> v2054;
        v2054 = EnumerableItems2.GetEnumerator();
        v2050 = new HashSet<int>();
        v2053 = new HashSet<int>();
        v2049 = 0;
        for (; v2049 < ArrayItems.Length; v2049++)
        {
            v2051 = ArrayItems[v2049];
            if (!(v2050.Add(v2051)))
                continue;
            if (!(v2053.Add(v2051)))
                continue;
            yield return v2051;
        }

        v2052 = 0;
        for (; v2052 < ArrayItems.Length; v2052++)
        {
            v2051 = ArrayItems[v2052];
            if (!(v2050.Add(v2051)))
                continue;
            if (!(v2053.Add(v2051)))
                continue;
            yield return v2051;
        }

        try
        {
            while (v2054.MoveNext())
            {
                v2051 = v2054.Current;
                if (!(v2053.Add(v2051)))
                    continue;
                yield return v2051;
            }
        }
        finally
        {
            v2054.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionArrayUnionEnumerable2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2055;
        HashSet<int> v2056;
        int v2057;
        IEnumerator<int> v2058;
        v2058 = EnumerableItems2.GetEnumerator();
        v2056 = new HashSet<int>();
        v2055 = 0;
        for (; v2055 < ArrayItems.Length; v2055++)
        {
            v2057 = ArrayItems[v2055];
            if (!(v2056.Add(v2057)))
                continue;
            yield return v2057;
        }

        try
        {
            while (v2058.MoveNext())
            {
                v2057 = v2058.Current;
                if (!(v2056.Add(v2057)))
                    continue;
                yield return v2057;
            }
        }
        finally
        {
            v2058.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionArrayUnionEnumerable2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v2059;
        HashSet<int> v2060;
        int v2061;
        IEnumerator<int> v2062;
        v2062 = ArrayUnionArrayUnionEnumerable2Rewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v2060 = new HashSet<int>();
        v2059 = 0;
        for (; v2059 < ArrayItems.Length; v2059++)
        {
            v2061 = ArrayItems[v2059];
            if (!(v2060.Add(v2061)))
                continue;
            yield return v2061;
        }

        try
        {
            while (v2062.MoveNext())
            {
                v2061 = v2062.Current;
                if (!(v2060.Add(v2061)))
                    continue;
                yield return v2061;
            }
        }
        finally
        {
            v2062.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctUnionArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2063;
        HashSet<int> v2064;
        v2064 = new HashSet<int>();
        v2063 = 0;
        for (; v2063 < ArrayItems.Length; v2063++)
        {
            if (!(v2064.Add(ArrayItems[v2063])))
                continue;
            yield return ArrayItems[v2063];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctUnionArrayDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v2065;
        HashSet<int> v2066;
        HashSet<int> v2067;
        int v2068;
        IEnumerator<int> v2069;
        v2069 = ArrayDistinctUnionArrayDistinctRewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v2066 = new HashSet<int>();
        v2067 = new HashSet<int>();
        v2065 = 0;
        for (; v2065 < ArrayItems.Length; v2065++)
        {
            if (!(v2066.Add(ArrayItems[v2065])))
                continue;
            v2068 = ArrayItems[v2065];
            if (!(v2067.Add(v2068)))
                continue;
            yield return v2068;
        }

        try
        {
            while (v2069.MoveNext())
            {
                v2068 = v2069.Current;
                if (!(v2067.Add(v2068)))
                    continue;
                yield return v2068;
            }
        }
        finally
        {
            v2069.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctUnionArrayDistinctDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2070;
        HashSet<int> v2071;
        v2071 = new HashSet<int>();
        v2070 = 0;
        for (; v2070 < ArrayItems.Length; v2070++)
        {
            if (!(v2071.Add(ArrayItems[v2070])))
                continue;
            yield return ArrayItems[v2070];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctUnionArrayDistinctDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v2072;
        HashSet<int> v2073;
        HashSet<int> v2074;
        int v2075;
        IEnumerator<int> v2076;
        HashSet<int> v2077;
        v2076 = ArrayDistinctUnionArrayDistinctDistinctRewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v2073 = new HashSet<int>();
        v2074 = new HashSet<int>();
        v2077 = new HashSet<int>();
        v2072 = 0;
        for (; v2072 < ArrayItems.Length; v2072++)
        {
            if (!(v2073.Add(ArrayItems[v2072])))
                continue;
            v2075 = ArrayItems[v2072];
            if (!(v2074.Add(v2075)))
                continue;
            if (!(v2077.Add(v2075)))
                continue;
            yield return v2075;
        }

        try
        {
            while (v2076.MoveNext())
            {
                v2075 = v2076.Current;
                if (!(v2074.Add(v2075)))
                    continue;
                if (!(v2077.Add(v2075)))
                    continue;
                yield return v2075;
            }
        }
        finally
        {
            v2076.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctUnionArrayDistinctDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2078;
        HashSet<int> v2079;
        v2079 = new HashSet<int>(EqualityComparer<int>.Default);
        v2078 = 0;
        for (; v2078 < ArrayItems.Length; v2078++)
        {
            if (!(v2079.Add(ArrayItems[v2078])))
                continue;
            yield return ArrayItems[v2078];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctUnionArrayDistinctDistinct2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v2080;
        HashSet<int> v2081;
        HashSet<int> v2082;
        int v2083;
        IEnumerator<int> v2084;
        HashSet<int> v2085;
        v2084 = ArrayDistinctUnionArrayDistinctDistinct2Rewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v2081 = new HashSet<int>(EqualityComparer<int>.Default);
        v2082 = new HashSet<int>();
        v2085 = new HashSet<int>(EqualityComparer<int>.Default);
        v2080 = 0;
        for (; v2080 < ArrayItems.Length; v2080++)
        {
            if (!(v2081.Add(ArrayItems[v2080])))
                continue;
            v2083 = ArrayItems[v2080];
            if (!(v2082.Add(v2083)))
                continue;
            if (!(v2085.Add(v2083)))
                continue;
            yield return v2083;
        }

        try
        {
            while (v2084.MoveNext())
            {
                v2083 = v2084.Current;
                if (!(v2082.Add(v2083)))
                    continue;
                if (!(v2085.Add(v2083)))
                    continue;
                yield return v2083;
            }
        }
        finally
        {
            v2084.Dispose();
        }
    }
}}