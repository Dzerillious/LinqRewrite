using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class CountTests
    {
        [Datapoints]
        private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
        [Datapoints]
        private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);

        public void RunTests()
        {
            ArrayCount().TestEquals(nameof(ArrayCount), ArrayCountRewritten());
            ArrayCount2().TestEquals(nameof(ArrayCount2), ArrayCount2Rewritten());
            ArrayCount3().TestEquals(nameof(ArrayCount3), ArrayCount3Rewritten());
            ArrayCount4().TestEquals(nameof(ArrayCount4), ArrayCount4Rewritten());
            ArrayCount5().TestEquals(nameof(ArrayCount5), ArrayCount5Rewritten());
            EnumerableCount2().TestEquals(nameof(EnumerableCount2), EnumerableCount2Rewritten());
            EnumerableCount3().TestEquals(nameof(EnumerableCount3), EnumerableCount3Rewritten());
            EnumerableCount4().TestEquals(nameof(EnumerableCount4), EnumerableCount4Rewritten());
            EnumerableCount5().TestEquals(nameof(EnumerableCount5), EnumerableCount5Rewritten()); 
        }

        [NoRewrite]
        public int ArrayCount()
        {
            return ArrayItems.Length;
        } //EndMethod

        public int ArrayCountRewritten()
        {
            return ArrayItems.Length;
        } //EndMethod


        [NoRewrite]
        public int ArrayCount2()
        {
            return ArrayItems.Count();
        } //EndMethod

        public int ArrayCount2Rewritten()
        {
            return ArrayItems.Count();
        } //EndMethod


        [NoRewrite]
        public int ArrayCount3()
        {
            return ArrayItems.Count(x => x > 3);
        } //EndMethod

        public int ArrayCount3Rewritten()
        {
            return ArrayItems.Count(x => x > 3);
        } //EndMethod


        [NoRewrite]
        public int ArrayCount4()
        {
            return ArrayItems.Select(x => x + 10).Count();
        } //EndMethod

        public int ArrayCount4Rewritten()
        {
            return ArrayItems.Select(x => x + 10).Count();
        } //EndMethod


        [NoRewrite]
        public int ArrayCount5()
        {
            return ArrayItems.Where(x => x > 4).Count(x => x % 2 == 0);
        } //EndMethod

        public int ArrayCount5Rewritten()
        {
            return ArrayItems.Where(x => x > 4).Count(x => x % 2 == 0);
        } //EndMethod


        [NoRewrite]
        public int EnumerableCount2()
        {
            return EnumerableItems.Count();
        } //EndMethod

        public int EnumerableCount2Rewritten()
        {
            return EnumerableItems.Count();
        } //EndMethod


        [NoRewrite]
        public int EnumerableCount3()
        {
            return EnumerableItems.Count(x => x > 3);
        } //EndMethod

        public int EnumerableCount3Rewritten()
        {
            return EnumerableItems.Count(x => x > 3);
        } //EndMethod


        [NoRewrite]
        public int EnumerableCount4()
        {
            return ArrayItems.Select(x => x + 10).Count();
        } //EndMethod

        public int EnumerableCount4Rewritten()
        {
            return ArrayItems.Select(x => x + 10).Count();
        } //EndMethod


        [NoRewrite]
        public int EnumerableCount5()
        {
            return ArrayItems.Where(x => x > 4).Count(x => x % 2 == 0);
        } //EndMethod

        public int EnumerableCount5Rewritten()
        {
            return ArrayItems.Where(x => x > 4).Count(x => x % 2 == 0);
        } //EndMethod

    }
}