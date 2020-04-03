using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class MinTests
    {
        [Datapoints]
        private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
        [Datapoints]
        private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);

        private int Selector(int value) => value + 50;
        
        public void RunTests()
        {
            TestsExtensions.TestEquals(nameof(Min1), Min1, Min1Rewritten);
            TestsExtensions.TestEquals(nameof(Min2), Min2, Min2Rewritten);
            TestsExtensions.TestEquals(nameof(Min3), Min3, Min3Rewritten);
            TestsExtensions.TestEquals(nameof(Min4), Min4, Min4Rewritten);
            TestsExtensions.TestEquals(nameof(Min5), Min5, Min5Rewritten);
            TestsExtensions.TestEquals(nameof(Min6), Min6, Min6Rewritten);
            TestsExtensions.TestEquals(nameof(Min7), Min7, Min7Rewritten);
            TestsExtensions.TestEquals(nameof(Min8), Min8, Min8Rewritten);
            TestsExtensions.TestEquals(nameof(Min9), Min9, Min9Rewritten);
            TestsExtensions.TestEquals(nameof(Min10), Min10, Min10Rewritten);
            TestsExtensions.TestEquals(nameof(Min11), Min11, Min11Rewritten);
            TestsExtensions.TestEquals(nameof(Min12), Min12, Min12Rewritten);
            TestsExtensions.TestEquals(nameof(MinParam), MinParam, MinParamRewritten);
            TestsExtensions.TestEquals(nameof(MinChangingParam), MinChangingParam, MinChangingParamRewritten);
            TestsExtensions.TestEquals(nameof(MinChangingParam2), MinChangingParam2, MinChangingParam2Rewritten);
            TestsExtensions.TestEquals(nameof(SelectMin), SelectMin, SelectMinRewritten);
            TestsExtensions.TestEquals(nameof(EmptyMin), EmptyMin, EmptyMinRewritten);
            TestsExtensions.TestEquals(nameof(EmptyMin2), EmptyMin2, EmptyMin2Rewritten);
            TestsExtensions.TestEquals(nameof(EnumerableMin), EnumerableMin, EnumerableMinRewritten);
        }

        [NoRewrite]
        public int Min1()
        {
            return ArrayItems.Min();
        } //EndMethod

        public int Min1Rewritten()
        {
            return ArrayItems.Min();
        } //EndMethod


        [NoRewrite]
        public int Min2()
        {
            return ArrayItems.Min(x => x + 2);
        } //EndMethod

        public int Min2Rewritten()
        {
            return ArrayItems.Min(x => x + 2);
        } //EndMethod


        [NoRewrite]
        public float Min3()
        {
            return ArrayItems.Min(x => x + 2f);
        } //EndMethod

        public float Min3Rewritten()
        {
            return ArrayItems.Min(x => x + 2f);
        } //EndMethod


        [NoRewrite]
        public double Min4()
        {
            return ArrayItems.Min(x => x + 2d);
        } //EndMethod

        public double Min4Rewritten()
        {
            return ArrayItems.Min(x => x + 2d);
        } //EndMethod


        [NoRewrite]
        public decimal Min5()
        {
            return ArrayItems.Min(x => x + 2m);
        } //EndMethod

        public decimal Min5Rewritten()
        {
            return ArrayItems.Min(x => x + 2m);
        } //EndMethod


        [NoRewrite]
        public int? Min6()
        {
            return ArrayItems.Min(x => x > 10 ? (int?)null : x + 2);
        } //EndMethod

        public int? Min6Rewritten()
        {
            return ArrayItems.Min(x => x > 10 ? (int?)null : x + 2);
        } //EndMethod


        [NoRewrite]
        public float? Min7()
        {
            return ArrayItems.Min(x => x > 10 ? (float?)null : x + 2);
        } //EndMethod

        public float? Min7Rewritten()
        {
            return ArrayItems.Min(x => x > 10 ? (float?)null : x + 2);
        } //EndMethod


        [NoRewrite]
        public double? Min8()
        {
            return ArrayItems.Min(x => x > 10 ? (double?)null : x + 2);
        } //EndMethod

        public double? Min8Rewritten()
        {
            return ArrayItems.Min(x => x > 10 ? (double?)null : x + 2);
        } //EndMethod


        [NoRewrite]
        public decimal? Min9()
        {
            return ArrayItems.Min(x => x > 10 ? (decimal?)null : x + 2);
        } //EndMethod

        public decimal? Min9Rewritten()
        {
            return ArrayItems.Min(x => x > 10 ? (decimal?)null : x + 2);
        } //EndMethod


        [NoRewrite]
        public long Min10()
        {
            return ArrayItems.Min(x => x + 2L);
        } //EndMethod

        public long Min10Rewritten()
        {
            return ArrayItems.Min(x => x + 2L);
        } //EndMethod


        [NoRewrite]
        public long? Min11()
        {
            return ArrayItems.Min(x => x > 10 ? (long?)null : x + 2);
        } //EndMethod

        public long? Min11Rewritten()
        {
            return ArrayItems.Min(x => x > 10 ? (long?)null : x + 2);
        } //EndMethod


        [NoRewrite]
        public int? Min12()
        {
            return ArrayItems.Min(Selector);
        } //EndMethod

        public int? Min12Rewritten()
        {
            return ArrayItems.Min(Selector);
        } //EndMethod


        [NoRewrite]
        public int? MinParam()
        {
            var a = 10;
            return ArrayItems.Min(x => x + a);
        } //EndMethod

        public int? MinParamRewritten()
        {
            var a = 10;
            return ArrayItems.Min(x => x + a);
        } //EndMethod


        [NoRewrite]
        public int? MinChangingParam()
        {
            var a = 10;
            return ArrayItems.Min(x => x + a++);
        } //EndMethod

        public int? MinChangingParamRewritten()
        {
            var a = 10;
            return ArrayItems.Min(x => x + a++);
        } //EndMethod


        [NoRewrite]
        public int? MinChangingParam2()
        {
            var a = 10;
            return ArrayItems.Min(x => x + a--);
        } //EndMethod

        public int? MinChangingParam2Rewritten()
        {
            var a = 10;
            return ArrayItems.Min(x => x + a--);
        } //EndMethod


        [NoRewrite]
        public int? SelectMin()
        {
            var a = 10;
            return ArrayItems.Select(x => x + 3).Min();
        } //EndMethod

        public int? SelectMinRewritten()
        {
            var a = 10;
            return ArrayItems.Select(x => x + 3).Min();
        } //EndMethod


        [NoRewrite]
        public int? EmptyMin()
        {
            return Enumerable.Empty<int>().Min();
        } //EndMethod

        public int? EmptyMinRewritten()
        {
            return Enumerable.Empty<int>().Min();
        } //EndMethod


        [NoRewrite]
        public int? EmptyMin2()
        {
            return ArrayItems.Where(x => false).Min();
        } //EndMethod

        public int? EmptyMin2Rewritten()
        {
            return ArrayItems.Where(x => false).Min();
        } //EndMethod


        [NoRewrite]
        public int? EnumerableMin()
        {
            return EnumerableItems.Min();
        } //EndMethod

        public int? EnumerableMinRewritten()
        {
            return EnumerableItems.Min();
        } //EndMethod

    }
}