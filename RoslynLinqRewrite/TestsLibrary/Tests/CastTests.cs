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
            ArrayCast().TestEquals(nameof(ArrayCast), ArrayCastRewritten());
            // ArrayCast2().TestEquals(nameof(ArrayCast2), ArrayCast2Rewritten());
            // ArrayCast3().TestEquals(nameof(ArrayCast3), ArrayCast3Rewritten());
            // ArrayCast4().TestEquals(nameof(ArrayCast4), ArrayCast4Rewritten());
            // ArraySelectCast().TestEquals(nameof(ArraySelectCast), ArraySelectCastRewritten());
            // ArrayWhereCast().TestEquals(nameof(ArrayWhereCast), ArrayWhereCastRewritten());
            // ArrayCastAverage().TestEquals(nameof(ArrayCastAverage), ArrayCastAverageRewritten());
            // ArrayCastAny().TestEquals(nameof(ArrayCastAny), ArrayCastAnyRewritten());
            // ArrayCastAggregate().TestEquals(nameof(ArrayCastAggregate), ArrayCastAggregateRewritten());
            // EnumerableCast().TestEquals(nameof(EnumerableCast), EnumerableCastRewritten());
            // EnumerableCastToArray().TestEquals(nameof(EnumerableCastToArray), EnumerableCastToArrayRewritten());
            // ArrayCastToArray().TestEquals(nameof(ArrayCastToArray), ArrayCastToArrayRewritten());
        }

        [NoRewrite]
        public IEnumerable<int> ArrayCast()
        {
            return ArrayItems.Cast<int>();
        } //EndMethod

        public IEnumerable<int> ArrayCastRewritten()
        {
            return ArrayItems.Cast<int>();
        } //EndMethod


        // [NoRewrite]
        // public IEnumerable<float> ArrayCast2()
        // {
        //     return ArrayItems.Cast<float>();
        // } //EndMethod
        //
        // public IEnumerable<float> ArrayCast2Rewritten()
        // {
        //     return ArrayItems.Cast<float>();
        // } //EndMethod
        //
        //
        // [NoRewrite]
        // public IEnumerable<double> ArrayCast3()
        // {
        //     return ArrayItems.Cast<double>();
        // } //EndMethod
        //
        // public IEnumerable<double> ArrayCast3Rewritten()
        // {
        //     return ArrayItems.Cast<double>();
        // } //EndMethod


        // [NoRewrite]
        // public IEnumerable<double?> ArrayCast4()
        // {
        //     return ArrayItems.Cast<double?>();
        // } //EndMethod
        //
        // public IEnumerable<double?> ArrayCast4Rewritten()
        // {
        //     return ArrayItems.Cast<double?>();
        // } //EndMethod


        // [NoRewrite]
        // public IEnumerable<int> ArraySelectCast()
        // {
        //     return ArrayItems.Select(x => x + 0.2).Cast<int>();
        // } //EndMethod
        //
        // public IEnumerable<int> ArraySelectCastRewritten()
        // {
        //     return ArrayItems.Select(x => x + 0.2).Cast<int>();
        // } //EndMethod
        //
        //
        // [NoRewrite]
        // public IEnumerable<double> ArrayWhereCast()
        // {
        //     return ArrayItems.Where(x => x % 2 == 1).Cast<double>();
        // } //EndMethod
        //
        // public IEnumerable<double> ArrayWhereCastRewritten()
        // {
        //     return ArrayItems.Where(x => x % 2 == 1).Cast<double>();
        // } //EndMethod


        // [NoRewrite]
        // public double? ArrayCastAverage()
        // {
        //     return ArrayItems.Cast<double?>().Average();
        // } //EndMethod
        //
        // public double? ArrayCastAverageRewritten()
        // {
        //     return ArrayItems.Cast<double?>().Average();
        // } //EndMethod


        // [NoRewrite]
        // public bool ArrayCastAny()
        // {
        //     return ArrayItems.Cast<double?>().Any(x => x == null);
        // } //EndMethod
        //
        // public bool ArrayCastAnyRewritten()
        // {
        //     return ArrayItems.Cast<double?>().Any(x => x == null);
        // } //EndMethod


        // [NoRewrite]
        // public double ArrayCastAggregate()
        // {
        //     return ArrayItems.Cast<double>().Aggregate((x, y) => x * y);
        // } //EndMethod
        //
        // public double ArrayCastAggregateRewritten()
        // {
        //     return ArrayItems.Cast<double>().Aggregate((x, y) => x * y);
        // } //EndMethod
        //
        //
        // [NoRewrite]
        // public IEnumerable<double> EnumerableCast()
        // {
        //     return EnumerableItems.Cast<double>();
        // } //EndMethod
        //
        // public IEnumerable<double> EnumerableCastRewritten()
        // {
        //     return EnumerableItems.Cast<double>();
        // } //EndMethod
        //
        //
        // [NoRewrite]
        // public IEnumerable<double> EnumerableCastToArray()
        // {
        //     return EnumerableItems.Cast<double>().ToArray();
        // } //EndMethod
        //
        // public IEnumerable<double> EnumerableCastToArrayRewritten()
        // {
        //     return EnumerableItems.Cast<double>().ToArray();
        // } //EndMethod
        //
        //
        // [NoRewrite]
        // public IEnumerable<double> ArrayCastToArray()
        // {
        //     return ArrayItems.Cast<double>().ToArray();
        // } //EndMethod
        //
        // public IEnumerable<double> ArrayCastToArrayRewritten()
        // {
        //     return ArrayItems.Cast<double>().ToArray();
        // } //EndMethod

    }
}