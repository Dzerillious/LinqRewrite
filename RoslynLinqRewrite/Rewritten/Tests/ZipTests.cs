using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class ZipTests
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
    [Datapoints]
    private int ZipMethod(int a, int b) => a - b;
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
        TestsExtensions.TestEquals(nameof(ArrayZipArray), ArrayZipArray, ArrayZipArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipSimpleList), ArrayZipSimpleList, ArrayZipSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipEnumerable), ArrayZipEnumerable, ArrayZipEnumerableRewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipMethod), ArrayZipMethod, ArrayZipMethodRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListZipArray), SimpleListZipArray, SimpleListZipArrayRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListZipSimpleList), SimpleListZipSimpleList, SimpleListZipSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListZipEnumerable), SimpleListZipEnumerable, SimpleListZipEnumerableRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListZipMethod), SimpleListZipMethod, SimpleListZipMethodRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableZipArray), EnumerableZipArray, EnumerableZipArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableZipSimpleList), EnumerableZipSimpleList, EnumerableZipSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableZipEnumerable), EnumerableZipEnumerable, EnumerableZipEnumerableRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableZipMethod), EnumerableZipMethod, EnumerableZipMethodRewritten);
        TestsExtensions.TestEquals(nameof(MethodZipArray), MethodZipArray, MethodZipArrayRewritten);
        TestsExtensions.TestEquals(nameof(MethodZipSimpleList), MethodZipSimpleList, MethodZipSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(MethodZipEnumerable), MethodZipEnumerable, MethodZipEnumerableRewritten);
        TestsExtensions.TestEquals(nameof(MethodZipMethod), MethodZipMethod, MethodZipMethodRewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipArrayToArray), ArrayZipArrayToArray, ArrayZipArrayToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipSimpleListToArray), ArrayZipSimpleListToArray, ArrayZipSimpleListToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipEnumerableToArray), ArrayZipEnumerableToArray, ArrayZipEnumerableToArrayRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListZipArrayToArray), SimpleListZipArrayToArray, SimpleListZipArrayToArrayRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListZipSimpleListToArray), SimpleListZipSimpleListToArray, SimpleListZipSimpleListToArrayRewritten);
        TestsExtensions.TestEquals(nameof(SimpleListZipEnumerableToArray), SimpleListZipEnumerableToArray, SimpleListZipEnumerableToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableZipArrayToArray), EnumerableZipArrayToArray, EnumerableZipArrayToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableZipSimpleListToArray), EnumerableZipSimpleListToArray, EnumerableZipSimpleListToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableZipEnumerableToArray), EnumerableZipEnumerableToArray, EnumerableZipEnumerableToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectZipArray), ArraySelectZipArray, ArraySelectZipArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectZipArraySelect), ArraySelectZipArraySelect, ArraySelectZipArraySelectRewritten);
        TestsExtensions.TestEquals(nameof(ArrayWhereZipArrayWhere), ArrayWhereZipArrayWhere, ArrayWhereZipArrayWhereRewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipArrayCount), ArrayZipArrayCount, ArrayZipArrayCountRewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipArrayCount2), ArrayZipArrayCount2, ArrayZipArrayCount2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipArraySum), ArrayZipArraySum, ArrayZipArraySumRewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipArraySum2), ArrayZipArraySum2, ArrayZipArraySum2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipArrayDistinct), ArrayZipArrayDistinct, ArrayZipArrayDistinctRewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipArrayDistinct2), ArrayZipArrayDistinct2, ArrayZipArrayDistinct2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipArrayElementAt), ArrayZipArrayElementAt, ArrayZipArrayElementAtRewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipArrayElementAtOrDefault), ArrayZipArrayElementAtOrDefault, ArrayZipArrayElementAtOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipArrayFirst), ArrayZipArrayFirst, ArrayZipArrayFirstRewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipArrayFirstOrDefault), ArrayZipArrayFirstOrDefault, ArrayZipArrayFirstOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipArrayLast), ArrayZipArrayLast, ArrayZipArrayLastRewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipArrayLastOrDefault), ArrayZipArrayLastOrDefault, ArrayZipArrayLastOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipArraySingle), ArrayZipArraySingle, ArrayZipArraySingleRewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipArraySingle2), ArrayZipArraySingle2, ArrayZipArraySingle2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipArraySingleOrDefault), ArrayZipArraySingleOrDefault, ArrayZipArraySingleOrDefaultRewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipArrayMin), ArrayZipArrayMin, ArrayZipArrayMinRewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipArrayMin2), ArrayZipArrayMin2, ArrayZipArrayMin2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipArrayMax), ArrayZipArrayMax, ArrayZipArrayMaxRewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipArrayMax2), ArrayZipArrayMax2, ArrayZipArrayMax2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipArrayLongCount), ArrayZipArrayLongCount, ArrayZipArrayLongCountRewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipArrayLongCount2), ArrayZipArrayLongCount2, ArrayZipArrayLongCount2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipArrayContains), ArrayZipArrayContains, ArrayZipArrayContainsRewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipArrayAverage), ArrayZipArrayAverage, ArrayZipArrayAverageRewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipArrayAverage2), ArrayZipArrayAverage2, ArrayZipArrayAverage2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipArrayContains2), ArrayZipArrayContains2, ArrayZipArrayContains2Rewritten);
        TestsExtensions.TestEquals(nameof(SelectWhereArrayZipSelectWhereArrayContains), SelectWhereArrayZipSelectWhereArrayContains, SelectWhereArrayZipSelectWhereArrayContainsRewritten);
        TestsExtensions.TestEquals(nameof(RangeZipArray), RangeZipArray, RangeZipArrayRewritten);
        TestsExtensions.TestEquals(nameof(RepeatZipArray), RepeatZipArray, RepeatZipArrayRewritten);
        TestsExtensions.TestEquals(nameof(EmptyZipArray), EmptyZipArray, EmptyZipArrayRewritten);
        TestsExtensions.TestEquals(nameof(RangeEmpty2Array), RangeEmpty2Array, RangeEmpty2ArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipRange), ArrayZipRange, ArrayZipRangeRewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipRepeat), ArrayZipRepeat, ArrayZipRepeatRewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipEmpty), ArrayZipEmpty, ArrayZipEmptyRewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipEmpty2), ArrayZipEmpty2, ArrayZipEmpty2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipAll), ArrayZipAll, ArrayZipAllRewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipNull), ArrayZipNull, ArrayZipNullRewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipArrayZipEnumerable), ArrayZipArrayZipEnumerable, ArrayZipArrayZipEnumerableRewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipArrayZipEnumerable2), ArrayZipArrayZipEnumerable2, ArrayZipArrayZipEnumerable2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayDistinctZipArrayDistinct), ArrayDistinctZipArrayDistinct, ArrayDistinctZipArrayDistinctRewritten);
        TestsExtensions.TestEquals(nameof(ArrayDistinctZipArrayDistinctDistinct), ArrayDistinctZipArrayDistinctDistinct, ArrayDistinctZipArrayDistinctDistinctRewritten);
        TestsExtensions.TestEquals(nameof(ArrayDistinctZipArrayDistinctDistinct2), ArrayDistinctZipArrayDistinctDistinct2, ArrayDistinctZipArrayDistinctDistinct2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayZipSelector), ArrayZipSelector, ArrayZipSelectorRewritten);
    }

    [NoRewrite]
    public IEnumerable<int> ArrayZipArray()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y));
    } //EndMethod

    public IEnumerable<int> ArrayZipArrayRewritten()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayZipSimpleList()
    {
        return ArrayItems.Zip(SimpleListItems2, ((x, y) => x + y));
    } //EndMethod

    public IEnumerable<int> ArrayZipSimpleListRewritten()
    {
        return ArrayItems.Zip(SimpleListItems2, ((x, y) => x + y));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayZipEnumerable()
    {
        return ArrayItems.Zip(EnumerableItems2, ((x, y) => x + y));
    } //EndMethod

    public IEnumerable<int> ArrayZipEnumerableRewritten()
    {
        return ArrayItems.Zip(EnumerableItems2, ((x, y) => x + y));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayZipMethod()
    {
        return ArrayItems.Zip(MethodEnumerable2(), ((x, y) => x + y));
    } //EndMethod

    public IEnumerable<int> ArrayZipMethodRewritten()
    {
        return ArrayItems.Zip(MethodEnumerable2(), ((x, y) => x + y));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListZipArray()
    {
        return SimpleListItems.Zip(ArrayItems2, ((x, y) => x + y));
    } //EndMethod

    public IEnumerable<int> SimpleListZipArrayRewritten()
    {
        return SimpleListItems.Zip(ArrayItems2, ((x, y) => x + y));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListZipSimpleList()
    {
        return SimpleListItems.Zip(SimpleListItems2, ((x, y) => x + y));
    } //EndMethod

    public IEnumerable<int> SimpleListZipSimpleListRewritten()
    {
        return SimpleListItems.Zip(SimpleListItems2, ((x, y) => x + y));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListZipEnumerable()
    {
        return SimpleListItems.Zip(EnumerableItems2, ((x, y) => x + y));
    } //EndMethod

    public IEnumerable<int> SimpleListZipEnumerableRewritten()
    {
        return SimpleListItems.Zip(EnumerableItems2, ((x, y) => x + y));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListZipMethod()
    {
        return SimpleListItems.Zip(MethodEnumerable2(), ((x, y) => x + y));
    } //EndMethod

    public IEnumerable<int> SimpleListZipMethodRewritten()
    {
        return SimpleListItems.Zip(MethodEnumerable2(), ((x, y) => x + y));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableZipArray()
    {
        return EnumerableItems.Zip(ArrayItems2, ((x, y) => x + y));
    } //EndMethod

    public IEnumerable<int> EnumerableZipArrayRewritten()
    {
        return EnumerableItems.Zip(ArrayItems2, ((x, y) => x + y));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableZipSimpleList()
    {
        return EnumerableItems.Zip(SimpleListItems2, ((x, y) => x + y));
    } //EndMethod

    public IEnumerable<int> EnumerableZipSimpleListRewritten()
    {
        return EnumerableItems.Zip(SimpleListItems2, ((x, y) => x + y));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableZipEnumerable()
    {
        return EnumerableItems.Zip(EnumerableItems2, ((x, y) => x + y));
    } //EndMethod

    public IEnumerable<int> EnumerableZipEnumerableRewritten()
    {
        return EnumerableItems.Zip(EnumerableItems2, ((x, y) => x + y));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableZipMethod()
    {
        return EnumerableItems.Zip(MethodEnumerable2(), ((x, y) => x + y));
    } //EndMethod

    public IEnumerable<int> EnumerableZipMethodRewritten()
    {
        return EnumerableItems.Zip(MethodEnumerable2(), ((x, y) => x + y));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> MethodZipArray()
    {
        return MethodEnumerable().Zip(ArrayItems2, ((x, y) => x + y));
    } //EndMethod

    public IEnumerable<int> MethodZipArrayRewritten()
    {
        return MethodEnumerable().Zip(ArrayItems2, ((x, y) => x + y));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> MethodZipSimpleList()
    {
        return MethodEnumerable().Zip(SimpleListItems2, ((x, y) => x + y));
    } //EndMethod

    public IEnumerable<int> MethodZipSimpleListRewritten()
    {
        return MethodEnumerable().Zip(SimpleListItems2, ((x, y) => x + y));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> MethodZipEnumerable()
    {
        return MethodEnumerable().Zip(EnumerableItems2, ((x, y) => x + y));
    } //EndMethod

    public IEnumerable<int> MethodZipEnumerableRewritten()
    {
        return MethodEnumerable().Zip(EnumerableItems2, ((x, y) => x + y));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> MethodZipMethod()
    {
        return MethodEnumerable().Zip(MethodEnumerable2(), ((x, y) => x + y));
    } //EndMethod

    public IEnumerable<int> MethodZipMethodRewritten()
    {
        return MethodEnumerable().Zip(MethodEnumerable2(), ((x, y) => x + y));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayZipArrayToArray()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayZipArrayToArrayRewritten()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).ToArray();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayZipSimpleListToArray()
    {
        return ArrayItems.Zip(SimpleListItems2, ((x, y) => x + y)).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayZipSimpleListToArrayRewritten()
    {
        return ArrayItems.Zip(SimpleListItems2, ((x, y) => x + y)).ToArray();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayZipEnumerableToArray()
    {
        return ArrayItems.Zip(EnumerableItems2, ((x, y) => x + y)).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayZipEnumerableToArrayRewritten()
    {
        return ArrayItems.Zip(EnumerableItems2, ((x, y) => x + y)).ToArray();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListZipArrayToArray()
    {
        return SimpleListItems.Zip(ArrayItems2, ((x, y) => x + y)).ToArray();
    } //EndMethod

    public IEnumerable<int> SimpleListZipArrayToArrayRewritten()
    {
        return SimpleListItems.Zip(ArrayItems2, ((x, y) => x + y)).ToArray();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListZipSimpleListToArray()
    {
        return SimpleListItems.Zip(SimpleListItems2, ((x, y) => x + y)).ToArray();
    } //EndMethod

    public IEnumerable<int> SimpleListZipSimpleListToArrayRewritten()
    {
        return SimpleListItems.Zip(SimpleListItems2, ((x, y) => x + y)).ToArray();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SimpleListZipEnumerableToArray()
    {
        return SimpleListItems.Zip(EnumerableItems2, ((x, y) => x + y)).ToArray();
    } //EndMethod

    public IEnumerable<int> SimpleListZipEnumerableToArrayRewritten()
    {
        return SimpleListItems.Zip(EnumerableItems2, ((x, y) => x + y)).ToArray();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableZipArrayToArray()
    {
        return EnumerableItems.Zip(ArrayItems2, ((x, y) => x + y)).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableZipArrayToArrayRewritten()
    {
        return EnumerableItems.Zip(ArrayItems2, ((x, y) => x + y)).ToArray();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableZipSimpleListToArray()
    {
        return EnumerableItems.Zip(SimpleListItems2, ((x, y) => x + y)).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableZipSimpleListToArrayRewritten()
    {
        return EnumerableItems.Zip(SimpleListItems2, ((x, y) => x + y)).ToArray();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableZipEnumerableToArray()
    {
        return EnumerableItems.Zip(EnumerableItems2, ((x, y) => x + y)).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableZipEnumerableToArrayRewritten()
    {
        return EnumerableItems.Zip(EnumerableItems2, ((x, y) => x + y)).ToArray();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectZipArray()
    {
        return ArrayItems.Select(x => x + 50).Zip(ArrayItems2, ((x, y) => x + y));
    } //EndMethod

    public IEnumerable<int> ArraySelectZipArrayRewritten()
    {
        return ArraySelectZipArrayRewritten_ProceduralLinq1(ArrayItems).Zip(ArrayItems2, ((x, y) => x + y));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectZipArraySelect()
    {
        return ArrayItems.Select(x => x + 50).Zip(ArrayItems2.Select(x => x + 50), ((x, y) => x + y));
    } //EndMethod

    public IEnumerable<int> ArraySelectZipArraySelectRewritten()
    {
        return ArraySelectZipArraySelectRewritten_ProceduralLinq1(ArrayItems).Zip(ArraySelectZipArraySelectRewritten_ProceduralLinq2(ArrayItems2), ((x, y) => x + y));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayWhereZipArrayWhere()
    {
        return ArrayItems.Where(x => x > 50).Zip(ArrayItems2.Where(x => x > 50), ((x, y) => x + y));
    } //EndMethod

    public IEnumerable<int> ArrayWhereZipArrayWhereRewritten()
    {
        return ArrayWhereZipArrayWhereRewritten_ProceduralLinq1(ArrayItems).Zip(ArrayWhereZipArrayWhereRewritten_ProceduralLinq2(ArrayItems2), ((x, y) => x + y));
    } //EndMethod

    [NoRewrite]
    public int ArrayZipArrayCount()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).Count();
    } //EndMethod

    public int ArrayZipArrayCountRewritten()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).Count();
    } //EndMethod

    [NoRewrite]
    public int ArrayZipArrayCount2()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).Count(x => x > 70);
    } //EndMethod

    public int ArrayZipArrayCount2Rewritten()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).Count(x => x > 70);
    } //EndMethod

    [NoRewrite]
    public int ArrayZipArraySum()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).Sum();
    } //EndMethod

    public int ArrayZipArraySumRewritten()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).Sum();
    } //EndMethod

    [NoRewrite]
    public int ArrayZipArraySum2()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).Sum(x => x + 10);
    } //EndMethod

    public int ArrayZipArraySum2Rewritten()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).Sum(x => x + 10);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayZipArrayDistinct()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).Distinct();
    } //EndMethod

    public IEnumerable<int> ArrayZipArrayDistinctRewritten()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).Distinct();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayZipArrayDistinct2()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).Distinct(EqualityComparer<int>.Default);
    } //EndMethod

    public IEnumerable<int> ArrayZipArrayDistinct2Rewritten()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).Distinct(EqualityComparer<int>.Default);
    } //EndMethod

    [NoRewrite]
    public int ArrayZipArrayElementAt()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).ElementAt(45);
    } //EndMethod

    public int ArrayZipArrayElementAtRewritten()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).ElementAt(45);
    } //EndMethod

    [NoRewrite]
    public int ArrayZipArrayElementAtOrDefault()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).ElementAtOrDefault(45);
    } //EndMethod

    public int ArrayZipArrayElementAtOrDefaultRewritten()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).ElementAtOrDefault(45);
    } //EndMethod

    [NoRewrite]
    public int ArrayZipArrayFirst()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).First();
    } //EndMethod

    public int ArrayZipArrayFirstRewritten()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).First();
    } //EndMethod

    [NoRewrite]
    public int ArrayZipArrayFirstOrDefault()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).FirstOrDefault();
    } //EndMethod

    public int ArrayZipArrayFirstOrDefaultRewritten()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).FirstOrDefault();
    } //EndMethod

    [NoRewrite]
    public int ArrayZipArrayLast()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).Last();
    } //EndMethod

    public int ArrayZipArrayLastRewritten()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).Last();
    } //EndMethod

    [NoRewrite]
    public int ArrayZipArrayLastOrDefault()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).LastOrDefault();
    } //EndMethod

    public int ArrayZipArrayLastOrDefaultRewritten()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).LastOrDefault();
    } //EndMethod

    [NoRewrite]
    public int ArrayZipArraySingle()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).Single();
    } //EndMethod

    public int ArrayZipArraySingleRewritten()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).Single();
    } //EndMethod

    [NoRewrite]
    public int ArrayZipArraySingle2()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).Single(x => x == 76);
    } //EndMethod

    public int ArrayZipArraySingle2Rewritten()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).Single(x => x == 76);
    } //EndMethod

    [NoRewrite]
    public int ArrayZipArraySingleOrDefault()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).SingleOrDefault();
    } //EndMethod

    public int ArrayZipArraySingleOrDefaultRewritten()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).SingleOrDefault();
    } //EndMethod

    [NoRewrite]
    public int ArrayZipArrayMin()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).Min();
    } //EndMethod

    public int ArrayZipArrayMinRewritten()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).Min();
    } //EndMethod

    [NoRewrite]
    public decimal ArrayZipArrayMin2()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).Min(x => x + 2m);
    } //EndMethod

    public decimal ArrayZipArrayMin2Rewritten()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).Min(x => x + 2m);
    } //EndMethod

    [NoRewrite]
    public int ArrayZipArrayMax()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).Max();
    } //EndMethod

    public int ArrayZipArrayMaxRewritten()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).Max();
    } //EndMethod

    [NoRewrite]
    public decimal ArrayZipArrayMax2()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).Max(x => x + 2m);
    } //EndMethod

    public decimal ArrayZipArrayMax2Rewritten()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).Max(x => x + 2m);
    } //EndMethod

    [NoRewrite]
    public long ArrayZipArrayLongCount()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).LongCount();
    } //EndMethod

    public long ArrayZipArrayLongCountRewritten()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).LongCount();
    } //EndMethod

    [NoRewrite]
    public long ArrayZipArrayLongCount2()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).LongCount(x => x > 50);
    } //EndMethod

    public long ArrayZipArrayLongCount2Rewritten()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).LongCount(x => x > 50);
    } //EndMethod

    [NoRewrite]
    public bool ArrayZipArrayContains()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).Contains(56);
    } //EndMethod

    public bool ArrayZipArrayContainsRewritten()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).Contains(56);
    } //EndMethod

    [NoRewrite]
    public double ArrayZipArrayAverage()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).Average();
    } //EndMethod

    public double ArrayZipArrayAverageRewritten()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).Average();
    } //EndMethod

    [NoRewrite]
    public double ArrayZipArrayAverage2()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).Average(x => x + 10);
    } //EndMethod

    public double ArrayZipArrayAverage2Rewritten()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).Average(x => x + 10);
    } //EndMethod

    [NoRewrite]
    public bool ArrayZipArrayContains2()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).Contains(56, EqualityComparer<int>.Default);
    } //EndMethod

    public bool ArrayZipArrayContains2Rewritten()
    {
        return ArrayItems.Zip(ArrayItems2, ((x, y) => x + y)).Contains(56, EqualityComparer<int>.Default);
    } //EndMethod

    [NoRewrite]
    public bool SelectWhereArrayZipSelectWhereArrayContains()
    {
        return ArrayItems.Select(x => x + 10).Where(x => x > 80).Zip(ArrayItems2.Select(x => x + 10).Where(x => x > 80), ((x, y) => x + y)).Contains(112);
    } //EndMethod

    public bool SelectWhereArrayZipSelectWhereArrayContainsRewritten()
    {
        return SelectWhereArrayZipSelectWhereArrayContainsRewritten_ProceduralLinq1(ArrayItems).Zip(SelectWhereArrayZipSelectWhereArrayContainsRewritten_ProceduralLinq2(ArrayItems2), ((x, y) => x + y)).Contains(112);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeZipArray()
    {
        return Enumerable.Range(20, 100).Zip(ArrayItems2, ((x, y) => x + y));
    } //EndMethod

    public IEnumerable<int> RangeZipArrayRewritten()
    {
        return RangeZipArrayRewritten_ProceduralLinq1().Zip(ArrayItems2, ((x, y) => x + y));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatZipArray()
    {
        return Enumerable.Repeat(20, 100).Zip(ArrayItems2, ((x, y) => x + y));
    } //EndMethod

    public IEnumerable<int> RepeatZipArrayRewritten()
    {
        return RepeatZipArrayRewritten_ProceduralLinq1().Zip(ArrayItems2, ((x, y) => x + y));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EmptyZipArray()
    {
        return Enumerable.Empty<int>().Zip(ArrayItems2, ((x, y) => x + y));
    } //EndMethod

    public IEnumerable<int> EmptyZipArrayRewritten()
    {
        return Enumerable.Empty<int>().Zip(ArrayItems2, ((x, y) => x + y));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeEmpty2Array()
    {
        return ArrayItems.Where(x => false).Zip(ArrayItems2, ((x, y) => x + y));
    } //EndMethod

    public IEnumerable<int> RangeEmpty2ArrayRewritten()
    {
        return RangeEmpty2ArrayRewritten_ProceduralLinq1(ArrayItems).Zip(ArrayItems2, ((x, y) => x + y));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayZipRange()
    {
        return ArrayItems.Zip(Enumerable.Range(70, 260), ((x, y) => x + y));
    } //EndMethod

    public IEnumerable<int> ArrayZipRangeRewritten()
    {
        return ArrayItems.Zip(ArrayZipRangeRewritten_ProceduralLinq1(), ((x, y) => x + y));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayZipRepeat()
    {
        return ArrayItems.Zip(Enumerable.Repeat(70, 100), ((x, y) => x + y));
    } //EndMethod

    public IEnumerable<int> ArrayZipRepeatRewritten()
    {
        return ArrayItems.Zip(ArrayZipRepeatRewritten_ProceduralLinq1(), ((x, y) => x + y));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayZipEmpty()
    {
        return ArrayItems.Zip(Enumerable.Empty<int>(), ((x, y) => x + y));
    } //EndMethod

    public IEnumerable<int> ArrayZipEmptyRewritten()
    {
        return ArrayItems.Zip(Enumerable.Empty<int>(), ((x, y) => x + y));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayZipEmpty2()
    {
        return ArrayItems.Zip(ArrayItems2.Where(x => false), ((x, y) => x + y));
    } //EndMethod

    public IEnumerable<int> ArrayZipEmpty2Rewritten()
    {
        return ArrayItems.Zip(ArrayZipEmpty2Rewritten_ProceduralLinq1(ArrayItems2), ((x, y) => x + y));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayZipAll()
    {
        return ArrayItems.Zip(Enumerable.Range(0, 1000), ((x, y) => x + y));
    } //EndMethod

    public IEnumerable<int> ArrayZipAllRewritten()
    {
        return ArrayItems.Zip(ArrayZipAllRewritten_ProceduralLinq1(), ((x, y) => x + y));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayZipNull()
    {
        return ArrayItems.Zip<int, int, int>(null, ((x, y) => x + y));
    } //EndMethod

    public IEnumerable<int> ArrayZipNullRewritten()
    {
        return ArrayZipNullRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayZipArrayZipEnumerable()
    {
        return ArrayItems.Zip(ArrayItems, ((x, y) => x + y)).Zip(EnumerableItems2, ((x, y) => x + y));
    } //EndMethod

    public IEnumerable<int> ArrayZipArrayZipEnumerableRewritten()
    {
        return ArrayItems.Zip(ArrayItems, ((x, y) => x + y)).Zip(EnumerableItems2, ((x, y) => x + y));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayZipArrayZipEnumerable2()
    {
        return ArrayItems.Zip(ArrayItems.Zip(EnumerableItems2, ((x, y) => x + y)), ((x, y) => x + y));
    } //EndMethod

    public IEnumerable<int> ArrayZipArrayZipEnumerable2Rewritten()
    {
        return ArrayItems.Zip(ArrayItems.Zip(EnumerableItems2, ((x, y) => x + y)), ((x, y) => x + y));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayDistinctZipArrayDistinct()
    {
        return ArrayItems.Distinct().Zip(ArrayItems.Distinct(), ((x, y) => x + y));
    } //EndMethod

    public IEnumerable<int> ArrayDistinctZipArrayDistinctRewritten()
    {
        return ArrayDistinctZipArrayDistinctRewritten_ProceduralLinq1(ArrayItems).Zip(ArrayDistinctZipArrayDistinctRewritten_ProceduralLinq2(ArrayItems), ((x, y) => x + y));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayDistinctZipArrayDistinctDistinct()
    {
        return ArrayItems.Distinct().Zip(ArrayItems.Distinct(), ((x, y) => x + y)).Distinct();
    } //EndMethod

    public IEnumerable<int> ArrayDistinctZipArrayDistinctDistinctRewritten()
    {
        return ArrayDistinctZipArrayDistinctDistinctRewritten_ProceduralLinq1(ArrayItems).Zip(ArrayDistinctZipArrayDistinctDistinctRewritten_ProceduralLinq2(ArrayItems), ((x, y) => x + y)).Distinct();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayDistinctZipArrayDistinctDistinct2()
    {
        return ArrayItems.Distinct(EqualityComparer<int>.Default).Zip(ArrayItems.Distinct(EqualityComparer<int>.Default), ((x, y) => x + y)).Distinct(EqualityComparer<int>.Default);
    } //EndMethod

    public IEnumerable<int> ArrayDistinctZipArrayDistinctDistinct2Rewritten()
    {
        return ArrayDistinctZipArrayDistinctDistinct2Rewritten_ProceduralLinq1(ArrayItems).Zip(ArrayDistinctZipArrayDistinctDistinct2Rewritten_ProceduralLinq2(ArrayItems), ((x, y) => x + y)).Distinct(EqualityComparer<int>.Default);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayZipSelector()
    {
        return ArrayItems.Zip(ArrayItems, ZipMethod);
    } //EndMethod

    public IEnumerable<int> ArrayZipSelectorRewritten()
    {
        return ArrayZipSelectorRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    System.Collections.Generic.IEnumerable<int> ArraySelectZipArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2965;
        v2965 = 0;
        for (; v2965 < ArrayItems.Length; v2965++)
            yield return (ArrayItems[v2965] + 50);
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectZipArraySelectRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2969;
        v2969 = 0;
        for (; v2969 < ArrayItems.Length; v2969++)
            yield return (ArrayItems[v2969] + 50);
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectZipArraySelectRewritten_ProceduralLinq2(int[] ArrayItems2)
    {
        int v2970;
        v2970 = 0;
        for (; v2970 < ArrayItems2.Length; v2970++)
            yield return (ArrayItems2[v2970] + 50);
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereZipArrayWhereRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2974;
        v2974 = 0;
        for (; v2974 < ArrayItems.Length; v2974++)
        {
            if (!((ArrayItems[v2974] > 50)))
                continue;
            yield return ArrayItems[v2974];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereZipArrayWhereRewritten_ProceduralLinq2(int[] ArrayItems2)
    {
        int v2975;
        v2975 = 0;
        for (; v2975 < ArrayItems2.Length; v2975++)
        {
            if (!((ArrayItems2[v2975] > 50)))
                continue;
            yield return ArrayItems2[v2975];
        }
    }

    System.Collections.Generic.IEnumerable<int> SelectWhereArrayZipSelectWhereArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3086;
        int v3087;
        v3086 = 0;
        for (; v3086 < ArrayItems.Length; v3086++)
        {
            v3087 = (ArrayItems[v3086] + 10);
            if (!((v3087 > 80)))
                continue;
            yield return v3087;
        }
    }

    System.Collections.Generic.IEnumerable<int> SelectWhereArrayZipSelectWhereArrayContainsRewritten_ProceduralLinq2(int[] ArrayItems2)
    {
        int v3088;
        int v3089;
        v3088 = 0;
        for (; v3088 < ArrayItems2.Length; v3088++)
        {
            v3089 = (ArrayItems2[v3088] + 10);
            if (!((v3089 > 80)))
                continue;
            yield return v3089;
        }
    }

    System.Collections.Generic.IEnumerable<int> RangeZipArrayRewritten_ProceduralLinq1()
    {
        int v3092;
        v3092 = 0;
        for (; v3092 < 100; v3092++)
            yield return (v3092 + 20);
    }

    System.Collections.Generic.IEnumerable<int> RepeatZipArrayRewritten_ProceduralLinq1()
    {
        int v3095;
        v3095 = 0;
        for (; v3095 < 100; v3095++)
            yield return 20;
    }

    System.Collections.Generic.IEnumerable<int> RangeEmpty2ArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3100;
        v3100 = 0;
        for (; v3100 < ArrayItems.Length; v3100++)
        {
            if (!((false)))
                continue;
            yield return ArrayItems[v3100];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayZipRangeRewritten_ProceduralLinq1()
    {
        int v3104;
        v3104 = 0;
        for (; v3104 < 260; v3104++)
            yield return (v3104 + 70);
    }

    System.Collections.Generic.IEnumerable<int> ArrayZipRepeatRewritten_ProceduralLinq1()
    {
        int v3108;
        v3108 = 0;
        for (; v3108 < 100; v3108++)
            yield return 70;
    }

    System.Collections.Generic.IEnumerable<int> ArrayZipEmpty2Rewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v3114;
        v3114 = 0;
        for (; v3114 < ArrayItems2.Length; v3114++)
        {
            if (!((false)))
                continue;
            yield return ArrayItems2[v3114];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayZipAllRewritten_ProceduralLinq1()
    {
        int v3118;
        v3118 = 0;
        for (; v3118 < 1000; v3118++)
            yield return (v3118 + 0);
    }

    System.Collections.Generic.IEnumerable<int> ArrayZipNullRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3119;
        throw new System.InvalidOperationException("Invalid null object");
        v3119 = 0;
        for (; v3119 < ArrayItems.Length; v3119++)
            yield return ArrayItems[v3119];
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctZipArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3135;
        HashSet<int> v3136;
        v3136 = new HashSet<int>();
        v3135 = 0;
        for (; v3135 < ArrayItems.Length; v3135++)
        {
            if (!(v3136.Add(ArrayItems[v3135])))
                continue;
            yield return ArrayItems[v3135];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctZipArrayDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v3137;
        HashSet<int> v3138;
        v3138 = new HashSet<int>();
        v3137 = 0;
        for (; v3137 < ArrayItems.Length; v3137++)
        {
            if (!(v3138.Add(ArrayItems[v3137])))
                continue;
            yield return ArrayItems[v3137];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctZipArrayDistinctDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3149;
        HashSet<int> v3150;
        v3150 = new HashSet<int>();
        v3149 = 0;
        for (; v3149 < ArrayItems.Length; v3149++)
        {
            if (!(v3150.Add(ArrayItems[v3149])))
                continue;
            yield return ArrayItems[v3149];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctZipArrayDistinctDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v3151;
        HashSet<int> v3152;
        v3152 = new HashSet<int>();
        v3151 = 0;
        for (; v3151 < ArrayItems.Length; v3151++)
        {
            if (!(v3152.Add(ArrayItems[v3151])))
                continue;
            yield return ArrayItems[v3151];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctZipArrayDistinctDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3163;
        HashSet<int> v3164;
        v3164 = new HashSet<int>(EqualityComparer<int>.Default);
        v3163 = 0;
        for (; v3163 < ArrayItems.Length; v3163++)
        {
            if (!(v3164.Add(ArrayItems[v3163])))
                continue;
            yield return ArrayItems[v3163];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctZipArrayDistinctDistinct2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v3165;
        HashSet<int> v3166;
        v3166 = new HashSet<int>(EqualityComparer<int>.Default);
        v3165 = 0;
        for (; v3165 < ArrayItems.Length; v3165++)
        {
            if (!(v3166.Add(ArrayItems[v3165])))
                continue;
            yield return ArrayItems[v3165];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayZipSelectorRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3167;
        if (ArrayItems == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v3168;
        v3168 = ((IEnumerable<int>)ArrayItems).GetEnumerator();
        try
        {
            v3167 = 0;
            for (; v3167 < ArrayItems.Length; v3167++)
            {
                if (!(v3168.MoveNext()))
                    throw new System.InvalidOperationException("Invalid sizes of sources");
                yield return ZipMethod(ArrayItems[v3167], v3168.Current);
            }
        }
        finally
        {
            v3168.Dispose();
        }

        if (v3168.MoveNext())
            throw new System.InvalidOperationException("Invalid sizes of sources");
    }
}}