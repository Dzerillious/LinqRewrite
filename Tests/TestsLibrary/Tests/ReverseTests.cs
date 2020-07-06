using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class ReverseTests
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
            TestsExtensions.TestEquals(nameof(ArrayReverse), ArrayReverse, ArrayReverseRewritten);
            TestsExtensions.TestEquals(nameof(ArrayReverseToArray), ArrayReverseToArray, ArrayReverseToArrayRewritten);
            TestsExtensions.TestEquals(nameof(SimpleListReverse), SimpleListReverse, SimpleListReverseRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableReverse), EnumerableReverse, EnumerableReverseRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableReverseToArray), EnumerableReverseToArray, EnumerableReverseToArrayRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableMethodReverse), EnumerableMethodReverse, EnumerableMethodReverseRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableMethodReverseToArray), EnumerableMethodReverseToArray, EnumerableMethodReverseToArrayRewritten);
            TestsExtensions.TestEquals(nameof(RangeReverse), RangeReverse, RangeReverseRewritten);
            TestsExtensions.TestEquals(nameof(RangeReverseToArray), RangeReverseToArray, RangeReverseToArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArraySelectReverse), ArraySelectReverse, ArraySelectReverseRewritten);
            TestsExtensions.TestEquals(nameof(ArrayWhereReverse), ArrayWhereReverse, ArrayWhereReverseRewritten);
            TestsExtensions.TestEquals(nameof(ArrayReverseWhereReverse), ArrayReverseWhereReverse, ArrayReverseWhereReverseRewritten);
            TestsExtensions.TestEquals(nameof(ArrayReverseConcatReverse), ArrayReverseConcatReverse, ArrayReverseConcatReverseRewritten);
            TestsExtensions.TestEquals(nameof(ArrayReverseConcatReversed), ArrayReverseConcatReversed, ArrayReverseConcatReversedRewritten);
            TestsExtensions.TestEquals(nameof(ArrayReverseConcatReversedConcatArray), ArrayReverseConcatReversedConcatArray, ArrayReverseConcatReversedConcatArrayRewritten);

            TestsExtensions.TestEquals("ArrayConcatArrayReversed", ArrayConcatArray, ArrayConcatArrayRewritten);
            TestsExtensions.TestEquals("ArrayConcatSimpleListReversed", ArrayConcatSimpleList, ArrayConcatSimpleListRewritten);
            TestsExtensions.TestEquals("ArrayConcatEnumerableReversed", ArrayConcatEnumerable, ArrayConcatEnumerableRewritten);
            TestsExtensions.TestEquals("ArrayConcatMethodReversed", ArrayConcatMethod, ArrayConcatMethodRewritten);
            TestsExtensions.TestEquals("SimpleListConcatArrayReversed", SimpleListConcatArray, SimpleListConcatArrayRewritten);
            TestsExtensions.TestEquals("SimpleListConcatSimpleListReversed", SimpleListConcatSimpleList, SimpleListConcatSimpleListRewritten);
            TestsExtensions.TestEquals("SimpleListConcatEnumerableReversed", SimpleListConcatEnumerable, SimpleListConcatEnumerableRewritten);
            TestsExtensions.TestEquals("SimpleListConcatMethodReversed", SimpleListConcatMethod, SimpleListConcatMethodRewritten);
            TestsExtensions.TestEquals("EnumerableConcatArrayReversed", EnumerableConcatArray, EnumerableConcatArrayRewritten);
            TestsExtensions.TestEquals("EnumerableConcatSimpleListReversed", EnumerableConcatSimpleList, EnumerableConcatSimpleListRewritten);
            TestsExtensions.TestEquals("EnumerableConcatEnumerableReversed", EnumerableConcatEnumerable, EnumerableConcatEnumerableRewritten);
            TestsExtensions.TestEquals("EnumerableConcatMethodReversed", EnumerableConcatMethod, EnumerableConcatMethodRewritten);
            TestsExtensions.TestEquals("MethodConcatArrayReversed", MethodConcatArray, MethodConcatArrayRewritten);
            TestsExtensions.TestEquals("MethodConcatSimpleListReversed", MethodConcatSimpleList, MethodConcatSimpleListRewritten);
            TestsExtensions.TestEquals("MethodConcatEnumerableReversed", MethodConcatEnumerable, MethodConcatEnumerableRewritten);
            TestsExtensions.TestEquals("MethodConcatMethodReversed", MethodConcatMethod, MethodConcatMethodRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayToArrayReversed", ArrayConcatArrayToArray, ArrayConcatArrayToArrayRewritten);
            TestsExtensions.TestEquals("ArrayConcatSimpleListToArrayReversed", ArrayConcatSimpleListToArray, ArrayConcatSimpleListToArrayRewritten);
            TestsExtensions.TestEquals("ArrayConcatEnumerableToArrayReversed", ArrayConcatEnumerableToArray, ArrayConcatEnumerableToArrayRewritten);
            TestsExtensions.TestEquals("SimpleListConcatArrayToArrayReversed", SimpleListConcatArrayToArray, SimpleListConcatArrayToArrayRewritten);
            TestsExtensions.TestEquals("SimpleListConcatSimpleListToArrayReversed", SimpleListConcatSimpleListToArray, SimpleListConcatSimpleListToArrayRewritten);
            TestsExtensions.TestEquals("SimpleListConcatEnumerableToArrayReversed", SimpleListConcatEnumerableToArray, SimpleListConcatEnumerableToArrayRewritten);
            TestsExtensions.TestEquals("EnumerableConcatArrayToArrayReversed", EnumerableConcatArrayToArray, EnumerableConcatArrayToArrayRewritten);
            TestsExtensions.TestEquals("EnumerableConcatSimpleListToArrayReversed", EnumerableConcatSimpleListToArray, EnumerableConcatSimpleListToArrayRewritten);
            TestsExtensions.TestEquals("EnumerableConcatEnumerableToArrayReversed", EnumerableConcatEnumerableToArray, EnumerableConcatEnumerableToArrayRewritten);
            TestsExtensions.TestEquals("ArraySelectConcatArrayReversed", ArraySelectConcatArray, ArraySelectConcatArrayRewritten);
            TestsExtensions.TestEquals("ArraySelectConcatArraySelectReversed", ArraySelectConcatArraySelect, ArraySelectConcatArraySelectRewritten);
            TestsExtensions.TestEquals("ArrayWhereConcatArrayWhereReversed", ArrayWhereConcatArrayWhere, ArrayWhereConcatArrayWhereRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayCountReversed", ArrayConcatArrayCount, ArrayConcatArrayCountRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayCount2Reversed", ArrayConcatArrayCount2, ArrayConcatArrayCount2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatArraySumReversed", ArrayConcatArraySum, ArrayConcatArraySumRewritten);
            TestsExtensions.TestEquals("ArrayConcatArraySum2Reversed", ArrayConcatArraySum2, ArrayConcatArraySum2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayDistinctReversed", ArrayConcatArrayDistinct, ArrayConcatArrayDistinctRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayDistinct2Reversed", ArrayConcatArrayDistinct2, ArrayConcatArrayDistinct2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayElementAtReversed", ArrayConcatArrayElementAt, ArrayConcatArrayElementAtRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayElementAtOrDefaultReversed", ArrayConcatArrayElementAtOrDefault, ArrayConcatArrayElementAtOrDefaultRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayFirstReversed", ArrayConcatArrayFirst, ArrayConcatArrayFirstRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayFirstOrDefaultReversed", ArrayConcatArrayFirstOrDefault, ArrayConcatArrayFirstOrDefaultRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayLastReversed", ArrayConcatArrayLast, ArrayConcatArrayLastRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayLastOrDefaultReversed", ArrayConcatArrayLastOrDefault, ArrayConcatArrayLastOrDefaultRewritten);
            TestsExtensions.TestEquals("ArrayConcatArraySingleReversed", ArrayConcatArraySingle, ArrayConcatArraySingleRewritten);
            TestsExtensions.TestEquals("ArrayConcatArraySingle2Reversed", ArrayConcatArraySingle2, ArrayConcatArraySingle2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatArraySingleOrDefaultReversed", ArrayConcatArraySingleOrDefault, ArrayConcatArraySingleOrDefaultRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayMinReversed", ArrayConcatArrayMin, ArrayConcatArrayMinRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayMin2Reversed", ArrayConcatArrayMin2, ArrayConcatArrayMin2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayMaxReversed", ArrayConcatArrayMax, ArrayConcatArrayMaxRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayMax2Reversed", ArrayConcatArrayMax2, ArrayConcatArrayMax2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayLongCountReversed", ArrayConcatArrayLongCount, ArrayConcatArrayLongCountRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayLongCount2Reversed", ArrayConcatArrayLongCount2, ArrayConcatArrayLongCount2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayContainsReversed", ArrayConcatArrayContains, ArrayConcatArrayContainsRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayAverageReversed", ArrayConcatArrayAverage, ArrayConcatArrayAverageRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayAverage2Reversed", ArrayConcatArrayAverage2, ArrayConcatArrayAverage2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayContains2Reversed", ArrayConcatArrayContains2, ArrayConcatArrayContains2Rewritten);
            TestsExtensions.TestEquals("SelectWhereArrayConcatSelectWhereArrayContainsReversed", SelectWhereArrayConcatSelectWhereArrayContains, SelectWhereArrayConcatSelectWhereArrayContainsRewritten);
            TestsExtensions.TestEquals("RangeConcatArrayReversed", RangeConcatArray, RangeConcatArrayRewritten);
            TestsExtensions.TestEquals("RepeatConcatArrayReversed", RepeatConcatArray, RepeatConcatArrayRewritten);
            TestsExtensions.TestEquals("EmptyConcatArrayReversed", EmptyConcatArray, EmptyConcatArrayRewritten);
            TestsExtensions.TestEquals("RangeEmpty2ArrayReversed", RangeEmpty2Array, RangeEmpty2ArrayRewritten);
            TestsExtensions.TestEquals("ArrayConcatRangeReversed", ArrayConcatRange, ArrayConcatRangeRewritten);
            TestsExtensions.TestEquals("ArrayConcatRepeatReversed", ArrayConcatRepeat, ArrayConcatRepeatRewritten);
            TestsExtensions.TestEquals("ArrayConcatEmptyReversed", ArrayConcatEmpty, ArrayConcatEmptyRewritten);
            TestsExtensions.TestEquals("ArrayConcatEmpty2Reversed", ArrayConcatEmpty2, ArrayConcatEmpty2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatAllReversed", ArrayConcatAll, ArrayConcatAllRewritten);
            TestsExtensions.TestEquals("ArrayConcatNullReversed", ArrayConcatNull, ArrayConcatNullRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayConcatEnumerableReversed", ArrayConcatArrayConcatEnumerable, ArrayConcatArrayConcatEnumerableRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayConcatEnumerable2Reversed", ArrayConcatArrayConcatEnumerable2, ArrayConcatArrayConcatEnumerable2Rewritten);
            TestsExtensions.TestEquals("ArrayDistinctConcatArrayDistinctReversed", ArrayDistinctConcatArrayDistinct, ArrayDistinctConcatArrayDistinctRewritten);
            TestsExtensions.TestEquals("ArrayDistinctConcatArrayDistinctDistinctReversed", ArrayDistinctConcatArrayDistinctDistinct, ArrayDistinctConcatArrayDistinctDistinctRewritten);
            TestsExtensions.TestEquals("ArrayDistinctConcatArrayDistinctDistinct2Reversed", ArrayDistinctConcatArrayDistinctDistinct2, ArrayDistinctConcatArrayDistinctDistinct2Rewritten);
        }

        public IEnumerable<int> ArrayReverse()
        {
            return ArrayItems.Reverse();
        }  //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayReverseRewritten()
        {
            return ArrayItems.Reverse();
        }  //EndMethod



        public IEnumerable<int> ArrayReverseToArray()
        {
            return ArrayItems.Reverse().ToArray();
        }  //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayReverseToArrayRewritten()
        {
            return ArrayItems.Reverse().ToArray();
        }  //EndMethod



        public IEnumerable<int> SimpleListReverse()
        {
            return SimpleListItems.Reverse();
        }  //EndMethod

        [LinqRewrite]
		public IEnumerable<int> SimpleListReverseRewritten()
        {
            return SimpleListItems.Reverse();
        }  //EndMethod



        public IEnumerable<int> EnumerableReverse()
        {
            return EnumerableItems.Reverse();
        }  //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableReverseRewritten()
        {
            return EnumerableItems.Reverse();
        }  //EndMethod



        public IEnumerable<int> EnumerableReverseToArray()
        {
            return EnumerableItems.Reverse().ToArray();
        }  //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableReverseToArrayRewritten()
        {
            return EnumerableItems.Reverse().ToArray();
        }  //EndMethod



        public IEnumerable<int> EnumerableMethodReverse()
        {
            return MethodEnumerable().Reverse();
        }  //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableMethodReverseRewritten()
        {
            return MethodEnumerable().Reverse();
        }  //EndMethod



        public IEnumerable<int> EnumerableMethodReverseToArray()
        {
            return MethodEnumerable().Reverse().ToArray();
        }  //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableMethodReverseToArrayRewritten()
        {
            return MethodEnumerable().Reverse().ToArray();
        }  //EndMethod



        public IEnumerable<int> RangeReverse()
        {
            return Enumerable.Range(56, 125).Reverse();
        }  //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeReverseRewritten()
        {
            return Enumerable.Range(56, 125).Reverse();
        }  //EndMethod



        public IEnumerable<int> RangeReverseToArray()
        {
            return Enumerable.Range(56, 125).Reverse().ToArray();
        }  //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeReverseToArrayRewritten()
        {
            return Enumerable.Range(56, 125).Reverse().ToArray();
        }  //EndMethod



        public IEnumerable<int> ArraySelectReverse()
        {
            return ArrayItems.Select(x => x + 3).Reverse();
        }  //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArraySelectReverseRewritten()
        {
            return ArrayItems.Select(x => x + 3).Reverse();
        }  //EndMethod



        public IEnumerable<int> ArrayWhereReverse()
        {
            return ArrayItems.Where(x => x > 10).Reverse();
        }  //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayWhereReverseRewritten()
        {
            return ArrayItems.Where(x => x > 10).Reverse();
        }  //EndMethod



        public IEnumerable<int> ArrayReverseWhereReverse()
        {
            return ArrayItems.Reverse().Where(x => x > 10).Reverse();
        }  //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayReverseWhereReverseRewritten()
        {
            return ArrayItems.Reverse().Where(x => x > 10).Reverse();
        }  //EndMethod



        public IEnumerable<int> ArrayReverseConcatReverse()
        {
            return ArrayItems.Reverse().Concat(ArrayItems).Reverse();
        }  //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayReverseConcatReverseRewritten()
        {
            return ArrayItems.Reverse().Concat(ArrayItems).Reverse();
        }  //EndMethod



        public IEnumerable<int> ArrayReverseConcatReversed()
        {
            return ArrayItems.Reverse().Concat(ArrayItems.Reverse()).Reverse();
        }  //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayReverseConcatReversedRewritten()
        {
            return ArrayItems.Reverse().Concat(ArrayItems.Reverse()).Reverse();
        }  //EndMethod



        public IEnumerable<int> ArrayReverseConcatReversedConcatArray()
        {
            return ArrayItems.Reverse().Concat(ArrayItems.Reverse()).Reverse().Concat(ArrayItems);
        }  //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayReverseConcatReversedConcatArrayRewritten()
        {
            return ArrayItems.Reverse().Concat(ArrayItems.Reverse()).Reverse().Concat(ArrayItems);
        }  //EndMethod

        public IEnumerable<int> ArrayConcatArray()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayConcatArrayRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse();
        } //EndMethod


        public IEnumerable<int> ArrayConcatSimpleList()
        {
            return ArrayItems.Concat(SimpleListItems2).Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayConcatSimpleListRewritten()
        {
            return ArrayItems.Concat(SimpleListItems2).Reverse();
        } //EndMethod


        public IEnumerable<int> ArrayConcatEnumerable()
        {
            return ArrayItems.Concat(EnumerableItems2).Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayConcatEnumerableRewritten()
        {
            return ArrayItems.Concat(EnumerableItems2).Reverse();
        } //EndMethod


        public IEnumerable<int> ArrayConcatMethod()
        {
            return ArrayItems.Concat(MethodEnumerable2()).Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayConcatMethodRewritten()
        {
            return ArrayItems.Concat(MethodEnumerable2()).Reverse();
        } //EndMethod


        public IEnumerable<int> SimpleListConcatArray()
        {
            return SimpleListItems.Concat(ArrayItems2).Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> SimpleListConcatArrayRewritten()
        {
            return SimpleListItems.Concat(ArrayItems2).Reverse();
        } //EndMethod


        public IEnumerable<int> SimpleListConcatSimpleList()
        {
            return SimpleListItems.Concat(SimpleListItems2).Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> SimpleListConcatSimpleListRewritten()
        {
            return SimpleListItems.Concat(SimpleListItems2).Reverse();
        } //EndMethod


        public IEnumerable<int> SimpleListConcatEnumerable()
        {
            return SimpleListItems.Concat(EnumerableItems2).Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> SimpleListConcatEnumerableRewritten()
        {
            return SimpleListItems.Concat(EnumerableItems2).Reverse();
        } //EndMethod


        public IEnumerable<int> SimpleListConcatMethod()
        {
            return SimpleListItems.Concat(MethodEnumerable2()).Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> SimpleListConcatMethodRewritten()
        {
            return SimpleListItems.Concat(MethodEnumerable2()).Reverse();
        } //EndMethod


        public IEnumerable<int> EnumerableConcatArray()
        {
            return EnumerableItems.Concat(ArrayItems2).Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableConcatArrayRewritten()
        {
            return EnumerableItems.Concat(ArrayItems2).Reverse();
        } //EndMethod


        public IEnumerable<int> EnumerableConcatSimpleList()
        {
            return EnumerableItems.Concat(SimpleListItems2).Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableConcatSimpleListRewritten()
        {
            return EnumerableItems.Concat(SimpleListItems2).Reverse();
        } //EndMethod


        public IEnumerable<int> EnumerableConcatEnumerable()
        {
            return EnumerableItems.Concat(EnumerableItems2).Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableConcatEnumerableRewritten()
        {
            return EnumerableItems.Concat(EnumerableItems2).Reverse();
        } //EndMethod


        public IEnumerable<int> EnumerableConcatMethod()
        {
            return EnumerableItems.Concat(MethodEnumerable2()).Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableConcatMethodRewritten()
        {
            return EnumerableItems.Concat(MethodEnumerable2()).Reverse();
        } //EndMethod


        public IEnumerable<int> MethodConcatArray()
        {
            return MethodEnumerable().Concat(ArrayItems2).Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> MethodConcatArrayRewritten()
        {
            return MethodEnumerable().Concat(ArrayItems2).Reverse();
        } //EndMethod


        public IEnumerable<int> MethodConcatSimpleList()
        {
            return MethodEnumerable().Concat(SimpleListItems2).Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> MethodConcatSimpleListRewritten()
        {
            return MethodEnumerable().Concat(SimpleListItems2).Reverse();
        } //EndMethod


        public IEnumerable<int> MethodConcatEnumerable()
        {
            return MethodEnumerable().Concat(EnumerableItems2).Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> MethodConcatEnumerableRewritten()
        {
            return MethodEnumerable().Concat(EnumerableItems2).Reverse();
        } //EndMethod


        public IEnumerable<int> MethodConcatMethod()
        {
            return MethodEnumerable().Concat(MethodEnumerable2()).Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> MethodConcatMethodRewritten()
        {
            return MethodEnumerable().Concat(MethodEnumerable2()).Reverse();
        } //EndMethod


        public IEnumerable<int> ArrayConcatArrayToArray()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayConcatArrayToArrayRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().ToArray();
        } //EndMethod


        public IEnumerable<int> ArrayConcatSimpleListToArray()
        {
            return ArrayItems.Concat(SimpleListItems2).Reverse().ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayConcatSimpleListToArrayRewritten()
        {
            return ArrayItems.Concat(SimpleListItems2).Reverse().ToArray();
        } //EndMethod


        public IEnumerable<int> ArrayConcatEnumerableToArray()
        {
            return ArrayItems.Concat(EnumerableItems2).Reverse().ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayConcatEnumerableToArrayRewritten()
        {
            return ArrayItems.Concat(EnumerableItems2).Reverse().ToArray();
        } //EndMethod


        public IEnumerable<int> SimpleListConcatArrayToArray()
        {
            return SimpleListItems.Concat(ArrayItems2).Reverse().ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> SimpleListConcatArrayToArrayRewritten()
        {
            return SimpleListItems.Concat(ArrayItems2).Reverse().ToArray();
        } //EndMethod


        public IEnumerable<int> SimpleListConcatSimpleListToArray()
        {
            return SimpleListItems.Concat(SimpleListItems2).Reverse().ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> SimpleListConcatSimpleListToArrayRewritten()
        {
            return SimpleListItems.Concat(SimpleListItems2).Reverse().ToArray();
        } //EndMethod


        public IEnumerable<int> SimpleListConcatEnumerableToArray()
        {
            return SimpleListItems.Concat(EnumerableItems2).Reverse().ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> SimpleListConcatEnumerableToArrayRewritten()
        {
            return SimpleListItems.Concat(EnumerableItems2).Reverse().ToArray();
        } //EndMethod


        public IEnumerable<int> EnumerableConcatArrayToArray()
        {
            return EnumerableItems.Concat(ArrayItems2).Reverse().ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableConcatArrayToArrayRewritten()
        {
            return EnumerableItems.Concat(ArrayItems2).Reverse().ToArray();
        } //EndMethod


        public IEnumerable<int> EnumerableConcatSimpleListToArray()
        {
            return EnumerableItems.Concat(SimpleListItems2).Reverse().ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableConcatSimpleListToArrayRewritten()
        {
            return EnumerableItems.Concat(SimpleListItems2).Reverse().ToArray();
        } //EndMethod


        public IEnumerable<int> EnumerableConcatEnumerableToArray()
        {
            return EnumerableItems.Concat(EnumerableItems2).Reverse().ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableConcatEnumerableToArrayRewritten()
        {
            return EnumerableItems.Concat(EnumerableItems2).Reverse().ToArray();
        } //EndMethod


        public IEnumerable<int> ArraySelectConcatArray()
        {
            return ArrayItems.Select(x => x + 50).Concat(ArrayItems2).Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArraySelectConcatArrayRewritten()
        {
            return ArrayItems.Select(x => x + 50).Concat(ArrayItems2).Reverse();
        } //EndMethod


        public IEnumerable<int> ArraySelectConcatArraySelect()
        {
            return ArrayItems.Select(x => x + 50).Concat(ArrayItems2.Select(x => x + 50)).Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArraySelectConcatArraySelectRewritten()
        {
            return ArrayItems.Select(x => x + 50).Concat(ArrayItems2.Select(x => x + 50)).Reverse();
        } //EndMethod


        public IEnumerable<int> ArrayWhereConcatArrayWhere()
        {
            return ArrayItems.Where(x => x > 50).Concat(ArrayItems2.Where(x => x > 50)).Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayWhereConcatArrayWhereRewritten()
        {
            return ArrayItems.Where(x => x > 50).Concat(ArrayItems2.Where(x => x > 50)).Reverse();
        } //EndMethod


        public int ArrayConcatArrayCount()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().Count();
        } //EndMethod

        [LinqRewrite]
		public int ArrayConcatArrayCountRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().Count();
        } //EndMethod


        public int ArrayConcatArrayCount2()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().Count(x => x > 70);
        } //EndMethod

        [LinqRewrite]
		public int ArrayConcatArrayCount2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().Count(x => x > 70);
        } //EndMethod


        public int ArrayConcatArraySum()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().Sum();
        } //EndMethod

        [LinqRewrite]
		public int ArrayConcatArraySumRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().Sum();
        } //EndMethod


        public int ArrayConcatArraySum2()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().Sum(x => x + 10);
        } //EndMethod

        [LinqRewrite]
		public int ArrayConcatArraySum2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().Sum(x => x + 10);
        } //EndMethod


        public IEnumerable<int> ArrayConcatArrayDistinct()
        {
            return ArrayItems.Concat(ArrayItems2).Distinct().Reverse().Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayConcatArrayDistinctRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().Distinct().Reverse();
        } //EndMethod


        public IEnumerable<int> ArrayConcatArrayDistinct2()
        {
            return ArrayItems.Concat(ArrayItems2).Distinct(EqualityComparer<int>.Default).Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayConcatArrayDistinct2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Distinct(EqualityComparer<int>.Default).Reverse();
        } //EndMethod


        public int ArrayConcatArrayElementAt()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().ElementAt(45);
        } //EndMethod

        [LinqRewrite]
		public int ArrayConcatArrayElementAtRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().ElementAt(45);
        } //EndMethod


        public int ArrayConcatArrayElementAtOrDefault()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().ElementAtOrDefault(45);
        } //EndMethod

        [LinqRewrite]
		public int ArrayConcatArrayElementAtOrDefaultRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().ElementAtOrDefault(45);
        } //EndMethod


        public int ArrayConcatArrayFirst()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().First();
        } //EndMethod

        [LinqRewrite]
		public int ArrayConcatArrayFirstRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().First();
        } //EndMethod


        public int ArrayConcatArrayFirstOrDefault()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().FirstOrDefault();
        } //EndMethod

        [LinqRewrite]
		public int ArrayConcatArrayFirstOrDefaultRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().FirstOrDefault();
        } //EndMethod


        public int ArrayConcatArrayLast()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().Last();
        } //EndMethod

        [LinqRewrite]
		public int ArrayConcatArrayLastRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().Last();
        } //EndMethod


        public int ArrayConcatArrayLastOrDefault()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().LastOrDefault();
        } //EndMethod

        [LinqRewrite]
		public int ArrayConcatArrayLastOrDefaultRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().LastOrDefault();
        } //EndMethod


        public int ArrayConcatArraySingle()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().Single();
        } //EndMethod

        [LinqRewrite]
		public int ArrayConcatArraySingleRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().Single();
        } //EndMethod


        public int ArrayConcatArraySingle2()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().Single(x => x == 76);
        } //EndMethod

        [LinqRewrite]
		public int ArrayConcatArraySingle2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().Single(x => x == 76);
        } //EndMethod


        public int ArrayConcatArraySingleOrDefault()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().SingleOrDefault();
        } //EndMethod

        [LinqRewrite]
		public int ArrayConcatArraySingleOrDefaultRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().SingleOrDefault();
        } //EndMethod


        public int ArrayConcatArrayMin()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().Min();
        } //EndMethod

        [LinqRewrite]
		public int ArrayConcatArrayMinRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().Min();
        } //EndMethod


        public decimal ArrayConcatArrayMin2()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().Min(x => x + 2m);
        } //EndMethod

        [LinqRewrite]
		public decimal ArrayConcatArrayMin2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().Min(x => x + 2m);
        } //EndMethod


        public int ArrayConcatArrayMax()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().Max();
        } //EndMethod

        [LinqRewrite]
		public int ArrayConcatArrayMaxRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().Max();
        } //EndMethod


        public decimal ArrayConcatArrayMax2()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().Max(x => x + 2m);
        } //EndMethod

        [LinqRewrite]
		public decimal ArrayConcatArrayMax2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().Max(x => x + 2m);
        } //EndMethod


        public long ArrayConcatArrayLongCount()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().LongCount();
        } //EndMethod

        [LinqRewrite]
		public long ArrayConcatArrayLongCountRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().LongCount();
        } //EndMethod


        public long ArrayConcatArrayLongCount2()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().LongCount(x => x > 50);
        } //EndMethod

        [LinqRewrite]
		public long ArrayConcatArrayLongCount2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().LongCount(x => x > 50);
        } //EndMethod


        public bool ArrayConcatArrayContains()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().Contains(56);
        } //EndMethod

        [LinqRewrite]
		public bool ArrayConcatArrayContainsRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().Contains(56);
        } //EndMethod


        public double ArrayConcatArrayAverage()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().Average();
        } //EndMethod

        [LinqRewrite]
		public double ArrayConcatArrayAverageRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().Average();
        } //EndMethod


        public double ArrayConcatArrayAverage2()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().Average(x => x + 10);
        } //EndMethod

        [LinqRewrite]
		public double ArrayConcatArrayAverage2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().Average(x => x + 10);
        } //EndMethod


        public bool ArrayConcatArrayContains2()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().Contains(56, EqualityComparer<int>.Default);
        } //EndMethod

        [LinqRewrite]
		public bool ArrayConcatArrayContains2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Reverse().Contains(56, EqualityComparer<int>.Default);
        } //EndMethod


        public bool SelectWhereArrayConcatSelectWhereArrayContains()
        {
            return ArrayItems.Select(x => x + 10).Where(x => x > 80).Concat(ArrayItems2.Select(x => x + 10).Where(x => x > 80)).Reverse().Contains(112);
        } //EndMethod

        [LinqRewrite]
		public bool SelectWhereArrayConcatSelectWhereArrayContainsRewritten()
        {
            return ArrayItems.Select(x => x + 10).Where(x => x > 80).Concat(ArrayItems2.Select(x => x + 10).Where(x => x > 80)).Reverse().Contains(112);
        } //EndMethod


        public IEnumerable<int> RangeConcatArray()
        {
            return Enumerable.Range(20, 100).Concat(ArrayItems2).Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeConcatArrayRewritten()
        {
            return Enumerable.Range(20, 100).Concat(ArrayItems2).Reverse();
        } //EndMethod


        public IEnumerable<int> RepeatConcatArray()
        {
            return Enumerable.Repeat(20, 100).Concat(ArrayItems2).Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RepeatConcatArrayRewritten()
        {
            return Enumerable.Repeat(20, 100).Concat(ArrayItems2).Reverse();
        } //EndMethod


        public IEnumerable<int> EmptyConcatArray()
        {
            return Enumerable.Empty<int>().Concat(ArrayItems2).Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EmptyConcatArrayRewritten()
        {
            return Enumerable.Empty<int>().Concat(ArrayItems2).Reverse();
        } //EndMethod


        public IEnumerable<int> RangeEmpty2Array()
        {
            return ArrayItems.Where(x => false).Concat(ArrayItems2).Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeEmpty2ArrayRewritten()
        {
            return ArrayItems.Where(x => false).Concat(ArrayItems2).Reverse();
        } //EndMethod


        public IEnumerable<int> ArrayConcatRange()
        {
            return ArrayItems.Concat(Enumerable.Range(70, 260)).Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayConcatRangeRewritten()
        {
            return ArrayItems.Concat(Enumerable.Range(70, 260)).Reverse();
        } //EndMethod


        public IEnumerable<int> ArrayConcatRepeat()
        {
            return ArrayItems.Concat(Enumerable.Repeat(70, 100)).Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayConcatRepeatRewritten()
        {
            return ArrayItems.Concat(Enumerable.Repeat(70, 100)).Reverse();
        } //EndMethod


        public IEnumerable<int> ArrayConcatEmpty()
        {
            return ArrayItems.Concat(Enumerable.Empty<int>()).Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayConcatEmptyRewritten()
        {
            return ArrayItems.Concat(Enumerable.Empty<int>()).Reverse();
        } //EndMethod


        public IEnumerable<int> ArrayConcatEmpty2()
        {
            return ArrayItems.Concat(ArrayItems2.Where(x => false)).Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayConcatEmpty2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2.Where(x => false)).Reverse();
        } //EndMethod


        public IEnumerable<int> ArrayConcatAll()
        {
            return ArrayItems.Concat(Enumerable.Range(0, 1000)).Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayConcatAllRewritten()
        {
            return ArrayItems.Concat(Enumerable.Range(0, 1000)).Reverse();
        } //EndMethod


        public IEnumerable<int> ArrayConcatNull()
        {
            return ArrayItems.Concat(null).Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayConcatNullRewritten()
        {
            return ArrayItems.Concat(null).Reverse();
        } //EndMethod


        public IEnumerable<int> ArrayConcatArrayConcatEnumerable()
        {
            return ArrayItems.Concat(ArrayItems).Concat(EnumerableItems2).Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayConcatArrayConcatEnumerableRewritten()
        {
            return ArrayItems.Concat(ArrayItems).Concat(EnumerableItems2).Reverse();
        } //EndMethod


        public IEnumerable<int> ArrayConcatArrayConcatEnumerable2()
        {
            return ArrayItems.Concat(ArrayItems.Concat(EnumerableItems2)).Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayConcatArrayConcatEnumerable2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems.Concat(EnumerableItems2)).Reverse();
        } //EndMethod


        public IEnumerable<int> ArrayDistinctConcatArrayDistinct()
        {
            return ArrayItems.Distinct().Concat(ArrayItems.Distinct()).Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayDistinctConcatArrayDistinctRewritten()
        {
            return ArrayItems.Distinct().Concat(ArrayItems.Distinct()).Reverse();
        } //EndMethod


        public IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinct()
        {
            return ArrayItems.Distinct().Concat(ArrayItems.Distinct()).Distinct().Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinctRewritten()
        {
            return ArrayItems.Distinct().Concat(ArrayItems.Distinct()).Distinct().Reverse();
        } //EndMethod


        public IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinct2()
        {
            return ArrayItems.Distinct(EqualityComparer<int>.Default).Concat(ArrayItems.Distinct(EqualityComparer<int>.Default)).Distinct(EqualityComparer<int>.Default).Reverse();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinct2Rewritten()
        {
            return ArrayItems.Distinct(EqualityComparer<int>.Default).Concat(ArrayItems.Distinct(EqualityComparer<int>.Default)).Distinct(EqualityComparer<int>.Default).Reverse();
        } //EndMethod

    }
}