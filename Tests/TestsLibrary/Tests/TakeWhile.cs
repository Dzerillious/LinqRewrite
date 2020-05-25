using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class TakeWhile
    {
        [Datapoints]
        private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
        [Datapoints]
        private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);

        private bool Predicate(int value) => value > 50;
        
        public void RunTests()
        {
            TestsExtensions.TestEquals(nameof(ArrayTakeWhile), ArrayTakeWhile, ArrayTakeWhileRewritten);
            TestsExtensions.TestEquals(nameof(ArrayTakeWhileReverse), ArrayTakeWhileReverse, ArrayTakeWhileReverseRewritten);
            TestsExtensions.TestEquals(nameof(ArrayTakeWhileTrue), ArrayTakeWhileTrue, ArrayTakeWhileTrueRewritten);
            TestsExtensions.TestEquals(nameof(ArrayTakeWhileFalse), ArrayTakeWhileFalse, ArrayTakeWhileFalseRewritten);        
            TestsExtensions.TestEquals(nameof(ArraySelectTakeWhile), ArraySelectTakeWhile, ArraySelectTakeWhileRewritten);        
            TestsExtensions.TestEquals(nameof(ArrayWhereTakeWhile), ArrayWhereTakeWhile, ArrayWhereTakeWhileRewritten);        
            TestsExtensions.TestEquals(nameof(ArrayTakeWhileParam), ArrayTakeWhileParam, ArrayTakeWhileParamRewritten);        
            TestsExtensions.TestEquals(nameof(ArrayTakeWhileChangingParam), ArrayTakeWhileChangingParam, ArrayTakeWhileChangingParamRewritten);        
            TestsExtensions.TestEquals(nameof(ArrayTakeWhileChangingParam2), ArrayTakeWhileChangingParam2, ArrayTakeWhileChangingParam2Rewritten);        
            TestsExtensions.TestEquals(nameof(ArrayTakeWhileChangingParams), ArrayTakeWhileChangingParams, ArrayTakeWhileChangingParamsRewritten);
            TestsExtensions.TestEquals(nameof(ArrayTakeWhileToArray), ArrayTakeWhileToArray, ArrayTakeWhileToArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArrayTakeWhileReverseToArray), ArrayTakeWhileReverseToArray, ArrayTakeWhileReverseToArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArrayTakeWhileTrueToArray), ArrayTakeWhileTrueToArray, ArrayTakeWhileTrueToArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArrayTakeWhileFalseToArray), ArrayTakeWhileFalseToArray, ArrayTakeWhileFalseToArrayRewritten);        
            TestsExtensions.TestEquals(nameof(ArraySelectTakeWhileToArray), ArraySelectTakeWhileToArray, ArraySelectTakeWhileToArrayRewritten);        
            TestsExtensions.TestEquals(nameof(ArrayWhereTakeWhileToArray), ArrayWhereTakeWhileToArray, ArrayWhereTakeWhileToArrayRewritten);        
            TestsExtensions.TestEquals(nameof(ArrayTakeWhileParamToArray), ArrayTakeWhileParamToArray, ArrayTakeWhileParamToArrayRewritten);        
            TestsExtensions.TestEquals(nameof(ArrayTakeWhileChangingParamToArray), ArrayTakeWhileChangingParamToArray, ArrayTakeWhileChangingParamToArrayRewritten);        
            TestsExtensions.TestEquals(nameof(ArrayTakeWhileChangingParamToArray2), ArrayTakeWhileChangingParamToArray2, ArrayTakeWhileChangingParamToArray2Rewritten);        
            TestsExtensions.TestEquals(nameof(ArrayTakeWhileChangingParamsToArray), ArrayTakeWhileChangingParamsToArray, ArrayTakeWhileChangingParamsToArrayRewritten);

            TestsExtensions.TestEquals(nameof(EnumerableTakeWhile), EnumerableTakeWhile, EnumerableTakeWhileRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableTakeWhileReverse), EnumerableTakeWhileReverse, EnumerableTakeWhileReverseRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableTakeWhileTrue), EnumerableTakeWhileTrue, EnumerableTakeWhileTrueRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableTakeWhileFalse), EnumerableTakeWhileFalse, EnumerableTakeWhileFalseRewritten);        
            TestsExtensions.TestEquals(nameof(EnumerableSelectTakeWhile), EnumerableSelectTakeWhile, EnumerableSelectTakeWhileRewritten);        
            TestsExtensions.TestEquals(nameof(EnumerableWhereTakeWhile), EnumerableWhereTakeWhile, EnumerableWhereTakeWhileRewritten);        
            TestsExtensions.TestEquals(nameof(EnumerableTakeWhileParam), EnumerableTakeWhileParam, EnumerableTakeWhileParamRewritten);        
            TestsExtensions.TestEquals(nameof(EnumerableTakeWhileChangingParam), EnumerableTakeWhileChangingParam, EnumerableTakeWhileChangingParamRewritten);        
            TestsExtensions.TestEquals(nameof(EnumerableTakeWhileChangingParam2), EnumerableTakeWhileChangingParam2, EnumerableTakeWhileChangingParam2Rewritten);        
            TestsExtensions.TestEquals(nameof(EnumerableTakeWhileChangingParams), EnumerableTakeWhileChangingParams, EnumerableTakeWhileChangingParamsRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableTakeWhileToArray), EnumerableTakeWhileToArray, EnumerableTakeWhileToArrayRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableTakeWhileReverseToArray), EnumerableTakeWhileReverseToArray, EnumerableTakeWhileReverseToArrayRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableTakeWhileTrueToArray), EnumerableTakeWhileTrueToArray, EnumerableTakeWhileTrueToArrayRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableTakeWhileFalseToArray), EnumerableTakeWhileFalseToArray, EnumerableTakeWhileFalseToArrayRewritten);        
            TestsExtensions.TestEquals(nameof(EnumerableSelectTakeWhileToArray), EnumerableSelectTakeWhileToArray, EnumerableSelectTakeWhileToArrayRewritten);        
            TestsExtensions.TestEquals(nameof(EnumerableWhereTakeWhileToArray), EnumerableWhereTakeWhileToArray, EnumerableWhereTakeWhileToArrayRewritten);        
            TestsExtensions.TestEquals(nameof(EnumerableTakeWhileParamToArray), EnumerableTakeWhileParamToArray, EnumerableTakeWhileParamToArrayRewritten);        
            TestsExtensions.TestEquals(nameof(EnumerableTakeWhileChangingParamToArray), EnumerableTakeWhileChangingParamToArray, EnumerableTakeWhileChangingParamToArrayRewritten);        
            TestsExtensions.TestEquals(nameof(EnumerableTakeWhileChangingParamToArray2), EnumerableTakeWhileChangingParamToArray2, EnumerableTakeWhileChangingParamToArray2Rewritten);        
            TestsExtensions.TestEquals(nameof(EnumerableTakeWhileChangingParamsToArray), EnumerableTakeWhileChangingParamsToArray, EnumerableTakeWhileChangingParamsToArrayRewritten);

            TestsExtensions.TestEquals(nameof(RangeTakeWhile), RangeTakeWhile, RangeTakeWhileRewritten);
            TestsExtensions.TestEquals(nameof(RangeTakeWhileReverse), RangeTakeWhileReverse, RangeTakeWhileReverseRewritten);
            TestsExtensions.TestEquals(nameof(RangeTakeWhileTrue), RangeTakeWhileTrue, RangeTakeWhileTrueRewritten);
            TestsExtensions.TestEquals(nameof(RangeTakeWhileFalse), RangeTakeWhileFalse, RangeTakeWhileFalseRewritten);        
            TestsExtensions.TestEquals(nameof(RangeSelectTakeWhile), RangeSelectTakeWhile, RangeSelectTakeWhileRewritten);        
            TestsExtensions.TestEquals(nameof(RangeWhereTakeWhile), RangeWhereTakeWhile, RangeWhereTakeWhileRewritten);        
            TestsExtensions.TestEquals(nameof(RangeTakeWhileParam), RangeTakeWhileParam, RangeTakeWhileParamRewritten);        
            TestsExtensions.TestEquals(nameof(RangeTakeWhileChangingParam), RangeTakeWhileChangingParam, RangeTakeWhileChangingParamRewritten);        
            TestsExtensions.TestEquals(nameof(RangeTakeWhileChangingParam2), RangeTakeWhileChangingParam2, RangeTakeWhileChangingParam2Rewritten);        
            TestsExtensions.TestEquals(nameof(RangeTakeWhileChangingParams), RangeTakeWhileChangingParams, RangeTakeWhileChangingParamsRewritten);
            TestsExtensions.TestEquals(nameof(RangeTakeWhileToArray), RangeTakeWhileToArray, RangeTakeWhileToArrayRewritten);
            TestsExtensions.TestEquals(nameof(RangeTakeWhileReverseToArray), RangeTakeWhileReverseToArray, RangeTakeWhileReverseToArrayRewritten);
            TestsExtensions.TestEquals(nameof(RangeTakeWhileTrueToArray), RangeTakeWhileTrueToArray, RangeTakeWhileTrueToArrayRewritten);
            TestsExtensions.TestEquals(nameof(RangeTakeWhileFalseToArray), RangeTakeWhileFalseToArray, RangeTakeWhileFalseToArrayRewritten);        
            TestsExtensions.TestEquals(nameof(RangeSelectTakeWhileToArray), RangeSelectTakeWhileToArray, RangeSelectTakeWhileToArrayRewritten);        
            TestsExtensions.TestEquals(nameof(RangeWhereTakeWhileToArray), RangeWhereTakeWhileToArray, RangeWhereTakeWhileToArrayRewritten);        
            TestsExtensions.TestEquals(nameof(RangeTakeWhileParamToArray), RangeTakeWhileParamToArray, RangeTakeWhileParamToArrayRewritten);        
            TestsExtensions.TestEquals(nameof(RangeTakeWhileChangingParamToArray), RangeTakeWhileChangingParamToArray, RangeTakeWhileChangingParamToArrayRewritten);        
            TestsExtensions.TestEquals(nameof(RangeTakeWhileChangingParamToArray2), RangeTakeWhileChangingParamToArray2, RangeTakeWhileChangingParamToArray2Rewritten);        
            TestsExtensions.TestEquals(nameof(RangeTakeWhileChangingParamsToArray), RangeTakeWhileChangingParamsToArray, RangeTakeWhileChangingParamsToArrayRewritten);
        }

        [NoRewrite]
        public IEnumerable<int> ArrayTakeWhile()
        {
            return ArrayItems.TakeWhile(x => x < 50);
        } //EndMethod

        public IEnumerable<int> ArrayTakeWhileRewritten()
        {
            return ArrayItems.TakeWhile(x => x < 50);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayTakeWhileReverse()
        {
            return ArrayItems.TakeWhile(x => x > 50);
        } //EndMethod

        public IEnumerable<int> ArrayTakeWhileReverseRewritten()
        {
            return ArrayItems.TakeWhile(x => x > 50);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayTakeWhileTrue()
        {
            return ArrayItems.TakeWhile(x => true);
        } //EndMethod

        public IEnumerable<int> ArrayTakeWhileTrueRewritten()
        {
            return ArrayItems.TakeWhile(x => true);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayTakeWhileFalse()
        {
            return ArrayItems.TakeWhile(x => false);
        } //EndMethod

        public IEnumerable<int> ArrayTakeWhileFalseRewritten()
        {
            return ArrayItems.TakeWhile(x => false);
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> ArraySelectTakeWhile()
        {
            return ArrayItems.Select(x => x + 20).TakeWhile(x => x < 50);
        } //EndMethod

        public IEnumerable<int> ArraySelectTakeWhileRewritten()
        {
            return ArrayItems.Select(x => x + 20).TakeWhile(x => x < 50);
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> ArrayWhereTakeWhile()
        {
            return ArrayItems.Where(x => x > 20).TakeWhile(x => x < 50);
        } //EndMethod

        public IEnumerable<int> ArrayWhereTakeWhileRewritten()
        {
            return ArrayItems.Where(x => x > 20).TakeWhile(x => x < 50);
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> ArrayTakeWhileParam()
        {
            var a = 50;
            return ArrayItems.TakeWhile(x => x < a);
        } //EndMethod

        public IEnumerable<int> ArrayTakeWhileParamRewritten()
        {
            var a = 50;
            return ArrayItems.TakeWhile(x => x < a);
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> ArrayTakeWhileChangingParam()
        {
            var a = 50;
            return ArrayItems.TakeWhile(x => x < a++);
        } //EndMethod

        public IEnumerable<int> ArrayTakeWhileChangingParamRewritten()
        {
            var a = 50;
            return ArrayItems.TakeWhile(x => x < a++);
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> ArrayTakeWhileChangingParam2()
        {
            var a = 50;
            return ArrayItems.TakeWhile(x => x < a--);
        } //EndMethod

        public IEnumerable<int> ArrayTakeWhileChangingParam2Rewritten()
        {
            var a = 50;
            return ArrayItems.TakeWhile(x => x < a--);
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> ArrayTakeWhileChangingParams()
        {
            var a = 50;
            var b = 50;
            return ArrayItems.TakeWhile(x => x < a++ - b--);
        } //EndMethod

        public IEnumerable<int> ArrayTakeWhileChangingParamsRewritten()
        {
            var a = 50;
            var b = 50;
            return ArrayItems.TakeWhile(x => x < a++ - b--);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayTakeWhileToArray()
        {
            return ArrayItems.TakeWhile(x => x < 50).ToArray();
        } //EndMethod

        public IEnumerable<int> ArrayTakeWhileToArrayRewritten()
        {
            return ArrayItems.TakeWhile(x => x < 50).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayTakeWhileReverseToArray()
        {
            return ArrayItems.TakeWhile(x => x > 50).ToArray();
        } //EndMethod

        public IEnumerable<int> ArrayTakeWhileReverseToArrayRewritten()
        {
            return ArrayItems.TakeWhile(x => x > 50).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayTakeWhileTrueToArray()
        {
            return ArrayItems.TakeWhile(x => true).ToArray();
        } //EndMethod

        public IEnumerable<int> ArrayTakeWhileTrueToArrayRewritten()
        {
            return ArrayItems.TakeWhile(x => true).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ArrayTakeWhileFalseToArray()
        {
            return ArrayItems.TakeWhile(x => false).ToArray();
        } //EndMethod

        public IEnumerable<int> ArrayTakeWhileFalseToArrayRewritten()
        {
            return ArrayItems.TakeWhile(x => false).ToArray();
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> ArraySelectTakeWhileToArray()
        {
            return ArrayItems.Select(x => x + 20).TakeWhile(x => x < 50).ToArray();
        } //EndMethod

        public IEnumerable<int> ArraySelectTakeWhileToArrayRewritten()
        {
            return ArrayItems.Select(x => x + 20).TakeWhile(x => x < 50).ToArray();
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> ArrayWhereTakeWhileToArray()
        {
            return ArrayItems.Where(x => x > 20).TakeWhile(x => x < 50).ToArray();
        } //EndMethod

        public IEnumerable<int> ArrayWhereTakeWhileToArrayRewritten()
        {
            return ArrayItems.Where(x => x > 20).TakeWhile(x => x < 50).ToArray();
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> ArrayTakeWhileParamToArray()
        {
            var a = 50;
            return ArrayItems.TakeWhile(x => x < a).ToArray();
        } //EndMethod

        public IEnumerable<int> ArrayTakeWhileParamToArrayRewritten()
        {
            var a = 50;
            return ArrayItems.TakeWhile(x => x < a).ToArray();
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> ArrayTakeWhileChangingParamToArray()
        {
            var a = 50;
            return ArrayItems.TakeWhile(x => x < a++).ToArray();
        } //EndMethod

        public IEnumerable<int> ArrayTakeWhileChangingParamToArrayRewritten()
        {
            var a = 50;
            return ArrayItems.TakeWhile(x => x < a++).ToArray();
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> ArrayTakeWhileChangingParamToArray2()
        {
            var a = 50;
            return ArrayItems.TakeWhile(x => x < a--).ToArray();
        } //EndMethod

        public IEnumerable<int> ArrayTakeWhileChangingParamToArray2Rewritten()
        {
            var a = 50;
            return ArrayItems.TakeWhile(x => x < a--).ToArray();
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> ArrayTakeWhileChangingParamsToArray()
        {
            var a = 50;
            var b = 50;
            return ArrayItems.TakeWhile(x => x < a++ - b--).ToArray();
        } //EndMethod

        public IEnumerable<int> ArrayTakeWhileChangingParamsToArrayRewritten()
        {
            var a = 50;
            var b = 50;
            return ArrayItems.TakeWhile(x => x < a++ - b--).ToArray();
        } //EndMethod



        [NoRewrite]
        public IEnumerable<int> EnumerableTakeWhile()
        {
            return EnumerableItems.TakeWhile(x => x < 50);
        } //EndMethod

        public IEnumerable<int> EnumerableTakeWhileRewritten()
        {
            return EnumerableItems.TakeWhile(x => x < 50);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableTakeWhileReverse()
        {
            return EnumerableItems.TakeWhile(x => x > 50);
        } //EndMethod

        public IEnumerable<int> EnumerableTakeWhileReverseRewritten()
        {
            return EnumerableItems.TakeWhile(x => x > 50);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableTakeWhileTrue()
        {
            return EnumerableItems.TakeWhile(x => true);
        } //EndMethod

        public IEnumerable<int> EnumerableTakeWhileTrueRewritten()
        {
            return EnumerableItems.TakeWhile(x => true);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableTakeWhileFalse()
        {
            return EnumerableItems.TakeWhile(x => false);
        } //EndMethod

        public IEnumerable<int> EnumerableTakeWhileFalseRewritten()
        {
            return EnumerableItems.TakeWhile(x => false);
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> EnumerableSelectTakeWhile()
        {
            return EnumerableItems.Select(x => x + 20).TakeWhile(x => x < 50);
        } //EndMethod

        public IEnumerable<int> EnumerableSelectTakeWhileRewritten()
        {
            return EnumerableItems.Select(x => x + 20).TakeWhile(x => x < 50);
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> EnumerableWhereTakeWhile()
        {
            return EnumerableItems.Where(x => x > 20).TakeWhile(x => x < 50);
        } //EndMethod

        public IEnumerable<int> EnumerableWhereTakeWhileRewritten()
        {
            return EnumerableItems.Where(x => x > 20).TakeWhile(x => x < 50);
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> EnumerableTakeWhileParam()
        {
            var a = 50;
            return EnumerableItems.TakeWhile(x => x < a);
        } //EndMethod

        public IEnumerable<int> EnumerableTakeWhileParamRewritten()
        {
            var a = 50;
            return EnumerableItems.TakeWhile(x => x < a);
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> EnumerableTakeWhileChangingParam()
        {
            var a = 50;
            return EnumerableItems.TakeWhile(x => x < a++);
        } //EndMethod

        public IEnumerable<int> EnumerableTakeWhileChangingParamRewritten()
        {
            var a = 50;
            return EnumerableItems.TakeWhile(x => x < a++);
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> EnumerableTakeWhileChangingParam2()
        {
            var a = 50;
            return EnumerableItems.TakeWhile(x => x < a--);
        } //EndMethod

        public IEnumerable<int> EnumerableTakeWhileChangingParam2Rewritten()
        {
            var a = 50;
            return EnumerableItems.TakeWhile(x => x < a--);
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> EnumerableTakeWhileChangingParams()
        {
            var a = 50;
            var b = 50;
            return EnumerableItems.TakeWhile(x => x < a++ - b--);
        } //EndMethod

        public IEnumerable<int> EnumerableTakeWhileChangingParamsRewritten()
        {
            var a = 50;
            var b = 50;
            return EnumerableItems.TakeWhile(x => x < a++ - b--);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableTakeWhileToArray()
        {
            return EnumerableItems.TakeWhile(x => x < 50).ToArray();
        } //EndMethod

        public IEnumerable<int> EnumerableTakeWhileToArrayRewritten()
        {
            return EnumerableItems.TakeWhile(x => x < 50).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableTakeWhileReverseToArray()
        {
            return EnumerableItems.TakeWhile(x => x > 50).ToArray();
        } //EndMethod

        public IEnumerable<int> EnumerableTakeWhileReverseToArrayRewritten()
        {
            return EnumerableItems.TakeWhile(x => x > 50).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableTakeWhileTrueToArray()
        {
            return EnumerableItems.TakeWhile(x => true).ToArray();
        } //EndMethod

        public IEnumerable<int> EnumerableTakeWhileTrueToArrayRewritten()
        {
            return EnumerableItems.TakeWhile(x => true).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> EnumerableTakeWhileFalseToArray()
        {
            return EnumerableItems.TakeWhile(x => false).ToArray();
        } //EndMethod

        public IEnumerable<int> EnumerableTakeWhileFalseToArrayRewritten()
        {
            return EnumerableItems.TakeWhile(x => false).ToArray();
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> EnumerableSelectTakeWhileToArray()
        {
            return EnumerableItems.Select(x => x + 20).TakeWhile(x => x < 50).ToArray();
        } //EndMethod

        public IEnumerable<int> EnumerableSelectTakeWhileToArrayRewritten()
        {
            return EnumerableItems.Select(x => x + 20).TakeWhile(x => x < 50).ToArray();
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> EnumerableWhereTakeWhileToArray()
        {
            return EnumerableItems.Where(x => x > 20).TakeWhile(x => x < 50).ToArray();
        } //EndMethod

        public IEnumerable<int> EnumerableWhereTakeWhileToArrayRewritten()
        {
            return EnumerableItems.Where(x => x > 20).TakeWhile(x => x < 50).ToArray();
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> EnumerableTakeWhileParamToArray()
        {
            var a = 50;
            return EnumerableItems.TakeWhile(x => x < a).ToArray();
        } //EndMethod

        public IEnumerable<int> EnumerableTakeWhileParamToArrayRewritten()
        {
            var a = 50;
            return EnumerableItems.TakeWhile(x => x < a).ToArray();
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> EnumerableTakeWhileChangingParamToArray()
        {
            var a = 50;
            return EnumerableItems.TakeWhile(x => x < a++).ToArray();
        } //EndMethod

        public IEnumerable<int> EnumerableTakeWhileChangingParamToArrayRewritten()
        {
            var a = 50;
            return EnumerableItems.TakeWhile(x => x < a++).ToArray();
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> EnumerableTakeWhileChangingParamToArray2()
        {
            var a = 50;
            return EnumerableItems.TakeWhile(x => x < a--).ToArray();
        } //EndMethod

        public IEnumerable<int> EnumerableTakeWhileChangingParamToArray2Rewritten()
        {
            var a = 50;
            return EnumerableItems.TakeWhile(x => x < a--).ToArray();
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> EnumerableTakeWhileChangingParamsToArray()
        {
            var a = 50;
            var b = 50;
            return EnumerableItems.TakeWhile(x => x < a++ - b--).ToArray();
        } //EndMethod

        public IEnumerable<int> EnumerableTakeWhileChangingParamsToArrayRewritten()
        {
            var a = 50;
            var b = 50;
            return EnumerableItems.TakeWhile(x => x < a++ - b--).ToArray();
        } //EndMethod



        [NoRewrite]
        public IEnumerable<int> RangeTakeWhile()
        {
            return Enumerable.Range(0, 100).TakeWhile(x => x < 50);
        } //EndMethod

        public IEnumerable<int> RangeTakeWhileRewritten()
        {
            return Enumerable.Range(0, 100).TakeWhile(x => x < 50);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RangeTakeWhileReverse()
        {
            return Enumerable.Range(0, 100).TakeWhile(x => x > 50);
        } //EndMethod

        public IEnumerable<int> RangeTakeWhileReverseRewritten()
        {
            return Enumerable.Range(0, 100).TakeWhile(x => x > 50);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RangeTakeWhileTrue()
        {
            return Enumerable.Range(0, 100).TakeWhile(x => true);
        } //EndMethod

        public IEnumerable<int> RangeTakeWhileTrueRewritten()
        {
            return Enumerable.Range(0, 100).TakeWhile(x => true);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RangeTakeWhileFalse()
        {
            return Enumerable.Range(0, 100).TakeWhile(x => false);
        } //EndMethod

        public IEnumerable<int> RangeTakeWhileFalseRewritten()
        {
            return Enumerable.Range(0, 100).TakeWhile(x => false);
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> RangeSelectTakeWhile()
        {
            return Enumerable.Range(0, 100).Select(x => x + 20).TakeWhile(x => x < 50);
        } //EndMethod

        public IEnumerable<int> RangeSelectTakeWhileRewritten()
        {
            return Enumerable.Range(0, 100).Select(x => x + 20).TakeWhile(x => x < 50);
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> RangeWhereTakeWhile()
        {
            return Enumerable.Range(0, 100).Where(x => x > 20).TakeWhile(x => x < 50);
        } //EndMethod

        public IEnumerable<int> RangeWhereTakeWhileRewritten()
        {
            return Enumerable.Range(0, 100).Where(x => x > 20).TakeWhile(x => x < 50);
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> RangeTakeWhileParam()
        {
            var a = 50;
            return Enumerable.Range(0, 100).TakeWhile(x => x < a);
        } //EndMethod

        public IEnumerable<int> RangeTakeWhileParamRewritten()
        {
            var a = 50;
            return Enumerable.Range(0, 100).TakeWhile(x => x < a);
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> RangeTakeWhileChangingParam()
        {
            var a = 50;
            return Enumerable.Range(0, 100).TakeWhile(x => x < a++);
        } //EndMethod

        public IEnumerable<int> RangeTakeWhileChangingParamRewritten()
        {
            var a = 50;
            return Enumerable.Range(0, 100).TakeWhile(x => x < a++);
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> RangeTakeWhileChangingParam2()
        {
            var a = 50;
            return Enumerable.Range(0, 100).TakeWhile(x => x < a--);
        } //EndMethod

        public IEnumerable<int> RangeTakeWhileChangingParam2Rewritten()
        {
            var a = 50;
            return Enumerable.Range(0, 100).TakeWhile(x => x < a--);
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> RangeTakeWhileChangingParams()
        {
            var a = 50;
            var b = 50;
            return Enumerable.Range(0, 100).TakeWhile(x => x < a++ - b--);
        } //EndMethod

        public IEnumerable<int> RangeTakeWhileChangingParamsRewritten()
        {
            var a = 50;
            var b = 50;
            return Enumerable.Range(0, 100).TakeWhile(x => x < a++ - b--);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RangeTakeWhileToArray()
        {
            return Enumerable.Range(0, 100).TakeWhile(x => x < 50).ToArray();
        } //EndMethod

        public IEnumerable<int> RangeTakeWhileToArrayRewritten()
        {
            return Enumerable.Range(0, 100).TakeWhile(x => x < 50).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RangeTakeWhileReverseToArray()
        {
            return Enumerable.Range(0, 100).TakeWhile(x => x > 50).ToArray();
        } //EndMethod

        public IEnumerable<int> RangeTakeWhileReverseToArrayRewritten()
        {
            return Enumerable.Range(0, 100).TakeWhile(x => x > 50).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RangeTakeWhileTrueToArray()
        {
            return Enumerable.Range(0, 100).TakeWhile(x => true).ToArray();
        } //EndMethod

        public IEnumerable<int> RangeTakeWhileTrueToArrayRewritten()
        {
            return Enumerable.Range(0, 100).TakeWhile(x => true).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> RangeTakeWhileFalseToArray()
        {
            return Enumerable.Range(0, 100).TakeWhile(x => false).ToArray();
        } //EndMethod

        public IEnumerable<int> RangeTakeWhileFalseToArrayRewritten()
        {
            return Enumerable.Range(0, 100).TakeWhile(x => false).ToArray();
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> RangeSelectTakeWhileToArray()
        {
            return Enumerable.Range(0, 100).Select(x => x + 20).TakeWhile(x => x < 50).ToArray();
        } //EndMethod

        public IEnumerable<int> RangeSelectTakeWhileToArrayRewritten()
        {
            return Enumerable.Range(0, 100).Select(x => x + 20).TakeWhile(x => x < 50).ToArray();
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> RangeWhereTakeWhileToArray()
        {
            return Enumerable.Range(0, 100).Where(x => x > 20).TakeWhile(x => x < 50).ToArray();
        } //EndMethod

        public IEnumerable<int> RangeWhereTakeWhileToArrayRewritten()
        {
            return Enumerable.Range(0, 100).Where(x => x > 20).TakeWhile(x => x < 50).ToArray();
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> RangeTakeWhileParamToArray()
        {
            var a = 50;
            return Enumerable.Range(0, 100).TakeWhile(x => x < a).ToArray();
        } //EndMethod

        public IEnumerable<int> RangeTakeWhileParamToArrayRewritten()
        {
            var a = 50;
            return Enumerable.Range(0, 100).TakeWhile(x => x < a).ToArray();
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> RangeTakeWhileChangingParamToArray()
        {
            var a = 50;
            return Enumerable.Range(0, 100).TakeWhile(x => x < a++).ToArray();
        } //EndMethod

        public IEnumerable<int> RangeTakeWhileChangingParamToArrayRewritten()
        {
            var a = 50;
            return Enumerable.Range(0, 100).TakeWhile(x => x < a++).ToArray();
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> RangeTakeWhileChangingParamToArray2()
        {
            var a = 50;
            return Enumerable.Range(0, 100).TakeWhile(x => x < a--).ToArray();
        } //EndMethod

        public IEnumerable<int> RangeTakeWhileChangingParamToArray2Rewritten()
        {
            var a = 50;
            return Enumerable.Range(0, 100).TakeWhile(x => x < a--).ToArray();
        } //EndMethod

        
        [NoRewrite]
        public IEnumerable<int> RangeTakeWhileChangingParamsToArray()
        {
            var a = 50;
            var b = 50;
            return Enumerable.Range(0, 100).TakeWhile(x => x < a++ - b--).ToArray();
        } //EndMethod

        public IEnumerable<int> RangeTakeWhileChangingParamsToArrayRewritten()
        {
            var a = 50;
            var b = 50;
            return Enumerable.Range(0, 100).TakeWhile(x => x < a++ - b--).ToArray();
        } //EndMethod

    }
}