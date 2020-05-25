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
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArrayZipArrayRewritten()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayZipSimpleList()
        {
            return ArrayItems.Zip(SimpleListItems2, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArrayZipSimpleListRewritten()
        {
            return ArrayItems.Zip(SimpleListItems2, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayZipEnumerable()
        {
            return ArrayItems.Zip(EnumerableItems2, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArrayZipEnumerableRewritten()
        {
            return ArrayItems.Zip(EnumerableItems2, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayZipMethod()
        {
            return ArrayItems.Zip(MethodEnumerable2(), (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArrayZipMethodRewritten()
        {
            return ArrayItems.Zip(MethodEnumerable2(), (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListZipArray()
        {
            return SimpleListItems.Zip(ArrayItems2, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> SimpleListZipArrayRewritten()
        {
            return SimpleListItems.Zip(ArrayItems2, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListZipSimpleList()
        {
            return SimpleListItems.Zip(SimpleListItems2, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> SimpleListZipSimpleListRewritten()
        {
            return SimpleListItems.Zip(SimpleListItems2, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListZipEnumerable()
        {
            return SimpleListItems.Zip(EnumerableItems2, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> SimpleListZipEnumerableRewritten()
        {
            return SimpleListItems.Zip(EnumerableItems2, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListZipMethod()
        {
            return SimpleListItems.Zip(MethodEnumerable2(), (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> SimpleListZipMethodRewritten()
        {
            return SimpleListItems.Zip(MethodEnumerable2(), (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableZipArray()
        {
            return EnumerableItems.Zip(ArrayItems2, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> EnumerableZipArrayRewritten()
        {
            return EnumerableItems.Zip(ArrayItems2, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableZipSimpleList()
        {
            return EnumerableItems.Zip(SimpleListItems2, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> EnumerableZipSimpleListRewritten()
        {
            return EnumerableItems.Zip(SimpleListItems2, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableZipEnumerable()
        {
            return EnumerableItems.Zip(EnumerableItems2, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> EnumerableZipEnumerableRewritten()
        {
            return EnumerableItems.Zip(EnumerableItems2, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableZipMethod()
        {
            return EnumerableItems.Zip(MethodEnumerable2(), (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> EnumerableZipMethodRewritten()
        {
            return EnumerableItems.Zip(MethodEnumerable2(), (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> MethodZipArray()
        {
            return MethodEnumerable().Zip(ArrayItems2, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> MethodZipArrayRewritten()
        {
            return MethodEnumerable().Zip(ArrayItems2, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> MethodZipSimpleList()
        {
            return MethodEnumerable().Zip(SimpleListItems2, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> MethodZipSimpleListRewritten()
        {
            return MethodEnumerable().Zip(SimpleListItems2, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> MethodZipEnumerable()
        {
            return MethodEnumerable().Zip(EnumerableItems2, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> MethodZipEnumerableRewritten()
        {
            return MethodEnumerable().Zip(EnumerableItems2, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> MethodZipMethod()
        {
            return MethodEnumerable().Zip(MethodEnumerable2(), (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> MethodZipMethodRewritten()
        {
            return MethodEnumerable().Zip(MethodEnumerable2(), (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayZipArrayToArray()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).ToArray();
        } //EndMethod

        public IEnumerable<int> ArrayZipArrayToArrayRewritten()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayZipSimpleListToArray()
        {
            return ArrayItems.Zip(SimpleListItems2, (x, y) => x + y).ToArray();
        } //EndMethod

        public IEnumerable<int> ArrayZipSimpleListToArrayRewritten()
        {
            return ArrayItems.Zip(SimpleListItems2, (x, y) => x + y).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayZipEnumerableToArray()
        {
            return ArrayItems.Zip(EnumerableItems2, (x, y) => x + y).ToArray();
        } //EndMethod

        public IEnumerable<int> ArrayZipEnumerableToArrayRewritten()
        {
            return ArrayItems.Zip(EnumerableItems2, (x, y) => x + y).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListZipArrayToArray()
        {
            return SimpleListItems.Zip(ArrayItems2, (x, y) => x + y).ToArray();
        } //EndMethod

        public IEnumerable<int> SimpleListZipArrayToArrayRewritten()
        {
            return SimpleListItems.Zip(ArrayItems2, (x, y) => x + y).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListZipSimpleListToArray()
        {
            return SimpleListItems.Zip(SimpleListItems2, (x, y) => x + y).ToArray();
        } //EndMethod

        public IEnumerable<int> SimpleListZipSimpleListToArrayRewritten()
        {
            return SimpleListItems.Zip(SimpleListItems2, (x, y) => x + y).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListZipEnumerableToArray()
        {
            return SimpleListItems.Zip(EnumerableItems2, (x, y) => x + y).ToArray();
        } //EndMethod

        public IEnumerable<int> SimpleListZipEnumerableToArrayRewritten()
        {
            return SimpleListItems.Zip(EnumerableItems2, (x, y) => x + y).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableZipArrayToArray()
        {
            return EnumerableItems.Zip(ArrayItems2, (x, y) => x + y).ToArray();
        } //EndMethod

        public IEnumerable<int> EnumerableZipArrayToArrayRewritten()
        {
            return EnumerableItems.Zip(ArrayItems2, (x, y) => x + y).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableZipSimpleListToArray()
        {
            return EnumerableItems.Zip(SimpleListItems2, (x, y) => x + y).ToArray();
        } //EndMethod

        public IEnumerable<int> EnumerableZipSimpleListToArrayRewritten()
        {
            return EnumerableItems.Zip(SimpleListItems2, (x, y) => x + y).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableZipEnumerableToArray()
        {
            return EnumerableItems.Zip(EnumerableItems2, (x, y) => x + y).ToArray();
        } //EndMethod

        public IEnumerable<int> EnumerableZipEnumerableToArrayRewritten()
        {
            return EnumerableItems.Zip(EnumerableItems2, (x, y) => x + y).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArraySelectZipArray()
        {
            return ArrayItems.Select(x => x + 50).Zip(ArrayItems2, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArraySelectZipArrayRewritten()
        {
            return ArrayItems.Select(x => x + 50).Zip(ArrayItems2, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArraySelectZipArraySelect()
        {
            return ArrayItems.Select(x => x + 50).Zip(ArrayItems2.Select(x => x + 50), (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArraySelectZipArraySelectRewritten()
        {
            return ArrayItems.Select(x => x + 50).Zip(ArrayItems2.Select(x => x + 50), (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayWhereZipArrayWhere()
        {
            return ArrayItems.Where(x => x > 50).Zip(ArrayItems2.Where(x => x > 50), (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArrayWhereZipArrayWhereRewritten()
        {
            return ArrayItems.Where(x => x > 50).Zip(ArrayItems2.Where(x => x > 50), (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public int ArrayZipArrayCount()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).Count();
        } //EndMethod

        public int ArrayZipArrayCountRewritten()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).Count();
        } //EndMethod


        [NoRewrite]
        public int ArrayZipArrayCount2()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).Count(x => x > 70);
        } //EndMethod

        public int ArrayZipArrayCount2Rewritten()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).Count(x => x > 70);
        } //EndMethod


        [NoRewrite]
        public int ArrayZipArraySum()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).Sum();
        } //EndMethod

        public int ArrayZipArraySumRewritten()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).Sum();
        } //EndMethod


        [NoRewrite]
        public int ArrayZipArraySum2()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).Sum(x => x + 10);
        } //EndMethod

        public int ArrayZipArraySum2Rewritten()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).Sum(x => x + 10);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayZipArrayDistinct()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).Distinct();
        } //EndMethod

        public IEnumerable<int> ArrayZipArrayDistinctRewritten()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).Distinct();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayZipArrayDistinct2()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).Distinct(EqualityComparer<int>.Default);
        } //EndMethod

        public IEnumerable<int> ArrayZipArrayDistinct2Rewritten()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).Distinct(EqualityComparer<int>.Default);
        } //EndMethod


        [NoRewrite]
        public int ArrayZipArrayElementAt()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).ElementAt(45);
        } //EndMethod

        public int ArrayZipArrayElementAtRewritten()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).ElementAt(45);
        } //EndMethod


        [NoRewrite]
        public int ArrayZipArrayElementAtOrDefault()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).ElementAtOrDefault(45);
        } //EndMethod

        public int ArrayZipArrayElementAtOrDefaultRewritten()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).ElementAtOrDefault(45);
        } //EndMethod


        [NoRewrite]
        public int ArrayZipArrayFirst()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).First();
        } //EndMethod

        public int ArrayZipArrayFirstRewritten()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).First();
        } //EndMethod


        [NoRewrite]
        public int ArrayZipArrayFirstOrDefault()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).FirstOrDefault();
        } //EndMethod

        public int ArrayZipArrayFirstOrDefaultRewritten()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).FirstOrDefault();
        } //EndMethod


        [NoRewrite]
        public int ArrayZipArrayLast()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).Last();
        } //EndMethod

        public int ArrayZipArrayLastRewritten()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).Last();
        } //EndMethod


        [NoRewrite]
        public int ArrayZipArrayLastOrDefault()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).LastOrDefault();
        } //EndMethod

        public int ArrayZipArrayLastOrDefaultRewritten()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).LastOrDefault();
        } //EndMethod


        [NoRewrite]
        public int ArrayZipArraySingle()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).Single();
        } //EndMethod

        public int ArrayZipArraySingleRewritten()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).Single();
        } //EndMethod


        [NoRewrite]
        public int ArrayZipArraySingle2()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).Single(x => x == 76);
        } //EndMethod

        public int ArrayZipArraySingle2Rewritten()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).Single(x => x == 76);
        } //EndMethod


        [NoRewrite]
        public int ArrayZipArraySingleOrDefault()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).SingleOrDefault();
        } //EndMethod

        public int ArrayZipArraySingleOrDefaultRewritten()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).SingleOrDefault();
        } //EndMethod


        [NoRewrite]
        public int ArrayZipArrayMin()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).Min();
        } //EndMethod

        public int ArrayZipArrayMinRewritten()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).Min();
        } //EndMethod


        [NoRewrite]
        public decimal ArrayZipArrayMin2()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).Min(x => x + 2m);
        } //EndMethod

        public decimal ArrayZipArrayMin2Rewritten()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).Min(x => x + 2m);
        } //EndMethod


        [NoRewrite]
        public int ArrayZipArrayMax()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).Max();
        } //EndMethod

        public int ArrayZipArrayMaxRewritten()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).Max();
        } //EndMethod


        [NoRewrite]
        public decimal ArrayZipArrayMax2()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).Max(x => x + 2m);
        } //EndMethod

        public decimal ArrayZipArrayMax2Rewritten()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).Max(x => x + 2m);
        } //EndMethod


        [NoRewrite]
        public long ArrayZipArrayLongCount()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).LongCount();
        } //EndMethod

        public long ArrayZipArrayLongCountRewritten()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).LongCount();
        } //EndMethod


        [NoRewrite]
        public long ArrayZipArrayLongCount2()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).LongCount(x => x > 50);
        } //EndMethod

        public long ArrayZipArrayLongCount2Rewritten()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).LongCount(x => x > 50);
        } //EndMethod


        [NoRewrite]
        public bool ArrayZipArrayContains()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).Contains(56);
        } //EndMethod

        public bool ArrayZipArrayContainsRewritten()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).Contains(56);
        } //EndMethod


        [NoRewrite]
        public double ArrayZipArrayAverage()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).Average();
        } //EndMethod

        public double ArrayZipArrayAverageRewritten()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).Average();
        } //EndMethod


        [NoRewrite]
        public double ArrayZipArrayAverage2()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).Average(x => x + 10);
        } //EndMethod

        public double ArrayZipArrayAverage2Rewritten()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).Average(x => x + 10);
        } //EndMethod


        [NoRewrite]
        public bool ArrayZipArrayContains2()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).Contains(56, EqualityComparer<int>.Default);
        } //EndMethod

        public bool ArrayZipArrayContains2Rewritten()
        {
            return ArrayItems.Zip(ArrayItems2, (x, y) => x + y).Contains(56, EqualityComparer<int>.Default);
        } //EndMethod


        [NoRewrite]
        public bool SelectWhereArrayZipSelectWhereArrayContains()
        {
            return ArrayItems.Select(x => x + 10).Where(x => x > 80).Zip(ArrayItems2.Select(x => x + 10).Where(x => x > 80), (x, y) => x + y).Contains(112);
        } //EndMethod

        public bool SelectWhereArrayZipSelectWhereArrayContainsRewritten()
        {
            return ArrayItems.Select(x => x + 10).Where(x => x > 80).Zip(ArrayItems2.Select(x => x + 10).Where(x => x > 80), (x, y) => x + y).Contains(112);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RangeZipArray()
        {
            return Enumerable.Range(20, 100).Zip(ArrayItems2, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> RangeZipArrayRewritten()
        {
            return Enumerable.Range(20, 100).Zip(ArrayItems2, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RepeatZipArray()
        {
            return Enumerable.Repeat(20, 100).Zip(ArrayItems2, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> RepeatZipArrayRewritten()
        {
            return Enumerable.Repeat(20, 100).Zip(ArrayItems2, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EmptyZipArray()
        {
            return Enumerable.Empty<int>().Zip(ArrayItems2, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> EmptyZipArrayRewritten()
        {
            return Enumerable.Empty<int>().Zip(ArrayItems2, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RangeEmpty2Array()
        {
            return ArrayItems.Where(x => false).Zip(ArrayItems2, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> RangeEmpty2ArrayRewritten()
        {
            return ArrayItems.Where(x => false).Zip(ArrayItems2, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayZipRange()
        {
            return ArrayItems.Zip(Enumerable.Range(70, 260), (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArrayZipRangeRewritten()
        {
            return ArrayItems.Zip(Enumerable.Range(70, 260), (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayZipRepeat()
        {
            return ArrayItems.Zip(Enumerable.Repeat(70, 100), (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArrayZipRepeatRewritten()
        {
            return ArrayItems.Zip(Enumerable.Repeat(70, 100), (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayZipEmpty()
        {
            return ArrayItems.Zip(Enumerable.Empty<int>(), (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArrayZipEmptyRewritten()
        {
            return ArrayItems.Zip(Enumerable.Empty<int>(), (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayZipEmpty2()
        {
            return ArrayItems.Zip(ArrayItems2.Where(x => false), (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArrayZipEmpty2Rewritten()
        {
            return ArrayItems.Zip(ArrayItems2.Where(x => false), (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayZipAll()
        {
            return ArrayItems.Zip(Enumerable.Range(0, 1000), (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArrayZipAllRewritten()
        {
            return ArrayItems.Zip(Enumerable.Range(0, 1000), (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayZipNull()
        {
            return ArrayItems.Zip<int, int, int>(null, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArrayZipNullRewritten()
        {
            return ArrayItems.Zip<int, int, int>(null, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayZipArrayZipEnumerable()
        {
            return ArrayItems.Zip(ArrayItems, (x, y) => x + y).Zip(EnumerableItems2, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArrayZipArrayZipEnumerableRewritten()
        {
            return ArrayItems.Zip(ArrayItems, (x, y) => x + y).Zip(EnumerableItems2, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayZipArrayZipEnumerable2()
        {
            return ArrayItems.Zip(ArrayItems.Zip(EnumerableItems2, (x, y) => x + y), (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArrayZipArrayZipEnumerable2Rewritten()
        {
            return ArrayItems.Zip(ArrayItems.Zip(EnumerableItems2, (x, y) => x + y), (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayDistinctZipArrayDistinct()
        {
            return ArrayItems.Distinct().Zip(ArrayItems.Distinct(), (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArrayDistinctZipArrayDistinctRewritten()
        {
            return ArrayItems.Distinct().Zip(ArrayItems.Distinct(), (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayDistinctZipArrayDistinctDistinct()
        {
            return ArrayItems.Distinct().Zip(ArrayItems.Distinct(), (x, y) => x + y).Distinct();
        } //EndMethod

        public IEnumerable<int> ArrayDistinctZipArrayDistinctDistinctRewritten()
        {
            return ArrayItems.Distinct().Zip(ArrayItems.Distinct(), (x, y) => x + y).Distinct();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayDistinctZipArrayDistinctDistinct2()
        {
            return ArrayItems.Distinct(EqualityComparer<int>.Default).Zip(ArrayItems.Distinct(EqualityComparer<int>.Default), (x, y) => x + y).Distinct(EqualityComparer<int>.Default);
        } //EndMethod

        public IEnumerable<int> ArrayDistinctZipArrayDistinctDistinct2Rewritten()
        {
            return ArrayItems.Distinct(EqualityComparer<int>.Default).Zip(ArrayItems.Distinct(EqualityComparer<int>.Default), (x, y) => x + y).Distinct(EqualityComparer<int>.Default);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayZipSelector()
        {
            return ArrayItems.Zip(ArrayItems, ZipMethod);
        } //EndMethod

        public IEnumerable<int> ArrayZipSelectorRewritten()
        {
            return ArrayItems.Zip(ArrayItems, ZipMethod);
        } //EndMethod

    }
}