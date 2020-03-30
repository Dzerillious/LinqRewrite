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
        }

        [NoRewrite]
        public int MaxTest1()
        {
            return ArrayItems.Max();
        } //EndMethod

        [NoRewrite]
        public int MaxTest2()
        {
            return ArrayItems.Max(x => x + 2);
        } //EndMethod

        [NoRewrite]
        public float MaxTest3()
        {
            return ArrayItems.Max(x => x + 2f);
        } //EndMethod

        [NoRewrite]
        public double MaxTest4()
        {
            return ArrayItems.Max(x => x + 2d);
        } //EndMethod

        [NoRewrite]
        public decimal MaxTest5()
        {
            return ArrayItems.Max(x => x + 2m);
        } //EndMethod

        [NoRewrite]
        public int? MaxTest6()
        {
            return ArrayItems.Max(x => x > 10 ? (int?)null : x + 2);
        } //EndMethod

        [NoRewrite]
        public float? MaxTest7()
        {
            return ArrayItems.Max(x => x > 10 ? (float?)null : x + 2);
        } //EndMethod

        [NoRewrite]
        public double? MaxTest8()
        {
            return ArrayItems.Max(x => x > 10 ? (double?)null : x + 2);
        } //EndMethod

        [NoRewrite]
        public decimal? MaxTest9()
        {
            return ArrayItems.Max(x => x > 10 ? (decimal?)null : x + 2);
        } //EndMethod

        [NoRewrite]
        public long MaxTest10()
        {
            return ArrayItems.Max(x => x + 2L);
        } //EndMethod

        [NoRewrite]
        public long? MaxTest11()
        {
            return ArrayItems.Max(x => x > 10 ? (long?)null : x + 2);
        } //EndMethod

        [NoRewrite]
        public int? MaxTest12()
        {
            return ArrayItems.Max(Selector);
        } //EndMethod

        [NoRewrite]
        public int? MaxTestParam()
        {
            var a = 10;
            return ArrayItems.Max(x => x + a);
        } //EndMethod

        [NoRewrite]
        public int? MaxTestChangingParam()
        {
            var a = 10;
            return ArrayItems.Max(x => x + a++);
        } //EndMethod

        [NoRewrite]
        public int? MaxTestChangingParam2()
        {
            var a = 10;
            return ArrayItems.Max(x => x + a--);
        } //EndMethod

        [NoRewrite]
        public int? SelectMaxTest()
        {
            var a = 10;
            return ArrayItems.Select(x => x + 3).Max();
        } //EndMethod

        [NoRewrite]
        public int? EmptyMaxTest()
        {
            return Enumerable.Empty<int>().Max();
        } //EndMethod

        [NoRewrite]
        public int? EmptyMaxTest2()
        {
            return ArrayItems.Where(x => false).Max();
        } //EndMethod

        [NoRewrite]
        public int? EnumerableMaxTest()
        {
            return EnumerableItems.Max();
        } //EndMethod
    }
}