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
        int v3210;
        v3210 = (0);
        for (; v3210 < (ArrayItems.Length); v3210 += 1)
            yield return (50 + ArrayItems[v3210]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectZipArraySelectRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3216;
        v3216 = (0);
        for (; v3216 < (ArrayItems.Length); v3216 += 1)
            yield return (50 + ArrayItems[v3216]);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectZipArraySelectRewritten_ProceduralLinq2(int[] ArrayItems2)
    {
        int v3218;
        v3218 = (0);
        for (; v3218 < (ArrayItems2.Length); v3218 += 1)
            yield return (((ArrayItems2[v3218]) + 50));
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereZipArrayWhereRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3222;
        v3222 = (0);
        for (; v3222 < (ArrayItems.Length); v3222 += 1)
        {
            if (!((((ArrayItems[v3222])) > 50)))
                continue;
            yield return ((ArrayItems[v3222]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereZipArrayWhereRewritten_ProceduralLinq2(int[] ArrayItems2)
    {
        int v3223;
        v3223 = (0);
        for (; v3223 < (ArrayItems2.Length); v3223 += 1)
        {
            if (!((((ArrayItems2[v3223])) > 50)))
                continue;
            yield return ((ArrayItems2[v3223]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SelectWhereArrayZipSelectWhereArrayContainsRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3334;
        int v3335;
        v3334 = (0);
        for (; v3334 < (ArrayItems.Length); v3334 += 1)
        {
            v3335 = (10 + ArrayItems[v3334]);
            if (!(((v3335) > 80)))
                continue;
            yield return (v3335);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> SelectWhereArrayZipSelectWhereArrayContainsRewritten_ProceduralLinq2(int[] ArrayItems2)
    {
        int v3336;
        int v3337;
        v3336 = (0);
        for (; v3336 < (ArrayItems2.Length); v3336 += 1)
        {
            v3337 = (((ArrayItems2[v3336]) + 10));
            if (!(((v3337) > 80)))
                continue;
            yield return (v3337);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeZipArrayRewritten_ProceduralLinq1()
    {
        int v3340;
        v3340 = (0);
        for (; v3340 < (100); v3340 += (1))
            yield return (20 + v3340);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RepeatZipArrayRewritten_ProceduralLinq1()
    {
        int v3343;
        v3343 = (0);
        for (; v3343 < (100); v3343 += 1)
            yield return (20);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeEmpty2ArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3348;
        v3348 = (0);
        for (; v3348 < (ArrayItems.Length); v3348 += 1)
        {
            if (!((false)))
                continue;
            yield return ((ArrayItems[v3348]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayZipRangeRewritten_ProceduralLinq1()
    {
        int v3352;
        v3352 = (0);
        for (; v3352 < (260); v3352 += (1))
            yield return (70 + v3352);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayZipRepeatRewritten_ProceduralLinq1()
    {
        int v3356;
        v3356 = (0);
        for (; v3356 < (100); v3356 += 1)
            yield return (70);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayZipEmpty2Rewritten_ProceduralLinq1(int[] ArrayItems2)
    {
        int v3362;
        v3362 = (0);
        for (; v3362 < (ArrayItems2.Length); v3362 += 1)
        {
            if (!((false)))
                continue;
            yield return ((ArrayItems2[v3362]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayZipAllRewritten_ProceduralLinq1()
    {
        int v3366;
        v3366 = (0);
        for (; v3366 < (1000); v3366 += (1))
            yield return (v3366);
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayZipNullRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3367;
        throw new System.InvalidOperationException("Invalid null object");
        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctZipArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3383;
        HashSet<int> v3384;
        v3384 = new HashSet<int>();
        v3383 = (0);
        for (; v3383 < (ArrayItems.Length); v3383 += 1)
        {
            if (!(v3384.Add(((ArrayItems[v3383])))))
                continue;
            yield return ((ArrayItems[v3383]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctZipArrayDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v3385;
        HashSet<int> v3386;
        v3386 = new HashSet<int>();
        v3385 = (0);
        for (; v3385 < (ArrayItems.Length); v3385 += 1)
        {
            if (!(v3386.Add(((ArrayItems[v3385])))))
                continue;
            yield return ((ArrayItems[v3385]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctZipArrayDistinctDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3397;
        HashSet<int> v3398;
        v3398 = new HashSet<int>();
        v3397 = (0);
        for (; v3397 < (ArrayItems.Length); v3397 += 1)
        {
            if (!(v3398.Add(((ArrayItems[v3397])))))
                continue;
            yield return ((ArrayItems[v3397]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctZipArrayDistinctDistinctRewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v3399;
        HashSet<int> v3400;
        v3400 = new HashSet<int>();
        v3399 = (0);
        for (; v3399 < (ArrayItems.Length); v3399 += 1)
        {
            if (!(v3400.Add(((ArrayItems[v3399])))))
                continue;
            yield return ((ArrayItems[v3399]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctZipArrayDistinctDistinct2Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3411;
        HashSet<int> v3412;
        v3412 = new HashSet<int>(EqualityComparer<int>.Default);
        v3411 = (0);
        for (; v3411 < (ArrayItems.Length); v3411 += 1)
        {
            if (!(v3412.Add(((ArrayItems[v3411])))))
                continue;
            yield return ((ArrayItems[v3411]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayDistinctZipArrayDistinctDistinct2Rewritten_ProceduralLinq2(int[] ArrayItems)
    {
        int v3413;
        HashSet<int> v3414;
        v3414 = new HashSet<int>(EqualityComparer<int>.Default);
        v3413 = (0);
        for (; v3413 < (ArrayItems.Length); v3413 += 1)
        {
            if (!(v3414.Add(((ArrayItems[v3413])))))
                continue;
            yield return ((ArrayItems[v3413]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayZipSelectorRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v3415;
        if (ArrayItems == null)
            throw new System.InvalidOperationException("Invalid null object");
        IEnumerator<int> v3416;
        v3416 = ((IEnumerable<int>)ArrayItems).GetEnumerator();
        try
        {
            v3415 = (0);
            for (; v3415 < (ArrayItems.Length); v3415 += 1)
            {
                if (!(v3416.MoveNext()))
                    throw new System.InvalidOperationException("Invalid sizes of sources");
                yield return (ZipMethod((ArrayItems[v3415]), v3416.Current));
            }
        }
        finally
        {
            v3416.Dispose();
        }

        if (v3416.MoveNext())
            throw new System.InvalidOperationException("Invalid sizes of sources");
        yield break;
    }
}}