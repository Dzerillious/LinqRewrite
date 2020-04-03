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
        int v2490;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2491;
        int v2492;
        int v2493;
        v2491 = new HashSet<int>();
        v2490 = 0;
        for (; v2490 < ArrayItems.Length; v2490++)
        {
            v2492 = ArrayItems[v2490];
            if (!(v2491.Add(v2492)))
                continue;
            yield return v2492;
        }

        v2493 = 0;
        for (; v2493 < ArrayItems2.Length; v2493++)
        {
            v2492 = ArrayItems2[v2493];
            if (!(v2491.Add(v2492)))
                continue;
            yield return v2492;
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2494;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2495;
        int v2496;
        IEnumerator<int> v2497;
        v2497 = SimpleListItems2.GetEnumerator();
        v2495 = new HashSet<int>();
        v2494 = 0;
        for (; v2494 < ArrayItems.Length; v2494++)
        {
            v2496 = ArrayItems[v2494];
            if (!(v2495.Add(v2496)))
                continue;
            yield return v2496;
        }

        try
        {
            while (v2497.MoveNext())
            {
                v2496 = v2497.Current;
                if (!(v2495.Add(v2496)))
                    continue;
                yield return v2496;
            }
        }
        finally
        {
            v2497.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2498;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2499;
        int v2500;
        IEnumerator<int> v2501;
        v2501 = EnumerableItems2.GetEnumerator();
        v2499 = new HashSet<int>();
        v2498 = 0;
        for (; v2498 < ArrayItems.Length; v2498++)
        {
            v2500 = ArrayItems[v2498];
            if (!(v2499.Add(v2500)))
                continue;
            yield return v2500;
        }

        try
        {
            while (v2501.MoveNext())
            {
                v2500 = v2501.Current;
                if (!(v2499.Add(v2500)))
                    continue;
                yield return v2500;
            }
        }
        finally
        {
            v2501.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2502;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2503;
        int v2504;
        IEnumerator<int> v2505;
        v2505 = MethodEnumerable2().GetEnumerator();
        v2503 = new HashSet<int>();
        v2502 = 0;
        for (; v2502 < ArrayItems.Length; v2502++)
        {
            v2504 = ArrayItems[v2502];
            if (!(v2503.Add(v2504)))
                continue;
            yield return v2504;
        }

        try
        {
            while (v2505.MoveNext())
            {
                v2504 = v2505.Current;
                if (!(v2503.Add(v2504)))
                    continue;
                yield return v2504;
            }
        }
        finally
        {
            v2505.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> SimpleListUnionArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v2506;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2507;
        int v2508;
        int v2509;
        v2506 = SimpleListItems.GetEnumerator();
        v2507 = new HashSet<int>();
        try
        {
            while (v2506.MoveNext())
            {
                v2508 = v2506.Current;
                if (!(v2507.Add(v2508)))
                    continue;
                yield return v2508;
            }
        }
        finally
        {
            v2506.Dispose();
        }

        v2509 = 0;
        for (; v2509 < ArrayItems2.Length; v2509++)
        {
            v2508 = ArrayItems2[v2509];
            if (!(v2507.Add(v2508)))
                continue;
            yield return v2508;
        }
    }

    System.Collections.Generic.IEnumerable<int> SimpleListUnionSimpleListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v2510;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2511;
        int v2512;
        IEnumerator<int> v2513;
        v2510 = SimpleListItems.GetEnumerator();
        v2513 = SimpleListItems2.GetEnumerator();
        v2511 = new HashSet<int>();
        try
        {
            while (v2510.MoveNext())
            {
                v2512 = v2510.Current;
                if (!(v2511.Add(v2512)))
                    continue;
                yield return v2512;
            }
        }
        finally
        {
            v2510.Dispose();
        }

        try
        {
            while (v2513.MoveNext())
            {
                v2512 = v2513.Current;
                if (!(v2511.Add(v2512)))
                    continue;
                yield return v2512;
            }
        }
        finally
        {
            v2513.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> SimpleListUnionEnumerableRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v2514;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2515;
        int v2516;
        IEnumerator<int> v2517;
        v2514 = SimpleListItems.GetEnumerator();
        v2517 = EnumerableItems2.GetEnumerator();
        v2515 = new HashSet<int>();
        try
        {
            while (v2514.MoveNext())
            {
                v2516 = v2514.Current;
                if (!(v2515.Add(v2516)))
                    continue;
                yield return v2516;
            }
        }
        finally
        {
            v2514.Dispose();
        }

        try
        {
            while (v2517.MoveNext())
            {
                v2516 = v2517.Current;
                if (!(v2515.Add(v2516)))
                    continue;
                yield return v2516;
            }
        }
        finally
        {
            v2517.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> SimpleListUnionMethodRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v2518;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2519;
        int v2520;
        IEnumerator<int> v2521;
        v2518 = SimpleListItems.GetEnumerator();
        v2521 = MethodEnumerable2().GetEnumerator();
        v2519 = new HashSet<int>();
        try
        {
            while (v2518.MoveNext())
            {
                v2520 = v2518.Current;
                if (!(v2519.Add(v2520)))
                    continue;
                yield return v2520;
            }
        }
        finally
        {
            v2518.Dispose();
        }

        try
        {
            while (v2521.MoveNext())
            {
                v2520 = v2521.Current;
                if (!(v2519.Add(v2520)))
                    continue;
                yield return v2520;
            }
        }
        finally
        {
            v2521.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableUnionArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2522;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2523;
        int v2524;
        int v2525;
        v2522 = EnumerableItems.GetEnumerator();
        v2523 = new HashSet<int>();
        try
        {
            while (v2522.MoveNext())
            {
                v2524 = v2522.Current;
                if (!(v2523.Add(v2524)))
                    continue;
                yield return v2524;
            }
        }
        finally
        {
            v2522.Dispose();
        }

        v2525 = 0;
        for (; v2525 < ArrayItems2.Length; v2525++)
        {
            v2524 = ArrayItems2[v2525];
            if (!(v2523.Add(v2524)))
                continue;
            yield return v2524;
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableUnionSimpleListRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2526;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2527;
        int v2528;
        IEnumerator<int> v2529;
        v2526 = EnumerableItems.GetEnumerator();
        v2529 = SimpleListItems2.GetEnumerator();
        v2527 = new HashSet<int>();
        try
        {
            while (v2526.MoveNext())
            {
                v2528 = v2526.Current;
                if (!(v2527.Add(v2528)))
                    continue;
                yield return v2528;
            }
        }
        finally
        {
            v2526.Dispose();
        }

        try
        {
            while (v2529.MoveNext())
            {
                v2528 = v2529.Current;
                if (!(v2527.Add(v2528)))
                    continue;
                yield return v2528;
            }
        }
        finally
        {
            v2529.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableUnionEnumerableRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2530;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2531;
        int v2532;
        IEnumerator<int> v2533;
        v2530 = EnumerableItems.GetEnumerator();
        v2533 = EnumerableItems2.GetEnumerator();
        v2531 = new HashSet<int>();
        try
        {
            while (v2530.MoveNext())
            {
                v2532 = v2530.Current;
                if (!(v2531.Add(v2532)))
                    continue;
                yield return v2532;
            }
        }
        finally
        {
            v2530.Dispose();
        }

        try
        {
            while (v2533.MoveNext())
            {
                v2532 = v2533.Current;
                if (!(v2531.Add(v2532)))
                    continue;
                yield return v2532;
            }
        }
        finally
        {
            v2533.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableUnionMethodRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2534;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2535;
        int v2536;
        IEnumerator<int> v2537;
        v2534 = EnumerableItems.GetEnumerator();
        v2537 = MethodEnumerable2().GetEnumerator();
        v2535 = new HashSet<int>();
        try
        {
            while (v2534.MoveNext())
            {
                v2536 = v2534.Current;
                if (!(v2535.Add(v2536)))
                    continue;
                yield return v2536;
            }
        }
        finally
        {
            v2534.Dispose();
        }

        try
        {
            while (v2537.MoveNext())
            {
                v2536 = v2537.Current;
                if (!(v2535.Add(v2536)))
                    continue;
                yield return v2536;
            }
        }
        finally
        {
            v2537.Dispose();
        }
    }

    int[] ArrayUnionArrayToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2538;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2539;
        int v2540;
        int v2541;
        int v2542;
        int v2543;
        int v2544;
        int[] v2545;
        v2539 = new HashSet<int>();
        v2542 = 0;
        v2543 = (LinqRewrite.Core.IntExtensions.Log2((uint)(ArrayItems2.Length + ArrayItems.Length)) - 3);
        v2543 -= (v2543 % 2);
        v2544 = 8;
        v2545 = new int[8];
        v2538 = 0;
        for (; v2538 < ArrayItems.Length; v2538++)
        {
            v2540 = ArrayItems[v2538];
            if (!(v2539.Add(v2540)))
                continue;
            if (v2542 >= v2544)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems2.Length + ArrayItems.Length), ref v2545, ref v2543, out v2544);
            v2545[v2542] = v2540;
            v2542++;
        }

        v2541 = 0;
        for (; v2541 < ArrayItems2.Length; v2541++)
        {
            v2540 = ArrayItems2[v2541];
            if (!(v2539.Add(v2540)))
                continue;
            if (v2542 >= v2544)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems2.Length + ArrayItems.Length), ref v2545, ref v2543, out v2544);
            v2545[v2542] = v2540;
            v2542++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2545, v2542);
    }

    int[] ArrayUnionSimpleListToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2546;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2547;
        int v2548;
        IEnumerator<int> v2549;
        int v2550;
        int v2551;
        int[] v2552;
        v2549 = SimpleListItems2.GetEnumerator();
        v2547 = new HashSet<int>();
        v2550 = 0;
        v2551 = 8;
        v2552 = new int[8];
        v2546 = 0;
        for (; v2546 < ArrayItems.Length; v2546++)
        {
            v2548 = ArrayItems[v2546];
            if (!(v2547.Add(v2548)))
                continue;
            if (v2550 >= v2551)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2552, ref v2551);
            v2552[v2550] = v2548;
            v2550++;
        }

        try
        {
            while (v2549.MoveNext())
            {
                v2548 = v2549.Current;
                if (!(v2547.Add(v2548)))
                    continue;
                if (v2550 >= v2551)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2552, ref v2551);
                v2552[v2550] = v2548;
                v2550++;
            }
        }
        finally
        {
            v2549.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2552, v2550);
    }

    int[] ArrayUnionEnumerableToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2553;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2554;
        int v2555;
        IEnumerator<int> v2556;
        int v2557;
        int v2558;
        int[] v2559;
        v2556 = EnumerableItems2.GetEnumerator();
        v2554 = new HashSet<int>();
        v2557 = 0;
        v2558 = 8;
        v2559 = new int[8];
        v2553 = 0;
        for (; v2553 < ArrayItems.Length; v2553++)
        {
            v2555 = ArrayItems[v2553];
            if (!(v2554.Add(v2555)))
                continue;
            if (v2557 >= v2558)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2559, ref v2558);
            v2559[v2557] = v2555;
            v2557++;
        }

        try
        {
            while (v2556.MoveNext())
            {
                v2555 = v2556.Current;
                if (!(v2554.Add(v2555)))
                    continue;
                if (v2557 >= v2558)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2559, ref v2558);
                v2559[v2557] = v2555;
                v2557++;
            }
        }
        finally
        {
            v2556.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2559, v2557);
    }

    int[] SimpleListUnionArrayToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v2560;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2561;
        int v2562;
        int v2563;
        int v2564;
        int v2565;
        int[] v2566;
        v2560 = SimpleListItems.GetEnumerator();
        v2561 = new HashSet<int>();
        v2564 = 0;
        v2565 = 8;
        v2566 = new int[8];
        try
        {
            while (v2560.MoveNext())
            {
                v2562 = v2560.Current;
                if (!(v2561.Add(v2562)))
                    continue;
                if (v2564 >= v2565)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2566, ref v2565);
                v2566[v2564] = v2562;
                v2564++;
            }
        }
        finally
        {
            v2560.Dispose();
        }

        v2563 = 0;
        for (; v2563 < ArrayItems2.Length; v2563++)
        {
            v2562 = ArrayItems2[v2563];
            if (!(v2561.Add(v2562)))
                continue;
            if (v2564 >= v2565)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2566, ref v2565);
            v2566[v2564] = v2562;
            v2564++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2566, v2564);
    }

    int[] SimpleListUnionSimpleListToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v2567;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2568;
        int v2569;
        IEnumerator<int> v2570;
        int v2571;
        int v2572;
        int[] v2573;
        v2567 = SimpleListItems.GetEnumerator();
        v2570 = SimpleListItems2.GetEnumerator();
        v2568 = new HashSet<int>();
        v2571 = 0;
        v2572 = 8;
        v2573 = new int[8];
        try
        {
            while (v2567.MoveNext())
            {
                v2569 = v2567.Current;
                if (!(v2568.Add(v2569)))
                    continue;
                if (v2571 >= v2572)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2573, ref v2572);
                v2573[v2571] = v2569;
                v2571++;
            }
        }
        finally
        {
            v2567.Dispose();
        }

        try
        {
            while (v2570.MoveNext())
            {
                v2569 = v2570.Current;
                if (!(v2568.Add(v2569)))
                    continue;
                if (v2571 >= v2572)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2573, ref v2572);
                v2573[v2571] = v2569;
                v2571++;
            }
        }
        finally
        {
            v2570.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2573, v2571);
    }

    int[] SimpleListUnionEnumerableToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        IEnumerator<int> v2574;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2575;
        int v2576;
        IEnumerator<int> v2577;
        int v2578;
        int v2579;
        int[] v2580;
        v2574 = SimpleListItems.GetEnumerator();
        v2577 = EnumerableItems2.GetEnumerator();
        v2575 = new HashSet<int>();
        v2578 = 0;
        v2579 = 8;
        v2580 = new int[8];
        try
        {
            while (v2574.MoveNext())
            {
                v2576 = v2574.Current;
                if (!(v2575.Add(v2576)))
                    continue;
                if (v2578 >= v2579)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2580, ref v2579);
                v2580[v2578] = v2576;
                v2578++;
            }
        }
        finally
        {
            v2574.Dispose();
        }

        try
        {
            while (v2577.MoveNext())
            {
                v2576 = v2577.Current;
                if (!(v2575.Add(v2576)))
                    continue;
                if (v2578 >= v2579)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2580, ref v2579);
                v2580[v2578] = v2576;
                v2578++;
            }
        }
        finally
        {
            v2577.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2580, v2578);
    }

    int[] EnumerableUnionArrayToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2581;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2582;
        int v2583;
        int v2584;
        int v2585;
        int v2586;
        int[] v2587;
        v2581 = EnumerableItems.GetEnumerator();
        v2582 = new HashSet<int>();
        v2585 = 0;
        v2586 = 8;
        v2587 = new int[8];
        try
        {
            while (v2581.MoveNext())
            {
                v2583 = v2581.Current;
                if (!(v2582.Add(v2583)))
                    continue;
                if (v2585 >= v2586)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2587, ref v2586);
                v2587[v2585] = v2583;
                v2585++;
            }
        }
        finally
        {
            v2581.Dispose();
        }

        v2584 = 0;
        for (; v2584 < ArrayItems2.Length; v2584++)
        {
            v2583 = ArrayItems2[v2584];
            if (!(v2582.Add(v2583)))
                continue;
            if (v2585 >= v2586)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2587, ref v2586);
            v2587[v2585] = v2583;
            v2585++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2587, v2585);
    }

    int[] EnumerableUnionSimpleListToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2588;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2589;
        int v2590;
        IEnumerator<int> v2591;
        int v2592;
        int v2593;
        int[] v2594;
        v2588 = EnumerableItems.GetEnumerator();
        v2591 = SimpleListItems2.GetEnumerator();
        v2589 = new HashSet<int>();
        v2592 = 0;
        v2593 = 8;
        v2594 = new int[8];
        try
        {
            while (v2588.MoveNext())
            {
                v2590 = v2588.Current;
                if (!(v2589.Add(v2590)))
                    continue;
                if (v2592 >= v2593)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2594, ref v2593);
                v2594[v2592] = v2590;
                v2592++;
            }
        }
        finally
        {
            v2588.Dispose();
        }

        try
        {
            while (v2591.MoveNext())
            {
                v2590 = v2591.Current;
                if (!(v2589.Add(v2590)))
                    continue;
                if (v2592 >= v2593)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2594, ref v2593);
                v2594[v2592] = v2590;
                v2592++;
            }
        }
        finally
        {
            v2591.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2594, v2592);
    }

    int[] EnumerableUnionEnumerableToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2595;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2596;
        int v2597;
        IEnumerator<int> v2598;
        int v2599;
        int v2600;
        int[] v2601;
        v2595 = EnumerableItems.GetEnumerator();
        v2598 = EnumerableItems2.GetEnumerator();
        v2596 = new HashSet<int>();
        v2599 = 0;
        v2600 = 8;
        v2601 = new int[8];
        try
        {
            while (v2595.MoveNext())
            {
                v2597 = v2595.Current;
                if (!(v2596.Add(v2597)))
                    continue;
                if (v2599 >= v2600)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2601, ref v2600);
                v2601[v2599] = v2597;
                v2599++;
            }
        }
        finally
        {
            v2595.Dispose();
        }

        try
        {
            while (v2598.MoveNext())
            {
                v2597 = v2598.Current;
                if (!(v2596.Add(v2597)))
                    continue;
                if (v2599 >= v2600)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2601, ref v2600);
                v2601[v2599] = v2597;
                v2599++;
            }
        }
        finally
        {
            v2598.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2601, v2599);
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectUnionArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2602;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2603;
        int v2604;
        int v2605;
        v2603 = new HashSet<int>();
        v2602 = 0;
        for (; v2602 < ArrayItems.Length; v2602++)
        {
            v2604 = (ArrayItems[v2602] + 50);
            if (!(v2603.Add(v2604)))
                continue;
            yield return v2604;
        }

        v2605 = 0;
        for (; v2605 < ArrayItems2.Length; v2605++)
        {
            v2604 = ArrayItems2[v2605];
            if (!(v2603.Add(v2604)))
                continue;
            yield return v2604;
        }
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectUnionArraySelectRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v2606;
        v2606 = 0;
        for (; v2606 < ArrayItems2.Length; v2606++)
            yield return (ArrayItems2[v2606] + 50);
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectUnionArraySelectRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v2607;
        if (ArraySelectUnionArraySelectRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2608;
        int v2609;
        IEnumerator<int> v2610;
        v2610 = ArraySelectUnionArraySelectRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v2608 = new HashSet<int>();
        v2607 = 0;
        for (; v2607 < ArrayItems.Length; v2607++)
        {
            v2609 = (ArrayItems[v2607] + 50);
            if (!(v2608.Add(v2609)))
                continue;
            yield return v2609;
        }

        try
        {
            while (v2610.MoveNext())
            {
                v2609 = v2610.Current;
                if (!(v2608.Add(v2609)))
                    continue;
                yield return v2609;
            }
        }
        finally
        {
            v2610.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereUnionArrayWhereRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v2611;
        v2611 = 0;
        for (; v2611 < ArrayItems2.Length; v2611++)
        {
            if (!((ArrayItems2[v2611] > 50)))
                continue;
            yield return ArrayItems2[v2611];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereUnionArrayWhereRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v2612;
        if (ArrayWhereUnionArrayWhereRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2613;
        int v2614;
        IEnumerator<int> v2615;
        v2615 = ArrayWhereUnionArrayWhereRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v2613 = new HashSet<int>();
        v2612 = 0;
        for (; v2612 < ArrayItems.Length; v2612++)
        {
            if (!((ArrayItems[v2612] > 50)))
                continue;
            v2614 = ArrayItems[v2612];
            if (!(v2613.Add(v2614)))
                continue;
            yield return v2614;
        }

        try
        {
            while (v2615.MoveNext())
            {
                v2614 = v2615.Current;
                if (!(v2613.Add(v2614)))
                    continue;
                yield return v2614;
            }
        }
        finally
        {
            v2615.Dispose();
        }
    }

    int ArrayUnionArrayCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2616;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2617;
        int v2618;
        int v2619;
        int v2620;
        v2617 = new HashSet<int>();
        v2620 = 0;
        v2616 = 0;
        for (; v2616 < ArrayItems.Length; v2616++)
        {
            v2618 = ArrayItems[v2616];
            if (!(v2617.Add(v2618)))
                continue;
            v2620++;
        }

        v2619 = 0;
        for (; v2619 < ArrayItems2.Length; v2619++)
        {
            v2618 = ArrayItems2[v2619];
            if (!(v2617.Add(v2618)))
                continue;
            v2620++;
        }

        return v2620;
    }

    int ArrayUnionArrayCount2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2621;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2622;
        int v2623;
        int v2624;
        int v2625;
        v2622 = new HashSet<int>();
        v2625 = 0;
        v2621 = 0;
        for (; v2621 < ArrayItems.Length; v2621++)
        {
            v2623 = ArrayItems[v2621];
            if (!(v2622.Add(v2623)))
                continue;
            if (!((v2623 > 70)))
                continue;
            v2625++;
        }

        v2624 = 0;
        for (; v2624 < ArrayItems2.Length; v2624++)
        {
            v2623 = ArrayItems2[v2624];
            if (!(v2622.Add(v2623)))
                continue;
            if (!((v2623 > 70)))
                continue;
            v2625++;
        }

        return v2625;
    }

    int ArrayUnionArraySumRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2626;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2627;
        int v2628;
        int v2629;
        int v2630;
        v2627 = new HashSet<int>();
        v2630 = 0;
        v2626 = 0;
        for (; v2626 < ArrayItems.Length; v2626++)
        {
            v2628 = ArrayItems[v2626];
            if (!(v2627.Add(v2628)))
                continue;
            v2630 += v2628;
        }

        v2629 = 0;
        for (; v2629 < ArrayItems2.Length; v2629++)
        {
            v2628 = ArrayItems2[v2629];
            if (!(v2627.Add(v2628)))
                continue;
            v2630 += v2628;
        }

        return v2630;
    }

    int ArrayUnionArraySum2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2631;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2632;
        int v2633;
        int v2634;
        int v2635;
        int v2636;
        v2632 = new HashSet<int>();
        v2635 = 0;
        v2631 = 0;
        for (; v2631 < ArrayItems.Length; v2631++)
        {
            v2633 = ArrayItems[v2631];
            if (!(v2632.Add(v2633)))
                continue;
            v2636 = (v2633 + 10);
            v2635 += v2636;
        }

        v2634 = 0;
        for (; v2634 < ArrayItems2.Length; v2634++)
        {
            v2633 = ArrayItems2[v2634];
            if (!(v2632.Add(v2633)))
                continue;
            v2636 = (v2633 + 10);
            v2635 += v2636;
        }

        return v2635;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2637;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2638;
        int v2639;
        int v2640;
        HashSet<int> v2641;
        v2638 = new HashSet<int>();
        v2641 = new HashSet<int>();
        v2637 = 0;
        for (; v2637 < ArrayItems.Length; v2637++)
        {
            v2639 = ArrayItems[v2637];
            if (!(v2638.Add(v2639)))
                continue;
            if (!(v2641.Add(v2639)))
                continue;
            yield return v2639;
        }

        v2640 = 0;
        for (; v2640 < ArrayItems2.Length; v2640++)
        {
            v2639 = ArrayItems2[v2640];
            if (!(v2638.Add(v2639)))
                continue;
            if (!(v2641.Add(v2639)))
                continue;
            yield return v2639;
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionArrayDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2642;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2643;
        int v2644;
        int v2645;
        HashSet<int> v2646;
        v2643 = new HashSet<int>();
        v2646 = new HashSet<int>(EqualityComparer<int>.Default);
        v2642 = 0;
        for (; v2642 < ArrayItems.Length; v2642++)
        {
            v2644 = ArrayItems[v2642];
            if (!(v2643.Add(v2644)))
                continue;
            if (!(v2646.Add(v2644)))
                continue;
            yield return v2644;
        }

        v2645 = 0;
        for (; v2645 < ArrayItems2.Length; v2645++)
        {
            v2644 = ArrayItems2[v2645];
            if (!(v2643.Add(v2644)))
                continue;
            if (!(v2646.Add(v2644)))
                continue;
            yield return v2644;
        }
    }

    int ArrayUnionArrayElementAtRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2647;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2648;
        int v2649;
        int v2650;
        int v2651;
        v2648 = new HashSet<int>();
        v2651 = 0;
        v2647 = 0;
        for (; v2647 < ArrayItems.Length; v2647++)
        {
            v2649 = ArrayItems[v2647];
            if (!(v2648.Add(v2649)))
                continue;
            if (v2651 == 45)
                return v2649;
            v2651++;
        }

        v2650 = 0;
        for (; v2650 < ArrayItems2.Length; v2650++)
        {
            v2649 = ArrayItems2[v2650];
            if (!(v2648.Add(v2649)))
                continue;
            if (v2651 == 45)
                return v2649;
            v2651++;
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArrayUnionArrayElementAtOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2652;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2653;
        int v2654;
        int v2655;
        int v2656;
        v2653 = new HashSet<int>();
        v2656 = 0;
        v2652 = 0;
        for (; v2652 < ArrayItems.Length; v2652++)
        {
            v2654 = ArrayItems[v2652];
            if (!(v2653.Add(v2654)))
                continue;
            if (v2656 == 45)
                return v2654;
            v2656++;
        }

        v2655 = 0;
        for (; v2655 < ArrayItems2.Length; v2655++)
        {
            v2654 = ArrayItems2[v2655];
            if (!(v2653.Add(v2654)))
                continue;
            if (v2656 == 45)
                return v2654;
            v2656++;
        }

        return default(int);
    }

    int ArrayUnionArrayFirstRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2657;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2658;
        int v2659;
        int v2660;
        v2658 = new HashSet<int>();
        v2657 = 0;
        for (; v2657 < ArrayItems.Length; v2657++)
        {
            v2659 = ArrayItems[v2657];
            if (!(v2658.Add(v2659)))
                continue;
            return v2659;
        }

        v2660 = 0;
        for (; v2660 < ArrayItems2.Length; v2660++)
        {
            v2659 = ArrayItems2[v2660];
            if (!(v2658.Add(v2659)))
                continue;
            return v2659;
        }

        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int ArrayUnionArrayFirstOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2661;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2662;
        int v2663;
        int v2664;
        v2662 = new HashSet<int>();
        v2661 = 0;
        for (; v2661 < ArrayItems.Length; v2661++)
        {
            v2663 = ArrayItems[v2661];
            if (!(v2662.Add(v2663)))
                continue;
            return v2663;
        }

        v2664 = 0;
        for (; v2664 < ArrayItems2.Length; v2664++)
        {
            v2663 = ArrayItems2[v2664];
            if (!(v2662.Add(v2663)))
                continue;
            return v2663;
        }

        return default(int);
    }

    int ArrayUnionArrayLastRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2665;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2666;
        int v2667;
        int v2668;
        int? v2669;
        v2666 = new HashSet<int>();
        v2669 = null;
        v2665 = 0;
        for (; v2665 < ArrayItems.Length; v2665++)
        {
            v2667 = ArrayItems[v2665];
            if (!(v2666.Add(v2667)))
                continue;
            v2669 = v2667;
        }

        v2668 = 0;
        for (; v2668 < ArrayItems2.Length; v2668++)
        {
            v2667 = ArrayItems2[v2668];
            if (!(v2666.Add(v2667)))
                continue;
            v2669 = v2667;
        }

        if (v2669 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v2669;
    }

    int ArrayUnionArrayLastOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2670;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2671;
        int v2672;
        int v2673;
        int? v2674;
        v2671 = new HashSet<int>();
        v2674 = null;
        v2670 = 0;
        for (; v2670 < ArrayItems.Length; v2670++)
        {
            v2672 = ArrayItems[v2670];
            if (!(v2671.Add(v2672)))
                continue;
            v2674 = v2672;
        }

        v2673 = 0;
        for (; v2673 < ArrayItems2.Length; v2673++)
        {
            v2672 = ArrayItems2[v2673];
            if (!(v2671.Add(v2672)))
                continue;
            v2674 = v2672;
        }

        if (v2674 == null)
            return default(int);
        else
            return (int)v2674;
    }

    int ArrayUnionArraySingleRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2675;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2676;
        int v2677;
        int v2678;
        int? v2679;
        v2676 = new HashSet<int>();
        v2679 = null;
        v2675 = 0;
        for (; v2675 < ArrayItems.Length; v2675++)
        {
            v2677 = ArrayItems[v2675];
            if (!(v2676.Add(v2677)))
                continue;
            if (v2679 == null)
                v2679 = v2677;
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        v2678 = 0;
        for (; v2678 < ArrayItems2.Length; v2678++)
        {
            v2677 = ArrayItems2[v2678];
            if (!(v2676.Add(v2677)))
                continue;
            if (v2679 == null)
                v2679 = v2677;
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v2679 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v2679;
    }

    int ArrayUnionArraySingle2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2680;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2681;
        int v2682;
        int v2683;
        int? v2684;
        v2681 = new HashSet<int>();
        v2684 = null;
        v2680 = 0;
        for (; v2680 < ArrayItems.Length; v2680++)
        {
            v2682 = ArrayItems[v2680];
            if (!(v2681.Add(v2682)))
                continue;
            if ((v2682 == 76))
                if (v2684 == null)
                    v2684 = v2682;
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        v2683 = 0;
        for (; v2683 < ArrayItems2.Length; v2683++)
        {
            v2682 = ArrayItems2[v2683];
            if (!(v2681.Add(v2682)))
                continue;
            if ((v2682 == 76))
                if (v2684 == null)
                    v2684 = v2682;
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v2684 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v2684;
    }

    int ArrayUnionArraySingleOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2685;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2686;
        int v2687;
        int v2688;
        int? v2689;
        v2686 = new HashSet<int>();
        v2689 = null;
        v2685 = 0;
        for (; v2685 < ArrayItems.Length; v2685++)
        {
            v2687 = ArrayItems[v2685];
            if (!(v2686.Add(v2687)))
                continue;
            if (v2689 == null)
                v2689 = v2687;
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        v2688 = 0;
        for (; v2688 < ArrayItems2.Length; v2688++)
        {
            v2687 = ArrayItems2[v2688];
            if (!(v2686.Add(v2687)))
                continue;
            if (v2689 == null)
                v2689 = v2687;
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v2689 == null)
            return default(int);
        else
            return (int)v2689;
    }

    int ArrayUnionArrayMinRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2690;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2691;
        int v2692;
        int v2693;
        int v2694;
        bool v2695;
        v2691 = new HashSet<int>();
        v2694 = 2147483647;
        v2695 = false;
        v2690 = 0;
        for (; v2690 < ArrayItems.Length; v2690++)
        {
            v2692 = ArrayItems[v2690];
            if (!(v2691.Add(v2692)))
                continue;
            if (v2692 >= v2694)
                continue;
            v2694 = v2692;
            v2695 = true;
        }

        v2693 = 0;
        for (; v2693 < ArrayItems2.Length; v2693++)
        {
            v2692 = ArrayItems2[v2693];
            if (!(v2691.Add(v2692)))
                continue;
            if (v2692 >= v2694)
                continue;
            v2694 = v2692;
            v2695 = true;
        }

        if (!(v2695))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v2694;
    }

    decimal ArrayUnionArrayMin2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2696;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2697;
        int v2698;
        int v2699;
        decimal v2700;
        bool v2701;
        decimal v2702;
        v2697 = new HashSet<int>();
        v2700 = 79228162514264337593543950335M;
        v2701 = false;
        v2696 = 0;
        for (; v2696 < ArrayItems.Length; v2696++)
        {
            v2698 = ArrayItems[v2696];
            if (!(v2697.Add(v2698)))
                continue;
            v2702 = (v2698 + 2m);
            if (v2702 >= v2700)
                continue;
            v2700 = v2702;
            v2701 = true;
        }

        v2699 = 0;
        for (; v2699 < ArrayItems2.Length; v2699++)
        {
            v2698 = ArrayItems2[v2699];
            if (!(v2697.Add(v2698)))
                continue;
            v2702 = (v2698 + 2m);
            if (v2702 >= v2700)
                continue;
            v2700 = v2702;
            v2701 = true;
        }

        if (!(v2701))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v2700;
    }

    int ArrayUnionArrayMaxRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2703;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2704;
        int v2705;
        int v2706;
        int v2707;
        bool v2708;
        v2704 = new HashSet<int>();
        v2707 = -2147483648;
        v2708 = false;
        v2703 = 0;
        for (; v2703 < ArrayItems.Length; v2703++)
        {
            v2705 = ArrayItems[v2703];
            if (!(v2704.Add(v2705)))
                continue;
            if (v2705 <= v2707)
                continue;
            v2707 = v2705;
            v2708 = true;
        }

        v2706 = 0;
        for (; v2706 < ArrayItems2.Length; v2706++)
        {
            v2705 = ArrayItems2[v2706];
            if (!(v2704.Add(v2705)))
                continue;
            if (v2705 <= v2707)
                continue;
            v2707 = v2705;
            v2708 = true;
        }

        if (!(v2708))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v2707;
    }

    decimal ArrayUnionArrayMax2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2709;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2710;
        int v2711;
        int v2712;
        decimal v2713;
        bool v2714;
        decimal v2715;
        v2710 = new HashSet<int>();
        v2713 = -79228162514264337593543950335M;
        v2714 = false;
        v2709 = 0;
        for (; v2709 < ArrayItems.Length; v2709++)
        {
            v2711 = ArrayItems[v2709];
            if (!(v2710.Add(v2711)))
                continue;
            v2715 = (v2711 + 2m);
            if (v2715 <= v2713)
                continue;
            v2713 = v2715;
            v2714 = true;
        }

        v2712 = 0;
        for (; v2712 < ArrayItems2.Length; v2712++)
        {
            v2711 = ArrayItems2[v2712];
            if (!(v2710.Add(v2711)))
                continue;
            v2715 = (v2711 + 2m);
            if (v2715 <= v2713)
                continue;
            v2713 = v2715;
            v2714 = true;
        }

        if (!(v2714))
            throw new System.InvalidOperationException("Sequence does not contains any elements");
        return v2713;
    }

    long ArrayUnionArrayLongCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2716;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2717;
        int v2718;
        int v2719;
        long v2720;
        v2717 = new HashSet<int>();
        v2720 = 0;
        v2716 = 0;
        for (; v2716 < ArrayItems.Length; v2716++)
        {
            v2718 = ArrayItems[v2716];
            if (!(v2717.Add(v2718)))
                continue;
            v2720++;
        }

        v2719 = 0;
        for (; v2719 < ArrayItems2.Length; v2719++)
        {
            v2718 = ArrayItems2[v2719];
            if (!(v2717.Add(v2718)))
                continue;
            v2720++;
        }

        return v2720;
    }

    long ArrayUnionArrayLongCount2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2721;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2722;
        int v2723;
        int v2724;
        long v2725;
        v2722 = new HashSet<int>();
        v2725 = 0;
        v2721 = 0;
        for (; v2721 < ArrayItems.Length; v2721++)
        {
            v2723 = ArrayItems[v2721];
            if (!(v2722.Add(v2723)))
                continue;
            if (!((v2723 > 50)))
                continue;
            v2725++;
        }

        v2724 = 0;
        for (; v2724 < ArrayItems2.Length; v2724++)
        {
            v2723 = ArrayItems2[v2724];
            if (!(v2722.Add(v2723)))
                continue;
            if (!((v2723 > 50)))
                continue;
            v2725++;
        }

        return v2725;
    }

    bool ArrayUnionArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2726;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2727;
        int v2728;
        int v2729;
        v2727 = new HashSet<int>();
        v2726 = 0;
        for (; v2726 < ArrayItems.Length; v2726++)
        {
            v2728 = ArrayItems[v2726];
            if (!(v2727.Add(v2728)))
                continue;
            if (v2728 == 56)
                return true;
        }

        v2729 = 0;
        for (; v2729 < ArrayItems2.Length; v2729++)
        {
            v2728 = ArrayItems2[v2729];
            if (!(v2727.Add(v2728)))
                continue;
            if (v2728 == 56)
                return true;
        }

        return false;
    }

    double ArrayUnionArrayAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2730;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2731;
        int v2732;
        int v2733;
        double v2734;
        int v2735;
        v2731 = new HashSet<int>();
        v2734 = 0;
        v2735 = 0;
        v2730 = 0;
        for (; v2730 < ArrayItems.Length; v2730++)
        {
            v2732 = ArrayItems[v2730];
            if (!(v2731.Add(v2732)))
                continue;
            v2734 += v2732;
            v2735++;
        }

        v2733 = 0;
        for (; v2733 < ArrayItems2.Length; v2733++)
        {
            v2732 = ArrayItems2[v2733];
            if (!(v2731.Add(v2732)))
                continue;
            v2734 += v2732;
            v2735++;
        }

        if (v2735 == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v2734 / v2735);
    }

    double ArrayUnionArrayAverage2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2736;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2737;
        int v2738;
        int v2739;
        double v2740;
        int v2741;
        v2737 = new HashSet<int>();
        v2740 = 0;
        v2741 = 0;
        v2736 = 0;
        for (; v2736 < ArrayItems.Length; v2736++)
        {
            v2738 = ArrayItems[v2736];
            if (!(v2737.Add(v2738)))
                continue;
            v2740 += (v2738 + 10);
            v2741++;
        }

        v2739 = 0;
        for (; v2739 < ArrayItems2.Length; v2739++)
        {
            v2738 = ArrayItems2[v2739];
            if (!(v2737.Add(v2738)))
                continue;
            v2740 += (v2738 + 10);
            v2741++;
        }

        if (v2741 == 0)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        return (v2740 / v2741);
    }

    bool ArrayUnionArrayContains2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2742;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2743;
        int v2744;
        int v2745;
        System.Collections.Generic.EqualityComparer<int> v2746;
        v2743 = new HashSet<int>();
        v2746 = EqualityComparer<int>.Default;
        v2742 = 0;
        for (; v2742 < ArrayItems.Length; v2742++)
        {
            v2744 = ArrayItems[v2742];
            if (!(v2743.Add(v2744)))
                continue;
            if (v2746.Equals(v2744, 56))
                return true;
        }

        v2745 = 0;
        for (; v2745 < ArrayItems2.Length; v2745++)
        {
            v2744 = ArrayItems2[v2745];
            if (!(v2743.Add(v2744)))
                continue;
            if (v2746.Equals(v2744, 56))
                return true;
        }

        return false;
    }

    System.Collections.Generic.IEnumerable<int> SelectWhereArrayUnionSelectWhereArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v2747;
        int v2748;
        v2747 = 0;
        for (; v2747 < ArrayItems2.Length; v2747++)
        {
            v2748 = (ArrayItems2[v2747] + 10);
            if (!((v2748 > 80)))
                continue;
            yield return v2748;
        }
    }

    bool SelectWhereArrayUnionSelectWhereArrayContainsRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v2749;
        int v2750;
        if (SelectWhereArrayUnionSelectWhereArrayContainsRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2751;
        IEnumerator<int> v2752;
        v2752 = SelectWhereArrayUnionSelectWhereArrayContainsRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v2751 = new HashSet<int>();
        v2749 = 0;
        for (; v2749 < ArrayItems.Length; v2749++)
        {
            v2750 = (ArrayItems[v2749] + 10);
            if (!((v2750 > 80)))
                continue;
            if (!(v2751.Add(v2750)))
                continue;
            if (v2750 == 112)
                return true;
        }

        try
        {
            while (v2752.MoveNext())
            {
                v2750 = v2752.Current;
                if (!(v2751.Add(v2750)))
                    continue;
                if (v2750 == 112)
                    return true;
            }
        }
        finally
        {
            v2752.Dispose();
        }

        return false;
    }

    System.Collections.Generic.IEnumerable<int> RangeUnionArrayRewritten_ProceduralLinq1()
    {
        int v2753;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2754;
        int v2755;
        int v2756;
        v2754 = new HashSet<int>();
        v2753 = 0;
        for (; v2753 < 100; v2753++)
        {
            v2755 = (v2753 + 20);
            if (!(v2754.Add(v2755)))
                continue;
            yield return v2755;
        }

        v2756 = 0;
        for (; v2756 < ArrayItems2.Length; v2756++)
        {
            v2755 = ArrayItems2[v2756];
            if (!(v2754.Add(v2755)))
                continue;
            yield return v2755;
        }
    }

    System.Collections.Generic.IEnumerable<int> RepeatUnionArrayRewritten_ProceduralLinq1()
    {
        int v2757;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2758;
        int v2759;
        int v2760;
        v2758 = new HashSet<int>();
        v2757 = 0;
        for (; v2757 < 100; v2757++)
        {
            v2759 = 20;
            if (!(v2758.Add(v2759)))
                continue;
            yield return v2759;
        }

        v2760 = 0;
        for (; v2760 < ArrayItems2.Length; v2760++)
        {
            v2759 = ArrayItems2[v2760];
            if (!(v2758.Add(v2759)))
                continue;
            yield return v2759;
        }
    }

    System.Collections.Generic.IEnumerable<int> EmptyUnionArrayRewritten_ProceduralLinq1()
    {
        int v2761;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2762;
        int v2763;
        int v2764;
        v2762 = new HashSet<int>();
        v2761 = 0;
        for (; v2761 < 0; v2761++)
        {
            v2763 = default(int);
            if (!(v2762.Add(v2763)))
                continue;
            yield return v2763;
        }

        v2764 = 0;
        for (; v2764 < ArrayItems2.Length; v2764++)
        {
            v2763 = ArrayItems2[v2764];
            if (!(v2762.Add(v2763)))
                continue;
            yield return v2763;
        }
    }

    System.Collections.Generic.IEnumerable<int> RangeEmpty2ArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2765;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2766;
        int v2767;
        v2766 = new HashSet<int>();
        v2765 = 0;
        for (; v2765 < ArrayItems.Length; v2765++)
        {
            if (!((false)))
                continue;
            v2767 = ArrayItems[v2765];
            if (!(v2766.Add(v2767)))
                continue;
            yield return v2767;
        }

        v2765 = 0;
        for (; v2765 < ArrayItems2.Length; v2765++)
        {
            v2767 = ArrayItems2[v2765];
            if (!(v2766.Add(v2767)))
                continue;
            yield return v2767;
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionRangeRewritten_ProceduralLinq1()
    {
        int v2768;
        v2768 = 0;
        for (; v2768 < 260; v2768++)
            yield return (v2768 + 70);
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionRangeRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v2769;
        if (ArrayUnionRangeRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2770;
        int v2771;
        IEnumerator<int> v2772;
        v2772 = ArrayUnionRangeRewritten_ProceduralLinq1().GetEnumerator();
        v2770 = new HashSet<int>();
        v2769 = 0;
        for (; v2769 < ArrayItems.Length; v2769++)
        {
            v2771 = ArrayItems[v2769];
            if (!(v2770.Add(v2771)))
                continue;
            yield return v2771;
        }

        try
        {
            while (v2772.MoveNext())
            {
                v2771 = v2772.Current;
                if (!(v2770.Add(v2771)))
                    continue;
                yield return v2771;
            }
        }
        finally
        {
            v2772.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionRepeatRewritten_ProceduralLinq1()
    {
        int v2773;
        v2773 = 0;
        for (; v2773 < 100; v2773++)
            yield return 70;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionRepeatRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v2774;
        if (ArrayUnionRepeatRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2775;
        int v2776;
        IEnumerator<int> v2777;
        v2777 = ArrayUnionRepeatRewritten_ProceduralLinq1().GetEnumerator();
        v2775 = new HashSet<int>();
        v2774 = 0;
        for (; v2774 < ArrayItems.Length; v2774++)
        {
            v2776 = ArrayItems[v2774];
            if (!(v2775.Add(v2776)))
                continue;
            yield return v2776;
        }

        try
        {
            while (v2777.MoveNext())
            {
                v2776 = v2777.Current;
                if (!(v2775.Add(v2776)))
                    continue;
                yield return v2776;
            }
        }
        finally
        {
            v2777.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionEmptyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2778;
        if (Enumerable.Empty<int>() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2779;
        int v2780;
        IEnumerator<int> v2781;
        v2781 = Enumerable.Empty<int>().GetEnumerator();
        v2779 = new HashSet<int>();
        v2778 = 0;
        for (; v2778 < ArrayItems.Length; v2778++)
        {
            v2780 = ArrayItems[v2778];
            if (!(v2779.Add(v2780)))
                continue;
            yield return v2780;
        }

        try
        {
            while (v2781.MoveNext())
            {
                v2780 = v2781.Current;
                if (!(v2779.Add(v2780)))
                    continue;
                yield return v2780;
            }
        }
        finally
        {
            v2781.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionEmpty2Rewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v2782;
        v2782 = 0;
        for (; v2782 < ArrayItems2.Length; v2782++)
        {
            if (!((false)))
                continue;
            yield return ArrayItems2[v2782];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionEmpty2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v2783;
        if (ArrayUnionEmpty2Rewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2784;
        int v2785;
        IEnumerator<int> v2786;
        v2786 = ArrayUnionEmpty2Rewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v2784 = new HashSet<int>();
        v2783 = 0;
        for (; v2783 < ArrayItems.Length; v2783++)
        {
            v2785 = ArrayItems[v2783];
            if (!(v2784.Add(v2785)))
                continue;
            yield return v2785;
        }

        try
        {
            while (v2786.MoveNext())
            {
                v2785 = v2786.Current;
                if (!(v2784.Add(v2785)))
                    continue;
                yield return v2785;
            }
        }
        finally
        {
            v2786.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionAllRewritten_ProceduralLinq1()
    {
        int v2787;
        v2787 = 0;
        for (; v2787 < 1000; v2787++)
            yield return (v2787 + 0);
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionAllRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v2788;
        if (ArrayUnionAllRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2789;
        int v2790;
        IEnumerator<int> v2791;
        v2791 = ArrayUnionAllRewritten_ProceduralLinq1().GetEnumerator();
        v2789 = new HashSet<int>();
        v2788 = 0;
        for (; v2788 < ArrayItems.Length; v2788++)
        {
            v2790 = ArrayItems[v2788];
            if (!(v2789.Add(v2790)))
                continue;
            yield return v2790;
        }

        try
        {
            while (v2791.MoveNext())
            {
                v2790 = v2791.Current;
                if (!(v2789.Add(v2790)))
                    continue;
                yield return v2790;
            }
        }
        finally
        {
            v2791.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionNullRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2792;
        throw new System.InvalidOperationException("Invalid null object");
        v2792 = 0;
        for (; v2792 < ArrayItems.Length; v2792++)
            yield return ArrayItems[v2792];
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionArrayUnionEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2793;
        if (ArrayItems == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2794;
        int v2795;
        int v2796;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2797;
        IEnumerator<int> v2798;
        v2798 = EnumerableItems2.GetEnumerator();
        v2794 = new HashSet<int>();
        v2797 = new HashSet<int>();
        v2793 = 0;
        for (; v2793 < ArrayItems.Length; v2793++)
        {
            v2795 = ArrayItems[v2793];
            if (!(v2794.Add(v2795)))
                continue;
            if (!(v2797.Add(v2795)))
                continue;
            yield return v2795;
        }

        v2796 = 0;
        for (; v2796 < ArrayItems.Length; v2796++)
        {
            v2795 = ArrayItems[v2796];
            if (!(v2794.Add(v2795)))
                continue;
            if (!(v2797.Add(v2795)))
                continue;
            yield return v2795;
        }

        try
        {
            while (v2798.MoveNext())
            {
                v2795 = v2798.Current;
                if (!(v2797.Add(v2795)))
                    continue;
                yield return v2795;
            }
        }
        finally
        {
            v2798.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionArrayUnionEnumerable2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2799;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2800;
        int v2801;
        IEnumerator<int> v2802;
        v2802 = EnumerableItems2.GetEnumerator();
        v2800 = new HashSet<int>();
        v2799 = 0;
        for (; v2799 < ArrayItems.Length; v2799++)
        {
            v2801 = ArrayItems[v2799];
            if (!(v2800.Add(v2801)))
                continue;
            yield return v2801;
        }

        try
        {
            while (v2802.MoveNext())
            {
                v2801 = v2802.Current;
                if (!(v2800.Add(v2801)))
                    continue;
                yield return v2801;
            }
        }
        finally
        {
            v2802.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionArrayUnionEnumerable2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v2803;
        if (ArrayUnionArrayUnionEnumerable2Rewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2804;
        int v2805;
        IEnumerator<int> v2806;
        v2806 = ArrayUnionArrayUnionEnumerable2Rewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v2804 = new HashSet<int>();
        v2803 = 0;
        for (; v2803 < ArrayItems.Length; v2803++)
        {
            v2805 = ArrayItems[v2803];
            if (!(v2804.Add(v2805)))
                continue;
            yield return v2805;
        }

        try
        {
            while (v2806.MoveNext())
            {
                v2805 = v2806.Current;
                if (!(v2804.Add(v2805)))
                    continue;
                yield return v2805;
            }
        }
        finally
        {
            v2806.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctUnionArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2807;
        HashSet<int> v2808;
        v2808 = new HashSet<int>();
        v2807 = 0;
        for (; v2807 < ArrayItems.Length; v2807++)
        {
            if (!(v2808.Add(ArrayItems[v2807])))
                continue;
            yield return ArrayItems[v2807];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctUnionArrayDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v2809;
        HashSet<int> v2810;
        if (ArrayDistinctUnionArrayDistinctRewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2811;
        int v2812;
        IEnumerator<int> v2813;
        v2813 = ArrayDistinctUnionArrayDistinctRewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v2810 = new HashSet<int>();
        v2811 = new HashSet<int>();
        v2809 = 0;
        for (; v2809 < ArrayItems.Length; v2809++)
        {
            if (!(v2810.Add(ArrayItems[v2809])))
                continue;
            v2812 = ArrayItems[v2809];
            if (!(v2811.Add(v2812)))
                continue;
            yield return v2812;
        }

        try
        {
            while (v2813.MoveNext())
            {
                v2812 = v2813.Current;
                if (!(v2811.Add(v2812)))
                    continue;
                yield return v2812;
            }
        }
        finally
        {
            v2813.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctUnionArrayDistinctDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2814;
        HashSet<int> v2815;
        v2815 = new HashSet<int>();
        v2814 = 0;
        for (; v2814 < ArrayItems.Length; v2814++)
        {
            if (!(v2815.Add(ArrayItems[v2814])))
                continue;
            yield return ArrayItems[v2814];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctUnionArrayDistinctDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v2816;
        HashSet<int> v2817;
        if (ArrayDistinctUnionArrayDistinctDistinctRewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2818;
        int v2819;
        IEnumerator<int> v2820;
        HashSet<int> v2821;
        v2820 = ArrayDistinctUnionArrayDistinctDistinctRewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v2817 = new HashSet<int>();
        v2818 = new HashSet<int>();
        v2821 = new HashSet<int>();
        v2816 = 0;
        for (; v2816 < ArrayItems.Length; v2816++)
        {
            if (!(v2817.Add(ArrayItems[v2816])))
                continue;
            v2819 = ArrayItems[v2816];
            if (!(v2818.Add(v2819)))
                continue;
            if (!(v2821.Add(v2819)))
                continue;
            yield return v2819;
        }

        try
        {
            while (v2820.MoveNext())
            {
                v2819 = v2820.Current;
                if (!(v2818.Add(v2819)))
                    continue;
                if (!(v2821.Add(v2819)))
                    continue;
                yield return v2819;
            }
        }
        finally
        {
            v2820.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctUnionArrayDistinctDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2822;
        HashSet<int> v2823;
        v2823 = new HashSet<int>(EqualityComparer<int>.Default);
        v2822 = 0;
        for (; v2822 < ArrayItems.Length; v2822++)
        {
            if (!(v2823.Add(ArrayItems[v2822])))
                continue;
            yield return ArrayItems[v2822];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctUnionArrayDistinctDistinct2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v2824;
        HashSet<int> v2825;
        if (ArrayDistinctUnionArrayDistinctDistinct2Rewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2826;
        int v2827;
        IEnumerator<int> v2828;
        HashSet<int> v2829;
        v2828 = ArrayDistinctUnionArrayDistinctDistinct2Rewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v2825 = new HashSet<int>(EqualityComparer<int>.Default);
        v2826 = new HashSet<int>();
        v2829 = new HashSet<int>(EqualityComparer<int>.Default);
        v2824 = 0;
        for (; v2824 < ArrayItems.Length; v2824++)
        {
            if (!(v2825.Add(ArrayItems[v2824])))
                continue;
            v2827 = ArrayItems[v2824];
            if (!(v2826.Add(v2827)))
                continue;
            if (!(v2829.Add(v2827)))
                continue;
            yield return v2827;
        }

        try
        {
            while (v2828.MoveNext())
            {
                v2827 = v2828.Current;
                if (!(v2826.Add(v2827)))
                    continue;
                if (!(v2829.Add(v2827)))
                    continue;
                yield return v2827;
            }
        }
        finally
        {
            v2828.Dispose();
        }
    }
}}