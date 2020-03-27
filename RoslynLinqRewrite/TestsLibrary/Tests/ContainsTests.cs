using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class IntStrangeComparer : IEqualityComparer<int>
    {
        public bool Equals(int x, int y)
        {
            return x > y;
        }

        public int GetHashCode(int obj)
        {
            return obj;
        }
    }
    
    public class ContainsTests
    {
        [Datapoints]
        private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
        [Datapoints]
        private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
        
        public void RunTests()
        {
            ArrayContains().TestEquals(nameof(ArrayContains), ArrayContainsRewritten());
            ArrayContains2().TestEquals(nameof(ArrayContains2), ArrayContains2Rewritten());
            ArrayContains3().TestEquals(nameof(ArrayContains3), ArrayContains3Rewritten());
            ArraySelectContains().TestEquals(nameof(ArraySelectContains), ArraySelectContainsRewritten());
            ArraySelectContains2().TestEquals(nameof(ArraySelectContains2), ArraySelectContains2Rewritten());
            ArraySelectContains3().TestEquals(nameof(ArraySelectContains3), ArraySelectContains3Rewritten());
            ArrayWhereContains().TestEquals(nameof(ArrayWhereContains), ArrayWhereContainsRewritten());
            ArrayWhereContains2().TestEquals(nameof(ArrayWhereContains2), ArrayWhereContains2Rewritten());
            ArrayWhereContains3().TestEquals(nameof(ArrayWhereContains3), ArrayWhereContains3Rewritten());
            EnumerableContains().TestEquals(nameof(EnumerableContains), EnumerableContainsRewritten());
            EnumerableContains2().TestEquals(nameof(EnumerableContains2), EnumerableContains2Rewritten());
            EnumerableContains3().TestEquals(nameof(EnumerableContains3), EnumerableContains3Rewritten());
        }

        [NoRewrite]
        public bool ArrayContains()
        {
            return ArrayItems.Contains(23);
        } //EndMethod

        public bool ArrayContainsRewritten()
        {
            return ArrayItems.Contains(23);
        } //EndMethod


        [NoRewrite]
        public bool ArrayContains2()
        {
            return ArrayItems.Contains(23, EqualityComparer<int>.Default);
        } //EndMethod
        
        public bool ArrayContains2Rewritten()
        {
            return ArrayItems.Contains(23, EqualityComparer<int>.Default);
        } //EndMethod
        
        
        [NoRewrite]
        public bool ArrayContains3()
        {
            return ArrayItems.Contains(23, new IntStrangeComparer());
        } //EndMethod
        
        public bool ArrayContains3Rewritten()
        {
            return ArrayItems.Contains(23, new IntStrangeComparer());
        } //EndMethod
        
        
        [NoRewrite]
        public bool ArraySelectContains()
        {
            return ArrayItems.Select(x => x + 5).Contains(23);
        } //EndMethod
        
        public bool ArraySelectContainsRewritten()
        {
            return ArrayItems.Select(x => x + 5).Contains(23);
        } //EndMethod
        
        
        [NoRewrite]
        public bool ArraySelectContains2()
        {
            return ArrayItems.Select(x => x + 5).Contains(23, EqualityComparer<int>.Default);
        } //EndMethod
        
        public bool ArraySelectContains2Rewritten()
        {
            return ArrayItems.Select(x => x + 5).Contains(23, EqualityComparer<int>.Default);
        } //EndMethod
        
        
        [NoRewrite]
        public bool ArraySelectContains3()
        {
            return ArrayItems.Select(x => x + 5).Contains(23, new IntStrangeComparer());
        } //EndMethod
        
        public bool ArraySelectContains3Rewritten()
        {
            return ArrayItems.Select(x => x + 5).Contains(23, new IntStrangeComparer());
        } //EndMethod
        
        
        [NoRewrite]
        public bool ArrayWhereContains()
        {
            return ArrayItems.Where(x => x > 20).Contains(23);
        } //EndMethod
        
        public bool ArrayWhereContainsRewritten()
        {
            return ArrayItems.Where(x => x > 20).Contains(23);
        } //EndMethod
        
        
        [NoRewrite]
        public bool ArrayWhereContains2()
        {
            return ArrayItems.Where(x => x > 20).Contains(23, EqualityComparer<int>.Default);
        } //EndMethod
        
        public bool ArrayWhereContains2Rewritten()
        {
            return ArrayItems.Where(x => x > 20).Contains(23, EqualityComparer<int>.Default);
        } //EndMethod
        
        
        [NoRewrite]
        public bool ArrayWhereContains3()
        {
            return ArrayItems.Where(x => x > 20).Contains(23, new IntStrangeComparer());
        } //EndMethod
        
        public bool ArrayWhereContains3Rewritten()
        {
            return ArrayItems.Where(x => x > 20).Contains(23, new IntStrangeComparer());
        } //EndMethod
        
        
        [NoRewrite]
        public bool EnumerableContains()
        {
            return EnumerableItems.Contains(23);
        } //EndMethod
        
        public bool EnumerableContainsRewritten()
        {
            return EnumerableItems.Contains(23);
        } //EndMethod
        
        
        [NoRewrite]
        public bool EnumerableContains2()
        {
            return EnumerableItems.Contains(23, EqualityComparer<int>.Default);
        } //EndMethod
        
        public bool EnumerableContains2Rewritten()
        {
            return EnumerableItems.Contains(23, EqualityComparer<int>.Default);
        } //EndMethod
        
        
        [NoRewrite]
        public bool EnumerableContains3()
        {
            return EnumerableItems.Contains(23, new IntStrangeComparer());
        } //EndMethod
        
        public bool EnumerableContains3Rewritten()
        {
            return EnumerableItems.Contains(23, new IntStrangeComparer());
        } //EndMethod

    }
}