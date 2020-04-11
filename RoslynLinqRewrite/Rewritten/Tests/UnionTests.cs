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
        return ArraySelectUnionArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectUnionArraySelect()
    {
        return ArrayItems.Select(x => x + 50).Union(ArrayItems2.Select(x => x + 50));
    } //EndMethod

    public IEnumerable<int> ArraySelectUnionArraySelectRewritten()
    {
        return ArraySelectUnionArraySelectRewritten_ProceduralLinq2(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayWhereUnionArrayWhere()
    {
        return ArrayItems.Where(x => x > 50).Union(ArrayItems2.Where(x => x > 50));
    } //EndMethod

    public IEnumerable<int> ArrayWhereUnionArrayWhereRewritten()
    {
        return ArrayWhereUnionArrayWhereRewritten_ProceduralLinq2(ArrayItems);
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
        return RangeEmpty2ArrayRewritten_ProceduralLinq1(ArrayItems);
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
        int v2697;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2698;
        int v2699;
        int v2700;
        v2698 = new HashSet<int>();
        v2697 = (0);
        for (; v2697 < (ArrayItems.Length); v2697 += 1)
        {
            v2699 = (ArrayItems[v2697]);
            if (!(v2698.Add((v2699))))
                continue;
            yield return (v2699);
        }

        v2700 = (0);
        for (; v2700 < (ArrayItems2.Length); v2700 += 1)
        {
            v2699 = ArrayItems2[v2700];
            if (!(v2698.Add((v2699))))
                continue;
            yield return (v2699);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2701;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2702;
        int v2703;
        int v2704;
        v2704 = SimpleListItems2.Count;
        int v2705;
        v2702 = new HashSet<int>();
        v2701 = (0);
        for (; v2701 < (ArrayItems.Length); v2701 += 1)
        {
            v2703 = (ArrayItems[v2701]);
            if (!(v2702.Add((v2703))))
                continue;
            yield return (v2703);
        }

        v2705 = (0);
        for (; v2705 < (v2704); v2705 += 1)
        {
            v2703 = SimpleListItems2[v2705];
            if (!(v2702.Add((v2703))))
                continue;
            yield return (v2703);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2706;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2707;
        int v2708;
        IEnumerator<int> v2709;
        v2709 = EnumerableItems2.GetEnumerator();
        v2707 = new HashSet<int>();
        v2706 = (0);
        for (; v2706 < (ArrayItems.Length); v2706 += 1)
        {
            v2708 = (ArrayItems[v2706]);
            if (!(v2707.Add((v2708))))
                continue;
            yield return (v2708);
        }

        try
        {
            while (v2709.MoveNext())
            {
                v2708 = v2709.Current;
                if (!(v2707.Add((v2708))))
                    continue;
                yield return (v2708);
            }
        }
        finally
        {
            v2709.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2710;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2711;
        int v2712;
        IEnumerator<int> v2713;
        v2713 = MethodEnumerable2().GetEnumerator();
        v2711 = new HashSet<int>();
        v2710 = (0);
        for (; v2710 < (ArrayItems.Length); v2710 += 1)
        {
            v2712 = (ArrayItems[v2710]);
            if (!(v2711.Add((v2712))))
                continue;
            yield return (v2712);
        }

        try
        {
            while (v2713.MoveNext())
            {
                v2712 = v2713.Current;
                if (!(v2711.Add((v2712))))
                    continue;
                yield return (v2712);
            }
        }
        finally
        {
            v2713.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SimpleListUnionArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v2714;
        v2714 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v2715;
        v2715 = SimpleListItems;
        int v2716;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2717;
        int v2718;
        int v2719;
        v2717 = new HashSet<int>();
        v2716 = (0);
        for (; v2716 < (v2714); v2716 += 1)
        {
            v2718 = (v2715[v2716]);
            if (!(v2717.Add((v2718))))
                continue;
            yield return (v2718);
        }

        v2719 = (0);
        for (; v2719 < (ArrayItems2.Length); v2719 += 1)
        {
            v2718 = ArrayItems2[v2719];
            if (!(v2717.Add((v2718))))
                continue;
            yield return (v2718);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SimpleListUnionSimpleListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v2720;
        v2720 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v2721;
        v2721 = SimpleListItems;
        int v2722;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2723;
        int v2724;
        int v2725;
        v2725 = SimpleListItems2.Count;
        int v2726;
        v2723 = new HashSet<int>();
        v2722 = (0);
        for (; v2722 < (v2720); v2722 += 1)
        {
            v2724 = (v2721[v2722]);
            if (!(v2723.Add((v2724))))
                continue;
            yield return (v2724);
        }

        v2726 = (0);
        for (; v2726 < (v2725); v2726 += 1)
        {
            v2724 = SimpleListItems2[v2726];
            if (!(v2723.Add((v2724))))
                continue;
            yield return (v2724);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SimpleListUnionEnumerableRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v2727;
        v2727 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v2728;
        v2728 = SimpleListItems;
        int v2729;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2730;
        int v2731;
        IEnumerator<int> v2732;
        v2732 = EnumerableItems2.GetEnumerator();
        v2730 = new HashSet<int>();
        v2729 = (0);
        for (; v2729 < (v2727); v2729 += 1)
        {
            v2731 = (v2728[v2729]);
            if (!(v2730.Add((v2731))))
                continue;
            yield return (v2731);
        }

        try
        {
            while (v2732.MoveNext())
            {
                v2731 = v2732.Current;
                if (!(v2730.Add((v2731))))
                    continue;
                yield return (v2731);
            }
        }
        finally
        {
            v2732.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SimpleListUnionMethodRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v2733;
        v2733 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v2734;
        v2734 = SimpleListItems;
        int v2735;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2736;
        int v2737;
        IEnumerator<int> v2738;
        v2738 = MethodEnumerable2().GetEnumerator();
        v2736 = new HashSet<int>();
        v2735 = (0);
        for (; v2735 < (v2733); v2735 += 1)
        {
            v2737 = (v2734[v2735]);
            if (!(v2736.Add((v2737))))
                continue;
            yield return (v2737);
        }

        try
        {
            while (v2738.MoveNext())
            {
                v2737 = v2738.Current;
                if (!(v2736.Add((v2737))))
                    continue;
                yield return (v2737);
            }
        }
        finally
        {
            v2738.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableUnionArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2739;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2740;
        int v2741;
        int v2742;
        v2739 = EnumerableItems.GetEnumerator();
        v2740 = new HashSet<int>();
        try
        {
            while (v2739.MoveNext())
            {
                v2741 = (v2739.Current);
                if (!(v2740.Add((v2741))))
                    continue;
                yield return (v2741);
            }
        }
        finally
        {
            v2739.Dispose();
        }

        v2742 = (0);
        for (; v2742 < (ArrayItems2.Length); v2742 += 1)
        {
            v2741 = ArrayItems2[v2742];
            if (!(v2740.Add((v2741))))
                continue;
            yield return (v2741);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableUnionSimpleListRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2743;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2744;
        int v2745;
        int v2746;
        v2746 = SimpleListItems2.Count;
        int v2747;
        v2743 = EnumerableItems.GetEnumerator();
        v2744 = new HashSet<int>();
        try
        {
            while (v2743.MoveNext())
            {
                v2745 = (v2743.Current);
                if (!(v2744.Add((v2745))))
                    continue;
                yield return (v2745);
            }
        }
        finally
        {
            v2743.Dispose();
        }

        v2747 = (0);
        for (; v2747 < (v2746); v2747 += 1)
        {
            v2745 = SimpleListItems2[v2747];
            if (!(v2744.Add((v2745))))
                continue;
            yield return (v2745);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableUnionEnumerableRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2748;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2749;
        int v2750;
        IEnumerator<int> v2751;
        v2748 = EnumerableItems.GetEnumerator();
        v2751 = EnumerableItems2.GetEnumerator();
        v2749 = new HashSet<int>();
        try
        {
            while (v2748.MoveNext())
            {
                v2750 = (v2748.Current);
                if (!(v2749.Add((v2750))))
                    continue;
                yield return (v2750);
            }
        }
        finally
        {
            v2748.Dispose();
        }

        try
        {
            while (v2751.MoveNext())
            {
                v2750 = v2751.Current;
                if (!(v2749.Add((v2750))))
                    continue;
                yield return (v2750);
            }
        }
        finally
        {
            v2751.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableUnionMethodRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2752;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2753;
        int v2754;
        IEnumerator<int> v2755;
        v2752 = EnumerableItems.GetEnumerator();
        v2755 = MethodEnumerable2().GetEnumerator();
        v2753 = new HashSet<int>();
        try
        {
            while (v2752.MoveNext())
            {
                v2754 = (v2752.Current);
                if (!(v2753.Add((v2754))))
                    continue;
                yield return (v2754);
            }
        }
        finally
        {
            v2752.Dispose();
        }

        try
        {
            while (v2755.MoveNext())
            {
                v2754 = v2755.Current;
                if (!(v2753.Add((v2754))))
                    continue;
                yield return (v2754);
            }
        }
        finally
        {
            v2755.Dispose();
        }

        yield break;
    }

    int[] ArrayUnionArrayToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2756;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2757;
        int v2758;
        int v2759;
        int v2760;
        int v2761;
        int v2762;
        int[] v2763;
        v2757 = new HashSet<int>();
        v2760 = 0;
        v2761 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems2.Length + ArrayItems.Length))) - 3);
        v2761 -= (v2761 % 2);
        v2762 = 8;
        v2763 = new int[8];
        v2756 = (0);
        for (; v2756 < (ArrayItems.Length); v2756 += 1)
        {
            v2758 = (ArrayItems[v2756]);
            if (!(v2757.Add((v2758))))
                continue;
            if (v2760 >= v2762)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems2.Length + ArrayItems.Length), ref v2763, ref v2761, out v2762);
            v2763[v2760] = (v2758);
            v2760++;
        }

        v2759 = (0);
        for (; v2759 < (ArrayItems2.Length); v2759 += 1)
        {
            v2758 = ArrayItems2[v2759];
            if (!(v2757.Add((v2758))))
                continue;
            if (v2760 >= v2762)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems2.Length + ArrayItems.Length), ref v2763, ref v2761, out v2762);
            v2763[v2760] = (v2758);
            v2760++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2763, v2760);
    }

    int[] ArrayUnionSimpleListToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2764;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2765;
        int v2766;
        int v2767;
        v2767 = SimpleListItems2.Count;
        int v2768;
        int v2769;
        int v2770;
        int v2771;
        int[] v2772;
        v2765 = new HashSet<int>();
        v2769 = 0;
        v2770 = (LinqRewrite.Core.IntExtensions.Log2((uint)((v2767 + ArrayItems.Length))) - 3);
        v2770 -= (v2770 % 2);
        v2771 = 8;
        v2772 = new int[8];
        v2764 = (0);
        for (; v2764 < (ArrayItems.Length); v2764 += 1)
        {
            v2766 = (ArrayItems[v2764]);
            if (!(v2765.Add((v2766))))
                continue;
            if (v2769 >= v2771)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (v2767 + ArrayItems.Length), ref v2772, ref v2770, out v2771);
            v2772[v2769] = (v2766);
            v2769++;
        }

        v2768 = (0);
        for (; v2768 < (v2767); v2768 += 1)
        {
            v2766 = SimpleListItems2[v2768];
            if (!(v2765.Add((v2766))))
                continue;
            if (v2769 >= v2771)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (v2767 + ArrayItems.Length), ref v2772, ref v2770, out v2771);
            v2772[v2769] = (v2766);
            v2769++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2772, v2769);
    }

    int[] ArrayUnionEnumerableToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2773;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2774;
        int v2775;
        IEnumerator<int> v2776;
        int v2777;
        int v2778;
        int[] v2779;
        v2776 = EnumerableItems2.GetEnumerator();
        v2774 = new HashSet<int>();
        v2777 = 0;
        v2778 = 8;
        v2779 = new int[8];
        v2773 = (0);
        for (; v2773 < (ArrayItems.Length); v2773 += 1)
        {
            v2775 = (ArrayItems[v2773]);
            if (!(v2774.Add((v2775))))
                continue;
            if (v2777 >= v2778)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2779, ref v2778);
            v2779[v2777] = (v2775);
            v2777++;
        }

        try
        {
            while (v2776.MoveNext())
            {
                v2775 = v2776.Current;
                if (!(v2774.Add((v2775))))
                    continue;
                if (v2777 >= v2778)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2779, ref v2778);
                v2779[v2777] = (v2775);
                v2777++;
            }
        }
        finally
        {
            v2776.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2779, v2777);
    }

    int[] SimpleListUnionArrayToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v2780;
        v2780 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v2781;
        v2781 = SimpleListItems;
        int v2782;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2783;
        int v2784;
        int v2785;
        int v2786;
        int v2787;
        int v2788;
        int[] v2789;
        v2783 = new HashSet<int>();
        v2786 = 0;
        v2787 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems2.Length + v2780))) - 3);
        v2787 -= (v2787 % 2);
        v2788 = 8;
        v2789 = new int[8];
        v2782 = (0);
        for (; v2782 < (v2780); v2782 += 1)
        {
            v2784 = (v2781[v2782]);
            if (!(v2783.Add((v2784))))
                continue;
            if (v2786 >= v2788)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems2.Length + v2780), ref v2789, ref v2787, out v2788);
            v2789[v2786] = (v2784);
            v2786++;
        }

        v2785 = (0);
        for (; v2785 < (ArrayItems2.Length); v2785 += 1)
        {
            v2784 = ArrayItems2[v2785];
            if (!(v2783.Add((v2784))))
                continue;
            if (v2786 >= v2788)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems2.Length + v2780), ref v2789, ref v2787, out v2788);
            v2789[v2786] = (v2784);
            v2786++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2789, v2786);
    }

    int[] SimpleListUnionSimpleListToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v2790;
        v2790 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v2791;
        v2791 = SimpleListItems;
        int v2792;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2793;
        int v2794;
        int v2795;
        v2795 = SimpleListItems2.Count;
        int v2796;
        int v2797;
        int v2798;
        int v2799;
        int[] v2800;
        v2793 = new HashSet<int>();
        v2797 = 0;
        v2798 = (LinqRewrite.Core.IntExtensions.Log2((uint)((v2795 + v2790))) - 3);
        v2798 -= (v2798 % 2);
        v2799 = 8;
        v2800 = new int[8];
        v2792 = (0);
        for (; v2792 < (v2790); v2792 += 1)
        {
            v2794 = (v2791[v2792]);
            if (!(v2793.Add((v2794))))
                continue;
            if (v2797 >= v2799)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (v2795 + v2790), ref v2800, ref v2798, out v2799);
            v2800[v2797] = (v2794);
            v2797++;
        }

        v2796 = (0);
        for (; v2796 < (v2795); v2796 += 1)
        {
            v2794 = SimpleListItems2[v2796];
            if (!(v2793.Add((v2794))))
                continue;
            if (v2797 >= v2799)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (v2795 + v2790), ref v2800, ref v2798, out v2799);
            v2800[v2797] = (v2794);
            v2797++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2800, v2797);
    }

    int[] SimpleListUnionEnumerableToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v2801;
        v2801 = SimpleListItems.Count;
        LinqRewrite.Core.SimpleList.SimpleList<int> v2802;
        v2802 = SimpleListItems;
        int v2803;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2804;
        int v2805;
        IEnumerator<int> v2806;
        int v2807;
        int v2808;
        int[] v2809;
        v2806 = EnumerableItems2.GetEnumerator();
        v2804 = new HashSet<int>();
        v2807 = 0;
        v2808 = 8;
        v2809 = new int[8];
        v2803 = (0);
        for (; v2803 < (v2801); v2803 += 1)
        {
            v2805 = (v2802[v2803]);
            if (!(v2804.Add((v2805))))
                continue;
            if (v2807 >= v2808)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2809, ref v2808);
            v2809[v2807] = (v2805);
            v2807++;
        }

        try
        {
            while (v2806.MoveNext())
            {
                v2805 = v2806.Current;
                if (!(v2804.Add((v2805))))
                    continue;
                if (v2807 >= v2808)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2809, ref v2808);
                v2809[v2807] = (v2805);
                v2807++;
            }
        }
        finally
        {
            v2806.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2809, v2807);
    }

    int[] EnumerableUnionArrayToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2810;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2811;
        int v2812;
        int v2813;
        int v2814;
        int v2815;
        int[] v2816;
        v2810 = EnumerableItems.GetEnumerator();
        v2811 = new HashSet<int>();
        v2814 = 0;
        v2815 = 8;
        v2816 = new int[8];
        try
        {
            while (v2810.MoveNext())
            {
                v2812 = (v2810.Current);
                if (!(v2811.Add((v2812))))
                    continue;
                if (v2814 >= v2815)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2816, ref v2815);
                v2816[v2814] = (v2812);
                v2814++;
            }
        }
        finally
        {
            v2810.Dispose();
        }

        v2813 = (0);
        for (; v2813 < (ArrayItems2.Length); v2813 += 1)
        {
            v2812 = ArrayItems2[v2813];
            if (!(v2811.Add((v2812))))
                continue;
            if (v2814 >= v2815)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2816, ref v2815);
            v2816[v2814] = (v2812);
            v2814++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2816, v2814);
    }

    int[] EnumerableUnionSimpleListToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2817;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2818;
        int v2819;
        int v2820;
        v2820 = SimpleListItems2.Count;
        int v2821;
        int v2822;
        int v2823;
        int[] v2824;
        v2817 = EnumerableItems.GetEnumerator();
        v2818 = new HashSet<int>();
        v2822 = 0;
        v2823 = 8;
        v2824 = new int[8];
        try
        {
            while (v2817.MoveNext())
            {
                v2819 = (v2817.Current);
                if (!(v2818.Add((v2819))))
                    continue;
                if (v2822 >= v2823)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2824, ref v2823);
                v2824[v2822] = (v2819);
                v2822++;
            }
        }
        finally
        {
            v2817.Dispose();
        }

        v2821 = (0);
        for (; v2821 < (v2820); v2821 += 1)
        {
            v2819 = SimpleListItems2[v2821];
            if (!(v2818.Add((v2819))))
                continue;
            if (v2822 >= v2823)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2824, ref v2823);
            v2824[v2822] = (v2819);
            v2822++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2824, v2822);
    }

    int[] EnumerableUnionEnumerableToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2825;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2826;
        int v2827;
        IEnumerator<int> v2828;
        int v2829;
        int v2830;
        int[] v2831;
        v2825 = EnumerableItems.GetEnumerator();
        v2828 = EnumerableItems2.GetEnumerator();
        v2826 = new HashSet<int>();
        v2829 = 0;
        v2830 = 8;
        v2831 = new int[8];
        try
        {
            while (v2825.MoveNext())
            {
                v2827 = (v2825.Current);
                if (!(v2826.Add((v2827))))
                    continue;
                if (v2829 >= v2830)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2831, ref v2830);
                v2831[v2829] = (v2827);
                v2829++;
            }
        }
        finally
        {
            v2825.Dispose();
        }

        try
        {
            while (v2828.MoveNext())
            {
                v2827 = v2828.Current;
                if (!(v2826.Add((v2827))))
                    continue;
                if (v2829 >= v2830)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2831, ref v2830);
                v2831[v2829] = (v2827);
                v2829++;
            }
        }
        finally
        {
            v2828.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2831, v2829);
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectUnionArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2832;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2833;
        int v2834;
        int v2835;
        v2833 = new HashSet<int>();
        v2832 = (0);
        for (; v2832 < (ArrayItems.Length); v2832 += 1)
        {
            v2834 = (50 + ArrayItems[v2832]);
            if (!(v2833.Add((v2834))))
                continue;
            yield return (v2834);
        }

        v2835 = (0);
        for (; v2835 < (ArrayItems2.Length); v2835 += 1)
        {
            v2834 = ArrayItems2[v2835];
            if (!(v2833.Add((v2834))))
                continue;
            yield return (v2834);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectUnionArraySelectRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v2837;
        v2837 = (0);
        for (; v2837 < (ArrayItems2.Length); v2837 += 1)
            yield return (((ArrayItems2[v2837]) + 50));
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectUnionArraySelectRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v2838;
        if (ArraySelectUnionArraySelectRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2839;
        int v2840;
        IEnumerator<int> v2841;
        v2841 = ArraySelectUnionArraySelectRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v2839 = new HashSet<int>();
        v2838 = (0);
        for (; v2838 < (ArrayItems.Length); v2838 += 1)
        {
            v2840 = (50 + ArrayItems[v2838]);
            if (!(v2839.Add((v2840))))
                continue;
            yield return (v2840);
        }

        try
        {
            while (v2841.MoveNext())
            {
                v2840 = v2841.Current;
                if (!(v2839.Add((v2840))))
                    continue;
                yield return (v2840);
            }
        }
        finally
        {
            v2841.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereUnionArrayWhereRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v2842;
        v2842 = (0);
        for (; v2842 < (ArrayItems2.Length); v2842 += 1)
        {
            if (!((((ArrayItems2[v2842])) > 50)))
                continue;
            yield return ((ArrayItems2[v2842]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereUnionArrayWhereRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v2843;
        if (ArrayWhereUnionArrayWhereRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2844;
        int v2845;
        IEnumerator<int> v2846;
        v2846 = ArrayWhereUnionArrayWhereRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v2844 = new HashSet<int>();
        v2843 = (0);
        for (; v2843 < (ArrayItems.Length); v2843 += 1)
        {
            if (!((((ArrayItems[v2843])) > 50)))
                continue;
            v2845 = ((ArrayItems[v2843]));
            if (!(v2844.Add((v2845))))
                continue;
            yield return (v2845);
        }

        try
        {
            while (v2846.MoveNext())
            {
                v2845 = v2846.Current;
                if (!(v2844.Add((v2845))))
                    continue;
                yield return (v2845);
            }
        }
        finally
        {
            v2846.Dispose();
        }

        yield break;
    }

    int ArrayUnionArrayCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2847;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2848;
        int v2849;
        int v2850;
        int v2851;
        v2848 = new HashSet<int>();
        v2851 = 0;
        v2847 = (0);
        for (; v2847 < (ArrayItems.Length); v2847 += 1)
        {
            v2849 = (ArrayItems[v2847]);
            if (!(v2848.Add((v2849))))
                continue;
            v2851++;
        }

        v2850 = (0);
        for (; v2850 < (ArrayItems2.Length); v2850 += 1)
        {
            v2849 = ArrayItems2[v2850];
            if (!(v2848.Add((v2849))))
                continue;
            v2851++;
        }

        return v2851;
    }

    int ArrayUnionArrayCount2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2852;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2853;
        int v2854;
        int v2855;
        int v2856;
        v2853 = new HashSet<int>();
        v2856 = 0;
        v2852 = (0);
        for (; v2852 < (ArrayItems.Length); v2852 += 1)
        {
            v2854 = (ArrayItems[v2852]);
            if (!(v2853.Add((v2854))))
                continue;
            if (!(((v2854) > 70)))
                continue;
            v2856++;
        }

        v2855 = (0);
        for (; v2855 < (ArrayItems2.Length); v2855 += 1)
        {
            v2854 = ArrayItems2[v2855];
            if (!(v2853.Add((v2854))))
                continue;
            if (!(((v2854) > 70)))
                continue;
            v2856++;
        }

        return v2856;
    }

    int ArrayUnionArraySumRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2857;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2858;
        int v2859;
        int v2860;
        int v2861;
        v2858 = new HashSet<int>();
        v2861 = 0;
        v2857 = (0);
        for (; v2857 < (ArrayItems.Length); v2857 += 1)
        {
            v2859 = (ArrayItems[v2857]);
            if (!(v2858.Add((v2859))))
                continue;
            v2861 += (v2859);
        }

        v2860 = (0);
        for (; v2860 < (ArrayItems2.Length); v2860 += 1)
        {
            v2859 = ArrayItems2[v2860];
            if (!(v2858.Add((v2859))))
                continue;
            v2861 += (v2859);
        }

        return v2861;
    }

    int ArrayUnionArraySum2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2862;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2863;
        int v2864;
        int v2865;
        int v2866;
        v2863 = new HashSet<int>();
        v2866 = 0;
        v2862 = (0);
        for (; v2862 < (ArrayItems.Length); v2862 += 1)
        {
            v2864 = (ArrayItems[v2862]);
            if (!(v2863.Add((v2864))))
                continue;
            v2866 += ((v2864) + 10);
        }

        v2865 = (0);
        for (; v2865 < (ArrayItems2.Length); v2865 += 1)
        {
            v2864 = ArrayItems2[v2865];
            if (!(v2863.Add((v2864))))
                continue;
            v2866 += ((v2864) + 10);
        }

        return v2866;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2867;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2868;
        int v2869;
        int v2870;
        HashSet<int> v2871;
        v2868 = new HashSet<int>();
        v2871 = new HashSet<int>();
        v2867 = (0);
        for (; v2867 < (ArrayItems.Length); v2867 += 1)
        {
            v2869 = (ArrayItems[v2867]);
            if (!(v2868.Add((v2869))))
                continue;
            if (!(v2871.Add(((v2869)))))
                continue;
            yield return ((v2869));
        }

        v2870 = (0);
        for (; v2870 < (ArrayItems2.Length); v2870 += 1)
        {
            v2869 = ArrayItems2[v2870];
            if (!(v2868.Add((v2869))))
                continue;
            if (!(v2871.Add(((v2869)))))
                continue;
            yield return ((v2869));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionArrayDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2872;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2873;
        int v2874;
        int v2875;
        HashSet<int> v2876;
        v2873 = new HashSet<int>();
        v2876 = new HashSet<int>(EqualityComparer<int>.Default);
        v2872 = (0);
        for (; v2872 < (ArrayItems.Length); v2872 += 1)
        {
            v2874 = (ArrayItems[v2872]);
            if (!(v2873.Add((v2874))))
                continue;
            if (!(v2876.Add(((v2874)))))
                continue;
            yield return ((v2874));
        }

        v2875 = (0);
        for (; v2875 < (ArrayItems2.Length); v2875 += 1)
        {
            v2874 = ArrayItems2[v2875];
            if (!(v2873.Add((v2874))))
                continue;
            if (!(v2876.Add(((v2874)))))
                continue;
            yield return ((v2874));
        }

        yield break;
    }

    int ArrayUnionArrayElementAtRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2877;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2878;
        int v2879;
        int v2880;
        int v2881;
        v2878 = new HashSet<int>();
        v2881 = 0;
        v2877 = (0);
        for (; v2877 < (ArrayItems.Length); v2877 += 1)
        {
            v2879 = (ArrayItems[v2877]);
            if (!(v2878.Add((v2879))))
                continue;
            if (v2881 == 45)
                return (v2879);
            v2881++;
        }

        v2880 = (0);
        for (; v2880 < (ArrayItems2.Length); v2880 += 1)
        {
            v2879 = ArrayItems2[v2880];
            if (!(v2878.Add((v2879))))
                continue;
            if (v2881 == 45)
                return (v2879);
            v2881++;
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArrayUnionArrayElementAtOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2882;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2883;
        int v2884;
        int v2885;
        int v2886;
        v2883 = new HashSet<int>();
        v2886 = 0;
        v2882 = (0);
        for (; v2882 < (ArrayItems.Length); v2882 += 1)
        {
            v2884 = (ArrayItems[v2882]);
            if (!(v2883.Add((v2884))))
                continue;
            if (v2886 == 45)
                return (v2884);
            v2886++;
        }

        v2885 = (0);
        for (; v2885 < (ArrayItems2.Length); v2885 += 1)
        {
            v2884 = ArrayItems2[v2885];
            if (!(v2883.Add((v2884))))
                continue;
            if (v2886 == 45)
                return (v2884);
            v2886++;
        }

        return default(int);
    }

    int ArrayUnionArrayFirstRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2887;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2888;
        int v2889;
        int v2890;
        int v2891;
        v2888 = new HashSet<int>();
        v2891 = 0;
        v2887 = (0);
        for (; v2887 < (ArrayItems.Length); v2887 += 1)
        {
            v2889 = (ArrayItems[v2887]);
            if (!(v2888.Add((v2889))))
                continue;
            return (v2889);
            v2891++;
        }

        v2890 = (0);
        for (; v2890 < (ArrayItems2.Length); v2890 += 1)
        {
            v2889 = ArrayItems2[v2890];
            if (!(v2888.Add((v2889))))
                continue;
            return (v2889);
            v2891++;
        }

        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int ArrayUnionArrayFirstOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2892;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2893;
        int v2894;
        int v2895;
        v2893 = new HashSet<int>();
        v2892 = (0);
        for (; v2892 < (ArrayItems.Length); v2892 += 1)
        {
            v2894 = (ArrayItems[v2892]);
            if (!(v2893.Add((v2894))))
                continue;
            return (v2894);
        }

        v2895 = (0);
        for (; v2895 < (ArrayItems2.Length); v2895 += 1)
        {
            v2894 = ArrayItems2[v2895];
            if (!(v2893.Add((v2894))))
                continue;
            return (v2894);
        }

        return default(int);
    }

    int ArrayUnionArrayLastRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2896;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2897;
        int v2898;
        int v2899;
        int v2900;
        int? v2901;
        v2897 = new HashSet<int>();
        v2900 = 0;
        v2901 = null;
        v2896 = (0);
        for (; v2896 < (ArrayItems.Length); v2896 += 1)
        {
            v2898 = (ArrayItems[v2896]);
            if (!(v2897.Add((v2898))))
                continue;
            v2901 = (v2898);
            v2900++;
        }

        v2899 = (0);
        for (; v2899 < (ArrayItems2.Length); v2899 += 1)
        {
            v2898 = ArrayItems2[v2899];
            if (!(v2897.Add((v2898))))
                continue;
            v2901 = (v2898);
            v2900++;
        }

        if (v2901 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v2901;
    }

    int ArrayUnionArrayLastOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2902;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2903;
        int v2904;
        int v2905;
        int? v2906;
        v2903 = new HashSet<int>();
        v2906 = null;
        v2902 = (0);
        for (; v2902 < (ArrayItems.Length); v2902 += 1)
        {
            v2904 = (ArrayItems[v2902]);
            if (!(v2903.Add((v2904))))
                continue;
            v2906 = (v2904);
        }

        v2905 = (0);
        for (; v2905 < (ArrayItems2.Length); v2905 += 1)
        {
            v2904 = ArrayItems2[v2905];
            if (!(v2903.Add((v2904))))
                continue;
            v2906 = (v2904);
        }

        if (v2906 == null)
            return default(int);
        else
            return (int)v2906;
    }

    int ArrayUnionArraySingleRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2907;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2908;
        int v2909;
        int v2910;
        int? v2911;
        v2908 = new HashSet<int>();
        v2911 = null;
        v2907 = (0);
        for (; v2907 < (ArrayItems.Length); v2907 += 1)
        {
            v2909 = (ArrayItems[v2907]);
            if (!(v2908.Add((v2909))))
                continue;
            if (v2911 == null)
                v2911 = (v2909);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        v2910 = (0);
        for (; v2910 < (ArrayItems2.Length); v2910 += 1)
        {
            v2909 = ArrayItems2[v2910];
            if (!(v2908.Add((v2909))))
                continue;
            if (v2911 == null)
                v2911 = (v2909);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v2911 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v2911;
    }

    int ArrayUnionArraySingle2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2912;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2913;
        int v2914;
        int v2915;
        int? v2916;
        v2913 = new HashSet<int>();
        v2916 = null;
        v2912 = (0);
        for (; v2912 < (ArrayItems.Length); v2912 += 1)
        {
            v2914 = (ArrayItems[v2912]);
            if (!(v2913.Add((v2914))))
                continue;
            if (((v2914) == 76))
                if (v2916 == null)
                    v2916 = (v2914);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        v2915 = (0);
        for (; v2915 < (ArrayItems2.Length); v2915 += 1)
        {
            v2914 = ArrayItems2[v2915];
            if (!(v2913.Add((v2914))))
                continue;
            if (((v2914) == 76))
                if (v2916 == null)
                    v2916 = (v2914);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v2916 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v2916;
    }

    int ArrayUnionArraySingleOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2917;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2918;
        int v2919;
        int v2920;
        int? v2921;
        v2918 = new HashSet<int>();
        v2921 = null;
        v2917 = (0);
        for (; v2917 < (ArrayItems.Length); v2917 += 1)
        {
            v2919 = (ArrayItems[v2917]);
            if (!(v2918.Add((v2919))))
                continue;
            if (v2921 == null)
                v2921 = (v2919);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        v2920 = (0);
        for (; v2920 < (ArrayItems2.Length); v2920 += 1)
        {
            v2919 = ArrayItems2[v2920];
            if (!(v2918.Add((v2919))))
                continue;
            if (v2921 == null)
                v2921 = (v2919);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v2921 == null)
            return default(int);
        else
            return (int)v2921;
    }

    int ArrayUnionArrayMinRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2922;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2923;
        int v2924;
        int v2925;
        int v2926;
        int v2927;
        v2923 = new HashSet<int>();
        v2926 = 0;
        v2927 = 2147483647;
        v2922 = (0);
        for (; v2922 < (ArrayItems.Length); v2922 += 1)
        {
            v2924 = (ArrayItems[v2922]);
            if (!(v2923.Add((v2924))))
                continue;
            if ((v2924) >= v2927)
                continue;
            v2927 = (v2924);
            v2926++;
        }

        v2925 = (0);
        for (; v2925 < (ArrayItems2.Length); v2925 += 1)
        {
            v2924 = ArrayItems2[v2925];
            if (!(v2923.Add((v2924))))
                continue;
            if ((v2924) >= v2927)
                continue;
            v2927 = (v2924);
            v2926++;
        }

        if (1 > v2926)
            throw new System.InvalidOperationException("Index out of range");
        return v2927;
    }

    decimal ArrayUnionArrayMin2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2928;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2929;
        int v2930;
        int v2931;
        int v2932;
        decimal v2933;
        decimal v2934;
        v2929 = new HashSet<int>();
        v2932 = 0;
        v2933 = 79228162514264337593543950335M;
        v2928 = (0);
        for (; v2928 < (ArrayItems.Length); v2928 += 1)
        {
            v2930 = (ArrayItems[v2928]);
            if (!(v2929.Add((v2930))))
                continue;
            v2934 = ((v2930) + 2m);
            if (v2934 >= v2933)
                continue;
            v2933 = v2934;
            v2932++;
        }

        v2931 = (0);
        for (; v2931 < (ArrayItems2.Length); v2931 += 1)
        {
            v2930 = ArrayItems2[v2931];
            if (!(v2929.Add((v2930))))
                continue;
            v2934 = ((v2930) + 2m);
            if (v2934 >= v2933)
                continue;
            v2933 = v2934;
            v2932++;
        }

        if (1 > v2932)
            throw new System.InvalidOperationException("Index out of range");
        return v2933;
    }

    int ArrayUnionArrayMaxRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2935;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2936;
        int v2937;
        int v2938;
        int v2939;
        int v2940;
        v2936 = new HashSet<int>();
        v2939 = 0;
        v2940 = -2147483648;
        v2935 = (0);
        for (; v2935 < (ArrayItems.Length); v2935 += 1)
        {
            v2937 = (ArrayItems[v2935]);
            if (!(v2936.Add((v2937))))
                continue;
            if ((v2937) <= v2940)
                continue;
            v2940 = (v2937);
            v2939++;
        }

        v2938 = (0);
        for (; v2938 < (ArrayItems2.Length); v2938 += 1)
        {
            v2937 = ArrayItems2[v2938];
            if (!(v2936.Add((v2937))))
                continue;
            if ((v2937) <= v2940)
                continue;
            v2940 = (v2937);
            v2939++;
        }

        if (1 > v2939)
            throw new System.InvalidOperationException("Index out of range");
        return v2940;
    }

    decimal ArrayUnionArrayMax2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2941;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2942;
        int v2943;
        int v2944;
        int v2945;
        decimal v2946;
        decimal v2947;
        v2942 = new HashSet<int>();
        v2945 = 0;
        v2946 = -79228162514264337593543950335M;
        v2941 = (0);
        for (; v2941 < (ArrayItems.Length); v2941 += 1)
        {
            v2943 = (ArrayItems[v2941]);
            if (!(v2942.Add((v2943))))
                continue;
            v2947 = ((v2943) + 2m);
            if (v2947 <= v2946)
                continue;
            v2946 = v2947;
            v2945++;
        }

        v2944 = (0);
        for (; v2944 < (ArrayItems2.Length); v2944 += 1)
        {
            v2943 = ArrayItems2[v2944];
            if (!(v2942.Add((v2943))))
                continue;
            v2947 = ((v2943) + 2m);
            if (v2947 <= v2946)
                continue;
            v2946 = v2947;
            v2945++;
        }

        if (1 > v2945)
            throw new System.InvalidOperationException("Index out of range");
        return v2946;
    }

    long ArrayUnionArrayLongCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2948;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2949;
        int v2950;
        int v2951;
        long v2952;
        v2949 = new HashSet<int>();
        v2952 = 0;
        v2948 = (0);
        for (; v2948 < (ArrayItems.Length); v2948 += 1)
        {
            v2950 = (ArrayItems[v2948]);
            if (!(v2949.Add((v2950))))
                continue;
            v2952++;
        }

        v2951 = (0);
        for (; v2951 < (ArrayItems2.Length); v2951 += 1)
        {
            v2950 = ArrayItems2[v2951];
            if (!(v2949.Add((v2950))))
                continue;
            v2952++;
        }

        return v2952;
    }

    long ArrayUnionArrayLongCount2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2953;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2954;
        int v2955;
        int v2956;
        long v2957;
        v2954 = new HashSet<int>();
        v2957 = 0;
        v2953 = (0);
        for (; v2953 < (ArrayItems.Length); v2953 += 1)
        {
            v2955 = (ArrayItems[v2953]);
            if (!(v2954.Add((v2955))))
                continue;
            if (!(((v2955) > 50)))
                continue;
            v2957++;
        }

        v2956 = (0);
        for (; v2956 < (ArrayItems2.Length); v2956 += 1)
        {
            v2955 = ArrayItems2[v2956];
            if (!(v2954.Add((v2955))))
                continue;
            if (!(((v2955) > 50)))
                continue;
            v2957++;
        }

        return v2957;
    }

    bool ArrayUnionArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2958;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2959;
        int v2960;
        int v2961;
        v2959 = new HashSet<int>();
        v2958 = (0);
        for (; v2958 < (ArrayItems.Length); v2958 += 1)
        {
            v2960 = (ArrayItems[v2958]);
            if (!(v2959.Add((v2960))))
                continue;
            if ((v2960) == 56)
                return true;
        }

        v2961 = (0);
        for (; v2961 < (ArrayItems2.Length); v2961 += 1)
        {
            v2960 = ArrayItems2[v2961];
            if (!(v2959.Add((v2960))))
                continue;
            if ((v2960) == 56)
                return true;
        }

        return false;
    }

    double ArrayUnionArrayAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2962;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2963;
        int v2964;
        int v2965;
        double v2966;
        int v2967;
        v2963 = new HashSet<int>();
        v2966 = 0;
        v2967 = 0;
        v2962 = (0);
        for (; v2962 < (ArrayItems.Length); v2962 += 1)
        {
            v2964 = (ArrayItems[v2962]);
            if (!(v2963.Add((v2964))))
                continue;
            v2966 += (v2964);
            v2967++;
        }

        v2965 = (0);
        for (; v2965 < (ArrayItems2.Length); v2965 += 1)
        {
            v2964 = ArrayItems2[v2965];
            if (!(v2963.Add((v2964))))
                continue;
            v2966 += (v2964);
            v2967++;
        }

        if (1 > v2967)
            throw new System.InvalidOperationException("Index out of range");
        return (v2966 / v2967);
    }

    double ArrayUnionArrayAverage2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2968;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2969;
        int v2970;
        int v2971;
        double v2972;
        int v2973;
        v2969 = new HashSet<int>();
        v2972 = 0;
        v2973 = 0;
        v2968 = (0);
        for (; v2968 < (ArrayItems.Length); v2968 += 1)
        {
            v2970 = (ArrayItems[v2968]);
            if (!(v2969.Add((v2970))))
                continue;
            v2972 += ((v2970) + 10);
            v2973++;
        }

        v2971 = (0);
        for (; v2971 < (ArrayItems2.Length); v2971 += 1)
        {
            v2970 = ArrayItems2[v2971];
            if (!(v2969.Add((v2970))))
                continue;
            v2972 += ((v2970) + 10);
            v2973++;
        }

        if (1 > v2973)
            throw new System.InvalidOperationException("Index out of range");
        return (v2972 / v2973);
    }

    bool ArrayUnionArrayContains2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2974;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2975;
        int v2976;
        int v2977;
        System.Collections.Generic.EqualityComparer<int> v2978;
        v2978 = EqualityComparer<int>.Default;
        v2975 = new HashSet<int>();
        v2974 = (0);
        for (; v2974 < (ArrayItems.Length); v2974 += 1)
        {
            v2976 = (ArrayItems[v2974]);
            if (!(v2975.Add((v2976))))
                continue;
            if (v2978.Equals((v2976), 56))
                return true;
        }

        v2977 = (0);
        for (; v2977 < (ArrayItems2.Length); v2977 += 1)
        {
            v2976 = ArrayItems2[v2977];
            if (!(v2975.Add((v2976))))
                continue;
            if (v2978.Equals((v2976), 56))
                return true;
        }

        return false;
    }

    System.Collections.Generic.IEnumerable<int> SelectWhereArrayUnionSelectWhereArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v2979;
        int v2980;
        v2979 = (0);
        for (; v2979 < (ArrayItems2.Length); v2979 += 1)
        {
            v2980 = (((ArrayItems2[v2979]) + 10));
            if (!(((v2980) > 80)))
                continue;
            yield return (v2980);
        }

        yield break;
    }

    bool SelectWhereArrayUnionSelectWhereArrayContainsRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v2981;
        int v2982;
        if (SelectWhereArrayUnionSelectWhereArrayContainsRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2983;
        IEnumerator<int> v2984;
        v2984 = SelectWhereArrayUnionSelectWhereArrayContainsRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v2983 = new HashSet<int>();
        v2981 = (0);
        for (; v2981 < (ArrayItems.Length); v2981 += 1)
        {
            v2982 = (10 + ArrayItems[v2981]);
            if (!(((v2982) > 80)))
                continue;
            if (!(v2983.Add((v2982))))
                continue;
            if ((v2982) == 112)
                return true;
        }

        try
        {
            while (v2984.MoveNext())
            {
                v2982 = v2984.Current;
                if (!(v2983.Add((v2982))))
                    continue;
                if ((v2982) == 112)
                    return true;
            }
        }
        finally
        {
            v2984.Dispose();
        }

        return false;
    }

    System.Collections.Generic.IEnumerable<int> RangeUnionArrayRewritten_ProceduralLinq1()
    {
        int v2985;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2986;
        int v2987;
        int v2988;
        v2986 = new HashSet<int>();
        v2985 = (0);
        for (; v2985 < (100); v2985 += (1))
        {
            v2987 = (20 + v2985);
            if (!(v2986.Add((v2987))))
                continue;
            yield return (v2987);
        }

        v2988 = (0);
        for (; v2988 < (ArrayItems2.Length); v2988 += 1)
        {
            v2987 = ArrayItems2[v2988];
            if (!(v2986.Add((v2987))))
                continue;
            yield return (v2987);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RepeatUnionArrayRewritten_ProceduralLinq1()
    {
        int v2989;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2990;
        int v2991;
        int v2992;
        v2990 = new HashSet<int>();
        v2989 = (0);
        for (; v2989 < (100); v2989 += 1)
        {
            v2991 = (20);
            if (!(v2990.Add((v2991))))
                continue;
            yield return (v2991);
        }

        v2992 = (0);
        for (; v2992 < (ArrayItems2.Length); v2992 += 1)
        {
            v2991 = ArrayItems2[v2992];
            if (!(v2990.Add((v2991))))
                continue;
            yield return (v2991);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EmptyUnionArrayRewritten_ProceduralLinq1()
    {
        int v2993;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2994;
        int v2995;
        int v2996;
        v2993 = 0;
        v2994 = new HashSet<int>();
        v2996 = (0);
        for (; v2996 < (ArrayItems2.Length); v2996 += 1)
        {
            v2995 = ArrayItems2[v2996];
            if (!(v2994.Add((v2995))))
                continue;
            yield return (v2995);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeEmpty2ArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2997;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2998;
        int v2999;
        int v3000;
        v2998 = new HashSet<int>();
        v2997 = (0);
        for (; v2997 < (ArrayItems.Length); v2997 += 1)
        {
            if (!((false)))
                continue;
            v2999 = ((ArrayItems[v2997]));
            if (!(v2998.Add((v2999))))
                continue;
            yield return (v2999);
        }

        v3000 = (0);
        for (; v3000 < (ArrayItems2.Length); v3000 += 1)
        {
            v2999 = ArrayItems2[v3000];
            if (!(v2998.Add((v2999))))
                continue;
            yield return (v2999);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionRangeRewritten_ProceduralLinq1()
    {
        int v3001;
        v3001 = (0);
        for (; v3001 < (260); v3001 += (1))
            yield return (70 + v3001);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionRangeRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v3002;
        if (ArrayUnionRangeRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3003;
        int v3004;
        IEnumerator<int> v3005;
        v3005 = ArrayUnionRangeRewritten_ProceduralLinq1().GetEnumerator();
        v3003 = new HashSet<int>();
        v3002 = (0);
        for (; v3002 < (ArrayItems.Length); v3002 += 1)
        {
            v3004 = (ArrayItems[v3002]);
            if (!(v3003.Add((v3004))))
                continue;
            yield return (v3004);
        }

        try
        {
            while (v3005.MoveNext())
            {
                v3004 = v3005.Current;
                if (!(v3003.Add((v3004))))
                    continue;
                yield return (v3004);
            }
        }
        finally
        {
            v3005.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionRepeatRewritten_ProceduralLinq1()
    {
        int v3006;
        v3006 = (0);
        for (; v3006 < (100); v3006 += 1)
            yield return (70);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionRepeatRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v3007;
        if (ArrayUnionRepeatRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3008;
        int v3009;
        IEnumerator<int> v3010;
        v3010 = ArrayUnionRepeatRewritten_ProceduralLinq1().GetEnumerator();
        v3008 = new HashSet<int>();
        v3007 = (0);
        for (; v3007 < (ArrayItems.Length); v3007 += 1)
        {
            v3009 = (ArrayItems[v3007]);
            if (!(v3008.Add((v3009))))
                continue;
            yield return (v3009);
        }

        try
        {
            while (v3010.MoveNext())
            {
                v3009 = v3010.Current;
                if (!(v3008.Add((v3009))))
                    continue;
                yield return (v3009);
            }
        }
        finally
        {
            v3010.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionEmptyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3011;
        if (Enumerable.Empty<int>() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3012;
        int v3013;
        IEnumerator<int> v3014;
        v3014 = Enumerable.Empty<int>().GetEnumerator();
        v3012 = new HashSet<int>();
        v3011 = (0);
        for (; v3011 < (ArrayItems.Length); v3011 += 1)
        {
            v3013 = (ArrayItems[v3011]);
            if (!(v3012.Add((v3013))))
                continue;
            yield return (v3013);
        }

        try
        {
            while (v3014.MoveNext())
            {
                v3013 = v3014.Current;
                if (!(v3012.Add((v3013))))
                    continue;
                yield return (v3013);
            }
        }
        finally
        {
            v3014.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionEmpty2Rewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v3015;
        v3015 = (0);
        for (; v3015 < (ArrayItems2.Length); v3015 += 1)
        {
            if (!((false)))
                continue;
            yield return ((ArrayItems2[v3015]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionEmpty2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v3016;
        if (ArrayUnionEmpty2Rewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3017;
        int v3018;
        IEnumerator<int> v3019;
        v3019 = ArrayUnionEmpty2Rewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v3017 = new HashSet<int>();
        v3016 = (0);
        for (; v3016 < (ArrayItems.Length); v3016 += 1)
        {
            v3018 = (ArrayItems[v3016]);
            if (!(v3017.Add((v3018))))
                continue;
            yield return (v3018);
        }

        try
        {
            while (v3019.MoveNext())
            {
                v3018 = v3019.Current;
                if (!(v3017.Add((v3018))))
                    continue;
                yield return (v3018);
            }
        }
        finally
        {
            v3019.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionAllRewritten_ProceduralLinq1()
    {
        int v3020;
        v3020 = (0);
        for (; v3020 < (1000); v3020 += (1))
            yield return (v3020);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionAllRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v3021;
        if (ArrayUnionAllRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3022;
        int v3023;
        IEnumerator<int> v3024;
        v3024 = ArrayUnionAllRewritten_ProceduralLinq1().GetEnumerator();
        v3022 = new HashSet<int>();
        v3021 = (0);
        for (; v3021 < (ArrayItems.Length); v3021 += 1)
        {
            v3023 = (ArrayItems[v3021]);
            if (!(v3022.Add((v3023))))
                continue;
            yield return (v3023);
        }

        try
        {
            while (v3024.MoveNext())
            {
                v3023 = v3024.Current;
                if (!(v3022.Add((v3023))))
                    continue;
                yield return (v3023);
            }
        }
        finally
        {
            v3024.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionNullRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3025;
        throw new System.InvalidOperationException("Invalid null object");
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionArrayUnionEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3026;
        if (ArrayItems == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3027;
        int v3028;
        int v3029;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3030;
        IEnumerator<int> v3031;
        v3031 = EnumerableItems2.GetEnumerator();
        v3027 = new HashSet<int>();
        v3030 = new HashSet<int>();
        v3026 = (0);
        for (; v3026 < (ArrayItems.Length); v3026 += 1)
        {
            v3028 = (ArrayItems[v3026]);
            if (!(v3027.Add((v3028))))
                continue;
            if (!(v3030.Add((v3028))))
                continue;
            yield return (v3028);
        }

        v3029 = (0);
        for (; v3029 < (ArrayItems.Length); v3029 += 1)
        {
            v3028 = ArrayItems[v3029];
            if (!(v3027.Add((v3028))))
                continue;
            if (!(v3030.Add((v3028))))
                continue;
            yield return (v3028);
        }

        try
        {
            while (v3031.MoveNext())
            {
                v3028 = v3031.Current;
                if (!(v3030.Add((v3028))))
                    continue;
                yield return (v3028);
            }
        }
        finally
        {
            v3031.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionArrayUnionEnumerable2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3032;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3033;
        int v3034;
        IEnumerator<int> v3035;
        v3035 = EnumerableItems2.GetEnumerator();
        v3033 = new HashSet<int>();
        v3032 = (0);
        for (; v3032 < (ArrayItems.Length); v3032 += 1)
        {
            v3034 = (ArrayItems[v3032]);
            if (!(v3033.Add((v3034))))
                continue;
            yield return (v3034);
        }

        try
        {
            while (v3035.MoveNext())
            {
                v3034 = v3035.Current;
                if (!(v3033.Add((v3034))))
                    continue;
                yield return (v3034);
            }
        }
        finally
        {
            v3035.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionArrayUnionEnumerable2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v3036;
        if (ArrayUnionArrayUnionEnumerable2Rewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3037;
        int v3038;
        IEnumerator<int> v3039;
        v3039 = ArrayUnionArrayUnionEnumerable2Rewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v3037 = new HashSet<int>();
        v3036 = (0);
        for (; v3036 < (ArrayItems.Length); v3036 += 1)
        {
            v3038 = (ArrayItems[v3036]);
            if (!(v3037.Add((v3038))))
                continue;
            yield return (v3038);
        }

        try
        {
            while (v3039.MoveNext())
            {
                v3038 = v3039.Current;
                if (!(v3037.Add((v3038))))
                    continue;
                yield return (v3038);
            }
        }
        finally
        {
            v3039.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctUnionArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3040;
        HashSet<int> v3041;
        v3041 = new HashSet<int>();
        v3040 = (0);
        for (; v3040 < (ArrayItems.Length); v3040 += 1)
        {
            if (!(v3041.Add(((ArrayItems[v3040])))))
                continue;
            yield return ((ArrayItems[v3040]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctUnionArrayDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v3042;
        HashSet<int> v3043;
        if (ArrayDistinctUnionArrayDistinctRewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3044;
        int v3045;
        IEnumerator<int> v3046;
        v3046 = ArrayDistinctUnionArrayDistinctRewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v3043 = new HashSet<int>();
        v3044 = new HashSet<int>();
        v3042 = (0);
        for (; v3042 < (ArrayItems.Length); v3042 += 1)
        {
            if (!(v3043.Add(((ArrayItems[v3042])))))
                continue;
            v3045 = ((ArrayItems[v3042]));
            if (!(v3044.Add((v3045))))
                continue;
            yield return (v3045);
        }

        try
        {
            while (v3046.MoveNext())
            {
                v3045 = v3046.Current;
                if (!(v3044.Add((v3045))))
                    continue;
                yield return (v3045);
            }
        }
        finally
        {
            v3046.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctUnionArrayDistinctDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3047;
        HashSet<int> v3048;
        v3048 = new HashSet<int>();
        v3047 = (0);
        for (; v3047 < (ArrayItems.Length); v3047 += 1)
        {
            if (!(v3048.Add(((ArrayItems[v3047])))))
                continue;
            yield return ((ArrayItems[v3047]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctUnionArrayDistinctDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v3049;
        HashSet<int> v3050;
        if (ArrayDistinctUnionArrayDistinctDistinctRewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3051;
        int v3052;
        IEnumerator<int> v3053;
        HashSet<int> v3054;
        v3053 = ArrayDistinctUnionArrayDistinctDistinctRewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v3050 = new HashSet<int>();
        v3051 = new HashSet<int>();
        v3054 = new HashSet<int>();
        v3049 = (0);
        for (; v3049 < (ArrayItems.Length); v3049 += 1)
        {
            if (!(v3050.Add(((ArrayItems[v3049])))))
                continue;
            v3052 = ((ArrayItems[v3049]));
            if (!(v3051.Add((v3052))))
                continue;
            if (!(v3054.Add(((v3052)))))
                continue;
            yield return ((v3052));
        }

        try
        {
            while (v3053.MoveNext())
            {
                v3052 = v3053.Current;
                if (!(v3051.Add((v3052))))
                    continue;
                if (!(v3054.Add(((v3052)))))
                    continue;
                yield return ((v3052));
            }
        }
        finally
        {
            v3053.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctUnionArrayDistinctDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3055;
        HashSet<int> v3056;
        v3056 = new HashSet<int>(EqualityComparer<int>.Default);
        v3055 = (0);
        for (; v3055 < (ArrayItems.Length); v3055 += 1)
        {
            if (!(v3056.Add(((ArrayItems[v3055])))))
                continue;
            yield return ((ArrayItems[v3055]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctUnionArrayDistinctDistinct2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v3057;
        HashSet<int> v3058;
        if (ArrayDistinctUnionArrayDistinctDistinct2Rewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3059;
        int v3060;
        IEnumerator<int> v3061;
        HashSet<int> v3062;
        v3061 = ArrayDistinctUnionArrayDistinctDistinct2Rewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v3058 = new HashSet<int>(EqualityComparer<int>.Default);
        v3059 = new HashSet<int>();
        v3062 = new HashSet<int>(EqualityComparer<int>.Default);
        v3057 = (0);
        for (; v3057 < (ArrayItems.Length); v3057 += 1)
        {
            if (!(v3058.Add(((ArrayItems[v3057])))))
                continue;
            v3060 = ((ArrayItems[v3057]));
            if (!(v3059.Add((v3060))))
                continue;
            if (!(v3062.Add(((v3060)))))
                continue;
            yield return ((v3060));
        }

        try
        {
            while (v3061.MoveNext())
            {
                v3060 = v3061.Current;
                if (!(v3059.Add((v3060))))
                    continue;
                if (!(v3062.Add(((v3060)))))
                    continue;
                yield return ((v3060));
            }
        }
        finally
        {
            v3061.Dispose();
        }

        yield break;
    }
}}