using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;

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
        public void Skip()
        {
            ArraySource.Skip(300);
        } //EndMethod

		[Benchmark]
        public void SkipRewritten()
        {
            ArraySource.Skip(300);
        } //EndMethod


        [NoRewrite, Benchmark]
        public void SkipToArray()
        {
            ArraySource.Skip(300).ToArray();
        } //EndMethod

		[Benchmark]
        public void SkipToArrayRewritten()
        {
            ArraySource.Skip(300).ToArray();
        } //EndMethod

        
        [NoRewrite, Benchmark]
        public void SkipMultiple()
        {
            ArraySource.Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50);
        } //EndMethod

		[Benchmark]
        public void SkipMultipleRewritten()
        {
            ArraySource.Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50);
        } //EndMethod

        
        [NoRewrite, Benchmark]
        public void SkipMultipleToArray()
        {
            ArraySource.Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50).ToArray();
        } //EndMethod

		[Benchmark]
        public void SkipMultipleToArrayRewritten()
        {
            ArraySource.Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50).ToArray();
        } //EndMethod

        
        [NoRewrite, Benchmark]
        public void EnumerableSkipToArray()
        {
            EnumerableSource.Skip(300).ToArray();
        } //EndMethod

		[Benchmark]
        public void EnumerableSkipToArrayRewritten()
        {
            EnumerableSource.Skip(300).ToArray();
        } //EndMethod

        
        [NoRewrite, Benchmark]
        public void EnumerableSkipMoreToArray()
        {
            EnumerableSource.Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50).ToArray();
        } //EndMethod

		[Benchmark]
        public void EnumerableSkipMoreToArrayRewritten()
        {
            EnumerableSource.Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50)
                .Skip(50).ToArray();
        } //EndMethod

        
        [NoRewrite, Benchmark]
        public void SkipToSimpleList()
        {
            ArraySource.Skip(300).ToSimpleList();
        } //EndMethod

		[Benchmark]
        public void SkipToSimpleListRewritten()
        {
            ArraySource.Skip(300).ToSimpleList();
        } //EndMethod

    }
}

