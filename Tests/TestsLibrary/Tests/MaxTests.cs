using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class MaxTests
    {
        
        [Datapoints]
        private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
        [Datapoints]
        private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);

        private int Selector(int value) => value + 50;
        
        public void RunTests()
        {
            TestsExtensions.TestEquals(nameof(Max1), Max1, Max1Rewritten);
            TestsExtensions.TestEquals(nameof(Max2), Max2, Max2Rewritten);
            TestsExtensions.TestEquals(nameof(Max3), Max3, Max3Rewritten);
            TestsExtensions.TestEquals(nameof(Max4), Max4, Max4Rewritten);
            TestsExtensions.TestEquals(nameof(Max5), Max5, Max5Rewritten);
            TestsExtensions.TestEquals(nameof(Max6), Max6, Max6Rewritten);
            TestsExtensions.TestEquals(nameof(Max7), Max7, Max7Rewritten);
            TestsExtensions.TestEquals(nameof(Max8), Max8, Max8Rewritten);
            TestsExtensions.TestEquals(nameof(Max9), Max9, Max9Rewritten);
            TestsExtensions.TestEquals(nameof(Max10), Max10, Max10Rewritten);
            TestsExtensions.TestEquals(nameof(Max11), Max11, Max11Rewritten);
            TestsExtensions.TestEquals(nameof(Max12), Max12, Max12Rewritten);
            TestsExtensions.TestEquals(nameof(MaxParam), MaxParam, MaxParamRewritten);
            TestsExtensions.TestEquals(nameof(MaxChangingParam), MaxChangingParam, MaxChangingParamRewritten);
            TestsExtensions.TestEquals(nameof(MaxChangingParam2), MaxChangingParam2, MaxChangingParam2Rewritten);
            TestsExtensions.TestEquals(nameof(SelectMax), SelectMax, SelectMaxRewritten);
            TestsExtensions.TestEquals(nameof(EmptyMax), EmptyMax, EmptyMaxRewritten);
            TestsExtensions.TestEquals(nameof(EmptyMax2), EmptyMax2, EmptyMax2Rewritten);
            TestsExtensions.TestEquals(nameof(EnumerableMax), EnumerableMax, EnumerableMaxRewritten);
        }

        public int Max1()
        {
            return ArrayItems.Max();
        } //EndMethod

        [LinqRewrite]
		public int Max1Rewritten()
        {
            return ArrayItems.Max();
        } //EndMethod


        public int Max2()
        {
            return ArrayItems.Max(x => x + 2);
        } //EndMethod

        [LinqRewrite]
		public int Max2Rewritten()
        {
            return ArrayItems.Max(x => x + 2);
        } //EndMethod


        public float Max3()
        {
            return ArrayItems.Max(x => x + 2f);
        } //EndMethod

        [LinqRewrite]
		public float Max3Rewritten()
        {
            return ArrayItems.Max(x => x + 2f);
        } //EndMethod


        public double Max4()
        {
            return ArrayItems.Max(x => x + 2d);
        } //EndMethod

        [LinqRewrite]
		public double Max4Rewritten()
        {
            return ArrayItems.Max(x => x + 2d);
        } //EndMethod


        public decimal Max5()
        {
            return ArrayItems.Max(x => x + 2m);
        } //EndMethod

        [LinqRewrite]
		public decimal Max5Rewritten()
        {
            return ArrayItems.Max(x => x + 2m);
        } //EndMethod


        public int? Max6()
        {
            return ArrayItems.Max(x => x > 10 ? (int?)null : x + 2);
        } //EndMethod

        [LinqRewrite]
		public int? Max6Rewritten()
        {
            return ArrayItems.Max(x => x > 10 ? (int?)null : x + 2);
        } //EndMethod


        public float? Max7()
        {
            return ArrayItems.Max(x => x > 10 ? (float?)null : x + 2);
        } //EndMethod

        [LinqRewrite]
		public float? Max7Rewritten()
        {
            return ArrayItems.Max(x => x > 10 ? (float?)null : x + 2);
        } //EndMethod


        public double? Max8()
        {
            return ArrayItems.Max(x => x > 10 ? (double?)null : x + 2);
        } //EndMethod

        [LinqRewrite]
		public double? Max8Rewritten()
        {
            return ArrayItems.Max(x => x > 10 ? (double?)null : x + 2);
        } //EndMethod


        public decimal? Max9()
        {
            return ArrayItems.Max(x => x > 10 ? (decimal?)null : x + 2);
        } //EndMethod

        [LinqRewrite]
		public decimal? Max9Rewritten()
        {
            return ArrayItems.Max(x => x > 10 ? (decimal?)null : x + 2);
        } //EndMethod


        public long Max10()
        {
            return ArrayItems.Max(x => x + 2L);
        } //EndMethod

        [LinqRewrite]
		public long Max10Rewritten()
        {
            return ArrayItems.Max(x => x + 2L);
        } //EndMethod


        public long? Max11()
        {
            return ArrayItems.Max(x => x > 10 ? (long?)null : x + 2);
        } //EndMethod

        [LinqRewrite]
		public long? Max11Rewritten()
        {
            return ArrayItems.Max(x => x > 10 ? (long?)null : x + 2);
        } //EndMethod


        public int? Max12()
        {
            return ArrayItems.Max(Selector);
        } //EndMethod

        [LinqRewrite]
		public int? Max12Rewritten()
        {
            return ArrayItems.Max(Selector);
        } //EndMethod


        public int? MaxParam()
        {
            var a = 10;
            return ArrayItems.Max(x => x + a);
        } //EndMethod

        [LinqRewrite]
		public int? MaxParamRewritten()
        {
            var a = 10;
            return ArrayItems.Max(x => x + a);
        } //EndMethod


        public int? MaxChangingParam()
        {
            var a = 10;
            return ArrayItems.Max(x => x + a++);
        } //EndMethod

        [LinqRewrite]
		public int? MaxChangingParamRewritten()
        {
            var a = 10;
            return ArrayItems.Max(x => x + a++);
        } //EndMethod


        public int? MaxChangingParam2()
        {
            var a = 10;
            return ArrayItems.Max(x => x + a--);
        } //EndMethod

        [LinqRewrite]
		public int? MaxChangingParam2Rewritten()
        {
            var a = 10;
            return ArrayItems.Max(x => x + a--);
        } //EndMethod


        public int? SelectMax()
        {
            var a = 10;
            return ArrayItems.Select(x => x + 3).Max();
        } //EndMethod

        [LinqRewrite]
		public int? SelectMaxRewritten()
        {
            var a = 10;
            return ArrayItems.Select(x => x + 3).Max();
        } //EndMethod


        public int? EmptyMax()
        {
            return Enumerable.Empty<int>().Max();
        } //EndMethod

        [LinqRewrite]
		public int? EmptyMaxRewritten()
        {
            return Enumerable.Empty<int>().Max();
        } //EndMethod


        public int? EmptyMax2()
        {
            return ArrayItems.Where(x => false).Max();
        } //EndMethod

        [LinqRewrite]
		public int? EmptyMax2Rewritten()
        {
            return ArrayItems.Where(x => false).Max();
        } //EndMethod


        public int? EnumerableMax()
        {
            return EnumerableItems.Max();
        } //EndMethod

        [LinqRewrite]
		public int? EnumerableMaxRewritten()
        {
            return EnumerableItems.Max();
        } //EndMethod

    }
}