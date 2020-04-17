﻿using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using LinqRewrite.Core;

namespace BenchmarkLibrary
{
    public class AggregateBenchmarks
    {
        private int[] ArraySource;
        private IEnumerable<int> EnumerableSource;

        [GlobalSetup]
        public void GlobalSetup()
        {
            ArraySource = Enumerable.Range(456, 654).ToArray();
            EnumerableSource = Enumerable.Range(456, 654);
        }
        
        [NoRewrite]
        [Benchmark]
        public double RangeAggregate()
        {
            return Enumerable.Range(567, 675).Aggregate((x, y) => x + y);
        }
        
        [Benchmark]
        public double RangeAggregateToArray()
        {
            return Enumerable.Range(567, 675).Aggregate((x, y) => x + y);
        }
        
        [NoRewrite]
        [Benchmark]
        public double ArrayAggregate5()
        {
            return ArraySource.Unchecked().Take(5).Aggregate((x, y) => x + y);
        }
        
        [Benchmark]
        public double ArrayAggregate5Rewritten()
        {
            return ArraySource.Unchecked().Take(5).Aggregate((x, y) => x + y);
        }
        
        [NoRewrite]
        [Benchmark]
        public double ArrayAggregate10()
        {
            return ArraySource.Unchecked().Take(10).Aggregate((x, y) => x + y);
        }
        
        [Benchmark]
        public double ArrayAggregate10Rewritten()
        {
            return ArraySource.Unchecked().Take(10).Aggregate((x, y) => x + y);
        }
        
        [NoRewrite]
        [Benchmark]
        public double ArrayWhereAggregate10()
        {
            return ArraySource.Where(x =>  x > 600).Aggregate((x, y) => x + y);
        }
        
        [Benchmark]
        public double ArrayWhereAggregateRewritten()
        {
            return ArraySource.Where(x =>  x > 600).Aggregate((x, y) => x + y);
        }
        
        [NoRewrite]
        [Benchmark]
        public double EnumerableAggregate()
        {
            return EnumerableSource.Aggregate((x, y) => x + y);
        }
        
        [Benchmark]
        public double EnumerableAggregateRewritten()
        {
            return EnumerableSource.Aggregate((x, y) => x + y);
        }
    }
}