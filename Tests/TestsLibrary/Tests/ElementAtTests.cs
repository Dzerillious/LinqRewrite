using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class ElementAtTests
    {
        [Datapoints]
        private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
        [Datapoints]
        private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
        
        public void RunTests()
        {
            TestsExtensions.TestEquals(nameof(ArrayElementAt), ArrayElementAt, ArrayElementAtRewritten);
            TestsExtensions.TestEquals(nameof(ArraySelectElementAt), ArraySelectElementAt, ArraySelectElementAtRewritten);
            TestsExtensions.TestEquals(nameof(ArrayWhereElementAt), ArrayWhereElementAt, ArrayWhereElementAtRewritten);
            TestsExtensions.TestEquals(nameof(ArraySelectWhereElementAt), ArraySelectWhereElementAt, ArraySelectWhereElementAtRewritten);
            TestsExtensions.TestEquals(nameof(ArrayElementAtParam), ArrayElementAtParam, ArrayElementAtParamRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableElementAt), EnumerableElementAt, EnumerableElementAtRewritten);
            TestsExtensions.TestEquals(nameof(ArrayElementAtOut), ArrayElementAtOut, ArrayElementAtOutRewritten);
            TestsExtensions.TestEquals(nameof(ArrayElementAtWhereOut), ArrayElementAtWhereOut, ArrayElementAtWhereOutRewritten);
        }

        public int ArrayElementAt()
        {
            return ArrayItems.ElementAt(23);
        } //EndMethod

        [LinqRewrite]
		public int ArrayElementAtRewritten()
        {
            return ArrayItems.ElementAt(23);
        } //EndMethod


        public int ArraySelectElementAt()
        {
            return ArrayItems.Select(x => x + 20).ElementAt(23);
        } //EndMethod

        [LinqRewrite]
		public int ArraySelectElementAtRewritten()
        {
            return ArrayItems.Select(x => x + 20).ElementAt(23);
        } //EndMethod


        public int ArrayWhereElementAt()
        {
            return ArrayItems.Where(x => x > 30).ElementAt(23);
        } //EndMethod

        [LinqRewrite]
		public int ArrayWhereElementAtRewritten()
        {
            return ArrayItems.Where(x => x > 30).ElementAt(23);
        } //EndMethod


        public int ArraySelectWhereElementAt()
        {
            return ArrayItems.Select(x => x + 30).Where(x => x > 30).ElementAt(23);
        } //EndMethod

        [LinqRewrite]
		public int ArraySelectWhereElementAtRewritten()
        {
            return ArrayItems.Select(x => x + 30).Where(x => x > 30).ElementAt(23);
        } //EndMethod


        public int ArrayElementAtParam()
        {
            var a = 23;
            return ArrayItems.ElementAt(a);
        } //EndMethod

        [LinqRewrite]
		public int ArrayElementAtParamRewritten()
        {
            var a = 23;
            return ArrayItems.ElementAt(a);
        } //EndMethod


        public int EnumerableElementAt()
        {
            return EnumerableItems.ElementAt(23);
        } //EndMethod

        [LinqRewrite]
		public int EnumerableElementAtRewritten()
        {
            return EnumerableItems.ElementAt(23);
        } //EndMethod


        public int ArrayElementAtOut()
        {
            return ArrayItems.ElementAt(20000);
        } //EndMethod

        [LinqRewrite]
		public int ArrayElementAtOutRewritten()
        {
            return ArrayItems.ElementAt(20000);
        } //EndMethod


        public int ArrayElementAtWhereOut()
        {
            return ArrayItems.Where(x => x > 10).ElementAt(20000);
        } //EndMethod

        [LinqRewrite]
		public int ArrayElementAtWhereOutRewritten()
        {
            return ArrayItems.Where(x => x > 10).ElementAt(20000);
        } //EndMethod

    }
}