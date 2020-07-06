using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class SkipWhile
    {
        
        [Datapoints]
        private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
        [Datapoints]
        private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);

        private bool Predicate(int value) => value > 50;
        
        public void RunTests()
        {
            TestsExtensions.TestEquals(nameof(ArraySkipWhile), ArraySkipWhile, ArraySkipWhileRewritten);
            TestsExtensions.TestEquals(nameof(ArraySkipWhileReverse), ArraySkipWhileReverse, ArraySkipWhileReverseRewritten);
            TestsExtensions.TestEquals(nameof(ArraySkipWhileTrue), ArraySkipWhileTrue, ArraySkipWhileTrueRewritten);
            TestsExtensions.TestEquals(nameof(ArraySkipWhileFalse), ArraySkipWhileFalse, ArraySkipWhileFalseRewritten);        
            TestsExtensions.TestEquals(nameof(ArraySelectSkipWhile), ArraySelectSkipWhile, ArraySelectSkipWhileRewritten);        
            TestsExtensions.TestEquals(nameof(ArrayWhereSkipWhile), ArrayWhereSkipWhile, ArrayWhereSkipWhileRewritten);        
            TestsExtensions.TestEquals(nameof(ArraySkipWhileParam), ArraySkipWhileParam, ArraySkipWhileParamRewritten);        
            TestsExtensions.TestEquals(nameof(ArraySkipWhileChangingParam), ArraySkipWhileChangingParam, ArraySkipWhileChangingParamRewritten);        
            TestsExtensions.TestEquals(nameof(ArraySkipWhileChangingParam2), ArraySkipWhileChangingParam2, ArraySkipWhileChangingParam2Rewritten);        
            TestsExtensions.TestEquals(nameof(ArraySkipWhileChangingParams), ArraySkipWhileChangingParams, ArraySkipWhileChangingParamsRewritten);   
            TestsExtensions.TestEquals(nameof(ArraySkipWhileChangingParamsIndexed), ArraySkipWhileChangingParamsIndexed, ArraySkipWhileChangingParamsIndexedRewritten);
            TestsExtensions.TestEquals(nameof(ArraySkipWhileToArray), ArraySkipWhileToArray, ArraySkipWhileToArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArraySkipWhileReverseToArray), ArraySkipWhileReverseToArray, ArraySkipWhileReverseToArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArraySkipWhileTrueToArray), ArraySkipWhileTrueToArray, ArraySkipWhileTrueToArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArraySkipWhileFalseToArray), ArraySkipWhileFalseToArray, ArraySkipWhileFalseToArrayRewritten);        
            TestsExtensions.TestEquals(nameof(ArraySelectSkipWhileToArray), ArraySelectSkipWhileToArray, ArraySelectSkipWhileToArrayRewritten);        
            TestsExtensions.TestEquals(nameof(ArrayWhereSkipWhileToArray), ArrayWhereSkipWhileToArray, ArrayWhereSkipWhileToArrayRewritten);        
            TestsExtensions.TestEquals(nameof(ArraySkipWhileParamToArray), ArraySkipWhileParamToArray, ArraySkipWhileParamToArrayRewritten);        
            TestsExtensions.TestEquals(nameof(ArraySkipWhileChangingParamToArray), ArraySkipWhileChangingParamToArray, ArraySkipWhileChangingParamToArrayRewritten);        
            TestsExtensions.TestEquals(nameof(ArraySkipWhileChangingParamToArray2), ArraySkipWhileChangingParamToArray2, ArraySkipWhileChangingParamToArray2Rewritten);        
            TestsExtensions.TestEquals(nameof(ArraySkipWhileChangingParamsToArray), ArraySkipWhileChangingParamsToArray, ArraySkipWhileChangingParamsToArrayRewritten);

            TestsExtensions.TestEquals(nameof(EnumerableSkipWhile), EnumerableSkipWhile, EnumerableSkipWhileRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableSkipWhileReverse), EnumerableSkipWhileReverse, EnumerableSkipWhileReverseRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableSkipWhileTrue), EnumerableSkipWhileTrue, EnumerableSkipWhileTrueRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableSkipWhileFalse), EnumerableSkipWhileFalse, EnumerableSkipWhileFalseRewritten);        
            TestsExtensions.TestEquals(nameof(EnumerableSelectSkipWhile), EnumerableSelectSkipWhile, EnumerableSelectSkipWhileRewritten);        
            TestsExtensions.TestEquals(nameof(EnumerableWhereSkipWhile), EnumerableWhereSkipWhile, EnumerableWhereSkipWhileRewritten);        
            TestsExtensions.TestEquals(nameof(EnumerableSkipWhileParam), EnumerableSkipWhileParam, EnumerableSkipWhileParamRewritten);        
            TestsExtensions.TestEquals(nameof(EnumerableSkipWhileChangingParam), EnumerableSkipWhileChangingParam, EnumerableSkipWhileChangingParamRewritten);        
            TestsExtensions.TestEquals(nameof(EnumerableSkipWhileChangingParam2), EnumerableSkipWhileChangingParam2, EnumerableSkipWhileChangingParam2Rewritten);        
            TestsExtensions.TestEquals(nameof(EnumerableSkipWhileChangingParams), EnumerableSkipWhileChangingParams, EnumerableSkipWhileChangingParamsRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableSkipWhileToArray), EnumerableSkipWhileToArray, EnumerableSkipWhileToArrayRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableSkipWhileReverseToArray), EnumerableSkipWhileReverseToArray, EnumerableSkipWhileReverseToArrayRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableSkipWhileTrueToArray), EnumerableSkipWhileTrueToArray, EnumerableSkipWhileTrueToArrayRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableSkipWhileFalseToArray), EnumerableSkipWhileFalseToArray, EnumerableSkipWhileFalseToArrayRewritten);        
            TestsExtensions.TestEquals(nameof(EnumerableSelectSkipWhileToArray), EnumerableSelectSkipWhileToArray, EnumerableSelectSkipWhileToArrayRewritten);        
            TestsExtensions.TestEquals(nameof(EnumerableWhereSkipWhileToArray), EnumerableWhereSkipWhileToArray, EnumerableWhereSkipWhileToArrayRewritten);        
            TestsExtensions.TestEquals(nameof(EnumerableSkipWhileParamToArray), EnumerableSkipWhileParamToArray, EnumerableSkipWhileParamToArrayRewritten);        
            TestsExtensions.TestEquals(nameof(EnumerableSkipWhileChangingParamToArray), EnumerableSkipWhileChangingParamToArray, EnumerableSkipWhileChangingParamToArrayRewritten);        
            TestsExtensions.TestEquals(nameof(EnumerableSkipWhileChangingParamToArray2), EnumerableSkipWhileChangingParamToArray2, EnumerableSkipWhileChangingParamToArray2Rewritten);        
            TestsExtensions.TestEquals(nameof(EnumerableSkipWhileChangingParamsToArray), EnumerableSkipWhileChangingParamsToArray, EnumerableSkipWhileChangingParamsToArrayRewritten);

            TestsExtensions.TestEquals(nameof(RangeSkipWhile), RangeSkipWhile, RangeSkipWhileRewritten);
            TestsExtensions.TestEquals(nameof(RangeSkipWhileReverse), RangeSkipWhileReverse, RangeSkipWhileReverseRewritten);
            TestsExtensions.TestEquals(nameof(RangeSkipWhileTrue), RangeSkipWhileTrue, RangeSkipWhileTrueRewritten);
            TestsExtensions.TestEquals(nameof(RangeSkipWhileFalse), RangeSkipWhileFalse, RangeSkipWhileFalseRewritten);        
            TestsExtensions.TestEquals(nameof(RangeSelectSkipWhile), RangeSelectSkipWhile, RangeSelectSkipWhileRewritten);        
            TestsExtensions.TestEquals(nameof(RangeWhereSkipWhile), RangeWhereSkipWhile, RangeWhereSkipWhileRewritten);        
            TestsExtensions.TestEquals(nameof(RangeSkipWhileParam), RangeSkipWhileParam, RangeSkipWhileParamRewritten);        
            TestsExtensions.TestEquals(nameof(RangeSkipWhileChangingParam), RangeSkipWhileChangingParam, RangeSkipWhileChangingParamRewritten);        
            TestsExtensions.TestEquals(nameof(RangeSkipWhileChangingParam2), RangeSkipWhileChangingParam2, RangeSkipWhileChangingParam2Rewritten);        
            TestsExtensions.TestEquals(nameof(RangeSkipWhileChangingParams), RangeSkipWhileChangingParams, RangeSkipWhileChangingParamsRewritten);
            TestsExtensions.TestEquals(nameof(RangeSkipWhileToArray), RangeSkipWhileToArray, RangeSkipWhileToArrayRewritten);
            TestsExtensions.TestEquals(nameof(RangeSkipWhileReverseToArray), RangeSkipWhileReverseToArray, RangeSkipWhileReverseToArrayRewritten);
            TestsExtensions.TestEquals(nameof(RangeSkipWhileTrueToArray), RangeSkipWhileTrueToArray, RangeSkipWhileTrueToArrayRewritten);
            TestsExtensions.TestEquals(nameof(RangeSkipWhileFalseToArray), RangeSkipWhileFalseToArray, RangeSkipWhileFalseToArrayRewritten);        
            TestsExtensions.TestEquals(nameof(RangeSelectSkipWhileToArray), RangeSelectSkipWhileToArray, RangeSelectSkipWhileToArrayRewritten);        
            TestsExtensions.TestEquals(nameof(RangeWhereSkipWhileToArray), RangeWhereSkipWhileToArray, RangeWhereSkipWhileToArrayRewritten);        
            TestsExtensions.TestEquals(nameof(RangeSkipWhileParamToArray), RangeSkipWhileParamToArray, RangeSkipWhileParamToArrayRewritten);        
            TestsExtensions.TestEquals(nameof(RangeSkipWhileChangingParamToArray), RangeSkipWhileChangingParamToArray, RangeSkipWhileChangingParamToArrayRewritten);        
            TestsExtensions.TestEquals(nameof(RangeSkipWhileChangingParamToArray2), RangeSkipWhileChangingParamToArray2, RangeSkipWhileChangingParamToArray2Rewritten);        
            TestsExtensions.TestEquals(nameof(RangeSkipWhileChangingParamsToArray), RangeSkipWhileChangingParamsToArray, RangeSkipWhileChangingParamsToArrayRewritten);
        }

        public IEnumerable<int> ArraySkipWhile()
        {
            return ArrayItems.SkipWhile(x => x < 50);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArraySkipWhileRewritten()
        {
            return ArrayItems.SkipWhile(x => x < 50);
        } //EndMethod


        public IEnumerable<int> ArraySkipWhileReverse()
        {
            return ArrayItems.SkipWhile(x => x > 50);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArraySkipWhileReverseRewritten()
        {
            return ArrayItems.SkipWhile(x => x > 50);
        } //EndMethod


        public IEnumerable<int> ArraySkipWhileTrue()
        {
            return ArrayItems.SkipWhile(x => true);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArraySkipWhileTrueRewritten()
        {
            return ArrayItems.SkipWhile(x => true);
        } //EndMethod


        public IEnumerable<int> ArraySkipWhileFalse()
        {
            return ArrayItems.SkipWhile(x => false);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArraySkipWhileFalseRewritten()
        {
            return ArrayItems.SkipWhile(x => false);
        } //EndMethod

        
        public IEnumerable<int> ArraySelectSkipWhile()
        {
            return ArrayItems.Select(x => x + 20).SkipWhile(x => x < 50);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArraySelectSkipWhileRewritten()
        {
            return ArrayItems.Select(x => x + 20).SkipWhile(x => x < 50);
        } //EndMethod

        
        public IEnumerable<int> ArrayWhereSkipWhile()
        {
            return ArrayItems.Where(x => x > 20).SkipWhile(x => x < 50);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayWhereSkipWhileRewritten()
        {
            return ArrayItems.Where(x => x > 20).SkipWhile(x => x < 50);
        } //EndMethod

        
        public IEnumerable<int> ArraySkipWhileParam()
        {
            var a = 50;
            return ArrayItems.SkipWhile(x => x < a);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArraySkipWhileParamRewritten()
        {
            var a = 50;
            return ArrayItems.SkipWhile(x => x < a);
        } //EndMethod

        
        public IEnumerable<int> ArraySkipWhileChangingParam()
        {
            var a = 50;
            return ArrayItems.SkipWhile(x => x < a++);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArraySkipWhileChangingParamRewritten()
        {
            var a = 50;
            return ArrayItems.SkipWhile(x => x < a++);
        } //EndMethod

        
        public IEnumerable<int> ArraySkipWhileChangingParam2()
        {
            var a = 50;
            return ArrayItems.SkipWhile(x => x < a--);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArraySkipWhileChangingParam2Rewritten()
        {
            var a = 50;
            return ArrayItems.SkipWhile(x => x < a--);
        } //EndMethod

        
        public IEnumerable<int> ArraySkipWhileChangingParams()
        {
            var a = 50;
            var b = 50;
            return ArrayItems.SkipWhile(x => x < a++ - b--);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArraySkipWhileChangingParamsRewritten()
        {
            var a = 50;
            var b = 50;
            return ArrayItems.SkipWhile(x => x < a++ - b--);
        } //EndMethod

        
        public IEnumerable<int> ArraySkipWhileChangingParamsIndexed()
        {
            var a = 50;
            var b = 50;
            return ArrayItems.SkipWhile((x, i) => x < a++ - b-- + i);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArraySkipWhileChangingParamsIndexedRewritten()
        {
            var a = 50;
            var b = 50;
            return ArrayItems.SkipWhile((x, i) => x < a++ - b-- + i);
        } //EndMethod


        public IEnumerable<int> ArraySkipWhileToArray()
        {
            return ArrayItems.SkipWhile(x => x < 50).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArraySkipWhileToArrayRewritten()
        {
            return ArrayItems.SkipWhile(x => x < 50).ToArray();
        } //EndMethod


        public IEnumerable<int> ArraySkipWhileReverseToArray()
        {
            return ArrayItems.SkipWhile(x => x > 50).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArraySkipWhileReverseToArrayRewritten()
        {
            return ArrayItems.SkipWhile(x => x > 50).ToArray();
        } //EndMethod


        public IEnumerable<int> ArraySkipWhileTrueToArray()
        {
            return ArrayItems.SkipWhile(x => true).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArraySkipWhileTrueToArrayRewritten()
        {
            return ArrayItems.SkipWhile(x => true).ToArray();
        } //EndMethod


        public IEnumerable<int> ArraySkipWhileFalseToArray()
        {
            return ArrayItems.SkipWhile(x => false).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArraySkipWhileFalseToArrayRewritten()
        {
            return ArrayItems.SkipWhile(x => false).ToArray();
        } //EndMethod

        
        public IEnumerable<int> ArraySelectSkipWhileToArray()
        {
            return ArrayItems.Select(x => x + 20).SkipWhile(x => x < 50).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArraySelectSkipWhileToArrayRewritten()
        {
            return ArrayItems.Select(x => x + 20).SkipWhile(x => x < 50).ToArray();
        } //EndMethod

        
        public IEnumerable<int> ArrayWhereSkipWhileToArray()
        {
            return ArrayItems.Where(x => x > 20).SkipWhile(x => x < 50).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayWhereSkipWhileToArrayRewritten()
        {
            return ArrayItems.Where(x => x > 20).SkipWhile(x => x < 50).ToArray();
        } //EndMethod

        
        public IEnumerable<int> ArraySkipWhileParamToArray()
        {
            var a = 50;
            return ArrayItems.SkipWhile(x => x < a).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArraySkipWhileParamToArrayRewritten()
        {
            var a = 50;
            return ArrayItems.SkipWhile(x => x < a).ToArray();
        } //EndMethod

        
        public IEnumerable<int> ArraySkipWhileChangingParamToArray()
        {
            var a = 50;
            return ArrayItems.SkipWhile(x => x < a++).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArraySkipWhileChangingParamToArrayRewritten()
        {
            var a = 50;
            return ArrayItems.SkipWhile(x => x < a++).ToArray();
        } //EndMethod

        
        public IEnumerable<int> ArraySkipWhileChangingParamToArray2()
        {
            var a = 50;
            return ArrayItems.SkipWhile(x => x < a--).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArraySkipWhileChangingParamToArray2Rewritten()
        {
            var a = 50;
            return ArrayItems.SkipWhile(x => x < a--).ToArray();
        } //EndMethod

        
        public IEnumerable<int> ArraySkipWhileChangingParamsToArray()
        {
            var a = 50;
            var b = 50;
            return ArrayItems.SkipWhile(x => x < a++ - b--).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArraySkipWhileChangingParamsToArrayRewritten()
        {
            var a = 50;
            var b = 50;
            return ArrayItems.SkipWhile(x => x < a++ - b--).ToArray();
        } //EndMethod



        public IEnumerable<int> EnumerableSkipWhile()
        {
            return EnumerableItems.SkipWhile(x => x < 50);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableSkipWhileRewritten()
        {
            return EnumerableItems.SkipWhile(x => x < 50);
        } //EndMethod


        public IEnumerable<int> EnumerableSkipWhileReverse()
        {
            return EnumerableItems.SkipWhile(x => x > 50);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableSkipWhileReverseRewritten()
        {
            return EnumerableItems.SkipWhile(x => x > 50);
        } //EndMethod


        public IEnumerable<int> EnumerableSkipWhileTrue()
        {
            return EnumerableItems.SkipWhile(x => true);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableSkipWhileTrueRewritten()
        {
            return EnumerableItems.SkipWhile(x => true);
        } //EndMethod


        public IEnumerable<int> EnumerableSkipWhileFalse()
        {
            return EnumerableItems.SkipWhile(x => false);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableSkipWhileFalseRewritten()
        {
            return EnumerableItems.SkipWhile(x => false);
        } //EndMethod

        
        public IEnumerable<int> EnumerableSelectSkipWhile()
        {
            return EnumerableItems.Select(x => x + 20).SkipWhile(x => x < 50);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableSelectSkipWhileRewritten()
        {
            return EnumerableItems.Select(x => x + 20).SkipWhile(x => x < 50);
        } //EndMethod

        
        public IEnumerable<int> EnumerableWhereSkipWhile()
        {
            return EnumerableItems.Where(x => x > 20).SkipWhile(x => x < 50);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableWhereSkipWhileRewritten()
        {
            return EnumerableItems.Where(x => x > 20).SkipWhile(x => x < 50);
        } //EndMethod

        
        public IEnumerable<int> EnumerableSkipWhileParam()
        {
            var a = 50;
            return EnumerableItems.SkipWhile(x => x < a);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableSkipWhileParamRewritten()
        {
            var a = 50;
            return EnumerableItems.SkipWhile(x => x < a);
        } //EndMethod

        
        public IEnumerable<int> EnumerableSkipWhileChangingParam()
        {
            var a = 50;
            return EnumerableItems.SkipWhile(x => x < a++);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableSkipWhileChangingParamRewritten()
        {
            var a = 50;
            return EnumerableItems.SkipWhile(x => x < a++);
        } //EndMethod

        
        public IEnumerable<int> EnumerableSkipWhileChangingParam2()
        {
            var a = 50;
            return EnumerableItems.SkipWhile(x => x < a--);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableSkipWhileChangingParam2Rewritten()
        {
            var a = 50;
            return EnumerableItems.SkipWhile(x => x < a--);
        } //EndMethod

        
        public IEnumerable<int> EnumerableSkipWhileChangingParams()
        {
            var a = 50;
            var b = 50;
            return EnumerableItems.SkipWhile(x => x < a++ - b--);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableSkipWhileChangingParamsRewritten()
        {
            var a = 50;
            var b = 50;
            return EnumerableItems.SkipWhile(x => x < a++ - b--);
        } //EndMethod


        public IEnumerable<int> EnumerableSkipWhileToArray()
        {
            return EnumerableItems.SkipWhile(x => x < 50).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableSkipWhileToArrayRewritten()
        {
            return EnumerableItems.SkipWhile(x => x < 50).ToArray();
        } //EndMethod


        public IEnumerable<int> EnumerableSkipWhileReverseToArray()
        {
            return EnumerableItems.SkipWhile(x => x > 50).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableSkipWhileReverseToArrayRewritten()
        {
            return EnumerableItems.SkipWhile(x => x > 50).ToArray();
        } //EndMethod


        public IEnumerable<int> EnumerableSkipWhileTrueToArray()
        {
            return EnumerableItems.SkipWhile(x => true).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableSkipWhileTrueToArrayRewritten()
        {
            return EnumerableItems.SkipWhile(x => true).ToArray();
        } //EndMethod


        public IEnumerable<int> EnumerableSkipWhileFalseToArray()
        {
            return EnumerableItems.SkipWhile(x => false).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableSkipWhileFalseToArrayRewritten()
        {
            return EnumerableItems.SkipWhile(x => false).ToArray();
        } //EndMethod

        
        public IEnumerable<int> EnumerableSelectSkipWhileToArray()
        {
            return EnumerableItems.Select(x => x + 20).SkipWhile(x => x < 50).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableSelectSkipWhileToArrayRewritten()
        {
            return EnumerableItems.Select(x => x + 20).SkipWhile(x => x < 50).ToArray();
        } //EndMethod

        
        public IEnumerable<int> EnumerableWhereSkipWhileToArray()
        {
            return EnumerableItems.Where(x => x > 20).SkipWhile(x => x < 50).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableWhereSkipWhileToArrayRewritten()
        {
            return EnumerableItems.Where(x => x > 20).SkipWhile(x => x < 50).ToArray();
        } //EndMethod

        
        public IEnumerable<int> EnumerableSkipWhileParamToArray()
        {
            var a = 50;
            return EnumerableItems.SkipWhile(x => x < a).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableSkipWhileParamToArrayRewritten()
        {
            var a = 50;
            return EnumerableItems.SkipWhile(x => x < a).ToArray();
        } //EndMethod

        
        public IEnumerable<int> EnumerableSkipWhileChangingParamToArray()
        {
            var a = 50;
            return EnumerableItems.SkipWhile(x => x < a++).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableSkipWhileChangingParamToArrayRewritten()
        {
            var a = 50;
            return EnumerableItems.SkipWhile(x => x < a++).ToArray();
        } //EndMethod

        
        public IEnumerable<int> EnumerableSkipWhileChangingParamToArray2()
        {
            var a = 50;
            return EnumerableItems.SkipWhile(x => x < a--).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableSkipWhileChangingParamToArray2Rewritten()
        {
            var a = 50;
            return EnumerableItems.SkipWhile(x => x < a--).ToArray();
        } //EndMethod

        
        public IEnumerable<int> EnumerableSkipWhileChangingParamsToArray()
        {
            var a = 50;
            var b = 50;
            return EnumerableItems.SkipWhile(x => x < a++ - b--).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> EnumerableSkipWhileChangingParamsToArrayRewritten()
        {
            var a = 50;
            var b = 50;
            return EnumerableItems.SkipWhile(x => x < a++ - b--).ToArray();
        } //EndMethod



        public IEnumerable<int> RangeSkipWhile()
        {
            return Enumerable.Range(0, 100).SkipWhile(x => x < 50);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeSkipWhileRewritten()
        {
            return Enumerable.Range(0, 100).SkipWhile(x => x < 50);
        } //EndMethod


        public IEnumerable<int> RangeSkipWhileReverse()
        {
            return Enumerable.Range(0, 100).SkipWhile(x => x > 50);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeSkipWhileReverseRewritten()
        {
            return Enumerable.Range(0, 100).SkipWhile(x => x > 50);
        } //EndMethod


        public IEnumerable<int> RangeSkipWhileTrue()
        {
            return Enumerable.Range(0, 100).SkipWhile(x => true);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeSkipWhileTrueRewritten()
        {
            return Enumerable.Range(0, 100).SkipWhile(x => true);
        } //EndMethod


        public IEnumerable<int> RangeSkipWhileFalse()
        {
            return Enumerable.Range(0, 100).SkipWhile(x => false);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeSkipWhileFalseRewritten()
        {
            return Enumerable.Range(0, 100).SkipWhile(x => false);
        } //EndMethod

        
        public IEnumerable<int> RangeSelectSkipWhile()
        {
            return Enumerable.Range(0, 100).Select(x => x + 20).SkipWhile(x => x < 50);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeSelectSkipWhileRewritten()
        {
            return Enumerable.Range(0, 100).Select(x => x + 20).SkipWhile(x => x < 50);
        } //EndMethod

        
        public IEnumerable<int> RangeWhereSkipWhile()
        {
            return Enumerable.Range(0, 100).Where(x => x > 20).SkipWhile(x => x < 50);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeWhereSkipWhileRewritten()
        {
            return Enumerable.Range(0, 100).Where(x => x > 20).SkipWhile(x => x < 50);
        } //EndMethod

        
        public IEnumerable<int> RangeSkipWhileParam()
        {
            var a = 50;
            return Enumerable.Range(0, 100).SkipWhile(x => x < a);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeSkipWhileParamRewritten()
        {
            var a = 50;
            return Enumerable.Range(0, 100).SkipWhile(x => x < a);
        } //EndMethod

        
        public IEnumerable<int> RangeSkipWhileChangingParam()
        {
            var a = 50;
            return Enumerable.Range(0, 100).SkipWhile(x => x < a++);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeSkipWhileChangingParamRewritten()
        {
            var a = 50;
            return Enumerable.Range(0, 100).SkipWhile(x => x < a++);
        } //EndMethod

        
        public IEnumerable<int> RangeSkipWhileChangingParam2()
        {
            var a = 50;
            return Enumerable.Range(0, 100).SkipWhile(x => x < a--);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeSkipWhileChangingParam2Rewritten()
        {
            var a = 50;
            return Enumerable.Range(0, 100).SkipWhile(x => x < a--);
        } //EndMethod

        
        public IEnumerable<int> RangeSkipWhileChangingParams()
        {
            var a = 50;
            var b = 50;
            return Enumerable.Range(0, 100).SkipWhile(x => x < a++ - b--);
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeSkipWhileChangingParamsRewritten()
        {
            var a = 50;
            var b = 50;
            return Enumerable.Range(0, 100).SkipWhile(x => x < a++ - b--);
        } //EndMethod


        public IEnumerable<int> RangeSkipWhileToArray()
        {
            return Enumerable.Range(0, 100).SkipWhile(x => x < 50).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeSkipWhileToArrayRewritten()
        {
            return Enumerable.Range(0, 100).SkipWhile(x => x < 50).ToArray();
        } //EndMethod


        public IEnumerable<int> RangeSkipWhileReverseToArray()
        {
            return Enumerable.Range(0, 100).SkipWhile(x => x > 50).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeSkipWhileReverseToArrayRewritten()
        {
            return Enumerable.Range(0, 100).SkipWhile(x => x > 50).ToArray();
        } //EndMethod


        public IEnumerable<int> RangeSkipWhileTrueToArray()
        {
            return Enumerable.Range(0, 100).SkipWhile(x => true).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeSkipWhileTrueToArrayRewritten()
        {
            return Enumerable.Range(0, 100).SkipWhile(x => true).ToArray();
        } //EndMethod


        public IEnumerable<int> RangeSkipWhileFalseToArray()
        {
            return Enumerable.Range(0, 100).SkipWhile(x => false).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeSkipWhileFalseToArrayRewritten()
        {
            return Enumerable.Range(0, 100).SkipWhile(x => false).ToArray();
        } //EndMethod

        
        public IEnumerable<int> RangeSelectSkipWhileToArray()
        {
            return Enumerable.Range(0, 100).Select(x => x + 20).SkipWhile(x => x < 50).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeSelectSkipWhileToArrayRewritten()
        {
            return Enumerable.Range(0, 100).Select(x => x + 20).SkipWhile(x => x < 50).ToArray();
        } //EndMethod

        
        public IEnumerable<int> RangeWhereSkipWhileToArray()
        {
            return Enumerable.Range(0, 100).Where(x => x > 20).SkipWhile(x => x < 50).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeWhereSkipWhileToArrayRewritten()
        {
            return Enumerable.Range(0, 100).Where(x => x > 20).SkipWhile(x => x < 50).ToArray();
        } //EndMethod

        
        public IEnumerable<int> RangeSkipWhileParamToArray()
        {
            var a = 50;
            return Enumerable.Range(0, 100).SkipWhile(x => x < a).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeSkipWhileParamToArrayRewritten()
        {
            var a = 50;
            return Enumerable.Range(0, 100).SkipWhile(x => x < a).ToArray();
        } //EndMethod

        
        public IEnumerable<int> RangeSkipWhileChangingParamToArray()
        {
            var a = 50;
            return Enumerable.Range(0, 100).SkipWhile(x => x < a++).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeSkipWhileChangingParamToArrayRewritten()
        {
            var a = 50;
            return Enumerable.Range(0, 100).SkipWhile(x => x < a++).ToArray();
        } //EndMethod

        
        public IEnumerable<int> RangeSkipWhileChangingParamToArray2()
        {
            var a = 50;
            return Enumerable.Range(0, 100).SkipWhile(x => x < a--).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeSkipWhileChangingParamToArray2Rewritten()
        {
            var a = 50;
            return Enumerable.Range(0, 100).SkipWhile(x => x < a--).ToArray();
        } //EndMethod

        
        public IEnumerable<int> RangeSkipWhileChangingParamsToArray()
        {
            var a = 50;
            var b = 50;
            return Enumerable.Range(0, 100).SkipWhile(x => x < a++ - b--).ToArray();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> RangeSkipWhileChangingParamsToArrayRewritten()
        {
            var a = 50;
            var b = 50;
            return Enumerable.Range(0, 100).SkipWhile(x => x < a++ - b--).ToArray();
        } //EndMethod

    }
}