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
            return ArrayItems.Concat(ArrayItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatSimpleList()
        {
            return ArrayItems.Concat(SimpleListItems2);
        } //EndMethod

        public IEnumerable<int> ArrayConcatSimpleListRewritten()
        {
            return ArrayItems.Concat(SimpleListItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatEnumerable()
        {
            return ArrayItems.Concat(EnumerableItems2);
        } //EndMethod

        public IEnumerable<int> ArrayConcatEnumerableRewritten()
        {
            return ArrayItems.Concat(EnumerableItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatMethod()
        {
            return ArrayItems.Concat(MethodEnumerable2());
        } //EndMethod

        public IEnumerable<int> ArrayConcatMethodRewritten()
        {
            return ArrayItems.Concat(MethodEnumerable2());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListConcatArray()
        {
            return SimpleListItems.Concat(ArrayItems2);
        } //EndMethod

        public IEnumerable<int> SimpleListConcatArrayRewritten()
        {
            return SimpleListItems.Concat(ArrayItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListConcatSimpleList()
        {
            return SimpleListItems.Concat(SimpleListItems2);
        } //EndMethod

        public IEnumerable<int> SimpleListConcatSimpleListRewritten()
        {
            return SimpleListItems.Concat(SimpleListItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListConcatEnumerable()
        {
            return SimpleListItems.Concat(EnumerableItems2);
        } //EndMethod

        public IEnumerable<int> SimpleListConcatEnumerableRewritten()
        {
            return SimpleListItems.Concat(EnumerableItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListConcatMethod()
        {
            return SimpleListItems.Concat(MethodEnumerable2());
        } //EndMethod

        public IEnumerable<int> SimpleListConcatMethodRewritten()
        {
            return SimpleListItems.Concat(MethodEnumerable2());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableConcatArray()
        {
            return EnumerableItems.Concat(ArrayItems2);
        } //EndMethod

        public IEnumerable<int> EnumerableConcatArrayRewritten()
        {
            return EnumerableItems.Concat(ArrayItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableConcatSimpleList()
        {
            return EnumerableItems.Concat(SimpleListItems2);
        } //EndMethod

        public IEnumerable<int> EnumerableConcatSimpleListRewritten()
        {
            return EnumerableItems.Concat(SimpleListItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableConcatEnumerable()
        {
            return EnumerableItems.Concat(EnumerableItems2);
        } //EndMethod

        public IEnumerable<int> EnumerableConcatEnumerableRewritten()
        {
            return EnumerableItems.Concat(EnumerableItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableConcatMethod()
        {
            return EnumerableItems.Concat(MethodEnumerable2());
        } //EndMethod

        public IEnumerable<int> EnumerableConcatMethodRewritten()
        {
            return EnumerableItems.Concat(MethodEnumerable2());
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
            return ArrayItems.Concat(ArrayItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatSimpleListToArray()
        {
            return ArrayItems.Concat(SimpleListItems2).ToArray();
        } //EndMethod

        public IEnumerable<int> ArrayConcatSimpleListToArrayRewritten()
        {
            return ArrayItems.Concat(SimpleListItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatEnumerableToArray()
        {
            return ArrayItems.Concat(EnumerableItems2).ToArray();
        } //EndMethod

        public IEnumerable<int> ArrayConcatEnumerableToArrayRewritten()
        {
            return ArrayItems.Concat(EnumerableItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListConcatArrayToArray()
        {
            return SimpleListItems.Concat(ArrayItems2).ToArray();
        } //EndMethod

        public IEnumerable<int> SimpleListConcatArrayToArrayRewritten()
        {
            return SimpleListItems.Concat(ArrayItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListConcatSimpleListToArray()
        {
            return SimpleListItems.Concat(SimpleListItems2).ToArray();
        } //EndMethod

        public IEnumerable<int> SimpleListConcatSimpleListToArrayRewritten()
        {
            return SimpleListItems.Concat(SimpleListItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListConcatEnumerableToArray()
        {
            return SimpleListItems.Concat(EnumerableItems2).ToArray();
        } //EndMethod

        public IEnumerable<int> SimpleListConcatEnumerableToArrayRewritten()
        {
            return SimpleListItems.Concat(EnumerableItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableConcatArrayToArray()
        {
            return EnumerableItems.Concat(ArrayItems2).ToArray();
        } //EndMethod

        public IEnumerable<int> EnumerableConcatArrayToArrayRewritten()
        {
            return EnumerableItems.Concat(ArrayItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableConcatSimpleListToArray()
        {
            return EnumerableItems.Concat(SimpleListItems2).ToArray();
        } //EndMethod

        public IEnumerable<int> EnumerableConcatSimpleListToArrayRewritten()
        {
            return EnumerableItems.Concat(SimpleListItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableConcatEnumerableToArray()
        {
            return EnumerableItems.Concat(EnumerableItems2).ToArray();
        } //EndMethod

        public IEnumerable<int> EnumerableConcatEnumerableToArrayRewritten()
        {
            return EnumerableItems.Concat(EnumerableItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArraySelectConcatArray()
        {
            return ArrayItems.Select(x => x + 50).Concat(ArrayItems2);
        } //EndMethod

        public IEnumerable<int> ArraySelectConcatArrayRewritten()
        {
            return ArrayItems.Select(x => x + 50).Concat(ArrayItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArraySelectConcatArraySelect()
        {
            return ArrayItems.Select(x => x + 50).Concat(ArrayItems2.Select(x => x + 50));
        } //EndMethod

        public IEnumerable<int> ArraySelectConcatArraySelectRewritten()
        {
            return ArrayItems.Select(x => x + 50).Concat(ArrayItems2.Select(x => x + 50));
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayWhereConcatArrayWhere()
        {
            return ArrayItems.Where(x => x > 50).Concat(ArrayItems2.Where(x => x > 50));
        } //EndMethod

        public IEnumerable<int> ArrayWhereConcatArrayWhereRewritten()
        {
            return ArrayItems.Where(x => x > 50).Concat(ArrayItems2.Where(x => x > 50));
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArrayCount()
        {
            return ArrayItems.Concat(ArrayItems2).Count();
        } //EndMethod

        public int ArrayConcatArrayCountRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Count();
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArrayCount2()
        {
            return ArrayItems.Concat(ArrayItems2).Count(x => x > 70);
        } //EndMethod

        public int ArrayConcatArrayCount2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Count(x => x > 70);
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArraySum()
        {
            return ArrayItems.Concat(ArrayItems2).Sum();
        } //EndMethod

        public int ArrayConcatArraySumRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Sum();
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArraySum2()
        {
            return ArrayItems.Concat(ArrayItems2).Sum(x => x + 10);
        } //EndMethod

        public int ArrayConcatArraySum2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Sum(x => x + 10);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatArrayDistinct()
        {
            return ArrayItems.Concat(ArrayItems2).Distinct();
        } //EndMethod

        public IEnumerable<int> ArrayConcatArrayDistinctRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Distinct();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatArrayDistinct2()
        {
            return ArrayItems.Concat(ArrayItems2).Distinct(EqualityComparer<int>.Default);
        } //EndMethod

        public IEnumerable<int> ArrayConcatArrayDistinct2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Distinct(EqualityComparer<int>.Default);
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArrayElementAt()
        {
            return ArrayItems.Concat(ArrayItems2).ElementAt(45);
        } //EndMethod

        public int ArrayConcatArrayElementAtRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).ElementAt(45);
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArrayElementAtOrDefault()
        {
            return ArrayItems.Concat(ArrayItems2).ElementAtOrDefault(45);
        } //EndMethod

        public int ArrayConcatArrayElementAtOrDefaultRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).ElementAtOrDefault(45);
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArrayFirst()
        {
            return ArrayItems.Concat(ArrayItems2).First();
        } //EndMethod

        public int ArrayConcatArrayFirstRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).First();
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArrayFirstOrDefault()
        {
            return ArrayItems.Concat(ArrayItems2).FirstOrDefault();
        } //EndMethod

        public int ArrayConcatArrayFirstOrDefaultRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).FirstOrDefault();
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArrayLast()
        {
            return ArrayItems.Concat(ArrayItems2).Last();
        } //EndMethod

        public int ArrayConcatArrayLastRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Last();
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArrayLastOrDefault()
        {
            return ArrayItems.Concat(ArrayItems2).LastOrDefault();
        } //EndMethod

        public int ArrayConcatArrayLastOrDefaultRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).LastOrDefault();
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArraySingle()
        {
            return ArrayItems.Concat(ArrayItems2).Single();
        } //EndMethod

        public int ArrayConcatArraySingleRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Single();
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArraySingle2()
        {
            return ArrayItems.Concat(ArrayItems2).Single(x => x == 76);
        } //EndMethod

        public int ArrayConcatArraySingle2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Single(x => x == 76);
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArraySingleOrDefault()
        {
            return ArrayItems.Concat(ArrayItems2).SingleOrDefault();
        } //EndMethod

        public int ArrayConcatArraySingleOrDefaultRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).SingleOrDefault();
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArrayMin()
        {
            return ArrayItems.Concat(ArrayItems2).Min();
        } //EndMethod

        public int ArrayConcatArrayMinRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Min();
        } //EndMethod


        [NoRewrite]
        public decimal ArrayConcatArrayMin2()
        {
            return ArrayItems.Concat(ArrayItems2).Min(x => x + 2m);
        } //EndMethod

        public decimal ArrayConcatArrayMin2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Min(x => x + 2m);
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArrayMax()
        {
            return ArrayItems.Concat(ArrayItems2).Max();
        } //EndMethod

        public int ArrayConcatArrayMaxRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Max();
        } //EndMethod


        [NoRewrite]
        public decimal ArrayConcatArrayMax2()
        {
            return ArrayItems.Concat(ArrayItems2).Max(x => x + 2m);
        } //EndMethod

        public decimal ArrayConcatArrayMax2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Max(x => x + 2m);
        } //EndMethod


        [NoRewrite]
        public long ArrayConcatArrayLongCount()
        {
            return ArrayItems.Concat(ArrayItems2).LongCount();
        } //EndMethod

        public long ArrayConcatArrayLongCountRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).LongCount();
        } //EndMethod


        [NoRewrite]
        public long ArrayConcatArrayLongCount2()
        {
            return ArrayItems.Concat(ArrayItems2).LongCount(x => x > 50);
        } //EndMethod

        public long ArrayConcatArrayLongCount2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).LongCount(x => x > 50);
        } //EndMethod


        [NoRewrite]
        public bool ArrayConcatArrayContains()
        {
            return ArrayItems.Concat(ArrayItems2).Contains(56);
        } //EndMethod

        public bool ArrayConcatArrayContainsRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Contains(56);
        } //EndMethod


        [NoRewrite]
        public double ArrayConcatArrayAverage()
        {
            return ArrayItems.Concat(ArrayItems2).Average();
        } //EndMethod

        public double ArrayConcatArrayAverageRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Average();
        } //EndMethod


        [NoRewrite]
        public double ArrayConcatArrayAverage2()
        {
            return ArrayItems.Concat(ArrayItems2).Average(x => x + 10);
        } //EndMethod

        public double ArrayConcatArrayAverage2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Average(x => x + 10);
        } //EndMethod


        [NoRewrite]
        public bool ArrayConcatArrayContains2()
        {
            return ArrayItems.Concat(ArrayItems2).Contains(56, EqualityComparer<int>.Default);
        } //EndMethod

        public bool ArrayConcatArrayContains2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Contains(56, EqualityComparer<int>.Default);
        } //EndMethod


        [NoRewrite]
        public bool SelectWhereArrayConcatSelectWhereArrayContains()
        {
            return ArrayItems.Select(x => x + 10).Where(x => x > 80).Concat(ArrayItems2.Select(x => x + 10).Where(x => x > 80)).Contains(112);
        } //EndMethod

        public bool SelectWhereArrayConcatSelectWhereArrayContainsRewritten()
        {
            return ArrayItems.Select(x => x + 10).Where(x => x > 80).Concat(ArrayItems2.Select(x => x + 10).Where(x => x > 80)).Contains(112);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RangeConcatArray()
        {
            return Enumerable.Range(20, 100).Concat(ArrayItems2);
        } //EndMethod

        public IEnumerable<int> RangeConcatArrayRewritten()
        {
            return Enumerable.Range(20, 100).Concat(ArrayItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RepeatConcatArray()
        {
            return Enumerable.Repeat(20, 100).Concat(ArrayItems2);
        } //EndMethod

        public IEnumerable<int> RepeatConcatArrayRewritten()
        {
            return Enumerable.Repeat(20, 100).Concat(ArrayItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EmptyConcatArray()
        {
            return Enumerable.Empty<int>().Concat(ArrayItems2);
        } //EndMethod

        public IEnumerable<int> EmptyConcatArrayRewritten()
        {
            return Enumerable.Empty<int>().Concat(ArrayItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RangeEmpty2Array()
        {
            return ArrayItems.Where(x => false).Concat(ArrayItems2);
        } //EndMethod

        public IEnumerable<int> RangeEmpty2ArrayRewritten()
        {
            return ArrayItems.Where(x => false).Concat(ArrayItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatRange()
        {
            return ArrayItems.Concat(Enumerable.Range(70, 260));
        } //EndMethod

        public IEnumerable<int> ArrayConcatRangeRewritten()
        {
            return ArrayItems.Concat(Enumerable.Range(70, 260));
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatRepeat()
        {
            return ArrayItems.Concat(Enumerable.Repeat(70, 100));
        } //EndMethod

        public IEnumerable<int> ArrayConcatRepeatRewritten()
        {
            return ArrayItems.Concat(Enumerable.Repeat(70, 100));
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatEmpty()
        {
            return ArrayItems.Concat(Enumerable.Empty<int>());
        } //EndMethod

        public IEnumerable<int> ArrayConcatEmptyRewritten()
        {
            return ArrayItems.Concat(Enumerable.Empty<int>());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatEmpty2()
        {
            return ArrayItems.Concat(ArrayItems2.Where(x => false));
        } //EndMethod

        public IEnumerable<int> ArrayConcatEmpty2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2.Where(x => false));
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatAll()
        {
            return ArrayItems.Concat(Enumerable.Range(0, 1000));
        } //EndMethod

        public IEnumerable<int> ArrayConcatAllRewritten()
        {
            return ArrayItems.Concat(Enumerable.Range(0, 1000));
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatNull()
        {
            return ArrayItems.Concat(null);
        } //EndMethod

        public IEnumerable<int> ArrayConcatNullRewritten()
        {
            return ArrayItems.Concat(null);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatArrayConcatEnumerable()
        {
            return ArrayItems.Concat(ArrayItems).Concat(EnumerableItems2);
        } //EndMethod

        public IEnumerable<int> ArrayConcatArrayConcatEnumerableRewritten()
        {
            return ArrayItems.Concat(ArrayItems).Concat(EnumerableItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatArrayConcatEnumerable2()
        {
            return ArrayItems.Concat(ArrayItems.Concat(EnumerableItems2));
        } //EndMethod

        public IEnumerable<int> ArrayConcatArrayConcatEnumerable2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems.Concat(EnumerableItems2));
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayDistinctConcatArrayDistinct()
        {
            return ArrayItems.Distinct().Concat(ArrayItems.Distinct());
        } //EndMethod

        public IEnumerable<int> ArrayDistinctConcatArrayDistinctRewritten()
        {
            return ArrayItems.Distinct().Concat(ArrayItems.Distinct());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinct()
        {
            return ArrayItems.Distinct().Concat(ArrayItems.Distinct()).Distinct();
        } //EndMethod

        public IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinctRewritten()
        {
            return ArrayItems.Distinct().Concat(ArrayItems.Distinct()).Distinct();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinct2()
        {
            return ArrayItems.Distinct(EqualityComparer<int>.Default).Concat(ArrayItems.Distinct(EqualityComparer<int>.Default)).Distinct(EqualityComparer<int>.Default);
        } //EndMethod

        public IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinct2Rewritten()
        {
            return ArrayItems.Distinct(EqualityComparer<int>.Default).Concat(ArrayItems.Distinct(EqualityComparer<int>.Default)).Distinct(EqualityComparer<int>.Default);
        } //EndMethod

    }
}