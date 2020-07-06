using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class GroupJoinTests
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
            TestsExtensions.TestEquals(nameof(ArrayGroupJoin), ArrayGroupJoin, ArrayGroupJoinRewritten);
            TestsExtensions.TestEquals(nameof(ArrayGroupJoinToArray), ArrayGroupJoinToArray, ArrayGroupJoinToArrayRewritten);
            TestsExtensions.TestEquals(nameof(SimpleListGroupJoin), SimpleListGroupJoin, SimpleListGroupJoinRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableGroupJoin), EnumerableGroupJoin, EnumerableGroupJoinRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableGroupJoinToArray), EnumerableGroupJoinToArray, EnumerableGroupJoinToArrayRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableMethodGroupJoin), EnumerableMethodGroupJoin, EnumerableMethodGroupJoinRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableMethodGroupJoinToArray), EnumerableMethodGroupJoinToArray, EnumerableMethodGroupJoinToArrayRewritten);
            TestsExtensions.TestEquals(nameof(RangeGroupJoin), RangeGroupJoin, RangeGroupJoinRewritten);
            TestsExtensions.TestEquals(nameof(RangeGroupJoinToArray), RangeGroupJoinToArray, RangeGroupJoinToArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArraySelectGroupJoin), ArraySelectGroupJoin, ArraySelectGroupJoinRewritten);
            TestsExtensions.TestEquals(nameof(ArrayWhereGroupJoin), ArrayWhereGroupJoin, ArrayWhereGroupJoinRewritten);
            TestsExtensions.TestEquals(nameof(ArrayGroupJoinWhereGroupJoin), ArrayGroupJoinWhereGroupJoin, ArrayGroupJoinWhereGroupJoinRewritten);
            TestsExtensions.TestEquals(nameof(ArrayGroupJoinConcatGroupJoin), ArrayGroupJoinConcatGroupJoin, ArrayGroupJoinConcatGroupJoinRewritten);
            TestsExtensions.TestEquals(nameof(ArrayGroupJoinConcatGroupJoind), ArrayGroupJoinConcatGroupJoind, ArrayGroupJoinConcatGroupJoindRewritten);
            TestsExtensions.TestEquals(nameof(ArrayGroupJoinConcatGroupJoindConcatArray), ArrayGroupJoinConcatGroupJoindConcatArray, ArrayGroupJoinConcatGroupJoindConcatArrayRewritten);

            TestsExtensions.TestEquals("ArrayConcatArrayGroupJoind", ArrayConcatArray, ArrayConcatArrayRewritten);
            TestsExtensions.TestEquals("ArrayConcatSimpleListGroupJoind", ArrayConcatSimpleList, ArrayConcatSimpleListRewritten);
            TestsExtensions.TestEquals("ArrayConcatEnumerableGroupJoind", ArrayConcatEnumerable, ArrayConcatEnumerableRewritten);
            TestsExtensions.TestEquals("ArrayConcatMethodGroupJoind", ArrayConcatMethod, ArrayConcatMethodRewritten);
            TestsExtensions.TestEquals("SimpleListConcatArrayGroupJoind", SimpleListConcatArray, SimpleListConcatArrayRewritten);
            TestsExtensions.TestEquals("SimpleListConcatSimpleListGroupJoind", SimpleListConcatSimpleList, SimpleListConcatSimpleListRewritten);
            TestsExtensions.TestEquals("SimpleListConcatEnumerableGroupJoind", SimpleListConcatEnumerable, SimpleListConcatEnumerableRewritten);
            TestsExtensions.TestEquals("SimpleListConcatMethodGroupJoind", SimpleListConcatMethod, SimpleListConcatMethodRewritten);
            TestsExtensions.TestEquals("EnumerableConcatArrayGroupJoind", EnumerableConcatArray, EnumerableConcatArrayRewritten);
            TestsExtensions.TestEquals("EnumerableConcatSimpleListGroupJoind", EnumerableConcatSimpleList, EnumerableConcatSimpleListRewritten);
            TestsExtensions.TestEquals("EnumerableConcatEnumerableGroupJoind", EnumerableConcatEnumerable, EnumerableConcatEnumerableRewritten);
            TestsExtensions.TestEquals("EnumerableConcatMethodGroupJoind", EnumerableConcatMethod, EnumerableConcatMethodRewritten);
            TestsExtensions.TestEquals("MethodConcatArrayGroupJoind", MethodConcatArray, MethodConcatArrayRewritten);
            TestsExtensions.TestEquals("MethodConcatSimpleListGroupJoind", MethodConcatSimpleList, MethodConcatSimpleListRewritten);
            TestsExtensions.TestEquals("MethodConcatEnumerableGroupJoind", MethodConcatEnumerable, MethodConcatEnumerableRewritten);
            TestsExtensions.TestEquals("MethodConcatMethodGroupJoind", MethodConcatMethod, MethodConcatMethodRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayToArrayGroupJoind", ArrayConcatArrayToArray, ArrayConcatArrayToArrayRewritten);
            TestsExtensions.TestEquals("ArrayConcatSimpleListToArrayGroupJoind", ArrayConcatSimpleListToArray, ArrayConcatSimpleListToArrayRewritten);
            TestsExtensions.TestEquals("ArrayConcatEnumerableToArrayGroupJoind", ArrayConcatEnumerableToArray, ArrayConcatEnumerableToArrayRewritten);
            TestsExtensions.TestEquals("SimpleListConcatArrayToArrayGroupJoind", SimpleListConcatArrayToArray, SimpleListConcatArrayToArrayRewritten);
            TestsExtensions.TestEquals("SimpleListConcatSimpleListToArrayGroupJoind", SimpleListConcatSimpleListToArray, SimpleListConcatSimpleListToArrayRewritten);
            TestsExtensions.TestEquals("SimpleListConcatEnumerableToArrayGroupJoind", SimpleListConcatEnumerableToArray, SimpleListConcatEnumerableToArrayRewritten);
            TestsExtensions.TestEquals("EnumerableConcatArrayToArrayGroupJoind", EnumerableConcatArrayToArray, EnumerableConcatArrayToArrayRewritten);
            TestsExtensions.TestEquals("EnumerableConcatSimpleListToArrayGroupJoind", EnumerableConcatSimpleListToArray, EnumerableConcatSimpleListToArrayRewritten);
            TestsExtensions.TestEquals("EnumerableConcatEnumerableToArrayGroupJoind", EnumerableConcatEnumerableToArray, EnumerableConcatEnumerableToArrayRewritten);
            TestsExtensions.TestEquals("ArraySelectConcatArrayGroupJoind", ArraySelectConcatArray, ArraySelectConcatArrayRewritten);
            TestsExtensions.TestEquals("ArraySelectConcatArraySelectGroupJoind", ArraySelectConcatArraySelect, ArraySelectConcatArraySelectRewritten);
            TestsExtensions.TestEquals("ArrayWhereConcatArrayWhereGroupJoind", ArrayWhereConcatArrayWhere, ArrayWhereConcatArrayWhereRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayCountGroupJoind", ArrayConcatArrayCount, ArrayConcatArrayCountRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayCount2GroupJoind", ArrayConcatArrayCount2, ArrayConcatArrayCount2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatArraySumGroupJoind", ArrayConcatArraySum, ArrayConcatArraySumRewritten);
            TestsExtensions.TestEquals("ArrayConcatArraySum2GroupJoind", ArrayConcatArraySum2, ArrayConcatArraySum2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayDistinctGroupJoind", ArrayConcatArrayDistinct, ArrayConcatArrayDistinctRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayDistinct2GroupJoind", ArrayConcatArrayDistinct2, ArrayConcatArrayDistinct2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayElementAtGroupJoind", ArrayConcatArrayElementAt, ArrayConcatArrayElementAtRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayElementAtOrDefaultGroupJoind", ArrayConcatArrayElementAtOrDefault, ArrayConcatArrayElementAtOrDefaultRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayFirstGroupJoind", ArrayConcatArrayFirst, ArrayConcatArrayFirstRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayFirstOrDefaultGroupJoind", ArrayConcatArrayFirstOrDefault, ArrayConcatArrayFirstOrDefaultRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayLastGroupJoind", ArrayConcatArrayLast, ArrayConcatArrayLastRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayLastOrDefaultGroupJoind", ArrayConcatArrayLastOrDefault, ArrayConcatArrayLastOrDefaultRewritten);
            TestsExtensions.TestEquals("ArrayConcatArraySingleGroupJoind", ArrayConcatArraySingle, ArrayConcatArraySingleRewritten);
            TestsExtensions.TestEquals("ArrayConcatArraySingle2GroupJoind", ArrayConcatArraySingle2, ArrayConcatArraySingle2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatArraySingleOrDefaultGroupJoind", ArrayConcatArraySingleOrDefault, ArrayConcatArraySingleOrDefaultRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayMinGroupJoind", ArrayConcatArrayMin, ArrayConcatArrayMinRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayMin2GroupJoind", ArrayConcatArrayMin2, ArrayConcatArrayMin2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayMaxGroupJoind", ArrayConcatArrayMax, ArrayConcatArrayMaxRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayMax2GroupJoind", ArrayConcatArrayMax2, ArrayConcatArrayMax2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayLongCountGroupJoind", ArrayConcatArrayLongCount, ArrayConcatArrayLongCountRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayLongCount2GroupJoind", ArrayConcatArrayLongCount2, ArrayConcatArrayLongCount2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayContainsGroupJoind", ArrayConcatArrayContains, ArrayConcatArrayContainsRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayAverageGroupJoind", ArrayConcatArrayAverage, ArrayConcatArrayAverageRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayAverage2GroupJoind", ArrayConcatArrayAverage2, ArrayConcatArrayAverage2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayContains2GroupJoind", ArrayConcatArrayContains2, ArrayConcatArrayContains2Rewritten);
            TestsExtensions.TestEquals("SelectWhereArrayConcatSelectWhereArrayContainsGroupJoind", SelectWhereArrayConcatSelectWhereArrayContains, SelectWhereArrayConcatSelectWhereArrayContainsRewritten);
            TestsExtensions.TestEquals("RangeConcatArrayGroupJoind", RangeConcatArray, RangeConcatArrayRewritten);
            TestsExtensions.TestEquals("RepeatConcatArrayGroupJoind", RepeatConcatArray, RepeatConcatArrayRewritten);
            TestsExtensions.TestEquals("EmptyConcatArrayGroupJoind", EmptyConcatArray, EmptyConcatArrayRewritten);
            TestsExtensions.TestEquals("RangeEmpty2ArrayGroupJoind", RangeEmpty2Array, RangeEmpty2ArrayRewritten);
            TestsExtensions.TestEquals("ArrayConcatRangeGroupJoind", ArrayConcatRange, ArrayConcatRangeRewritten);
            TestsExtensions.TestEquals("ArrayConcatRepeatGroupJoind", ArrayConcatRepeat, ArrayConcatRepeatRewritten);
            TestsExtensions.TestEquals("ArrayConcatEmptyGroupJoind", ArrayConcatEmpty, ArrayConcatEmptyRewritten);
            TestsExtensions.TestEquals("ArrayConcatEmpty2GroupJoind", ArrayConcatEmpty2, ArrayConcatEmpty2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatAllGroupJoind", ArrayConcatAll, ArrayConcatAllRewritten);
            TestsExtensions.TestEquals("ArrayConcatNullGroupJoind", ArrayConcatNull, ArrayConcatNullRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayConcatEnumerableGroupJoind", ArrayConcatArrayConcatEnumerable, ArrayConcatArrayConcatEnumerableRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayConcatEnumerable2GroupJoind", ArrayConcatArrayConcatEnumerable2, ArrayConcatArrayConcatEnumerable2Rewritten);
            TestsExtensions.TestEquals("ArrayDistinctConcatArrayDistinctGroupJoind", ArrayDistinctConcatArrayDistinct, ArrayDistinctConcatArrayDistinctRewritten);
            TestsExtensions.TestEquals("ArrayDistinctConcatArrayDistinctDistinctGroupJoind", ArrayDistinctConcatArrayDistinctDistinct, ArrayDistinctConcatArrayDistinctDistinctRewritten);
            TestsExtensions.TestEquals("ArrayDistinctConcatArrayDistinctDistinct2GroupJoind", ArrayDistinctConcatArrayDistinctDistinct2, ArrayDistinctConcatArrayDistinctDistinct2Rewritten);
        }

        public IEnumerable<int> ArrayGroupJoin()
        {
            return ArrayItems.GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        }  //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayGroupJoinRewritten()
        {
            return ArrayItems.GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        }  //EndMethod



        public IEnumerable<int> ArrayGroupJoinToArray()
        {
            return ArrayItems.GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).ToArray();
        }  //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayGroupJoinToArrayRewritten()
        {
            return ArrayItems.GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).ToArray();
        }  //EndMethod



        public IEnumerable<int> SimpleListGroupJoin()
        {
            return SimpleListItems.GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        }  //EndMethod

        [LinqRewrite]
		public IEnumerable<int> SimpleListGroupJoinRewritten()
        {
            return SimpleListItems.GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        }  //EndMethod



        public IEnumerable<int> EnumerableGroupJoin()
        {
            return EnumerableItems.GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        }  //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableGroupJoinRewritten()
        {
            return EnumerableItems.GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        }  //EndMethod



        public IEnumerable<int> EnumerableGroupJoinToArray()
        {
            return EnumerableItems.GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).ToArray();
        }  //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableGroupJoinToArrayRewritten()
        {
            return EnumerableItems.GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).ToArray();
        }  //EndMethod



        public IEnumerable<int> EnumerableMethodGroupJoin()
        {
            return MethodEnumerable().GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        }  //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableMethodGroupJoinRewritten()
        {
            return MethodEnumerable().GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        }  //EndMethod



        public IEnumerable<int> EnumerableMethodGroupJoinToArray()
        {
            return MethodEnumerable().GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).ToArray();
        }  //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableMethodGroupJoinToArrayRewritten()
        {
            return MethodEnumerable().GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).ToArray();
        }  //EndMethod



        public IEnumerable<int> RangeGroupJoin()
        {
            return Enumerable.Range(56, 125).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        }  //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeGroupJoinRewritten()
        {
            return Enumerable.Range(56, 125).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        }  //EndMethod



        public IEnumerable<int> RangeGroupJoinToArray()
        {
            return Enumerable.Range(56, 125).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).ToArray();
        }  //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeGroupJoinToArrayRewritten()
        {
            return Enumerable.Range(56, 125).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).ToArray();
        }  //EndMethod



        public IEnumerable<int> ArraySelectGroupJoin()
        {
            return ArrayItems.Select(x => x + 3).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        }  //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArraySelectGroupJoinRewritten()
        {
            return ArrayItems.Select(x => x + 3).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        }  //EndMethod



        public IEnumerable<int> ArrayWhereGroupJoin()
        {
            return ArrayItems.Where(x => x > 10).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        }  //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayWhereGroupJoinRewritten()
        {
            return ArrayItems.Where(x => x > 10).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        }  //EndMethod



        public IEnumerable<int> ArrayGroupJoinWhereGroupJoin()
        {
            return ArrayItems.GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Where(x => x > 10).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        }  //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayGroupJoinWhereGroupJoinRewritten()
        {
            return ArrayItems.GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Where(x => x > 10).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        }  //EndMethod



        public IEnumerable<int> ArrayGroupJoinConcatGroupJoin()
        {
            return ArrayItems.GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Concat(ArrayItems).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        }  //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayGroupJoinConcatGroupJoinRewritten()
        {
            return ArrayItems.GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Concat(ArrayItems).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        }  //EndMethod



        public IEnumerable<int> ArrayGroupJoinConcatGroupJoind()
        {
            return ArrayItems.GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Concat(ArrayItems.GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y))).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        }  //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayGroupJoinConcatGroupJoindRewritten()
        {
            return ArrayItems.GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Concat(ArrayItems.GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y))).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        }  //EndMethod



        public IEnumerable<int> ArrayGroupJoinConcatGroupJoindConcatArray()
        {
            return ArrayItems.GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Concat(ArrayItems.GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y))).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Concat(ArrayItems);
        }  //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayGroupJoinConcatGroupJoindConcatArrayRewritten()
        {
            return ArrayItems.GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Concat(ArrayItems.GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y))).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Concat(ArrayItems);
        }  //EndMethod

        public IEnumerable<int> ArrayConcatArray()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayConcatArrayRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod


        public IEnumerable<int> ArrayConcatSimpleList()
        {
            return ArrayItems.Concat(SimpleListItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayConcatSimpleListRewritten()
        {
            return ArrayItems.Concat(SimpleListItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod


        public IEnumerable<int> ArrayConcatEnumerable()
        {
            return ArrayItems.Concat(EnumerableItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayConcatEnumerableRewritten()
        {
            return ArrayItems.Concat(EnumerableItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod


        public IEnumerable<int> ArrayConcatMethod()
        {
            return ArrayItems.Concat(MethodEnumerable2()).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayConcatMethodRewritten()
        {
            return ArrayItems.Concat(MethodEnumerable2()).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod


        public IEnumerable<int> SimpleListConcatArray()
        {
            return SimpleListItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> SimpleListConcatArrayRewritten()
        {
            return SimpleListItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod


        public IEnumerable<int> SimpleListConcatSimpleList()
        {
            return SimpleListItems.Concat(SimpleListItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> SimpleListConcatSimpleListRewritten()
        {
            return SimpleListItems.Concat(SimpleListItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod


        public IEnumerable<int> SimpleListConcatEnumerable()
        {
            return SimpleListItems.Concat(EnumerableItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> SimpleListConcatEnumerableRewritten()
        {
            return SimpleListItems.Concat(EnumerableItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod


        public IEnumerable<int> SimpleListConcatMethod()
        {
            return SimpleListItems.Concat(MethodEnumerable2()).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> SimpleListConcatMethodRewritten()
        {
            return SimpleListItems.Concat(MethodEnumerable2()).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod


        public IEnumerable<int> EnumerableConcatArray()
        {
            return EnumerableItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableConcatArrayRewritten()
        {
            return EnumerableItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod


        public IEnumerable<int> EnumerableConcatSimpleList()
        {
            return EnumerableItems.Concat(SimpleListItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableConcatSimpleListRewritten()
        {
            return EnumerableItems.Concat(SimpleListItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod


        public IEnumerable<int> EnumerableConcatEnumerable()
        {
            return EnumerableItems.Concat(EnumerableItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableConcatEnumerableRewritten()
        {
            return EnumerableItems.Concat(EnumerableItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod


        public IEnumerable<int> EnumerableConcatMethod()
        {
            return EnumerableItems.Concat(MethodEnumerable2()).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableConcatMethodRewritten()
        {
            return EnumerableItems.Concat(MethodEnumerable2()).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod


        public IEnumerable<int> MethodConcatArray()
        {
            return MethodEnumerable().Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> MethodConcatArrayRewritten()
        {
            return MethodEnumerable().Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod


        public IEnumerable<int> MethodConcatSimpleList()
        {
            return MethodEnumerable().Concat(SimpleListItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> MethodConcatSimpleListRewritten()
        {
            return MethodEnumerable().Concat(SimpleListItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod


        public IEnumerable<int> MethodConcatEnumerable()
        {
            return MethodEnumerable().Concat(EnumerableItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> MethodConcatEnumerableRewritten()
        {
            return MethodEnumerable().Concat(EnumerableItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod


        public IEnumerable<int> MethodConcatMethod()
        {
            return MethodEnumerable().Concat(MethodEnumerable2()).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> MethodConcatMethodRewritten()
        {
            return MethodEnumerable().Concat(MethodEnumerable2()).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod


        public IEnumerable<int> ArrayConcatArrayToArray()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayConcatArrayToArrayRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).ToArray();
        } //EndMethod


        public IEnumerable<int> ArrayConcatSimpleListToArray()
        {
            return ArrayItems.Concat(SimpleListItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayConcatSimpleListToArrayRewritten()
        {
            return ArrayItems.Concat(SimpleListItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).ToArray();
        } //EndMethod


        public IEnumerable<int> ArrayConcatEnumerableToArray()
        {
            return ArrayItems.Concat(EnumerableItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayConcatEnumerableToArrayRewritten()
        {
            return ArrayItems.Concat(EnumerableItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).ToArray();
        } //EndMethod


        public IEnumerable<int> SimpleListConcatArrayToArray()
        {
            return SimpleListItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> SimpleListConcatArrayToArrayRewritten()
        {
            return SimpleListItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).ToArray();
        } //EndMethod


        public IEnumerable<int> SimpleListConcatSimpleListToArray()
        {
            return SimpleListItems.Concat(SimpleListItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> SimpleListConcatSimpleListToArrayRewritten()
        {
            return SimpleListItems.Concat(SimpleListItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).ToArray();
        } //EndMethod


        public IEnumerable<int> SimpleListConcatEnumerableToArray()
        {
            return SimpleListItems.Concat(EnumerableItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> SimpleListConcatEnumerableToArrayRewritten()
        {
            return SimpleListItems.Concat(EnumerableItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).ToArray();
        } //EndMethod


        public IEnumerable<int> EnumerableConcatArrayToArray()
        {
            return EnumerableItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableConcatArrayToArrayRewritten()
        {
            return EnumerableItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).ToArray();
        } //EndMethod


        public IEnumerable<int> EnumerableConcatSimpleListToArray()
        {
            return EnumerableItems.Concat(SimpleListItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableConcatSimpleListToArrayRewritten()
        {
            return EnumerableItems.Concat(SimpleListItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).ToArray();
        } //EndMethod


        public IEnumerable<int> EnumerableConcatEnumerableToArray()
        {
            return EnumerableItems.Concat(EnumerableItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableConcatEnumerableToArrayRewritten()
        {
            return EnumerableItems.Concat(EnumerableItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).ToArray();
        } //EndMethod


        public IEnumerable<int> ArraySelectConcatArray()
        {
            return ArrayItems.Select(x => x + 50).Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArraySelectConcatArrayRewritten()
        {
            return ArrayItems.Select(x => x + 50).Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod


        public IEnumerable<int> ArraySelectConcatArraySelect()
        {
            return ArrayItems.Select(x => x + 50).Concat(ArrayItems2.Select(x => x + 50)).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArraySelectConcatArraySelectRewritten()
        {
            return ArrayItems.Select(x => x + 50).Concat(ArrayItems2.Select(x => x + 50)).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod


        public IEnumerable<int> ArrayWhereConcatArrayWhere()
        {
            return ArrayItems.Where(x => x > 50).Concat(ArrayItems2.Where(x => x > 50)).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayWhereConcatArrayWhereRewritten()
        {
            return ArrayItems.Where(x => x > 50).Concat(ArrayItems2.Where(x => x > 50)).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod


        public int ArrayConcatArrayCount()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Count();
        } //EndMethod

        [LinqRewrite]
		public int ArrayConcatArrayCountRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Count();
        } //EndMethod


        public int ArrayConcatArrayCount2()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Count(x => x > 70);
        } //EndMethod

        [LinqRewrite]
		public int ArrayConcatArrayCount2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Count(x => x > 70);
        } //EndMethod


        public int ArrayConcatArraySum()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Sum();
        } //EndMethod

        [LinqRewrite]
		public int ArrayConcatArraySumRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Sum();
        } //EndMethod


        public int ArrayConcatArraySum2()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Sum(x => x + 10);
        } //EndMethod

        [LinqRewrite]
		public int ArrayConcatArraySum2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Sum(x => x + 10);
        } //EndMethod


        public IEnumerable<int> ArrayConcatArrayDistinct()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Distinct().GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayConcatArrayDistinctRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Distinct().GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod


        public IEnumerable<int> ArrayConcatArrayDistinct2()
        {
            return ArrayItems.Concat(ArrayItems2).Distinct(EqualityComparer<int>.Default).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayConcatArrayDistinct2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Distinct(EqualityComparer<int>.Default).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod


        public int ArrayConcatArrayElementAt()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).ElementAt(45);
        } //EndMethod

        [LinqRewrite]
		public int ArrayConcatArrayElementAtRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).ElementAt(45);
        } //EndMethod


        public int ArrayConcatArrayElementAtOrDefault()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).ElementAtOrDefault(45);
        } //EndMethod

        [LinqRewrite]
		public int ArrayConcatArrayElementAtOrDefaultRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).ElementAtOrDefault(45);
        } //EndMethod


        public int ArrayConcatArrayFirst()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).First();
        } //EndMethod

        [LinqRewrite]
		public int ArrayConcatArrayFirstRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).First();
        } //EndMethod


        public int ArrayConcatArrayFirstOrDefault()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).FirstOrDefault();
        } //EndMethod

        [LinqRewrite]
		public int ArrayConcatArrayFirstOrDefaultRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).FirstOrDefault();
        } //EndMethod


        public int ArrayConcatArrayLast()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Last();
        } //EndMethod

        [LinqRewrite]
		public int ArrayConcatArrayLastRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Last();
        } //EndMethod


        public int ArrayConcatArrayLastOrDefault()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).LastOrDefault();
        } //EndMethod

        [LinqRewrite]
		public int ArrayConcatArrayLastOrDefaultRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).LastOrDefault();
        } //EndMethod


        public int ArrayConcatArraySingle()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Single();
        } //EndMethod

        [LinqRewrite]
		public int ArrayConcatArraySingleRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Single();
        } //EndMethod


        public int ArrayConcatArraySingle2()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Single(x => x == 76);
        } //EndMethod

        [LinqRewrite]
		public int ArrayConcatArraySingle2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Single(x => x == 76);
        } //EndMethod


        public int ArrayConcatArraySingleOrDefault()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).SingleOrDefault();
        } //EndMethod

        [LinqRewrite]
		public int ArrayConcatArraySingleOrDefaultRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).SingleOrDefault();
        } //EndMethod


        public int ArrayConcatArrayMin()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Min();
        } //EndMethod

        [LinqRewrite]
		public int ArrayConcatArrayMinRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Min();
        } //EndMethod


        public decimal ArrayConcatArrayMin2()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Min(x => x + 2m);
        } //EndMethod

        [LinqRewrite]
		public decimal ArrayConcatArrayMin2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Min(x => x + 2m);
        } //EndMethod


        public int ArrayConcatArrayMax()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Max();
        } //EndMethod

        [LinqRewrite]
		public int ArrayConcatArrayMaxRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Max();
        } //EndMethod


        public decimal ArrayConcatArrayMax2()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Max(x => x + 2m);
        } //EndMethod

        [LinqRewrite]
		public decimal ArrayConcatArrayMax2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Max(x => x + 2m);
        } //EndMethod


        public long ArrayConcatArrayLongCount()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).LongCount();
        } //EndMethod

        [LinqRewrite]
		public long ArrayConcatArrayLongCountRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).LongCount();
        } //EndMethod


        public long ArrayConcatArrayLongCount2()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).LongCount(x => x > 50);
        } //EndMethod

        [LinqRewrite]
		public long ArrayConcatArrayLongCount2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).LongCount(x => x > 50);
        } //EndMethod


        public bool ArrayConcatArrayContains()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Contains(56);
        } //EndMethod

        [LinqRewrite]
		public bool ArrayConcatArrayContainsRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Contains(56);
        } //EndMethod


        public double ArrayConcatArrayAverage()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Average();
        } //EndMethod

        [LinqRewrite]
		public double ArrayConcatArrayAverageRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Average();
        } //EndMethod


        public double ArrayConcatArrayAverage2()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Average(x => x + 10);
        } //EndMethod

        [LinqRewrite]
		public double ArrayConcatArrayAverage2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Average(x => x + 10);
        } //EndMethod


        public bool ArrayConcatArrayContains2()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Contains(56, EqualityComparer<int>.Default);
        } //EndMethod

        [LinqRewrite]
		public bool ArrayConcatArrayContains2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Contains(56, EqualityComparer<int>.Default);
        } //EndMethod


        public bool SelectWhereArrayConcatSelectWhereArrayContains()
        {
            return ArrayItems.Select(x => x + 10).Where(x => x > 80).Concat(ArrayItems2.Select(x => x + 10).Where(x => x > 80)).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Contains(112);
        } //EndMethod

        [LinqRewrite]
		public bool SelectWhereArrayConcatSelectWhereArrayContainsRewritten()
        {
            return ArrayItems.Select(x => x + 10).Where(x => x > 80).Concat(ArrayItems2.Select(x => x + 10).Where(x => x > 80)).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y)).Contains(112);
        } //EndMethod


        public IEnumerable<int> RangeConcatArray()
        {
            return Enumerable.Range(20, 100).Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeConcatArrayRewritten()
        {
            return Enumerable.Range(20, 100).Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod


        public IEnumerable<int> RepeatConcatArray()
        {
            return Enumerable.Repeat(20, 100).Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RepeatConcatArrayRewritten()
        {
            return Enumerable.Repeat(20, 100).Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod


        public IEnumerable<int> EmptyConcatArray()
        {
            return Enumerable.Empty<int>().Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EmptyConcatArrayRewritten()
        {
            return Enumerable.Empty<int>().Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod


        public IEnumerable<int> RangeEmpty2Array()
        {
            return ArrayItems.Where(x => false).Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeEmpty2ArrayRewritten()
        {
            return ArrayItems.Where(x => false).Concat(ArrayItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod


        public IEnumerable<int> ArrayConcatRange()
        {
            return ArrayItems.Concat(Enumerable.Range(70, 260)).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayConcatRangeRewritten()
        {
            return ArrayItems.Concat(Enumerable.Range(70, 260)).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod


        public IEnumerable<int> ArrayConcatRepeat()
        {
            return ArrayItems.Concat(Enumerable.Repeat(70, 100)).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayConcatRepeatRewritten()
        {
            return ArrayItems.Concat(Enumerable.Repeat(70, 100)).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod


        public IEnumerable<int> ArrayConcatEmpty()
        {
            return ArrayItems.Concat(Enumerable.Empty<int>()).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayConcatEmptyRewritten()
        {
            return ArrayItems.Concat(Enumerable.Empty<int>()).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod


        public IEnumerable<int> ArrayConcatEmpty2()
        {
            return ArrayItems.Concat(ArrayItems2.Where(x => false)).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayConcatEmpty2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2.Where(x => false)).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod


        public IEnumerable<int> ArrayConcatAll()
        {
            return ArrayItems.Concat(Enumerable.Range(0, 1000)).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayConcatAllRewritten()
        {
            return ArrayItems.Concat(Enumerable.Range(0, 1000)).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod


        public IEnumerable<int> ArrayConcatNull()
        {
            return ArrayItems.Concat(null).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayConcatNullRewritten()
        {
            return ArrayItems.Concat(null).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod


        public IEnumerable<int> ArrayConcatArrayConcatEnumerable()
        {
            return ArrayItems.Concat(ArrayItems).Concat(EnumerableItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayConcatArrayConcatEnumerableRewritten()
        {
            return ArrayItems.Concat(ArrayItems).Concat(EnumerableItems2).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod


        public IEnumerable<int> ArrayConcatArrayConcatEnumerable2()
        {
            return ArrayItems.Concat(ArrayItems.Concat(EnumerableItems2)).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayConcatArrayConcatEnumerable2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems.Concat(EnumerableItems2)).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod


        public IEnumerable<int> ArrayDistinctConcatArrayDistinct()
        {
            return ArrayItems.Distinct().Concat(ArrayItems.Distinct()).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayDistinctConcatArrayDistinctRewritten()
        {
            return ArrayItems.Distinct().Concat(ArrayItems.Distinct()).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod


        public IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinct()
        {
            return ArrayItems.Distinct().Concat(ArrayItems.Distinct()).Distinct().GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinctRewritten()
        {
            return ArrayItems.Distinct().Concat(ArrayItems.Distinct()).Distinct().GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod


        public IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinct2()
        {
            return ArrayItems.Distinct(EqualityComparer<int>.Default).Concat(ArrayItems.Distinct(EqualityComparer<int>.Default)).Distinct(EqualityComparer<int>.Default).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinct2Rewritten()
        {
            return ArrayItems.Distinct(EqualityComparer<int>.Default).Concat(ArrayItems.Distinct(EqualityComparer<int>.Default)).Distinct(EqualityComparer<int>.Default).GroupJoin(ArrayItems2, x => x % 10, x => x % 10, (x, group) => group.Sum(y => y));
        } //EndMethod

    }
}