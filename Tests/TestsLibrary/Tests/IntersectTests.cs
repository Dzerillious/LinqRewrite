using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class IntersectTests
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
            TestsExtensions.TestEquals(nameof(ArrayIntersectArray), ArrayIntersectArray, ArrayIntersectArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectSimpleList), ArrayIntersectSimpleList, ArrayIntersectSimpleListRewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectEnumerable), ArrayIntersectEnumerable, ArrayIntersectEnumerableRewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectMethod), ArrayIntersectMethod, ArrayIntersectMethodRewritten);
            TestsExtensions.TestEquals(nameof(SimpleListIntersectArray), SimpleListIntersectArray, SimpleListIntersectArrayRewritten);
            TestsExtensions.TestEquals(nameof(SimpleListIntersectSimpleList), SimpleListIntersectSimpleList, SimpleListIntersectSimpleListRewritten);
            TestsExtensions.TestEquals(nameof(SimpleListIntersectEnumerable), SimpleListIntersectEnumerable, SimpleListIntersectEnumerableRewritten);
            TestsExtensions.TestEquals(nameof(SimpleListIntersectMethod), SimpleListIntersectMethod, SimpleListIntersectMethodRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableIntersectArray), EnumerableIntersectArray, EnumerableIntersectArrayRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableIntersectSimpleList), EnumerableIntersectSimpleList, EnumerableIntersectSimpleListRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableIntersectEnumerable), EnumerableIntersectEnumerable, EnumerableIntersectEnumerableRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableIntersectMethod), EnumerableIntersectMethod, EnumerableIntersectMethodRewritten);
            TestsExtensions.TestEquals(nameof(MethodIntersectArray), MethodIntersectArray, MethodIntersectArrayRewritten);
            TestsExtensions.TestEquals(nameof(MethodIntersectSimpleList), MethodIntersectSimpleList, MethodIntersectSimpleListRewritten);
            TestsExtensions.TestEquals(nameof(MethodIntersectEnumerable), MethodIntersectEnumerable, MethodIntersectEnumerableRewritten);
            TestsExtensions.TestEquals(nameof(MethodIntersectMethod), MethodIntersectMethod, MethodIntersectMethodRewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectArrayToArray), ArrayIntersectArrayToArray, ArrayIntersectArrayToArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectSimpleListToArray), ArrayIntersectSimpleListToArray, ArrayIntersectSimpleListToArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectEnumerableToArray), ArrayIntersectEnumerableToArray, ArrayIntersectEnumerableToArrayRewritten);
            TestsExtensions.TestEquals(nameof(SimpleListIntersectArrayToArray), SimpleListIntersectArrayToArray, SimpleListIntersectArrayToArrayRewritten);
            TestsExtensions.TestEquals(nameof(SimpleListIntersectSimpleListToArray), SimpleListIntersectSimpleListToArray, SimpleListIntersectSimpleListToArrayRewritten);
            TestsExtensions.TestEquals(nameof(SimpleListIntersectEnumerableToArray), SimpleListIntersectEnumerableToArray, SimpleListIntersectEnumerableToArrayRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableIntersectArrayToArray), EnumerableIntersectArrayToArray, EnumerableIntersectArrayToArrayRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableIntersectSimpleListToArray), EnumerableIntersectSimpleListToArray, EnumerableIntersectSimpleListToArrayRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableIntersectEnumerableToArray), EnumerableIntersectEnumerableToArray, EnumerableIntersectEnumerableToArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArraySelectIntersectArray), ArraySelectIntersectArray, ArraySelectIntersectArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArraySelectIntersectArraySelect), ArraySelectIntersectArraySelect, ArraySelectIntersectArraySelectRewritten);
            TestsExtensions.TestEquals(nameof(ArrayWhereIntersectArrayWhere), ArrayWhereIntersectArrayWhere, ArrayWhereIntersectArrayWhereRewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectArrayCount), ArrayIntersectArrayCount, ArrayIntersectArrayCountRewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectArrayCount2), ArrayIntersectArrayCount2, ArrayIntersectArrayCount2Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectArraySum), ArrayIntersectArraySum, ArrayIntersectArraySumRewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectArraySum2), ArrayIntersectArraySum2, ArrayIntersectArraySum2Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectArrayDistinct), ArrayIntersectArrayDistinct, ArrayIntersectArrayDistinctRewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectArrayDistinct2), ArrayIntersectArrayDistinct2, ArrayIntersectArrayDistinct2Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectArrayElementAt), ArrayIntersectArrayElementAt, ArrayIntersectArrayElementAtRewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectArrayElementAtOrDefault), ArrayIntersectArrayElementAtOrDefault, ArrayIntersectArrayElementAtOrDefaultRewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectArrayFirst), ArrayIntersectArrayFirst, ArrayIntersectArrayFirstRewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectArrayFirstOrDefault), ArrayIntersectArrayFirstOrDefault, ArrayIntersectArrayFirstOrDefaultRewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectArrayLast), ArrayIntersectArrayLast, ArrayIntersectArrayLastRewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectArrayLastOrDefault), ArrayIntersectArrayLastOrDefault, ArrayIntersectArrayLastOrDefaultRewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectArraySingle), ArrayIntersectArraySingle, ArrayIntersectArraySingleRewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectArraySingle2), ArrayIntersectArraySingle2, ArrayIntersectArraySingle2Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectArraySingleOrDefault), ArrayIntersectArraySingleOrDefault, ArrayIntersectArraySingleOrDefaultRewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectArrayMin), ArrayIntersectArrayMin, ArrayIntersectArrayMinRewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectArrayMin2), ArrayIntersectArrayMin2, ArrayIntersectArrayMin2Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectArrayMax), ArrayIntersectArrayMax, ArrayIntersectArrayMaxRewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectArrayMax2), ArrayIntersectArrayMax2, ArrayIntersectArrayMax2Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectArrayLongCount), ArrayIntersectArrayLongCount, ArrayIntersectArrayLongCountRewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectArrayLongCount2), ArrayIntersectArrayLongCount2, ArrayIntersectArrayLongCount2Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectArrayContains), ArrayIntersectArrayContains, ArrayIntersectArrayContainsRewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectArrayAverage), ArrayIntersectArrayAverage, ArrayIntersectArrayAverageRewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectArrayAverage2), ArrayIntersectArrayAverage2, ArrayIntersectArrayAverage2Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectArrayContains2), ArrayIntersectArrayContains2, ArrayIntersectArrayContains2Rewritten);
            TestsExtensions.TestEquals(nameof(SelectWhereArrayIntersectSelectWhereArrayContains), SelectWhereArrayIntersectSelectWhereArrayContains, SelectWhereArrayIntersectSelectWhereArrayContainsRewritten);
            TestsExtensions.TestEquals(nameof(RangeIntersectArray), RangeIntersectArray, RangeIntersectArrayRewritten);
            TestsExtensions.TestEquals(nameof(RepeatIntersectArray), RepeatIntersectArray, RepeatIntersectArrayRewritten);
            TestsExtensions.TestEquals(nameof(EmptyIntersectArray), EmptyIntersectArray, EmptyIntersectArrayRewritten);
            TestsExtensions.TestEquals(nameof(RangeEmpty2Array), RangeEmpty2Array, RangeEmpty2ArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectRange), ArrayIntersectRange, ArrayIntersectRangeRewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectRepeat), ArrayIntersectRepeat, ArrayIntersectRepeatRewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectEmpty), ArrayIntersectEmpty, ArrayIntersectEmptyRewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectEmpty2), ArrayIntersectEmpty2, ArrayIntersectEmpty2Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectAll), ArrayIntersectAll, ArrayIntersectAllRewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectNull), ArrayIntersectNull, ArrayIntersectNullRewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectArrayIntersectEnumerable), ArrayIntersectArrayIntersectEnumerable, ArrayIntersectArrayIntersectEnumerableRewritten);
            TestsExtensions.TestEquals(nameof(ArrayIntersectArrayIntersectEnumerable2), ArrayIntersectArrayIntersectEnumerable2, ArrayIntersectArrayIntersectEnumerable2Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayDistinctIntersectArrayDistinct), ArrayDistinctIntersectArrayDistinct, ArrayDistinctIntersectArrayDistinctRewritten);
            TestsExtensions.TestEquals(nameof(ArrayDistinctIntersectArrayDistinctDistinct), ArrayDistinctIntersectArrayDistinctDistinct, ArrayDistinctIntersectArrayDistinctDistinctRewritten);
            TestsExtensions.TestEquals(nameof(ArrayDistinctIntersectArrayDistinctDistinct2), ArrayDistinctIntersectArrayDistinctDistinct2, ArrayDistinctIntersectArrayDistinctDistinct2Rewritten);
        }

        [NoRewrite]
        public IEnumerable<int> ArrayIntersectArray()
        {
            return ArrayItems.Intersect(ArrayItems2);
        } //EndMethod

        public IEnumerable<int> ArrayIntersectArrayRewritten()
        {
            return ArrayItems.Intersect(ArrayItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayIntersectSimpleList()
        {
            return ArrayItems.Intersect(SimpleListItems2);
        } //EndMethod

        public IEnumerable<int> ArrayIntersectSimpleListRewritten()
        {
            return ArrayItems.Intersect(SimpleListItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayIntersectEnumerable()
        {
            return ArrayItems.Intersect(EnumerableItems2);
        } //EndMethod

        public IEnumerable<int> ArrayIntersectEnumerableRewritten()
        {
            return ArrayItems.Intersect(EnumerableItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayIntersectMethod()
        {
            return ArrayItems.Intersect(MethodEnumerable2());
        } //EndMethod

        public IEnumerable<int> ArrayIntersectMethodRewritten()
        {
            return ArrayItems.Intersect(MethodEnumerable2());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListIntersectArray()
        {
            return SimpleListItems.Intersect(ArrayItems2);
        } //EndMethod

        public IEnumerable<int> SimpleListIntersectArrayRewritten()
        {
            return SimpleListItems.Intersect(ArrayItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListIntersectSimpleList()
        {
            return SimpleListItems.Intersect(SimpleListItems2);
        } //EndMethod

        public IEnumerable<int> SimpleListIntersectSimpleListRewritten()
        {
            return SimpleListItems.Intersect(SimpleListItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListIntersectEnumerable()
        {
            return SimpleListItems.Intersect(EnumerableItems2);
        } //EndMethod

        public IEnumerable<int> SimpleListIntersectEnumerableRewritten()
        {
            return SimpleListItems.Intersect(EnumerableItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListIntersectMethod()
        {
            return SimpleListItems.Intersect(MethodEnumerable2());
        } //EndMethod

        public IEnumerable<int> SimpleListIntersectMethodRewritten()
        {
            return SimpleListItems.Intersect(MethodEnumerable2());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableIntersectArray()
        {
            return EnumerableItems.Intersect(ArrayItems2);
        } //EndMethod

        public IEnumerable<int> EnumerableIntersectArrayRewritten()
        {
            return EnumerableItems.Intersect(ArrayItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableIntersectSimpleList()
        {
            return EnumerableItems.Intersect(SimpleListItems2);
        } //EndMethod

        public IEnumerable<int> EnumerableIntersectSimpleListRewritten()
        {
            return EnumerableItems.Intersect(SimpleListItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableIntersectEnumerable()
        {
            return EnumerableItems.Intersect(EnumerableItems2);
        } //EndMethod

        public IEnumerable<int> EnumerableIntersectEnumerableRewritten()
        {
            return EnumerableItems.Intersect(EnumerableItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableIntersectMethod()
        {
            return EnumerableItems.Intersect(MethodEnumerable2());
        } //EndMethod

        public IEnumerable<int> EnumerableIntersectMethodRewritten()
        {
            return EnumerableItems.Intersect(MethodEnumerable2());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> MethodIntersectArray()
        {
            return MethodEnumerable().Intersect(ArrayItems2);
        } //EndMethod

        public IEnumerable<int> MethodIntersectArrayRewritten()
        {
            return MethodEnumerable().Intersect(ArrayItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> MethodIntersectSimpleList()
        {
            return MethodEnumerable().Intersect(SimpleListItems2);
        } //EndMethod

        public IEnumerable<int> MethodIntersectSimpleListRewritten()
        {
            return MethodEnumerable().Intersect(SimpleListItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> MethodIntersectEnumerable()
        {
            return MethodEnumerable().Intersect(EnumerableItems2);
        } //EndMethod

        public IEnumerable<int> MethodIntersectEnumerableRewritten()
        {
            return MethodEnumerable().Intersect(EnumerableItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> MethodIntersectMethod()
        {
            return MethodEnumerable().Intersect(MethodEnumerable2());
        } //EndMethod

        public IEnumerable<int> MethodIntersectMethodRewritten()
        {
            return MethodEnumerable().Intersect(MethodEnumerable2());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayIntersectArrayToArray()
        {
            return ArrayItems.Intersect(ArrayItems2).ToArray();
        } //EndMethod

        public IEnumerable<int> ArrayIntersectArrayToArrayRewritten()
        {
            return ArrayItems.Intersect(ArrayItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayIntersectSimpleListToArray()
        {
            return ArrayItems.Intersect(SimpleListItems2).ToArray();
        } //EndMethod

        public IEnumerable<int> ArrayIntersectSimpleListToArrayRewritten()
        {
            return ArrayItems.Intersect(SimpleListItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayIntersectEnumerableToArray()
        {
            return ArrayItems.Intersect(EnumerableItems2).ToArray();
        } //EndMethod

        public IEnumerable<int> ArrayIntersectEnumerableToArrayRewritten()
        {
            return ArrayItems.Intersect(EnumerableItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListIntersectArrayToArray()
        {
            return SimpleListItems.Intersect(ArrayItems2).ToArray();
        } //EndMethod

        public IEnumerable<int> SimpleListIntersectArrayToArrayRewritten()
        {
            return SimpleListItems.Intersect(ArrayItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListIntersectSimpleListToArray()
        {
            return SimpleListItems.Intersect(SimpleListItems2).ToArray();
        } //EndMethod

        public IEnumerable<int> SimpleListIntersectSimpleListToArrayRewritten()
        {
            return SimpleListItems.Intersect(SimpleListItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListIntersectEnumerableToArray()
        {
            return SimpleListItems.Intersect(EnumerableItems2).ToArray();
        } //EndMethod

        public IEnumerable<int> SimpleListIntersectEnumerableToArrayRewritten()
        {
            return SimpleListItems.Intersect(EnumerableItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableIntersectArrayToArray()
        {
            return EnumerableItems.Intersect(ArrayItems2).ToArray();
        } //EndMethod

        public IEnumerable<int> EnumerableIntersectArrayToArrayRewritten()
        {
            return EnumerableItems.Intersect(ArrayItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableIntersectSimpleListToArray()
        {
            return EnumerableItems.Intersect(SimpleListItems2).ToArray();
        } //EndMethod

        public IEnumerable<int> EnumerableIntersectSimpleListToArrayRewritten()
        {
            return EnumerableItems.Intersect(SimpleListItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableIntersectEnumerableToArray()
        {
            return EnumerableItems.Intersect(EnumerableItems2).ToArray();
        } //EndMethod

        public IEnumerable<int> EnumerableIntersectEnumerableToArrayRewritten()
        {
            return EnumerableItems.Intersect(EnumerableItems2).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArraySelectIntersectArray()
        {
            return ArrayItems.Select(x => x + 50).Intersect(ArrayItems2);
        } //EndMethod

        public IEnumerable<int> ArraySelectIntersectArrayRewritten()
        {
            return ArrayItems.Select(x => x + 50).Intersect(ArrayItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArraySelectIntersectArraySelect()
        {
            return ArrayItems.Select(x => x + 50).Intersect(ArrayItems2.Select(x => x + 50));
        } //EndMethod

        public IEnumerable<int> ArraySelectIntersectArraySelectRewritten()
        {
            return ArrayItems.Select(x => x + 50).Intersect(ArrayItems2.Select(x => x + 50));
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayWhereIntersectArrayWhere()
        {
            return ArrayItems.Where(x => x > 50).Intersect(ArrayItems2.Where(x => x > 50));
        } //EndMethod

        public IEnumerable<int> ArrayWhereIntersectArrayWhereRewritten()
        {
            return ArrayItems.Where(x => x > 50).Intersect(ArrayItems2.Where(x => x > 50));
        } //EndMethod


        [NoRewrite]
        public int ArrayIntersectArrayCount()
        {
            return ArrayItems.Intersect(ArrayItems2).Count();
        } //EndMethod

        public int ArrayIntersectArrayCountRewritten()
        {
            return ArrayItems.Intersect(ArrayItems2).Count();
        } //EndMethod


        [NoRewrite]
        public int ArrayIntersectArrayCount2()
        {
            return ArrayItems.Intersect(ArrayItems2).Count(x => x > 70);
        } //EndMethod

        public int ArrayIntersectArrayCount2Rewritten()
        {
            return ArrayItems.Intersect(ArrayItems2).Count(x => x > 70);
        } //EndMethod


        [NoRewrite]
        public int ArrayIntersectArraySum()
        {
            return ArrayItems.Intersect(ArrayItems2).Sum();
        } //EndMethod

        public int ArrayIntersectArraySumRewritten()
        {
            return ArrayItems.Intersect(ArrayItems2).Sum();
        } //EndMethod


        [NoRewrite]
        public int ArrayIntersectArraySum2()
        {
            return ArrayItems.Intersect(ArrayItems2).Sum(x => x + 10);
        } //EndMethod

        public int ArrayIntersectArraySum2Rewritten()
        {
            return ArrayItems.Intersect(ArrayItems2).Sum(x => x + 10);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayIntersectArrayDistinct()
        {
            return ArrayItems.Intersect(ArrayItems2).Distinct();
        } //EndMethod

        public IEnumerable<int> ArrayIntersectArrayDistinctRewritten()
        {
            return ArrayItems.Intersect(ArrayItems2).Distinct();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayIntersectArrayDistinct2()
        {
            return ArrayItems.Intersect(ArrayItems2).Distinct(EqualityComparer<int>.Default);
        } //EndMethod

        public IEnumerable<int> ArrayIntersectArrayDistinct2Rewritten()
        {
            return ArrayItems.Intersect(ArrayItems2).Distinct(EqualityComparer<int>.Default);
        } //EndMethod


        [NoRewrite]
        public int ArrayIntersectArrayElementAt()
        {
            return ArrayItems.Intersect(ArrayItems2).ElementAt(45);
        } //EndMethod

        public int ArrayIntersectArrayElementAtRewritten()
        {
            return ArrayItems.Intersect(ArrayItems2).ElementAt(45);
        } //EndMethod


        [NoRewrite]
        public int ArrayIntersectArrayElementAtOrDefault()
        {
            return ArrayItems.Intersect(ArrayItems2).ElementAtOrDefault(45);
        } //EndMethod

        public int ArrayIntersectArrayElementAtOrDefaultRewritten()
        {
            return ArrayItems.Intersect(ArrayItems2).ElementAtOrDefault(45);
        } //EndMethod


        [NoRewrite]
        public int ArrayIntersectArrayFirst()
        {
            return ArrayItems.Intersect(ArrayItems2).First();
        } //EndMethod

        public int ArrayIntersectArrayFirstRewritten()
        {
            return ArrayItems.Intersect(ArrayItems2).First();
        } //EndMethod


        [NoRewrite]
        public int ArrayIntersectArrayFirstOrDefault()
        {
            return ArrayItems.Intersect(ArrayItems2).FirstOrDefault();
        } //EndMethod

        public int ArrayIntersectArrayFirstOrDefaultRewritten()
        {
            return ArrayItems.Intersect(ArrayItems2).FirstOrDefault();
        } //EndMethod


        [NoRewrite]
        public int ArrayIntersectArrayLast()
        {
            return ArrayItems.Intersect(ArrayItems2).Last();
        } //EndMethod

        public int ArrayIntersectArrayLastRewritten()
        {
            return ArrayItems.Intersect(ArrayItems2).Last();
        } //EndMethod


        [NoRewrite]
        public int ArrayIntersectArrayLastOrDefault()
        {
            return ArrayItems.Intersect(ArrayItems2).LastOrDefault();
        } //EndMethod

        public int ArrayIntersectArrayLastOrDefaultRewritten()
        {
            return ArrayItems.Intersect(ArrayItems2).LastOrDefault();
        } //EndMethod


        [NoRewrite]
        public int ArrayIntersectArraySingle()
        {
            return ArrayItems.Intersect(ArrayItems2).Single();
        } //EndMethod

        public int ArrayIntersectArraySingleRewritten()
        {
            return ArrayItems.Intersect(ArrayItems2).Single();
        } //EndMethod


        [NoRewrite]
        public int ArrayIntersectArraySingle2()
        {
            return ArrayItems.Intersect(ArrayItems2).Single(x => x == 76);
        } //EndMethod

        public int ArrayIntersectArraySingle2Rewritten()
        {
            return ArrayItems.Intersect(ArrayItems2).Single(x => x == 76);
        } //EndMethod


        [NoRewrite]
        public int ArrayIntersectArraySingleOrDefault()
        {
            return ArrayItems.Intersect(ArrayItems2).SingleOrDefault();
        } //EndMethod

        public int ArrayIntersectArraySingleOrDefaultRewritten()
        {
            return ArrayItems.Intersect(ArrayItems2).SingleOrDefault();
        } //EndMethod


        [NoRewrite]
        public int ArrayIntersectArrayMin()
        {
            return ArrayItems.Intersect(ArrayItems2).Min();
        } //EndMethod

        public int ArrayIntersectArrayMinRewritten()
        {
            return ArrayItems.Intersect(ArrayItems2).Min();
        } //EndMethod


        [NoRewrite]
        public decimal ArrayIntersectArrayMin2()
        {
            return ArrayItems.Intersect(ArrayItems2).Min(x => x + 2m);
        } //EndMethod

        public decimal ArrayIntersectArrayMin2Rewritten()
        {
            return ArrayItems.Intersect(ArrayItems2).Min(x => x + 2m);
        } //EndMethod


        [NoRewrite]
        public int ArrayIntersectArrayMax()
        {
            return ArrayItems.Intersect(ArrayItems2).Max();
        } //EndMethod

        public int ArrayIntersectArrayMaxRewritten()
        {
            return ArrayItems.Intersect(ArrayItems2).Max();
        } //EndMethod


        [NoRewrite]
        public decimal ArrayIntersectArrayMax2()
        {
            return ArrayItems.Intersect(ArrayItems2).Max(x => x + 2m);
        } //EndMethod

        public decimal ArrayIntersectArrayMax2Rewritten()
        {
            return ArrayItems.Intersect(ArrayItems2).Max(x => x + 2m);
        } //EndMethod


        [NoRewrite]
        public long ArrayIntersectArrayLongCount()
        {
            return ArrayItems.Intersect(ArrayItems2).LongCount();
        } //EndMethod

        public long ArrayIntersectArrayLongCountRewritten()
        {
            return ArrayItems.Intersect(ArrayItems2).LongCount();
        } //EndMethod


        [NoRewrite]
        public long ArrayIntersectArrayLongCount2()
        {
            return ArrayItems.Intersect(ArrayItems2).LongCount(x => x > 50);
        } //EndMethod

        public long ArrayIntersectArrayLongCount2Rewritten()
        {
            return ArrayItems.Intersect(ArrayItems2).LongCount(x => x > 50);
        } //EndMethod


        [NoRewrite]
        public bool ArrayIntersectArrayContains()
        {
            return ArrayItems.Intersect(ArrayItems2).Contains(56);
        } //EndMethod

        public bool ArrayIntersectArrayContainsRewritten()
        {
            return ArrayItems.Intersect(ArrayItems2).Contains(56);
        } //EndMethod


        [NoRewrite]
        public double ArrayIntersectArrayAverage()
        {
            return ArrayItems.Intersect(ArrayItems2).Average();
        } //EndMethod

        public double ArrayIntersectArrayAverageRewritten()
        {
            return ArrayItems.Intersect(ArrayItems2).Average();
        } //EndMethod


        [NoRewrite]
        public double ArrayIntersectArrayAverage2()
        {
            return ArrayItems.Intersect(ArrayItems2).Average(x => x + 10);
        } //EndMethod

        public double ArrayIntersectArrayAverage2Rewritten()
        {
            return ArrayItems.Intersect(ArrayItems2).Average(x => x + 10);
        } //EndMethod


        [NoRewrite]
        public bool ArrayIntersectArrayContains2()
        {
            return ArrayItems.Intersect(ArrayItems2).Contains(56, EqualityComparer<int>.Default);
        } //EndMethod

        public bool ArrayIntersectArrayContains2Rewritten()
        {
            return ArrayItems.Intersect(ArrayItems2).Contains(56, EqualityComparer<int>.Default);
        } //EndMethod


        [NoRewrite]
        public bool SelectWhereArrayIntersectSelectWhereArrayContains()
        {
            return ArrayItems.Select(x => x + 10).Where(x => x > 80).Intersect(ArrayItems2.Select(x => x + 10).Where(x => x > 80)).Contains(112);
        } //EndMethod

        public bool SelectWhereArrayIntersectSelectWhereArrayContainsRewritten()
        {
            return ArrayItems.Select(x => x + 10).Where(x => x > 80).Intersect(ArrayItems2.Select(x => x + 10).Where(x => x > 80)).Contains(112);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RangeIntersectArray()
        {
            return Enumerable.Range(20, 100).Intersect(ArrayItems2);
        } //EndMethod

        public IEnumerable<int> RangeIntersectArrayRewritten()
        {
            return Enumerable.Range(20, 100).Intersect(ArrayItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RepeatIntersectArray()
        {
            return Enumerable.Repeat(20, 100).Intersect(ArrayItems2);
        } //EndMethod

        public IEnumerable<int> RepeatIntersectArrayRewritten()
        {
            return Enumerable.Repeat(20, 100).Intersect(ArrayItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EmptyIntersectArray()
        {
            return Enumerable.Empty<int>().Intersect(ArrayItems2);
        } //EndMethod

        public IEnumerable<int> EmptyIntersectArrayRewritten()
        {
            return Enumerable.Empty<int>().Intersect(ArrayItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RangeEmpty2Array()
        {
            return ArrayItems.Where(x => false).Intersect(ArrayItems2);
        } //EndMethod

        public IEnumerable<int> RangeEmpty2ArrayRewritten()
        {
            return ArrayItems.Where(x => false).Intersect(ArrayItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayIntersectRange()
        {
            return ArrayItems.Intersect(Enumerable.Range(70, 260));
        } //EndMethod

        public IEnumerable<int> ArrayIntersectRangeRewritten()
        {
            return ArrayItems.Intersect(Enumerable.Range(70, 260));
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayIntersectRepeat()
        {
            return ArrayItems.Intersect(Enumerable.Repeat(70, 100));
        } //EndMethod

        public IEnumerable<int> ArrayIntersectRepeatRewritten()
        {
            return ArrayItems.Intersect(Enumerable.Repeat(70, 100));
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayIntersectEmpty()
        {
            return ArrayItems.Intersect(Enumerable.Empty<int>());
        } //EndMethod

        public IEnumerable<int> ArrayIntersectEmptyRewritten()
        {
            return ArrayItems.Intersect(Enumerable.Empty<int>());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayIntersectEmpty2()
        {
            return ArrayItems.Intersect(ArrayItems2.Where(x => false));
        } //EndMethod

        public IEnumerable<int> ArrayIntersectEmpty2Rewritten()
        {
            return ArrayItems.Intersect(ArrayItems2.Where(x => false));
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayIntersectAll()
        {
            return ArrayItems.Intersect(Enumerable.Range(0, 1000));
        } //EndMethod

        public IEnumerable<int> ArrayIntersectAllRewritten()
        {
            return ArrayItems.Intersect(Enumerable.Range(0, 1000));
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayIntersectNull()
        {
            return ArrayItems.Intersect(null);
        } //EndMethod

        public IEnumerable<int> ArrayIntersectNullRewritten()
        {
            return ArrayItems.Intersect(null);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayIntersectArrayIntersectEnumerable()
        {
            return ArrayItems.Intersect(ArrayItems).Intersect(EnumerableItems2);
        } //EndMethod

        public IEnumerable<int> ArrayIntersectArrayIntersectEnumerableRewritten()
        {
            return ArrayItems.Intersect(ArrayItems).Intersect(EnumerableItems2);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayIntersectArrayIntersectEnumerable2()
        {
            return ArrayItems.Intersect(ArrayItems.Intersect(EnumerableItems2));
        } //EndMethod

        public IEnumerable<int> ArrayIntersectArrayIntersectEnumerable2Rewritten()
        {
            return ArrayItems.Intersect(ArrayItems.Intersect(EnumerableItems2));
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayDistinctIntersectArrayDistinct()
        {
            return ArrayItems.Distinct().Intersect(ArrayItems.Distinct());
        } //EndMethod

        public IEnumerable<int> ArrayDistinctIntersectArrayDistinctRewritten()
        {
            return ArrayItems.Distinct().Intersect(ArrayItems.Distinct());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayDistinctIntersectArrayDistinctDistinct()
        {
            return ArrayItems.Distinct().Intersect(ArrayItems.Distinct()).Distinct();
        } //EndMethod

        public IEnumerable<int> ArrayDistinctIntersectArrayDistinctDistinctRewritten()
        {
            return ArrayItems.Distinct().Intersect(ArrayItems.Distinct()).Distinct();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayDistinctIntersectArrayDistinctDistinct2()
        {
            return ArrayItems.Distinct(EqualityComparer<int>.Default).Intersect(ArrayItems.Distinct(EqualityComparer<int>.Default)).Distinct(EqualityComparer<int>.Default);
        } //EndMethod

        public IEnumerable<int> ArrayDistinctIntersectArrayDistinctDistinct2Rewritten()
        {
            return ArrayItems.Distinct(EqualityComparer<int>.Default).Intersect(ArrayItems.Distinct(EqualityComparer<int>.Default)).Distinct(EqualityComparer<int>.Default);
        } //EndMethod

    }
}