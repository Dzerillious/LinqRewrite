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
            return ArrayItems.Union(ArrayItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayUnionSimpleList()
        {
            return ArrayItems.Union(SimpleListItems2);
        } //EndMethod

        public IEnumerable<int> ArrayUnionSimpleListRewritten()
        {
            return ArrayItems.Union(SimpleListItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayUnionEnumerable()
        {
            return ArrayItems.Union(EnumerableItems2);
        } //EndMethod

        public IEnumerable<int> ArrayUnionEnumerableRewritten()
        {
            return ArrayItems.Union(EnumerableItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayUnionMethod()
        {
            return ArrayItems.Union(MethodEnumerable2());
        } //EndMethod

        public IEnumerable<int> ArrayUnionMethodRewritten()
        {
            return ArrayItems.Union(MethodEnumerable2());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListUnionArray()
        {
            return SimpleListItems.Union(ArrayItems2);
        } //EndMethod

        public IEnumerable<int> SimpleListUnionArrayRewritten()
        {
            return SimpleListItems.Union(ArrayItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListUnionSimpleList()
        {
            return SimpleListItems.Union(SimpleListItems2);
        } //EndMethod

        public IEnumerable<int> SimpleListUnionSimpleListRewritten()
        {
            return SimpleListItems.Union(SimpleListItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListUnionEnumerable()
        {
            return SimpleListItems.Union(EnumerableItems2);
        } //EndMethod

        public IEnumerable<int> SimpleListUnionEnumerableRewritten()
        {
            return SimpleListItems.Union(EnumerableItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListUnionMethod()
        {
            return SimpleListItems.Union(MethodEnumerable2());
        } //EndMethod

        public IEnumerable<int> SimpleListUnionMethodRewritten()
        {
            return SimpleListItems.Union(MethodEnumerable2());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableUnionArray()
        {
            return EnumerableItems.Union(ArrayItems2);
        } //EndMethod

        public IEnumerable<int> EnumerableUnionArrayRewritten()
        {
            return EnumerableItems.Union(ArrayItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableUnionSimpleList()
        {
            return EnumerableItems.Union(SimpleListItems2);
        } //EndMethod

        public IEnumerable<int> EnumerableUnionSimpleListRewritten()
        {
            return EnumerableItems.Union(SimpleListItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableUnionEnumerable()
        {
            return EnumerableItems.Union(EnumerableItems2);
        } //EndMethod

        public IEnumerable<int> EnumerableUnionEnumerableRewritten()
        {
            return EnumerableItems.Union(EnumerableItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableUnionMethod()
        {
            return EnumerableItems.Union(MethodEnumerable2());
        } //EndMethod

        public IEnumerable<int> EnumerableUnionMethodRewritten()
        {
            return EnumerableItems.Union(MethodEnumerable2());
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
            return ArrayItems.Union(ArrayItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayUnionSimpleListToArray()
        {
            return ArrayItems.Union(SimpleListItems2).ToArray();
        } //EndMethod

        public IEnumerable<int> ArrayUnionSimpleListToArrayRewritten()
        {
            return ArrayItems.Union(SimpleListItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayUnionEnumerableToArray()
        {
            return ArrayItems.Union(EnumerableItems2).ToArray();
        } //EndMethod

        public IEnumerable<int> ArrayUnionEnumerableToArrayRewritten()
        {
            return ArrayItems.Union(EnumerableItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListUnionArrayToArray()
        {
            return SimpleListItems.Union(ArrayItems2).ToArray();
        } //EndMethod

        public IEnumerable<int> SimpleListUnionArrayToArrayRewritten()
        {
            return SimpleListItems.Union(ArrayItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListUnionSimpleListToArray()
        {
            return SimpleListItems.Union(SimpleListItems2).ToArray();
        } //EndMethod

        public IEnumerable<int> SimpleListUnionSimpleListToArrayRewritten()
        {
            return SimpleListItems.Union(SimpleListItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListUnionEnumerableToArray()
        {
            return SimpleListItems.Union(EnumerableItems2).ToArray();
        } //EndMethod

        public IEnumerable<int> SimpleListUnionEnumerableToArrayRewritten()
        {
            return SimpleListItems.Union(EnumerableItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableUnionArrayToArray()
        {
            return EnumerableItems.Union(ArrayItems2).ToArray();
        } //EndMethod

        public IEnumerable<int> EnumerableUnionArrayToArrayRewritten()
        {
            return EnumerableItems.Union(ArrayItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableUnionSimpleListToArray()
        {
            return EnumerableItems.Union(SimpleListItems2).ToArray();
        } //EndMethod

        public IEnumerable<int> EnumerableUnionSimpleListToArrayRewritten()
        {
            return EnumerableItems.Union(SimpleListItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableUnionEnumerableToArray()
        {
            return EnumerableItems.Union(EnumerableItems2).ToArray();
        } //EndMethod

        public IEnumerable<int> EnumerableUnionEnumerableToArrayRewritten()
        {
            return EnumerableItems.Union(EnumerableItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArraySelectUnionArray()
        {
            return ArrayItems.Select(x => x + 50).Union(ArrayItems2);
        } //EndMethod

        public IEnumerable<int> ArraySelectUnionArrayRewritten()
        {
            return ArrayItems.Select(x => x + 50).Union(ArrayItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArraySelectUnionArraySelect()
        {
            return ArrayItems.Select(x => x + 50).Union(ArrayItems2.Select(x => x + 50));
        } //EndMethod

        public IEnumerable<int> ArraySelectUnionArraySelectRewritten()
        {
            return ArrayItems.Select(x => x + 50).Union(ArrayItems2.Select(x => x + 50));
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayWhereUnionArrayWhere()
        {
            return ArrayItems.Where(x => x > 50).Union(ArrayItems2.Where(x => x > 50));
        } //EndMethod

        public IEnumerable<int> ArrayWhereUnionArrayWhereRewritten()
        {
            return ArrayItems.Where(x => x > 50).Union(ArrayItems2.Where(x => x > 50));
        } //EndMethod


        [NoRewrite]
        public int ArrayUnionArrayCount()
        {
            return ArrayItems.Union(ArrayItems2).Count();
        } //EndMethod

        public int ArrayUnionArrayCountRewritten()
        {
            return ArrayItems.Union(ArrayItems2).Count();
        } //EndMethod


        [NoRewrite]
        public int ArrayUnionArrayCount2()
        {
            return ArrayItems.Union(ArrayItems2).Count(x => x > 70);
        } //EndMethod

        public int ArrayUnionArrayCount2Rewritten()
        {
            return ArrayItems.Union(ArrayItems2).Count(x => x > 70);
        } //EndMethod


        [NoRewrite]
        public int ArrayUnionArraySum()
        {
            return ArrayItems.Union(ArrayItems2).Sum();
        } //EndMethod

        public int ArrayUnionArraySumRewritten()
        {
            return ArrayItems.Union(ArrayItems2).Sum();
        } //EndMethod


        [NoRewrite]
        public int ArrayUnionArraySum2()
        {
            return ArrayItems.Union(ArrayItems2).Sum(x => x + 10);
        } //EndMethod

        public int ArrayUnionArraySum2Rewritten()
        {
            return ArrayItems.Union(ArrayItems2).Sum(x => x + 10);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayUnionArrayDistinct()
        {
            return ArrayItems.Union(ArrayItems2).Distinct();
        } //EndMethod

        public IEnumerable<int> ArrayUnionArrayDistinctRewritten()
        {
            return ArrayItems.Union(ArrayItems2).Distinct();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayUnionArrayDistinct2()
        {
            return ArrayItems.Union(ArrayItems2).Distinct(EqualityComparer<int>.Default);
        } //EndMethod

        public IEnumerable<int> ArrayUnionArrayDistinct2Rewritten()
        {
            return ArrayItems.Union(ArrayItems2).Distinct(EqualityComparer<int>.Default);
        } //EndMethod


        [NoRewrite]
        public int ArrayUnionArrayElementAt()
        {
            return ArrayItems.Union(ArrayItems2).ElementAt(45);
        } //EndMethod

        public int ArrayUnionArrayElementAtRewritten()
        {
            return ArrayItems.Union(ArrayItems2).ElementAt(45);
        } //EndMethod


        [NoRewrite]
        public int ArrayUnionArrayElementAtOrDefault()
        {
            return ArrayItems.Union(ArrayItems2).ElementAtOrDefault(45);
        } //EndMethod

        public int ArrayUnionArrayElementAtOrDefaultRewritten()
        {
            return ArrayItems.Union(ArrayItems2).ElementAtOrDefault(45);
        } //EndMethod


        [NoRewrite]
        public int ArrayUnionArrayFirst()
        {
            return ArrayItems.Union(ArrayItems2).First();
        } //EndMethod

        public int ArrayUnionArrayFirstRewritten()
        {
            return ArrayItems.Union(ArrayItems2).First();
        } //EndMethod


        [NoRewrite]
        public int ArrayUnionArrayFirstOrDefault()
        {
            return ArrayItems.Union(ArrayItems2).FirstOrDefault();
        } //EndMethod

        public int ArrayUnionArrayFirstOrDefaultRewritten()
        {
            return ArrayItems.Union(ArrayItems2).FirstOrDefault();
        } //EndMethod


        [NoRewrite]
        public int ArrayUnionArrayLast()
        {
            return ArrayItems.Union(ArrayItems2).Last();
        } //EndMethod

        public int ArrayUnionArrayLastRewritten()
        {
            return ArrayItems.Union(ArrayItems2).Last();
        } //EndMethod


        [NoRewrite]
        public int ArrayUnionArrayLastOrDefault()
        {
            return ArrayItems.Union(ArrayItems2).LastOrDefault();
        } //EndMethod

        public int ArrayUnionArrayLastOrDefaultRewritten()
        {
            return ArrayItems.Union(ArrayItems2).LastOrDefault();
        } //EndMethod


        [NoRewrite]
        public int ArrayUnionArraySingle()
        {
            return ArrayItems.Union(ArrayItems2).Single();
        } //EndMethod

        public int ArrayUnionArraySingleRewritten()
        {
            return ArrayItems.Union(ArrayItems2).Single();
        } //EndMethod


        [NoRewrite]
        public int ArrayUnionArraySingle2()
        {
            return ArrayItems.Union(ArrayItems2).Single(x => x == 76);
        } //EndMethod

        public int ArrayUnionArraySingle2Rewritten()
        {
            return ArrayItems.Union(ArrayItems2).Single(x => x == 76);
        } //EndMethod


        [NoRewrite]
        public int ArrayUnionArraySingleOrDefault()
        {
            return ArrayItems.Union(ArrayItems2).SingleOrDefault();
        } //EndMethod

        public int ArrayUnionArraySingleOrDefaultRewritten()
        {
            return ArrayItems.Union(ArrayItems2).SingleOrDefault();
        } //EndMethod


        [NoRewrite]
        public int ArrayUnionArrayMin()
        {
            return ArrayItems.Union(ArrayItems2).Min();
        } //EndMethod

        public int ArrayUnionArrayMinRewritten()
        {
            return ArrayItems.Union(ArrayItems2).Min();
        } //EndMethod


        [NoRewrite]
        public decimal ArrayUnionArrayMin2()
        {
            return ArrayItems.Union(ArrayItems2).Min(x => x + 2m);
        } //EndMethod

        public decimal ArrayUnionArrayMin2Rewritten()
        {
            return ArrayItems.Union(ArrayItems2).Min(x => x + 2m);
        } //EndMethod


        [NoRewrite]
        public int ArrayUnionArrayMax()
        {
            return ArrayItems.Union(ArrayItems2).Max();
        } //EndMethod

        public int ArrayUnionArrayMaxRewritten()
        {
            return ArrayItems.Union(ArrayItems2).Max();
        } //EndMethod


        [NoRewrite]
        public decimal ArrayUnionArrayMax2()
        {
            return ArrayItems.Union(ArrayItems2).Max(x => x + 2m);
        } //EndMethod

        public decimal ArrayUnionArrayMax2Rewritten()
        {
            return ArrayItems.Union(ArrayItems2).Max(x => x + 2m);
        } //EndMethod


        [NoRewrite]
        public long ArrayUnionArrayLongCount()
        {
            return ArrayItems.Union(ArrayItems2).LongCount();
        } //EndMethod

        public long ArrayUnionArrayLongCountRewritten()
        {
            return ArrayItems.Union(ArrayItems2).LongCount();
        } //EndMethod


        [NoRewrite]
        public long ArrayUnionArrayLongCount2()
        {
            return ArrayItems.Union(ArrayItems2).LongCount(x => x > 50);
        } //EndMethod

        public long ArrayUnionArrayLongCount2Rewritten()
        {
            return ArrayItems.Union(ArrayItems2).LongCount(x => x > 50);
        } //EndMethod


        [NoRewrite]
        public bool ArrayUnionArrayContains()
        {
            return ArrayItems.Union(ArrayItems2).Contains(56);
        } //EndMethod

        public bool ArrayUnionArrayContainsRewritten()
        {
            return ArrayItems.Union(ArrayItems2).Contains(56);
        } //EndMethod


        [NoRewrite]
        public double ArrayUnionArrayAverage()
        {
            return ArrayItems.Union(ArrayItems2).Average();
        } //EndMethod

        public double ArrayUnionArrayAverageRewritten()
        {
            return ArrayItems.Union(ArrayItems2).Average();
        } //EndMethod


        [NoRewrite]
        public double ArrayUnionArrayAverage2()
        {
            return ArrayItems.Union(ArrayItems2).Average(x => x + 10);
        } //EndMethod

        public double ArrayUnionArrayAverage2Rewritten()
        {
            return ArrayItems.Union(ArrayItems2).Average(x => x + 10);
        } //EndMethod


        [NoRewrite]
        public bool ArrayUnionArrayContains2()
        {
            return ArrayItems.Union(ArrayItems2).Contains(56, EqualityComparer<int>.Default);
        } //EndMethod

        public bool ArrayUnionArrayContains2Rewritten()
        {
            return ArrayItems.Union(ArrayItems2).Contains(56, EqualityComparer<int>.Default);
        } //EndMethod


        [NoRewrite]
        public bool SelectWhereArrayUnionSelectWhereArrayContains()
        {
            return ArrayItems.Select(x => x + 10).Where(x => x > 80).Union(ArrayItems2.Select(x => x + 10).Where(x => x > 80)).Contains(112);
        } //EndMethod

        public bool SelectWhereArrayUnionSelectWhereArrayContainsRewritten()
        {
            return ArrayItems.Select(x => x + 10).Where(x => x > 80).Union(ArrayItems2.Select(x => x + 10).Where(x => x > 80)).Contains(112);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RangeUnionArray()
        {
            return Enumerable.Range(20, 100).Union(ArrayItems2);
        } //EndMethod

        public IEnumerable<int> RangeUnionArrayRewritten()
        {
            return Enumerable.Range(20, 100).Union(ArrayItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RepeatUnionArray()
        {
            return Enumerable.Repeat(20, 100).Union(ArrayItems2);
        } //EndMethod

        public IEnumerable<int> RepeatUnionArrayRewritten()
        {
            return Enumerable.Repeat(20, 100).Union(ArrayItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EmptyUnionArray()
        {
            return Enumerable.Empty<int>().Union(ArrayItems2);
        } //EndMethod

        public IEnumerable<int> EmptyUnionArrayRewritten()
        {
            return Enumerable.Empty<int>().Union(ArrayItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RangeEmpty2Array()
        {
            return ArrayItems.Where(x => false).Union(ArrayItems2);
        } //EndMethod

        public IEnumerable<int> RangeEmpty2ArrayRewritten()
        {
            return ArrayItems.Where(x => false).Union(ArrayItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayUnionRange()
        {
            return ArrayItems.Union(Enumerable.Range(70, 260));
        } //EndMethod

        public IEnumerable<int> ArrayUnionRangeRewritten()
        {
            return ArrayItems.Union(Enumerable.Range(70, 260));
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayUnionRepeat()
        {
            return ArrayItems.Union(Enumerable.Repeat(70, 100));
        } //EndMethod

        public IEnumerable<int> ArrayUnionRepeatRewritten()
        {
            return ArrayItems.Union(Enumerable.Repeat(70, 100));
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayUnionEmpty()
        {
            return ArrayItems.Union(Enumerable.Empty<int>());
        } //EndMethod

        public IEnumerable<int> ArrayUnionEmptyRewritten()
        {
            return ArrayItems.Union(Enumerable.Empty<int>());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayUnionEmpty2()
        {
            return ArrayItems.Union(ArrayItems2.Where(x => false));
        } //EndMethod

        public IEnumerable<int> ArrayUnionEmpty2Rewritten()
        {
            return ArrayItems.Union(ArrayItems2.Where(x => false));
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayUnionAll()
        {
            return ArrayItems.Union(Enumerable.Range(0, 1000));
        } //EndMethod

        public IEnumerable<int> ArrayUnionAllRewritten()
        {
            return ArrayItems.Union(Enumerable.Range(0, 1000));
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayUnionNull()
        {
            return ArrayItems.Union(null);
        } //EndMethod

        public IEnumerable<int> ArrayUnionNullRewritten()
        {
            return ArrayItems.Union(null);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayUnionArrayUnionEnumerable()
        {
            return ArrayItems.Union(ArrayItems).Union(EnumerableItems2);
        } //EndMethod

        public IEnumerable<int> ArrayUnionArrayUnionEnumerableRewritten()
        {
            return ArrayItems.Union(ArrayItems).Union(EnumerableItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayUnionArrayUnionEnumerable2()
        {
            return ArrayItems.Union(ArrayItems.Union(EnumerableItems2));
        } //EndMethod

        public IEnumerable<int> ArrayUnionArrayUnionEnumerable2Rewritten()
        {
            return ArrayItems.Union(ArrayItems.Union(EnumerableItems2));
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayDistinctUnionArrayDistinct()
        {
            return ArrayItems.Distinct().Union(ArrayItems.Distinct());
        } //EndMethod

        public IEnumerable<int> ArrayDistinctUnionArrayDistinctRewritten()
        {
            return ArrayItems.Distinct().Union(ArrayItems.Distinct());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayDistinctUnionArrayDistinctDistinct()
        {
            return ArrayItems.Distinct().Union(ArrayItems.Distinct()).Distinct();
        } //EndMethod

        public IEnumerable<int> ArrayDistinctUnionArrayDistinctDistinctRewritten()
        {
            return ArrayItems.Distinct().Union(ArrayItems.Distinct()).Distinct();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayDistinctUnionArrayDistinctDistinct2()
        {
            return ArrayItems.Distinct(EqualityComparer<int>.Default).Union(ArrayItems.Distinct(EqualityComparer<int>.Default)).Distinct(EqualityComparer<int>.Default);
        } //EndMethod

        public IEnumerable<int> ArrayDistinctUnionArrayDistinctDistinct2Rewritten()
        {
            return ArrayItems.Distinct(EqualityComparer<int>.Default).Union(ArrayItems.Distinct(EqualityComparer<int>.Default)).Distinct(EqualityComparer<int>.Default);
        } //EndMethod

    }
}