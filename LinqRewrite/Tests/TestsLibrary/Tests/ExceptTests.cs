using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class ExceptTests
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
            TestsExtensions.TestEquals(nameof(ArrayExceptArray), ArrayExceptArray, ArrayExceptArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptSimpleList), ArrayExceptSimpleList, ArrayExceptSimpleListRewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptEnumerable), ArrayExceptEnumerable, ArrayExceptEnumerableRewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptMethod), ArrayExceptMethod, ArrayExceptMethodRewritten);
            TestsExtensions.TestEquals(nameof(SimpleListExceptArray), SimpleListExceptArray, SimpleListExceptArrayRewritten);
            TestsExtensions.TestEquals(nameof(SimpleListExceptSimpleList), SimpleListExceptSimpleList, SimpleListExceptSimpleListRewritten);
            TestsExtensions.TestEquals(nameof(SimpleListExceptEnumerable), SimpleListExceptEnumerable, SimpleListExceptEnumerableRewritten);
            TestsExtensions.TestEquals(nameof(SimpleListExceptMethod), SimpleListExceptMethod, SimpleListExceptMethodRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableExceptArray), EnumerableExceptArray, EnumerableExceptArrayRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableExceptSimpleList), EnumerableExceptSimpleList, EnumerableExceptSimpleListRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableExceptEnumerable), EnumerableExceptEnumerable, EnumerableExceptEnumerableRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableExceptMethod), EnumerableExceptMethod, EnumerableExceptMethodRewritten);
            TestsExtensions.TestEquals(nameof(MethodExceptArray), MethodExceptArray, MethodExceptArrayRewritten);
            TestsExtensions.TestEquals(nameof(MethodExceptSimpleList), MethodExceptSimpleList, MethodExceptSimpleListRewritten);
            TestsExtensions.TestEquals(nameof(MethodExceptEnumerable), MethodExceptEnumerable, MethodExceptEnumerableRewritten);
            TestsExtensions.TestEquals(nameof(MethodExceptMethod), MethodExceptMethod, MethodExceptMethodRewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptArrayToArray), ArrayExceptArrayToArray, ArrayExceptArrayToArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptSimpleListToArray), ArrayExceptSimpleListToArray, ArrayExceptSimpleListToArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptEnumerableToArray), ArrayExceptEnumerableToArray, ArrayExceptEnumerableToArrayRewritten);
            TestsExtensions.TestEquals(nameof(SimpleListExceptArrayToArray), SimpleListExceptArrayToArray, SimpleListExceptArrayToArrayRewritten);
            TestsExtensions.TestEquals(nameof(SimpleListExceptSimpleListToArray), SimpleListExceptSimpleListToArray, SimpleListExceptSimpleListToArrayRewritten);
            TestsExtensions.TestEquals(nameof(SimpleListExceptEnumerableToArray), SimpleListExceptEnumerableToArray, SimpleListExceptEnumerableToArrayRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableExceptArrayToArray), EnumerableExceptArrayToArray, EnumerableExceptArrayToArrayRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableExceptSimpleListToArray), EnumerableExceptSimpleListToArray, EnumerableExceptSimpleListToArrayRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableExceptEnumerableToArray), EnumerableExceptEnumerableToArray, EnumerableExceptEnumerableToArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArraySelectExceptArray), ArraySelectExceptArray, ArraySelectExceptArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArraySelectExceptArraySelect), ArraySelectExceptArraySelect, ArraySelectExceptArraySelectRewritten);
            TestsExtensions.TestEquals(nameof(ArrayWhereExceptArrayWhere), ArrayWhereExceptArrayWhere, ArrayWhereExceptArrayWhereRewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptArrayCount), ArrayExceptArrayCount, ArrayExceptArrayCountRewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptArrayCount2), ArrayExceptArrayCount2, ArrayExceptArrayCount2Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptArraySum), ArrayExceptArraySum, ArrayExceptArraySumRewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptArraySum2), ArrayExceptArraySum2, ArrayExceptArraySum2Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptArrayDistinct), ArrayExceptArrayDistinct, ArrayExceptArrayDistinctRewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptArrayDistinct2), ArrayExceptArrayDistinct2, ArrayExceptArrayDistinct2Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptArrayElementAt), ArrayExceptArrayElementAt, ArrayExceptArrayElementAtRewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptArrayElementAtOrDefault), ArrayExceptArrayElementAtOrDefault, ArrayExceptArrayElementAtOrDefaultRewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptArrayFirst), ArrayExceptArrayFirst, ArrayExceptArrayFirstRewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptArrayFirstOrDefault), ArrayExceptArrayFirstOrDefault, ArrayExceptArrayFirstOrDefaultRewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptArrayLast), ArrayExceptArrayLast, ArrayExceptArrayLastRewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptArrayLastOrDefault), ArrayExceptArrayLastOrDefault, ArrayExceptArrayLastOrDefaultRewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptArraySingle), ArrayExceptArraySingle, ArrayExceptArraySingleRewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptArraySingle2), ArrayExceptArraySingle2, ArrayExceptArraySingle2Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptArraySingleOrDefault), ArrayExceptArraySingleOrDefault, ArrayExceptArraySingleOrDefaultRewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptArrayMin), ArrayExceptArrayMin, ArrayExceptArrayMinRewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptArrayMin2), ArrayExceptArrayMin2, ArrayExceptArrayMin2Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptArrayMax), ArrayExceptArrayMax, ArrayExceptArrayMaxRewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptArrayMax2), ArrayExceptArrayMax2, ArrayExceptArrayMax2Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptArrayLongCount), ArrayExceptArrayLongCount, ArrayExceptArrayLongCountRewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptArrayLongCount2), ArrayExceptArrayLongCount2, ArrayExceptArrayLongCount2Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptArrayContains), ArrayExceptArrayContains, ArrayExceptArrayContainsRewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptArrayAverage), ArrayExceptArrayAverage, ArrayExceptArrayAverageRewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptArrayAverage2), ArrayExceptArrayAverage2, ArrayExceptArrayAverage2Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptArrayContains2), ArrayExceptArrayContains2, ArrayExceptArrayContains2Rewritten);
            TestsExtensions.TestEquals(nameof(SelectWhereArrayExceptSelectWhereArrayContains), SelectWhereArrayExceptSelectWhereArrayContains, SelectWhereArrayExceptSelectWhereArrayContainsRewritten);
            TestsExtensions.TestEquals(nameof(RangeExceptArray), RangeExceptArray, RangeExceptArrayRewritten);
            TestsExtensions.TestEquals(nameof(RepeatExceptArray), RepeatExceptArray, RepeatExceptArrayRewritten);
            TestsExtensions.TestEquals(nameof(EmptyExceptArray), EmptyExceptArray, EmptyExceptArrayRewritten);
            TestsExtensions.TestEquals(nameof(RangeEmpty2Array), RangeEmpty2Array, RangeEmpty2ArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptRange), ArrayExceptRange, ArrayExceptRangeRewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptRepeat), ArrayExceptRepeat, ArrayExceptRepeatRewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptEmpty), ArrayExceptEmpty, ArrayExceptEmptyRewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptEmpty2), ArrayExceptEmpty2, ArrayExceptEmpty2Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptAll), ArrayExceptAll, ArrayExceptAllRewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptNull), ArrayExceptNull, ArrayExceptNullRewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptArrayExceptEnumerable), ArrayExceptArrayExceptEnumerable, ArrayExceptArrayExceptEnumerableRewritten);
            TestsExtensions.TestEquals(nameof(ArrayExceptArrayExceptEnumerable2), ArrayExceptArrayExceptEnumerable2, ArrayExceptArrayExceptEnumerable2Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayDistinctExceptArrayDistinct), ArrayDistinctExceptArrayDistinct, ArrayDistinctExceptArrayDistinctRewritten);
            TestsExtensions.TestEquals(nameof(ArrayDistinctExceptArrayDistinctDistinct), ArrayDistinctExceptArrayDistinctDistinct, ArrayDistinctExceptArrayDistinctDistinctRewritten);
            TestsExtensions.TestEquals(nameof(ArrayDistinctExceptArrayDistinctDistinct2), ArrayDistinctExceptArrayDistinctDistinct2, ArrayDistinctExceptArrayDistinctDistinct2Rewritten);
        }

        [NoRewrite]
        public IEnumerable<int> ArrayExceptArray()
        {
            return ArrayItems.Except(ArrayItems2);
        } //EndMethod

        public IEnumerable<int> ArrayExceptArrayRewritten()
        {
            return ArrayItems.Except(ArrayItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayExceptSimpleList()
        {
            return ArrayItems.Except(SimpleListItems2);
        } //EndMethod

        public IEnumerable<int> ArrayExceptSimpleListRewritten()
        {
            return ArrayItems.Except(SimpleListItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayExceptEnumerable()
        {
            return ArrayItems.Except(EnumerableItems2);
        } //EndMethod

        public IEnumerable<int> ArrayExceptEnumerableRewritten()
        {
            return ArrayItems.Except(EnumerableItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayExceptMethod()
        {
            return ArrayItems.Except(MethodEnumerable2());
        } //EndMethod

        public IEnumerable<int> ArrayExceptMethodRewritten()
        {
            return ArrayItems.Except(MethodEnumerable2());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListExceptArray()
        {
            return SimpleListItems.Except(ArrayItems2);
        } //EndMethod

        public IEnumerable<int> SimpleListExceptArrayRewritten()
        {
            return SimpleListItems.Except(ArrayItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListExceptSimpleList()
        {
            return SimpleListItems.Except(SimpleListItems2);
        } //EndMethod

        public IEnumerable<int> SimpleListExceptSimpleListRewritten()
        {
            return SimpleListItems.Except(SimpleListItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListExceptEnumerable()
        {
            return SimpleListItems.Except(EnumerableItems2);
        } //EndMethod

        public IEnumerable<int> SimpleListExceptEnumerableRewritten()
        {
            return SimpleListItems.Except(EnumerableItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListExceptMethod()
        {
            return SimpleListItems.Except(MethodEnumerable2());
        } //EndMethod

        public IEnumerable<int> SimpleListExceptMethodRewritten()
        {
            return SimpleListItems.Except(MethodEnumerable2());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableExceptArray()
        {
            return EnumerableItems.Except(ArrayItems2);
        } //EndMethod

        public IEnumerable<int> EnumerableExceptArrayRewritten()
        {
            return EnumerableItems.Except(ArrayItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableExceptSimpleList()
        {
            return EnumerableItems.Except(SimpleListItems2);
        } //EndMethod

        public IEnumerable<int> EnumerableExceptSimpleListRewritten()
        {
            return EnumerableItems.Except(SimpleListItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableExceptEnumerable()
        {
            return EnumerableItems.Except(EnumerableItems2);
        } //EndMethod

        public IEnumerable<int> EnumerableExceptEnumerableRewritten()
        {
            return EnumerableItems.Except(EnumerableItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableExceptMethod()
        {
            return EnumerableItems.Except(MethodEnumerable2());
        } //EndMethod

        public IEnumerable<int> EnumerableExceptMethodRewritten()
        {
            return EnumerableItems.Except(MethodEnumerable2());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> MethodExceptArray()
        {
            return MethodEnumerable().Except(ArrayItems2);
        } //EndMethod

        public IEnumerable<int> MethodExceptArrayRewritten()
        {
            return MethodEnumerable().Except(ArrayItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> MethodExceptSimpleList()
        {
            return MethodEnumerable().Except(SimpleListItems2);
        } //EndMethod

        public IEnumerable<int> MethodExceptSimpleListRewritten()
        {
            return MethodEnumerable().Except(SimpleListItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> MethodExceptEnumerable()
        {
            return MethodEnumerable().Except(EnumerableItems2);
        } //EndMethod

        public IEnumerable<int> MethodExceptEnumerableRewritten()
        {
            return MethodEnumerable().Except(EnumerableItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> MethodExceptMethod()
        {
            return MethodEnumerable().Except(MethodEnumerable2());
        } //EndMethod

        public IEnumerable<int> MethodExceptMethodRewritten()
        {
            return MethodEnumerable().Except(MethodEnumerable2());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayExceptArrayToArray()
        {
            return ArrayItems.Except(ArrayItems2).ToArray();
        } //EndMethod

        public IEnumerable<int> ArrayExceptArrayToArrayRewritten()
        {
            return ArrayItems.Except(ArrayItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayExceptSimpleListToArray()
        {
            return ArrayItems.Except(SimpleListItems2).ToArray();
        } //EndMethod

        public IEnumerable<int> ArrayExceptSimpleListToArrayRewritten()
        {
            return ArrayItems.Except(SimpleListItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayExceptEnumerableToArray()
        {
            return ArrayItems.Except(EnumerableItems2).ToArray();
        } //EndMethod

        public IEnumerable<int> ArrayExceptEnumerableToArrayRewritten()
        {
            return ArrayItems.Except(EnumerableItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListExceptArrayToArray()
        {
            return SimpleListItems.Except(ArrayItems2).ToArray();
        } //EndMethod

        public IEnumerable<int> SimpleListExceptArrayToArrayRewritten()
        {
            return SimpleListItems.Except(ArrayItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListExceptSimpleListToArray()
        {
            return SimpleListItems.Except(SimpleListItems2).ToArray();
        } //EndMethod

        public IEnumerable<int> SimpleListExceptSimpleListToArrayRewritten()
        {
            return SimpleListItems.Except(SimpleListItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListExceptEnumerableToArray()
        {
            return SimpleListItems.Except(EnumerableItems2).ToArray();
        } //EndMethod

        public IEnumerable<int> SimpleListExceptEnumerableToArrayRewritten()
        {
            return SimpleListItems.Except(EnumerableItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableExceptArrayToArray()
        {
            return EnumerableItems.Except(ArrayItems2).ToArray();
        } //EndMethod

        public IEnumerable<int> EnumerableExceptArrayToArrayRewritten()
        {
            return EnumerableItems.Except(ArrayItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableExceptSimpleListToArray()
        {
            return EnumerableItems.Except(SimpleListItems2).ToArray();
        } //EndMethod

        public IEnumerable<int> EnumerableExceptSimpleListToArrayRewritten()
        {
            return EnumerableItems.Except(SimpleListItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableExceptEnumerableToArray()
        {
            return EnumerableItems.Except(EnumerableItems2).ToArray();
        } //EndMethod

        public IEnumerable<int> EnumerableExceptEnumerableToArrayRewritten()
        {
            return EnumerableItems.Except(EnumerableItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArraySelectExceptArray()
        {
            return ArrayItems.Select(x => x + 50).Except(ArrayItems2);
        } //EndMethod

        public IEnumerable<int> ArraySelectExceptArrayRewritten()
        {
            return ArrayItems.Select(x => x + 50).Except(ArrayItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArraySelectExceptArraySelect()
        {
            return ArrayItems.Select(x => x + 50).Except(ArrayItems2.Select(x => x + 50));
        } //EndMethod

        public IEnumerable<int> ArraySelectExceptArraySelectRewritten()
        {
            return ArrayItems.Select(x => x + 50).Except(ArrayItems2.Select(x => x + 50));
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayWhereExceptArrayWhere()
        {
            return ArrayItems.Where(x => x > 50).Except(ArrayItems2.Where(x => x > 50));
        } //EndMethod

        public IEnumerable<int> ArrayWhereExceptArrayWhereRewritten()
        {
            return ArrayItems.Where(x => x > 50).Except(ArrayItems2.Where(x => x > 50));
        } //EndMethod


        [NoRewrite]
        public int ArrayExceptArrayCount()
        {
            return ArrayItems.Except(ArrayItems2).Count();
        } //EndMethod

        public int ArrayExceptArrayCountRewritten()
        {
            return ArrayItems.Except(ArrayItems2).Count();
        } //EndMethod


        [NoRewrite]
        public int ArrayExceptArrayCount2()
        {
            return ArrayItems.Except(ArrayItems2).Count(x => x > 70);
        } //EndMethod

        public int ArrayExceptArrayCount2Rewritten()
        {
            return ArrayItems.Except(ArrayItems2).Count(x => x > 70);
        } //EndMethod


        [NoRewrite]
        public int ArrayExceptArraySum()
        {
            return ArrayItems.Except(ArrayItems2).Sum();
        } //EndMethod

        public int ArrayExceptArraySumRewritten()
        {
            return ArrayItems.Except(ArrayItems2).Sum();
        } //EndMethod


        [NoRewrite]
        public int ArrayExceptArraySum2()
        {
            return ArrayItems.Except(ArrayItems2).Sum(x => x + 10);
        } //EndMethod

        public int ArrayExceptArraySum2Rewritten()
        {
            return ArrayItems.Except(ArrayItems2).Sum(x => x + 10);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayExceptArrayDistinct()
        {
            return ArrayItems.Except(ArrayItems2).Distinct();
        } //EndMethod

        public IEnumerable<int> ArrayExceptArrayDistinctRewritten()
        {
            return ArrayItems.Except(ArrayItems2).Distinct();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayExceptArrayDistinct2()
        {
            return ArrayItems.Except(ArrayItems2).Distinct(EqualityComparer<int>.Default);
        } //EndMethod

        public IEnumerable<int> ArrayExceptArrayDistinct2Rewritten()
        {
            return ArrayItems.Except(ArrayItems2).Distinct(EqualityComparer<int>.Default);
        } //EndMethod


        [NoRewrite]
        public int ArrayExceptArrayElementAt()
        {
            return ArrayItems.Except(ArrayItems2).ElementAt(45);
        } //EndMethod

        public int ArrayExceptArrayElementAtRewritten()
        {
            return ArrayItems.Except(ArrayItems2).ElementAt(45);
        } //EndMethod


        [NoRewrite]
        public int ArrayExceptArrayElementAtOrDefault()
        {
            return ArrayItems.Except(ArrayItems2).ElementAtOrDefault(45);
        } //EndMethod

        public int ArrayExceptArrayElementAtOrDefaultRewritten()
        {
            return ArrayItems.Except(ArrayItems2).ElementAtOrDefault(45);
        } //EndMethod


        [NoRewrite]
        public int ArrayExceptArrayFirst()
        {
            return ArrayItems.Except(ArrayItems2).First();
        } //EndMethod

        public int ArrayExceptArrayFirstRewritten()
        {
            return ArrayItems.Except(ArrayItems2).First();
        } //EndMethod


        [NoRewrite]
        public int ArrayExceptArrayFirstOrDefault()
        {
            return ArrayItems.Except(ArrayItems2).FirstOrDefault();
        } //EndMethod

        public int ArrayExceptArrayFirstOrDefaultRewritten()
        {
            return ArrayItems.Except(ArrayItems2).FirstOrDefault();
        } //EndMethod


        [NoRewrite]
        public int ArrayExceptArrayLast()
        {
            return ArrayItems.Except(ArrayItems2).Last();
        } //EndMethod

        public int ArrayExceptArrayLastRewritten()
        {
            return ArrayItems.Except(ArrayItems2).Last();
        } //EndMethod


        [NoRewrite]
        public int ArrayExceptArrayLastOrDefault()
        {
            return ArrayItems.Except(ArrayItems2).LastOrDefault();
        } //EndMethod

        public int ArrayExceptArrayLastOrDefaultRewritten()
        {
            return ArrayItems.Except(ArrayItems2).LastOrDefault();
        } //EndMethod


        [NoRewrite]
        public int ArrayExceptArraySingle()
        {
            return ArrayItems.Except(ArrayItems2).Single();
        } //EndMethod

        public int ArrayExceptArraySingleRewritten()
        {
            return ArrayItems.Except(ArrayItems2).Single();
        } //EndMethod


        [NoRewrite]
        public int ArrayExceptArraySingle2()
        {
            return ArrayItems.Except(ArrayItems2).Single(x => x == 76);
        } //EndMethod

        public int ArrayExceptArraySingle2Rewritten()
        {
            return ArrayItems.Except(ArrayItems2).Single(x => x == 76);
        } //EndMethod


        [NoRewrite]
        public int ArrayExceptArraySingleOrDefault()
        {
            return ArrayItems.Except(ArrayItems2).SingleOrDefault();
        } //EndMethod

        public int ArrayExceptArraySingleOrDefaultRewritten()
        {
            return ArrayItems.Except(ArrayItems2).SingleOrDefault();
        } //EndMethod


        [NoRewrite]
        public int ArrayExceptArrayMin()
        {
            return ArrayItems.Except(ArrayItems2).Min();
        } //EndMethod

        public int ArrayExceptArrayMinRewritten()
        {
            return ArrayItems.Except(ArrayItems2).Min();
        } //EndMethod


        [NoRewrite]
        public decimal ArrayExceptArrayMin2()
        {
            return ArrayItems.Except(ArrayItems2).Min(x => x + 2m);
        } //EndMethod

        public decimal ArrayExceptArrayMin2Rewritten()
        {
            return ArrayItems.Except(ArrayItems2).Min(x => x + 2m);
        } //EndMethod


        [NoRewrite]
        public int ArrayExceptArrayMax()
        {
            return ArrayItems.Except(ArrayItems2).Max();
        } //EndMethod

        public int ArrayExceptArrayMaxRewritten()
        {
            return ArrayItems.Except(ArrayItems2).Max();
        } //EndMethod


        [NoRewrite]
        public decimal ArrayExceptArrayMax2()
        {
            return ArrayItems.Except(ArrayItems2).Max(x => x + 2m);
        } //EndMethod

        public decimal ArrayExceptArrayMax2Rewritten()
        {
            return ArrayItems.Except(ArrayItems2).Max(x => x + 2m);
        } //EndMethod


        [NoRewrite]
        public long ArrayExceptArrayLongCount()
        {
            return ArrayItems.Except(ArrayItems2).LongCount();
        } //EndMethod

        public long ArrayExceptArrayLongCountRewritten()
        {
            return ArrayItems.Except(ArrayItems2).LongCount();
        } //EndMethod


        [NoRewrite]
        public long ArrayExceptArrayLongCount2()
        {
            return ArrayItems.Except(ArrayItems2).LongCount(x => x > 50);
        } //EndMethod

        public long ArrayExceptArrayLongCount2Rewritten()
        {
            return ArrayItems.Except(ArrayItems2).LongCount(x => x > 50);
        } //EndMethod


        [NoRewrite]
        public bool ArrayExceptArrayContains()
        {
            return ArrayItems.Except(ArrayItems2).Contains(56);
        } //EndMethod

        public bool ArrayExceptArrayContainsRewritten()
        {
            return ArrayItems.Except(ArrayItems2).Contains(56);
        } //EndMethod


        [NoRewrite]
        public double ArrayExceptArrayAverage()
        {
            return ArrayItems.Except(ArrayItems2).Average();
        } //EndMethod

        public double ArrayExceptArrayAverageRewritten()
        {
            return ArrayItems.Except(ArrayItems2).Average();
        } //EndMethod


        [NoRewrite]
        public double ArrayExceptArrayAverage2()
        {
            return ArrayItems.Except(ArrayItems2).Average(x => x + 10);
        } //EndMethod

        public double ArrayExceptArrayAverage2Rewritten()
        {
            return ArrayItems.Except(ArrayItems2).Average(x => x + 10);
        } //EndMethod


        [NoRewrite]
        public bool ArrayExceptArrayContains2()
        {
            return ArrayItems.Except(ArrayItems2).Contains(56, EqualityComparer<int>.Default);
        } //EndMethod

        public bool ArrayExceptArrayContains2Rewritten()
        {
            return ArrayItems.Except(ArrayItems2).Contains(56, EqualityComparer<int>.Default);
        } //EndMethod


        [NoRewrite]
        public bool SelectWhereArrayExceptSelectWhereArrayContains()
        {
            return ArrayItems.Select(x => x + 10).Where(x => x > 80).Except(ArrayItems2.Select(x => x + 10).Where(x => x > 80)).Contains(112);
        } //EndMethod

        public bool SelectWhereArrayExceptSelectWhereArrayContainsRewritten()
        {
            return ArrayItems.Select(x => x + 10).Where(x => x > 80).Except(ArrayItems2.Select(x => x + 10).Where(x => x > 80)).Contains(112);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RangeExceptArray()
        {
            return Enumerable.Range(20, 100).Except(ArrayItems2);
        } //EndMethod

        public IEnumerable<int> RangeExceptArrayRewritten()
        {
            return Enumerable.Range(20, 100).Except(ArrayItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RepeatExceptArray()
        {
            return Enumerable.Repeat(20, 100).Except(ArrayItems2);
        } //EndMethod

        public IEnumerable<int> RepeatExceptArrayRewritten()
        {
            return Enumerable.Repeat(20, 100).Except(ArrayItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EmptyExceptArray()
        {
            return Enumerable.Empty<int>().Except(ArrayItems2);
        } //EndMethod

        public IEnumerable<int> EmptyExceptArrayRewritten()
        {
            return Enumerable.Empty<int>().Except(ArrayItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RangeEmpty2Array()
        {
            return ArrayItems.Where(x => false).Except(ArrayItems2);
        } //EndMethod

        public IEnumerable<int> RangeEmpty2ArrayRewritten()
        {
            return ArrayItems.Where(x => false).Except(ArrayItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayExceptRange()
        {
            return ArrayItems.Except(Enumerable.Range(70, 260));
        } //EndMethod

        public IEnumerable<int> ArrayExceptRangeRewritten()
        {
            return ArrayItems.Except(Enumerable.Range(70, 260));
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayExceptRepeat()
        {
            return ArrayItems.Except(Enumerable.Repeat(70, 100));
        } //EndMethod

        public IEnumerable<int> ArrayExceptRepeatRewritten()
        {
            return ArrayItems.Except(Enumerable.Repeat(70, 100));
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayExceptEmpty()
        {
            return ArrayItems.Except(Enumerable.Empty<int>());
        } //EndMethod

        public IEnumerable<int> ArrayExceptEmptyRewritten()
        {
            return ArrayItems.Except(Enumerable.Empty<int>());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayExceptEmpty2()
        {
            return ArrayItems.Except(ArrayItems2.Where(x => false));
        } //EndMethod

        public IEnumerable<int> ArrayExceptEmpty2Rewritten()
        {
            return ArrayItems.Except(ArrayItems2.Where(x => false));
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayExceptAll()
        {
            return ArrayItems.Except(Enumerable.Range(0, 1000));
        } //EndMethod

        public IEnumerable<int> ArrayExceptAllRewritten()
        {
            return ArrayItems.Except(Enumerable.Range(0, 1000));
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayExceptNull()
        {
            return ArrayItems.Except(null);
        } //EndMethod

        public IEnumerable<int> ArrayExceptNullRewritten()
        {
            return ArrayItems.Except(null);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayExceptArrayExceptEnumerable()
        {
            return ArrayItems.Except(ArrayItems).Except(EnumerableItems2);
        } //EndMethod

        public IEnumerable<int> ArrayExceptArrayExceptEnumerableRewritten()
        {
            return ArrayItems.Except(ArrayItems).Except(EnumerableItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayExceptArrayExceptEnumerable2()
        {
            return ArrayItems.Except(ArrayItems.Except(EnumerableItems2));
        } //EndMethod

        public IEnumerable<int> ArrayExceptArrayExceptEnumerable2Rewritten()
        {
            return ArrayItems.Except(ArrayItems.Except(EnumerableItems2));
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayDistinctExceptArrayDistinct()
        {
            return ArrayItems.Distinct().Except(ArrayItems.Distinct());
        } //EndMethod

        public IEnumerable<int> ArrayDistinctExceptArrayDistinctRewritten()
        {
            return ArrayItems.Distinct().Except(ArrayItems.Distinct());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayDistinctExceptArrayDistinctDistinct()
        {
            return ArrayItems.Distinct().Except(ArrayItems.Distinct()).Distinct();
        } //EndMethod

        public IEnumerable<int> ArrayDistinctExceptArrayDistinctDistinctRewritten()
        {
            return ArrayItems.Distinct().Except(ArrayItems.Distinct()).Distinct();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayDistinctExceptArrayDistinctDistinct2()
        {
            return ArrayItems.Distinct(EqualityComparer<int>.Default).Except(ArrayItems.Distinct(EqualityComparer<int>.Default)).Distinct(EqualityComparer<int>.Default);
        } //EndMethod

        public IEnumerable<int> ArrayDistinctExceptArrayDistinctDistinct2Rewritten()
        {
            return ArrayItems.Distinct(EqualityComparer<int>.Default).Except(ArrayItems.Distinct(EqualityComparer<int>.Default)).Distinct(EqualityComparer<int>.Default);
        } //EndMethod

    }
}