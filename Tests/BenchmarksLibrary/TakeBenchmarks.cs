using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarksLibrary
{
    [MemoryDiagnoser]
    public class TakeBenchmarks
    {
        public int[] ArraySource;
        public IEnumerable<int> EnumerableSource;

        [GlobalSetup]
        public void GlobalSetup()
        {
            ArraySource = Enumerable.Range(0, 1000).ToArray();
            EnumerableSource = Enumerable.Range(0, 1000);
        }


        [Benchmark]
        public void TakeToArrayUnchecked()
        {
            var res = ArraySource.Unchecked().Select(x => x + 2).Take(0).ToArray();
        } //EndMethod

        [Benchmark, LinqRewrite]
		public void TakeToArrayUncheckedRewritten()
        {
            var res = ArraySource.Unchecked().Select(x => x + 2).Take(0).ToArray();
        } //EndMethod


        [Benchmark]
        public void TakeToArray()
        {
            var res = ArraySource.Unchecked().Select(x => x + 2).Take(0).ToArray();
        } //EndMethod

        [Benchmark, LinqRewrite]
		public void TakeToArrayRewritten()
        {
            var res = ArraySource.Select(x => x + 2).Take(0).ToArray();
        } //EndMethod


        [Benchmark]
        public void TakeToArrayUnchecked1()
        {
            var res = ArraySource.Unchecked().Select(x => x + 2).Take(1).ToArray();
        } //EndMethod

        [Benchmark, LinqRewrite(RewriteOptions.Unchecked)]
        public void TakeToArrayUncheckedRewritten1()
        {
            var res = ArraySource.Unchecked().Select(x => x + 2).Take(1).ToArray();
        } //EndMethod


        [Benchmark]
        public void TakeToArray1()
        {
            var res = ArraySource.Select(x => x + 2).Take(1).ToArray();
        } //EndMethod

        [Benchmark, LinqRewrite]
        public void TakeToArrayRewritten1()
        {
            var res = ArraySource.Select(x => x + 2).Take(1).ToArray();
        } //EndMethod


        [Benchmark]
        public void TakeToArrayUnchecked10()
        {
            var res = ArraySource.Unchecked().Take(10).ToArray();
        } //EndMethod

        [Benchmark, LinqRewrite(RewriteOptions.Unchecked)]
        public void TakeToArrayUncheckedRewritten10()
        {
            var res = ArraySource.Unchecked().Take(10).ToArray();
        } //EndMethod


        [Benchmark]
        public void TakeToArray10()
        {
            var res = ArraySource.Take(10).ToArray();
        } //EndMethod

        [Benchmark, LinqRewrite]
        public void TakeToArrayRewritten10()
        {
            var res = ArraySource.Take(10).ToArray();
        } //EndMethod


        [Benchmark]
        public void TakeToArrayUnchecked20()
        {
            var res = ArraySource.Unchecked().Take(20).ToArray();
        } //EndMethod

        [Benchmark, LinqRewrite(RewriteOptions.Unchecked)]
        public void TakeToArrayUncheckedRewritten20()
        {
            var res = ArraySource.Unchecked().Take(20).ToArray();
        } //EndMethod


        [Benchmark]
        public void TakeToArray20()
        {
            var res = ArraySource.Select(x => x + 2).Take(20).ToArray();
        } //EndMethod

        [Benchmark, LinqRewrite]
        public void TakeToArrayRewritten20()
        {
            var res = ArraySource.Select(x => x + 2).Take(20).ToArray();
        } //EndMethod


        [Benchmark]
        public void TakeToArrayUnchecked100()
        {
            var res = ArraySource.Unchecked().Select(x => x + 2).Take(100).ToArray();
        } //EndMethod

        [Benchmark, LinqRewrite(RewriteOptions.Unchecked)]
        public void TakeToArrayUncheckedRewritten100()
        {
            var res = ArraySource.Unchecked().Select(x => x + 2).Take(100).ToArray();
        } //EndMethod


        [Benchmark]
        public void TakeToArray100()
        {
            var res = ArraySource.Unchecked().Take(100).ToArray();
        } //EndMethod

        [Benchmark, LinqRewrite]
        public void TakeToArrayRewritten100()
        {
            var res = ArraySource.Unchecked().Select(x => x + 2).Take(100).ToArray();
        } //EndMethod


        [Benchmark]
        public void EnumerableTakeToArrayUnchecked()
        {
            var res = EnumerableSource.Unchecked().Select(x => x + 2).Take(0).ToArray();
        } //EndMethod

        [Benchmark, LinqRewrite(RewriteOptions.Unchecked)]
		public void EnumerableTakeToArrayUncheckedRewritten()
        {
            var res = EnumerableSource.Unchecked().Select(x => x + 2).Take(0).ToArray();
        } //EndMethod


        [Benchmark]
        public void EnumerableTakeToArray()
        {
            var res = EnumerableSource.Unchecked().Select(x => x + 2).Take(0).ToArray();
        } //EndMethod

        [Benchmark, LinqRewrite]
		public void EnumerableTakeToArrayRewritten()
        {
            var res = EnumerableSource.Select(x => x + 2).Take(0).ToArray();
        } //EndMethod


        [Benchmark]
        public void EnumerableTakeToArrayUnchecked1()
        {
            var res = EnumerableSource.Select(x => x + 2).Take(0).ToArray();
        } //EndMethod

        [Benchmark, LinqRewrite(RewriteOptions.Unchecked)]
        public void EnumerableTakeToArrayUncheckedRewritten1()
        {
            var res = EnumerableSource.Unchecked().Select(x => x + 2).Take(1).ToArray();
        } //EndMethod


        [Benchmark]
        public void EnumerableTakeToArray1()
        {
            var res = EnumerableSource.Select(x => x + 2).Take(1).ToArray();
        } //EndMethod

        [Benchmark, LinqRewrite]
        public void EnumerableTakeToArrayRewritten1()
        {
            var res = EnumerableSource.Select(x => x + 2).Take(1).ToArray();
        } //EndMethod


        [Benchmark]
        public void EnumerableTakeToArrayUnchecked10()
        {
            var res = EnumerableSource.Unchecked().Take(10).ToArray();
        } //EndMethod

        [Benchmark, LinqRewrite(RewriteOptions.Unchecked)]
        public void EnumerableTakeToArrayUncheckedRewritten10()
        {
            var res = EnumerableSource.Unchecked().Take(10).ToArray();
        } //EndMethod


        [Benchmark]
        public void EnumerableTakeToArray10()
        {
            var res = EnumerableSource.Take(10).ToArray();
        } //EndMethod

        [Benchmark, LinqRewrite]
        public void EnumerableTakeToArrayRewritten10()
        {
            var res = EnumerableSource.Take(10).ToArray();
        } //EndMethod


        [Benchmark]
        public void EnumerableTakeToArrayUnchecked20()
        {
            var res = EnumerableSource.Unchecked().Take(20).ToArray();
        } //EndMethod

        [Benchmark, LinqRewrite(RewriteOptions.Unchecked)]
        public void EnumerableTakeToArrayUncheckedRewritten20()
        {
            var res = EnumerableSource.Unchecked().Take(20).ToArray();
        } //EndMethod


        [Benchmark]
        public void EnumerableTakeToArray20()
        {
            var res = EnumerableSource.Select(x => x + 2).Take(20).ToArray();
        } //EndMethod

        [Benchmark, LinqRewrite]
        public void EnumerableTakeToArrayRewritten20()
        {
            var res = EnumerableSource.Select(x => x + 2).Take(20).ToArray();
        } //EndMethod


        [Benchmark]
        public void EnumerableTakeToArrayUnchecked100()
        {
            var res = EnumerableSource.Unchecked().Select(x => x + 2).Take(100).ToArray();
        } //EndMethod

        [Benchmark, LinqRewrite(RewriteOptions.Unchecked)]
        public void EnumerableTakeToArrayUncheckedRewritten100()
        {
            var res = EnumerableSource.Unchecked().Select(x => x + 2).Take(100).ToArray();
        } //EndMethod


        [Benchmark]
        public void EnumerableTakeToArray100()
        {
            var res = EnumerableSource.Unchecked().Take(100).ToArray();
        } //EndMethod

        [Benchmark, LinqRewrite]
        public void EnumerableTakeToArrayRewritten100()
        {
            var res = EnumerableSource.Unchecked().Select(x => x + 2).Take(100).ToArray();
        } //EndMethod

    }
}

