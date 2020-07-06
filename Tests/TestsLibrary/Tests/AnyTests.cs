using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class AnyTests
    {
        [Datapoints]
        private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
        [Datapoints]
        private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
        
        public bool Predicate(int x) => x > 50;

        public void RunTests()
        {
            TestsExtensions.TestEquals(nameof(ArrayAny), ArrayAny, ArrayAnyRewritten);
            TestsExtensions.TestEquals(nameof(ArraySelectAny), ArraySelectAny, ArraySelectAnyRewritten);
            TestsExtensions.TestEquals(nameof(ArrayWhereAny), ArrayWhereAny, ArrayWhereAnyRewritten);
            TestsExtensions.TestEquals(nameof(ArrayEmptyAny), ArrayEmptyAny, ArrayEmptyAnyRewritten);
            TestsExtensions.TestEquals(nameof(ArraySelectEmptyAny), ArraySelectEmptyAny, ArraySelectEmptyAnyRewritten);
            TestsExtensions.TestEquals(nameof(ArrayWhereEmptyAny), ArrayWhereEmptyAny, ArrayWhereEmptyAnyRewritten);
            TestsExtensions.TestEquals(nameof(ArrayAnyFalse), ArrayAnyFalse, ArrayAnyFalseRewritten);
            TestsExtensions.TestEquals(nameof(ArrayAnyPredicate), ArrayAnyPredicate, ArrayAnyPredicateRewritten);
            TestsExtensions.TestEquals(nameof(ArrayAnyParameter), ArrayAnyParameter, ArrayAnyParameterRewritten);
            TestsExtensions.TestEquals(nameof(ArrayAnyChangingParameter), ArrayAnyChangingParameter, ArrayAnyChangingParameterRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableAnyChangingParameter), EnumerableAnyChangingParameter, EnumerableAnyChangingParameterRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableAny), EnumerableAny, EnumerableAnyRewritten);
            TestsExtensions.TestEquals(nameof(RepeatAny), RepeatAny, RepeatAnyRewritten);
            TestsExtensions.TestEquals(nameof(RangeAny), RangeAny, RangeAnyRewritten);
            TestsExtensions.TestEquals(nameof(RepeatAnyTrue), RepeatAnyTrue, RepeatAnyTrueRewritten);
        }
        
        public bool ArrayAny()
        {
            return ArrayItems.Any(x => x > 50);
        } //EndMethod

        [LinqRewrite]
		public bool ArrayAnyRewritten()
        {
            return ArrayItems.Any(x => x > 50);
        } //EndMethod

        
        public bool ArraySelectAny()
        {
            return ArrayItems.Select(x => x + 10).Any(x => x > 50);
        } //EndMethod

        [LinqRewrite]
		public bool ArraySelectAnyRewritten()
        {
            return ArrayItems.Select(x => x + 10).Any(x => x > 50);
        } //EndMethod

        
        public bool ArrayWhereAny()
        {
            return ArrayItems.Where(x => x > 40).Any(x => x > 50);
        } //EndMethod

        [LinqRewrite]
		public bool ArrayWhereAnyRewritten()
        {
            return ArrayItems.Where(x => x > 40).Any(x => x > 50);
        } //EndMethod

        
        public bool ArrayEmptyAny()
        {
            return ArrayItems.Any();
        } //EndMethod

        [LinqRewrite]
		public bool ArrayEmptyAnyRewritten()
        {
            return ArrayItems.Any();
        } //EndMethod

        
        public bool ArraySelectEmptyAny()
        {
            return ArrayItems.Select(x => x - 40).Any();
        } //EndMethod

        [LinqRewrite]
		public bool ArraySelectEmptyAnyRewritten()
        {
            return ArrayItems.Select(x => x - 40).Any();
        } //EndMethod

        
        public bool ArrayWhereEmptyAny()
        {
            return ArrayItems.Where(x => x > 40).Any();
        } //EndMethod

        [LinqRewrite]
		public bool ArrayWhereEmptyAnyRewritten()
        {
            return ArrayItems.Where(x => x > 40).Any();
        } //EndMethod

        
        public bool ArrayAnyFalse()
        {
            return ArrayItems.Any(x => x > 105);
        } //EndMethod

        [LinqRewrite]
		public bool ArrayAnyFalseRewritten()
        {
            return ArrayItems.Any(x => x > 105);
        } //EndMethod

        
        public bool ArrayAnyPredicate()
        {
            return ArrayItems.Any(Predicate);
        } //EndMethod

        [LinqRewrite]
		public bool ArrayAnyPredicateRewritten()
        {
            return ArrayItems.Any(Predicate);
        } //EndMethod

        
        public bool ArrayAnyParameter()
        {
            var a = 5;
            return ArrayItems.Any(x => x > a);
        } //EndMethod

        [LinqRewrite]
		public bool ArrayAnyParameterRewritten()
        {
            var a = 5;
            return ArrayItems.Any(x => x > a);
        } //EndMethod

        
        public bool ArrayAnyChangingParameter()
        {
            var a = 5;
            return ArrayItems.Any(x => x > a++);
        } //EndMethod

        [LinqRewrite]
		public bool ArrayAnyChangingParameterRewritten()
        {
            var a = 5;
            return ArrayItems.Any(x => x > a++);
        } //EndMethod

        
        public bool EnumerableAnyChangingParameter()
        {
            var a = 5;
            return EnumerableItems.Any(x => x > a++);
        } //EndMethod

        [LinqRewrite]
		public bool EnumerableAnyChangingParameterRewritten()
        {
            var a = 5;
            return EnumerableItems.Any(x => x > a++);
        } //EndMethod

        
        public bool EnumerableAny()
        {
            return EnumerableItems.Any(x => x > 50);
        } //EndMethod

        [LinqRewrite]
		public bool EnumerableAnyRewritten()
        {
            return EnumerableItems.Any(x => x > 50);
        } //EndMethod

        
        public bool RangeAny()
        {
            return Enumerable.Range(0, 100).Any(x => x > 50);
        } //EndMethod

        [LinqRewrite]
		public bool RangeAnyRewritten()
        {
            return Enumerable.Range(0, 100).Any(x => x > 50);
        } //EndMethod

        
        public bool RepeatAny()
        {
            return Enumerable.Repeat(0, 100).Any(x => x > 50);
        } //EndMethod

        [LinqRewrite]
		public bool RepeatAnyRewritten()
        {
            return Enumerable.Repeat(0, 100).Any(x => x > 50);
        } //EndMethod

        
        public bool RepeatAnyTrue()
        {
            return Enumerable.Repeat(0, 100).Any(x => x > -1);
        } //EndMethod

        [LinqRewrite]
		public bool RepeatAnyTrueRewritten()
        {
            return Enumerable.Repeat(0, 100).Any(x => x > -1);
        } //EndMethod


    }
}