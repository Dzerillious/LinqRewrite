using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class CastTests
    {
        [Datapoints]
        private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
        [Datapoints]
        private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
        
        public void RunTests()
        {
            TestsExtensions.TestEquals(nameof(ArrayCast), ArrayCast, ArrayCastRewritten);
            TestsExtensions.TestEquals(nameof(ArrayCast2), ArrayCast2, ArrayCast2Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayCast3), ArrayCast3, ArrayCast3Rewritten);
            TestsExtensions.TestEquals(nameof(ArrayCast4), ArrayCast4, ArrayCast4Rewritten);
            TestsExtensions.TestEquals(nameof(ArraySelectCast), ArraySelectCast, ArraySelectCastRewritten);
            TestsExtensions.TestEquals(nameof(ArrayWhereCast), ArrayWhereCast, ArrayWhereCastRewritten);
            TestsExtensions.TestEquals(nameof(ArrayCastAverage), ArrayCastAverage, ArrayCastAverageRewritten);
            TestsExtensions.TestEquals(nameof(ArrayCastAny), ArrayCastAny, ArrayCastAnyRewritten);
            TestsExtensions.TestEquals(nameof(ArrayCastAggregate), ArrayCastAggregate, ArrayCastAggregateRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableCast), EnumerableCast, EnumerableCastRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableCastToArray), EnumerableCastToArray, EnumerableCastToArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArrayCastToArray), ArrayCastToArray, ArrayCastToArrayRewritten);
        }

        public IEnumerable<int> ArrayCast()
        {
            return ArrayItems.Cast<int>();
        } //EndMethod

        [LinqRewrite]
		public IEnumerable<int> ArrayCastRewritten()
        {
            return ArrayItems.Cast<int>();
        } //EndMethod


        public IEnumerable<float> ArrayCast2()
        {
            return ArrayItems.Cast<float>();
        } //EndMethod
        
        [LinqRewrite]
		public IEnumerable<float> ArrayCast2Rewritten()
        {
            return ArrayItems.Cast<float>();
        } //EndMethod
        
        
        public IEnumerable<double> ArrayCast3()
        {
            return ArrayItems.Cast<double>();
        } //EndMethod
        
        [LinqRewrite]
		public IEnumerable<double> ArrayCast3Rewritten()
        {
            return ArrayItems.Cast<double>();
        } //EndMethod


        public IEnumerable<double?> ArrayCast4()
        {
            return ArrayItems.Cast<double?>();
        } //EndMethod
        
        [LinqRewrite]
		public IEnumerable<double?> ArrayCast4Rewritten()
        {
            return ArrayItems.Cast<double?>();
        } //EndMethod


        public IEnumerable<int> ArraySelectCast()
        {
            return ArrayItems.Select(x => x + 0.2).Cast<int>();
        } //EndMethod
        
        [LinqRewrite]
		public IEnumerable<int> ArraySelectCastRewritten()
        {
            return ArrayItems.Select(x => x + 0.2).Cast<int>();
        } //EndMethod
        
        
        public IEnumerable<double> ArrayWhereCast()
        {
            return ArrayItems.Where(x => x % 2 == 1).Cast<double>();
        } //EndMethod
        
        [LinqRewrite]
		public IEnumerable<double> ArrayWhereCastRewritten()
        {
            return ArrayItems.Where(x => x % 2 == 1).Cast<double>();
        } //EndMethod


        public double? ArrayCastAverage()
        {
            return ArrayItems.Cast<double?>().Average();
        } //EndMethod
        
        [LinqRewrite]
		public double? ArrayCastAverageRewritten()
        {
            return ArrayItems.Cast<double?>().Average();
        } //EndMethod


        public bool ArrayCastAny()
        {
            return ArrayItems.Cast<double?>().Any(x => x == null);
        } //EndMethod

        [LinqRewrite]
		public bool ArrayCastAnyRewritten()
        {
            return ArrayItems.Cast<double?>().Any(x => x == null);
        } //EndMethod


        public double ArrayCastAggregate()
        {
            return ArrayItems.Cast<double>().Aggregate((x, y) => x * y);
        } //EndMethod
        
        [LinqRewrite]
		public double ArrayCastAggregateRewritten()
        {
            return ArrayItems.Cast<double>().Aggregate((x, y) => x * y);
        } //EndMethod
        
        
        public IEnumerable<double> EnumerableCast()
        {
            return EnumerableItems.Cast<double>();
        } //EndMethod
        
        [LinqRewrite]
		public IEnumerable<double> EnumerableCastRewritten()
        {
            return EnumerableItems.Cast<double>();
        } //EndMethod
        
        
        public IEnumerable<double> EnumerableCastToArray()
        {
            return EnumerableItems.Cast<double>().ToArray();
        } //EndMethod
        
        [LinqRewrite]
		public IEnumerable<double> EnumerableCastToArrayRewritten()
        {
            return EnumerableItems.Cast<double>().ToArray();
        } //EndMethod
        
        
        public IEnumerable<double> ArrayCastToArray()
        {
            return ArrayItems.Cast<double>().ToArray();
        } //EndMethod
        
        [LinqRewrite]
		public IEnumerable<double> ArrayCastToArrayRewritten()
        {
            return ArrayItems.Cast<double>().ToArray();
        } //EndMethod

    }
}