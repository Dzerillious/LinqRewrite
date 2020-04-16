using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class JoinTests
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
            TestsExtensions.TestEquals(nameof(ArrayJoin), ArrayJoin, ArrayJoinRewritten);
            TestsExtensions.TestEquals(nameof(ArrayJoinToArray), ArrayJoinToArray, ArrayJoinToArrayRewritten);
            TestsExtensions.TestEquals(nameof(SimpleListJoin), SimpleListJoin, SimpleListJoinRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableJoin), EnumerableJoin, EnumerableJoinRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableJoinToArray), EnumerableJoinToArray, EnumerableJoinToArrayRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableMethodJoin), EnumerableMethodJoin, EnumerableMethodJoinRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableMethodJoinToArray), EnumerableMethodJoinToArray, EnumerableMethodJoinToArrayRewritten);
            TestsExtensions.TestEquals(nameof(RangeJoin), RangeJoin, RangeJoinRewritten);
            TestsExtensions.TestEquals(nameof(RangeJoinToArray), RangeJoinToArray, RangeJoinToArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArraySelectJoin), ArraySelectJoin, ArraySelectJoinRewritten);
            TestsExtensions.TestEquals(nameof(ArrayWhereJoin), ArrayWhereJoin, ArrayWhereJoinRewritten);
            TestsExtensions.TestEquals(nameof(ArrayJoinWhereJoin), ArrayJoinWhereJoin, ArrayJoinWhereJoinRewritten);
            TestsExtensions.TestEquals(nameof(ArrayJoinConcatJoin), ArrayJoinConcatJoin, ArrayJoinConcatJoinRewritten);
            TestsExtensions.TestEquals(nameof(ArrayJoinConcatJoind), ArrayJoinConcatJoind, ArrayJoinConcatJoindRewritten);
            TestsExtensions.TestEquals(nameof(ArrayJoinConcatJoindConcatArray), ArrayJoinConcatJoindConcatArray, ArrayJoinConcatJoindConcatArrayRewritten);

            TestsExtensions.TestEquals("ArrayConcatArrayJoind", ArrayConcatArray, ArrayConcatArrayRewritten);
            TestsExtensions.TestEquals("ArrayConcatSimpleListJoind", ArrayConcatSimpleList, ArrayConcatSimpleListRewritten);
            TestsExtensions.TestEquals("ArrayConcatEnumerableJoind", ArrayConcatEnumerable, ArrayConcatEnumerableRewritten);
            TestsExtensions.TestEquals("ArrayConcatMethodJoind", ArrayConcatMethod, ArrayConcatMethodRewritten);
            TestsExtensions.TestEquals("SimpleListConcatArrayJoind", SimpleListConcatArray, SimpleListConcatArrayRewritten);
            TestsExtensions.TestEquals("SimpleListConcatSimpleListJoind", SimpleListConcatSimpleList, SimpleListConcatSimpleListRewritten);
            TestsExtensions.TestEquals("SimpleListConcatEnumerableJoind", SimpleListConcatEnumerable, SimpleListConcatEnumerableRewritten);
            TestsExtensions.TestEquals("SimpleListConcatMethodJoind", SimpleListConcatMethod, SimpleListConcatMethodRewritten);
            TestsExtensions.TestEquals("EnumerableConcatArrayJoind", EnumerableConcatArray, EnumerableConcatArrayRewritten);
            TestsExtensions.TestEquals("EnumerableConcatSimpleListJoind", EnumerableConcatSimpleList, EnumerableConcatSimpleListRewritten);
            TestsExtensions.TestEquals("EnumerableConcatEnumerableJoind", EnumerableConcatEnumerable, EnumerableConcatEnumerableRewritten);
            TestsExtensions.TestEquals("EnumerableConcatMethodJoind", EnumerableConcatMethod, EnumerableConcatMethodRewritten);
            TestsExtensions.TestEquals("MethodConcatArrayJoind", MethodConcatArray, MethodConcatArrayRewritten);
            TestsExtensions.TestEquals("MethodConcatSimpleListJoind", MethodConcatSimpleList, MethodConcatSimpleListRewritten);
            TestsExtensions.TestEquals("MethodConcatEnumerableJoind", MethodConcatEnumerable, MethodConcatEnumerableRewritten);
            TestsExtensions.TestEquals("MethodConcatMethodJoind", MethodConcatMethod, MethodConcatMethodRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayToArrayJoind", ArrayConcatArrayToArray, ArrayConcatArrayToArrayRewritten);
            TestsExtensions.TestEquals("ArrayConcatSimpleListToArrayJoind", ArrayConcatSimpleListToArray, ArrayConcatSimpleListToArrayRewritten);
            TestsExtensions.TestEquals("ArrayConcatEnumerableToArrayJoind", ArrayConcatEnumerableToArray, ArrayConcatEnumerableToArrayRewritten);
            TestsExtensions.TestEquals("SimpleListConcatArrayToArrayJoind", SimpleListConcatArrayToArray, SimpleListConcatArrayToArrayRewritten);
            TestsExtensions.TestEquals("SimpleListConcatSimpleListToArrayJoind", SimpleListConcatSimpleListToArray, SimpleListConcatSimpleListToArrayRewritten);
            TestsExtensions.TestEquals("SimpleListConcatEnumerableToArrayJoind", SimpleListConcatEnumerableToArray, SimpleListConcatEnumerableToArrayRewritten);
            TestsExtensions.TestEquals("EnumerableConcatArrayToArrayJoind", EnumerableConcatArrayToArray, EnumerableConcatArrayToArrayRewritten);
            TestsExtensions.TestEquals("EnumerableConcatSimpleListToArrayJoind", EnumerableConcatSimpleListToArray, EnumerableConcatSimpleListToArrayRewritten);
            TestsExtensions.TestEquals("EnumerableConcatEnumerableToArrayJoind", EnumerableConcatEnumerableToArray, EnumerableConcatEnumerableToArrayRewritten);
            TestsExtensions.TestEquals("ArraySelectConcatArrayJoind", ArraySelectConcatArray, ArraySelectConcatArrayRewritten);
            TestsExtensions.TestEquals("ArraySelectConcatArraySelectJoind", ArraySelectConcatArraySelect, ArraySelectConcatArraySelectRewritten);
            TestsExtensions.TestEquals("ArrayWhereConcatArrayWhereJoind", ArrayWhereConcatArrayWhere, ArrayWhereConcatArrayWhereRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayCountJoind", ArrayConcatArrayCount, ArrayConcatArrayCountRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayCount2Joind", ArrayConcatArrayCount2, ArrayConcatArrayCount2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatArraySumJoind", ArrayConcatArraySum, ArrayConcatArraySumRewritten);
            TestsExtensions.TestEquals("ArrayConcatArraySum2Joind", ArrayConcatArraySum2, ArrayConcatArraySum2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayDistinctJoind", ArrayConcatArrayDistinct, ArrayConcatArrayDistinctRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayDistinct2Joind", ArrayConcatArrayDistinct2, ArrayConcatArrayDistinct2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayElementAtJoind", ArrayConcatArrayElementAt, ArrayConcatArrayElementAtRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayElementAtOrDefaultJoind", ArrayConcatArrayElementAtOrDefault, ArrayConcatArrayElementAtOrDefaultRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayFirstJoind", ArrayConcatArrayFirst, ArrayConcatArrayFirstRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayFirstOrDefaultJoind", ArrayConcatArrayFirstOrDefault, ArrayConcatArrayFirstOrDefaultRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayLastJoind", ArrayConcatArrayLast, ArrayConcatArrayLastRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayLastOrDefaultJoind", ArrayConcatArrayLastOrDefault, ArrayConcatArrayLastOrDefaultRewritten);
            TestsExtensions.TestEquals("ArrayConcatArraySingleJoind", ArrayConcatArraySingle, ArrayConcatArraySingleRewritten);
            TestsExtensions.TestEquals("ArrayConcatArraySingle2Joind", ArrayConcatArraySingle2, ArrayConcatArraySingle2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatArraySingleOrDefaultJoind", ArrayConcatArraySingleOrDefault, ArrayConcatArraySingleOrDefaultRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayMinJoind", ArrayConcatArrayMin, ArrayConcatArrayMinRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayMin2Joind", ArrayConcatArrayMin2, ArrayConcatArrayMin2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayMaxJoind", ArrayConcatArrayMax, ArrayConcatArrayMaxRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayMax2Joind", ArrayConcatArrayMax2, ArrayConcatArrayMax2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayLongCountJoind", ArrayConcatArrayLongCount, ArrayConcatArrayLongCountRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayLongCount2Joind", ArrayConcatArrayLongCount2, ArrayConcatArrayLongCount2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayContainsJoind", ArrayConcatArrayContains, ArrayConcatArrayContainsRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayAverageJoind", ArrayConcatArrayAverage, ArrayConcatArrayAverageRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayAverage2Joind", ArrayConcatArrayAverage2, ArrayConcatArrayAverage2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayContains2Joind", ArrayConcatArrayContains2, ArrayConcatArrayContains2Rewritten);
            TestsExtensions.TestEquals("SelectWhereArrayConcatSelectWhereArrayContainsJoind", SelectWhereArrayConcatSelectWhereArrayContains, SelectWhereArrayConcatSelectWhereArrayContainsRewritten);
            TestsExtensions.TestEquals("RangeConcatArrayJoind", RangeConcatArray, RangeConcatArrayRewritten);
            TestsExtensions.TestEquals("RepeatConcatArrayJoind", RepeatConcatArray, RepeatConcatArrayRewritten);
            TestsExtensions.TestEquals("EmptyConcatArrayJoind", EmptyConcatArray, EmptyConcatArrayRewritten);
            TestsExtensions.TestEquals("RangeEmpty2ArrayJoind", RangeEmpty2Array, RangeEmpty2ArrayRewritten);
            TestsExtensions.TestEquals("ArrayConcatRangeJoind", ArrayConcatRange, ArrayConcatRangeRewritten);
            TestsExtensions.TestEquals("ArrayConcatRepeatJoind", ArrayConcatRepeat, ArrayConcatRepeatRewritten);
            TestsExtensions.TestEquals("ArrayConcatEmptyJoind", ArrayConcatEmpty, ArrayConcatEmptyRewritten);
            TestsExtensions.TestEquals("ArrayConcatEmpty2Joind", ArrayConcatEmpty2, ArrayConcatEmpty2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatAllJoind", ArrayConcatAll, ArrayConcatAllRewritten);
            TestsExtensions.TestEquals("ArrayConcatNullJoind", ArrayConcatNull, ArrayConcatNullRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayConcatEnumerableJoind", ArrayConcatArrayConcatEnumerable, ArrayConcatArrayConcatEnumerableRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayConcatEnumerable2Joind", ArrayConcatArrayConcatEnumerable2, ArrayConcatArrayConcatEnumerable2Rewritten);
            TestsExtensions.TestEquals("ArrayDistinctConcatArrayDistinctJoind", ArrayDistinctConcatArrayDistinct, ArrayDistinctConcatArrayDistinctRewritten);
            TestsExtensions.TestEquals("ArrayDistinctConcatArrayDistinctDistinctJoind", ArrayDistinctConcatArrayDistinctDistinct, ArrayDistinctConcatArrayDistinctDistinctRewritten);
            TestsExtensions.TestEquals("ArrayDistinctConcatArrayDistinctDistinct2Joind", ArrayDistinctConcatArrayDistinctDistinct2, ArrayDistinctConcatArrayDistinctDistinct2Rewritten);
        }

        [NoRewrite]
        public IEnumerable<int> ArrayJoin()
        {
            return ArrayItems.Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        }  //EndMethod

        public IEnumerable<int> ArrayJoinRewritten()
        {
            return ArrayItems.Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        }  //EndMethod



        [NoRewrite]
        public IEnumerable<int> ArrayJoinToArray()
        {
            return ArrayItems.Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).ToArray();
        }  //EndMethod

        public IEnumerable<int> ArrayJoinToArrayRewritten()
        {
            return ArrayItems.Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).ToArray();
        }  //EndMethod



        [NoRewrite]
        public IEnumerable<int> SimpleListJoin()
        {
            return SimpleListItems.Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        }  //EndMethod

        public IEnumerable<int> SimpleListJoinRewritten()
        {
            return SimpleListItems.Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        }  //EndMethod



        [NoRewrite]
        public IEnumerable<int> EnumerableJoin()
        {
            return EnumerableItems.Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        }  //EndMethod

        public IEnumerable<int> EnumerableJoinRewritten()
        {
            return EnumerableItems.Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        }  //EndMethod



        [NoRewrite]
        public IEnumerable<int> EnumerableJoinToArray()
        {
            return EnumerableItems.Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).ToArray();
        }  //EndMethod

        public IEnumerable<int> EnumerableJoinToArrayRewritten()
        {
            return EnumerableItems.Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).ToArray();
        }  //EndMethod



        [NoRewrite]
        public IEnumerable<int> EnumerableMethodJoin()
        {
            return MethodEnumerable().Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        }  //EndMethod

        public IEnumerable<int> EnumerableMethodJoinRewritten()
        {
            return MethodEnumerable().Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        }  //EndMethod



        [NoRewrite]
        public IEnumerable<int> EnumerableMethodJoinToArray()
        {
            return MethodEnumerable().Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).ToArray();
        }  //EndMethod

        public IEnumerable<int> EnumerableMethodJoinToArrayRewritten()
        {
            return MethodEnumerable().Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).ToArray();
        }  //EndMethod



        [NoRewrite]
        public IEnumerable<int> RangeJoin()
        {
            return Enumerable.Range(56, 125).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        }  //EndMethod

        public IEnumerable<int> RangeJoinRewritten()
        {
            return Enumerable.Range(56, 125).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        }  //EndMethod



        [NoRewrite]
        public IEnumerable<int> RangeJoinToArray()
        {
            return Enumerable.Range(56, 125).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).ToArray();
        }  //EndMethod

        public IEnumerable<int> RangeJoinToArrayRewritten()
        {
            return Enumerable.Range(56, 125).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).ToArray();
        }  //EndMethod



        [NoRewrite]
        public IEnumerable<int> ArraySelectJoin()
        {
            return ArrayItems.Select(x => x + 3).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        }  //EndMethod

        public IEnumerable<int> ArraySelectJoinRewritten()
        {
            return ArrayItems.Select(x => x + 3).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        }  //EndMethod



        [NoRewrite]
        public IEnumerable<int> ArrayWhereJoin()
        {
            return ArrayItems.Where(x => x > 10).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        }  //EndMethod

        public IEnumerable<int> ArrayWhereJoinRewritten()
        {
            return ArrayItems.Where(x => x > 10).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        }  //EndMethod



        [NoRewrite]
        public IEnumerable<int> ArrayJoinWhereJoin()
        {
            return ArrayItems.Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Where(x => x > 10).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        }  //EndMethod

        public IEnumerable<int> ArrayJoinWhereJoinRewritten()
        {
            return ArrayItems.Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Where(x => x > 10).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        }  //EndMethod



        [NoRewrite]
        public IEnumerable<int> ArrayJoinConcatJoin()
        {
            return ArrayItems.Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Concat(ArrayItems).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        }  //EndMethod

        public IEnumerable<int> ArrayJoinConcatJoinRewritten()
        {
            return ArrayItems.Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Concat(ArrayItems).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        }  //EndMethod



        [NoRewrite]
        public IEnumerable<int> ArrayJoinConcatJoind()
        {
            return ArrayItems.Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Concat(ArrayItems.Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y)).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        }  //EndMethod

        public IEnumerable<int> ArrayJoinConcatJoindRewritten()
        {
            return ArrayItems.Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Concat(ArrayItems.Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y)).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        }  //EndMethod



        [NoRewrite]
        public IEnumerable<int> ArrayJoinConcatJoindConcatArray()
        {
            return ArrayItems.Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Concat(ArrayItems.Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y)).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Concat(ArrayItems);
        }  //EndMethod

        public IEnumerable<int> ArrayJoinConcatJoindConcatArrayRewritten()
        {
            return ArrayItems.Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Concat(ArrayItems.Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y)).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Concat(ArrayItems);
        }  //EndMethod

        [NoRewrite]
        public IEnumerable<int> ArrayConcatArray()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArrayConcatArrayRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatSimpleList()
        {
            return ArrayItems.Concat(SimpleListItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArrayConcatSimpleListRewritten()
        {
            return ArrayItems.Concat(SimpleListItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatEnumerable()
        {
            return ArrayItems.Concat(EnumerableItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArrayConcatEnumerableRewritten()
        {
            return ArrayItems.Concat(EnumerableItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatMethod()
        {
            return ArrayItems.Concat(MethodEnumerable2()).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArrayConcatMethodRewritten()
        {
            return ArrayItems.Concat(MethodEnumerable2()).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListConcatArray()
        {
            return SimpleListItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> SimpleListConcatArrayRewritten()
        {
            return SimpleListItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListConcatSimpleList()
        {
            return SimpleListItems.Concat(SimpleListItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> SimpleListConcatSimpleListRewritten()
        {
            return SimpleListItems.Concat(SimpleListItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListConcatEnumerable()
        {
            return SimpleListItems.Concat(EnumerableItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> SimpleListConcatEnumerableRewritten()
        {
            return SimpleListItems.Concat(EnumerableItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListConcatMethod()
        {
            return SimpleListItems.Concat(MethodEnumerable2()).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> SimpleListConcatMethodRewritten()
        {
            return SimpleListItems.Concat(MethodEnumerable2()).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableConcatArray()
        {
            return EnumerableItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> EnumerableConcatArrayRewritten()
        {
            return EnumerableItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableConcatSimpleList()
        {
            return EnumerableItems.Concat(SimpleListItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> EnumerableConcatSimpleListRewritten()
        {
            return EnumerableItems.Concat(SimpleListItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableConcatEnumerable()
        {
            return EnumerableItems.Concat(EnumerableItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> EnumerableConcatEnumerableRewritten()
        {
            return EnumerableItems.Concat(EnumerableItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableConcatMethod()
        {
            return EnumerableItems.Concat(MethodEnumerable2()).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> EnumerableConcatMethodRewritten()
        {
            return EnumerableItems.Concat(MethodEnumerable2()).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> MethodConcatArray()
        {
            return MethodEnumerable().Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> MethodConcatArrayRewritten()
        {
            return MethodEnumerable().Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> MethodConcatSimpleList()
        {
            return MethodEnumerable().Concat(SimpleListItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> MethodConcatSimpleListRewritten()
        {
            return MethodEnumerable().Concat(SimpleListItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> MethodConcatEnumerable()
        {
            return MethodEnumerable().Concat(EnumerableItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> MethodConcatEnumerableRewritten()
        {
            return MethodEnumerable().Concat(EnumerableItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> MethodConcatMethod()
        {
            return MethodEnumerable().Concat(MethodEnumerable2()).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> MethodConcatMethodRewritten()
        {
            return MethodEnumerable().Concat(MethodEnumerable2()).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatArrayToArray()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).ToArray();
        } //EndMethod

        public IEnumerable<int> ArrayConcatArrayToArrayRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatSimpleListToArray()
        {
            return ArrayItems.Concat(SimpleListItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).ToArray();
        } //EndMethod

        public IEnumerable<int> ArrayConcatSimpleListToArrayRewritten()
        {
            return ArrayItems.Concat(SimpleListItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatEnumerableToArray()
        {
            return ArrayItems.Concat(EnumerableItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).ToArray();
        } //EndMethod

        public IEnumerable<int> ArrayConcatEnumerableToArrayRewritten()
        {
            return ArrayItems.Concat(EnumerableItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListConcatArrayToArray()
        {
            return SimpleListItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).ToArray();
        } //EndMethod

        public IEnumerable<int> SimpleListConcatArrayToArrayRewritten()
        {
            return SimpleListItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListConcatSimpleListToArray()
        {
            return SimpleListItems.Concat(SimpleListItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).ToArray();
        } //EndMethod

        public IEnumerable<int> SimpleListConcatSimpleListToArrayRewritten()
        {
            return SimpleListItems.Concat(SimpleListItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListConcatEnumerableToArray()
        {
            return SimpleListItems.Concat(EnumerableItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).ToArray();
        } //EndMethod

        public IEnumerable<int> SimpleListConcatEnumerableToArrayRewritten()
        {
            return SimpleListItems.Concat(EnumerableItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableConcatArrayToArray()
        {
            return EnumerableItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).ToArray();
        } //EndMethod

        public IEnumerable<int> EnumerableConcatArrayToArrayRewritten()
        {
            return EnumerableItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableConcatSimpleListToArray()
        {
            return EnumerableItems.Concat(SimpleListItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).ToArray();
        } //EndMethod

        public IEnumerable<int> EnumerableConcatSimpleListToArrayRewritten()
        {
            return EnumerableItems.Concat(SimpleListItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableConcatEnumerableToArray()
        {
            return EnumerableItems.Concat(EnumerableItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).ToArray();
        } //EndMethod

        public IEnumerable<int> EnumerableConcatEnumerableToArrayRewritten()
        {
            return EnumerableItems.Concat(EnumerableItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArraySelectConcatArray()
        {
            return ArrayItems.Select(x => x + 50).Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArraySelectConcatArrayRewritten()
        {
            return ArrayItems.Select(x => x + 50).Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArraySelectConcatArraySelect()
        {
            return ArrayItems.Select(x => x + 50).Concat(ArrayItems2.Select(x => x + 50)).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArraySelectConcatArraySelectRewritten()
        {
            return ArrayItems.Select(x => x + 50).Concat(ArrayItems2.Select(x => x + 50)).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayWhereConcatArrayWhere()
        {
            return ArrayItems.Where(x => x > 50).Concat(ArrayItems2.Where(x => x > 50)).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArrayWhereConcatArrayWhereRewritten()
        {
            return ArrayItems.Where(x => x > 50).Concat(ArrayItems2.Where(x => x > 50)).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArrayCount()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Count();
        } //EndMethod

        public int ArrayConcatArrayCountRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Count();
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArrayCount2()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Count(x => x > 70);
        } //EndMethod

        public int ArrayConcatArrayCount2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Count(x => x > 70);
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArraySum()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Sum();
        } //EndMethod

        public int ArrayConcatArraySumRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Sum();
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArraySum2()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Sum(x => x + 10);
        } //EndMethod

        public int ArrayConcatArraySum2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Sum(x => x + 10);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatArrayDistinct()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Distinct().Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArrayConcatArrayDistinctRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Distinct().Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatArrayDistinct2()
        {
            return ArrayItems.Concat(ArrayItems2).Distinct(EqualityComparer<int>.Default).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArrayConcatArrayDistinct2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Distinct(EqualityComparer<int>.Default).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArrayElementAt()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).ElementAt(45);
        } //EndMethod

        public int ArrayConcatArrayElementAtRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).ElementAt(45);
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArrayElementAtOrDefault()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).ElementAtOrDefault(45);
        } //EndMethod

        public int ArrayConcatArrayElementAtOrDefaultRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).ElementAtOrDefault(45);
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArrayFirst()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).First();
        } //EndMethod

        public int ArrayConcatArrayFirstRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).First();
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArrayFirstOrDefault()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).FirstOrDefault();
        } //EndMethod

        public int ArrayConcatArrayFirstOrDefaultRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).FirstOrDefault();
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArrayLast()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Last();
        } //EndMethod

        public int ArrayConcatArrayLastRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Last();
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArrayLastOrDefault()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).LastOrDefault();
        } //EndMethod

        public int ArrayConcatArrayLastOrDefaultRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).LastOrDefault();
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArraySingle()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Single();
        } //EndMethod

        public int ArrayConcatArraySingleRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Single();
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArraySingle2()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Single(x => x == 76);
        } //EndMethod

        public int ArrayConcatArraySingle2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Single(x => x == 76);
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArraySingleOrDefault()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).SingleOrDefault();
        } //EndMethod

        public int ArrayConcatArraySingleOrDefaultRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).SingleOrDefault();
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArrayMin()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Min();
        } //EndMethod

        public int ArrayConcatArrayMinRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Min();
        } //EndMethod


        [NoRewrite]
        public decimal ArrayConcatArrayMin2()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Min(x => x + 2m);
        } //EndMethod

        public decimal ArrayConcatArrayMin2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Min(x => x + 2m);
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArrayMax()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Max();
        } //EndMethod

        public int ArrayConcatArrayMaxRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Max();
        } //EndMethod


        [NoRewrite]
        public decimal ArrayConcatArrayMax2()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Max(x => x + 2m);
        } //EndMethod

        public decimal ArrayConcatArrayMax2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Max(x => x + 2m);
        } //EndMethod


        [NoRewrite]
        public long ArrayConcatArrayLongCount()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).LongCount();
        } //EndMethod

        public long ArrayConcatArrayLongCountRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).LongCount();
        } //EndMethod


        [NoRewrite]
        public long ArrayConcatArrayLongCount2()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).LongCount(x => x > 50);
        } //EndMethod

        public long ArrayConcatArrayLongCount2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).LongCount(x => x > 50);
        } //EndMethod


        [NoRewrite]
        public bool ArrayConcatArrayContains()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Contains(56);
        } //EndMethod

        public bool ArrayConcatArrayContainsRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Contains(56);
        } //EndMethod


        [NoRewrite]
        public double ArrayConcatArrayAverage()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Average();
        } //EndMethod

        public double ArrayConcatArrayAverageRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Average();
        } //EndMethod


        [NoRewrite]
        public double ArrayConcatArrayAverage2()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Average(x => x + 10);
        } //EndMethod

        public double ArrayConcatArrayAverage2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Average(x => x + 10);
        } //EndMethod


        [NoRewrite]
        public bool ArrayConcatArrayContains2()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Contains(56, EqualityComparer<int>.Default);
        } //EndMethod

        public bool ArrayConcatArrayContains2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Contains(56, EqualityComparer<int>.Default);
        } //EndMethod


        [NoRewrite]
        public bool SelectWhereArrayConcatSelectWhereArrayContains()
        {
            return ArrayItems.Select(x => x + 10).Where(x => x > 80).Concat(ArrayItems2.Select(x => x + 10).Where(x => x > 80)).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Contains(112);
        } //EndMethod

        public bool SelectWhereArrayConcatSelectWhereArrayContainsRewritten()
        {
            return ArrayItems.Select(x => x + 10).Where(x => x > 80).Concat(ArrayItems2.Select(x => x + 10).Where(x => x > 80)).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y).Contains(112);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RangeConcatArray()
        {
            return Enumerable.Range(20, 100).Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> RangeConcatArrayRewritten()
        {
            return Enumerable.Range(20, 100).Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RepeatConcatArray()
        {
            return Enumerable.Repeat(20, 100).Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> RepeatConcatArrayRewritten()
        {
            return Enumerable.Repeat(20, 100).Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EmptyConcatArray()
        {
            return Enumerable.Empty<int>().Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> EmptyConcatArrayRewritten()
        {
            return Enumerable.Empty<int>().Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RangeEmpty2Array()
        {
            return ArrayItems.Where(x => false).Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> RangeEmpty2ArrayRewritten()
        {
            return ArrayItems.Where(x => false).Concat(ArrayItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatRange()
        {
            return ArrayItems.Concat(Enumerable.Range(70, 260)).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArrayConcatRangeRewritten()
        {
            return ArrayItems.Concat(Enumerable.Range(70, 260)).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatRepeat()
        {
            return ArrayItems.Concat(Enumerable.Repeat(70, 100)).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArrayConcatRepeatRewritten()
        {
            return ArrayItems.Concat(Enumerable.Repeat(70, 100)).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatEmpty()
        {
            return ArrayItems.Concat(Enumerable.Empty<int>()).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArrayConcatEmptyRewritten()
        {
            return ArrayItems.Concat(Enumerable.Empty<int>()).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatEmpty2()
        {
            return ArrayItems.Concat(ArrayItems2.Where(x => false)).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArrayConcatEmpty2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2.Where(x => false)).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatAll()
        {
            return ArrayItems.Concat(Enumerable.Range(0, 1000)).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArrayConcatAllRewritten()
        {
            return ArrayItems.Concat(Enumerable.Range(0, 1000)).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatNull()
        {
            return ArrayItems.Concat(null).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArrayConcatNullRewritten()
        {
            return ArrayItems.Concat(null).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatArrayConcatEnumerable()
        {
            return ArrayItems.Concat(ArrayItems).Concat(EnumerableItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArrayConcatArrayConcatEnumerableRewritten()
        {
            return ArrayItems.Concat(ArrayItems).Concat(EnumerableItems2).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatArrayConcatEnumerable2()
        {
            return ArrayItems.Concat(ArrayItems.Concat(EnumerableItems2)).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArrayConcatArrayConcatEnumerable2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems.Concat(EnumerableItems2)).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayDistinctConcatArrayDistinct()
        {
            return ArrayItems.Distinct().Concat(ArrayItems.Distinct()).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArrayDistinctConcatArrayDistinctRewritten()
        {
            return ArrayItems.Distinct().Concat(ArrayItems.Distinct()).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinct()
        {
            return ArrayItems.Distinct().Concat(ArrayItems.Distinct()).Distinct().Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinctRewritten()
        {
            return ArrayItems.Distinct().Concat(ArrayItems.Distinct()).Distinct().Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinct2()
        {
            return ArrayItems.Distinct(EqualityComparer<int>.Default).Concat(ArrayItems.Distinct(EqualityComparer<int>.Default)).Distinct(EqualityComparer<int>.Default).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

        public IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinct2Rewritten()
        {
            return ArrayItems.Distinct(EqualityComparer<int>.Default).Concat(ArrayItems.Distinct(EqualityComparer<int>.Default)).Distinct(EqualityComparer<int>.Default).Join(ArrayItems2, x => x % 10, x => x % 10, (x, y) => x + y);
        } //EndMethod

    }
}