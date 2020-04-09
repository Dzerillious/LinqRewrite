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
        int v2990;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2991;
        int v2992;
        int v2993;
        v2991 = new HashSet<int>();
        v2990 = (0);
        for (; v2990 < (ArrayItems.Length); v2990++)
        {
            v2992 = (ArrayItems[v2990]);
            if (!(v2991.Add((v2992))))
                continue;
            yield return (v2992);
        }

        v2993 = (0);
        for (; v2993 < (ArrayItems2.Length); v2993++)
        {
            v2992 = ArrayItems2[v2993];
            if (!(v2991.Add((v2992))))
                continue;
            yield return (v2992);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2994;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v2995;
        int v2996;
        int v2997;
        int v2998;
        v2995 = new HashSet<int>();
        v2997 = SimpleListItems2.Count;
        v2994 = (0);
        for (; v2994 < (ArrayItems.Length); v2994++)
        {
            v2996 = (ArrayItems[v2994]);
            if (!(v2995.Add((v2996))))
                continue;
            yield return (v2996);
        }

        v2998 = (0);
        for (; v2998 < (v2997); v2998++)
        {
            v2996 = SimpleListItems2[v2998];
            if (!(v2995.Add((v2996))))
                continue;
            yield return (v2996);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2999;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3000;
        int v3001;
        IEnumerator<int> v3002;
        v3002 = EnumerableItems2.GetEnumerator();
        v3000 = new HashSet<int>();
        v2999 = (0);
        for (; v2999 < (ArrayItems.Length); v2999++)
        {
            v3001 = (ArrayItems[v2999]);
            if (!(v3000.Add((v3001))))
                continue;
            yield return (v3001);
        }

        try
        {
            while (v3002.MoveNext())
            {
                v3001 = v3002.Current;
                if (!(v3000.Add((v3001))))
                    continue;
                yield return (v3001);
            }
        }
        finally
        {
            v3002.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionMethodRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3003;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3004;
        int v3005;
        IEnumerator<int> v3006;
        v3006 = MethodEnumerable2().GetEnumerator();
        v3004 = new HashSet<int>();
        v3003 = (0);
        for (; v3003 < (ArrayItems.Length); v3003++)
        {
            v3005 = (ArrayItems[v3003]);
            if (!(v3004.Add((v3005))))
                continue;
            yield return (v3005);
        }

        try
        {
            while (v3006.MoveNext())
            {
                v3005 = v3006.Current;
                if (!(v3004.Add((v3005))))
                    continue;
                yield return (v3005);
            }
        }
        finally
        {
            v3006.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SimpleListUnionArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v3007;
        LinqRewrite.Core.SimpleList.SimpleList<int> v3008;
        int v3009;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3010;
        int v3011;
        int v3012;
        v3007 = SimpleListItems.Count;
        v3008 = SimpleListItems;
        v3010 = new HashSet<int>();
        v3009 = (0);
        for (; v3009 < (v3007); v3009++)
        {
            v3011 = (v3008[v3009]);
            if (!(v3010.Add((v3011))))
                continue;
            yield return (v3011);
        }

        v3012 = (0);
        for (; v3012 < (ArrayItems2.Length); v3012++)
        {
            v3011 = ArrayItems2[v3012];
            if (!(v3010.Add((v3011))))
                continue;
            yield return (v3011);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SimpleListUnionSimpleListRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v3013;
        LinqRewrite.Core.SimpleList.SimpleList<int> v3014;
        int v3015;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3016;
        int v3017;
        int v3018;
        int v3019;
        v3013 = SimpleListItems.Count;
        v3014 = SimpleListItems;
        v3016 = new HashSet<int>();
        v3018 = SimpleListItems2.Count;
        v3015 = (0);
        for (; v3015 < (v3013); v3015++)
        {
            v3017 = (v3014[v3015]);
            if (!(v3016.Add((v3017))))
                continue;
            yield return (v3017);
        }

        v3019 = (0);
        for (; v3019 < (v3018); v3019++)
        {
            v3017 = SimpleListItems2[v3019];
            if (!(v3016.Add((v3017))))
                continue;
            yield return (v3017);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SimpleListUnionEnumerableRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v3020;
        LinqRewrite.Core.SimpleList.SimpleList<int> v3021;
        int v3022;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3023;
        int v3024;
        IEnumerator<int> v3025;
        v3025 = EnumerableItems2.GetEnumerator();
        v3020 = SimpleListItems.Count;
        v3021 = SimpleListItems;
        v3023 = new HashSet<int>();
        v3022 = (0);
        for (; v3022 < (v3020); v3022++)
        {
            v3024 = (v3021[v3022]);
            if (!(v3023.Add((v3024))))
                continue;
            yield return (v3024);
        }

        try
        {
            while (v3025.MoveNext())
            {
                v3024 = v3025.Current;
                if (!(v3023.Add((v3024))))
                    continue;
                yield return (v3024);
            }
        }
        finally
        {
            v3025.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SimpleListUnionMethodRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v3026;
        LinqRewrite.Core.SimpleList.SimpleList<int> v3027;
        int v3028;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3029;
        int v3030;
        IEnumerator<int> v3031;
        v3031 = MethodEnumerable2().GetEnumerator();
        v3026 = SimpleListItems.Count;
        v3027 = SimpleListItems;
        v3029 = new HashSet<int>();
        v3028 = (0);
        for (; v3028 < (v3026); v3028++)
        {
            v3030 = (v3027[v3028]);
            if (!(v3029.Add((v3030))))
                continue;
            yield return (v3030);
        }

        try
        {
            while (v3031.MoveNext())
            {
                v3030 = v3031.Current;
                if (!(v3029.Add((v3030))))
                    continue;
                yield return (v3030);
            }
        }
        finally
        {
            v3031.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableUnionArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v3032;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3033;
        int v3034;
        int v3035;
        v3032 = EnumerableItems.GetEnumerator();
        v3033 = new HashSet<int>();
        try
        {
            while (v3032.MoveNext())
            {
                v3034 = (v3032.Current);
                if (!(v3033.Add((v3034))))
                    continue;
                yield return (v3034);
            }
        }
        finally
        {
            v3032.Dispose();
        }

        v3035 = (0);
        for (; v3035 < (ArrayItems2.Length); v3035++)
        {
            v3034 = ArrayItems2[v3035];
            if (!(v3033.Add((v3034))))
                continue;
            yield return (v3034);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableUnionSimpleListRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v3036;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3037;
        int v3038;
        int v3039;
        int v3040;
        v3036 = EnumerableItems.GetEnumerator();
        v3037 = new HashSet<int>();
        v3039 = SimpleListItems2.Count;
        try
        {
            while (v3036.MoveNext())
            {
                v3038 = (v3036.Current);
                if (!(v3037.Add((v3038))))
                    continue;
                yield return (v3038);
            }
        }
        finally
        {
            v3036.Dispose();
        }

        v3040 = (0);
        for (; v3040 < (v3039); v3040++)
        {
            v3038 = SimpleListItems2[v3040];
            if (!(v3037.Add((v3038))))
                continue;
            yield return (v3038);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableUnionEnumerableRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v3041;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3042;
        int v3043;
        IEnumerator<int> v3044;
        v3041 = EnumerableItems.GetEnumerator();
        v3044 = EnumerableItems2.GetEnumerator();
        v3042 = new HashSet<int>();
        try
        {
            while (v3041.MoveNext())
            {
                v3043 = (v3041.Current);
                if (!(v3042.Add((v3043))))
                    continue;
                yield return (v3043);
            }
        }
        finally
        {
            v3041.Dispose();
        }

        try
        {
            while (v3044.MoveNext())
            {
                v3043 = v3044.Current;
                if (!(v3042.Add((v3043))))
                    continue;
                yield return (v3043);
            }
        }
        finally
        {
            v3044.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableUnionMethodRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v3045;
        if (MethodEnumerable2() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3046;
        int v3047;
        IEnumerator<int> v3048;
        v3045 = EnumerableItems.GetEnumerator();
        v3048 = MethodEnumerable2().GetEnumerator();
        v3046 = new HashSet<int>();
        try
        {
            while (v3045.MoveNext())
            {
                v3047 = (v3045.Current);
                if (!(v3046.Add((v3047))))
                    continue;
                yield return (v3047);
            }
        }
        finally
        {
            v3045.Dispose();
        }

        try
        {
            while (v3048.MoveNext())
            {
                v3047 = v3048.Current;
                if (!(v3046.Add((v3047))))
                    continue;
                yield return (v3047);
            }
        }
        finally
        {
            v3048.Dispose();
        }

        yield break;
    }

    int[] ArrayUnionArrayToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3049;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3050;
        int v3051;
        int v3052;
        int v3053;
        int v3054;
        int v3055;
        int[] v3056;
        v3050 = new HashSet<int>();
        v3053 = 0;
        v3054 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems2.Length + ArrayItems.Length))) - 3);
        v3054 -= (v3054 % 2);
        v3055 = 8;
        v3056 = new int[8];
        v3049 = (0);
        for (; v3049 < (ArrayItems.Length); v3049++)
        {
            v3051 = (ArrayItems[v3049]);
            if (!(v3050.Add((v3051))))
                continue;
            if (v3053 >= v3055)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems2.Length + ArrayItems.Length), ref v3056, ref v3054, out v3055);
            v3056[v3053] = (v3051);
            v3053++;
        }

        v3052 = (0);
        for (; v3052 < (ArrayItems2.Length); v3052++)
        {
            v3051 = ArrayItems2[v3052];
            if (!(v3050.Add((v3051))))
                continue;
            if (v3053 >= v3055)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems2.Length + ArrayItems.Length), ref v3056, ref v3054, out v3055);
            v3056[v3053] = (v3051);
            v3053++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v3056, v3053);
    }

    int[] ArrayUnionSimpleListToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3057;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3058;
        int v3059;
        int v3060;
        int v3061;
        int v3062;
        int v3063;
        int v3064;
        int[] v3065;
        v3058 = new HashSet<int>();
        v3060 = SimpleListItems2.Count;
        v3062 = 0;
        v3063 = (LinqRewrite.Core.IntExtensions.Log2((uint)((v3060 + ArrayItems.Length))) - 3);
        v3063 -= (v3063 % 2);
        v3064 = 8;
        v3065 = new int[8];
        v3057 = (0);
        for (; v3057 < (ArrayItems.Length); v3057++)
        {
            v3059 = (ArrayItems[v3057]);
            if (!(v3058.Add((v3059))))
                continue;
            if (v3062 >= v3064)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (v3060 + ArrayItems.Length), ref v3065, ref v3063, out v3064);
            v3065[v3062] = (v3059);
            v3062++;
        }

        v3061 = (0);
        for (; v3061 < (v3060); v3061++)
        {
            v3059 = SimpleListItems2[v3061];
            if (!(v3058.Add((v3059))))
                continue;
            if (v3062 >= v3064)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (v3060 + ArrayItems.Length), ref v3065, ref v3063, out v3064);
            v3065[v3062] = (v3059);
            v3062++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v3065, v3062);
    }

    int[] ArrayUnionEnumerableToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3066;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3067;
        int v3068;
        IEnumerator<int> v3069;
        int v3070;
        int v3071;
        int[] v3072;
        v3069 = EnumerableItems2.GetEnumerator();
        v3067 = new HashSet<int>();
        v3070 = 0;
        v3071 = 8;
        v3072 = new int[8];
        v3066 = (0);
        for (; v3066 < (ArrayItems.Length); v3066++)
        {
            v3068 = (ArrayItems[v3066]);
            if (!(v3067.Add((v3068))))
                continue;
            if (v3070 >= v3071)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v3072, ref v3071);
            v3072[v3070] = (v3068);
            v3070++;
        }

        try
        {
            while (v3069.MoveNext())
            {
                v3068 = v3069.Current;
                if (!(v3067.Add((v3068))))
                    continue;
                if (v3070 >= v3071)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v3072, ref v3071);
                v3072[v3070] = (v3068);
                v3070++;
            }
        }
        finally
        {
            v3069.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v3072, v3070);
    }

    int[] SimpleListUnionArrayToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v3073;
        LinqRewrite.Core.SimpleList.SimpleList<int> v3074;
        int v3075;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3076;
        int v3077;
        int v3078;
        int v3079;
        int v3080;
        int v3081;
        int[] v3082;
        v3073 = SimpleListItems.Count;
        v3074 = SimpleListItems;
        v3076 = new HashSet<int>();
        v3079 = 0;
        v3080 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems2.Length + v3073))) - 3);
        v3080 -= (v3080 % 2);
        v3081 = 8;
        v3082 = new int[8];
        v3075 = (0);
        for (; v3075 < (v3073); v3075++)
        {
            v3077 = (v3074[v3075]);
            if (!(v3076.Add((v3077))))
                continue;
            if (v3079 >= v3081)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems2.Length + v3073), ref v3082, ref v3080, out v3081);
            v3082[v3079] = (v3077);
            v3079++;
        }

        v3078 = (0);
        for (; v3078 < (ArrayItems2.Length); v3078++)
        {
            v3077 = ArrayItems2[v3078];
            if (!(v3076.Add((v3077))))
                continue;
            if (v3079 >= v3081)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems2.Length + v3073), ref v3082, ref v3080, out v3081);
            v3082[v3079] = (v3077);
            v3079++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v3082, v3079);
    }

    int[] SimpleListUnionSimpleListToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v3083;
        LinqRewrite.Core.SimpleList.SimpleList<int> v3084;
        int v3085;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3086;
        int v3087;
        int v3088;
        int v3089;
        int v3090;
        int v3091;
        int v3092;
        int[] v3093;
        v3083 = SimpleListItems.Count;
        v3084 = SimpleListItems;
        v3086 = new HashSet<int>();
        v3088 = SimpleListItems2.Count;
        v3090 = 0;
        v3091 = (LinqRewrite.Core.IntExtensions.Log2((uint)((v3088 + v3083))) - 3);
        v3091 -= (v3091 % 2);
        v3092 = 8;
        v3093 = new int[8];
        v3085 = (0);
        for (; v3085 < (v3083); v3085++)
        {
            v3087 = (v3084[v3085]);
            if (!(v3086.Add((v3087))))
                continue;
            if (v3090 >= v3092)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (v3088 + v3083), ref v3093, ref v3091, out v3092);
            v3093[v3090] = (v3087);
            v3090++;
        }

        v3089 = (0);
        for (; v3089 < (v3088); v3089++)
        {
            v3087 = SimpleListItems2[v3089];
            if (!(v3086.Add((v3087))))
                continue;
            if (v3090 >= v3092)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (v3088 + v3083), ref v3093, ref v3091, out v3092);
            v3093[v3090] = (v3087);
            v3090++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v3093, v3090);
    }

    int[] SimpleListUnionEnumerableToArrayRewritten_ProceduralLinq1(LinqRewrite.Core.SimpleList.SimpleList<int> SimpleListItems)
    {
        int v3094;
        LinqRewrite.Core.SimpleList.SimpleList<int> v3095;
        int v3096;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3097;
        int v3098;
        IEnumerator<int> v3099;
        int v3100;
        int v3101;
        int[] v3102;
        v3099 = EnumerableItems2.GetEnumerator();
        v3094 = SimpleListItems.Count;
        v3095 = SimpleListItems;
        v3097 = new HashSet<int>();
        v3100 = 0;
        v3101 = 8;
        v3102 = new int[8];
        v3096 = (0);
        for (; v3096 < (v3094); v3096++)
        {
            v3098 = (v3095[v3096]);
            if (!(v3097.Add((v3098))))
                continue;
            if (v3100 >= v3101)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v3102, ref v3101);
            v3102[v3100] = (v3098);
            v3100++;
        }

        try
        {
            while (v3099.MoveNext())
            {
                v3098 = v3099.Current;
                if (!(v3097.Add((v3098))))
                    continue;
                if (v3100 >= v3101)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v3102, ref v3101);
                v3102[v3100] = (v3098);
                v3100++;
            }
        }
        finally
        {
            v3099.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v3102, v3100);
    }

    int[] EnumerableUnionArrayToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v3103;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3104;
        int v3105;
        int v3106;
        int v3107;
        int v3108;
        int[] v3109;
        v3103 = EnumerableItems.GetEnumerator();
        v3104 = new HashSet<int>();
        v3107 = 0;
        v3108 = 8;
        v3109 = new int[8];
        try
        {
            while (v3103.MoveNext())
            {
                v3105 = (v3103.Current);
                if (!(v3104.Add((v3105))))
                    continue;
                if (v3107 >= v3108)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v3109, ref v3108);
                v3109[v3107] = (v3105);
                v3107++;
            }
        }
        finally
        {
            v3103.Dispose();
        }

        v3106 = (0);
        for (; v3106 < (ArrayItems2.Length); v3106++)
        {
            v3105 = ArrayItems2[v3106];
            if (!(v3104.Add((v3105))))
                continue;
            if (v3107 >= v3108)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v3109, ref v3108);
            v3109[v3107] = (v3105);
            v3107++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v3109, v3107);
    }

    int[] EnumerableUnionSimpleListToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v3110;
        if (SimpleListItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3111;
        int v3112;
        int v3113;
        int v3114;
        int v3115;
        int v3116;
        int[] v3117;
        v3110 = EnumerableItems.GetEnumerator();
        v3111 = new HashSet<int>();
        v3113 = SimpleListItems2.Count;
        v3115 = 0;
        v3116 = 8;
        v3117 = new int[8];
        try
        {
            while (v3110.MoveNext())
            {
                v3112 = (v3110.Current);
                if (!(v3111.Add((v3112))))
                    continue;
                if (v3115 >= v3116)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v3117, ref v3116);
                v3117[v3115] = (v3112);
                v3115++;
            }
        }
        finally
        {
            v3110.Dispose();
        }

        v3114 = (0);
        for (; v3114 < (v3113); v3114++)
        {
            v3112 = SimpleListItems2[v3114];
            if (!(v3111.Add((v3112))))
                continue;
            if (v3115 >= v3116)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v3117, ref v3116);
            v3117[v3115] = (v3112);
            v3115++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v3117, v3115);
    }

    int[] EnumerableUnionEnumerableToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v3118;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3119;
        int v3120;
        IEnumerator<int> v3121;
        int v3122;
        int v3123;
        int[] v3124;
        v3118 = EnumerableItems.GetEnumerator();
        v3121 = EnumerableItems2.GetEnumerator();
        v3119 = new HashSet<int>();
        v3122 = 0;
        v3123 = 8;
        v3124 = new int[8];
        try
        {
            while (v3118.MoveNext())
            {
                v3120 = (v3118.Current);
                if (!(v3119.Add((v3120))))
                    continue;
                if (v3122 >= v3123)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v3124, ref v3123);
                v3124[v3122] = (v3120);
                v3122++;
            }
        }
        finally
        {
            v3118.Dispose();
        }

        try
        {
            while (v3121.MoveNext())
            {
                v3120 = v3121.Current;
                if (!(v3119.Add((v3120))))
                    continue;
                if (v3122 >= v3123)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v3124, ref v3123);
                v3124[v3122] = (v3120);
                v3122++;
            }
        }
        finally
        {
            v3121.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v3124, v3122);
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectUnionArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3125;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3126;
        int v3127;
        int v3128;
        v3126 = new HashSet<int>();
        v3125 = (0);
        for (; v3125 < (ArrayItems.Length); v3125++)
        {
            v3127 = (50 + ArrayItems[v3125]);
            if (!(v3126.Add((v3127))))
                continue;
            yield return (v3127);
        }

        v3128 = (0);
        for (; v3128 < (ArrayItems2.Length); v3128++)
        {
            v3127 = ArrayItems2[v3128];
            if (!(v3126.Add((v3127))))
                continue;
            yield return (v3127);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectUnionArraySelectRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v3130;
        v3130 = (0);
        for (; v3130 < (ArrayItems2.Length); v3130++)
            yield return (((ArrayItems2[v3130]) + 50));
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectUnionArraySelectRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v3131;
        if (ArraySelectUnionArraySelectRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3132;
        int v3133;
        IEnumerator<int> v3134;
        v3134 = ArraySelectUnionArraySelectRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v3132 = new HashSet<int>();
        v3131 = (0);
        for (; v3131 < (ArrayItems.Length); v3131++)
        {
            v3133 = (50 + ArrayItems[v3131]);
            if (!(v3132.Add((v3133))))
                continue;
            yield return (v3133);
        }

        try
        {
            while (v3134.MoveNext())
            {
                v3133 = v3134.Current;
                if (!(v3132.Add((v3133))))
                    continue;
                yield return (v3133);
            }
        }
        finally
        {
            v3134.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereUnionArrayWhereRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v3135;
        int v3136;
        v3135 = (0);
        for (; v3135 < (ArrayItems2.Length); v3135++)
        {
            v3136 = (ArrayItems2[v3135]);
            if (!(((v3136) > 50)))
                continue;
            yield return (v3136);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereUnionArrayWhereRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v3137;
        int v3138;
        if (ArrayWhereUnionArrayWhereRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3139;
        IEnumerator<int> v3140;
        v3140 = ArrayWhereUnionArrayWhereRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v3139 = new HashSet<int>();
        v3137 = (0);
        for (; v3137 < (ArrayItems.Length); v3137++)
        {
            v3138 = (ArrayItems[v3137]);
            if (!(((v3138) > 50)))
                continue;
            if (!(v3139.Add((v3138))))
                continue;
            yield return (v3138);
        }

        try
        {
            while (v3140.MoveNext())
            {
                v3138 = v3140.Current;
                if (!(v3139.Add((v3138))))
                    continue;
                yield return (v3138);
            }
        }
        finally
        {
            v3140.Dispose();
        }

        yield break;
    }

    int ArrayUnionArrayCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3141;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3142;
        int v3143;
        int v3144;
        int v3145;
        v3142 = new HashSet<int>();
        v3145 = 0;
        v3141 = (0);
        for (; v3141 < (ArrayItems.Length); v3141++)
        {
            v3143 = (ArrayItems[v3141]);
            if (!(v3142.Add((v3143))))
                continue;
            v3145++;
        }

        v3144 = (0);
        for (; v3144 < (ArrayItems2.Length); v3144++)
        {
            v3143 = ArrayItems2[v3144];
            if (!(v3142.Add((v3143))))
                continue;
            v3145++;
        }

        return v3145;
    }

    int ArrayUnionArrayCount2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3146;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3147;
        int v3148;
        int v3149;
        int v3150;
        v3147 = new HashSet<int>();
        v3150 = 0;
        v3146 = (0);
        for (; v3146 < (ArrayItems.Length); v3146++)
        {
            v3148 = (ArrayItems[v3146]);
            if (!(v3147.Add((v3148))))
                continue;
            if (!(((v3148) > 70)))
                continue;
            v3150++;
        }

        v3149 = (0);
        for (; v3149 < (ArrayItems2.Length); v3149++)
        {
            v3148 = ArrayItems2[v3149];
            if (!(v3147.Add((v3148))))
                continue;
            if (!(((v3148) > 70)))
                continue;
            v3150++;
        }

        return v3150;
    }

    int ArrayUnionArraySumRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3151;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3152;
        int v3153;
        int v3154;
        int v3155;
        v3152 = new HashSet<int>();
        v3155 = 0;
        v3151 = (0);
        for (; v3151 < (ArrayItems.Length); v3151++)
        {
            v3153 = (ArrayItems[v3151]);
            if (!(v3152.Add((v3153))))
                continue;
            v3155 += (v3153);
        }

        v3154 = (0);
        for (; v3154 < (ArrayItems2.Length); v3154++)
        {
            v3153 = ArrayItems2[v3154];
            if (!(v3152.Add((v3153))))
                continue;
            v3155 += (v3153);
        }

        return v3155;
    }

    int ArrayUnionArraySum2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3156;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3157;
        int v3158;
        int v3159;
        int v3160;
        int v3161;
        v3157 = new HashSet<int>();
        v3160 = 0;
        v3156 = (0);
        for (; v3156 < (ArrayItems.Length); v3156++)
        {
            v3158 = (ArrayItems[v3156]);
            if (!(v3157.Add((v3158))))
                continue;
            v3161 = ((v3158) + 10);
            v3160 += v3161;
        }

        v3159 = (0);
        for (; v3159 < (ArrayItems2.Length); v3159++)
        {
            v3158 = ArrayItems2[v3159];
            if (!(v3157.Add((v3158))))
                continue;
            v3161 = ((v3158) + 10);
            v3160 += v3161;
        }

        return v3160;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3162;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3163;
        int v3164;
        int v3165;
        HashSet<int> v3166;
        int v3167;
        v3163 = new HashSet<int>();
        v3166 = new HashSet<int>();
        v3162 = (0);
        for (; v3162 < (ArrayItems.Length); v3162++)
        {
            v3164 = (ArrayItems[v3162]);
            if (!(v3163.Add((v3164))))
                continue;
            v3167 = (v3164);
            if (!(v3166.Add((v3167))))
                continue;
            yield return (v3167);
        }

        v3165 = (0);
        for (; v3165 < (ArrayItems2.Length); v3165++)
        {
            v3164 = ArrayItems2[v3165];
            if (!(v3163.Add((v3164))))
                continue;
            v3167 = (v3164);
            if (!(v3166.Add((v3167))))
                continue;
            yield return (v3167);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionArrayDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3168;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3169;
        int v3170;
        int v3171;
        HashSet<int> v3172;
        int v3173;
        v3169 = new HashSet<int>();
        v3172 = new HashSet<int>(EqualityComparer<int>.Default);
        v3168 = (0);
        for (; v3168 < (ArrayItems.Length); v3168++)
        {
            v3170 = (ArrayItems[v3168]);
            if (!(v3169.Add((v3170))))
                continue;
            v3173 = (v3170);
            if (!(v3172.Add((v3173))))
                continue;
            yield return (v3173);
        }

        v3171 = (0);
        for (; v3171 < (ArrayItems2.Length); v3171++)
        {
            v3170 = ArrayItems2[v3171];
            if (!(v3169.Add((v3170))))
                continue;
            v3173 = (v3170);
            if (!(v3172.Add((v3173))))
                continue;
            yield return (v3173);
        }

        yield break;
    }

    int ArrayUnionArrayElementAtRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3174;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3175;
        int v3176;
        int v3177;
        int v3178;
        v3175 = new HashSet<int>();
        v3178 = 0;
        v3174 = (0);
        for (; v3174 < (ArrayItems.Length); v3174++)
        {
            v3176 = (ArrayItems[v3174]);
            if (!(v3175.Add((v3176))))
                continue;
            if (v3178 == 45)
                return (v3176);
            v3178++;
        }

        v3177 = (0);
        for (; v3177 < (ArrayItems2.Length); v3177++)
        {
            v3176 = ArrayItems2[v3177];
            if (!(v3175.Add((v3176))))
                continue;
            if (v3178 == 45)
                return (v3176);
            v3178++;
        }

        throw new System.InvalidOperationException("The sequence did not contain enough elements.");
    }

    int ArrayUnionArrayElementAtOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3179;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3180;
        int v3181;
        int v3182;
        int v3183;
        v3180 = new HashSet<int>();
        v3183 = 0;
        v3179 = (0);
        for (; v3179 < (ArrayItems.Length); v3179++)
        {
            v3181 = (ArrayItems[v3179]);
            if (!(v3180.Add((v3181))))
                continue;
            if (v3183 == 45)
                return (v3181);
            v3183++;
        }

        v3182 = (0);
        for (; v3182 < (ArrayItems2.Length); v3182++)
        {
            v3181 = ArrayItems2[v3182];
            if (!(v3180.Add((v3181))))
                continue;
            if (v3183 == 45)
                return (v3181);
            v3183++;
        }

        return default(int);
    }

    int ArrayUnionArrayFirstRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3184;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3185;
        int v3186;
        int v3187;
        int v3188;
        v3185 = new HashSet<int>();
        v3188 = 0;
        v3184 = (0);
        for (; v3184 < (ArrayItems.Length); v3184++)
        {
            v3186 = (ArrayItems[v3184]);
            if (!(v3185.Add((v3186))))
                continue;
            return (v3186);
            v3188++;
        }

        v3187 = (0);
        for (; v3187 < (ArrayItems2.Length); v3187++)
        {
            v3186 = ArrayItems2[v3187];
            if (!(v3185.Add((v3186))))
                continue;
            return (v3186);
            v3188++;
        }

        throw new System.InvalidOperationException("The sequence did not contain any elements.");
    }

    int ArrayUnionArrayFirstOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3189;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3190;
        int v3191;
        int v3192;
        v3190 = new HashSet<int>();
        v3189 = (0);
        for (; v3189 < (ArrayItems.Length); v3189++)
        {
            v3191 = (ArrayItems[v3189]);
            if (!(v3190.Add((v3191))))
                continue;
            return (v3191);
        }

        v3192 = (0);
        for (; v3192 < (ArrayItems2.Length); v3192++)
        {
            v3191 = ArrayItems2[v3192];
            if (!(v3190.Add((v3191))))
                continue;
            return (v3191);
        }

        return default(int);
    }

    int ArrayUnionArrayLastRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3193;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3194;
        int v3195;
        int v3196;
        int v3197;
        int? v3198;
        v3194 = new HashSet<int>();
        v3197 = 0;
        v3198 = null;
        v3193 = (0);
        for (; v3193 < (ArrayItems.Length); v3193++)
        {
            v3195 = (ArrayItems[v3193]);
            if (!(v3194.Add((v3195))))
                continue;
            v3198 = (v3195);
            v3197++;
        }

        v3196 = (0);
        for (; v3196 < (ArrayItems2.Length); v3196++)
        {
            v3195 = ArrayItems2[v3196];
            if (!(v3194.Add((v3195))))
                continue;
            v3198 = (v3195);
            v3197++;
        }

        if (v3198 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v3198;
    }

    int ArrayUnionArrayLastOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3199;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3200;
        int v3201;
        int v3202;
        int? v3203;
        v3200 = new HashSet<int>();
        v3203 = null;
        v3199 = (0);
        for (; v3199 < (ArrayItems.Length); v3199++)
        {
            v3201 = (ArrayItems[v3199]);
            if (!(v3200.Add((v3201))))
                continue;
            v3203 = (v3201);
        }

        v3202 = (0);
        for (; v3202 < (ArrayItems2.Length); v3202++)
        {
            v3201 = ArrayItems2[v3202];
            if (!(v3200.Add((v3201))))
                continue;
            v3203 = (v3201);
        }

        if (v3203 == null)
            return default(int);
        else
            return (int)v3203;
    }

    int ArrayUnionArraySingleRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3204;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3205;
        int v3206;
        int v3207;
        int? v3208;
        v3205 = new HashSet<int>();
        v3208 = null;
        v3204 = (0);
        for (; v3204 < (ArrayItems.Length); v3204++)
        {
            v3206 = (ArrayItems[v3204]);
            if (!(v3205.Add((v3206))))
                continue;
            if (v3208 == null)
                v3208 = (v3206);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        v3207 = (0);
        for (; v3207 < (ArrayItems2.Length); v3207++)
        {
            v3206 = ArrayItems2[v3207];
            if (!(v3205.Add((v3206))))
                continue;
            if (v3208 == null)
                v3208 = (v3206);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v3208 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v3208;
    }

    int ArrayUnionArraySingle2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3209;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3210;
        int v3211;
        int v3212;
        int? v3213;
        v3210 = new HashSet<int>();
        v3213 = null;
        v3209 = (0);
        for (; v3209 < (ArrayItems.Length); v3209++)
        {
            v3211 = (ArrayItems[v3209]);
            if (!(v3210.Add((v3211))))
                continue;
            if (((v3211) == 76))
                if (v3213 == null)
                    v3213 = (v3211);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        v3212 = (0);
        for (; v3212 < (ArrayItems2.Length); v3212++)
        {
            v3211 = ArrayItems2[v3212];
            if (!(v3210.Add((v3211))))
                continue;
            if (((v3211) == 76))
                if (v3213 == null)
                    v3213 = (v3211);
                else
                    throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v3213 == null)
            throw new System.InvalidOperationException("The sequence did not contain any elements.");
        else
            return (int)v3213;
    }

    int ArrayUnionArraySingleOrDefaultRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3214;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3215;
        int v3216;
        int v3217;
        int? v3218;
        v3215 = new HashSet<int>();
        v3218 = null;
        v3214 = (0);
        for (; v3214 < (ArrayItems.Length); v3214++)
        {
            v3216 = (ArrayItems[v3214]);
            if (!(v3215.Add((v3216))))
                continue;
            if (v3218 == null)
                v3218 = (v3216);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        v3217 = (0);
        for (; v3217 < (ArrayItems2.Length); v3217++)
        {
            v3216 = ArrayItems2[v3217];
            if (!(v3215.Add((v3216))))
                continue;
            if (v3218 == null)
                v3218 = (v3216);
            else
                throw new System.InvalidOperationException("The sequence contains more than single matching element.");
        }

        if (v3218 == null)
            return default(int);
        else
            return (int)v3218;
    }

    int ArrayUnionArrayMinRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3219;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3220;
        int v3221;
        int v3222;
        int v3223;
        int v3224;
        int v3225;
        v3220 = new HashSet<int>();
        v3223 = 0;
        v3224 = 2147483647;
        v3219 = (0);
        for (; v3219 < (ArrayItems.Length); v3219++)
        {
            v3221 = (ArrayItems[v3219]);
            if (!(v3220.Add((v3221))))
                continue;
            v3225 = (v3221);
            if (v3225 >= v3224)
                continue;
            v3224 = v3225;
            v3223++;
        }

        v3222 = (0);
        for (; v3222 < (ArrayItems2.Length); v3222++)
        {
            v3221 = ArrayItems2[v3222];
            if (!(v3220.Add((v3221))))
                continue;
            v3225 = (v3221);
            if (v3225 >= v3224)
                continue;
            v3224 = v3225;
            v3223++;
        }

        if (1 > v3223)
            throw new System.InvalidOperationException("Index out of range");
        return v3224;
    }

    decimal ArrayUnionArrayMin2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3226;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3227;
        int v3228;
        int v3229;
        int v3230;
        decimal v3231;
        decimal v3232;
        v3227 = new HashSet<int>();
        v3230 = 0;
        v3231 = 79228162514264337593543950335M;
        v3226 = (0);
        for (; v3226 < (ArrayItems.Length); v3226++)
        {
            v3228 = (ArrayItems[v3226]);
            if (!(v3227.Add((v3228))))
                continue;
            v3232 = ((v3228) + 2m);
            if (v3232 >= v3231)
                continue;
            v3231 = v3232;
            v3230++;
        }

        v3229 = (0);
        for (; v3229 < (ArrayItems2.Length); v3229++)
        {
            v3228 = ArrayItems2[v3229];
            if (!(v3227.Add((v3228))))
                continue;
            v3232 = ((v3228) + 2m);
            if (v3232 >= v3231)
                continue;
            v3231 = v3232;
            v3230++;
        }

        if (1 > v3230)
            throw new System.InvalidOperationException("Index out of range");
        return v3231;
    }

    int ArrayUnionArrayMaxRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3233;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3234;
        int v3235;
        int v3236;
        int v3237;
        int v3238;
        int v3239;
        v3234 = new HashSet<int>();
        v3237 = 0;
        v3238 = -2147483648;
        v3233 = (0);
        for (; v3233 < (ArrayItems.Length); v3233++)
        {
            v3235 = (ArrayItems[v3233]);
            if (!(v3234.Add((v3235))))
                continue;
            v3239 = (v3235);
            if (v3239 <= v3238)
                continue;
            v3238 = v3239;
            v3237++;
        }

        v3236 = (0);
        for (; v3236 < (ArrayItems2.Length); v3236++)
        {
            v3235 = ArrayItems2[v3236];
            if (!(v3234.Add((v3235))))
                continue;
            v3239 = (v3235);
            if (v3239 <= v3238)
                continue;
            v3238 = v3239;
            v3237++;
        }

        if (1 > v3237)
            throw new System.InvalidOperationException("Index out of range");
        return v3238;
    }

    decimal ArrayUnionArrayMax2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3240;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3241;
        int v3242;
        int v3243;
        int v3244;
        decimal v3245;
        decimal v3246;
        v3241 = new HashSet<int>();
        v3244 = 0;
        v3245 = -79228162514264337593543950335M;
        v3240 = (0);
        for (; v3240 < (ArrayItems.Length); v3240++)
        {
            v3242 = (ArrayItems[v3240]);
            if (!(v3241.Add((v3242))))
                continue;
            v3246 = ((v3242) + 2m);
            if (v3246 <= v3245)
                continue;
            v3245 = v3246;
            v3244++;
        }

        v3243 = (0);
        for (; v3243 < (ArrayItems2.Length); v3243++)
        {
            v3242 = ArrayItems2[v3243];
            if (!(v3241.Add((v3242))))
                continue;
            v3246 = ((v3242) + 2m);
            if (v3246 <= v3245)
                continue;
            v3245 = v3246;
            v3244++;
        }

        if (1 > v3244)
            throw new System.InvalidOperationException("Index out of range");
        return v3245;
    }

    long ArrayUnionArrayLongCountRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3247;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3248;
        int v3249;
        int v3250;
        long v3251;
        v3248 = new HashSet<int>();
        v3251 = 0;
        v3247 = (0);
        for (; v3247 < (ArrayItems.Length); v3247++)
        {
            v3249 = (ArrayItems[v3247]);
            if (!(v3248.Add((v3249))))
                continue;
            v3251++;
        }

        v3250 = (0);
        for (; v3250 < (ArrayItems2.Length); v3250++)
        {
            v3249 = ArrayItems2[v3250];
            if (!(v3248.Add((v3249))))
                continue;
            v3251++;
        }

        return v3251;
    }

    long ArrayUnionArrayLongCount2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3252;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3253;
        int v3254;
        int v3255;
        long v3256;
        v3253 = new HashSet<int>();
        v3256 = 0;
        v3252 = (0);
        for (; v3252 < (ArrayItems.Length); v3252++)
        {
            v3254 = (ArrayItems[v3252]);
            if (!(v3253.Add((v3254))))
                continue;
            if (!(((v3254) > 50)))
                continue;
            v3256++;
        }

        v3255 = (0);
        for (; v3255 < (ArrayItems2.Length); v3255++)
        {
            v3254 = ArrayItems2[v3255];
            if (!(v3253.Add((v3254))))
                continue;
            if (!(((v3254) > 50)))
                continue;
            v3256++;
        }

        return v3256;
    }

    bool ArrayUnionArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3257;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3258;
        int v3259;
        int v3260;
        v3258 = new HashSet<int>();
        v3257 = (0);
        for (; v3257 < (ArrayItems.Length); v3257++)
        {
            v3259 = (ArrayItems[v3257]);
            if (!(v3258.Add((v3259))))
                continue;
            if ((v3259) == 56)
                return true;
        }

        v3260 = (0);
        for (; v3260 < (ArrayItems2.Length); v3260++)
        {
            v3259 = ArrayItems2[v3260];
            if (!(v3258.Add((v3259))))
                continue;
            if ((v3259) == 56)
                return true;
        }

        return false;
    }

    double ArrayUnionArrayAverageRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3261;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3262;
        int v3263;
        int v3264;
        double v3265;
        int v3266;
        v3262 = new HashSet<int>();
        v3265 = 0;
        v3266 = 0;
        v3261 = (0);
        for (; v3261 < (ArrayItems.Length); v3261++)
        {
            v3263 = (ArrayItems[v3261]);
            if (!(v3262.Add((v3263))))
                continue;
            v3265 += (v3263);
            v3266++;
        }

        v3264 = (0);
        for (; v3264 < (ArrayItems2.Length); v3264++)
        {
            v3263 = ArrayItems2[v3264];
            if (!(v3262.Add((v3263))))
                continue;
            v3265 += (v3263);
            v3266++;
        }

        if (1 > v3266)
            throw new System.InvalidOperationException("Index out of range");
        return (v3265 / v3266);
    }

    double ArrayUnionArrayAverage2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3267;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3268;
        int v3269;
        int v3270;
        double v3271;
        int v3272;
        v3268 = new HashSet<int>();
        v3271 = 0;
        v3272 = 0;
        v3267 = (0);
        for (; v3267 < (ArrayItems.Length); v3267++)
        {
            v3269 = (ArrayItems[v3267]);
            if (!(v3268.Add((v3269))))
                continue;
            v3271 += ((v3269) + 10);
            v3272++;
        }

        v3270 = (0);
        for (; v3270 < (ArrayItems2.Length); v3270++)
        {
            v3269 = ArrayItems2[v3270];
            if (!(v3268.Add((v3269))))
                continue;
            v3271 += ((v3269) + 10);
            v3272++;
        }

        if (1 > v3272)
            throw new System.InvalidOperationException("Index out of range");
        return (v3271 / v3272);
    }

    bool ArrayUnionArrayContains2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3273;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3274;
        int v3275;
        int v3276;
        System.Collections.Generic.EqualityComparer<int> v3277;
        v3274 = new HashSet<int>();
        v3277 = EqualityComparer<int>.Default;
        v3273 = (0);
        for (; v3273 < (ArrayItems.Length); v3273++)
        {
            v3275 = (ArrayItems[v3273]);
            if (!(v3274.Add((v3275))))
                continue;
            if (v3277.Equals((v3275), 56))
                return true;
        }

        v3276 = (0);
        for (; v3276 < (ArrayItems2.Length); v3276++)
        {
            v3275 = ArrayItems2[v3276];
            if (!(v3274.Add((v3275))))
                continue;
            if (v3277.Equals((v3275), 56))
                return true;
        }

        return false;
    }

    System.Collections.Generic.IEnumerable<int> SelectWhereArrayUnionSelectWhereArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v3278;
        int v3279;
        v3278 = (0);
        for (; v3278 < (ArrayItems2.Length); v3278++)
        {
            v3279 = (((ArrayItems2[v3278]) + 10));
            if (!(((v3279) > 80)))
                continue;
            yield return (v3279);
        }

        yield break;
    }

    bool SelectWhereArrayUnionSelectWhereArrayContainsRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v3280;
        int v3281;
        if (SelectWhereArrayUnionSelectWhereArrayContainsRewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3282;
        IEnumerator<int> v3283;
        v3283 = SelectWhereArrayUnionSelectWhereArrayContainsRewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v3282 = new HashSet<int>();
        v3280 = (0);
        for (; v3280 < (ArrayItems.Length); v3280++)
        {
            v3281 = (10 + ArrayItems[v3280]);
            if (!(((v3281) > 80)))
                continue;
            if (!(v3282.Add((v3281))))
                continue;
            if ((v3281) == 112)
                return true;
        }

        try
        {
            while (v3283.MoveNext())
            {
                v3281 = v3283.Current;
                if (!(v3282.Add((v3281))))
                    continue;
                if ((v3281) == 112)
                    return true;
            }
        }
        finally
        {
            v3283.Dispose();
        }

        return false;
    }

    System.Collections.Generic.IEnumerable<int> RangeUnionArrayRewritten_ProceduralLinq1()
    {
        int v3284;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3285;
        int v3286;
        int v3287;
        v3285 = new HashSet<int>();
        v3284 = (0);
        for (; v3284 < (100); v3284++)
        {
            v3286 = (20 + v3284);
            if (!(v3285.Add((v3286))))
                continue;
            yield return (v3286);
        }

        v3287 = (0);
        for (; v3287 < (ArrayItems2.Length); v3287++)
        {
            v3286 = ArrayItems2[v3287];
            if (!(v3285.Add((v3286))))
                continue;
            yield return (v3286);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RepeatUnionArrayRewritten_ProceduralLinq1()
    {
        int v3288;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3289;
        int v3290;
        int v3291;
        v3289 = new HashSet<int>();
        v3288 = (0);
        for (; v3288 < (100); v3288++)
        {
            v3290 = (20);
            if (!(v3289.Add((v3290))))
                continue;
            yield return (v3290);
        }

        v3291 = (0);
        for (; v3291 < (ArrayItems2.Length); v3291++)
        {
            v3290 = ArrayItems2[v3291];
            if (!(v3289.Add((v3290))))
                continue;
            yield return (v3290);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EmptyUnionArrayRewritten_ProceduralLinq1()
    {
        int v3292;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3293;
        int v3294;
        int v3295;
        v3292 = 0;
        v3293 = new HashSet<int>();
        v3295 = (0);
        for (; v3295 < (ArrayItems2.Length); v3295++)
        {
            v3294 = ArrayItems2[v3295];
            if (!(v3293.Add((v3294))))
                continue;
            yield return (v3294);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeEmpty2ArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3296;
        int v3297;
        if (ArrayItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3298;
        int v3299;
        v3298 = new HashSet<int>();
        v3296 = (0);
        for (; v3296 < (ArrayItems.Length); v3296++)
        {
            v3297 = (ArrayItems[v3296]);
            if (!((false)))
                continue;
            if (!(v3298.Add((v3297))))
                continue;
            yield return (v3297);
        }

        v3299 = (0);
        for (; v3299 < (ArrayItems2.Length); v3299++)
        {
            v3297 = ArrayItems2[v3299];
            if (!(v3298.Add((v3297))))
                continue;
            yield return (v3297);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionRangeRewritten_ProceduralLinq1()
    {
        int v3300;
        v3300 = (0);
        for (; v3300 < (260); v3300++)
            yield return (70 + v3300);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionRangeRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v3301;
        if (ArrayUnionRangeRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3302;
        int v3303;
        IEnumerator<int> v3304;
        v3304 = ArrayUnionRangeRewritten_ProceduralLinq1().GetEnumerator();
        v3302 = new HashSet<int>();
        v3301 = (0);
        for (; v3301 < (ArrayItems.Length); v3301++)
        {
            v3303 = (ArrayItems[v3301]);
            if (!(v3302.Add((v3303))))
                continue;
            yield return (v3303);
        }

        try
        {
            while (v3304.MoveNext())
            {
                v3303 = v3304.Current;
                if (!(v3302.Add((v3303))))
                    continue;
                yield return (v3303);
            }
        }
        finally
        {
            v3304.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionRepeatRewritten_ProceduralLinq1()
    {
        int v3305;
        v3305 = (0);
        for (; v3305 < (100); v3305++)
            yield return (70);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionRepeatRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v3306;
        if (ArrayUnionRepeatRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3307;
        int v3308;
        IEnumerator<int> v3309;
        v3309 = ArrayUnionRepeatRewritten_ProceduralLinq1().GetEnumerator();
        v3307 = new HashSet<int>();
        v3306 = (0);
        for (; v3306 < (ArrayItems.Length); v3306++)
        {
            v3308 = (ArrayItems[v3306]);
            if (!(v3307.Add((v3308))))
                continue;
            yield return (v3308);
        }

        try
        {
            while (v3309.MoveNext())
            {
                v3308 = v3309.Current;
                if (!(v3307.Add((v3308))))
                    continue;
                yield return (v3308);
            }
        }
        finally
        {
            v3309.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionEmptyRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3310;
        if (Enumerable.Empty<int>() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3311;
        int v3312;
        IEnumerator<int> v3313;
        v3313 = Enumerable.Empty<int>().GetEnumerator();
        v3311 = new HashSet<int>();
        v3310 = (0);
        for (; v3310 < (ArrayItems.Length); v3310++)
        {
            v3312 = (ArrayItems[v3310]);
            if (!(v3311.Add((v3312))))
                continue;
            yield return (v3312);
        }

        try
        {
            while (v3313.MoveNext())
            {
                v3312 = v3313.Current;
                if (!(v3311.Add((v3312))))
                    continue;
                yield return (v3312);
            }
        }
        finally
        {
            v3313.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionEmpty2Rewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v3314;
        int v3315;
        v3314 = (0);
        for (; v3314 < (ArrayItems2.Length); v3314++)
        {
            v3315 = (ArrayItems2[v3314]);
            if (!((false)))
                continue;
            yield return (v3315);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionEmpty2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v3316;
        if (ArrayUnionEmpty2Rewritten_ProceduralLinq1(ArrayItems2) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3317;
        int v3318;
        IEnumerator<int> v3319;
        v3319 = ArrayUnionEmpty2Rewritten_ProceduralLinq1(ArrayItems2).GetEnumerator();
        v3317 = new HashSet<int>();
        v3316 = (0);
        for (; v3316 < (ArrayItems.Length); v3316++)
        {
            v3318 = (ArrayItems[v3316]);
            if (!(v3317.Add((v3318))))
                continue;
            yield return (v3318);
        }

        try
        {
            while (v3319.MoveNext())
            {
                v3318 = v3319.Current;
                if (!(v3317.Add((v3318))))
                    continue;
                yield return (v3318);
            }
        }
        finally
        {
            v3319.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionAllRewritten_ProceduralLinq1()
    {
        int v3320;
        v3320 = (0);
        for (; v3320 < (1000); v3320++)
            yield return (v3320);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionAllRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v3321;
        if (ArrayUnionAllRewritten_ProceduralLinq1() == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3322;
        int v3323;
        IEnumerator<int> v3324;
        v3324 = ArrayUnionAllRewritten_ProceduralLinq1().GetEnumerator();
        v3322 = new HashSet<int>();
        v3321 = (0);
        for (; v3321 < (ArrayItems.Length); v3321++)
        {
            v3323 = (ArrayItems[v3321]);
            if (!(v3322.Add((v3323))))
                continue;
            yield return (v3323);
        }

        try
        {
            while (v3324.MoveNext())
            {
                v3323 = v3324.Current;
                if (!(v3322.Add((v3323))))
                    continue;
                yield return (v3323);
            }
        }
        finally
        {
            v3324.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionNullRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3325;
        throw new System.InvalidOperationException("Invalid null object");
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionArrayUnionEnumerableRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3326;
        if (ArrayItems == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3327;
        int v3328;
        int v3329;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3330;
        IEnumerator<int> v3331;
        v3331 = EnumerableItems2.GetEnumerator();
        v3327 = new HashSet<int>();
        v3330 = new HashSet<int>();
        v3326 = (0);
        for (; v3326 < (ArrayItems.Length); v3326++)
        {
            v3328 = (ArrayItems[v3326]);
            if (!(v3327.Add((v3328))))
                continue;
            if (!(v3330.Add((v3328))))
                continue;
            yield return (v3328);
        }

        v3329 = (0);
        for (; v3329 < (ArrayItems.Length); v3329++)
        {
            v3328 = ArrayItems[v3329];
            if (!(v3327.Add((v3328))))
                continue;
            if (!(v3330.Add((v3328))))
                continue;
            yield return (v3328);
        }

        try
        {
            while (v3331.MoveNext())
            {
                v3328 = v3331.Current;
                if (!(v3330.Add((v3328))))
                    continue;
                yield return (v3328);
            }
        }
        finally
        {
            v3331.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionArrayUnionEnumerable2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3332;
        if (EnumerableItems2 == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3333;
        int v3334;
        IEnumerator<int> v3335;
        v3335 = EnumerableItems2.GetEnumerator();
        v3333 = new HashSet<int>();
        v3332 = (0);
        for (; v3332 < (ArrayItems.Length); v3332++)
        {
            v3334 = (ArrayItems[v3332]);
            if (!(v3333.Add((v3334))))
                continue;
            yield return (v3334);
        }

        try
        {
            while (v3335.MoveNext())
            {
                v3334 = v3335.Current;
                if (!(v3333.Add((v3334))))
                    continue;
                yield return (v3334);
            }
        }
        finally
        {
            v3335.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayUnionArrayUnionEnumerable2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v3336;
        if (ArrayUnionArrayUnionEnumerable2Rewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3337;
        int v3338;
        IEnumerator<int> v3339;
        v3339 = ArrayUnionArrayUnionEnumerable2Rewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v3337 = new HashSet<int>();
        v3336 = (0);
        for (; v3336 < (ArrayItems.Length); v3336++)
        {
            v3338 = (ArrayItems[v3336]);
            if (!(v3337.Add((v3338))))
                continue;
            yield return (v3338);
        }

        try
        {
            while (v3339.MoveNext())
            {
                v3338 = v3339.Current;
                if (!(v3337.Add((v3338))))
                    continue;
                yield return (v3338);
            }
        }
        finally
        {
            v3339.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctUnionArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3340;
        HashSet<int> v3341;
        int v3342;
        v3341 = new HashSet<int>();
        v3340 = (0);
        for (; v3340 < (ArrayItems.Length); v3340++)
        {
            v3342 = (ArrayItems[v3340]);
            if (!(v3341.Add((v3342))))
                continue;
            yield return (v3342);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctUnionArrayDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v3343;
        HashSet<int> v3344;
        int v3345;
        if (ArrayDistinctUnionArrayDistinctRewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3346;
        IEnumerator<int> v3347;
        v3347 = ArrayDistinctUnionArrayDistinctRewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v3344 = new HashSet<int>();
        v3346 = new HashSet<int>();
        v3343 = (0);
        for (; v3343 < (ArrayItems.Length); v3343++)
        {
            v3345 = (ArrayItems[v3343]);
            if (!(v3344.Add((v3345))))
                continue;
            if (!(v3346.Add((v3345))))
                continue;
            yield return (v3345);
        }

        try
        {
            while (v3347.MoveNext())
            {
                v3345 = v3347.Current;
                if (!(v3346.Add((v3345))))
                    continue;
                yield return (v3345);
            }
        }
        finally
        {
            v3347.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctUnionArrayDistinctDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3348;
        HashSet<int> v3349;
        int v3350;
        v3349 = new HashSet<int>();
        v3348 = (0);
        for (; v3348 < (ArrayItems.Length); v3348++)
        {
            v3350 = (ArrayItems[v3348]);
            if (!(v3349.Add((v3350))))
                continue;
            yield return (v3350);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctUnionArrayDistinctDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v3351;
        HashSet<int> v3352;
        int v3353;
        if (ArrayDistinctUnionArrayDistinctDistinctRewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3354;
        IEnumerator<int> v3355;
        HashSet<int> v3356;
        int v3357;
        v3355 = ArrayDistinctUnionArrayDistinctDistinctRewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v3352 = new HashSet<int>();
        v3354 = new HashSet<int>();
        v3356 = new HashSet<int>();
        v3351 = (0);
        for (; v3351 < (ArrayItems.Length); v3351++)
        {
            v3353 = (ArrayItems[v3351]);
            if (!(v3352.Add((v3353))))
                continue;
            if (!(v3354.Add((v3353))))
                continue;
            v3357 = (v3353);
            if (!(v3356.Add((v3357))))
                continue;
            yield return (v3357);
        }

        try
        {
            while (v3355.MoveNext())
            {
                v3353 = v3355.Current;
                if (!(v3354.Add((v3353))))
                    continue;
                v3357 = (v3353);
                if (!(v3356.Add((v3357))))
                    continue;
                yield return (v3357);
            }
        }
        finally
        {
            v3355.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctUnionArrayDistinctDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3358;
        HashSet<int> v3359;
        int v3360;
        v3359 = new HashSet<int>(EqualityComparer<int>.Default);
        v3358 = (0);
        for (; v3358 < (ArrayItems.Length); v3358++)
        {
            v3360 = (ArrayItems[v3358]);
            if (!(v3359.Add((v3360))))
                continue;
            yield return (v3360);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctUnionArrayDistinctDistinct2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v3361;
        HashSet<int> v3362;
        int v3363;
        if (ArrayDistinctUnionArrayDistinctDistinct2Rewritten_ProceduralLinq1(ArrayItems) == null)
            throw new System.InvalidOperationException("Invalid null object");
        HashSet<int> v3364;
        IEnumerator<int> v3365;
        HashSet<int> v3366;
        int v3367;
        v3365 = ArrayDistinctUnionArrayDistinctDistinct2Rewritten_ProceduralLinq1(ArrayItems).GetEnumerator();
        v3362 = new HashSet<int>(EqualityComparer<int>.Default);
        v3364 = new HashSet<int>();
        v3366 = new HashSet<int>(EqualityComparer<int>.Default);
        v3361 = (0);
        for (; v3361 < (ArrayItems.Length); v3361++)
        {
            v3363 = (ArrayItems[v3361]);
            if (!(v3362.Add((v3363))))
                continue;
            if (!(v3364.Add((v3363))))
                continue;
            v3367 = (v3363);
            if (!(v3366.Add((v3367))))
                continue;
            yield return (v3367);
        }

        try
        {
            while (v3365.MoveNext())
            {
                v3363 = v3365.Current;
                if (!(v3364.Add((v3363))))
                    continue;
                v3367 = (v3363);
                if (!(v3366.Add((v3367))))
                    continue;
                yield return (v3367);
            }
        }
        finally
        {
            v3365.Dispose();
        }

        yield break;
    }
}}