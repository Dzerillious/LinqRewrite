using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class ElementAtOrDefaultOrDefaultTests
    {
        
        [Datapoints]
        private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
        [Datapoints]
        private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
        
        public void RunTests()
        {
            TestsExtensions.TestEquals(nameof(ArrayElementAtOrDefault), ArrayElementAtOrDefault, ArrayElementAtOrDefaultRewritten);
            TestsExtensions.TestEquals(nameof(ArraySelectElementAtOrDefault), ArraySelectElementAtOrDefault, ArraySelectElementAtOrDefaultRewritten);
            TestsExtensions.TestEquals(nameof(ArrayWhereElementAtOrDefault), ArrayWhereElementAtOrDefault, ArrayWhereElementAtOrDefaultRewritten);
            TestsExtensions.TestEquals(nameof(ArraySelectWhereElementAtOrDefault), ArraySelectWhereElementAtOrDefault, ArraySelectWhereElementAtOrDefaultRewritten);
            TestsExtensions.TestEquals(nameof(ArrayElementAtOrDefaultParam), ArrayElementAtOrDefaultParam, ArrayElementAtOrDefaultParamRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableElementAtOrDefault), EnumerableElementAtOrDefault, EnumerableElementAtOrDefaultRewritten);
            TestsExtensions.TestEquals(nameof(ArrayElementAtOrDefaultOut), ArrayElementAtOrDefaultOut, ArrayElementAtOrDefaultOutRewritten);
            TestsExtensions.TestEquals(nameof(ArrayElementAtOrDefaultWhereOut), ArrayElementAtOrDefaultWhereOut, ArrayElementAtOrDefaultWhereOutRewritten);
        }

        [NoRewrite]
        public int ArrayElementAtOrDefault()
        {
            return ArrayItems.ElementAtOrDefault(23);
        } //EndMethod

        public int ArrayElementAtOrDefaultRewritten()
        {
            return ArrayItems.ElementAtOrDefault(23);
        } //EndMethod


        [NoRewrite]
        public int ArraySelectElementAtOrDefault()
        {
            return ArrayItems.Select(x => x + 20).ElementAtOrDefault(23);
        } //EndMethod

        public int ArraySelectElementAtOrDefaultRewritten()
        {
            return ArrayItems.Select(x => x + 20).ElementAtOrDefault(23);
        } //EndMethod


        [NoRewrite]
        public int ArrayWhereElementAtOrDefault()
        {
            return ArrayItems.Where(x => x > 30).ElementAtOrDefault(23);
        } //EndMethod

        public int ArrayWhereElementAtOrDefaultRewritten()
        {
            return ArrayItems.Where(x => x > 30).ElementAtOrDefault(23);
        } //EndMethod


        [NoRewrite]
        public int ArraySelectWhereElementAtOrDefault()
        {
            return ArrayItems.Select(x => x + 30).Where(x => x > 30).ElementAtOrDefault(23);
        } //EndMethod

        public int ArraySelectWhereElementAtOrDefaultRewritten()
        {
            return ArrayItems.Select(x => x + 30).Where(x => x > 30).ElementAtOrDefault(23);
        } //EndMethod


        [NoRewrite]
        public int ArrayElementAtOrDefaultParam()
        {
            var a = 23;
            return ArrayItems.ElementAtOrDefault(a);
        } //EndMethod

        public int ArrayElementAtOrDefaultParamRewritten()
        {
            var a = 23;
            return ArrayItems.ElementAtOrDefault(a);
        } //EndMethod


        [NoRewrite]
        public int EnumerableElementAtOrDefault()
        {
            return EnumerableItems.ElementAtOrDefault(23);
        } //EndMethod

        public int EnumerableElementAtOrDefaultRewritten()
        {
            return EnumerableItems.ElementAtOrDefault(23);
        } //EndMethod


        [NoRewrite]
        public int ArrayElementAtOrDefaultOut()
        {
            return ArrayItems.ElementAt(20000);
        } //EndMethod

        public int ArrayElementAtOrDefaultOutRewritten()
        {
            return ArrayItems.ElementAt(20000);
        } //EndMethod


        [NoRewrite]
        public int ArrayElementAtOrDefaultWhereOut()
        {
            return ArrayItems.Where(x => x > 10).ElementAt(20000);
        } //EndMethod

        public int ArrayElementAtOrDefaultWhereOutRewritten()
        {
            return ArrayItems.Where(x => x > 10).ElementAt(20000);
        } //EndMethod

    }
}