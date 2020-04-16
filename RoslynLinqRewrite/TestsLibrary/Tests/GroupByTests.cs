using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class GroupByTests
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
            TestsExtensions.TestEquals(nameof(ArrayGroupBy), ArrayGroupBy, ArrayGroupByRewritten);
            TestsExtensions.TestEquals(nameof(ArrayGroupByToArray), ArrayGroupByToArray, ArrayGroupByToArrayRewritten);
            TestsExtensions.TestEquals(nameof(SimpleListGroupBy), SimpleListGroupBy, SimpleListGroupByRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableGroupBy), EnumerableGroupBy, EnumerableGroupByRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableGroupByToArray), EnumerableGroupByToArray, EnumerableGroupByToArrayRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableMethodGroupBy), EnumerableMethodGroupBy, EnumerableMethodGroupByRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableMethodGroupByToArray), EnumerableMethodGroupByToArray, EnumerableMethodGroupByToArrayRewritten);
            TestsExtensions.TestEquals(nameof(RangeGroupBy), RangeGroupBy, RangeGroupByRewritten);
            TestsExtensions.TestEquals(nameof(RangeGroupByToArray), RangeGroupByToArray, RangeGroupByToArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArraySelectGroupBy), ArraySelectGroupBy, ArraySelectGroupByRewritten);
            TestsExtensions.TestEquals(nameof(ArrayWhereGroupBy), ArrayWhereGroupBy, ArrayWhereGroupByRewritten);
            TestsExtensions.TestEquals(nameof(ArrayGroupByWhereGroupBy), ArrayGroupByWhereGroupBy, ArrayGroupByWhereGroupByRewritten);
            TestsExtensions.TestEquals(nameof(ArrayGroupByConcatGroupBy), ArrayGroupByConcatGroupBy, ArrayGroupByConcatGroupByRewritten);
            TestsExtensions.TestEquals(nameof(ArrayGroupByConcatGroupByd), ArrayGroupByConcatGroupByd, ArrayGroupByConcatGroupBydRewritten);
            TestsExtensions.TestEquals(nameof(ArrayGroupByConcatGroupBydConcatArray), ArrayGroupByConcatGroupBydConcatArray, ArrayGroupByConcatGroupBydConcatArrayRewritten);

            TestsExtensions.TestEquals("ArrayConcatArrayGroupByd", ArrayConcatArray, ArrayConcatArrayRewritten);
            TestsExtensions.TestEquals("ArrayConcatSimpleListGroupByd", ArrayConcatSimpleList, ArrayConcatSimpleListRewritten);
            TestsExtensions.TestEquals("ArrayConcatEnumerableGroupByd", ArrayConcatEnumerable, ArrayConcatEnumerableRewritten);
            TestsExtensions.TestEquals("ArrayConcatMethodGroupByd", ArrayConcatMethod, ArrayConcatMethodRewritten);
            TestsExtensions.TestEquals("SimpleListConcatArrayGroupByd", SimpleListConcatArray, SimpleListConcatArrayRewritten);
            TestsExtensions.TestEquals("SimpleListConcatSimpleListGroupByd", SimpleListConcatSimpleList, SimpleListConcatSimpleListRewritten);
            TestsExtensions.TestEquals("SimpleListConcatEnumerableGroupByd", SimpleListConcatEnumerable, SimpleListConcatEnumerableRewritten);
            TestsExtensions.TestEquals("SimpleListConcatMethodGroupByd", SimpleListConcatMethod, SimpleListConcatMethodRewritten);
            TestsExtensions.TestEquals("EnumerableConcatArrayGroupByd", EnumerableConcatArray, EnumerableConcatArrayRewritten);
            TestsExtensions.TestEquals("EnumerableConcatSimpleListGroupByd", EnumerableConcatSimpleList, EnumerableConcatSimpleListRewritten);
            TestsExtensions.TestEquals("EnumerableConcatEnumerableGroupByd", EnumerableConcatEnumerable, EnumerableConcatEnumerableRewritten);
            TestsExtensions.TestEquals("EnumerableConcatMethodGroupByd", EnumerableConcatMethod, EnumerableConcatMethodRewritten);
            TestsExtensions.TestEquals("MethodConcatArrayGroupByd", MethodConcatArray, MethodConcatArrayRewritten);
            TestsExtensions.TestEquals("MethodConcatSimpleListGroupByd", MethodConcatSimpleList, MethodConcatSimpleListRewritten);
            TestsExtensions.TestEquals("MethodConcatEnumerableGroupByd", MethodConcatEnumerable, MethodConcatEnumerableRewritten);
            TestsExtensions.TestEquals("MethodConcatMethodGroupByd", MethodConcatMethod, MethodConcatMethodRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayToArrayGroupByd", ArrayConcatArrayToArray, ArrayConcatArrayToArrayRewritten);
            TestsExtensions.TestEquals("ArrayConcatSimpleListToArrayGroupByd", ArrayConcatSimpleListToArray, ArrayConcatSimpleListToArrayRewritten);
            TestsExtensions.TestEquals("ArrayConcatEnumerableToArrayGroupByd", ArrayConcatEnumerableToArray, ArrayConcatEnumerableToArrayRewritten);
            TestsExtensions.TestEquals("SimpleListConcatArrayToArrayGroupByd", SimpleListConcatArrayToArray, SimpleListConcatArrayToArrayRewritten);
            TestsExtensions.TestEquals("SimpleListConcatSimpleListToArrayGroupByd", SimpleListConcatSimpleListToArray, SimpleListConcatSimpleListToArrayRewritten);
            TestsExtensions.TestEquals("SimpleListConcatEnumerableToArrayGroupByd", SimpleListConcatEnumerableToArray, SimpleListConcatEnumerableToArrayRewritten);
            TestsExtensions.TestEquals("EnumerableConcatArrayToArrayGroupByd", EnumerableConcatArrayToArray, EnumerableConcatArrayToArrayRewritten);
            TestsExtensions.TestEquals("EnumerableConcatSimpleListToArrayGroupByd", EnumerableConcatSimpleListToArray, EnumerableConcatSimpleListToArrayRewritten);
            TestsExtensions.TestEquals("EnumerableConcatEnumerableToArrayGroupByd", EnumerableConcatEnumerableToArray, EnumerableConcatEnumerableToArrayRewritten);
            TestsExtensions.TestEquals("ArraySelectConcatArrayGroupByd", ArraySelectConcatArray, ArraySelectConcatArrayRewritten);
            TestsExtensions.TestEquals("ArraySelectConcatArraySelectGroupByd", ArraySelectConcatArraySelect, ArraySelectConcatArraySelectRewritten);
            TestsExtensions.TestEquals("ArrayWhereConcatArrayWhereGroupByd", ArrayWhereConcatArrayWhere, ArrayWhereConcatArrayWhereRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayCountGroupByd", ArrayConcatArrayCount, ArrayConcatArrayCountRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayCount2GroupByd", ArrayConcatArrayCount2, ArrayConcatArrayCount2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatArraySumGroupByd", ArrayConcatArraySum, ArrayConcatArraySumRewritten);
            TestsExtensions.TestEquals("ArrayConcatArraySum2GroupByd", ArrayConcatArraySum2, ArrayConcatArraySum2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayDistinctGroupByd", ArrayConcatArrayDistinct, ArrayConcatArrayDistinctRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayDistinct2GroupByd", ArrayConcatArrayDistinct2, ArrayConcatArrayDistinct2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayElementAtGroupByd", ArrayConcatArrayElementAt, ArrayConcatArrayElementAtRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayElementAtOrDefaultGroupByd", ArrayConcatArrayElementAtOrDefault, ArrayConcatArrayElementAtOrDefaultRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayFirstGroupByd", ArrayConcatArrayFirst, ArrayConcatArrayFirstRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayFirstOrDefaultGroupByd", ArrayConcatArrayFirstOrDefault, ArrayConcatArrayFirstOrDefaultRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayLastGroupByd", ArrayConcatArrayLast, ArrayConcatArrayLastRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayLastOrDefaultGroupByd", ArrayConcatArrayLastOrDefault, ArrayConcatArrayLastOrDefaultRewritten);
            TestsExtensions.TestEquals("ArrayConcatArraySingleGroupByd", ArrayConcatArraySingle, ArrayConcatArraySingleRewritten);
            TestsExtensions.TestEquals("ArrayConcatArraySingle2GroupByd", ArrayConcatArraySingle2, ArrayConcatArraySingle2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatArraySingleOrDefaultGroupByd", ArrayConcatArraySingleOrDefault, ArrayConcatArraySingleOrDefaultRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayMinGroupByd", ArrayConcatArrayMin, ArrayConcatArrayMinRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayMin2GroupByd", ArrayConcatArrayMin2, ArrayConcatArrayMin2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayMaxGroupByd", ArrayConcatArrayMax, ArrayConcatArrayMaxRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayMax2GroupByd", ArrayConcatArrayMax2, ArrayConcatArrayMax2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayLongCountGroupByd", ArrayConcatArrayLongCount, ArrayConcatArrayLongCountRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayLongCount2GroupByd", ArrayConcatArrayLongCount2, ArrayConcatArrayLongCount2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayContainsGroupByd", ArrayConcatArrayContains, ArrayConcatArrayContainsRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayAverageGroupByd", ArrayConcatArrayAverage, ArrayConcatArrayAverageRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayAverage2GroupByd", ArrayConcatArrayAverage2, ArrayConcatArrayAverage2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayContains2GroupByd", ArrayConcatArrayContains2, ArrayConcatArrayContains2Rewritten);
            TestsExtensions.TestEquals("SelectWhereArrayConcatSelectWhereArrayContainsGroupByd", SelectWhereArrayConcatSelectWhereArrayContains, SelectWhereArrayConcatSelectWhereArrayContainsRewritten);
            TestsExtensions.TestEquals("RangeConcatArrayGroupByd", RangeConcatArray, RangeConcatArrayRewritten);
            TestsExtensions.TestEquals("RepeatConcatArrayGroupByd", RepeatConcatArray, RepeatConcatArrayRewritten);
            TestsExtensions.TestEquals("EmptyConcatArrayGroupByd", EmptyConcatArray, EmptyConcatArrayRewritten);
            TestsExtensions.TestEquals("RangeEmpty2ArrayGroupByd", RangeEmpty2Array, RangeEmpty2ArrayRewritten);
            TestsExtensions.TestEquals("ArrayConcatRangeGroupByd", ArrayConcatRange, ArrayConcatRangeRewritten);
            TestsExtensions.TestEquals("ArrayConcatRepeatGroupByd", ArrayConcatRepeat, ArrayConcatRepeatRewritten);
            TestsExtensions.TestEquals("ArrayConcatEmptyGroupByd", ArrayConcatEmpty, ArrayConcatEmptyRewritten);
            TestsExtensions.TestEquals("ArrayConcatEmpty2GroupByd", ArrayConcatEmpty2, ArrayConcatEmpty2Rewritten);
            TestsExtensions.TestEquals("ArrayConcatAllGroupByd", ArrayConcatAll, ArrayConcatAllRewritten);
            TestsExtensions.TestEquals("ArrayConcatNullGroupByd", ArrayConcatNull, ArrayConcatNullRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayConcatEnumerableGroupByd", ArrayConcatArrayConcatEnumerable, ArrayConcatArrayConcatEnumerableRewritten);
            TestsExtensions.TestEquals("ArrayConcatArrayConcatEnumerable2GroupByd", ArrayConcatArrayConcatEnumerable2, ArrayConcatArrayConcatEnumerable2Rewritten);
            TestsExtensions.TestEquals("ArrayDistinctConcatArrayDistinctGroupByd", ArrayDistinctConcatArrayDistinct, ArrayDistinctConcatArrayDistinctRewritten);
            TestsExtensions.TestEquals("ArrayDistinctConcatArrayDistinctDistinctGroupByd", ArrayDistinctConcatArrayDistinctDistinct, ArrayDistinctConcatArrayDistinctDistinctRewritten);
            TestsExtensions.TestEquals("ArrayDistinctConcatArrayDistinctDistinct2GroupByd", ArrayDistinctConcatArrayDistinctDistinct2, ArrayDistinctConcatArrayDistinctDistinct2Rewritten);
        }

        [NoRewrite]
        public IEnumerable<int> ArrayGroupBy()
        {
            return ArrayItems.GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        }  //EndMethod

        public IEnumerable<int> ArrayGroupByRewritten()
        {
            return ArrayItems.GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        }  //EndMethod



        [NoRewrite]
        public IEnumerable<int> ArrayGroupByToArray()
        {
            return ArrayItems.GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).ToArray();
        }  //EndMethod

        public IEnumerable<int> ArrayGroupByToArrayRewritten()
        {
            return ArrayItems.GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).ToArray();
        }  //EndMethod



        [NoRewrite]
        public IEnumerable<int> SimpleListGroupBy()
        {
            return SimpleListItems.GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        }  //EndMethod

        public IEnumerable<int> SimpleListGroupByRewritten()
        {
            return SimpleListItems.GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        }  //EndMethod



        [NoRewrite]
        public IEnumerable<int> EnumerableGroupBy()
        {
            return EnumerableItems.GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        }  //EndMethod

        public IEnumerable<int> EnumerableGroupByRewritten()
        {
            return EnumerableItems.GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        }  //EndMethod



        [NoRewrite]
        public IEnumerable<int> EnumerableGroupByToArray()
        {
            return EnumerableItems.GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).ToArray();
        }  //EndMethod

        public IEnumerable<int> EnumerableGroupByToArrayRewritten()
        {
            return EnumerableItems.GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).ToArray();
        }  //EndMethod



        [NoRewrite]
        public IEnumerable<int> EnumerableMethodGroupBy()
        {
            return MethodEnumerable().GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        }  //EndMethod

        public IEnumerable<int> EnumerableMethodGroupByRewritten()
        {
            return MethodEnumerable().GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        }  //EndMethod



        [NoRewrite]
        public IEnumerable<int> EnumerableMethodGroupByToArray()
        {
            return MethodEnumerable().GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).ToArray();
        }  //EndMethod

        public IEnumerable<int> EnumerableMethodGroupByToArrayRewritten()
        {
            return MethodEnumerable().GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).ToArray();
        }  //EndMethod



        [NoRewrite]
        public IEnumerable<int> RangeGroupBy()
        {
            return Enumerable.Range(56, 125).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        }  //EndMethod

        public IEnumerable<int> RangeGroupByRewritten()
        {
            return Enumerable.Range(56, 125).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        }  //EndMethod



        [NoRewrite]
        public IEnumerable<int> RangeGroupByToArray()
        {
            return Enumerable.Range(56, 125).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).ToArray();
        }  //EndMethod

        public IEnumerable<int> RangeGroupByToArrayRewritten()
        {
            return Enumerable.Range(56, 125).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).ToArray();
        }  //EndMethod



        [NoRewrite]
        public IEnumerable<int> ArraySelectGroupBy()
        {
            return ArrayItems.Select(x => x + 3).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        }  //EndMethod

        public IEnumerable<int> ArraySelectGroupByRewritten()
        {
            return ArrayItems.Select(x => x + 3).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        }  //EndMethod



        [NoRewrite]
        public IEnumerable<int> ArrayWhereGroupBy()
        {
            return ArrayItems.Where(x => x > 10).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        }  //EndMethod

        public IEnumerable<int> ArrayWhereGroupByRewritten()
        {
            return ArrayItems.Where(x => x > 10).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        }  //EndMethod



        [NoRewrite]
        public IEnumerable<int> ArrayGroupByWhereGroupBy()
        {
            return ArrayItems.GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Where(x => x > 10).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        }  //EndMethod

        public IEnumerable<int> ArrayGroupByWhereGroupByRewritten()
        {
            return ArrayItems.GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Where(x => x > 10).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        }  //EndMethod



        [NoRewrite]
        public IEnumerable<int> ArrayGroupByConcatGroupBy()
        {
            return ArrayItems.GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Concat(ArrayItems).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        }  //EndMethod

        public IEnumerable<int> ArrayGroupByConcatGroupByRewritten()
        {
            return ArrayItems.GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Concat(ArrayItems).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        }  //EndMethod



        [NoRewrite]
        public IEnumerable<int> ArrayGroupByConcatGroupByd()
        {
            return ArrayItems.GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Concat(ArrayItems.GroupBy(x => x % 10, x => x, (x, y) => y.Sum())).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        }  //EndMethod

        public IEnumerable<int> ArrayGroupByConcatGroupBydRewritten()
        {
            return ArrayItems.GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Concat(ArrayItems.GroupBy(x => x % 10, x => x, (x, y) => y.Sum())).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        }  //EndMethod



        [NoRewrite]
        public IEnumerable<int> ArrayGroupByConcatGroupBydConcatArray()
        {
            return ArrayItems.GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Concat(ArrayItems.GroupBy(x => x % 10, x => x, (x, y) => y.Sum())).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Concat(ArrayItems);
        }  //EndMethod

        public IEnumerable<int> ArrayGroupByConcatGroupBydConcatArrayRewritten()
        {
            return ArrayItems.GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Concat(ArrayItems.GroupBy(x => x % 10, x => x, (x, y) => y.Sum())).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Concat(ArrayItems);
        }  //EndMethod

        [NoRewrite]
        public IEnumerable<int> ArrayConcatArray()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> ArrayConcatArrayRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatSimpleList()
        {
            return ArrayItems.Concat(SimpleListItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> ArrayConcatSimpleListRewritten()
        {
            return ArrayItems.Concat(SimpleListItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatEnumerable()
        {
            return ArrayItems.Concat(EnumerableItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> ArrayConcatEnumerableRewritten()
        {
            return ArrayItems.Concat(EnumerableItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatMethod()
        {
            return ArrayItems.Concat(MethodEnumerable2()).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> ArrayConcatMethodRewritten()
        {
            return ArrayItems.Concat(MethodEnumerable2()).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListConcatArray()
        {
            return SimpleListItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> SimpleListConcatArrayRewritten()
        {
            return SimpleListItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListConcatSimpleList()
        {
            return SimpleListItems.Concat(SimpleListItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> SimpleListConcatSimpleListRewritten()
        {
            return SimpleListItems.Concat(SimpleListItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListConcatEnumerable()
        {
            return SimpleListItems.Concat(EnumerableItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> SimpleListConcatEnumerableRewritten()
        {
            return SimpleListItems.Concat(EnumerableItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListConcatMethod()
        {
            return SimpleListItems.Concat(MethodEnumerable2()).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> SimpleListConcatMethodRewritten()
        {
            return SimpleListItems.Concat(MethodEnumerable2()).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableConcatArray()
        {
            return EnumerableItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> EnumerableConcatArrayRewritten()
        {
            return EnumerableItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableConcatSimpleList()
        {
            return EnumerableItems.Concat(SimpleListItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> EnumerableConcatSimpleListRewritten()
        {
            return EnumerableItems.Concat(SimpleListItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableConcatEnumerable()
        {
            return EnumerableItems.Concat(EnumerableItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> EnumerableConcatEnumerableRewritten()
        {
            return EnumerableItems.Concat(EnumerableItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableConcatMethod()
        {
            return EnumerableItems.Concat(MethodEnumerable2()).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> EnumerableConcatMethodRewritten()
        {
            return EnumerableItems.Concat(MethodEnumerable2()).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> MethodConcatArray()
        {
            return MethodEnumerable().Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> MethodConcatArrayRewritten()
        {
            return MethodEnumerable().Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> MethodConcatSimpleList()
        {
            return MethodEnumerable().Concat(SimpleListItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> MethodConcatSimpleListRewritten()
        {
            return MethodEnumerable().Concat(SimpleListItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> MethodConcatEnumerable()
        {
            return MethodEnumerable().Concat(EnumerableItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> MethodConcatEnumerableRewritten()
        {
            return MethodEnumerable().Concat(EnumerableItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> MethodConcatMethod()
        {
            return MethodEnumerable().Concat(MethodEnumerable2()).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> MethodConcatMethodRewritten()
        {
            return MethodEnumerable().Concat(MethodEnumerable2()).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatArrayToArray()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).ToArray();
        } //EndMethod

        public IEnumerable<int> ArrayConcatArrayToArrayRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatSimpleListToArray()
        {
            return ArrayItems.Concat(SimpleListItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).ToArray();
        } //EndMethod

        public IEnumerable<int> ArrayConcatSimpleListToArrayRewritten()
        {
            return ArrayItems.Concat(SimpleListItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatEnumerableToArray()
        {
            return ArrayItems.Concat(EnumerableItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).ToArray();
        } //EndMethod

        public IEnumerable<int> ArrayConcatEnumerableToArrayRewritten()
        {
            return ArrayItems.Concat(EnumerableItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListConcatArrayToArray()
        {
            return SimpleListItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).ToArray();
        } //EndMethod

        public IEnumerable<int> SimpleListConcatArrayToArrayRewritten()
        {
            return SimpleListItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListConcatSimpleListToArray()
        {
            return SimpleListItems.Concat(SimpleListItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).ToArray();
        } //EndMethod

        public IEnumerable<int> SimpleListConcatSimpleListToArrayRewritten()
        {
            return SimpleListItems.Concat(SimpleListItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SimpleListConcatEnumerableToArray()
        {
            return SimpleListItems.Concat(EnumerableItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).ToArray();
        } //EndMethod

        public IEnumerable<int> SimpleListConcatEnumerableToArrayRewritten()
        {
            return SimpleListItems.Concat(EnumerableItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableConcatArrayToArray()
        {
            return EnumerableItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).ToArray();
        } //EndMethod

        public IEnumerable<int> EnumerableConcatArrayToArrayRewritten()
        {
            return EnumerableItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableConcatSimpleListToArray()
        {
            return EnumerableItems.Concat(SimpleListItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).ToArray();
        } //EndMethod

        public IEnumerable<int> EnumerableConcatSimpleListToArrayRewritten()
        {
            return EnumerableItems.Concat(SimpleListItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableConcatEnumerableToArray()
        {
            return EnumerableItems.Concat(EnumerableItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).ToArray();
        } //EndMethod

        public IEnumerable<int> EnumerableConcatEnumerableToArrayRewritten()
        {
            return EnumerableItems.Concat(EnumerableItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArraySelectConcatArray()
        {
            return ArrayItems.Select(x => x + 50).Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> ArraySelectConcatArrayRewritten()
        {
            return ArrayItems.Select(x => x + 50).Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArraySelectConcatArraySelect()
        {
            return ArrayItems.Select(x => x + 50).Concat(ArrayItems2.Select(x => x + 50)).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> ArraySelectConcatArraySelectRewritten()
        {
            return ArrayItems.Select(x => x + 50).Concat(ArrayItems2.Select(x => x + 50)).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayWhereConcatArrayWhere()
        {
            return ArrayItems.Where(x => x > 50).Concat(ArrayItems2.Where(x => x > 50)).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> ArrayWhereConcatArrayWhereRewritten()
        {
            return ArrayItems.Where(x => x > 50).Concat(ArrayItems2.Where(x => x > 50)).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArrayCount()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Count();
        } //EndMethod

        public int ArrayConcatArrayCountRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Count();
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArrayCount2()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Count(x => x > 70);
        } //EndMethod

        public int ArrayConcatArrayCount2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Count(x => x > 70);
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArraySum()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Sum();
        } //EndMethod

        public int ArrayConcatArraySumRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Sum();
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArraySum2()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Sum(x => x + 10);
        } //EndMethod

        public int ArrayConcatArraySum2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Sum(x => x + 10);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatArrayDistinct()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Distinct().GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> ArrayConcatArrayDistinctRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Distinct().GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatArrayDistinct2()
        {
            return ArrayItems.Concat(ArrayItems2).Distinct(EqualityComparer<int>.Default).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> ArrayConcatArrayDistinct2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).Distinct(EqualityComparer<int>.Default).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArrayElementAt()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).ElementAt(45);
        } //EndMethod

        public int ArrayConcatArrayElementAtRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).ElementAt(45);
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArrayElementAtOrDefault()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).ElementAtOrDefault(45);
        } //EndMethod

        public int ArrayConcatArrayElementAtOrDefaultRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).ElementAtOrDefault(45);
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArrayFirst()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).First();
        } //EndMethod

        public int ArrayConcatArrayFirstRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).First();
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArrayFirstOrDefault()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).FirstOrDefault();
        } //EndMethod

        public int ArrayConcatArrayFirstOrDefaultRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).FirstOrDefault();
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArrayLast()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Last();
        } //EndMethod

        public int ArrayConcatArrayLastRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Last();
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArrayLastOrDefault()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).LastOrDefault();
        } //EndMethod

        public int ArrayConcatArrayLastOrDefaultRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).LastOrDefault();
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArraySingle()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Single();
        } //EndMethod

        public int ArrayConcatArraySingleRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Single();
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArraySingle2()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Single(x => x == 76);
        } //EndMethod

        public int ArrayConcatArraySingle2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Single(x => x == 76);
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArraySingleOrDefault()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).SingleOrDefault();
        } //EndMethod

        public int ArrayConcatArraySingleOrDefaultRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).SingleOrDefault();
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArrayMin()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Min();
        } //EndMethod

        public int ArrayConcatArrayMinRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Min();
        } //EndMethod


        [NoRewrite]
        public decimal ArrayConcatArrayMin2()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Min(x => x + 2m);
        } //EndMethod

        public decimal ArrayConcatArrayMin2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Min(x => x + 2m);
        } //EndMethod


        [NoRewrite]
        public int ArrayConcatArrayMax()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Max();
        } //EndMethod

        public int ArrayConcatArrayMaxRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Max();
        } //EndMethod


        [NoRewrite]
        public decimal ArrayConcatArrayMax2()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Max(x => x + 2m);
        } //EndMethod

        public decimal ArrayConcatArrayMax2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Max(x => x + 2m);
        } //EndMethod


        [NoRewrite]
        public long ArrayConcatArrayLongCount()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).LongCount();
        } //EndMethod

        public long ArrayConcatArrayLongCountRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).LongCount();
        } //EndMethod


        [NoRewrite]
        public long ArrayConcatArrayLongCount2()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).LongCount(x => x > 50);
        } //EndMethod

        public long ArrayConcatArrayLongCount2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).LongCount(x => x > 50);
        } //EndMethod


        [NoRewrite]
        public bool ArrayConcatArrayContains()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Contains(56);
        } //EndMethod

        public bool ArrayConcatArrayContainsRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Contains(56);
        } //EndMethod


        [NoRewrite]
        public double ArrayConcatArrayAverage()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Average();
        } //EndMethod

        public double ArrayConcatArrayAverageRewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Average();
        } //EndMethod


        [NoRewrite]
        public double ArrayConcatArrayAverage2()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Average(x => x + 10);
        } //EndMethod

        public double ArrayConcatArrayAverage2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Average(x => x + 10);
        } //EndMethod


        [NoRewrite]
        public bool ArrayConcatArrayContains2()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Contains(56, EqualityComparer<int>.Default);
        } //EndMethod

        public bool ArrayConcatArrayContains2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Contains(56, EqualityComparer<int>.Default);
        } //EndMethod


        [NoRewrite]
        public bool SelectWhereArrayConcatSelectWhereArrayContains()
        {
            return ArrayItems.Select(x => x + 10).Where(x => x > 80).Concat(ArrayItems2.Select(x => x + 10).Where(x => x > 80)).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Contains(112);
        } //EndMethod

        public bool SelectWhereArrayConcatSelectWhereArrayContainsRewritten()
        {
            return ArrayItems.Select(x => x + 10).Where(x => x > 80).Concat(ArrayItems2.Select(x => x + 10).Where(x => x > 80)).GroupBy(x => x % 10, x => x, (x, y) => y.Sum()).Contains(112);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RangeConcatArray()
        {
            return Enumerable.Range(20, 100).Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> RangeConcatArrayRewritten()
        {
            return Enumerable.Range(20, 100).Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RepeatConcatArray()
        {
            return Enumerable.Repeat(20, 100).Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> RepeatConcatArrayRewritten()
        {
            return Enumerable.Repeat(20, 100).Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EmptyConcatArray()
        {
            return Enumerable.Empty<int>().Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> EmptyConcatArrayRewritten()
        {
            return Enumerable.Empty<int>().Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RangeEmpty2Array()
        {
            return ArrayItems.Where(x => false).Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> RangeEmpty2ArrayRewritten()
        {
            return ArrayItems.Where(x => false).Concat(ArrayItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatRange()
        {
            return ArrayItems.Concat(Enumerable.Range(70, 260)).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> ArrayConcatRangeRewritten()
        {
            return ArrayItems.Concat(Enumerable.Range(70, 260)).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatRepeat()
        {
            return ArrayItems.Concat(Enumerable.Repeat(70, 100)).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> ArrayConcatRepeatRewritten()
        {
            return ArrayItems.Concat(Enumerable.Repeat(70, 100)).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatEmpty()
        {
            return ArrayItems.Concat(Enumerable.Empty<int>()).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> ArrayConcatEmptyRewritten()
        {
            return ArrayItems.Concat(Enumerable.Empty<int>()).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatEmpty2()
        {
            return ArrayItems.Concat(ArrayItems2.Where(x => false)).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> ArrayConcatEmpty2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems2.Where(x => false)).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatAll()
        {
            return ArrayItems.Concat(Enumerable.Range(0, 1000)).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> ArrayConcatAllRewritten()
        {
            return ArrayItems.Concat(Enumerable.Range(0, 1000)).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatNull()
        {
            return ArrayItems.Concat(null).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> ArrayConcatNullRewritten()
        {
            return ArrayItems.Concat(null).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatArrayConcatEnumerable()
        {
            return ArrayItems.Concat(ArrayItems).Concat(EnumerableItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> ArrayConcatArrayConcatEnumerableRewritten()
        {
            return ArrayItems.Concat(ArrayItems).Concat(EnumerableItems2).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayConcatArrayConcatEnumerable2()
        {
            return ArrayItems.Concat(ArrayItems.Concat(EnumerableItems2)).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> ArrayConcatArrayConcatEnumerable2Rewritten()
        {
            return ArrayItems.Concat(ArrayItems.Concat(EnumerableItems2)).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayDistinctConcatArrayDistinct()
        {
            return ArrayItems.Distinct().Concat(ArrayItems.Distinct()).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> ArrayDistinctConcatArrayDistinctRewritten()
        {
            return ArrayItems.Distinct().Concat(ArrayItems.Distinct()).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinct()
        {
            return ArrayItems.Distinct().Concat(ArrayItems.Distinct()).Distinct().GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinctRewritten()
        {
            return ArrayItems.Distinct().Concat(ArrayItems.Distinct()).Distinct().GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinct2()
        {
            return ArrayItems.Distinct(EqualityComparer<int>.Default).Concat(ArrayItems.Distinct(EqualityComparer<int>.Default)).Distinct(EqualityComparer<int>.Default).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

        public IEnumerable<int> ArrayDistinctConcatArrayDistinctDistinct2Rewritten()
        {
            return ArrayItems.Distinct(EqualityComparer<int>.Default).Concat(ArrayItems.Distinct(EqualityComparer<int>.Default)).Distinct(EqualityComparer<int>.Default).GroupBy(x => x % 10, x => x, (x, y) => y.Sum());
        } //EndMethod

    }
}