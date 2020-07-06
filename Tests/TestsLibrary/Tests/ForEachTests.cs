using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class ForEachTests
    {
        [Datapoints]
        private int[] NullItems = null;
        [Datapoints]
        private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
        [Datapoints]
        private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
        
        public void RunTests()
        {
            TestsExtensions.TestEquals(nameof(ArrayForEach), ArrayForEach, ArrayForEachRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableForEach), EnumerableForEach, EnumerableForEachRewritten);
            TestsExtensions.TestEquals(nameof(NullForEach), NullForEach, NullForEachRewritten);
            TestsExtensions.TestEquals(nameof(NullableForEach), NullableForEach, NullableForEachRewritten);
            TestsExtensions.TestEquals(nameof(ArrayChangingParamsForEach), ArrayChangingParamsForEach, ArrayChangingParamsForEachRewritten);
        }

        public int ArrayForEach()
        {
            ArrayItems.ForEach(x => _ = 3);
            return 0;
        } //EndMethod

        [LinqRewrite]
		public int ArrayForEachRewritten()
        {
            ArrayItems.ForEach(x => _ = 3);
            return 0;
        } //EndMethod

        
        public int EnumerableForEach()
        {
            EnumerableItems.ForEach(x => _ = 3);
            return 0;
        } //EndMethod

        [LinqRewrite]
		public int EnumerableForEachRewritten()
        {
            EnumerableItems.ForEach(x => _ = 3);
            return 0;
        } //EndMethod


        public int NullForEach()
        {
            NullItems.ForEach(x => _ = 3);
            return 0;
        } //EndMethod

        [LinqRewrite]
		public int NullForEachRewritten()
        {
            NullItems.ForEach(x => _ = 3);
            return 0;
        } //EndMethod


        public int NullableForEach()
        {
            NullItems?.ForEach(x => _ = 3);
            return 0;
        } //EndMethod

        [LinqRewrite]
		public int NullableForEachRewritten()
        {
            NullItems?.Select(x => x + 3).ForEach(x => _ = 3);
            return 0;
        } //EndMethod


        public int ArrayChangingParamsForEach()
        {
            var a = 0;
            NullItems.ForEach(x => a++);
            return a;
        } //EndMethod

        [LinqRewrite]
		public int ArrayChangingParamsForEachRewritten()
        {
            var a = 0;
            NullItems.ForEach(x => a++);
            return a;
        } //EndMethod

    }
}