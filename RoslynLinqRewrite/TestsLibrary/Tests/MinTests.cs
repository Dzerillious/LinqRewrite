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
        }

        [NoRewrite]
        public int MinTest1()
        {
            return ArrayItems.Min();
        } //EndMethod

        [NoRewrite]
        public int MinTest2()
        {
            return ArrayItems.Min(x => x + 2);
        } //EndMethod

        [NoRewrite]
        public float MinTest3()
        {
            return ArrayItems.Min(x => x + 2f);
        } //EndMethod

        [NoRewrite]
        public double MinTest4()
        {
            return ArrayItems.Min(x => x + 2d);
        } //EndMethod

        [NoRewrite]
        public decimal MinTest5()
        {
            return ArrayItems.Min(x => x + 2m);
        } //EndMethod

        [NoRewrite]
        public int? MinTest6()
        {
            return ArrayItems.Min(x => x > 10 ? (int?)null : x + 2);
        } //EndMethod

        [NoRewrite]
        public float? MinTest7()
        {
            return ArrayItems.Min(x => x > 10 ? (float?)null : x + 2);
        } //EndMethod

        [NoRewrite]
        public double? MinTest8()
        {
            return ArrayItems.Min(x => x > 10 ? (double?)null : x + 2);
        } //EndMethod

        [NoRewrite]
        public decimal? MinTest9()
        {
            return ArrayItems.Min(x => x > 10 ? (decimal?)null : x + 2);
        } //EndMethod

        [NoRewrite]
        public long MinTest10()
        {
            return ArrayItems.Min(x => x + 2L);
        } //EndMethod

        [NoRewrite]
        public long? MinTest11()
        {
            return ArrayItems.Min(x => x > 10 ? (long?)null : x + 2);
        } //EndMethod

        [NoRewrite]
        public int? MinTest12()
        {
            return ArrayItems.Min(Selector);
        } //EndMethod

        [NoRewrite]
        public int? MinTestParam()
        {
            var a = 10;
            return ArrayItems.Min(x => x + a);
        } //EndMethod

        [NoRewrite]
        public int? MinTestChangingParam()
        {
            var a = 10;
            return ArrayItems.Min(x => x + a++);
        } //EndMethod

        [NoRewrite]
        public int? MinTestChangingParam2()
        {
            var a = 10;
            return ArrayItems.Min(x => x + a--);
        } //EndMethod

        [NoRewrite]
        public int? SelectMinTest()
        {
            var a = 10;
            return ArrayItems.Select(x => x + 3).Min();
        } //EndMethod

        [NoRewrite]
        public int? EmptyMinTest()
        {
            return Enumerable.Empty<int>().Min();
        } //EndMethod

        [NoRewrite]
        public int? EmptyMinTest2()
        {
            return ArrayItems.Where(x => false).Min();
        } //EndMethod

        [NoRewrite]
        public int? EnumerableMinTest()
        {
            return EnumerableItems.Min();
        } //EndMethod
    }
}