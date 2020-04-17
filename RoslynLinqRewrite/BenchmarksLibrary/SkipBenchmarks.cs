using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarkLibrary
{
    public class SkipBenchmarks
    {
        public int[] ArraySource;
        public IEnumerable<int> EnumerableSource;

        [GlobalSetup]
        public void GlobalSetup()
        {
            ArraySource = Enumerable.Range(0, 1000).ToArray();
            EnumerableSource = Enumerable.Range(0, 1000);
        }


        [NoRewrite, Benchmark]
        public void SkipToArrayUnchecked()
        {
            var res = ArraySource.Unchecked().Select(x => x + 2).Skip(900).ToArray();
        } //EndMethod

        [Benchmark]
        public void SkipToArrayUncheckedRewritten()
        {
            var res = ArraySource.Unchecked().Select(x => x + 2).Skip(900).ToArray();
        } //EndMethod


        [NoRewrite, Benchmark]
        public void SkipToArray()
        {
            var res = ArraySource.Unchecked().Select(x => x + 2).Skip(900).ToArray();
        } //EndMethod

        [Benchmark]
        public void SkipToArrayRewritten()
        {
            var res = ArraySource.Select(x => x + 2).Skip(900).ToArray();
        } //EndMethod


        [NoRewrite, Benchmark]
        public void SkipToArrayUnchecked1()
        {
            var res = ArraySource.Unchecked().Select(x => x + 2).ToArray();
        } //EndMethod

        [Benchmark]
        public void SkipToArrayUncheckedRewritten1()
        {
            var res = ArraySource.Unchecked().Select(x => x + 2).Skip(900).ToArray();
        } //EndMethod


        [NoRewrite, Benchmark]
        public void SkipToArray1()
        {
            var res = ArraySource.Select(x => x + 2).Skip(900).ToArray();
        } //EndMethod

        [Benchmark]
        public void SkipToArrayRewritten1()
        {
            var res = ArraySource.Select(x => x + 2).Skip(900).ToArray();
        } //EndMethod


        [NoRewrite, Benchmark]
        public void SkipToArrayUnchecked10()
        {
            var res = ArraySource.Skip(900).Unchecked().ToArray();
        } //EndMethod

        [Benchmark]
        public void SkipToArrayUncheckedRewritten10()
        {
            var res = ArraySource.Skip(900).Unchecked().ToArray();
        } //EndMethod


        [NoRewrite, Benchmark]
        public void SkipToArray10()
        {
            var res = ArraySource.Skip(900).ToArray();
        } //EndMethod

        [Benchmark]
        public void SkipToArrayRewritten10()
        {
            var res = ArraySource.Skip(900).ToArray();
        } //EndMethod


        [NoRewrite, Benchmark]
        public void SkipToArrayUnchecked20()
        {
            var res = ArraySource.Skip(900).Unchecked().ToArray();
        } //EndMethod

        [Benchmark]
        public void SkipToArrayUncheckedRewritten20()
        {
            var res = ArraySource.Skip(900).Unchecked().ToArray();
        } //EndMethod


        [NoRewrite, Benchmark]
        public void SkipToArray20()
        {
            var res = ArraySource.Select(x => x + 2).Skip(900).ToArray();
        } //EndMethod

        [Benchmark]
        public void SkipToArrayRewritten20()
        {
            var res = ArraySource.Select(x => x + 2).Skip(900).ToArray();
        } //EndMethod


        [NoRewrite, Benchmark]
        public void SkipToArrayUnchecked100()
        {
            var res = ArraySource.Unchecked().Select(x => x + 2).Skip(900).ToArray();
        } //EndMethod

        [Benchmark]
        public void SkipToArrayUncheckedRewritten100()
        {
            var res = ArraySource.Unchecked().Select(x => x + 2).Skip(900).ToArray();
        } //EndMethod


        [NoRewrite, Benchmark]
        public void SkipToArray100()
        {
            var res = ArraySource.Unchecked().Skip(900).ToArray();
        } //EndMethod

        [Benchmark]
        public void SkipToArrayRewritten100()
        {
            var res = ArraySource.Unchecked().Select(x => x + 2).Skip(900).ToArray();
        } //EndMethod


        [NoRewrite, Benchmark]
        public void EnumerableSkipToArrayUnchecked()
        {
            var res = EnumerableSource.Unchecked().Select(x => x + 2).Skip(900).ToArray();
        } //EndMethod

        [Benchmark]
        public void EnumerableSkipToArrayUncheckedRewritten()
        {
            var res = EnumerableSource.Unchecked().Select(x => x + 2).Skip(900).ToArray();
        } //EndMethod


        [NoRewrite, Benchmark]
        public void EnumerableSkipToArray()
        {
            var res = EnumerableSource.Unchecked().Select(x => x + 2).Skip(900).ToArray();
        } //EndMethod

        [Benchmark]
        public void EnumerableSkipToArrayRewritten()
        {
            var res = EnumerableSource.Select(x => x + 2).Skip(900).ToArray();
        } //EndMethod


        [NoRewrite, Benchmark]
        public void EnumerableSkipToArrayUnchecked1()
        {
            var res = EnumerableSource.Select(x => x + 2).Skip(900).ToArray();
        } //EndMethod

        [Benchmark]
        public void EnumerableSkipToArrayUncheckedRewritten1()
        {
            var res = EnumerableSource.Unchecked().Select(x => x + 2).Skip(900).ToArray();
        } //EndMethod


        [NoRewrite, Benchmark]
        public void EnumerableSkipToArray1()
        {
            var res = EnumerableSource.Select(x => x + 2).Skip(900).ToArray();
        } //EndMethod

        [Benchmark]
        public void EnumerableSkipToArrayRewritten1()
        {
            var res = EnumerableSource.Select(x => x + 2).Skip(900).ToArray();
        } //EndMethod


        [NoRewrite, Benchmark]
        public void EnumerableSkipToArrayUnchecked10()
        {
            var res = EnumerableSource.Skip(900).Unchecked().ToArray();
        } //EndMethod

        [Benchmark]
        public void EnumerableSkipToArrayUncheckedRewritten10()
        {
            var res = EnumerableSource.Skip(900).Unchecked().ToArray();
        } //EndMethod


        [NoRewrite, Benchmark]
        public void EnumerableSkipToArray10()
        {
            var res = EnumerableSource.Skip(900).ToArray();
        } //EndMethod

        [Benchmark]
        public void EnumerableSkipToArrayRewritten10()
        {
            var res = EnumerableSource.Skip(900).ToArray();
        } //EndMethod


        [NoRewrite, Benchmark]
        public void EnumerableSkipToArrayUnchecked20()
        {
            var res = EnumerableSource.Skip(900).Unchecked().ToArray();
        } //EndMethod

        [Benchmark]
        public void EnumerableSkipToArrayUncheckedRewritten20()
        {
            var res = EnumerableSource.Skip(900).Unchecked().ToArray();
        } //EndMethod


        [NoRewrite, Benchmark]
        public void EnumerableSkipToArray20()
        {
            var res = EnumerableSource.Select(x => x + 2).Skip(900).ToArray();
        } //EndMethod

        [Benchmark]
        public void EnumerableSkipToArrayRewritten20()
        {
            var res = EnumerableSource.Select(x => x + 2).Skip(900).ToArray();
        } //EndMethod


        [NoRewrite, Benchmark]
        public void EnumerableSkipToArrayUnchecked100()
        {
            var res = EnumerableSource.Unchecked().Select(x => x + 2).Skip(900).ToArray();
        } //EndMethod

        [Benchmark]
        public void EnumerableSkipToArrayUncheckedRewritten100()
        {
            var res = EnumerableSource.Unchecked().Select(x => x + 2).Skip(900).ToArray();
        } //EndMethod


        [NoRewrite, Benchmark]
        public void EnumerableSkipToArray100()
        {
            var res = EnumerableSource.Unchecked().Skip(900).ToArray();
        } //EndMethod

        [Benchmark]
        public void EnumerableSkipToArrayRewritten100()
        {
            var res = EnumerableSource.Unchecked().Select(x => x + 2).Skip(900).ToArray();
        } //EndMethod

    }
}

